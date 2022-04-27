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
    | Message of string
    | SdkInitializationMsg of string OperationTransition
    | WorkItemMsg of string list OperationTransition
type Model = {
    userName: string Deferred
    userFacingMessage: string option;
    ready: bool;
    workItems: string list Deferred }
    with
    static member fresh = { userName = NotStarted; userFacingMessage = None; ready = true; workItems = NotStarted  }

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

let getWorkItems() = promise {
    let options = jsOptions<IVssRestClientOptions>(fun o ->
#if DEBUG
        o.rootPath <- Some (Fable.Core.Case1 "https://dev.azure.com/maxw0485/") // there must be a better way to do this
#endif
    )
    let! projectService = sdk.getService<IProjectPageService>(CommonServiceIds.ProjectPageService);
    let! project = projectService.getProject();

    let client = WorkItemTrackingClient.exports.WorkItemTrackingRestClient.Create options
    let! wiTypes = client.getWorkItemTypes(project.Value.name)
    return wiTypes |> List.ofSeq |> List.map (fun wit -> wit.name)
    //return proj |> Seq.map (fun p -> p.name) |> List.ofSeq
    }

let init _ = Model.fresh
let update msg model =
    match msg with
    | Message msg -> { model with userFacingMessage = msg |> Some }
    | WorkItemMsg op -> { model with workItems = receive op }
    | SdkInitializationMsg op -> { model with userName = receive op }

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
            Html.unorderedList [
                match model.workItems with
                | NotStarted ->
                    Html.button [prop.text "Get work items"; prop.onClick (operation WorkItemMsg getWorkItems)]
                | InProgress ->
                    Html.div [prop.text "Fetching..."]
                | Ready(Error err) ->
                    viewError err
                    Html.button [prop.text "Get work items"; prop.onClick (operation WorkItemMsg getWorkItems)]
                | Ready(Ok workItems) ->
                    for item in workItems do
                        Html.div [prop.text item; prop.key item]
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