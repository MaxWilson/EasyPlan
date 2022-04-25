// ts2fable 0.7.1
module rec Git
open System
open Fable.Core
open Fable.Core.JS

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

type [<AllowNullLiteral>] AsyncGitOperationNotification =
    abstract operationId: float with get, set

type [<AllowNullLiteral>] AsyncRefOperationCommitLevelEventNotification =
    inherit AsyncGitOperationNotification
    abstract commitId: string with get, set

type [<AllowNullLiteral>] AsyncRefOperationCompletedNotification =
    inherit AsyncGitOperationNotification
    abstract newRefName: string with get, set

type [<AllowNullLiteral>] AsyncRefOperationConflictNotification =
    inherit AsyncRefOperationCommitLevelEventNotification

type [<AllowNullLiteral>] AsyncRefOperationGeneralFailureNotification =
    inherit AsyncGitOperationNotification

type [<AllowNullLiteral>] AsyncRefOperationProgressNotification =
    inherit AsyncRefOperationCommitLevelEventNotification
    abstract progress: float with get, set

type [<AllowNullLiteral>] AsyncRefOperationTimeoutNotification =
    inherit AsyncGitOperationNotification

/// Meta data for a file attached to an artifact.
type [<AllowNullLiteral>] Attachment =
    /// Links to other related objects.
    abstract _links: obj option with get, set
    /// The person that uploaded this attachment.
    abstract author: WebApi.IdentityRef with get, set
    /// Content hash of on-disk representation of file content. Its calculated by the server by using SHA1 hash function.
    abstract contentHash: string with get, set
    /// The time the attachment was uploaded.
    abstract createdDate: DateTime with get, set
    /// The description of the attachment.
    abstract description: string with get, set
    /// The display name of the attachment. Can't be null or empty.
    abstract displayName: string with get, set
    /// Id of the attachment.
    abstract id: float with get, set
    /// Extended properties.
    abstract properties: obj option with get, set
    /// The url to download the content of the attachment.
    abstract url: string with get, set

/// Real time event (SignalR) for an auto-complete update on a pull request
type [<AllowNullLiteral>] AutoCompleteUpdatedEvent =
    inherit RealTimePullRequestEvent

/// Real time event (SignalR) for a source/target branch update on a pull request
type [<AllowNullLiteral>] BranchUpdatedEvent =
    inherit RealTimePullRequestEvent
    /// If true, the source branch of the pull request was updated
    abstract isSourceUpdate: bool with get, set

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

type [<AllowNullLiteral>] ChangeCountDictionary =
    interface end

type [<AllowNullLiteral>] ChangeList<'T> =
    abstract allChangesIncluded: bool with get, set
    abstract changeCounts: ChangeListChangeCounts with get, set
    abstract changes: ResizeArray<Change<'T>> with get, set
    abstract comment: string with get, set
    abstract commentTruncated: bool with get, set
    abstract creationDate: DateTime with get, set
    abstract notes: ResizeArray<CheckinNote> with get, set
    abstract owner: string with get, set
    abstract ownerDisplayName: string with get, set
    abstract ownerId: string with get, set
    abstract sortDate: DateTime with get, set
    abstract version: string with get, set

/// Criteria used in a search for change lists
type [<AllowNullLiteral>] ChangeListSearchCriteria =
    /// If provided, a version descriptor to compare against base
    abstract compareVersion: string with get, set
    /// If true, don't include delete history entries
    abstract excludeDeletes: bool with get, set
    /// Whether or not to follow renames for the given item being queried
    abstract followRenames: bool with get, set
    /// If provided, only include history entries created after this date (string)
    abstract fromDate: string with get, set
    /// If provided, a version descriptor for the earliest change list to include
    abstract fromVersion: string with get, set
    /// Path of item to search under. If the itemPaths memebr is used then it will take precedence over this.
    abstract itemPath: string with get, set
    /// List of item paths to search under. If this member is used then itemPath will be ignored.
    abstract itemPaths: ResizeArray<string> with get, set
    /// Version of the items to search
    abstract itemVersion: string with get, set
    /// Number of results to skip (used when clicking more...)
    abstract skip: float with get, set
    /// If provided, only include history entries created before this date (string)
    abstract toDate: string with get, set
    /// If provided, the maximum number of history entries to return
    abstract top: float with get, set
    /// If provided, a version descriptor for the latest change list to include
    abstract toVersion: string with get, set
    /// Alias or display name of user who made the changes
    abstract user: string with get, set

type [<AllowNullLiteral>] CheckinNote =
    abstract name: string with get, set
    abstract value: string with get, set

/// Represents a comment which is one of potentially many in a comment thread.
type [<AllowNullLiteral>] Comment =
    /// Links to other related objects.
    abstract _links: obj option with get, set
    /// The author of the comment.
    abstract author: WebApi.IdentityRef with get, set
    /// The comment type at the time of creation.
    abstract commentType: CommentType with get, set
    /// The comment content.
    abstract content: string with get, set
    /// The comment ID. IDs start at 1 and are unique to a pull request.
    abstract id: float with get, set
    /// Whether or not this comment was soft-deleted.
    abstract isDeleted: bool with get, set
    /// The date the comment's content was last updated.
    abstract lastContentUpdatedDate: DateTime with get, set
    /// The date the comment was last updated.
    abstract lastUpdatedDate: DateTime with get, set
    /// The ID of the parent comment. This is used for replies.
    abstract parentCommentId: float with get, set
    /// The date the comment was first published.
    abstract publishedDate: DateTime with get, set
    /// A list of the users who have liked this comment.
    abstract usersLiked: ResizeArray<WebApi.IdentityRef> with get, set

/// Comment iteration context is used to identify which diff was being viewed when the thread was created.
type [<AllowNullLiteral>] CommentIterationContext =
    /// The iteration of the file on the left side of the diff when the thread was created. If this value is equal to SecondComparingIteration, then this version is the common commit between the source and target branches of the pull request.
    abstract firstComparingIteration: float with get, set
    /// The iteration of the file on the right side of the diff when the thread was created.
    abstract secondComparingIteration: float with get, set

type [<AllowNullLiteral>] CommentPosition =
    /// The line number of a thread's position. Starts at 1.
    abstract line: float with get, set
    /// The character offset of a thread's position inside of a line. Starts at 0.
    abstract offset: float with get, set

/// Represents a comment thread of a pull request. A thread contains meta data about the file it was left on along with one or more comments (an initial comment and the subsequent replies).
type [<AllowNullLiteral>] CommentThread =
    /// Links to other related objects.
    abstract _links: obj option with get, set
    /// A list of the comments.
    abstract comments: ResizeArray<Comment> with get, set
    /// The comment thread id.
    abstract id: float with get, set
    /// Set of identities related to this thread
    abstract identities: CommentThreadIdentities with get, set
    /// Specify if the thread is deleted which happens when all comments are deleted.
    abstract isDeleted: bool with get, set
    /// The time this thread was last updated.
    abstract lastUpdatedDate: DateTime with get, set
    /// Optional properties associated with the thread as a collection of key-value pairs.
    abstract properties: obj option with get, set
    /// The time this thread was published.
    abstract publishedDate: DateTime with get, set
    /// The status of the comment thread.
    abstract status: CommentThreadStatus with get, set
    /// Specify thread context such as position in left/right file.
    abstract threadContext: CommentThreadContext with get, set

type [<AllowNullLiteral>] CommentThreadContext =
    /// File path relative to the root of the repository. It's up to the client to use any path format.
    abstract filePath: string with get, set
    /// Position of last character of the thread's span in left file.
    abstract leftFileEnd: CommentPosition with get, set
    /// Position of first character of the thread's span in left file.
    abstract leftFileStart: CommentPosition with get, set
    /// Position of last character of the thread's span in right file.
    abstract rightFileEnd: CommentPosition with get, set
    /// Position of first character of the thread's span in right file.
    abstract rightFileStart: CommentPosition with get, set

type [<RequireQualifiedAccess>] CommentThreadStatus =
    | Unknown = 0
    | Active = 1
    | Fixed = 2
    | WontFix = 3
    | Closed = 4
    | ByDesign = 5
    | Pending = 6

/// Comment tracking criteria is used to identify which iteration context the thread has been tracked to (if any) along with some detail about the original position and filename.
type [<AllowNullLiteral>] CommentTrackingCriteria =
    /// The iteration of the file on the left side of the diff that the thread will be tracked to. Threads were tracked if this is greater than 0.
    abstract firstComparingIteration: float with get, set
    /// Original filepath the thread was created on before tracking. This will be different than the current thread filepath if the file in question was renamed in a later iteration.
    abstract origFilePath: string with get, set
    /// Original position of last character of the thread's span in left file.
    abstract origLeftFileEnd: CommentPosition with get, set
    /// Original position of first character of the thread's span in left file.
    abstract origLeftFileStart: CommentPosition with get, set
    /// Original position of last character of the thread's span in right file.
    abstract origRightFileEnd: CommentPosition with get, set
    /// Original position of first character of the thread's span in right file.
    abstract origRightFileStart: CommentPosition with get, set
    /// The iteration of the file on the right side of the diff that the thread will be tracked to. Threads were tracked if this is greater than 0.
    abstract secondComparingIteration: float with get, set

