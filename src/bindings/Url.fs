// ts2fable 0.7.1
module rec Url
open System
open Fable.Core
open Fable.Core.JS

type Array<'T> = System.Collections.Generic.IList<'T>

type [<AllowNullLiteral>] IExports =
    abstract Uri: UriStatic
    /// <summary>Take url segments and join them with a single slash character. Takes care of path segements that start and/or end
    /// with a slash to ensure that the resulting URL does not have double-slashes</summary>
    /// <param name="paths">Path segments to concatenate</param>
    abstract combineUrlPaths: [<ParamArray>] paths: ResizeArray<string> -> string
    /// <summary>Parse a route template into a structure that can be used to quickly do route replacements</summary>
    /// <param name="routeTemplate">MVC route template string (like "/foo/{id}/{*params}")</param>
    abstract parseRouteTemplate: routeTemplate: string -> IParsedRoute
    /// <summary>Take a set of routes and route values and form a url using the best match. The best match
    /// is the route with the highest number of replacements (of the given routeValues dictionary).
    /// In the event of a tie (same number of replacements) the route that came first wins.</summary>
    /// <param name="routeCollection">Array of parsed routes</param>
    /// <param name="routeValues">Replacement values</param>
    abstract routeUrl: routeCollection: ResizeArray<IParsedRoute> * routeValues: RouteUrlRouteValues -> string
    /// <summary>Take a set of routes and find the best match. The best match is the route with the highest number of replacements
    /// (of the given routeValues dictionary). In the event of a tie (same number of replacements) the route that came first wins.</summary>
    /// <param name="routeCollection">Array of parsed routes</param>
    /// <param name="routeValues">Replacement values</param>
    abstract getBestRouteMatch: routeCollection: ResizeArray<IParsedRoute> * routeValues: GetBestRouteMatchRouteValues -> IRouteMatchResult option
    /// <summary>Replace route values for a specific parsed route</summary>
    /// <param name="parsedRoute">The route to evaluate</param>
    /// <param name="routeValues">Dictionary of route replacement parameters</param>
    /// <param name="continueOnUnmatchedSegements">If true, continue with replacements even after a miss. By default (false), stop replacements once a parameter is not present.</param>
    abstract replaceParsedRouteValues: parsedRoute: IParsedRoute * routeValues: ReplaceParsedRouteValuesRouteValues * ?continueOnUnmatchedSegements: bool -> IRouteMatchResult option
    /// <summary>Take an MVC route template (like "/foo/{id}/{*params}") and replace the templated parts with values from the given dictionary</summary>
    /// <param name="routeTemplate">MVC route template (like "/foo/{id}/{*params}")</param>
    /// <param name="routeValues">Route value replacements</param>
    abstract replaceRouteValues: routeTemplate: string * routeValues: ReplaceRouteValuesRouteValues -> string

type [<AllowNullLiteral>] RouteUrlRouteValues =
    [<Emit "$0[$1]{{=$2}}">] abstract Item: name: string -> string with get, set

type [<AllowNullLiteral>] GetBestRouteMatchRouteValues =
    [<Emit "$0[$1]{{=$2}}">] abstract Item: name: string -> string with get, set

type [<AllowNullLiteral>] ReplaceParsedRouteValuesRouteValues =
    [<Emit "$0[$1]{{=$2}}">] abstract Item: name: string -> U2<string, float> option with get, set

type [<AllowNullLiteral>] ReplaceRouteValuesRouteValues =
    [<Emit "$0[$1]{{=$2}}">] abstract Item: name: string -> U2<string, float> option with get, set

/// A single query parameter entry in a Uri
type [<AllowNullLiteral>] IQueryParameter =
    /// Unencoded name of the query parameter
    abstract name: string with get, set
    /// Unencoded value of the query parameter
    abstract value: string option with get, set

/// Options for parsing a Uri string
type [<AllowNullLiteral>] IUriParseOptions =
    /// If true, throw if the Uri is not absolute
    abstract absoluteUriRequired: bool option with get, set

type QueryParameterEntryValueType =
    U4<string, bool, float, DateTime> option

type QueryParameterValueType =
    U3<QueryParameterEntryValueType, Array<QueryParameterEntryValueType>, QueryParameterEntryValueType>

