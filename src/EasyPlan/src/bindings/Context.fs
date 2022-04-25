// ts2fable 0.7.1
module rec Context
open System
open Fable.Core
open Fable.Core.JS


module Context =

    /// Interface for a class that can retrieve authorization tokens to be used in fetch requests.
    type [<AllowNullLiteral>] IAuthorizationTokenProvider =
        /// <summary>Gets the authorization header to use in a fetch request</summary>
        /// <param name="forceRefresh">- If true, indicates that we should get a new token, if applicable for current provider.</param>
        abstract getAuthorizationHeader: ?forceRefresh: bool -> Promise<string>

    /// Options for a specific instance of a REST client.
    type [<AllowNullLiteral>] IVssRestClientOptions =
        /// Auth token manager that can be used to get and attach auth tokens to requests.
        /// If not supplied, the default token provider is used if the serviceInstanceType option is supplied
        /// and is different from the hosting page's service instance type.
        abstract authTokenProvider: IAuthorizationTokenProvider option with get, set
        /// The root URL path to use for this client. Can be relative or absolute.
        abstract rootPath: U2<string, Promise<string>> option with get, set
        /// Current session id.
        abstract sessionId: string option with get, set
        /// Current command for activity logging.
        abstract command: string option with get, set
