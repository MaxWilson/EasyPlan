// ts2fable 0.7.1
module rec TaskAgent
open System
open Fable.Core
open Fable.Core.JS

type [<RequireQualifiedAccess>] AadLoginPromptOption =
    | NoOption = 0
    | Login = 1
    | SelectAccount = 2
    | FreshLogin = 3
    | FreshLoginWithMfa = 4

type [<AllowNullLiteral>] AadOauthTokenRequest =
    abstract refresh: bool with get, set
    abstract resource: string with get, set
    abstract tenantId: string with get, set
    abstract token: string with get, set

type [<AllowNullLiteral>] AadOauthTokenResult =
    abstract accessToken: string with get, set
    abstract refreshTokenCache: string with get, set

type [<AllowNullLiteral>] AgentChangeEvent =
    abstract agent: TaskAgent with get, set
    abstract eventType: string with get, set
    abstract pool: TaskAgentPoolReference with get, set
    abstract poolId: int with get, set
    abstract timeStamp: DateTime with get, set

type [<AllowNullLiteral>] AgentJobRequestMessage =
    inherit JobRequestMessage
    abstract lockedUntil: DateTime with get, set
    abstract lockToken: string with get, set
    abstract requestId: int with get, set
    abstract tasks: ResizeArray<TaskInstance> with get, set

type [<AllowNullLiteral>] AgentMigrationMessage =
    abstract accessToken: string with get, set

type [<AllowNullLiteral>] AgentPoolEvent =
    abstract eventType: string with get, set
    abstract pool: TaskAgentPool with get, set

type [<AllowNullLiteral>] AgentQueueEvent =
    abstract eventType: string with get, set
    abstract queue: TaskAgentQueue with get, set

type [<AllowNullLiteral>] AgentQueuesEvent =
    abstract eventType: string with get, set
    abstract queues: ResizeArray<TaskAgentQueue> with get, set

type [<AllowNullLiteral>] AgentRefreshMessage =
    abstract agentId: int with get, set
    abstract targetVersion: string with get, set
    abstract timeout: obj option with get, set

type [<RequireQualifiedAccess>] AuditAction =
    | Add = 1
    | Update = 2
    | Delete = 3
    | Undelete = 4

type [<AllowNullLiteral>] AuthenticationSchemeReference =
    abstract inputs: AuthenticationSchemeReferenceInputs with get, set
    abstract ``type``: string with get, set

type [<AllowNullLiteral>] AuthorizationHeader =
    /// Gets or sets the name of authorization header.
    abstract name: string with get, set
    /// Gets or sets the value of authorization header.
    abstract value: string with get, set

type [<AllowNullLiteral>] AzureKeyVaultPermission =
    inherit AzureResourcePermission
    abstract vault: string with get, set

type [<AllowNullLiteral>] AzureKeyVaultVariableGroupProviderData =
    inherit VariableGroupProviderData
    abstract lastRefreshedOn: DateTime with get, set
    abstract serviceEndpointId: string with get, set
    abstract vault: string with get, set

type [<AllowNullLiteral>] AzureKeyVaultVariableValue =
    inherit VariableValue
    abstract contentType: string with get, set
    abstract enabled: bool with get, set
    abstract expires: DateTime with get, set

/// Azure Management Group
type [<AllowNullLiteral>] AzureManagementGroup =
    /// Display name of azure management group
    abstract displayName: string with get, set
    /// Id of azure management group
    abstract id: string with get, set
    /// Azure management group name
    abstract name: string with get, set
    /// Id of tenant from which azure management group belongs
    abstract tenantId: string with get, set

/// Azure management group query result
type [<AllowNullLiteral>] AzureManagementGroupQueryResult =
    /// Error message in case of an exception
    abstract errorMessage: string with get, set
    /// List of azure management groups
    abstract value: ResizeArray<AzureManagementGroup> with get, set

type [<AllowNullLiteral>] AzurePermission =
    abstract provisioned: bool with get, set
    abstract resourceProvider: string with get, set

type [<AllowNullLiteral>] AzureResourcePermission =
    inherit AzurePermission
    abstract resourceGroup: string with get, set

type [<AllowNullLiteral>] AzureRoleAssignmentPermission =
    inherit AzurePermission
    abstract roleAssignmentId: string with get, set

type [<AllowNullLiteral>] AzureSpnOperationStatus =
    abstract state: string with get, set
    abstract statusMessage: string with get, set

type [<AllowNullLiteral>] AzureSubscription =
    abstract displayName: string with get, set
    abstract subscriptionId: string with get, set
    abstract subscriptionTenantId: string with get, set
    abstract subscriptionTenantName: string with get, set

type [<AllowNullLiteral>] AzureSubscriptionQueryResult =
    abstract errorMessage: string with get, set
    abstract value: ResizeArray<AzureSubscription> with get, set

type [<AllowNullLiteral>] ClientCertificate =
    /// Gets or sets the value of client certificate.
    abstract value: string with get, set

type [<AllowNullLiteral>] CounterVariable =
    abstract prefix: string with get, set
    abstract seed: int with get, set
    abstract value: int with get, set

type [<AllowNullLiteral>] DataSource =
    abstract authenticationScheme: AuthenticationSchemeReference with get, set
    abstract endpointUrl: string with get, set
    abstract headers: ResizeArray<AuthorizationHeader> with get, set
    abstract name: string with get, set
    abstract resourceUrl: string with get, set
    abstract resultSelector: string with get, set

type [<AllowNullLiteral>] DataSourceBinding =
    inherit DistributedTaskCommon.DataSourceBindingBase

type [<AllowNullLiteral>] DataSourceDetails =
    abstract dataSourceName: string with get, set
    abstract dataSourceUrl: string with get, set
    abstract headers: ResizeArray<AuthorizationHeader> with get, set
    abstract parameters: AuthenticationSchemeReferenceInputs with get, set
    abstract resourceUrl: string with get, set
    abstract resultSelector: string with get, set

type [<AllowNullLiteral>] Demand =
    abstract name: string with get, set
    abstract value: string with get, set

type [<AllowNullLiteral>] DemandEquals =
    inherit Demand

type [<AllowNullLiteral>] DemandExists =
    inherit Demand

type [<AllowNullLiteral>] DemandMinimumVersion =
    inherit Demand

type [<AllowNullLiteral>] DependencyBinding =
    abstract key: string with get, set
    abstract value: string with get, set

type [<AllowNullLiteral>] DependencyData =
    abstract input: string with get, set
    abstract map: ResizeArray<DependencyDataMap> with get, set

type [<AllowNullLiteral>] DependsOn =
    abstract input: string with get, set
    abstract map: ResizeArray<DependencyBinding> with get, set

type [<AllowNullLiteral>] DeploymentGatesChangeEvent =
    abstract gateNames: ResizeArray<string> with get, set

/// Deployment group.
type [<AllowNullLiteral>] DeploymentGroup =
    inherit DeploymentGroupReference
    /// Description of the deployment group.
    abstract description: string with get, set
    /// Number of deployment targets in the deployment group.
    abstract machineCount: int with get, set
    /// List of deployment targets in the deployment group.
    abstract machines: ResizeArray<DeploymentMachine> with get, set
    /// List of unique tags across all deployment targets in the deployment group.
    abstract machineTags: ResizeArray<string> with get, set

type [<RequireQualifiedAccess>] DeploymentGroupActionFilter =
    | None = 0
    | Manage = 2
    | Use = 16

/// Properties to create Deployment group.
type [<AllowNullLiteral>] DeploymentGroupCreateParameter =
    /// Description of the deployment group.
    abstract description: string with get, set
    /// Name of the deployment group.
    abstract name: string with get, set
    /// Deployment pool in which deployment agents are registered. This is obsolete. Kept for compatibility. Will be marked obsolete explicitly by M132.
    abstract pool: DeploymentGroupCreateParameterPoolProperty with get, set
    /// Identifier of the deployment pool in which deployment agents are registered.
    abstract poolId: int with get, set

/// Properties of Deployment pool to create Deployment group.
type [<AllowNullLiteral>] DeploymentGroupCreateParameterPoolProperty =
    /// Deployment pool identifier.
    abstract id: int with get, set

type [<RequireQualifiedAccess>] DeploymentGroupExpands =
    | None = 0
    | Machines = 2
    | Tags = 4

/// Deployment group metrics.
type [<AllowNullLiteral>] DeploymentGroupMetrics =
    /// List of deployment group properties. And types of metrics provided for those properties.
    abstract columnsHeader: MetricsColumnsHeader with get, set
    /// Deployment group.
    abstract deploymentGroup: DeploymentGroupReference with get, set
    /// Values of properties and the metrics. E.g. 1: total count of deployment targets for which 'TargetState' is 'offline'. E.g. 2: Average time of deployment to the deployment targets for which 'LastJobStatus' is 'passed' and 'TargetState' is 'online'.
    abstract rows: ResizeArray<MetricsRow> with get, set

/// Deployment group reference. This is useful for referring a deployment group in another object.
type [<AllowNullLiteral>] DeploymentGroupReference =
    /// Deployment group identifier.
    abstract id: int with get, set
    /// Name of the deployment group.
    abstract name: string with get, set
    /// Deployment pool in which deployment agents are registered.
    abstract pool: TaskAgentPoolReference with get, set
    /// Project to which the deployment group belongs.
    abstract project: ProjectReference with get, set

/// Deployment group update parameter.
type [<AllowNullLiteral>] DeploymentGroupUpdateParameter =
    /// Description of the deployment group.
    abstract description: string with get, set
    /// Name of the deployment group.
    abstract name: string with get, set

/// Deployment target.
type [<AllowNullLiteral>] DeploymentMachine =
    /// Deployment agent.
    abstract agent: TaskAgent with get, set
    /// Deployment target Identifier.
    abstract id: int with get, set
    /// Properties of the deployment target.
    abstract properties: obj option with get, set
    /// Tags of the deployment target.
    abstract tags: ResizeArray<string> with get, set

