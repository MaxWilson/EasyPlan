// ts2fable 0.7.1
module rec Gallery
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
    /// The target that this options refer to
    abstract target: string with get, set

type [<AllowNullLiteral>] Answers =
    /// Gets or sets the vs marketplace extension name
    abstract vsMarketplaceExtensionName: string with get, set
    /// Gets or sets the vs marketplace publisher name
    abstract vsMarketplacePublisherName: string with get, set

type [<AllowNullLiteral>] AssetDetails =
    /// Gets or sets the Answers, which contains vs marketplace extension name and publisher name
    abstract answers: Answers with get, set
    /// Gets or sets the VS publisher Id
    abstract publisherNaturalIdentifier: string with get, set

type [<AllowNullLiteral>] AzurePublisher =
    abstract azurePublisherId: string with get, set
    abstract publisherName: string with get, set

type [<AllowNullLiteral>] AzureRestApiRequestModel =
    /// Gets or sets the Asset details
    abstract assetDetails: AssetDetails with get, set
    /// Gets or sets the asset id
    abstract assetId: string with get, set
    /// Gets or sets the asset version
    abstract assetVersion: int with get, set
    /// Gets or sets the customer support email
    abstract customerSupportEmail: string with get, set
    /// Gets or sets the integration contact email
    abstract integrationContactEmail: string with get, set
    /// Gets or sets the asset version
    abstract operation: string with get, set
    /// Gets or sets the plan identifier if any.
    abstract planId: string with get, set
    /// Gets or sets the publisher id
    abstract publisherId: string with get, set
    /// Gets or sets the resource type
    abstract ``type``: string with get, set

type [<AllowNullLiteral>] AzureRestApiResponseModel =
    inherit AzureRestApiRequestModel
    /// Gets or sets the Asset operation status
    abstract operationStatus: RestApiResponseStatusModel with get, set

/// This is the set of categories in response to the get category query
type [<AllowNullLiteral>] CategoriesResult =
    abstract categories: ResizeArray<ExtensionCategory> with get, set

/// Definition of one title of a category
type [<AllowNullLiteral>] CategoryLanguageTitle =
    /// The language for which the title is applicable
    abstract lang: string with get, set
    /// The language culture id of the lang parameter
    abstract lcid: int with get, set
    /// Actual title to be shown on the UI
    abstract title: string with get, set

/// The structure of a Concern Rather than defining a separate data structure having same fields as QnAItem, we are inheriting from the QnAItem.
type [<AllowNullLiteral>] Concern =
    inherit QnAItem
    /// Category of the concern
    abstract category: ConcernCategory with get, set

type [<RequireQualifiedAccess>] ConcernCategory =
    | General = 1
    | Abusive = 2
    | Spam = 4

/// Stores Last Contact Date
type [<AllowNullLiteral>] CustomerLastContact =
    /// account for which customer was last contacted
    abstract account: string with get, set
    /// Date on which the customer was last contacted
    abstract lastContactDate: DateTime with get, set

type [<RequireQualifiedAccess>] DraftPatchOperation =
    | Publish = 1
    | Cancel = 2

type [<RequireQualifiedAccess>] DraftStateType =
    | Unpublished = 1
    | Published = 2
    | Cancelled = 3
    | Error = 4

type [<AllowNullLiteral>] EventCounts =
    /// Average rating on the day for extension
    abstract averageRating: int with get, set
    /// Number of times the extension was bought in hosted scenario (applies only to VSTS extensions)
    abstract buyCount: int with get, set
    /// Number of times the extension was bought in connected scenario (applies only to VSTS extensions)
    abstract connectedBuyCount: int with get, set
    /// Number of times the extension was installed in connected scenario (applies only to VSTS extensions)
    abstract connectedInstallCount: int with get, set
    /// Number of times the extension was installed
    abstract installCount: int with get, set
    /// Number of times the extension was installed as a trial (applies only to VSTS extensions)
    abstract tryCount: int with get, set
    /// Number of times the extension was uninstalled (applies only to VSTS extensions)
    abstract uninstallCount: int with get, set
    /// Number of times the extension was downloaded (applies to VSTS extensions and VSCode marketplace click installs)
    abstract webDownloadCount: int with get, set
    /// Number of detail page views
    abstract webPageViews: int with get, set

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
    /// A list of target guids where the item should be acquired (installed, requested, etc.), such as account id
    abstract targets: ResizeArray<string> with get, set

