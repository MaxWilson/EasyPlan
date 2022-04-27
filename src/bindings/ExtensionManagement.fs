// ts2fable 0.7.1
module rec ExtensionManagement
open System
open Fable.Core
open Fable.Core.JS
type [<RequireQualifiedAccess>] AcquisitionAssignmentType =
    | None = 0
    | Me = 1
    | All = 2

type [<AllowNullLiteral>] AcquisitionOperation =
    /// State of the the AcquisitionOperation for the current user
    abstract operationState: AcquisitionOperationState with get, set
    /// AcquisitionOperationType: install, request, buy, etc...
    abstract operationType: AcquisitionOperationType with get, set
    /// Optional reason to justify current state. Typically used with Disallow state.
    abstract reason: string with get, set
    /// List of reasons indicating why the operation is not allowed.
    abstract reasons: ResizeArray<AcquisitionOperationDisallowReason> with get, set

type [<AllowNullLiteral>] AcquisitionOperationDisallowReason =
    /// User-friendly message clarifying the reason for disallowance
    abstract message: string with get, set
    /// Type of reason for disallowance - AlreadyInstalled, UnresolvedDemand, etc.
    abstract ``type``: string with get, set

type [<RequireQualifiedAccess>] AcquisitionOperationState =
    | Disallow = 0
    | Allow = 1
    | Completed = 3

type [<RequireQualifiedAccess>] AcquisitionOperationType =
    | Get = 0
    | Install = 1
    | Buy = 2
    | Try = 3
    | Request = 4
    | None = 5
    | PurchaseRequest = 6

/// Market item acquisition options (install, buy, etc) for an installation target.
type [<AllowNullLiteral>] AcquisitionOptions =
    /// Default Operation for the ItemId in this target
    abstract defaultOperation: AcquisitionOperation with get, set
    /// The item id that this options refer to
    abstract itemId: string with get, set
    /// Operations allowed for the ItemId in this target
    abstract operations: ResizeArray<AcquisitionOperation> with get, set
    /// Additional properties which can be added to the request.
    abstract properties: obj option with get, set
    /// The target that this options refer to
    abstract target: string with get, set

/// Representation of a ContributionNode that can be used for serialized to clients.
type [<AllowNullLiteral>] ClientContribution =
    /// Description of the contribution/type
    abstract description: string with get, set
    /// Fully qualified identifier of the contribution/type
    abstract id: string with get, set
    /// Includes is a set of contributions that should have this contribution included in their targets list.
    abstract includes: ResizeArray<string> with get, set
    /// Properties/attributes of this contribution
    abstract properties: obj option with get, set
    /// The ids of the contribution(s) that this contribution targets. (parent contributions)
    abstract targets: ResizeArray<string> with get, set
    /// Id of the Contribution Type
    abstract ``type``: string with get, set

/// Representation of a ContributionNode that can be used for serialized to clients.
type [<AllowNullLiteral>] ClientContributionNode =
    /// List of ids for contributions which are children to the current contribution.
    abstract children: ResizeArray<string> with get, set
    /// Contribution associated with this node.
    abstract contribution: ClientContribution with get, set
    /// List of ids for contributions which are parents to the current contribution.
    abstract parents: ResizeArray<string> with get, set

type [<AllowNullLiteral>] ClientContributionProviderDetails =
    /// Friendly name for the provider.
    abstract displayName: string with get, set
    /// Unique identifier for this provider. The provider name can be used to cache the contribution data and refer back to it when looking for changes
    abstract name: string with get, set
    /// Properties associated with the provider
    abstract properties: ClientContributionProviderDetailsProperties with get, set
    /// Version of contributions associated with this contribution provider.
    abstract version: string with get, set

/// A client data provider are the details needed to make the data provider request from the client.
type [<AllowNullLiteral>] ClientDataProviderQuery =
    inherit DataProviderQuery
    /// The Id of the service instance type that should be communicated with in order to resolve the data providers from the client given the query values.
    abstract queryServiceInstanceType: string with get, set

