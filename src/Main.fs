module Main

open Feliz
open App
open Browser.Dom
open Fable.Core.JsInterop

importSideEffects "./styles/global.scss"

open App
open Elmish
open Elmish.React

type Msg = | Delta of int
type Model = { count: int } with static member fresh = { count = 10 }
let init _ = Model.fresh
let update msg model =
    match msg with
    | Delta n -> { model with count = model.count + n }
let view (model: Model) dispatch =
    Html.div [
        Html.button [prop.text "-"; prop.ariaValueText "Increment counter"; prop.onClick(thunk1 dispatch (Delta -1))]
        Html.span [prop.text $"Current count: {model.count}"]
        Html.button [prop.text "+"; prop.ariaValueText "Increment counter"; prop.onClick(thunk1 dispatch (Delta +1))]
        ]

Program.mkSimple init update view
|> Program.withSubscription(fun m -> Cmd.ofSub(fun dispatch ->
    Browser.Dom.window.onerror <-
    fun msg ->
        if msg.ToString().Contains "SocketProtocolError" = false then
            Browser.Dom.window.alert ("Unhandled Exception: " + msg.ToString())
        ))
|> Program.withReactBatched "feliz-app"
|> Program.run