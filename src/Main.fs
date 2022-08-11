module Main

open Feliz
open App
open Browser.Dom
open Fable.Core.JsInterop

importSideEffects "./styles/global.sass"

open App
open Elmish
open Elmish.React
open WorkItemTracking
open WorkItemTrackingClient
open CommonServices
open UI.Konva
open Fable.Core

let sdk = SDK.sdk;

type 't Deferred =
    | NotStarted
    | InProgress
    | Ready of Result<'t, string>
type 't OperationTransition = Started | Finished of Result<'t, string>
let receive = function
    | Started -> InProgress
    | Finished result -> Ready result
type DisplayOrganization = ByBucket | ByDeliverable
type QueryResult = {
    workItems: WorkItem list
    deliverables: Map<int, WorkItem>
    }
type ProgressStatus = OK | Warning of float | AtRisk of float
type EditMode = NotEditing | SelectingDependency of WorkItem Assignment
type Selection =
    | WorkItemSelection of WorkItem Assignment
    | DeliverableSelection of WorkItem
type Msg =
    | SetWiql of string
    | Message of string
    | SdkInitializationMsg of string OperationTransition
    | Query of QueryResult OperationTransition
    | SetPAT of string
    | SetServerOverrideURL of string
    | ToggleHelp
    | ToggleSettings
    | SetDisplayOrganization of DisplayOrganization
    | Select of Selection
    | SelectDependency
    | CancelDependencySelect
    | SetHasUnsavedChanges of bool
type Model = {
    userName: string Deferred
    wiql: string
    userFacingMessage: string option;
    ready: bool;
    query: QueryResult Deferred
    assignments: WorkItem Assignment list
    dropped: WorkItem list
    ctx: WorkItem AssignmentContext option
    serverUrlOverride: string option
    pat: string option
    showHelpScreen: bool
    showSettings: bool
    displayOrganization: DisplayOrganization
    selectedItem: Selection option
    editMode: EditMode
    hasUnsavedChanges: bool
    }
    with
    static member fresh = { userName = NotStarted; userFacingMessage = None; ready = true; query = NotStarted; wiql = ""; assignments = []; dropped = []; ctx = None; serverUrlOverride = None; pat = None; showHelpScreen = false; showSettings = false; displayOrganization = ByDeliverable; selectedItem = None; editMode = NotEditing; hasUnsavedChanges = false }

let asyncOperation dispatch opMsg impl = promise {
    try
        Started |> opMsg |> dispatch
        let! result = impl()
        Finished (Ok result) |> opMsg |> dispatch
    with err ->
        Finished (Error $"{err}") |> opMsg |> dispatch
    }

let initializeSdk() = promise {
    do! sdk.init()
    return sdk.getUser().name
    }

module ResizeArray =
    let map f input =
        input |> Seq.map f |> ResizeArray

module Properties =
    let get<'t> fieldName (item:WorkItem) =
        match item.fields[fieldName] with
        | Some v ->
            try
                unbox<'t> v |> Some
            with _ -> None
        | None -> None
    let getId (workItem: WorkItem) = workItem.id
    let getOwner item : string option = item |> get "System.AssignedTo" |> Option.map (fun p -> p?displayName)
    let getRemainingWork item =
        item |> get<float> "Microsoft.VSTS.Scheduling.RemainingWork"
        |> (function None -> item |> get "OSG.RemainingDays" | otherwise -> otherwise)
        |> Option.defaultValue 1.
        |> (fun w -> w * 1.<dayCost>)
    let getTitle = get<string> "System.Title" >> Option.defaultValue "Untitled"
    let getDeliverableId = get<int option> "System.Parent" >> Option.flatten >> Option.defaultValue 0
    let getWorkItemType = get<string> "System.WorkItemType"
    let getPriority item =
        match get<int> "Microsoft.VSTS.Common.Priority" item with
        | Some pri -> float pri
        | None -> match getWorkItemType item with | Some "Task" | Some "Deliverable" -> 2.0 | _ -> 2.0
    let getDueDate = get<System.DateTime> "Microsoft.VSTS.Scheduling.DueDate"
    let getPrioritization = (fun (i:WorkItem) ->
        // treat work items as less important than P1 bugs and equal to P2
        let pri = getPriority i

        // also respect DueDate as a secondary ordering factor
        let due = getDueDate i
        pri, due
        )
    let getFinalNumber (url: string) =
        let result = System.Text.RegularExpressions.Regex.Match(url, "([0-9]+)$")
        if result.Success then
            result.Groups.[1].Value |> System.Int32.Parse
        else
            failwith $"{url} does not end in a number"
    let getDependencies (workItem: WorkItem) =
        if workItem.relations = null then []
        else
            [for rel in workItem.relations do
                match rel.attributes["name"] |> string with
                | "Dependent On" | "Predecessor" ->
                    rel.url |> getFinalNumber
                | _ -> ()
                ] |> List.distinct

