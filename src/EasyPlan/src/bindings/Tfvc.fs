// ts2fable 0.7.1
module rec Tfvc
open System
open Fable.Core
open Fable.Core.JS


module Tfvc =
    module TfsCore = ___Core_Core
    module WebApi = ___WebApi_WebApi

    type [<AllowNullLiteral>] AssociatedWorkItem =
        abstract assignedTo: string with get, set
        /// Id of associated the work item.
        abstract id: float with get, set
        abstract state: string with get, set
        abstract title: string with get, set
        /// REST Url of the work item.
        abstract url: string with get, set
        abstract webUrl: string with get, set
        abstract workItemType: string with get, set

    type [<AllowNullLiteral>] Change<'T> =
        /// The type of change that was made to the item.
        abstract changeType: VersionControlChangeType with get, set
        /// Current version.
        abstract item: 'T with get, set
        /// Content of the item after the change.
        abstract newContent: ItemContent with get, set
        /// Path of the item on the server.
        abstract sourceServerItem: string with get, set
        /// URL to retrieve the item.
        abstract url: string with get, set

    type [<AllowNullLiteral>] CheckinNote =
        abstract name: string with get, set
        abstract value: string with get, set

    type [<AllowNullLiteral>] FileContentMetadata =
        abstract contentType: string with get, set
        abstract encoding: float with get, set
        abstract extension: string with get, set
        abstract fileName: string with get, set
        abstract isBinary: bool with get, set
        abstract isImage: bool with get, set
        abstract vsLink: string with get, set

    type [<AllowNullLiteral>] GitRepository =
        abstract _links: obj option with get, set
        abstract defaultBranch: string with get, set
        abstract id: string with get, set
        /// True if the repository was created as a fork
        abstract isFork: bool with get, set
        abstract name: string with get, set
        abstract parentRepository: GitRepositoryRef with get, set
        abstract project: TfsCore.TeamProjectReference with get, set
        abstract remoteUrl: string with get, set
        /// Compressed size (bytes) of the repository.
        abstract size: float with get, set
        abstract sshUrl: string with get, set
        abstract url: string with get, set
        abstract validRemoteUrls: ResizeArray<string> with get, set
        abstract webUrl: string with get, set

    type [<AllowNullLiteral>] GitRepositoryRef =
        /// Team Project Collection where this Fork resides
        abstract collection: TfsCore.TeamProjectCollectionReference with get, set
        abstract id: string with get, set
        /// True if the repository was created as a fork
        abstract isFork: bool with get, set
        abstract name: string with get, set
        abstract project: TfsCore.TeamProjectReference with get, set
        abstract remoteUrl: string with get, set
        abstract sshUrl: string with get, set
        abstract url: string with get, set

    type [<AllowNullLiteral>] ItemContent =
        abstract content: string with get, set
        abstract contentType: ItemContentType with get, set

    type [<RequireQualifiedAccess>] ItemContentType =
        | RawText = 0
        | Base64Encoded = 1

    type [<AllowNullLiteral>] ItemModel =
        abstract _links: obj option with get, set
        abstract content: string with get, set
        abstract contentMetadata: FileContentMetadata with get, set
        abstract isFolder: bool with get, set
        abstract isSymLink: bool with get, set
        abstract path: string with get, set
        abstract url: string with get, set

    /// Class representing a branch object.
    type [<AllowNullLiteral>] TfvcBranch =
        inherit TfvcBranchRef
        /// List of children for the branch.
        abstract children: ResizeArray<TfvcBranch> with get, set
        /// List of branch mappings.
        abstract mappings: ResizeArray<TfvcBranchMapping> with get, set
        /// Path of the branch's parent.
        abstract parent: TfvcShallowBranchRef with get, set
        /// List of paths of the related branches.
        abstract relatedBranches: ResizeArray<TfvcShallowBranchRef> with get, set

    /// A branch mapping.
    type [<AllowNullLiteral>] TfvcBranchMapping =
        /// Depth of the branch.
        abstract depth: string with get, set
        /// Server item for the branch.
        abstract serverItem: string with get, set
        /// Type of the branch.
        abstract ``type``: string with get, set

    /// Metadata for a branchref.
    type [<AllowNullLiteral>] TfvcBranchRef =
        inherit TfvcShallowBranchRef
        /// A collection of REST reference links.
        abstract _links: obj option with get, set
        /// Creation date of the branch.
        abstract createdDate: DateTime with get, set
        /// Branch description.
        abstract description: string with get, set
        /// Is the branch deleted?
        abstract isDeleted: bool with get, set
        /// Alias or display name of user
        abstract owner: WebApi.IdentityRef with get, set
        /// URL to retrieve the item.
        abstract url: string with get, set

    /// A change.
    type [<AllowNullLiteral>] TfvcChange =
        inherit Change<TfvcItem>
        /// List of merge sources in case of rename or branch creation.
        abstract mergeSources: ResizeArray<TfvcMergeSource> with get, set
        /// Version at which a (shelved) change was pended against
        abstract pendingVersion: float with get, set

    /// A collection of changes.
    type [<AllowNullLiteral>] TfvcChangeset =
        inherit TfvcChangesetRef
        /// Changeset Account Id also known as Organization Id.
        abstract accountId: string with get, set
        /// List of associated changes.
        abstract changes: ResizeArray<TfvcChange> with get, set
        /// List of Checkin Notes for the changeset.
        abstract checkinNotes: ResizeArray<CheckinNote> with get, set
        /// Changeset collection Id.
        abstract collectionId: string with get, set
        /// True if more changes are available.
        abstract hasMoreChanges: bool with get, set
        /// Policy Override for the changeset.
        abstract policyOverride: TfvcPolicyOverrideInfo with get, set
        /// Team Project Ids for the changeset.
        abstract teamProjectIds: ResizeArray<string> with get, set
        /// List of work items associated with the changeset.
        abstract workItems: ResizeArray<AssociatedWorkItem> with get, set

    /// Metadata for a changeset.
    type [<AllowNullLiteral>] TfvcChangesetRef =
        /// A collection of REST reference links.
        abstract _links: obj option with get, set
        /// Alias or display name of user.
        abstract author: WebApi.IdentityRef with get, set
        /// Changeset Id.
        abstract changesetId: float with get, set
        /// Alias or display name of user.
        abstract checkedInBy: WebApi.IdentityRef with get, set
        /// Comment for the changeset.
        abstract comment: string with get, set
        /// Was the Comment result truncated?
        abstract commentTruncated: bool with get, set
        /// Creation date of the changeset.
        abstract createdDate: DateTime with get, set
        /// URL to retrieve the item.
        abstract url: string with get, set

    /// Criteria used in a search for change lists.
    type [<AllowNullLiteral>] TfvcChangesetSearchCriteria =
        /// Alias or display name of user who made the changes.
        abstract author: string with get, set
        /// Whether or not to follow renames for the given item being queried.
        abstract followRenames: bool with get, set
        /// If provided, only include changesets created after this date (string).
        abstract fromDate: string with get, set
        /// If provided, only include changesets after this changesetID.
        abstract fromId: float with get, set
        /// Whether to include the _links field on the shallow references.
        abstract includeLinks: bool with get, set
        /// Path of item to search under.
        abstract itemPath: string with get, set
        abstract mappings: ResizeArray<TfvcMappingFilter> with get, set
        /// If provided, only include changesets created before this date (string).
        abstract toDate: string with get, set
        /// If provided, a version descriptor for the latest change list to include.
        abstract toId: float with get, set

    /// Request body for Get batched changesets.
    type [<AllowNullLiteral>] TfvcChangesetsRequestData =
        /// List of changeset Ids.
        abstract changesetIds: ResizeArray<float> with get, set
        /// Max length of the comment.
        abstract commentLength: float with get, set
        /// Whether to include the _links field on the shallow references
        abstract includeLinks: bool with get, set

    /// Metadata for an item.
    type [<AllowNullLiteral>] TfvcItem =
        inherit ItemModel
        /// Item changed datetime.
        abstract changeDate: DateTime with get, set
        /// Greater than 0 if item is deleted.
        abstract deletionId: float with get, set
        /// File encoding from database, -1 represents binary.
        abstract encoding: float with get, set
        /// MD5 hash as a base 64 string, applies to files only.
        abstract hashValue: string with get, set
        /// True if item is a branch.
        abstract isBranch: bool with get, set
        /// True if there is a change pending.
        abstract isPendingChange: bool with get, set
        /// The size of the file, if applicable.
        abstract size: float with get, set
        /// Changeset version Id.
        abstract version: float with get, set

    /// Item path and Version descriptor properties
    type [<AllowNullLiteral>] TfvcItemDescriptor =
        /// Item path.
        abstract path: string with get, set
        /// Defaults to OneLevel.
        abstract recursionLevel: VersionControlRecursionType with get, set
        /// Specify the desired version, can be null or empty string only if VersionType is latest or tip.
        abstract version: string with get, set
        /// Defaults to None.
        abstract versionOption: TfvcVersionOption with get, set
        /// Defaults to Latest.
        abstract versionType: TfvcVersionType with get, set

    /// Request body used by Get Items Batch
    type [<AllowNullLiteral>] TfvcItemRequestData =
        /// If true, include metadata about the file type
        abstract includeContentMetadata: bool with get, set
        /// Whether to include the _links field on the shallow references
        abstract includeLinks: bool with get, set
        abstract itemDescriptors: ResizeArray<TfvcItemDescriptor> with get, set

    /// Metadata for a label.
    type [<AllowNullLiteral>] TfvcLabel =
        inherit TfvcLabelRef
        /// List of items.
        abstract items: ResizeArray<TfvcItem> with get, set

    /// Metadata for a Label.
    type [<AllowNullLiteral>] TfvcLabelRef =
        /// Collection of reference links.
        abstract _links: obj option with get, set
        /// Label description.
        abstract description: string with get, set
        /// Label Id.
        abstract id: float with get, set
        /// Label scope.
        abstract labelScope: string with get, set
        /// Last modified datetime for the label.
        abstract modifiedDate: DateTime with get, set
        /// Label name.
        abstract name: string with get, set
        /// Label owner.
        abstract owner: WebApi.IdentityRef with get, set
        /// Label Url.
        abstract url: string with get, set

    type [<AllowNullLiteral>] TfvcLabelRequestData =
        /// Whether to include the _links field on the shallow references
        abstract includeLinks: bool with get, set
        abstract itemLabelFilter: string with get, set
        abstract labelScope: string with get, set
        abstract maxItemCount: float with get, set
        abstract name: string with get, set
        abstract owner: string with get, set

    /// MappingFilter can be used to include or exclude specific paths.
    type [<AllowNullLiteral>] TfvcMappingFilter =
        /// True if ServerPath should be excluded.
        abstract exclude: bool with get, set
        /// Path to be included or excluded.
        abstract serverPath: string with get, set

    type [<AllowNullLiteral>] TfvcMergeSource =
        /// Indicates if this a rename source. If false, it is a merge source.
        abstract isRename: bool with get, set
        /// The server item of the merge source.
        abstract serverItem: string with get, set
        /// Start of the version range.
        abstract versionFrom: float with get, set
        /// End of the version range.
        abstract versionTo: float with get, set

    /// Policy failure information.
    type [<AllowNullLiteral>] TfvcPolicyFailureInfo =
        /// Policy failure message.
        abstract message: string with get, set
        /// Name of the policy that failed.
        abstract policyName: string with get, set

    /// Information on the policy override.
    type [<AllowNullLiteral>] TfvcPolicyOverrideInfo =
        /// Overidden policy comment.
        abstract comment: string with get, set
        /// Information on the failed policy that was overridden.
        abstract policyFailures: ResizeArray<TfvcPolicyFailureInfo> with get, set

    /// This is the shallow branchref class.
    type [<AllowNullLiteral>] TfvcShallowBranchRef =
        /// Path for the branch.
        abstract path: string with get, set

    /// Metadata for a shelveset.
    type [<AllowNullLiteral>] TfvcShelveset =
        inherit TfvcShelvesetRef
        /// List of changes.
        abstract changes: ResizeArray<TfvcChange> with get, set
        /// List of checkin notes.
        abstract notes: ResizeArray<CheckinNote> with get, set
        /// Policy override information if applicable.
        abstract policyOverride: TfvcPolicyOverrideInfo with get, set
        /// List of associated workitems.
        abstract workItems: ResizeArray<AssociatedWorkItem> with get, set

    /// Metadata for a shallow shelveset.
    type [<AllowNullLiteral>] TfvcShelvesetRef =
        /// List of reference links for the shelveset.
        abstract _links: obj option with get, set
        /// Shelveset comment.
        abstract comment: string with get, set
        /// Shelveset comment truncated as applicable.
        abstract commentTruncated: bool with get, set
        /// Shelveset create date.
        abstract createdDate: DateTime with get, set
        /// Shelveset Id.
        abstract id: string with get, set
        /// Shelveset name.
        abstract name: string with get, set
        /// Shelveset Owner.
        abstract owner: WebApi.IdentityRef with get, set
        /// Shelveset Url.
        abstract url: string with get, set

    type [<AllowNullLiteral>] TfvcShelvesetRequestData =
        /// Whether to include policyOverride and notes Only applies when requesting a single deep shelveset
        abstract includeDetails: bool with get, set
        /// Whether to include the _links field on the shallow references. Does not apply when requesting a single deep shelveset object. Links will always be included in the deep shelveset.
        abstract includeLinks: bool with get, set
        /// Whether to include workItems
        abstract includeWorkItems: bool with get, set
        /// Max number of changes to include
        abstract maxChangeCount: float with get, set
        /// Max length of comment
        abstract maxCommentLength: float with get, set
        /// Shelveset name
        abstract name: string with get, set
        /// Owner's ID. Could be a name or a guid.
        abstract owner: string with get, set

    type [<AllowNullLiteral>] TfvcStatistics =
        /// Id of the last changeset the stats are based on.
        abstract changesetId: float with get, set
        /// Count of files at the requested scope.
        abstract fileCountTotal: float with get, set

    /// Version descriptor properties.
    type [<AllowNullLiteral>] TfvcVersionDescriptor =
        /// Version object.
        abstract version: string with get, set
        abstract versionOption: TfvcVersionOption with get, set
        abstract versionType: TfvcVersionType with get, set

    type [<RequireQualifiedAccess>] TfvcVersionOption =
        | None = 0
        | Previous = 1
        | UseRename = 2

    type [<RequireQualifiedAccess>] TfvcVersionType =
        | None = 0
        | Changeset = 1
        | Shelveset = 2
        | Change = 3
        | Date = 4
        | Latest = 5
        | Tip = 6
        | MergeSource = 7

    type [<RequireQualifiedAccess>] VersionControlChangeType =
        | None = 0
        | Add = 1
        | Edit = 2
        | Encoding = 4
        | Rename = 8
        | Delete = 16
        | Undelete = 32
        | Branch = 64
        | Merge = 128
        | Lock = 256
        | Rollback = 512
        | SourceRename = 1024
        | TargetRename = 2048
        | Property = 4096
        | All = 8191

    type [<AllowNullLiteral>] VersionControlProjectInfo =
        abstract defaultSourceControlType: TfsCore.SourceControlTypes with get, set
        abstract project: TfsCore.TeamProjectReference with get, set
        abstract supportsGit: bool with get, set
        abstract supportsTFVC: bool with get, set

    type [<RequireQualifiedAccess>] VersionControlRecursionType =
        | None = 0
        | OneLevel = 1
        | OneLevelPlusNestedEmptyFolders = 4
        | Full = 120