type [<AllowNullLiteral>] DeploymentMachineChangedData =
    inherit DeploymentMachine
    abstract addedTags: ResizeArray<string> with get, set
    abstract deletedTags: ResizeArray<string> with get, set

type [<RequireQualifiedAccess>] DeploymentMachineExpands =
    | None = 0
    | Capabilities = 2
    | AssignedRequest = 4

type [<AllowNullLiteral>] DeploymentMachineGroup =
    inherit DeploymentMachineGroupReference
    abstract machines: ResizeArray<DeploymentMachine> with get, set
    abstract size: int with get, set

type [<AllowNullLiteral>] DeploymentMachineGroupReference =
    abstract id: int with get, set
    abstract name: string with get, set
    abstract pool: TaskAgentPoolReference with get, set
    abstract project: ProjectReference with get, set

type [<AllowNullLiteral>] DeploymentMachinesChangeEvent =
    abstract machineGroupReference: DeploymentGroupReference with get, set
    abstract machines: ResizeArray<DeploymentMachineChangedData> with get, set

/// Deployment pool summary.
type [<AllowNullLiteral>] DeploymentPoolSummary =
    /// List of deployment groups referring to the deployment pool.
    abstract deploymentGroups: ResizeArray<DeploymentGroupReference> with get, set
    /// Number of deployment agents that are offline.
    abstract offlineAgentsCount: int with get, set
    /// Number of deployment agents that are online.
    abstract onlineAgentsCount: int with get, set
    /// Deployment pool.
    abstract pool: TaskAgentPoolReference with get, set
    /// Virtual machine Resource referring in pool.
    abstract resource: EnvironmentResourceReference with get, set

type [<RequireQualifiedAccess>] DeploymentPoolSummaryExpands =
    | None = 0
    | DeploymentGroups = 2
    | Resource = 4

type [<RequireQualifiedAccess>] DeploymentTargetExpands =
    | None = 0
    | Capabilities = 2
    | AssignedRequest = 4
    | LastCompletedRequest = 8

/// Deployment target update parameter.
type [<AllowNullLiteral>] DeploymentTargetUpdateParameter =
    /// Identifier of the deployment target.
    abstract id: int with get, set
    abstract tags: ResizeArray<string> with get, set

type [<AllowNullLiteral>] DiagnosticLogMetadata =
    abstract agentId: int with get, set
    abstract agentName: string with get, set
    abstract fileName: string with get, set
    abstract phaseName: string with get, set
    abstract phaseResult: string with get, set
    abstract poolId: int with get, set

type [<AllowNullLiteral>] EndpointAuthorization =
    /// Gets or sets the parameters for the selected authorization scheme.
    abstract parameters: AuthenticationSchemeReferenceInputs with get, set
    /// Gets or sets the scheme used for service endpoint authentication.
    abstract scheme: string with get, set

/// Represents url of the service endpoint.
type [<AllowNullLiteral>] EndpointUrl =
    /// Gets or sets the dependency bindings.
    abstract dependsOn: DependsOn with get, set
    /// Gets or sets the display name of service endpoint url.
    abstract displayName: string with get, set
    /// Gets or sets the help text of service endpoint url.
    abstract helpText: string with get, set
    /// Gets or sets the visibility of service endpoint url.
    abstract isVisible: string with get, set
    /// Gets or sets the value of service endpoint url.
    abstract value: string with get, set

type [<RequireQualifiedAccess>] EnvironmentActionFilter =
    | None = 0
    | Manage = 2
    | Use = 16

/// Properties to create Environment.
type [<AllowNullLiteral>] EnvironmentCreateParameter =
    /// Description of the environment.
    abstract description: string with get, set
    /// Name of the environment.
    abstract name: string with get, set

/// EnvironmentDeploymentExecutionRecord.
type [<AllowNullLiteral>] EnvironmentDeploymentExecutionRecord =
    /// Definition of the environment deployment execution owner
    abstract definition: TaskOrchestrationOwner with get, set
    /// Id of the Environment
    abstract environmentId: int with get, set
    /// Finish time of the environment deployment execution
    abstract finishTime: DateTime with get, set
    /// Id of the Environment deployment execution history record
    abstract id: int with get, set
    /// Job Attempt
    abstract jobAttempt: int with get, set
    /// Job name
    abstract jobName: string with get, set
    /// Owner of the environment deployment execution record
    abstract owner: TaskOrchestrationOwner with get, set
    /// Plan Id
    abstract planId: string with get, set
    /// Plan type of the environment deployment execution record
    abstract planType: string with get, set
    /// Queue time of the environment deployment execution
    abstract queueTime: DateTime with get, set
    /// Request identifier of the Environment deployment execution history record
    abstract requestIdentifier: string with get, set
    /// Resource Id
    abstract resourceId: int with get, set
    /// Result of the environment deployment execution
    abstract result: TaskResult with get, set
    /// Project Id
    abstract scopeId: string with get, set
    /// Service owner Id
    abstract serviceOwner: string with get, set
    /// Stage Attempt
    abstract stageAttempt: int with get, set
    /// Stage name
    abstract stageName: string with get, set
    /// Start time of the environment deployment execution
    abstract startTime: DateTime with get, set

type [<RequireQualifiedAccess>] EnvironmentExpands =
    | None = 0
    | ResourceReferences = 1

/// Environment.
type [<AllowNullLiteral>] EnvironmentInstance =
    /// Identity reference of the user who created the Environment.
    abstract createdBy: WebApi.IdentityRef with get, set
    /// Creation time of the Environment
    abstract createdOn: DateTime with get, set
    /// Description of the Environment.
    abstract description: string with get, set
    /// Id of the Environment
    abstract id: int with get, set
    /// Identity reference of the user who last modified the Environment.
    abstract lastModifiedBy: WebApi.IdentityRef with get, set
    /// Last modified time of the Environment
    abstract lastModifiedOn: DateTime with get, set
    /// Name of the Environment.
    abstract name: string with get, set
    /// Project information for environment.
    abstract project: ProjectReference with get, set
    abstract resources: ResizeArray<EnvironmentResourceReference> with get, set

/// EnvironmentLinkedResourceReference.
type [<AllowNullLiteral>] EnvironmentLinkedResourceReference =
    /// Id of the resource.
    abstract id: string with get, set
    /// Type of resource.
    abstract typeName: string with get, set

type [<AllowNullLiteral>] EnvironmentReference =
    abstract id: int with get, set
    abstract name: string with get, set

type [<AllowNullLiteral>] EnvironmentResource =
    abstract createdBy: WebApi.IdentityRef with get, set
    abstract createdOn: DateTime with get, set
    abstract environmentReference: EnvironmentReference with get, set
    abstract id: int with get, set
    abstract lastModifiedBy: WebApi.IdentityRef with get, set
    abstract lastModifiedOn: DateTime with get, set
    abstract name: string with get, set
    /// Tags of the Environment Resource.
    abstract tags: ResizeArray<string> with get, set
    /// Environment resource type
    abstract ``type``: EnvironmentResourceType with get, set

/// EnvironmentResourceReference.
type [<AllowNullLiteral>] EnvironmentResourceReference =
    /// Id of the resource.
    abstract id: int with get, set
    /// Name of the resource.
    abstract name: string with get, set
    /// Tags of the Environment Resource Reference.
    abstract tags: ResizeArray<string> with get, set
    /// Type of the resource.
    abstract ``type``: EnvironmentResourceType with get, set

type [<RequireQualifiedAccess>] EnvironmentResourceType =
    | Undefined = 0
    | Generic = 1
    | VirtualMachine = 2
    | Kubernetes = 4

/// Properties to update Environment.
type [<AllowNullLiteral>] EnvironmentUpdateParameter =
    /// Description of the environment.
    abstract description: string with get, set
    /// Name of the environment.
    abstract name: string with get, set

type [<AllowNullLiteral>] EventsConfig =
    interface end

type [<AllowNullLiteral>] ExpressionValidationItem =
    inherit ValidationItem

type [<AllowNullLiteral>] HelpLink =
    abstract text: string with get, set
    abstract url: string with get, set

type [<AllowNullLiteral>] InputBindingContext =
    /// Value of the input
    abstract value: string with get, set

type [<AllowNullLiteral>] InputValidationItem =
    inherit ValidationItem
    /// Provides binding context for the expression to evaluate
    abstract context: InputBindingContext with get, set

type [<AllowNullLiteral>] InputValidationRequest =
    abstract inputs: InputValidationRequestInputs with get, set

type [<AllowNullLiteral>] Issue =
    abstract category: string with get, set
    abstract data: AuthenticationSchemeReferenceInputs with get, set
    abstract message: string with get, set
    abstract ``type``: IssueType with get, set

type [<RequireQualifiedAccess>] IssueType =
    | Error = 1
    | Warning = 2

type [<AllowNullLiteral>] JobAssignedEvent =
    inherit JobEvent
    abstract request: TaskAgentJobRequest with get, set

type [<AllowNullLiteral>] JobCancelMessage =
    abstract jobId: string with get, set
    abstract timeout: obj option with get, set

type [<AllowNullLiteral>] JobCompletedEvent =
    inherit JobEvent
    abstract requestId: int with get, set
    abstract result: TaskResult with get, set

/// Represents the context of variables and vectors for a job request.
type [<AllowNullLiteral>] JobEnvironment =
    abstract endpoints: ResizeArray<ServiceEndpoint> with get, set
    abstract mask: ResizeArray<MaskHint> with get, set
    abstract options: JobEnvironmentOptions with get, set
    abstract secureFiles: ResizeArray<SecureFile> with get, set
    /// Gets or sets the endpoint used for communicating back to the calling service.
    abstract systemConnection: ServiceEndpoint with get, set
    abstract variables: AuthenticationSchemeReferenceInputs with get, set

type [<AllowNullLiteral>] JobEvent =
    abstract jobId: string with get, set
    abstract name: string with get, set