type [<RequireQualifiedAccess>] CommentType =
    | Unknown = 0
    | Text = 1
    | CodeChange = 2
    | System = 3

/// Real time event (SignalR) for a completion errors on a pull request
type [<AllowNullLiteral>] CompletionErrorsEvent =
    inherit RealTimePullRequestEvent
    /// The error message associated with the completion error
    abstract errorMessage: string with get, set

/// Real time event (SignalR) for a discussions update on a pull request
type [<AllowNullLiteral>] DiscussionsUpdatedEvent =
    inherit RealTimePullRequestEvent

type [<AllowNullLiteral>] FileContentMetadata =
    abstract contentType: string with get, set
    abstract encoding: float with get, set
    abstract extension: string with get, set
    abstract fileName: string with get, set
    abstract isBinary: bool with get, set
    abstract isImage: bool with get, set
    abstract vsLink: string with get, set

/// Provides properties that describe file differences
type [<AllowNullLiteral>] FileDiff =
    /// The collection of line diff blocks
    abstract lineDiffBlocks: ResizeArray<LineDiffBlock> with get, set
    /// Original path of item if different from current path.
    abstract originalPath: string with get, set
    /// Current path of item
    abstract path: string with get, set

/// Provides parameters that describe inputs for the file diff
type [<AllowNullLiteral>] FileDiffParams =
    /// Original path of the file
    abstract originalPath: string with get, set
    /// Current path of the file
    abstract path: string with get, set

/// Provides properties that describe inputs for the file diffs
type [<AllowNullLiteral>] FileDiffsCriteria =
    /// Commit ID of the base version
    abstract baseVersionCommit: string with get, set
    /// List of parameters for each of the files for which we need to get the file diff
    abstract fileDiffParams: ResizeArray<FileDiffParams> with get, set
    /// Commit ID of the target version
    abstract targetVersionCommit: string with get, set

/// A Git annotated tag.
type [<AllowNullLiteral>] GitAnnotatedTag =
    /// The tagging Message
    abstract message: string with get, set
    /// The name of the annotated tag.
    abstract name: string with get, set
    /// The objectId (Sha1Id) of the tag.
    abstract objectId: string with get, set
    /// User info and date of tagging.
    abstract taggedBy: GitUserDate with get, set
    /// Tagged git object.
    abstract taggedObject: GitObject with get, set
    abstract url: string with get, set

type [<RequireQualifiedAccess>] GitAsyncOperationStatus =
    | Queued = 1
    | InProgress = 2
    | Completed = 3
    | Failed = 4
    | Abandoned = 5

type [<AllowNullLiteral>] GitAsyncRefOperation =
    abstract _links: obj option with get, set
    abstract detailedStatus: GitAsyncRefOperationDetail with get, set
    abstract parameters: GitAsyncRefOperationParameters with get, set
    abstract status: GitAsyncOperationStatus with get, set
    /// A URL that can be used to make further requests for status about the operation
    abstract url: string with get, set

/// Information about the progress of a cherry pick or revert operation.
type [<AllowNullLiteral>] GitAsyncRefOperationDetail =
    /// Indicates if there was a conflict generated when trying to cherry pick or revert the changes.
    abstract conflict: bool with get, set
    /// The current commit from the list of commits that are being cherry picked or reverted.
    abstract currentCommitId: string with get, set
    /// Detailed information about why the cherry pick or revert failed to complete.
    abstract failureMessage: string with get, set
    /// A number between 0 and 1 indicating the percent complete of the operation.
    abstract progress: float with get, set
    /// Provides a status code that indicates the reason the cherry pick or revert failed.
    abstract status: GitAsyncRefOperationFailureStatus with get, set
    /// Indicates if the operation went beyond the maximum time allowed for a cherry pick or revert operation.
    abstract timedout: bool with get, set

type [<RequireQualifiedAccess>] GitAsyncRefOperationFailureStatus =
    | None = 0
    | InvalidRefName = 1
    | RefNameConflict = 2
    | CreateBranchPermissionRequired = 3
    | WritePermissionRequired = 4
    | TargetBranchDeleted = 5
    | GitObjectTooLarge = 6
    | OperationIndentityNotFound = 7
    | AsyncOperationNotFound = 8
    | Other = 9
    | EmptyCommitterSignature = 10

/// Parameters that are provided in the request body when requesting to cherry pick or revert.
type [<AllowNullLiteral>] GitAsyncRefOperationParameters =
    /// Proposed target branch name for the cherry pick or revert operation.
    abstract generatedRefName: string with get, set
    /// The target branch for the cherry pick or revert operation.
    abstract ontoRefName: string with get, set
    /// The git repository for the cherry pick or revert operation.
    abstract repository: GitRepository with get, set
    /// Details about the source of the cherry pick or revert operation (e.g. A pull request or a specific commit).
    abstract source: GitAsyncRefOperationSource with get, set

/// GitAsyncRefOperationSource specifies the pull request or list of commits to use when making a cherry pick and revert operation request. Only one should be provided.
type [<AllowNullLiteral>] GitAsyncRefOperationSource =
    /// A list of commits to cherry pick or revert
    abstract commitList: ResizeArray<GitCommitRef> with get, set
    /// Id of the pull request to cherry pick or revert
    abstract pullRequestId: float with get, set

type [<AllowNullLiteral>] GitBaseVersionDescriptor =
    inherit GitVersionDescriptor
    /// Version string identifier (name of tag/branch, SHA1 of commit)
    abstract baseVersion: string with get, set
    /// Version options - Specify additional modifiers to version (e.g Previous)
    abstract baseVersionOptions: GitVersionOptions with get, set
    /// Version type (branch, tag, or commit). Determines how Id is interpreted
    abstract baseVersionType: GitVersionType with get, set

type [<AllowNullLiteral>] GitBlobRef =
    abstract _links: obj option with get, set
    /// SHA1 hash of git object
    abstract objectId: string with get, set
    /// Size of blob content (in bytes)
    abstract size: float with get, set
    abstract url: string with get, set

/// Ahead and behind counts for a particular ref.
type [<AllowNullLiteral>] GitBranchStats =
    /// Number of commits ahead.
    abstract aheadCount: float with get, set
    /// Number of commits behind.
    abstract behindCount: float with get, set
    /// Current commit.
    abstract commit: GitCommitRef with get, set
    /// True if this is the result for the base version.
    abstract isBaseVersion: bool with get, set
    /// Name of the ref.
    abstract name: string with get, set

type [<AllowNullLiteral>] GitChange =
    inherit Change<GitItem>
    /// ID of the change within the group of changes.
    abstract changeId: float with get, set
    /// New Content template to be used when pushing new changes.
    abstract newContentTemplate: GitTemplate with get, set
    /// Original path of item if different from current path.
    abstract originalPath: string with get, set

/// This object is returned from Cherry Pick operations and provides the id and status of the operation
type [<AllowNullLiteral>] GitCherryPick =
    inherit GitAsyncRefOperation
    abstract cherryPickId: float with get, set

type [<AllowNullLiteral>] GitCommit =
    inherit GitCommitRef
    abstract treeId: string with get, set

type [<AllowNullLiteral>] GitCommitChanges =
    abstract changeCounts: ChangeCountDictionary with get, set
    abstract changes: ResizeArray<GitChange> with get, set

type [<AllowNullLiteral>] GitCommitDiffs =
    abstract aheadCount: float with get, set
    abstract allChangesIncluded: bool with get, set
    abstract baseCommit: string with get, set
    abstract behindCount: float with get, set
    abstract changeCounts: ChangeListChangeCounts with get, set
    abstract changes: ResizeArray<GitChange> with get, set
    abstract commonCommit: string with get, set
    abstract targetCommit: string with get, set

/// Provides properties that describe a Git commit and associated metadata.
type [<AllowNullLiteral>] GitCommitRef =
    /// A collection of related REST reference links.
    abstract _links: obj option with get, set
    /// Author of the commit.
    abstract author: GitUserDate with get, set
    /// Counts of the types of changes (edits, deletes, etc.) included with the commit.
    abstract changeCounts: ChangeCountDictionary with get, set
    /// An enumeration of the changes included with the commit.
    abstract changes: ResizeArray<GitChange> with get, set
    /// Comment or message of the commit.
    abstract comment: string with get, set
    /// Indicates if the comment is truncated from the full Git commit comment message.
    abstract commentTruncated: bool with get, set
    /// ID (SHA-1) of the commit.
    abstract commitId: string with get, set
    /// Committer of the commit.
    abstract committer: GitUserDate with get, set
    /// An enumeration of the parent commit IDs for this commit.
    abstract parents: ResizeArray<string> with get, set
    /// The push associated with this commit.
    abstract push: GitPushRef with get, set
    /// Remote URL path to the commit.
    abstract remoteUrl: string with get, set
    /// A list of status metadata from services and extensions that may associate additional information to the commit.
    abstract statuses: ResizeArray<GitStatus> with get, set
    /// REST URL for this resource.
    abstract url: string with get, set
    /// A list of workitems associated with this commit.
    abstract workItems: ResizeArray<WebApi.ResourceRef> with get, set

type [<AllowNullLiteral>] GitCommitToCreate =
    abstract baseRef: GitRef with get, set
    abstract comment: string with get, set
    abstract pathActions: ResizeArray<GitPathAction> with get, set

