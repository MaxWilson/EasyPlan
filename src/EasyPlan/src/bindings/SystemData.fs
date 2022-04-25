// ts2fable 0.7.1
module rec SystemData
open System
open Fable.Core
open Fable.Core.JS


module SystemData =

    type [<RequireQualifiedAccess>] SqlDbType =
        | BigInt = 0
        | Binary = 1
        | Bit = 2
        | Char = 3
        | DateTime = 4
        | Decimal = 5
        | Float = 6
        | Image = 7
        | Int = 8
        | Money = 9
        | NChar = 10
        | NText = 11
        | NVarChar = 12
        | Real = 13
        | UniqueIdentifier = 14
        | SmallDateTime = 15
        | SmallInt = 16
        | SmallMoney = 17
        | Text = 18
        | Timestamp = 19
        | TinyInt = 20
        | VarBinary = 21
        | VarChar = 22
        | Variant = 23
        | Xml = 25
        | Udt = 29
        | Structured = 30
        | Date = 31
        | Time = 32
        | DateTime2 = 33
        | DateTimeOffset = 34
