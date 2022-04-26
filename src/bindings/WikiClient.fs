// ts2fable 0.7.1
module rec WikiClient
open System
open Fable.Core
open Fable.Core.JS


type IVssRestClientOptions = Context.IVssRestClientOptions
type RestClientBase = RestClientBase.RestClientBase

type [<AllowNullLiteral>] IExports =
    abstract WikiRestClient: WikiRestClientStatic

type [<AllowNullLiteral>] WikiRestClient =
    inherit RestClientBase
    /// <summary>Uploads an attachment on a comment on a wiki page.</summary>
    /// <param name="content">- Content to upload</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="wikiIdentifier">- Wiki ID or wiki name.</param>
    /// <param name="pageId">- Wiki page ID.</param>
    abstract createCommentAttachment: content: obj option * project: string * wikiIdentifier: string * pageId: float -> Promise<Comments.CommentAttachment>
    /// <summary>Downloads an attachment on a comment on a wiki page.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="wikiIdentifier">- Wiki ID or wiki name.</param>
    /// <param name="pageId">- Wiki page ID.</param>
    /// <param name="attachmentId">- Attachment ID.</param>
    abstract getAttachmentContent: project: string * wikiIdentifier: string * pageId: float * attachmentId: string -> Promise<ArrayBuffer>
    /// <summary>Add a reaction on a wiki page comment.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="wikiIdentifier">- Wiki ID or wiki name</param>
    /// <param name="pageId">- Wiki page ID</param>
    /// <param name="commentId">- ID of the associated comment</param>
    /// <param name="type">- Type of the reaction being added</param>
    abstract addCommentReaction: project: string * wikiIdentifier: string * pageId: float * commentId: float * ``type``: Comments.CommentReactionType -> Promise<Comments.CommentReaction>
    /// <summary>Delete a reaction on a wiki page comment.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="wikiIdentifier">- Wiki ID or name</param>
    /// <param name="pageId">- Wiki page ID</param>
    /// <param name="commentId">- ID of the associated comment</param>
    /// <param name="type">- Type of the reaction being deleted</param>
    abstract deleteCommentReaction: project: string * wikiIdentifier: string * pageId: float * commentId: float * ``type``: Comments.CommentReactionType -> Promise<Comments.CommentReaction>
    /// <summary>Gets a list of users who have reacted for the given wiki comment with a given reaction type. Supports paging, with a default page size of 100 users at a time.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="wikiIdentifier">- Wiki ID or wiki name.</param>
    /// <param name="pageId">- Wiki page ID.</param>
    /// <param name="commentId">- ID of the associated comment</param>
    /// <param name="type">- Type of the reaction for which the engaged users are being requested</param>
    /// <param name="top">- Number of enagaged users to be returned in a given page. Optional, defaults to 100</param>
    /// <param name="skip">- Number of engaged users to be skipped to page the next set of engaged users, defaults to 0</param>
    abstract getEngagedUsers: project: string * wikiIdentifier: string * pageId: float * commentId: float * ``type``: Comments.CommentReactionType * ?top: float * ?skip: float -> Promise<ResizeArray<WebApi.IdentityRef>>
    /// <summary>Add a comment on a wiki page.</summary>
    /// <param name="request">- Comment create request.</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="wikiIdentifier">- Wiki ID or wiki name.</param>
    /// <param name="pageId">- Wiki page ID.</param>
    abstract addComment: request: Comments.CommentCreateParameters * project: string * wikiIdentifier: string * pageId: float -> Promise<Comments.Comment>
    /// <summary>Delete a comment on a wiki page.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="wikiIdentifier">- Wiki ID or name.</param>
    /// <param name="pageId">- Wiki page ID.</param>
    /// <param name="id">- Comment ID.</param>
    abstract deleteComment: project: string * wikiIdentifier: string * pageId: float * id: float -> Promise<unit>
    /// <summary>Returns a comment associated with the Wiki Page.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="wikiIdentifier">- Wiki ID or wiki name.</param>
    /// <param name="pageId">- Wiki page ID.</param>
    /// <param name="id">- ID of the comment to return.</param>
    /// <param name="excludeDeleted">- Specify if the deleted comment should be skipped.</param>
    /// <param name="expand">- Specifies the additional data retrieval options for comments.</param>
    abstract getComment: project: string * wikiIdentifier: string * pageId: float * id: float * ?excludeDeleted: bool * ?expand: Comments.CommentExpandOptions -> Promise<Comments.Comment>
    /// <summary>Returns a pageable list of comments.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="wikiIdentifier">- Wiki ID or wiki name.</param>
    /// <param name="pageId">- Wiki page ID.</param>
    /// <param name="top">- Max number of comments to return.</param>
    /// <param name="continuationToken">- Used to query for the next page of comments.</param>
    /// <param name="excludeDeleted">- Specify if the deleted comments should be skipped.</param>
    /// <param name="expand">- Specifies the additional data retrieval options for comments.</param>
    /// <param name="order">- Order in which the comments should be returned.</param>
    /// <param name="parentId">- CommentId of the parent comment.</param>
    abstract listComments: project: string * wikiIdentifier: string * pageId: float * ?top: float * ?continuationToken: string * ?excludeDeleted: bool * ?expand: Comments.CommentExpandOptions * ?order: Comments.CommentSortOrder * ?parentId: float -> Promise<Comments.CommentList>
    /// <summary>Update a comment on a wiki page.</summary>
    /// <param name="comment">- Comment update request.</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="wikiIdentifier">- Wiki ID or wiki name.</param>
    /// <param name="pageId">- Wiki page ID.</param>
    /// <param name="id">- Comment ID.</param>
    abstract updateComment: comment: Comments.CommentUpdateParameters * project: string * wikiIdentifier: string * pageId: float * id: float -> Promise<Comments.Comment>
    /// <summary>Gets metadata or content of the wiki page for the provided path. Content negotiation is done based on the \`Accept\` header sent in the request.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="wikiIdentifier">- Wiki ID or wiki name.</param>
    /// <param name="path">- Wiki page path.</param>
    /// <param name="recursionLevel">- Recursion level for subpages retrieval. Defaults to \`None\` (Optional).</param>
    /// <param name="versionDescriptor">- GitVersionDescriptor for the page. Defaults to the default branch (Optional).</param>
    /// <param name="includeContent">- True to include the content of the page in the response for Json content type. Defaults to false (Optional)</param>
    abstract getPageText: project: string * wikiIdentifier: string * ?path: string * ?recursionLevel: Git.VersionControlRecursionType * ?versionDescriptor: Git.GitVersionDescriptor * ?includeContent: bool -> Promise<string>
    /// <summary>Gets metadata or content of the wiki page for the provided path. Content negotiation is done based on the \`Accept\` header sent in the request.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="wikiIdentifier">- Wiki ID or wiki name.</param>
    /// <param name="path">- Wiki page path.</param>
    /// <param name="recursionLevel">- Recursion level for subpages retrieval. Defaults to \`None\` (Optional).</param>
    /// <param name="versionDescriptor">- GitVersionDescriptor for the page. Defaults to the default branch (Optional).</param>
    /// <param name="includeContent">- True to include the content of the page in the response for Json content type. Defaults to false (Optional)</param>
    abstract getPageZip: project: string * wikiIdentifier: string * ?path: string * ?recursionLevel: Git.VersionControlRecursionType * ?versionDescriptor: Git.GitVersionDescriptor * ?includeContent: bool -> Promise<ArrayBuffer>
    /// <summary>Gets metadata or content of the wiki page for the provided page id. Content negotiation is done based on the \`Accept\` header sent in the request.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="wikiIdentifier">- Wiki ID or wiki name..</param>
    /// <param name="id">- Wiki page ID.</param>
    /// <param name="recursionLevel">- Recursion level for subpages retrieval. Defaults to \`None\` (Optional).</param>
    /// <param name="includeContent">- True to include the content of the page in the response for Json content type. Defaults to false (Optional)</param>
    abstract getPageByIdText: project: string * wikiIdentifier: string * id: float * ?recursionLevel: Git.VersionControlRecursionType * ?includeContent: bool -> Promise<string>
    /// <summary>Gets metadata or content of the wiki page for the provided page id. Content negotiation is done based on the \`Accept\` header sent in the request.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="wikiIdentifier">- Wiki ID or wiki name..</param>
    /// <param name="id">- Wiki page ID.</param>
    /// <param name="recursionLevel">- Recursion level for subpages retrieval. Defaults to \`None\` (Optional).</param>
    /// <param name="includeContent">- True to include the content of the page in the response for Json content type. Defaults to false (Optional)</param>
    abstract getPageByIdZip: project: string * wikiIdentifier: string * id: float * ?recursionLevel: Git.VersionControlRecursionType * ?includeContent: bool -> Promise<ArrayBuffer>
    /// <summary>Creates a new page view stats resource or updates an existing page view stats resource.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="wikiIdentifier">- Wiki ID or wiki name.</param>
    /// <param name="wikiVersion">- Wiki version.</param>
    /// <param name="path">- Wiki page path.</param>
    /// <param name="oldPath">- Old page path. This is optional and required to rename path in existing page view stats.</param>
    abstract createOrUpdatePageViewStats: project: string * wikiIdentifier: string * wikiVersion: Git.GitVersionDescriptor * path: string * ?oldPath: string -> Promise<Wiki.WikiPageViewStats>
    /// <summary>Creates the wiki resource.</summary>
    /// <param name="wikiCreateParams">- Parameters for the wiki creation.</param>
    /// <param name="project">- Project ID or project name</param>
    abstract createWiki: wikiCreateParams: Wiki.WikiCreateParametersV2 * ?project: string -> Promise<Wiki.WikiV2>
    /// <summary>Deletes the wiki corresponding to the wiki ID or wiki name provided.</summary>
    /// <param name="wikiIdentifier">- Wiki ID or wiki name.</param>
    /// <param name="project">- Project ID or project name</param>
    abstract deleteWiki: wikiIdentifier: string * ?project: string -> Promise<Wiki.WikiV2>
    /// <summary>Gets all wikis in a project or collection.</summary>
    /// <param name="project">- Project ID or project name</param>
    abstract getAllWikis: ?project: string -> Promise<ResizeArray<Wiki.WikiV2>>
    /// <summary>Gets the wiki corresponding to the wiki ID or wiki name provided.</summary>
    /// <param name="wikiIdentifier">- Wiki ID or wiki name.</param>
    /// <param name="project">- Project ID or project name</param>
    abstract getWiki: wikiIdentifier: string * ?project: string -> Promise<Wiki.WikiV2>
    /// <summary>Updates the wiki corresponding to the wiki ID or wiki name provided using the update parameters.</summary>
    /// <param name="updateParameters">- Update parameters.</param>
    /// <param name="wikiIdentifier">- Wiki ID or wiki name.</param>
    /// <param name="project">- Project ID or project name</param>
    abstract updateWiki: updateParameters: Wiki.WikiUpdateParameters * wikiIdentifier: string * ?project: string -> Promise<Wiki.WikiV2>

type [<AllowNullLiteral>] WikiRestClientStatic =
    [<Emit "new $0($1...)">] abstract Create: options: IVssRestClientOptions -> WikiRestClient
    abstract RESOURCE_AREA_ID: string