type [<AllowNullLiteral>] GitConflict =
    abstract _links: obj option with get, set
    abstract conflictId: float with get, set
    abstract conflictPath: string with get, set
    abstract conflictType: GitConflictType with get, set
    abstract mergeBaseCommit: GitCommitRef with get, set
    abstract mergeOrigin: GitMergeOriginRef with get, set
    abstract mergeSourceCommit: GitCommitRef with get, set
    abstract mergeTargetCommit: GitCommitRef with get, set
    abstract resolutionError: GitResolutionError with get, set
    abstract resolutionStatus: GitResolutionStatus with get, set
    abstract resolvedBy: WebApi.IdentityRef with get, set
    abstract resolvedDate: DateTime with get, set
    abstract url: string with get, set

/// Data object for AddAdd conflict
type [<AllowNullLiteral>] GitConflictAddAdd =
    inherit GitConflict
    abstract resolution: GitResolutionMergeContent with get, set
    abstract sourceBlob: GitBlobRef with get, set
    abstract targetBlob: GitBlobRef with get, set

/// Data object for RenameAdd conflict
type [<AllowNullLiteral>] GitConflictAddRename =
    inherit GitConflict
    abstract baseBlob: GitBlobRef with get, set
    abstract resolution: GitResolutionPathConflict with get, set
    abstract sourceBlob: GitBlobRef with get, set
    abstract targetBlob: GitBlobRef with get, set
    abstract targetOriginalPath: string with get, set

/// Data object for EditDelete conflict
type [<AllowNullLiteral>] GitConflictDeleteEdit =
    inherit GitConflict
    abstract baseBlob: GitBlobRef with get, set
    abstract resolution: GitResolutionPickOneAction with get, set
    abstract targetBlob: GitBlobRef with get, set

/// Data object for RenameDelete conflict
type [<AllowNullLiteral>] GitConflictDeleteRename =
    inherit GitConflict
    abstract baseBlob: GitBlobRef with get, set
    abstract resolution: GitResolutionPickOneAction with get, set
    abstract targetBlob: GitBlobRef with get, set
    abstract targetNewPath: string with get, set

/// Data object for FileDirectory conflict
type [<AllowNullLiteral>] GitConflictDirectoryFile =
    inherit GitConflict
    abstract resolution: GitResolutionPathConflict with get, set
    abstract sourceTree: GitTreeRef with get, set
    abstract targetBlob: GitBlobRef with get, set

/// Data object for DeleteEdit conflict
type [<AllowNullLiteral>] GitConflictEditDelete =
    inherit GitConflict
    abstract baseBlob: GitBlobRef with get, set
    abstract resolution: GitResolutionPickOneAction with get, set
    abstract sourceBlob: GitBlobRef with get, set

/// Data object for EditEdit conflict
type [<AllowNullLiteral>] GitConflictEditEdit =
    inherit GitConflict
    abstract baseBlob: GitBlobRef with get, set
    abstract resolution: GitResolutionMergeContent with get, set
    abstract sourceBlob: GitBlobRef with get, set
    abstract targetBlob: GitBlobRef with get, set

/// Data object for DirectoryFile conflict
type [<AllowNullLiteral>] GitConflictFileDirectory =
    inherit GitConflict
    abstract resolution: GitResolutionPathConflict with get, set
    abstract sourceBlob: GitBlobRef with get, set
    abstract targetTree: GitTreeRef with get, set

/// Data object for Rename1to2 conflict
type [<AllowNullLiteral>] GitConflictRename1to2 =
    inherit GitConflict
    abstract baseBlob: GitBlobRef with get, set
    abstract resolution: GitResolutionRename1to2 with get, set
    abstract sourceBlob: GitBlobRef with get, set
    abstract sourceNewPath: string with get, set
    abstract targetBlob: GitBlobRef with get, set
    abstract targetNewPath: string with get, set

/// Data object for Rename2to1 conflict
type [<AllowNullLiteral>] GitConflictRename2to1 =
    inherit GitConflict
    abstract resolution: GitResolutionPathConflict with get, set
    abstract sourceNewBlob: GitBlobRef with get, set
    abstract sourceOriginalBlob: GitBlobRef with get, set
    abstract sourceOriginalPath: string with get, set
    abstract targetNewBlob: GitBlobRef with get, set
    abstract targetOriginalBlob: GitBlobRef with get, set
    abstract targetOriginalPath: string with get, set

/// Data object for AddRename conflict
type [<AllowNullLiteral>] GitConflictRenameAdd =
    inherit GitConflict
    abstract baseBlob: GitBlobRef with get, set
    abstract resolution: GitResolutionPathConflict with get, set
    abstract sourceBlob: GitBlobRef with get, set
    abstract sourceOriginalPath: string with get, set
    abstract targetBlob: GitBlobRef with get, set

/// Data object for DeleteRename conflict
type [<AllowNullLiteral>] GitConflictRenameDelete =
    inherit GitConflict
    abstract baseBlob: GitBlobRef with get, set
    abstract resolution: GitResolutionPickOneAction with get, set
    abstract sourceBlob: GitBlobRef with get, set
    abstract sourceNewPath: string with get, set

/// Data object for RenameRename conflict
type [<AllowNullLiteral>] GitConflictRenameRename =
    inherit GitConflict
    abstract baseBlob: GitBlobRef with get, set
    abstract originalPath: string with get, set
    abstract resolution: GitResolutionMergeContent with get, set
    abstract sourceBlob: GitBlobRef with get, set
    abstract targetBlob: GitBlobRef with get, set

type [<RequireQualifiedAccess>] GitConflictType =
    | None = 0
    | AddAdd = 1
    | AddRename = 2
    | DeleteEdit = 3
    | DeleteRename = 4
    | DirectoryFile = 5
    | DirectoryChild = 6
    | EditDelete = 7
    | EditEdit = 8
    | FileDirectory = 9
    | Rename1to2 = 10
    | Rename2to1 = 11
    | RenameAdd = 12
    | RenameDelete = 13
    | RenameRename = 14

type [<AllowNullLiteral>] GitConflictUpdateResult =
    /// Conflict ID that was provided by input
    abstract conflictId: float with get, set
    /// Reason for failing
    abstract customMessage: string with get, set
    /// New state of the conflict after updating
    abstract updatedConflict: GitConflict with get, set
    /// Status of the update on the server
    abstract updateStatus: GitConflictUpdateStatus with get, set

type [<RequireQualifiedAccess>] GitConflictUpdateStatus =
    | Succeeded = 0
    | BadRequest = 1
    | InvalidResolution = 2
    | UnsupportedConflictType = 3
    | NotFound = 4

type [<AllowNullLiteral>] GitDeletedRepository =
    abstract createdDate: DateTime with get, set
    abstract deletedBy: WebApi.IdentityRef with get, set
    abstract deletedDate: DateTime with get, set
    abstract id: string with get, set
    abstract name: string with get, set
    abstract project: Core.TeamProjectReference with get, set

type [<AllowNullLiteral>] GitFilePathsCollection =
    abstract commitId: string with get, set
    abstract paths: ResizeArray<string> with get, set
    abstract url: string with get, set

/// Status information about a requested fork operation.
type [<AllowNullLiteral>] GitForkOperationStatusDetail =
    /// All valid steps for the forking process
    abstract allSteps: ResizeArray<string> with get, set
    /// Index into AllSteps for the current step
    abstract currentStep: float with get, set
    /// Error message if the operation failed.
    abstract errorMessage: string with get, set

/// Information about a fork ref.
type [<AllowNullLiteral>] GitForkRef =
    inherit GitRef
    /// The repository ID of the fork.
    abstract repository: GitRepository with get, set

/// Request to sync data between two forks.
type [<AllowNullLiteral>] GitForkSyncRequest =
    /// Collection of related links
    abstract _links: obj option with get, set
    abstract detailedStatus: GitForkOperationStatusDetail with get, set
    /// Unique identifier for the operation.
    abstract operationId: float with get, set
    /// Fully-qualified identifier for the source repository.
    abstract source: GlobalGitRepositoryKey with get, set
    /// If supplied, the set of ref mappings to use when performing a "sync" or create. If missing, all refs will be synchronized.
    abstract sourceToTargetRefs: ResizeArray<SourceToTargetRef> with get, set
    abstract status: GitAsyncOperationStatus with get, set

/// Parameters for creating a fork request
type [<AllowNullLiteral>] GitForkSyncRequestParameters =
    /// Fully-qualified identifier for the source repository.
    abstract source: GlobalGitRepositoryKey with get, set
    /// If supplied, the set of ref mappings to use when performing a "sync" or create. If missing, all refs will be synchronized.
    abstract sourceToTargetRefs: ResizeArray<SourceToTargetRef> with get, set

type [<AllowNullLiteral>] GitForkTeamProjectReference =
    inherit Core.TeamProjectReference

type [<RequireQualifiedAccess>] GitHistoryMode =
    | SimplifiedHistory = 0
    | FirstParent = 1
    | FullHistory = 2
    | FullHistorySimplifyMerges = 3

type [<AllowNullLiteral>] GitImportFailedEvent =
    abstract sourceRepositoryName: string with get, set
    abstract targetRepository: GitRepository with get, set

