// ts2fable 0.7.1
module rec Release
open System
open Fable.Core
open Fable.Core.JS

type [<AllowNullLiteral>] AgentArtifactDefinition =
    /// Gets or sets the artifact definition alias.
    abstract alias: string with get, set
    /// Gets or sets the artifact type.
    abstract artifactType: AgentArtifactType with get, set
    /// Gets or sets the artifact definition details.
    abstract details: string with get, set
    /// Gets or sets the name of artifact definition.
    abstract name: string with get, set
    /// Gets or sets the version of artifact definition.
    abstract version: string with get, set

type [<RequireQualifiedAccess>] AgentArtifactType =
    | XamlBuild = 0
    | Build = 1
    | Jenkins = 2
    | FileShare = 3
    | Nuget = 4
    | TfsOnPrem = 5
    | GitHub = 6
    | TFGit = 7
    | ExternalTfsBuild = 8
    | Custom = 9
    | Tfvc = 10

type [<AllowNullLiteral>] AgentBasedDeployPhase =
    inherit DeployPhase
    /// Gets and sets the agent job deployment input
    abstract deploymentInput: AgentDeploymentInput with get, set

type [<AllowNullLiteral>] AgentDeploymentInput =
    inherit DeploymentInput
    /// Specification for an agent on which a job gets executed.
    abstract agentSpecification: AgentSpecification with get, set
    /// Gets or sets the image ID.
    abstract imageId: int with get, set
    /// Gets or sets the parallel execution input.
    abstract parallelExecution: ExecutionInput with get, set

/// Represents a reference to an agent queue.
type [<AllowNullLiteral>] AgentPoolQueueReference =
    inherit ResourceReference
    /// The ID of the queue.
    abstract id: int with get, set

/// Specification of the agent defined by the pool provider.
type [<AllowNullLiteral>] AgentSpecification =
    /// Agent specification unique identifier.
    abstract identifier: string with get, set

type [<RequireQualifiedAccess>] ApprovalExecutionOrder =
    | BeforeGates = 1
    | AfterSuccessfulGates = 2
    | AfterGatesAlways = 4

type [<RequireQualifiedAccess>] ApprovalFilters =
    | None = 0
    | ManualApprovals = 1
    | AutomatedApprovals = 2
    | ApprovalSnapshots = 4
    | All = 7

type [<AllowNullLiteral>] ApprovalOptions =
    /// Specify whether the approval can be skipped if the same approver approved the previous stage.
    abstract autoTriggeredAndPreviousEnvironmentApprovedCanBeSkipped: bool with get, set
    /// Specify whether revalidate identity of approver before completing the approval.
    abstract enforceIdentityRevalidation: bool with get, set
    /// Approvals execution order.
    abstract executionOrder: ApprovalExecutionOrder with get, set
    /// Specify whether the user requesting a release or deployment should allow to approver.
    abstract releaseCreatorCanBeApprover: bool with get, set
    /// The number of approvals required to move release forward. '0' means all approvals required.
    abstract requiredApproverCount: int with get, set
    /// Approval timeout. Approval default timeout is 30 days. Maximum allowed timeout is 365 days. '0' means default timeout i.e 30 days.
    abstract timeoutInMinutes: int with get, set

type [<RequireQualifiedAccess>] ApprovalStatus =
    | Undefined = 0
    | Pending = 1
    | Approved = 2
    | Rejected = 4
    | Reassigned = 6
    | Canceled = 7
    | Skipped = 8

type [<RequireQualifiedAccess>] ApprovalType =
    | Undefined = 0
    | PreDeploy = 1
    | PostDeploy = 2
    | All = 3

type [<AllowNullLiteral>] Artifact =
    /// Gets or sets alias.
    abstract alias: string with get, set
    /// Gets or sets definition reference. e.g. \{"project":\{"id":"fed755ea-49c5-4399-acea-fd5b5aa90a6c","name":"myProject"\},"definition":\{"id":"1","name":"mybuildDefinition"\},"connection":\{"id":"1","name":"myConnection"\}\}.
    abstract definitionReference: ArtifactDefinitionReference with get, set
    /// Indicates whether artifact is primary or not.
    abstract isPrimary: bool with get, set
    /// Indicates whether artifact is retained by release or not.
    abstract isRetained: bool with get, set
    abstract sourceId: string with get, set
    /// Gets or sets type. It can have value as 'Build', 'Jenkins', 'GitHub', 'Nuget', 'Team Build (external)', 'ExternalTFSBuild', 'Git', 'TFVC', 'ExternalTfsXamlBuild'.
    abstract ``type``: string with get, set

type [<AllowNullLiteral>] ArtifactContributionDefinition =
    abstract artifactTriggerConfiguration: ArtifactTriggerConfiguration with get, set
    abstract artifactType: string with get, set
    abstract artifactTypeStreamMapping: ArtifactContributionDefinitionArtifactTypeStreamMapping with get, set
    abstract browsableArtifactTypeMapping: ArtifactContributionDefinitionArtifactTypeStreamMapping with get, set
    abstract dataSourceBindings: ResizeArray<DataSourceBinding> with get, set
    abstract displayName: string with get, set
    abstract downloadTaskId: string with get, set
    abstract endpointTypeId: string with get, set
    abstract inputDescriptors: ResizeArray<FormInput.InputDescriptor> with get, set
    abstract isCommitsTraceabilitySupported: bool with get, set
    abstract isWorkitemsTraceabilitySupported: bool with get, set
    abstract name: string with get, set
    abstract taskInputMapping: ArtifactContributionDefinitionArtifactTypeStreamMapping with get, set
    abstract uniqueSourceIdentifier: string with get, set

type [<AllowNullLiteral>] ArtifactDownloadInputBase =
    /// Gets or sets the alias of artifact.
    abstract alias: string with get, set
    /// Gets or sets the name of artifact definition. Valid values are 'Skip', 'Selective', 'All'.
    abstract artifactDownloadMode: string with get, set
    /// Gets or sets the artifact items of the input.
    abstract artifactItems: ResizeArray<string> with get, set
    /// Gets or sets the type of artifact.
    abstract artifactType: string with get, set

type [<AllowNullLiteral>] ArtifactFilter =
    /// Gets or sets whether a release should be created on build tagging.
    abstract createReleaseOnBuildTagging: bool with get, set
    /// Gets or sets the branch for the filter.
    abstract sourceBranch: string with get, set
    /// Gets or sets the regex based tag filter.
    abstract tagFilter: TagFilter with get, set
    /// Gets or sets the list of tags for the filter.
    abstract tags: ResizeArray<string> with get, set
    /// Gets or sets whether filter should default to build definition branch.
    abstract useBuildDefinitionBranch: bool with get, set

type [<AllowNullLiteral>] ArtifactInstanceData =
    abstract accountName: string with get, set
    abstract authenticationToken: string with get, set
    abstract tfsUrl: string with get, set
    abstract version: string with get, set

type [<AllowNullLiteral>] ArtifactMetadata =
    /// Sets alias of artifact.
    abstract alias: string with get, set
    /// Sets instance reference of artifact. e.g. for build artifact it is build number.
    abstract instanceReference: BuildVersion with get, set

type [<AllowNullLiteral>] ArtifactProvider =
    /// Gets or sets the id of artifact provider.
    abstract id: int with get, set
    /// Gets or sets the name of artifact provider.
    abstract name: string with get, set
    /// Gets or sets the link of artifact provider.
    abstract sourceUri: string with get, set
    /// Gets or sets the version of artifact provider.
    abstract version: string with get, set

type [<AllowNullLiteral>] ArtifactsDownloadInput =
    abstract downloadInputs: ResizeArray<ArtifactDownloadInputBase> with get, set

type [<AllowNullLiteral>] ArtifactSourceId =
    /// Gets or sets the artifact type of artifact source.
    abstract artifactTypeId: string with get, set
    /// Gets or sets the list of sourceIdInput of artifact source.
    abstract sourceIdInputs: ResizeArray<SourceIdInput> with get, set

type [<AllowNullLiteral>] ArtifactSourceIdsQueryResult =
    /// Gets or sets the list of artifactsourceIds.
    abstract artifactSourceIds: ResizeArray<ArtifactSourceId> with get, set

type [<AllowNullLiteral>] ArtifactSourceReference =
    /// ID of the artifact source.
    abstract id: string with get, set
    /// Name of the artifact source.
    abstract name: string with get, set

type [<AllowNullLiteral>] ArtifactSourceTrigger =
    inherit ReleaseTriggerBase
    /// Artifact source alias for Artifact Source trigger type
    abstract artifactAlias: string with get, set
    abstract triggerConditions: ResizeArray<ArtifactFilter> with get, set

type [<AllowNullLiteral>] ArtifactTriggerConfiguration =
    /// Gets or sets the whether trigger is supported or not.
    abstract isTriggerSupported: bool with get, set
    /// Gets or sets the whether trigger is supported only on hosted environment.
    abstract isTriggerSupportedOnlyInHosted: bool with get, set
    /// Gets or sets the whether webhook is supported at server level.
    abstract isWebhookSupportedAtServerLevel: bool with get, set
    /// Gets or sets the payload hash header name for the artifact trigger configuration.
    abstract payloadHashHeaderName: string with get, set
    /// Gets or sets the resources for artifact trigger configuration.
    abstract resources: ArtifactContributionDefinitionArtifactTypeStreamMapping with get, set
    /// Gets or sets the webhook payload mapping for artifact trigger configuration.
    abstract webhookPayloadMapping: ArtifactContributionDefinitionArtifactTypeStreamMapping with get, set

type [<AllowNullLiteral>] ArtifactTypeDefinition =
    /// Gets or sets the artifact trigger configuration of artifact type definition.
    abstract artifactTriggerConfiguration: ArtifactTriggerConfiguration with get, set
    /// Gets or sets the artifact type of artifact type definition. Valid values are 'Build', 'Package', 'Source' or 'ContainerImage'.
    abstract artifactType: string with get, set
    /// Gets or sets the display name of artifact type definition.
    abstract displayName: string with get, set
    /// Gets or sets the endpoint type id of artifact type definition.
    abstract endpointTypeId: string with get, set
    /// Gets or sets the input descriptors of artifact type definition.
    abstract inputDescriptors: ResizeArray<FormInput.InputDescriptor> with get, set
    /// Gets or sets the is commits tracebility supported value of artifact type defintion.
    abstract isCommitsTraceabilitySupported: bool with get, set
    /// Gets or sets the is workitems tracebility supported value of artifact type defintion.
    abstract isWorkitemsTraceabilitySupported: bool with get, set
    /// Gets or sets the name of artifact type definition.
    abstract name: string with get, set
    /// Gets or sets the unique source identifier of artifact type definition.
    abstract uniqueSourceIdentifier: string with get, set

type [<AllowNullLiteral>] ArtifactVersion =
    /// Gets or sets the alias of artifact.
    abstract alias: string with get, set
    /// Gets or sets the default version of artifact.
    abstract defaultVersion: BuildVersion with get, set
    /// Gets or sets the error message encountered during querying of versions for artifact.
    abstract errorMessage: string with get, set
    abstract sourceId: string with get, set
    /// Gets or sets the list of build versions of artifact.
    abstract versions: ResizeArray<BuildVersion> with get, set

