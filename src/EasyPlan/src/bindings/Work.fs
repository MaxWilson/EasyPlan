// ts2fable 0.7.1
module rec Work
open System
open Fable.Core
open Fable.Core.JS


module Work =
    module System = ___Common_System
    module WebApi = ___WebApi_WebApi
    module WorkItemTracking = ___WorkItemTracking_WorkItemTracking

    type [<AllowNullLiteral>] Activity =
        abstract capacityPerDay: float with get, set
        abstract name: string with get, set

    type [<AllowNullLiteral>] attribute =
        interface end

    type [<AllowNullLiteral>] BacklogColumn =
        abstract columnFieldReference: WorkItemTracking.WorkItemFieldReference with get, set
        abstract width: float with get, set

    type [<AllowNullLiteral>] BacklogConfiguration =
        /// Behavior/type field mapping
        abstract backlogFields: BacklogFields with get, set
        /// Bugs behavior
        abstract bugsBehavior: BugsBehavior with get, set
        /// Hidden Backlog
        abstract hiddenBacklogs: ResizeArray<string> with get, set
        /// Is BugsBehavior Configured in the process
        abstract isBugsBehaviorConfigured: bool with get, set
        /// Portfolio backlog descriptors
        abstract portfolioBacklogs: ResizeArray<BacklogLevelConfiguration> with get, set
        /// Requirement backlog
        abstract requirementBacklog: BacklogLevelConfiguration with get, set
        /// Task backlog
        abstract taskBacklog: BacklogLevelConfiguration with get, set
        abstract url: string with get, set
        /// Mapped states for work item types
        abstract workItemTypeMappedStates: ResizeArray<WorkItemTypeStateInfo> with get, set

    type [<AllowNullLiteral>] BacklogFields =
        /// Field Type (e.g. Order, Activity) to Field Reference Name map
        abstract typeFields: BacklogFieldsTypeFields with get, set

    /// Contract representing a backlog level
    type [<AllowNullLiteral>] BacklogLevel =
        /// Reference name of the corresponding WIT category
        abstract categoryReferenceName: string with get, set
        /// Plural name for the backlog level
        abstract pluralName: string with get, set
        /// Collection of work item states that are included in the plan. The server will filter to only these work item types.
        abstract workItemStates: ResizeArray<string> with get, set
        /// Collection of valid workitem type names for the given backlog level
        abstract workItemTypes: ResizeArray<string> with get, set

    type [<AllowNullLiteral>] BacklogLevelConfiguration =
        /// List of fields to include in Add Panel
        abstract addPanelFields: ResizeArray<WorkItemTracking.WorkItemFieldReference> with get, set
        /// Color for the backlog level
        abstract color: string with get, set
        /// Default list of columns for the backlog
        abstract columnFields: ResizeArray<BacklogColumn> with get, set
        /// Default Work Item Type for the backlog
        abstract defaultWorkItemType: WorkItemTracking.WorkItemTypeReference with get, set
        /// Backlog Id (for Legacy Backlog Level from process config it can be categoryref name)
        abstract id: string with get, set
        /// Indicates whether the backlog level is hidden
        abstract isHidden: bool with get, set
        /// Backlog Name
        abstract name: string with get, set
        /// Backlog Rank (Taskbacklog is 0)
        abstract rank: float with get, set
        /// The type of this backlog level
        abstract ``type``: BacklogType with get, set
        /// Max number of work items to show in the given backlog
        abstract workItemCountLimit: float with get, set
        /// Work Item types participating in this backlog as known by the project/Process, can be overridden by team settings for bugs
        abstract workItemTypes: ResizeArray<WorkItemTracking.WorkItemTypeReference> with get, set

    /// Represents work items in a backlog level
    type [<AllowNullLiteral>] BacklogLevelWorkItems =
        /// A list of work items within a backlog level
        abstract workItems: ResizeArray<WorkItemTracking.WorkItemLink> with get, set

    type [<RequireQualifiedAccess>] BacklogType =
        | Portfolio = 0
        | Requirement = 1
        | Task = 2

    type [<AllowNullLiteral>] Board =
        inherit BoardReference
        abstract _links: obj option with get, set
        abstract allowedMappings: BoardAllowedMappings with get, set
        abstract canEdit: bool with get, set
        abstract columns: ResizeArray<BoardColumn> with get, set
        abstract fields: BoardFields with get, set
        abstract isValid: bool with get, set
        abstract revision: float with get, set
        abstract rows: ResizeArray<BoardRow> with get, set

    /// Represents a board badge.
    type [<AllowNullLiteral>] BoardBadge =
        /// The ID of the board represented by this badge.
        abstract boardId: string with get, set
        /// A link to the SVG resource.
        abstract imageUrl: string with get, set

    type [<RequireQualifiedAccess>] BoardBadgeColumnOptions =
        | InProgressColumns = 0
        | AllColumns = 1
        | CustomColumns = 2

    type [<AllowNullLiteral>] BoardCardRuleSettings =
        abstract _links: obj option with get, set
        abstract rules: BoardCardRuleSettingsRules with get, set
        abstract url: string with get, set

    type [<AllowNullLiteral>] BoardCardSettings =
        abstract cards: BoardCardSettingsCards with get, set

    type [<AllowNullLiteral>] BoardChart =
        inherit BoardChartReference
        /// The links for the resource
        abstract _links: obj option with get, set
        /// The settings for the resource
        abstract settings: BoardChartSettings with get, set

    type [<AllowNullLiteral>] BoardChartReference =
        /// Name of the resource
        abstract name: string with get, set
        /// Full http link to the resource
        abstract url: string with get, set

    type [<AllowNullLiteral>] BoardColumn =
        abstract columnType: BoardColumnType with get, set
        abstract description: string with get, set
        abstract id: string with get, set
        abstract isSplit: bool with get, set
        abstract itemLimit: float with get, set
        abstract name: string with get, set
        abstract stateMappings: BacklogFieldsTypeFields with get, set

    type [<RequireQualifiedAccess>] BoardColumnType =
        | Incoming = 0
        | InProgress = 1
        | Outgoing = 2

    type [<AllowNullLiteral>] BoardFields =
        abstract columnField: FieldReference with get, set
        abstract doneField: FieldReference with get, set
        abstract rowField: FieldReference with get, set

    type [<AllowNullLiteral>] BoardReference =
        /// Id of the resource
        abstract id: string with get, set
        /// Name of the resource
        abstract name: string with get, set
        /// Full http link to the resource
        abstract url: string with get, set

    type [<AllowNullLiteral>] BoardRow =
        abstract id: string with get, set
        abstract name: string with get, set

    type [<AllowNullLiteral>] BoardSuggestedValue =
        abstract name: string with get, set

    type [<AllowNullLiteral>] BoardUserSettings =
        abstract autoRefreshState: bool with get, set

    type [<RequireQualifiedAccess>] BugsBehavior =
        | Off = 0
        | AsRequirements = 1
        | AsTasks = 2

    type [<AllowNullLiteral>] CapacityContractBase =
        inherit TeamSettingsDataContractBase
        /// Collection of capacities associated with the team member
        abstract activities: ResizeArray<Activity> with get, set
        /// The days off associated with the team member
        abstract daysOff: ResizeArray<DateRange> with get, set

    /// Expected data from PATCH
    type [<AllowNullLiteral>] CapacityPatch =
        abstract activities: ResizeArray<Activity> with get, set
        abstract daysOff: ResizeArray<DateRange> with get, set

    /// Card settings, such as fields and rules
    type [<AllowNullLiteral>] CardFieldSettings =
        /// A collection of field information of additional fields on cards. The index in the collection signifies the order of the field among the additional fields. Currently unused. Should be used with User Story 691539: Card setting: additional fields
        abstract additionalFields: ResizeArray<FieldInfo> with get, set
        /// Display format for the assigned to field
        abstract assignedToDisplayFormat: IdentityDisplayFormat with get, set
        /// A collection of field information of rendered core fields on cards.
        abstract coreFields: ResizeArray<FieldInfo> with get, set
        /// Flag indicating whether to show assigned to field on cards. When true, AssignedToDisplayFormat will determine how the field will be displayed
        abstract showAssignedTo: bool with get, set
        /// Flag indicating whether to show empty fields on cards
        abstract showEmptyFields: bool with get, set
        /// Flag indicating whether to show ID on cards
        abstract showId: bool with get, set
        /// Flag indicating whether to show state field on cards
        abstract showState: bool with get, set
        /// Flag indicating whether to show tags on cards
        abstract showTags: bool with get, set

    /// Card settings, such as fields and rules
    type [<AllowNullLiteral>] CardSettings =
        /// A collection of settings related to rendering of fields on cards
        abstract fields: CardFieldSettings with get, set

    /// Details about a given backlog category
    type [<AllowNullLiteral>] CategoryConfiguration =
        /// Name
        abstract name: string with get, set
        /// Category Reference Name
        abstract referenceName: string with get, set
        /// Work item types for the backlog category
        abstract workItemTypes: ResizeArray<WorkItemTracking.WorkItemTypeReference> with get, set

    type [<AllowNullLiteral>] CreatePlan =
        /// Description of the plan
        abstract description: string with get, set
        /// Name of the plan to create.
        abstract name: string with get, set
        /// Plan properties.
        abstract properties: obj option with get, set
        /// Type of plan to create.
        abstract ``type``: PlanType with get, set

    type [<AllowNullLiteral>] DateRange =
        /// End of the date range.
        abstract ``end``: DateTime with get, set
        /// Start of the date range.
        abstract start: DateTime with get, set

    /// Data contract for Data of Delivery View
    type [<AllowNullLiteral>] DeliveryViewData =
        inherit PlanViewData
        /// Work item child id to parent id map
        abstract childIdToParentIdMap: DeliveryViewDataChildIdToParentIdMap with get, set
        /// Filter criteria status of the timeline
        abstract criteriaStatus: TimelineCriteriaStatus with get, set
        /// The end date of the delivery view data
        abstract endDate: DateTime with get, set
        /// Max number of teams can be configured for a delivery plan.
        abstract maxExpandedTeams: float with get, set
        /// The start date for the delivery view data
        abstract startDate: DateTime with get, set
        /// All the team data
        abstract teams: ResizeArray<TimelineTeamData> with get, set

    /// Collection of properties, specific to the DeliveryTimelineView
    type [<AllowNullLiteral>] DeliveryViewPropertyCollection =
        /// Card settings
        abstract cardSettings: CardSettings with get, set
        /// Field criteria
        abstract criteria: ResizeArray<FilterClause> with get, set
        /// Markers. Will be missing/null if there are no markers.
        abstract markers: ResizeArray<Marker> with get, set
        /// Team backlog mappings
        abstract teamBacklogMappings: ResizeArray<TeamBacklogMapping> with get, set

    /// Object bag storing the set of permissions relevant to this plan
    type [<AllowNullLiteral>] FieldInfo =
        /// The additional field display name
        abstract displayName: string with get, set
        /// The additional field type
        abstract fieldType: FieldType with get, set
        /// Indicates if the field definition is for an identity field.
        abstract isIdentity: bool with get, set
        /// The additional field reference name
        abstract referenceName: string with get, set

    /// An abstracted reference to a field
    type [<AllowNullLiteral>] FieldReference =
        /// fieldRefName for the field
        abstract referenceName: string with get, set
        /// Full http link to more information about the field
        abstract url: string with get, set

    type [<AllowNullLiteral>] FieldSetting =
        interface end

    type [<RequireQualifiedAccess>] FieldType =
        | String = 0
        | PlainText = 1
        | Integer = 2
        | DateTime = 3
        | TreePath = 4
        | Boolean = 5
        | Double = 6

    type [<AllowNullLiteral>] FilterClause =
        abstract fieldName: string with get, set
        abstract index: float with get, set
        abstract logicalOperator: string with get, set
        abstract operator: string with get, set
        abstract value: string with get, set

    type [<AllowNullLiteral>] FilterGroup =
        abstract ``end``: float with get, set
        abstract level: float with get, set
        abstract start: float with get, set

    type [<RequireQualifiedAccess>] IdentityDisplayFormat =
        | AvatarOnly = 0
        | FullName = 1
        | AvatarAndFullName = 2

    type [<AllowNullLiteral>] ITaskboardColumnMapping =
        abstract state: string with get, set
        abstract workItemType: string with get, set

    /// Represents work items in an iteration backlog
    type [<AllowNullLiteral>] IterationWorkItems =
        inherit TeamSettingsDataContractBase
        /// Work item relations
        abstract workItemRelations: ResizeArray<WorkItemTracking.WorkItemLink> with get, set

    /// Client serialization contract for Delivery Timeline Markers.
    type [<AllowNullLiteral>] Marker =
        /// Color associated with the marker.
        abstract color: string with get, set
        /// Where the marker should be displayed on the timeline.
        abstract date: DateTime with get, set
        /// Label/title for the marker.
        abstract label: string with get, set

    type [<AllowNullLiteral>] Member =
        abstract displayName: string with get, set
        abstract id: string with get, set
        abstract imageUrl: string with get, set
        abstract uniqueName: string with get, set
        abstract url: string with get, set

    type [<AllowNullLiteral>] ParentChildWIMap =
        abstract childWorkItemIds: ResizeArray<float> with get, set
        abstract id: float with get, set
        abstract title: string with get, set

    /// Data contract for the plan definition
    type [<AllowNullLiteral>] Plan =
        /// Identity that created this plan. Defaults to null for records before upgrading to ScaledAgileViewComponent4.
        abstract createdByIdentity: WebApi.IdentityRef with get, set
        /// Date when the plan was created
        abstract createdDate: DateTime with get, set
        /// Description of the plan
        abstract description: string with get, set
        /// Id of the plan
        abstract id: string with get, set
        /// Identity that last modified this plan. Defaults to null for records before upgrading to ScaledAgileViewComponent4.
        abstract modifiedByIdentity: WebApi.IdentityRef with get, set
        /// Date when the plan was last modified. Default to CreatedDate when the plan is first created.
        abstract modifiedDate: DateTime with get, set
        /// Name of the plan
        abstract name: string with get, set
        /// The PlanPropertyCollection instance associated with the plan. These are dependent on the type of the plan. For example, DeliveryTimelineView, it would be of type DeliveryViewPropertyCollection.
        abstract properties: obj option with get, set
        /// Revision of the plan. Used to safeguard users from overwriting each other's changes.
        abstract revision: float with get, set
        /// Type of the plan
        abstract ``type``: PlanType with get, set
        /// The resource url to locate the plan via rest api
        abstract url: string with get, set
        /// Bit flag indicating set of permissions a user has to the plan.
        abstract userPermissions: PlanUserPermissions with get, set

    /// Metadata about a plan definition that is stored in favorites service
    type [<AllowNullLiteral>] PlanMetadata =
        /// Identity of the creator of the plan
        abstract createdByIdentity: WebApi.IdentityRef with get, set
        /// Description of plan
        abstract description: string with get, set
        /// Last modified date of the plan
        abstract modifiedDate: DateTime with get, set
        /// Bit flag indicating set of permissions a user has to the plan.
        abstract userPermissions: PlanUserPermissions with get, set

    type [<RequireQualifiedAccess>] PlanType =
        | DeliveryTimelineView = 0

    type [<RequireQualifiedAccess>] PlanUserPermissions =
        | None = 0
        | View = 1
        | Edit = 2
        | Delete = 4
        | Manage = 8
        | AllPermissions = 15

    /// Base class for plan view data contracts. Anything common goes here.
    type [<AllowNullLiteral>] PlanViewData =
        abstract id: string with get, set
        abstract revision: float with get, set

    /// Represents a single pre-defined query.
    type [<AllowNullLiteral>] PredefinedQuery =
        /// Whether or not the query returned the complete set of data or if the data was truncated.
        abstract hasMore: bool with get, set
        /// Id of the query
        abstract id: string with get, set
        /// Localized name of the query
        abstract name: string with get, set
        /// The results of the query.  This will be a set of WorkItem objects with only the 'id' set.  The client is responsible for paging in the data as needed.
        abstract results: ResizeArray<WorkItemTracking.WorkItem> with get, set
        /// REST API Url to use to retrieve results for this query
        abstract url: string with get, set
        /// Url to use to display a page in the browser with the results of this query
        abstract webUrl: string with get, set

    /// Process Configurations for the project
    type [<AllowNullLiteral>] ProcessConfiguration =
        /// Details about bug work items
        abstract bugWorkItems: CategoryConfiguration with get, set
        /// Details about portfolio backlogs
        abstract portfolioBacklogs: ResizeArray<CategoryConfiguration> with get, set
        /// Details of requirement backlog
        abstract requirementBacklog: CategoryConfiguration with get, set
        /// Details of task backlog
        abstract taskBacklog: CategoryConfiguration with get, set
        /// Type fields for the process configuration
        abstract typeFields: ProcessConfigurationTypeFields with get, set
        abstract url: string with get, set

    /// Represents a reorder request for one or more work items.
    type [<AllowNullLiteral>] ReorderOperation =
        /// IDs of the work items to be reordered.  Must be valid WorkItem Ids.
        abstract ids: ResizeArray<float> with get, set
        /// IterationPath for reorder operation. This is only used when we reorder from the Iteration Backlog
        abstract iterationPath: string with get, set
        /// ID of the work item that should be after the reordered items. Can use 0 to specify the end of the list.
        abstract nextId: float with get, set
        /// Parent ID for all of the work items involved in this operation. Can use 0 to indicate the items don't have a parent.
        abstract parentId: float with get, set
        /// ID of the work item that should be before the reordered items. Can use 0 to specify the beginning of the list.
        abstract previousId: float with get, set

    /// Represents a reorder result for a work item.
    type [<AllowNullLiteral>] ReorderResult =
        /// The ID of the work item that was reordered.
        abstract id: float with get, set
        /// The updated order value of the work item that was reordered.
        abstract order: float with get, set

    type [<AllowNullLiteral>] Rule =
        abstract clauses: ResizeArray<FilterClause> with get, set
        abstract filter: string with get, set
        abstract isEnabled: string with get, set
        abstract name: string with get, set
        abstract settings: attribute with get, set

    /// Represents the taskbord column
    type [<AllowNullLiteral>] TaskboardColumn =
        /// Column ID
        abstract id: string with get, set
        /// Work item type states mapped to this column to support auto state update when column is updated.
        abstract mappings: ResizeArray<ITaskboardColumnMapping> with get, set
        /// Column name
        abstract name: string with get, set
        /// Column position relative to other columns in the same board
        abstract order: float with get, set

    /// Represents the state to column mapping per work item type This allows auto state update when the column changes
    type [<AllowNullLiteral>] TaskboardColumnMapping =
        /// State of the work item type mapped to the column
        abstract state: string with get, set
        /// Work Item Type name who's state is mapped to the column
        abstract workItemType: string with get, set

    type [<AllowNullLiteral>] TaskboardColumns =
        abstract columns: ResizeArray<TaskboardColumn> with get, set
        /// Are the columns cutomized for this team
        abstract isCustomized: bool with get, set
        /// Specifies if the referenced WIT and State is valid
        abstract isValid: bool with get, set
        /// Details of validation failure if the state to column mapping is invalid
        abstract validationMesssage: string with get, set

    /// Column value of a work item in the taskboard
    type [<AllowNullLiteral>] TaskboardWorkItemColumn =
        /// Work item column value in the taskboard
        abstract column: string with get, set
        /// Work item column id in the taskboard
        abstract columnId: string with get, set
        /// Work Item state value
        abstract state: string with get, set
        /// Work item id
        abstract workItemId: float with get, set

    /// Mapping of teams to the corresponding work item category
    type [<AllowNullLiteral>] TeamBacklogMapping =
        abstract categoryReferenceName: string with get, set
        abstract teamId: string with get, set

    /// Represents a single TeamFieldValue
    type [<AllowNullLiteral>] TeamFieldValue =
        abstract includeChildren: bool with get, set
        abstract value: string with get, set

    /// Essentially a collection of team field values
    type [<AllowNullLiteral>] TeamFieldValues =
        inherit TeamSettingsDataContractBase
        /// The default team field value
        abstract defaultValue: string with get, set
        /// Shallow ref to the field being used as a team field
        abstract field: FieldReference with get, set
        /// Collection of all valid team field values
        abstract values: ResizeArray<TeamFieldValue> with get, set

    /// Expected data from PATCH
    type [<AllowNullLiteral>] TeamFieldValuesPatch =
        abstract defaultValue: string with get, set
        abstract values: ResizeArray<TeamFieldValue> with get, set

    type [<AllowNullLiteral>] TeamIterationAttributes =
        /// Finish date of the iteration. Date-only, correct unadjusted at midnight in UTC.
        abstract finishDate: DateTime with get, set
        /// Start date of the iteration. Date-only, correct unadjusted at midnight in UTC.
        abstract startDate: DateTime with get, set
        /// Time frame of the iteration, such as past, current or future.
        abstract timeFrame: TimeFrame with get, set

    /// Represents capacity for a specific team member
    type [<AllowNullLiteral>] TeamMemberCapacity =
        inherit CapacityContractBase
        /// Shallow Ref to the associated team member
        abstract teamMember: Member with get, set

    /// Represents capacity for a specific team member
    type [<AllowNullLiteral>] TeamMemberCapacityIdentityRef =
        inherit CapacityContractBase
        /// Identity ref of the associated team member
        abstract teamMember: WebApi.IdentityRef with get, set

    /// Data contract for TeamSettings
    type [<AllowNullLiteral>] TeamSetting =
        inherit TeamSettingsDataContractBase
        /// Backlog Iteration
        abstract backlogIteration: TeamSettingsIteration with get, set
        /// Information about categories that are visible on the backlog.
        abstract backlogVisibilities: TeamSettingBacklogVisibilities with get, set
        /// BugsBehavior (Off, AsTasks, AsRequirements, ...)
        abstract bugsBehavior: BugsBehavior with get, set
        /// Default Iteration, the iteration used when creating a new work item on the queries page.
        abstract defaultIteration: TeamSettingsIteration with get, set
        /// Default Iteration macro (if any)
        abstract defaultIterationMacro: string with get, set
        /// Days that the team is working
        abstract workingDays: ResizeArray<System.DayOfWeek> with get, set

    /// Base class for TeamSettings data contracts. Anything common goes here.
    type [<AllowNullLiteral>] TeamSettingsDataContractBase =
        /// Collection of links relevant to resource
        abstract _links: obj option with get, set
        /// Full http link to the resource
        abstract url: string with get, set

    type [<AllowNullLiteral>] TeamSettingsDaysOff =
        inherit TeamSettingsDataContractBase
        abstract daysOff: ResizeArray<DateRange> with get, set

    type [<AllowNullLiteral>] TeamSettingsDaysOffPatch =
        abstract daysOff: ResizeArray<DateRange> with get, set

    /// Represents a shallow ref for a single iteration.
    type [<AllowNullLiteral>] TeamSettingsIteration =
        inherit TeamSettingsDataContractBase
        /// Attributes of the iteration such as start and end date.
        abstract attributes: TeamIterationAttributes with get, set
        /// Id of the iteration.
        abstract id: string with get, set
        /// Name of the iteration.
        abstract name: string with get, set
        /// Relative path of the iteration.
        abstract path: string with get, set

    /// Data contract for what we expect to receive when PATCH
    type [<AllowNullLiteral>] TeamSettingsPatch =
        abstract backlogIteration: string with get, set
        abstract backlogVisibilities: TeamSettingBacklogVisibilities with get, set
        abstract bugsBehavior: BugsBehavior with get, set
        abstract defaultIteration: string with get, set
        abstract defaultIterationMacro: string with get, set
        abstract workingDays: ResizeArray<System.DayOfWeek> with get, set

    type [<RequireQualifiedAccess>] TimeFrame =
        | Past = 0
        | Current = 1
        | Future = 2

    type [<AllowNullLiteral>] TimelineCriteriaStatus =
        abstract message: string with get, set
        abstract ``type``: TimelineCriteriaStatusCode with get, set

    type [<RequireQualifiedAccess>] TimelineCriteriaStatusCode =
        | OK = 0
        | InvalidFilterClause = 1
        | Unknown = 2

    type [<AllowNullLiteral>] TimelineIterationStatus =
        abstract message: string with get, set
        abstract ``type``: TimelineIterationStatusCode with get, set

    type [<RequireQualifiedAccess>] TimelineIterationStatusCode =
        | OK = 0
        | IsOverlapping = 1

    type [<AllowNullLiteral>] TimelineTeamData =
        /// Backlog matching the mapped backlog associated with this team.
        abstract backlog: BacklogLevel with get, set
        /// The field reference names of the work item data
        abstract fieldReferenceNames: ResizeArray<string> with get, set
        /// The id of the team
        abstract id: string with get, set
        /// Was iteration and work item data retrieved for this team. \<remarks\> Teams with IsExpanded false have not had their iteration, work item, and field related data queried and will never contain this data. If true then these items are queried and, if there are items in the queried range, there will be data. \</remarks\>
        abstract isExpanded: bool with get, set
        /// The iteration data, including the work items, in the queried date range.
        abstract iterations: ResizeArray<TimelineTeamIteration> with get, set
        /// The name of the team
        abstract name: string with get, set
        /// The order by field name of this team
        abstract orderByField: string with get, set
        /// The field reference names of the partially paged work items, such as ID, WorkItemType
        abstract partiallyPagedFieldReferenceNames: ResizeArray<string> with get, set
        /// The project id the team belongs team
        abstract projectId: string with get, set
        /// Status for this team.
        abstract status: TimelineTeamStatus with get, set
        /// The team field default value
        abstract teamFieldDefaultValue: string with get, set
        /// The team field name of this team
        abstract teamFieldName: string with get, set
        /// The team field values
        abstract teamFieldValues: ResizeArray<TeamFieldValue> with get, set
        /// Colors for the work item types.
        abstract workItemTypeColors: ResizeArray<WorkItemColor> with get, set

    type [<AllowNullLiteral>] TimelineTeamIteration =
        /// The iteration CSS Node Id
        abstract cssNodeId: string with get, set
        /// The end date of the iteration
        abstract finishDate: DateTime with get, set
        /// The iteration name
        abstract name: string with get, set
        /// All the partially paged workitems in this iteration.
        abstract partiallyPagedWorkItems: ResizeArray<ResizeArray<obj option>> with get, set
        /// The iteration path
        abstract path: string with get, set
        /// The start date of the iteration
        abstract startDate: DateTime with get, set
        /// The status of this iteration
        abstract status: TimelineIterationStatus with get, set
        /// The work items that have been paged in this iteration
        abstract workItems: ResizeArray<ResizeArray<obj option>> with get, set

    type [<AllowNullLiteral>] TimelineTeamStatus =
        abstract message: string with get, set
        abstract ``type``: TimelineTeamStatusCode with get, set

    type [<RequireQualifiedAccess>] TimelineTeamStatusCode =
        | OK = 0
        | DoesntExistOrAccessDenied = 1
        | MaxTeamsExceeded = 2
        | MaxTeamFieldsExceeded = 3
        | BacklogInError = 4
        | MissingTeamFieldValue = 5
        | NoIterationsExist = 6

    type [<AllowNullLiteral>] UpdatePlan =
        /// Description of the plan
        abstract description: string with get, set
        /// Name of the plan to create.
        abstract name: string with get, set
        /// Plan properties.
        abstract properties: obj option with get, set
        /// Revision of the plan that was updated - the value used here should match the one the server gave the client in the Plan.
        abstract revision: float with get, set
        /// Type of the plan
        abstract ``type``: PlanType with get, set

    type [<AllowNullLiteral>] UpdateTaskboardColumn =
        /// Column ID, keep it null for new column
        abstract id: string with get, set
        /// Work item type states mapped to this column to support auto state update when column is updated.
        abstract mappings: ResizeArray<TaskboardColumnMapping> with get, set
        /// Column name is required
        abstract name: string with get, set
        /// Column position relative to other columns in the same board
        abstract order: float with get, set

    type [<AllowNullLiteral>] UpdateTaskboardWorkItemColumn =
        abstract newColumn: string with get, set

    /// Work item color and icon.
    type [<AllowNullLiteral>] WorkItemColor =
        abstract icon: string with get, set
        abstract primaryColor: string with get, set
        abstract workItemTypeName: string with get, set

    type [<AllowNullLiteral>] WorkItemTypeStateInfo =
        /// State name to state category map
        abstract states: BacklogFieldsTypeFields with get, set
        /// Work Item type name
        abstract workItemTypeName: string with get, set

    type [<AllowNullLiteral>] BacklogFieldsTypeFields =
        [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> string with get, set

    type [<AllowNullLiteral>] BoardAllowedMappingsItem =
        [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> ResizeArray<string> with get, set

    type [<AllowNullLiteral>] BoardAllowedMappings =
        [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> BoardAllowedMappingsItem with get, set

    type [<AllowNullLiteral>] BoardCardRuleSettingsRules =
        [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> ResizeArray<Rule> with get, set

    type [<AllowNullLiteral>] BoardCardSettingsCards =
        [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> ResizeArray<FieldSetting> with get, set

    type [<AllowNullLiteral>] BoardChartSettings =
        [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

    type [<AllowNullLiteral>] DeliveryViewDataChildIdToParentIdMap =
        [<Emit "$0[$1]{{=$2}}">] abstract Item: key: float -> float with get, set

    type [<AllowNullLiteral>] ProcessConfigurationTypeFields =
        [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> WorkItemTracking.WorkItemFieldReference with get, set

    type [<AllowNullLiteral>] TeamSettingBacklogVisibilities =
        [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> bool with get, set