/// Parameter for creating a git import request when source is Git version control
type [<AllowNullLiteral>] GitImportGitSource =
    /// Tells if this is a sync request or not
    abstract overwrite: bool with get, set
    /// Url for the source repo
    abstract url: string with get, set

/// A request to import data from a remote source control system.
type [<AllowNullLiteral>] GitImportRequest =
    /// Links to related resources.
    abstract _links: obj option with get, set
    /// Detailed status of the import, including the current step and an error message, if applicable.
    abstract detailedStatus: GitImportStatusDetail with get, set
    /// The unique identifier for this import request.
    abstract importRequestId: float with get, set
    /// Parameters for creating the import request.
    abstract parameters: GitImportRequestParameters with get, set
    /// The target repository for this import.
    abstract repository: GitRepository with get, set
    /// Current status of the import.
    abstract status: GitAsyncOperationStatus with get, set
    /// A link back to this import request resource.
    abstract url: string with get, set

/// Parameters for creating an import request
type [<AllowNullLiteral>] GitImportRequestParameters =
    /// Option to delete service endpoint when import is done
    abstract deleteServiceEndpointAfterImportIsDone: bool with get, set
    /// Source for importing git repository
    abstract gitSource: GitImportGitSource with get, set
    /// Service Endpoint for connection to external endpoint
    abstract serviceEndpointId: string with get, set
    /// Source for importing tfvc repository
    abstract tfvcSource: GitImportTfvcSource with get, set

/// Additional status information about an import request.
type [<AllowNullLiteral>] GitImportStatusDetail =
    /// All valid steps for the import process
    abstract allSteps: ResizeArray<string> with get, set
    /// Index into AllSteps for the current step
    abstract currentStep: float with get, set
    /// Error message if the operation failed.
    abstract errorMessage: string with get, set

type [<AllowNullLiteral>] GitImportSucceededEvent =
    abstract sourceRepositoryName: string with get, set
    abstract targetRepository: GitRepository with get, set

/// Parameter for creating a git import request when source is tfvc version control
type [<AllowNullLiteral>] GitImportTfvcSource =
    /// Set true to import History, false otherwise
    abstract importHistory: bool with get, set
    /// Get history for last n days (max allowed value is 180 days)
    abstract importHistoryDurationInDays: float with get, set
    /// Path which we want to import (this can be copied from Path Control in Explorer)
    abstract path: string with get, set

type [<AllowNullLiteral>] GitItem =
    inherit ItemModel
    /// SHA1 of commit item was fetched at
    abstract commitId: string with get, set
    /// Type of object (Commit, Tree, Blob, Tag, ...)
    abstract gitObjectType: GitObjectType with get, set
    /// Shallow ref to commit that last changed this item Only populated if latestProcessedChange is requested May not be accurate if latest change is not yet cached
    abstract latestProcessedChange: GitCommitRef with get, set
    /// Git object id
    abstract objectId: string with get, set
    /// Git object id
    abstract originalObjectId: string with get, set

type [<AllowNullLiteral>] GitItemDescriptor =
    /// Path to item
    abstract path: string with get, set
    /// Specifies whether to include children (OneLevel), all descendants (Full), or None
    abstract recursionLevel: VersionControlRecursionType with get, set
    /// Version string (interpretation based on VersionType defined in subclass
    abstract version: string with get, set
    /// Version modifiers (e.g. previous)
    abstract versionOptions: GitVersionOptions with get, set
    /// How to interpret version (branch,tag,commit)
    abstract versionType: GitVersionType with get, set

type [<AllowNullLiteral>] GitItemRequestData =
    /// Whether to include metadata for all items
    abstract includeContentMetadata: bool with get, set
    /// Whether to include the _links field on the shallow references
    abstract includeLinks: bool with get, set
    /// Collection of items to fetch, including path, version, and recursion level
    abstract itemDescriptors: ResizeArray<GitItemDescriptor> with get, set
    /// Whether to include shallow ref to commit that last changed each item
    abstract latestProcessedChange: bool with get, set

type [<AllowNullLiteral>] GitLastChangeItem =
    /// Gets or sets the commit Id this item was modified most recently for the provided version.
    abstract commitId: string with get, set
    /// Gets or sets the path of the item.
    abstract path: string with get, set

type [<AllowNullLiteral>] GitLastChangeTreeItems =
    /// The list of commits referenced by Items, if they were requested.
    abstract commits: ResizeArray<GitCommitRef> with get, set
    /// The last change of items.
    abstract items: ResizeArray<GitLastChangeItem> with get, set
    /// The last explored time, in case the result is not comprehensive. Null otherwise.
    abstract lastExploredTime: DateTime with get, set

type [<AllowNullLiteral>] GitMerge =
    inherit GitMergeParameters
    /// Reference links.
    abstract _links: obj option with get, set
    /// Detailed status of the merge operation.
    abstract detailedStatus: GitMergeOperationStatusDetail with get, set
    /// Unique identifier for the merge operation.
    abstract mergeOperationId: float with get, set
    /// Status of the merge operation.
    abstract status: GitAsyncOperationStatus with get, set

/// Status information about a requested merge operation.
type [<AllowNullLiteral>] GitMergeOperationStatusDetail =
    /// Error message if the operation failed.
    abstract failureMessage: string with get, set
    /// The commitId of the resultant merge commit.
    abstract mergeCommitId: string with get, set

type [<AllowNullLiteral>] GitMergeOriginRef =
    abstract pullRequestId: float with get, set

/// Parameters required for performing git merge.
type [<AllowNullLiteral>] GitMergeParameters =
    /// Comment or message of the commit.
    abstract comment: string with get, set
    /// An enumeration of the parent commit IDs for the merge  commit.
    abstract parents: ResizeArray<string> with get, set

/// Git object identifier and type information.
type [<AllowNullLiteral>] GitObject =
    /// Object Id (Sha1Id).
    abstract objectId: string with get, set
    /// Type of object (Commit, Tree, Blob, Tag)
    abstract objectType: GitObjectType with get, set

type [<RequireQualifiedAccess>] GitObjectType =
    | Bad = 0
    | Commit = 1
    | Tree = 2
    | Blob = 3
    | Tag = 4
    | Ext2 = 5
    | OfsDelta = 6
    | RefDelta = 7

type [<AllowNullLiteral>] GitPathAction =
    abstract action: GitPathActions with get, set
    abstract base64Content: string with get, set
    abstract path: string with get, set
    abstract rawTextContent: string with get, set
    abstract targetPath: string with get, set

type [<RequireQualifiedAccess>] GitPathActions =
    | None = 0
    | Edit = 1
    | Delete = 2
    | Add = 3
    | Rename = 4

type [<AllowNullLiteral>] GitPathToItemsCollection =
    abstract items: GitPathToItemsCollectionItems with get, set

type [<AllowNullLiteral>] GitPolicyConfigurationResponse =
    /// The HTTP client methods find the continuation token header in the response and populate this field.
    abstract continuationToken: string option with get, set
    abstract policyConfigurations: ResizeArray<Policy.PolicyConfiguration> with get, set

/// Represents all the data associated with a pull request.
type [<AllowNullLiteral>] GitPullRequest =
    /// Links to other related objects.
    abstract _links: obj option with get, set
    /// A string which uniquely identifies this pull request. To generate an artifact ID for a pull request, use this template: \`\`\`vstfs:///Git/PullRequestId/\{projectId\}/\{repositoryId\}/\{pullRequestId\}\`\`\`
    abstract artifactId: string with get, set
    /// If set, auto-complete is enabled for this pull request and this is the identity that enabled it.
    abstract autoCompleteSetBy: WebApi.IdentityRef with get, set
    /// The user who closed the pull request.
    abstract closedBy: WebApi.IdentityRef with get, set
    /// The date when the pull request was closed (completed, abandoned, or merged externally).
    abstract closedDate: DateTime with get, set
    /// The code review ID of the pull request. Used internally.
    abstract codeReviewId: float with get, set
    /// The commits contained in the pull request.
    abstract commits: ResizeArray<GitCommitRef> with get, set
    /// Options which affect how the pull request will be merged when it is completed.
    abstract completionOptions: GitPullRequestCompletionOptions with get, set
    /// The most recent date at which the pull request entered the queue to be completed. Used internally.
    abstract completionQueueTime: DateTime with get, set
    /// The identity of the user who created the pull request.
    abstract createdBy: WebApi.IdentityRef with get, set
    /// The date when the pull request was created.
    abstract creationDate: DateTime with get, set
    /// The description of the pull request.
    abstract description: string with get, set
    /// If this is a PR from a fork this will contain information about its source.
    abstract forkSource: GitForkRef with get, set
    /// Draft / WIP pull request.
    abstract isDraft: bool with get, set
    /// The labels associated with the pull request.
    abstract labels: ResizeArray<Core.WebApiTagDefinition> with get, set
    /// The commit of the most recent pull request merge. If empty, the most recent merge is in progress or was unsuccessful.
    abstract lastMergeCommit: GitCommitRef with get, set
    /// The commit at the head of the source branch at the time of the last pull request merge.
    abstract lastMergeSourceCommit: GitCommitRef with get, set
    /// The commit at the head of the target branch at the time of the last pull request merge.
    abstract lastMergeTargetCommit: GitCommitRef with get, set
    /// If set, pull request merge failed for this reason.
    abstract mergeFailureMessage: string with get, set
    /// The type of failure (if any) of the pull request merge.
    abstract mergeFailureType: PullRequestMergeFailureType with get, set
    /// The ID of the job used to run the pull request merge. Used internally.
    abstract mergeId: string with get, set
    /// Options used when the pull request merge runs. These are separate from completion options since completion happens only once and a new merge will run every time the source branch of the pull request changes.
    abstract mergeOptions: GitPullRequestMergeOptions with get, set
    /// The current status of the pull request merge.
    abstract mergeStatus: PullRequestAsyncStatus with get, set
    /// The ID of the pull request.
    abstract pullRequestId: float with get, set
    /// Used internally.
    abstract remoteUrl: string with get, set
    /// The repository containing the target branch of the pull request.
    abstract repository: GitRepository with get, set
    /// A list of reviewers on the pull request along with the state of their votes.
    abstract reviewers: ResizeArray<IdentityRefWithVote> with get, set
    /// The name of the source branch of the pull request.
    abstract sourceRefName: string with get, set
    /// The status of the pull request.
    abstract status: PullRequestStatus with get, set
    /// If true, this pull request supports multiple iterations. Iteration support means individual pushes to the source branch of the pull request can be reviewed and comments left in one iteration will be tracked across future iterations.
    abstract supportsIterations: bool with get, set
    /// The name of the target branch of the pull request.
    abstract targetRefName: string with get, set
    /// The title of the pull request.
    abstract title: string with get, set
    /// Used internally.
    abstract url: string with get, set
    /// Any work item references associated with this pull request.
    abstract workItemRefs: ResizeArray<WebApi.ResourceRef> with get, set

