// ts2fable 0.7.1
module rec ServiceHooksClient
open System
open Fable.Core
open Fable.Core.JS


module ServiceHooksClient =
    module FormInput = ___FormInput_FormInput
    module Notification = ___Notification_Notification
    module ServiceHooks = ___ServiceHooks_ServiceHooks
    type IVssRestClientOptions = Context.IVssRestClientOptions
    type RestClientBase = RestClientBase.RestClientBase

    type [<AllowNullLiteral>] IExports =
        abstract ServiceHooksRestClient: ServiceHooksRestClientStatic

    type [<AllowNullLiteral>] ServiceHooksRestClient =
        inherit RestClientBase
        /// <summary>Get details about a specific consumer action.</summary>
        /// <param name="consumerId">- ID for a consumer.</param>
        /// <param name="consumerActionId">- ID for a consumerActionId.</param>
        /// <param name="publisherId">-</param>
        abstract getConsumerAction: consumerId: string * consumerActionId: string * ?publisherId: string -> Promise<ServiceHooks.ConsumerAction>
        /// <summary>Get a list of consumer actions for a specific consumer.</summary>
        /// <param name="consumerId">- ID for a consumer.</param>
        /// <param name="publisherId">-</param>
        abstract listConsumerActions: consumerId: string * ?publisherId: string -> Promise<ResizeArray<ServiceHooks.ConsumerAction>>
        /// <summary>Get a specific consumer service. Optionally filter out consumer actions that do not support any event types for the specified publisher.</summary>
        /// <param name="consumerId">- ID for a consumer.</param>
        /// <param name="publisherId">-</param>
        abstract getConsumer: consumerId: string * ?publisherId: string -> Promise<ServiceHooks.Consumer>
        /// <summary>Get a list of available service hook consumer services. Optionally filter by consumers that support at least one event type from the specific publisher.</summary>
        /// <param name="publisherId">-</param>
        abstract listConsumers: ?publisherId: string -> Promise<ResizeArray<ServiceHooks.Consumer>>
        /// <param name="subscriptionId">-</param>
        abstract getSubscriptionDiagnostics: subscriptionId: string -> Promise<Notification.SubscriptionDiagnostics>
        /// <param name="updateParameters">-</param>
        /// <param name="subscriptionId">-</param>
        abstract updateSubscriptionDiagnostics: updateParameters: Notification.UpdateSubscripitonDiagnosticsParameters * subscriptionId: string -> Promise<Notification.SubscriptionDiagnostics>
        /// <summary>Get a specific event type.</summary>
        /// <param name="publisherId">- ID for a publisher.</param>
        /// <param name="eventTypeId">-</param>
        abstract getEventType: publisherId: string * eventTypeId: string -> Promise<ServiceHooks.EventTypeDescriptor>
        /// <summary>Get the event types for a specific publisher.</summary>
        /// <param name="publisherId">- ID for a publisher.</param>
        abstract listEventTypes: publisherId: string -> Promise<ResizeArray<ServiceHooks.EventTypeDescriptor>>
        /// <summary>Publish an external event.</summary>
        /// <param name="publisherId">-</param>
        /// <param name="channelId">-</param>
        abstract publishExternalEvent: publisherId: string * ?channelId: string -> Promise<ResizeArray<ServiceHooks.PublisherEvent>>
        /// <summary>Get a specific notification for a subscription.</summary>
        /// <param name="subscriptionId">- ID for a subscription.</param>
        /// <param name="notificationId">-</param>
        abstract getNotification: subscriptionId: string * notificationId: float -> Promise<ServiceHooks.Notification>
        /// <summary>Get a list of notifications for a specific subscription. A notification includes details about the event, the request to and the response from the consumer service.</summary>
        /// <param name="subscriptionId">- ID for a subscription.</param>
        /// <param name="maxResults">- Maximum number of notifications to return. Default is **100**.</param>
        /// <param name="status">- Get only notifications with this status.</param>
        /// <param name="result">- Get only notifications with this result type.</param>
        abstract getNotifications: subscriptionId: string * ?maxResults: float * ?status: ServiceHooks.NotificationStatus * ?result: ServiceHooks.NotificationResult -> Promise<ResizeArray<ServiceHooks.Notification>>
        /// <summary>Query for notifications. A notification includes details about the event, the request to and the response from the consumer service.</summary>
        /// <param name="query">-</param>
        abstract queryNotifications: query: ServiceHooks.NotificationsQuery -> Promise<ServiceHooks.NotificationsQuery>
        /// <param name="inputValuesQuery">-</param>
        /// <param name="publisherId">-</param>
        abstract queryInputValues: inputValuesQuery: FormInput.InputValuesQuery * publisherId: string -> Promise<FormInput.InputValuesQuery>
        /// <summary>Get a specific service hooks publisher.</summary>
        /// <param name="publisherId">- ID for a publisher.</param>
        abstract getPublisher: publisherId: string -> Promise<ServiceHooks.Publisher>
        /// Get a list of publishers.
        abstract listPublishers: unit -> Promise<ResizeArray<ServiceHooks.Publisher>>
        /// <summary>Query for service hook publishers.</summary>
        /// <param name="query">-</param>
        abstract queryPublishers: query: ServiceHooks.PublishersQuery -> Promise<ServiceHooks.PublishersQuery>
        /// <summary>Create a subscription.</summary>
        /// <param name="subscription">- Subscription to be created.</param>
        abstract createSubscription: subscription: ServiceHooks.Subscription -> Promise<ServiceHooks.Subscription>
        /// <summary>Delete a specific service hooks subscription.</summary>
        /// <param name="subscriptionId">- ID for a subscription.</param>
        abstract deleteSubscription: subscriptionId: string -> Promise<unit>
        /// <summary>Get a specific service hooks subscription.</summary>
        /// <param name="subscriptionId">- ID for a subscription.</param>
        abstract getSubscription: subscriptionId: string -> Promise<ServiceHooks.Subscription>
        /// <summary>Get a list of subscriptions.</summary>
        /// <param name="publisherId">- ID for a subscription.</param>
        /// <param name="eventType">- The event type to filter on (if any).</param>
        /// <param name="consumerId">- ID for a consumer.</param>
        /// <param name="consumerActionId">- ID for a consumerActionId.</param>
        abstract listSubscriptions: ?publisherId: string * ?eventType: string * ?consumerId: string * ?consumerActionId: string -> Promise<ResizeArray<ServiceHooks.Subscription>>
        /// <summary>Update a subscription. \<param name="subscriptionId"\>ID for a subscription that you wish to update.\</param\></summary>
        /// <param name="subscription">-</param>
        /// <param name="subscriptionId">-</param>
        abstract replaceSubscription: subscription: ServiceHooks.Subscription * ?subscriptionId: string -> Promise<ServiceHooks.Subscription>
        /// <summary>Query for service hook subscriptions.</summary>
        /// <param name="query">-</param>
        abstract createSubscriptionsQuery: query: ServiceHooks.SubscriptionsQuery -> Promise<ServiceHooks.SubscriptionsQuery>
        /// <summary>Sends a test notification. This is useful for verifying the configuration of an updated or new service hooks subscription.</summary>
        /// <param name="testNotification">-</param>
        /// <param name="useRealData">- Only allow testing with real data in existing subscriptions.</param>
        abstract createTestNotification: testNotification: ServiceHooks.Notification * ?useRealData: bool -> Promise<ServiceHooks.Notification>

    type [<AllowNullLiteral>] ServiceHooksRestClientStatic =
        [<Emit "new $0($1...)">] abstract Create: options: IVssRestClientOptions -> ServiceHooksRestClient
