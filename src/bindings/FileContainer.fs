// ts2fable 0.7.1
module rec FileContainer
open System
open Fable.Core
open Fable.Core.JS

type [<RequireQualifiedAccess>] ContainerItemStatus =
    | Created = 1
    | PendingUpload = 2

type [<RequireQualifiedAccess>] ContainerItemType =
    | Any = 0
    | Folder = 1
    | File = 2

type [<RequireQualifiedAccess>] ContainerOptions =
    | None = 0

/// Represents a container that encapsulates a hierarchical file system.
type [<AllowNullLiteral>] FileContainer =
    /// Uri of the artifact associated with the container.
    abstract artifactUri: string with get, set
    /// Download Url for the content of this item.
    abstract contentLocation: string with get, set
    /// Owner.
    abstract createdBy: string with get, set
    /// Creation date.
    abstract dateCreated: DateTime with get, set
    /// Description.
    abstract description: string with get, set
    /// Id.
    abstract id: float with get, set
    /// Location of the item resource.
    abstract itemLocation: string with get, set
    /// ItemStore Locator for this container.
    abstract locatorPath: string with get, set
    /// Name.
    abstract name: string with get, set
    /// Options the container can have.
    abstract options: ContainerOptions with get, set
    /// Project Id.
    abstract scopeIdentifier: string with get, set
    /// Security token of the artifact associated with the container.
    abstract securityToken: string with get, set
    /// Identifier of the optional encryption key.
    abstract signingKeyId: string with get, set
    /// Total size of the files in bytes.
    abstract size: float with get, set

/// Represents an item in a container.
type [<AllowNullLiteral>] FileContainerItem =
    /// Container Id.
    abstract containerId: float with get, set
    abstract contentId: ResizeArray<float> with get, set
    /// Download Url for the content of this item.
    abstract contentLocation: string with get, set
    /// Creator.
    abstract createdBy: string with get, set
    /// Creation date.
    abstract dateCreated: DateTime with get, set
    /// Last modified date.
    abstract dateLastModified: DateTime with get, set
    /// Encoding of the file. Zero if not a file.
    abstract fileEncoding: float with get, set
    /// Hash value of the file. Null if not a file.
    abstract fileHash: ResizeArray<float> with get, set
    /// Id of the file content.
    abstract fileId: float with get, set
    /// Length of the file. Zero if not of a file.
    abstract fileLength: float with get, set
    /// Type of the file. Zero if not a file.
    abstract fileType: float with get, set
    /// Location of the item resource.
    abstract itemLocation: string with get, set
    /// Type of the item: Folder, File or String.
    abstract itemType: ContainerItemType with get, set
    /// Modifier.
    abstract lastModifiedBy: string with get, set
    /// Unique path that identifies the item.
    abstract path: string with get, set
    /// Project Id.
    abstract scopeIdentifier: string with get, set
    /// Status of the item: Created or Pending Upload.
    abstract status: ContainerItemStatus with get, set
    abstract ticket: string with get, set
