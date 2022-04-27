// ts2fable 0.7.1
module rec ServiceHooks
open System
open Fable.Core
open Fable.Core.JS

type [<RequireQualifiedAccess>] AuthenticationType =
    | None = 0
    | OAuth = 10
    | External = 30

/// Defines the data contract of a consumer.
type [<AllowNullLiteral>] Consumer =
    /// Reference Links
    abstract _links: obj option with get, set
    /// Gets this consumer's actions.
    abstract actions: ResizeArray<ConsumerAction> with get, set
    /// Gets or sets this consumer's authentication type.
    abstract authenticationType: AuthenticationType with get, set
    /// Gets or sets this consumer's localized description.
    abstract description: string with get, set
    /// Non-null only if subscriptions for this consumer are configured externally.
    abstract externalConfiguration: ExternalConfigurationDescriptor with get, set
    /// Gets or sets this consumer's identifier.
    abstract id: string with get, set
    /// Gets or sets this consumer's image URL, if any.
    abstract imageUrl: string with get, set
    /// Gets or sets this consumer's information URL, if any.
    abstract informationUrl: string with get, set
    /// Gets or sets this consumer's input descriptors.
    abstract inputDescriptors: ResizeArray<FormInput.InputDescriptor> with get, set
    /// Gets or sets this consumer's localized name.
    abstract name: string with get, set
    /// The url for this resource
    abstract url: string with get, set

/// Defines the data contract of a consumer action.
type [<AllowNullLiteral>] ConsumerAction =
    /// Reference Links
    abstract _links: obj option with get, set
    /// Gets or sets the flag indicating if resource version can be overridden when creating or editing a subscription.
    abstract allowResourceVersionOverride: bool with get, set
    /// Gets or sets the identifier of the consumer to which this action belongs.
    abstract consumerId: string with get, set
    /// Gets or sets this action's localized description.
    abstract description: string with get, set
    /// Gets or sets this action's identifier.
    abstract id: string with get, set
    /// Gets or sets this action's input descriptors.
    abstract inputDescriptors: ResizeArray<FormInput.InputDescriptor> with get, set
    /// Gets or sets this action's localized name.
    abstract name: string with get, set
    /// Gets or sets this action's supported event identifiers.
    abstract supportedEventTypes: ResizeArray<string> with get, set
    /// Gets or sets this action's supported resource versions.
    abstract supportedResourceVersions: ConsumerActionSupportedResourceVersions with get, set
    /// The url for this resource
    abstract url: string with get, set

/// Encapsulates the properties of an event.
type [<AllowNullLiteral>] Event =
    /// Gets or sets the UTC-based date and time that this event was created.
    abstract createdDate: DateTime with get, set
    /// Gets or sets the detailed message associated with this event.
    abstract detailedMessage: FormattedEventMessage with get, set
    /// Gets or sets the type of this event.
    abstract eventType: string with get, set
    /// Gets or sets the unique identifier of this event.
    abstract id: string with get, set
    /// Gets or sets the (brief) message associated with this event.
    abstract message: FormattedEventMessage with get, set
    /// Gets or sets the identifier of the publisher that raised this event.
    abstract publisherId: string with get, set
    /// Gets or sets the data associated with this event.
    abstract resource: obj option with get, set
    /// Gets or sets the resource containers.
    abstract resourceContainers: EventResourceContainers with get, set
    /// Gets or sets the version of the data associated with this event.
    abstract resourceVersion: string with get, set
    /// Gets or sets the Session Token that can be used in further interactions
    abstract sessionToken: SessionToken with get, set

/// Describes a type of event
type [<AllowNullLiteral>] EventTypeDescriptor =
    /// A localized description of the event type
    abstract description: string with get, set
    /// A unique id for the event type
    abstract id: string with get, set
    /// Event-specific inputs
    abstract inputDescriptors: ResizeArray<FormInput.InputDescriptor> with get, set
    /// A localized friendly name for the event type
    abstract name: string with get, set
    /// A unique id for the publisher of this event type
    abstract publisherId: string with get, set
    /// Supported versions for the event's resource payloads.
    abstract supportedResourceVersions: ResizeArray<string> with get, set
    /// The url for this resource
    abstract url: string with get, set

