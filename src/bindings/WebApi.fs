// ts2fable 0.7.1
module rec WebApi
open System
open Fable.Core
open Fable.Core.JS

/// Information about the location of a REST API resource
type [<AllowNullLiteral>] ApiResourceLocation =
    /// Area name for this resource
    abstract area: string with get, set
    /// Unique Identifier for this location
    abstract id: string with get, set
    /// Maximum api version that this resource supports (current server version for this resource)
    abstract maxVersion: string with get, set
    /// Minimum api version that this resource supports
    abstract minVersion: string with get, set
    /// The latest version of this resource location that is in "Release" (non-preview) mode
    abstract releasedVersion: string with get, set
    /// Resource name
    abstract resourceName: string with get, set
    /// The current resource version supported by this resource location
    abstract resourceVersion: float with get, set
    /// This location's route template (templated relative path)
    abstract routeTemplate: string with get, set

/// Represents version information for a REST Api resource
type [<AllowNullLiteral>] ApiResourceVersion =
    /// String representation of the Public API version. This is the version that the public sees and is used for a large group of services (e.g. the TFS 1.0 API)
    abstract apiVersion: string with get, set
    /// Is the public API version in preview
    abstract isPreview: bool with get, set
    /// Internal resource version. This is defined per-resource and is used to support build-to-build compatibility of API changes within a given (in-preview) public api version. For example, within the TFS 1.0 API release cycle, while it is still in preview, a resource's data structure may be changed. This resource can be versioned such that older clients will still work (requests will be sent to the older version) and new/upgraded clients will talk to the new version of the resource.
    abstract resourceVersion: float with get, set

type [<RequireQualifiedAccess>] ConnectOptions =
    | None = 0
    | IncludeServices = 1
    | IncludeLastUserAccess = 2
    | IncludeInheritedDefinitionsOnly = 4
    | IncludeNonInheritedDefinitionsOnly = 8

type [<RequireQualifiedAccess>] DeploymentFlags =
    | None = 0
    | Hosted = 1
    | OnPremises = 2

/// Defines an "actor" for an event.
type [<AllowNullLiteral>] EventActor =
    /// Required: This is the identity of the user for the specified role.
    abstract id: string with get, set
    /// Required: The event specific name of a role.
    abstract role: string with get, set

/// Defines a scope for an event.
type [<AllowNullLiteral>] EventScope =
    /// Required: This is the identity of the scope for the type.
    abstract id: string with get, set
    /// Optional: The display name of the scope
    abstract name: string with get, set
    /// Required: The event specific type of a scope.
    abstract ``type``: string with get, set

type [<AllowNullLiteral>] IdentityRef =
    inherit Graph.GraphSubjectBase
    /// Deprecated - Can be retrieved by querying the Graph user referenced in the "self" entry of the IdentityRef "_links" dictionary
    abstract directoryAlias: string with get, set
    abstract id: string with get, set
    /// Deprecated - Available in the "avatar" entry of the IdentityRef "_links" dictionary
    abstract imageUrl: string with get, set
    /// Deprecated - Can be retrieved by querying the Graph membership state referenced in the "membershipState" entry of the GraphUser "_links" dictionary
    abstract inactive: bool with get, set
    /// Deprecated - Can be inferred from the subject type of the descriptor (Descriptor.IsAadUserType/Descriptor.IsAadGroupType)
    abstract isAadIdentity: bool with get, set
    /// Deprecated - Can be inferred from the subject type of the descriptor (Descriptor.IsGroupType)
    abstract isContainer: bool with get, set
    abstract isDeletedInOrigin: bool with get, set
    /// Deprecated - not in use in most preexisting implementations of ToIdentityRef
    abstract profileUrl: string with get, set
    /// Deprecated - use Domain+PrincipalName instead
    abstract uniqueName: string with get, set

type [<AllowNullLiteral>] IdentityRefWithEmail =
    inherit IdentityRef
    abstract preferredEmailAddress: string with get, set

/// The JSON model for JSON Patch Operations
type [<AllowNullLiteral>] JsonPatchDocument =
    interface end

/// The JSON model for a JSON Patch operation
type [<AllowNullLiteral>] JsonPatchOperation =
    /// The path to copy from for the Move/Copy operation.
    abstract from: string with get, set
    /// The patch operation
    abstract op: Operation with get, set
    /// The path for the operation. In the case of an array, a zero based index can be used to specify the position in the array (e.g. /biscuits/0/name). The "-" character can be used instead of an index to insert at the end of the array (e.g. /biscuits/-).
    abstract path: string with get, set
    /// The value for the operation. This is either a primitive or a JToken.
    abstract value: obj option with get, set

type [<AllowNullLiteral>] JsonWebToken =
    interface end

type [<RequireQualifiedAccess>] JWTAlgorithm =
    | None = 0
    | HS256 = 1
    | RS256 = 2

type [<RequireQualifiedAccess>] Operation =
    | Add = 0
    | Remove = 1
    | Replace = 2
    | Move = 3
    | Copy = 4
    | Test = 5

type [<AllowNullLiteral>] PagedList<'T> =
    interface end

/// Represents the public key portion of an RSA asymmetric key.
type [<AllowNullLiteral>] PublicKey =
    /// Gets or sets the exponent for the public key.
    abstract exponent: ResizeArray<float> with get, set
    /// Gets or sets the modulus for the public key.
    abstract modulus: ResizeArray<float> with get, set

type [<AllowNullLiteral>] Publisher =
    /// Name of the publishing service.
    abstract name: string with get, set
    /// Service Owner Guid Eg. Tfs : 00025394-6065-48CA-87D9-7F5672854EF7
    abstract serviceOwnerId: string with get, set