type [<AllowNullLiteral>] ExtensionBadge =
    abstract description: string with get, set
    abstract imgUri: string with get, set
    abstract link: string with get, set

type [<AllowNullLiteral>] ExtensionCategory =
    /// The name of the products with which this category is associated to.
    abstract associatedProducts: ResizeArray<string> with get, set
    abstract categoryId: int with get, set
    /// This is the internal name for a category
    abstract categoryName: string with get, set
    /// This parameter is obsolete. Refer to LanguageTitles for langauge specific titles
    abstract language: string with get, set
    /// The list of all the titles of this category in various languages
    abstract languageTitles: ResizeArray<CategoryLanguageTitle> with get, set
    /// This is the internal name of the parent if this is associated with a parent
    abstract parentCategoryName: string with get, set

type [<AllowNullLiteral>] ExtensionDailyStat =
    /// Stores the event counts
    abstract counts: EventCounts with get, set
    /// Generic key/value pair to store extended statistics. Used for sending paid extension stats like Upgrade, Downgrade, Cancel trend etc.
    abstract extendedStats: ExtensionDailyStatExtendedStats with get, set
    /// Timestamp of this data point
    abstract statisticDate: DateTime with get, set
    /// Version of the extension
    abstract version: string with get, set

type [<AllowNullLiteral>] ExtensionDailyStats =
    /// List of extension statistics data points
    abstract dailyStats: ResizeArray<ExtensionDailyStat> with get, set
    /// Id of the extension, this will never be sent back to the client. For internal use only.
    abstract extensionId: string with get, set
    /// Name of the extension
    abstract extensionName: string with get, set
    /// Name of the publisher
    abstract publisherName: string with get, set
    /// Count of stats
    abstract statCount: int with get, set

type [<RequireQualifiedAccess>] ExtensionDeploymentTechnology =
    | Exe = 1
    | Msi = 2
    | Vsix = 3
    | ReferralLink = 4

type [<AllowNullLiteral>] ExtensionDraft =
    abstract assets: ResizeArray<ExtensionDraftAsset> with get, set
    abstract createdDate: DateTime with get, set
    abstract draftState: DraftStateType with get, set
    abstract extensionName: string with get, set
    abstract id: string with get, set
    abstract lastUpdated: DateTime with get, set
    abstract payload: ExtensionPayload with get, set
    abstract product: string with get, set
    abstract publisherName: string with get, set
    abstract validationErrors: ResizeArray<ExtensionDraftValidationErrors> with get, set
    abstract validationWarnings: ResizeArray<ExtensionDraftValidationErrors> with get, set

type [<AllowNullLiteral>] ExtensionDraftAsset =
    inherit ExtensionFile

type [<AllowNullLiteral>] ExtensionDraftPatch =
    abstract extensionData: UnpackagedExtensionData with get, set
    abstract operation: DraftPatchOperation with get, set

/// Stores details of each event
type [<AllowNullLiteral>] ExtensionEvent =
    /// Id which identifies each data point uniquely
    abstract id: int with get, set
    abstract properties: obj option with get, set
    /// Timestamp of when the event occurred
    abstract statisticDate: DateTime with get, set
    /// Version of the extension
    abstract version: string with get, set

/// Container object for all extension events. Stores all install and uninstall events related to an extension. The events container is generic so can store data of any type of event. New event types can be added without altering the contract.
type [<AllowNullLiteral>] ExtensionEvents =
    /// Generic container for events data. The dictionary key denotes the type of event and the list contains properties related to that event
    abstract events: ExtensionEventsEvents with get, set
    /// Id of the extension, this will never be sent back to the client. This field will mainly be used when EMS calls into Gallery REST API to update install/uninstall events for various extensions in one go.
    abstract extensionId: string with get, set
    /// Name of the extension
    abstract extensionName: string with get, set
    /// Name of the publisher
    abstract publisherName: string with get, set

