// ts2fable 0.7.1
module rec FileContainerClient
open System
open Fable.Core
open Fable.Core.JS

type IVssRestClientOptions = Context.IVssRestClientOptions
type RestClientBase = RestClientBase.RestClientBase

type [<AllowNullLiteral>] IExports =
    abstract FileContainerRestClient: FileContainerRestClientStatic

type [<AllowNullLiteral>] FileContainerRestClient =
    inherit RestClientBase
    /// <summary>Creates the specified items in in the referenced container.</summary>
    /// <param name="items">-</param>
    /// <param name="containerId">-</param>
    /// <param name="scope">- A guid representing the scope of the container. This is often the project id.</param>
    abstract createItems: items: WebApi.VssJsonCollectionWrapperV<ResizeArray<FileContainer.FileContainerItem>> * containerId: float * ?scope: string -> Promise<ResizeArray<FileContainer.FileContainerItem>>
    /// <summary>Deletes the specified items in a container.</summary>
    /// <param name="containerId">- Container Id.</param>
    /// <param name="itemPath">- Path to delete.</param>
    /// <param name="scope">- A guid representing the scope of the container. This is often the project id.</param>
    abstract deleteItem: containerId: float * itemPath: string * ?scope: string -> Promise<unit>
    /// <summary>Gets containers filtered by a comma separated list of artifact uris within the same scope, if not specified returns all containers</summary>
    /// <param name="scope">- A guid representing the scope of the container. This is often the project id.</param>
    /// <param name="artifactUris">-</param>
    abstract getContainers: ?scope: string * ?artifactUris: string -> Promise<ResizeArray<FileContainer.FileContainer>>
    /// <param name="containerId">-</param>
    /// <param name="scope">-</param>
    /// <param name="itemPath">-</param>
    /// <param name="metadata">-</param>
    /// <param name="format">-</param>
    /// <param name="downloadFileName">-</param>
    /// <param name="includeDownloadTickets">-</param>
    /// <param name="isShallow">-</param>
    abstract getItems: containerId: float * ?scope: string * ?itemPath: string * ?metadata: bool * ?format: string * ?downloadFileName: string * ?includeDownloadTickets: bool * ?isShallow: bool -> Promise<ResizeArray<FileContainer.FileContainerItem>>

type [<AllowNullLiteral>] FileContainerRestClientStatic =
    [<Emit "new $0($1...)">] abstract Create: options: IVssRestClientOptions -> FileContainerRestClient