type [<AllowNullLiteral>] ArtifactVersionQueryResult =
    /// Gets or sets the list for artifact versions of artifact version query result.
    abstract artifactVersions: ResizeArray<ArtifactVersion> with get, set

type [<RequireQualifiedAccess>] AuditAction =
    | Add = 1
    | Update = 2
    | Delete = 3
    | Undelete = 4

type [<RequireQualifiedAccess>] AuthorizationHeaderFor =
    | RevalidateApproverIdentity = 0
    | OnBehalfOf = 1

type [<AllowNullLiteral>] AutoTriggerIssue =
    abstract issue: Issue with get, set
    abstract issueSource: IssueSource with get, set
    abstract project: ProjectReference with get, set
    abstract releaseDefinitionReference: ReleaseDefinitionShallowReference with get, set
    abstract releaseTriggerType: ReleaseTriggerType with get, set

type [<AllowNullLiteral>] AzureKeyVaultVariableGroupProviderData =
    inherit VariableGroupProviderData
    /// Gets or sets last refreshed time.
    abstract lastRefreshedOn: DateTime with get, set
    /// Gets or sets the service endpoint ID.
    abstract serviceEndpointId: string with get, set
    /// Gets or sets the vault name.
    abstract vault: string with get, set

type [<AllowNullLiteral>] AzureKeyVaultVariableValue =
    inherit VariableValue
    /// Gets or sets the content type of key vault variable value.
    abstract contentType: string with get, set
    /// Indicates the vault variable value enabled or not.
    abstract enabled: bool with get, set
    /// Gets or sets the expire time of key vault variable value.
    abstract expires: DateTime with get, set

type [<AllowNullLiteral>] BaseDeploymentInput =
    /// Gets or sets the job condition.
    abstract condition: string with get, set
    /// Gets or sets the job cancel timeout in minutes for deployment which are cancelled by user for this release environment.
    abstract jobCancelTimeoutInMinutes: int with get, set
    /// Gets or sets the override inputs.
    abstract overrideInputs: ArtifactContributionDefinitionArtifactTypeStreamMapping with get, set
    /// Gets or sets the job execution timeout in minutes for deployment which are queued against this release environment.
    abstract timeoutInMinutes: int with get, set

type [<AllowNullLiteral>] BuildArtifactDownloadInput =
    inherit ArtifactDownloadInputBase

type [<AllowNullLiteral>] BuildVersion =
    /// Gets or sets the commit message for the artifact.
    abstract commitMessage: string with get, set
    /// Gets or sets the definition id.
    abstract definitionId: string with get, set
    /// Gets or sets the definition name.
    abstract definitionName: string with get, set
    /// Gets or sets the build id.
    abstract id: string with get, set
    /// Gets or sets if the artifact supports multiple definitions.
    abstract isMultiDefinitionType: bool with get, set
    /// Gets or sets the build number.
    abstract name: string with get, set
    /// Gets or sets the source branch for the artifact.
    abstract sourceBranch: string with get, set
    /// Gets or sets the source pull request version for the artifact.
    abstract sourcePullRequestVersion: SourcePullRequestVersion with get, set
    /// Gets or sets the repository id for the artifact.
    abstract sourceRepositoryId: string with get, set
    /// Gets or sets the repository type for the artifact.
    abstract sourceRepositoryType: string with get, set
    /// Gets or sets the source version for the artifact.
    abstract sourceVersion: string with get, set

/// Represents a change associated with a build.
type [<AllowNullLiteral>] Change =
    /// The author of the change.
    abstract author: WebApi.IdentityRef with get, set
    /// The type of source. "TfsVersionControl", "TfsGit", etc.
    abstract changeType: string with get, set
    /// The location of a user-friendly representation of the resource.
    abstract displayUri: string with get, set
    /// Something that identifies the change. For a commit, this would be the SHA1. For a TFVC changeset, this would be the changeset id.
    abstract id: string with get, set
    /// The location of the full representation of the resource.
    abstract location: string with get, set
    /// A description of the change. This might be a commit message or changeset description.
    abstract message: string with get, set
    /// The person or process that pushed the change.
    abstract pushedBy: WebApi.IdentityRef with get, set
    /// The person or process that pushed the change.
    abstract pusher: string with get, set
    /// A timestamp for the change.
    abstract timestamp: DateTime with get, set

type [<AllowNullLiteral>] CodeRepositoryReference =
    /// Gets and sets the repository references.
    abstract repositoryReference: CodeRepositoryReferenceRepositoryReference with get, set
    /// It can have value as ‘GitHub’, ‘Vsts’.
    abstract systemType: PullRequestSystemType with get, set

type [<AllowNullLiteral>] ComplianceSettings =
    /// Scan the release definition for secrets
    abstract checkForCredentialsAndOtherSecrets: bool with get, set

type [<AllowNullLiteral>] Condition =
    /// Gets or sets the condition type.
    abstract conditionType: ConditionType with get, set
    /// Gets or sets the name of the condition. e.g. 'ReleaseStarted'.
    abstract name: string with get, set
    /// Gets or set value of the condition.
    abstract value: string with get, set

type [<RequireQualifiedAccess>] ConditionType =
    | Undefined = 0
    | Event = 1
    | EnvironmentState = 2
    | Artifact = 4

type [<AllowNullLiteral>] ConfigurationVariableValue =
    /// Gets and sets if a variable can be overridden at deployment time or not.
    abstract allowOverride: bool with get, set
    /// Gets or sets as variable is secret or not.
    abstract isSecret: bool with get, set
    /// Gets and sets value of the configuration variable.
    abstract value: string with get, set

type [<AllowNullLiteral>] Consumer =
    /// ID of the consumer.
    abstract consumerId: int with get, set
    /// Name of the consumer.
    abstract consumerName: string with get, set

type [<AllowNullLiteral>] ContainerImageTrigger =
    inherit ReleaseTriggerBase
    /// Alias of the trigger.
    abstract alias: string with get, set
    /// List tag filters applied while trigger.
    abstract tagFilters: ResizeArray<TagFilter> with get, set

type [<AllowNullLiteral>] ContinuousDeploymentTriggerIssue =
    inherit AutoTriggerIssue
    /// Artifact type.
    abstract artifactType: string with get, set
    /// ArtifactVersion ID.
    abstract artifactVersionId: string with get, set
    /// Artifact source ID.
    abstract sourceId: string with get, set

type [<AllowNullLiteral>] ControlOptions =
    /// Always run the job.
    abstract alwaysRun: bool with get, set
    /// Indicates whether to continue job on error or not.
    abstract continueOnError: bool with get, set
    /// Indicates the job enabled or not.
    abstract enabled: bool with get, set

type [<AllowNullLiteral>] CustomArtifactDownloadInput =
    inherit ArtifactDownloadInputBase

type [<AllowNullLiteral>] DataSourceBinding =
    /// Pagination format supported by this data source(ContinuationToken/SkipTop).
    abstract callbackContextTemplate: string with get, set
    /// Subsequent calls needed?
    abstract callBackRequiredTemplate: string with get, set
    /// Name of the datasource.
    abstract dataSourceName: string with get, set
    /// Endpoint ID of the datasource.
    abstract endpointId: string with get, set
    /// Endpoint URL of the datasource.
    abstract endpointUrl: string with get, set
    /// Defines the initial value of the query params
    abstract initialContextTemplate: string with get, set
    /// Parameters of the datasource.
    abstract parameters: ArtifactContributionDefinitionArtifactTypeStreamMapping with get, set
    /// Gets or sets http request body
    abstract requestContent: string with get, set
    /// Gets or sets http request verb
    abstract requestVerb: string with get, set
    /// Result selector applied on output of datasource result, for example jsonpath:$.value[?(\@.properties.isEnabled == true)].
    abstract resultSelector: string with get, set
    /// Format of the return results, for example. \{ "Value" : "\{\{\{id\}\}\}", "DisplayValue" : "\{\{\{name\}\}\}" \}.
    abstract resultTemplate: string with get, set
    /// Target of the datasource.
    abstract target: string with get, set

type [<AllowNullLiteral>] DefinitionEnvironmentReference =
    /// Definition environment ID.
    abstract definitionEnvironmentId: int with get, set
    /// Definition environment name.
    abstract definitionEnvironmentName: string with get, set
    /// ReleaseDefinition ID.
    abstract releaseDefinitionId: int with get, set
    /// ReleaseDefinition name.
    abstract releaseDefinitionName: string with get, set

type [<AllowNullLiteral>] Demand =
    /// Gets and sets the name of demand.
    abstract name: string with get, set
    /// Gets and sets the value of demand.
    abstract value: string with get, set

type [<AllowNullLiteral>] Deployment =
    /// Gets links to access the deployment.
    abstract _links: obj option with get, set
    /// Gets attempt number.
    abstract attempt: int with get, set
    /// Gets the date on which deployment is complete.
    abstract completedOn: DateTime with get, set
    /// Gets the list of condition associated with deployment.
    abstract conditions: ResizeArray<Condition> with get, set
    /// Gets release definition environment id.
    abstract definitionEnvironmentId: int with get, set
    /// Gets status of the deployment.
    abstract deploymentStatus: DeploymentStatus with get, set
    /// Gets the unique identifier for deployment.
    abstract id: int with get, set
    /// Gets the identity who last modified the deployment.
    abstract lastModifiedBy: WebApi.IdentityRef with get, set
    /// Gets the date on which deployment is last modified.
    abstract lastModifiedOn: DateTime with get, set
    /// Gets operation status of deployment.
    abstract operationStatus: DeploymentOperationStatus with get, set
    /// Gets list of PostDeployApprovals.
    abstract postDeployApprovals: ResizeArray<ReleaseApproval> with get, set
    /// Gets list of PreDeployApprovals.
    abstract preDeployApprovals: ResizeArray<ReleaseApproval> with get, set
    /// Gets or sets project reference.
    abstract projectReference: ProjectReference with get, set
    /// Gets the date on which deployment is queued.
    abstract queuedOn: DateTime with get, set
    /// Gets reason of deployment.
    abstract reason: DeploymentReason with get, set
    /// Gets the reference of release.
    abstract release: ReleaseReference with get, set
    /// Gets releaseDefinitionReference which specifies the reference of the release definition to which the deployment is associated.
    abstract releaseDefinition: ReleaseDefinitionShallowReference with get, set
    /// Gets releaseEnvironmentReference which specifies the reference of the release environment to which the deployment is associated.
    abstract releaseEnvironment: ReleaseEnvironmentShallowReference with get, set
    /// Gets the identity who requested.
    abstract requestedBy: WebApi.IdentityRef with get, set
    /// Gets the identity for whom deployment is requested.
    abstract requestedFor: WebApi.IdentityRef with get, set
    /// Gets the date on which deployment is scheduled.
    abstract scheduledDeploymentTime: DateTime with get, set
    /// Gets the date on which deployment is started.
    abstract startedOn: DateTime with get, set