type [<AllowNullLiteral>] ExtensionFile =
    abstract assetType: string with get, set
    abstract language: string with get, set
    abstract source: string with get, set

/// The FilterResult is the set of extensions that matched a particular query filter.
type [<AllowNullLiteral>] ExtensionFilterResult =
    /// This is the set of applications that matched the query filter supplied.
    abstract extensions: ResizeArray<PublishedExtension> with get, set
    /// The PagingToken is returned from a request when more records exist that match the result than were requested or could be returned. A follow-up query with this paging token can be used to retrieve more results.
    abstract pagingToken: string with get, set
    /// This is the additional optional metadata for the given result. E.g. Total count of results which is useful in case of paged results
    abstract resultMetadata: ResizeArray<ExtensionFilterResultMetadata> with get, set

/// ExtensionFilterResultMetadata is one set of metadata for the result e.g. Total count. There can be multiple metadata items for one metadata.
type [<AllowNullLiteral>] ExtensionFilterResultMetadata =
    /// The metadata items for the category
    abstract metadataItems: ResizeArray<MetadataItem> with get, set
    /// Defines the category of metadata items
    abstract metadataType: string with get, set

/// Represents the component pieces of an extensions fully qualified name, along with the fully qualified name.
type [<AllowNullLiteral>] ExtensionIdentifier =
    /// The ExtensionName component part of the fully qualified ExtensionIdentifier
    abstract extensionName: string with get, set
    /// The PublisherName component part of the fully qualified ExtensionIdentifier
    abstract publisherName: string with get, set

type [<RequireQualifiedAccess>] ExtensionLifecycleEventType =
    | Uninstall = 1
    | Install = 2
    | Review = 3
    | Acquisition = 4
    | Sales = 5
    | Other = 999

/// Package that will be used to create or update a published extension
type [<AllowNullLiteral>] ExtensionPackage =
    /// Base 64 encoded extension package
    abstract extensionManifest: string with get, set

type [<AllowNullLiteral>] ExtensionPayload =
    abstract description: string with get, set
    abstract displayName: string with get, set
    abstract fileName: string with get, set
    abstract installationTargets: ResizeArray<InstallationTarget> with get, set
    abstract isPreview: bool with get, set
    abstract isSignedByMicrosoft: bool with get, set
    abstract isValid: bool with get, set
    abstract metadata: ResizeArray<ExtensionDraftValidationErrors> with get, set
    abstract ``type``: ExtensionDeploymentTechnology with get, set

/// Policy with a set of permissions on extension operations
type [<AllowNullLiteral>] ExtensionPolicy =
    /// Permissions on 'Install' operation
    abstract install: ExtensionPolicyFlags with get, set
    /// Permission on 'Request' operation
    abstract request: ExtensionPolicyFlags with get, set

type [<RequireQualifiedAccess>] ExtensionPolicyFlags =
    | None = 0
    | Private = 1
    | Public = 2
    | Preview = 4
    | Released = 8
    | FirstParty = 16
    | All = 31

/// An ExtensionQuery is used to search the gallery for a set of extensions that match one of many filter values.
type [<AllowNullLiteral>] ExtensionQuery =
    /// When retrieving extensions with a query; frequently the caller only needs a small subset of the assets. The caller may specify a list of asset types that should be returned if the extension contains it. All other assets will not be returned.
    abstract assetTypes: ResizeArray<string> with get, set
    /// Each filter is a unique query and will have matching set of extensions returned from the request. Each result will have the same index in the resulting array that the filter had in the incoming query.
    abstract filters: ResizeArray<QueryFilter> with get, set
    /// The Flags are used to determine which set of information the caller would like returned for the matched extensions.
    abstract flags: ExtensionQueryFlags with get, set

type [<RequireQualifiedAccess>] ExtensionQueryFilterType =
    | Tag = 1
    | DisplayName = 2
    | Private = 3
    | Id = 4
    | Category = 5
    | ContributionType = 6
    | Name = 7
    | InstallationTarget = 8
    | Featured = 9
    | SearchText = 10
    | FeaturedInCategory = 11
    | ExcludeWithFlags = 12
    | IncludeWithFlags = 13
    | Lcid = 14
    | InstallationTargetVersion = 15
    | InstallationTargetVersionRange = 16
    | VsixMetadata = 17
    | PublisherName = 18
    | PublisherDisplayName = 19
    | IncludeWithPublisherFlags = 20
    | OrganizationSharedWith = 21

