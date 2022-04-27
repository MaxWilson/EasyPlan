// ts2fable 0.7.1
module rec Notification
open System
open Fable.Core
open Fable.Core.JS

type [<AllowNullLiteral>] ActorFilter =
    inherit RoleBasedFilter

type [<AllowNullLiteral>] ActorNotificationReason =
    inherit NotificationReason
    abstract matchedRoles: ResizeArray<string> with get, set

/// Artifact filter options. Used in "follow" subscriptions.
type [<AllowNullLiteral>] ArtifactFilter =
    inherit BaseSubscriptionFilter
    abstract artifactId: string with get, set
    abstract artifactType: string with get, set
    abstract artifactUri: string with get, set
    abstract ``type``: string with get, set

type [<AllowNullLiteral>] BaseSubscriptionFilter =
    abstract eventType: string with get, set
    abstract ``type``: string with get, set

type [<AllowNullLiteral>] BatchNotificationOperation =
    abstract notificationOperation: NotificationOperation with get, set
    abstract notificationQueryConditions: ResizeArray<NotificationQueryCondition> with get, set

type [<AllowNullLiteral>] BlockFilter =
    inherit RoleBasedFilter

type [<AllowNullLiteral>] BlockSubscriptionChannel =
    abstract ``type``: string with get, set

type [<RequireQualifiedAccess>] DefaultGroupDeliveryPreference =
    | NoDelivery = -1
    | EachMember = 2

type [<AllowNullLiteral>] DiagnosticIdentity =
    abstract displayName: string with get, set
    abstract emailAddress: string with get, set
    abstract id: string with get, set

type [<AllowNullLiteral>] DiagnosticNotification =
    abstract eventId: int with get, set
    abstract eventType: string with get, set
    abstract id: int with get, set
    abstract messages: ResizeArray<NotificationDiagnosticLogMessage> with get, set
    abstract recipients: DiagnosticNotificationRecipients with get, set
    abstract result: string with get, set
    abstract stats: DiagnosticNotificationStats with get, set
    abstract subscriptionId: string with get, set

type [<AllowNullLiteral>] DiagnosticRecipient =
    abstract recipient: DiagnosticIdentity with get, set
    abstract status: string with get, set

type [<AllowNullLiteral>] EmailHtmlSubscriptionChannel =
    inherit SubscriptionChannelWithAddress
    abstract ``type``: string with get, set

type [<AllowNullLiteral>] EmailPlaintextSubscriptionChannel =
    inherit SubscriptionChannelWithAddress
    abstract ``type``: string with get, set

type [<RequireQualifiedAccess>] EvaluationOperationStatus =
    | NotSet = 0
    | Queued = 1
    | InProgress = 2
    | Cancelled = 3
    | Succeeded = 4
    | Failed = 5
    | TimedOut = 6
    | NotFound = 7

type [<AllowNullLiteral>] EventBacklogStatus =
    abstract captureTime: DateTime with get, set
    abstract jobId: string with get, set
    abstract lastEventBatchStartTime: DateTime with get, set
    abstract lastEventProcessedTime: DateTime with get, set
    abstract lastJobBatchStartTime: DateTime with get, set
    abstract lastJobProcessedTime: DateTime with get, set
    abstract oldestPendingEventTime: DateTime with get, set
    abstract publisher: string with get, set
    abstract unprocessedEvents: int with get, set

type [<AllowNullLiteral>] EventBatch =
    abstract endTime: obj option with get, set
    abstract eventCounts: DiagnosticNotificationStats with get, set
    abstract eventIds: string with get, set
    abstract notificationCounts: DiagnosticNotificationStats with get, set
    abstract preProcessEndTime: obj option with get, set
    abstract preProcessStartTime: obj option with get, set
    abstract processEndTime: obj option with get, set
    abstract processStartTime: obj option with get, set
    abstract startTime: obj option with get, set
    abstract subscriptionCounts: DiagnosticNotificationStats with get, set

type [<AllowNullLiteral>] EventProcessingLog =
    inherit NotificationJobDiagnosticLog
    abstract batches: ResizeArray<EventBatch> with get, set
    abstract matcherResults: ResizeArray<MatcherResult> with get, set

type [<RequireQualifiedAccess>] EventPublisherQueryFlags =
    | None = 0
    | IncludeRemoteServices = 2

/// Encapsulates events result properties. It defines the total number of events used and the number of matched events.
type [<AllowNullLiteral>] EventsEvaluationResult =
    /// Count of events evaluated.
    abstract count: int with get, set
    /// Count of matched events.
    abstract matchedCount: int with get, set

/// A transform request specify the properties of a notification event to be transformed.
type [<AllowNullLiteral>] EventTransformRequest =
    /// Event payload.
    abstract eventPayload: string with get, set
    /// Event type.
    abstract eventType: string with get, set
    /// System inputs.
    abstract systemInputs: EventTransformRequestSystemInputs with get, set

/// Result of transforming a notification event.
type [<AllowNullLiteral>] EventTransformResult =
    /// Transformed html content.
    abstract content: string with get, set
    /// Calculated data.
    abstract data: obj option with get, set
    /// Calculated system inputs.
    abstract systemInputs: EventTransformRequestSystemInputs with get, set