type [<AllowNullLiteral>] DeploymentApprovalCompletedEvent =
    abstract approval: ReleaseApproval with get, set
    abstract project: ProjectReference with get, set
    abstract release: Release with get, set

type [<AllowNullLiteral>] DeploymentApprovalPendingEvent =
    abstract approval: ReleaseApproval with get, set
    abstract approvalOptions: ApprovalOptions with get, set
    abstract completedApprovals: ResizeArray<ReleaseApproval> with get, set
    abstract data: DeploymentApprovalPendingEventData with get, set
    abstract deployment: Deployment with get, set
    abstract isMultipleRankApproval: bool with get, set
    abstract pendingApprovals: ResizeArray<ReleaseApproval> with get, set
    abstract project: ProjectReference with get, set
    abstract release: Release with get, set

type [<AllowNullLiteral>] DeploymentAttempt =
    /// Deployment attempt.
    abstract attempt: int with get, set
    /// ID of the deployment.
    abstract deploymentId: int with get, set
    /// Error log to show any unexpected error that occurred during executing deploy step
    abstract errorLog: string with get, set
    /// Specifies whether deployment has started or not.
    abstract hasStarted: bool with get, set
    /// ID of deployment.
    abstract id: int with get, set
    /// All the issues related to the deployment.
    abstract issues: ResizeArray<Issue> with get, set
    abstract job: ReleaseTask with get, set
    /// Identity who last modified this deployment.
    abstract lastModifiedBy: WebApi.IdentityRef with get, set
    /// Time when this deployment last modified.
    abstract lastModifiedOn: DateTime with get, set
    /// Deployment operation status.
    abstract operationStatus: DeploymentOperationStatus with get, set
    /// Post deployment gates that executed in this deployment.
    abstract postDeploymentGates: ReleaseGates with get, set
    /// Pre deployment gates that executed in this deployment.
    abstract preDeploymentGates: ReleaseGates with get, set
    /// When this deployment queued on.
    abstract queuedOn: DateTime with get, set
    /// Reason for the deployment.
    abstract reason: DeploymentReason with get, set
    /// List of release deployphases executed in this deployment.
    abstract releaseDeployPhases: ResizeArray<ReleaseDeployPhase> with get, set
    /// Identity who requested this deployment.
    abstract requestedBy: WebApi.IdentityRef with get, set
    /// Identity for this deployment requested.
    abstract requestedFor: WebApi.IdentityRef with get, set
    abstract runPlanId: string with get, set
    /// status of the deployment.
    abstract status: DeploymentStatus with get, set
    abstract tasks: ResizeArray<ReleaseTask> with get, set

type [<AllowNullLiteral>] DeploymentAuthorizationInfo =
    /// Authorization header type, typically either RevalidateApproverIdentity or OnBehalfOf.
    abstract authorizationHeaderFor: AuthorizationHeaderFor with get, set
    /// List of resources.
    abstract resources: ResizeArray<string> with get, set
    /// ID of the tenant.
    abstract tenantId: string with get, set
    /// Access token key.
    abstract vstsAccessTokenKey: string with get, set

type [<RequireQualifiedAccess>] DeploymentAuthorizationOwner =
    | Automatic = 0
    | DeploymentSubmitter = 1
    | FirstPreDeploymentApprover = 2

type [<AllowNullLiteral>] DeploymentCompletedEvent =
    abstract comment: string with get, set
    abstract data: DeploymentApprovalPendingEventData with get, set
    abstract deployment: Deployment with get, set
    abstract environment: ReleaseEnvironment with get, set
    abstract project: ProjectReference with get, set

type [<RequireQualifiedAccess>] DeploymentExpands =
    | All = 0
    | DeploymentOnly = 1
    | Approvals = 2
    | Artifacts = 4

type [<AllowNullLiteral>] DeploymentInput =
    inherit BaseDeploymentInput
    /// Artifacts that downloaded during job execution.
    abstract artifactsDownloadInput: ArtifactsDownloadInput with get, set
    /// List demands that needs to meet to execute the job.
    abstract demands: ResizeArray<Demand> with get, set
    /// Indicates whether to include access token in deployment job or not.
    abstract enableAccessToken: bool with get, set
    /// Id of the pool on which job get executed.
    abstract queueId: int with get, set
    /// Indicates whether artifacts downloaded while job execution or not.
    abstract skipArtifactsDownload: bool with get, set

type [<AllowNullLiteral>] DeploymentJob =
    /// Parent task of all executed tasks.
    abstract job: ReleaseTask with get, set
    /// List of  executed tasks with in job.
    abstract tasks: ResizeArray<ReleaseTask> with get, set

type [<AllowNullLiteral>] DeploymentManualInterventionPendingEvent =
    abstract deployment: Deployment with get, set
    abstract emailRecipients: ResizeArray<string> with get, set
    abstract environmentOwner: WebApi.IdentityRef with get, set
    abstract manualIntervention: ManualIntervention with get, set
    abstract project: ProjectReference with get, set
    abstract release: Release with get, set

type [<RequireQualifiedAccess>] DeploymentOperationStatus =
    | Undefined = 0
    | Queued = 1
    | Scheduled = 2
    | Pending = 4
    | Approved = 8
    | Rejected = 16
    | Deferred = 32
    | QueuedForAgent = 64
    | PhaseInProgress = 128
    | PhaseSucceeded = 256
    | PhasePartiallySucceeded = 512
    | PhaseFailed = 1024
    | Canceled = 2048
    | PhaseCanceled = 4096
    | ManualInterventionPending = 8192
    | QueuedForPipeline = 16384
    | Cancelling = 32768
    | EvaluatingGates = 65536
    | GateFailed = 131072
    | All = 258047

type [<AllowNullLiteral>] DeploymentQueryParameters =
    /// Query deployments based specified artifact source id.
    abstract artifactSourceId: string with get, set
    /// Query deployments based specified artifact type id.
    abstract artifactTypeId: string with get, set
    /// Query deployments based specified artifact versions.
    abstract artifactVersions: ResizeArray<string> with get, set
    /// Query deployments number of deployments per environment.
    abstract deploymentsPerEnvironment: int with get, set
    /// Query deployment based on deployment status.
    abstract deploymentStatus: DeploymentStatus with get, set
    /// Query deployments of specified environments.
    abstract environments: ResizeArray<DefinitionEnvironmentReference> with get, set
    /// Query deployments based specified expands.
    abstract expands: DeploymentExpands with get, set
    /// Specify deleted deployments should return or not.
    abstract isDeleted: bool with get, set
    abstract latestDeploymentsOnly: bool with get, set
    abstract maxDeploymentsPerEnvironment: int with get, set
    abstract maxModifiedTime: DateTime with get, set
    abstract minModifiedTime: DateTime with get, set
    /// Query deployment based on deployment operation status.
    abstract operationStatus: DeploymentOperationStatus with get, set
    abstract queryOrder: ReleaseQueryOrder with get, set
    /// Query deployments based query type.
    abstract queryType: DeploymentsQueryType with get, set
    /// Query deployments based specified source branch.
    abstract sourceBranch: string with get, set

type [<RequireQualifiedAccess>] DeploymentReason =
    | None = 0
    | Manual = 1
    | Automated = 2
    | Scheduled = 4
    | RedeployTrigger = 8

type [<RequireQualifiedAccess>] DeploymentsQueryType =
    | Regular = 1
    | FailingSince = 2

type [<AllowNullLiteral>] DeploymentStartedEvent =
    abstract environment: ReleaseEnvironment with get, set
    abstract project: ProjectReference with get, set
    abstract release: Release with get, set

type [<RequireQualifiedAccess>] DeploymentStatus =
    | Undefined = 0
    | NotDeployed = 1
    | InProgress = 2
    | Succeeded = 4
    | PartiallySucceeded = 8
    | Failed = 16
    | All = 31

type [<AllowNullLiteral>] DeployPhase =
    /// Gets and sets the name of deploy phase.
    abstract name: string with get, set
    /// Indicates the deploy phase type.
    abstract phaseType: DeployPhaseTypes with get, set
    /// Gets and sets the rank of deploy phase.
    abstract rank: int with get, set
    /// Gets and sets the reference name of deploy phase.
    abstract refName: string with get, set
    /// Gets and sets the workflow tasks for the deploy phase.
    abstract workflowTasks: ResizeArray<WorkflowTask> with get, set

type [<RequireQualifiedAccess>] DeployPhaseStatus =
    | Undefined = 0
    | NotStarted = 1
    | InProgress = 2
    | PartiallySucceeded = 4
    | Succeeded = 8
    | Failed = 16
    | Canceled = 32
    | Skipped = 64
    | Cancelling = 128

type [<RequireQualifiedAccess>] DeployPhaseTypes =
    | Undefined = 0
    | AgentBasedDeployment = 1
    | RunOnServer = 2
    | MachineGroupBasedDeployment = 4
    | DeploymentGates = 8

type [<AllowNullLiteral>] EmailRecipients =
    /// List of email addresses.
    abstract emailAddresses: ResizeArray<string> with get, set
    /// List of TFS IDs guids.
    abstract tfsIds: ResizeArray<string> with get, set

/// Defines policy on environment queuing at Release Management side queue. We will send to Environment Runner [creating pre-deploy and other steps] only when the policies mentioned are satisfied.
type [<AllowNullLiteral>] EnvironmentExecutionPolicy =
    /// This policy decides, how many environments would be with Environment Runner.
    abstract concurrencyCount: int with get, set
    /// Queue depth in the EnvironmentQueue table, this table keeps the environment entries till Environment Runner is free [as per it's policy] to take another environment for running.
    abstract queueDepthCount: int with get, set

type [<AllowNullLiteral>] EnvironmentOptions =
    /// Gets and sets as the auto link workitems or not.
    abstract autoLinkWorkItems: bool with get, set
    /// Gets and sets as the badge enabled or not.
    abstract badgeEnabled: bool with get, set
    abstract emailNotificationType: string with get, set
    abstract emailRecipients: string with get, set
    abstract enableAccessToken: bool with get, set
    /// Gets and sets as the publish deployment status or not.
    abstract publishDeploymentStatus: bool with get, set
    /// Gets and sets as the.pull request deployment enabled or not.
    abstract pullRequestDeploymentEnabled: bool with get, set
    abstract skipArtifactsDownload: bool with get, set
    abstract timeoutInMinutes: int with get, set

type [<AllowNullLiteral>] EnvironmentRetentionPolicy =
    /// Gets and sets the number of days to keep environment.
    abstract daysToKeep: int with get, set
    /// Gets and sets the number of releases to keep.
    abstract releasesToKeep: int with get, set
    /// Gets and sets as the build to be retained or not.
    abstract retainBuild: bool with get, set

type [<RequireQualifiedAccess>] EnvironmentStatus =
    | Undefined = 0
    | NotStarted = 1
    | InProgress = 2
    | Succeeded = 4
    | Canceled = 8
    | Rejected = 16
    | Queued = 32
    | Scheduled = 64
    | PartiallySucceeded = 128