type [<RequireQualifiedAccess>] ExtensionQueryFlags =
    | None = 0
    | IncludeVersions = 1
    | IncludeFiles = 2
    | IncludeCategoryAndTags = 4
    | IncludeSharedAccounts = 8
    | IncludeVersionProperties = 16
    | ExcludeNonValidated = 32
    | IncludeInstallationTargets = 64
    | IncludeAssetUri = 128
    | IncludeStatistics = 256
    | IncludeLatestVersionOnly = 512
    | UseFallbackAssetUri = 1024
    | IncludeMetadata = 2048
    | IncludeMinimalPayloadForVsIde = 4096
    | IncludeLcids = 8192
    | IncludeSharedOrganizations = 16384
    | AllAttributes = 16863

/// This is the set of extensions that matched a supplied query through the filters given.
type [<AllowNullLiteral>] ExtensionQueryResult =
    /// For each filter supplied in the query, a filter result will be returned in the query result.
    abstract results: ResizeArray<ExtensionFilterResult> with get, set

type [<AllowNullLiteral>] ExtensionShare =
    abstract id: string with get, set
    abstract isOrg: bool with get, set
    abstract name: string with get, set
    abstract ``type``: string with get, set

type [<AllowNullLiteral>] ExtensionStatistic =
    abstract statisticName: string with get, set
    abstract value: int with get, set

type [<RequireQualifiedAccess>] ExtensionStatisticOperation =
    | None = 0
    | Set = 1
    | Increment = 2
    | Decrement = 3
    | Delete = 4

type [<AllowNullLiteral>] ExtensionStatisticUpdate =
    abstract extensionName: string with get, set
    abstract operation: ExtensionStatisticOperation with get, set
    abstract publisherName: string with get, set
    abstract statistic: ExtensionStatistic with get, set

type [<RequireQualifiedAccess>] ExtensionStatsAggregateType =
    | Daily = 1

type [<AllowNullLiteral>] ExtensionVersion =
    abstract assetUri: string with get, set
    abstract badges: ResizeArray<ExtensionBadge> with get, set
    abstract fallbackAssetUri: string with get, set
    abstract files: ResizeArray<ExtensionFile> with get, set
    abstract flags: ExtensionVersionFlags with get, set
    abstract lastUpdated: DateTime with get, set
    abstract properties: ResizeArray<ExtensionDraftValidationErrors> with get, set
    abstract validationResultMessage: string with get, set
    abstract version: string with get, set
    abstract versionDescription: string with get, set

type [<RequireQualifiedAccess>] ExtensionVersionFlags =
    | None = 0
    | Validated = 1

/// One condition in a QueryFilter.
type [<AllowNullLiteral>] FilterCriteria =
    abstract filterType: int with get, set
    /// The value used in the match based on the filter type.
    abstract value: string with get, set

type [<AllowNullLiteral>] InstallationTarget =
    abstract target: string with get, set
    abstract targetVersion: string with get, set

/// MetadataItem is one value of metadata under a given category of metadata
type [<AllowNullLiteral>] MetadataItem =
    /// The count of the metadata item
    abstract count: int with get, set
    /// The name of the metadata item
    abstract name: string with get, set

/// Information needed for sending mail notification
type [<AllowNullLiteral>] NotificationsData =
    /// Notification data needed
    abstract data: ExtensionDailyStatExtendedStats with get, set
    /// List of users who should get the notification
    abstract identities: ExtensionDailyStatExtendedStats with get, set
    /// Type of Mail Notification.Can be Qna , review or CustomerContact
    abstract ``type``: NotificationTemplateType with get, set

type [<RequireQualifiedAccess>] NotificationTemplateType =
    | ReviewNotification = 1
    | QnaNotification = 2
    | CustomerContactNotification = 3
    | PublisherMemberUpdateNotification = 4

type [<RequireQualifiedAccess>] PagingDirection =
    | Backward = 1
    | Forward = 2