type [<AllowNullLiteral>] JobEventConfig =
    abstract timeout: string with get, set

type [<AllowNullLiteral>] JobEventsConfig =
    inherit EventsConfig
    abstract jobAssigned: JobEventConfig with get, set
    abstract jobCompleted: JobEventConfig with get, set
    abstract jobStarted: JobEventConfig with get, set

/// Represents an option that may affect the way an agent runs the job.
type [<AllowNullLiteral>] JobOption =
    abstract data: AuthenticationSchemeReferenceInputs with get, set
    /// Gets the id of the option.
    abstract id: string with get, set

type [<AllowNullLiteral>] JobRequestMessage =
    abstract environment: JobEnvironment with get, set
    abstract jobId: string with get, set
    abstract jobName: string with get, set
    abstract jobRefName: string with get, set
    abstract messageType: string with get, set
    abstract plan: TaskOrchestrationPlanReference with get, set
    abstract timeline: TimelineReference with get, set

type [<AllowNullLiteral>] JobStartedEvent =
    inherit JobEvent

type [<AllowNullLiteral>] KubernetesResource =
    inherit EnvironmentResource
    abstract clusterName: string with get, set
    abstract ``namespace``: string with get, set
    abstract serviceEndpointId: string with get, set

type [<AllowNullLiteral>] KubernetesResourceCreateParameters =
    abstract clusterName: string with get, set
    abstract name: string with get, set
    abstract ``namespace``: string with get, set
    abstract serviceEndpointId: string with get, set
    /// Tags of the kubernetes resource.
    abstract tags: ResizeArray<string> with get, set

type [<RequireQualifiedAccess>] MachineGroupActionFilter =
    | None = 0
    | Manage = 2
    | Use = 16

/// Represents a purchase of resource units in a secondary marketplace.
type [<AllowNullLiteral>] MarketplacePurchasedLicense =
    /// The Marketplace display name.
    abstract marketplaceName: string with get, set
    /// The name of the identity making the purchase as seen by the marketplace
    abstract purchaserName: string with get, set
    /// The quantity purchased.
    abstract purchaseUnitCount: int with get, set

type [<AllowNullLiteral>] MaskHint =
    abstract ``type``: MaskType with get, set
    abstract value: string with get, set

type [<RequireQualifiedAccess>] MaskType =
    | Variable = 1
    | Regex = 2

/// Meta data for a metrics column.
type [<AllowNullLiteral>] MetricsColumnMetaData =
    /// Name.
    abstract columnName: string with get, set
    /// Data type.
    abstract columnValueType: string with get, set

/// Metrics columns header
type [<AllowNullLiteral>] MetricsColumnsHeader =
    /// Properties of deployment group for which metrics are provided. E.g. 1: LastJobStatus E.g. 2: TargetState
    abstract dimensions: ResizeArray<MetricsColumnMetaData> with get, set
    /// The types of metrics. E.g. 1: total count of deployment targets. E.g. 2: Average time of deployment to the deployment targets.
    abstract metrics: ResizeArray<MetricsColumnMetaData> with get, set

/// Metrics row.
type [<AllowNullLiteral>] MetricsRow =
    /// The values of the properties mentioned as 'Dimensions' in column header. E.g. 1: For a property 'LastJobStatus' - metrics will be provided for 'passed', 'failed', etc. E.g. 2: For a property 'TargetState' - metrics will be provided for 'online', 'offline' targets.
    abstract dimensions: ResizeArray<string> with get, set
    /// Metrics in serialized format. Should be deserialized based on the data type provided in header.
    abstract metrics: ResizeArray<string> with get, set

/// Represents a downloadable package.
type [<AllowNullLiteral>] PackageMetadata =
    /// The date the package was created
    abstract createdOn: DateTime with get, set
    /// A direct link to download the package.
    abstract downloadUrl: string with get, set
    /// The UI uses this to display instructions, i.e. "unzip MyAgent.zip"
    abstract filename: string with get, set
    /// MD5 hash as a base64 string
    abstract hashValue: string with get, set
    /// A link to documentation
    abstract infoUrl: string with get, set
    /// The platform (win7, linux, etc.)
    abstract platform: string with get, set
    /// The type of package (e.g. "agent")
    abstract ``type``: string with get, set
    /// The package version.
    abstract version: PackageVersion with get, set

type [<AllowNullLiteral>] PackageVersion =
    abstract major: int with get, set
    abstract minor: int with get, set
    abstract patch: int with get, set

type [<AllowNullLiteral>] PlanEnvironment =
    abstract mask: ResizeArray<MaskHint> with get, set
    abstract options: JobEnvironmentOptions with get, set
    abstract variables: AuthenticationSchemeReferenceInputs with get, set

type [<RequireQualifiedAccess>] PlanGroupStatus =
    | Running = 1
    | Queued = 2
    | All = 3

type [<RequireQualifiedAccess>] PlanGroupStatusFilter =
    | Running = 1
    | Queued = 2
    | All = 3

type [<AllowNullLiteral>] ProjectReference =
    abstract id: string with get, set
    abstract name: string with get, set

type [<AllowNullLiteral>] PublishTaskGroupMetadata =
    abstract comment: string with get, set
    abstract parentDefinitionRevision: int with get, set
    abstract preview: bool with get, set
    abstract taskGroupId: string with get, set
    abstract taskGroupRevision: int with get, set

type [<AllowNullLiteral>] ResourceFilterOptions =
    abstract identities: ResizeArray<WebApi.IdentityRef> with get, set
    abstract resourceTypes: ResizeArray<string> with get, set

type [<AllowNullLiteral>] ResourceFilters =
    abstract createdBy: ResizeArray<string> with get, set
    abstract resourceType: ResizeArray<string> with get, set
    abstract searchText: string with get, set

/// Resources include Service Connections, Variable Groups and Secure Files.
type [<AllowNullLiteral>] ResourceItem =
    /// Gets or sets the identity who created the resource.
    abstract createdBy: WebApi.IdentityRef with get, set
    /// Gets or sets description of the resource.
    abstract description: string with get, set
    /// Gets or sets icon url of the resource.
    abstract iconUrl: string with get, set
    /// Gets or sets Id of the resource.
    abstract id: string with get, set
    /// Indicates whether resource is shared with other projects or not.
    abstract isShared: bool with get, set
    /// Gets or sets name of the resource.
    abstract name: string with get, set
    /// Gets or sets internal properties of the resource.
    abstract properties: AuthenticationSchemeReferenceInputs with get, set
    /// Gets or sets resource type.
    abstract resourceType: string with get, set

type [<AllowNullLiteral>] ResourceLimit =
    abstract failedToReachAllProviders: bool with get, set
    abstract hostId: string with get, set
    abstract isHosted: bool with get, set
    abstract isPremium: bool with get, set
    abstract parallelismTag: string with get, set
    abstract resourceLimitsData: AuthenticationSchemeReferenceInputs with get, set
    abstract totalCount: int with get, set
    abstract totalMinutes: int with get, set

type [<AllowNullLiteral>] ResourcesHubData =
    abstract continuationToken: string with get, set
    abstract resourceFilterOptions: ResourceFilterOptions with get, set
    abstract resourceFilters: ResourceFilters with get, set
    abstract resourceItems: ResizeArray<ResourceItem> with get, set

type [<AllowNullLiteral>] ResourceUsage =
    abstract resourceLimit: ResourceLimit with get, set
    abstract runningRequests: ResizeArray<TaskAgentJobRequest> with get, set
    abstract usedCount: int with get, set
    abstract usedMinutes: int with get, set

type [<AllowNullLiteral>] ResultTransformationDetails =
    abstract resultTemplate: string with get, set

type [<AllowNullLiteral>] SecureFile =
    abstract createdBy: WebApi.IdentityRef with get, set
    abstract createdOn: DateTime with get, set
    abstract id: string with get, set
    abstract modifiedBy: WebApi.IdentityRef with get, set
    abstract modifiedOn: DateTime with get, set
    abstract name: string with get, set
    abstract properties: AuthenticationSchemeReferenceInputs with get, set
    abstract ticket: string with get, set

type [<RequireQualifiedAccess>] SecureFileActionFilter =
    | None = 0
    | Manage = 2
    | Use = 16

type [<AllowNullLiteral>] SecureFileEvent =
    abstract eventType: string with get, set
    abstract projectId: string with get, set
    abstract secureFiles: ResizeArray<SecureFile> with get, set

type [<AllowNullLiteral>] SendJobResponse =
    abstract events: JobEventsConfig with get, set
    abstract variables: AuthenticationSchemeReferenceInputs with get, set

type [<AllowNullLiteral>] ServerExecutionDefinition =
    abstract events: EventsConfig with get, set
    abstract handlerName: string with get, set

type [<AllowNullLiteral>] ServerTaskRequestMessage =
    inherit JobRequestMessage
    abstract taskDefinition: TaskDefinition with get, set
    abstract taskInstance: TaskInstance with get, set

/// Represents an endpoint which may be used by an orchestration job.
type [<AllowNullLiteral>] ServiceEndpoint =
    /// Gets or sets the identity reference for the administrators group of the service endpoint.
    abstract administratorsGroup: WebApi.IdentityRef with get, set
    /// Gets or sets the authorization data for talking to the endpoint.
    abstract authorization: EndpointAuthorization with get, set
    /// Gets or sets the identity reference for the user who created the Service endpoint.
    abstract createdBy: WebApi.IdentityRef with get, set
    abstract data: AuthenticationSchemeReferenceInputs with get, set
    /// Gets or sets the description of endpoint.
    abstract description: string with get, set
    abstract groupScopeId: string with get, set
    /// Gets or sets the identifier of this endpoint.
    abstract id: string with get, set
    /// EndPoint state indicator
    abstract isReady: bool with get, set
    /// Indicates whether service endpoint is shared with other projects or not.
    abstract isShared: bool with get, set
    /// Gets or sets the friendly name of the endpoint.
    abstract name: string with get, set
    /// Error message during creation/deletion of endpoint
    abstract operationStatus: obj option with get, set
    /// Gets or sets the owner of the endpoint.
    abstract owner: string with get, set
    /// Gets or sets the identity reference for the readers group of the service endpoint.
    abstract readersGroup: WebApi.IdentityRef with get, set
    /// Gets or sets the type of the endpoint.
    abstract ``type``: string with get, set
    /// Gets or sets the url of the endpoint.
    abstract url: string with get, set

