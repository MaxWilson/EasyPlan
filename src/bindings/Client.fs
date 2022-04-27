// ts2fable 0.7.1
module rec Client
open System
open Fable.Core
open Fable.Core.JS

type IVssRestClientOptions = Context.IVssRestClientOptions

type [<AllowNullLiteral>] IExports =
    abstract getClient: clientClass: RestClientFactory<'T> * ?clientOptions: IVssRestClientOptions -> 'T

type [<AllowNullLiteral>] RestClientFactory<'T> =
    [<Emit "new $0($1...)">] abstract Create: options: IVssRestClientOptions -> obj
    abstract RESOURCE_AREA_ID: string option with get, set

[<ImportAll("azure-devops-extension-api")>]
let exports: IExports = jsNative