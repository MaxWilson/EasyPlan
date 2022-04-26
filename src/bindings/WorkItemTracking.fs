// ts2fable 0.7.1
module rec WorkItemTracking
open System
open Fable.Core
open Fable.Core.JS

type [<AllowNullLiteral>] AccountMyWorkResult =
    /// True, when length of WorkItemDetails is same as the limit
    abstract querySizeLimitExceeded: bool with get, set
    /// WorkItem Details
    abstract workItemDetails: ResizeArray<AccountWorkWorkItemModel> with get, set

/// Represents Work Item Recent Activity
type [<AllowNullLiteral>] AccountRecentActivityWorkItemModel =
    inherit AccountRecentActivityWorkItemModelBase
    /// Assigned To
    abstract assignedTo: string with get, set

/// Represents Work Item Recent Activity
type [<AllowNullLiteral>] AccountRecentActivityWorkItemModel2 =
    inherit AccountRecentActivityWorkItemModelBase
    /// Assigned To
    abstract assignedTo: WebApi.IdentityRef with get, set

/// Represents Work Item Recent Activity
type [<AllowNullLiteral>] AccountRecentActivityWorkItemModelBase =
    /// Date of the last Activity by the user
    abstract activityDate: DateTime with get, set
    /// Type of the activity
    abstract activityType: WorkItemRecentActivityType with get, set
    /// Last changed date of the work item
    abstract changedDate: DateTime with get, set
    /// Work Item Id
    abstract id: float with get, set
    /// TeamFoundationId of the user this activity belongs to
    abstract identityId: string with get, set
    /// State of the work item
    abstract state: string with get, set
    /// Team project the work item belongs to
    abstract teamProject: string with get, set
    /// Title of the work item
    abstract title: string with get, set
    /// Type of Work Item
    abstract workItemType: string with get, set

/// Represents Recent Mention Work Item
type [<AllowNullLiteral>] AccountRecentMentionWorkItemModel =
    /// Assigned To
    abstract assignedTo: string with get, set
    /// Work Item Id
    abstract id: float with get, set
    /// Latest date that the user were mentioned
    abstract mentionedDateField: DateTime with get, set
    /// State of the work item
    abstract state: string with get, set
    /// Team project the work item belongs to
    abstract teamProject: string with get, set
    /// Title of the work item
    abstract title: string with get, set
    /// Type of Work Item
    abstract workItemType: string with get, set

type [<AllowNullLiteral>] AccountWorkWorkItemModel =
    abstract assignedTo: string with get, set
    abstract changedDate: DateTime with get, set
    abstract id: float with get, set
    abstract state: string with get, set
    abstract teamProject: string with get, set
    abstract title: string with get, set
    abstract workItemType: string with get, set

/// Contains criteria for querying work items based on artifact URI.
type [<AllowNullLiteral>] ArtifactUriQuery =
    /// List of artifact URIs to use for querying work items.
    abstract artifactUris: ResizeArray<string> with get, set

/// Defines result of artifact URI query on work items. Contains mapping of work item IDs to artifact URI.
type [<AllowNullLiteral>] ArtifactUriQueryResult =
    /// A Dictionary that maps a list of work item references to the given list of artifact URI.
    abstract artifactUrisQueryResult: ArtifactUriQueryResultArtifactUrisQueryResult with get, set

type [<AllowNullLiteral>] AttachmentReference =
    abstract id: string with get, set
    abstract url: string with get, set

type [<RequireQualifiedAccess>] ClassificationNodesErrorPolicy =
    | Fail = 1
    | Omit = 2

/// Comment on a Work Item.
type [<AllowNullLiteral>] Comment =
    inherit WorkItemTrackingResource
    /// IdentityRef of the creator of the comment.
    abstract createdBy: WebApi.IdentityRef with get, set
    /// The creation date of the comment.
    abstract createdDate: DateTime with get, set
    /// Effective Date/time value for adding the comment. Can be optionally different from CreatedDate.
    abstract createdOnBehalfDate: DateTime with get, set
    /// Identity on whose behalf this comment has been added. Can be optionally different from CreatedBy.
    abstract createdOnBehalfOf: WebApi.IdentityRef with get, set
    /// The id assigned to the comment.
    abstract id: float with get, set
    /// Indicates if the comment has been deleted.
    abstract isDeleted: bool with get, set
    /// The mentions of the comment.
    abstract mentions: ResizeArray<CommentMention> with get, set
    /// IdentityRef of the user who last modified the comment.
    abstract modifiedBy: WebApi.IdentityRef with get, set
    /// The last modification date of the comment.
    abstract modifiedDate: DateTime with get, set
    /// The reactions of the comment.
    abstract reactions: ResizeArray<CommentReaction> with get, set
    /// The text of the comment.
    abstract text: string with get, set
    /// The current version of the comment.
    abstract version: float with get, set
    /// The id of the work item this comment belongs to.
    abstract workItemId: float with get, set

