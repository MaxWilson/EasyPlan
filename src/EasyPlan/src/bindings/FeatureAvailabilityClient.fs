// ts2fable 0.7.1
module rec FeatureAvailabilityClient
open System
open Fable.Core
open Fable.Core.JS

type IVssRestClientOptions = Context.IVssRestClientOptions
type RestClientBase = RestClientBase.RestClientBase

type [<AllowNullLiteral>] IExports =
    abstract FeatureAvailabilityRestClient: FeatureAvailabilityRestClientStatic

type [<AllowNullLiteral>] FeatureAvailabilityRestClient =
    inherit RestClientBase
    /// <summary>Retrieve a listing of all feature flags and their current states for a user</summary>
    /// <param name="userEmail">- The email of the user to check</param>
    abstract getAllFeatureFlags: ?userEmail: string -> Promise<ResizeArray<FeatureAvailability.FeatureFlag>>
    /// <summary>Retrieve information on a single feature flag and its current states</summary>
    /// <param name="name">- The name of the feature to retrieve</param>
    /// <param name="checkFeatureExists">- Check if feature exists</param>
    abstract getFeatureFlagByName: name: string * ?checkFeatureExists: bool -> Promise<FeatureAvailability.FeatureFlag>
    /// <summary>Retrieve information on a single feature flag and its current states for a user</summary>
    /// <param name="name">- The name of the feature to retrieve</param>
    /// <param name="userEmail">- The email of the user to check</param>
    /// <param name="checkFeatureExists">- Check if feature exists</param>
    abstract getFeatureFlagByNameAndUserEmail: name: string * userEmail: string * ?checkFeatureExists: bool -> Promise<FeatureAvailability.FeatureFlag>
    /// <summary>Retrieve information on a single feature flag and its current states for a user</summary>
    /// <param name="name">- The name of the feature to retrieve</param>
    /// <param name="userId">- The id of the user to check</param>
    /// <param name="checkFeatureExists">- Check if feature exists</param>
    abstract getFeatureFlagByNameAndUserId: name: string * userId: string * ?checkFeatureExists: bool -> Promise<FeatureAvailability.FeatureFlag>
    /// <summary>Change the state of an individual feature flag for a name</summary>
    /// <param name="state">- State that should be set</param>
    /// <param name="name">- The name of the feature to change</param>
    /// <param name="userEmail">-</param>
    /// <param name="checkFeatureExists">- Checks if the feature exists before setting the state</param>
    /// <param name="setAtApplicationLevelAlso">-</param>
    abstract updateFeatureFlag: state: FeatureAvailability.FeatureFlagPatch * name: string * ?userEmail: string * ?checkFeatureExists: bool * ?setAtApplicationLevelAlso: bool -> Promise<FeatureAvailability.FeatureFlag>

type [<AllowNullLiteral>] FeatureAvailabilityRestClientStatic =
    [<Emit "new $0($1...)">] abstract Create: options: IVssRestClientOptions -> FeatureAvailabilityRestClient
