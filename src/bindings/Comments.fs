// ts2fable 0.7.1
module rec Comments
open System
open Fable.Core
open Fable.Core.JS

/// Comment on an artifact like Work Item or Wiki, etc.
type [<AllowNullLiteral>] Comment =
    inherit CommentResourceReference
    /// The id of the artifact this comment belongs to
    abstract artifactId: string with get, set
    /// IdentityRef of the creator of the comment.
    abstract createdBy: WebApi.IdentityRef with get, set
    /// The creation date of the comment.
    abstract createdDate: DateTime with get, set
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
    /// The comment id of the parent comment, if any
    abstract parentId: float with get, set
    /// The reactions on the comment.
    abstract reactions: ResizeArray<CommentReaction> with get, set
    /// The rendered text of the comment
    abstract renderedText: string with get, set
    /// Replies for this comment
    abstract replies: CommentList with get, set
    /// Indicates the current state of the comment
    abstract state: CommentState with get, set
    /// The plaintext/markdown version of the comment
    abstract text: string with get, set
    /// The current version of the comment
    abstract version: float with get, set

/// Represents an attachment to a comment.
type [<AllowNullLiteral>] CommentAttachment =
    inherit CommentResourceReference
    /// IdentityRef of the creator of the attachment.
    abstract createdBy: WebApi.IdentityRef with get, set
    /// The creation date of the attachment.
    abstract createdDate: DateTime with get, set
    /// Unique Id of the attachment.
    abstract id: string with get, set

/// Represents a request to create a work item comment.
type [<AllowNullLiteral>] CommentCreateParameters =
    /// Optional CommentId of the parent in order to add a reply for an existing comment
    abstract parentId: float with get, set
    abstract text: string with get, set

type [<RequireQualifiedAccess>] CommentExpandOptions =
    | None = 0
    | Reactions = 1
    | RenderedText = 8
    | RenderedTextOnly = 16
    | Children = 32
    | All = -17

type [<RequireQualifiedAccess>] CommentFormat =
    | Markdown = 0
    | Html = 1

/// Represents a list of comments.
type [<AllowNullLiteral>] CommentList =
    inherit CommentResourceReference
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

/// Contains information about various artifacts mentioned in the comment
type [<AllowNullLiteral>] CommentMention =
    inherit CommentResourceReference
    /// Id of the artifact this mention belongs to
    abstract artifactId: string with get, set
    /// Id of the comment associated with this mention. Nullable to support legacy mentions which can potentially have null commentId
    abstract commentId: float with get, set
    /// Value of the mentioned artifact. Expected Value varies by CommentMentionType: Person:         VSID associated with the identity Work Item:      ID of the work item Pull Request:   ID of the Pull Request
    abstract mentionedArtifact: string with get, set
    /// The context which represent where this mentioned was parsed from
    abstract ``type``: CommentMentionType with get, set

type [<RequireQualifiedAccess>] CommentMentionType =
    | Person = 0
    | WorkItem = 1
    | PullRequest = 2

/// Contains information about comment reaction for a particular reaction type.
type [<AllowNullLiteral>] CommentReaction =
    inherit CommentResourceReference
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

/// Base class for comment resource references
type [<AllowNullLiteral>] CommentResourceReference =
    abstract url: string with get, set

type [<RequireQualifiedAccess>] CommentSortOrder =
    | Asc = 1
    | Desc = 2

type [<RequireQualifiedAccess>] CommentState =
    | Active = 0
    | Resolved = 1
    | Closed = 2

/// Represents a request to update a comment.
type [<AllowNullLiteral>] CommentUpdateParameters =
    /// Set the current state of the comment
    abstract state: CommentState with get, set
    /// The updated text of the comment
    abstract text: string with get, set

/// Represents a specific version of a comment on a work item.
type [<AllowNullLiteral>] CommentVersion =
    inherit CommentResourceReference
    /// IdentityRef of the creator of the comment.
    abstract createdBy: WebApi.IdentityRef with get, set
    /// The creation date of the comment.
    abstract createdDate: DateTime with get, set
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
    /// Indicates the current state of the comment
    abstract state: CommentState with get, set
    /// The text of the comment at this version.
    abstract text: string with get, set
    /// The version number.
    abstract version: float with get, set
