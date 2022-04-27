// ts2fable 0.7.1
module rec WorkItemTrackingClient
open System
open Fable.Core
open Fable.Core.JS


type IVssRestClientOptions = Context.IVssRestClientOptions
type RestClientBase = RestClientBase.RestClientBase

type [<AllowNullLiteral>] IExports =
    abstract WorkItemTrackingRestClient: WorkItemTrackingRestClientStatic

type [<AllowNullLiteral>] WorkItemTrackingRestClient =
    inherit RestClientBase
    /// <summary>INTERNAL ONLY: USED BY ACCOUNT MY WORK PAGE. This returns Doing, Done, Follows and activity work items details.</summary>
    /// <param name="queryOption">-</param>
    abstract getAccountMyWorkData: ?queryOption: WorkItemTracking.QueryOption -> Promise<WorkItemTracking.AccountMyWorkResult>
    /// Gets recent work item activities
    abstract getRecentActivityData: unit -> Promise<ResizeArray<WorkItemTracking.AccountRecentActivityWorkItemModel2>>
    /// INTERNAL ONLY: USED BY ACCOUNT MY WORK PAGE.
    abstract getRecentMentions: unit -> Promise<ResizeArray<WorkItemTracking.AccountRecentMentionWorkItemModel>>
    /// Get the list of work item tracking outbound artifact link types.
    abstract getWorkArtifactLinkTypes: unit -> Promise<ResizeArray<WorkItemTracking.WorkArtifactLink>>
    /// <summary>Queries work items linked to a given list of artifact URI.</summary>
    /// <param name="artifactUriQuery">- Defines a list of artifact URI for querying work items.</param>
    /// <param name="project">- Project ID or project name</param>
    abstract queryWorkItemsForArtifactUris: artifactUriQuery: WorkItemTracking.ArtifactUriQuery * ?project: string -> Promise<WorkItemTracking.ArtifactUriQueryResult>
    /// <summary>Uploads an attachment.</summary>
    /// <param name="content">- Content to upload</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="fileName">- The name of the file</param>
    /// <param name="uploadType">- Attachment upload type: Simple or Chunked</param>
    /// <param name="areaPath">- Target project Area Path</param>
    abstract createAttachment: content: obj option * ?project: string * ?fileName: string * ?uploadType: string * ?areaPath: string -> Promise<WorkItemTracking.AttachmentReference>
    /// <summary>Downloads an attachment.</summary>
    /// <param name="id">- Attachment ID</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="fileName">- Name of the file</param>
    /// <param name="download">- If set to \<c\>true\</c\> always download attachment</param>
    abstract getAttachmentContent: id: string * ?project: string * ?fileName: string * ?download: bool -> Promise<ArrayBuffer>
    /// <summary>Downloads an attachment.</summary>
    /// <param name="id">- Attachment ID</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="fileName">- Name of the file</param>
    /// <param name="download">- If set to \<c\>true\</c\> always download attachment</param>
    abstract getAttachmentZip: id: string * ?project: string * ?fileName: string * ?download: bool -> Promise<ArrayBuffer>
    /// <summary>Gets root classification nodes or list of classification nodes for a given list of nodes ids, for a given project. In case ids parameter is supplied you will  get list of classification nodes for those ids. Otherwise you will get root classification nodes for this project.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="ids">- Comma separated integer classification nodes ids. It's not required, if you want root nodes.</param>
    /// <param name="depth">- Depth of children to fetch.</param>
    /// <param name="errorPolicy">- Flag to handle errors in getting some nodes. Possible options are Fail and Omit.</param>
    abstract getClassificationNodes: project: string * ids: ResizeArray<float> * ?depth: int * ?errorPolicy: WorkItemTracking.ClassificationNodesErrorPolicy -> Promise<ResizeArray<WorkItemTracking.WorkItemClassificationNode>>
    /// <summary>Gets root classification nodes under the project.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="depth">- Depth of children to fetch.</param>
    abstract getRootNodes: project: string * ?depth: int -> Promise<ResizeArray<WorkItemTracking.WorkItemClassificationNode>>
    /// <summary>Create new or update an existing classification node.</summary>
    /// <param name="postedNode">- Node to create or update.</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="structureGroup">- Structure group of the classification node, area or iteration.</param>
    /// <param name="path">- Path of the classification node.</param>
    abstract createOrUpdateClassificationNode: postedNode: WorkItemTracking.WorkItemClassificationNode * project: string * structureGroup: WorkItemTracking.TreeStructureGroup * ?path: string -> Promise<WorkItemTracking.WorkItemClassificationNode>
    /// <summary>Delete an existing classification node.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="structureGroup">- Structure group of the classification node, area or iteration.</param>
    /// <param name="path">- Path of the classification node.</param>
    /// <param name="reclassifyId">- Id of the target classification node for reclassification.</param>
    abstract deleteClassificationNode: project: string * structureGroup: WorkItemTracking.TreeStructureGroup * ?path: string * ?reclassifyId: int -> Promise<unit>
    /// <summary>Gets the classification node for a given node path.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="structureGroup">- Structure group of the classification node, area or iteration.</param>
    /// <param name="path">- Path of the classification node.</param>
    /// <param name="depth">- Depth of children to fetch.</param>
    abstract getClassificationNode: project: string * structureGroup: WorkItemTracking.TreeStructureGroup * ?path: string * ?depth: int -> Promise<WorkItemTracking.WorkItemClassificationNode>
    /// <summary>Update an existing classification node.</summary>
    /// <param name="postedNode">- Node to create or update.</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="structureGroup">- Structure group of the classification node, area or iteration.</param>
    /// <param name="path">- Path of the classification node.</param>
    abstract updateClassificationNode: postedNode: WorkItemTracking.WorkItemClassificationNode * project: string * structureGroup: WorkItemTracking.TreeStructureGroup * ?path: string -> Promise<WorkItemTracking.WorkItemClassificationNode>
    /// <summary>Gets a comment for a work item at the specified revision.</summary>
    /// <param name="id">- Work item id</param>
    /// <param name="revision">- Revision for which the comment need to be fetched</param>
    /// <param name="project">- Project ID or project name</param>
    abstract getComment: id: int * revision: int * ?project: string -> Promise<WorkItemTracking.WorkItemComment>
    /// <summary>Gets the specified number of comments for a work item from the specified revision.</summary>
    /// <param name="id">- Work item id</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="fromRevision">- Revision from which comments are to be fetched (default is 1)</param>
    /// <param name="top">- The number of comments to return (default is 200)</param>
    /// <param name="order">- Ascending or descending by revision id (default is ascending)</param>
    abstract getComments: id: int * ?project: string * ?fromRevision: int * ?top: int * ?order: WorkItemTracking.CommentSortOrder -> Promise<WorkItemTracking.WorkItemComments>
    /// <summary>Create a new field.</summary>
    /// <param name="workItemField">- New field definition</param>
    /// <param name="project">- Project ID or project name</param>
    abstract createField: workItemField: WorkItemTracking.WorkItemField * ?project: string -> Promise<WorkItemTracking.WorkItemField>
    /// <summary>Deletes the field.</summary>
    /// <param name="fieldNameOrRefName">- Field simple name or reference name</param>
    /// <param name="project">- Project ID or project name</param>
    abstract deleteField: fieldNameOrRefName: string * ?project: string -> Promise<unit>
    /// <summary>Gets information on a specific field.</summary>
    /// <param name="fieldNameOrRefName">- Field simple name or reference name</param>
    /// <param name="project">- Project ID or project name</param>
    abstract getField: fieldNameOrRefName: string * ?project: string -> Promise<WorkItemTracking.WorkItemField>
    /// <summary>Returns information for all fields. The project ID/name parameter is optional.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="expand">- Use ExtensionFields to include extension fields, otherwise exclude them. Unless the feature flag for this parameter is enabled, extension fields are always included.</param>
    abstract getFields: ?project: string * ?expand: WorkItemTracking.GetFieldsExpand -> Promise<ResizeArray<WorkItemTracking.WorkItemField>>
    /// <summary>Creates a query, or moves a query.</summary>
    /// <param name="postedQuery">- The query to create.</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="query">- The parent id or path under which the query is to be created.</param>
    /// <param name="validateWiqlOnly">- If you only want to validate your WIQL query without actually creating one, set it to true. Default is false.</param>
    abstract createQuery: postedQuery: WorkItemTracking.QueryHierarchyItem * project: string * query: string * ?validateWiqlOnly: bool -> Promise<WorkItemTracking.QueryHierarchyItem>
    /// <summary>Delete a query or a folder. This deletes any permission change on the deleted query or folder and any of its descendants if it is a folder. It is important to note that the deleted permission changes cannot be recovered upon undeleting the query or folder.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="query">- ID or path of the query or folder to delete.</param>
    abstract deleteQuery: project: string * query: string -> Promise<unit>
    /// <summary>Gets the root queries and their children</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="expand">- Include the query string (wiql), clauses, query result columns, and sort options in the results.</param>
    /// <param name="depth">- In the folder of queries, return child queries and folders to this depth.</param>
    /// <param name="includeDeleted">- Include deleted queries and folders</param>
    abstract getQueries: project: string * ?expand: WorkItemTracking.QueryExpand * ?depth: int * ?includeDeleted: bool -> Promise<ResizeArray<WorkItemTracking.QueryHierarchyItem>>
    /// <summary>Retrieves an individual query and its children</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="query">- ID or path of the query.</param>
    /// <param name="expand">- Include the query string (wiql), clauses, query result columns, and sort options in the results.</param>
    /// <param name="depth">- In the folder of queries, return child queries and folders to this depth.</param>
    /// <param name="includeDeleted">- Include deleted queries and folders</param>
    abstract getQuery: project: string * query: string * ?expand: WorkItemTracking.QueryExpand * ?depth: int * ?includeDeleted: bool -> Promise<WorkItemTracking.QueryHierarchyItem>
    /// <summary>Searches all queries the user has access to in the current project</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="filter">- The text to filter the queries with.</param>
    /// <param name="top">- The number of queries to return (Default is 50 and maximum is 200).</param>
    /// <param name="expand">-</param>
    /// <param name="includeDeleted">- Include deleted queries and folders</param>
    abstract searchQueries: project: string * filter: string * ?top: int * ?expand: WorkItemTracking.QueryExpand * ?includeDeleted: bool -> Promise<WorkItemTracking.QueryHierarchyItemsResult>
    /// <summary>Update a query or a folder. This allows you to update, rename and move queries and folders.</summary>
    /// <param name="queryUpdate">- The query to update.</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="query">- The ID or path for the query to update.</param>
    /// <param name="undeleteDescendants">- Undelete the children of this folder. It is important to note that this will not bring back the permission changes that were previously applied to the descendants.</param>
    abstract updateQuery: queryUpdate: WorkItemTracking.QueryHierarchyItem * project: string * query: string * ?undeleteDescendants: bool -> Promise<WorkItemTracking.QueryHierarchyItem>
    /// <summary>Gets a list of queries by ids (Maximum 1000)</summary>
    /// <param name="queryGetRequest">-</param>
    /// <param name="project">- Project ID or project name</param>
    abstract getQueriesBatch: queryGetRequest: WorkItemTracking.QueryBatchGetRequest * project: string -> Promise<ResizeArray<WorkItemTracking.QueryHierarchyItem>>
    /// <summary>Destroys the specified work item permanently from the Recycle Bin. This action can not be undone.</summary>
    /// <param name="id">- ID of the work item to be destroyed permanently</param>
    /// <param name="project">- Project ID or project name</param>
    abstract destroyWorkItem: id: int * ?project: string -> Promise<unit>
    /// <summary>Gets a deleted work item from Recycle Bin.</summary>
    /// <param name="id">- ID of the work item to be returned</param>
    /// <param name="project">- Project ID or project name</param>
    abstract getDeletedWorkItem: id: int * ?project: string -> Promise<WorkItemTracking.WorkItemDelete>
    /// <summary>Gets the work items from the recycle bin, whose IDs have been specified in the parameters</summary>
    /// <param name="ids">- Comma separated list of IDs of the deleted work items to be returned</param>
    /// <param name="project">- Project ID or project name</param>
    abstract getDeletedWorkItems: ids: ResizeArray<float> * ?project: string -> Promise<ResizeArray<WorkItemTracking.WorkItemDeleteReference>>
    /// <summary>Gets a list of the IDs and the URLs of the deleted the work items in the Recycle Bin.</summary>
    /// <param name="project">- Project ID or project name</param>
    abstract getDeletedWorkItemShallowReferences: ?project: string -> Promise<ResizeArray<WorkItemTracking.WorkItemDeleteShallowReference>>
    /// <summary>Restores the deleted work item from Recycle Bin.</summary>
    /// <param name="payload">- Paylod with instructions to update the IsDeleted flag to false</param>
    /// <param name="id">- ID of the work item to be restored</param>
    /// <param name="project">- Project ID or project name</param>
    abstract restoreWorkItem: payload: WorkItemTracking.WorkItemDeleteUpdate * id: int * ?project: string -> Promise<WorkItemTracking.WorkItemDelete>
    /// <summary>Returns a fully hydrated work item for the requested revision</summary>
    /// <param name="id">-</param>
    /// <param name="revisionNumber">-</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="expand">-</param>
    abstract getRevision: id: int * revisionNumber: int * ?project: string * ?expand: WorkItemTracking.WorkItemExpand -> Promise<WorkItemTracking.WorkItem>
    /// <summary>Returns the list of fully hydrated work item revisions, paged.</summary>
    /// <param name="id">-</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="top">-</param>
    /// <param name="skip">-</param>
    /// <param name="expand">-</param>
    abstract getRevisions: id: int * ?project: string * ?top: int * ?skip: int * ?expand: WorkItemTracking.WorkItemExpand -> Promise<ResizeArray<WorkItemTracking.WorkItem>>
    /// <summary>Creates a template</summary>
    /// <param name="template">- Template contents</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="team">- Team ID or team name</param>
    abstract createTemplate: template: WorkItemTracking.WorkItemTemplate * project: string * team: string -> Promise<WorkItemTracking.WorkItemTemplate>
    /// <summary>Gets template</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="team">- Team ID or team name</param>
    /// <param name="workitemtypename">- Optional, When specified returns templates for given Work item type.</param>
    abstract getTemplates: project: string * team: string * ?workitemtypename: string -> Promise<ResizeArray<WorkItemTracking.WorkItemTemplateReference>>
    /// <summary>Deletes the template with given id</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="team">- Team ID or team name</param>
    /// <param name="templateId">- Template id</param>
    abstract deleteTemplate: project: string * team: string * templateId: string -> Promise<unit>
    /// <summary>Gets the template with specified id</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="team">- Team ID or team name</param>
    /// <param name="templateId">- Template Id</param>
    abstract getTemplate: project: string * team: string * templateId: string -> Promise<WorkItemTracking.WorkItemTemplate>
    /// <summary>Replace template contents</summary>
    /// <param name="templateContent">- Template contents to replace with</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="team">- Team ID or team name</param>
    /// <param name="templateId">- Template id</param>
    abstract replaceTemplate: templateContent: WorkItemTracking.WorkItemTemplate * project: string * team: string * templateId: string -> Promise<WorkItemTracking.WorkItemTemplate>
    /// <summary>Returns a single update for a work item</summary>
    /// <param name="id">-</param>
    /// <param name="updateNumber">-</param>
    /// <param name="project">- Project ID or project name</param>
    abstract getUpdate: id: int * updateNumber: int * ?project: string -> Promise<WorkItemTracking.WorkItemUpdate>
    /// <summary>Returns a the deltas between work item revisions</summary>
    /// <param name="id">-</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="top">-</param>
    /// <param name="skip">-</param>
    abstract getUpdates: id: int * ?project: string * ?top: int * ?skip: int -> Promise<ResizeArray<WorkItemTracking.WorkItemUpdate>>
    /// <summary>Gets the results of the query given its WIQL.</summary>
    /// <param name="wiql">- The query containing the WIQL.</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="team">- Team ID or team name</param>
    /// <param name="timePrecision">- Whether or not to use time precision.</param>
    /// <param name="top">- The max number of results to return.</param>
    abstract queryByWiql: wiql: WorkItemTracking.Wiql * ?project: string * ?team: string * ?timePrecision: bool * ?top: int -> Promise<WorkItemTracking.WorkItemQueryResult>
    /// <summary>Gets the results of the query given the query ID.</summary>
    /// <param name="id">- The query ID.</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="team">- Team ID or team name</param>
    /// <param name="timePrecision">- Whether or not to use time precision.</param>
    /// <param name="top">- The max number of results to return.</param>
    abstract getQueryResultCount: id: string * ?project: string * ?team: string * ?timePrecision: bool * ?top: int -> Promise<float>
    /// <summary>Gets the results of the query given the query ID.</summary>
    /// <param name="id">- The query ID.</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="team">- Team ID or team name</param>
    /// <param name="timePrecision">- Whether or not to use time precision.</param>
    /// <param name="top">- The max number of results to return.</param>
    abstract queryById: id: string * ?project: string * ?team: string * ?timePrecision: bool * ?top: int -> Promise<WorkItemTracking.WorkItemQueryResult>
    /// <summary>Get a work item icon given the friendly name and icon color.</summary>
    /// <param name="icon">- The name of the icon</param>
    /// <param name="color">- The 6-digit hex color for the icon</param>
    /// <param name="v">- The version of the icon (used only for cache invalidation)</param>
    abstract getWorkItemIconJson: icon: string * ?color: string * ?v: int -> Promise<WorkItemTracking.WorkItemIcon>
    /// Get a list of all work item icons.
    abstract getWorkItemIcons: unit -> Promise<ResizeArray<WorkItemTracking.WorkItemIcon>>
    /// <summary>Get a work item icon given the friendly name and icon color.</summary>
    /// <param name="icon">- The name of the icon</param>
    /// <param name="color">- The 6-digit hex color for the icon</param>
    /// <param name="v">- The version of the icon (used only for cache invalidation)</param>
    abstract getWorkItemIconSvg: icon: string * ?color: string * ?v: int -> Promise<obj option>
    /// <summary>Get a work item icon given the friendly name and icon color.</summary>
    /// <param name="icon">- The name of the icon</param>
    /// <param name="color">- The 6-digit hex color for the icon</param>
    /// <param name="v">- The version of the icon (used only for cache invalidation)</param>
    abstract getWorkItemIconXaml: icon: string * ?color: string * ?v: int -> Promise<obj option>
    /// <summary>Get a batch of work item links</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="linkTypes">- A list of types to filter the results to specific link types. Omit this parameter to get work item links of all link types.</param>
    /// <param name="types">- A list of types to filter the results to specific work item types. Omit this parameter to get work item links of all work item types.</param>
    /// <param name="continuationToken">- Specifies the continuationToken to start the batch from. Omit this parameter to get the first batch of links.</param>
    /// <param name="startDateTime">- Date/time to use as a starting point for link changes. Only link changes that occurred after that date/time will be returned. Cannot be used in conjunction with 'watermark' parameter.</param>
    abstract getReportingLinksByLinkType: ?project: string * ?linkTypes: ResizeArray<string> * ?types: ResizeArray<string> * ?continuationToken: string * ?startDateTime: DateTime -> Promise<WorkItemTracking.ReportingWorkItemLinksBatch>
    /// <summary>Gets the work item relation type definition.</summary>
    /// <param name="relation">- The relation name</param>
    abstract getRelationType: relation: string -> Promise<WorkItemTracking.WorkItemRelationType>
    /// Gets the work item relation types.
    abstract getRelationTypes: unit -> Promise<ResizeArray<WorkItemTracking.WorkItemRelationType>>
    /// <summary>Get a batch of work item revisions with the option of including deleted items</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="fields">- A list of fields to return in work item revisions. Omit this parameter to get all reportable fields.</param>
    /// <param name="types">- A list of types to filter the results to specific work item types. Omit this parameter to get work item revisions of all work item types.</param>
    /// <param name="continuationToken">- Specifies the watermark to start the batch from. Omit this parameter to get the first batch of revisions.</param>
    /// <param name="startDateTime">- Date/time to use as a starting point for revisions, all revisions will occur after this date/time. Cannot be used in conjunction with 'watermark' parameter.</param>
    /// <param name="includeIdentityRef">- Return an identity reference instead of a string value for identity fields.</param>
    /// <param name="includeDeleted">- Specify if the deleted item should be returned.</param>
    /// <param name="includeTagRef">- Specify if the tag objects should be returned for System.Tags field.</param>
    /// <param name="includeLatestOnly">- Return only the latest revisions of work items, skipping all historical revisions</param>
    /// <param name="expand">- Return all the fields in work item revisions, including long text fields which are not returned by default</param>
    /// <param name="includeDiscussionChangesOnly">- Return only the those revisions of work items, where only history field was changed</param>
    /// <param name="maxPageSize">- The maximum number of results to return in this batch</param>
    abstract readReportingRevisionsGet: ?project: string * ?fields: ResizeArray<string> * ?types: ResizeArray<string> * ?continuationToken: string * ?startDateTime: DateTime * ?includeIdentityRef: bool * ?includeDeleted: bool * ?includeTagRef: bool * ?includeLatestOnly: bool * ?expand: WorkItemTracking.ReportingRevisionsExpand * ?includeDiscussionChangesOnly: bool * ?maxPageSize: int -> Promise<WorkItemTracking.ReportingWorkItemRevisionsBatch>
    /// <summary>Get a batch of work item revisions. This request may be used if your list of fields is large enough that it may run the URL over the length limit.</summary>
    /// <param name="filter">- An object that contains request settings: field filter, type filter, identity format</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="continuationToken">- Specifies the watermark to start the batch from. Omit this parameter to get the first batch of revisions.</param>
    /// <param name="startDateTime">- Date/time to use as a starting point for revisions, all revisions will occur after this date/time. Cannot be used in conjunction with 'watermark' parameter.</param>
    /// <param name="expand">-</param>
    abstract readReportingRevisionsPost: filter: WorkItemTracking.ReportingWorkItemRevisionsFilter * ?project: string * ?continuationToken: string * ?startDateTime: DateTime * ?expand: WorkItemTracking.ReportingRevisionsExpand -> Promise<WorkItemTracking.ReportingWorkItemRevisionsBatch>
    /// <summary>Creates a single work item.</summary>
    /// <param name="document">- The JSON Patch document representing the work item</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="type">- The work item type of the work item to create</param>
    /// <param name="validateOnly">- Indicate if you only want to validate the changes without saving the work item</param>
    /// <param name="bypassRules">- Do not enforce the work item type rules on this update</param>
    /// <param name="suppressNotifications">- Do not fire any notifications for this change</param>
    /// <param name="expand">- The expand parameters for work item attributes. Possible options are \{ None, Relations, Fields, Links, All \}.</param>
    abstract createWorkItem: document: WebApi.JsonPatchDocument * project: string * ``type``: string * ?validateOnly: bool * ?bypassRules: bool * ?suppressNotifications: bool * ?expand: WorkItemTracking.WorkItemExpand -> Promise<WorkItemTracking.WorkItem>
    /// <summary>Returns a single work item from a template.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="type">- The work item type name</param>
    /// <param name="fields">- Comma-separated list of requested fields</param>
    /// <param name="asOf">- AsOf UTC date time string</param>
    /// <param name="expand">- The expand parameters for work item attributes. Possible options are \{ None, Relations, Fields, Links, All \}.</param>
    abstract getWorkItemTemplate: project: string * ``type``: string * ?fields: string * ?asOf: DateTime * ?expand: WorkItemTracking.WorkItemExpand -> Promise<WorkItemTracking.WorkItem>
    /// <summary>Deletes the specified work item and sends it to the Recycle Bin, so that it can be restored back, if required. Optionally, if the destroy parameter has been set to true, it destroys the work item permanently. WARNING: If the destroy parameter is set to true, work items deleted by this command will NOT go to recycle-bin and there is no way to restore/recover them after deletion. It is recommended NOT to use this parameter. If you do, please use this parameter with extreme caution.</summary>
    /// <param name="id">- ID of the work item to be deleted</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="destroy">- Optional parameter, if set to true, the work item is deleted permanently. Please note: the destroy action is PERMANENT and cannot be undone.</param>
    abstract deleteWorkItem: id: int * ?project: string * ?destroy: bool -> Promise<WorkItemTracking.WorkItemDelete>
    /// <summary>Returns a single work item.</summary>
    /// <param name="id">- The work item id</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="fields">- Comma-separated list of requested fields</param>
    /// <param name="asOf">- AsOf UTC date time string</param>
    /// <param name="expand">- The expand parameters for work item attributes. Possible options are \{ None, Relations, Fields, Links, All \}.</param>
    abstract getWorkItem: id: int * ?project: string * ?fields: ResizeArray<string> * ?asOf: DateTime * ?expand: WorkItemTracking.WorkItemExpand -> Promise<WorkItemTracking.WorkItem>
    /// <summary>Returns a list of work items (Maximum 200)</summary>
    /// <param name="ids">- The comma-separated list of requested work item ids. (Maximum 200 ids allowed).</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="fields">- Comma-separated list of requested fields</param>
    /// <param name="asOf">- AsOf UTC date time string</param>
    /// <param name="expand">- The expand parameters for work item attributes. Possible options are \{ None, Relations, Fields, Links, All \}.</param>
    /// <param name="errorPolicy">- The flag to control error policy in a bulk get work items request. Possible options are \{Fail, Omit\}.</param>
    abstract getWorkItems: ids: ResizeArray<int> * ?project: string * ?fields: ResizeArray<string> * ?asOf: DateTime * ?expand: WorkItemTracking.WorkItemExpand * ?errorPolicy: WorkItemTracking.WorkItemErrorPolicy -> Promise<ResizeArray<WorkItemTracking.WorkItem>>
    /// <summary>Updates a single work item.</summary>
    /// <param name="document">- The JSON Patch document representing the update</param>
    /// <param name="id">- The id of the work item to update</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="validateOnly">- Indicate if you only want to validate the changes without saving the work item</param>
    /// <param name="bypassRules">- Do not enforce the work item type rules on this update</param>
    /// <param name="suppressNotifications">- Do not fire any notifications for this change</param>
    /// <param name="expand">- The expand parameters for work item attributes. Possible options are \{ None, Relations, Fields, Links, All \}.</param>
    abstract updateWorkItem: document: WebApi.JsonPatchDocument * id: int * ?project: string * ?validateOnly: bool * ?bypassRules: bool * ?suppressNotifications: bool * ?expand: WorkItemTracking.WorkItemExpand -> Promise<WorkItemTracking.WorkItem>
    /// <summary>Gets work items for a list of work item ids (Maximum 200)</summary>
    /// <param name="workItemGetRequest">-</param>
    /// <param name="project">- Project ID or project name</param>
    abstract getWorkItemsBatch: workItemGetRequest: WorkItemTracking.WorkItemBatchGetRequest * ?project: string -> Promise<ResizeArray<WorkItemTracking.WorkItem>>
    /// <summary>INTERNAL ONLY: It will be used for My account work experience. Get the work item type state color for multiple projects</summary>
    /// <param name="projectNames">-</param>
    abstract getWorkItemStateColors: projectNames: ResizeArray<string> -> Promise<ResizeArray<WorkItemTracking.ProjectWorkItemStateColors>>
    /// <summary>Returns the next state on the given work item IDs.</summary>
    /// <param name="ids">- list of work item ids</param>
    /// <param name="action">- possible actions. Currently only supports checkin</param>
    abstract getWorkItemNextStatesOnCheckinAction: ids: ResizeArray<float> * ?action: string -> Promise<ResizeArray<WorkItemTracking.WorkItemNextStateOnTransition>>
    /// <summary>Get all work item type categories.</summary>
    /// <param name="project">- Project ID or project name</param>
    abstract getWorkItemTypeCategories: project: string -> Promise<ResizeArray<WorkItemTracking.WorkItemTypeCategory>>
    /// <summary>Get specific work item type category by name.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="category">- The category name</param>
    abstract getWorkItemTypeCategory: project: string * category: string -> Promise<WorkItemTracking.WorkItemTypeCategory>
    /// <summary>INTERNAL ONLY: It will be used for My account work experience. Get the wit type color for multiple projects</summary>
    /// <param name="projectNames">-</param>
    abstract getWorkItemTypeColors: projectNames: ResizeArray<string> -> Promise<ResizeArray<WorkItemTrackingRestClientGetWorkItemTypeColorsPromise>>
    /// <summary>INTERNAL ONLY: It is used for color and icon providers. Get the wit type color for multiple projects</summary>
    /// <param name="projectNames">-</param>
    abstract getWorkItemTypeColorAndIcons: projectNames: ResizeArray<string> -> Promise<ResizeArray<WorkItemTrackingRestClientGetWorkItemTypeColorAndIconsPromise>>
    /// <summary>Returns a work item type definition.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="type">- Work item type name</param>
    abstract getWorkItemType: project: string * ``type``: string -> Promise<WorkItemTracking.WorkItemType>
    /// <summary>Returns the list of work item types</summary>
    /// <param name="project">- Project ID or project name</param>
    abstract getWorkItemTypes: project: string -> Promise<ResizeArray<WorkItemTracking.WorkItemType>>
    /// <summary>Get a list of fields for a work item type with detailed references.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="type">- Work item type.</param>
    /// <param name="expand">- Expand level for the API response. Properties: to include allowedvalues, default value, isRequired etc. as a part of response; None: to skip these properties.</param>
    abstract getWorkItemTypeFieldsWithReferences: project: string * ``type``: string * ?expand: WorkItemTracking.WorkItemTypeFieldsExpandLevel -> Promise<ResizeArray<WorkItemTracking.WorkItemTypeFieldWithReferences>>
    /// <summary>Get a field for a work item type with detailed references.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="type">- Work item type.</param>
    /// <param name="field">-</param>
    /// <param name="expand">- Expand level for the API response. Properties: to include allowedvalues, default value, isRequired etc. as a part of response; None: to skip these properties.</param>
    abstract getWorkItemTypeFieldWithReferences: project: string * ``type``: string * field: string * ?expand: WorkItemTracking.WorkItemTypeFieldsExpandLevel -> Promise<WorkItemTracking.WorkItemTypeFieldWithReferences>
    /// <summary>Returns the state names and colors for a work item type.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="type">- The state name</param>
    abstract getWorkItemTypeStates: project: string * ``type``: string -> Promise<ResizeArray<WorkItemTracking.WorkItemStateColor>>
    /// <summary>Export work item type</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="type">-</param>
    /// <param name="exportGlobalLists">-</param>
    abstract exportWorkItemTypeDefinition: ?project: string * ?``type``: string * ?exportGlobalLists: bool -> Promise<WorkItemTracking.WorkItemTypeTemplate>
    /// <summary>Add/updates a work item type</summary>
    /// <param name="updateModel">-</param>
    /// <param name="project">- Project ID or project name</param>
    abstract updateWorkItemTypeDefinition: updateModel: WorkItemTracking.WorkItemTypeTemplateUpdateModel * ?project: string -> Promise<WorkItemTracking.ProvisioningResult>

type [<AllowNullLiteral>] WorkItemTrackingRestClientStatic =
    [<Emit "new $0($1...)">] abstract Create: options: IVssRestClientOptions -> WorkItemTrackingRestClient
    abstract RESOURCE_AREA_ID: string

type [<AllowNullLiteral>] WorkItemTrackingRestClientGetWorkItemTypeColorsPromise =
    abstract key: string with get, set
    abstract value: ResizeArray<WorkItemTracking.WorkItemTypeColor> with get, set

type [<AllowNullLiteral>] WorkItemTrackingRestClientGetWorkItemTypeColorAndIconsPromise =
    abstract key: string with get, set
    abstract value: ResizeArray<WorkItemTracking.WorkItemTypeColorAndIcon> with get, set

[<ImportAll("azure-devops-extension-api/WorkItemTracking/WorkItemTrackingClient")>]
let exports: IExports = jsNative