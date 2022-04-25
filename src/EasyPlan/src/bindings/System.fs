// ts2fable 0.7.1
module rec System
open System
open Fable.Core
open Fable.Core.JS


module System =

    type [<RequireQualifiedAccess>] DayOfWeek =
        | Sunday = 0
        | Monday = 1
        | Tuesday = 2
        | Wednesday = 3
        | Thursday = 4
        | Friday = 5
        | Saturday = 6
