// ts2fable 0.7.1
module rec Core
open System
open Fable.Core
open Fable.Core.JS

type [<RequireQualifiedAccess>] ConnectedServiceKind =
    | Custom = 0
    | AzureSubscription = 1
    | Chef = 2
    | Generic = 3

type [<AllowNullLiteral>] IdentityData =
    abstract identityIds: ResizeArray<string> with get, set

type [<AllowNullLiteral>] Process =
    inherit ProcessReference
    abstract _links: obj option with get, set
    abstract description: string with get, set
    abstract id: string with get, set
    abstract isDefault: bool with get, set
    abstract ``type``: ProcessType with get, set

type [<RequireQualifiedAccess>] ProcessCustomizationType =
    | Unknown = -1
    | Xml = 0
    | Inherited = 1

type [<AllowNullLiteral>] ProcessReference =
    abstract name: string with get, set
    abstract url: string with get, set

type [<RequireQualifiedAccess>] ProcessType =
    | System = 0
    | Custom = 1
    | Inherited = 2

/// Contains the image data for project avatar.
type [<AllowNullLiteral>] ProjectAvatar =
    /// The avatar image represented as a byte array.
    abstract image: ResizeArray<float> with get, set

type [<RequireQualifiedAccess>] ProjectChangeType =
    | Modified = 0
    | Deleted = 1
    | Added = 2

/// Contains information describing a project.
type [<AllowNullLiteral>] ProjectInfo =
    /// The abbreviated name of the project.
    abstract abbreviation: string with get, set
    /// The description of the project.
    abstract description: string with get, set
    /// The id of the project.
    abstract id: string with get, set
    /// The time that this project was last updated.
    abstract lastUpdateTime: DateTime with get, set
    /// The name of the project.
    abstract name: string with get, set
    /// A set of name-value pairs storing additional property data related to the project.
    abstract properties: ResizeArray<ProjectProperty> with get, set
    /// The current revision of the project.
    abstract revision: int with get, set
    /// The current state of the project.
    abstract state: obj option with get, set
    /// A Uri that can be used to refer to this project.
    abstract uri: string with get, set
    /// The version number of the project.
    abstract version: int with get, set
    /// Indicates whom the project is visible to.
    abstract visibility: ProjectVisibility with get, set

type [<AllowNullLiteral>] ProjectMessage =
    abstract project: ProjectInfo with get, set
    abstract projectChangeType: ProjectChangeType with get, set
    abstract shouldInvalidateSystemStore: bool with get, set

type [<AllowNullLiteral>] ProjectProperties =
    /// The team project Id
    abstract projectId: string with get, set
    /// The collection of team project properties
    abstract properties: ResizeArray<ProjectProperty> with get, set

/// A named value associated with a project.
type [<AllowNullLiteral>] ProjectProperty =
    /// The name of the property.
    abstract name: string with get, set
    /// The value of the property.
    abstract value: obj option with get, set

type [<RequireQualifiedAccess>] ProjectVisibility =
    | Unchanged = -1
    | Private = 0
    | Organization = 1
    | Public = 2
    | SystemPrivate = 3

type [<AllowNullLiteral>] Proxy =
    abstract authorization: ProxyAuthorization with get, set
    /// This is a description string
    abstract description: string with get, set
    /// The friendly name of the server
    abstract friendlyName: string with get, set
    abstract globalDefault: bool with get, set
    /// This is a string representation of the site that the proxy server is located in (e.g. "NA-WA-RED")
    abstract site: string with get, set
    abstract siteDefault: bool with get, set
    /// The URL of the proxy server
    abstract url: string with get, set

type [<AllowNullLiteral>] ProxyAuthorization =
    /// Gets or sets the endpoint used to obtain access tokens from the configured token service.
    abstract authorizationUrl: string with get, set
    /// Gets or sets the client identifier for this proxy.
    abstract clientId: string with get, set
    /// Gets or sets the user identity to authorize for on-prem.
    abstract identity: Identities.IdentityDescriptor with get, set
    /// Gets or sets the public key used to verify the identity of this proxy. Only specify on hosted.
    abstract publicKey: WebApi.PublicKey with get, set

type [<RequireQualifiedAccess>] SourceControlTypes =
    | Tfvc = 1
    | Git = 2

/// The Team Context for an operation.
type [<AllowNullLiteral>] TeamContext =
    /// The team project Id or name.  Ignored if ProjectId is set.
    abstract project: string with get, set
    /// The Team Project ID.  Required if Project is not set.
    abstract projectId: string with get, set
    /// The Team Id or name.  Ignored if TeamId is set.
    abstract team: string with get, set
    /// The Team Id
    abstract teamId: string with get, set

/// Represents a Team Project object.
type [<AllowNullLiteral>] TeamProject =
    inherit TeamProjectReference
    /// The links to other objects related to this object.
    abstract _links: obj option with get, set
    /// Set of capabilities this project has (such as process template & version control).
    abstract capabilities: TeamProjectCapabilities with get, set
    /// The shallow ref to the default team.
    abstract defaultTeam: WebApiTeamRef with get, set

/// Data contract for a TeamProjectCollection.
type [<AllowNullLiteral>] TeamProjectCollection =
    inherit TeamProjectCollectionReference
    /// The links to other objects related to this object.
    abstract _links: obj option with get, set
    /// Project collection description.
    abstract description: string with get, set
    /// Process customization type on this collection. It can be Xml or Inherited.
    abstract processCustomizationType: ProcessCustomizationType with get, set
    /// Project collection state.
    abstract state: string with get, set

