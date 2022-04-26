// ts2fable 0.7.1
module rec FeatureManagementClient
open System
open Fable.Core
open Fable.Core.JS
type IVssRestClientOptions = Context.IVssRestClientOptions
type RestClientBase = RestClientBase.RestClientBase

type [<AllowNullLiteral>] IExports =
    abstract FeatureManagementRestClient: FeatureManagementRestClientStatic

type [<AllowNullLiteral>] FeatureManagementRestClient =
    inherit RestClientBase
    /// <summary>Get a specific feature by its id</summary>
    /// <param name="featureId">- The contribution id of the feature</param>
    abstract getFeature: featureId: string -> Promise<FeatureManagement.ContributedFeature>
    /// <summary>Get a list of all defined features</summary>
    /// <param name="targetContributionId">- Optional target contribution. If null/empty, return all features. If specified include the features that target the specified contribution.</param>
    abstract getFeatures: ?targetContributionId: string -> Promise<ResizeArray<FeatureManagement.ContributedFeature>>
    /// <summary>Get the state of the specified feature for the given user/all-users scope</summary>
    /// <param name="featureId">- Contribution id of the feature</param>
    /// <param name="userScope">- User-Scope at which to get the value. Should be "me" for the current user or "host" for all users.</param>
    abstract getFeatureState: featureId: string * userScope: string -> Promise<FeatureManagement.ContributedFeatureState>
    /// <summary>Set the state of a feature</summary>
    /// <param name="feature">- Posted feature state object. Should specify the effective value.</param>
    /// <param name="featureId">- Contribution id of the feature</param>
    /// <param name="userScope">- User-Scope at which to set the value. Should be "me" for the current user or "host" for all users.</param>
    /// <param name="reason">- Reason for changing the state</param>
    /// <param name="reasonCode">- Short reason code</param>
    abstract setFeatureState: feature: FeatureManagement.ContributedFeatureState * featureId: string * userScope: string * ?reason: string * ?reasonCode: string -> Promise<FeatureManagement.ContributedFeatureState>
    /// <summary>Get the state of the specified feature for the given named scope</summary>
    /// <param name="featureId">- Contribution id of the feature</param>
    /// <param name="userScope">- User-Scope at which to get the value. Should be "me" for the current user or "host" for all users.</param>
    /// <param name="scopeName">- Scope at which to get the feature setting for (e.g. "project" or "team")</param>
    /// <param name="scopeValue">- Value of the scope (e.g. the project or team id)</param>
    abstract getFeatureStateForScope: featureId: string * userScope: string * scopeName: string * scopeValue: string -> Promise<FeatureManagement.ContributedFeatureState>
    /// <summary>Set the state of a feature at a specific scope</summary>
    /// <param name="feature">- Posted feature state object. Should specify the effective value.</param>
    /// <param name="featureId">- Contribution id of the feature</param>
    /// <param name="userScope">- User-Scope at which to set the value. Should be "me" for the current user or "host" for all users.</param>
    /// <param name="scopeName">- Scope at which to get the feature setting for (e.g. "project" or "team")</param>
    /// <param name="scopeValue">- Value of the scope (e.g. the project or team id)</param>
    /// <param name="reason">- Reason for changing the state</param>
    /// <param name="reasonCode">- Short reason code</param>
    abstract setFeatureStateForScope: feature: FeatureManagement.ContributedFeatureState * featureId: string * userScope: string * scopeName: string * scopeValue: string * ?reason: string * ?reasonCode: string -> Promise<FeatureManagement.ContributedFeatureState>
    /// <summary>Get the effective state for a list of feature ids</summary>
    /// <param name="query">- Features to query along with current scope values</param>
    abstract queryFeatureStates: query: FeatureManagement.ContributedFeatureStateQuery -> Promise<FeatureManagement.ContributedFeatureStateQuery>
    /// <summary>Get the states of the specified features for the default scope</summary>
    /// <param name="query">- Query describing the features to query.</param>
    /// <param name="userScope">-</param>
    abstract queryFeatureStatesForDefaultScope: query: FeatureManagement.ContributedFeatureStateQuery * userScope: string -> Promise<FeatureManagement.ContributedFeatureStateQuery>
    /// <summary>Get the states of the specified features for the specific named scope</summary>
    /// <param name="query">- Query describing the features to query.</param>
    /// <param name="userScope">-</param>
    /// <param name="scopeName">-</param>
    /// <param name="scopeValue">-</param>
    abstract queryFeatureStatesForNamedScope: query: FeatureManagement.ContributedFeatureStateQuery * userScope: string * scopeName: string * scopeValue: string -> Promise<FeatureManagement.ContributedFeatureStateQuery>

type [<AllowNullLiteral>] FeatureManagementRestClientStatic =
    [<Emit "new $0($1...)">] abstract Create: options: IVssRestClientOptions -> FeatureManagementRestClient