type [<RequireQualifiedAccess>] EventTypeQueryFlags =
    | None = 0
    | IncludeFields = 1

type [<AllowNullLiteral>] ExpressionFilter =
    inherit BaseSubscriptionFilter
    abstract criteria: ExpressionFilterModel with get, set
    abstract ``type``: string with get, set

/// Subscription Filter Clause represents a single clause in a subscription filter e.g. If the subscription has the following criteria "Project Name = [Current Project] AND Assigned To = [Me] it will be represented as two Filter Clauses Clause 1: Index = 1, Logical Operator: NULL  , FieldName = 'Project Name', Operator = '=', Value = '[Current Project]' Clause 2: Index = 2, Logical Operator: 'AND' , FieldName = 'Assigned To' , Operator = '=', Value = '[Me]'
type [<AllowNullLiteral>] ExpressionFilterClause =
    abstract fieldName: string with get, set
    /// The order in which this clause appeared in the filter query
    abstract index: int with get, set
    /// Logical Operator 'AND', 'OR' or NULL (only for the first clause in the filter)
    abstract logicalOperator: string with get, set
    abstract operator: string with get, set
    abstract value: string with get, set

/// Represents a hierarchy of SubscritionFilterClauses that have been grouped together through either adding a group in the WebUI or using parethesis in the Subscription condition string
type [<AllowNullLiteral>] ExpressionFilterGroup =
    /// The index of the last FilterClause in this group
    abstract ``end``: int with get, set
    /// Level of the group, since groups can be nested for each nested group the level will increase by 1
    abstract level: int with get, set
    /// The index of the first FilterClause in this group
    abstract start: int with get, set

type [<AllowNullLiteral>] ExpressionFilterModel =
    /// Flat list of clauses in this subscription
    abstract clauses: ResizeArray<ExpressionFilterClause> with get, set
    /// Grouping of clauses in the subscription
    abstract groups: ResizeArray<ExpressionFilterGroup> with get, set
    /// Max depth of the Subscription tree
    abstract maxGroupLevel: int with get, set

type [<AllowNullLiteral>] FieldInputValues =
    inherit FormInput.InputValues
    abstract operators: ResizeArray<float> with get, set

type [<AllowNullLiteral>] FieldValuesQuery =
    inherit FormInput.InputValuesQuery
    abstract inputValues: ResizeArray<FieldInputValues> with get, set
    abstract scope: string with get, set

type [<AllowNullLiteral>] GeneratedNotification =
    abstract recipients: ResizeArray<DiagnosticIdentity> with get, set

type [<AllowNullLiteral>] GroupSubscriptionChannel =
    inherit SubscriptionChannelWithAddress
    abstract ``type``: string with get, set

/// Abstraction interface for the diagnostic log.  Primarily for deserialization.
type [<AllowNullLiteral>] INotificationDiagnosticLog =
    /// Identifier used for correlating to other diagnostics that may have been recorded elsewhere.
    abstract activityId: string with get, set
    /// Description of what subscription or notification job is being logged.
    abstract description: string with get, set
    /// Time the log ended.
    abstract endTime: DateTime with get, set
    /// Unique instance identifier.
    abstract id: string with get, set
    /// Type of information being logged.
    abstract logType: string with get, set
    /// List of log messages.
    abstract messages: ResizeArray<NotificationDiagnosticLogMessage> with get, set
    /// Dictionary of log properties and settings for the job.
    abstract properties: EventTransformRequestSystemInputs with get, set
    /// This identifier depends on the logType.  For notification jobs, this will be the job Id. For subscription tracing, this will be a special root Guid with the subscription Id encoded.
    abstract source: string with get, set
    /// Time the log started.
    abstract startTime: DateTime with get, set

type [<AllowNullLiteral>] ISubscriptionChannel =
    abstract ``type``: string with get, set

type [<AllowNullLiteral>] ISubscriptionFilter =
    abstract eventType: string with get, set
    abstract ``type``: string with get, set

type [<AllowNullLiteral>] MatcherResult =
    abstract matcher: string with get, set
    abstract stats: MatcherResultStats with get, set

type [<AllowNullLiteral>] MessageQueueSubscriptionChannel =
    abstract ``type``: string with get, set

type [<AllowNullLiteral>] NotificationAdminSettings =
    /// The default group delivery preference for groups in this collection
    abstract defaultGroupDeliveryPreference: DefaultGroupDeliveryPreference with get, set

type [<AllowNullLiteral>] NotificationAdminSettingsUpdateParameters =
    abstract defaultGroupDeliveryPreference: DefaultGroupDeliveryPreference with get, set

type [<AllowNullLiteral>] NotificationBacklogStatus =
    abstract captureTime: DateTime with get, set
    abstract channel: string with get, set
    abstract jobId: string with get, set
    abstract lastJobBatchStartTime: DateTime with get, set
    abstract lastJobProcessedTime: DateTime with get, set
    abstract lastNotificationBatchStartTime: DateTime with get, set
    abstract lastNotificationProcessedTime: DateTime with get, set
    abstract oldestPendingNotificationTime: DateTime with get, set
    abstract publisher: string with get, set
    /// Null status is unprocessed
    abstract status: string with get, set
    abstract unprocessedNotifications: int with get, set

