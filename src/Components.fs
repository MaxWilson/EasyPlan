module Components

open Feliz
open Feliz.Router
open Fable.Core
open Fable.Core.JsInterop

// Apparently prop.type'.date must be in a ReactComponent in order for prop.onChange to work
[<ReactComponent>]
let SimpleDateInput(selectedDate: System.DateTime option, visible, updateDate: System.DateTime -> _) =
    let currentDate, update = React.useState selectedDate
    let updateDate (v: System.DateTime) =
        update (Some v)
        updateDate v
    Html.input [
        prop.type'.date
        if currentDate.IsSome then
            prop.value currentDate.Value
        prop.onChange (fun newValue -> updateDate newValue)
        if not visible then prop.className "hidden";
    ]

[<Emit("typeof $0")>]
let jsTypeof (_ : obj) : string = jsNative
[<Emit("$0[$1]")>]
let jsLookup (_ : obj) (key:string) : obj option = jsNative
[<Emit("$0 instanceof Date")>]
let isJSDate (_ : obj) : bool = jsNative
[<Emit("Intl.DateTimeFormat().resolvedOptions().Locale")>]
let inline jsCurrentLocale() : string = jsNative
let currentLocale =
    try
        jsCurrentLocale()
    with _ -> "en-US"
[<Emit("$1.toLocaleDateString($0, { weekday: 'short', month: 'short', day: 'numeric' })")>]
let convertJSDateToLocaleString (locale:string) (_ : System.DateTime) : string = jsNative
let convertJSDateToString (date : System.DateTime) : string = convertJSDateToLocaleString currentLocale date

let class' ctor (className:string) (elements : _ list) =
    ctor [prop.className className; prop.children elements]
