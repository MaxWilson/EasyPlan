// ts2fable 0.7.1
module rec PolicyClient
open System
open Fable.Core
open Fable.Core.JS
type IVssRestClientOptions = Context.IVssRestClientOptions
type RestClientBase = RestClientBase.RestClientBase

type [<AllowNullLiteral>] IExports =
    abstract PolicyRestClient: PolicyRestClientStatic

type [<AllowNullLiteral>] PolicyRestClient =
    inherit RestClientBase
    /// <summary>Create a policy configuration of a given policy type.</summary>
    /// <param name="configuration">- The policy configuration to create.</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="configurationId">-</param>
    abstract createPolicyConfiguration: configuration: Policy.PolicyConfiguration * project: string * ?configurationId: int -> Promise<Policy.PolicyConfiguration>
    /// <summary>Delete a policy configuration by its ID.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="configurationId">- ID of the policy configuration to delete.</param>
    abstract deletePolicyConfiguration: project: string * configurationId: int -> Promise<unit>
    /// <summary>Get a policy configuration by its ID.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="configurationId">- ID of the policy configuration</param>
    abstract getPolicyConfiguration: project: string * configurationId: int -> Promise<Policy.PolicyConfiguration>
    /// <summary>Get a list of policy configurations in a project.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="scope">- [Provided for legacy reasons] The scope on which a subset of policies is defined.</param>
    /// <param name="policyType">- Filter returned policies to only this type</param>
    abstract getPolicyConfigurations: project: string * ?scope: string * ?policyType: string -> Promise<ResizeArray<Policy.PolicyConfiguration>>
    /// <summary>Update a policy configuration by its ID.</summary>
    /// <param name="configuration">- The policy configuration to update.</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="configurationId">- ID of the existing policy configuration to be updated.</param>
    abstract updatePolicyConfiguration: configuration: Policy.PolicyConfiguration * project: string * configurationId: int -> Promise<Policy.PolicyConfiguration>
    /// <summary>Gets the present evaluation state of a policy.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="evaluationId">- ID of the policy evaluation to be retrieved.</param>
    abstract getPolicyEvaluation: project: string * evaluationId: string -> Promise<Policy.PolicyEvaluationRecord>
    /// <summary>Requeue the policy evaluation.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="evaluationId">- ID of the policy evaluation to be retrieved.</param>
    abstract requeuePolicyEvaluation: project: string * evaluationId: string -> Promise<Policy.PolicyEvaluationRecord>
    /// <summary>Retrieves a list of all the policy evaluation statuses for a specific pull request.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="artifactId">- A string which uniquely identifies the target of a policy evaluation.</param>
    /// <param name="includeNotApplicable">- Some policies might determine that they do not apply to a specific pull request. Setting this parameter to true will return evaluation records even for policies which don't apply to this pull request.</param>
    /// <param name="top">- The number of policy evaluation records to retrieve.</param>
    /// <param name="skip">- The number of policy evaluation records to ignore. For example, to retrieve results 101-150, set top to 50 and skip to 100.</param>
    abstract getPolicyEvaluations: project: string * artifactId: string * ?includeNotApplicable: bool * ?top: int * ?skip: int -> Promise<ResizeArray<Policy.PolicyEvaluationRecord>>
    /// <summary>Retrieve a specific revision of a given policy by ID.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="configurationId">- The policy configuration ID.</param>
    /// <param name="revisionId">- The revision ID.</param>
    abstract getPolicyConfigurationRevision: project: string * configurationId: int * revisionId: int -> Promise<Policy.PolicyConfiguration>
    /// <summary>Retrieve all revisions for a given policy.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="configurationId">- The policy configuration ID.</param>
    /// <param name="top">- The number of revisions to retrieve.</param>
    /// <param name="skip">- The number of revisions to ignore. For example, to retrieve results 101-150, set top to 50 and skip to 100.</param>
    abstract getPolicyConfigurationRevisions: project: string * configurationId: int * ?top: int * ?skip: int -> Promise<ResizeArray<Policy.PolicyConfiguration>>
    /// <summary>Retrieve a specific policy type by ID.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="typeId">- The policy ID.</param>
    abstract getPolicyType: project: string * typeId: string -> Promise<Policy.PolicyType>
    /// <summary>Retrieve all available policy types.</summary>
    /// <param name="project">- Project ID or project name</param>
    abstract getPolicyTypes: project: string -> Promise<ResizeArray<Policy.PolicyType>>

type [<AllowNullLiteral>] PolicyRestClientStatic =
    [<Emit "new $0($1...)">] abstract Create: options: IVssRestClientOptions -> PolicyRestClient
    abstract RESOURCE_AREA_ID: string
