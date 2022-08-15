module Main

open Feliz
open Browser.Dom
open Fable.Core.JsInterop

importSideEffects "./styles/global.sass"

open Components
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
type Capacity = {
    description: string
    daysOff: Work.DateRange list
    capacity: float
    }
type QueryResult = {
    workItems: WorkItem list
    deliverables: Map<int, WorkItem>
    capacityMap: string -> Capacity
    }
type QueryContext = {
    // TODO: there's got to be a better way to do this than root/project-scoped options separately
    options: Client.IVssRestClientOptions
    projectScopedOptions: Client.IVssRestClientOptions
    serverRoot: string option
    projectName: string option
    }
type ProgressStatus = OK | Warning of float | AtRisk of float
type EditMode = NotEditing | SelectingDependency of WorkItem Assignment
type Selection =
    | AssignmentSelection of WorkItem Assignment
    | WorkItemSelection of WorkItem
    | BucketSelection of txt:string
type Msg =
    | SetWiql of string
    | Message of string
    | SdkInitializationMsg of string OperationTransition
    | Query of QueryResult OperationTransition
    | SetPAT of string
    | SetServerOverrideURL of string
    | ToggleHelp
    | ToggleSettings
    | ToggleDrilldown
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
    showDetail: bool
    displayOrganization: DisplayOrganization
    selectedItem: Selection option
    editMode: EditMode
    hasUnsavedChanges: bool
    }
    with
    static member fresh = { userName = NotStarted; userFacingMessage = None; ready = true; query = NotStarted; wiql = ""; assignments = []; dropped = []; ctx = None; serverUrlOverride = None; pat = None; showHelpScreen = false; showSettings = false; displayOrganization = ByDeliverable; selectedItem = None; editMode = NotEditing; hasUnsavedChanges = false; showDetail = false }

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
    let getState = get<string> "System.State"
    let getOwner item : string option = item |> get "System.AssignedTo" |> Option.map (fun p -> p?displayName)
    let getRemainingWork item =
        // if an item is cut/completed/closed, ignore it even if it still has Remaining Days listed.
        let explicitRemainingDays = item |> get<float> "Microsoft.VSTS.Scheduling.RemainingWork" |> Option.orElse (item |> get<float> "OSG.RemainingDays")
        match item |> getState, explicitRemainingDays with
        | Some ("Closed" | "Completed" | "Cut"), _ -> 0.
        | Some ("Resolved"), None -> 0.3 // assume resolution is pretty fast usually
        | _, Some v -> v
        | _ -> 1. // if no Remaining Days estimate but there is still work to do, it might be a new item. Default to 1 just so the timeline doesn't collapse.
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