/// Describes how to configure a subscription that is managed externally.
type [<AllowNullLiteral>] ExternalConfigurationDescriptor =
    /// Url of the site to create this type of subscription.
    abstract createSubscriptionUrl: string with get, set
    /// The name of an input property that contains the URL to edit a subscription.
    abstract editSubscriptionPropertyName: string with get, set
    /// True if the external configuration applies only to hosted.
    abstract hostedOnly: bool with get, set

/// Provides different formats of an event message
type [<AllowNullLiteral>] FormattedEventMessage =
    /// Gets or sets the html format of the message
    abstract html: string with get, set
    /// Gets or sets the markdown format of the message
    abstract markdown: string with get, set
    /// Gets or sets the raw text of the message
    abstract text: string with get, set

/// Defines the data contract of the result of processing an event for a subscription.
type [<AllowNullLiteral>] Notification =
    /// Gets or sets date and time that this result was created.
    abstract createdDate: DateTime with get, set
    /// Details about this notification (if available)
    abstract details: NotificationDetails with get, set
    /// The event id associated with this notification
    abstract eventId: string with get, set
    /// The notification id
    abstract id: int with get, set
    /// Gets or sets date and time that this result was last modified.
    abstract modifiedDate: DateTime with get, set
    /// Result of the notification
    abstract result: NotificationResult with get, set
    /// Status of the notification
    abstract status: NotificationStatus with get, set
    /// The subscriber Id  associated with this notification. This is the last identity who touched in the subscription. In case of test notifications it can be the tester if the subscription is not created yet.
    abstract subscriberId: string with get, set
    /// The subscription id associated with this notification
    abstract subscriptionId: string with get, set

/// Defines the data contract of notification details.
type [<AllowNullLiteral>] NotificationDetails =
    /// Gets or sets the time that this notification was completed (response received from the consumer)
    abstract completedDate: DateTime with get, set
    /// Gets or sets this notification detail's consumer action identifier.
    abstract consumerActionId: string with get, set
    /// Gets or sets this notification detail's consumer identifier.
    abstract consumerId: string with get, set
    /// Gets or sets this notification detail's consumer inputs.
    abstract consumerInputs: NotificationDetailsConsumerInputs with get, set
    /// Gets or sets the time that this notification was dequeued for processing
    abstract dequeuedDate: DateTime with get, set
    /// Gets or sets this notification detail's error detail.
    abstract errorDetail: string with get, set
    /// Gets or sets this notification detail's error message.
    abstract errorMessage: string with get, set
    /// Gets or sets this notification detail's event content.
    abstract ``event``: Event with get, set
    /// Gets or sets this notification detail's event type.
    abstract eventType: string with get, set
    /// Gets or sets the time that this notification was finished processing (just before the request is sent to the consumer)
    abstract processedDate: DateTime with get, set
    /// Gets or sets this notification detail's publisher identifier.
    abstract publisherId: string with get, set
    /// Gets or sets this notification detail's publisher inputs.
    abstract publisherInputs: NotificationDetailsConsumerInputs with get, set
    /// Gets or sets the time that this notification was queued (created)
    abstract queuedDate: DateTime with get, set
    /// Gets or sets this notification detail's request.
    abstract request: string with get, set
    /// Number of requests attempted to be sent to the consumer
    abstract requestAttempts: int with get, set
    /// Duration of the request to the consumer in seconds
    abstract requestDuration: int with get, set
    /// Gets or sets this notification detail's response.
    abstract response: string with get, set

type [<RequireQualifiedAccess>] NotificationResult =
    | Pending = 0
    | Succeeded = 10
    | Failed = 20
    | Filtered = 30

/// Summary of a particular result and count.
type [<AllowNullLiteral>] NotificationResultsSummaryDetail =
    /// Count of notification sent out with a matching result.
    abstract notificationCount: int with get, set
    /// Result of the notification
    abstract result: NotificationResult with get, set