type [<AllowNullLiteral>] EnvironmentTrigger =
    /// Definition environment ID on which this trigger applicable.
    abstract definitionEnvironmentId: int with get, set
    /// ReleaseDefinition ID on which this trigger applicable.
    abstract releaseDefinitionId: int with get, set
    /// Gets or sets the trigger content.
    abstract triggerContent: string with get, set
    /// Gets or sets the trigger type.
    abstract triggerType: EnvironmentTriggerType with get, set

type [<AllowNullLiteral>] EnvironmentTriggerContent =
    /// Gets or sets action.
    abstract action: string with get, set
    /// Gets or sets list of event types.
    abstract eventTypes: ResizeArray<string> with get, set

type [<RequireQualifiedAccess>] EnvironmentTriggerType =
    | Undefined = 0
    | DeploymentGroupRedeploy = 1
    | RollbackRedeploy = 2

type [<AllowNullLiteral>] ExecutionInput =
    /// Parallel execution type, for example MultiConfiguration or MultiMachine.
    abstract parallelExecutionType: ParallelExecutionTypes with get, set

/// Class to represent favorite entry.
type [<AllowNullLiteral>] FavoriteItem =
    /// Application specific data for the entry.
    abstract data: string with get, set
    /// Unique Id of the the entry.
    abstract id: string with get, set
    /// Display text for favorite entry.
    abstract name: string with get, set
    /// Application specific favorite entry type. Empty or Null represents that Favorite item is a Folder.
    abstract ``type``: string with get, set

type [<AllowNullLiteral>] Folder =
    /// Identity who created this folder.
    abstract createdBy: WebApi.IdentityRef with get, set
    /// Time when this folder created.
    abstract createdOn: DateTime with get, set
    /// Description of the folder.
    abstract description: string with get, set
    /// Identity who last changed this folder.
    abstract lastChangedBy: WebApi.IdentityRef with get, set
    /// Time when this folder last changed.
    abstract lastChangedDate: DateTime with get, set
    /// path of the folder.
    abstract path: string with get, set

type [<RequireQualifiedAccess>] FolderPathQueryOrder =
    | None = 0
    | Ascending = 1
    | Descending = 2

type [<AllowNullLiteral>] GatesDeploymentInput =
    inherit BaseDeploymentInput
    /// Gates minimum success duration.
    abstract minimumSuccessDuration: int with get, set
    /// Gates sampling interval.
    abstract samplingInterval: int with get, set
    /// Gates stabilization time.
    abstract stabilizationTime: int with get, set

type [<AllowNullLiteral>] GatesDeployPhase =
    inherit DeployPhase
    /// Gets and sets the gate job input.
    abstract deploymentInput: GatesDeploymentInput with get, set

type [<RequireQualifiedAccess>] GateStatus =
    | None = 0
    | Pending = 1
    | InProgress = 2
    | Succeeded = 4
    | Failed = 8
    | Canceled = 16

type [<AllowNullLiteral>] GateUpdateMetadata =
    /// Comment.
    abstract comment: string with get, set
    /// Name of gate to be ignored.
    abstract gatesToIgnore: ResizeArray<string> with get, set

type [<AllowNullLiteral>] GitArtifactDownloadInput =
    inherit ArtifactDownloadInputBase

type [<AllowNullLiteral>] GitHubArtifactDownloadInput =
    inherit ArtifactDownloadInputBase

type [<AllowNullLiteral>] IgnoredGate =
    /// Gets the date on which gate is last ignored.
    abstract lastModifiedOn: DateTime with get, set
    /// Name of gate ignored.
    abstract name: string with get, set

type [<AllowNullLiteral>] Issue =
    /// Issue data.
    abstract data: ArtifactContributionDefinitionArtifactTypeStreamMapping with get, set
    /// Issue type, for example error, warning or info.
    abstract issueType: string with get, set
    /// Issue message.
    abstract message: string with get, set

type [<RequireQualifiedAccess>] IssueSource =
    | None = 0
    | User = 1
    | System = 2

type [<AllowNullLiteral>] JenkinsArtifactDownloadInput =
    inherit ArtifactDownloadInputBase

type [<AllowNullLiteral>] MachineGroupBasedDeployPhase =
    inherit DeployPhase
    /// Gets and sets the deployment group job input
    abstract deploymentInput: MachineGroupDeploymentInput with get, set

type [<AllowNullLiteral>] MachineGroupDeploymentInput =
    inherit DeploymentInput
    /// Deployment group health option.
    abstract deploymentHealthOption: string with get, set
    /// Minimum percentage of the targets guaranteed to be healthy.
    abstract healthPercent: int with get, set
    /// Deployment target tag filter.
    abstract tags: ResizeArray<string> with get, set

type [<AllowNullLiteral>] MailMessage =
    /// Body of mail.
    abstract body: string with get, set
    /// Mail CC recipients.
    abstract cc: EmailRecipients with get, set
    /// Reply to.
    abstract inReplyTo: string with get, set
    /// Message ID of the mail.
    abstract messageId: string with get, set
    /// Data when should be replied to mail.
    abstract replyBy: DateTime with get, set
    /// Reply to Email recipients.
    abstract replyTo: EmailRecipients with get, set
    /// List of mail section types.
    abstract sections: ResizeArray<MailSectionType> with get, set
    /// Mail sender type.
    abstract senderType: SenderType with get, set
    /// Subject of the mail.
    abstract subject: string with get, set
    /// Mail To recipients.
    abstract ``to``: EmailRecipients with get, set

type [<RequireQualifiedAccess>] MailSectionType =
    | Details = 0
    | Environments = 1
    | Issues = 2
    | TestResults = 3
    | WorkItems = 4
    | ReleaseInfo = 5

type [<AllowNullLiteral>] ManualIntervention =
    /// Gets or sets the identity who should approve.
    abstract approver: WebApi.IdentityRef with get, set
    /// Gets or sets comments for approval.
    abstract comments: string with get, set
    /// Gets date on which it got created.
    abstract createdOn: DateTime with get, set
    /// Gets the unique identifier for manual intervention.
    abstract id: int with get, set
    /// Gets or sets instructions for approval.
    abstract instructions: string with get, set
    /// Gets date on which it got modified.
    abstract modifiedOn: DateTime with get, set
    /// Gets or sets the name.
    abstract name: string with get, set
    /// Gets releaseReference for manual intervention.
    abstract release: ReleaseShallowReference with get, set
    /// Gets releaseDefinitionReference for manual intervention.
    abstract releaseDefinition: ReleaseDefinitionShallowReference with get, set
    /// Gets releaseEnvironmentReference for manual intervention.
    abstract releaseEnvironment: ReleaseEnvironmentShallowReference with get, set
    /// Gets or sets the status of the manual intervention.
    abstract status: ManualInterventionStatus with get, set
    /// Get task instance identifier.
    abstract taskInstanceId: string with get, set
    /// Gets url to access the manual intervention.
    abstract url: string with get, set

type [<RequireQualifiedAccess>] ManualInterventionStatus =
    | Unknown = 0
    | Pending = 1
    | Rejected = 2
    | Approved = 4
    | Canceled = 8

type [<AllowNullLiteral>] ManualInterventionUpdateMetadata =
    /// Sets the comment for manual intervention update.
    abstract comment: string with get, set
    /// Sets the status of the manual intervention.
    abstract status: ManualInterventionStatus with get, set

type [<AllowNullLiteral>] MappingDetails =
    abstract mappings: MappingDetailsMappings with get, set

type [<AllowNullLiteral>] Metric =
    /// Name of the Metric.
    abstract name: string with get, set
    /// Value of the Metric.
    abstract value: int with get, set

type [<AllowNullLiteral>] MultiConfigInput =
    inherit ParallelExecutionInputBase
    /// Multipliers for parallel execution of deployment, for example x86,x64.
    abstract multipliers: string with get, set

type [<AllowNullLiteral>] MultiMachineInput =
    inherit ParallelExecutionInputBase

type [<AllowNullLiteral>] PackageTrigger =
    inherit ReleaseTriggerBase
    /// Package trigger alias.
    abstract alias: string with get, set

type [<AllowNullLiteral>] ParallelExecutionInputBase =
    inherit ExecutionInput
    /// Indicate whether continue execution of deployment on error or not.
    abstract continueOnError: bool with get, set
    /// Maximum number of agents used while parallel execution.
    abstract maxNumberOfAgents: int with get, set

type [<RequireQualifiedAccess>] ParallelExecutionTypes =
    | None = 0
    | MultiConfiguration = 1
    | MultiMachine = 2

type [<AllowNullLiteral>] PipelineProcess =
    /// Pipeline process type.
    abstract ``type``: PipelineProcessTypes with get, set

type [<RequireQualifiedAccess>] PipelineProcessTypes =
    | Designer = 1
    | Yaml = 2

type [<AllowNullLiteral>] ProjectReference =
    /// Gets the unique identifier of this field.
    abstract id: string with get, set
    /// Gets name of project.
    abstract name: string with get, set

type [<AllowNullLiteral>] PropertySelector =
    /// List of properties.
    abstract properties: ResizeArray<string> with get, set
    /// Property selector type.
    abstract selectorType: PropertySelectorType with get, set

type [<RequireQualifiedAccess>] PropertySelectorType =
    | Inclusion = 0
    | Exclusion = 1

type [<AllowNullLiteral>] PullRequestConfiguration =
    /// Code repository reference.
    abstract codeRepositoryReference: CodeRepositoryReference with get, set
    /// In case of Source based artifacts, Code reference will be present in Artifact details.
    abstract useArtifactReference: bool with get, set

type [<AllowNullLiteral>] PullRequestFilter =
    /// List of tags.
    abstract tags: ResizeArray<string> with get, set
    /// Target branch of pull request.
    abstract targetBranch: string with get, set

type [<RequireQualifiedAccess>] PullRequestSystemType =
    | None = 0
    | TfsGit = 1
    | GitHub = 2

type [<AllowNullLiteral>] PullRequestTrigger =
    inherit ReleaseTriggerBase
    /// Artifact alias trigger is linked to.
    abstract artifactAlias: string with get, set
    /// Code reference details of pull request.
    abstract pullRequestConfiguration: PullRequestConfiguration with get, set
    /// Policy name using which status will be published to pull request.
    abstract statusPolicyName: string with get, set
    /// List of filters applied while trigger.
    abstract triggerConditions: ResizeArray<PullRequestFilter> with get, set

type [<AllowNullLiteral>] QueuedReleaseData =
    /// Project ID of the release.
    abstract projectId: string with get, set
    /// Release queue position.
    abstract queuePosition: int with get, set
    /// Queued release ID.
    abstract releaseId: int with get, set

type [<AllowNullLiteral>] RealtimeReleaseDefinitionEvent =
    abstract definitionId: int with get, set
    abstract projectId: string with get, set

type [<AllowNullLiteral>] RealtimeReleaseEvent =
    abstract environmentId: int with get, set
    abstract projectId: string with get, set
    abstract releaseId: int with get, set

