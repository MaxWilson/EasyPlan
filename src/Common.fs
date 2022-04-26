[<AutoOpen>]
module Common

open System
open Fable.Core
open Fable.Core.JsInterop

let thunk x _ = x
let thunk1 f x _ = f x
let thunk2 f x y _ = f x y