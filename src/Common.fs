[<AutoOpen>]
module Common

open System

let thunk x _ = x
let thunk1 f x _ = f x
let thunk2 f x y _ = f x y
let tup2 x y = x,y
let toString x = x.ToString()
let (|Regex|_|) pattern input =
    match System.Text.RegularExpressions.Regex.Match(input, pattern) with
    | m when m.Success ->
        Some (List.tail [ for x in m.Groups -> x.Value ])
    | _ -> None
module Seq =
    let flatten s = Seq.collect id s
module List =
    let every f lst = lst |> List.exists (f >> not) |> not
module String =
    let join (delimiter: string) (strings: string seq) = String.Join(delimiter, strings)
let notImpl msg = failwith $"Not implemented yet. Email Max if you want this feature. {msg}"

let inline show (msg:'t) =
#if DEBUG
    System.Console.WriteLine msg
#else
    ()
#endif