open Properties

let makeContext (items: WorkItem seq) : _ AssignmentContext =
    // todo: make this real
    let capacityStub (ctx: _ AssignmentContext) (bucket: string) (startTime: float<realDay>): float<dayCost/realDay> =
        let ratio = match bucket with "sasiy" -> 0.4<dayCost/realDay> | _ -> 0.7<dayCost/realDay>
        match (ctx.startTime.AddDays (int startTime)).DayOfWeek |> int with
        | 0 | 6 -> 0.<dayCost/realDay> // not Saturday/Sunday. For some reason can't refer directly to Saturday/Sunday.
        | _ ->
            ratio

    let getBucket = getOwner
    {
        startTime = System.DateTime.Now.Date
        buckets = items |> Seq.map getBucket |> Seq.filter Option.isSome |> Seq.map Option.get |> List.ofSeq // todo: find a better way than filter
        capacityCoefficient = capacityStub // todo: make this real
        prioritize = fun items -> items |> List.sortBy getPrioritization
        getId = getId
        getDependencies = getDependencies
        getBucket = getBucket
        getCost = getRemainingWork
        getDeliverable = getDeliverableId
        }

let options(address:string option, pat) =
    jsOptions<Client.IVssRestClientOptions>(fun options ->
        match address, pat with
        | Some address, Some pat ->
            options.rootPath <- Some (Fable.Core.Case1 address)
            options.authTokenProvider <- Some { new Context.IAuthorizationTokenProvider with
                                                    member this.getAuthorizationHeader(forceRefresh: bool option): Fable.Core.JS.Promise<string> =
                                                        promise {
                                                            return "basic " + System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(":"+pat))
                                                            }
                                                        }
        | _ -> ()
        )

let getWorkClient options = promise {
    return Client.exports.getClient<WorkItemTrackingClient.WorkItemTrackingRestClient>(unbox WorkItemTrackingClient.exports.WorkItemTrackingRestClient, options)
    }

let getTeam (project:IProjectInfo) options = promise {
    let coreClient = Client.exports.getClient<CoreClient.CoreRestClient>(unbox CoreClient.exports.CoreRestClient, options)
    let! teams = coreClient.getTeams(project.id,true,1) // in theory you should be able to query teams you're not on but for perf sake right now we don't allow it
    if teams.Count > 0 then
        return teams[0] // TODO: make this more robust for people who belong to multiple teams. Pull the data from the query to figure out which team is relevant.
    else
        return failwith "Could not determine a unique team for current user. Ask Max to add this as a feature."
    }

let getIterations options = promise {
    let! projectService = sdk.getService<IProjectPageService>(CommonServiceIds.ProjectPageService)
    let! project = projectService.getProject()
    let! team = getTeam project.Value options
    let teamCtx : Core.TeamContext = !! {|
        project = project.Value.name // TODO: again, make more robust by pulling data from query.
        projectId = project.Value.id
        team = team.name
        teamId = team.id
        |}
    let client = Client.exports.getClient<WorkClient.WorkRestClient>(unbox WorkClient.exports.WorkRestClient, options)
    let! iterations = client.getTeamIterations(teamCtx)
    return team, iterations
    }