/// Class that represents a Uri and allows parsing/getting and setting of individual parts
type [<AllowNullLiteral>] Uri =
    /// The uri scheme such as http or https
    abstract scheme: string with get, set
    /// If true, do not emit the "//" separator after the scheme:
    /// Set to true for schemes like mailto (e.g. mailto:foo@bar)
    abstract noSchemeSeparator: bool with get, set
    /// The uri hostname (does not include port or scheme)
    abstract host: string with get, set
    /// The port number of the uri as supplied in the url. 0 if left out in the url (e.g. the default port for the scheme).
    abstract port: int with get, set
    /// The relative path of the uri
    abstract path: string with get, set
    /// The array of query parameters in the uri
    abstract queryParameters: ResizeArray<IQueryParameter> with get, set
    /// The hash string of the uri
    abstract hashString: string with get, set
    /// Set the absolute uri string for this Uri. Replaces all existing values
    abstract absoluteUri: string with get, set
    /// Gets the effective port number, returning the default port number if omitted for the given scheme.
    abstract getEffectivePort: unit -> float
    /// Set the query string for this Uri. Replaces existing value
    abstract queryString: string with get, set
    /// <summary>Get the value of the query parameter with the given key</summary>
    /// <param name="name">Query parameter name</param>
    abstract getQueryParam: name: string -> string option
    /// <summary>Adds a query string parameter to the current uri</summary>
    /// <param name="name">The Query parameter name</param>
    /// <param name="value">The Query parameter value</param>
    /// <param name="replaceExisting">If true, replace all existing parameters with the same name</param>
    abstract addQueryParam: name: string * value: string option * ?replaceExisting: bool -> unit
    /// <summary>Adds query string parameters to the current uri</summary>
    /// <param name="parameters">Query parameters to add</param>
    /// <param name="replaceExisting">If true, replace all existing parameters with the same name</param>
    /// <param name="keyPrefix">If specified, a value to prepend to all query parameter keys</param>
    abstract addQueryParams: parameters: UriAddQueryParamsParameters * ?replaceExisting: bool * ?keyPrefix: string -> unit
    /// <summary>Removes a query string parameter</summary>
    /// <param name="name">The Query parameter name</param>
    abstract removeQueryParam: name: string -> unit

type [<AllowNullLiteral>] UriAddQueryParamsParameters =
    [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> QueryParameterValueType with get, set

/// Class that represents a Uri and allows parsing/getting and setting of individual parts
type [<AllowNullLiteral>] UriStatic =
    /// <summary>Create a new Uri.</summary>
    /// <param name="uri">Optional uri string to populate values with</param>
    /// <param name="options">Options for parsing the uri string</param>
    [<Emit "new $0($1...)">] abstract Create: ?uri: string * ?options: IUriParseOptions -> Uri

/// Represents a route parsed by parseRoute
type [<AllowNullLiteral>] IParsedRoute =
    /// Array of the segements in the route
    abstract segments: ResizeArray<IParsedRouteSegment> with get, set

/// And individual segment of the route (fixed text or a parameter)
type [<AllowNullLiteral>] IParsedRouteSegment =
    /// If present, the fixed text for this segement. Either text or paramName will be defined for a segment, never both.
    abstract text: string option with get, set
    /// If present, the name of the route value parameter to substitute for this segment. Either text or paramName will be defined for a segment, never both.
    abstract paramName: string option with get, set
    /// For parameters, whether or not this parameter is a wildcard (*) parameter, which means it allows multiple path segments (i.e. don't escape "/")
    abstract isWildCardParam: bool option with get, set
    /// Whether the parameter is required in order for the URL to be valid.
    abstract isRequiredParam: bool option with get, set

/// Result of a call to replace route values for a parsed route
type [<AllowNullLiteral>] IRouteMatchResult =
    /// Resulting URL from the template replacement. Does NOT include any query parameters that would be added from extra route values.
    abstract url: string with get, set
    /// Dictionary of the route value keys that were used as replacements
    abstract matchedParameters: IRouteMatchResultMatchedParameters with get, set
    /// The number of parameter replacements made
    abstract matchedParametersCount: int with get, set

type [<AllowNullLiteral>] IRouteMatchResultMatchedParameters =
    [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> bool with get, set