/// An individual contribution made by an extension
type [<AllowNullLiteral>] Contribution =
    inherit ContributionBase
    /// List of constraints (filters) that should be applied to the availability of this contribution
    abstract constraints: ResizeArray<ContributionConstraint> with get, set
    /// Includes is a set of contributions that should have this contribution included in their targets list.
    abstract includes: ResizeArray<string> with get, set
    /// Properties/attributes of this contribution
    abstract properties: obj option with get, set
    /// List of demanded claims in order for the user to see this contribution (like anonymous, public, member...).
    abstract restrictedTo: ResizeArray<string> with get, set
    /// The ids of the contribution(s) that this contribution targets. (parent contributions)
    abstract targets: ResizeArray<string> with get, set
    /// Id of the Contribution Type
    abstract ``type``: string with get, set

/// Base class shared by contributions and contribution types
type [<AllowNullLiteral>] ContributionBase =
    /// Description of the contribution/type
    abstract description: string with get, set
    /// Fully qualified identifier of the contribution/type
    abstract id: string with get, set
    /// VisibleTo can be used to restrict whom can reference a given contribution/type. This value should be a list of publishers or extensions access is restricted too.  Examples: "ms" - Means only the "ms" publisher can reference this. "ms.vss-web" - Means only the "vss-web" extension from the "ms" publisher can reference this.
    abstract visibleTo: ResizeArray<string> with get, set

/// Specifies a constraint that can be used to dynamically include/exclude a given contribution
type [<AllowNullLiteral>] ContributionConstraint =
    /// An optional property that can be specified to group constraints together. All constraints within a group are AND'd together (all must be evaluate to True in order for the contribution to be included). Different groups of constraints are OR'd (only one group needs to evaluate to True for the contribution to be included).
    abstract group: int with get, set
    /// Fully qualified identifier of a shared constraint
    abstract id: string with get, set
    /// If true, negate the result of the filter (include the contribution if the applied filter returns false instead of true)
    abstract inverse: bool with get, set
    /// Name of the IContributionFilter plugin
    abstract name: string with get, set
    /// Properties that are fed to the contribution filter class
    abstract properties: obj option with get, set
    /// Constraints can be optionally be applied to one or more of the relationships defined in the contribution. If no relationships are defined then all relationships are associated with the constraint. This means the default behaviour will elimiate the contribution from the tree completely if the constraint is applied.
    abstract relationships: ResizeArray<string> with get, set

type [<RequireQualifiedAccess>] ContributionLicensingBehaviorType =
    | OnlyIfLicensed = 0
    | OnlyIfUnlicensed = 1
    | AlwaysInclude = 2

/// A query that can be issued for contribution nodes
type [<AllowNullLiteral>] ContributionNodeQuery =
    /// The contribution ids of the nodes to find.
    abstract contributionIds: ResizeArray<string> with get, set
    /// Contextual information that can be leveraged by contribution constraints
    abstract dataProviderContext: DataProviderContext with get, set
    /// Indicator if contribution provider details should be included in the result.
    abstract includeProviderDetails: bool with get, set
    /// Query options tpo be used when fetching ContributionNodes
    abstract queryOptions: ContributionQueryOptions with get, set

/// Result of a contribution node query.  Wraps the resulting contribution nodes and provider details.
type [<AllowNullLiteral>] ContributionNodeQueryResult =
    /// Map of contribution ids to corresponding node.
    abstract nodes: ContributionNodeQueryResultNodes with get, set
    /// Map of provider ids to the corresponding provider details object.
    abstract providerDetails: ContributionNodeQueryResultProviderDetails with get, set

/// Description about a property of a contribution type
type [<AllowNullLiteral>] ContributionPropertyDescription =
    /// Description of the property
    abstract description: string with get, set
    /// Name of the property
    abstract name: string with get, set
    /// True if this property is required
    abstract required: bool with get, set
    /// The type of value used for this property
    abstract ``type``: ContributionPropertyType with get, set

type [<RequireQualifiedAccess>] ContributionPropertyType =
    | Unknown = 0
    | String = 1
    | Uri = 2
    | Guid = 4
    | Boolean = 8
    | Integer = 16
    | Double = 32
    | DateTime = 64
    | Dictionary = 128
    | Array = 256
    | Object = 512

type [<AllowNullLiteral>] ContributionProviderDetails =
    /// Friendly name for the provider.
    abstract displayName: string with get, set
    /// Unique identifier for this provider. The provider name can be used to cache the contribution data and refer back to it when looking for changes
    abstract name: string with get, set
    /// Properties associated with the provider
    abstract properties: ClientContributionProviderDetailsProperties with get, set
    /// Version of contributions associated with this contribution provider.
    abstract version: string with get, set