/// Represents a request to create a work item comment.
type [<AllowNullLiteral>] CommentCreate =
    /// The text of the comment.
    abstract text: string with get, set

type [<RequireQualifiedAccess>] CommentExpandOptions =
    | None = 0
    | Reactions = 1
    | RenderedText = 8
    | RenderedTextOnly = 16
    | All = -17

/// Represents a list of work item comments.
type [<AllowNullLiteral>] CommentList =
    inherit WorkItemTrackingResource
    /// List of comments in the current batch.
    abstract comments: ResizeArray<Comment> with get, set
    /// A string token that can be used to retrieving next page of comments if available. Otherwise null.
    abstract continuationToken: string with get, set
    /// The count of comments in the current batch.
    abstract count: float with get, set
    /// Uri to the next page of comments if it is available. Otherwise null.
    abstract nextPage: string with get, set
    /// Total count of comments on a work item.
    abstract totalCount: float with get, set

type [<AllowNullLiteral>] CommentMention =
    inherit WorkItemTrackingResource
    /// The artifact portion of the parsed text. (i.e. the work item's id)
    abstract artifactId: string with get, set
    /// The type the parser assigned to the mention. (i.e. person, work item, etc)
    abstract artifactType: string with get, set
    /// The comment id of the mention.
    abstract commentId: float with get, set
    /// The resolved target of the mention. An example of this could be a user's tfid
    abstract targetId: string with get, set

/// Contains information about work item comment reaction for a particular reaction type.
type [<AllowNullLiteral>] CommentReaction =
    inherit WorkItemTrackingResource
    /// The id of the comment this reaction belongs to.
    abstract commentId: float with get, set
    /// Total number of reactions for the CommentReactionType.
    abstract count: float with get, set
    /// Flag to indicate if the current user has engaged on this particular EngagementType (e.g. if they liked the associated comment).
    abstract isCurrentUserEngaged: bool with get, set
    /// Type of the reaction.
    abstract ``type``: CommentReactionType with get, set

type [<RequireQualifiedAccess>] CommentReactionType =
    | Like = 0
    | Dislike = 1
    | Heart = 2
    | Hooray = 3
    | Smile = 4
    | Confused = 5

type [<RequireQualifiedAccess>] CommentSortOrder =
    | Asc = 1
    | Desc = 2

/// Represents a request to update a work item comment.
type [<AllowNullLiteral>] CommentUpdate =
    /// The updated text of the comment.
    abstract text: string with get, set

/// Represents a specific version of a comment on a work item.
type [<AllowNullLiteral>] CommentVersion =
    inherit WorkItemTrackingResource
    /// IdentityRef of the creator of the comment.
    abstract createdBy: WebApi.IdentityRef with get, set
    /// The creation date of the comment.
    abstract createdDate: DateTime with get, set
    /// Effective Date/time value for adding the comment. Can be optionally different from CreatedDate.
    abstract createdOnBehalfDate: DateTime with get, set
    /// Identity on whose behalf this comment has been added. Can be optionally different from CreatedBy.
    abstract createdOnBehalfOf: WebApi.IdentityRef with get, set
    /// The id assigned to the comment.
    abstract id: float with get, set
    /// Indicates if the comment has been deleted at this version.
    abstract isDeleted: bool with get, set
    /// IdentityRef of the user who modified the comment at this version.
    abstract modifiedBy: WebApi.IdentityRef with get, set
    /// The modification date of the comment for this version.
    abstract modifiedDate: DateTime with get, set
    /// The rendered content of the comment at this version.
    abstract renderedText: string with get, set
    /// The text of the comment at this version.
    abstract text: string with get, set
    /// The version number.
    abstract version: float with get, set

type [<AllowNullLiteral>] ExternalDeployment =
    abstract artifactId: string with get, set
    abstract createdBy: string with get, set
    abstract description: string with get, set
    abstract displayName: string with get, set
    abstract environment: ExternalEnvironment with get, set
    abstract group: string with get, set
    abstract pipeline: ExternalPipeline with get, set
    abstract relatedWorkItemIds: ResizeArray<float> with get, set
    abstract runId: float with get, set
    abstract sequenceNumber: float with get, set
    abstract status: string with get, set
    abstract statusDate: DateTime with get, set
    abstract url: string with get, set

type [<AllowNullLiteral>] ExternalEnvironment =
    abstract displayName: string with get, set
    abstract id: float with get, set
    abstract ``type``: string with get, set

type [<AllowNullLiteral>] ExternalPipeline =
    abstract displayName: string with get, set
    abstract id: float with get, set
    abstract url: string with get, set

