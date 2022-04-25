// ts2fable 0.7.1
module rec FeatureAvailability
open System
open Fable.Core
open Fable.Core.JS
type [<AllowNullLiteral>] FeatureFlag =
    abstract description: string with get, set
    abstract effectiveState: string with get, set
    abstract explicitState: string with get, set
    abstract name: string with get, set
    abstract uri: string with get, set

/// This is passed to the FeatureFlagController to edit the status of a feature flag
type [<AllowNullLiteral>] FeatureFlagPatch =
    abstract state: string with get, set
