// ts2fable 0.7.1
module rec NotificationClient
open System
open Fable.Core
open Fable.Core.JS

type IVssRestClientOptions = Context.IVssRestClientOptions
type RestClientBase = RestClientBase.RestClientBase

type [<AllowNullLiteral>] IExports =
    abstract NotificationRestClient: NotificationRestClientStatic

type [<AllowNullLiteral>] NotificationRestClient =
    inherit RestClientBase
    /// <param name="operation">-</param>
    abstract performBatchNotificationOperations: operation: Notification.BatchNotificationOperation -> Promise<unit>
    /// <summary>Get a list of diagnostic logs for this service.</summary>
    /// <param name="source">- ID specifying which type of logs to check diagnostics for.</param>
    /// <param name="entryId">- The ID of the specific log to query for.</param>
    /// <param name="startTime">- Start time for the time range to query in.</param>
    /// <param name="endTime">- End time for the time range to query in.</param>
    abstract listLogs: source: string * ?entryId: string * ?startTime: DateTime * ?endTime: DateTime -> Promise<ResizeArray<Notification.INotificationDiagnosticLog>>
    /// <summary>Get the diagnostics settings for a subscription.</summary>
    /// <param name="subscriptionId">- The id of the notifications subscription.</param>
    abstract getSubscriptionDiagnostics: subscriptionId: string -> Promise<Notification.SubscriptionDiagnostics>
    /// <summary>Update the diagnostics settings for a subscription.</summary>
    /// <param name="updateParameters">-</param>
    /// <param name="subscriptionId">- The id of the notifications subscription.</param>
    abstract updateSubscriptionDiagnostics: updateParameters: Notification.UpdateSubscripitonDiagnosticsParameters * subscriptionId: string -> Promise<Notification.SubscriptionDiagnostics>
    /// <summary>Publish an event. This request must be directed to the service "extmgmt".</summary>
    /// <param name="notificationEvent">-</param>
    abstract publishEvent: notificationEvent: WebApi.VssNotificationEvent -> Promise<WebApi.VssNotificationEvent>
    /// <summary>Tranform a notification event.</summary>
    /// <param name="transformRequest">- Object to be transformed.</param>
    abstract transformEvent: transformRequest: Notification.EventTransformRequest -> Promise<Notification.EventTransformResult>
    /// <param name="inputValuesQuery">-</param>
    /// <param name="eventType">-</param>
    abstract queryEventTypes: inputValuesQuery: Notification.FieldValuesQuery * eventType: string -> Promise<ResizeArray<Notification.NotificationEventField>>
    /// <summary>Get a specific event type.</summary>
    /// <param name="eventType">- The ID of the event type.</param>
    abstract getEventType: eventType: string -> Promise<Notification.NotificationEventType>
    /// <summary>List available event types for this service. Optionally filter by only event types for the specified publisher.</summary>
    /// <param name="publisherId">- Limit to event types for this publisher</param>
    abstract listEventTypes: ?publisherId: string -> Promise<ResizeArray<Notification.NotificationEventType>>
    /// <param name="notificationId">-</param>
    abstract getNotificationReasons: notificationId: int -> Promise<Notification.NotificationReason>
    /// <param name="notificationIds">-</param>
    abstract listNotificationReasons: ?notificationIds: int -> Promise<ResizeArray<Notification.NotificationReason>>
    abstract getSettings: unit -> Promise<Notification.NotificationAdminSettings>
    /// <param name="updateParameters">-</param>
    abstract updateSettings: updateParameters: Notification.NotificationAdminSettingsUpdateParameters -> Promise<Notification.NotificationAdminSettings>
    /// <summary>Get delivery preferences of a notifications subscriber.</summary>
    /// <param name="subscriberId">- ID of the user or group.</param>
    abstract getSubscriber: subscriberId: string -> Promise<Notification.NotificationSubscriber>
    /// <summary>Update delivery preferences of a notifications subscriber.</summary>
    /// <param name="updateParameters">-</param>
    /// <param name="subscriberId">- ID of the user or group.</param>
    abstract updateSubscriber: updateParameters: Notification.NotificationSubscriberUpdateParameters * subscriberId: string -> Promise<Notification.NotificationSubscriber>
    /// <summary>Query for subscriptions. A subscription is returned if it matches one or more of the specified conditions.</summary>
    /// <param name="subscriptionQuery">-</param>
    abstract querySubscriptions: subscriptionQuery: Notification.SubscriptionQuery -> Promise<ResizeArray<Notification.NotificationSubscription>>
    /// <summary>Create a new subscription.</summary>
    /// <param name="createParameters">-</param>
    abstract createSubscription: createParameters: Notification.NotificationSubscriptionCreateParameters -> Promise<Notification.NotificationSubscription>
    /// <summary>Delete a subscription.</summary>
    /// <param name="subscriptionId">-</param>
    abstract deleteSubscription: subscriptionId: string -> Promise<unit>
    /// <summary>Get a notification subscription by its ID.</summary>
    /// <param name="subscriptionId">-</param>
    /// <param name="queryFlags">-</param>
    abstract getSubscription: subscriptionId: string * ?queryFlags: Notification.SubscriptionQueryFlags -> Promise<Notification.NotificationSubscription>
    /// <summary>Get a list of notification subscriptions, either by subscription IDs or by all subscriptions for a given user or group.</summary>
    /// <param name="targetId">- User or Group ID</param>
    /// <param name="ids">- List of subscription IDs</param>
    /// <param name="queryFlags">-</param>
    abstract listSubscriptions: ?targetId: string * ?ids: ResizeArray<string> * ?queryFlags: Notification.SubscriptionQueryFlags -> Promise<ResizeArray<Notification.NotificationSubscription>>
    /// <summary>Update an existing subscription. Depending on the type of subscription and permissions, the caller can update the description, filter settings, channel (delivery) settings and more.</summary>
    /// <param name="updateParameters">-</param>
    /// <param name="subscriptionId">-</param>
    abstract updateSubscription: updateParameters: Notification.NotificationSubscriptionUpdateParameters * subscriptionId: string -> Promise<Notification.NotificationSubscription>
    /// Get available subscription templates.
    abstract getSubscriptionTemplates: unit -> Promise<ResizeArray<Notification.NotificationSubscriptionTemplate>>
    /// <summary>Update the specified user's settings for the specified subscription. This API is typically used to opt in or out of a shared subscription. User settings can only be applied to shared subscriptions, like team subscriptions or default subscriptions.</summary>
    /// <param name="userSettings">-</param>
    /// <param name="subscriptionId">-</param>
    /// <param name="userId">- ID of the user</param>
    abstract updateSubscriptionUserSettings: userSettings: Notification.SubscriptionUserSettings * subscriptionId: string * userId: string -> Promise<Notification.SubscriptionUserSettings>

type [<AllowNullLiteral>] NotificationRestClientStatic =
    [<Emit "new $0($1...)">] abstract Create: options: IVssRestClientOptions -> NotificationRestClient