/// This is the set of categories in response to the get category query
type [<AllowNullLiteral>] ProductCategoriesResult =
    abstract categories: ResizeArray<ProductCategory> with get, set

/// This is the interface object to be used by Root Categories and Category Tree APIs for Visual Studio Ide.
type [<AllowNullLiteral>] ProductCategory =
    abstract children: ResizeArray<ProductCategory> with get, set
    /// Indicator whether this is a leaf or there are children under this category
    abstract hasChildren: bool with get, set
    /// Individual Guid of the Category
    abstract id: string with get, set
    /// Category Title in the requested language
    abstract title: string with get, set

type [<AllowNullLiteral>] PublishedExtension =
    abstract categories: ResizeArray<string> with get, set
    abstract deploymentType: ExtensionDeploymentTechnology with get, set
    abstract displayName: string with get, set
    abstract extensionId: string with get, set
    abstract extensionName: string with get, set
    abstract flags: PublishedExtensionFlags with get, set
    abstract installationTargets: ResizeArray<InstallationTarget> with get, set
    abstract lastUpdated: DateTime with get, set
    abstract longDescription: string with get, set
    /// Date on which the extension was first uploaded.
    abstract publishedDate: DateTime with get, set
    abstract publisher: PublisherFacts with get, set
    /// Date on which the extension first went public.
    abstract releaseDate: DateTime with get, set
    abstract sharedWith: ResizeArray<ExtensionShare> with get, set
    abstract shortDescription: string with get, set
    abstract statistics: ResizeArray<ExtensionStatistic> with get, set
    abstract tags: ResizeArray<string> with get, set
    abstract versions: ResizeArray<ExtensionVersion> with get, set

type [<RequireQualifiedAccess>] PublishedExtensionFlags =
    | None = 0
    | Disabled = 1
    | BuiltIn = 2
    | Validated = 4
    | Trusted = 8
    | Paid = 16
    | Public = 256
    | MultiVersion = 512
    | System = 1024
    | Preview = 2048
    | Unpublished = 4096
    | Trial = 8192
    | Locked = 16384
    | Hidden = 32768

type [<AllowNullLiteral>] Publisher =
    inherit PublisherBase
    abstract _links: obj option with get, set

/// Keeping base class separate since publisher DB model class and publisher contract class share these common properties
type [<AllowNullLiteral>] PublisherBase =
    abstract displayName: string with get, set
    abstract emailAddress: ResizeArray<string> with get, set
    abstract extensions: ResizeArray<PublishedExtension> with get, set
    abstract flags: PublisherFlags with get, set
    abstract lastUpdated: DateTime with get, set
    abstract longDescription: string with get, set
    abstract publisherId: string with get, set
    abstract publisherName: string with get, set
    abstract shortDescription: string with get, set
    abstract state: PublisherState with get, set

/// High-level information about the publisher, like id's and names
type [<AllowNullLiteral>] PublisherFacts =
    abstract displayName: string with get, set
    abstract flags: PublisherFlags with get, set
    abstract publisherId: string with get, set
    abstract publisherName: string with get, set

/// The FilterResult is the set of publishers that matched a particular query filter.
type [<AllowNullLiteral>] PublisherFilterResult =
    /// This is the set of applications that matched the query filter supplied.
    abstract publishers: ResizeArray<Publisher> with get, set

type [<RequireQualifiedAccess>] PublisherFlags =
    | UnChanged = 1073741824
    | None = 0
    | Disabled = 1
    | Verified = 2
    | Certified = 4
    | ServiceFlags = 7

type [<RequireQualifiedAccess>] PublisherPermissions =
    | Read = 1
    | UpdateExtension = 2
    | CreatePublisher = 4
    | PublishExtension = 8
    | Admin = 16
    | TrustedPartner = 32
    | PrivateRead = 64
    | DeleteExtension = 128
    | EditSettings = 256
    | ViewPermissions = 512
    | ManagePermissions = 1024
    | DeletePublisher = 2048

/// An PublisherQuery is used to search the gallery for a set of publishers that match one of many filter values.
type [<AllowNullLiteral>] PublisherQuery =
    /// Each filter is a unique query and will have matching set of publishers returned from the request. Each result will have the same index in the resulting array that the filter had in the incoming query.
    abstract filters: ResizeArray<QueryFilter> with get, set
    /// The Flags are used to determine which set of information the caller would like returned for the matched publishers.
    abstract flags: PublisherQueryFlags with get, set