let getWorkItems options (wiql) = promise {
    try
        let! i = getIterations options
        printfn "getIterations result: %A" i
    with err ->
        printfn "getIterations error: %A" err
    let query = jsOptions<Wiql>(fun o ->
        o.query <- wiql)
    let! client = getWorkClient options
    let! wiqlResult = client.queryByWiql(query)
    if wiqlResult.workItems.Count = 0 then
        return { QueryResult.workItems = []; deliverables = Map.empty }
    else
        let! details = client.getWorkItems(wiqlResult.workItems |> ResizeArray.map (fun ref -> ref.id), expand=WorkItemExpand.All) |> Promise.map List.ofSeq
        let deliverableIds = details |> List.map getDeliverableId |> List.distinct
        let! deliverables = client.getWorkItems(deliverableIds |> List.filter (fun id -> id > 0) |> ResizeArray) |> Promise.map List.ofSeq
        let deliverablesById = deliverables |> List.collect (fun wi -> [wi.id, wi]) |> Map.ofList
        return { QueryResult.workItems = details; deliverables = deliverablesById }
    }

let getProgressStatus (ctx: _ AssignmentContext) (asn: WorkItem Assignment) =
    match asn.underlying |> getDueDate with
    | Some dueDate ->
        let finishTime = ctx.startTime.AddDays(asn.startTime + asn.duration |> float)
        let percentOverdue =
            let dueDateInRealDays = (dueDate - ctx.startTime).TotalDays * 1.<realDay>
            ((asn.startTime + asn.duration) - dueDateInRealDays)/asn.duration |> min 1.
        if finishTime < dueDate then
            OK
        elif finishTime < dueDate.AddDays(1) then
            Warning percentOverdue
        else
            AtRisk percentOverdue
    | None -> OK

let addDependency (target: WorkItem Assignment) (dependency: WorkItem Assignment) (queryResult: QueryResult) =

    queryResult

let saveChanges (model:Model) dispatch =
    promise {
        dispatch (SetHasUnsavedChanges false)
    } |> Promise.start

let init _ = { Model.fresh with pat = LocalStorage.PAT.read(); serverUrlOverride = LocalStorage.ServerUrlOverride.read() }
let update msg model =
    match msg with
    | Message msg -> { model with userFacingMessage = msg |> Some }
    | Query op ->
        let model = { model with query = receive op }
        match model.query with
        | Ready(Ok queryResult) ->
            let ctx = makeContext queryResult.workItems
            let asn, dropped = Extensions.assignments ctx queryResult.workItems
            { model with ctx = Some ctx; assignments = asn; dropped = dropped }
        | _ -> model
    | SdkInitializationMsg op -> { model with userName = receive op; wiql = Extensions.LocalStorage.Wiql.read() }
    | SetWiql wiql ->
        LocalStorage.Wiql.write wiql
        { model with wiql = wiql }
    | SetPAT pat ->
        let pat = if pat.Trim().Length > 0 then Some (pat.Trim()) else None
        LocalStorage.PAT.write pat
        { model with pat = pat }
    | SetServerOverrideURL url ->
        let url = if url.Trim().Length > 0 then Some (url.Trim()) else None
        LocalStorage.ServerUrlOverride.write url
        { model with serverUrlOverride = url }
    | ToggleHelp ->
        { model with showHelpScreen = not model.showHelpScreen }
    | ToggleSettings ->
        { model with showSettings = not model.showSettings }
    | SetDisplayOrganization displayOrganization ->
        { model with displayOrganization = displayOrganization }
    | Select workItemAssignment ->
        // SELECT is a user action which has different effects in different modes (not sure if I love that idea, but for now...)
        // When we're selecting dependencies, it adds a new dependency, clears edit mode, and recomputes assignments, while preserving the currently-selected item.
        // Otherwise, it changes what the currently-selected item is (which affects detail display at the bottom of the screen).
        match model.editMode, workItemAssignment, model.query with
        | EditMode.SelectingDependency target, (WorkItemSelection asn), Ready (Ok queryResult) ->
            // update the source of truth
            let queryResult = queryResult |> addDependency target asn
            let ctx = makeContext queryResult.workItems
            let asn', dropped = Extensions.assignments ctx queryResult.workItems
            // for UX reasons, preserve selection (up to underlying id)
            let selection' = asn' |> List.tryFind (fun a -> a.underlying.id = asn.underlying.id) |> Option.map (WorkItemSelection)
            { model with ctx = Some ctx; assignments = asn'; dropped = dropped; editMode = EditMode.NotEditing; selectedItem = selection'; hasUnsavedChanges = true; query = Ready (Ok queryResult) }
        | _ ->
            { model with selectedItem = workItemAssignment |> Some }
    | SetHasUnsavedChanges v ->
        { model with hasUnsavedChanges = v }
    | CancelDependencySelect ->
        { model with editMode = EditMode.NotEditing }
    | SelectDependency ->
        { model with editMode = match model.selectedItem with | Some (WorkItemSelection asn) -> EditMode.SelectingDependency asn | _ -> model.editMode }