type [<AllowNullLiteral>] ServiceEndpointAuthenticationScheme =
    /// Gets or sets the authorization headers of service endpoint authentication scheme.
    abstract authorizationHeaders: ResizeArray<AuthorizationHeader> with get, set
    /// Gets or sets the certificates of service endpoint authentication scheme.
    abstract clientCertificates: ResizeArray<ClientCertificate> with get, set
    /// Gets or sets the display name for the service endpoint authentication scheme.
    abstract displayName: string with get, set
    /// Gets or sets the input descriptors for the service endpoint authentication scheme.
    abstract inputDescriptors: ResizeArray<FormInput.InputDescriptor> with get, set
    /// Gets or sets the scheme for service endpoint authentication.
    abstract scheme: string with get, set

type [<AllowNullLiteral>] ServiceEndpointDetails =
    abstract authorization: EndpointAuthorization with get, set
    abstract data: AuthenticationSchemeReferenceInputs with get, set
    abstract ``type``: string with get, set
    abstract url: string with get, set

/// Represents service endpoint execution data.
type [<AllowNullLiteral>] ServiceEndpointExecutionData =
    /// Gets the definition of service endpoint execution owner.
    abstract definition: TaskOrchestrationOwner with get, set
    /// Gets the finish time of service endpoint execution.
    abstract finishTime: DateTime with get, set
    /// Gets the Id of service endpoint execution data.
    abstract id: int with get, set
    /// Gets the owner of service endpoint execution data.
    abstract owner: TaskOrchestrationOwner with get, set
    /// Gets the plan type of service endpoint execution data.
    abstract planType: string with get, set
    /// Gets the result of service endpoint execution.
    abstract result: TaskResult with get, set
    /// Gets the start time of service endpoint execution.
    abstract startTime: DateTime with get, set

type [<AllowNullLiteral>] ServiceEndpointExecutionRecord =
    /// Gets the execution data of service endpoint execution.
    abstract data: ServiceEndpointExecutionData with get, set
    /// Gets the Id of service endpoint.
    abstract endpointId: string with get, set

type [<AllowNullLiteral>] ServiceEndpointExecutionRecordsInput =
    abstract data: ServiceEndpointExecutionData with get, set
    abstract endpointIds: ResizeArray<string> with get, set

type [<AllowNullLiteral>] ServiceEndpointRequest =
    abstract dataSourceDetails: DataSourceDetails with get, set
    abstract resultTransformationDetails: ResultTransformationDetails with get, set
    abstract serviceEndpointDetails: ServiceEndpointDetails with get, set

type [<AllowNullLiteral>] ServiceEndpointRequestResult =
    abstract errorMessage: string with get, set
    abstract result: obj option with get, set
    abstract statusCode: string with get, set

/// Represents type of the service endpoint.
type [<AllowNullLiteral>] ServiceEndpointType =
    /// Authentication scheme of service endpoint type.
    abstract authenticationSchemes: ResizeArray<ServiceEndpointAuthenticationScheme> with get, set
    /// Data sources of service endpoint type.
    abstract dataSources: ResizeArray<DataSource> with get, set
    /// Dependency data of service endpoint type.
    abstract dependencyData: ResizeArray<DependencyData> with get, set
    /// Gets or sets the description of service endpoint type.
    abstract description: string with get, set
    /// Gets or sets the display name of service endpoint type.
    abstract displayName: string with get, set
    /// Gets or sets the endpoint url of service endpoint type.
    abstract endpointUrl: EndpointUrl with get, set
    /// Gets or sets the help link of service endpoint type.
    abstract helpLink: HelpLink with get, set
    abstract helpMarkDown: string with get, set
    /// Gets or sets the icon url of service endpoint type.
    abstract iconUrl: string with get, set
    /// Input descriptor of service endpoint type.
    abstract inputDescriptors: ResizeArray<FormInput.InputDescriptor> with get, set
    /// Gets or sets the name of service endpoint type.
    abstract name: string with get, set
    /// Trusted hosts of a service endpoint type.
    abstract trustedHosts: ResizeArray<string> with get, set
    /// Gets or sets the ui contribution id of service endpoint type.
    abstract uiContributionId: string with get, set

/// A task agent.
type [<AllowNullLiteral>] TaskAgent =
    inherit TaskAgentReference
    /// The agent cloud request that's currently associated with this agent.
    abstract assignedAgentCloudRequest: TaskAgentCloudRequest with get, set
    /// The request which is currently assigned to this agent.
    abstract assignedRequest: TaskAgentJobRequest with get, set
    /// Authorization information for this agent.
    abstract authorization: TaskAgentAuthorization with get, set
    /// Date on which this agent was created.
    abstract createdOn: DateTime with get, set
    /// The last request which was completed by this agent.
    abstract lastCompletedRequest: TaskAgentJobRequest with get, set
    /// Maximum job parallelism allowed for this agent.
    abstract maxParallelism: int with get, set
    /// Pending update for this agent.
    abstract pendingUpdate: TaskAgentUpdate with get, set
    abstract properties: obj option with get, set
    /// Date on which the last connectivity status change occurred.
    abstract statusChangedOn: DateTime with get, set
    abstract systemCapabilities: AuthenticationSchemeReferenceInputs with get, set
    abstract userCapabilities: AuthenticationSchemeReferenceInputs with get, set

/// Provides data necessary for authorizing the agent using OAuth 2.0 authentication flows.
type [<AllowNullLiteral>] TaskAgentAuthorization =
    /// Endpoint used to obtain access tokens from the configured token service.
    abstract authorizationUrl: string with get, set
    /// Client identifier for this agent.
    abstract clientId: string with get, set
    /// Public key used to verify the identity of this agent.
    abstract publicKey: TaskAgentPublicKey with get, set

type [<AllowNullLiteral>] TaskAgentCloud =
    /// Gets or sets a AcquireAgentEndpoint using which a request can be made to acquire new agent
    abstract acquireAgentEndpoint: string with get, set
    abstract acquisitionTimeout: int with get, set
    abstract agentCloudId: int with get, set
    abstract getAccountParallelismEndpoint: string with get, set
    abstract getAgentDefinitionEndpoint: string with get, set
    abstract getAgentRequestStatusEndpoint: string with get, set
    abstract id: string with get, set
    /// Signifies that this Agent Cloud is internal and should not be user-manageable
    abstract ``internal``: bool with get, set
    abstract maxParallelism: int with get, set
    abstract name: string with get, set
    abstract releaseAgentEndpoint: string with get, set
    abstract sharedSecret: string with get, set
    /// Gets or sets the type of the endpoint.
    abstract ``type``: string with get, set

type [<AllowNullLiteral>] TaskAgentCloudRequest =
    abstract agent: TaskAgentReference with get, set
    abstract agentCloudId: int with get, set
    abstract agentConnectedTime: DateTime with get, set
    abstract agentData: obj option with get, set
    abstract agentSpecification: obj option with get, set
    abstract pool: TaskAgentPoolReference with get, set
    abstract provisionedTime: DateTime with get, set
    abstract provisionRequestTime: DateTime with get, set
    abstract releaseRequestTime: DateTime with get, set
    abstract requestId: string with get, set

type [<AllowNullLiteral>] TaskAgentCloudType =
    /// Gets or sets the display name of agent cloud type.
    abstract displayName: string with get, set
    /// Gets or sets the input descriptors
    abstract inputDescriptors: ResizeArray<FormInput.InputDescriptor> with get, set
    /// Gets or sets the name of agent cloud type.
    abstract name: string with get, set

type [<AllowNullLiteral>] TaskAgentDelaySource =
    abstract delays: ResizeArray<obj option> with get, set
    abstract taskAgent: TaskAgentReference with get, set

type [<AllowNullLiteral>] TaskAgentJob =
    abstract container: string with get, set
    abstract id: string with get, set
    abstract name: string with get, set
    abstract sidecarContainers: AuthenticationSchemeReferenceInputs with get, set
    abstract steps: ResizeArray<TaskAgentJobStep> with get, set
    abstract variables: ResizeArray<TaskAgentJobVariable> with get, set

/// A job request for an agent.
type [<AllowNullLiteral>] TaskAgentJobRequest =
    abstract agentDelays: ResizeArray<TaskAgentDelaySource> with get, set
    abstract agentSpecification: obj option with get, set
    /// The date/time this request was assigned.
    abstract assignTime: DateTime with get, set
    /// Additional data about the request.
    abstract data: AuthenticationSchemeReferenceInputs with get, set
    /// The pipeline definition associated with this request
    abstract definition: TaskOrchestrationOwner with get, set
    /// A list of demands required to fulfill this request.
    abstract demands: ResizeArray<Demand> with get, set
    abstract expectedDuration: obj option with get, set
    /// The date/time this request was finished.
    abstract finishTime: DateTime with get, set
    /// The host which triggered this request.
    abstract hostId: string with get, set
    /// ID of the job resulting from this request.
    abstract jobId: string with get, set
    /// Name of the job resulting from this request.
    abstract jobName: string with get, set
    /// The deadline for the agent to renew the lock.
    abstract lockedUntil: DateTime with get, set
    abstract matchedAgents: ResizeArray<TaskAgentReference> with get, set
    abstract matchesAllAgentsInPool: bool with get, set
    abstract orchestrationId: string with get, set
    /// The pipeline associated with this request
    abstract owner: TaskOrchestrationOwner with get, set
    abstract planGroup: string with get, set
    /// Internal ID for the orchestration plan connected with this request.
    abstract planId: string with get, set
    /// Internal detail representing the type of orchestration plan.
    abstract planType: string with get, set
    /// The ID of the pool this request targets
    abstract poolId: int with get, set
    /// The ID of the queue this request targets
    abstract queueId: int with get, set
    /// The date/time this request was queued.
    abstract queueTime: DateTime with get, set
    /// The date/time this request was receieved by an agent.
    abstract receiveTime: DateTime with get, set
    /// ID of the request.
    abstract requestId: int with get, set
    /// The agent allocated for this request.
    abstract reservedAgent: TaskAgentReference with get, set
    /// The result of this request.
    abstract result: TaskResult with get, set
    /// Scope of the pipeline; matches the project ID.
    abstract scopeId: string with get, set
    /// The service which owns this request.
    abstract serviceOwner: string with get, set
    abstract statusMessage: string with get, set
    abstract userDelayed: bool with get, set

