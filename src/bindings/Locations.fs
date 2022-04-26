// ts2fable 0.7.1
module rec Locations
open System
open Fable.Core
open Fable.Core.JS

type [<AllowNullLiteral>] AccessMapping =
    abstract accessPoint: string with get, set
    abstract displayName: string with get, set
    abstract moniker: string with get, set
    /// The service which owns this access mapping e.g. TFS, ELS, etc.
    abstract serviceOwner: string with get, set
    /// Part of the access mapping which applies context after the access point of the server.
    abstract virtualDirectory: string with get, set

/// Data transfer class that holds information needed to set up a connection with a VSS server.
type [<AllowNullLiteral>] ConnectionData =
    /// The Id of the authenticated user who made this request. More information about the user can be obtained by passing this Id to the Identity service
    abstract authenticatedUser: Identities.Identity with get, set
    /// The Id of the authorized user who made this request. More information about the user can be obtained by passing this Id to the Identity service
    abstract authorizedUser: Identities.Identity with get, set
    /// The id for the server.
    abstract deploymentId: string with get, set
    /// The type for the server Hosted/OnPremises.
    abstract deploymentType: WebApi.DeploymentFlags with get, set
    /// The instance id for this host.
    abstract instanceId: string with get, set
    /// The last user access for this instance.  Null if not requested specifically.
    abstract lastUserAccess: DateTime with get, set
    /// Data that the location service holds.
    abstract locationServiceData: LocationServiceData with get, set
    /// The virtual directory of the host we are talking to.
    abstract webApplicationRelativeDirectory: string with get, set

type [<RequireQualifiedAccess>] InheritLevel =
    | None = 0
    | Deployment = 1
    | Account = 2
    | Collection = 4
    | All = 7

type [<AllowNullLiteral>] LocationMapping =
    abstract accessMappingMoniker: string with get, set
    abstract location: string with get, set

/// Data transfer class used to transfer data about the location service data over the web service.
type [<AllowNullLiteral>] LocationServiceData =
    /// Data about the access mappings contained by this location service.
    abstract accessMappings: ResizeArray<AccessMapping> with get, set
    /// Data that the location service holds.
    abstract clientCacheFresh: bool with get, set
    /// The time to live on the location service cache.
    abstract clientCacheTimeToLive: float with get, set
    /// The default access mapping moniker for the server.
    abstract defaultAccessMappingMoniker: string with get, set
    /// The obsolete id for the last change that took place on the server (use LastChangeId64).
    abstract lastChangeId: float with get, set
    /// The non-truncated 64-bit id for the last change that took place on the server.
    abstract lastChangeId64: float with get, set
    /// Data about the service definitions contained by this location service.
    abstract serviceDefinitions: ResizeArray<ServiceDefinition> with get, set
    /// The identifier of the deployment which is hosting this location data (e.g. SPS, TFS, ELS, Napa, etc.)
    abstract serviceOwner: string with get, set

type [<RequireQualifiedAccess>] RelativeToSetting =
    | Context = 0
    | WebApplication = 2
    | FullyQualified = 3

type [<AllowNullLiteral>] ResourceAreaInfo =
    abstract id: string with get, set
    abstract locationUrl: string with get, set
    abstract name: string with get, set

type [<AllowNullLiteral>] ServiceDefinition =
    abstract description: string with get, set
    abstract displayName: string with get, set
    abstract identifier: string with get, set
    abstract inheritLevel: InheritLevel with get, set
    abstract locationMappings: ResizeArray<LocationMapping> with get, set
    /// Maximum api version that this resource supports (current server version for this resource). Copied from \<c\>ApiResourceLocation\</c\>.
    abstract maxVersion: string with get, set
    /// Minimum api version that this resource supports. Copied from \<c\>ApiResourceLocation\</c\>.
    abstract minVersion: string with get, set
    abstract parentIdentifier: string with get, set
    abstract parentServiceType: string with get, set
    abstract properties: obj option with get, set
    abstract relativePath: string with get, set
    abstract relativeToSetting: RelativeToSetting with get, set
    /// The latest version of this resource location that is in "Release" (non-preview) mode. Copied from \<c\>ApiResourceLocation\</c\>.
    abstract releasedVersion: string with get, set
    /// The current resource version supported by this resource location. Copied from \<c\>ApiResourceLocation\</c\>.
    abstract resourceVersion: float with get, set
    /// The service which owns this definition e.g. TFS, ELS, etc.
    abstract serviceOwner: string with get, set
    abstract serviceType: string with get, set
    abstract status: ServiceStatus with get, set
    abstract toolId: string with get, set

type [<RequireQualifiedAccess>] ServiceStatus =
    | Assigned = 0
    | Active = 1
    | Moving = 2