let viewAssignments (ctx: WorkItem AssignmentContext) (deliverables: Map<int, WorkItem>) (work: WorkItem Assignment list) (dropped: WorkItem list) org dispatch =
    let height = 20
    let bucketWidth = 200
    let width = 50
    let margin = 10.
    let headerHeight = height
    let timeRatio = (float width/1.<realDay>)
    let yCoord, (rows : (BucketId * int * (_ -> unit)) list) =
        match org with
        | ByBucket ->
            let rows = work |> List.map (fun w -> w.bucketId) |> List.distinct |> List.sort
            let yCoord (asn: _ Assignment) =
                let ix = rows |> List.findIndex ((=) asn.bucketId)
                headerHeight + ix * height
            yCoord, rows |> List.map (fun row -> row, 1, ignore)
        | ByDeliverable ->
            let getDeliverableId w = w.underlying |> getDeliverableId
            let getDeliverable deliverableId =
                deliverables |> Map.tryFind deliverableId
            let rows =
                work
                |> List.map (fun wi ->
                                let parentId = getDeliverableId wi
                                let onClick dispatch =
                                    match deliverables |> Map.tryFind parentId with
                                    | Some deliverable ->
                                        DeliverableSelection deliverable |> Select |> dispatch
                                    | None -> ()
                                let height = work |> List.filter (fun wi -> getDeliverableId wi = parentId) |> List.map (fun wi -> wi.resourceRow) |> List.max
                                {| workItem = wi; parentId = parentId; height = height; onClick = onClick |})
                |> List.distinctBy (fun row -> row.parentId)
                |> List.sortBy (fun row -> row.parentId)
            let yCoord (asn: _ Assignment) =
                let parent = asn |> getDeliverableId
                let ix = rows |> List.findIndex (fun row -> row.parentId = parent)
                let rowHeight = asn.resourceRow + (rows |> List.take ix |> List.sumBy (fun wi -> wi.height))
                rowHeight * height
            yCoord, rows |> List.map (fun row -> match deliverables |> Map.tryFind row.parentId with Some workItem -> (getTitle workItem, row.height, row.onClick) | None -> (row.parentId |> toString, 1, row.onClick))
    let msg (item: WorkItem) =
        getTitle item
    let date (asn: _ Assignment) msg =
        $"""{ctx.startTime.AddDays(asn.startTime |> float).ToString("MM/dd")} {msg}"""
    let stageHeight = headerHeight + (((rows |> List.sumBy (fun (_,height,_) -> height)) + dropped.Length) * height)
    let stageWidth = (match work with [] -> 0. | _ -> ((work |> List.map (fun w -> w.startTime + w.duration)) |> List.max) * timeRatio + (float width) + 0.)
    let class' ctor (className:string) elements =
        ctor (prop.className className::elements)
    let startLeft = bucketWidth + 20
    class' Html.div "stage" [
        prop.style [
            style.width (int stageWidth)
            style.height stageHeight
            ]
        prop.children [
            let maxDaySpan = if work.IsEmpty then 0.<realDay> else (work |> List.map (fun wi -> (wi.startTime + wi.duration)) |> List.max)
            for x in (0.<realDay>)..1.<realDay>..(maxDaySpan) do
                let day = ctx.startTime.AddDays(x |> float)
                let startX = (startLeft + (x * timeRatio |> int))
                Html.div [
                    prop.className "header"
                    prop.style [
                        style.top 0
                        style.left startX
                        style.height stageHeight
                        style.borderLeft(2, borderStyle.solid, color.black)
                        ]
                    prop.text $"""{day.ToString("M/d")}"""
                    ]
                let verticalLineAt (xPos: int) =
                    Html.div [
                        prop.className "divider"
                        prop.style [
                            style.top 0
                            style.left xPos
                            style.height stageHeight
                            style.borderLeft(2, borderStyle.solid, color.black)
                            ]
                        ]
                verticalLineAt startX
                match day.DayOfWeek |> int with
                | 6 | 0 -> // Saturday, Sunday
                    // draw some blue shade for weekends to visually distinguish them
                    Html.div [
                        prop.className "divider"
                        prop.style [
                            style.top 0
                            style.left startX
                            style.height stageHeight
                            style.width width
                            style.opacity 0.22
                            style.backgroundColor.blue
                            ]
                        ]
                | dayOfWeek ->
                    ()
            let mutable rowTop = 0
            for ix, (row, rowHeight, onclick) in rows |> List.mapi tup2 do
                Html.input [
                    prop.className "bucket"
                    prop.style [
                        style.top (headerHeight + rowTop * height)
                        style.left 0
                        style.width bucketWidth
                        ]
                    prop.value row
                    prop.readOnly true
                    prop.onClick (fun _ -> onclick dispatch)
                    ]
                rowTop <- rowHeight + rowTop
            for asn in work do
                let item = asn.underlying
                Html.input [
                    prop.className "item"
                    prop.style [
                        style.top (yCoord asn)
                        style.left ((asn.startTime * timeRatio |> int) + startLeft)
                        style.width (asn.duration * timeRatio - margin |> int)
                        match asn |> getProgressStatus ctx with
                        | AtRisk percentOverdue ->
                            let percent = (100. - percentOverdue * 100.) |> int
                            style.backgroundImage $"linear-gradient(to right, blue, blue {percent}%%, red {percent}%%, red 100%%)"
                        | Warning percentOverdue ->
                            let percent = (100. - percentOverdue * 100.) |> int
                            style.backgroundImage $"linear-gradient(to right, blue, blue {percent}%%, yellow {percent}%%, yellow 100%%)"
                            if percent < 30 then style.color.black
                        | _ -> ()
                        ]
                    prop.value (msg item)
                    prop.readOnly true
                    prop.onClick (thunk1 dispatch (Select (WorkItemSelection asn)))
                    ]
            for ix, item in dropped |> List.mapi tup2 do
                Html.span [
                    prop.className "dropped"
                    prop.style [
                        style.top (height * (ix + rows.Length))
                        style.left width
                        ]
                    prop.text (msg item)
                    ]
            ]
        ]