type [<AllowNullLiteral>] Release =
    /// Gets links to access the release.
    abstract _links: obj option with get, set
    /// Gets or sets the list of artifacts.
    abstract artifacts: ResizeArray<Artifact> with get, set
    /// Gets or sets comment.
    abstract comment: string with get, set
    /// Gets or sets the identity who created.
    abstract createdBy: WebApi.IdentityRef with get, set
    /// Gets date on which it got created.
    abstract createdOn: DateTime with get, set
    /// Gets revision number of definition snapshot.
    abstract definitionSnapshotRevision: int with get, set
    /// Gets or sets description of release.
    abstract description: string with get, set
    /// Gets list of environments.
    abstract environments: ResizeArray<ReleaseEnvironment> with get, set
    /// Gets the unique identifier of this field.
    abstract id: int with get, set
    /// Whether to exclude the release from retention policies.
    abstract keepForever: bool with get, set
    /// Gets logs container url.
    abstract logsContainerUrl: string with get, set
    /// Gets or sets the identity who modified.
    abstract modifiedBy: WebApi.IdentityRef with get, set
    /// Gets date on which it got modified.
    abstract modifiedOn: DateTime with get, set
    /// Gets name.
    abstract name: string with get, set
    /// Gets pool name.
    abstract poolName: string with get, set
    /// Gets or sets project reference.
    abstract projectReference: ProjectReference with get, set
    abstract properties: obj option with get, set
    /// Gets reason of release.
    abstract reason: ReleaseReason with get, set
    /// Gets releaseDefinitionReference which specifies the reference of the release definition to which this release is associated.
    abstract releaseDefinition: ReleaseDefinitionShallowReference with get, set
    /// Gets or sets the release definition revision.
    abstract releaseDefinitionRevision: int with get, set
    /// Gets release name format.
    abstract releaseNameFormat: string with get, set
    /// Gets status.
    abstract status: ReleaseStatus with get, set
    /// Gets or sets list of tags.
    abstract tags: ResizeArray<string> with get, set
    abstract triggeringArtifactAlias: string with get, set
    abstract url: string with get, set
    /// Gets the list of variable groups.
    abstract variableGroups: ResizeArray<VariableGroup> with get, set
    /// Gets or sets the dictionary of variables.
    abstract variables: ReleaseVariables with get, set

type [<AllowNullLiteral>] ReleaseAbandonedEvent =
    abstract project: ProjectReference with get, set
    abstract release: Release with get, set

type [<AllowNullLiteral>] ReleaseApproval =
    /// Gets or sets the type of approval.
    abstract approvalType: ApprovalType with get, set
    /// Gets the identity who approved.
    abstract approvedBy: WebApi.IdentityRef with get, set
    /// Gets or sets the identity who should approve.
    abstract approver: WebApi.IdentityRef with get, set
    /// Gets or sets attempt which specifies as which deployment attempt it belongs.
    abstract attempt: int with get, set
    /// Gets or sets comments for approval.
    abstract comments: string with get, set
    /// Gets date on which it got created.
    abstract createdOn: DateTime with get, set
    /// Gets history which specifies all approvals associated with this approval.
    abstract history: ResizeArray<ReleaseApprovalHistory> with get, set
    /// Gets the unique identifier of this field.
    abstract id: int with get, set
    /// Gets or sets as approval is automated or not.
    abstract isAutomated: bool with get, set
    abstract isNotificationOn: bool with get, set
    /// Gets date on which it got modified.
    abstract modifiedOn: DateTime with get, set
    /// Gets or sets rank which specifies the order of the approval. e.g. Same rank denotes parallel approval.
    abstract rank: int with get, set
    /// Gets releaseReference which specifies the reference of the release to which this approval is associated.
    abstract release: ReleaseShallowReference with get, set
    /// Gets releaseDefinitionReference which specifies the reference of the release definition to which this approval is associated.
    abstract releaseDefinition: ReleaseDefinitionShallowReference with get, set
    /// Gets releaseEnvironmentReference which specifies the reference of the release environment to which this approval is associated.
    abstract releaseEnvironment: ReleaseEnvironmentShallowReference with get, set
    /// Gets the revision number.
    abstract revision: int with get, set
    /// Gets or sets the status of the approval.
    abstract status: ApprovalStatus with get, set
    abstract trialNumber: int with get, set
    /// Gets url to access the approval.
    abstract url: string with get, set

type [<AllowNullLiteral>] ReleaseApprovalHistory =
    /// Identity of the approver.
    abstract approver: WebApi.IdentityRef with get, set
    /// Identity of the object who changed approval.
    abstract changedBy: WebApi.IdentityRef with get, set
    /// Approval history comments.
    abstract comments: string with get, set
    /// Time when this approval created.
    abstract createdOn: DateTime with get, set
    /// Time when this approval modified.
    abstract modifiedOn: DateTime with get, set
    /// Approval history revision.
    abstract revision: int with get, set

type [<AllowNullLiteral>] ReleaseApprovalPendingEvent =
    abstract approval: ReleaseApproval with get, set
    abstract approvalOptions: ApprovalOptions with get, set
    abstract completedApprovals: ResizeArray<ReleaseApproval> with get, set
    abstract definitionName: string with get, set
    abstract deployment: Deployment with get, set
    abstract environmentId: int with get, set
    abstract environmentName: string with get, set
    abstract environments: ResizeArray<ReleaseEnvironment> with get, set
    abstract isMultipleRankApproval: bool with get, set
    abstract pendingApprovals: ResizeArray<ReleaseApproval> with get, set
    abstract releaseCreator: string with get, set
    abstract releaseName: string with get, set
    abstract title: string with get, set
    abstract webAccessUri: string with get, set

type [<AllowNullLiteral>] ReleaseArtifact =
    /// Gets or sets the artifact provider of ReleaseArtifact.
    abstract artifactProvider: ArtifactProvider with get, set
    /// Gets or sets the artifact type of ReleaseArtifact.
    abstract artifactType: string with get, set
    /// Gets or sets the definition json of ReleaseArtifact.
    abstract definitionData: string with get, set
    /// Gets or sets the definition id of ReleaseArtifact.
    abstract definitionId: int with get, set
    /// Gets or sets the description of ReleaseArtifact.
    abstract description: string with get, set
    /// Gets or sets the id of ReleaseArtifact.
    abstract id: int with get, set
    /// Gets or sets the name of ReleaseArtifact.
    abstract name: string with get, set
    /// Gets or sets the release id.
    abstract releaseId: int with get, set

type [<AllowNullLiteral>] ReleaseCondition =
    inherit Condition
    /// The release condition result.
    abstract result: bool with get, set

type [<AllowNullLiteral>] ReleaseCreatedEvent =
    abstract project: ProjectReference with get, set
    abstract release: Release with get, set

type [<AllowNullLiteral>] ReleaseDefinition =
    inherit ReleaseDefinitionShallowReference
    /// Gets or sets the list of artifacts.
    abstract artifacts: ResizeArray<Artifact> with get, set
    /// Gets or sets comment.
    abstract comment: string with get, set
    /// Gets or sets the identity who created.
    abstract createdBy: WebApi.IdentityRef with get, set
    /// Gets date on which it got created.
    abstract createdOn: DateTime with get, set
    /// Gets or sets the description.
    abstract description: string with get, set
    /// Gets or sets the list of environments.
    abstract environments: ResizeArray<ReleaseDefinitionEnvironment> with get, set
    /// Whether release definition is deleted.
    abstract isDeleted: bool with get, set
    /// Gets the reference of last release.
    abstract lastRelease: ReleaseReference with get, set
    /// Gets or sets the identity who modified.
    abstract modifiedBy: WebApi.IdentityRef with get, set
    /// Gets date on which it got modified.
    abstract modifiedOn: DateTime with get, set
    /// Gets or sets pipeline process.
    abstract pipelineProcess: PipelineProcess with get, set
    /// Gets or sets properties.
    abstract properties: obj option with get, set
    /// Gets or sets the release name format.
    abstract releaseNameFormat: string with get, set
    abstract retentionPolicy: RetentionPolicy with get, set
    /// Gets the revision number.
    abstract revision: int with get, set
    /// Gets or sets source of release definition.
    abstract source: ReleaseDefinitionSource with get, set
    /// Gets or sets list of tags.
    abstract tags: ResizeArray<string> with get, set
    /// Gets or sets the list of triggers.
    abstract triggers: ResizeArray<ReleaseTriggerBase> with get, set
    /// Gets or sets the list of variable groups.
    abstract variableGroups: ResizeArray<float> with get, set
    /// Gets or sets the dictionary of variables.
    abstract variables: ReleaseVariables with get, set

type [<AllowNullLiteral>] ReleaseDefinitionApprovals =
    /// Gets or sets the approval options.
    abstract approvalOptions: ApprovalOptions with get, set
    /// Gets or sets the approvals.
    abstract approvals: ResizeArray<ReleaseDefinitionApprovalStep> with get, set

type [<AllowNullLiteral>] ReleaseDefinitionApprovalStep =
    inherit ReleaseDefinitionEnvironmentStep
    /// Gets and sets the approver.
    abstract approver: WebApi.IdentityRef with get, set
    /// Indicates whether the approval automated.
    abstract isAutomated: bool with get, set
    /// Indicates whether the approval notification set.
    abstract isNotificationOn: bool with get, set
    /// Gets or sets the rank of approval step.
    abstract rank: int with get, set

type [<AllowNullLiteral>] ReleaseDefinitionDeployStep =
    inherit ReleaseDefinitionEnvironmentStep
    /// The list of steps for this definition.
    abstract tasks: ResizeArray<WorkflowTask> with get, set

type [<AllowNullLiteral>] ReleaseDefinitionEnvironment =
    /// Gets or sets the BadgeUrl. BadgeUrl will be used when Badge will be enabled in Release Definition Environment.
    abstract badgeUrl: string with get, set
    /// Gets or sets the environment conditions.
    abstract conditions: ResizeArray<Condition> with get, set
    /// Gets or sets the current release reference.
    abstract currentRelease: ReleaseShallowReference with get, set
    /// Gets or sets the demands.
    abstract demands: ResizeArray<Demand> with get, set
    /// Gets or sets the deploy phases of environment.
    abstract deployPhases: ResizeArray<DeployPhase> with get, set
    /// Gets or sets the deploystep.
    abstract deployStep: ReleaseDefinitionDeployStep with get, set
    /// Gets or sets the environment options.
    abstract environmentOptions: EnvironmentOptions with get, set
    /// Gets or sets the triggers on environment.
    abstract environmentTriggers: ResizeArray<EnvironmentTrigger> with get, set
    /// Gets or sets the environment execution policy.
    abstract executionPolicy: EnvironmentExecutionPolicy with get, set
    /// Gets and sets the ID of the ReleaseDefinitionEnvironment.
    abstract id: int with get, set
    /// Gets and sets the name of the ReleaseDefinitionEnvironment.
    abstract name: string with get, set
    /// Gets and sets the Owner of the ReleaseDefinitionEnvironment.
    abstract owner: WebApi.IdentityRef with get, set
    /// Gets or sets the post deployment approvals.
    abstract postDeployApprovals: ReleaseDefinitionApprovals with get, set
    /// Gets or sets the post deployment gates.
    abstract postDeploymentGates: ReleaseDefinitionGatesStep with get, set
    /// Gets or sets the pre deployment approvals.
    abstract preDeployApprovals: ReleaseDefinitionApprovals with get, set
    /// Gets or sets the pre deployment gates.
    abstract preDeploymentGates: ReleaseDefinitionGatesStep with get, set
    /// Gets or sets the environment process parameters.
    abstract processParameters: DistributedTaskCommon.ProcessParameters with get, set
    /// Gets or sets the properties on environment.
    abstract properties: obj option with get, set
    /// Gets or sets the queue ID.
    abstract queueId: int with get, set
    /// Gets and sets the rank of the ReleaseDefinitionEnvironment.
    abstract rank: int with get, set
    /// Gets or sets the environment retention policy.
    abstract retentionPolicy: EnvironmentRetentionPolicy with get, set
    abstract runOptions: ArtifactContributionDefinitionArtifactTypeStreamMapping with get, set
    /// Gets or sets the schedules
    abstract schedules: ResizeArray<ReleaseSchedule> with get, set
    /// Gets or sets the variable groups.
    abstract variableGroups: ResizeArray<float> with get, set
    /// Gets and sets the variables.
    abstract variables: ReleaseVariables with get, set