/// Change made in a pull request.
type [<AllowNullLiteral>] GitPullRequestChange =
    inherit GitChange
    /// ID used to track files through multiple changes.
    abstract changeTrackingId: float with get, set

/// Represents a comment thread of a pull request. A thread contains meta data about the file it was left on (if any) along with one or more comments (an initial comment and the subsequent replies).
type [<AllowNullLiteral>] GitPullRequestCommentThread =
    inherit CommentThread
    /// Extended context information unique to pull requests
    abstract pullRequestThreadContext: GitPullRequestCommentThreadContext with get, set

/// Comment thread context contains details about what diffs were being viewed at the time of thread creation and whether or not the thread has been tracked from that original diff.
type [<AllowNullLiteral>] GitPullRequestCommentThreadContext =
    /// Used to track a comment across iterations. This value can be found by looking at the iteration's changes list. Must be set for pull requests with iteration support. Otherwise, it's not required for 'legacy' pull requests.
    abstract changeTrackingId: float with get, set
    /// The iteration context being viewed when the thread was created.
    abstract iterationContext: CommentIterationContext with get, set
    /// The criteria used to track this thread. If this property is filled out when the thread is returned, then the thread has been tracked from its original location using the given criteria.
    abstract trackingCriteria: CommentTrackingCriteria with get, set

/// Preferences about how the pull request should be completed.
type [<AllowNullLiteral>] GitPullRequestCompletionOptions =
    /// If true, policies will be explicitly bypassed while the pull request is completed.
    abstract bypassPolicy: bool with get, set
    /// If policies are bypassed, this reason is stored as to why bypass was used.
    abstract bypassReason: string with get, set
    /// If true, the source branch of the pull request will be deleted after completion.
    abstract deleteSourceBranch: bool with get, set
    /// If set, this will be used as the commit message of the merge commit.
    abstract mergeCommitMessage: string with get, set
    /// Specify the strategy used to merge the pull request during completion. If MergeStrategy is not set to any value, a no-FF merge will be created if SquashMerge == false. If MergeStrategy is not set to any value, the pull request commits will be squash if SquashMerge == true. The SquashMerge member is deprecated. It is recommended that you explicitly set MergeStrategy in all cases. If an explicit value is provided for MergeStrategy, the SquashMerge member will be ignored.
    abstract mergeStrategy: GitPullRequestMergeStrategy with get, set
    /// SquashMerge is deprecated. You should explicity set the value of MergeStrategy. If MergeStrategy is set to any value, the SquashMerge value will be ignored. If MergeStrategy is not set, the merge strategy will be no-fast-forward if this flag is false, or squash if true.
    abstract squashMerge: bool with get, set
    /// If true, we will attempt to transition any work items linked to the pull request into the next logical state (i.e. Active -\> Resolved)
    abstract transitionWorkItems: bool with get, set
    /// If true, the current completion attempt was triggered via auto-complete. Used internally.
    abstract triggeredByAutoComplete: bool with get, set

/// Provides properties that describe a Git pull request iteration. Iterations are created as a result of creating and pushing updates to a pull request.
type [<AllowNullLiteral>] GitPullRequestIteration =
    /// A collection of related REST reference links.
    abstract _links: obj option with get, set
    /// Author of the pull request iteration.
    abstract author: WebApi.IdentityRef with get, set
    /// Changes included with the pull request iteration.
    abstract changeList: ResizeArray<GitPullRequestChange> with get, set
    /// The commits included with the pull request iteration.
    abstract commits: ResizeArray<GitCommitRef> with get, set
    /// The first common Git commit of the source and target refs.
    abstract commonRefCommit: GitCommitRef with get, set
    /// The creation date of the pull request iteration.
    abstract createdDate: DateTime with get, set
    /// Description of the pull request iteration.
    abstract description: string with get, set
    /// Indicates if the Commits property contains a truncated list of commits in this pull request iteration.
    abstract hasMoreCommits: bool with get, set
    /// ID of the pull request iteration. Iterations are created as a result of creating and pushing updates to a pull request.
    abstract id: float with get, set
    /// If the iteration reason is Retarget, this is the refName of the new target
    abstract newTargetRefName: string with get, set
    /// If the iteration reason is Retarget, this is the original target refName
    abstract oldTargetRefName: string with get, set
    /// The Git push information associated with this pull request iteration.
    abstract push: GitPushRef with get, set
    /// The reason for which the pull request iteration was created.
    abstract reason: IterationReason with get, set
    /// The source Git commit of this iteration.
    abstract sourceRefCommit: GitCommitRef with get, set
    /// The target Git commit of this iteration.
    abstract targetRefCommit: GitCommitRef with get, set
    /// The updated date of the pull request iteration.
    abstract updatedDate: DateTime with get, set

/// Collection of changes made in a pull request.
type [<AllowNullLiteral>] GitPullRequestIterationChanges =
    /// Changes made in the iteration.
    abstract changeEntries: ResizeArray<GitPullRequestChange> with get, set
    /// Value to specify as skip to get the next page of changes.  This will be zero if there are no more changes.
    abstract nextSkip: float with get, set
    /// Value to specify as top to get the next page of changes.  This will be zero if there are no more changes.
    abstract nextTop: float with get, set

/// The options which are used when a pull request merge is created.
type [<AllowNullLiteral>] GitPullRequestMergeOptions =
    abstract detectRenameFalsePositives: bool with get, set
    /// If true, rename detection will not be performed during the merge.
    abstract disableRenames: bool with get, set

type [<RequireQualifiedAccess>] GitPullRequestMergeStrategy =
    | NoFastForward = 1
    | Squash = 2
    | Rebase = 3
    | RebaseMerge = 4

/// A set of pull request queries and their results.
type [<AllowNullLiteral>] GitPullRequestQuery =
    /// The queries to perform.
    abstract queries: ResizeArray<GitPullRequestQueryInput> with get, set
    /// The results of the queries. This matches the QueryInputs list so Results[n] are the results of QueryInputs[n]. Each entry in the list is a dictionary of commit-\>pull requests.
    abstract results: ResizeArray<GitPullRequestQueryResults> with get, set

/// Pull request query input parameters.
type [<AllowNullLiteral>] GitPullRequestQueryInput =
    /// The list of commit IDs to search for.
    abstract items: ResizeArray<string> with get, set
    /// The type of query to perform.
    abstract ``type``: GitPullRequestQueryType with get, set

type [<RequireQualifiedAccess>] GitPullRequestQueryType =
    | NotSet = 0
    | LastMergeCommit = 1
    | Commit = 2

type [<AllowNullLiteral>] GitPullRequestReviewFileContentInfo =
    abstract _links: obj option with get, set
    /// The file change path.
    abstract path: string with get, set
    /// Content hash of on-disk representation of file content. Its calculated by the client by using SHA1 hash function. Ensure that uploaded file has same encoding as in source control.
    abstract shA1Hash: string with get, set

type [<RequireQualifiedAccess>] GitPullRequestReviewFileType =
    | ChangeEntry = 0
    | Attachment = 1

/// Pull requests can be searched for matching this criteria.
type [<AllowNullLiteral>] GitPullRequestSearchCriteria =
    /// If set, search for pull requests that were created by this identity.
    abstract creatorId: string with get, set
    /// Whether to include the _links field on the shallow references
    abstract includeLinks: bool with get, set
    /// If set, search for pull requests whose target branch is in this repository.
    abstract repositoryId: string with get, set
    /// If set, search for pull requests that have this identity as a reviewer.
    abstract reviewerId: string with get, set
    /// If set, search for pull requests from this branch.
    abstract sourceRefName: string with get, set
    /// If set, search for pull requests whose source branch is in this repository.
    abstract sourceRepositoryId: string with get, set
    /// If set, search for pull requests that are in this state. Defaults to Active if unset.
    abstract status: PullRequestStatus with get, set
    /// If set, search for pull requests into this branch.
    abstract targetRefName: string with get, set

