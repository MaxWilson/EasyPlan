// ts2fable 0.7.1
module rec Policy
open System
open Fable.Core
open Fable.Core.JS
/// The full policy configuration with settings.
type [<AllowNullLiteral>] PolicyConfiguration =
    inherit VersionedPolicyConfigurationRef
    /// The links to other objects related to this object.
    abstract _links: obj option with get, set
    /// A reference to the identity that created the policy.
    abstract createdBy: WebApi.IdentityRef with get, set
    /// The date and time when the policy was created.
    abstract createdDate: DateTime with get, set
    /// Indicates whether the policy is blocking.
    abstract isBlocking: bool with get, set
    /// Indicates whether the policy has been (soft) deleted.
    abstract isDeleted: bool with get, set
    /// Indicates whether the policy is enabled.
    abstract isEnabled: bool with get, set
    /// The policy configuration settings.
    abstract settings: obj option with get, set

/// Policy configuration reference.
type [<AllowNullLiteral>] PolicyConfigurationRef =
    /// The policy configuration ID.
    abstract id: int with get, set
    /// The policy configuration type.
    abstract ``type``: PolicyTypeRef with get, set
    /// The URL where the policy configuration can be retrieved.
    abstract url: string with get, set

/// This record encapsulates the current state of a policy as it applies to one specific pull request. Each pull request has a unique PolicyEvaluationRecord for each pull request which the policy applies to.
type [<AllowNullLiteral>] PolicyEvaluationRecord =
    /// Links to other related objects
    abstract _links: obj option with get, set
    /// A string which uniquely identifies the target of a policy evaluation.
    abstract artifactId: string with get, set
    /// Time when this policy finished evaluating on this pull request.
    abstract completedDate: DateTime with get, set
    /// Contains all configuration data for the policy which is being evaluated.
    abstract configuration: PolicyConfiguration with get, set
    /// Internal context data of this policy evaluation.
    abstract context: obj option with get, set
    /// Guid which uniquely identifies this evaluation record (one policy running on one pull request).
    abstract evaluationId: string with get, set
    /// Time when this policy was first evaluated on this pull request.
    abstract startedDate: DateTime with get, set
    /// Status of the policy (Running, Approved, Failed, etc.)
    abstract status: PolicyEvaluationStatus with get, set

type [<RequireQualifiedAccess>] PolicyEvaluationStatus =
    | Queued = 0
    | Running = 1
    | Approved = 2
    | Rejected = 3
    | NotApplicable = 4
    | Broken = 5

/// User-friendly policy type with description (used for querying policy types).
type [<AllowNullLiteral>] PolicyType =
    inherit PolicyTypeRef
    /// The links to other objects related to this object.
    abstract _links: obj option with get, set
    /// Detailed description of the policy type.
    abstract description: string with get, set

/// Policy type reference.
type [<AllowNullLiteral>] PolicyTypeRef =
    /// Display name of the policy type.
    abstract displayName: string with get, set
    /// The policy type ID.
    abstract id: string with get, set
    /// The URL where the policy type can be retrieved.
    abstract url: string with get, set

/// A particular revision for a policy configuration.
type [<AllowNullLiteral>] VersionedPolicyConfigurationRef =
    inherit PolicyConfigurationRef
    /// The policy configuration revision ID.
    abstract revision: int with get, set