[<Emit("typeof $0")>]
let jsTypeof (_ : obj) : string = jsNative
[<Emit("$0[$1]")>]
let jsLookup (_ : obj) (key:string) : obj option = jsNative
[<Emit("$0 instanceof Date")>]
let isJSDate (_ : obj) : bool = jsNative

let viewDetails (workItems: WorkItem list) linkBase = [
    for item in workItems do
        let whom = getOwner item
        let typ = match item.fields["System.WorkItemType"] with | Some typ -> unbox<string> typ | None -> "None"
        Html.div [
            prop.key $"WorkItem{item.id}"
            prop.children [
                    let link (indent: int) (msg: string) href =
                        Html.a [
                            prop.text msg
                            prop.style [style.marginLeft indent]
                            prop.href href
                            ]
                    let emit (indent: int) (msg: string) =
                        Html.div [
                            prop.text msg
                            prop.style [style.marginLeft indent]
                            ]
                    let href =
                        match linkBase with
                        | Some linkBase -> $"{linkBase}/_workitems/edit/{item.id}"
                        | None -> $"../../../_workitems/edit/{item.id}"
                    link 0 $"""{item.id} P{getPriority item |> int} {typ}: { whom } {item.fields["System.Title"]} {item.fields["System.State"]}""" href
                    emit 0 $"Due: {item |> getDueDate}"
                    emit 0 "Fields:"
                    let rec unpack margin src =
                        [
                        for k in Fable.Core.JS.Constructors.Object.keys src do
                            let value = jsLookup src k
                            match jsTypeof value, value with
                            | "object", Some value ->
                                if isJSDate value then
                                    emit margin $"{k}: {value}"
                                else
                                    emit margin $"{k}:"
                                    yield! unpack (margin+20) value
                            | _else ->
                                emit margin $"{k}: {value}"
                            ]
                    yield! unpack 20 item.fields
                    emit 0 "Relations:"
                    match item.relations |> unbox<WorkItemRelation array option> with
                    | Some relations ->
                        for rel in relations do
                            emit 20 $"{rel.rel}: {rel.url}"
                            match rel.attributes |> unbox with
                            | Some attr ->
                                yield! unpack 40 attr
                            | None -> ()
                    | None -> emit 20 "No relations"
                ]
            ]
        Html.div [prop.text $"""{item.id} {typ}: { whom } {item.fields["System.Title"]} {item.fields["System.State"]}"""; prop.key item.id]
    ]