/// Reference object for a TeamProjectCollection.
type [<AllowNullLiteral>] TeamProjectCollectionReference =
    /// Collection Id.
    abstract id: string with get, set
    /// Collection Name.
    abstract name: string with get, set
    /// Collection REST Url.
    abstract url: string with get, set

/// Represents a shallow reference to a TeamProject.
type [<AllowNullLiteral>] TeamProjectReference =
    /// Project abbreviation.
    abstract abbreviation: string with get, set
    /// Url to default team identity image.
    abstract defaultTeamImageUrl: string with get, set
    /// The project's description (if any).
    abstract description: string with get, set
    /// Project identifier.
    abstract id: string with get, set
    /// Project last update time.
    abstract lastUpdateTime: DateTime with get, set
    /// Project name.
    abstract name: string with get, set
    /// Project revision.
    abstract revision: int with get, set
    /// Project state.
    abstract state: obj option with get, set
    /// Url to the full version of the object.
    abstract url: string with get, set
    /// Project visibility.
    abstract visibility: ProjectVisibility with get, set

/// A data transfer object that stores the metadata associated with the creation of temporary data.
type [<AllowNullLiteral>] TemporaryDataCreatedDTO =
    inherit TemporaryDataDTO
    abstract expirationDate: DateTime with get, set
    abstract id: string with get, set
    abstract url: string with get, set

/// A data transfer object that stores the metadata associated with the temporary data.
type [<AllowNullLiteral>] TemporaryDataDTO =
    abstract expirationSeconds: int with get, set
    abstract origin: string with get, set
    abstract value: obj option with get, set

/// Updateable properties for a WebApiTeam.
type [<AllowNullLiteral>] UpdateTeam =
    /// New description for the team.
    abstract description: string with get, set
    /// New name for the team.
    abstract name: string with get, set

type [<AllowNullLiteral>] WebApiConnectedService =
    inherit WebApiConnectedServiceRef
    /// The user who did the OAuth authentication to created this service
    abstract authenticatedBy: WebApi.IdentityRef with get, set
    /// Extra description on the service.
    abstract description: string with get, set
    /// Friendly Name of service connection
    abstract friendlyName: string with get, set
    /// Id/Name of the connection service. For Ex: Subscription Id for Azure Connection
    abstract id: string with get, set
    /// The kind of service.
    abstract kind: string with get, set
    /// The project associated with this service
    abstract project: TeamProjectReference with get, set
    /// Optional uri to connect directly to the service such as https://windows.azure.com
    abstract serviceUri: string with get, set

type [<AllowNullLiteral>] WebApiConnectedServiceDetails =
    inherit WebApiConnectedServiceRef
    /// Meta data for service connection
    abstract connectedServiceMetaData: WebApiConnectedService with get, set
    /// Credential info
    abstract credentialsXml: string with get, set
    /// Optional uri to connect directly to the service such as https://windows.azure.com
    abstract endPoint: string with get, set

type [<AllowNullLiteral>] WebApiConnectedServiceRef =
    abstract id: string with get, set
    abstract url: string with get, set

/// The representation of data needed to create a tag definition which is sent across the wire.
type [<AllowNullLiteral>] WebApiCreateTagRequestData =
    /// Name of the tag definition that will be created.
    abstract name: string with get, set

type [<AllowNullLiteral>] WebApiProject =
    inherit TeamProjectReference
    /// Set of capabilities this project has
    abstract capabilities: TeamProjectCapabilities with get, set
    /// Reference to collection which contains this project
    abstract collection: WebApiProjectCollectionRef with get, set
    /// Default team for this project
    abstract defaultTeam: WebApiTeamRef with get, set

type [<AllowNullLiteral>] WebApiProjectCollection =
    inherit WebApiProjectCollectionRef
    /// Project collection description
    abstract description: string with get, set
    /// Project collection state
    abstract state: string with get, set

type [<AllowNullLiteral>] WebApiProjectCollectionRef =
    /// Collection Tfs Url (Host Url)
    abstract collectionUrl: string with get, set
    /// Collection Guid
    abstract id: string with get, set
    /// Collection Name
    abstract name: string with get, set
    /// Collection REST Url
    abstract url: string with get, set

/// The representation of a tag definition which is sent across the wire.
type [<AllowNullLiteral>] WebApiTagDefinition =
    /// Whether or not the tag definition is active.
    abstract active: bool with get, set
    /// ID of the tag definition.
    abstract id: string with get, set
    /// The name of the tag definition.
    abstract name: string with get, set
    /// Resource URL for the Tag Definition.
    abstract url: string with get, set

type [<AllowNullLiteral>] WebApiTeam =
    inherit WebApiTeamRef
    /// Team description
    abstract description: string with get, set
    /// Team identity.
    abstract identity: Identities.Identity with get, set
    /// Identity REST API Url to this team
    abstract identityUrl: string with get, set
    abstract projectId: string with get, set
    abstract projectName: string with get, set

type [<AllowNullLiteral>] WebApiTeamRef =
    /// Team (Identity) Guid. A Team Foundation ID.
    abstract id: string with get, set
    /// Team name
    abstract name: string with get, set
    /// Team REST API Url
    abstract url: string with get, set

type [<AllowNullLiteral>] TeamProjectCapabilitiesItem =
    [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> string with get, set

type [<AllowNullLiteral>] TeamProjectCapabilities =
    [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> TeamProjectCapabilitiesItem with get, set
