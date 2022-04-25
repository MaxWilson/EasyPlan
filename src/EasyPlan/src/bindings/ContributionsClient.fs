// ts2fable 0.7.1
module rec ContributionsClient
open System
open Fable.Core
open Fable.Core.JS


module ContributionsClient =
    module Contributions = ___Contributions_Contributions
    type IVssRestClientOptions = _____Common_Context.IVssRestClientOptions
    type RestClientBase = _____Common_RestClientBase.RestClientBase

    type [<AllowNullLiteral>] IExports =
        abstract ContributionsRestClient: ContributionsRestClientStatic

    type [<AllowNullLiteral>] ContributionsRestClient =
        inherit RestClientBase
        /// <summary>Query for contribution nodes and provider details according the parameters in the passed in query object.</summary>
        /// <param name="query">-</param>
        abstract queryContributionNodes: query: Contributions.ContributionNodeQuery -> Promise<Contributions.ContributionNodeQueryResult>
        /// <param name="query">-</param>
        /// <param name="scopeName">-</param>
        /// <param name="scopeValue">-</param>
        abstract queryDataProviders: query: Contributions.DataProviderQuery * ?scopeName: string * ?scopeValue: string -> Promise<Contributions.DataProviderResult>
        /// <param name="contributionIds">-</param>
        /// <param name="includeDisabledApps">-</param>
        /// <param name="assetTypes">-</param>
        abstract getInstalledExtensions: ?contributionIds: ResizeArray<string> * ?includeDisabledApps: bool * ?assetTypes: ResizeArray<string> -> Promise<ResizeArray<Contributions.InstalledExtension>>
        /// <param name="publisherName">-</param>
        /// <param name="extensionName">-</param>
        /// <param name="assetTypes">-</param>
        abstract getInstalledExtensionByName: publisherName: string * extensionName: string * ?assetTypes: ResizeArray<string> -> Promise<Contributions.InstalledExtension>

    type [<AllowNullLiteral>] ContributionsRestClientStatic =
        [<Emit "new $0($1...)">] abstract Create: options: IVssRestClientOptions -> ContributionsRestClient
        abstract RESOURCE_AREA_ID: string