type [<AllowNullLiteral>] NotificationBatch =
    abstract endTime: obj option with get, set
    abstract notificationCount: int with get, set
    abstract notificationIds: string with get, set
    abstract problematicNotifications: ResizeArray<DiagnosticNotification> with get, set
    abstract startTime: obj option with get, set

type [<AllowNullLiteral>] NotificationDeliveryLog =
    inherit NotificationJobDiagnosticLog
    abstract batches: ResizeArray<NotificationBatch> with get, set

/// Abstract base class for all of the diagnostic logs.
type [<AllowNullLiteral>] NotificationDiagnosticLog =
    /// Identifier used for correlating to other diagnostics that may have been recorded elsewhere.
    abstract activityId: string with get, set
    abstract description: string with get, set
    abstract endTime: DateTime with get, set
    abstract errors: int with get, set
    /// Unique instance identifier.
    abstract id: string with get, set
    abstract logType: string with get, set
    abstract messages: ResizeArray<NotificationDiagnosticLogMessage> with get, set
    abstract properties: EventTransformRequestSystemInputs with get, set
    /// This identifier depends on the logType.  For notification jobs, this will be the job Id. For subscription tracing, this will be a special root Guid with the subscription Id encoded.
    abstract source: string with get, set
    abstract startTime: DateTime with get, set
    abstract warnings: int with get, set

type [<AllowNullLiteral>] NotificationDiagnosticLogMessage =
    /// Corresponds to .Net TraceLevel enumeration
    abstract level: int with get, set
    abstract message: string with get, set
    abstract time: obj option with get, set

type [<AllowNullLiteral>] NotificationEventBacklogStatus =
    abstract eventBacklogStatus: ResizeArray<EventBacklogStatus> with get, set
    abstract notificationBacklogStatus: ResizeArray<NotificationBacklogStatus> with get, set

/// Encapsulates the properties of a filterable field. A filterable field is a field in an event that can used to filter notifications for a certain event type.
type [<AllowNullLiteral>] NotificationEventField =
    /// Gets or sets the type of this field.
    abstract fieldType: NotificationEventFieldType with get, set
    /// Gets or sets the unique identifier of this field.
    abstract id: string with get, set
    /// Gets or sets the name of this field.
    abstract name: string with get, set
    /// Gets or sets the path to the field in the event object. This path can be either Json Path or XPath, depending on if the event will be serialized into Json or XML
    abstract path: string with get, set
    /// Gets or sets the scopes that this field supports. If not specified then the event type scopes apply.
    abstract supportedScopes: ResizeArray<string> with get, set

/// Encapsulates the properties of a field type. It includes a unique id for the operator and a localized string for display name
type [<AllowNullLiteral>] NotificationEventFieldOperator =
    /// Gets or sets the display name of an operator
    abstract displayName: string with get, set
    /// Gets or sets the id of an operator
    abstract id: string with get, set

/// Encapsulates the properties of a field type. It describes the data type of a field, the operators it support and how to populate it in the UI
type [<AllowNullLiteral>] NotificationEventFieldType =
    /// Gets or sets the unique identifier of this field type.
    abstract id: string with get, set
    abstract operatorConstraints: ResizeArray<OperatorConstraint> with get, set
    /// Gets or sets the list of operators that this type supports.
    abstract operators: ResizeArray<NotificationEventFieldOperator> with get, set
    abstract subscriptionFieldType: SubscriptionFieldType with get, set
    /// Gets or sets the value definition of this field like the getValuesMethod and template to display in the UI
    abstract value: ValueDefinition with get, set

/// Encapsulates the properties of a notification event publisher.
type [<AllowNullLiteral>] NotificationEventPublisher =
    abstract id: string with get, set
    abstract subscriptionManagementInfo: SubscriptionManagement with get, set
    abstract url: string with get, set

/// Encapsulates the properties of an event role.  An event Role is used for role based subscription for example for a buildCompletedEvent, one role is request by field
type [<AllowNullLiteral>] NotificationEventRole =
    /// Gets or sets an Id for that role, this id is used by the event.
    abstract id: string with get, set
    /// Gets or sets the Name for that role, this name is used for UI display.
    abstract name: string with get, set
    /// Gets or sets whether this role can be a group or just an individual user
    abstract supportsGroups: bool with get, set