type [<RequireQualifiedAccess>] TaskAgentJobResultFilter =
    | Failed = 1
    | Passed = 2
    | NeverDeployed = 4
    | All = 7

type [<AllowNullLiteral>] TaskAgentJobStep =
    abstract condition: string with get, set
    abstract continueOnError: bool with get, set
    abstract enabled: bool with get, set
    abstract env: AuthenticationSchemeReferenceInputs with get, set
    abstract id: string with get, set
    abstract inputs: AuthenticationSchemeReferenceInputs with get, set
    abstract name: string with get, set
    abstract task: TaskAgentJobTask with get, set
    abstract timeoutInMinutes: int with get, set
    abstract ``type``: TaskAgentJobStepType with get, set

type [<RequireQualifiedAccess>] TaskAgentJobStepType =
    | Task = 1
    | Action = 2

type [<AllowNullLiteral>] TaskAgentJobTask =
    abstract id: string with get, set
    abstract name: string with get, set
    abstract version: string with get, set

type [<AllowNullLiteral>] TaskAgentJobVariable =
    abstract name: string with get, set
    abstract secret: bool with get, set
    abstract value: string with get, set

type [<AllowNullLiteral>] TaskAgentManualUpdate =
    inherit TaskAgentUpdateReason

/// Provides a contract for receiving messages from the task orchestrator.
type [<AllowNullLiteral>] TaskAgentMessage =
    /// Gets or sets the body of the message. If the \<c\>IV\</c\> property is provided the body will need to be decrypted using the \<c\>TaskAgentSession.EncryptionKey\</c\> value in addition to the \<c\>IV\</c\>.
    abstract body: string with get, set
    /// Gets or sets the initialization vector used to encrypt this message.
    abstract iv: ResizeArray<float> with get, set
    /// Gets or sets the message identifier.
    abstract messageId: int with get, set
    /// Gets or sets the message type, describing the data contract found in \<c\>TaskAgentMessage.Body\</c\>.
    abstract messageType: string with get, set

type [<AllowNullLiteral>] TaskAgentMinAgentVersionRequiredUpdate =
    inherit TaskAgentUpdateReason
    abstract jobDefinition: TaskOrchestrationOwner with get, set
    abstract jobOwner: TaskOrchestrationOwner with get, set
    abstract minAgentVersion: Demand with get, set

/// An organization-level grouping of agents.
type [<AllowNullLiteral>] TaskAgentPool =
    inherit TaskAgentPoolReference
    /// The ID of the associated agent cloud.
    abstract agentCloudId: int with get, set
    /// Whether or not a queue should be automatically provisioned for each project collection.
    abstract autoProvision: bool with get, set
    /// Whether or not the pool should autosize itself based on the Agent Cloud Provider settings.
    abstract autoSize: bool with get, set
    /// Creator of the pool. The creator of the pool is automatically added into the administrators group for the pool on creation.
    abstract createdBy: WebApi.IdentityRef with get, set
    /// The date/time of the pool creation.
    abstract createdOn: DateTime with get, set
    /// Owner or administrator of the pool.
    abstract owner: WebApi.IdentityRef with get, set
    abstract properties: obj option with get, set
    /// Target parallelism.
    abstract targetSize: int with get, set

type [<RequireQualifiedAccess>] TaskAgentPoolActionFilter =
    | None = 0
    | Manage = 2
    | Use = 16

type [<AllowNullLiteral>] TaskAgentPoolMaintenanceDefinition =
    /// Enable maintenance
    abstract enabled: bool with get, set
    /// Id
    abstract id: int with get, set
    /// Maintenance job timeout per agent
    abstract jobTimeoutInMinutes: int with get, set
    /// Max percentage of agents within a pool running maintenance job at given time
    abstract maxConcurrentAgentsPercentage: int with get, set
    abstract options: TaskAgentPoolMaintenanceOptions with get, set
    /// Pool reference for the maintenance definition
    abstract pool: TaskAgentPoolReference with get, set
    abstract retentionPolicy: TaskAgentPoolMaintenanceRetentionPolicy with get, set
    abstract scheduleSetting: TaskAgentPoolMaintenanceSchedule with get, set

type [<AllowNullLiteral>] TaskAgentPoolMaintenanceJob =
    /// The maintenance definition for the maintenance job
    abstract definitionId: int with get, set
    /// The total error counts during the maintenance job
    abstract errorCount: int with get, set
    /// Time that the maintenance job was completed
    abstract finishTime: DateTime with get, set
    /// Id of the maintenance job
    abstract jobId: int with get, set
    /// The log download url for the maintenance job
    abstract logsDownloadUrl: string with get, set
    /// Orchestration/Plan Id for the maintenance job
    abstract orchestrationId: string with get, set
    /// Pool reference for the maintenance job
    abstract pool: TaskAgentPoolReference with get, set
    /// Time that the maintenance job was queued
    abstract queueTime: DateTime with get, set
    /// The identity that queued the maintenance job
    abstract requestedBy: WebApi.IdentityRef with get, set
    /// The maintenance job result
    abstract result: TaskAgentPoolMaintenanceJobResult with get, set
    /// Time that the maintenance job was started
    abstract startTime: DateTime with get, set
    /// Status of the maintenance job
    abstract status: TaskAgentPoolMaintenanceJobStatus with get, set
    abstract targetAgents: ResizeArray<TaskAgentPoolMaintenanceJobTargetAgent> with get, set
    /// The total warning counts during the maintenance job
    abstract warningCount: int with get, set

type [<RequireQualifiedAccess>] TaskAgentPoolMaintenanceJobResult =
    | Succeeded = 1
    | Failed = 2
    | Canceled = 4

type [<RequireQualifiedAccess>] TaskAgentPoolMaintenanceJobStatus =
    | InProgress = 1
    | Completed = 2
    | Cancelling = 4
    | Queued = 8

type [<AllowNullLiteral>] TaskAgentPoolMaintenanceJobTargetAgent =
    abstract agent: TaskAgentReference with get, set
    abstract jobId: int with get, set
    abstract result: TaskAgentPoolMaintenanceJobResult with get, set
    abstract status: TaskAgentPoolMaintenanceJobStatus with get, set

type [<AllowNullLiteral>] TaskAgentPoolMaintenanceOptions =
    /// time to consider a System.DefaultWorkingDirectory is stale
    abstract workingDirectoryExpirationInDays: int with get, set

type [<AllowNullLiteral>] TaskAgentPoolMaintenanceRetentionPolicy =
    /// Number of records to keep for maintenance job executed with this definition.
    abstract numberOfHistoryRecordsToKeep: int with get, set

type [<AllowNullLiteral>] TaskAgentPoolMaintenanceSchedule =
    /// Days for a build (flags enum for days of the week)
    abstract daysToBuild: TaskAgentPoolMaintenanceScheduleDays with get, set
    /// The Job Id of the Scheduled job that will queue the pool maintenance job.
    abstract scheduleJobId: string with get, set
    /// Local timezone hour to start
    abstract startHours: int with get, set
    /// Local timezone minute to start
    abstract startMinutes: int with get, set
    /// Time zone of the build schedule (string representation of the time zone id)
    abstract timeZoneId: string with get, set

type [<RequireQualifiedAccess>] TaskAgentPoolMaintenanceScheduleDays =
    | None = 0
    | Monday = 1
    | Tuesday = 2
    | Wednesday = 4
    | Thursday = 8
    | Friday = 16
    | Saturday = 32
    | Sunday = 64
    | All = 127

type [<AllowNullLiteral>] TaskAgentPoolReference =
    abstract id: int with get, set
    /// Gets or sets a value indicating whether or not this pool is managed by the service.
    abstract isHosted: bool with get, set
    /// Determines whether the pool is legacy.
    abstract isLegacy: bool with get, set
    abstract name: string with get, set
    /// Gets or sets the type of the pool
    abstract poolType: TaskAgentPoolType with get, set
    abstract scope: string with get, set
    /// Gets the current size of the pool.
    abstract size: int with get, set

type [<AllowNullLiteral>] TaskAgentPoolStatus =
    inherit TaskAgentPoolReference
    /// Number of requests queued and assigned to an agent. Not running yet.
    abstract assignedRequestCount: int with get, set
    /// Number of queued requests which are not assigned to any agents
    abstract queuedRequestCount: int with get, set
    /// Number of currently running requests
    abstract runningRequestCount: int with get, set

type [<AllowNullLiteral>] TaskAgentPoolSummary =
    abstract columnsHeader: MetricsColumnsHeader with get, set
    abstract deploymentGroups: ResizeArray<DeploymentGroupReference> with get, set
    abstract pool: TaskAgentPoolReference with get, set
    abstract queues: ResizeArray<TaskAgentQueue> with get, set
    abstract rows: ResizeArray<MetricsRow> with get, set

type [<RequireQualifiedAccess>] TaskAgentPoolType =
    | Automation = 1
    | Deployment = 2

/// Represents the public key portion of an RSA asymmetric key.
type [<AllowNullLiteral>] TaskAgentPublicKey =
    /// Gets or sets the exponent for the public key.
    abstract exponent: ResizeArray<float> with get, set
    /// Gets or sets the modulus for the public key.
    abstract modulus: ResizeArray<float> with get, set