type [<RequireQualifiedAccess>] ContributionQueryOptions =
    | None = 0
    | IncludeSelf = 16
    | IncludeChildren = 32
    | IncludeSubTree = 96
    | IncludeAll = 112
    | IgnoreConstraints = 256

/// A contribution type, given by a json schema
type [<AllowNullLiteral>] ContributionType =
    inherit ContributionBase
    /// Controls whether or not contributions of this type have the type indexed for queries. This allows clients to find all extensions that have a contribution of this type.  NOTE: Only TrustedPartners are allowed to specify indexed contribution types.
    abstract indexed: bool with get, set
    /// Friendly name of the contribution/type
    abstract name: string with get, set
    /// Describes the allowed properties for this contribution type
    abstract properties: ContributionTypeProperties with get, set

/// Contextual information that data providers can examine when populating their data
type [<AllowNullLiteral>] DataProviderContext =
    /// Generic property bag that contains context-specific properties that data providers can use when populating their data dictionary
    abstract properties: DataProviderContextProperties with get, set

type [<AllowNullLiteral>] DataProviderExceptionDetails =
    /// The type of the exception that was thrown.
    abstract exceptionType: string with get, set
    /// Message that is associated with the exception.
    abstract message: string with get, set
    /// The StackTrace from the exception turned into a string.
    abstract stackTrace: string with get, set

/// A query that can be issued for data provider data
type [<AllowNullLiteral>] DataProviderQuery =
    /// Contextual information to pass to the data providers
    abstract context: DataProviderContext with get, set
    /// The contribution ids of the data providers to resolve
    abstract contributionIds: ResizeArray<string> with get, set

/// Result structure from calls to GetDataProviderData
type [<AllowNullLiteral>] DataProviderResult =
    /// This is the set of data providers that were requested, but either they were defined as client providers, or as remote providers that failed and may be retried by the client.
    abstract clientProviders: DataProviderResultClientProviders with get, set
    /// Property bag of data keyed off of the data provider contribution id
    abstract data: DataProviderContextProperties with get, set
    /// Set of exceptions that occurred resolving the data providers.
    abstract exceptions: DataProviderResultExceptions with get, set
    /// List of data providers resolved in the data-provider query
    abstract resolvedProviders: ResizeArray<ResolvedDataProvider> with get, set
    /// Scope name applied to this data provider result.
    abstract scopeName: string with get, set
    /// Scope value applied to this data provider result.
    abstract scopeValue: string with get, set
    /// Property bag of shared data that was contributed to by any of the individual data providers
    abstract sharedData: DataProviderContextProperties with get, set

/// Data bag that any data provider can contribute to. This shared dictionary is returned in the data provider result.
type [<AllowNullLiteral>] DataProviderSharedData =
    interface end

/// Contract for handling the extension acquisition process
type [<AllowNullLiteral>] ExtensionAcquisitionRequest =
    /// How the item is being assigned
    abstract assignmentType: AcquisitionAssignmentType with get, set
    /// The id of the subscription used for purchase
    abstract billingId: string with get, set
    /// The marketplace id (publisherName.extensionName) for the item
    abstract itemId: string with get, set
    /// The type of operation, such as install, request, purchase
    abstract operationType: AcquisitionOperationType with get, set
    /// Additional properties which can be added to the request.
    abstract properties: obj option with get, set
    /// How many licenses should be purchased
    abstract quantity: int with get, set

/// Audit log for an extension
type [<AllowNullLiteral>] ExtensionAuditLog =
    /// Collection of audit log entries
    abstract entries: ResizeArray<ExtensionAuditLogEntry> with get, set
    /// Extension that the change was made for
    abstract extensionName: string with get, set
    /// Publisher that the extension is part of
    abstract publisherName: string with get, set

/// An audit log entry for an extension
type [<AllowNullLiteral>] ExtensionAuditLogEntry =
    /// Change that was made to extension
    abstract auditAction: string with get, set
    /// Date at which the change was made
    abstract auditDate: DateTime with get, set
    /// Extra information about the change
    abstract comment: string with get, set
    /// Represents the user who made the change
    abstract updatedBy: WebApi.IdentityRef with get, set

type [<AllowNullLiteral>] ExtensionAuthorization =
    abstract id: string with get, set
    abstract scopes: ResizeArray<string> with get, set

