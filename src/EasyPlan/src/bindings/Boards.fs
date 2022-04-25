// ts2fable 0.7.1
module rec Boards
open System
open Fable.Core
open Fable.Core.JS

type [<AllowNullLiteral>] Board =
    inherit BoardReference
    /// Links to other related objects.
    abstract _links: obj option with get, set
    /// Description of the board.
    abstract description: string with get, set

/// Provides properties that describe a column in a board.
type [<AllowNullLiteral>] BoardColumn =
    inherit BoardColumnBase
    /// Links to other related objects.
    abstract _links: obj option with get, set
    /// Id of the resource.
    abstract id: string with get, set
    /// Next column identifier.
    abstract nextColumnId: string with get, set
    /// Full http link to the resource.
    abstract url: string with get, set

/// Provides base properties that describe a column in a board.
type [<AllowNullLiteral>] BoardColumnBase =
    /// Board column description.
    abstract description: string with get, set
    /// Name of the column.
    abstract name: string with get, set

/// Response collection for board column actions.
type [<AllowNullLiteral>] BoardColumnCollectionResponse =
    /// Links to other related objects.
    abstract _links: obj option with get, set
    /// The resulting collection of BoardColumn.
    abstract columns: ResizeArray<BoardColumn> with get, set

/// Describes a column to create on a board.
type [<AllowNullLiteral>] BoardColumnCreate =
    inherit BoardColumnBase
    /// Next column identifier or supported directive: $first or $last.
    abstract nextColumnId: string with get, set

/// INTERNAL. Event that is fired when a column is added.
type [<AllowNullLiteral>] BoardColumnCreatedRealtimeEvent =
    inherit RealtimeBoardEvent
    /// Ids of columns created.
    abstract columnIds: ResizeArray<string> with get, set
    /// The latest ETag for the column.
    abstract eTag: string with get, set
    /// Gets the identifier of the next column.
    abstract nextColumnId: string with get, set

/// Describes a list of columns to create on a board.
type [<AllowNullLiteral>] BoardColumnCreateList =
    /// New columns.
    abstract columns: ResizeArray<BoardColumnBase> with get, set
    /// Next column identifier or supported directive: $first or $last.
    abstract nextColumnId: string with get, set

/// INTERNAL. Event that is fired when a column is deleted.
type [<AllowNullLiteral>] BoardColumnDeletedRealtimeEvent =
    inherit RealtimeBoardEvent
    /// Gets the column identifier.
    abstract columnId: string with get, set

/// Response for board column actions.
type [<AllowNullLiteral>] BoardColumnResponse =
    /// The resulting BoardColumn.
    abstract column: BoardColumn with get, set
    /// The last change date and time for all the columns in the collection.
    abstract eTag: ResizeArray<string> with get, set

/// Describes a column to update on a board.
type [<AllowNullLiteral>] BoardColumnUpdate =
    inherit BoardColumnCreate
    /// Name of the column.
    abstract name: string with get, set

/// INTERNAL. Event that is fired when a column is updated.
type [<AllowNullLiteral>] BoardColumnUpdatedRealtimeEvent =
    inherit RealtimeBoardEvent
    /// Gets the column identifier.
    abstract columnId: string with get, set
    /// The latest ETag for the column.
    abstract eTag: string with get, set
    /// Gets the identifier of the next column.
    abstract nextColumnId: string with get, set

/// Provides properties that describe an item in a board.
type [<AllowNullLiteral>] BoardItem =
    inherit BoardItemReference
    /// Links to other related objects.
    abstract _links: obj option with get, set
    /// Board id for this item.
    abstract boardId: float with get, set
    /// Board column id for this item.
    abstract columnId: string with get, set
    /// Next board item id.
    abstract nextId: string with get, set
    /// Board row id for this item.
    abstract rowId: string with get, set
    /// Error that occurred related to the source data for this item.
    abstract sourceErrorMessages: ResizeArray<string> with get, set
    /// Indicates whether a change has occurred requiring a refresh of the source data for this item.
    abstract sourceRefreshRequired: bool with get, set

/// Describe the action to apply when an item is moved to a column and the specified condition is met.
type [<AllowNullLiteral>] BoardItemAction =
    inherit PredicateAndAction
    /// Action Id.
    abstract id: string with get, set
    /// Item type.
    abstract itemType: string with get, set

/// Describes a board item action to create on a board.
type [<AllowNullLiteral>] BoardItemActionCreate =
    inherit PredicateAndAction
    /// Item Type.
    abstract itemType: string with get, set

