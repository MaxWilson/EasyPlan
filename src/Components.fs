module Components

open Feliz
open Feliz.Router
open Fable.Core
open Fable.Core.JsInterop

type Components =
    /// <summary>
    /// The simplest possible React component.
    /// Shows a header with the text Hello World
    /// </summary>
    [<ReactComponent>]
    static member HelloWorld() = Html.h1 "Hello World"

    /// <summary>
    /// A stateful React component that maintains a counter
    /// </summary>
    [<ReactComponent>]
    static member Counter() =
        let (count, setCount) = React.useState(0)
        Html.div [
            Html.h1 count
            Html.button [
                prop.onClick (fun _ -> setCount(count + 1))
                prop.text "Increment"
            ]
        ]

    /// <summary>
    /// A React component that uses Feliz.Router
    /// to determine what to show based on the current URL
    /// </summary>
    [<ReactComponent>]
    static member Router() =
        let (currentUrl, updateUrl) = React.useState(Router.currentUrl())
        React.router [
            router.onUrlChanged updateUrl
            router.children [
                match currentUrl with
                | [ ] -> Html.h1 "Index"
                | [ "hello" ] -> Components.HelloWorld()
                | [ "counter" ] -> Components.Counter()
                | otherwise -> Html.h1 "Not found"
            ]
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