/// Describes a list of dependent fields for a rule.
type [<AllowNullLiteral>] FieldDependentRule =
    inherit WorkItemTrackingResource
    /// The dependent fields.
    abstract dependentFields: ResizeArray<WorkItemFieldReference> with get, set

type [<RequireQualifiedAccess>] FieldType =
    | String = 0
    | Integer = 1
    | DateTime = 2
    | PlainText = 3
    | Html = 4
    | TreePath = 5
    | History = 6
    | Double = 7
    | Guid = 8
    | Boolean = 9
    | Identity = 10
    | PicklistString = 11
    | PicklistInteger = 12
    | PicklistDouble = 13

type [<RequireQualifiedAccess>] FieldUsage =
    | None = 0
    | WorkItem = 1
    | WorkItemLink = 2
    | Tree = 3
    | WorkItemTypeExtension = 4

type [<RequireQualifiedAccess>] GetFieldsExpand =
    | None = 0
    | ExtensionFields = 1
    | IncludeDeleted = 2

/// Describes a reference to an identity.
type [<AllowNullLiteral>] IdentityReference =
    inherit WebApi.IdentityRef
    abstract id: string with get, set
    /// Legacy back-compat property. This has been the WIT specific value from Constants. Will be hidden (but exists) on the client unless they are targeting the newest version
    abstract name: string with get, set

/// Link description.
type [<AllowNullLiteral>] Link =
    /// Collection of link attributes.
    abstract attributes: LinkAttributes with get, set
    /// Relation type.
    abstract rel: string with get, set
    /// Link url.
    abstract url: string with get, set

type [<RequireQualifiedAccess>] LinkQueryMode =
    | WorkItems = 0
    | LinksOneHopMustContain = 1
    | LinksOneHopMayContain = 2
    | LinksOneHopDoesNotContain = 3
    | LinksRecursiveMustContain = 4
    | LinksRecursiveMayContain = 5
    | LinksRecursiveDoesNotContain = 6

type [<RequireQualifiedAccess>] LogicalOperation =
    | NONE = 0
    | AND = 1
    | OR = 2

/// Project work item type state colors
type [<AllowNullLiteral>] ProjectWorkItemStateColors =
    /// Project name
    abstract projectName: string with get, set
    /// State colors for all work item type in a project
    abstract workItemTypeStateColors: ResizeArray<WorkItemTypeStateColors> with get, set

type [<RequireQualifiedAccess>] ProvisioningActionType =
    | Import = 0
    | Validate = 1

/// Result of an update work item type XML update operation.
type [<AllowNullLiteral>] ProvisioningResult =
    /// Details about of the provisioning import events.
    abstract provisioningImportEvents: ResizeArray<string> with get, set

/// Describes a request to get a list of queries
type [<AllowNullLiteral>] QueryBatchGetRequest =
    /// The expand parameters for queries. Possible options are \{ None, Wiql, Clauses, All, Minimal \}
    abstract ``$expand``: QueryExpand with get, set
    /// The flag to control error policy in a query batch request. Possible options are \{ Fail, Omit \}.
    abstract errorPolicy: QueryErrorPolicy with get, set
    /// The requested query ids
    abstract ids: ResizeArray<string> with get, set

type [<RequireQualifiedAccess>] QueryErrorPolicy =
    | Fail = 1
    | Omit = 2

type [<RequireQualifiedAccess>] QueryExpand =
    | None = 0
    | Wiql = 1
    | Clauses = 2
    | All = 3
    | Minimal = 4

/// Represents an item in the work item query hierarchy. This can be either a query or a folder.
type [<AllowNullLiteral>] QueryHierarchyItem =
    inherit WorkItemTrackingResource
    /// The child query items inside a query folder.
    abstract children: ResizeArray<QueryHierarchyItem> with get, set
    /// The clauses for a flat query.
    abstract clauses: WorkItemQueryClause with get, set
    /// The columns of the query.
    abstract columns: ResizeArray<WorkItemFieldReference> with get, set
    /// The identity who created the query item.
    abstract createdBy: IdentityReference with get, set
    /// When the query item was created.
    abstract createdDate: DateTime with get, set
    /// The link query mode.
    abstract filterOptions: LinkQueryMode with get, set
    /// If this is a query folder, indicates if it contains any children.
    abstract hasChildren: bool with get, set
    /// The id of the query item.
    abstract id: string with get, set
    /// Indicates if this query item is deleted. Setting this to false on a deleted query item will undelete it. Undeleting a query or folder will not bring back the permission changes that were previously applied to it.
    abstract isDeleted: bool with get, set
    /// Indicates if this is a query folder or a query.
    abstract isFolder: bool with get, set
    /// Indicates if the WIQL of this query is invalid. This could be due to invalid syntax or a no longer valid area/iteration path.
    abstract isInvalidSyntax: bool with get, set
    /// Indicates if this query item is public or private.
    abstract isPublic: bool with get, set
    /// The identity who last ran the query.
    abstract lastExecutedBy: IdentityReference with get, set
    /// When the query was last run.
    abstract lastExecutedDate: DateTime with get, set
    /// The identity who last modified the query item.
    abstract lastModifiedBy: IdentityReference with get, set
    /// When the query item was last modified.
    abstract lastModifiedDate: DateTime with get, set
    /// The link query clause.
    abstract linkClauses: WorkItemQueryClause with get, set
    /// The name of the query item.
    abstract name: string with get, set
    /// The path of the query item.
    abstract path: string with get, set
    /// The recursion option for use in a tree query.
    abstract queryRecursionOption: QueryRecursionOption with get, set
    /// The type of query.
    abstract queryType: QueryType with get, set
    /// The sort columns of the query.
    abstract sortColumns: ResizeArray<WorkItemQuerySortColumn> with get, set
    /// The source clauses in a tree or one-hop link query.
    abstract sourceClauses: WorkItemQueryClause with get, set
    /// The target clauses in a tree or one-hop link query.
    abstract targetClauses: WorkItemQueryClause with get, set
    /// The WIQL text of the query
    abstract wiql: string with get, set