type [<RequireQualifiedAccess>] PublisherQueryFlags =
    | None = 0
    | IncludeExtensions = 1
    | IncludeEmailAddress = 2

/// This is the set of publishers that matched a supplied query through the filters given.
type [<AllowNullLiteral>] PublisherQueryResult =
    /// For each filter supplied in the query, a filter result will be returned in the query result.
    abstract results: ResizeArray<PublisherFilterResult> with get, set

type [<RequireQualifiedAccess>] PublisherRoleAccess =
    | Assigned = 1
    | Inherited = 2

type [<AllowNullLiteral>] PublisherRoleAssignment =
    /// Designates the role as explicitly assigned or inherited.
    abstract access: PublisherRoleAccess with get, set
    /// User friendly description of access assignment.
    abstract accessDisplayName: string with get, set
    /// The user to whom the role is assigned.
    abstract identity: WebApi.IdentityRef with get, set
    /// The role assigned to the user.
    abstract role: PublisherSecurityRole with get, set

type [<AllowNullLiteral>] PublisherSecurityRole =
    /// Permissions the role is allowed.
    abstract allowPermissions: int with get, set
    /// Permissions the role is denied.
    abstract denyPermissions: int with get, set
    /// Description of user access defined by the role
    abstract description: string with get, set
    /// User friendly name of the role.
    abstract displayName: string with get, set
    /// Globally unique identifier for the role.
    abstract identifier: string with get, set
    /// Unique name of the role in the scope.
    abstract name: string with get, set
    /// Returns the id of the ParentScope.
    abstract scope: string with get, set

type [<RequireQualifiedAccess>] PublisherState =
    | None = 0
    | VerificationPending = 1
    | CertificationPending = 2
    | CertificationRejected = 4
    | CertificationRevoked = 8

type [<AllowNullLiteral>] PublisherUserRoleAssignmentRef =
    /// The name of the role assigned.
    abstract roleName: string with get, set
    /// Identifier of the user given the role assignment.
    abstract uniqueName: string with get, set
    /// Unique id of the user given the role assignment.
    abstract userId: string with get, set

/// The core structure of a QnA item
type [<AllowNullLiteral>] QnAItem =
    /// Time when the review was first created
    abstract createdDate: DateTime with get, set
    /// Unique identifier of a QnA item
    abstract id: int with get, set
    /// Get status of item
    abstract status: QnAItemStatus with get, set
    /// Text description of the QnA item
    abstract text: string with get, set
    /// Time when the review was edited/updated
    abstract updatedDate: DateTime with get, set
    /// User details for the item.
    abstract user: UserIdentityRef with get, set

type [<RequireQualifiedAccess>] QnAItemStatus =
    | None = 0
    | UserEditable = 1
    | PublisherCreated = 2

/// A filter used to define a set of extensions to return during a query.
type [<AllowNullLiteral>] QueryFilter =
    /// The filter values define the set of values in this query. They are applied based on the QueryFilterType.
    abstract criteria: ResizeArray<FilterCriteria> with get, set
    /// The PagingDirection is applied to a paging token if one exists. If not the direction is ignored, and Forward from the start of the resultset is used. Direction should be left out of the request unless a paging token is used to help prevent future issues.
    abstract direction: PagingDirection with get, set
    /// The page number requested by the user. If not provided 1 is assumed by default.
    abstract pageNumber: int with get, set
    /// The page size defines the number of results the caller wants for this filter. The count can't exceed the overall query size limits.
    abstract pageSize: int with get, set
    /// The paging token is a distinct type of filter and the other filter fields are ignored. The paging token represents the continuation of a previously executed query. The information about where in the result and what fields are being filtered are embeded in the token.
    abstract pagingToken: string with get, set
    /// Defines the type of sorting to be applied on the results. The page slice is cut of the sorted results only.
    abstract sortBy: int with get, set
    /// Defines the order of sorting, 1 for Ascending, 2 for Descending, else default ordering based on the SortBy value
    abstract sortOrder: int with get, set

