// ts2fable 0.7.1
module rec TaskAgentClient
open System
open Fable.Core
open Fable.Core.JS

type IVssRestClientOptions = Context.IVssRestClientOptions
type RestClientBase = RestClientBase.RestClientBase

type [<AllowNullLiteral>] IExports =
    abstract TaskAgentRestClient: TaskAgentRestClientStatic

type [<AllowNullLiteral>] TaskAgentRestClient =
    inherit RestClientBase
    /// <param name="agentCloud">-</param>
    abstract addAgentCloud: agentCloud: TaskAgent.TaskAgentCloud -> Promise<TaskAgent.TaskAgentCloud>
    /// <param name="agentCloudId">-</param>
    abstract deleteAgentCloud: agentCloudId: int -> Promise<TaskAgent.TaskAgentCloud>
    /// <param name="agentCloudId">-</param>
    abstract getAgentCloud: agentCloudId: int -> Promise<TaskAgent.TaskAgentCloud>
    abstract getAgentClouds: unit -> Promise<ResizeArray<TaskAgent.TaskAgentCloud>>
    /// Get agent cloud types.
    abstract getAgentCloudTypes: unit -> Promise<ResizeArray<TaskAgent.TaskAgentCloudType>>
    /// <param name="queueId">-</param>
    /// <param name="top">-</param>
    /// <param name="continuationToken">-</param>
    abstract getAgentRequestsForQueue: queueId: int * top: int * ?continuationToken: string -> Promise<ResizeArray<TaskAgent.TaskAgentJobRequest>>
    /// <param name="request">-</param>
    /// <param name="queueId">-</param>
    abstract queueAgentRequest: request: TaskAgent.TaskAgentJobRequest * queueId: int -> Promise<TaskAgent.TaskAgentJobRequest>
    /// <summary>Adds an agent to a pool.  You probably don't want to call this endpoint directly. Instead, [configure an agent](https://docs.microsoft.com/azure/devops/pipelines/agents/agents) using the agent download package.</summary>
    /// <param name="agent">- Details about the agent being added</param>
    /// <param name="poolId">- The agent pool in which to add the agent</param>
    abstract addAgent: agent: TaskAgent.TaskAgent * poolId: int -> Promise<TaskAgent.TaskAgent>
    /// <summary>Delete an agent.  You probably don't want to call this endpoint directly. Instead, [use the agent configuration script](https://docs.microsoft.com/azure/devops/pipelines/agents/agents) to remove an agent from your organization.</summary>
    /// <param name="poolId">- The pool ID to remove the agent from</param>
    /// <param name="agentId">- The agent ID to remove</param>
    abstract deleteAgent: poolId: int * agentId: int -> Promise<unit>
    /// <summary>Get information about an agent.</summary>
    /// <param name="poolId">- The agent pool containing the agent</param>
    /// <param name="agentId">- The agent ID to get information about</param>
    /// <param name="includeCapabilities">- Whether to include the agent's capabilities in the response</param>
    /// <param name="includeAssignedRequest">- Whether to include details about the agent's current work</param>
    /// <param name="includeLastCompletedRequest">- Whether to include details about the agents' most recent completed work</param>
    /// <param name="propertyFilters">- Filter which custom properties will be returned</param>
    abstract getAgent: poolId: int * agentId: int * ?includeCapabilities: bool * ?includeAssignedRequest: bool * ?includeLastCompletedRequest: bool * ?propertyFilters: ResizeArray<string> -> Promise<TaskAgent.TaskAgent>
    /// <summary>Get a list of agents.</summary>
    /// <param name="poolId">- The agent pool containing the agents</param>
    /// <param name="agentName">- Filter on agent name</param>
    /// <param name="includeCapabilities">- Whether to include the agents' capabilities in the response</param>
    /// <param name="includeAssignedRequest">- Whether to include details about the agents' current work</param>
    /// <param name="includeLastCompletedRequest">- Whether to include details about the agents' most recent completed work</param>
    /// <param name="propertyFilters">- Filter which custom properties will be returned</param>
    /// <param name="demands">- Filter by demands the agents can satisfy</param>
    abstract getAgents: poolId: int * ?agentName: string * ?includeCapabilities: bool * ?includeAssignedRequest: bool * ?includeLastCompletedRequest: bool * ?propertyFilters: ResizeArray<string> * ?demands: ResizeArray<string> -> Promise<ResizeArray<TaskAgent.TaskAgent>>
    /// <summary>Replace an agent.  You probably don't want to call this endpoint directly. Instead, [use the agent configuration script](https://docs.microsoft.com/azure/devops/pipelines/agents/agents) to remove and reconfigure an agent from your organization.</summary>
    /// <param name="agent">- Updated details about the replacing agent</param>
    /// <param name="poolId">- The agent pool to use</param>
    /// <param name="agentId">- The agent to replace</param>
    abstract replaceAgent: agent: TaskAgent.TaskAgent * poolId: int * agentId: int -> Promise<TaskAgent.TaskAgent>
    /// <summary>Update agent details.</summary>
    /// <param name="agent">- Updated details about the agent</param>
    /// <param name="poolId">- The agent pool to use</param>
    /// <param name="agentId">- The agent to update</param>
    abstract updateAgent: agent: TaskAgent.TaskAgent * poolId: int * agentId: int -> Promise<TaskAgent.TaskAgent>
    /// Returns list of azure subscriptions
    abstract getAzureManagementGroups: unit -> Promise<TaskAgent.AzureManagementGroupQueryResult>
    /// Returns list of azure subscriptions
    abstract getAzureSubscriptions: unit -> Promise<TaskAgent.AzureSubscriptionQueryResult>
    /// <summary>GET a PAT token for managing (configuring, removing, tagging) deployment targets in a deployment group.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="deploymentGroupId">- ID of the deployment group in which deployment targets are managed.</param>
    abstract generateDeploymentGroupAccessToken: project: string * deploymentGroupId: int -> Promise<string>
    /// <summary>Create a deployment group.</summary>
    /// <param name="deploymentGroup">- Deployment group to create.</param>
    /// <param name="project">- Project ID or project name</param>
    abstract addDeploymentGroup: deploymentGroup: TaskAgent.DeploymentGroupCreateParameter * project: string -> Promise<TaskAgent.DeploymentGroup>
    /// <summary>Delete a deployment group.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="deploymentGroupId">- ID of the deployment group to be deleted.</param>
    abstract deleteDeploymentGroup: project: string * deploymentGroupId: int -> Promise<unit>
    /// <summary>Get a deployment group by its ID.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="deploymentGroupId">- ID of the deployment group.</param>
    /// <param name="actionFilter">- Get the deployment group only if this action can be performed on it.</param>
    /// <param name="expand">- Include these additional details in the returned object.</param>
    abstract getDeploymentGroup: project: string * deploymentGroupId: int * ?actionFilter: TaskAgent.DeploymentGroupActionFilter * ?expand: TaskAgent.DeploymentGroupExpands -> Promise<TaskAgent.DeploymentGroup>
    /// <summary>Get a list of deployment groups by name or IDs.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="name">- Name of the deployment group.</param>
    /// <param name="actionFilter">- Get only deployment groups on which this action can be performed.</param>
    /// <param name="expand">- Include these additional details in the returned objects.</param>
    /// <param name="continuationToken">- Get deployment groups with names greater than this continuationToken lexicographically.</param>
    /// <param name="top">- Maximum number of deployment groups to return. Default is **1000**.</param>
    /// <param name="ids">- Comma separated list of IDs of the deployment groups.</param>
    abstract getDeploymentGroups: project: string * ?name: string * ?actionFilter: TaskAgent.DeploymentGroupActionFilter * ?expand: TaskAgent.DeploymentGroupExpands * ?continuationToken: string * ?top: int * ?ids: ResizeArray<float> -> Promise<ResizeArray<TaskAgent.DeploymentGroup>>
    /// <summary>Update a deployment group.</summary>
    /// <param name="deploymentGroup">- Deployment group to update.</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="deploymentGroupId">- ID of the deployment group.</param>
    abstract updateDeploymentGroup: deploymentGroup: TaskAgent.DeploymentGroupUpdateParameter * project: string * deploymentGroupId: int -> Promise<TaskAgent.DeploymentGroup>
    /// <summary>Get a list of deployment group metrics.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="deploymentGroupName">- Name of the deployment group.</param>
    /// <param name="continuationToken">- Get metrics for deployment groups with names greater than this continuationToken lexicographically.</param>
    /// <param name="top">- Maximum number of deployment group metrics to return. Default is **50**.</param>
    abstract getDeploymentGroupsMetrics: project: string * ?deploymentGroupName: string * ?continuationToken: string * ?top: int -> Promise<ResizeArray<TaskAgent.DeploymentGroupMetrics>>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="deploymentGroupId">-</param>
    /// <param name="machineId">-</param>
    /// <param name="completedRequestCount">-</param>
    abstract getAgentRequestsForDeploymentMachine: project: string * deploymentGroupId: int * machineId: int * ?completedRequestCount: int -> Promise<ResizeArray<TaskAgent.TaskAgentJobRequest>>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="deploymentGroupId">-</param>
    /// <param name="machineIds">-</param>
    /// <param name="completedRequestCount">-</param>
    abstract getAgentRequestsForDeploymentMachines: project: string * deploymentGroupId: int * ?machineIds: ResizeArray<float> * ?completedRequestCount: int -> Promise<ResizeArray<TaskAgent.TaskAgentJobRequest>>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="deploymentGroupId">-</param>
    abstract refreshDeploymentMachines: project: string * deploymentGroupId: int -> Promise<unit>
    /// <summary>GET a PAT token for managing (configuring, removing, tagging) deployment agents in a deployment pool.</summary>
    /// <param name="poolId">- ID of the deployment pool in which deployment agents are managed.</param>
    abstract generateDeploymentPoolAccessToken: poolId: int -> Promise<string>
    /// <summary>Get a list of deployment pool summaries.</summary>
    /// <param name="poolName">- Name of the deployment pool.</param>
    /// <param name="expands">- Include these additional details in the returned objects.</param>
    /// <param name="poolIds">- List of deployment pool ids.</param>
    abstract getDeploymentPoolsSummary: ?poolName: string * ?expands: TaskAgent.DeploymentPoolSummaryExpands * ?poolIds: ResizeArray<float> -> Promise<ResizeArray<TaskAgent.DeploymentPoolSummary>>
    /// <summary>Get agent requests for a deployment target.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="deploymentGroupId">- ID of the deployment group to which the target belongs.</param>
    /// <param name="targetId">- ID of the deployment target.</param>
    /// <param name="completedRequestCount">- Maximum number of completed requests to return. Default is **50**</param>
    abstract getAgentRequestsForDeploymentTarget: project: string * deploymentGroupId: int * targetId: int * ?completedRequestCount: int -> Promise<ResizeArray<TaskAgent.TaskAgentJobRequest>>
    /// <summary>Get agent requests for a list deployment targets.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="deploymentGroupId">- ID of the deployment group to which the targets belong.</param>
    /// <param name="targetIds">- Comma separated list of IDs of the deployment targets.</param>
    /// <param name="ownerId">- Id of owner of agent job request.</param>
    /// <param name="completedOn">- Datetime to return request after this time.</param>
    /// <param name="completedRequestCount">- Maximum number of completed requests to return for each target. Default is **50**</param>
    abstract getAgentRequestsForDeploymentTargets: project: string * deploymentGroupId: int * ?targetIds: ResizeArray<float> * ?ownerId: int * ?completedOn: DateTime * ?completedRequestCount: int -> Promise<ResizeArray<TaskAgent.TaskAgentJobRequest>>
    /// <summary>Upgrade the deployment targets in a deployment group.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="deploymentGroupId">- ID of the deployment group.</param>
    abstract refreshDeploymentTargets: project: string * deploymentGroupId: int -> Promise<unit>
    /// <summary>Proxy for a GET request defined by an 'endpoint'. The request is authorized using a service connection. The response is filtered using an XPath/Json based selector.</summary>
    /// <param name="endpoint">- Describes the URL to fetch.</param>
    abstract queryEndpoint: endpoint: TaskAgent.TaskDefinitionEndpoint -> Promise<ResizeArray<string>>
    /// <summary>Get environment deployment execution history</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="environmentId">-</param>
    /// <param name="continuationToken">-</param>
    /// <param name="top">-</param>
    abstract getEnvironmentDeploymentExecutionRecords: project: string * environmentId: int * ?continuationToken: string * ?top: int -> Promise<ResizeArray<TaskAgent.EnvironmentDeploymentExecutionRecord>>
    /// <summary>Create an environment.</summary>
    /// <param name="environmentCreateParameter">- Environment to create.</param>
    /// <param name="project">- Project ID or project name</param>
    abstract addEnvironment: environmentCreateParameter: TaskAgent.EnvironmentCreateParameter * project: string -> Promise<TaskAgent.EnvironmentInstance>
    /// <summary>Delete the specified environment.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="environmentId">- ID of the environment.</param>
    abstract deleteEnvironment: project: string * environmentId: int -> Promise<unit>
    /// <summary>Get an environment by its ID.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="environmentId">- ID of the environment.</param>
    /// <param name="expands">- Include these additional details in the returned objects.</param>
    abstract getEnvironmentById: project: string * environmentId: int * ?expands: TaskAgent.EnvironmentExpands -> Promise<TaskAgent.EnvironmentInstance>
    /// <summary>Get all environments.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="name">-</param>
    /// <param name="continuationToken">-</param>
    /// <param name="top">-</param>
    abstract getEnvironments: project: string * ?name: string * ?continuationToken: string * ?top: int -> Promise<ResizeArray<TaskAgent.EnvironmentInstance>>
    /// <summary>Update the specified environment.</summary>
    /// <param name="environmentUpdateParameter">- Environment data to update.</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="environmentId">- ID of the environment.</param>
    abstract updateEnvironment: environmentUpdateParameter: TaskAgent.EnvironmentUpdateParameter * project: string * environmentId: int -> Promise<TaskAgent.EnvironmentInstance>
    /// <param name="hubName">-</param>
    /// <param name="includeEnterpriseUsersCount">-</param>
    /// <param name="includeHostedAgentMinutesCount">-</param>
    abstract getTaskHubLicenseDetails: hubName: string * ?includeEnterpriseUsersCount: bool * ?includeHostedAgentMinutesCount: bool -> Promise<TaskAgent.TaskHubLicenseDetails>
    /// <param name="taskHubLicenseDetails">-</param>
    /// <param name="hubName">-</param>
    abstract updateTaskHubLicenseDetails: taskHubLicenseDetails: TaskAgent.TaskHubLicenseDetails * hubName: string -> Promise<TaskAgent.TaskHubLicenseDetails>
    /// <param name="inputValidationRequest">-</param>
    abstract validateInputs: inputValidationRequest: TaskAgent.InputValidationRequest -> Promise<TaskAgent.InputValidationRequest>
    /// <param name="poolId">-</param>
    /// <param name="requestId">-</param>
    /// <param name="lockToken">-</param>
    /// <param name="result">-</param>
    abstract deleteAgentRequest: poolId: int * requestId: int * lockToken: string * ?result: TaskAgent.TaskResult -> Promise<unit>
    /// <param name="poolId">-</param>
    /// <param name="requestId">-</param>
    /// <param name="includeStatus">-</param>
    abstract getAgentRequest: poolId: int * requestId: int * ?includeStatus: bool -> Promise<TaskAgent.TaskAgentJobRequest>
    /// <param name="poolId">-</param>
    /// <param name="top">-</param>
    /// <param name="continuationToken">-</param>
    abstract getAgentRequests: poolId: int * top: int * ?continuationToken: string -> Promise<ResizeArray<TaskAgent.TaskAgentJobRequest>>
    /// <param name="poolId">-</param>
    /// <param name="agentId">-</param>
    /// <param name="completedRequestCount">-</param>
    abstract getAgentRequestsForAgent: poolId: int * agentId: int * ?completedRequestCount: int -> Promise<ResizeArray<TaskAgent.TaskAgentJobRequest>>
    /// <param name="poolId">-</param>
    /// <param name="agentIds">-</param>
    /// <param name="completedRequestCount">-</param>
    abstract getAgentRequestsForAgents: poolId: int * ?agentIds: ResizeArray<float> * ?completedRequestCount: int -> Promise<ResizeArray<TaskAgent.TaskAgentJobRequest>>
    /// <param name="poolId">-</param>
    /// <param name="planId">-</param>
    /// <param name="jobId">-</param>
    abstract getAgentRequestsForPlan: poolId: int * planId: string * ?jobId: string -> Promise<ResizeArray<TaskAgent.TaskAgentJobRequest>>
    /// <param name="request">-</param>
    /// <param name="poolId">-</param>
    abstract queueAgentRequestByPool: request: TaskAgent.TaskAgentJobRequest * poolId: int -> Promise<TaskAgent.TaskAgentJobRequest>
    /// <param name="request">-</param>
    /// <param name="poolId">-</param>
    /// <param name="requestId">-</param>
    /// <param name="lockToken">-</param>
    abstract updateAgentRequest: request: TaskAgent.TaskAgentJobRequest * poolId: int * requestId: int * lockToken: string -> Promise<TaskAgent.TaskAgentJobRequest>
    /// <param name="createParameters">-</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="environmentId">-</param>
    abstract addKubernetesResource: createParameters: TaskAgent.KubernetesResourceCreateParameters * project: string * environmentId: int -> Promise<TaskAgent.KubernetesResource>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="environmentId">-</param>
    /// <param name="resourceId">-</param>
    abstract deleteKubernetesResource: project: string * environmentId: int * resourceId: int -> Promise<unit>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="environmentId">-</param>
    /// <param name="resourceId">-</param>
    abstract getKubernetesResource: project: string * environmentId: int * resourceId: int -> Promise<TaskAgent.KubernetesResource>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="machineGroupId">-</param>
    abstract generateDeploymentMachineGroupAccessToken: project: string * machineGroupId: int -> Promise<string>
    /// <param name="machineGroup">-</param>
    /// <param name="project">- Project ID or project name</param>
    abstract addDeploymentMachineGroup: machineGroup: TaskAgent.DeploymentMachineGroup * project: string -> Promise<TaskAgent.DeploymentMachineGroup>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="machineGroupId">-</param>
    abstract deleteDeploymentMachineGroup: project: string * machineGroupId: int -> Promise<unit>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="machineGroupId">-</param>
    /// <param name="actionFilter">-</param>
    abstract getDeploymentMachineGroup: project: string * machineGroupId: int * ?actionFilter: TaskAgent.MachineGroupActionFilter -> Promise<TaskAgent.DeploymentMachineGroup>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="machineGroupName">-</param>
    /// <param name="actionFilter">-</param>
    abstract getDeploymentMachineGroups: project: string * ?machineGroupName: string * ?actionFilter: TaskAgent.MachineGroupActionFilter -> Promise<ResizeArray<TaskAgent.DeploymentMachineGroup>>
    /// <param name="machineGroup">-</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="machineGroupId">-</param>
    abstract updateDeploymentMachineGroup: machineGroup: TaskAgent.DeploymentMachineGroup * project: string * machineGroupId: int -> Promise<TaskAgent.DeploymentMachineGroup>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="machineGroupId">-</param>
    /// <param name="tagFilters">-</param>
    abstract getDeploymentMachineGroupMachines: project: string * machineGroupId: int * ?tagFilters: ResizeArray<string> -> Promise<ResizeArray<TaskAgent.DeploymentMachine>>
    /// <param name="deploymentMachines">-</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="machineGroupId">-</param>
    abstract updateDeploymentMachineGroupMachines: deploymentMachines: ResizeArray<TaskAgent.DeploymentMachine> * project: string * machineGroupId: int -> Promise<ResizeArray<TaskAgent.DeploymentMachine>>
    /// <param name="machine">-</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="deploymentGroupId">-</param>
    abstract addDeploymentMachine: machine: TaskAgent.DeploymentMachine * project: string * deploymentGroupId: int -> Promise<TaskAgent.DeploymentMachine>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="deploymentGroupId">-</param>
    /// <param name="machineId">-</param>
    abstract deleteDeploymentMachine: project: string * deploymentGroupId: int * machineId: int -> Promise<unit>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="deploymentGroupId">-</param>
    /// <param name="machineId">-</param>
    /// <param name="expand">-</param>
    abstract getDeploymentMachine: project: string * deploymentGroupId: int * machineId: int * ?expand: TaskAgent.DeploymentMachineExpands -> Promise<TaskAgent.DeploymentMachine>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="deploymentGroupId">-</param>
    /// <param name="tags">-</param>
    /// <param name="name">-</param>
    /// <param name="expand">-</param>
    abstract getDeploymentMachines: project: string * deploymentGroupId: int * ?tags: ResizeArray<string> * ?name: string * ?expand: TaskAgent.DeploymentMachineExpands -> Promise<ResizeArray<TaskAgent.DeploymentMachine>>
    /// <param name="machine">-</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="deploymentGroupId">-</param>
    /// <param name="machineId">-</param>
    abstract replaceDeploymentMachine: machine: TaskAgent.DeploymentMachine * project: string * deploymentGroupId: int * machineId: int -> Promise<TaskAgent.DeploymentMachine>
    /// <param name="machine">-</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="deploymentGroupId">-</param>
    /// <param name="machineId">-</param>
    abstract updateDeploymentMachine: machine: TaskAgent.DeploymentMachine * project: string * deploymentGroupId: int * machineId: int -> Promise<TaskAgent.DeploymentMachine>
    /// <param name="machines">-</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="deploymentGroupId">-</param>
    abstract updateDeploymentMachines: machines: ResizeArray<TaskAgent.DeploymentMachine> * project: string * deploymentGroupId: int -> Promise<ResizeArray<TaskAgent.DeploymentMachine>>
    /// <param name="definition">-</param>
    /// <param name="poolId">-</param>
    abstract createAgentPoolMaintenanceDefinition: definition: TaskAgent.TaskAgentPoolMaintenanceDefinition * poolId: int -> Promise<TaskAgent.TaskAgentPoolMaintenanceDefinition>
    /// <param name="poolId">-</param>
    /// <param name="definitionId">-</param>
    abstract deleteAgentPoolMaintenanceDefinition: poolId: int * definitionId: int -> Promise<unit>
    /// <param name="poolId">-</param>
    /// <param name="definitionId">-</param>
    abstract getAgentPoolMaintenanceDefinition: poolId: int * definitionId: int -> Promise<TaskAgent.TaskAgentPoolMaintenanceDefinition>
    /// <param name="poolId">-</param>
    abstract getAgentPoolMaintenanceDefinitions: poolId: int -> Promise<ResizeArray<TaskAgent.TaskAgentPoolMaintenanceDefinition>>
    /// <param name="definition">-</param>
    /// <param name="poolId">-</param>
    /// <param name="definitionId">-</param>
    abstract updateAgentPoolMaintenanceDefinition: definition: TaskAgent.TaskAgentPoolMaintenanceDefinition * poolId: int * definitionId: int -> Promise<TaskAgent.TaskAgentPoolMaintenanceDefinition>
    /// <param name="poolId">-</param>
    /// <param name="jobId">-</param>
    abstract deleteAgentPoolMaintenanceJob: poolId: int * jobId: int -> Promise<unit>
    /// <param name="poolId">-</param>
    /// <param name="jobId">-</param>
    abstract getAgentPoolMaintenanceJob: poolId: int * jobId: int -> Promise<TaskAgent.TaskAgentPoolMaintenanceJob>
    /// <param name="poolId">-</param>
    /// <param name="jobId">-</param>
    abstract getAgentPoolMaintenanceJobLogs: poolId: int * jobId: int -> Promise<ArrayBuffer>
    /// <param name="poolId">-</param>
    /// <param name="definitionId">-</param>
    abstract getAgentPoolMaintenanceJobs: poolId: int * ?definitionId: int -> Promise<ResizeArray<TaskAgent.TaskAgentPoolMaintenanceJob>>
    /// <param name="job">-</param>
    /// <param name="poolId">-</param>
    abstract queueAgentPoolMaintenanceJob: job: TaskAgent.TaskAgentPoolMaintenanceJob * poolId: int -> Promise<TaskAgent.TaskAgentPoolMaintenanceJob>
    /// <param name="job">-</param>
    /// <param name="poolId">-</param>
    /// <param name="jobId">-</param>
    abstract updateAgentPoolMaintenanceJob: job: TaskAgent.TaskAgentPoolMaintenanceJob * poolId: int * jobId: int -> Promise<TaskAgent.TaskAgentPoolMaintenanceJob>
    /// <param name="poolId">-</param>
    /// <param name="messageId">-</param>
    /// <param name="sessionId">-</param>
    abstract deleteMessage: poolId: int * messageId: int * sessionId: string -> Promise<unit>
    /// <param name="poolId">-</param>
    /// <param name="sessionId">-</param>
    /// <param name="lastMessageId">-</param>
    abstract getMessage: poolId: int * sessionId: string * ?lastMessageId: int -> Promise<TaskAgent.TaskAgentMessage>
    /// <param name="poolId">-</param>
    /// <param name="agentId">-</param>
    abstract refreshAgent: poolId: int * agentId: int -> Promise<unit>
    /// <param name="poolId">-</param>
    abstract refreshAgents: poolId: int -> Promise<unit>
    /// <param name="message">-</param>
    /// <param name="poolId">-</param>
    /// <param name="requestId">-</param>
    abstract sendMessage: message: TaskAgent.TaskAgentMessage * poolId: int * requestId: int -> Promise<unit>
    /// <param name="packageType">-</param>
    /// <param name="platform">-</param>
    /// <param name="version">-</param>
    abstract getPackage: packageType: string * platform: string * version: string -> Promise<TaskAgent.PackageMetadata>
    /// <param name="packageType">-</param>
    /// <param name="platform">-</param>
    /// <param name="top">-</param>
    abstract getPackages: packageType: string * ?platform: string * ?top: int -> Promise<ResizeArray<TaskAgent.PackageMetadata>>
    /// <param name="poolId">-</param>
    abstract getAgentPoolMetadata: poolId: int -> Promise<string>
    /// <summary>Create an agent pool.</summary>
    /// <param name="pool">- Details about the new agent pool</param>
    abstract addAgentPool: pool: TaskAgent.TaskAgentPool -> Promise<TaskAgent.TaskAgentPool>
    /// <summary>Delete an agent pool.</summary>
    /// <param name="poolId">- ID of the agent pool to delete</param>
    abstract deleteAgentPool: poolId: int -> Promise<unit>
    /// <summary>Get information about an agent pool.</summary>
    /// <param name="poolId">- An agent pool ID</param>
    /// <param name="properties">- Agent pool properties (comma-separated)</param>
    /// <param name="actionFilter">- Filter by whether the calling user has use or manage permissions</param>
    abstract getAgentPool: poolId: int * ?properties: ResizeArray<string> * ?actionFilter: TaskAgent.TaskAgentPoolActionFilter -> Promise<TaskAgent.TaskAgentPool>
    /// <summary>Get a list of agent pools.</summary>
    /// <param name="poolName">- Filter by name</param>
    /// <param name="properties">- Filter by agent pool properties (comma-separated)</param>
    /// <param name="poolType">- Filter by pool type</param>
    /// <param name="actionFilter">- Filter by whether the calling user has use or manage permissions</param>
    abstract getAgentPools: ?poolName: string * ?properties: ResizeArray<string> * ?poolType: TaskAgent.TaskAgentPoolType * ?actionFilter: TaskAgent.TaskAgentPoolActionFilter -> Promise<ResizeArray<TaskAgent.TaskAgentPool>>
    /// <summary>Get a list of agent pools.</summary>
    /// <param name="poolIds">- pool Ids to fetch</param>
    /// <param name="actionFilter">- Filter by whether the calling user has use or manage permissions</param>
    abstract getAgentPoolsByIds: poolIds: ResizeArray<float> * ?actionFilter: TaskAgent.TaskAgentPoolActionFilter -> Promise<ResizeArray<TaskAgent.TaskAgentPool>>
    /// <summary>Update properties on an agent pool</summary>
    /// <param name="pool">- Updated agent pool details</param>
    /// <param name="poolId">- The agent pool to update</param>
    abstract updateAgentPool: pool: TaskAgent.TaskAgentPool * poolId: int -> Promise<TaskAgent.TaskAgentPool>
    /// <summary>Create a new agent queue to connect a project to an agent pool.</summary>
    /// <param name="queue">- Details about the queue to create</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="authorizePipelines">- Automatically authorize this queue when using YAML</param>
    abstract addAgentQueue: queue: TaskAgent.TaskAgentQueue * ?project: string * ?authorizePipelines: bool -> Promise<TaskAgent.TaskAgentQueue>
    /// <summary>Create a new team project.</summary>
    /// <param name="project">- Project ID or project name</param>
    abstract createTeamProject: ?project: string -> Promise<unit>
    /// <summary>Removes an agent queue from a project.</summary>
    /// <param name="queueId">- The agent queue to remove</param>
    /// <param name="project">- Project ID or project name</param>
    abstract deleteAgentQueue: queueId: int * ?project: string -> Promise<unit>
    /// <summary>Get information about an agent queue.</summary>
    /// <param name="queueId">- The agent queue to get information about</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="actionFilter">- Filter by whether the calling user has use or manage permissions</param>
    abstract getAgentQueue: queueId: int * ?project: string * ?actionFilter: TaskAgent.TaskAgentQueueActionFilter -> Promise<TaskAgent.TaskAgentQueue>
    /// <summary>Get a list of agent queues.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="queueName">- Filter on the agent queue name</param>
    /// <param name="actionFilter">- Filter by whether the calling user has use or manage permissions</param>
    abstract getAgentQueues: ?project: string * ?queueName: string * ?actionFilter: TaskAgent.TaskAgentQueueActionFilter -> Promise<ResizeArray<TaskAgent.TaskAgentQueue>>
    /// <summary>Get a list of agent queues by their IDs</summary>
    /// <param name="queueIds">- A comma-separated list of agent queue IDs to retrieve</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="actionFilter">- Filter by whether the calling user has use or manage permissions</param>
    abstract getAgentQueuesByIds: queueIds: ResizeArray<float> * ?project: string * ?actionFilter: TaskAgent.TaskAgentQueueActionFilter -> Promise<ResizeArray<TaskAgent.TaskAgentQueue>>
    /// <summary>Get a list of agent queues by their names</summary>
    /// <param name="queueNames">- A comma-separated list of agent names to retrieve</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="actionFilter">- Filter by whether the calling user has use or manage permissions</param>
    abstract getAgentQueuesByNames: queueNames: ResizeArray<string> * ?project: string * ?actionFilter: TaskAgent.TaskAgentQueueActionFilter -> Promise<ResizeArray<TaskAgent.TaskAgentQueue>>
    /// <summary>Get a list of agent queues by pool ids</summary>
    /// <param name="poolIds">- A comma-separated list of pool ids to get the corresponding queues for</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="actionFilter">- Filter by whether the calling user has use or manage permissions</param>
    abstract getAgentQueuesForPools: poolIds: ResizeArray<float> * ?project: string * ?actionFilter: TaskAgent.TaskAgentQueueActionFilter -> Promise<ResizeArray<TaskAgent.TaskAgentQueue>>
    /// <param name="agentCloudId">-</param>
    abstract getAgentCloudRequests: agentCloudId: int -> Promise<ResizeArray<TaskAgent.TaskAgentCloudRequest>>
    abstract getResourceLimits: unit -> Promise<ResizeArray<TaskAgent.ResourceLimit>>
    /// <param name="parallelismTag">-</param>
    /// <param name="poolIsHosted">-</param>
    /// <param name="includeRunningRequests">-</param>
    abstract getResourceUsage: ?parallelismTag: string * ?poolIsHosted: bool * ?includeRunningRequests: bool -> Promise<TaskAgent.ResourceUsage>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="taskGroupId">-</param>
    abstract getTaskGroupHistory: project: string * taskGroupId: string -> Promise<ResizeArray<TaskAgent.TaskGroupRevision>>
    /// <summary>Delete a secure file</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="secureFileId">- The unique secure file Id</param>
    abstract deleteSecureFile: project: string * secureFileId: string -> Promise<unit>
    /// <summary>Download a secure file by Id</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="secureFileId">- The unique secure file Id</param>
    /// <param name="ticket">- A valid download ticket</param>
    /// <param name="download">- If download is true, the file is sent as attachement in the response body. If download is false, the response body contains the file stream.</param>
    abstract downloadSecureFile: project: string * secureFileId: string * ticket: string * ?download: bool -> Promise<ArrayBuffer>
    /// <summary>Get a secure file</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="secureFileId">- The unique secure file Id</param>
    /// <param name="includeDownloadTicket">- If includeDownloadTicket is true and the caller has permissions, a download ticket is included in the response.</param>
    /// <param name="actionFilter">-</param>
    abstract getSecureFile: project: string * secureFileId: string * ?includeDownloadTicket: bool * ?actionFilter: TaskAgent.SecureFileActionFilter -> Promise<TaskAgent.SecureFile>
    /// <summary>Get secure files</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="namePattern">- Name of the secure file to match. Can include wildcards to match multiple files.</param>
    /// <param name="includeDownloadTickets">- If includeDownloadTickets is true and the caller has permissions, a download ticket for each secure file is included in the response.</param>
    /// <param name="actionFilter">- Filter by secure file permissions for View, Manage or Use action. Defaults to View.</param>
    abstract getSecureFiles: project: string * ?namePattern: string * ?includeDownloadTickets: bool * ?actionFilter: TaskAgent.SecureFileActionFilter -> Promise<ResizeArray<TaskAgent.SecureFile>>
    /// <summary>Get secure files</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="secureFileIds">- A list of secure file Ids</param>
    /// <param name="includeDownloadTickets">- If includeDownloadTickets is true and the caller has permissions, a download ticket for each secure file is included in the response.</param>
    /// <param name="actionFilter">-</param>
    abstract getSecureFilesByIds: project: string * secureFileIds: ResizeArray<string> * ?includeDownloadTickets: bool * ?actionFilter: TaskAgent.SecureFileActionFilter -> Promise<ResizeArray<TaskAgent.SecureFile>>
    /// <summary>Get secure files</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="secureFileNames">- A list of secure file Ids</param>
    /// <param name="includeDownloadTickets">- If includeDownloadTickets is true and the caller has permissions, a download ticket for each secure file is included in the response.</param>
    /// <param name="actionFilter">-</param>
    abstract getSecureFilesByNames: project: string * secureFileNames: ResizeArray<string> * ?includeDownloadTickets: bool * ?actionFilter: TaskAgent.SecureFileActionFilter -> Promise<ResizeArray<TaskAgent.SecureFile>>
    /// <summary>Query secure files using a name pattern and a condition on file properties.</summary>
    /// <param name="condition">- The main condition syntax is described [here](https://go.microsoft.com/fwlink/?linkid=842996). Use the *property('property-name')* function to access the value of the specified property of a secure file. It returns null if the property is not set. E.g. \`\`\` and( eq( property('devices'), '2' ), in( property('provisioning profile type'), 'ad hoc', 'development' ) ) \`\`\`</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="namePattern">- Name of the secure file to match. Can include wildcards to match multiple files.</param>
    abstract querySecureFilesByProperties: condition: string * project: string * ?namePattern: string -> Promise<ResizeArray<TaskAgent.SecureFile>>
    /// <summary>Update the name or properties of an existing secure file</summary>
    /// <param name="secureFile">- The secure file with updated name and/or properties</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="secureFileId">- The unique secure file Id</param>
    abstract updateSecureFile: secureFile: TaskAgent.SecureFile * project: string * secureFileId: string -> Promise<TaskAgent.SecureFile>
    /// <summary>Update properties and/or names of a set of secure files. Files are identified by their IDs. Properties provided override the existing one entirely, i.e. do not merge.</summary>
    /// <param name="secureFiles">- A list of secure file objects. Only three field must be populated Id, Name, and Properties. The rest of fields in the object are ignored.</param>
    /// <param name="project">- Project ID or project name</param>
    abstract updateSecureFiles: secureFiles: ResizeArray<TaskAgent.SecureFile> * project: string -> Promise<ResizeArray<TaskAgent.SecureFile>>
    /// <summary>Upload a secure file, include the file stream in the request body</summary>
    /// <param name="content">- Content to upload</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="name">- Name of the file to upload</param>
    /// <param name="authorizePipelines">- If authorizePipelines is true, then the secure file is authorized for use by all pipelines in the project.</param>
    abstract uploadSecureFile: content: obj option * project: string * name: string * ?authorizePipelines: bool -> Promise<TaskAgent.SecureFile>
    /// <param name="session">-</param>
    /// <param name="poolId">-</param>
    abstract createAgentSession: session: TaskAgent.TaskAgentSession * poolId: int -> Promise<TaskAgent.TaskAgentSession>
    /// <param name="poolId">-</param>
    /// <param name="sessionId">-</param>
    abstract deleteAgentSession: poolId: int * sessionId: string -> Promise<unit>
    /// <summary>Register a deployment target to a deployment group. Generally this is called by agent configuration tool.</summary>
    /// <param name="machine">- Deployment target to register.</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="deploymentGroupId">- ID of the deployment group to which the deployment target is registered.</param>
    abstract addDeploymentTarget: machine: TaskAgent.DeploymentMachine * project: string * deploymentGroupId: int -> Promise<TaskAgent.DeploymentMachine>
    /// <summary>Delete a deployment target in a deployment group. This deletes the agent from associated deployment pool too.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="deploymentGroupId">- ID of the deployment group in which deployment target is deleted.</param>
    /// <param name="targetId">- ID of the deployment target to delete.</param>
    abstract deleteDeploymentTarget: project: string * deploymentGroupId: int * targetId: int -> Promise<unit>
    /// <summary>Get a deployment target by its ID in a deployment group</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="deploymentGroupId">- ID of the deployment group to which deployment target belongs.</param>
    /// <param name="targetId">- ID of the deployment target to return.</param>
    /// <param name="expand">- Include these additional details in the returned objects.</param>
    abstract getDeploymentTarget: project: string * deploymentGroupId: int * targetId: int * ?expand: TaskAgent.DeploymentTargetExpands -> Promise<TaskAgent.DeploymentMachine>
    /// <summary>Get a list of deployment targets in a deployment group.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="deploymentGroupId">- ID of the deployment group.</param>
    /// <param name="tags">- Get only the deployment targets that contain all these comma separted list of tags.</param>
    /// <param name="name">- Name pattern of the deployment targets to return.</param>
    /// <param name="partialNameMatch">- When set to true, treats **name** as pattern. Else treats it as absolute match. Default is **false**.</param>
    /// <param name="expand">- Include these additional details in the returned objects.</param>
    /// <param name="agentStatus">- Get only deployment targets that have this status.</param>
    /// <param name="agentJobResult">- Get only deployment targets that have this last job result.</param>
    /// <param name="continuationToken">- Get deployment targets with names greater than this continuationToken lexicographically.</param>
    /// <param name="top">- Maximum number of deployment targets to return. Default is **1000**.</param>
    /// <param name="enabled">- Get only deployment targets that are enabled or disabled. Default is 'null' which returns all the targets.</param>
    /// <param name="propertyFilters">-</param>
    abstract getDeploymentTargets: project: string * deploymentGroupId: int * ?tags: ResizeArray<string> * ?name: string * ?partialNameMatch: bool * ?expand: TaskAgent.DeploymentTargetExpands * ?agentStatus: TaskAgent.TaskAgentStatusFilter * ?agentJobResult: TaskAgent.TaskAgentJobResultFilter * ?continuationToken: string * ?top: int * ?enabled: bool * ?propertyFilters: ResizeArray<string> -> Promise<ResizeArray<TaskAgent.DeploymentMachine>>
    /// <summary>Replace a deployment target in a deployment group. Generally this is called by agent configuration tool.</summary>
    /// <param name="machine">- New deployment target.</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="deploymentGroupId">- ID of the deployment group in which deployment target is replaced.</param>
    /// <param name="targetId">- ID of the deployment target to replace.</param>
    abstract replaceDeploymentTarget: machine: TaskAgent.DeploymentMachine * project: string * deploymentGroupId: int * targetId: int -> Promise<TaskAgent.DeploymentMachine>
    /// <summary>Update a deployment target and its agent properties in a deployment group. Generally this is called by agent configuration tool.</summary>
    /// <param name="machine">- Deployment target to update.</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="deploymentGroupId">- ID of the deployment group in which deployment target is updated.</param>
    /// <param name="targetId">- ID of the deployment target to update.</param>
    abstract updateDeploymentTarget: machine: TaskAgent.DeploymentMachine * project: string * deploymentGroupId: int * targetId: int -> Promise<TaskAgent.DeploymentMachine>
    /// <summary>Update tags of a list of deployment targets in a deployment group.</summary>
    /// <param name="machines">- Deployment targets with tags to udpdate.</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="deploymentGroupId">- ID of the deployment group in which deployment targets are updated.</param>
    abstract updateDeploymentTargets: machines: ResizeArray<TaskAgent.DeploymentTargetUpdateParameter> * project: string * deploymentGroupId: int -> Promise<ResizeArray<TaskAgent.DeploymentMachine>>
    /// <summary>Create a task group.</summary>
    /// <param name="taskGroup">- Task group object to create.</param>
    /// <param name="project">- Project ID or project name</param>
    abstract addTaskGroup: taskGroup: TaskAgent.TaskGroupCreateParameter * project: string -> Promise<TaskAgent.TaskGroup>
    /// <summary>Delete a task group.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="taskGroupId">- Id of the task group to be deleted.</param>
    /// <param name="comment">- Comments to delete.</param>
    abstract deleteTaskGroup: project: string * taskGroupId: string * ?comment: string -> Promise<unit>
    /// <summary>Get task group.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="taskGroupId">- Id of the task group.</param>
    /// <param name="versionSpec">- version specification of the task group. examples: 1, 1.0.</param>
    /// <param name="expand">- The properties that should be expanded. example $expand=Tasks will expand nested task groups.</param>
    abstract getTaskGroup: project: string * taskGroupId: string * versionSpec: string * ?expand: TaskAgent.TaskGroupExpands -> Promise<TaskAgent.TaskGroup>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="taskGroupId">-</param>
    /// <param name="revision">-</param>
    abstract getTaskGroupRevision: project: string * taskGroupId: string * revision: int -> Promise<string>
    /// <summary>List task groups.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="taskGroupId">- Id of the task group.</param>
    /// <param name="expanded">- 'true' to recursively expand task groups. Default is 'false'.</param>
    /// <param name="taskIdFilter">- Guid of the taskId to filter.</param>
    /// <param name="deleted">- 'true'to include deleted task groups. Default is 'false'.</param>
    /// <param name="top">- Number of task groups to get.</param>
    /// <param name="continuationToken">- Gets the task groups after the continuation token provided.</param>
    /// <param name="queryOrder">- Gets the results in the defined order. Default is 'CreatedOnDescending'.</param>
    abstract getTaskGroups: project: string * ?taskGroupId: string * ?expanded: bool * ?taskIdFilter: string * ?deleted: bool * ?top: int * ?continuationToken: DateTime * ?queryOrder: TaskAgent.TaskGroupQueryOrder -> Promise<ResizeArray<TaskAgent.TaskGroup>>
    /// <param name="taskGroupMetadata">-</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="parentTaskGroupId">-</param>
    abstract publishTaskGroup: taskGroupMetadata: TaskAgent.PublishTaskGroupMetadata * project: string * parentTaskGroupId: string -> Promise<ResizeArray<TaskAgent.TaskGroup>>
    /// <param name="taskGroup">-</param>
    /// <param name="project">- Project ID or project name</param>
    abstract undeleteTaskGroup: taskGroup: TaskAgent.TaskGroup * project: string -> Promise<ResizeArray<TaskAgent.TaskGroup>>
    /// <summary>Update a task group.</summary>
    /// <param name="taskGroup">- Task group to update.</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="taskGroupId">- Id of the task group to update.</param>
    abstract updateTaskGroup: taskGroup: TaskAgent.TaskGroupUpdateParameter * project: string * ?taskGroupId: string -> Promise<TaskAgent.TaskGroup>
    /// <param name="taskGroupUpdateProperties">-</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="taskGroupId">-</param>
    /// <param name="disablePriorVersions">-</param>
    abstract updateTaskGroupProperties: taskGroupUpdateProperties: TaskAgent.TaskGroupUpdatePropertiesBase * project: string * taskGroupId: string * ?disablePriorVersions: bool -> Promise<ResizeArray<TaskAgent.TaskGroup>>
    /// <param name="taskId">-</param>
    abstract deleteTaskDefinition: taskId: string -> Promise<unit>
    /// <param name="taskId">-</param>
    /// <param name="versionString">-</param>
    /// <param name="visibility">-</param>
    /// <param name="scopeLocal">-</param>
    abstract getTaskContentZip: taskId: string * versionString: string * ?visibility: ResizeArray<string> * ?scopeLocal: bool -> Promise<ArrayBuffer>
    /// <param name="taskId">-</param>
    /// <param name="versionString">-</param>
    /// <param name="visibility">-</param>
    /// <param name="scopeLocal">-</param>
    abstract getTaskDefinition: taskId: string * versionString: string * ?visibility: ResizeArray<string> * ?scopeLocal: bool -> Promise<TaskAgent.TaskDefinition>
    /// <param name="taskId">-</param>
    /// <param name="visibility">-</param>
    /// <param name="scopeLocal">-</param>
    abstract getTaskDefinitions: ?taskId: string * ?visibility: ResizeArray<string> * ?scopeLocal: bool -> Promise<ResizeArray<TaskAgent.TaskDefinition>>
    /// <param name="poolId">-</param>
    /// <param name="agentId">-</param>
    /// <param name="currentState">-</param>
    abstract updateAgentUpdateState: poolId: int * agentId: int * currentState: string -> Promise<TaskAgent.TaskAgent>
    /// <param name="userCapabilities">-</param>
    /// <param name="poolId">-</param>
    /// <param name="agentId">-</param>
    abstract updateAgentUserCapabilities: userCapabilities: TaskAgentRestClientUpdateAgentUserCapabilitiesUserCapabilities * poolId: int * agentId: int -> Promise<TaskAgent.TaskAgent>
    /// <summary>Add a variable group.</summary>
    /// <param name="variableGroupParameters">-</param>
    abstract addVariableGroup: variableGroupParameters: TaskAgent.VariableGroupParameters -> Promise<TaskAgent.VariableGroup>
    /// <summary>Delete a variable group</summary>
    /// <param name="groupId">- Id of the variable group.</param>
    /// <param name="projectIds">-</param>
    abstract deleteVariableGroup: groupId: int * projectIds: ResizeArray<string> -> Promise<unit>
    /// <summary>Add a variable group.</summary>
    /// <param name="variableGroupProjectReferences">-</param>
    /// <param name="variableGroupId">-</param>
    abstract shareVariableGroup: variableGroupProjectReferences: ResizeArray<TaskAgent.VariableGroupProjectReference> * variableGroupId: int -> Promise<unit>
    /// <summary>Update a variable group.</summary>
    /// <param name="variableGroupParameters">-</param>
    /// <param name="groupId">- Id of the variable group to update.</param>
    abstract updateVariableGroup: variableGroupParameters: TaskAgent.VariableGroupParameters * groupId: int -> Promise<TaskAgent.VariableGroup>
    /// <summary>Get a variable group.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="groupId">- Id of the variable group.</param>
    abstract getVariableGroup: project: string * groupId: int -> Promise<TaskAgent.VariableGroup>
    /// <summary>Get variable groups.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="groupName">- Name of variable group.</param>
    /// <param name="actionFilter">- Action filter for the variable group. It specifies the action which can be performed on the variable groups.</param>
    /// <param name="top">- Number of variable groups to get.</param>
    /// <param name="continuationToken">- Gets the variable groups after the continuation token provided.</param>
    /// <param name="queryOrder">- Gets the results in the defined order. Default is 'IdDescending'.</param>
    abstract getVariableGroups: project: string * ?groupName: string * ?actionFilter: TaskAgent.VariableGroupActionFilter * ?top: int * ?continuationToken: int * ?queryOrder: TaskAgent.VariableGroupQueryOrder -> Promise<ResizeArray<TaskAgent.VariableGroup>>
    /// <summary>Get variable groups by ids.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="groupIds">- Comma separated list of Ids of variable groups.</param>
    abstract getVariableGroupsById: project: string * groupIds: ResizeArray<float> -> Promise<ResizeArray<TaskAgent.VariableGroup>>
    /// <param name="createParameters">-</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="environmentId">-</param>
    abstract addVirtualMachineGroup: createParameters: TaskAgent.VirtualMachineGroupCreateParameters * project: string * environmentId: int -> Promise<TaskAgent.VirtualMachineGroup>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="environmentId">-</param>
    /// <param name="resourceId">-</param>
    abstract deleteVirtualMachineGroup: project: string * environmentId: int * resourceId: int -> Promise<unit>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="environmentId">-</param>
    /// <param name="resourceId">-</param>
    abstract getVirtualMachineGroup: project: string * environmentId: int * resourceId: int -> Promise<TaskAgent.VirtualMachineGroup>
    /// <param name="resource">-</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="environmentId">-</param>
    abstract updateVirtualMachineGroup: resource: TaskAgent.VirtualMachineGroup * project: string * environmentId: int -> Promise<TaskAgent.VirtualMachineGroup>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="environmentId">-</param>
    /// <param name="resourceId">-</param>
    /// <param name="continuationToken">-</param>
    /// <param name="name">-</param>
    /// <param name="partialNameMatch">-</param>
    /// <param name="tags">-</param>
    /// <param name="top">-</param>
    abstract getVirtualMachines: project: string * environmentId: int * resourceId: int * ?continuationToken: string * ?name: string * ?partialNameMatch: bool * ?tags: ResizeArray<string> * ?top: int -> Promise<ResizeArray<TaskAgent.VirtualMachine>>
    /// <param name="machines">-</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="environmentId">-</param>
    /// <param name="resourceId">-</param>
    abstract updateVirtualMachines: machines: ResizeArray<TaskAgent.VirtualMachine> * project: string * environmentId: int * resourceId: int -> Promise<ResizeArray<TaskAgent.VirtualMachine>>
    /// <param name="authenticationRequest">-</param>
    abstract acquireAccessToken: authenticationRequest: TaskAgent.AadOauthTokenRequest -> Promise<TaskAgent.AadOauthTokenResult>
    /// <param name="tenantId">-</param>
    /// <param name="redirectUri">-</param>
    /// <param name="promptOption">-</param>
    /// <param name="completeCallbackPayload">-</param>
    /// <param name="completeCallbackByAuthCode">-</param>
    abstract createAadOAuthRequest: tenantId: string * redirectUri: string * ?promptOption: TaskAgent.AadLoginPromptOption * ?completeCallbackPayload: string * ?completeCallbackByAuthCode: bool -> Promise<string>
    abstract getVstsAadTenantId: unit -> Promise<string>
    /// <summary>GET the Yaml schema used for Yaml file validation.</summary>
    /// <param name="validateTaskNames">- Whether the schema should validate that tasks are actually installed (useful for offline tools where you don't want validation).</param>
    abstract getYamlSchema: ?validateTaskNames: bool -> Promise<obj option>

type [<AllowNullLiteral>] TaskAgentRestClientUpdateAgentUserCapabilitiesUserCapabilities =
    [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> string with get, set

type [<AllowNullLiteral>] TaskAgentRestClientStatic =
    [<Emit "new $0($1...)">] abstract Create: options: IVssRestClientOptions -> TaskAgentRestClient
    abstract RESOURCE_AREA_ID: string