let viewSelected (item:Selection option) (ctx: _ AssignmentContext) linkBase dispatch =
    match item with
    | Some (WorkItemSelection item) ->
        Html.div [
            let date days =
                $"""{ctx.startTime.AddDays(days |> float).ToString("M/d")}"""
            let dateRange = $"{item.startTime |> date} to {(item.startTime + item.duration) |> date}"
            Html.div [Html.text dateRange]
            Html.input [prop.value (getTitle item.underlying); prop.className "selected"; prop.readOnly true; prop.disabled true]
            Html.div [
                Html.br []
                yield! viewDetails [item.underlying] linkBase
                ]
            ]
    | Some (DeliverableSelection item) ->
        Html.div [
            Html.div [
                Html.br []
                yield! viewDetails [item] linkBase
                ]
            ]
    | None -> Html.div []

let viewHelp (model:Model) dispatch =
    Html.div [
        prop.className "help"
        prop.children [
            Html.div [
                Html.text "Helpful tip: "
                Html.text "To set dependencies, select an item and press Ctrl-D or hit the Add Dependencies button, and then select the item it depends on. Hit Ctrl-S or the Save button to save."
                ]
            Html.div [
                Html.span [prop.text "For cross-tenant access to OSGS, get a PAT from "]
                Html.a [prop.href "https://dev.azure.com/microsoft/_usersSettings/tokens"; prop.text "https://dev.azure.com/microsoft/_usersSettings/tokens"]
                Html.span [prop.text " with read permission to Work Items, Project and Team, and User Profile, and with write permission if you want to save your changes back to OSGS"]
                ]
            Html.div [
                Html.input [prop.value (defaultArg model.serverUrlOverride ""); prop.className "serverUrlOverride"; prop.placeholder "Server URL e.g. https://dev.azure.com/microsoft/OSGS/"; prop.onChange (SetServerOverrideURL >> dispatch)]
                Html.input [prop.value (defaultArg model.pat ""); prop.className "PAT"; prop.placeholder "Personal access token with work scope, generated at e.g. https://dev.azure.com/microsoft/_usersSettings/tokens"; prop.onChange (SetPAT >> dispatch)]
                ]
            Html.button [prop.text "OK"; prop.onClick(fun _ -> dispatch ToggleHelp)]
            ]
        ]

let viewError errMsg = Html.div [prop.text $"Error: {errMsg}"; prop.className "error"]

