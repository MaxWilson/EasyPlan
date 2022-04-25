// ts2fable 0.7.1
module rec BoardsClient
open System
open Fable.Core
open Fable.Core.JS

type IVssRestClientOptions = Context.IVssRestClientOptions
type RestClientBase = RestClientBase.RestClientBase

type [<AllowNullLiteral>] IExports =
    abstract BoardsRestClient: BoardsRestClientStatic

type [<AllowNullLiteral>] BoardsRestClient =
    inherit RestClientBase
    /// <summary>Add a new board for the project.</summary>
    /// <param name="postedBoard">- Board definition.</param>
    /// <param name="project">- Project ID or project name</param>
    abstract createBoard: postedBoard: Boards.CreateBoard * project: string -> Promise<Boards.BoardResponse>
    /// <summary>Deletes a board.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="id">- Board identifier.</param>
    abstract deleteBoard: project: string * id: float -> Promise<unit>
    /// <summary>Returns information for a board given its unique identifier.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="id">- Board's unique identifier.</param>
    abstract getBoard: project: string * id: float -> Promise<Boards.BoardResponse>
    /// <summary>Get boards.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="top">- The maximum number of boards to get.</param>
    /// <param name="skip">- The number of boards to skip.</param>
    abstract getBoards: project: string * ?top: float * ?skip: float -> Promise<ResizeArray<Boards.BoardReference>>
    /// <summary>Updates a board.</summary>
    /// <param name="updatedBoard">- New board data.</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="id">- Id of the board to update.</param>
    /// <param name="eTag">- Board Latest Changed Date</param>
    abstract updateBoard: updatedBoard: Boards.UpdateBoard * project: string * id: float * eTag: String -> Promise<Boards.BoardResponse>
    /// <summary>Creates a new column on a board.</summary>
    /// <param name="boardColumn">- Column data.</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="board">- Board identifier.</param>
    abstract createBoardColumn: boardColumn: Boards.BoardColumnCreate * project: string * board: float -> Promise<Boards.BoardColumnResponse>
    /// <summary>Deletes a column from a board.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="board">- Board identifier.</param>
    /// <param name="id">- Column identifier.</param>
    /// <param name="forceRemoveItems">- Boolean indicating if items are to be force removed during the column delete.</param>
    abstract deleteBoardColumn: project: string * board: float * id: string * forceRemoveItems: bool -> Promise<unit>
    /// <summary>Gets column data for a board given its identifier.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="board">- Board identifier.</param>
    /// <param name="id">- Column identifier.</param>
    abstract getBoardColumn: project: string * board: float * id: string -> Promise<Boards.BoardColumnResponse>
    /// <summary>Get columns in a board.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="board">- Board identifier.</param>
    abstract getBoardColumns: project: string * board: float -> Promise<Boards.BoardColumnCollectionResponse>
    /// <summary>Updates a board column.</summary>
    /// <param name="boardColumn">- Column data.</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="board">- Board identifier.</param>
    /// <param name="id">- Column identifier.</param>
    /// <param name="eTag">- Column Latest Changed Date</param>
    abstract updateBoardColumn: boardColumn: Boards.BoardColumnUpdate * project: string * board: float * id: string * eTag: String -> Promise<Boards.BoardColumnResponse>
    /// <summary>Adds a single item to a board.</summary>
    /// <param name="item">- Item to add to the board.</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="board">- Board identifier.</param>
    abstract addBoardItem: item: Boards.NewBoardItem * project: string * board: float -> Promise<Boards.BoardItemResponse>
    /// <summary>Gets data for a single board's item.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="board">- Board identifier.</param>
    /// <param name="id">- Item identifier.</param>
    abstract getBoardItem: project: string * board: float * id: string -> Promise<Boards.BoardItemResponse>
    /// <summary>Get items information for a board given its identifier.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="board">- Board identifier.</param>
    abstract getBoardItems: project: string * board: float -> Promise<Boards.BoardItemCollectionResponse>
    /// <summary>Removes an item from a board.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="board">- Board identifier.</param>
    /// <param name="id">- Board Item identifier to remove.</param>
    abstract removeBoardItem: project: string * board: float * id: string -> Promise<unit>
    /// <summary>Updates a single item in a board.</summary>
    /// <param name="updateItemDef">- Updated item data.</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="board">- Board identifier.</param>
    /// <param name="id">- Update item id.</param>
    /// <param name="eTag">- Item Latest Changed Date</param>
    abstract updateBoardItem: updateItemDef: Boards.UpdateBoardItem * project: string * board: float * id: string * eTag: String -> Promise<Boards.BoardItemResponse>
    /// <summary>Do an operation on a batch of items.</summary>
    /// <param name="batchRequest">- Data defining the batch operation.</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="board">- The id of the board containing the items.</param>
    abstract updateBoardItems: batchRequest: Boards.BoardItemBatchOperation * project: string * board: float -> Promise<Boards.BoardItemCollectionResponse>
    /// <summary>Creates a new row on a board.</summary>
    /// <param name="boardRow">- Row data.</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="board">- Board identifier.</param>
    abstract createBoardRow: boardRow: Boards.BoardRowCreate * project: string * board: float -> Promise<Boards.BoardRowResponse>
    /// <summary>Deletes a row from a board.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="board">- Board identifier.</param>
    /// <param name="id">- Row identifier.</param>
    /// <param name="forceRemoveItems">- Boolean indicating if items are to be force removed during the row delete.</param>
    abstract deleteBoardRow: project: string * board: float * id: string * forceRemoveItems: bool -> Promise<unit>
    /// <summary>Gets a row given its identifier and board.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="board">- Board identifier.</param>
    /// <param name="id">- Board row identifier.</param>
    abstract getBoardRow: project: string * board: float * id: string -> Promise<Boards.BoardRowResponse>
    /// <summary>Get rows in a board given its identifier.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="board">- Board identifier.</param>
    abstract getBoardRows: project: string * board: float -> Promise<Boards.BoardRowCollectionResponse>
    /// <summary>Updates a board row.</summary>
    /// <param name="boardRow">- Row data.</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="board">- Board identifier.</param>
    /// <param name="id">- Row identifier.</param>
    /// <param name="eTag">- Row Latest Changed Date</param>
    abstract updateBoardRow: boardRow: Boards.BoardRowUpdate * project: string * board: float * id: string * eTag: String -> Promise<Boards.BoardRowResponse>
    /// <summary>Creates a new sync for a column on a board.</summary>
    /// <param name="boardSync">-</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="board">-</param>
    /// <param name="column">-</param>
    abstract createBoardSyncAction: boardSync: Boards.BoardItemStateSyncCreate * project: string * board: float * column: string -> Promise<Boards.BoardItemStateSync>

type [<AllowNullLiteral>] BoardsRestClientStatic =
    [<Emit "new $0($1...)">] abstract Create: options: IVssRestClientOptions -> BoardsRestClient
    abstract RESOURCE_AREA_ID: string