/// Represents a single collection for extension data documents
type [<AllowNullLiteral>] ExtensionDataCollection =
    /// The name of the collection
    abstract collectionName: string with get, set
    /// A list of documents belonging to the collection
    abstract documents: ResizeArray<obj option> with get, set
    /// The type of the collection's scope, such as Default or User
    abstract scopeType: string with get, set
    /// The value of the collection's scope, such as Current or Me
    abstract scopeValue: string with get, set

/// Represents a query to receive a set of extension data collections
type [<AllowNullLiteral>] ExtensionDataCollectionQuery =
    /// A list of collections to query
    abstract collections: ResizeArray<ExtensionDataCollection> with get, set

type [<AllowNullLiteral>] ExtensionEvent =
    /// The extension which has been updated
    abstract extension: Gallery.PublishedExtension with get, set
    /// The current version of the extension that was updated
    abstract extensionVersion: string with get, set
    /// Name of the collection for which the extension was requested
    abstract host: ExtensionHost with get, set
    /// Gallery host url
    abstract links: ExtensionEventUrls with get, set
    /// Represents the user who initiated the update
    abstract modifiedBy: WebApi.IdentityRef with get, set
    /// The type of update that was made
    abstract updateType: ExtensionUpdateType with get, set

/// Base class for an event callback for an extension
type [<AllowNullLiteral>] ExtensionEventCallback =
    /// The uri of the endpoint that is hit when an event occurs
    abstract uri: string with get, set

/// Collection of event callbacks - endpoints called when particular extension events occur.
type [<AllowNullLiteral>] ExtensionEventCallbackCollection =
    /// Optional.  Defines an endpoint that gets called via a POST request to notify that an extension disable has occurred.
    abstract postDisable: ExtensionEventCallback with get, set
    /// Optional.  Defines an endpoint that gets called via a POST request to notify that an extension enable has occurred.
    abstract postEnable: ExtensionEventCallback with get, set
    /// Optional.  Defines an endpoint that gets called via a POST request to notify that an extension install has completed.
    abstract postInstall: ExtensionEventCallback with get, set
    /// Optional.  Defines an endpoint that gets called via a POST request to notify that an extension uninstall has occurred.
    abstract postUninstall: ExtensionEventCallback with get, set
    /// Optional.  Defines an endpoint that gets called via a POST request to notify that an extension update has occurred.
    abstract postUpdate: ExtensionEventCallback with get, set
    /// Optional.  Defines an endpoint that gets called via a POST request to notify that an extension install is about to occur.  Response indicates whether to proceed or abort.
    abstract preInstall: ExtensionEventCallback with get, set
    /// For multi-version extensions, defines an endpoint that gets called via an OPTIONS request to determine the particular version of the extension to be used
    abstract versionCheck: ExtensionEventCallback with get, set

type [<AllowNullLiteral>] ExtensionEventUrls =
    inherit ExtensionUrls
    /// Url of the extension management page
    abstract manageExtensionsPage: string with get, set

type [<RequireQualifiedAccess>] ExtensionFlags =
    | BuiltIn = 1
    | Trusted = 2

type [<AllowNullLiteral>] ExtensionHost =
    abstract id: string with get, set
    abstract name: string with get, set

/// How an extension should handle including contributions based on licensing
type [<AllowNullLiteral>] ExtensionLicensing =
    /// A list of contributions which deviate from the default licensing behavior
    abstract overrides: ResizeArray<LicensingOverride> with get, set

/// Base class for extension properties which are shared by the extension manifest and the extension model
type [<AllowNullLiteral>] ExtensionManifest =
    /// Uri used as base for other relative uri's defined in extension
    abstract baseUri: string with get, set
    /// List of shared constraints defined by this extension
    abstract constraints: ResizeArray<ContributionConstraint> with get, set
    /// List of contributions made by this extension
    abstract contributions: ResizeArray<Contribution> with get, set
    /// List of contribution types defined by this extension
    abstract contributionTypes: ResizeArray<ContributionType> with get, set
    /// List of explicit demands required by this extension
    abstract demands: ResizeArray<string> with get, set
    /// Collection of endpoints that get called when particular extension events occur
    abstract eventCallbacks: ExtensionEventCallbackCollection with get, set
    /// Secondary location that can be used as base for other relative uri's defined in extension
    abstract fallbackBaseUri: string with get, set
    /// Language Culture Name set by the Gallery
    abstract language: string with get, set
    /// How this extension behaves with respect to licensing
    abstract licensing: ExtensionLicensing with get, set
    /// Version of the extension manifest format/content
    abstract manifestVersion: int with get, set
    /// Default user claims applied to all contributions (except the ones which have been specified restrictedTo explicitly) to control the visibility of a contribution.
    abstract restrictedTo: ResizeArray<string> with get, set
    /// List of all oauth scopes required by this extension
    abstract scopes: ResizeArray<string> with get, set
    /// The ServiceInstanceType(Guid) of the VSTS service that must be available to an account in order for the extension to be installed
    abstract serviceInstanceType: string with get, set

