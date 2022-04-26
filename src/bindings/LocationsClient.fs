// ts2fable 0.7.1
module rec LocationsClient
open System
open Fable.Core
open Fable.Core.JS

type IVssRestClientOptions = Context.IVssRestClientOptions
type RestClientBase = RestClientBase.RestClientBase

type [<AllowNullLiteral>] IExports =
    abstract LocationsRestClient: LocationsRestClientStatic

type [<AllowNullLiteral>] LocationsRestClient =
    inherit RestClientBase
    /// <summary>This was copied and adapted from TeamFoundationConnectionService.Connect()</summary>
    /// <param name="connectOptions">-</param>
    /// <param name="lastChangeId">- Obsolete 32-bit LastChangeId</param>
    /// <param name="lastChangeId64">- Non-truncated 64-bit LastChangeId</param>
    abstract getConnectionData: ?connectOptions: WebApi.ConnectOptions * ?lastChangeId: float * ?lastChangeId64: float -> Promise<Locations.ConnectionData>
    /// <param name="areaId">-</param>
    /// <param name="enterpriseName">-</param>
    /// <param name="organizationName">-</param>
    abstract getResourceArea: areaId: string * ?enterpriseName: string * ?organizationName: string -> Promise<Locations.ResourceAreaInfo>
    /// <param name="areaId">-</param>
    /// <param name="hostId">-</param>
    abstract getResourceAreaByHost: areaId: string * hostId: string -> Promise<Locations.ResourceAreaInfo>
    /// <param name="enterpriseName">-</param>
    /// <param name="organizationName">-</param>
    abstract getResourceAreas: ?enterpriseName: string * ?organizationName: string -> Promise<ResizeArray<Locations.ResourceAreaInfo>>
    /// <param name="hostId">-</param>
    abstract getResourceAreasByHost: hostId: string -> Promise<ResizeArray<Locations.ResourceAreaInfo>>
    /// <param name="serviceType">-</param>
    /// <param name="identifier">-</param>
    abstract deleteServiceDefinition: serviceType: string * identifier: string -> Promise<unit>
    /// <summary>Finds a given service definition.</summary>
    /// <param name="serviceType">-</param>
    /// <param name="identifier">-</param>
    /// <param name="allowFaultIn">- If true, we will attempt to fault in a host instance mapping if in SPS.</param>
    /// <param name="previewFaultIn">- If true, we will calculate and return a host instance mapping, but not persist it.</param>
    abstract getServiceDefinition: serviceType: string * identifier: string * ?allowFaultIn: bool * ?previewFaultIn: bool -> Promise<Locations.ServiceDefinition>
    /// <param name="serviceType">-</param>
    abstract getServiceDefinitions: ?serviceType: string -> Promise<ResizeArray<Locations.ServiceDefinition>>
    /// <param name="serviceDefinitions">-</param>
    abstract updateServiceDefinitions: serviceDefinitions: WebApi.VssJsonCollectionWrapperV<ResizeArray<Locations.ServiceDefinition>> -> Promise<unit>

type [<AllowNullLiteral>] LocationsRestClientStatic =
    [<Emit "new $0($1...)">] abstract Create: options: IVssRestClientOptions -> LocationsRestClient
