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
type Model = {
    userName: string Deferred
    wiql: string
    userFacingMessage: string option;
    ready: bool;
    workItems: WorkItem list Deferred }
    with
    static member fresh = { userName = NotStarted; userFacingMessage = None; ready = true; workItems = NotStarted; wiql = "" }

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
let getWorkItems(wiql) = promise {
    let! projectService = sdk.getService<IProjectPageService>(CommonServiceIds.ProjectPageService);
    let! project = projectService.getProject();

    let query = jsOptions<Wiql>(fun o ->
        o.query <- wiql)
    let client = Client.exports.getClient<WorkItemTrackingClient.WorkItemTrackingRestClient>(unbox WorkItemTrackingClient.exports.WorkItemTrackingRestClient)
    let! wiqlResult = client.queryByWiql(query)
    let! details = client.getWorkItems(wiqlResult.workItems |> ResizeArray.map (fun ref -> ref.id))
    return details |> List.ofSeq
    }

let init _ = Model.fresh
let update msg model =
    match msg with
    | Message msg -> { model with userFacingMessage = msg |> Some }
    | WorkItemMsg op -> { model with workItems = receive op }
    | SdkInitializationMsg op -> { model with userName = receive op; wiql = "Select [System.Id], [System.Title], [System.State] From WorkItems Where System.CreatedBy=@me" }
    | SetWiql wiql -> { model with wiql = wiql }

let viewError errMsg = Html.div [prop.text $"Error: {errMsg}"; prop.className "error"]
let view (model: Model) dispatch =
    let operation opMsg impl _ =
        asyncOperation dispatch opMsg impl |> Promise.start

    Html.div [
        match model.userName with
        | NotStarted | InProgress ->
            Html.div [prop.text $"Initializing..."]
        | Ready(Error errMsg) ->
            Html.div [prop.text $"Initialization error: {errMsg}"; prop.className "error"]
        | Ready(Ok userName) ->

            Html.div [prop.text $"Hello, {userName}"]
            Html.div [prop.text (model.userFacingMessage |> Option.defaultValue "")]
            Html.textarea [prop.value model.wiql; prop.className "wiql"; prop.placeholder "Enter a WIQL query"; prop.onChange(fun e -> e |> SetWiql |> dispatch)]
            Html.button [prop.text "Get work items"; prop.onClick (operation WorkItemMsg (thunk1 getWorkItems model.wiql))]
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
                        Html.div [prop.text $"""{item.id}: { whom } {item.fields["System.Title"]} {item.fields["System.State"]}"""; prop.key item.id]
                ]
            ]

Program.mkSimple init update view
|> Program.withSubscription(fun m -> Cmd.ofSub(fun dispatch ->
    Browser.Dom.window.onerror <-
        fun msg ->
            if msg.ToString().Contains "SocketProtocolError" = false then
                Browser.Dom.window.alert ("Unhandled Exception: " + msg.ToString())
                Message $"Error: {msg}" |> dispatch
    Browser.Dom.window.addEventListener("unhandledrejection", fun e ->
        let msg = e.ToString()
        e.preventDefault()
        Browser.Dom.window.alert ("Unhandled Exception: " + msg.ToString())
        Message $"Error: {msg}" |> dispatch
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