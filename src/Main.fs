module Main

open Feliz
open App
open Browser.Dom
open Fable.Core.JsInterop

importSideEffects "./styles/global.scss"

open App
open Elmish
open Elmish.React

type Msg = | Delta of int | Message of string
type Model = { count: int; userFacingMessage: string option } with static member fresh = { count = 10; userFacingMessage = None }
let init _ = Model.fresh
let update msg model =
    match msg with
    | Delta n -> { model with count = model.count + n }
    | Message msg -> { model with userFacingMessage = msg |> Some }
let view (model: Model) dispatch =
    Html.div [
        Html.div [prop.text (model.userFacingMessage |> Option.defaultValue "")]
        Html.button [prop.text "-"; prop.ariaValueText "Increment counter"; prop.onClick(thunk1 dispatch (Delta -1))]
        Html.span [prop.text $"Current count: {model.count}"]
        Html.button [prop.text "+"; prop.ariaValueText "Increment counter"; prop.onClick(thunk1 dispatch (Delta +1))]
        ]

let sdk = SDK.sdk;

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
            let p = SDK.sdk.init()
            let p2 = Promise.catch(fun err -> Message $"Oops, error! {err}" |> dispatch) p
            do! p2
            Message "OK, ready to go." |> dispatch
        with exn ->
            Message $"Oops, error! {exn}" |> dispatch
        }
        |> Promise.catch (fun exn -> Message $"Oops, error! {exn}" |> dispatch)
        |> Promise.start
        ))
|> Program.withReactBatched "feliz-app"
|> Program.run