type [<AllowNullLiteral>] QueryHierarchyItemsResult =
    /// The count of items.
    abstract count: float with get, set
    /// Indicates if the max return limit was hit but there are still more items
    abstract hasMore: bool with get, set
    /// The list of items
    abstract value: ResizeArray<QueryHierarchyItem> with get, set

type [<RequireQualifiedAccess>] QueryOption =
    | Doing = 1
    | Done = 2
    | Followed = 3

type [<RequireQualifiedAccess>] QueryRecursionOption =
    | ParentFirst = 0
    | ChildFirst = 1

type [<RequireQualifiedAccess>] QueryResultType =
    | WorkItem = 1
    | WorkItemLink = 2

type [<RequireQualifiedAccess>] QueryType =
    | Flat = 1
    | Tree = 2
    | OneHop = 3

type [<RequireQualifiedAccess>] ReportingRevisionsExpand =
    | None = 0
    | Fields = 1

type [<AllowNullLiteral>] ReportingWorkItemLinksBatch =
    inherit StreamedBatch<WorkItemRelation>

type [<AllowNullLiteral>] ReportingWorkItemRevisionsBatch =
    inherit StreamedBatch<WorkItem>

/// The class represents the reporting work item revision filer.
type [<AllowNullLiteral>] ReportingWorkItemRevisionsFilter =
    /// A list of fields to return in work item revisions. Omit this parameter to get all reportable fields.
    abstract fields: ResizeArray<string> with get, set
    /// Include deleted work item in the result.
    abstract includeDeleted: bool with get, set
    /// Return an identity reference instead of a string value for identity fields.
    abstract includeIdentityRef: bool with get, set
    /// Include only the latest version of a work item, skipping over all previous revisions of the work item.
    abstract includeLatestOnly: bool with get, set
    /// Include tag reference instead of string value for System.Tags field
    abstract includeTagRef: bool with get, set
    /// A list of types to filter the results to specific work item types. Omit this parameter to get work item revisions of all work item types.
    abstract types: ResizeArray<string> with get, set

/// The class describes reporting work item revision batch.
type [<AllowNullLiteral>] StreamedBatch<'T> =
    /// ContinuationToken acts as a waterMark. Used while querying large results.
    abstract continuationToken: string with get, set
    /// Returns 'true' if it's last batch, 'false' otherwise.
    abstract isLastBatch: bool with get, set
    /// The next link for the work item.
    abstract nextLink: string with get, set
    /// Values such as rel, sourceId, TargetId, ChangedDate, isActive.
    abstract values: ResizeArray<'T> with get, set

type [<RequireQualifiedAccess>] TemplateType =
    | WorkItemType = 0
    | GlobalWorkflow = 1

type [<RequireQualifiedAccess>] TreeNodeStructureType =
    | Area = 0
    | Iteration = 1

type [<RequireQualifiedAccess>] TreeStructureGroup =
    | Areas = 0
    | Iterations = 1

/// A WIQL query
type [<AllowNullLiteral>] Wiql =
    /// The text of the WIQL query
    abstract query: string with get, set

/// A work artifact link describes an outbound artifact link type.
type [<AllowNullLiteral>] WorkArtifactLink =
    /// Target artifact type.
    abstract artifactType: string with get, set
    /// Outbound link type.
    abstract linkType: string with get, set
    /// Target tool type.
    abstract toolType: string with get, set