/// An agent queue.
type [<AllowNullLiteral>] TaskAgentQueue =
    /// ID of the queue
    abstract id: int with get, set
    /// Name of the queue
    abstract name: string with get, set
    /// Pool reference for this queue
    abstract pool: TaskAgentPoolReference with get, set
    /// Project ID
    abstract projectId: string with get, set

type [<RequireQualifiedAccess>] TaskAgentQueueActionFilter =
    | None = 0
    | Manage = 2
    | Use = 16

/// A reference to an agent.
type [<AllowNullLiteral>] TaskAgentReference =
    abstract _links: obj option with get, set
    /// This agent's access point.
    abstract accessPoint: string with get, set
    /// Whether or not this agent should run jobs.
    abstract enabled: bool with get, set
    /// Identifier of the agent.
    abstract id: int with get, set
    /// Name of the agent.
    abstract name: string with get, set
    /// Agent OS.
    abstract osDescription: string with get, set
    /// Provisioning state of this agent.
    abstract provisioningState: string with get, set
    /// Whether or not the agent is online.
    abstract status: TaskAgentStatus with get, set
    /// Agent version.
    abstract version: string with get, set

/// Represents a session for performing message exchanges from an agent.
type [<AllowNullLiteral>] TaskAgentSession =
    /// Gets or sets the agent which is the target of the session.
    abstract agent: TaskAgentReference with get, set
    /// Gets the key used to encrypt message traffic for this session.
    abstract encryptionKey: TaskAgentSessionKey with get, set
    /// Gets or sets the owner name of this session. Generally this will be the machine of origination.
    abstract ownerName: string with get, set
    /// Gets the unique identifier for this session.
    abstract sessionId: string with get, set
    abstract systemCapabilities: AuthenticationSchemeReferenceInputs with get, set

/// Represents a symmetric key used for message-level encryption for communication sent to an agent.
type [<AllowNullLiteral>] TaskAgentSessionKey =
    /// Gets or sets a value indicating whether or not the key value is encrypted. If this value is true, the Value property should be decrypted using the \<c\>RSA\</c\> key exchanged with the server during registration.
    abstract encrypted: bool with get, set
    /// Gets or sets the symmetric key value.
    abstract value: ResizeArray<float> with get, set

type [<RequireQualifiedAccess>] TaskAgentStatus =
    | Offline = 1
    | Online = 2

type [<RequireQualifiedAccess>] TaskAgentStatusFilter =
    | Offline = 1
    | Online = 2
    | All = 3

/// Details about an agent update.
type [<AllowNullLiteral>] TaskAgentUpdate =
    /// Current state of this agent update.
    abstract currentState: string with get, set
    /// Reason for this update.
    abstract reason: TaskAgentUpdateReason with get, set
    /// Identity which requested this update.
    abstract requestedBy: WebApi.IdentityRef with get, set
    /// Date on which this update was requested.
    abstract requestTime: DateTime with get, set
    /// Source agent version of the update.
    abstract sourceVersion: PackageVersion with get, set
    /// Target agent version of the update.
    abstract targetVersion: PackageVersion with get, set

type [<AllowNullLiteral>] TaskAgentUpdateReason =
    abstract code: TaskAgentUpdateReasonType with get, set

type [<RequireQualifiedAccess>] TaskAgentUpdateReasonType =
    | Manual = 1
    | MinAgentVersionRequired = 2

type [<AllowNullLiteral>] TaskAssignedEvent =
    inherit TaskEvent

type [<AllowNullLiteral>] TaskAttachment =
    abstract _links: obj option with get, set
    abstract createdOn: DateTime with get, set
    abstract lastChangedBy: string with get, set
    abstract lastChangedOn: DateTime with get, set
    abstract name: string with get, set
    abstract recordId: string with get, set
    abstract timelineId: string with get, set
    abstract ``type``: string with get, set

type [<AllowNullLiteral>] TaskCompletedEvent =
    inherit TaskEvent
    abstract result: TaskResult with get, set

type [<AllowNullLiteral>] TaskDefinition =
    abstract agentExecution: TaskExecution with get, set
    abstract author: string with get, set
    abstract category: string with get, set
    abstract contentsUploaded: bool with get, set
    abstract contributionIdentifier: string with get, set
    abstract contributionVersion: string with get, set
    abstract dataSourceBindings: ResizeArray<DataSourceBinding> with get, set
    abstract definitionType: string with get, set
    abstract demands: ResizeArray<Demand> with get, set
    abstract deprecated: bool with get, set
    abstract description: string with get, set
    abstract disabled: bool with get, set
    abstract ecosystem: string with get, set
    abstract execution: TaskDefinitionExecution with get, set
    abstract friendlyName: string with get, set
    abstract groups: ResizeArray<TaskGroupDefinition> with get, set
    abstract helpMarkDown: string with get, set
    abstract helpUrl: string with get, set
    abstract hostType: string with get, set
    abstract iconUrl: string with get, set
    abstract id: string with get, set
    abstract inputs: ResizeArray<TaskInputDefinition> with get, set
    abstract instanceNameFormat: string with get, set
    abstract minimumAgentVersion: string with get, set
    abstract name: string with get, set
    abstract outputVariables: ResizeArray<TaskOutputVariable> with get, set
    abstract packageLocation: string with get, set
    abstract packageType: string with get, set
    abstract postJobExecution: TaskDefinitionExecution with get, set
    abstract preJobExecution: TaskDefinitionExecution with get, set
    abstract preview: bool with get, set
    abstract releaseNotes: string with get, set
    abstract runsOn: ResizeArray<string> with get, set
    abstract satisfies: ResizeArray<string> with get, set
    abstract serverOwned: bool with get, set
    abstract showEnvironmentVariables: bool with get, set
    abstract sourceDefinitions: ResizeArray<TaskSourceDefinition> with get, set
    abstract sourceLocation: string with get, set
    abstract version: TaskVersion with get, set
    abstract visibility: ResizeArray<string> with get, set

type [<AllowNullLiteral>] TaskDefinitionEndpoint =
    /// An ID that identifies a service connection to be used for authenticating endpoint requests.
    abstract connectionId: string with get, set
    /// An Json based keyselector to filter response returned by fetching the endpoint \<c\>Url\</c\>.A Json based keyselector must be prefixed with "jsonpath:". KeySelector can be used to specify the filter to get the keys for the values specified with Selector. \<example\> The following keyselector defines an Json for extracting nodes named 'ServiceName'. \<code\> endpoint.KeySelector = "jsonpath://ServiceName"; \</code\>\</example\>
    abstract keySelector: string with get, set
    /// The scope as understood by Connected Services. Essentially, a project-id for now.
    abstract scope: string with get, set
    /// An XPath/Json based selector to filter response returned by fetching the endpoint \<c\>Url\</c\>. An XPath based selector must be prefixed with the string "xpath:". A Json based selector must be prefixed with "jsonpath:". \<example\> The following selector defines an XPath for extracting nodes named 'ServiceName'. \<code\> endpoint.Selector = "xpath://ServiceName"; \</code\>\</example\>
    abstract selector: string with get, set
    /// TaskId that this endpoint belongs to.
    abstract taskId: string with get, set
    /// URL to GET.
    abstract url: string with get, set

type [<AllowNullLiteral>] TaskDefinitionReference =
    /// Gets or sets the definition type. Values can be 'task' or 'metaTask'.
    abstract definitionType: string with get, set
    /// Gets or sets the unique identifier of task.
    abstract id: string with get, set
    /// Gets or sets the version specification of task.
    abstract versionSpec: string with get, set

type [<RequireQualifiedAccess>] TaskDefinitionStatus =
    | Preinstalled = 1
    | ReceivedInstallOrUpdate = 2
    | Installed = 3
    | ReceivedUninstall = 4
    | Uninstalled = 5
    | RequestedUpdate = 6
    | Updated = 7
    | AlreadyUpToDate = 8
    | InlineUpdateReceived = 9

type [<AllowNullLiteral>] TaskEvent =
    inherit JobEvent
    abstract taskId: string with get, set

type [<AllowNullLiteral>] TaskExecution =
    /// The utility task to run.  Specifying this means that this task definition is simply a meta task to call another task. This is useful for tasks that call utility tasks like powershell and commandline
    abstract execTask: TaskReference with get, set
    /// If a task is going to run code, then this provides the type/script etc... information by platform. For example, it might look like. net45: \{ typeName: "Microsoft.TeamFoundation.Automation.Tasks.PowerShellTask", assemblyName: "Microsoft.TeamFoundation.Automation.Tasks.PowerShell.dll" \} net20: \{ typeName: "Microsoft.TeamFoundation.Automation.Tasks.PowerShellTask", assemblyName: "Microsoft.TeamFoundation.Automation.Tasks.PowerShell.dll" \} java: \{ jar: "powershelltask.tasks.automation.teamfoundation.microsoft.com", \} node: \{ script: "powershellhost.js", \}
    abstract platformInstructions: TaskExecutionPlatformInstructions with get, set

type [<AllowNullLiteral>] TaskGroup =
    inherit TaskDefinition
    /// Gets or sets comment.
    abstract comment: string with get, set
    /// Gets or sets the identity who created.
    abstract createdBy: WebApi.IdentityRef with get, set
    /// Gets or sets date on which it got created.
    abstract createdOn: DateTime with get, set
    /// Gets or sets as 'true' to indicate as deleted, 'false' otherwise.
    abstract deleted: bool with get, set
    /// Gets or sets the identity who modified.
    abstract modifiedBy: WebApi.IdentityRef with get, set
    /// Gets or sets date on which it got modified.
    abstract modifiedOn: DateTime with get, set
    /// Gets or sets the owner.
    abstract owner: string with get, set
    /// Gets or sets parent task group Id. This is used while creating a draft task group.
    abstract parentDefinitionId: string with get, set
    /// Gets or sets revision.
    abstract revision: int with get, set
    /// Gets or sets the tasks.
    abstract tasks: ResizeArray<TaskGroupStep> with get, set