/// This class contains the metadata of a service/extension posting pull request status. Status can be associated with a pull request or an iteration.
type [<AllowNullLiteral>] GitPullRequestStatus =
    inherit GitStatus
    /// ID of the iteration to associate status with. Minimum value is 1.
    abstract iterationId: float with get, set
    /// Custom properties of the status.
    abstract properties: obj option with get, set

type [<AllowNullLiteral>] GitPush =
    inherit GitPushRef
    abstract commits: ResizeArray<GitCommitRef> with get, set
    abstract refUpdates: ResizeArray<GitRefUpdate> with get, set
    abstract repository: GitRepository with get, set

type [<AllowNullLiteral>] GitPushEventData =
    abstract afterId: string with get, set
    abstract beforeId: string with get, set
    abstract branch: string with get, set
    abstract commits: ResizeArray<GitCommit> with get, set
    abstract repository: GitRepository with get, set

type [<AllowNullLiteral>] GitPushRef =
    abstract _links: obj option with get, set
    abstract date: DateTime with get, set
    abstract pushCorrelationId: string with get, set
    abstract pushedBy: WebApi.IdentityRef with get, set
    abstract pushId: float with get, set
    abstract url: string with get, set

type [<AllowNullLiteral>] GitPushSearchCriteria =
    abstract fromDate: DateTime with get, set
    /// Whether to include the _links field on the shallow references
    abstract includeLinks: bool with get, set
    abstract includeRefUpdates: bool with get, set
    abstract pusherId: string with get, set
    abstract refName: string with get, set
    abstract toDate: DateTime with get, set

type [<AllowNullLiteral>] GitQueryBranchStatsCriteria =
    abstract baseCommit: GitVersionDescriptor with get, set
    abstract targetCommits: ResizeArray<GitVersionDescriptor> with get, set

type [<AllowNullLiteral>] GitQueryCommitsCriteria =
    /// Number of entries to skip
    abstract ``$skip``: float with get, set
    /// Maximum number of entries to retrieve
    abstract ``$top``: float with get, set
    /// Alias or display name of the author
    abstract author: string with get, set
    /// Only applicable when ItemVersion specified. If provided, start walking history starting at this commit.
    abstract compareVersion: GitVersionDescriptor with get, set
    /// Only applies when an itemPath is specified. This determines whether to exclude delete entries of the specified path.
    abstract excludeDeletes: bool with get, set
    /// If provided, a lower bound for filtering commits alphabetically
    abstract fromCommitId: string with get, set
    /// If provided, only include history entries created after this date (string)
    abstract fromDate: string with get, set
    /// What Git history mode should be used. This only applies to the search criteria when Ids = null and an itemPath is specified.
    abstract historyMode: GitHistoryMode with get, set
    /// If provided, specifies the exact commit ids of the commits to fetch. May not be combined with other parameters.
    abstract ids: ResizeArray<string> with get, set
    /// Whether to include the _links field on the shallow references
    abstract includeLinks: bool with get, set
    /// Whether to include the push information
    abstract includePushData: bool with get, set
    /// Whether to include the image Url for committers and authors
    abstract includeUserImageUrl: bool with get, set
    /// Whether to include linked work items
    abstract includeWorkItems: bool with get, set
    /// Path of item to search under
    abstract itemPath: string with get, set
    /// If provided, identifies the commit or branch to search
    abstract itemVersion: GitVersionDescriptor with get, set
    /// If provided, an upper bound for filtering commits alphabetically
    abstract toCommitId: string with get, set
    /// If provided, only include history entries created before this date (string)
    abstract toDate: string with get, set
    /// Alias or display name of the committer
    abstract user: string with get, set

type [<AllowNullLiteral>] GitQueryRefsCriteria =
    /// List of commit Ids to be searched
    abstract commitIds: ResizeArray<string> with get, set
    /// List of complete or partial names for refs to be searched
    abstract refNames: ResizeArray<string> with get, set
    /// Type of search on refNames, if provided
    abstract searchType: GitRefSearchType with get, set

type [<AllowNullLiteral>] GitRecycleBinRepositoryDetails =
    /// Setting to false will undo earlier deletion and restore the repository.
    abstract deleted: bool with get, set

type [<AllowNullLiteral>] GitRef =
    abstract _links: obj option with get, set
    abstract creator: WebApi.IdentityRef with get, set
    abstract isLocked: bool with get, set
    abstract isLockedBy: WebApi.IdentityRef with get, set
    abstract name: string with get, set
    abstract objectId: string with get, set
    abstract peeledObjectId: string with get, set
    abstract statuses: ResizeArray<GitStatus> with get, set
    abstract url: string with get, set

type [<AllowNullLiteral>] GitRefFavorite =
    abstract _links: obj option with get, set
    abstract id: float with get, set
    abstract identityId: string with get, set
    abstract name: string with get, set
    abstract repositoryId: string with get, set
    abstract ``type``: RefFavoriteType with get, set
    abstract url: string with get, set

type [<RequireQualifiedAccess>] GitRefSearchType =
    | Exact = 0
    | StartsWith = 1
    | Contains = 2

type [<AllowNullLiteral>] GitRefUpdate =
    abstract isLocked: bool with get, set
    abstract name: string with get, set
    abstract newObjectId: string with get, set
    abstract oldObjectId: string with get, set
    abstract repositoryId: string with get, set

type [<RequireQualifiedAccess>] GitRefUpdateMode =
    | BestEffort = 0
    | AllOrNone = 1

type [<AllowNullLiteral>] GitRefUpdateResult =
    /// Custom message for the result object For instance, Reason for failing.
    abstract customMessage: string with get, set
    /// Whether the ref is locked or not
    abstract isLocked: bool with get, set
    /// Ref name
    abstract name: string with get, set
    /// New object ID
    abstract newObjectId: string with get, set
    /// Old object ID
    abstract oldObjectId: string with get, set
    /// Name of the plugin that rejected the updated.
    abstract rejectedBy: string with get, set
    /// Repository ID
    abstract repositoryId: string with get, set
    /// True if the ref update succeeded, false otherwise
    abstract success: bool with get, set
    /// Status of the update from the TFS server.
    abstract updateStatus: GitRefUpdateStatus with get, set

type [<RequireQualifiedAccess>] GitRefUpdateStatus =
    | Succeeded = 0
    | ForcePushRequired = 1
    | StaleOldObjectId = 2
    | InvalidRefName = 3
    | Unprocessed = 4
    | UnresolvableToCommit = 5
    | WritePermissionRequired = 6
    | ManageNotePermissionRequired = 7
    | CreateBranchPermissionRequired = 8
    | CreateTagPermissionRequired = 9
    | RejectedByPlugin = 10
    | Locked = 11
    | RefNameConflict = 12
    | RejectedByPolicy = 13
    | SucceededNonExistentRef = 14
    | SucceededCorruptRef = 15

type [<AllowNullLiteral>] GitRepository =
    abstract _links: obj option with get, set
    abstract defaultBranch: string with get, set
    abstract id: string with get, set
    /// True if the repository was created as a fork
    abstract isFork: bool with get, set
    abstract name: string with get, set
    abstract parentRepository: GitRepositoryRef with get, set
    abstract project: Core.TeamProjectReference with get, set
    abstract remoteUrl: string with get, set
    /// Compressed size (bytes) of the repository.
    abstract size: float with get, set
    abstract sshUrl: string with get, set
    abstract url: string with get, set
    abstract validRemoteUrls: ResizeArray<string> with get, set
    abstract webUrl: string with get, set

type [<AllowNullLiteral>] GitRepositoryCreateOptions =
    abstract name: string with get, set
    abstract parentRepository: GitRepositoryRef with get, set
    abstract project: Core.TeamProjectReference with get, set

type [<AllowNullLiteral>] GitRepositoryRef =
    /// Team Project Collection where this Fork resides
    abstract collection: Core.TeamProjectCollectionReference with get, set
    abstract id: string with get, set
    /// True if the repository was created as a fork
    abstract isFork: bool with get, set
    abstract name: string with get, set
    abstract project: Core.TeamProjectReference with get, set
    abstract remoteUrl: string with get, set
    abstract sshUrl: string with get, set
    abstract url: string with get, set

type [<AllowNullLiteral>] GitRepositoryStats =
    abstract activePullRequestsCount: float with get, set
    abstract branchesCount: float with get, set
    abstract commitsCount: float with get, set
    abstract repositoryId: string with get, set

type [<AllowNullLiteral>] GitResolution =
    /// User who created the resolution.
    abstract author: WebApi.IdentityRef with get, set

type [<RequireQualifiedAccess>] GitResolutionError =
    | None = 0
    | MergeContentNotFound = 1
    | PathInUse = 2
    | InvalidPath = 3
    | UnknownAction = 4
    | UnknownMergeType = 5
    | OtherError = 255

type [<AllowNullLiteral>] GitResolutionMergeContent =
    inherit GitResolution
    abstract mergeType: GitResolutionMergeType with get, set
    abstract userMergedBlob: GitBlobRef with get, set
    abstract userMergedContent: ResizeArray<float> with get, set