/// The class to represent a REST reference link.  RFC: http://tools.ietf.org/html/draft-kelly-json-hal-06  The RFC is not fully implemented, additional properties are allowed on the reference link but as of yet we don't have a need for them.
type [<AllowNullLiteral>] ReferenceLink =
    abstract href: string with get, set

type [<AllowNullLiteral>] ResourceRef =
    abstract id: string with get, set
    abstract url: string with get, set

type [<AllowNullLiteral>] ServiceEvent =
    /// This is the id of the type. Constants that will be used by subscribers to identify/filter events being published on a topic.
    abstract eventType: string with get, set
    /// This is the service that published this event.
    abstract publisher: Publisher with get, set
    /// The resource object that carries specific information about the event. The object must have the ServiceEventObject applied for serialization/deserialization to work.
    abstract resource: obj option with get, set
    /// This dictionary carries the context descriptors along with their ids.
    abstract resourceContainers: ServiceEventResourceContainers with get, set
    /// This is the version of the resource.
    abstract resourceVersion: string with get, set

/// A signed url allowing limited-time anonymous access to private resources.
type [<AllowNullLiteral>] SignedUrl =
    abstract signatureExpires: DateTime with get, set
    abstract url: string with get, set

type [<AllowNullLiteral>] TeamMember =
    abstract identity: IdentityRef with get, set
    abstract isTeamAdmin: bool with get, set

/// A single secured timing consisting of a duration and start time
type [<AllowNullLiteral>] TimingEntry =
    /// Duration of the entry in ticks
    abstract elapsedTicks: float with get, set
    /// Properties to distinguish timings within the same group or to provide data to send with telemetry
    abstract properties: ServiceEventResourceContainers with get, set
    /// Offset from Server Request Context start time in microseconds
    abstract startOffset: float with get, set

/// A set of secured performance timings all keyed off of the same string
type [<AllowNullLiteral>] TimingGroup =
    /// The total number of timing entries associated with this group
    abstract count: float with get, set
    /// Overall duration of all entries in this group in ticks
    abstract elapsedTicks: float with get, set
    /// A list of timing entries in this group. Only the first few entries in each group are collected.
    abstract timings: ResizeArray<TimingEntry> with get, set

/// This class describes a trace filter, i.e. a set of criteria on whether or not a trace event should be emitted
type [<AllowNullLiteral>] TraceFilter =
    abstract area: string with get, set
    abstract exceptionType: string with get, set
    abstract isEnabled: bool with get, set
    abstract layer: string with get, set
    abstract level: float with get, set
    abstract ``method``: string with get, set
    /// Used to serialize additional identity information (display name, etc) to clients. Not set by default. Server-side callers should use OwnerId.
    abstract owner: IdentityRef with get, set
    abstract ownerId: string with get, set
    abstract path: string with get, set
    abstract processName: string with get, set
    abstract service: string with get, set
    abstract serviceHost: string with get, set
    abstract timeCreated: DateTime with get, set
    abstract traceId: string with get, set
    abstract tracepoint: float with get, set
    abstract uri: string with get, set
    abstract userAgent: string with get, set
    abstract userLogin: string with get, set

type [<AllowNullLiteral>] VssJsonCollectionWrapper =
    inherit VssJsonCollectionWrapperBase
    abstract value: ResizeArray<obj option> with get, set

/// This class is used to serialized collections as a single JSON object on the wire, to avoid serializing JSON arrays directly to the client, which can be a security hole
type [<AllowNullLiteral>] VssJsonCollectionWrapperV<'T> =
    inherit VssJsonCollectionWrapperBase
    abstract value: 'T with get, set

type [<AllowNullLiteral>] VssJsonCollectionWrapperBase =
    abstract count: float with get, set

/// This is the type used for firing notifications intended for the subsystem in the Notifications SDK. For components that can't take a dependency on the Notifications SDK directly, they can use ITeamFoundationEventService.PublishNotification and the Notifications SDK ISubscriber implementation will get it.
type [<AllowNullLiteral>] VssNotificationEvent =
    /// Optional: A list of actors which are additional identities with corresponding roles that are relevant to the event.
    abstract actors: ResizeArray<EventActor> with get, set
    /// Optional: A list of artifacts referenced or impacted by this event.
    abstract artifactUris: ResizeArray<string> with get, set
    /// Required: The event payload.  If Data is a string, it must be in Json or XML format.  Otherwise it must have a serialization format attribute.
    abstract data: obj option with get, set
    /// Required: The name of the event.  This event must be registered in the context it is being fired.
    abstract eventType: string with get, set
    /// How long before the event expires and will be cleaned up.  The default is to use the system default.
    abstract expiresIn: obj option with get, set
    /// The id of the item, artifact, extension, project, etc.
    abstract itemId: string with get, set
    /// How long to wait before processing this event.  The default is to process immediately.
    abstract processDelay: obj option with get, set
    /// Optional: A list of scopes which are are relevant to the event.
    abstract scopes: ResizeArray<EventScope> with get, set
    /// This is the time the original source event for this VssNotificationEvent was created.  For example, for something like a build completion notification SourceEventCreatedTime should be the time the build finished not the time this event was raised.
    abstract sourceEventCreatedTime: DateTime with get, set

type [<AllowNullLiteral>] WrappedException =
    abstract customProperties: ServiceEventResourceContainers with get, set
    abstract errorCode: float with get, set
    abstract eventId: float with get, set
    abstract helpLink: string with get, set
    abstract innerException: WrappedException with get, set
    abstract message: string with get, set
    abstract stackTrace: string with get, set
    abstract typeKey: string with get, set
    abstract typeName: string with get, set

type [<AllowNullLiteral>] ServiceEventResourceContainers =
    [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set