type [<AllowNullLiteral>] ReleaseDefinitionEnvironmentStep =
    /// ID of the approval or deploy step.
    abstract id: int with get, set

type [<AllowNullLiteral>] ReleaseDefinitionEnvironmentSummary =
    /// ID of ReleaseDefinition environment summary.
    abstract id: int with get, set
    /// List of release shallow reference deployed using this ReleaseDefinition.
    abstract lastReleases: ResizeArray<ReleaseShallowReference> with get, set
    /// Name of ReleaseDefinition environment summary.
    abstract name: string with get, set

type [<AllowNullLiteral>] ReleaseDefinitionEnvironmentTemplate =
    /// Indicates whether template can be deleted or not.
    abstract canDelete: bool with get, set
    /// Category of the ReleaseDefinition environment template.
    abstract category: string with get, set
    /// Description of the ReleaseDefinition environment template.
    abstract description: string with get, set
    /// ReleaseDefinition environment data which used to create this template.
    abstract environment: ReleaseDefinitionEnvironment with get, set
    /// ID of the task which used to display icon used for this template.
    abstract iconTaskId: string with get, set
    /// Icon uri of the template.
    abstract iconUri: string with get, set
    /// ID of the ReleaseDefinition environment template.
    abstract id: string with get, set
    /// Indicates whether template deleted or not.
    abstract isDeleted: bool with get, set
    /// Name of the ReleaseDefinition environment template.
    abstract name: string with get, set

type [<RequireQualifiedAccess>] ReleaseDefinitionExpands =
    | None = 0
    | Environments = 2
    | Artifacts = 4
    | Triggers = 8
    | Variables = 16
    | Tags = 32
    | LastRelease = 64

type [<AllowNullLiteral>] ReleaseDefinitionGate =
    /// Gets or sets the gates workflow.
    abstract tasks: ResizeArray<WorkflowTask> with get, set

type [<AllowNullLiteral>] ReleaseDefinitionGatesOptions =
    /// Gets or sets as the gates enabled or not.
    abstract isEnabled: bool with get, set
    /// Gets or sets the minimum duration for steady results after a successful gates evaluation.
    abstract minimumSuccessDuration: int with get, set
    /// Gets or sets the time between re-evaluation of gates.
    abstract samplingInterval: int with get, set
    /// Gets or sets the delay before evaluation.
    abstract stabilizationTime: int with get, set
    /// Gets or sets the timeout after which gates fail.
    abstract timeout: int with get, set

type [<AllowNullLiteral>] ReleaseDefinitionGatesStep =
    /// Gets or sets the gates.
    abstract gates: ResizeArray<ReleaseDefinitionGate> with get, set
    /// Gets or sets the gate options.
    abstract gatesOptions: ReleaseDefinitionGatesOptions with get, set
    /// ID of the ReleaseDefinitionGateStep.
    abstract id: int with get, set

type [<RequireQualifiedAccess>] ReleaseDefinitionQueryOrder =
    | IdAscending = 0
    | IdDescending = 1
    | NameAscending = 2
    | NameDescending = 3

type [<AllowNullLiteral>] ReleaseDefinitionRevision =
    /// Gets api-version for revision object.
    abstract apiVersion: string with get, set
    /// Gets the identity who did change.
    abstract changedBy: WebApi.IdentityRef with get, set
    /// Gets date on which ReleaseDefinition changed.
    abstract changedDate: DateTime with get, set
    /// Gets type of change.
    abstract changeType: AuditAction with get, set
    /// Gets comments for revision.
    abstract comment: string with get, set
    /// Get id of the definition.
    abstract definitionId: int with get, set
    /// Gets definition URL.
    abstract definitionUrl: string with get, set
    /// Get revision number of the definition.
    abstract revision: int with get, set

type [<AllowNullLiteral>] ReleaseDefinitionShallowReference =
    /// Gets the links to related resources, APIs, and views for the release definition.
    abstract _links: obj option with get, set
    /// Gets the unique identifier of release definition.
    abstract id: int with get, set
    /// Gets or sets the name of the release definition.
    abstract name: string with get, set
    /// Gets or sets the path of the release definition.
    abstract path: string with get, set
    /// Gets or sets project reference.
    abstract projectReference: ProjectReference with get, set
    /// Gets the REST API url to access the release definition.
    abstract url: string with get, set

type [<RequireQualifiedAccess>] ReleaseDefinitionSource =
    | Undefined = 0
    | RestApi = 1
    | UserInterface = 2
    | Ibiza = 4
    | PortalExtensionApi = 8

type [<AllowNullLiteral>] ReleaseDefinitionSummary =
    /// List of Release Definition environment summary.
    abstract environments: ResizeArray<ReleaseDefinitionEnvironmentSummary> with get, set
    /// Release Definition reference.
    abstract releaseDefinition: ReleaseDefinitionShallowReference with get, set
    /// List of releases deployed using this Release Definition.
    abstract releases: ResizeArray<Release> with get, set

type [<AllowNullLiteral>] ReleaseDefinitionUndeleteParameter =
    /// Gets or sets comment.
    abstract comment: string with get, set

type [<AllowNullLiteral>] ReleaseDeployPhase =
    /// Deployment jobs of the phase.
    abstract deploymentJobs: ResizeArray<DeploymentJob> with get, set
    /// Phase execution error logs.
    abstract errorLog: string with get, set
    /// ID of the phase.
    abstract id: int with get, set
    /// List of manual intervention tasks execution information in phase.
    abstract manualInterventions: ResizeArray<ManualIntervention> with get, set
    /// Name of the phase.
    abstract name: string with get, set
    /// ID of the phase.
    abstract phaseId: string with get, set
    /// Type of the phase.
    abstract phaseType: DeployPhaseTypes with get, set
    /// Rank of the phase.
    abstract rank: int with get, set
    /// Run Plan ID of the phase.
    abstract runPlanId: string with get, set
    /// Phase start time.
    abstract startedOn: DateTime with get, set
    /// Status of the phase.
    abstract status: DeployPhaseStatus with get, set

type [<AllowNullLiteral>] ReleaseEnvironment =
    /// Gets list of conditions.
    abstract conditions: ResizeArray<ReleaseCondition> with get, set
    /// Gets date on which it got created.
    abstract createdOn: DateTime with get, set
    /// Gets definition environment id.
    abstract definitionEnvironmentId: int with get, set
    /// Gets demands.
    abstract demands: ResizeArray<Demand> with get, set
    /// Gets list of deploy phases snapshot.
    abstract deployPhasesSnapshot: ResizeArray<DeployPhase> with get, set
    /// Gets deploy steps.
    abstract deploySteps: ResizeArray<DeploymentAttempt> with get, set
    /// Gets environment options.
    abstract environmentOptions: EnvironmentOptions with get, set
    /// Gets the unique identifier of this field.
    abstract id: int with get, set
    /// Gets date on which it got modified.
    abstract modifiedOn: DateTime with get, set
    /// Gets name.
    abstract name: string with get, set
    /// Gets next scheduled UTC time.
    abstract nextScheduledUtcTime: DateTime with get, set
    /// Gets the identity who is owner for release environment.
    abstract owner: WebApi.IdentityRef with get, set
    /// Gets list of post deploy approvals snapshot.
    abstract postApprovalsSnapshot: ReleaseDefinitionApprovals with get, set
    /// Gets list of post deploy approvals.
    abstract postDeployApprovals: ResizeArray<ReleaseApproval> with get, set
    /// Post deployment gates snapshot data.
    abstract postDeploymentGatesSnapshot: ReleaseDefinitionGatesStep with get, set
    /// Gets list of pre deploy approvals snapshot.
    abstract preApprovalsSnapshot: ReleaseDefinitionApprovals with get, set
    /// Gets list of pre deploy approvals.
    abstract preDeployApprovals: ResizeArray<ReleaseApproval> with get, set
    /// Pre deployment gates snapshot data.
    abstract preDeploymentGatesSnapshot: ReleaseDefinitionGatesStep with get, set
    /// Gets process parameters.
    abstract processParameters: DistributedTaskCommon.ProcessParameters with get, set
    /// Gets queue id.
    abstract queueId: int with get, set
    /// Gets rank.
    abstract rank: int with get, set
    /// Gets release reference which specifies the reference of the release to which this release environment is associated.
    abstract release: ReleaseShallowReference with get, set
    /// Gets the identity who created release.
    abstract releaseCreatedBy: WebApi.IdentityRef with get, set
    /// Gets releaseDefinitionReference which specifies the reference of the release definition to which this release environment is associated.
    abstract releaseDefinition: ReleaseDefinitionShallowReference with get, set
    /// Gets release description.
    abstract releaseDescription: string with get, set
    /// Gets release id.
    abstract releaseId: int with get, set
    /// Gets schedule deployment time of release environment.
    abstract scheduledDeploymentTime: DateTime with get, set
    /// Gets list of schedules.
    abstract schedules: ResizeArray<ReleaseSchedule> with get, set
    /// Gets environment status.
    abstract status: EnvironmentStatus with get, set
    /// Gets time to deploy.
    abstract timeToDeploy: int with get, set
    /// Gets trigger reason.
    abstract triggerReason: string with get, set
    /// Gets the list of variable groups.
    abstract variableGroups: ResizeArray<VariableGroup> with get, set
    /// Gets the dictionary of variables.
    abstract variables: ReleaseVariables with get, set
    /// Gets list of workflow tasks.
    abstract workflowTasks: ResizeArray<WorkflowTask> with get, set

type [<AllowNullLiteral>] ReleaseEnvironmentCompletedEvent =
    abstract createdByName: string with get, set
    abstract definitionId: int with get, set
    abstract definitionName: string with get, set
    abstract environment: ReleaseEnvironment with get, set
    abstract environmentId: int with get, set
    abstract projectName: string with get, set
    abstract reason: DeploymentReason with get, set
    abstract releaseCreatedBy: WebApi.IdentityRef with get, set
    abstract releaseLogsUri: string with get, set
    abstract releaseName: string with get, set
    abstract status: string with get, set
    abstract title: string with get, set
    abstract webAccessUri: string with get, set