/// Describes a work item.
type [<AllowNullLiteral>] WorkItem =
    inherit WorkItemTrackingResource
    /// Reference to a specific version of the comment added/edited/deleted in this revision.
    abstract commentVersionRef: WorkItemCommentVersionRef with get, set
    /// Map of field and values for the work item.
    abstract fields: LinkAttributes with get, set
    /// The work item ID.
    abstract id: float with get, set
    /// Relations of the work item.
    abstract relations: ResizeArray<WorkItemRelation> with get, set
    /// Revision number of the work item.
    abstract rev: float with get, set

/// Describes a request to get a set of work items
type [<AllowNullLiteral>] WorkItemBatchGetRequest =
    /// The expand parameters for work item attributes. Possible options are \{ None, Relations, Fields, Links, All \}
    abstract ``$expand``: WorkItemExpand with get, set
    /// AsOf UTC date time string
    abstract asOf: DateTime with get, set
    /// The flag to control error policy in a bulk get work items request. Possible options are \{Fail, Omit\}.
    abstract errorPolicy: WorkItemErrorPolicy with get, set
    /// The requested fields
    abstract fields: ResizeArray<string> with get, set
    /// The requested work item ids
    abstract ids: ResizeArray<float> with get, set

/// Defines a classification node for work item tracking.
type [<AllowNullLiteral>] WorkItemClassificationNode =
    inherit WorkItemTrackingResource
    /// Dictionary that has node attributes like start/finish date for iteration nodes.
    abstract attributes: LinkAttributes with get, set
    /// List of child nodes fetched.
    abstract children: ResizeArray<WorkItemClassificationNode> with get, set
    /// Flag that indicates if the classification node has any child nodes.
    abstract hasChildren: bool with get, set
    /// Integer ID of the classification node.
    abstract id: float with get, set
    /// GUID ID of the classification node.
    abstract identifier: string with get, set
    /// Name of the classification node.
    abstract name: string with get, set
    /// Path of the classification node.
    abstract path: string with get, set
    /// Node structure type.
    abstract structureType: TreeNodeStructureType with get, set

/// Comment on Work Item
type [<AllowNullLiteral>] WorkItemComment =
    inherit WorkItemTrackingResource
    /// Identity of user who added the comment.
    abstract revisedBy: IdentityReference with get, set
    /// The date of comment.
    abstract revisedDate: DateTime with get, set
    /// The work item revision number.
    abstract revision: float with get, set
    /// The text of the comment.
    abstract text: string with get, set

/// Collection of comments.
type [<AllowNullLiteral>] WorkItemComments =
    inherit WorkItemTrackingResource
    /// Comments collection.
    abstract comments: ResizeArray<WorkItemComment> with get, set
    /// The count of comments.
    abstract count: float with get, set
    /// Count of comments from the revision.
    abstract fromRevisionCount: float with get, set
    /// Total count of comments.
    abstract totalCount: float with get, set

/// Represents the reference to a specific version of a comment on a Work Item.
type [<AllowNullLiteral>] WorkItemCommentVersionRef =
    inherit WorkItemTrackingResourceReference
    /// The id assigned to the comment.
    abstract commentId: float with get, set
    /// [Internal] The work item revision where this comment was originally added.
    abstract createdInRevision: float with get, set
    /// [Internal] Specifies whether comment was deleted.
    abstract isDeleted: bool with get, set
    /// [Internal] The text of the comment.
    abstract text: string with get, set
    /// The version number.
    abstract version: float with get, set

/// Full deleted work item object. Includes the work item itself.
type [<AllowNullLiteral>] WorkItemDelete =
    inherit WorkItemDeleteReference
    /// The work item object that was deleted.
    abstract resource: WorkItem with get, set

/// Reference to a deleted work item.
type [<AllowNullLiteral>] WorkItemDeleteReference =
    /// The HTTP status code for work item operation in a batch request.
    abstract code: float with get, set
    /// The user who deleted the work item type.
    abstract deletedBy: string with get, set
    /// The work item deletion date.
    abstract deletedDate: string with get, set
    /// Work item ID.
    abstract id: float with get, set
    /// The exception message for work item operation in a batch request.
    abstract message: string with get, set
    /// Name or title of the work item.
    abstract name: string with get, set
    /// Parent project of the deleted work item.
    abstract project: string with get, set
    /// Type of work item.
    abstract ``type``: string with get, set
    /// REST API URL of the resource
    abstract url: string with get, set

/// Shallow Reference to a deleted work item.
type [<AllowNullLiteral>] WorkItemDeleteShallowReference =
    /// Work item ID.
    abstract id: float with get, set
    /// REST API URL of the resource
    abstract url: string with get, set

/// Describes an update request for a deleted work item.
type [<AllowNullLiteral>] WorkItemDeleteUpdate =
    /// Sets a value indicating whether this work item is deleted.
    abstract isDeleted: bool with get, set