type [<RequireQualifiedAccess>] GitResolutionMergeType =
    | Undecided = 0
    | TakeSourceContent = 1
    | TakeTargetContent = 2
    | AutoMerged = 3
    | UserMerged = 4

type [<AllowNullLiteral>] GitResolutionPathConflict =
    inherit GitResolution
    abstract action: GitResolutionPathConflictAction with get, set
    abstract renamePath: string with get, set

type [<RequireQualifiedAccess>] GitResolutionPathConflictAction =
    | Undecided = 0
    | KeepSourceRenameTarget = 1
    | KeepSourceDeleteTarget = 2
    | KeepTargetRenameSource = 3
    | KeepTargetDeleteSource = 4

type [<AllowNullLiteral>] GitResolutionPickOneAction =
    inherit GitResolution
    abstract action: GitResolutionWhichAction with get, set

type [<AllowNullLiteral>] GitResolutionRename1to2 =
    inherit GitResolutionMergeContent
    abstract action: GitResolutionRename1to2Action with get, set

type [<RequireQualifiedAccess>] GitResolutionRename1to2Action =
    | Undecided = 0
    | KeepSourcePath = 1
    | KeepTargetPath = 2
    | KeepBothFiles = 3

type [<RequireQualifiedAccess>] GitResolutionStatus =
    | Unresolved = 0
    | PartiallyResolved = 1
    | Resolved = 2

type [<RequireQualifiedAccess>] GitResolutionWhichAction =
    | Undecided = 0
    | PickSourceAction = 1
    | PickTargetAction = 2

type [<AllowNullLiteral>] GitRevert =
    inherit GitAsyncRefOperation
    abstract revertId: float with get, set

/// This class contains the metadata of a service/extension posting a status.
type [<AllowNullLiteral>] GitStatus =
    /// Reference links.
    abstract _links: obj option with get, set
    /// Context of the status.
    abstract context: GitStatusContext with get, set
    /// Identity that created the status.
    abstract createdBy: WebApi.IdentityRef with get, set
    /// Creation date and time of the status.
    abstract creationDate: DateTime with get, set
    /// Status description. Typically describes current state of the status.
    abstract description: string with get, set
    /// Status identifier.
    abstract id: float with get, set
    /// State of the status.
    abstract state: GitStatusState with get, set
    /// URL with status details.
    abstract targetUrl: string with get, set
    /// Last update date and time of the status.
    abstract updatedDate: DateTime with get, set

/// Status context that uniquely identifies the status.
type [<AllowNullLiteral>] GitStatusContext =
    /// Genre of the status. Typically name of the service/tool generating the status, can be empty.
    abstract genre: string with get, set
    /// Name identifier of the status, cannot be null or empty.
    abstract name: string with get, set

type [<RequireQualifiedAccess>] GitStatusState =
    | NotSet = 0
    | Pending = 1
    | Succeeded = 2
    | Failed = 3
    | Error = 4
    | NotApplicable = 5

/// An object describing the git suggestion.  Git suggestions are currently limited to suggested pull requests.
type [<AllowNullLiteral>] GitSuggestion =
    /// Specific properties describing the suggestion.
    abstract properties: GitSuggestionProperties with get, set
    /// The type of suggestion (e.g. pull request).
    abstract ``type``: string with get, set

type [<AllowNullLiteral>] GitTargetVersionDescriptor =
    inherit GitVersionDescriptor
    /// Version string identifier (name of tag/branch, SHA1 of commit)
    abstract targetVersion: string with get, set
    /// Version options - Specify additional modifiers to version (e.g Previous)
    abstract targetVersionOptions: GitVersionOptions with get, set
    /// Version type (branch, tag, or commit). Determines how Id is interpreted
    abstract targetVersionType: GitVersionType with get, set

type [<AllowNullLiteral>] GitTemplate =
    /// Name of the Template
    abstract name: string with get, set
    /// Type of the Template
    abstract ``type``: string with get, set

type [<AllowNullLiteral>] GitTreeDiff =
    /// ObjectId of the base tree of this diff.
    abstract baseTreeId: string with get, set
    /// List of tree entries that differ between the base and target tree.  Renames and object type changes are returned as a delete for the old object and add for the new object.  If a continuation token is returned in the response header, some tree entries are yet to be processed and may yeild more diff entries. If the continuation token is not returned all the diff entries have been included in this response.
    abstract diffEntries: ResizeArray<GitTreeDiffEntry> with get, set
    /// ObjectId of the target tree of this diff.
    abstract targetTreeId: string with get, set
    /// REST Url to this resource.
    abstract url: string with get, set

type [<AllowNullLiteral>] GitTreeDiffEntry =
    /// SHA1 hash of the object in the base tree, if it exists. Will be null in case of adds.
    abstract baseObjectId: string with get, set
    /// Type of change that affected this entry.
    abstract changeType: VersionControlChangeType with get, set
    /// Object type of the tree entry. Blob, Tree or Commit("submodule")
    abstract objectType: GitObjectType with get, set
    /// Relative path in base and target trees.
    abstract path: string with get, set
    /// SHA1 hash of the object in the target tree, if it exists. Will be null in case of deletes.
    abstract targetObjectId: string with get, set

type [<AllowNullLiteral>] GitTreeDiffResponse =
    /// The HTTP client methods find the continuation token header in the response and populate this field.
    abstract continuationToken: ResizeArray<string> with get, set
    abstract treeDiff: GitTreeDiff with get, set

type [<AllowNullLiteral>] GitTreeEntryRef =
    /// Blob or tree
    abstract gitObjectType: GitObjectType with get, set
    /// Mode represented as octal string
    abstract mode: string with get, set
    /// SHA1 hash of git object
    abstract objectId: string with get, set
    /// Path relative to parent tree object
    abstract relativePath: string with get, set
    /// Size of content
    abstract size: float with get, set
    /// url to retrieve tree or blob
    abstract url: string with get, set

type [<AllowNullLiteral>] GitTreeRef =
    abstract _links: obj option with get, set
    /// SHA1 hash of git object
    abstract objectId: string with get, set
    /// Sum of sizes of all children
    abstract size: float with get, set
    /// Blobs and trees under this tree
    abstract treeEntries: ResizeArray<GitTreeEntryRef> with get, set
    /// Url to tree
    abstract url: string with get, set

/// User info and date for Git operations.
type [<AllowNullLiteral>] GitUserDate =
    /// Date of the Git operation.
    abstract date: DateTime with get, set
    /// Email address of the user performing the Git operation.
    abstract email: string with get, set
    /// Url for the user's avatar.
    abstract imageUrl: string with get, set
    /// Name of the user performing the Git operation.
    abstract name: string with get, set

type [<AllowNullLiteral>] GitVersionDescriptor =
    /// Version string identifier (name of tag/branch, SHA1 of commit)
    abstract version: string with get, set
    /// Version options - Specify additional modifiers to version (e.g Previous)
    abstract versionOptions: GitVersionOptions with get, set
    /// Version type (branch, tag, or commit). Determines how Id is interpreted
    abstract versionType: GitVersionType with get, set

type [<RequireQualifiedAccess>] GitVersionOptions =
    | None = 0
    | PreviousChange = 1
    | FirstParent = 2

type [<RequireQualifiedAccess>] GitVersionType =
    | Branch = 0
    | Tag = 1
    | Commit = 2

/// Globally unique key for a repository.
type [<AllowNullLiteral>] GlobalGitRepositoryKey =
    /// Team Project Collection ID of the collection for the repository.
    abstract collectionId: string with get, set
    /// Team Project ID of the project for the repository.
    abstract projectId: string with get, set
    /// ID of the repository.
    abstract repositoryId: string with get, set

type [<AllowNullLiteral>] HistoryEntry<'T> =
    /// The Change list (changeset/commit/shelveset) for this point in history
    abstract changeList: ChangeList<'T> with get, set
    /// The change made to the item from this change list (only relevant for File history, not folders)
    abstract itemChangeType: VersionControlChangeType with get, set
    /// The path of the item at this point in history (only relevant for File history, not folders)
    abstract serverItem: string with get, set

/// Identity information including a vote on a pull request.
type [<AllowNullLiteral>] IdentityRefWithVote =
    inherit WebApi.IdentityRef
    /// Indicates if this reviewer is flagged for attention on this pull request.
    abstract isFlagged: bool with get, set
    /// Indicates if this is a required reviewer for this pull request. \<br /\> Branches can have policies that require particular reviewers are required for pull requests.
    abstract isRequired: bool with get, set
    /// URL to retrieve information about this identity
    abstract reviewerUrl: string with get, set
    /// Vote on a pull request:\<br /\> 10 - approved 5 - approved with suggestions 0 - no vote -5 - waiting for author -10 - rejected
    abstract vote: float with get, set
    /// Groups or teams that that this reviewer contributed to. \<br /\> Groups and teams can be reviewers on pull requests but can not vote directly.  When a member of the group or team votes, that vote is rolled up into the group or team vote.  VotedFor is a list of such votes.
    abstract votedFor: ResizeArray<IdentityRefWithVote> with get, set