/// Describes a board item action to update on a board.
type [<AllowNullLiteral>] BoardItemActionUpdate =
    /// Action to execute. e.g. Change state
    abstract action: string with get, set
    /// Condition to meet before applying action.
    abstract predicate: string with get, set

/// INTERNAL. Event that is fired when a board item is added.
type [<AllowNullLiteral>] BoardItemAddedRealtimeEvent =
    inherit RealtimeBoardEvent
    /// The column id where the item was added.
    abstract columnId: string with get, set
    /// The latest eTag for the item.
    abstract eTag: string with get, set
    /// The id of the added item.
    abstract id: string with get, set
    /// The id of the added item
    abstract itemSourceId: string with get, set
    /// The type of the added item
    abstract itemType: string with get, set
    /// The id of the next item in the list.
    abstract nextId: string with get, set
    /// The row id where the item was added.
    abstract rowId: string with get, set

/// Data to perform an operation on a batch of board items.
type [<AllowNullLiteral>] BoardItemBatchOperation =
    /// The data needed to perform the operation. This is optional based on the type of the operation.
    abstract data: UpdateBoardItem with get, set
    /// The list of items with etags to perform the operation on.
    abstract items: ResizeArray<BoardItemIdAndEtag> with get, set
    /// Operation to perform.
    abstract operation: BoardItemBatchOperationTypeEnum with get, set

type [<RequireQualifiedAccess>] BoardItemBatchOperationTypeEnum =
    | Reorder = 1

/// Response collection for board items actions.
type [<AllowNullLiteral>] BoardItemCollectionResponse =
    /// Links to other related objects.
    abstract _links: obj option with get, set
    /// The resulting collection of BoardItem.
    abstract items: ResizeArray<BoardItem> with get, set

/// Board Item id and etag pair.
type [<AllowNullLiteral>] BoardItemIdAndEtag =
    /// Board Item's etag.
    abstract eTag: string with get, set
    /// Board Item's id.
    abstract id: string with get, set

/// INTERNAL. Event that is fired when a board item moves.
type [<AllowNullLiteral>] BoardItemMovedRealtimeEvent =
    inherit RealtimeBoardEvent
    /// The column id where the item was moved.
    abstract columnId: string with get, set
    /// The latest eTag for the items.
    abstract eTag: string with get, set
    /// The ids of the moved item.
    abstract ids: ResizeArray<string> with get, set
    /// The id of the next item in the list.
    abstract nextId: string with get, set
    /// The row id where the item was moved.
    abstract rowId: string with get, set

type [<AllowNullLiteral>] BoardItemReference =
    inherit BoardItemSourceIdAndType
    /// Board item identifier. Unique for each item in the board.
    abstract id: string with get, set
    /// Full http link to the resource.
    abstract url: string with get, set

/// INTERNAL. Event that is fired when a board item is removed.
type [<AllowNullLiteral>] BoardItemRemovedRealtimeEvent =
    inherit RealtimeBoardEvent
    /// The id of the removed item.
    abstract id: string with get, set

/// Provides a response for board item actions.
type [<AllowNullLiteral>] BoardItemResponse =
    /// The last changed date for the board item.
    abstract eTag: ResizeArray<string> with get, set
    /// The resulting BoardItem.
    abstract item: BoardItem with get, set

/// Provides properties that describe an item's source identifier and type in a board.
type [<AllowNullLiteral>] BoardItemSourceIdAndType =
    /// Item id.
    abstract itemSourceId: string with get, set
    /// Item type.
    abstract itemType: string with get, set

/// Describe a two way sync from moving item on board OR from changing state of item outside of the board.
type [<AllowNullLiteral>] BoardItemStateSync =
    inherit SubTypeAndStateValue
    /// Sync Id.
    abstract id: string with get, set
    /// Item type.
    abstract itemType: string with get, set

/// Describes a board item state sync to create on a board.
type [<AllowNullLiteral>] BoardItemStateSyncCreate =
    inherit SubTypeAndStateValue
    /// The Item type.
    abstract itemType: string with get, set

/// Describes a board item state sync to update on a board.
type [<AllowNullLiteral>] BoardItemStateSyncUpdate =
    /// The state value that will be synced to.
    abstract stateValue: string with get, set
    /// The sub-type that will be set for sync, for example, 'User Story' for work item.
    abstract subType: string with get, set

type [<AllowNullLiteral>] BoardReference =
    inherit EntityReference
    /// Id of the resource.
    abstract id: float with get, set

/// Response for board column actions.
type [<AllowNullLiteral>] BoardResponse =
    /// The resulting Board.
    abstract board: Board with get, set
    /// The last date and time the board was changed.
    abstract eTag: ResizeArray<string> with get, set

