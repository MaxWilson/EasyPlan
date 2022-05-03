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

type Msg =
    | SetWiql of string
    | Message of string
    | SdkInitializationMsg of string OperationTransition
    | WorkItemMsg of WorkItem list OperationTransition
    | SetPAT of string
    | SetServerOverrideURL of string
    | ToggleHelp
    | ToggleSettings
type Model = {
    userName: string Deferred
    wiql: string
    userFacingMessage: string option;
    ready: bool;
    workItems: WorkItem list Deferred
    assignments: WorkItem Assignment list
    dropped: WorkItem list
    ctx: WorkItem AssignmentContext option
    serverUrlOverride: string option
    pat: string option
    showHelpScreen: bool
    showSettings: bool
    }
    with
    static member fresh = { userName = NotStarted; userFacingMessage = None; ready = true; workItems = NotStarted; wiql = ""; assignments = []; dropped = []; ctx = None; serverUrlOverride = None; pat = None; showHelpScreen = false; showSettings = false }

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

let makeContext (items: WorkItem seq) : _ AssignmentContext =
    let getBucket (item: WorkItem) = match item.fields["System.AssignedTo"] with | Some p -> p?displayName | None -> None
    {
        startTime = System.DateTime.UtcNow.Date
        buckets = items |> Seq.map getBucket |> Seq.filter Option.isSome |> Seq.map Option.get |> List.ofSeq // todo: find a better way than filter
        capacityCoefficient = Extensions.Test.measureCapacity // todo: make this real
        prioritize = fun items -> items |> List.sortBy (fun (i:WorkItem) -> match i.fields["Microsoft.VSTS.Common.Priority"] with | Some pri -> unbox<int> pri | _ -> 5)
        getId = fun (item: WorkItem) -> item.id
        getDependencies = thunk []
        getBucket = getBucket
        getCost = fun (item: WorkItem) ->
            match item.fields["Microsoft.VSTS.Scheduling.RemainingWork"] with
            | Some w -> unbox<float<dayCost>> w
            | None ->
                match item.fields["OSG.RemainingDays"] with
                | Some w -> unbox<float<dayCost>> w
                | None -> 1.<dayCost>
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
    let! details = client.getWorkItems(wiqlResult.workItems |> ResizeArray.map (fun ref -> ref.id))
    return details |> List.ofSeq
    }

let init _ = { Model.fresh with pat = LocalStorage.PAT.read(); serverUrlOverride = LocalStorage.ServerUrlOverride.read() }
let update msg model =
    match msg with
    | Message msg -> { model with userFacingMessage = msg |> Some }
    | WorkItemMsg op ->
        let model = { model with workItems = receive op }
        match model.workItems with
        | Ready(Ok items) ->
            let ctx = makeContext items
            let asn, dropped = Extensions.assignments ctx items
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

let viewAssignments (ctx: WorkItem AssignmentContext) (work: WorkItem Assignment list) (dropped: WorkItem list) dispatch =
    let buckets = work |> List.map (fun w -> w.bucketId) |> List.distinct |> List.sort
    let height = 30
    let width = 50
    let margin = 10.
    let timeRatio = (float width/1.<realDay>)
    let yCoord (asn: _ Assignment) =
        let ix = buckets |> List.findIndex ((=) asn.bucketId)
        ix * height
    let msg (item: WorkItem) =
        $"""{item.fields["System.Title"]} """
    let date (asn: _ Assignment) msg =
        $"""{ctx.startTime.AddDays(asn.startTime |> float).ToString("MM/dd")} {msg}"""
    let stageWidth = (match work with [] -> 0. | _ -> ((work |> List.map (fun w -> w.startTime + w.duration)) |> List.max) * timeRatio + (float width) + 0.)
    printfn "%d" (int stageWidth)
    let class' ctor (className:string) elements =
        ctor (prop.className className::elements)
    let startX, startY = 0,0
    class' Html.div "stage" [
        prop.style [
            style.width (int stageWidth)
            style.height ((buckets.Length + dropped.Length) * height)
            ]
        prop.children [
            for ix, bucket in buckets |> List.mapi tup2 do
                Html.input [
                    prop.className "bucket"
                    prop.style [
                        style.top (ix * height)
                        style.left 0
                        style.width width
                        ]
                    prop.value bucket
                    prop.readOnly true
                    prop.disabled true
                    ]
            for asn in work do
                let item = asn.underlying
                Html.input [
                    prop.className "item"
                    prop.style [
                        style.top (yCoord asn)
                        style.left (asn.startTime * timeRatio + 60. |> int)
                        style.width (asn.duration * timeRatio - margin |> int)
                        ]
                    prop.value (msg item)
                    prop.readOnly true
                    prop.disabled true
                    ]
            for ix, item in dropped |> List.mapi tup2 do
                Html.span [
                    prop.className "dropped"
                    prop.style [
                        style.top (height * (ix + buckets.Length))
                        style.left width
                        ]
                    prop.text (msg item)
                    ]
            ]
        ]

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

