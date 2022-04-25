// ts2fable 0.7.1
module rec IdentityService
open System
open Fable.Core
open Fable.Core.JS


module IdentityService =

    type [<StringEnum>] [<RequireQualifiedAccess>] IdentityServiceIds =
        | [<CompiledName "ms.vss-features.identity-service">] IdentityService

    type [<AllowNullLiteral>] IIdentity =
        abstract entityId: string with get, set
        abstract entityType: string with get, set
        abstract originDirectory: string with get, set
        abstract originId: string with get, set

    type [<AllowNullLiteral>] IdentitiesGetConnectionsResponseModel =
        abstract successors: ResizeArray<IIdentity> option with get, set
        abstract managers: ResizeArray<IIdentity> option with get, set
        abstract directReports: ResizeArray<IIdentity> option with get, set

    type [<AllowNullLiteral>] IdentitiesSearchRequestModel =
        abstract query: string with get, set
        abstract identityTypes: ResizeArray<string> option with get, set
        abstract operationScopes: ResizeArray<string> option with get, set
        abstract queryTypeHint: string option with get, set
        abstract pagingToken: string option with get, set
        abstract properties: ResizeArray<string> option with get, set
        abstract filterByAncestorEntityIds: ResizeArray<string> option with get, set
        abstract filterByEntityIds: ResizeArray<string> option with get, set
        abstract options: obj option with get, set

    type [<AllowNullLiteral>] IVssIdentityService =
        /// Get a list of the Most Recently Used (MRU) identities
        abstract getIdentityMruAsync: unit -> Promise<ResizeArray<IIdentity>>
        /// <summary>Given a search request model, return a list of Entities. If the filterIdentity callback is added, additionally filter the values before returning</summary>
        /// <param name="query">The query to search the identities type with.</param>
        /// <param name="identityTypes">The types of identities to search (default "user" and "group")</param>
        /// <param name="operationScopes">The scope you would like to search (default "ims", "source")</param>
        /// <param name="queryTypeHint">A hint of what property your query is trying to search</param>
        /// <param name="options">Additional options to pass into the search</param>
        /// <param name="filterIdentity">A filter passed in to alter the results of the identities found</param>
        abstract searchIdentitiesAsync: query: string * ?identityTypes: ResizeArray<string> * ?operationScopes: ResizeArray<string> * ?queryTypeHint: string * ?options: obj * ?filterIdentity: (ResizeArray<IIdentity> -> ResizeArray<IIdentity>) -> Promise<ResizeArray<IIdentity>>
        /// <summary>Add a list of identities to the MRU</summary>
        /// <param name="identities">list of IdentityRefs to add to the MRU</param>
        abstract addMruIdentitiesAsync: identities: ResizeArray<IIdentity> -> Promise<bool>
        /// Remove a list of identities from the MRU
        abstract removeMruIdentitiesAsync: identity: ResizeArray<IIdentity> -> Promise<bool>
        /// <summary>Gets a list of connections for a given identity</summary>
        /// <param name="identity">Entity to look up connections</param>
        abstract getConnections: identity: IIdentity * ?getDirectReports: bool -> Promise<IdentitiesGetConnectionsResponseModel>