type [<AllowNullLiteral>] TaskGroupCreateParameter =
    /// Sets author name of the task group.
    abstract author: string with get, set
    /// Sets category of the task group.
    abstract category: string with get, set
    /// Sets description of the task group.
    abstract description: string with get, set
    /// Sets friendly name of the task group.
    abstract friendlyName: string with get, set
    /// Sets url icon of the task group.
    abstract iconUrl: string with get, set
    /// Sets input for the task group.
    abstract inputs: ResizeArray<TaskInputDefinition> with get, set
    /// Sets display name of the task group.
    abstract instanceNameFormat: string with get, set
    /// Sets name of the task group.
    abstract name: string with get, set
    /// Sets parent task group Id. This is used while creating a draft task group.
    abstract parentDefinitionId: string with get, set
    /// Sets RunsOn of the task group. Value can be 'Agent', 'Server' or 'DeploymentGroup'.
    abstract runsOn: ResizeArray<string> with get, set
    /// Sets tasks for the task group.
    abstract tasks: ResizeArray<TaskGroupStep> with get, set
    /// Sets version of the task group.
    abstract version: TaskVersion with get, set

type [<AllowNullLiteral>] TaskGroupDefinition =
    abstract displayName: string with get, set
    abstract isExpanded: bool with get, set
    abstract name: string with get, set
    abstract tags: ResizeArray<string> with get, set
    abstract visibleRule: string with get, set

type [<RequireQualifiedAccess>] TaskGroupExpands =
    | None = 0
    | Tasks = 2

type [<AllowNullLiteral>] TaskGroupPublishPreviewParameter =
    inherit TaskGroupUpdatePropertiesBase
    /// This is to disable previous versions of task group upon publish
    abstract disablePriorVersions: bool with get, set
    /// Denotes if task group is in preview
    abstract preview: bool with get, set
    /// This is the revision of task group that is getting published
    abstract revision: int with get, set
    /// This is the version of task group that is getting published
    abstract version: TaskVersion with get, set

type [<RequireQualifiedAccess>] TaskGroupQueryOrder =
    | CreatedOnAscending = 0
    | CreatedOnDescending = 1

type [<AllowNullLiteral>] TaskGroupRestoreParameter =
    inherit TaskGroupUpdatePropertiesBase
    /// This is to restore deleted Task Group
    abstract restore: bool with get, set

type [<AllowNullLiteral>] TaskGroupRevision =
    abstract changedBy: WebApi.IdentityRef with get, set
    abstract changedDate: DateTime with get, set
    abstract changeType: AuditAction with get, set
    abstract comment: string with get, set
    abstract fileId: int with get, set
    abstract majorVersion: int with get, set
    abstract revision: int with get, set
    abstract taskGroupId: string with get, set

/// Represents tasks in the task group.
type [<AllowNullLiteral>] TaskGroupStep =
    /// Gets or sets as 'true' to run the task always, 'false' otherwise.
    abstract alwaysRun: bool with get, set
    /// Gets or sets condition for the task.
    abstract condition: string with get, set
    /// Gets or sets as 'true' to continue on error, 'false' otherwise.
    abstract continueOnError: bool with get, set
    /// Gets or sets the display name.
    abstract displayName: string with get, set
    /// Gets or sets as task is enabled or not.
    abstract enabled: bool with get, set
    /// Gets dictionary of environment variables.
    abstract environment: AuthenticationSchemeReferenceInputs with get, set
    /// Gets or sets dictionary of inputs.
    abstract inputs: AuthenticationSchemeReferenceInputs with get, set
    /// Gets or sets the reference of the task.
    abstract task: TaskDefinitionReference with get, set
    /// Gets or sets the maximum time, in minutes, that a task is allowed to execute on agent before being cancelled by server. A zero value indicates an infinite timeout.
    abstract timeoutInMinutes: int with get, set

type [<AllowNullLiteral>] TaskGroupUpdateParameter =
    /// Sets author name of the task group.
    abstract author: string with get, set
    /// Sets category of the task group.
    abstract category: string with get, set
    /// Sets comment of the task group.
    abstract comment: string with get, set
    /// Sets description of the task group.
    abstract description: string with get, set
    /// Sets friendly name of the task group.
    abstract friendlyName: string with get, set
    /// Sets url icon of the task group.
    abstract iconUrl: string with get, set
    /// Sets the unique identifier of this field.
    abstract id: string with get, set
    /// Sets input for the task group.
    abstract inputs: ResizeArray<TaskInputDefinition> with get, set
    /// Sets display name of the task group.
    abstract instanceNameFormat: string with get, set
    /// Sets name of the task group.
    abstract name: string with get, set
    /// Gets or sets parent task group Id. This is used while creating a draft task group.
    abstract parentDefinitionId: string with get, set
    /// Sets revision of the task group.
    abstract revision: int with get, set
    /// Sets RunsOn of the task group. Value can be 'Agent', 'Server' or 'DeploymentGroup'.
    abstract runsOn: ResizeArray<string> with get, set
    /// Sets tasks for the task group.
    abstract tasks: ResizeArray<TaskGroupStep> with get, set
    /// Sets version of the task group.
    abstract version: TaskVersion with get, set

type [<AllowNullLiteral>] TaskGroupUpdatePropertiesBase =
    /// Comment for this update request
    abstract comment: string with get, set

type [<AllowNullLiteral>] TaskHubLicenseDetails =
    abstract enterpriseUsersCount: int with get, set
    abstract failedToReachAllProviders: bool with get, set
    abstract freeHostedLicenseCount: int with get, set
    abstract freeLicenseCount: int with get, set
    abstract hasLicenseCountEverUpdated: bool with get, set
    abstract hostedAgentMinutesFreeCount: int with get, set
    abstract hostedAgentMinutesUsedCount: int with get, set
    abstract hostedLicensesArePremium: bool with get, set
    abstract marketplacePurchasedHostedLicenses: ResizeArray<MarketplacePurchasedLicense> with get, set
    abstract msdnUsersCount: int with get, set
    /// Microsoft-hosted licenses purchased from VSTS directly.
    abstract purchasedHostedLicenseCount: int with get, set
    /// Self-hosted licenses purchased from VSTS directly.
    abstract purchasedLicenseCount: int with get, set
    abstract totalHostedLicenseCount: int with get, set
    abstract totalLicenseCount: int with get, set
    abstract totalPrivateLicenseCount: int with get, set

type [<AllowNullLiteral>] TaskInputDefinition =
    inherit DistributedTaskCommon.TaskInputDefinitionBase

type [<AllowNullLiteral>] TaskInstance =
    inherit TaskReference
    abstract alwaysRun: bool with get, set
    abstract condition: string with get, set
    abstract continueOnError: bool with get, set
    abstract displayName: string with get, set
    abstract enabled: bool with get, set
    abstract environment: AuthenticationSchemeReferenceInputs with get, set
    abstract instanceId: string with get, set
    abstract refName: string with get, set
    abstract timeoutInMinutes: int with get, set

type [<AllowNullLiteral>] TaskLog =
    inherit TaskLogReference
    abstract createdOn: DateTime with get, set
    abstract indexLocation: string with get, set
    abstract lastChangedOn: DateTime with get, set
    abstract lineCount: int with get, set
    abstract path: string with get, set

type [<AllowNullLiteral>] TaskLogReference =
    abstract id: int with get, set
    abstract location: string with get, set

type [<AllowNullLiteral>] TaskOrchestrationContainer =
    inherit TaskOrchestrationItem
    abstract children: ResizeArray<TaskOrchestrationItem> with get, set
    abstract continueOnError: bool with get, set
    abstract data: AuthenticationSchemeReferenceInputs with get, set
    abstract maxConcurrency: int with get, set
    abstract ``parallel``: bool with get, set
    abstract rollback: TaskOrchestrationContainer with get, set

type [<AllowNullLiteral>] TaskOrchestrationItem =
    abstract itemType: TaskOrchestrationItemType with get, set

type [<RequireQualifiedAccess>] TaskOrchestrationItemType =
    | Container = 0
    | Job = 1

type [<AllowNullLiteral>] TaskOrchestrationJob =
    inherit TaskOrchestrationItem
    abstract demands: ResizeArray<Demand> with get, set
    abstract executeAs: WebApi.IdentityRef with get, set
    abstract executionMode: string with get, set
    abstract executionTimeout: obj option with get, set
    abstract instanceId: string with get, set
    abstract name: string with get, set
    abstract refName: string with get, set
    abstract tasks: ResizeArray<TaskInstance> with get, set
    abstract variables: AuthenticationSchemeReferenceInputs with get, set

type [<AllowNullLiteral>] TaskOrchestrationOwner =
    abstract _links: obj option with get, set
    abstract id: int with get, set
    abstract name: string with get, set

type [<AllowNullLiteral>] TaskOrchestrationPlan =
    inherit TaskOrchestrationPlanReference
    abstract environment: PlanEnvironment with get, set
    abstract finishTime: DateTime with get, set
    abstract implementation: TaskOrchestrationContainer with get, set
    abstract initializationLog: TaskLogReference with get, set
    abstract requestedById: string with get, set
    abstract requestedForId: string with get, set
    abstract result: TaskResult with get, set
    abstract resultCode: string with get, set
    abstract startTime: DateTime with get, set
    abstract state: TaskOrchestrationPlanState with get, set
    abstract timeline: TimelineReference with get, set

type [<AllowNullLiteral>] TaskOrchestrationPlanGroup =
    abstract planGroup: string with get, set
    abstract project: ProjectReference with get, set
    abstract runningRequests: ResizeArray<TaskAgentJobRequest> with get, set

type [<AllowNullLiteral>] TaskOrchestrationPlanGroupsQueueMetrics =
    abstract count: int with get, set
    abstract status: PlanGroupStatus with get, set