/// The structure of the question / thread
type [<AllowNullLiteral>] Question =
    inherit QnAItem
    /// List of answers in for the question / thread
    abstract responses: ResizeArray<Response> with get, set

type [<AllowNullLiteral>] QuestionsResult =
    /// Flag indicating if there are more QnA threads to be shown (for paging)
    abstract hasMoreQuestions: bool with get, set
    /// List of the QnA threads
    abstract questions: ResizeArray<Question> with get, set

type [<AllowNullLiteral>] RatingCountPerRating =
    /// Rating value
    abstract rating: int with get, set
    /// Count of total ratings
    abstract ratingCount: int with get, set

/// The structure of a response
type [<AllowNullLiteral>] Response =
    inherit QnAItem

type [<RequireQualifiedAccess>] RestApiResponseStatus =
    | Completed = 0
    | Failed = 1
    | Inprogress = 2
    | Skipped = 3

/// REST Api Response
type [<AllowNullLiteral>] RestApiResponseStatusModel =
    /// Gets or sets the operation details
    abstract operationDetails: obj option with get, set
    /// Gets or sets the operation id
    abstract operationId: string with get, set
    /// Gets or sets the completed status percentage
    abstract percentageCompleted: int with get, set
    /// Gets or sets the status
    abstract status: RestApiResponseStatus with get, set
    /// Gets or sets the status message
    abstract statusMessage: string with get, set

type [<AllowNullLiteral>] Review =
    /// Admin Reply, if any, for this review
    abstract adminReply: ReviewReply with get, set
    /// Unique identifier of a review item
    abstract id: int with get, set
    /// Flag for soft deletion
    abstract isDeleted: bool with get, set
    abstract isIgnored: bool with get, set
    /// Version of the product for which review was submitted
    abstract productVersion: string with get, set
    /// Rating provided by the user
    abstract rating: int with get, set
    /// Reply, if any, for this review
    abstract reply: ReviewReply with get, set
    /// Text description of the review
    abstract text: string with get, set
    /// Title of the review
    abstract title: string with get, set
    /// Time when the review was edited/updated
    abstract updatedDate: DateTime with get, set
    /// Name of the user
    abstract userDisplayName: string with get, set
    /// Id of the user who submitted the review
    abstract userId: string with get, set

type [<RequireQualifiedAccess>] ReviewEventOperation =
    | Create = 1
    | Update = 2
    | Delete = 3

/// Properties associated with Review event
type [<AllowNullLiteral>] ReviewEventProperties =
    /// Operation performed on Event - Create\\Update
    abstract eventOperation: ReviewEventOperation with get, set
    /// Flag to see if reply is admin reply
    abstract isAdminReply: bool with get, set
    /// Flag to record if the review is ignored
    abstract isIgnored: bool with get, set
    /// Rating at the time of event
    abstract rating: int with get, set
    /// Reply update date
    abstract replyDate: DateTime with get, set
    /// Publisher reply text or admin reply text
    abstract replyText: string with get, set
    /// User who responded to the review
    abstract replyUserId: string with get, set
    /// Review Event Type - Review
    abstract resourceType: ReviewResourceType with get, set
    /// Review update date
    abstract reviewDate: DateTime with get, set
    /// ReviewId of the review  on which the operation is performed
    abstract reviewId: int with get, set
    /// Text in Review Text
    abstract reviewText: string with get, set
    /// User display name at the time of review
    abstract userDisplayName: string with get, set
    /// User who gave review
    abstract userId: string with get, set

type [<RequireQualifiedAccess>] ReviewFilterOptions =
    | None = 0
    | FilterEmptyReviews = 1
    | FilterEmptyUserNames = 2

type [<AllowNullLiteral>] ReviewPatch =
    /// Denotes the patch operation type
    abstract operation: ReviewPatchOperation with get, set
    /// Use when patch operation is FlagReview
    abstract reportedConcern: UserReportedConcern with get, set
    /// Use when patch operation is EditReview
    abstract reviewItem: Review with get, set

type [<RequireQualifiedAccess>] ReviewPatchOperation =
    | FlagReview = 1
    | UpdateReview = 2
    | ReplyToReview = 3
    | AdminResponseForReview = 4
    | DeleteAdminReply = 5
    | DeletePublisherReply = 6