let viewApp (model: Model) dispatch =
    let operation opMsg impl _ =
        asyncOperation dispatch opMsg impl |> Promise.start

    Html.div [
        let executeQuery _ = operation Query (thunk2 getWorkItems (options(model.serverUrlOverride, model.pat)) model.wiql)()

        match model.userName with
        | NotStarted | InProgress ->
            Html.div [prop.text $"Initializing..."]
        | Ready(Error errMsg) ->
            Html.div [prop.text $"Initialization error: {errMsg}"; prop.className "error"]
        | Ready(Ok userName) ->
            Html.div [
                Html.text $"Hello, {userName}"
                Html.a [prop.text "Help"; prop.className "menuItem"; prop.href "."; prop.onClick(fun ev -> ev.preventDefault(); dispatch ToggleHelp)]
                Html.a [prop.text "Settings"; prop.className "menuItem"; prop.href "."; prop.onClick(fun ev -> ev.preventDefault(); dispatch ToggleSettings)]
                ]
            if model.showSettings then
                Html.div [
                    Html.input [prop.valueOrDefault (defaultArg model.serverUrlOverride ""); prop.className "serverUrlOverride"; prop.placeholder "Server URL e.g. https://dev.azure.com/microsoft/OSGS/"; prop.onChange (SetServerOverrideURL >> dispatch)]
                    Html.input [prop.valueOrDefault (defaultArg model.pat ""); prop.className "PAT"; prop.placeholder "Personal access token with work scope, generated at e.g. https://dev.azure.com/microsoft/_usersSettings/tokens"; prop.onChange (SetPAT >> dispatch)]
                    ]
            Html.div [prop.text (model.userFacingMessage |> Option.defaultValue "")]
            Html.textarea [
                prop.className "wiql"
                prop.valueOrDefault model.wiql
                prop.autoFocus true
                prop.placeholder "Enter a WIQL query"
                prop.onKeyDown (fun e -> if e.code = "Enter" then executeQuery())
                prop.onChange(fun e -> e |> SetWiql |> dispatch)
                ]
            Html.button [prop.text "Get work items"; prop.onClick executeQuery]

            match model.query with
            | NotStarted -> ()
            | InProgress ->
                Html.div [prop.text "Fetching..."]
            | Ready(Error err) ->
                viewError err
            | Ready(Ok queryResult) ->
                match model.ctx with
                | Some ctx ->
                    let dest = match model.displayOrganization with | ByBucket -> ByDeliverable | ByDeliverable -> ByBucket
                    Html.button [prop.text $"Switch to {dest} view"; prop.onClick (thunk1 dispatch (SetDisplayOrganization dest))]
                    match model.selectedItem with
                    | Some (WorkItemSelection _) ->
                        Html.button [prop.text "Add dependency"; prop.disabled (model.editMode <> NotEditing); prop.onClick (thunk1 dispatch SelectDependency)]
                    | _ -> ()
                    if model.hasUnsavedChanges then
                        Html.button [prop.text "Save"; prop.onClick (fun _ -> saveChanges model dispatch)]
                    viewAssignments ctx queryResult.deliverables model.assignments model.dropped model.displayOrganization dispatch
                    viewSelected model.selectedItem ctx model.serverUrlOverride dispatch
                | None -> ()

        ]

let view (model:Model) dispatch =
    if model.showHelpScreen then
        viewHelp model dispatch
    else
        viewApp model dispatch

let mutable lastError = ""
let mutable lastErrorTime = None

let showError msg dispatch =
    // crude debouncer.
    // todo: use a better, more concise debouncer.
    let longEnough =
        match lastErrorTime with
        | Some last -> (last - System.DateTimeOffset.UtcNow).Seconds > 10
        | None -> true
    if msg <> lastError && longEnough then
        Browser.Dom.window.alert ("Unhandled Exception: " + msg)
    lastError <- msg
    lastErrorTime <- Some System.DateTimeOffset.Now
    Message $"Error: {msg}" |> dispatch


Program.mkSimple init update view
|> Program.withSubscription(fun m -> Cmd.ofSub(fun dispatch ->
    Browser.Dom.window.onerror <-
        fun msg ->
            if msg.ToString().Contains "SocketProtocolError" = false then
                showError (msg.ToString()) dispatch
    Browser.Dom.window.addEventListener("unhandledrejection", fun e ->
        let msg = e.ToString()
        showError msg dispatch
        )
    Browser.Dom.window.addEventListener("keydown", fun e ->
        if e?key = "d" && e?ctrlKey then
            dispatch (SelectDependency)
            e.preventDefault()
        elif e?key = "Escape" then
            dispatch (CancelDependencySelect)
            e.preventDefault()
        )

    let initialize() = promise {
        do! sdk.init()
        return sdk.getUser().name |> Ok
        }

    asyncOperation dispatch SdkInitializationMsg initializeSdk
    |> Promise.start
    ))
|> Program.withReactBatched "feliz-app"
|> Program.run