type [<RequireQualifiedAccess>] WorkItemErrorPolicy =
    | Fail = 1
    | Omit = 2

type [<RequireQualifiedAccess>] WorkItemExpand =
    | None = 0
    | Relations = 1
    | Fields = 2
    | Links = 3
    | All = 4

/// Describes a field on a work item and it's properties specific to that work item type.
type [<AllowNullLiteral>] WorkItemField =
    inherit WorkItemTrackingResource
    /// Indicates whether the field is sortable in server queries.
    abstract canSortBy: bool with get, set
    /// The description of the field.
    abstract description: string with get, set
    /// Indicates whether this field is deleted.
    abstract isDeleted: bool with get, set
    /// Indicates whether this field is an identity field.
    abstract isIdentity: bool with get, set
    /// Indicates whether this instance is picklist.
    abstract isPicklist: bool with get, set
    /// Indicates whether this instance is a suggested picklist .
    abstract isPicklistSuggested: bool with get, set
    /// Indicates whether the field can be queried in the server.
    abstract isQueryable: bool with get, set
    /// The name of the field.
    abstract name: string with get, set
    /// If this field is picklist, the identifier of the picklist associated, otherwise null
    abstract picklistId: string with get, set
    /// Indicates whether the field is [read only].
    abstract readOnly: bool with get, set
    /// The reference name of the field.
    abstract referenceName: string with get, set
    /// The supported operations on this field.
    abstract supportedOperations: ResizeArray<WorkItemFieldOperation> with get, set
    /// The type of the field.
    abstract ``type``: FieldType with get, set
    /// The usage of the field.
    abstract usage: FieldUsage with get, set

/// Describes a work item field operation.
type [<AllowNullLiteral>] WorkItemFieldOperation =
    /// Friendly name of the operation.
    abstract name: string with get, set
    /// Reference name of the operation.
    abstract referenceName: string with get, set

/// Reference to a field in a work item
type [<AllowNullLiteral>] WorkItemFieldReference =
    /// The friendly name of the field.
    abstract name: string with get, set
    /// The reference name of the field.
    abstract referenceName: string with get, set
    /// The REST URL of the resource.
    abstract url: string with get, set

/// Describes an update to a work item field.
type [<AllowNullLiteral>] WorkItemFieldUpdate =
    /// The new value of the field.
    abstract newValue: obj option with get, set
    /// The old value of the field.
    abstract oldValue: obj option with get, set

type [<AllowNullLiteral>] WorkItemHistory =
    inherit WorkItemTrackingResource
    abstract rev: float with get, set
    abstract revisedBy: IdentityReference with get, set
    abstract revisedDate: DateTime with get, set
    abstract value: string with get, set

/// Reference to a work item icon.
type [<AllowNullLiteral>] WorkItemIcon =
    /// The identifier of the icon.
    abstract id: string with get, set
    /// The REST URL of the resource.
    abstract url: string with get, set

/// A link between two work items.
type [<AllowNullLiteral>] WorkItemLink =
    /// The type of link.
    abstract rel: string with get, set
    /// The source work item.
    abstract source: WorkItemReference with get, set
    /// The target work item.
    abstract target: WorkItemReference with get, set

/// Describes the next state for a work item.
type [<AllowNullLiteral>] WorkItemNextStateOnTransition =
    /// Error code if there is no next state transition possible.
    abstract errorCode: string with get, set
    /// Work item ID.
    abstract id: float with get, set
    /// Error message if there is no next state transition possible.
    abstract message: string with get, set
    /// Name of the next state on transition.
    abstract stateOnTransition: string with get, set

/// Represents a clause in a work item query. This shows the structure of a work item query.
type [<AllowNullLiteral>] WorkItemQueryClause =
    /// Child clauses if the current clause is a logical operator
    abstract clauses: ResizeArray<WorkItemQueryClause> with get, set
    /// Field associated with condition
    abstract field: WorkItemFieldReference with get, set
    /// Right side of the condition when a field to field comparison
    abstract fieldValue: WorkItemFieldReference with get, set
    /// Determines if this is a field to field comparison
    abstract isFieldValue: bool with get, set
    /// Logical operator separating the condition clause
    abstract logicalOperator: LogicalOperation with get, set
    /// The field operator
    abstract operator: WorkItemFieldOperation with get, set
    /// Right side of the condition when a field to value comparison
    abstract value: string with get, set

/// The result of a work item query.
type [<AllowNullLiteral>] WorkItemQueryResult =
    /// The date the query was run in the context of.
    abstract asOf: DateTime with get, set
    /// The columns of the query.
    abstract columns: ResizeArray<WorkItemFieldReference> with get, set
    /// The result type
    abstract queryResultType: QueryResultType with get, set
    /// The type of the query
    abstract queryType: QueryType with get, set
    /// The sort columns of the query.
    abstract sortColumns: ResizeArray<WorkItemQuerySortColumn> with get, set
    /// The work item links returned by the query.
    abstract workItemRelations: ResizeArray<WorkItemLink> with get, set
    /// The work items returned by the query.
    abstract workItems: ResizeArray<WorkItemReference> with get, set