type [<AllowNullLiteral>] TaskOrchestrationPlanReference =
    abstract artifactLocation: string with get, set
    abstract artifactUri: string with get, set
    abstract definition: TaskOrchestrationOwner with get, set
    abstract owner: TaskOrchestrationOwner with get, set
    abstract planGroup: string with get, set
    abstract planId: string with get, set
    abstract planType: string with get, set
    abstract scopeIdentifier: string with get, set
    abstract version: int with get, set

type [<RequireQualifiedAccess>] TaskOrchestrationPlanState =
    | InProgress = 1
    | Queued = 2
    | Completed = 4
    | Throttled = 8

type [<AllowNullLiteral>] TaskOrchestrationQueuedPlan =
    abstract assignTime: DateTime with get, set
    abstract definition: TaskOrchestrationOwner with get, set
    abstract owner: TaskOrchestrationOwner with get, set
    abstract planGroup: string with get, set
    abstract planId: string with get, set
    abstract poolId: int with get, set
    abstract queuePosition: int with get, set
    abstract queueTime: DateTime with get, set
    abstract scopeIdentifier: string with get, set

type [<AllowNullLiteral>] TaskOrchestrationQueuedPlanGroup =
    abstract definition: TaskOrchestrationOwner with get, set
    abstract owner: TaskOrchestrationOwner with get, set
    abstract planGroup: string with get, set
    abstract plans: ResizeArray<TaskOrchestrationQueuedPlan> with get, set
    abstract project: ProjectReference with get, set
    abstract queuePosition: int with get, set

type [<AllowNullLiteral>] TaskOutputVariable =
    abstract description: string with get, set
    abstract name: string with get, set

type [<AllowNullLiteral>] TaskPackageMetadata =
    /// Gets the name of the package.
    abstract ``type``: string with get, set
    /// Gets the url of the package.
    abstract url: string with get, set
    /// Gets the version of the package.
    abstract version: string with get, set

type [<AllowNullLiteral>] TaskReference =
    abstract id: string with get, set
    abstract inputs: AuthenticationSchemeReferenceInputs with get, set
    abstract name: string with get, set
    abstract version: string with get, set

type [<RequireQualifiedAccess>] TaskResult =
    | Succeeded = 0
    | SucceededWithIssues = 1
    | Failed = 2
    | Canceled = 3
    | Skipped = 4
    | Abandoned = 5

type [<AllowNullLiteral>] TaskSourceDefinition =
    inherit DistributedTaskCommon.TaskSourceDefinitionBase

type [<AllowNullLiteral>] TaskStartedEvent =
    inherit TaskEvent

type [<AllowNullLiteral>] TaskVersion =
    abstract isTest: bool with get, set
    abstract major: int with get, set
    abstract minor: int with get, set
    abstract patch: int with get, set

type [<AllowNullLiteral>] Timeline =
    inherit TimelineReference
    abstract lastChangedBy: string with get, set
    abstract lastChangedOn: DateTime with get, set
    abstract records: ResizeArray<TimelineRecord> with get, set

type [<AllowNullLiteral>] TimelineAttempt =
    /// Gets or sets the attempt of the record.
    abstract attempt: int with get, set
    /// Gets or sets the unique identifier for the record.
    abstract identifier: string with get, set
    /// Gets or sets the record identifier located within the specified timeline.
    abstract recordId: string with get, set
    /// Gets or sets the timeline identifier which owns the record representing this attempt.
    abstract timelineId: string with get, set

type [<AllowNullLiteral>] TimelineRecord =
    abstract agentSpecification: obj option with get, set
    abstract attempt: int with get, set
    abstract changeId: int with get, set
    abstract currentOperation: string with get, set
    abstract details: TimelineReference with get, set
    abstract errorCount: int with get, set
    abstract finishTime: DateTime with get, set
    abstract id: string with get, set
    abstract identifier: string with get, set
    abstract issues: ResizeArray<Issue> with get, set
    abstract lastModified: DateTime with get, set
    abstract location: string with get, set
    abstract log: TaskLogReference with get, set
    abstract name: string with get, set
    abstract order: int with get, set
    abstract parentId: string with get, set
    abstract percentComplete: int with get, set
    abstract previousAttempts: ResizeArray<TimelineAttempt> with get, set
    abstract queueId: int with get, set
    abstract refName: string with get, set
    abstract result: TaskResult with get, set
    abstract resultCode: string with get, set
    abstract startTime: DateTime with get, set
    abstract state: TimelineRecordState with get, set
    abstract task: TaskReference with get, set
    abstract ``type``: string with get, set
    abstract variables: TimelineRecordVariables with get, set
    abstract warningCount: int with get, set
    abstract workerName: string with get, set

type [<AllowNullLiteral>] TimelineRecordFeedLinesWrapper =
    abstract count: int with get, set
    abstract endLine: int with get, set
    abstract startLine: int with get, set
    abstract stepId: string with get, set
    abstract value: ResizeArray<string> with get, set

type [<RequireQualifiedAccess>] TimelineRecordState =
    | Pending = 0
    | InProgress = 1
    | Completed = 2

type [<AllowNullLiteral>] TimelineReference =
    abstract changeId: int with get, set
    abstract id: string with get, set
    abstract location: string with get, set

type [<AllowNullLiteral>] ValidationItem =
    /// Tells whether the current input is valid or not
    abstract isValid: bool with get, set
    /// Reason for input validation failure
    abstract reason: string with get, set
    /// Type of validation item
    abstract ``type``: string with get, set
    /// Value to validate. The conditional expression to validate for the input for "expression" type Eg:eq(variables['Build.SourceBranch'], 'refs/heads/master');eq(value, 'refs/heads/master')
    abstract value: string with get, set

/// A variable group is a collection of related variables.
type [<AllowNullLiteral>] VariableGroup =
    /// Gets or sets the identity who created the variable group.
    abstract createdBy: WebApi.IdentityRef with get, set
    /// Gets or sets the time when variable group was created.
    abstract createdOn: DateTime with get, set
    /// Gets or sets description of the variable group.
    abstract description: string with get, set
    /// Gets or sets id of the variable group.
    abstract id: int with get, set
    /// Indicates whether variable group is shared with other projects or not.
    abstract isShared: bool with get, set
    /// Gets or sets the identity who modified the variable group.
    abstract modifiedBy: WebApi.IdentityRef with get, set
    /// Gets or sets the time when variable group was modified
    abstract modifiedOn: DateTime with get, set
    /// Gets or sets name of the variable group.
    abstract name: string with get, set
    /// Gets or sets provider data.
    abstract providerData: VariableGroupProviderData with get, set
    /// Gets or sets type of the variable group.
    abstract ``type``: string with get, set
    /// all project references where the variable group is shared with other projects.
    abstract variableGroupProjectReferences: ResizeArray<VariableGroupProjectReference> with get, set
    /// Gets or sets variables contained in the variable group.
    abstract variables: TimelineRecordVariables with get, set

type [<RequireQualifiedAccess>] VariableGroupActionFilter =
    | None = 0
    | Manage = 2
    | Use = 16

type [<AllowNullLiteral>] VariableGroupParameters =
    /// Sets description of the variable group.
    abstract description: string with get, set
    /// Sets name of the variable group.
    abstract name: string with get, set
    /// Sets provider data.
    abstract providerData: VariableGroupProviderData with get, set
    /// Sets type of the variable group.
    abstract ``type``: string with get, set
    abstract variableGroupProjectReferences: ResizeArray<VariableGroupProjectReference> with get, set
    /// Sets variables contained in the variable group.
    abstract variables: TimelineRecordVariables with get, set

/// A variable group reference is a shallow reference to variable group.
type [<AllowNullLiteral>] VariableGroupProjectReference =
    /// Gets or sets description of the variable group.
    abstract description: string with get, set
    /// Gets or sets name of the variable group.
    abstract name: string with get, set
    /// Gets or sets project reference of the variable group.
    abstract projectReference: ProjectReference with get, set

/// Defines provider data of the variable group.
type [<AllowNullLiteral>] VariableGroupProviderData =
    interface end

type [<RequireQualifiedAccess>] VariableGroupQueryOrder =
    | IdAscending = 0
    | IdDescending = 1

type [<AllowNullLiteral>] VariableValue =
    abstract isSecret: bool with get, set
    abstract value: string with get, set

type [<AllowNullLiteral>] VirtualMachine =
    abstract agent: TaskAgent with get, set
    abstract id: int with get, set
    abstract tags: ResizeArray<string> with get, set

type [<AllowNullLiteral>] VirtualMachineGroup =
    inherit EnvironmentResource
    abstract poolId: int with get, set

type [<AllowNullLiteral>] VirtualMachineGroupCreateParameters =
    abstract name: string with get, set

type [<AllowNullLiteral>] VirtualMachineResource =
    inherit EnvironmentResource
    abstract agent: TaskAgent with get, set

type [<AllowNullLiteral>] VirtualMachineResourceCreateParameters =
    abstract name: string with get, set

type [<AllowNullLiteral>] AuthenticationSchemeReferenceInputs =
    [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> string with get, set

type [<AllowNullLiteral>] DependencyDataMapValue =
    abstract key: string with get, set
    abstract value: string with get, set

type [<AllowNullLiteral>] DependencyDataMap =
    abstract key: string with get, set
    abstract value: ResizeArray<DependencyDataMapValue> with get, set

type [<AllowNullLiteral>] InputValidationRequestInputs =
    [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> ValidationItem with get, set

type [<AllowNullLiteral>] JobEnvironmentOptions =
    [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> JobOption with get, set

type [<AllowNullLiteral>] TaskDefinitionExecution =
    [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

type [<AllowNullLiteral>] TaskExecutionPlatformInstructions =
    [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> AuthenticationSchemeReferenceInputs with get, set

type [<AllowNullLiteral>] TimelineRecordVariables =
    [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> VariableValue with get, set