let makeContext (queryResult: QueryResult): _ AssignmentContext =
    let capacity (ctx: _ AssignmentContext) (bucket: string) (startTime: float<realDay>): float<dayCost/realDay> =
        match (ctx.startTime.AddDays (int startTime)).DayOfWeek |> int with
        | 0 | 6 -> 0.<dayCost/realDay> // not Saturday/Sunday. For some reason can't refer directly to Saturday/Sunday. TODO: get this and holidays from ADO instead of hardwiring.
        | _ ->
            let capacity = queryResult.capacityMap bucket
            let dt = ctx.startTime.AddDays (float startTime)
            if capacity.daysOff |> List.exists (fun range -> range.start.LocalDateTime <= dt && dt <= range.``end``.LocalDateTime ) then 0.0<dayCost/realDay> // no capacity on days off
            else capacity.capacity*1.<dayCost/realDay>

    let getBucket item =
        match getOwner item with
        // ignore buckets that have no actual person assigned--they will just cause infinite loops. Instead, return None so those work items get listed as dropped/won't be done.
        | Some bucket when (queryResult.capacityMap bucket).capacity > 0. -> Some bucket
        | _ -> None
    {
        startTime = System.DateTime.Now.Date
        buckets = queryResult.workItems |> Seq.map getBucket |> Seq.filter Option.isSome |> Seq.map Option.get |> List.ofSeq // todo: find a better way than filter
        capacityCoefficient = capacity // todo: make this real
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


let queryContext (model: Model) : QueryContext =
    let serverRoot, projectName =
        match model.serverUrlOverride with
        | Some(Regex "(https://[^/]+/[^/]+/)([^/]+).*" [serverRoot; teamName]) ->
            Some serverRoot, Some teamName
        | _ -> None, None
    {
        options = options(model.serverUrlOverride, model.pat)
        projectScopedOptions = options(serverRoot |> Option.orElse model.serverUrlOverride, model.pat)
        serverRoot = serverRoot
        projectName = projectName
    }

let getWorkClient options = promise {
    return Client.exports.getClient<WorkItemTrackingClient.WorkItemTrackingRestClient>(unbox WorkItemTrackingClient.exports.WorkItemTrackingRestClient, options)
    }

let getTeams (project:IProjectInfo) (ctx: QueryContext) = promise {
    let coreClient = Client.exports.getClient<CoreClient.CoreRestClient>(unbox CoreClient.exports.CoreRestClient, ctx.projectScopedOptions)
    let! teams = coreClient.getTeams(ctx.projectName |> Option.defaultValue null, mine=true) // in theory you should be able to query teams you're not on but for perf sake right now we don't allow it
    return teams
    }

let tryGetTeamCapacity (ctx: QueryContext) (team:Core.WebApiTeam) = promise {
    let! projectService = sdk.getService<IProjectPageService>(CommonServiceIds.ProjectPageService)
    let! project = projectService.getProject()
    let teamCtx : Core.TeamContext = !! {|
        project = ctx.projectName |> Option.defaultValue project.Value.name
        //projectId = project.Value.id
        team = team.name
        //teamId = team.id
        |}
    let client = Client.exports.getClient<WorkClient.WorkRestClient>(unbox WorkClient.exports.WorkRestClient, ctx.projectScopedOptions)
    let! iterations = client.getTeamIterations(teamCtx)
    let inScope (targetDate: System.DateTime) (iteration: Work.TeamSettingsIteration) =
        iteration.attributes.startDate <= targetDate && targetDate <= iteration.attributes.finishDate
    let capacityForIteration (iteration: Work.TeamSettingsIteration) =
        client.getCapacitiesWithIdentityRef(teamCtx, iteration.id)
    let! capacities = iterations |> Seq.filter (inScope System.DateTime.Now) |> Seq.map capacityForIteration |> Promise.all
    return capacities
    }

let tryGetCapacity (ctx: QueryContext) = promise {
    try
        let! projectService = sdk.getService<IProjectPageService>(CommonServiceIds.ProjectPageService)
        let! project = projectService.getProject()
        let! teams = getTeams project.Value ctx
        let! capacities = promise {
            let! items = teams |> Seq.map (tryGetTeamCapacity ctx) |> Promise.Parallel
            return items |> Seq.flatten |> Seq.flatten |> Array.ofSeq
            }

        printfn "Capacity:  %A" (capacities.Length)
        let capacityForTeamMember (teamMemberName: string) =
            let capacitiesAndDaysOff =
                [
                for capacity in capacities do
                    if capacity.teamMember.displayName = teamMemberName then
                        (capacity.activities |> Seq.sumBy(fun activity -> activity.capacityPerDay)), capacity.daysOff
                ]
            let capacity = capacitiesAndDaysOff |> Seq.sumBy fst
            let daysOff = capacitiesAndDaysOff |> Seq.map snd |> Seq.flatten |> List.ofSeq
            let daysOffDescr =
                match daysOff
                    |> List.map (fun daysOff -> $"{daysOff.start.Date |> convertJSDateToString} to {daysOff.``end``.Date |> convertJSDateToString}") with
                | [] -> ""
                | daysOff -> $""", off {String.join ", " daysOff}"""
            {
                description = $"{teamMemberName}: {capacity} capacity{daysOffDescr}"
                capacity = capacity
                daysOff = daysOff
                }
        return capacityForTeamMember
    with _err ->
        printfn "tryGetCapacity failed: %A" _err
        return fun (teamMemberName:string) -> { description = (sprintf "Error: %A" _err); capacity = 0; daysOff = [] }
    }

let getWorkItems (ctx: QueryContext) (wiql) = promise {
    let! capacityMap = tryGetCapacity ctx
    let query = jsOptions<Wiql>(fun o ->
        o.query <- wiql)
    let! client = getWorkClient ctx.options
    let! wiqlResult = client.queryByWiql(query)
    if wiqlResult.workItems.Count = 0 then
        return { QueryResult.workItems = []; deliverables = Map.empty; capacityMap = capacityMap }
    else
        let! details = client.getWorkItems(wiqlResult.workItems |> ResizeArray.map (fun ref -> ref.id), expand=WorkItemExpand.All) |> Promise.map List.ofSeq
        let deliverableIds = details |> List.map getDeliverableId |> List.distinct
        let! deliverables = client.getWorkItems(deliverableIds |> List.filter (fun id -> id > 0) |> ResizeArray) |> Promise.map List.ofSeq
        let deliverablesById = deliverables |> List.collect (fun wi -> [wi.id, wi]) |> Map.ofList
        return { QueryResult.workItems = details; deliverables = deliverablesById; capacityMap = capacityMap }
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
            let ctx = makeContext queryResult
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
    | ToggleDrilldown ->
        { model with showDetail = not model.showDetail }
    | SetDisplayOrganization displayOrganization ->
        { model with displayOrganization = displayOrganization }
    | Select workItemAssignment ->
        // SELECT is a user action which has different effects in different modes (not sure if I love that idea, but for now...)
        // When we're selecting dependencies, it adds a new dependency, clears edit mode, and recomputes assignments, while preserving the currently-selected item.
        // Otherwise, it changes what the currently-selected item is (which affects detail display at the bottom of the screen).
        match model.editMode, workItemAssignment, model.query with
        | EditMode.SelectingDependency target, (AssignmentSelection asn), Ready (Ok queryResult) ->
            // update the source of truth
            let queryResult = queryResult |> addDependency target asn
            let ctx = makeContext queryResult
            let asn', dropped = Extensions.assignments ctx queryResult.workItems
            // for UX reasons, preserve selection (up to underlying id)
            let selection' = asn' |> List.tryFind (fun a -> a.underlying.id = asn.underlying.id) |> Option.map (AssignmentSelection)
            { model with ctx = Some ctx; assignments = asn'; dropped = dropped; editMode = EditMode.NotEditing; selectedItem = selection'; hasUnsavedChanges = true; query = Ready (Ok queryResult) }
        | _ ->
            { model with selectedItem = workItemAssignment |> Some }
    | SetHasUnsavedChanges v ->
        { model with hasUnsavedChanges = v }
    | CancelDependencySelect ->
        { model with editMode = EditMode.NotEditing }
    | SelectDependency ->
        { model with editMode = match model.selectedItem with | Some (AssignmentSelection asn) -> EditMode.SelectingDependency asn | _ -> model.editMode }

let viewAssignments (ctx: WorkItem AssignmentContext) (queryResult: QueryResult) (work: WorkItem Assignment list) (dropped: WorkItem list) org dispatch =
    let deliverables = queryResult.deliverables
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
            yCoord, rows |> List.map (fun row -> row, 1, (fun _ -> (queryResult.capacityMap row).description |> BucketSelection |> Select |> dispatch))
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
                                        WorkItemSelection deliverable |> Select |> dispatch
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
    let preDroppedHeight = headerHeight + ((height + (work |> List.map (fun item -> yCoord item) |> List.append [0] |> List.max)))
    let stageHeight = preDroppedHeight + (dropped.Length * height)
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
                    prop.onClick (thunk1 dispatch (Select (AssignmentSelection asn)))
                    ]
            for ix, item in dropped |> List.mapi tup2 do
                Html.span [
                    prop.className "dropped"
                    prop.style [
                        style.top (preDroppedHeight + (height * ix))
                        style.left startLeft
                        ]
                    prop.onClick (thunk1 dispatch (Select (WorkItemSelection item)))
                    prop.text ("Won't be done: " + msg item)
                    ]
            ]
        ]


