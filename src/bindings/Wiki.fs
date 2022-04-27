// ts2fable 0.7.1
module rec Wiki
open System
open Fable.Core
open Fable.Core.JS

/// Defines a wiki repository which encapsulates the git repository backing the wiki.
type [<AllowNullLiteral>] Wiki =
    inherit WikiCreateParameters
    /// The head commit associated with the git repository backing up the wiki.
    abstract headCommit: string with get, set
    /// The ID of the wiki which is same as the ID of the Git repository that it is backed by.
    abstract id: string with get, set
    /// The git repository that backs up the wiki.
    abstract repository: Git.GitRepository with get, set

/// Defines properties for wiki attachment file.
type [<AllowNullLiteral>] WikiAttachment =
    /// Name of the wiki attachment file.
    abstract name: string with get, set
    /// Path of the wiki attachment file.
    abstract path: string with get, set

/// Response contract for the Wiki Attachments API
type [<AllowNullLiteral>] WikiAttachmentResponse =
    /// Defines properties for wiki attachment file.
    abstract attachment: WikiAttachment with get, set
    /// Contains the list of ETag values from the response header of the attachments API call. The first item in the list contains the version of the wiki attachment.
    abstract eTag: ResizeArray<string> with get, set

/// Base wiki creation parameters.
type [<AllowNullLiteral>] WikiCreateBaseParameters =
    /// Folder path inside repository which is shown as Wiki. Not required for ProjectWiki type.
    abstract mappedPath: string with get, set
    /// Wiki name.
    abstract name: string with get, set
    /// ID of the project in which the wiki is to be created.
    abstract projectId: string with get, set
    /// ID of the git repository that backs up the wiki. Not required for ProjectWiki type.
    abstract repositoryId: string with get, set
    /// Type of the wiki.
    abstract ``type``: WikiType with get, set

/// Wiki creations parameters.
type [<AllowNullLiteral>] WikiCreateParameters =
    /// Wiki name.
    abstract name: string with get, set
    /// ID of the project in which the wiki is to be created.
    abstract projectId: string with get, set

/// Wiki creation parameters.
type [<AllowNullLiteral>] WikiCreateParametersV2 =
    inherit WikiCreateBaseParameters
    /// Version of the wiki. Not required for ProjectWiki type.
    abstract version: Git.GitVersionDescriptor with get, set

/// Defines a page in a wiki.
type [<AllowNullLiteral>] WikiPage =
    inherit WikiPageCreateOrUpdateParameters
    /// Path of the git item corresponding to the wiki page stored in the backing Git repository.
    abstract gitItemPath: string with get, set
    /// When present, permanent identifier for the wiki page
    abstract id: int with get, set
    /// True if a page is non-conforming, i.e. 1) if the name doesn't match page naming standards. 2) if the page does not have a valid entry in the appropriate order file.
    abstract isNonConformant: bool with get, set
    /// True if this page has subpages under its path.
    abstract isParentPage: bool with get, set
    /// Order of the wiki page, relative to other pages in the same hierarchy level.
    abstract order: int with get, set
    /// Path of the wiki page.
    abstract path: string with get, set
    /// Remote web url to the wiki page.
    abstract remoteUrl: string with get, set
    /// List of subpages of the current page.
    abstract subPages: ResizeArray<WikiPage> with get, set
    /// REST url for this wiki page.
    abstract url: string with get, set

/// Contract encapsulating parameters for the page create or update operations.
type [<AllowNullLiteral>] WikiPageCreateOrUpdateParameters =
    /// Content of the wiki page.
    abstract content: string with get, set

/// Request contract for Wiki Page Move.
type [<AllowNullLiteral>] WikiPageMove =
    inherit WikiPageMoveParameters
    /// Resultant page of this page move operation.
    abstract page: WikiPage with get, set

/// Contract encapsulating parameters for the page move operation.
type [<AllowNullLiteral>] WikiPageMoveParameters =
    /// New order of the wiki page.
    abstract newOrder: int with get, set
    /// New path of the wiki page.
    abstract newPath: string with get, set
    /// Current path of the wiki page.
    abstract path: string with get, set

/// Response contract for the Wiki Page Move API.
type [<AllowNullLiteral>] WikiPageMoveResponse =
    /// Contains the list of ETag values from the response header of the page move API call. The first item in the list contains the version of the wiki page subject to page move.
    abstract eTag: ResizeArray<string> with get, set
    /// Defines properties for wiki page move.
    abstract pageMove: WikiPageMove with get, set

/// Response contract for the Wiki Pages PUT, PATCH and DELETE APIs.
type [<AllowNullLiteral>] WikiPageResponse =
    /// Contains the list of ETag values from the response header of the pages API call. The first item in the list contains the version of the wiki page.
    abstract eTag: ResizeArray<string> with get, set
    /// Defines properties for wiki page.
    abstract page: WikiPage with get, set

/// Defines properties for wiki page view stats.
type [<AllowNullLiteral>] WikiPageViewStats =
    /// Wiki page view count.
    abstract count: int with get, set
    /// Wiki page last viewed time.
    abstract lastViewedTime: DateTime with get, set
    /// Wiki page path.
    abstract path: string with get, set

type [<RequireQualifiedAccess>] WikiType =
    | ProjectWiki = 0
    | CodeWiki = 1

type [<AllowNullLiteral>] WikiUpdatedNotificationMessage =
    /// Collection host Id for which the wikis are updated.
    abstract collectionId: string with get, set
    /// Project Id for which the wikis are updated.
    abstract projectId: string with get, set
    /// Repository Id associated with the particular wiki which is added, updated or deleted.
    abstract repositoryId: string with get, set

/// Wiki update parameters.
type [<AllowNullLiteral>] WikiUpdateParameters =
    /// Name for wiki.
    abstract name: string with get, set
    /// Versions of the wiki.
    abstract versions: ResizeArray<Git.GitVersionDescriptor> with get, set

/// Defines a wiki resource.
type [<AllowNullLiteral>] WikiV2 =
    inherit WikiCreateBaseParameters
    /// ID of the wiki.
    abstract id: string with get, set
    /// Properties of the wiki.
    abstract properties: WikiV2Properties with get, set
    /// Remote web url to the wiki.
    abstract remoteUrl: string with get, set
    /// REST url for this wiki.
    abstract url: string with get, set
    /// Versions of the wiki.
    abstract versions: ResizeArray<Git.GitVersionDescriptor> with get, set

type [<AllowNullLiteral>] WikiV2Properties =
    [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> string with get, set