/// Encapsulates the properties of an event type. It defines the fields, that can be used for filtering, for that event type.
type [<AllowNullLiteral>] NotificationEventType =
    abstract category: NotificationEventTypeCategory with get, set
    /// Gets or sets the color representing this event type. Example: rgb(128,245,211) or #fafafa
    abstract color: string with get, set
    abstract customSubscriptionsAllowed: bool with get, set
    abstract eventPublisher: NotificationEventPublisher with get, set
    abstract fields: NotificationEventTypeFields with get, set
    abstract hasInitiator: bool with get, set
    /// Gets or sets the icon representing this event type. Can be a URL or a CSS class. Example: css://some-css-class
    abstract icon: string with get, set
    /// Gets or sets the unique identifier of this event definition.
    abstract id: string with get, set
    /// Gets or sets the name of this event definition.
    abstract name: string with get, set
    abstract roles: ResizeArray<NotificationEventRole> with get, set
    /// Gets or sets the scopes that this event type supports
    abstract supportedScopes: ResizeArray<string> with get, set
    /// Gets or sets the rest end point to get this event type details (fields, fields types)
    abstract url: string with get, set

/// Encapsulates the properties of a category. A category will be used by the UI to group event types
type [<AllowNullLiteral>] NotificationEventTypeCategory =
    /// Gets or sets the unique identifier of this category.
    abstract id: string with get, set
    /// Gets or sets the friendly name of this category.
    abstract name: string with get, set

type [<AllowNullLiteral>] NotificationJobDiagnosticLog =
    inherit NotificationDiagnosticLog
    abstract result: string with get, set
    abstract stats: MatcherResultStats with get, set

type [<RequireQualifiedAccess>] NotificationOperation =
    | None = 0
    | SuspendUnprocessed = 1

type [<AllowNullLiteral>] NotificationQueryCondition =
    abstract eventInitiator: string with get, set
    abstract eventType: string with get, set
    abstract subscriber: string with get, set
    abstract subscriptionId: string with get, set

type [<AllowNullLiteral>] NotificationReason =
    abstract notificationReasonType: NotificationReasonType with get, set
    abstract targetIdentities: ResizeArray<WebApi.IdentityRef> with get, set

type [<RequireQualifiedAccess>] NotificationReasonType =
    | Unknown = 0
    | Follows = 1
    | Personal = 2
    | PersonalAlias = 3
    | DirectMember = 4
    | IndirectMember = 5
    | GroupAlias = 6
    | SubscriptionAlias = 7
    | SingleRole = 8
    | DirectMemberGroupRole = 9
    | InDirectMemberGroupRole = 10
    | AliasMemberGroupRole = 11

/// Encapsulates notifications result properties. It defines the number of notifications and the recipients of notifications.
type [<AllowNullLiteral>] NotificationsEvaluationResult =
    /// Count of generated notifications
    abstract count: int with get, set

type [<AllowNullLiteral>] NotificationStatistic =
    abstract date: DateTime with get, set
    abstract hitCount: int with get, set
    abstract path: string with get, set
    abstract ``type``: NotificationStatisticType with get, set
    abstract user: WebApi.IdentityRef with get, set

type [<AllowNullLiteral>] NotificationStatisticsQuery =
    abstract conditions: ResizeArray<NotificationStatisticsQueryConditions> with get, set

type [<AllowNullLiteral>] NotificationStatisticsQueryConditions =
    abstract endDate: DateTime with get, set
    abstract hitCountMinimum: int with get, set
    abstract path: string with get, set
    abstract startDate: DateTime with get, set
    abstract ``type``: NotificationStatisticType with get, set
    abstract user: WebApi.IdentityRef with get, set

type [<RequireQualifiedAccess>] NotificationStatisticType =
    | NotificationBySubscription = 0
    | EventsByEventType = 1
    | NotificationByEventType = 2
    | EventsByEventTypePerUser = 3
    | NotificationByEventTypePerUser = 4
    | Events = 5
    | Notifications = 6
    | NotificationFailureBySubscription = 7
    | UnprocessedRangeStart = 100
    | UnprocessedEventsByPublisher = 101
    | UnprocessedEventDelayByPublisher = 102
    | UnprocessedNotificationsByChannelByPublisher = 103
    | UnprocessedNotificationDelayByChannelByPublisher = 104
    | DelayRangeStart = 200
    | TotalPipelineTime = 201
    | NotificationPipelineTime = 202
    | EventPipelineTime = 203
    | HourlyRangeStart = 1000
    | HourlyNotificationBySubscription = 1001
    | HourlyEventsByEventTypePerUser = 1002
    | HourlyEvents = 1003
    | HourlyNotifications = 1004
    | HourlyUnprocessedEventsByPublisher = 1101
    | HourlyUnprocessedEventDelayByPublisher = 1102
    | HourlyUnprocessedNotificationsByChannelByPublisher = 1103
    | HourlyUnprocessedNotificationDelayByChannelByPublisher = 1104
    | HourlyTotalPipelineTime = 1201
    | HourlyNotificationPipelineTime = 1202
    | HourlyEventPipelineTime = 1203

/// A subscriber is a user or group that has the potential to receive notifications.
type [<AllowNullLiteral>] NotificationSubscriber =
    /// Indicates how the subscriber should be notified by default.
    abstract deliveryPreference: NotificationSubscriberDeliveryPreference with get, set
    abstract flags: SubscriberFlags with get, set
    /// Identifier of the subscriber.
    abstract id: string with get, set
    /// Preferred email address of the subscriber. A null or empty value indicates no preferred email address has been set.
    abstract preferredEmailAddress: string with get, set