/// A request for an extension (to be installed or have a license assigned)
type [<AllowNullLiteral>] ExtensionRequest =
    /// Required message supplied if the request is rejected
    abstract rejectMessage: string with get, set
    /// Date at which the request was made
    abstract requestDate: DateTime with get, set
    /// Represents the user who made the request
    abstract requestedBy: WebApi.IdentityRef with get, set
    /// Optional message supplied by the requester justifying the request
    abstract requestMessage: string with get, set
    /// Represents the state of the request
    abstract requestState: ExtensionRequestState with get, set
    /// Date at which the request was resolved
    abstract resolveDate: DateTime with get, set
    /// Represents the user who resolved the request
    abstract resolvedBy: WebApi.IdentityRef with get, set

type [<AllowNullLiteral>] ExtensionRequestEvent =
    /// The extension which has been requested
    abstract extension: Gallery.PublishedExtension with get, set
    /// Information about the host for which this extension is requested
    abstract host: ExtensionHost with get, set
    /// Name of the collection for which the extension was requested
    abstract hostName: string with get, set
    /// Gallery host url
    abstract links: ExtensionRequestUrls with get, set
    /// The extension request object
    abstract request: ExtensionRequest with get, set
    /// The type of update that was made
    abstract updateType: ExtensionRequestUpdateType with get, set

type [<AllowNullLiteral>] ExtensionRequestsEvent =
    /// The extension which has been requested
    abstract extension: Gallery.PublishedExtension with get, set
    /// Information about the host for which this extension is requested
    abstract host: ExtensionHost with get, set
    /// Gallery host url
    abstract links: ExtensionRequestUrls with get, set
    /// The extension request object
    abstract requests: ResizeArray<ExtensionRequest> with get, set
    /// The type of update that was made
    abstract updateType: ExtensionRequestUpdateType with get, set

type [<RequireQualifiedAccess>] ExtensionRequestState =
    | Open = 0
    | Accepted = 1
    | Rejected = 2

type [<RequireQualifiedAccess>] ExtensionRequestUpdateType =
    | Created = 1
    | Approved = 2
    | Rejected = 3
    | Deleted = 4

type [<AllowNullLiteral>] ExtensionRequestUrls =
    inherit ExtensionUrls
    /// Link to view the extension request
    abstract requestPage: string with get, set

/// The state of an extension
type [<AllowNullLiteral>] ExtensionState =
    inherit InstalledExtensionState
    abstract extensionName: string with get, set
    /// The time at which the version was last checked
    abstract lastVersionCheck: DateTime with get, set
    abstract publisherName: string with get, set
    abstract version: string with get, set

type [<RequireQualifiedAccess>] ExtensionStateFlags =
    | None = 0
    | Disabled = 1
    | BuiltIn = 2
    | MultiVersion = 4
    | UnInstalled = 8
    | VersionCheckError = 16
    | Trusted = 32
    | Error = 64
    | NeedsReauthorization = 128
    | AutoUpgradeError = 256
    | Warning = 512

type [<RequireQualifiedAccess>] ExtensionUpdateType =
    | Installed = 1
    | Uninstalled = 2
    | Enabled = 3
    | Disabled = 4
    | VersionUpdated = 5
    | ActionRequired = 6
    | ActionResolved = 7

type [<AllowNullLiteral>] ExtensionUrls =
    /// Url of the extension icon
    abstract extensionIcon: string with get, set
    /// Link to view the extension details page
    abstract extensionPage: string with get, set