let viewDetails (model: Model) (ctx: _ AssignmentContext) (item: WorkItem) (asn: _ Assignment option) linkBase = [
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
                link 0 $"""{item.id} P{getPriority item |> int} {typ}: { whom } {item.fields["System.Title"]}""" href
                let due = item |> getDueDate
                let ETA, overdueBy =
                    match due, asn with
                    | Some due, Some asn ->
                        let eta = ctx.startTime.AddDays((asn.startTime + asn.duration)/1.<realDay>)
                        if eta > due then
                            eta |> Some, Some (eta - due).TotalDays
                        else
                            eta |> Some, None
                    | _ -> None, None
                let dateToString label = function Some (v: System.DateTime) -> $"""{label}: {convertJSDateToString v}""" | None -> $"{label}: N/A"
                emit 0 $"""{dateToString "Due" due} {dateToString "ETA" ETA} [{getState item}] {match overdueBy with Some v -> $"(overdue by %.2f{v} days)" | None -> "(on time)"}"""
                if model.showDetail then
                    emit 0 "-----"
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
    ]

let viewSelected (model:Model) (ctx: _ AssignmentContext) linkBase dispatch =
    let item = model.selectedItem
    match item with
    | Some (BucketSelection txt) -> Html.div txt
    | Some (AssignmentSelection item) ->
        Html.div [
            let date days =
                $"""{ctx.startTime.AddDays(days |> float).ToString("M/d")}"""
            let dateRange = $"{item.startTime |> date} to {(item.startTime + item.duration) |> date}"
            Html.div [Html.text dateRange]
            Html.input [prop.value (getTitle item.underlying); prop.className "selected"; prop.readOnly true; prop.disabled true]
            Html.div [
                Html.br []
                yield! viewDetails model ctx item.underlying (Some item) linkBase
                ]
            ]
    | Some (WorkItemSelection item) ->
        Html.div [
            Html.div [
                Html.br []
                yield! viewDetails model ctx item None linkBase
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
        let executeQuery _ = operation Query (thunk2 getWorkItems (queryContext model) model.wiql)()

        match model.userName with
        | NotStarted | InProgress ->
            Html.div [prop.text $"Initializing..."]
        | Ready(Error errMsg) ->
            Html.div [prop.text $"Initialization error: {errMsg}"; prop.className "error"]
        | Ready(Ok userName) ->
            Html.div [
                Html.text $"Hello, {userName}"
                Html.a [prop.text "Settings"; prop.className "menuItem"; prop.href "."; prop.onClick(fun ev -> ev.preventDefault(); dispatch ToggleSettings)]
                Html.a [prop.text "Help"; prop.className "menuItem"; prop.href "."; prop.onClick(fun ev -> ev.preventDefault(); dispatch ToggleHelp)]
                ]
            if model.showSettings then
                Html.div [
                    Html.input [prop.valueOrDefault (defaultArg model.serverUrlOverride ""); prop.className "serverUrlOverride"; prop.placeholder "Server URL e.g. https://dev.azure.com/microsoft/OSGS/"; prop.onChange (SetServerOverrideURL >> dispatch)]
                    Html.input [prop.valueOrDefault (defaultArg model.pat ""); prop.className "PAT"; prop.placeholder "Personal access token with work scope, generated at e.g. https://dev.azure.com/microsoft/_usersSettings/tokens"; prop.onChange (SetPAT >> dispatch)]
                    Html.div [
                        let showDetailId = "chkShowDetail"
                        Html.input [prop.type'.checkbox; prop.id showDetailId; prop.valueOrDefault model.showDetail; prop.onClick (thunk1 dispatch ToggleDrilldown)]
                        Html.label [prop.for' showDetailId; prop.text "Show detailed fields for selected item"]
                        ]
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
                    | Some (AssignmentSelection _) ->
                        Html.button [prop.text "Add dependency"; prop.disabled (model.editMode <> NotEditing); prop.onClick (thunk1 dispatch SelectDependency)]
                    | _ -> ()
                    if model.hasUnsavedChanges then
                        Html.button [prop.text "Save"; prop.onClick (fun _ -> saveChanges model dispatch)]
                    viewAssignments ctx queryResult model.assignments model.dropped model.displayOrganization dispatch
                    viewSelected model ctx model.serverUrlOverride dispatch
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