type [<RequireQualifiedAccess>] NotificationSubscriberDeliveryPreference =
    | NoDelivery = -1
    | PreferredEmailAddress = 1
    | EachMember = 2
    | UseDefault = 3

/// Updates to a subscriber. Typically used to change (or set) a preferred email address or default delivery preference.
type [<AllowNullLiteral>] NotificationSubscriberUpdateParameters =
    /// New delivery preference for the subscriber (indicates how the subscriber should be notified).
    abstract deliveryPreference: NotificationSubscriberDeliveryPreference with get, set
    /// New preferred email address for the subscriber. Specify an empty string to clear the current address.
    abstract preferredEmailAddress: string with get, set

/// A subscription defines criteria for matching events and how the subscription's subscriber should be notified about those events.
type [<AllowNullLiteral>] NotificationSubscription =
    /// Links to related resources, APIs, and views for the subscription.
    abstract _links: obj option with get, set
    /// Admin-managed settings for the subscription. Only applies when the subscriber is a group.
    abstract adminSettings: SubscriptionAdminSettings with get, set
    /// Channel for delivering notifications triggered by the subscription.
    abstract channel: ISubscriptionChannel with get, set
    /// Description of the subscription. Typically describes filter criteria which helps identity the subscription.
    abstract description: string with get, set
    /// Diagnostics for this subscription.
    abstract diagnostics: SubscriptionDiagnostics with get, set
    /// Any extra properties like detailed description for different contexts, user/group contexts
    abstract extendedProperties: EventTransformRequestSystemInputs with get, set
    /// Matching criteria for the subscription. ExpressionFilter
    abstract filter: ISubscriptionFilter with get, set
    /// Read-only indicators that further describe the subscription.
    abstract flags: SubscriptionFlags with get, set
    /// Subscription identifier.
    abstract id: string with get, set
    /// User that last modified (or created) the subscription.
    abstract lastModifiedBy: WebApi.IdentityRef with get, set
    /// Date when the subscription was last modified. If the subscription has not been updated since it was created, this value will indicate when the subscription was created.
    abstract modifiedDate: DateTime with get, set
    /// The permissions the user have for this subscriptions.
    abstract permissions: SubscriptionPermissions with get, set
    /// The container in which events must be published from in order to be matched by the subscription. If empty, the scope is the current host (typically an account or project collection). For example, a subscription scoped to project A will not produce notifications for events published from project B.
    abstract scope: SubscriptionScope with get, set
    /// Status of the subscription. Typically indicates whether the subscription is enabled or not.
    abstract status: SubscriptionStatus with get, set
    /// Message that provides more details about the status of the subscription.
    abstract statusMessage: string with get, set
    /// User or group that will receive notifications for events matching the subscription's filter criteria.
    abstract subscriber: WebApi.IdentityRef with get, set
    /// REST API URL of the subscriotion.
    abstract url: string with get, set
    /// User-managed settings for the subscription. Only applies when the subscriber is a group. Typically used to indicate whether the calling user is opted in or out of a group subscription.
    abstract userSettings: SubscriptionUserSettings with get, set

/// Parameters for creating a new subscription. A subscription defines criteria for matching events and how the subscription's subscriber should be notified about those events.
type [<AllowNullLiteral>] NotificationSubscriptionCreateParameters =
    /// Channel for delivering notifications triggered by the new subscription.
    abstract channel: ISubscriptionChannel with get, set
    /// Brief description for the new subscription. Typically describes filter criteria which helps identity the subscription.
    abstract description: string with get, set
    /// Matching criteria for the new subscription. ExpressionFilter
    abstract filter: ISubscriptionFilter with get, set
    /// The container in which events must be published from in order to be matched by the new subscription. If not specified, defaults to the current host (typically an account or project collection). For example, a subscription scoped to project A will not produce notifications for events published from project B.
    abstract scope: SubscriptionScope with get, set
    /// User or group that will receive notifications for events matching the subscription's filter criteria. If not specified, defaults to the calling user.
    abstract subscriber: WebApi.IdentityRef with get, set

type [<AllowNullLiteral>] NotificationSubscriptionTemplate =
    abstract description: string with get, set
    abstract filter: ISubscriptionFilter with get, set
    abstract id: string with get, set
    abstract notificationEventInformation: NotificationEventType with get, set
    abstract ``type``: SubscriptionTemplateType with get, set