/// Provides properties that describe a row in a board.
type [<AllowNullLiteral>] BoardRow =
    inherit BoardRowBase
    /// Links to other related objects.
    abstract _links: obj option with get, set
    /// Id of the resource.
    abstract id: string with get, set
    /// Next row identifier.
    abstract nextRowId: string with get, set
    /// Full http link to the resource.
    abstract url: string with get, set

/// Provides properties that describe a row in a board.
type [<AllowNullLiteral>] BoardRowBase =
    /// Row name.
    abstract name: string with get, set

/// Response collection for board row actions.
type [<AllowNullLiteral>] BoardRowCollectionResponse =
    /// Links to other related objects.
    abstract _links: obj option with get, set
    /// The resulting collection of BoardRow.
    abstract rows: ResizeArray<BoardRow> with get, set

/// Describes a row to create on a board.
type [<AllowNullLiteral>] BoardRowCreate =
    inherit BoardRowBase
    /// Next row identifier or supported directive: $first or $last.
    abstract nextRowId: string with get, set

/// Describes a list of rows to create on a board.
type [<AllowNullLiteral>] BoardRowCreateList =
    /// Next row identifier or supported directive: $first or $last.
    abstract nextRowId: string with get, set
    /// New rows.
    abstract rows: ResizeArray<BoardRowBase> with get, set

/// Response for board row actions.
type [<AllowNullLiteral>] BoardRowResponse =
    /// The last change date and time for all the rows in the collection.
    abstract eTag: ResizeArray<string> with get, set
    /// The resulting collection of BoardRow.
    abstract row: BoardRow with get, set

/// Describes a row to update on a board.
type [<AllowNullLiteral>] BoardRowUpdate =
    inherit BoardRowCreate

type [<RequireQualifiedAccess>] BoardTypeEnum =
    | IdBoundBoard = 1
    | QueryBoundBoard = 2
    | KanbanBoard = 3
    | TaskBoard = 4

type [<AllowNullLiteral>] CreateBoard =
    /// Description of the board.
    abstract description: string with get, set
    /// Name of the board to create.
    abstract name: string with get, set

type [<AllowNullLiteral>] EntityReference =
    /// Name of the resource.
    abstract name: string with get, set
    /// Full http link to the resource.
    abstract url: string with get, set

type [<AllowNullLiteral>] NewBoardItem =
    inherit BoardItemSourceIdAndType
    /// Board column identifier.
    abstract columnId: string with get, set
    /// Next board item id or supported directive: $first or $last.
    abstract nextId: string with get, set
    /// Board row identifier.
    abstract rowId: string with get, set

/// Response containing ETag header with no content
type [<AllowNullLiteral>] NoContentResponse =
    /// The place holder to stop genclient from creating invalid client code
    abstract data: obj option with get, set
    /// The last change date and time for all the rows/columns in the collection.
    abstract eTag: ResizeArray<string> with get, set

type [<AllowNullLiteral>] PredicateAndAction =
    /// Action to execute. e.g. Change state
    abstract action: string with get, set
    /// Condition to meet before applying action.
    abstract predicate: string with get, set

/// Base type for real time board events. All board events should inherit from this class.
type [<AllowNullLiteral>] RealtimeBoardEvent =
    /// The Board ID of the event
    abstract boardId: float with get, set
    /// A unique ID for events, used for logging and tracing.
    abstract eventId: string with get, set
    /// The Project ID of the board.
    abstract projectId: string with get, set
    /// The type of this event, so the client can disambiguate
    abstract ``type``: string with get, set

type [<AllowNullLiteral>] SubTypeAndStateValue =
    /// The state value that will be synced to.
    abstract stateValue: string with get, set
    /// The sub-type that will be set for sync, for example, 'User Story' for work item.
    abstract subType: string with get, set

type [<AllowNullLiteral>] UpdateBoard =
    /// New description of the board.
    abstract description: string with get, set
    /// New name of the board.
    abstract name: string with get, set

type [<AllowNullLiteral>] UpdateBoardItem =
    /// Board column identifier.
    abstract columnId: string with get, set
    /// Next board item id or supported directive: $first or $last.
    abstract nextId: string with get, set
    /// Board row identifier.
    abstract rowId: string with get, set

/// List of items to update in the board.
type [<AllowNullLiteral>] UpdateBoardItemList =
    inherit UpdateBoardItem
    /// List of items by id and etag.
    abstract items: ResizeArray<BoardItemIdAndEtag> with get, set
