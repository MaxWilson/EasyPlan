// ts2fable 0.7.1
module rec TfvcClient
open System
open Fable.Core
open Fable.Core.JS

type IVssRestClientOptions = Context.IVssRestClientOptions
type RestClientBase = RestClientBase.RestClientBase

type [<AllowNullLiteral>] IExports =
    abstract TfvcRestClient: TfvcRestClientStatic

type [<AllowNullLiteral>] TfvcRestClient =
    inherit RestClientBase
    /// <summary>Get a single branch hierarchy at the given path with parents or children as specified.</summary>
    /// <param name="path">- Full path to the branch.  Default: $/ Examples: $/, $/MyProject, $/MyProject/SomeFolder.</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="includeParent">- Return the parent branch, if there is one. Default: False</param>
    /// <param name="includeChildren">- Return child branches, if there are any. Default: False</param>
    abstract getBranch: path: string * ?project: string * ?includeParent: bool * ?includeChildren: bool -> Promise<Tfvc.TfvcBranch>
    /// <summary>Get a collection of branch roots -- first-level children, branches with no parents.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="includeParent">- Return the parent branch, if there is one. Default: False</param>
    /// <param name="includeChildren">- Return the child branches for each root branch. Default: False</param>
    /// <param name="includeDeleted">- Return deleted branches. Default: False</param>
    /// <param name="includeLinks">- Return links. Default: False</param>
    abstract getBranches: ?project: string * ?includeParent: bool * ?includeChildren: bool * ?includeDeleted: bool * ?includeLinks: bool -> Promise<ResizeArray<Tfvc.TfvcBranch>>
    /// <summary>Get branch hierarchies below the specified scopePath</summary>
    /// <param name="scopePath">- Full path to the branch.  Default: $/ Examples: $/, $/MyProject, $/MyProject/SomeFolder.</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="includeDeleted">- Return deleted branches. Default: False</param>
    /// <param name="includeLinks">- Return links. Default: False</param>
    abstract getBranchRefs: scopePath: string * ?project: string * ?includeDeleted: bool * ?includeLinks: bool -> Promise<ResizeArray<Tfvc.TfvcBranchRef>>
    /// <summary>Retrieve Tfvc changes for a given changeset.</summary>
    /// <param name="id">- ID of the changeset. Default: null</param>
    /// <param name="skip">- Number of results to skip. Default: null</param>
    /// <param name="top">- The maximum number of results to return. Default: null</param>
    abstract getChangesetChanges: ?id: int * ?skip: int * ?top: int -> Promise<ResizeArray<Tfvc.TfvcChange>>
    /// <summary>Create a new changeset.</summary>
    /// <param name="changeset">-</param>
    /// <param name="project">- Project ID or project name</param>
    abstract createChangeset: changeset: Tfvc.TfvcChangeset * ?project: string -> Promise<Tfvc.TfvcChangesetRef>
    /// <summary>Retrieve a Tfvc Changeset</summary>
    /// <param name="id">- Changeset Id to retrieve.</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="maxChangeCount">- Number of changes to return (maximum 100 changes) Default: 0</param>
    /// <param name="includeDetails">- Include policy details and check-in notes in the response. Default: false</param>
    /// <param name="includeWorkItems">- Include workitems. Default: false</param>
    /// <param name="maxCommentLength">- Include details about associated work items in the response. Default: null</param>
    /// <param name="includeSourceRename">- Include renames.  Default: false</param>
    /// <param name="skip">- Number of results to skip. Default: null</param>
    /// <param name="top">- The maximum number of results to return. Default: null</param>
    /// <param name="orderby">- Results are sorted by ID in descending order by default. Use id asc to sort by ID in ascending order.</param>
    /// <param name="searchCriteria">- Following criteria available (.itemPath, .version, .versionType, .versionOption, .author, .fromId, .toId, .fromDate, .toDate) Default: null</param>
    abstract getChangeset: id: int * ?project: string * ?maxChangeCount: int * ?includeDetails: bool * ?includeWorkItems: bool * ?maxCommentLength: int * ?includeSourceRename: bool * ?skip: int * ?top: int * ?orderby: string * ?searchCriteria: Tfvc.TfvcChangesetSearchCriteria -> Promise<Tfvc.TfvcChangeset>
    /// <summary>Retrieve Tfvc Changesets</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="maxCommentLength">- Include details about associated work items in the response. Default: null</param>
    /// <param name="skip">- Number of results to skip. Default: null</param>
    /// <param name="top">- The maximum number of results to return. Default: null</param>
    /// <param name="orderby">- Results are sorted by ID in descending order by default. Use id asc to sort by ID in ascending order.</param>
    /// <param name="searchCriteria">- Following criteria available (.itemPath, .version, .versionType, .versionOption, .author, .fromId, .toId, .fromDate, .toDate) Default: null</param>
    abstract getChangesets: ?project: string * ?maxCommentLength: int * ?skip: int * ?top: int * ?orderby: string * ?searchCriteria: Tfvc.TfvcChangesetSearchCriteria -> Promise<ResizeArray<Tfvc.TfvcChangesetRef>>
    /// <summary>Returns changesets for a given list of changeset Ids.</summary>
    /// <param name="changesetsRequestData">- List of changeset IDs.</param>
    abstract getBatchedChangesets: changesetsRequestData: Tfvc.TfvcChangesetsRequestData -> Promise<ResizeArray<Tfvc.TfvcChangesetRef>>
    /// <summary>Retrieves the work items associated with a particular changeset.</summary>
    /// <param name="id">- ID of the changeset.</param>
    abstract getChangesetWorkItems: ?id: int -> Promise<ResizeArray<Tfvc.AssociatedWorkItem>>
    /// <summary>Post for retrieving a set of items given a list of paths or a long path. Allows for specifying the recursionLevel and version descriptors for each path.</summary>
    /// <param name="itemRequestData">-</param>
    /// <param name="project">- Project ID or project name</param>
    abstract getItemsBatch: itemRequestData: Tfvc.TfvcItemRequestData * ?project: string -> Promise<ResizeArray<ResizeArray<Tfvc.TfvcItem>>>
    /// <summary>Post for retrieving a set of items given a list of paths or a long path. Allows for specifying the recursionLevel and version descriptors for each path.</summary>
    /// <param name="itemRequestData">-</param>
    /// <param name="project">- Project ID or project name</param>
    abstract getItemsBatchZip: itemRequestData: Tfvc.TfvcItemRequestData * ?project: string -> Promise<ArrayBuffer>
    /// <summary>Get Item Metadata and/or Content for a single item. The download parameter is to indicate whether the content should be available as a download or just sent as a stream in the response. Doesn't apply to zipped content which is always returned as a download.</summary>
    /// <param name="path">- Version control path of an individual item to return.</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="fileName">- file name of item returned.</param>
    /// <param name="download">- If true, create a downloadable attachment.</param>
    /// <param name="scopePath">- Version control path of a folder to return multiple items.</param>
    /// <param name="recursionLevel">- None (just the item), or OneLevel (contents of a folder).</param>
    /// <param name="versionDescriptor">- Version descriptor.  Default is null.</param>
    /// <param name="includeContent">- Set to true to include item content when requesting json.  Default is false.</param>
    abstract getItem: path: string * ?project: string * ?fileName: string * ?download: bool * ?scopePath: string * ?recursionLevel: Tfvc.VersionControlRecursionType * ?versionDescriptor: Tfvc.TfvcVersionDescriptor * ?includeContent: bool -> Promise<Tfvc.TfvcItem>
    /// <summary>Get Item Metadata and/or Content for a single item. The download parameter is to indicate whether the content should be available as a download or just sent as a stream in the response. Doesn't apply to zipped content which is always returned as a download.</summary>
    /// <param name="path">- Version control path of an individual item to return.</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="fileName">- file name of item returned.</param>
    /// <param name="download">- If true, create a downloadable attachment.</param>
    /// <param name="scopePath">- Version control path of a folder to return multiple items.</param>
    /// <param name="recursionLevel">- None (just the item), or OneLevel (contents of a folder).</param>
    /// <param name="versionDescriptor">- Version descriptor.  Default is null.</param>
    /// <param name="includeContent">- Set to true to include item content when requesting json.  Default is false.</param>
    abstract getItemContent: path: string * ?project: string * ?fileName: string * ?download: bool * ?scopePath: string * ?recursionLevel: Tfvc.VersionControlRecursionType * ?versionDescriptor: Tfvc.TfvcVersionDescriptor * ?includeContent: bool -> Promise<ArrayBuffer>
    /// <summary>Get a list of Tfvc items</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="scopePath">- Version control path of a folder to return multiple items.</param>
    /// <param name="recursionLevel">- None (just the item), or OneLevel (contents of a folder).</param>
    /// <param name="includeLinks">- True to include links.</param>
    /// <param name="versionDescriptor">-</param>
    abstract getItems: ?project: string * ?scopePath: string * ?recursionLevel: Tfvc.VersionControlRecursionType * ?includeLinks: bool * ?versionDescriptor: Tfvc.TfvcVersionDescriptor -> Promise<ResizeArray<Tfvc.TfvcItem>>
    /// <summary>Get Item Metadata and/or Content for a single item. The download parameter is to indicate whether the content should be available as a download or just sent as a stream in the response. Doesn't apply to zipped content which is always returned as a download.</summary>
    /// <param name="path">- Version control path of an individual item to return.</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="fileName">- file name of item returned.</param>
    /// <param name="download">- If true, create a downloadable attachment.</param>
    /// <param name="scopePath">- Version control path of a folder to return multiple items.</param>
    /// <param name="recursionLevel">- None (just the item), or OneLevel (contents of a folder).</param>
    /// <param name="versionDescriptor">- Version descriptor.  Default is null.</param>
    /// <param name="includeContent">- Set to true to include item content when requesting json.  Default is false.</param>
    abstract getItemText: path: string * ?project: string * ?fileName: string * ?download: bool * ?scopePath: string * ?recursionLevel: Tfvc.VersionControlRecursionType * ?versionDescriptor: Tfvc.TfvcVersionDescriptor * ?includeContent: bool -> Promise<string>
    /// <summary>Get Item Metadata and/or Content for a single item. The download parameter is to indicate whether the content should be available as a download or just sent as a stream in the response. Doesn't apply to zipped content which is always returned as a download.</summary>
    /// <param name="path">- Version control path of an individual item to return.</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="fileName">- file name of item returned.</param>
    /// <param name="download">- If true, create a downloadable attachment.</param>
    /// <param name="scopePath">- Version control path of a folder to return multiple items.</param>
    /// <param name="recursionLevel">- None (just the item), or OneLevel (contents of a folder).</param>
    /// <param name="versionDescriptor">- Version descriptor.  Default is null.</param>
    /// <param name="includeContent">- Set to true to include item content when requesting json.  Default is false.</param>
    abstract getItemZip: path: string * ?project: string * ?fileName: string * ?download: bool * ?scopePath: string * ?recursionLevel: Tfvc.VersionControlRecursionType * ?versionDescriptor: Tfvc.TfvcVersionDescriptor * ?includeContent: bool -> Promise<ArrayBuffer>
    /// <summary>Get items under a label.</summary>
    /// <param name="labelId">- Unique identifier of label</param>
    /// <param name="top">- Max number of items to return</param>
    /// <param name="skip">- Number of items to skip</param>
    abstract getLabelItems: labelId: string * ?top: int * ?skip: int -> Promise<ResizeArray<Tfvc.TfvcItem>>
    /// <summary>Get a single deep label.</summary>
    /// <param name="labelId">- Unique identifier of label</param>
    /// <param name="requestData">- maxItemCount</param>
    /// <param name="project">- Project ID or project name</param>
    abstract getLabel: labelId: string * requestData: Tfvc.TfvcLabelRequestData * ?project: string -> Promise<Tfvc.TfvcLabel>
    /// <summary>Get a collection of shallow label references.</summary>
    /// <param name="requestData">- labelScope, name, owner, and itemLabelFilter</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="top">- Max number of labels to return</param>
    /// <param name="skip">- Number of labels to skip</param>
    abstract getLabels: requestData: Tfvc.TfvcLabelRequestData * ?project: string * ?top: int * ?skip: int -> Promise<ResizeArray<Tfvc.TfvcLabelRef>>
    /// <summary>Get changes included in a shelveset.</summary>
    /// <param name="shelvesetId">- Shelveset's unique ID</param>
    /// <param name="top">- Max number of changes to return</param>
    /// <param name="skip">- Number of changes to skip</param>
    abstract getShelvesetChanges: shelvesetId: string * ?top: int * ?skip: int -> Promise<ResizeArray<Tfvc.TfvcChange>>
    /// <summary>Get a single deep shelveset.</summary>
    /// <param name="shelvesetId">- Shelveset's unique ID</param>
    /// <param name="requestData">- includeDetails, includeWorkItems, maxChangeCount, and maxCommentLength</param>
    abstract getShelveset: shelvesetId: string * ?requestData: Tfvc.TfvcShelvesetRequestData -> Promise<Tfvc.TfvcShelveset>
    /// <summary>Return a collection of shallow shelveset references.</summary>
    /// <param name="requestData">- name, owner, and maxCommentLength</param>
    /// <param name="top">- Max number of shelvesets to return</param>
    /// <param name="skip">- Number of shelvesets to skip</param>
    abstract getShelvesets: ?requestData: Tfvc.TfvcShelvesetRequestData * ?top: int * ?skip: int -> Promise<ResizeArray<Tfvc.TfvcShelvesetRef>>
    /// <summary>Get work items associated with a shelveset.</summary>
    /// <param name="shelvesetId">- Shelveset's unique ID</param>
    abstract getShelvesetWorkItems: shelvesetId: string -> Promise<ResizeArray<Tfvc.AssociatedWorkItem>>
    /// <summary>Provides File Count and Uncompressed Bytes for a Collection/Project at a particular scope for TFVC.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="scopePath">- '$/' for collection, '$/project' for specific project</param>
    abstract getTfvcStatistics: ?project: string * ?scopePath: string -> Promise<Tfvc.TfvcStatistics>

type [<AllowNullLiteral>] TfvcRestClientStatic =
    [<Emit "new $0($1...)">] abstract Create: options: IVssRestClientOptions -> TfvcRestClient
    abstract RESOURCE_AREA_ID: string
