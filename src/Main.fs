module Main

open Feliz
open App
open Browser.Dom
open Fable.Core.JsInterop

importSideEffects "./styles/global.scss"

open App
open Elmish
open Elmish.React
open WorkItemTracking
open WorkItemTrackingClient

let sdk = SDK.sdk;

type Msg = | Message of string | InitializationComplete of string list
type Model = { userFacingMessage: string option; ready: bool; workItems: string list } with static member fresh = { userFacingMessage = None; ready = true; workItems = []  }
let init _ = Model.fresh
let update msg model =
    match msg with
    | Message msg -> { model with userFacingMessage = msg |> Some }
    | InitializationComplete workItems -> { model with workItems = workItems }

let view (model: Model) dispatch =
    Html.div [
        Html.div [prop.text (model.userFacingMessage |> Option.defaultValue "")]
        Html.unorderedList [
            for item in model.workItems do
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
    promise {
        Message "Initializing..." |> dispatch
        try
            let p = sdk.init()
            let p2 = Promise.catch(fun err -> Message $"Oops, error! {err}" |> dispatch) p
            do! p2

            Message $"Hello, {sdk.getUser().name}" |> dispatch
            let options = jsOptions<IVssRestClientOptions>(fun o ->
                ()
                )
            let client = WorkItemTrackingClient.exports.WorkItemTrackingRestClient.Create options
            client.getWorkItems()
            ()
        with exn ->
            Message $"Oops, error! {exn}" |> dispatch
        }
        |> Promise.catch (fun exn -> Message $"Oops, error! {exn}" |> dispatch)
        |> Promise.start
        ))
|> Program.withReactBatched "feliz-app"
|> Program.run