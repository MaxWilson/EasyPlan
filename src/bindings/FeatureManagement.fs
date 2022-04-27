// ts2fable 0.7.1
module rec FeatureManagement
open System
open Fable.Core
open Fable.Core.JS

type [<AllowNullLiteral>] ContributedFeature =
    /// Named links describing the feature
    abstract _links: obj option with get, set
    /// If true, the feature is enabled unless overridden at some scope
    abstract defaultState: bool with get, set
    /// Rules for setting the default value if not specified by any setting/scope. Evaluated in order until a rule returns an Enabled or Disabled state (not Undefined)
    abstract defaultValueRules: ResizeArray<ContributedFeatureValueRule> with get, set
    /// The description of the feature
    abstract description: string with get, set
    /// Extra properties for the feature
    abstract featureProperties: ContributedFeatureFeatureProperties with get, set
    /// Handler for listening to setter calls on feature value. These listeners are only invoked after a successful set has occurred
    abstract featureStateChangedListeners: ResizeArray<ContributedFeatureListener> with get, set
    /// The full contribution id of the feature
    abstract id: string with get, set
    /// If this is set to true, then the id for this feature will be added to the list of claims for the request.
    abstract includeAsClaim: bool with get, set
    /// The friendly name of the feature
    abstract name: string with get, set
    /// Suggested order to display feature in.
    abstract order: int with get, set
    /// Rules for overriding a feature value. These rules are run before explicit user/host state values are checked. They are evaluated in order until a rule returns an Enabled or Disabled state (not Undefined)
    abstract overrideRules: ResizeArray<ContributedFeatureValueRule> with get, set
    /// The scopes/levels at which settings can set the enabled/disabled state of this feature
    abstract scopes: ResizeArray<ContributedFeatureSettingScope> with get, set
    /// The service instance id of the service that owns this feature
    abstract serviceInstanceType: string with get, set
    /// Tags associated with the feature.
    abstract tags: ResizeArray<string> with get, set

type [<RequireQualifiedAccess>] ContributedFeatureEnabledValue =
    | Undefined = -1
    | Disabled = 0
    | Enabled = 1

type [<AllowNullLiteral>] ContributedFeatureHandlerSettings =
    /// Name of the handler to run
    abstract name: string with get, set
    /// Properties to feed to the handler
    abstract properties: ContributedFeatureFeatureProperties with get, set

/// An identifier and properties used to pass into a handler for a listener or plugin
type [<AllowNullLiteral>] ContributedFeatureListener =
    inherit ContributedFeatureHandlerSettings

/// The scope to which a feature setting applies
type [<AllowNullLiteral>] ContributedFeatureSettingScope =
    /// The name of the settings scope to use when reading/writing the setting
    abstract settingScope: string with get, set
    /// Whether this is a user-scope or this is a host-wide (all users) setting
    abstract userScoped: bool with get, set

/// A contributed feature/state pair
type [<AllowNullLiteral>] ContributedFeatureState =
    /// The full contribution id of the feature
    abstract featureId: string with get, set
    /// True if the effective state was set by an override rule (indicating that the state cannot be managed by the end user)
    abstract overridden: bool with get, set
    /// Reason that the state was set (by a plugin/rule).
    abstract reason: string with get, set
    /// The scope at which this state applies
    abstract scope: ContributedFeatureSettingScope with get, set
    /// The current state of this feature
    abstract state: ContributedFeatureEnabledValue with get, set

/// A query for the effective contributed feature states for a list of feature ids
type [<AllowNullLiteral>] ContributedFeatureStateQuery =
    /// The list of feature ids to query
    abstract featureIds: ResizeArray<string> with get, set
    /// The query result containing the current feature states for each of the queried feature ids
    abstract featureStates: ContributedFeatureStateQueryFeatureStates with get, set
    /// A dictionary of scope values (project name, etc.) to use in the query (if querying across scopes)
    abstract scopeValues: ContributedFeatureStateQueryScopeValues with get, set

/// A rule for dynamically getting the enabled/disabled state of a feature
type [<AllowNullLiteral>] ContributedFeatureValueRule =
    inherit ContributedFeatureHandlerSettings

type [<AllowNullLiteral>] ContributedFeatureFeatureProperties =
    [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

type [<AllowNullLiteral>] ContributedFeatureStateQueryFeatureStates =
    [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> ContributedFeatureState with get, set

type [<AllowNullLiteral>] ContributedFeatureStateQueryScopeValues =
    [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> string with get, set