/// A sort column.
type [<AllowNullLiteral>] WorkItemQuerySortColumn =
    /// The direction to sort by.
    abstract descending: bool with get, set
    /// A work item field.
    abstract field: WorkItemFieldReference with get, set

type [<RequireQualifiedAccess>] WorkItemRecentActivityType =
    | Visited = 0
    | Edited = 1
    | Deleted = 2
    | Restored = 3

/// Contains reference to a work item.
type [<AllowNullLiteral>] WorkItemReference =
    /// Work item ID.
    abstract id: float with get, set
    /// REST API URL of the resource
    abstract url: string with get, set

type [<AllowNullLiteral>] WorkItemRelation =
    inherit Link

/// Represents the work item type relation type.
type [<AllowNullLiteral>] WorkItemRelationType =
    inherit WorkItemTrackingReference
    /// The collection of relation type attributes.
    abstract attributes: LinkAttributes with get, set

/// Describes updates to a work item's relations.
type [<AllowNullLiteral>] WorkItemRelationUpdates =
    /// List of newly added relations.
    abstract added: ResizeArray<WorkItemRelation> with get, set
    /// List of removed relations.
    abstract removed: ResizeArray<WorkItemRelation> with get, set
    /// List of updated relations.
    abstract updated: ResizeArray<WorkItemRelation> with get, set

/// Work item type state name, color and state category
type [<AllowNullLiteral>] WorkItemStateColor =
    /// Category of state
    abstract category: string with get, set
    /// Color value
    abstract color: string with get, set
    /// Work item type state name
    abstract name: string with get, set

/// Describes a state transition in a work item.
type [<AllowNullLiteral>] WorkItemStateTransition =
    /// Gets a list of actions needed to transition to that state.
    abstract actions: ResizeArray<string> with get, set
    /// Name of the next state.
    abstract ``to``: string with get, set

type [<AllowNullLiteral>] WorkItemTagDefinition =
    abstract id: string with get, set
    abstract name: string with get, set
    abstract url: string with get, set

/// Describes a work item template.
type [<AllowNullLiteral>] WorkItemTemplate =
    inherit WorkItemTemplateReference
    /// Mapping of field and its templated value.
    abstract fields: WorkItemTemplateFields with get, set

/// Describes a shallow reference to a work item template.
type [<AllowNullLiteral>] WorkItemTemplateReference =
    inherit WorkItemTrackingResource
    /// The description of the work item template.
    abstract description: string with get, set
    /// The identifier of the work item template.
    abstract id: string with get, set
    /// The name of the work item template.
    abstract name: string with get, set
    /// The name of the work item type.
    abstract workItemTypeName: string with get, set

type [<AllowNullLiteral>] WorkItemTrackingReference =
    inherit WorkItemTrackingResource
    /// The name.
    abstract name: string with get, set
    /// The reference name.
    abstract referenceName: string with get, set

/// Base class for WIT REST resources.
type [<AllowNullLiteral>] WorkItemTrackingResource =
    inherit WorkItemTrackingResourceReference
    /// Link references to related REST resources.
    abstract _links: obj option with get, set

/// Base class for work item tracking resource references.
type [<AllowNullLiteral>] WorkItemTrackingResourceReference =
    abstract url: string with get, set

/// Describes a work item type.
type [<AllowNullLiteral>] WorkItemType =
    inherit WorkItemTrackingResource
    /// The color.
    abstract color: string with get, set
    /// The description of the work item type.
    abstract description: string with get, set
    /// The fields that exist on the work item type.
    abstract fieldInstances: ResizeArray<WorkItemTypeFieldInstance> with get, set
    /// The fields that exist on the work item type.
    abstract fields: ResizeArray<WorkItemTypeFieldInstance> with get, set
    /// The icon of the work item type.
    abstract icon: WorkItemIcon with get, set
    /// True if work item type is disabled
    abstract isDisabled: bool with get, set
    /// Gets the name of the work item type.
    abstract name: string with get, set
    /// The reference name of the work item type.
    abstract referenceName: string with get, set
    /// Gets state information for the work item type.
    abstract states: ResizeArray<WorkItemStateColor> with get, set
    /// Gets the various state transition mappings in the work item type.
    abstract transitions: WorkItemTypeTransitions with get, set
    /// The XML form.
    abstract xmlForm: string with get, set