type [<AllowNullLiteral>] ReviewReply =
    /// Id of the reply
    abstract id: int with get, set
    /// Flag for soft deletion
    abstract isDeleted: bool with get, set
    /// Version of the product when the reply was submitted or updated
    abstract productVersion: string with get, set
    /// Content of the reply
    abstract replyText: string with get, set
    /// Id of the review, to which this reply belongs
    abstract reviewId: int with get, set
    /// Title of the reply
    abstract title: string with get, set
    /// Date the reply was submitted or updated
    abstract updatedDate: DateTime with get, set
    /// Id of the user who left the reply
    abstract userId: string with get, set

type [<RequireQualifiedAccess>] ReviewResourceType =
    | Review = 1
    | PublisherReply = 2
    | AdminReply = 3

type [<AllowNullLiteral>] ReviewsResult =
    /// Flag indicating if there are more reviews to be shown (for paging)
    abstract hasMoreReviews: bool with get, set
    /// List of reviews
    abstract reviews: ResizeArray<Review> with get, set
    /// Count of total review items
    abstract totalReviewCount: int with get, set

type [<AllowNullLiteral>] ReviewSummary =
    /// Average Rating
    abstract averageRating: int with get, set
    /// Count of total ratings
    abstract ratingCount: int with get, set
    /// Split of count across rating
    abstract ratingSplit: ResizeArray<RatingCountPerRating> with get, set

type [<RequireQualifiedAccess>] SortByType =
    | Relevance = 0
    | LastUpdatedDate = 1
    | Title = 2
    | Publisher = 3
    | InstallCount = 4
    | PublishedDate = 5
    | AverageRating = 6
    | TrendingDaily = 7
    | TrendingWeekly = 8
    | TrendingMonthly = 9
    | ReleaseDate = 10
    | Author = 11
    | WeightedRating = 12

type [<RequireQualifiedAccess>] SortOrderType =
    | Default = 0
    | Ascending = 1
    | Descending = 2

type [<AllowNullLiteral>] UnpackagedExtensionData =
    abstract categories: ResizeArray<string> with get, set
    abstract description: string with get, set
    abstract displayName: string with get, set
    abstract draftId: string with get, set
    abstract extensionName: string with get, set
    abstract installationTargets: ResizeArray<InstallationTarget> with get, set
    abstract isConvertedToMarkdown: bool with get, set
    abstract isPreview: bool with get, set
    abstract pricingCategory: string with get, set
    abstract product: string with get, set
    abstract publisherName: string with get, set
    abstract qnAEnabled: bool with get, set
    abstract referralUrl: string with get, set
    abstract repositoryUrl: string with get, set
    abstract tags: ResizeArray<string> with get, set
    abstract version: string with get, set
    abstract vsixId: string with get, set

/// Represents the extension policy applied to a given user
type [<AllowNullLiteral>] UserExtensionPolicy =
    /// User display name that this policy refers to
    abstract displayName: string with get, set
    /// The extension policy applied to the user
    abstract permissions: ExtensionPolicy with get, set
    /// User id that this policy refers to
    abstract userId: string with get, set

/// Identity reference with name and guid
type [<AllowNullLiteral>] UserIdentityRef =
    /// User display name
    abstract displayName: string with get, set
    /// User VSID
    abstract id: string with get, set

type [<AllowNullLiteral>] UserReportedConcern =
    /// Category of the concern
    abstract category: ConcernCategory with get, set
    /// User comment associated with the report
    abstract concernText: string with get, set
    /// Id of the review which was reported
    abstract reviewId: int with get, set
    /// Date the report was submitted
    abstract submittedDate: DateTime with get, set
    /// Id of the user who reported a review
    abstract userId: string with get, set

type [<AllowNullLiteral>] ExtensionDailyStatExtendedStats =
    [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

type [<AllowNullLiteral>] ExtensionDraftValidationErrors =
    abstract key: string with get, set
    abstract value: string with get, set

type [<AllowNullLiteral>] ExtensionEventsEvents =
    [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> ResizeArray<ExtensionEvent> with get, set