type [<AllowNullLiteral>] ReleaseEnvironmentShallowReference =
    /// Gets the links to related resources, APIs, and views for the release environment.
    abstract _links: obj option with get, set
    /// Gets the unique identifier of release environment.
    abstract id: int with get, set
    /// Gets or sets the name of the release environment.
    abstract name: string with get, set
    /// Gets the REST API url to access the release environment.
    abstract url: string with get, set

type [<AllowNullLiteral>] ReleaseEnvironmentStatusUpdatedEvent =
    inherit RealtimeReleaseDefinitionEvent
    abstract environmentId: int with get, set
    abstract environmentStatus: EnvironmentStatus with get, set
    abstract latestDeploymentOperationStatus: DeploymentOperationStatus with get, set
    abstract latestDeploymentStatus: DeploymentStatus with get, set
    abstract releaseId: int with get, set

type [<AllowNullLiteral>] ReleaseEnvironmentUpdateMetadata =
    /// Gets or sets comment.
    abstract comment: string with get, set
    /// Gets or sets scheduled deployment time.
    abstract scheduledDeploymentTime: DateTime with get, set
    /// Gets or sets status of environment.
    abstract status: EnvironmentStatus with get, set
    /// Sets list of environment variables to be overridden at deployment time.
    abstract variables: ReleaseVariables with get, set

type [<RequireQualifiedAccess>] ReleaseExpands =
    | None = 0
    | Environments = 2
    | Artifacts = 4
    | Approvals = 8
    | ManualInterventions = 16
    | Variables = 32
    | Tags = 64

type [<AllowNullLiteral>] ReleaseGates =
    /// Contains the gates job details of each evaluation.
    abstract deploymentJobs: ResizeArray<DeploymentJob> with get, set
    /// ID of release gates.
    abstract id: int with get, set
    /// List of ignored gates.
    abstract ignoredGates: ResizeArray<IgnoredGate> with get, set
    /// Gates last modified time.
    abstract lastModifiedOn: DateTime with get, set
    /// Run plan ID of the gates.
    abstract runPlanId: string with get, set
    /// Gates stabilization completed date and time.
    abstract stabilizationCompletedOn: DateTime with get, set
    /// Gates evaluation started time.
    abstract startedOn: DateTime with get, set
    /// Status of release gates.
    abstract status: GateStatus with get, set
    /// Date and time at which all gates executed successfully.
    abstract succeedingSince: DateTime with get, set

type [<AllowNullLiteral>] ReleaseGatesPhase =
    inherit ReleaseDeployPhase
    /// List of ignored gates.
    abstract ignoredGates: ResizeArray<IgnoredGate> with get, set
    /// Date and time at which stabilization of gates completed.
    abstract stabilizationCompletedOn: DateTime with get, set
    /// Date and time at which all gates executed successfully.
    abstract succeedingSince: DateTime with get, set

type [<AllowNullLiteral>] ReleaseManagementInputValue =
    /// The text to show for the display of this value.
    abstract displayValue: string with get, set
    /// The value to store for this input.
    abstract value: string with get, set

type [<AllowNullLiteral>] ReleaseNotCreatedEvent =
    abstract definitionReference: ReleaseDefinitionShallowReference with get, set
    abstract message: string with get, set
    abstract releaseReason: ReleaseReason with get, set
    abstract requestedBy: WebApi.IdentityRef with get, set

type [<RequireQualifiedAccess>] ReleaseQueryOrder =
    | Descending = 0
    | Ascending = 1

type [<RequireQualifiedAccess>] ReleaseReason =
    | None = 0
    | Manual = 1
    | ContinuousIntegration = 2
    | Schedule = 3
    | PullRequest = 4

type [<AllowNullLiteral>] ReleaseReference =
    /// Gets links to access the release.
    abstract _links: obj option with get, set
    /// Gets list of artifacts.
    abstract artifacts: ResizeArray<Artifact> with get, set
    /// Gets the identity who created release.
    abstract createdBy: WebApi.IdentityRef with get, set
    /// Gets date on when this release created.
    abstract createdOn: DateTime with get, set
    /// Gets description.
    abstract description: string with get, set
    /// ID of the Release.
    abstract id: int with get, set
    /// Gets the identity who modified release.
    abstract modifiedBy: WebApi.IdentityRef with get, set
    /// Gets name of release.
    abstract name: string with get, set
    /// Gets reason for release.
    abstract reason: ReleaseReason with get, set
    /// Gets release definition shallow reference.
    abstract releaseDefinition: ReleaseDefinitionShallowReference with get, set
    abstract url: string with get, set
    abstract webAccessUri: string with get, set

type [<AllowNullLiteral>] ReleaseRevision =
    /// Gets or sets the identity who changed.
    abstract changedBy: WebApi.IdentityRef with get, set
    /// Change date of the revision.
    abstract changedDate: DateTime with get, set
    /// Change details of the revision.
    abstract changeDetails: string with get, set
    /// Change details of the revision. Typically ChangeDetails values are Add and Update.
    abstract changeType: string with get, set
    /// Comment of the revision.
    abstract comment: string with get, set
    /// Release ID of which this revision belongs.
    abstract definitionSnapshotRevision: int with get, set
    /// Gets or sets the release ID of which this revision belongs.
    abstract releaseId: int with get, set

type [<AllowNullLiteral>] ReleaseSchedule =
    /// Days of the week to release.
    abstract daysToRelease: ScheduleDays with get, set
    /// Team Foundation Job Definition Job Id.
    abstract jobId: string with get, set
    /// Flag to determine if this schedule should only release if the associated artifact has been changed or release definition changed.
    abstract scheduleOnlyWithChanges: bool with get, set
    /// Local time zone hour to start.
    abstract startHours: int with get, set
    /// Local time zone minute to start.
    abstract startMinutes: int with get, set
    /// Time zone Id of release schedule, such as 'UTC'.
    abstract timeZoneId: string with get, set

type [<AllowNullLiteral>] ReleaseSettings =
    /// Release Compliance settings.
    abstract complianceSettings: ComplianceSettings with get, set
    /// Release retention settings.
    abstract retentionSettings: RetentionSettings with get, set

type [<AllowNullLiteral>] ReleaseShallowReference =
    /// Gets the links to related resources, APIs, and views for the release.
    abstract _links: obj option with get, set
    /// Gets the unique identifier of release.
    abstract id: int with get, set
    /// Gets or sets the name of the release.
    abstract name: string with get, set
    /// Gets the REST API url to access the release.
    abstract url: string with get, set

type [<AllowNullLiteral>] ReleaseStartEnvironmentMetadata =
    /// Sets release definition environment id.
    abstract definitionEnvironmentId: int with get, set
    /// Sets list of environments variables to be overridden at deployment time.
    abstract variables: ReleaseVariables with get, set

type [<AllowNullLiteral>] ReleaseStartMetadata =
    /// Sets list of artifact to create a release.
    abstract artifacts: ResizeArray<ArtifactMetadata> with get, set
    /// Sets definition Id to create a release.
    abstract definitionId: int with get, set
    /// Sets description to create a release.
    abstract description: string with get, set
    /// Sets list of environments meta data.
    abstract environmentsMetadata: ResizeArray<ReleaseStartEnvironmentMetadata> with get, set
    /// Sets 'true' to create release in draft mode, 'false' otherwise.
    abstract isDraft: bool with get, set
    /// Sets list of environments to manual as condition.
    abstract manualEnvironments: ResizeArray<string> with get, set
    abstract properties: obj option with get, set
    /// Sets reason to create a release.
    abstract reason: ReleaseReason with get, set
    /// Sets list of release variables to be overridden at deployment time.
    abstract variables: ReleaseVariables with get, set

type [<RequireQualifiedAccess>] ReleaseStatus =
    | Undefined = 0
    | Draft = 1
    | Active = 2
    | Abandoned = 4

type [<AllowNullLiteral>] ReleaseTask =
    /// Agent name on which task executed.
    abstract agentName: string with get, set
    abstract dateEnded: DateTime with get, set
    abstract dateStarted: DateTime with get, set
    /// Finish time of the release task.
    abstract finishTime: DateTime with get, set
    /// ID of the release task.
    abstract id: int with get, set
    /// List of issues occurred while execution of task.
    abstract issues: ResizeArray<Issue> with get, set
    /// Number of lines log release task has.
    abstract lineCount: int with get, set
    /// Log URL of the task.
    abstract logUrl: string with get, set
    /// Name of the task.
    abstract name: string with get, set
    /// Task execution complete precent.
    abstract percentComplete: int with get, set
    /// Rank of the release task.
    abstract rank: int with get, set
    /// Result code of the task.
    abstract resultCode: string with get, set
    /// ID of the release task.
    abstract startTime: DateTime with get, set
    /// Status of release task.
    abstract status: TaskStatus with get, set
    /// Workflow task reference.
    abstract task: WorkflowTaskReference with get, set
    /// Timeline record ID of the release task.
    abstract timelineRecordId: string with get, set

type [<AllowNullLiteral>] ReleaseTaskAttachment =
    /// Reference links of task.
    abstract _links: obj option with get, set
    /// Data and time when it created.
    abstract createdOn: DateTime with get, set
    /// Identity who modified.
    abstract modifiedBy: WebApi.IdentityRef with get, set
    /// Data and time when modified.
    abstract modifiedOn: DateTime with get, set
    /// Name of the task attachment.
    abstract name: string with get, set
    /// Record ID of the task.
    abstract recordId: string with get, set
    /// Timeline ID of the task.
    abstract timelineId: string with get, set
    /// Type of task attachment.
    abstract ``type``: string with get, set

type [<AllowNullLiteral>] ReleaseTaskLogUpdatedEvent =
    inherit RealtimeReleaseEvent
    abstract lines: ResizeArray<string> with get, set
    abstract stepRecordId: string with get, set
    abstract timelineRecordId: string with get, set

type [<AllowNullLiteral>] ReleaseTasksUpdatedEvent =
    inherit RealtimeReleaseEvent
    abstract job: ReleaseTask with get, set
    abstract planId: string with get, set
    abstract releaseDeployPhaseId: int with get, set
    abstract releaseStepId: int with get, set
    abstract tasks: ResizeArray<ReleaseTask> with get, set

type [<AllowNullLiteral>] ReleaseTriggerBase =
    /// Type of release trigger.
    abstract triggerType: ReleaseTriggerType with get, set

type [<RequireQualifiedAccess>] ReleaseTriggerType =
    | Undefined = 0
    | ArtifactSource = 1
    | Schedule = 2
    | SourceRepo = 3
    | ContainerImage = 4
    | Package = 5
    | PullRequest = 6

type [<AllowNullLiteral>] ReleaseUpdatedEvent =
    inherit RealtimeReleaseEvent
    abstract release: Release with get, set

type [<AllowNullLiteral>] ReleaseUpdateMetadata =
    /// Sets comment for release.
    abstract comment: string with get, set
    /// Set 'true' to exclude the release from retention policies.
    abstract keepForever: bool with get, set
    /// Sets list of manual environments.
    abstract manualEnvironments: ResizeArray<string> with get, set
    /// Sets name of the release.
    abstract name: string with get, set
    /// Sets status of the release.
    abstract status: ReleaseStatus with get, set

