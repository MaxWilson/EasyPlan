// ts2fable 0.7.1
module rec Build
open System
open Fable.Core
open Fable.Core.JS


module Build =
    module TfsCore = ___Core_Core
    module DistributedTaskCommon = ___DistributedTaskCommon_DistributedTaskCommon
    module Git = ___Git_Git
    module Test = ___Test_Test
    module WebApi = ___WebApi_WebApi

    /// Represents a queue for running builds.
    type [<AllowNullLiteral>] AgentPoolQueue =
        abstract _links: obj option with get, set
        /// The ID of the queue.
        abstract id: float with get, set
        /// The name of the queue.
        abstract name: string with get, set
        /// The pool used by this queue.
        abstract pool: TaskAgentPoolReference with get, set
        /// The full http link to the resource.
        abstract url: string with get, set

    /// Represents a reference to an agent queue.
    type [<AllowNullLiteral>] AgentPoolQueueReference =
        inherit ResourceReference
        /// The ID of the queue.
        abstract id: float with get, set

    /// Describes how a phase should run against an agent queue.
    type [<AllowNullLiteral>] AgentPoolQueueTarget =
        inherit PhaseTarget
        /// Agent specification of the target.
        abstract agentSpecification: AgentSpecification with get, set
        /// Enables scripts and other processes launched while executing phase to access the OAuth token
        abstract allowScriptsAuthAccessOption: bool with get, set
        abstract demands: ResizeArray<Demand> with get, set
        /// The execution options.
        abstract executionOptions: AgentTargetExecutionOptions with get, set
        /// The queue.
        abstract queue: AgentPoolQueue with get, set

    /// Specification of the agent defined by the pool provider.
    type [<AllowNullLiteral>] AgentSpecification =
        /// Agent specification unique identifier.
        abstract identifier: string with get, set

    type [<RequireQualifiedAccess>] AgentStatus =
        | Unavailable = 0
        | Available = 1
        | Offline = 2

    /// Additional options for running phases against an agent queue.
    type [<AllowNullLiteral>] AgentTargetExecutionOptions =
        /// Indicates the type of execution options.
        abstract ``type``: float with get, set

    type [<AllowNullLiteral>] ArtifactResource =
        abstract _links: obj option with get, set
        /// Type-specific data about the artifact.
        abstract data: string with get, set
        /// A link to download the resource.
        abstract downloadUrl: string with get, set
        /// Type-specific properties of the artifact.
        abstract properties: ArtifactResourceProperties with get, set
        /// The type of the resource: File container, version control folder, UNC path, etc.
        abstract ``type``: string with get, set
        /// The full http link to the resource.
        abstract url: string with get, set

    /// Represents an attachment to a build.
    type [<AllowNullLiteral>] Attachment =
        abstract _links: obj option with get, set
        /// The name of the attachment.
        abstract name: string with get, set

    type [<RequireQualifiedAccess>] AuditAction =
        | Add = 1
        | Update = 2
        | Delete = 3

    /// Data representation of a build.
    type [<AllowNullLiteral>] Build =
        abstract _links: obj option with get, set
        /// The agent specification for the build.
        abstract agentSpecification: AgentSpecification with get, set
        /// The build number/name of the build.
        abstract buildNumber: string with get, set
        /// The build number revision.
        abstract buildNumberRevision: float with get, set
        /// The build controller. This is only set if the definition type is Xaml.
        abstract controller: BuildController with get, set
        /// The definition associated with the build.
        abstract definition: DefinitionReference with get, set
        /// Indicates whether the build has been deleted.
        abstract deleted: bool with get, set
        /// The identity of the process or person that deleted the build.
        abstract deletedBy: WebApi.IdentityRef with get, set
        /// The date the build was deleted.
        abstract deletedDate: DateTime with get, set
        /// The description of how the build was deleted.
        abstract deletedReason: string with get, set
        /// A list of demands that represents the agent capabilities required by this build.
        abstract demands: ResizeArray<Demand> with get, set
        /// The time that the build was completed.
        abstract finishTime: DateTime with get, set
        /// The ID of the build.
        abstract id: float with get, set
        /// Indicates whether the build should be skipped by retention policies.
        abstract keepForever: bool with get, set
        /// The identity representing the process or person that last changed the build.
        abstract lastChangedBy: WebApi.IdentityRef with get, set
        /// The date the build was last changed.
        abstract lastChangedDate: DateTime with get, set
        /// Information about the build logs.
        abstract logs: BuildLogReference with get, set
        /// The orchestration plan for the build.
        abstract orchestrationPlan: TaskOrchestrationPlanReference with get, set
        /// The parameters for the build.
        abstract parameters: string with get, set
        /// Orchestration plans associated with the build (build, cleanup)
        abstract plans: ResizeArray<TaskOrchestrationPlanReference> with get, set
        /// The build's priority.
        abstract priority: QueuePriority with get, set
        /// The team project.
        abstract project: TfsCore.TeamProjectReference with get, set
        abstract properties: obj option with get, set
        /// The quality of the xaml build (good, bad, etc.)
        abstract quality: string with get, set
        /// The queue. This is only set if the definition type is Build.
        abstract queue: AgentPoolQueue with get, set
        /// Additional options for queueing the build.
        abstract queueOptions: QueueOptions with get, set
        /// The current position of the build in the queue.
        abstract queuePosition: float with get, set
        /// The time that the build was queued.
        abstract queueTime: DateTime with get, set
        /// The reason that the build was created.
        abstract reason: BuildReason with get, set
        /// The repository.
        abstract repository: BuildRepository with get, set
        /// The identity that queued the build.
        abstract requestedBy: WebApi.IdentityRef with get, set
        /// The identity on whose behalf the build was queued.
        abstract requestedFor: WebApi.IdentityRef with get, set
        /// The build result.
        abstract result: BuildResult with get, set
        /// Indicates whether the build is retained by a release.
        abstract retainedByRelease: bool with get, set
        /// The source branch.
        abstract sourceBranch: string with get, set
        /// The source version.
        abstract sourceVersion: string with get, set
        /// The time that the build was started.
        abstract startTime: DateTime with get, set
        /// The status of the build.
        abstract status: BuildStatus with get, set
        abstract tags: ResizeArray<string> with get, set
        /// The build that triggered this build via a Build completion trigger.
        abstract triggeredByBuild: Build with get, set
        /// Sourceprovider-specific information about what triggered the build
        abstract triggerInfo: ArtifactResourceProperties with get, set
        /// The URI of the build.
        abstract uri: string with get, set
        /// The REST URL of the build.
        abstract url: string with get, set
        abstract validationResults: ResizeArray<BuildRequestValidationResult> with get, set

    type [<AllowNullLiteral>] BuildAgent =
        abstract buildDirectory: string with get, set
        abstract controller: XamlBuildControllerReference with get, set
        abstract createdDate: DateTime with get, set
        abstract description: string with get, set
        abstract enabled: bool with get, set
        abstract id: float with get, set
        abstract messageQueueUrl: string with get, set
        abstract name: string with get, set
        abstract reservedForBuild: string with get, set
        abstract server: XamlBuildServerReference with get, set
        abstract status: AgentStatus with get, set
        abstract statusMessage: string with get, set
        abstract updatedDate: DateTime with get, set
        abstract uri: string with get, set
        abstract url: string with get, set

    type [<AllowNullLiteral>] BuildAgentReference =
        /// Id of the resource
        abstract id: float with get, set
        /// Name of the linked resource (definition name, controller name, etc.)
        abstract name: string with get, set
        /// Full http link to the resource
        abstract url: string with get, set

    /// Represents an artifact produced by a build.
    type [<AllowNullLiteral>] BuildArtifact =
        /// The artifact ID.
        abstract id: float with get, set
        /// The name of the artifact.
        abstract name: string with get, set
        /// The actual resource.
        abstract resource: ArtifactResource with get, set
        /// The artifact source, which will be the ID of the job that produced this artifact. If an artifact is associated with multiple sources, this points to the first source.
        abstract source: string with get, set

    type [<RequireQualifiedAccess>] BuildAuthorizationScope =
        | ProjectCollection = 1
        | Project = 2

    /// Represents a build badge.
    type [<AllowNullLiteral>] BuildBadge =
        /// The ID of the build represented by this badge.
        abstract buildId: float with get, set
        /// A link to the SVG resource.
        abstract imageUrl: string with get, set

    type [<AllowNullLiteral>] BuildCompletedEvent =
        inherit BuildUpdatedEvent
        /// Changes associated with a build used for build notifications
        abstract changes: ResizeArray<Change> with get, set
        /// Pull request for the build used for build notifications
        abstract pullRequest: PullRequest with get, set
        /// Test results associated with a build used for build notifications
        abstract testResults: Test.AggregatedResultsAnalysis with get, set
        /// Timeline records associated with a build used for build notifications
        abstract timelineRecords: ResizeArray<TimelineRecord> with get, set
        /// Work items associated with a build used for build notifications
        abstract workItems: ResizeArray<Git.AssociatedWorkItem> with get, set

    /// Represents a build completion trigger.
    type [<AllowNullLiteral>] BuildCompletionTrigger =
        inherit BuildTrigger
        abstract branchFilters: ResizeArray<string> with get, set
        /// A reference to the definition that should trigger builds for this definition.
        abstract definition: DefinitionReference with get, set
        abstract requiresSuccessfulBuild: bool with get, set

    type [<AllowNullLiteral>] BuildController =
        inherit XamlBuildControllerReference
        abstract _links: obj option with get, set
        /// The date the controller was created.
        abstract createdDate: DateTime with get, set
        /// The description of the controller.
        abstract description: string with get, set
        /// Indicates whether the controller is enabled.
        abstract enabled: bool with get, set
        /// The status of the controller.
        abstract status: ControllerStatus with get, set
        /// The date the controller was last updated.
        abstract updatedDate: DateTime with get, set
        /// The controller's URI.
        abstract uri: string with get, set

    /// Represents a build definition.
    type [<AllowNullLiteral>] BuildDefinition =
        inherit BuildDefinitionReference
        /// Indicates whether badges are enabled for this definition.
        abstract badgeEnabled: bool with get, set
        /// The build number format.
        abstract buildNumberFormat: string with get, set
        /// A save-time comment for the definition.
        abstract comment: string with get, set
        abstract demands: ResizeArray<Demand> with get, set
        /// The description.
        abstract description: string with get, set
        /// The drop location for the definition.
        abstract dropLocation: string with get, set
        /// The job authorization scope for builds queued against this definition.
        abstract jobAuthorizationScope: BuildAuthorizationScope with get, set
        /// The job cancel timeout (in minutes) for builds cancelled by user for this definition.
        abstract jobCancelTimeoutInMinutes: float with get, set
        /// The job execution timeout (in minutes) for builds queued against this definition.
        abstract jobTimeoutInMinutes: float with get, set
        abstract options: ResizeArray<BuildOption> with get, set
        /// The build process.
        abstract ``process``: BuildProcess with get, set
        /// The process parameters for this definition.
        abstract processParameters: DistributedTaskCommon.ProcessParameters with get, set
        abstract properties: obj option with get, set
        /// The repository.
        abstract repository: BuildRepository with get, set
        abstract retentionRules: ResizeArray<RetentionPolicy> with get, set
        abstract tags: ResizeArray<string> with get, set
        abstract triggers: ResizeArray<BuildTrigger> with get, set
        abstract variableGroups: ResizeArray<VariableGroup> with get, set
        abstract variables: BuildDefinitionVariables with get, set

    /// For back-compat with extensions that use the old Steps format instead of Process and Phases
    type [<AllowNullLiteral>] BuildDefinition3_2 =
        inherit BuildDefinitionReference3_2
        /// Indicates whether badges are enabled for this definition
        abstract badgeEnabled: bool with get, set
        abstract build: ResizeArray<BuildDefinitionStep> with get, set
        /// The build number format
        abstract buildNumberFormat: string with get, set
        /// The comment entered when saving the definition
        abstract comment: string with get, set
        abstract demands: ResizeArray<Demand> with get, set
        /// The description
        abstract description: string with get, set
        /// The drop location for the definition
        abstract dropLocation: string with get, set
        /// The job authorization scope for builds which are queued against this definition
        abstract jobAuthorizationScope: BuildAuthorizationScope with get, set
        /// The job cancel timeout in minutes for builds which are cancelled by user for this definition
        abstract jobCancelTimeoutInMinutes: float with get, set
        /// The job execution timeout in minutes for builds which are queued against this definition
        abstract jobTimeoutInMinutes: float with get, set
        abstract latestBuild: Build with get, set
        abstract latestCompletedBuild: Build with get, set
        abstract options: ResizeArray<BuildOption> with get, set
        /// Process Parameters
        abstract processParameters: DistributedTaskCommon.ProcessParameters with get, set
        abstract properties: obj option with get, set
        /// The repository
        abstract repository: BuildRepository with get, set
        abstract retentionRules: ResizeArray<RetentionPolicy> with get, set
        abstract tags: ResizeArray<string> with get, set
        abstract triggers: ResizeArray<BuildTrigger> with get, set
        abstract variables: BuildDefinitionVariables with get, set

    /// Represents a reference to a build definition.
    type [<AllowNullLiteral>] BuildDefinitionReference =
        inherit DefinitionReference
        abstract _links: obj option with get, set
        /// The author of the definition.
        abstract authoredBy: WebApi.IdentityRef with get, set
        /// A reference to the definition that this definition is a draft of, if this is a draft definition.
        abstract draftOf: DefinitionReference with get, set
        /// The list of drafts associated with this definition, if this is not a draft definition.
        abstract drafts: ResizeArray<DefinitionReference> with get, set
        abstract latestBuild: Build with get, set
        abstract latestCompletedBuild: Build with get, set
        abstract metrics: ResizeArray<BuildMetric> with get, set
        /// The quality of the definition document (draft, etc.)
        abstract quality: DefinitionQuality with get, set
        /// The default queue for builds run against this definition.
        abstract queue: AgentPoolQueue with get, set

    /// For back-compat with extensions that use the old Steps format instead of Process and Phases
    type [<AllowNullLiteral>] BuildDefinitionReference3_2 =
        inherit DefinitionReference
        abstract _links: obj option with get, set
        /// The author of the definition.
        abstract authoredBy: WebApi.IdentityRef with get, set
        /// A reference to the definition that this definition is a draft of, if this is a draft definition.
        abstract draftOf: DefinitionReference with get, set
        /// The list of drafts associated with this definition, if this is not a draft definition.
        abstract drafts: ResizeArray<DefinitionReference> with get, set
        abstract metrics: ResizeArray<BuildMetric> with get, set
        /// The quality of the definition document (draft, etc.)
        abstract quality: DefinitionQuality with get, set
        /// The default queue for builds run against this definition.
        abstract queue: AgentPoolQueue with get, set

    /// Represents a revision of a build definition.
    type [<AllowNullLiteral>] BuildDefinitionRevision =
        /// The identity of the person or process that changed the definition.
        abstract changedBy: WebApi.IdentityRef with get, set
        /// The date and time that the definition was changed.
        abstract changedDate: DateTime with get, set
        /// The change type (add, edit, delete).
        abstract changeType: AuditAction with get, set
        /// The comment associated with the change.
        abstract comment: string with get, set
        /// A link to the definition at this revision.
        abstract definitionUrl: string with get, set
        /// The name of the definition.
        abstract name: string with get, set
        /// The revision number.
        abstract revision: float with get, set

    type [<AllowNullLiteral>] BuildDefinitionSourceProvider =
        /// Uri of the associated definition
        abstract definitionUri: string with get, set
        /// fields associated with this build definition
        abstract fields: ArtifactResourceProperties with get, set
        /// Id of this source provider
        abstract id: float with get, set
        /// The lst time this source provider was modified
        abstract lastModified: DateTime with get, set
        /// Name of the source provider
        abstract name: string with get, set
        /// Which trigger types are supported by this definition source provider
        abstract supportedTriggerTypes: DefinitionTriggerType with get, set

    /// Represents a step in a build phase.
    type [<AllowNullLiteral>] BuildDefinitionStep =
        /// Indicates whether this step should run even if a previous step fails.
        abstract alwaysRun: bool with get, set
        /// A condition that determines whether this step should run.
        abstract condition: string with get, set
        /// Indicates whether the phase should continue even if this step fails.
        abstract continueOnError: bool with get, set
        /// The display name for this step.
        abstract displayName: string with get, set
        /// Indicates whether the step is enabled.
        abstract enabled: bool with get, set
        abstract environment: ArtifactResourceProperties with get, set
        abstract inputs: ArtifactResourceProperties with get, set
        /// The reference name for this step.
        abstract refName: string with get, set
        /// The task associated with this step.
        abstract task: TaskDefinitionReference with get, set
        /// The time, in minutes, that this step is allowed to run.
        abstract timeoutInMinutes: float with get, set

    /// Represents a template from which new build definitions can be created.
    type [<AllowNullLiteral>] BuildDefinitionTemplate =
        /// Indicates whether the template can be deleted.
        abstract canDelete: bool with get, set
        /// The template category.
        abstract category: string with get, set
        /// An optional hosted agent queue for the template to use by default.
        abstract defaultHostedQueue: string with get, set
        /// A description of the template.
        abstract description: string with get, set
        abstract icons: ArtifactResourceProperties with get, set
        /// The ID of the task whose icon is used when showing this template in the UI.
        abstract iconTaskId: string with get, set
        /// The ID of the template.
        abstract id: string with get, set
        /// The name of the template.
        abstract name: string with get, set
        /// The actual template.
        abstract template: BuildDefinition with get, set

    /// For back-compat with extensions that use the old Steps format instead of Process and Phases
    type [<AllowNullLiteral>] BuildDefinitionTemplate3_2 =
        abstract canDelete: bool with get, set
        abstract category: string with get, set
        abstract defaultHostedQueue: string with get, set
        abstract description: string with get, set
        abstract icons: ArtifactResourceProperties with get, set
        abstract iconTaskId: string with get, set
        abstract id: string with get, set
        abstract name: string with get, set
        abstract template: BuildDefinition3_2 with get, set

    /// Represents a variable used by a build definition.
    type [<AllowNullLiteral>] BuildDefinitionVariable =
        /// Indicates whether the value can be set at queue time.
        abstract allowOverride: bool with get, set
        /// Indicates whether the variable's value is a secret.
        abstract isSecret: bool with get, set
        /// The value of the variable.
        abstract value: string with get, set

    type [<AllowNullLiteral>] BuildDeletedEvent =
        inherit RealtimeBuildEvent
        abstract build: Build with get, set

    type [<AllowNullLiteral>] BuildDeployment =
        abstract deployment: BuildSummary with get, set
        abstract sourceBuild: XamlBuildReference with get, set

    type [<AllowNullLiteral>] BuildEvent =
        abstract data: ResizeArray<string> with get, set
        abstract identifier: string with get, set

    /// Represents a build log.
    type [<AllowNullLiteral>] BuildLog =
        inherit BuildLogReference
        /// The date and time the log was created.
        abstract createdOn: DateTime with get, set
        /// The date and time the log was last changed.
        abstract lastChangedOn: DateTime with get, set
        /// The number of lines in the log.
        abstract lineCount: float with get, set

    /// Represents a reference to a build log.
    type [<AllowNullLiteral>] BuildLogReference =
        /// The ID of the log.
        abstract id: float with get, set
        /// The type of the log location.
        abstract ``type``: string with get, set
        /// A full link to the log resource.
        abstract url: string with get, set

    /// Represents metadata about builds in the system.
    type [<AllowNullLiteral>] BuildMetric =
        /// The date for the scope.
        abstract date: DateTime with get, set
        /// The value.
        abstract intValue: float with get, set
        /// The name of the metric.
        abstract name: string with get, set
        /// The scope.
        abstract scope: string with get, set

    /// Represents the application of an optional behavior to a build definition.
    type [<AllowNullLiteral>] BuildOption =
        /// A reference to the build option.
        abstract definition: BuildOptionDefinitionReference with get, set
        /// Indicates whether the behavior is enabled.
        abstract enabled: bool with get, set
        abstract inputs: ArtifactResourceProperties with get, set

    /// Represents an optional behavior that can be applied to a build definition.
    type [<AllowNullLiteral>] BuildOptionDefinition =
        inherit BuildOptionDefinitionReference
        /// The description.
        abstract description: string with get, set
        /// The list of input groups defined for the build option.
        abstract groups: ResizeArray<BuildOptionGroupDefinition> with get, set
        /// The list of inputs defined for the build option.
        abstract inputs: ResizeArray<BuildOptionInputDefinition> with get, set
        /// The name of the build option.
        abstract name: string with get, set
        /// A value that indicates the relative order in which the behavior should be applied.
        abstract ordinal: float with get, set

    /// Represents a reference to a build option definition.
    type [<AllowNullLiteral>] BuildOptionDefinitionReference =
        /// The ID of the referenced build option.
        abstract id: string with get, set

    /// Represents a group of inputs for a build option.
    type [<AllowNullLiteral>] BuildOptionGroupDefinition =
        /// The name of the group to display in the UI.
        abstract displayName: string with get, set
        /// Indicates whether the group is initially displayed as expanded in the UI.
        abstract isExpanded: bool with get, set
        /// The internal name of the group.
        abstract name: string with get, set

    /// Represents an input for a build option.
    type [<AllowNullLiteral>] BuildOptionInputDefinition =
        /// The default value.
        abstract defaultValue: string with get, set
        /// The name of the input group that this input belongs to.
        abstract groupName: string with get, set
        abstract help: ArtifactResourceProperties with get, set
        /// The label for the input.
        abstract label: string with get, set
        /// The name of the input.
        abstract name: string with get, set
        abstract options: ArtifactResourceProperties with get, set
        /// Indicates whether the input is required to have a value.
        abstract required: bool with get, set
        /// Indicates the type of the input value.
        abstract ``type``: BuildOptionInputType with get, set
        /// The rule that is applied to determine whether the input is visible in the UI.
        abstract visibleRule: string with get, set

    type [<RequireQualifiedAccess>] BuildOptionInputType =
        | String = 0
        | Boolean = 1
        | StringList = 2
        | Radio = 3
        | PickList = 4
        | MultiLine = 5
        | BranchFilter = 6

    type [<RequireQualifiedAccess>] BuildPhaseStatus =
        | Unknown = 0
        | Failed = 1
        | Succeeded = 2

    /// Represents a build process.
    type [<AllowNullLiteral>] BuildProcess =
        /// The type of the process.
        abstract ``type``: float with get, set

    /// Represents resources used by a build process.
    type [<AllowNullLiteral>] BuildProcessResources =
        abstract endpoints: ResizeArray<ServiceEndpointReference> with get, set
        abstract files: ResizeArray<SecureFileReference> with get, set
        abstract queues: ResizeArray<AgentPoolQueueReference> with get, set
        abstract variableGroups: ResizeArray<VariableGroupReference> with get, set

    type [<AllowNullLiteral>] BuildProcessTemplate =
        abstract description: string with get, set
        abstract fileExists: bool with get, set
        abstract id: float with get, set
        abstract parameters: string with get, set
        abstract serverPath: string with get, set
        abstract supportedReasons: BuildReason with get, set
        abstract teamProject: string with get, set
        abstract templateType: ProcessTemplateType with get, set
        abstract url: string with get, set
        abstract version: string with get, set

    type [<RequireQualifiedAccess>] BuildQueryOrder =
        | FinishTimeAscending = 2
        | FinishTimeDescending = 3
        | QueueTimeDescending = 4
        | QueueTimeAscending = 5
        | StartTimeDescending = 6
        | StartTimeAscending = 7

    type [<AllowNullLiteral>] BuildQueuedEvent =
        inherit BuildUpdatedEvent

    type [<RequireQualifiedAccess>] BuildReason =
        | None = 0
        | Manual = 1
        | IndividualCI = 2
        | BatchedCI = 4
        | Schedule = 8
        | ScheduleForced = 16
        | UserCreated = 32
        | ValidateShelveset = 64
        | CheckInShelveset = 128
        | PullRequest = 256
        | BuildCompletion = 512
        | Triggered = 943
        | All = 1007

    /// Represents a reference to a build.
    type [<AllowNullLiteral>] BuildReference =
        abstract _links: obj option with get, set
        /// The build number.
        abstract buildNumber: string with get, set
        /// Indicates whether the build has been deleted.
        abstract deleted: bool with get, set
        /// The time that the build was completed.
        abstract finishTime: DateTime with get, set
        /// The ID of the build.
        abstract id: float with get, set
        /// The time that the build was queued.
        abstract queueTime: DateTime with get, set
        /// The identity on whose behalf the build was queued.
        abstract requestedFor: WebApi.IdentityRef with get, set
        /// The build result.
        abstract result: BuildResult with get, set
        /// The time that the build was started.
        abstract startTime: DateTime with get, set
        /// The build status.
        abstract status: BuildStatus with get, set

    /// Represents information about a build report.
    type [<AllowNullLiteral>] BuildReportMetadata =
        /// The Id of the build.
        abstract buildId: float with get, set
        /// The content of the report.
        abstract content: string with get, set
        /// The type of the report.
        abstract ``type``: string with get, set

    /// Represents a repository used by a build definition.
    type [<AllowNullLiteral>] BuildRepository =
        /// Indicates whether to checkout submodules.
        abstract checkoutSubmodules: bool with get, set
        /// Indicates whether to clean the target folder when getting code from the repository.
        abstract clean: string with get, set
        /// The name of the default branch.
        abstract defaultBranch: string with get, set
        /// The ID of the repository.
        abstract id: string with get, set
        /// The friendly name of the repository.
        abstract name: string with get, set
        abstract properties: ArtifactResourceProperties with get, set
        /// The root folder.
        abstract rootFolder: string with get, set
        /// The type of the repository.
        abstract ``type``: string with get, set
        /// The URL of the repository.
        abstract url: string with get, set

    /// Represents the result of validating a build request.
    type [<AllowNullLiteral>] BuildRequestValidationResult =
        /// The message associated with the result.
        abstract message: string with get, set
        /// The result.
        abstract result: ValidationResult with get, set

    /// Represents information about resources used by builds in the system.
    type [<AllowNullLiteral>] BuildResourceUsage =
        /// The number of build agents.
        abstract distributedTaskAgents: float with get, set
        /// The number of paid private agent slots.
        abstract paidPrivateAgentSlots: float with get, set
        /// The total usage.
        abstract totalUsage: float with get, set
        /// The number of XAML controllers.
        abstract xamlControllers: float with get, set

    type [<RequireQualifiedAccess>] BuildResult =
        | None = 0
        | Succeeded = 2
        | PartiallySucceeded = 4
        | Failed = 8
        | Canceled = 32

    type [<AllowNullLiteral>] BuildsDeletedEvent =
        inherit BuildsDeletedEvent1

    type [<AllowNullLiteral>] BuildsDeletedEvent1 =
        abstract buildIds: ResizeArray<float> with get, set
        /// The ID of the definition.
        abstract definitionId: float with get, set
        /// The ID of the project.
        abstract projectId: string with get, set

    type [<AllowNullLiteral>] BuildServer =
        abstract agents: ResizeArray<BuildAgentReference> with get, set
        abstract controller: XamlBuildControllerReference with get, set
        abstract id: float with get, set
        abstract isVirtual: bool with get, set
        abstract messageQueueUrl: string with get, set
        abstract name: string with get, set
        abstract requireClientCertificates: bool with get, set
        abstract status: ServiceHostStatus with get, set
        abstract statusChangedDate: DateTime with get, set
        abstract uri: string with get, set
        abstract url: string with get, set
        abstract version: float with get, set

    /// Represents system-wide build settings.
    type [<AllowNullLiteral>] BuildSettings =
        /// The number of days to keep records of deleted builds.
        abstract daysToKeepDeletedBuildsBeforeDestroy: float with get, set
        /// The default retention policy.
        abstract defaultRetentionPolicy: RetentionPolicy with get, set
        /// The maximum retention policy.
        abstract maximumRetentionPolicy: RetentionPolicy with get, set

    type [<RequireQualifiedAccess>] BuildStatus =
        | None = 0
        | InProgress = 1
        | Completed = 2
        | Cancelling = 4
        | Postponed = 8
        | NotStarted = 32
        | All = 47

    type [<AllowNullLiteral>] BuildSummary =
        abstract build: XamlBuildReference with get, set
        abstract finishTime: DateTime with get, set
        abstract keepForever: bool with get, set
        abstract quality: string with get, set
        abstract reason: BuildReason with get, set
        abstract requestedFor: WebApi.IdentityRef with get, set
        abstract startTime: DateTime with get, set
        abstract status: BuildStatus with get, set

    type [<AllowNullLiteral>] BuildTagsAddedEvent =
        inherit BuildUpdatedEvent
        abstract allTags: ResizeArray<string> with get, set
        abstract newTags: ResizeArray<string> with get, set

    /// Represents a trigger for a buld definition.
    type [<AllowNullLiteral>] BuildTrigger =
        /// The type of the trigger.
        abstract triggerType: DefinitionTriggerType with get, set

    type [<AllowNullLiteral>] BuildUpdatedEvent =
        inherit RealtimeBuildEvent
        abstract build: Build with get, set

    /// Represents a workspace mapping.
    type [<AllowNullLiteral>] BuildWorkspace =
        abstract mappings: ResizeArray<MappingDetails> with get, set

    /// Represents a change associated with a build.
    type [<AllowNullLiteral>] Change =
        /// The author of the change.
        abstract author: WebApi.IdentityRef with get, set
        /// The location of a user-friendly representation of the resource.
        abstract displayUri: string with get, set
        /// The identifier for the change. For a commit, this would be the SHA1. For a TFVC changeset, this would be the changeset ID.
        abstract id: string with get, set
        /// The location of the full representation of the resource.
        abstract location: string with get, set
        /// The description of the change. This might be a commit message or changeset description.
        abstract message: string with get, set
        /// Indicates whether the message was truncated.
        abstract messageTruncated: bool with get, set
        /// The person or process that pushed the change.
        abstract pusher: string with get, set
        /// The timestamp for the change.
        abstract timestamp: DateTime with get, set
        /// The type of change. "commit", "changeset", etc.
        abstract ``type``: string with get, set

    type [<AllowNullLiteral>] ConsoleLogEvent =
        inherit RealtimeBuildEvent
        abstract lines: ResizeArray<string> with get, set
        abstract stepRecordId: string with get, set
        abstract timelineId: string with get, set
        abstract timelineRecordId: string with get, set

    type [<AllowNullLiteral>] ContinuousDeploymentDefinition =
        /// The connected service associated with the continuous deployment
        abstract connectedService: TfsCore.WebApiConnectedServiceRef with get, set
        /// The definition associated with the continuous deployment
        abstract definition: XamlDefinitionReference with get, set
        abstract gitBranch: string with get, set
        abstract hostedServiceName: string with get, set
        abstract project: TfsCore.TeamProjectReference with get, set
        abstract repositoryId: string with get, set
        abstract storageAccountName: string with get, set
        abstract subscriptionId: string with get, set
        abstract website: string with get, set
        abstract webspace: string with get, set

    /// Represents a continuous integration (CI) trigger.
    type [<AllowNullLiteral>] ContinuousIntegrationTrigger =
        inherit BuildTrigger
        /// Indicates whether changes should be batched while another CI build is running.
        abstract batchChanges: bool with get, set
        abstract branchFilters: ResizeArray<string> with get, set
        /// The maximum number of simultaneous CI builds that will run per branch.
        abstract maxConcurrentBuildsPerBranch: float with get, set
        abstract pathFilters: ResizeArray<string> with get, set
        /// The polling interval, in seconds.
        abstract pollingInterval: float with get, set
        /// The ID of the job used to poll an external repository.
        abstract pollingJobId: string with get, set
        abstract settingsSourceType: float with get, set

    type [<RequireQualifiedAccess>] ControllerStatus =
        | Unavailable = 0
        | Available = 1
        | Offline = 2

    type [<RequireQualifiedAccess>] DefinitionQuality =
        | Definition = 1
        | Draft = 2

    type [<RequireQualifiedAccess>] DefinitionQueryOrder =
        | None = 0
        | LastModifiedAscending = 1
        | LastModifiedDescending = 2
        | DefinitionNameAscending = 3
        | DefinitionNameDescending = 4

    type [<RequireQualifiedAccess>] DefinitionQueueStatus =
        | Enabled = 0
        | Paused = 1
        | Disabled = 2

    /// Represents a reference to a definition.
    type [<AllowNullLiteral>] DefinitionReference =
        /// The date this version of the definition was created.
        abstract createdDate: DateTime with get, set
        /// The ID of the referenced definition.
        abstract id: float with get, set
        /// The name of the referenced definition.
        abstract name: string with get, set
        /// The folder path of the definition.
        abstract path: string with get, set
        /// A reference to the project.
        abstract project: TfsCore.TeamProjectReference with get, set
        /// A value that indicates whether builds can be queued against this definition.
        abstract queueStatus: DefinitionQueueStatus with get, set
        /// The definition revision number.
        abstract revision: float with get, set
        /// The type of the definition.
        abstract ``type``: DefinitionType with get, set
        /// The definition's URI.
        abstract uri: string with get, set
        /// The REST URL of the definition.
        abstract url: string with get, set

    type [<AllowNullLiteral>] DefinitionResourceReference =
        /// Indicates whether the resource is authorized for use.
        abstract authorized: bool with get, set
        /// The id of the resource.
        abstract id: string with get, set
        /// A friendly name for the resource.
        abstract name: string with get, set
        /// The type of the resource.
        abstract ``type``: string with get, set

    type [<RequireQualifiedAccess>] DefinitionTriggerType =
        | None = 1
        | ContinuousIntegration = 2
        | BatchedContinuousIntegration = 4
        | Schedule = 8
        | GatedCheckIn = 16
        | BatchedGatedCheckIn = 32
        | PullRequest = 64
        | BuildCompletion = 128
        | All = 255

    type [<RequireQualifiedAccess>] DefinitionType =
        | Xaml = 1
        | Build = 2

    type [<RequireQualifiedAccess>] DeleteOptions =
        | None = 0
        | DropLocation = 1
        | TestResults = 2
        | Label = 4
        | Details = 8
        | Symbols = 16
        | All = 31

    /// Represents a demand used by a definition or build.
    type [<AllowNullLiteral>] Demand =
        /// The name of the capability referenced by the demand.
        abstract name: string with get, set
        /// The demanded value.
        abstract value: string with get, set

    /// Represents a dependency.
    type [<AllowNullLiteral>] Dependency =
        /// The event. The dependency is satisfied when the referenced object emits this event.
        abstract ``event``: string with get, set
        /// The scope. This names the object referenced by the dependency.
        abstract scope: string with get, set

    /// Represents the data from the build information nodes for type "DeploymentInformation" for xaml builds
    type [<AllowNullLiteral>] Deployment =
        abstract ``type``: string with get, set

    /// Deployment information for type "Build"
    type [<AllowNullLiteral>] DeploymentBuild =
        inherit Deployment
        abstract buildId: float with get, set

    /// Deployment information for type "Deploy"
    type [<AllowNullLiteral>] DeploymentDeploy =
        inherit Deployment
        abstract message: string with get, set

    /// Deployment information for type "Test"
    type [<AllowNullLiteral>] DeploymentTest =
        inherit Deployment
        abstract runId: float with get, set

    /// Represents a build process supported by the build definition designer.
    type [<AllowNullLiteral>] DesignerProcess =
        inherit BuildProcess
        abstract phases: ResizeArray<Phase> with get, set
        /// The target for the build process.
        abstract target: DesignerProcessTarget with get, set

    /// Represents the target for the build process.
    type [<AllowNullLiteral>] DesignerProcessTarget =
        /// Agent specification for the build process.
        abstract agentSpecification: AgentSpecification with get, set

    type [<AllowNullLiteral>] DockerProcess =
        inherit BuildProcess
        abstract target: DockerProcessTarget with get, set

    /// Represents the target for the docker build process.
    type [<AllowNullLiteral>] DockerProcessTarget =
        inherit DesignerProcessTarget

    /// Represents a folder that contains build definitions.
    type [<AllowNullLiteral>] Folder =
        /// The process or person who created the folder.
        abstract createdBy: WebApi.IdentityRef with get, set
        /// The date the folder was created.
        abstract createdOn: DateTime with get, set
        /// The description.
        abstract description: string with get, set
        /// The process or person that last changed the folder.
        abstract lastChangedBy: WebApi.IdentityRef with get, set
        /// The date the folder was last changed.
        abstract lastChangedDate: DateTime with get, set
        /// The full path.
        abstract path: string with get, set
        /// The project.
        abstract project: TfsCore.TeamProjectReference with get, set

    type [<RequireQualifiedAccess>] FolderQueryOrder =
        | None = 0
        | FolderAscending = 1
        | FolderDescending = 2

    /// Represents the ability to build forks of the selected repository.
    type [<AllowNullLiteral>] Forks =
        /// Indicates whether a build should use secrets when building forks of the selected repository.
        abstract allowSecrets: bool with get, set
        /// Indicates whether the trigger should queue builds for forks of the selected repository.
        abstract enabled: bool with get, set

    /// Represents a gated check-in trigger.
    type [<AllowNullLiteral>] GatedCheckInTrigger =
        inherit BuildTrigger
        abstract pathFilters: ResizeArray<string> with get, set
        /// Indicates whether CI triggers should run after the gated check-in succeeds.
        abstract runContinuousIntegration: bool with get, set
        /// Indicates whether to take workspace mappings into account when determining whether a build should run.
        abstract useWorkspaceMappings: bool with get, set

    type [<RequireQualifiedAccess>] GetOption =
        | LatestOnQueue = 0
        | LatestOnBuild = 1
        | Custom = 2

    /// Data representation of an information node associated with a build
    type [<AllowNullLiteral>] InformationNode =
        /// Fields of the information node
        abstract fields: ArtifactResourceProperties with get, set
        /// Process or person that last modified this node
        abstract lastModifiedBy: string with get, set
        /// Date this node was last modified
        abstract lastModifiedDate: DateTime with get, set
        /// Node Id of this information node
        abstract nodeId: float with get, set
        /// Id of parent node (xml tree)
        abstract parentId: float with get, set
        /// The type of the information node
        abstract ``type``: string with get, set

    /// Represents an issue (error, warning) associated with a build.
    type [<AllowNullLiteral>] Issue =
        /// The category.
        abstract category: string with get, set
        abstract data: ArtifactResourceProperties with get, set
        /// A description of the issue.
        abstract message: string with get, set
        /// The type (error, warning) of the issue.
        abstract ``type``: IssueType with get, set

    type [<RequireQualifiedAccess>] IssueType =
        | Error = 1
        | Warning = 2

    type [<AllowNullLiteral>] JustInTimeProcess =
        inherit BuildProcess

    /// Represents an entry in a workspace mapping.
    type [<AllowNullLiteral>] MappingDetails =
        /// The local path.
        abstract localPath: string with get, set
        /// The mapping type.
        abstract mappingType: string with get, set
        /// The server path.
        abstract serverPath: string with get, set

    /// Represents options for running a phase against multiple agents.
    type [<AllowNullLiteral>] MultipleAgentExecutionOptions =
        inherit AgentTargetExecutionOptions
        /// Indicates whether failure on one agent should prevent the phase from running on other agents.
        abstract continueOnError: bool with get, set
        /// The maximum number of agents to use simultaneously.
        abstract maxConcurrency: float with get, set

    /// Represents a phase of a build definition.
    type [<AllowNullLiteral>] Phase =
        /// The condition that must be true for this phase to execute.
        abstract condition: string with get, set
        abstract dependencies: ResizeArray<Dependency> with get, set
        /// The job authorization scope for builds queued against this definition.
        abstract jobAuthorizationScope: BuildAuthorizationScope with get, set
        /// The cancellation timeout, in minutes, for builds queued against this definition.
        abstract jobCancelTimeoutInMinutes: float with get, set
        /// The job execution timeout, in minutes, for builds queued against this definition.
        abstract jobTimeoutInMinutes: float with get, set
        /// The name of the phase.
        abstract name: string with get, set
        /// The unique ref name of the phase.
        abstract refName: string with get, set
        abstract steps: ResizeArray<BuildDefinitionStep> with get, set
        /// The target (agent, server, etc.) for this phase.
        abstract target: PhaseTarget with get, set
        abstract variables: BuildDefinitionVariables with get, set

    /// Represents the target of a phase.
    type [<AllowNullLiteral>] PhaseTarget =
        /// The type of the target.
        abstract ``type``: float with get, set

    type [<RequireQualifiedAccess>] ProcessTemplateType =
        | Custom = 0
        | Default = 1
        | Upgrade = 2

    /// Contains the settings for the retention rules.
    type [<AllowNullLiteral>] ProjectRetentionSetting =
        /// The rules for artifact retention. Artifacts can not live longer than a run, so will be overridden by a shorter run purge setting.
        abstract purgeArtifacts: RetentionSetting with get, set
        /// The rules for pull request pipeline run retention.
        abstract purgePullRequestRuns: RetentionSetting with get, set
        /// The rules for pipeline run retention.
        abstract purgeRuns: RetentionSetting with get, set

    /// Represents a pull request object.  These are retrieved from Source Providers.
    type [<AllowNullLiteral>] PullRequest =
        /// The links to other objects related to this object.
        abstract _links: obj option with get, set
        /// Author of the pull request.
        abstract author: WebApi.IdentityRef with get, set
        /// Current state of the pull request, e.g. open, merged, closed, conflicts, etc.
        abstract currentState: string with get, set
        /// Description for the pull request.
        abstract description: string with get, set
        /// Unique identifier for the pull request
        abstract id: string with get, set
        /// The name of the provider this pull request is associated with.
        abstract providerName: string with get, set
        /// Source branch ref of this pull request
        abstract sourceBranchRef: string with get, set
        /// Owner of the source repository of this pull request
        abstract sourceRepositoryOwner: string with get, set
        /// Target branch ref of this pull request
        abstract targetBranchRef: string with get, set
        /// Owner of the target repository of this pull request
        abstract targetRepositoryOwner: string with get, set
        /// Title of the pull request.
        abstract title: string with get, set

    /// Represents a pull request trigger.
    type [<AllowNullLiteral>] PullRequestTrigger =
        inherit BuildTrigger
        /// Indicates if an update to a PR should delete current in-progress builds.
        abstract autoCancel: bool with get, set
        abstract branchFilters: ResizeArray<string> with get, set
        abstract forks: Forks with get, set
        abstract isCommentRequiredForPullRequest: bool with get, set
        abstract pathFilters: ResizeArray<string> with get, set
        abstract requireCommentsForNonTeamMembersOnly: bool with get, set
        abstract settingsSourceType: float with get, set

    type [<RequireQualifiedAccess>] QueryDeletedOption =
        | ExcludeDeleted = 0
        | IncludeDeleted = 1
        | OnlyDeleted = 2

    type [<RequireQualifiedAccess>] QueueOptions =
        | None = 0
        | DoNotRun = 1

    type [<RequireQualifiedAccess>] QueuePriority =
        | Low = 5
        | BelowNormal = 4
        | Normal = 3
        | AboveNormal = 2
        | High = 1

    type [<AllowNullLiteral>] RealtimeBuildEvent =
        abstract buildId: float with get, set

    type [<RequireQualifiedAccess>] RepositoryCleanOptions =
        | Source = 0
        | SourceAndOutputDir = 1
        | SourceDir = 2
        | AllBuildDir = 3

    /// Represents a repository's webhook returned from a source provider.
    type [<AllowNullLiteral>] RepositoryWebhook =
        /// The friendly name of the repository.
        abstract name: string with get, set
        abstract types: ResizeArray<DefinitionTriggerType> with get, set
        /// The URL of the repository.
        abstract url: string with get, set

    /// Represents a reference to a resource.
    type [<AllowNullLiteral>] ResourceReference =
        /// An alias to be used when referencing the resource.
        abstract alias: string with get, set

    type [<RequireQualifiedAccess>] ResultSet =
        | All = 0
        | Top = 1

    /// Represents a retention policy for a build definition.
    type [<AllowNullLiteral>] RetentionPolicy =
        abstract artifacts: ResizeArray<string> with get, set
        abstract artifactTypesToDelete: ResizeArray<string> with get, set
        abstract branches: ResizeArray<string> with get, set
        /// The number of days to keep builds.
        abstract daysToKeep: float with get, set
        /// Indicates whether the build record itself should be deleted.
        abstract deleteBuildRecord: bool with get, set
        /// Indicates whether to delete test results associated with the build.
        abstract deleteTestResults: bool with get, set
        /// The minimum number of builds to keep.
        abstract minimumToKeep: float with get, set

    /// Contains the minimum, maximum, and current value for a retention setting.
    type [<AllowNullLiteral>] RetentionSetting =
        abstract max: float with get, set
        abstract min: float with get, set
        abstract value: float with get, set

    type [<AllowNullLiteral>] Schedule =
        abstract branchFilters: ResizeArray<string> with get, set
        /// Days for a build (flags enum for days of the week)
        abstract daysToBuild: ScheduleDays with get, set
        /// The Job Id of the Scheduled job that will queue the scheduled build. Since a single trigger can have multiple schedules and we want a single job to process a single schedule (since each schedule has a list of branches to build), the schedule itself needs to define the Job Id. This value will be filled in when a definition is added or updated.  The UI does not provide it or use it.
        abstract scheduleJobId: string with get, set
        /// Flag to determine if this schedule should only build if the associated source has been changed.
        abstract scheduleOnlyWithChanges: bool with get, set
        /// Local timezone hour to start
        abstract startHours: float with get, set
        /// Local timezone minute to start
        abstract startMinutes: float with get, set
        /// Time zone of the build schedule (String representation of the time zone ID)
        abstract timeZoneId: string with get, set

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

    /// Represents a schedule trigger.
    type [<AllowNullLiteral>] ScheduleTrigger =
        inherit BuildTrigger
        abstract schedules: ResizeArray<Schedule> with get, set

    /// Represents a reference to a secure file.
    type [<AllowNullLiteral>] SecureFileReference =
        inherit ResourceReference
        /// The ID of the secure file.
        abstract id: string with get, set

    /// Represents a phase target that runs on the server.
    type [<AllowNullLiteral>] ServerTarget =
        inherit PhaseTarget
        /// The execution options.
        abstract executionOptions: ServerTargetExecutionOptions with get, set

    /// Represents options for running a phase on the server.
    type [<AllowNullLiteral>] ServerTargetExecutionOptions =
        /// The type.
        abstract ``type``: float with get, set

    /// Represents a referenec to a service endpoint.
    type [<AllowNullLiteral>] ServiceEndpointReference =
        inherit ResourceReference
        /// The ID of the service endpoint.
        abstract id: string with get, set

    type [<RequireQualifiedAccess>] ServiceHostStatus =
        | Online = 1
        | Offline = 2

    type [<AllowNullLiteral>] SourceProviderAttributes =
        /// The name of the source provider.
        abstract name: string with get, set
        /// The capabilities supported by this source provider.
        abstract supportedCapabilities: SourceProviderAttributesSupportedCapabilities with get, set
        /// The types of triggers supported by this source provider.
        abstract supportedTriggers: ResizeArray<SupportedTrigger> with get, set

    type [<RequireQualifiedAccess>] SourceProviderAvailability =
        | Hosted = 1
        | OnPremises = 2
        | All = 3

    /// Represents a work item related to some source item. These are retrieved from Source Providers.
    type [<AllowNullLiteral>] SourceRelatedWorkItem =
        abstract _links: obj option with get, set
        /// Identity ref for the person that the work item is assigned to.
        abstract assignedTo: WebApi.IdentityRef with get, set
        /// Current state of the work item, e.g. Active, Resolved, Closed, etc.
        abstract currentState: string with get, set
        /// Long description for the work item.
        abstract description: string with get, set
        /// Unique identifier for the work item
        abstract id: string with get, set
        /// The name of the provider the work item is associated with.
        abstract providerName: string with get, set
        /// Short name for the work item.
        abstract title: string with get, set
        /// Type of work item, e.g. Bug, Task, User Story, etc.
        abstract ``type``: string with get, set

    /// A set of repositories returned from the source provider.
    type [<AllowNullLiteral>] SourceRepositories =
        /// A token used to continue this paged request; 'null' if the request is complete
        abstract continuationToken: string with get, set
        /// The number of repositories requested for each page
        abstract pageLength: float with get, set
        /// A list of repositories
        abstract repositories: ResizeArray<SourceRepository> with get, set
        /// The total number of pages, or '-1' if unknown
        abstract totalPageCount: float with get, set

    /// Represents a repository returned from a source provider.
    type [<AllowNullLiteral>] SourceRepository =
        /// The name of the default branch.
        abstract defaultBranch: string with get, set
        /// The full name of the repository.
        abstract fullName: string with get, set
        /// The ID of the repository.
        abstract id: string with get, set
        /// The friendly name of the repository.
        abstract name: string with get, set
        abstract properties: ArtifactResourceProperties with get, set
        /// The name of the source provider the repository is from.
        abstract sourceProviderName: string with get, set
        /// The URL of the repository.
        abstract url: string with get, set

    /// Represents an item in a repository from a source provider.
    type [<AllowNullLiteral>] SourceRepositoryItem =
        /// Whether the item is able to have sub-items (e.g., is a folder).
        abstract isContainer: bool with get, set
        /// The full path of the item, relative to the root of the repository.
        abstract path: string with get, set
        /// The type of the item (folder, file, etc).
        abstract ``type``: string with get, set
        /// The URL of the item.
        abstract url: string with get, set

    type [<RequireQualifiedAccess>] StageUpdateType =
        | Cancel = 0
        | Retry = 1

    type [<AllowNullLiteral>] SupportedTrigger =
        /// The default interval to wait between polls (only relevant when NotificationType is Polling).
        abstract defaultPollingInterval: float with get, set
        /// How the trigger is notified of changes.
        abstract notificationType: string with get, set
        /// The capabilities supported by this trigger.
        abstract supportedCapabilities: SupportedTriggerSupportedCapabilities with get, set
        /// The type of trigger.
        abstract ``type``: DefinitionTriggerType with get, set

    type [<RequireQualifiedAccess>] SupportLevel =
        | Unsupported = 0
        | Supported = 1
        | Required = 2

    /// Represents a Subversion mapping entry.
    type [<AllowNullLiteral>] SvnMappingDetails =
        /// The depth.
        abstract depth: float with get, set
        /// Indicates whether to ignore externals.
        abstract ignoreExternals: bool with get, set
        /// The local path.
        abstract localPath: string with get, set
        /// The revision.
        abstract revision: string with get, set
        /// The server path.
        abstract serverPath: string with get, set

    /// Represents a subversion workspace.
    type [<AllowNullLiteral>] SvnWorkspace =
        abstract mappings: ResizeArray<SvnMappingDetails> with get, set

    /// Represents a reference to an agent pool.
    type [<AllowNullLiteral>] TaskAgentPoolReference =
        /// The pool ID.
        abstract id: float with get, set
        /// A value indicating whether or not this pool is managed by the service.
        abstract isHosted: bool with get, set
        /// The pool name.
        abstract name: string with get, set

    /// A reference to a task definition.
    type [<AllowNullLiteral>] TaskDefinitionReference =
        /// The type of task (task or task group).
        abstract definitionType: string with get, set
        /// The ID of the task.
        abstract id: string with get, set
        /// The version of the task.
        abstract versionSpec: string with get, set

    /// Represents a reference to a plan group.
    type [<AllowNullLiteral>] TaskOrchestrationPlanGroupReference =
        /// The name of the plan group.
        abstract planGroup: string with get, set
        /// The project ID.
        abstract projectId: string with get, set

    type [<AllowNullLiteral>] TaskOrchestrationPlanGroupsStartedEvent =
        abstract planGroups: ResizeArray<TaskOrchestrationPlanGroupReference> with get, set

    /// Represents a reference to an orchestration plan.
    type [<AllowNullLiteral>] TaskOrchestrationPlanReference =
        /// The type of the plan.
        abstract orchestrationType: float with get, set
        /// The ID of the plan.
        abstract planId: string with get, set

    /// Represents a reference to a task.
    type [<AllowNullLiteral>] TaskReference =
        /// The ID of the task definition.
        abstract id: string with get, set
        /// The name of the task definition.
        abstract name: string with get, set
        /// The version of the task definition.
        abstract version: string with get, set

    type [<RequireQualifiedAccess>] TaskResult =
        | Succeeded = 0
        | SucceededWithIssues = 1
        | Failed = 2
        | Canceled = 3
        | Skipped = 4
        | Abandoned = 5

    /// Represents the timeline of a build.
    type [<AllowNullLiteral>] Timeline =
        inherit TimelineReference
        /// The process or person that last changed the timeline.
        abstract lastChangedBy: string with get, set
        /// The time the timeline was last changed.
        abstract lastChangedOn: DateTime with get, set
        abstract records: ResizeArray<TimelineRecord> with get, set

    type [<AllowNullLiteral>] TimelineAttempt =
        /// Gets or sets the attempt of the record.
        abstract attempt: float with get, set
        /// Gets or sets the record identifier located within the specified timeline.
        abstract recordId: string with get, set
        /// Gets or sets the timeline identifier which owns the record representing this attempt.
        abstract timelineId: string with get, set

    /// Represents an entry in a build's timeline.
    type [<AllowNullLiteral>] TimelineRecord =
        abstract _links: obj option with get, set
        /// Attempt number of record.
        abstract attempt: float with get, set
        /// The change ID.
        abstract changeId: float with get, set
        /// A string that indicates the current operation.
        abstract currentOperation: string with get, set
        /// A reference to a sub-timeline.
        abstract details: TimelineReference with get, set
        /// The number of errors produced by this operation.
        abstract errorCount: float with get, set
        /// The finish time.
        abstract finishTime: DateTime with get, set
        /// The ID of the record.
        abstract id: string with get, set
        /// String identifier that is consistent across attempts.
        abstract identifier: string with get, set
        abstract issues: ResizeArray<Issue> with get, set
        /// The time the record was last modified.
        abstract lastModified: DateTime with get, set
        /// A reference to the log produced by this operation.
        abstract log: BuildLogReference with get, set
        /// The name.
        abstract name: string with get, set
        /// An ordinal value relative to other records.
        abstract order: float with get, set
        /// The ID of the record's parent.
        abstract parentId: string with get, set
        /// The current completion percentage.
        abstract percentComplete: float with get, set
        abstract previousAttempts: ResizeArray<TimelineAttempt> with get, set
        /// The result.
        abstract result: TaskResult with get, set
        /// The result code.
        abstract resultCode: string with get, set
        /// The start time.
        abstract startTime: DateTime with get, set
        /// The state of the record.
        abstract state: TimelineRecordState with get, set
        /// A reference to the task represented by this timeline record.
        abstract task: TaskReference with get, set
        /// The type of the record.
        abstract ``type``: string with get, set
        /// The REST URL of the timeline record.
        abstract url: string with get, set
        /// The number of warnings produced by this operation.
        abstract warningCount: float with get, set
        /// The name of the agent running the operation.
        abstract workerName: string with get, set

    type [<RequireQualifiedAccess>] TimelineRecordState =
        | Pending = 0
        | InProgress = 1
        | Completed = 2

    type [<AllowNullLiteral>] TimelineRecordsUpdatedEvent =
        inherit RealtimeBuildEvent
        abstract timelineRecords: ResizeArray<TimelineRecord> with get, set

    /// Represents a reference to a timeline.
    type [<AllowNullLiteral>] TimelineReference =
        /// The change ID.
        abstract changeId: float with get, set
        /// The ID of the timeline.
        abstract id: string with get, set
        /// The REST URL of the timeline.
        abstract url: string with get, set

    /// Contains members for updating the retention settings values. All fields are optional.
    type [<AllowNullLiteral>] UpdateProjectRetentionSettingModel =
        abstract artifactsRetention: UpdateRetentionSettingModel with get, set
        abstract pullRequestRunRetention: UpdateRetentionSettingModel with get, set
        abstract runRetention: UpdateRetentionSettingModel with get, set

    type [<AllowNullLiteral>] UpdateRetentionSettingModel =
        abstract value: float with get, set

    type [<AllowNullLiteral>] UpdateStageParameters =
        abstract state: StageUpdateType with get, set

    type [<RequireQualifiedAccess>] ValidationResult =
        | OK = 0
        | Warning = 1
        | Error = 2

    /// Represents a variable group.
    type [<AllowNullLiteral>] VariableGroup =
        inherit VariableGroupReference
        /// The description.
        abstract description: string with get, set
        /// The name of the variable group.
        abstract name: string with get, set
        /// The type of the variable group.
        abstract ``type``: string with get, set
        abstract variables: BuildDefinitionVariables with get, set

    /// Represents a reference to a variable group.
    type [<AllowNullLiteral>] VariableGroupReference =
        /// The Name of the variable group.
        abstract alias: string with get, set
        /// The ID of the variable group.
        abstract id: float with get, set

    /// Represents options for running a phase based on values specified by a list of variables.
    type [<AllowNullLiteral>] VariableMultipliersAgentExecutionOptions =
        inherit AgentTargetExecutionOptions
        /// Indicates whether failure on one agent should prevent the phase from running on other agents.
        abstract continueOnError: bool with get, set
        /// The maximum number of agents to use in parallel.
        abstract maxConcurrency: float with get, set
        abstract multipliers: ResizeArray<string> with get, set

    /// Represents options for running a phase based on values specified by a list of variables.
    type [<AllowNullLiteral>] VariableMultipliersServerExecutionOptions =
        inherit ServerTargetExecutionOptions
        /// Indicates whether failure of one job should prevent the phase from running in other jobs.
        abstract continueOnError: bool with get, set
        /// The maximum number of server jobs to run in parallel.
        abstract maxConcurrency: float with get, set
        abstract multipliers: ResizeArray<string> with get, set

    /// Mapping for a workspace
    type [<AllowNullLiteral>] WorkspaceMapping =
        /// Uri of the associated definition
        abstract definitionUri: string with get, set
        /// Depth of this mapping
        abstract depth: float with get, set
        /// local location of the definition
        abstract localItem: string with get, set
        /// type of workspace mapping
        abstract mappingType: WorkspaceMappingType with get, set
        /// Server location of the definition
        abstract serverItem: string with get, set
        /// Id of the workspace
        abstract workspaceId: float with get, set

    type [<RequireQualifiedAccess>] WorkspaceMappingType =
        | Map = 0
        | Cloak = 1

    type [<AllowNullLiteral>] WorkspaceTemplate =
        /// Uri of the associated definition
        abstract definitionUri: string with get, set
        /// The identity that last modified this template
        abstract lastModifiedBy: string with get, set
        /// The last time this template was modified
        abstract lastModifiedDate: DateTime with get, set
        /// List of workspace mappings
        abstract mappings: ResizeArray<WorkspaceMapping> with get, set
        /// Id of the workspace for this template
        abstract workspaceId: float with get, set

    type [<AllowNullLiteral>] XamlBuildControllerReference =
        /// Id of the resource
        abstract id: float with get, set
        /// Name of the linked resource (definition name, controller name, etc.)
        abstract name: string with get, set
        /// Full http link to the resource
        abstract url: string with get, set

    type [<AllowNullLiteral>] XamlBuildDefinition =
        inherit DefinitionReference
        abstract _links: obj option with get, set
        /// Batch size of the definition
        abstract batchSize: float with get, set
        abstract buildArgs: string with get, set
        /// The continuous integration quiet period
        abstract continuousIntegrationQuietPeriod: float with get, set
        /// The build controller
        abstract controller: BuildController with get, set
        /// The date this definition was created
        abstract createdOn: DateTime with get, set
        /// Default drop location for builds from this definition
        abstract defaultDropLocation: string with get, set
        /// Description of the definition
        abstract description: string with get, set
        /// The last build on this definition
        abstract lastBuild: XamlBuildReference with get, set
        /// The repository
        abstract repository: BuildRepository with get, set
        /// The reasons supported by the template
        abstract supportedReasons: BuildReason with get, set
        /// How builds are triggered from this definition
        abstract triggerType: DefinitionTriggerType with get, set

    type [<AllowNullLiteral>] XamlBuildReference =
        /// Id of the resource
        abstract id: float with get, set
        /// Name of the linked resource (definition name, controller name, etc.)
        abstract name: string with get, set
        /// Full http link to the resource
        abstract url: string with get, set

    type [<AllowNullLiteral>] XamlBuildServerReference =
        /// Id of the resource
        abstract id: float with get, set
        /// Name of the linked resource (definition name, controller name, etc.)
        abstract name: string with get, set
        /// Full http link to the resource
        abstract url: string with get, set

    type [<AllowNullLiteral>] XamlDefinitionReference =
        /// Id of the resource
        abstract id: float with get, set
        /// Name of the linked resource (definition name, controller name, etc.)
        abstract name: string with get, set
        /// Full http link to the resource
        abstract url: string with get, set

    /// Represents a YAML process.
    type [<AllowNullLiteral>] YamlProcess =
        inherit BuildProcess
        abstract errors: ResizeArray<string> with get, set
        /// The resources used by the build definition.
        abstract resources: BuildProcessResources with get, set
        /// The YAML filename.
        abstract yamlFilename: string with get, set

    type [<AllowNullLiteral>] ArtifactResourceProperties =
        [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> string with get, set

    type [<AllowNullLiteral>] BuildDefinitionVariables =
        [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> BuildDefinitionVariable with get, set

    type [<AllowNullLiteral>] SourceProviderAttributesSupportedCapabilities =
        [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> bool with get, set

    type [<AllowNullLiteral>] SupportedTriggerSupportedCapabilities =
        [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> SupportLevel with get, set
