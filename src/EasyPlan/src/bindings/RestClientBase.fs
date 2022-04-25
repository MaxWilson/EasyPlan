// ts2fable 0.7.1
module rec RestClientBase
open System
open Fable.Core
open Fable.Core.JS


module RestClientBase =
    type IVssRestClientOptions = Context.IVssRestClientOptions

    type [<AllowNullLiteral>] IExports =
        abstract RestClientBase: RestClientBaseStatic

    /// Parameters for sending a WebApi request
    type [<AllowNullLiteral>] RestClientRequestParams =
        /// Route template that is used to form the request path. If routeTemplate is NOT specified, then locationId
        /// is used to lookup the template via an OPTIONS request.
        abstract routeTemplate: string with get, set
        /// The api version string to send in the request (e.g. "1.0" or "2.0-preview.2")
        abstract apiVersion: string with get, set
        /// Dictionary of route template replacement values
        abstract routeValues: RestClientRequestParamsRouteValues option with get, set
        /// Data to post. In this case of a GET, this indicates query parameters.
        /// For other requests, this is the request body object (which will be serialized
        /// into a JSON string unless isRawData is set to true).
        abstract body: obj option with get, set
        /// Query parameters to add to the url. In the case of a GET, query parameters can
        /// be supplied via 'data' or 'queryParams'. For other verbs such as POST, the
        /// data object specifies the POST body, so queryParams is needed to indicate
        /// parameters to add to the query string of the url (not included in the post body).
        abstract queryParams: RestClientRequestParamsRouteValues option with get, set
        /// HTTP verb (GET by default if not specified)
        abstract ``method``: string option with get, set
        /// The http response (Accept) type. This is "json" (corresponds to application/json Accept header)
        /// unless otherwise specified. Other possible values are "html", "text", "zip", or "binary" or their accept
        /// header equivalents (e.g. application/zip).
        abstract httpResponseType: string option with get, set
        /// Allows the caller to specify custom request headers.
        abstract customHeaders: RestClientRequestParamsCustomHeaders option with get, set
        /// If true, indicates that the raw Response should be returned in the request's resulting promise
        /// rather than deserializing the response (the default).
        abstract returnRawResponse: bool option with get, set
        /// If true, this indicates that no processing should be done on the 'data' object
        /// before it is sent in the request. *This is rarely needed*. One case is when posting
        /// an HTML5 File object.
        abstract isRawData: bool option with get, set
        /// Current command for activity logging. This will override the RestClient's base option.
        abstract command: string option with get, set

    /// Base class that should be used (derived from) to make requests to VSS REST apis
    type [<AllowNullLiteral>] RestClientBase =
        /// Gets the root path of the Service
        abstract getRootPath: unit -> Promise<string>
        /// <summary>Issue a request to a VSS REST endpoint.</summary>
        /// <param name="requestParams">request options</param>
        abstract beginRequest: requestParams: RestClientRequestParams -> Promise<'T>
        /// <summary>Issue a request to a VSS REST endpoint at the specified location</summary>
        /// <param name="requestUrl">Resolved URL of the request</param>
        /// <param name="apiVersion">API version</param>
        /// <param name="requestParams">Optional request parameters</param>
        abstract _issueRequest: requestUrl: string * apiVersion: string * requestParams: RestClientRequestParams -> Promise<'T>

    /// Base class that should be used (derived from) to make requests to VSS REST apis
    type [<AllowNullLiteral>] RestClientBaseStatic =
        [<Emit "new $0($1...)">] abstract Create: options: IVssRestClientOptions -> RestClientBase

    type [<AllowNullLiteral>] RestClientRequestParamsRouteValues =
        [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

    type [<AllowNullLiteral>] RestClientRequestParamsCustomHeaders =
        [<Emit "$0[$1]{{=$2}}">] abstract Item: headerName: string -> obj option with get, set