type [<AllowNullLiteral>] ReleaseWorkItemRef =
    abstract assignee: string with get, set
    /// Gets or sets the ID.
    abstract id: string with get, set
    /// Gets or sets the provider.
    abstract provider: string with get, set
    /// Gets or sets the state.
    abstract state: string with get, set
    /// Gets or sets the title.
    abstract title: string with get, set
    /// Gets or sets the type.
    abstract ``type``: string with get, set
    /// Gets or sets the workitem url.
    abstract url: string with get, set

/// Represents a reference to a resource.
type [<AllowNullLiteral>] ResourceReference =
    /// An alias to be used when referencing the resource.
    abstract alias: string with get, set

type [<AllowNullLiteral>] RetentionPolicy =
    /// Indicates the number of days to keep deployment.
    abstract daysToKeep: int with get, set

type [<AllowNullLiteral>] RetentionSettings =
    /// Number of days to keep deleted releases.
    abstract daysToKeepDeletedReleases: int with get, set
    /// Specifies the default environment retention policy.
    abstract defaultEnvironmentRetentionPolicy: EnvironmentRetentionPolicy with get, set
    /// Specifies the maximum environment retention policy.
    abstract maximumEnvironmentRetentionPolicy: EnvironmentRetentionPolicy with get, set

type [<AllowNullLiteral>] RunOnServerDeployPhase =
    inherit DeployPhase
    /// Gets and sets the agentless job input.
    abstract deploymentInput: ServerDeploymentInput with get, set

type [<RequireQualifiedAccess>] ScheduleDays =
    | None = 0
    | Monday = 1
    | Tuesday = 2
    | Wednesday = 4
    | Thursday = 8
    | Friday = 16
    | Saturday = 32
    | Sunday = 64
    | All = 127

type [<AllowNullLiteral>] ScheduledReleaseTrigger =
    inherit ReleaseTriggerBase
    /// Release schedule for Scheduled Release trigger type.
    abstract schedule: ReleaseSchedule with get, set

type [<RequireQualifiedAccess>] SenderType =
    | ServiceAccount = 1
    | RequestingUser = 2

type [<AllowNullLiteral>] ServerDeploymentInput =
    inherit BaseDeploymentInput
    /// Gets or sets the parallel execution input.
    abstract parallelExecution: ExecutionInput with get, set

/// Represents a reference to a service endpoint.
type [<AllowNullLiteral>] ServiceEndpointReference =
    inherit ResourceReference
    /// The ID of the service endpoint.
    abstract id: string with get, set

type [<RequireQualifiedAccess>] SingleReleaseExpands =
    | None = 0
    | Tasks = 1

type [<AllowNullLiteral>] SourceIdInput =
    /// ID of source.
    abstract id: string with get, set
    /// Name of the source.
    abstract name: string with get, set

type [<AllowNullLiteral>] SourcePullRequestVersion =
    /// Pull Request Iteration Id for which the release will publish status.
    abstract iterationId: string with get, set
    /// Pull Request Id for which the release will publish status.
    abstract pullRequestId: string with get, set
    /// Date and time of the pull request merge creation. It is required to keep timeline record of Releases created by pull request.
    abstract pullRequestMergedAt: DateTime with get, set
    /// Source branch of the Pull Request.
    abstract sourceBranch: string with get, set
    /// Source branch commit Id of the Pull Request for which the release will publish status.
    abstract sourceBranchCommitId: string with get, set
    /// Target branch of the Pull Request.
    abstract targetBranch: string with get, set

type [<AllowNullLiteral>] SourceRepoTrigger =
    inherit ReleaseTriggerBase
    /// Alias of the source repo trigger.
    abstract alias: string with get, set
    abstract branchFilters: ResizeArray<string> with get, set

type [<AllowNullLiteral>] SummaryMailSection =
    /// Html content of summary mail.
    abstract htmlContent: string with get, set
    /// Rank of the summary mail.
    abstract rank: int with get, set
    /// Summary mail section type. MailSectionType has section types.
    abstract sectionType: MailSectionType with get, set
    /// Title of the summary mail.
    abstract title: string with get, set

type [<AllowNullLiteral>] TagFilter =
    /// Gets or sets the tag filter pattern.
    abstract pattern: string with get, set

type [<AllowNullLiteral>] TaskOrchestrationPlanGroupReference =
    /// Gets or sets the plan group.
    abstract planGroup: string with get, set
    /// ID of the Project.
    abstract projectId: string with get, set

type [<AllowNullLiteral>] TaskOrchestrationPlanGroupsStartedEvent =
    abstract planGroups: ResizeArray<TaskOrchestrationPlanGroupReference> with get, set

type [<RequireQualifiedAccess>] TaskStatus =
    | Unknown = 0
    | Pending = 1
    | InProgress = 2
    | Success = 3
    | Failure = 4
    | Canceled = 5
    | Skipped = 6
    | Succeeded = 7
    | Failed = 8
    | PartiallySucceeded = 9

type [<AllowNullLiteral>] TfvcArtifactDownloadInput =
    inherit ArtifactDownloadInputBase

type [<AllowNullLiteral>] TimeZone =
    /// Display name of the time zone.
    abstract displayName: string with get, set
    /// Id of the time zone.
    abstract id: string with get, set

type [<AllowNullLiteral>] TimeZoneList =
    /// UTC timezone.
    abstract utcTimeZone: TimeZone with get, set
    /// List of valid timezones.
    abstract validTimeZones: ResizeArray<TimeZone> with get, set

type [<AllowNullLiteral>] VariableGroup =
    /// Gets or sets the identity who created.
    abstract createdBy: WebApi.IdentityRef with get, set
    /// Gets date on which it got created.
    abstract createdOn: DateTime with get, set
    /// Gets or sets description.
    abstract description: string with get, set
    /// Gets the unique identifier of this field.
    abstract id: int with get, set
    /// Denotes if a variable group is shared with other project or not.
    abstract isShared: bool with get, set
    /// Gets or sets the identity who modified.
    abstract modifiedBy: WebApi.IdentityRef with get, set
    /// Gets date on which it got modified.
    abstract modifiedOn: DateTime with get, set
    /// Gets or sets name.
    abstract name: string with get, set
    /// Gets or sets provider data.
    abstract providerData: VariableGroupProviderData with get, set
    /// Gets or sets type.
    abstract ``type``: string with get, set
    /// all project references where the variable group is shared with other projects.
    abstract variableGroupProjectReferences: ResizeArray<VariableGroupProjectReference> with get, set
    /// Gets and sets the dictionary of variables.
    abstract variables: VariableGroupVariables with get, set

type [<RequireQualifiedAccess>] VariableGroupActionFilter =
    | None = 0
    | Manage = 2
    | Use = 16

/// A variable group reference is a shallow reference to variable group.
type [<AllowNullLiteral>] VariableGroupProjectReference =
    /// Gets or sets description of the variable group.
    abstract description: string with get, set
    /// Gets or sets name of the variable group.
    abstract name: string with get, set
    /// Gets or sets project reference of the variable group.
    abstract projectReference: ProjectReference with get, set

type [<AllowNullLiteral>] VariableGroupProviderData =
    interface end

type [<AllowNullLiteral>] VariableValue =
    /// Gets or sets as the variable is secret or not.
    abstract isSecret: bool with get, set
    /// Gets or sets the value.
    abstract value: string with get, set

type [<AllowNullLiteral>] WorkflowTask =
    /// Gets or sets as the task always run or not.
    abstract alwaysRun: bool with get, set
    /// Gets or sets the task condition.
    abstract condition: string with get, set
    /// Gets or sets as the task continue run on error or not.
    abstract continueOnError: bool with get, set
    /// Gets or sets the task definition type. Example:- 'Agent', DeploymentGroup', 'Server' or 'ServerGate'.
    abstract definitionType: string with get, set
    /// Gets or sets as the task enabled or not.
    abstract enabled: bool with get, set
    /// Gets or sets the task environment variables.
    abstract environment: ArtifactContributionDefinitionArtifactTypeStreamMapping with get, set
    /// Gets or sets the task inputs.
    abstract inputs: ArtifactContributionDefinitionArtifactTypeStreamMapping with get, set
    /// Gets or sets the name of the task.
    abstract name: string with get, set
    /// Gets or sets the task override inputs.
    abstract overrideInputs: ArtifactContributionDefinitionArtifactTypeStreamMapping with get, set
    /// Gets or sets the reference name of the task.
    abstract refName: string with get, set
    /// Gets or sets the ID of the task.
    abstract taskId: string with get, set
    /// Gets or sets the task timeout.
    abstract timeoutInMinutes: int with get, set
    /// Gets or sets the version of the task.
    abstract version: string with get, set

type [<AllowNullLiteral>] WorkflowTaskReference =
    /// Task identifier.
    abstract id: string with get, set
    /// Name of the task.
    abstract name: string with get, set
    /// Version of the task.
    abstract version: string with get, set

type [<AllowNullLiteral>] YamlFileSource =
    /// Gets or sets definition reference. e.g. \{"project":\{"id":"fed755ea-49c5-4399-acea-fd5b5aa90a6c","name":"myProject"\},"definition":\{"id":"1","name":"mybuildDefinition"\},"connection":\{"id":"1","name":"myConnection"\}\}
    abstract sourceReference: YamlFileSourceSourceReference with get, set
    abstract ``type``: YamlFileSourceTypes with get, set

type [<RequireQualifiedAccess>] YamlFileSourceTypes =
    | None = 0
    | TFSGit = 1

type [<AllowNullLiteral>] YamlPipelineProcess =
    inherit PipelineProcess
    abstract errors: ResizeArray<string> with get, set
    abstract filename: string with get, set
    abstract fileSource: YamlFileSource with get, set
    abstract resources: YamlPipelineProcessResources with get, set

type [<AllowNullLiteral>] YamlPipelineProcessResources =
    abstract endpoints: ResizeArray<ServiceEndpointReference> with get, set
    abstract queues: ResizeArray<AgentPoolQueueReference> with get, set

type [<AllowNullLiteral>] YamlSourceReference =
    abstract id: string with get, set
    abstract name: string with get, set

type [<AllowNullLiteral>] ArtifactDefinitionReference =
    [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> ArtifactSourceReference with get, set

type [<AllowNullLiteral>] ArtifactContributionDefinitionArtifactTypeStreamMapping =
    [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> string with get, set

type [<AllowNullLiteral>] CodeRepositoryReferenceRepositoryReference =
    [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> ReleaseManagementInputValue with get, set

type [<AllowNullLiteral>] DeploymentApprovalPendingEventData =
    [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

type [<AllowNullLiteral>] MappingDetailsMappings =
    [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> FormInput.InputValue with get, set

type [<AllowNullLiteral>] ReleaseVariables =
    [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> ConfigurationVariableValue with get, set

type [<AllowNullLiteral>] VariableGroupVariables =
    [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> VariableValue with get, set

type [<AllowNullLiteral>] YamlFileSourceSourceReference =
    [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> YamlSourceReference with get, set
