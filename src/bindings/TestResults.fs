// ts2fable 0.7.1
module rec TestResults
open System
open Fable.Core
open Fable.Core.JS


module TestResults =

    type [<AllowNullLiteral>] Attachment =
        abstract compressionType: string with get, set
        abstract fileName: string with get, set
        abstract stream: obj option with get, set
