// ts2fable 0.7.1
module rec WorkClient
open System
open Fable.Core
open Fable.Core.JS

type IVssRestClientOptions = Context.IVssRestClientOptions
type RestClientBase = RestClientBase.RestClientBase

type [<AllowNullLiteral>] IExports =
    abstract WorkRestClient: WorkRestClientStatic

type [<AllowNullLiteral>] WorkRestClient =
    inherit RestClientBase
    /// <summary>Gets backlog configuration for a team</summary>
    /// <param name="teamContext">- The team context for the operation</param>
    abstract getBacklogConfigurations: teamContext: Core.TeamContext -> Promise<Work.BacklogConfiguration>
    /// <summary>Get a list of work items within a backlog level</summary>
    /// <param name="teamContext">- The team context for the operation</param>
    /// <param name="backlogId">-</param>
    abstract getBacklogLevelWorkItems: teamContext: Core.TeamContext * backlogId: string -> Promise<Work.BacklogLevelWorkItems>
    /// <summary>Get a backlog level</summary>
    /// <param name="teamContext">- The team context for the operation</param>
    /// <param name="id">- The id of the backlog level</param>
    abstract getBacklog: teamContext: Core.TeamContext * id: string -> Promise<Work.BacklogLevelConfiguration>
    /// <summary>List all backlog levels</summary>
    /// <param name="teamContext">- The team context for the operation</param>
    abstract getBacklogs: teamContext: Core.TeamContext -> Promise<ResizeArray<Work.BacklogLevelConfiguration>>
    /// <summary>Gets a badge that displays the status of columns on the board.</summary>
    /// <param name="teamContext">- The team context for the operation</param>
    /// <param name="id">- The id of the board.</param>
    /// <param name="columnOptions">- Determines what columns to show.</param>
    /// <param name="columns">- If columnOptions is set to custom, specify the list of column names.</param>
    abstract getBoardBadge: teamContext: Core.TeamContext * id: string * ?columnOptions: Work.BoardBadgeColumnOptions * ?columns: ResizeArray<string> -> Promise<Work.BoardBadge>
    /// <summary>Gets a badge that displays the status of columns on the board.</summary>
    /// <param name="teamContext">- The team context for the operation</param>
    /// <param name="id">- The id of the board.</param>
    /// <param name="columnOptions">- Determines what columns to show.</param>
    /// <param name="columns">- If columnOptions is set to custom, specify the list of column names.</param>
    abstract getBoardBadgeData: teamContext: Core.TeamContext * id: string * ?columnOptions: Work.BoardBadgeColumnOptions * ?columns: ResizeArray<string> -> Promise<string>
    /// <summary>Get available board columns in a project</summary>
    /// <param name="project">- Project ID or project name</param>
    abstract getColumnSuggestedValues: ?project: string -> Promise<ResizeArray<Work.BoardSuggestedValue>>
    /// <summary>Returns the list of parent field filter model for the given list of workitem ids</summary>
    /// <param name="teamContext">- The team context for the operation</param>
    /// <param name="childBacklogContextCategoryRefName">-</param>
    /// <param name="workitemIds">-</param>
    abstract getBoardMappingParentItems: teamContext: Core.TeamContext * childBacklogContextCategoryRefName: string * workitemIds: ResizeArray<float> -> Promise<ResizeArray<Work.ParentChildWIMap>>
    /// <summary>Get available board rows in a project</summary>
    /// <param name="project">- Project ID or project name</param>
    abstract getRowSuggestedValues: ?project: string -> Promise<ResizeArray<Work.BoardSuggestedValue>>
    /// <summary>Get board</summary>
    /// <param name="teamContext">- The team context for the operation</param>
    /// <param name="id">- identifier for board, either board's backlog level name (Eg:"Stories") or Id</param>
    abstract getBoard: teamContext: Core.TeamContext * id: string -> Promise<Work.Board>
    /// <summary>Get boards</summary>
    /// <param name="teamContext">- The team context for the operation</param>
    abstract getBoards: teamContext: Core.TeamContext -> Promise<ResizeArray<Work.BoardReference>>
    /// <summary>Update board options</summary>
    /// <param name="options">- options to updated</param>
    /// <param name="teamContext">- The team context for the operation</param>
    /// <param name="id">- identifier for board, either category plural name (Eg:"Stories") or guid</param>
    abstract setBoardOptions: options: WorkRestClientSetBoardOptionsOptions * teamContext: Core.TeamContext * id: string -> Promise<WorkRestClientSetBoardOptionsPromise>
    /// <summary>Get board user settings for a board id</summary>
    /// <param name="teamContext">- The team context for the operation</param>
    /// <param name="board">- Board ID or Name</param>
    abstract getBoardUserSettings: teamContext: Core.TeamContext * board: string -> Promise<Work.BoardUserSettings>
    /// <summary>Update board user settings for the board id</summary>
    /// <param name="boardUserSettings">-</param>
    /// <param name="teamContext">- The team context for the operation</param>
    /// <param name="board">-</param>
    abstract updateBoardUserSettings: boardUserSettings: WorkRestClientUpdateBoardUserSettingsBoardUserSettings * teamContext: Core.TeamContext * board: string -> Promise<Work.BoardUserSettings>
    /// <summary>Get a team's capacity</summary>
    /// <param name="teamContext">- The team context for the operation</param>
    /// <param name="iterationId">- ID of the iteration</param>
    abstract getCapacitiesWithIdentityRef: teamContext: Core.TeamContext * iterationId: string -> Promise<ResizeArray<Work.TeamMemberCapacityIdentityRef>>
    /// <summary>Get a team member's capacity</summary>
    /// <param name="teamContext">- The team context for the operation</param>
    /// <param name="iterationId">- ID of the iteration</param>
    /// <param name="teamMemberId">- ID of the team member</param>
    abstract getCapacityWithIdentityRef: teamContext: Core.TeamContext * iterationId: string * teamMemberId: string -> Promise<Work.TeamMemberCapacityIdentityRef>
    /// <summary>Replace a team's capacity</summary>
    /// <param name="capacities">- Team capacity to replace</param>
    /// <param name="teamContext">- The team context for the operation</param>
    /// <param name="iterationId">- ID of the iteration</param>
    abstract replaceCapacitiesWithIdentityRef: capacities: ResizeArray<Work.TeamMemberCapacityIdentityRef> * teamContext: Core.TeamContext * iterationId: string -> Promise<ResizeArray<Work.TeamMemberCapacityIdentityRef>>
    /// <summary>Update a team member's capacity</summary>
    /// <param name="patch">- Updated capacity</param>
    /// <param name="teamContext">- The team context for the operation</param>
    /// <param name="iterationId">- ID of the iteration</param>
    /// <param name="teamMemberId">- ID of the team member</param>
    abstract updateCapacityWithIdentityRef: patch: Work.CapacityPatch * teamContext: Core.TeamContext * iterationId: string * teamMemberId: string -> Promise<Work.TeamMemberCapacityIdentityRef>
    /// <summary>Get board card Rule settings for the board id or board by name</summary>
    /// <param name="teamContext">- The team context for the operation</param>
    /// <param name="board">-</param>
    abstract getBoardCardRuleSettings: teamContext: Core.TeamContext * board: string -> Promise<Work.BoardCardRuleSettings>
    /// <summary>Update board card Rule settings for the board id or board by name</summary>
    /// <param name="boardCardRuleSettings">-</param>
    /// <param name="teamContext">- The team context for the operation</param>
    /// <param name="board">-</param>
    abstract updateBoardCardRuleSettings: boardCardRuleSettings: Work.BoardCardRuleSettings * teamContext: Core.TeamContext * board: string -> Promise<Work.BoardCardRuleSettings>
    /// <summary>Update taskboard card Rule settings</summary>
    /// <param name="boardCardRuleSettings">-</param>
    /// <param name="teamContext">- The team context for the operation</param>
    abstract updateTaskboardCardRuleSettings: boardCardRuleSettings: Work.BoardCardRuleSettings * teamContext: Core.TeamContext -> Promise<unit>
    /// <summary>Get board card settings for the board id or board by name</summary>
    /// <param name="teamContext">- The team context for the operation</param>
    /// <param name="board">-</param>
    abstract getBoardCardSettings: teamContext: Core.TeamContext * board: string -> Promise<Work.BoardCardSettings>
    /// <summary>Update board card settings for the board id or board by name</summary>
    /// <param name="boardCardSettingsToSave">-</param>
    /// <param name="teamContext">- The team context for the operation</param>
    /// <param name="board">-</param>
    abstract updateBoardCardSettings: boardCardSettingsToSave: Work.BoardCardSettings * teamContext: Core.TeamContext * board: string -> Promise<Work.BoardCardSettings>
    /// <summary>Update taskboard card settings</summary>
    /// <param name="boardCardSettingsToSave">-</param>
    /// <param name="teamContext">- The team context for the operation</param>
    abstract updateTaskboardCardSettings: boardCardSettingsToSave: Work.BoardCardSettings * teamContext: Core.TeamContext -> Promise<unit>
    /// <summary>Get a board chart</summary>
    /// <param name="teamContext">- The team context for the operation</param>
    /// <param name="board">- Identifier for board, either board's backlog level name (Eg:"Stories") or Id</param>
    /// <param name="name">- The chart name</param>
    abstract getBoardChart: teamContext: Core.TeamContext * board: string * name: string -> Promise<Work.BoardChart>
    /// <summary>Get board charts</summary>
    /// <param name="teamContext">- The team context for the operation</param>
    /// <param name="board">- Identifier for board, either board's backlog level name (Eg:"Stories") or Id</param>
    abstract getBoardCharts: teamContext: Core.TeamContext * board: string -> Promise<ResizeArray<Work.BoardChartReference>>
    /// <summary>Update a board chart</summary>
    /// <param name="chart">-</param>
    /// <param name="teamContext">- The team context for the operation</param>
    /// <param name="board">- Identifier for board, either board's backlog level name (Eg:"Stories") or Id</param>
    /// <param name="name">- The chart name</param>
    abstract updateBoardChart: chart: Work.BoardChart * teamContext: Core.TeamContext * board: string * name: string -> Promise<Work.BoardChart>
    /// <summary>Get columns on a board</summary>
    /// <param name="teamContext">- The team context for the operation</param>
    /// <param name="board">- Name or ID of the specific board</param>
    abstract getBoardColumns: teamContext: Core.TeamContext * board: string -> Promise<ResizeArray<Work.BoardColumn>>
    /// <summary>Update columns on a board</summary>
    /// <param name="boardColumns">- List of board columns to update</param>
    /// <param name="teamContext">- The team context for the operation</param>
    /// <param name="board">- Name or ID of the specific board</param>
    abstract updateBoardColumns: boardColumns: ResizeArray<Work.BoardColumn> * teamContext: Core.TeamContext * board: string -> Promise<ResizeArray<Work.BoardColumn>>
    /// <summary>Get Delivery View Data</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="id">- Identifier for delivery view</param>
    /// <param name="revision">- Revision of the plan for which you want data. If the current plan is a different revision you will get an ViewRevisionMismatchException exception. If you do not supply a revision you will get data for the latest revision.</param>
    /// <param name="startDate">- The start date of timeline</param>
    /// <param name="endDate">- The end date of timeline</param>
    abstract getDeliveryTimelineData: project: string * id: string * ?revision: float * ?startDate: DateTime * ?endDate: DateTime -> Promise<Work.DeliveryViewData>
    /// <summary>Delete a team's iteration by iterationId</summary>
    /// <param name="teamContext">- The team context for the operation</param>
    /// <param name="id">- ID of the iteration</param>
    abstract deleteTeamIteration: teamContext: Core.TeamContext * id: string -> Promise<unit>
    /// <summary>Get team's iteration by iterationId</summary>
    /// <param name="teamContext">- The team context for the operation</param>
    /// <param name="id">- ID of the iteration</param>
    abstract getTeamIteration: teamContext: Core.TeamContext * id: string -> Promise<Work.TeamSettingsIteration>
    /// <summary>Get a team's iterations using timeframe filter</summary>
    /// <param name="teamContext">- The team context for the operation</param>
    /// <param name="timeframe">- A filter for which iterations are returned based on relative time. Only Current is supported currently.</param>
    abstract getTeamIterations: teamContext: Core.TeamContext * ?timeframe: string -> Promise<ResizeArray<Work.TeamSettingsIteration>>
    /// <summary>Add an iteration to the team</summary>
    /// <param name="iteration">- Iteration to add</param>
    /// <param name="teamContext">- The team context for the operation</param>
    abstract postTeamIteration: iteration: Work.TeamSettingsIteration * teamContext: Core.TeamContext -> Promise<Work.TeamSettingsIteration>
    /// <summary>Add a new plan for the team</summary>
    /// <param name="postedPlan">- Plan definition</param>
    /// <param name="project">- Project ID or project name</param>
    abstract createPlan: postedPlan: Work.CreatePlan * project: string -> Promise<Work.Plan>
    /// <summary>Delete the specified plan</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="id">- Identifier of the plan</param>
    abstract deletePlan: project: string * id: string -> Promise<unit>
    /// <summary>Get the information for the specified plan</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="id">- Identifier of the plan</param>
    abstract getPlan: project: string * id: string -> Promise<Work.Plan>
    /// <summary>Get the information for all the plans configured for the given team</summary>
    /// <param name="project">- Project ID or project name</param>
    abstract getPlans: project: string -> Promise<ResizeArray<Work.Plan>>
    /// <summary>Update the information for the specified plan</summary>
    /// <param name="updatedPlan">- Plan definition to be updated</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="id">- Identifier of the plan</param>
    abstract updatePlan: updatedPlan: Work.UpdatePlan * project: string * id: string -> Promise<Work.Plan>
    /// <summary>Get process configuration</summary>
    /// <param name="project">- Project ID or project name</param>
    abstract getProcessConfiguration: project: string -> Promise<Work.ProcessConfiguration>
    /// <summary>Get rows on a board</summary>
    /// <param name="teamContext">- The team context for the operation</param>
    /// <param name="board">- Name or ID of the specific board</param>
    abstract getBoardRows: teamContext: Core.TeamContext * board: string -> Promise<ResizeArray<Work.BoardRow>>
    /// <summary>Update rows on a board</summary>
    /// <param name="boardRows">- List of board rows to update</param>
    /// <param name="teamContext">- The team context for the operation</param>
    /// <param name="board">- Name or ID of the specific board</param>
    abstract updateBoardRows: boardRows: ResizeArray<Work.BoardRow> * teamContext: Core.TeamContext * board: string -> Promise<ResizeArray<Work.BoardRow>>
    /// <param name="teamContext">- The team context for the operation</param>
    abstract getColumns: teamContext: Core.TeamContext -> Promise<Work.TaskboardColumns>
    /// <param name="updateColumns">-</param>
    /// <param name="teamContext">- The team context for the operation</param>
    abstract updateColumns: updateColumns: ResizeArray<Work.UpdateTaskboardColumn> * teamContext: Core.TeamContext -> Promise<Work.TaskboardColumns>
    /// <param name="teamContext">- The team context for the operation</param>
    /// <param name="iterationId">-</param>
    abstract getWorkItemColumns: teamContext: Core.TeamContext * iterationId: string -> Promise<ResizeArray<Work.TaskboardWorkItemColumn>>
    /// <param name="updateColumn">-</param>
    /// <param name="teamContext">- The team context for the operation</param>
    /// <param name="iterationId">-</param>
    /// <param name="workItemId">-</param>
    abstract updateWorkItemColumn: updateColumn: Work.UpdateTaskboardWorkItemColumn * teamContext: Core.TeamContext * iterationId: string * workItemId: float -> Promise<unit>
    /// <summary>Get team's days off for an iteration</summary>
    /// <param name="teamContext">- The team context for the operation</param>
    /// <param name="iterationId">- ID of the iteration</param>
    abstract getTeamDaysOff: teamContext: Core.TeamContext * iterationId: string -> Promise<Work.TeamSettingsDaysOff>
    /// <summary>Set a team's days off for an iteration</summary>
    /// <param name="daysOffPatch">- Team's days off patch containting a list of start and end dates</param>
    /// <param name="teamContext">- The team context for the operation</param>
    /// <param name="iterationId">- ID of the iteration</param>
    abstract updateTeamDaysOff: daysOffPatch: Work.TeamSettingsDaysOffPatch * teamContext: Core.TeamContext * iterationId: string -> Promise<Work.TeamSettingsDaysOff>
    /// <summary>Get a collection of team field values</summary>
    /// <param name="teamContext">- The team context for the operation</param>
    abstract getTeamFieldValues: teamContext: Core.TeamContext -> Promise<Work.TeamFieldValues>
    /// <summary>Update team field values</summary>
    /// <param name="patch">-</param>
    /// <param name="teamContext">- The team context for the operation</param>
    abstract updateTeamFieldValues: patch: Work.TeamFieldValuesPatch * teamContext: Core.TeamContext -> Promise<Work.TeamFieldValues>
    /// <summary>Get a team's settings</summary>
    /// <param name="teamContext">- The team context for the operation</param>
    abstract getTeamSettings: teamContext: Core.TeamContext -> Promise<Work.TeamSetting>
    /// <summary>Update a team's settings</summary>
    /// <param name="teamSettingsPatch">- TeamSettings changes</param>
    /// <param name="teamContext">- The team context for the operation</param>
    abstract updateTeamSettings: teamSettingsPatch: Work.TeamSettingsPatch * teamContext: Core.TeamContext -> Promise<Work.TeamSetting>
    /// <summary>Get work items for iteration</summary>
    /// <param name="teamContext">- The team context for the operation</param>
    /// <param name="iterationId">- ID of the iteration</param>
    abstract getIterationWorkItems: teamContext: Core.TeamContext * iterationId: string -> Promise<Work.IterationWorkItems>
    /// <summary>Reorder Product Backlog/Boards Work Items</summary>
    /// <param name="operation">-</param>
    /// <param name="teamContext">- The team context for the operation</param>
    abstract reorderBacklogWorkItems: operation: Work.ReorderOperation * teamContext: Core.TeamContext -> Promise<ResizeArray<Work.ReorderResult>>
    /// <summary>Reorder Sprint Backlog/Taskboard Work Items</summary>
    /// <param name="operation">-</param>
    /// <param name="teamContext">- The team context for the operation</param>
    /// <param name="iterationId">- The id of the iteration</param>
    abstract reorderIterationWorkItems: operation: Work.ReorderOperation * teamContext: Core.TeamContext * iterationId: string -> Promise<ResizeArray<Work.ReorderResult>>

type [<AllowNullLiteral>] WorkRestClientSetBoardOptionsOptions =
    [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> string with get, set

type [<AllowNullLiteral>] WorkRestClientUpdateBoardUserSettingsBoardUserSettings =
    [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> string with get, set

type [<AllowNullLiteral>] WorkRestClientStatic =
    [<Emit "new $0($1...)">] abstract Create: options: IVssRestClientOptions -> WorkRestClient
    abstract RESOURCE_AREA_ID: string

type [<AllowNullLiteral>] WorkRestClientSetBoardOptionsPromise =
    [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> string with get, set