/// Parameters for updating an existing subscription. A subscription defines criteria for matching events and how the subscription's subscriber should be notified about those events. Note: only the fields to be updated should be set.
type [<AllowNullLiteral>] NotificationSubscriptionUpdateParameters =
    /// Admin-managed settings for the subscription. Only applies to subscriptions where the subscriber is a group.
    abstract adminSettings: SubscriptionAdminSettings with get, set
    /// Channel for delivering notifications triggered by the subscription.
    abstract channel: ISubscriptionChannel with get, set
    /// Updated description for the subscription. Typically describes filter criteria which helps identity the subscription.
    abstract description: string with get, set
    /// Matching criteria for the subscription. ExpressionFilter
    abstract filter: ISubscriptionFilter with get, set
    /// The container in which events must be published from in order to be matched by the new subscription. If not specified, defaults to the current host (typically the current account or project collection). For example, a subscription scoped to project A will not produce notifications for events published from project B.
    abstract scope: SubscriptionScope with get, set
    /// Updated status for the subscription. Typically used to enable or disable a subscription.
    abstract status: SubscriptionStatus with get, set
    /// Optional message that provides more details about the updated status.
    abstract statusMessage: string with get, set
    /// User-managed settings for the subscription. Only applies to subscriptions where the subscriber is a group. Typically used to opt-in or opt-out a user from a group subscription.
    abstract userSettings: SubscriptionUserSettings with get, set

/// Encapsulates the properties of an operator constraint. An operator constraint defines if some operator is available only for specific scope like a project scope.
type [<AllowNullLiteral>] OperatorConstraint =
    abstract operator: string with get, set
    /// Gets or sets the list of scopes that this type supports.
    abstract supportedScopes: ResizeArray<string> with get, set

type [<AllowNullLiteral>] ProcessedEvent =
    /// All of the users that were associated with this event and their role.
    abstract actors: ResizeArray<WebApi.EventActor> with get, set
    abstract allowedChannels: string with get, set
    abstract artifactUri: string with get, set
    abstract deliveryIdentities: ProcessingIdentities with get, set
    /// Evaluations for each user
    abstract evaluations: ProcessedEventEvaluations with get, set
    abstract eventId: int with get, set
    /// Which members were excluded from evaluation (only applies to ActorMatcher subscriptions)
    abstract exclusions: ResizeArray<WebApi.EventActor> with get, set
    /// Which members were included for evaluation (only applies to ActorMatcher subscriptions)
    abstract inclusions: ResizeArray<WebApi.EventActor> with get, set
    abstract notifications: ResizeArray<GeneratedNotification> with get, set

type [<AllowNullLiteral>] ProcessingDiagnosticIdentity =
    inherit DiagnosticIdentity
    abstract deliveryPreference: string with get, set
    abstract isActive: bool with get, set
    abstract isGroup: bool with get, set
    abstract message: string with get, set

type [<AllowNullLiteral>] ProcessingIdentities =
    abstract excludedIdentities: ProcessingIdentitiesExcludedIdentities with get, set
    abstract includedIdentities: ProcessingIdentitiesExcludedIdentities with get, set
    abstract messages: ResizeArray<NotificationDiagnosticLogMessage> with get, set
    abstract missingIdentities: ResizeArray<string> with get, set
    abstract properties: EventTransformRequestSystemInputs with get, set

type [<AllowNullLiteral>] RoleBasedFilter =
    inherit ExpressionFilter
    abstract exclusions: ResizeArray<string> with get, set
    abstract inclusions: ResizeArray<string> with get, set

type [<AllowNullLiteral>] ServiceBusSubscriptionChannel =
    abstract ``type``: string with get, set

type [<AllowNullLiteral>] ServiceHooksSubscriptionChannel =
    abstract ``type``: string with get, set

type [<AllowNullLiteral>] SoapSubscriptionChannel =
    inherit SubscriptionChannelWithAddress
    abstract ``type``: string with get, set

type [<RequireQualifiedAccess>] SubscriberFlags =
    | None = 0
    | DeliveryPreferencesEditable = 2
    | SupportsPreferredEmailAddressDelivery = 4
    | SupportsEachMemberDelivery = 8
    | SupportsNoDelivery = 16
    | IsUser = 32
    | IsGroup = 64
    | IsTeam = 128

/// Admin-managed settings for a group subscription.
type [<AllowNullLiteral>] SubscriptionAdminSettings =
    /// If true, members of the group subscribed to the associated subscription cannot opt (choose not to get notified)
    abstract blockUserOptOut: bool with get, set

type [<AllowNullLiteral>] SubscriptionChannelWithAddress =
    abstract address: string with get, set
    abstract ``type``: string with get, set
    abstract useCustomAddress: bool with get, set

/// Contains all the diagonstics settings for a subscription.
type [<AllowNullLiteral>] SubscriptionDiagnostics =
    /// Diagnostics settings for retaining delivery results.  Used for Service Hooks subscriptions.
    abstract deliveryResults: SubscriptionTracing with get, set
    /// Diagnostics settings for troubleshooting notification delivery.
    abstract deliveryTracing: SubscriptionTracing with get, set
    /// Diagnostics settings for troubleshooting event matching.
    abstract evaluationTracing: SubscriptionTracing with get, set

type [<AllowNullLiteral>] SubscriptionEvaluation =
    abstract clauses: ResizeArray<SubscriptionEvaluationClause> with get, set
    abstract user: DiagnosticIdentity with get, set

type [<AllowNullLiteral>] SubscriptionEvaluationClause =
    abstract clause: string with get, set
    abstract order: int with get, set
    abstract result: bool with get, set

