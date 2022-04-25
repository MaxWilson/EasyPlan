// ts2fable 0.7.1
module rec OperationsClient
open System
open Fable.Core
open Fable.Core.JS
type IVssRestClientOptions = Context.IVssRestClientOptions
type RestClientBase = RestClientBase.RestClientBase

type [<AllowNullLiteral>] IExports =
    abstract OperationsRestClient: OperationsRestClientStatic

type [<AllowNullLiteral>] OperationsRestClient =
    inherit RestClientBase
    /// <summary>Gets an operation from the the operationId using the given pluginId.</summary>
    /// <param name="operationId">- The ID for the operation.</param>
    /// <param name="pluginId">- The ID for the plugin.</param>
    abstract getOperation: operationId: string * ?pluginId: string -> Promise<Operations.Operation>

type [<AllowNullLiteral>] OperationsRestClientStatic =
    [<Emit "new $0($1...)">] abstract Create: options: IVssRestClientOptions -> OperationsRestClient