/// Describes a work item type category.
type [<AllowNullLiteral>] WorkItemTypeCategory =
    inherit WorkItemTrackingResource
    /// Gets or sets the default type of the work item.
    abstract defaultWorkItemType: WorkItemTypeReference with get, set
    /// The name of the category.
    abstract name: string with get, set
    /// The reference name of the category.
    abstract referenceName: string with get, set
    /// The work item types that belong to the category.
    abstract workItemTypes: ResizeArray<WorkItemTypeReference> with get, set

/// Describes a work item type's colors.
type [<AllowNullLiteral>] WorkItemTypeColor =
    /// Gets or sets the color of the primary.
    abstract primaryColor: string with get, set
    /// Gets or sets the color of the secondary.
    abstract secondaryColor: string with get, set
    /// The name of the work item type.
    abstract workItemTypeName: string with get, set

/// Describes work item type nam, its icon and color.
type [<AllowNullLiteral>] WorkItemTypeColorAndIcon =
    /// The color of the work item type in hex format.
    abstract color: string with get, set
    /// The work item type icon.
    abstract icon: string with get, set
    /// The name of the work item type.
    abstract workItemTypeName: string with get, set

/// Field instance of a work item type.
type [<AllowNullLiteral>] WorkItemTypeFieldInstance =
    inherit WorkItemTypeFieldInstanceBase
    /// The list of field allowed values.
    abstract allowedValues: ResizeArray<string> with get, set
    /// Represents the default value of the field.
    abstract defaultValue: string with get, set

/// Base field instance for workItemType fields.
type [<AllowNullLiteral>] WorkItemTypeFieldInstanceBase =
    inherit WorkItemFieldReference
    /// Indicates whether field value is always required.
    abstract alwaysRequired: bool with get, set
    /// The list of dependent fields.
    abstract dependentFields: ResizeArray<WorkItemFieldReference> with get, set
    /// Gets the help text for the field.
    abstract helpText: string with get, set

type [<RequireQualifiedAccess>] WorkItemTypeFieldsExpandLevel =
    | None = 0
    | AllowedValues = 1
    | DependentFields = 2
    | All = 3

/// Field Instance of a workItemype with detailed references.
type [<AllowNullLiteral>] WorkItemTypeFieldWithReferences =
    inherit WorkItemTypeFieldInstanceBase
    /// The list of field allowed values.
    abstract allowedValues: ResizeArray<obj option> with get, set
    /// Represents the default value of the field.
    abstract defaultValue: obj option with get, set

/// Reference to a work item type.
type [<AllowNullLiteral>] WorkItemTypeReference =
    inherit WorkItemTrackingResourceReference
    /// Name of the work item type.
    abstract name: string with get, set

/// State colors for a work item type
type [<AllowNullLiteral>] WorkItemTypeStateColors =
    /// Work item type state colors
    abstract stateColors: ResizeArray<WorkItemStateColor> with get, set
    /// Work item type name
    abstract workItemTypeName: string with get, set

/// Describes a work item type template.
type [<AllowNullLiteral>] WorkItemTypeTemplate =
    /// XML template in string format.
    abstract template: string with get, set

/// Describes a update work item type template request body.
type [<AllowNullLiteral>] WorkItemTypeTemplateUpdateModel =
    /// Describes the type of the action for the update request.
    abstract actionType: ProvisioningActionType with get, set
    /// Methodology to which the template belongs, eg. Agile, Scrum, CMMI.
    abstract methodology: string with get, set
    /// String representation of the work item type template.
    abstract template: string with get, set
    /// The type of the template described in the request body.
    abstract templateType: TemplateType with get, set

/// Describes an update to a work item.
type [<AllowNullLiteral>] WorkItemUpdate =
    inherit WorkItemTrackingResource
    /// List of updates to fields.
    abstract fields: WorkItemUpdateFields with get, set
    /// ID of update.
    abstract id: float with get, set
    /// List of updates to relations.
    abstract relations: WorkItemRelationUpdates with get, set
    /// The revision number of work item update.
    abstract rev: float with get, set
    /// Identity for the work item update.
    abstract revisedBy: IdentityReference with get, set
    /// The work item updates revision date.
    abstract revisedDate: DateTime with get, set
    /// The work item ID.
    abstract workItemId: float with get, set

type [<AllowNullLiteral>] ArtifactUriQueryResultArtifactUrisQueryResult =
    [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> ResizeArray<WorkItemReference> with get, set

type [<AllowNullLiteral>] LinkAttributes =
    [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

type [<AllowNullLiteral>] WorkItemTemplateFields =
    [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> string with get, set

type [<AllowNullLiteral>] WorkItemTypeTransitions =
    [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> ResizeArray<WorkItemStateTransition> with get, set

type [<AllowNullLiteral>] WorkItemUpdateFields =
    [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> WorkItemFieldUpdate with get, set