/// Defines a query for service hook notifications.
type [<AllowNullLiteral>] NotificationsQuery =
    /// The subscriptions associated with the notifications returned from the query
    abstract associatedSubscriptions: ResizeArray<Subscription> with get, set
    /// If true, we will return all notification history for the query provided; otherwise, the summary is returned.
    abstract includeDetails: bool with get, set
    /// Optional maximum date at which the notification was created
    abstract maxCreatedDate: DateTime with get, set
    /// Optional maximum number of overall results to include
    abstract maxResults: int with get, set
    /// Optional maximum number of results for each subscription. Only takes effect when a list of subscription ids is supplied in the query.
    abstract maxResultsPerSubscription: int with get, set
    /// Optional minimum date at which the notification was created
    abstract minCreatedDate: DateTime with get, set
    /// Optional publisher id to restrict the results to
    abstract publisherId: string with get, set
    /// Results from the query
    abstract results: ResizeArray<Notification> with get, set
    /// Optional notification result type to filter results to
    abstract resultType: NotificationResult with get, set
    /// Optional notification status to filter results to
    abstract status: NotificationStatus with get, set
    /// Optional list of subscription ids to restrict the results to
    abstract subscriptionIds: ResizeArray<string> with get, set
    /// Summary of notifications - the count of each result type (success, fail, ..).
    abstract summary: ResizeArray<NotificationSummary> with get, set

type [<RequireQualifiedAccess>] NotificationStatus =
    | Queued = 10
    | Processing = 20
    | RequestInProgress = 30
    | Completed = 100

/// Summary of the notifications for a subscription.
type [<AllowNullLiteral>] NotificationSummary =
    /// The notification results for this particular subscription.
    abstract results: ResizeArray<NotificationResultsSummaryDetail> with get, set
    /// The subscription id associated with this notification
    abstract subscriptionId: string with get, set

/// Defines the data contract of an event publisher.
type [<AllowNullLiteral>] Publisher =
    /// Reference Links
    abstract _links: obj option with get, set
    /// Gets this publisher's localized description.
    abstract description: string with get, set
    /// Gets this publisher's identifier.
    abstract id: string with get, set
    /// Publisher-specific inputs
    abstract inputDescriptors: ResizeArray<FormInput.InputDescriptor> with get, set
    /// Gets this publisher's localized name.
    abstract name: string with get, set
    /// The service instance type of the first party publisher.
    abstract serviceInstanceType: string with get, set
    /// Gets this publisher's supported event types.
    abstract supportedEvents: ResizeArray<EventTypeDescriptor> with get, set
    /// The url for this resource
    abstract url: string with get, set

/// Wrapper around an event which is being published
type [<AllowNullLiteral>] PublisherEvent =
    /// Add key/value pairs which will be stored with a published notification in the SH service DB.  This key/value pairs are for diagnostic purposes only and will have not effect on the delivery of a notificaton.
    abstract diagnostics: NotificationDetailsConsumerInputs with get, set
    /// The event being published
    abstract ``event``: Event with get, set
    /// Gets or sets flag for filtered events
    abstract isFilteredEvent: bool with get, set
    /// Additional data that needs to be sent as part of notification to complement the Resource data in the Event
    abstract notificationData: NotificationDetailsConsumerInputs with get, set
    /// Gets or sets the array of older supported resource versions.
    abstract otherResourceVersions: ResizeArray<VersionedResource> with get, set
    /// Optional publisher-input filters which restricts the set of subscriptions which are triggered by the event
    abstract publisherInputFilters: ResizeArray<FormInput.InputFilter> with get, set
    /// Gets or sets matched hooks subscription which caused this event.
    abstract subscription: Subscription with get, set

/// Defines a query for service hook publishers.
type [<AllowNullLiteral>] PublishersQuery =
    /// Optional list of publisher ids to restrict the results to
    abstract publisherIds: ResizeArray<string> with get, set
    /// Filter for publisher inputs
    abstract publisherInputs: NotificationDetailsConsumerInputs with get, set
    /// Results from the query
    abstract results: ResizeArray<Publisher> with get, set