/// Encapsulates the properties of a SubscriptionEvaluationRequest. It defines the subscription to be evaluated and time interval for events used in evaluation.
type [<AllowNullLiteral>] SubscriptionEvaluationRequest =
    /// The min created date for the events used for matching in UTC. Use all events created since this date
    abstract minEventsCreatedDate: DateTime with get, set
    /// User or group that will receive notifications for events matching the subscription's filter criteria. If not specified, defaults to the calling user.
    abstract subscriptionCreateParameters: NotificationSubscriptionCreateParameters with get, set

/// Encapsulates the subscription evaluation results. It defines the Date Interval that was used, number of events evaluated and events and notifications results
type [<AllowNullLiteral>] SubscriptionEvaluationResult =
    /// Subscription evaluation job status
    abstract evaluationJobStatus: EvaluationOperationStatus with get, set
    /// Subscription evaluation events results.
    abstract events: EventsEvaluationResult with get, set
    /// The requestId which is the subscription evaluation jobId
    abstract id: string with get, set
    /// Subscription evaluation  notification results.
    abstract notifications: NotificationsEvaluationResult with get, set

/// Encapsulates the subscription evaluation settings needed for the UI
type [<AllowNullLiteral>] SubscriptionEvaluationSettings =
    /// Indicates whether subscription evaluation before saving is enabled or not
    abstract enabled: bool with get, set
    /// Time interval to check on subscription evaluation job in seconds
    abstract interval: int with get, set
    /// Threshold on the number of notifications for considering a subscription too noisy
    abstract threshold: int with get, set
    /// Time out for the subscription evaluation check in seconds
    abstract timeOut: int with get, set

type [<RequireQualifiedAccess>] SubscriptionFieldType =
    | String = 1
    | Integer = 2
    | DateTime = 3
    | PlainText = 5
    | Html = 7
    | TreePath = 8
    | History = 9
    | Double = 10
    | Guid = 11
    | Boolean = 12
    | Identity = 13
    | PicklistInteger = 14
    | PicklistString = 15
    | PicklistDouble = 16
    | TeamProject = 17

type [<RequireQualifiedAccess>] SubscriptionFlags =
    | None = 0
    | GroupSubscription = 1
    | ContributedSubscription = 2
    | CanOptOut = 4
    | TeamSubscription = 8
    | OneActorMatches = 16

/// Encapsulates the properties needed to manage subscriptions, opt in and out of subscriptions.
type [<AllowNullLiteral>] SubscriptionManagement =
    abstract serviceInstanceType: string with get, set
    abstract url: string with get, set

type [<RequireQualifiedAccess>] SubscriptionPermissions =
    | None = 0
    | View = 1
    | Edit = 2
    | Delete = 4

/// Notification subscriptions query input.
type [<AllowNullLiteral>] SubscriptionQuery =
    /// One or more conditions to query on. If more than 2 conditions are specified, the combined results of each condition is returned (i.e. conditions are logically OR'ed).
    abstract conditions: ResizeArray<SubscriptionQueryCondition> with get, set
    /// Flags the refine the types of subscriptions that will be returned from the query.
    abstract queryFlags: SubscriptionQueryFlags with get, set

/// Conditions a subscription must match to qualify for the query result set. Not all fields are required. A subscription must match all conditions specified in order to qualify for the result set.
type [<AllowNullLiteral>] SubscriptionQueryCondition =
    /// Filter conditions that matching subscriptions must have. Typically only the filter's type and event type are used for matching.
    abstract filter: ISubscriptionFilter with get, set
    /// Flags to specify the the type subscriptions to query for.
    abstract flags: SubscriptionFlags with get, set
    /// Scope that matching subscriptions must have.
    abstract scope: string with get, set
    /// ID of the subscriber (user or group) that matching subscriptions must be subscribed to.
    abstract subscriberId: string with get, set
    /// ID of the subscription to query for.
    abstract subscriptionId: string with get, set

type [<RequireQualifiedAccess>] SubscriptionQueryFlags =
    | None = 0
    | IncludeInvalidSubscriptions = 2
    | IncludeDeletedSubscriptions = 4
    | IncludeFilterDetails = 8
    | AlwaysReturnBasicInformation = 16
    | IncludeSystemSubscriptions = 32

/// A resource, typically an account or project, in which events are published from.
type [<AllowNullLiteral>] SubscriptionScope =
    inherit WebApi.EventScope

type [<RequireQualifiedAccess>] SubscriptionStatus =
    | JailedByNotificationsVolume = -200
    | PendingDeletion = -100
    | DisabledArgumentException = -12
    | DisabledProjectInvalid = -11
    | DisabledMissingPermissions = -10
    | DisabledFromProbation = -9
    | DisabledInactiveIdentity = -8
    | DisabledMessageQueueNotSupported = -7
    | DisabledMissingIdentity = -6
    | DisabledInvalidRoleExpression = -5
    | DisabledInvalidPathClause = -4
    | DisabledAsDuplicateOfDefault = -3
    | DisabledByAdmin = -2
    | Disabled = -1
    | Enabled = 0
    | EnabledOnProbation = 1

type [<RequireQualifiedAccess>] SubscriptionTemplateQueryFlags =
    | None = 0
    | IncludeUser = 1
    | IncludeGroup = 2
    | IncludeUserAndGroup = 4
    | IncludeEventTypeInformation = 22