type [<AllowNullLiteral>] ImportRepositoryValidation =
    abstract gitSource: GitImportGitSource with get, set
    abstract password: string with get, set
    abstract tfvcSource: GitImportTfvcSource with get, set
    abstract username: string with get, set

type [<AllowNullLiteral>] IncludedGitCommit =
    abstract commitId: string with get, set
    abstract commitTime: DateTime with get, set
    abstract parentCommitIds: ResizeArray<string> with get, set
    abstract repositoryId: string with get, set

/// Real time event (SignalR) for IsDraft update on a pull request
type [<AllowNullLiteral>] IsDraftUpdatedEvent =
    inherit RealTimePullRequestEvent

type [<AllowNullLiteral>] ItemContent =
    abstract content: string with get, set
    abstract contentType: ItemContentType with get, set

type [<RequireQualifiedAccess>] ItemContentType =
    | RawText = 0
    | Base64Encoded = 1

/// Optional details to include when returning an item model
type [<AllowNullLiteral>] ItemDetailsOptions =
    /// If true, include metadata about the file type
    abstract includeContentMetadata: bool with get, set
    /// Specifies whether to include children (OneLevel), all descendants (Full) or None for folder items
    abstract recursionLevel: VersionControlRecursionType with get, set

type [<AllowNullLiteral>] ItemModel =
    abstract _links: obj option with get, set
    abstract content: string with get, set
    abstract contentMetadata: FileContentMetadata with get, set
    abstract isFolder: bool with get, set
    abstract isSymLink: bool with get, set
    abstract path: string with get, set
    abstract url: string with get, set

type [<RequireQualifiedAccess>] IterationReason =
    | Push = 0
    | ForcePush = 1
    | Create = 2
    | Rebase = 4
    | Unknown = 8
    | Retarget = 16

/// Real time event (SignalR) for updated labels on a pull request
type [<AllowNullLiteral>] LabelsUpdatedEvent =
    inherit RealTimePullRequestEvent

/// The class to represent the line diff block
type [<AllowNullLiteral>] LineDiffBlock =
    /// Type of change that was made to the block.
    abstract changeType: LineDiffBlockChangeType with get, set
    /// Line number where this block starts in modified file.
    abstract modifiedLineNumberStart: float with get, set
    /// Count of lines in this block in modified file.
    abstract modifiedLinesCount: float with get, set
    /// Line number where this block starts in original file.
    abstract originalLineNumberStart: float with get, set
    /// Count of lines in this block in original file.
    abstract originalLinesCount: float with get, set

type [<RequireQualifiedAccess>] LineDiffBlockChangeType =
    | None = 0
    | Add = 1
    | Delete = 2
    | Edit = 3

/// Real time event (SignalR) for a merge completed on a pull request
type [<AllowNullLiteral>] MergeCompletedEvent =
    inherit RealTimePullRequestEvent

/// Real time event (SignalR) for a policy evaluation update on a pull request
type [<AllowNullLiteral>] PolicyEvaluationUpdatedEvent =
    inherit RealTimePullRequestEvent

type [<RequireQualifiedAccess>] PullRequestAsyncStatus =
    | NotSet = 0
    | Queued = 1
    | Conflicts = 2
    | Succeeded = 3
    | RejectedByPolicy = 4
    | Failure = 5

/// Real time event (SignalR) for pull request creation
type [<AllowNullLiteral>] PullRequestCreatedEvent =
    inherit RealTimePullRequestEvent

type [<RequireQualifiedAccess>] PullRequestMergeFailureType =
    | None = 0
    | Unknown = 1
    | CaseSensitive = 2
    | ObjectTooLarge = 3

type [<RequireQualifiedAccess>] PullRequestStatus =
    | NotSet = 0
    | Active = 1
    | Abandoned = 2
    | Completed = 3
    | All = 4

/// Initial config contract sent to extensions creating tabs on the pull request page
type [<AllowNullLiteral>] PullRequestTabExtensionConfig =
    abstract pullRequestId: float with get, set
    abstract repositoryId: string with get, set

/// Base contract for a real time pull request event (SignalR)
type [<AllowNullLiteral>] RealTimePullRequestEvent =
    /// The id of this event. Can be used to track send/receive state between client and server.
    abstract eventId: string with get, set
    /// The id of the pull request this event was generated for.
    abstract pullRequestId: float with get, set

type [<RequireQualifiedAccess>] RefFavoriteType =
    | Invalid = 0
    | Folder = 1
    | Ref = 2

/// Real time event (SignalR) for when the target branch of a pull request is changed
type [<AllowNullLiteral>] RetargetEvent =
    inherit RealTimePullRequestEvent

/// Real time event (SignalR) for an update to reviewers on a pull request
type [<AllowNullLiteral>] ReviewersUpdatedEvent =
    inherit RealTimePullRequestEvent

/// Real time event (SignalR) for reviewer votes being reset on a pull request
type [<AllowNullLiteral>] ReviewersVotesResetEvent =
    inherit RealTimePullRequestEvent

/// Real time event (SignalR) for a reviewer vote update on a pull request
type [<AllowNullLiteral>] ReviewerVoteUpdatedEvent =
    inherit RealTimePullRequestEvent

/// Context used while sharing a pull request.
type [<AllowNullLiteral>] ShareNotificationContext =
    /// Optional user note or message.
    abstract message: string with get, set
    /// Identities of users who will receive a share notification.
    abstract receivers: ResizeArray<WebApi.IdentityRef> with get, set

type [<AllowNullLiteral>] SourceToTargetRef =
    /// The source ref to copy. For example, refs/heads/master.
    abstract sourceRef: string with get, set
    /// The target ref to update. For example, refs/heads/master.
    abstract targetRef: string with get, set

/// Real time event (SignalR) for an added status on a pull request
type [<AllowNullLiteral>] StatusAddedEvent =
    inherit RealTimePullRequestEvent

/// Real time event (SignalR) for deleted statuses on a pull request
type [<AllowNullLiteral>] StatusesDeletedEvent =
    inherit RealTimePullRequestEvent

/// Real time event (SignalR) for a status update on a pull request
type [<AllowNullLiteral>] StatusUpdatedEvent =
    inherit RealTimePullRequestEvent

/// Represents a Supported IDE entity.
type [<AllowNullLiteral>] SupportedIde =
    /// The download URL for the IDE.
    abstract downloadUrl: string with get, set
    /// The type of the IDE.
    abstract ideType: SupportedIdeType with get, set
    /// The name of the IDE.
    abstract name: string with get, set
    /// The URL to open the protocol handler for the IDE.
    abstract protocolHandlerUrl: string with get, set
    /// A list of SupportedPlatforms.
    abstract supportedPlatforms: ResizeArray<string> with get, set

type [<RequireQualifiedAccess>] SupportedIdeType =
    | Unknown = 0
    | AndroidStudio = 1
    | AppCode = 2
    | CLion = 3
    | DataGrip = 4
    | Eclipse = 13
    | IntelliJ = 5
    | MPS = 6
    | PhpStorm = 7
    | PyCharm = 8
    | RubyMine = 9
    | Tower = 10
    | VisualStudio = 11
    | VSCode = 14
    | WebStorm = 12

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

type [<AllowNullLiteral>] TfvcCheckinEventData =
    abstract changeset: TfvcChangeset with get, set
    abstract project: Core.TeamProjectReference with get, set

type [<AllowNullLiteral>] TfvcHistoryEntry =
    inherit HistoryEntry<TfvcItem>
    /// The encoding of the item at this point in history (only relevant for File history, not folders)
    abstract encoding: float with get, set
    /// The file id of the item at this point in history (only relevant for File history, not folders)
    abstract fileId: float with get, set

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

/// Metadata for an item including the previous hash value for files.
type [<AllowNullLiteral>] TfvcItemPreviousHash =
    inherit TfvcItem
    /// MD5 hash as a base 64 string, applies to files only.
    abstract previousHashValue: string with get, set

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

/// Real time event (SignalR) for a title/description update on a pull request
type [<AllowNullLiteral>] TitleDescriptionUpdatedEvent =
    inherit RealTimePullRequestEvent

type [<AllowNullLiteral>] UpdateRefsRequest =
    abstract refUpdateRequests: ResizeArray<GitRefUpdate> with get, set
    abstract updateMode: GitRefUpdateMode with get, set

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
    abstract defaultSourceControlType: Core.SourceControlTypes with get, set
    abstract project: Core.TeamProjectReference with get, set
    abstract supportsGit: bool with get, set
    abstract supportsTFVC: bool with get, set

type [<RequireQualifiedAccess>] VersionControlRecursionType =
    | None = 0
    | OneLevel = 1
    | OneLevelPlusNestedEmptyFolders = 4
    | Full = 120

type [<AllowNullLiteral>] ChangeListChangeCounts =
    [<Emit "$0[$1]{{=$2}}">] abstract Item: key: float -> float with get, set

type [<AllowNullLiteral>] CommentThreadIdentities =
    [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> WebApi.IdentityRef with get, set

type [<AllowNullLiteral>] GitPathToItemsCollectionItems =
    [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> ResizeArray<GitItem> with get, set

type [<AllowNullLiteral>] GitPullRequestQueryResults =
    [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> ResizeArray<GitPullRequest> with get, set

type [<AllowNullLiteral>] GitSuggestionProperties =
    [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set