[<Emit("typeof $0")>]
let jsTypeof (_ : obj) : string = jsNative
[<Emit("$0[$1]")>]
let jsLookup (_ : obj) (key:string): obj option = jsNative

let viewError errMsg = Html.div [prop.text $"Error: {errMsg}"; prop.className "error"]
let viewApp (model: Model) dispatch =
    let operation opMsg impl _ =
        asyncOperation dispatch opMsg impl |> Promise.start

    Html.div [
        let executeQuery _ = operation WorkItemMsg (thunk2 getWorkItems (options(model.serverUrlOverride, model.pat)) model.wiql)()

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
                    Html.input [prop.value (defaultArg model.serverUrlOverride ""); prop.className "serverUrlOverride"; prop.placeholder "Server URL e.g. https://dev.azure.com/microsoft/OSGS/"; prop.onChange (SetServerOverrideURL >> dispatch)]
                    Html.input [prop.value (defaultArg model.pat ""); prop.className "PAT"; prop.placeholder "Personal access token with work scope, generated at e.g. https://dev.azure.com/microsoft/_usersSettings/tokens"; prop.onChange (SetPAT >> dispatch)]
                    ]
            Html.div [prop.text (model.userFacingMessage |> Option.defaultValue "")]
            Html.textarea [
                prop.className "wiql"
                prop.value model.wiql
                prop.autoFocus true
                prop.placeholder "Enter a WIQL query"
                prop.onKeyDown (fun e -> if e.code = "Enter" then executeQuery())
                prop.onChange(fun e -> e |> SetWiql |> dispatch)
                ]
            Html.button [prop.text "Get work items"; prop.onClick executeQuery]
            match model.ctx with
            | Some ctx ->
                viewAssignments ctx model.assignments model.dropped dispatch
            | None -> ()
            Html.unorderedList [
                match model.workItems with
                | NotStarted -> ()
                | InProgress ->
                    Html.div [prop.text "Fetching..."]
                | Ready(Error err) ->
                    viewError err
                | Ready(Ok workItems) ->
                    for item in workItems do
                        let whom = match item.fields["System.AssignedTo"] with | Some p -> p?displayName | None -> "Unassigned"
                        let typ = match item.fields["System.WorkItemType"] with | Some typ -> unbox<string> typ | None -> "None"
                        Html.div [
                            prop.key $"WorkItem{item.id}"
                            prop.children [
                                    let emit (indent: int) (msg: string) =
                                        Html.div [
                                            prop.text msg
                                            prop.style [style.marginLeft indent]
                                            ]
                                    emit 0 $"""{item.id} {typ}: { whom } {item.fields["System.Title"]} {item.fields["System.State"]}"""
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
                                    for rel in item.relations do
                                        emit 20 rel.url
                                        match rel.attributes |> unbox with
                                        | Some attr ->
                                            yield! unpack 40 attr
                                        | None -> ()
                                ]
                            ]
                        Html.div [prop.text $"""{item.id} {typ}: { whom } {item.fields["System.Title"]} {item.fields["System.State"]}"""; prop.key item.id]
                ]
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