/// The base class for all resource containers, i.e. Account, Collection, Project
type [<AllowNullLiteral>] ResourceContainer =
    /// Gets or sets the container's base URL, i.e. the URL of the host (collection, application, or deployment) containing the container resource.
    abstract baseUrl: string with get, set
    /// Gets or sets the container's specific Id.
    abstract id: string with get, set
    /// Gets or sets the container's name.
    abstract name: string with get, set
    /// Gets or sets the container's REST API URL.
    abstract url: string with get, set

/// Represents a session token to be attached in Events for Consumer actions that need it.
type [<AllowNullLiteral>] SessionToken =
    /// The error message in case of error
    abstract error: string with get, set
    /// The access token
    abstract token: string with get, set
    /// The expiration date in UTC
    abstract validTo: DateTime with get, set

/// Encapsulates an event subscription.
type [<AllowNullLiteral>] Subscription =
    /// Reference Links
    abstract _links: obj option with get, set
    abstract actionDescription: string with get, set
    abstract consumerActionId: string with get, set
    abstract consumerId: string with get, set
    /// Consumer input values
    abstract consumerInputs: NotificationDetailsConsumerInputs with get, set
    abstract createdBy: WebApi.IdentityRef with get, set
    abstract createdDate: DateTime with get, set
    abstract eventDescription: string with get, set
    abstract eventType: string with get, set
    abstract id: string with get, set
    abstract modifiedBy: WebApi.IdentityRef with get, set
    abstract modifiedDate: DateTime with get, set
    abstract probationRetries: int with get, set
    abstract publisherId: string with get, set
    /// Publisher input values
    abstract publisherInputs: NotificationDetailsConsumerInputs with get, set
    abstract resourceVersion: string with get, set
    abstract status: SubscriptionStatus with get, set
    abstract subscriber: WebApi.IdentityRef with get, set
    abstract url: string with get, set

type [<RequireQualifiedAccess>] SubscriptionInputScope =
    | Publisher = 10
    | Consumer = 20

/// Query for obtaining information about the possible/allowed values for one or more subscription inputs
type [<AllowNullLiteral>] SubscriptionInputValuesQuery =
    /// The input values to return on input, and the result from the consumer on output.
    abstract inputValues: ResizeArray<FormInput.InputValues> with get, set
    /// The scope at which the properties to query belong
    abstract scope: SubscriptionInputScope with get, set
    /// Subscription containing information about the publisher/consumer and the current input values
    abstract subscription: Subscription with get, set

/// Defines a query for service hook subscriptions.
type [<AllowNullLiteral>] SubscriptionsQuery =
    /// Optional consumer action id to restrict the results to (null for any)
    abstract consumerActionId: string with get, set
    /// Optional consumer id to restrict the results to (null for any)
    abstract consumerId: string with get, set
    /// Filter for subscription consumer inputs
    abstract consumerInputFilters: ResizeArray<FormInput.InputFilter> with get, set
    /// Optional event type id to restrict the results to (null for any)
    abstract eventType: string with get, set
    /// Optional publisher id to restrict the results to (null for any)
    abstract publisherId: string with get, set
    /// Filter for subscription publisher inputs
    abstract publisherInputFilters: ResizeArray<FormInput.InputFilter> with get, set
    /// Results from the query
    abstract results: ResizeArray<Subscription> with get, set
    /// Optional subscriber filter.
    abstract subscriberId: string with get, set

type [<RequireQualifiedAccess>] SubscriptionStatus =
    | Enabled = 0
    | OnProbation = 10
    | DisabledByUser = 20
    | DisabledBySystem = 30
    | DisabledByInactiveIdentity = 40

/// Encapsulates the resource version and its data or reference to the compatible version. Only one of the two last fields should be not null.
type [<AllowNullLiteral>] VersionedResource =
    /// Gets or sets the reference to the compatible version.
    abstract compatibleWith: string with get, set
    /// Gets or sets the resource data.
    abstract resource: obj option with get, set
    /// Gets or sets the version of the resource data.
    abstract resourceVersion: string with get, set

type [<AllowNullLiteral>] ConsumerActionSupportedResourceVersions =
    [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> ResizeArray<string> with get, set

type [<AllowNullLiteral>] EventResourceContainers =
    [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> ResourceContainer with get, set

type [<AllowNullLiteral>] NotificationDetailsConsumerInputs =
    [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> string with get, set