type [<RequireQualifiedAccess>] SubscriptionTemplateType =
    | User = 0
    | Team = 1
    | Both = 2
    | None = 3

type [<AllowNullLiteral>] SubscriptionTraceDiagnosticLog =
    inherit NotificationDiagnosticLog
    /// Indicates the job Id that processed or delivered this subscription
    abstract jobId: string with get, set
    /// Indicates unique instance identifier for the job that processed or delivered this subscription
    abstract jobInstanceId: string with get, set
    abstract subscriptionId: string with get, set

type [<AllowNullLiteral>] SubscriptionTraceEventProcessingLog =
    inherit SubscriptionTraceDiagnosticLog
    abstract channel: string with get, set
    abstract evaluationIdentities: ProcessingIdentities with get, set
    /// Which members opted out from receiving notifications from this subscription
    abstract optedOut: ResizeArray<DiagnosticIdentity> with get, set
    abstract processedEvents: SubscriptionTraceEventProcessingLogProcessedEvents with get, set

type [<AllowNullLiteral>] SubscriptionTraceNotificationDeliveryLog =
    inherit SubscriptionTraceDiagnosticLog
    abstract notifications: ResizeArray<DiagnosticNotification> with get, set

/// Data controlling a single diagnostic setting for a subscription.
type [<AllowNullLiteral>] SubscriptionTracing =
    /// Indicates whether the diagnostic tracing is enabled or not.
    abstract enabled: bool with get, set
    /// Trace until the specified end date.
    abstract endDate: DateTime with get, set
    /// The maximum number of result details to trace.
    abstract maxTracedEntries: int with get, set
    /// The date and time tracing started.
    abstract startDate: DateTime with get, set
    /// Trace until remaining count reaches 0.
    abstract tracedEntries: int with get, set

/// User-managed settings for a group subscription.
type [<AllowNullLiteral>] SubscriptionUserSettings =
    /// Indicates whether the user will receive notifications for the associated group subscription.
    abstract optedOut: bool with get, set

type [<AllowNullLiteral>] UnsupportedFilter =
    inherit BaseSubscriptionFilter
    abstract ``type``: string with get, set

type [<AllowNullLiteral>] UnsupportedSubscriptionChannel =
    abstract ``type``: string with get, set

/// Parameters to update diagnostics settings for a subscription.
type [<AllowNullLiteral>] UpdateSubscripitonDiagnosticsParameters =
    /// Diagnostics settings for retaining delivery results.  Used for Service Hooks subscriptions.
    abstract deliveryResults: UpdateSubscripitonTracingParameters with get, set
    /// Diagnostics settings for troubleshooting notification delivery.
    abstract deliveryTracing: UpdateSubscripitonTracingParameters with get, set
    /// Diagnostics settings for troubleshooting event matching.
    abstract evaluationTracing: UpdateSubscripitonTracingParameters with get, set

/// Parameters to update a specific diagnostic setting.
type [<AllowNullLiteral>] UpdateSubscripitonTracingParameters =
    /// Indicates whether to enable to disable the diagnostic tracing.
    abstract enabled: bool with get, set

type [<AllowNullLiteral>] UserSubscriptionChannel =
    inherit SubscriptionChannelWithAddress
    abstract ``type``: string with get, set

type [<AllowNullLiteral>] UserSystemSubscriptionChannel =
    inherit SubscriptionChannelWithAddress
    abstract ``type``: string with get, set

/// Encapsulates the properties of a field value definition. It has the information needed to retrieve the list of possible values for a certain field and how to handle that field values in the UI. This information includes what type of object this value represents, which property to use for UI display and which property to use for saving the subscription
type [<AllowNullLiteral>] ValueDefinition =
    /// Gets or sets the data source.
    abstract dataSource: ResizeArray<FormInput.InputValue> with get, set
    /// Gets or sets the rest end point.
    abstract endPoint: string with get, set
    /// Gets or sets the result template.
    abstract resultTemplate: string with get, set

type [<AllowNullLiteral>] DiagnosticNotificationRecipients =
    [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> DiagnosticRecipient with get, set

type [<AllowNullLiteral>] DiagnosticNotificationStats =
    [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> float with get, set

type [<AllowNullLiteral>] EventTransformRequestSystemInputs =
    [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> string with get, set

type [<AllowNullLiteral>] MatcherResultStats =
    [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> DiagnosticNotificationStats with get, set

type [<AllowNullLiteral>] NotificationEventTypeFields =
    [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> NotificationEventField with get, set

type [<AllowNullLiteral>] ProcessedEventEvaluations =
    [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> SubscriptionEvaluation with get, set

type [<AllowNullLiteral>] ProcessingIdentitiesExcludedIdentities =
    [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> ProcessingDiagnosticIdentity with get, set

type [<AllowNullLiteral>] SubscriptionTraceEventProcessingLogProcessedEvents =
    [<Emit "$0[$1]{{=$2}}">] abstract Item: key: int -> ProcessedEvent with get, set
