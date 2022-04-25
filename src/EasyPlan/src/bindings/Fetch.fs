// ts2fable 0.7.1
module rec Fetch
open System
open Fable.Core
open Fable.Core.JS

type Error = System.Exception


module Fetch =
    type IAuthorizationTokenProvider = Context.IAuthorizationTokenProvider

    type [<AllowNullLiteral>] IExports =
        /// <summary>Issue a fetch request. This is a wrapper around the browser fetch method that handles VSS authentication
        /// and triggers events that can be listened to by other modules.</summary>
        /// <param name="requestUrl">Url to send the request to</param>
        /// <param name="options">fetch settings/options for the request</param>
        /// <param name="vssRequestOptions">VSS specific request options
        /// 
        /// Triggered Events:
        /// afterRequest -> IPostRequestEvent is sent after the request has completed.
        /// beforeRequest -> IPreRequestEvent is sent before the request is made.</param>
        abstract issueRequest: requestUrl: string * ?options: RequestInit * ?vssRequestOptions: IVssRequestOptions -> Promise<Response>

    /// VSS-specific options for VSS requests
    type [<AllowNullLiteral>] IVssRequestOptions =
        abstract authTokenProvider: IAuthorizationTokenProvider option with get, set
        /// Current session id.
        abstract sessionId: string option with get, set
        /// Current command for activity logging.
        abstract command: string option with get, set

    /// An IPreRequestEvent is sent before a fetch request is made.
    type [<AllowNullLiteral>] IPreRequestEvent =
        /// A unique id that can be used to track this particular request (id is unique among all clients)
        abstract requestId: float with get, set
        /// Url of the request that is about to be issued
        abstract requestUrl: string with get, set
        /// Request settings being used
        abstract options: RequestInit option with get, set
        /// Additional VSS-specific options supplied in the request
        abstract vssRequestOptions: IVssRequestOptions option with get, set

    /// An IPostRequestEvent is sent after a fetch request has completed.
    type [<AllowNullLiteral>] IPostRequestEvent =
        /// A unique id that can be used to track this particular request (id is unique among all clients)
        abstract requestId: float with get, set
        /// Url of the request that is about to be issued
        abstract requestUrl: string with get, set
        /// The Response returned for this request, if the request fails it will be undefined
        abstract response: Response option with get, set
        /// Additional VSS-specific options supplied in the request
        abstract vssRequestOptions: IVssRequestOptions option with get, set

    /// When a fetch request fails, it will throw a VssServerError. Failure is defined
    /// as a request that made it to the server, and the server successfully responded
    /// with a failure. This will be any status return that is not a status code in
    /// the success range (200-299).
    type [<AllowNullLiteral>] VssServerError =
        inherit Error
        /// The status code returned from the server.
        abstract status: float with get, set
        /// The raw text that was returned from the server. If any is available.
        abstract responseText: string with get, set
        /// If the response text was sent and it was in the form of a JSON response
        /// the object will be parsed and deserialized object is available here.
        /// 
        /// This commonly has the exception details about the failure from the server.
        /// Things like the message, exception type, and stack trace will be available.
        abstract serverError: obj option with get, set