/// Represents a VSTS extension along with its installation state
type [<AllowNullLiteral>] InstalledExtension =
    inherit ExtensionManifest
    /// The friendly extension id for this extension - unique for a given publisher.
    abstract extensionId: string with get, set
    /// The display name of the extension.
    abstract extensionName: string with get, set
    /// This is the set of files available from the extension.
    abstract files: ResizeArray<Gallery.ExtensionFile> with get, set
    /// Extension flags relevant to contribution consumers
    abstract flags: ExtensionFlags with get, set
    /// Information about this particular installation of the extension
    abstract installState: InstalledExtensionState with get, set
    /// This represents the date/time the extensions was last updated in the gallery. This doesnt mean this version was updated the value represents changes to any and all versions of the extension.
    abstract lastPublished: DateTime with get, set
    /// Unique id of the publisher of this extension
    abstract publisherId: string with get, set
    /// The display name of the publisher
    abstract publisherName: string with get, set
    /// Unique id for this extension (the same id is used for all versions of a single extension)
    abstract registrationId: string with get, set
    /// Version of this extension
    abstract version: string with get, set

type [<AllowNullLiteral>] InstalledExtensionQuery =
    abstract assetTypes: ResizeArray<string> with get, set
    abstract monikers: ResizeArray<Gallery.ExtensionIdentifier> with get, set

/// The state of an installed extension
type [<AllowNullLiteral>] InstalledExtensionState =
    /// States of an installed extension
    abstract flags: ExtensionStateFlags with get, set
    /// List of installation issues
    abstract installationIssues: ResizeArray<InstalledExtensionStateIssue> with get, set
    /// The time at which this installation was last updated
    abstract lastUpdated: DateTime with get, set

/// Represents an installation issue
type [<AllowNullLiteral>] InstalledExtensionStateIssue =
    /// The error message
    abstract message: string with get, set
    /// Source of the installation issue, for example  "Demands"
    abstract source: string with get, set
    /// Installation issue type (Warning, Error)
    abstract ``type``: InstalledExtensionStateIssueType with get, set

type [<RequireQualifiedAccess>] InstalledExtensionStateIssueType =
    | Warning = 0
    | Error = 1

/// Maps a contribution to a licensing behavior
type [<AllowNullLiteral>] LicensingOverride =
    /// How the inclusion of this contribution should change based on licensing
    abstract behavior: ContributionLicensingBehaviorType with get, set
    /// Fully qualified contribution id which we want to define licensing behavior for
    abstract id: string with get, set

/// A request for an extension (to be installed or have a license assigned)
type [<AllowNullLiteral>] RequestedExtension =
    /// The unique name of the extension
    abstract extensionName: string with get, set
    /// A list of each request for the extension
    abstract extensionRequests: ResizeArray<ExtensionRequest> with get, set
    /// DisplayName of the publisher that owns the extension being published.
    abstract publisherDisplayName: string with get, set
    /// Represents the Publisher of the requested extension
    abstract publisherName: string with get, set
    /// The total number of requests for an extension
    abstract requestCount: int with get, set

/// Entry for a specific data provider's resulting data
type [<AllowNullLiteral>] ResolvedDataProvider =
    /// The total time the data provider took to resolve its data (in milliseconds)
    abstract duration: int with get, set
    abstract error: string with get, set
    abstract id: string with get, set

type [<AllowNullLiteral>] Scope =
    abstract description: string with get, set
    abstract title: string with get, set
    abstract value: string with get, set

/// Information about the extension
type [<AllowNullLiteral>] SupportedExtension =
    /// Unique Identifier for this extension
    abstract extension: string with get, set
    /// Unique Identifier for this publisher
    abstract publisher: string with get, set
    /// Supported version for this extension
    abstract version: string with get, set

type [<AllowNullLiteral>] ClientContributionProviderDetailsProperties =
    [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> string with get, set

type [<AllowNullLiteral>] ContributionNodeQueryResultNodes =
    [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> ClientContributionNode with get, set

type [<AllowNullLiteral>] ContributionNodeQueryResultProviderDetails =
    [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> ClientContributionProviderDetails with get, set

type [<AllowNullLiteral>] ContributionTypeProperties =
    [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> ContributionPropertyDescription with get, set

type [<AllowNullLiteral>] DataProviderContextProperties =
    [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

type [<AllowNullLiteral>] DataProviderResultClientProviders =
    [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> ClientDataProviderQuery with get, set

type [<AllowNullLiteral>] DataProviderResultExceptions =
    [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> DataProviderExceptionDetails with get, set
