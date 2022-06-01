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
    }
    with
    static member fresh = { userName = NotStarted; userFacingMessage = None; ready = true; query = NotStarted; wiql = ""; assignments = []; dropped = []; ctx = None; serverUrlOverride = None; pat = None; showHelpScreen = false; showSettings = false; displayOrganization = ByDeliverable; selectedItem = None }

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
    let getOwner item = item |> get "System.AssignedTo" |> Option.map (fun p -> p?displayName)
    let getRemainingWork item =
        item |> get<float> "Microsoft.VSTS.Scheduling.RemainingWork"
        |> (function None -> item |> get "OSG.RemainingDays" | otherwise -> otherwise)
        |> Option.defaultValue 1.
        |> (fun w -> w * 1.<dayCost>)
    let getTitle = get<string> "System.Title" >> Option.defaultValue "Untitled"
    let getDeliverableId = get<int option> "System.Parent" >> Option.flatten >> Option.defaultValue 0

open Properties

let makeContext (items: WorkItem seq) : _ AssignmentContext =
    let getBucket = getOwner
    {
        startTime = System.DateTime.UtcNow.Date
        buckets = items |> Seq.map getBucket |> Seq.filter Option.isSome |> Seq.map Option.get |> List.ofSeq // todo: find a better way than filter
        capacityCoefficient = Extensions.Test.measureCapacity // todo: make this real
        prioritize = fun items -> items |> List.sortBy (fun (i:WorkItem) -> match i.fields["Microsoft.VSTS.Common.Priority"] with | Some pri -> unbox<int> pri | _ -> 5)
        getId = getId
        getDependencies = thunk []
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
    let! projectService = sdk.getService<IProjectPageService>(CommonServiceIds.ProjectPageService);
    let! project = projectService.getProject();
    return Client.exports.getClient<WorkItemTrackingClient.WorkItemTrackingRestClient>(unbox WorkItemTrackingClient.exports.WorkItemTrackingRestClient, options)
    }

let getWorkItems options (wiql) = promise {
    let query = jsOptions<Wiql>(fun o ->
        o.query <- wiql)
    let! client = getWorkClient options
    let! wiqlResult = client.queryByWiql(query)
    if wiqlResult.workItems.Count = 0 then
        return { QueryResult.workItems = []; deliverables = Map.empty }
    else
        let! details = client.getWorkItems(wiqlResult.workItems |> ResizeArray.map (fun ref -> ref.id), expand=WorkItemExpand.All) |> Promise.map List.ofSeq
        let deliverableIds = details |> List.map getDeliverableId |> List.distinct
        let! deliverables = client.getWorkItems(deliverableIds |> ResizeArray) |> Promise.map List.ofSeq
        let deliverablesById = deliverables |> List.collect (fun wi -> [wi.id, wi]) |> Map.ofList
        return { QueryResult.workItems = details; deliverables = deliverablesById }
    }

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
        { model with selectedItem = workItemAssignment |> Some }

let viewAssignments (ctx: WorkItem AssignmentContext) (deliverables: Map<int, WorkItem>) (work: WorkItem Assignment list) (dropped: WorkItem list) org dispatch =
    let height = 30
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
                headerHeight + rowHeight * height
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
                    prop.text $"""{day.ToString("m/d")}"""
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
let jsLookup (_ : obj) (key:string): obj option = jsNative

let viewDetails (workItems: WorkItem list) linkBase = [
    for item in workItems do
        let whom = match item.fields["System.AssignedTo"] with | Some p -> p?displayName | None -> "Unassigned"
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
                    link 0 $"""{item.id} {typ}: { whom } {item.fields["System.Title"]} {item.fields["System.State"]}""" href
                    let rec unpack margin src =
                        [
                        for k in Fable.Core.JS.Constructors.Object.keys src do
                            let value = jsLookup src k
                            match jsTypeof value, value with
                            | "object", Some value ->
                                yield! unpack (margin+20) value
                            | _else ->
                                emit margin $"{k}: {value}"
                            ]
                    yield! unpack 20 item.fields
                    match item.relations |> unbox<WorkItemRelation array option> with
                    | Some relations ->
                        for rel in relations do
                            emit 20 rel.url
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
                Html.text "To set dependencies, select an item and press Ctrl-D or hit the dependencies button, and then select the item it is dependent on. Hit Ctrl-S or the Save button to save."
                ]
            Html.div [
                Html.span [prop.text "For cross-tenant access to OSGS, get a PAT from "]
                Html.a [prop.href "https://dev.azure.com/microsoft/_usersSettings/tokens"; prop.text "https://dev.azure.com/microsoft/_usersSettings/tokens"]
                Html.span [prop.text " with Work Item read permission, and with write permission if you want to save your changes back to OSGS"]
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

    let initialize() = promise {
        do! sdk.init()
        return sdk.getUser().name |> Ok
        }

    asyncOperation dispatch SdkInitializationMsg initializeSdk
    |> Promise.start
    ))
|> Program.withReactBatched "feliz-app"
|> Program.run
