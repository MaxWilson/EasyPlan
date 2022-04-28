[<AutoOpen>]
module Common

open System

let thunk x _ = x
let thunk1 f x _ = f x
let thunk2 f x y _ = f x y

module List =
    let every f lst = lst |> List.exists (f >> not) |> not