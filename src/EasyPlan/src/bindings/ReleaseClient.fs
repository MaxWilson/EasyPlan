// ts2fable 0.7.1
module rec ReleaseClient
open System
open Fable.Core
open Fable.Core.JS


module ReleaseClient =
    module FormInput = ___FormInput_FormInput
    module Release = ___Release_Release
    type IVssRestClientOptions = _____Common_Context.IVssRestClientOptions
    type RestClientBase = _____Common_RestClientBase.RestClientBase

    type [<AllowNullLiteral>] IExports =
        abstract ReleaseRestClient: ReleaseRestClientStatic

    type [<AllowNullLiteral>] ReleaseRestClient =
        inherit RestClientBase
        /// <summary>Returns the artifact details that automation agent requires</summary>
        /// <param name="project">- Project ID or project name</param>
        /// <param name="releaseId">-</param>
        abstract getAgentArtifactDefinitions: project: string * releaseId: float -> Promise<ResizeArray<Release.AgentArtifactDefinition>>
        /// <summary>Get a list of approvals</summary>
        /// <param name="project">- Project ID or project name</param>
        /// <param name="assignedToFilter">- Approvals assigned to this user.</param>
        /// <param name="statusFilter">- Approvals with this status. Default is 'pending'.</param>
        /// <param name="releaseIdsFilter">- Approvals for release id(s) mentioned in the filter. Multiple releases can be mentioned by separating them with ',' e.g. releaseIdsFilter=1,2,3,4.</param>
        /// <param name="typeFilter">- Approval with this type.</param>
        /// <param name="top">- Number of approvals to get. Default is 50.</param>
        /// <param name="continuationToken">- Gets the approvals after the continuation token provided.</param>
        /// <param name="queryOrder">- Gets the results in the defined order of created approvals. Default is 'descending'.</param>
        /// <param name="includeMyGroupApprovals">- 'true' to include my group approvals. Default is 'false'.</param>
        abstract getApprovals: project: string * ?assignedToFilter: string * ?statusFilter: Release.ApprovalStatus * ?releaseIdsFilter: ResizeArray<float> * ?typeFilter: Release.ApprovalType * ?top: float * ?continuationToken: float * ?queryOrder: Release.ReleaseQueryOrder * ?includeMyGroupApprovals: bool -> Promise<ResizeArray<Release.ReleaseApproval>>
        /// <summary>Get approval history.</summary>
        /// <param name="project">- Project ID or project name</param>
        /// <param name="approvalStepId">- Id of the approval.</param>
        abstract getApprovalHistory: project: string * approvalStepId: float -> Promise<Release.ReleaseApproval>
        /// <summary>Get an approval.</summary>
        /// <param name="project">- Project ID or project name</param>
        /// <param name="approvalId">- Id of the approval.</param>
        /// <param name="includeHistory">- 'true' to include history of the approval. Default is 'false'.</param>
        abstract getApproval: project: string * approvalId: float * ?includeHistory: bool -> Promise<Release.ReleaseApproval>
        /// <summary>Update status of an approval</summary>
        /// <param name="approval">- ReleaseApproval object having status, approver and comments.</param>
        /// <param name="project">- Project ID or project name</param>
        /// <param name="approvalId">- Id of the approval.</param>
        abstract updateReleaseApproval: approval: Release.ReleaseApproval * project: string * approvalId: float -> Promise<Release.ReleaseApproval>
        /// <param name="approvals">-</param>
        /// <param name="project">- Project ID or project name</param>
        abstract updateReleaseApprovals: approvals: ResizeArray<Release.ReleaseApproval> * project: string -> Promise<ResizeArray<Release.ReleaseApproval>>
        /// <summary>Get a task attachment.</summary>
        /// <param name="project">- Project ID or project name</param>
        /// <param name="releaseId">- Id of the release.</param>
        /// <param name="environmentId">- Id of the release environment.</param>
        /// <param name="attemptId">- Attempt number of deployment.</param>
        /// <param name="timelineId">- Timeline Id of the task.</param>
        /// <param name="recordId">- Record Id of attachment.</param>
        /// <param name="type">- Type of the attachment.</param>
        /// <param name="name">- Name of the attachment.</param>
        abstract getTaskAttachmentContent: project: string * releaseId: float * environmentId: float * attemptId: float * timelineId: string * recordId: string * ``type``: string * name: string -> Promise<ArrayBuffer>
        /// <summary>Get a release task attachment.</summary>
        /// <param name="project">- Project ID or project name</param>
        /// <param name="releaseId">- Id of the release.</param>
        /// <param name="environmentId">- Id of the release environment.</param>
        /// <param name="attemptId">- Attempt number of deployment.</param>
        /// <param name="planId">- Plan Id of the deploy phase.</param>
        /// <param name="timelineId">- Timeline Id of the task.</param>
        /// <param name="recordId">- Record Id of attachment.</param>
        /// <param name="type">- Type of the attachment.</param>
        /// <param name="name">- Name of the attachment.</param>
        abstract getReleaseTaskAttachmentContent: project: string * releaseId: float * environmentId: float * attemptId: float * planId: string * timelineId: string * recordId: string * ``type``: string * name: string -> Promise<ArrayBuffer>
        /// <summary>Get the task attachments.</summary>
        /// <param name="project">- Project ID or project name</param>
        /// <param name="releaseId">- Id of the release.</param>
        /// <param name="environmentId">- Id of the release environment.</param>
        /// <param name="attemptId">- Attempt number of deployment.</param>
        /// <param name="timelineId">- Timeline Id of the task.</param>
        /// <param name="type">- Type of the attachment.</param>
        abstract getTaskAttachments: project: string * releaseId: float * environmentId: float * attemptId: float * timelineId: string * ``type``: string -> Promise<ResizeArray<Release.ReleaseTaskAttachment>>
        /// <summary>Get the release task attachments.</summary>
        /// <param name="project">- Project ID or project name</param>
        /// <param name="releaseId">- Id of the release.</param>
        /// <param name="environmentId">- Id of the release environment.</param>
        /// <param name="attemptId">- Attempt number of deployment.</param>
        /// <param name="planId">- Plan Id of the deploy phase.</param>
        /// <param name="type">- Type of the attachment.</param>
        abstract getReleaseTaskAttachments: project: string * releaseId: float * environmentId: float * attemptId: float * planId: string * ``type``: string -> Promise<ResizeArray<Release.ReleaseTaskAttachment>>
        /// <param name="artifactType">-</param>
        /// <param name="sourceId">-</param>
        /// <param name="artifactVersionId">-</param>
        /// <param name="project">- Project ID or project name</param>
        abstract getAutoTriggerIssues: artifactType: string * sourceId: string * artifactVersionId: string * ?project: string -> Promise<ResizeArray<Release.AutoTriggerIssue>>
        /// <summary>Gets a badge that indicates the status of the most recent deployment for an environment.</summary>
        /// <param name="projectId">- The ID of the Project.</param>
        /// <param name="releaseDefinitionId">- The ID of the Release Definition.</param>
        /// <param name="environmentId">- The ID of the Environment.</param>
        /// <param name="branchName">- The name of the branch.</param>
        abstract getDeploymentBadge: projectId: string * releaseDefinitionId: float * environmentId: float * ?branchName: string -> Promise<string>
        /// <param name="project">- Project ID or project name</param>
        /// <param name="releaseId">-</param>
        /// <param name="baseReleaseId">-</param>
        /// <param name="top">-</param>
        /// <param name="artifactAlias">-</param>
        abstract getReleaseChanges: project: string * releaseId: float * ?baseReleaseId: float * ?top: float * ?artifactAlias: string -> Promise<ResizeArray<Release.Change>>
        /// <param name="project">- Project ID or project name</param>
        /// <param name="taskGroupId">-</param>
        /// <param name="propertyFilters">-</param>
        abstract getDefinitionEnvironments: project: string * ?taskGroupId: string * ?propertyFilters: ResizeArray<string> -> Promise<ResizeArray<Release.DefinitionEnvironmentReference>>
        /// <summary>Create a release definition</summary>
        /// <param name="releaseDefinition">- release definition object to create.</param>
        /// <param name="project">- Project ID or project name</param>
        abstract createReleaseDefinition: releaseDefinition: Release.ReleaseDefinition * project: string -> Promise<Release.ReleaseDefinition>
        /// <summary>Delete a release definition.</summary>
        /// <param name="project">- Project ID or project name</param>
        /// <param name="definitionId">- Id of the release definition.</param>
        /// <param name="comment">- Comment for deleting a release definition.</param>
        /// <param name="forceDelete">- 'true' to automatically cancel any in-progress release deployments and proceed with release definition deletion . Default is 'false'.</param>
        abstract deleteReleaseDefinition: project: string * definitionId: float * ?comment: string * ?forceDelete: bool -> Promise<unit>
        /// <summary>Get a release definition.</summary>
        /// <param name="project">- Project ID or project name</param>
        /// <param name="definitionId">- Id of the release definition.</param>
        /// <param name="propertyFilters">- A comma-delimited list of extended properties to be retrieved. If set, the returned Release Definition will contain values for the specified property Ids (if they exist). If not set, properties will not be included.</param>
        abstract getReleaseDefinition: project: string * definitionId: float * ?propertyFilters: ResizeArray<string> -> Promise<Release.ReleaseDefinition>
        /// <summary>Get release definition of a given revision.</summary>
        /// <param name="project">- Project ID or project name</param>
        /// <param name="definitionId">- Id of the release definition.</param>
        /// <param name="revision">- Revision number of the release definition.</param>
        abstract getReleaseDefinitionRevision: project: string * definitionId: float * revision: float -> Promise<string>
        /// <summary>Get a list of release definitions.</summary>
        /// <param name="project">- Project ID or project name</param>
        /// <param name="searchText">- Get release definitions with names containing searchText.</param>
        /// <param name="expand">- The properties that should be expanded in the list of Release definitions.</param>
        /// <param name="artifactType">- Release definitions with given artifactType will be returned. Values can be Build, Jenkins, GitHub, Nuget, Team Build (external), ExternalTFSBuild, Git, TFVC, ExternalTfsXamlBuild.</param>
        /// <param name="artifactSourceId">- Release definitions with given artifactSourceId will be returned. e.g. For build it would be \{projectGuid\}:\{BuildDefinitionId\}, for Jenkins it would be \{JenkinsConnectionId\}:\{JenkinsDefinitionId\}, for TfsOnPrem it would be \{TfsOnPremConnectionId\}:\{ProjectName\}:\{TfsOnPremDefinitionId\}. For third-party artifacts e.g. TeamCity, BitBucket you may refer 'uniqueSourceIdentifier' inside vss-extension.json at https://github.com/Microsoft/vsts-rm-extensions/blob/master/Extensions.</param>
        /// <param name="top">- Number of release definitions to get.</param>
        /// <param name="continuationToken">- Gets the release definitions after the continuation token provided.</param>
        /// <param name="queryOrder">- Gets the results in the defined order. Default is 'IdAscending'.</param>
        /// <param name="path">- Gets the release definitions under the specified path.</param>
        /// <param name="isExactNameMatch">- 'true'to gets the release definitions with exact match as specified in searchText. Default is 'false'.</param>
        /// <param name="tagFilter">- A comma-delimited list of tags. Only release definitions with these tags will be returned.</param>
        /// <param name="propertyFilters">- A comma-delimited list of extended properties to be retrieved. If set, the returned Release Definitions will contain values for the specified property Ids (if they exist). If not set, properties will not be included. Note that this will not filter out any Release Definition from results irrespective of whether it has property set or not.</param>
        /// <param name="definitionIdFilter">- A comma-delimited list of release definitions to retrieve.</param>
        /// <param name="isDeleted">- 'true' to get release definitions that has been deleted. Default is 'false'</param>
        /// <param name="searchTextContainsFolderName">- 'true' to get the release definitions under the folder with name as specified in searchText. Default is 'false'.</param>
        abstract getReleaseDefinitions: project: string * ?searchText: string * ?expand: Release.ReleaseDefinitionExpands * ?artifactType: string * ?artifactSourceId: string * ?top: float * ?continuationToken: string * ?queryOrder: Release.ReleaseDefinitionQueryOrder * ?path: string * ?isExactNameMatch: bool * ?tagFilter: ResizeArray<string> * ?propertyFilters: ResizeArray<string> * ?definitionIdFilter: ResizeArray<string> * ?isDeleted: bool * ?searchTextContainsFolderName: bool -> Promise<ResizeArray<Release.ReleaseDefinition>>
        /// <summary>Undelete a release definition.</summary>
        /// <param name="releaseDefinitionUndeleteParameter">- Object for undelete release definition.</param>
        /// <param name="project">- Project ID or project name</param>
        /// <param name="definitionId">- Id of the release definition to be undeleted</param>
        abstract undeleteReleaseDefinition: releaseDefinitionUndeleteParameter: Release.ReleaseDefinitionUndeleteParameter * project: string * definitionId: float -> Promise<Release.ReleaseDefinition>
        /// <summary>Update a release definition.</summary>
        /// <param name="releaseDefinition">- Release definition object to update.</param>
        /// <param name="project">- Project ID or project name</param>
        abstract updateReleaseDefinition: releaseDefinition: Release.ReleaseDefinition * project: string -> Promise<Release.ReleaseDefinition>
        /// <param name="project">- Project ID or project name</param>
        /// <param name="definitionId">-</param>
        /// <param name="definitionEnvironmentId">-</param>
        /// <param name="createdBy">-</param>
        /// <param name="minModifiedTime">-</param>
        /// <param name="maxModifiedTime">-</param>
        /// <param name="deploymentStatus">-</param>
        /// <param name="operationStatus">-</param>
        /// <param name="latestAttemptsOnly">-</param>
        /// <param name="queryOrder">-</param>
        /// <param name="top">-</param>
        /// <param name="continuationToken">-</param>
        /// <param name="createdFor">-</param>
        /// <param name="minStartedTime">-</param>
        /// <param name="maxStartedTime">-</param>
        /// <param name="sourceBranch">-</param>
        abstract getDeployments: project: string * ?definitionId: float * ?definitionEnvironmentId: float * ?createdBy: string * ?minModifiedTime: DateTime * ?maxModifiedTime: DateTime * ?deploymentStatus: Release.DeploymentStatus * ?operationStatus: Release.DeploymentOperationStatus * ?latestAttemptsOnly: bool * ?queryOrder: Release.ReleaseQueryOrder * ?top: float * ?continuationToken: float * ?createdFor: string * ?minStartedTime: DateTime * ?maxStartedTime: DateTime * ?sourceBranch: string -> Promise<ResizeArray<Release.Deployment>>
        /// <param name="queryParameters">-</param>
        /// <param name="project">- Project ID or project name</param>
        abstract getDeploymentsForMultipleEnvironments: queryParameters: Release.DeploymentQueryParameters * project: string -> Promise<ResizeArray<Release.Deployment>>
        /// <summary>Get a release environment.</summary>
        /// <param name="project">- Project ID or project name</param>
        /// <param name="releaseId">- Id of the release.</param>
        /// <param name="environmentId">- Id of the release environment.</param>
        abstract getReleaseEnvironment: project: string * releaseId: float * environmentId: float -> Promise<Release.ReleaseEnvironment>
        /// <summary>Update the status of a release environment</summary>
        /// <param name="environmentUpdateData">- Environment update meta data.</param>
        /// <param name="project">- Project ID or project name</param>
        /// <param name="releaseId">- Id of the release.</param>
        /// <param name="environmentId">- Id of release environment.</param>
        abstract updateReleaseEnvironment: environmentUpdateData: Release.ReleaseEnvironmentUpdateMetadata * project: string * releaseId: float * environmentId: float -> Promise<Release.ReleaseEnvironment>
        /// <summary>Creates a definition environment template</summary>
        /// <param name="template">- Definition environment template to create</param>
        /// <param name="project">- Project ID or project name</param>
        abstract createDefinitionEnvironmentTemplate: template: Release.ReleaseDefinitionEnvironmentTemplate * project: string -> Promise<Release.ReleaseDefinitionEnvironmentTemplate>
        /// <summary>Delete a definition environment template</summary>
        /// <param name="project">- Project ID or project name</param>
        /// <param name="templateId">- Id of the definition environment template</param>
        abstract deleteDefinitionEnvironmentTemplate: project: string * templateId: string -> Promise<unit>
        /// <summary>Gets a definition environment template</summary>
        /// <param name="project">- Project ID or project name</param>
        /// <param name="templateId">- Id of the definition environment template</param>
        abstract getDefinitionEnvironmentTemplate: project: string * templateId: string -> Promise<Release.ReleaseDefinitionEnvironmentTemplate>
        /// <summary>Gets a list of definition environment templates</summary>
        /// <param name="project">- Project ID or project name</param>
        /// <param name="isDeleted">- 'true' to get definition environment templates that have been deleted. Default is 'false'</param>
        abstract listDefinitionEnvironmentTemplates: project: string * ?isDeleted: bool -> Promise<ResizeArray<Release.ReleaseDefinitionEnvironmentTemplate>>
        /// <summary>Undelete a release definition environment template.</summary>
        /// <param name="project">- Project ID or project name</param>
        /// <param name="templateId">- Id of the definition environment template to be undeleted</param>
        abstract undeleteReleaseDefinitionEnvironmentTemplate: project: string * templateId: string -> Promise<Release.ReleaseDefinitionEnvironmentTemplate>
        /// <param name="favoriteItems">-</param>
        /// <param name="project">- Project ID or project name</param>
        /// <param name="scope">-</param>
        /// <param name="identityId">-</param>
        abstract createFavorites: favoriteItems: ResizeArray<Release.FavoriteItem> * project: string * scope: string * ?identityId: string -> Promise<ResizeArray<Release.FavoriteItem>>
        /// <param name="project">- Project ID or project name</param>
        /// <param name="scope">-</param>
        /// <param name="identityId">-</param>
        /// <param name="favoriteItemIds">-</param>
        abstract deleteFavorites: project: string * scope: string * ?identityId: string * ?favoriteItemIds: string -> Promise<unit>
        /// <param name="project">- Project ID or project name</param>
        /// <param name="scope">-</param>
        /// <param name="identityId">-</param>
        abstract getFavorites: project: string * scope: string * ?identityId: string -> Promise<ResizeArray<Release.FavoriteItem>>
        /// <param name="flightName">-</param>
        abstract getFlightAssignments: ?flightName: string -> Promise<ResizeArray<string>>
        /// <summary>Creates a new folder.</summary>
        /// <param name="folder">- folder.</param>
        /// <param name="project">- Project ID or project name</param>
        /// <param name="path">- Path of the folder.</param>
        abstract createFolder: folder: Release.Folder * project: string * ?path: string -> Promise<Release.Folder>
        /// <summary>Deletes a definition folder for given folder name and path and all it's existing definitions.</summary>
        /// <param name="project">- Project ID or project name</param>
        /// <param name="path">- Path of the folder to delete.</param>
        abstract deleteFolder: project: string * path: string -> Promise<unit>
        /// <summary>Gets folders.</summary>
        /// <param name="project">- Project ID or project name</param>
        /// <param name="path">- Path of the folder.</param>
        /// <param name="queryOrder">- Gets the results in the defined order. Default is 'None'.</param>
        abstract getFolders: project: string * ?path: string * ?queryOrder: Release.FolderPathQueryOrder -> Promise<ResizeArray<Release.Folder>>
        /// <summary>Updates an existing folder at given existing path.</summary>
        /// <param name="folder">- folder.</param>
        /// <param name="project">- Project ID or project name</param>
        /// <param name="path">- Path of the folder to update.</param>
        abstract updateFolder: folder: Release.Folder * project: string * path: string -> Promise<Release.Folder>
        /// <summary>Updates the gate for a deployment.</summary>
        /// <param name="gateUpdateMetadata">- Metadata to patch the Release Gates.</param>
        /// <param name="project">- Project ID or project name</param>
        /// <param name="gateStepId">- Gate step Id.</param>
        abstract updateGates: gateUpdateMetadata: Release.GateUpdateMetadata * project: string * gateStepId: float -> Promise<Release.ReleaseGates>
        /// <param name="project">- Project ID or project name</param>
        /// <param name="releaseId">-</param>
        abstract getReleaseHistory: project: string * releaseId: float -> Promise<ResizeArray<Release.ReleaseRevision>>
        /// <param name="query">-</param>
        /// <param name="project">- Project ID or project name</param>
        abstract getInputValues: query: FormInput.InputValuesQuery * project: string -> Promise<FormInput.InputValuesQuery>
        /// <param name="project">- Project ID or project name</param>
        /// <param name="buildId">-</param>
        /// <param name="sourceId">-</param>
        abstract getIssues: project: string * buildId: float * ?sourceId: string -> Promise<ResizeArray<Release.AutoTriggerIssue>>
        /// <summary>Gets gate logs</summary>
        /// <param name="project">- Project ID or project name</param>
        /// <param name="releaseId">- Id of the release.</param>
        /// <param name="environmentId">- Id of release environment.</param>
        /// <param name="gateId">- Id of the gate.</param>
        /// <param name="taskId">- ReleaseTask Id for the log.</param>
        abstract getGateLog: project: string * releaseId: float * environmentId: float * gateId: float * taskId: float -> Promise<string>
        /// <summary>Get logs for a release Id.</summary>
        /// <param name="project">- Project ID or project name</param>
        /// <param name="releaseId">- Id of the release.</param>
        abstract getLogs: project: string * releaseId: float -> Promise<ArrayBuffer>
        /// <summary>Gets logs</summary>
        /// <param name="project">- Project ID or project name</param>
        /// <param name="releaseId">- Id of the release.</param>
        /// <param name="environmentId">- Id of release environment.</param>
        /// <param name="taskId">- ReleaseTask Id for the log.</param>
        /// <param name="attemptId">- Id of the attempt.</param>
        abstract getLog: project: string * releaseId: float * environmentId: float * taskId: float * ?attemptId: float -> Promise<string>
        /// <summary>Gets the task log of a release as a plain text file.</summary>
        /// <param name="project">- Project ID or project name</param>
        /// <param name="releaseId">- Id of the release.</param>
        /// <param name="environmentId">- Id of release environment.</param>
        /// <param name="attemptId">-</param>
        /// <param name="timelineId">-</param>
        /// <param name="taskId">- ReleaseTask Id for the log.</param>
        /// <param name="startLine">- Starting line number for logs</param>
        /// <param name="endLine">- Ending line number for logs</param>
        abstract getTaskLog2: project: string * releaseId: float * environmentId: float * attemptId: float * timelineId: string * taskId: float * ?startLine: float * ?endLine: float -> Promise<string>
        /// <summary>Gets the task log of a release as a plain text file.</summary>
        /// <param name="project">- Project ID or project name</param>
        /// <param name="releaseId">- Id of the release.</param>
        /// <param name="environmentId">- Id of release environment.</param>
        /// <param name="releaseDeployPhaseId">- Release deploy phase Id.</param>
        /// <param name="taskId">- ReleaseTask Id for the log.</param>
        /// <param name="startLine">- Starting line number for logs</param>
        /// <param name="endLine">- Ending line number for logs</param>
        abstract getTaskLog: project: string * releaseId: float * environmentId: float * releaseDeployPhaseId: float * taskId: float * ?startLine: float * ?endLine: float -> Promise<string>
        /// <summary>Get manual intervention for a given release and manual intervention id.</summary>
        /// <param name="project">- Project ID or project name</param>
        /// <param name="releaseId">- Id of the release.</param>
        /// <param name="manualInterventionId">- Id of the manual intervention.</param>
        abstract getManualIntervention: project: string * releaseId: float * manualInterventionId: float -> Promise<Release.ManualIntervention>
        /// <summary>List all manual interventions for a given release.</summary>
        /// <param name="project">- Project ID or project name</param>
        /// <param name="releaseId">- Id of the release.</param>
        abstract getManualInterventions: project: string * releaseId: float -> Promise<ResizeArray<Release.ManualIntervention>>
        /// <summary>Update manual intervention.</summary>
        /// <param name="manualInterventionUpdateMetadata">- Meta data to update manual intervention.</param>
        /// <param name="project">- Project ID or project name</param>
        /// <param name="releaseId">- Id of the release.</param>
        /// <param name="manualInterventionId">- Id of the manual intervention.</param>
        abstract updateManualIntervention: manualInterventionUpdateMetadata: Release.ManualInterventionUpdateMetadata * project: string * releaseId: float * manualInterventionId: float -> Promise<Release.ManualIntervention>
        /// <param name="project">- Project ID or project name</param>
        /// <param name="minMetricsTime">-</param>
        abstract getMetrics: project: string * ?minMetricsTime: DateTime -> Promise<ResizeArray<Release.Metric>>
        /// <param name="artifactType">-</param>
        /// <param name="artifactSourceId">-</param>
        abstract getReleaseProjects: artifactType: string * artifactSourceId: string -> Promise<ResizeArray<Release.ProjectReference>>
        /// <summary>Get a list of releases</summary>
        /// <param name="project">- Project ID or project name</param>
        /// <param name="definitionId">- Releases from this release definition Id.</param>
        /// <param name="definitionEnvironmentId">-</param>
        /// <param name="searchText">- Releases with names containing searchText.</param>
        /// <param name="createdBy">- Releases created by this user.</param>
        /// <param name="statusFilter">- Releases that have this status.</param>
        /// <param name="environmentStatusFilter">-</param>
        /// <param name="minCreatedTime">- Releases that were created after this time.</param>
        /// <param name="maxCreatedTime">- Releases that were created before this time.</param>
        /// <param name="queryOrder">- Gets the results in the defined order of created date for releases. Default is descending.</param>
        /// <param name="top">- Number of releases to get. Default is 50.</param>
        /// <param name="continuationToken">- Gets the releases after the continuation token provided.</param>
        /// <param name="expand">- The property that should be expanded in the list of releases.</param>
        /// <param name="artifactTypeId">- Releases with given artifactTypeId will be returned. Values can be Build, Jenkins, GitHub, Nuget, Team Build (external), ExternalTFSBuild, Git, TFVC, ExternalTfsXamlBuild.</param>
        /// <param name="sourceId">- Unique identifier of the artifact used. e.g. For build it would be \{projectGuid\}:\{BuildDefinitionId\}, for Jenkins it would be \{JenkinsConnectionId\}:\{JenkinsDefinitionId\}, for TfsOnPrem it would be \{TfsOnPremConnectionId\}:\{ProjectName\}:\{TfsOnPremDefinitionId\}. For third-party artifacts e.g. TeamCity, BitBucket you may refer 'uniqueSourceIdentifier' inside vss-extension.json https://github.com/Microsoft/vsts-rm-extensions/blob/master/Extensions.</param>
        /// <param name="artifactVersionId">- Releases with given artifactVersionId will be returned. E.g. in case of Build artifactType, it is buildId.</param>
        /// <param name="sourceBranchFilter">- Releases with given sourceBranchFilter will be returned.</param>
        /// <param name="isDeleted">- Gets the soft deleted releases, if true.</param>
        /// <param name="tagFilter">- A comma-delimited list of tags. Only releases with these tags will be returned.</param>
        /// <param name="propertyFilters">- A comma-delimited list of extended properties to be retrieved. If set, the returned Releases will contain values for the specified property Ids (if they exist). If not set, properties will not be included. Note that this will not filter out any Release from results irrespective of whether it has property set or not.</param>
        /// <param name="releaseIdFilter">- A comma-delimited list of releases Ids. Only releases with these Ids will be returned.</param>
        /// <param name="path">- Releases under this folder path will be returned</param>
        abstract getReleases: ?project: string * ?definitionId: float * ?definitionEnvironmentId: float * ?searchText: string * ?createdBy: string * ?statusFilter: Release.ReleaseStatus * ?environmentStatusFilter: float * ?minCreatedTime: DateTime * ?maxCreatedTime: DateTime * ?queryOrder: Release.ReleaseQueryOrder * ?top: float * ?continuationToken: float * ?expand: Release.ReleaseExpands * ?artifactTypeId: string * ?sourceId: string * ?artifactVersionId: string * ?sourceBranchFilter: string * ?isDeleted: bool * ?tagFilter: ResizeArray<string> * ?propertyFilters: ResizeArray<string> * ?releaseIdFilter: ResizeArray<float> * ?path: string -> Promise<ResizeArray<Release.Release>>
        /// <summary>Create a release.</summary>
        /// <param name="releaseStartMetadata">- Metadata to create a release.</param>
        /// <param name="project">- Project ID or project name</param>
        abstract createRelease: releaseStartMetadata: Release.ReleaseStartMetadata * project: string -> Promise<Release.Release>
        /// <summary>Soft delete a release</summary>
        /// <param name="project">- Project ID or project name</param>
        /// <param name="releaseId">- Id of the release.</param>
        /// <param name="comment">- Comment for deleting a release.</param>
        abstract deleteRelease: project: string * releaseId: float * ?comment: string -> Promise<unit>
        /// <summary>Get a Release</summary>
        /// <param name="project">- Project ID or project name</param>
        /// <param name="releaseId">- Id of the release.</param>
        /// <param name="approvalFilters">- A filter which would allow fetching approval steps selectively based on whether it is automated, or manual. This would also decide whether we should fetch pre and post approval snapshots. Assumes All by default</param>
        /// <param name="propertyFilters">- A comma-delimited list of extended properties to be retrieved. If set, the returned Release will contain values for the specified property Ids (if they exist). If not set, properties will not be included.</param>
        /// <param name="expand">- A property that should be expanded in the release.</param>
        /// <param name="topGateRecords">- Number of release gate records to get. Default is 5.</param>
        abstract getRelease: project: string * releaseId: float * ?approvalFilters: Release.ApprovalFilters * ?propertyFilters: ResizeArray<string> * ?expand: Release.SingleReleaseExpands * ?topGateRecords: float -> Promise<Release.Release>
        /// <summary>Get release summary of a given definition Id.</summary>
        /// <param name="project">- Project ID or project name</param>
        /// <param name="definitionId">- Id of the definition to get release summary.</param>
        /// <param name="releaseCount">- Count of releases to be included in summary.</param>
        /// <param name="includeArtifact">- Include artifact details.Default is 'false'.</param>
        /// <param name="definitionEnvironmentIdsFilter">-</param>
        abstract getReleaseDefinitionSummary: project: string * definitionId: float * releaseCount: float * ?includeArtifact: bool * ?definitionEnvironmentIdsFilter: ResizeArray<float> -> Promise<Release.ReleaseDefinitionSummary>
        /// <summary>Get release for a given revision number.</summary>
        /// <param name="project">- Project ID or project name</param>
        /// <param name="releaseId">- Id of the release.</param>
        /// <param name="definitionSnapshotRevision">- Definition snapshot revision number.</param>
        abstract getReleaseRevision: project: string * releaseId: float * definitionSnapshotRevision: float -> Promise<string>
        /// <summary>Undelete a soft deleted release.</summary>
        /// <param name="project">- Project ID or project name</param>
        /// <param name="releaseId">- Id of release to be undeleted.</param>
        /// <param name="comment">- Any comment for undeleting.</param>
        abstract undeleteRelease: project: string * releaseId: float * comment: string -> Promise<unit>
        /// <summary>Update a complete release object.</summary>
        /// <param name="release">- Release object for update.</param>
        /// <param name="project">- Project ID or project name</param>
        /// <param name="releaseId">- Id of the release to update.</param>
        abstract updateRelease: release: Release.Release * project: string * releaseId: float -> Promise<Release.Release>
        /// <summary>Update few properties of a release.</summary>
        /// <param name="releaseUpdateMetadata">- Properties of release to update.</param>
        /// <param name="project">- Project ID or project name</param>
        /// <param name="releaseId">- Id of the release to update.</param>
        abstract updateReleaseResource: releaseUpdateMetadata: Release.ReleaseUpdateMetadata * project: string * releaseId: float -> Promise<Release.Release>
        /// <summary>Gets the release settings</summary>
        /// <param name="project">- Project ID or project name</param>
        abstract getReleaseSettings: project: string -> Promise<Release.ReleaseSettings>
        /// <summary>Updates the release settings</summary>
        /// <param name="releaseSettings">-</param>
        /// <param name="project">- Project ID or project name</param>
        abstract updateReleaseSettings: releaseSettings: Release.ReleaseSettings * project: string -> Promise<Release.ReleaseSettings>
        /// <summary>Get release definition for a given definitionId and revision</summary>
        /// <param name="project">- Project ID or project name</param>
        /// <param name="definitionId">- Id of the definition.</param>
        /// <param name="revision">- Id of the revision.</param>
        abstract getDefinitionRevision: project: string * definitionId: float * revision: float -> Promise<string>
        /// <summary>Get revision history for a release definition</summary>
        /// <param name="project">- Project ID or project name</param>
        /// <param name="definitionId">- Id of the definition.</param>
        abstract getReleaseDefinitionHistory: project: string * definitionId: float -> Promise<ResizeArray<Release.ReleaseDefinitionRevision>>
        /// <param name="project">- Project ID or project name</param>
        /// <param name="releaseId">-</param>
        abstract getSummaryMailSections: project: string * releaseId: float -> Promise<ResizeArray<Release.SummaryMailSection>>
        /// <param name="mailMessage">-</param>
        /// <param name="project">- Project ID or project name</param>
        /// <param name="releaseId">-</param>
        abstract sendSummaryMail: mailMessage: Release.MailMessage * project: string * releaseId: float -> Promise<unit>
        /// <param name="project">- Project ID or project name</param>
        /// <param name="definitionId">-</param>
        abstract getSourceBranches: project: string * definitionId: float -> Promise<ResizeArray<string>>
        /// <summary>Adds a tag to a definition</summary>
        /// <param name="project">- Project ID or project name</param>
        /// <param name="releaseDefinitionId">-</param>
        /// <param name="tag">-</param>
        abstract addDefinitionTag: project: string * releaseDefinitionId: float * tag: string -> Promise<ResizeArray<string>>
        /// <summary>Adds multiple tags to a definition</summary>
        /// <param name="tags">-</param>
        /// <param name="project">- Project ID or project name</param>
        /// <param name="releaseDefinitionId">-</param>
        abstract addDefinitionTags: tags: ResizeArray<string> * project: string * releaseDefinitionId: float -> Promise<ResizeArray<string>>
        /// <summary>Deletes a tag from a definition</summary>
        /// <param name="project">- Project ID or project name</param>
        /// <param name="releaseDefinitionId">-</param>
        /// <param name="tag">-</param>
        abstract deleteDefinitionTag: project: string * releaseDefinitionId: float * tag: string -> Promise<ResizeArray<string>>
        /// <summary>Gets the tags for a definition</summary>
        /// <param name="project">- Project ID or project name</param>
        /// <param name="releaseDefinitionId">-</param>
        abstract getDefinitionTags: project: string * releaseDefinitionId: float -> Promise<ResizeArray<string>>
        /// <summary>Adds a tag to a releaseId</summary>
        /// <param name="project">- Project ID or project name</param>
        /// <param name="releaseId">-</param>
        /// <param name="tag">-</param>
        abstract addReleaseTag: project: string * releaseId: float * tag: string -> Promise<ResizeArray<string>>
        /// <summary>Adds tag to a release</summary>
        /// <param name="tags">-</param>
        /// <param name="project">- Project ID or project name</param>
        /// <param name="releaseId">-</param>
        abstract addReleaseTags: tags: ResizeArray<string> * project: string * releaseId: float -> Promise<ResizeArray<string>>
        /// <summary>Deletes a tag from a release</summary>
        /// <param name="project">- Project ID or project name</param>
        /// <param name="releaseId">-</param>
        /// <param name="tag">-</param>
        abstract deleteReleaseTag: project: string * releaseId: float * tag: string -> Promise<ResizeArray<string>>
        /// <summary>Gets the tags for a release</summary>
        /// <param name="project">- Project ID or project name</param>
        /// <param name="releaseId">-</param>
        abstract getReleaseTags: project: string * releaseId: float -> Promise<ResizeArray<string>>
        /// <param name="project">- Project ID or project name</param>
        abstract getTags: project: string -> Promise<ResizeArray<string>>
        /// <param name="project">- Project ID or project name</param>
        /// <param name="releaseId">-</param>
        /// <param name="environmentId">-</param>
        /// <param name="releaseDeployPhaseId">-</param>
        abstract getTasksForTaskGroup: project: string * releaseId: float * environmentId: float * releaseDeployPhaseId: float -> Promise<ResizeArray<Release.ReleaseTask>>
        /// <param name="project">- Project ID or project name</param>
        /// <param name="releaseId">-</param>
        /// <param name="environmentId">-</param>
        /// <param name="attemptId">-</param>
        /// <param name="timelineId">-</param>
        abstract getTasks2: project: string * releaseId: float * environmentId: float * attemptId: float * timelineId: string -> Promise<ResizeArray<Release.ReleaseTask>>
        /// <param name="project">- Project ID or project name</param>
        /// <param name="releaseId">-</param>
        /// <param name="environmentId">-</param>
        /// <param name="attemptId">-</param>
        abstract getTasks: project: string * releaseId: float * environmentId: float * ?attemptId: float -> Promise<ResizeArray<Release.ReleaseTask>>
        /// <param name="project">- Project ID or project name</param>
        abstract getArtifactTypeDefinitions: project: string -> Promise<ResizeArray<Release.ArtifactTypeDefinition>>
        /// <param name="project">- Project ID or project name</param>
        /// <param name="releaseDefinitionId">-</param>
        abstract getArtifactVersions: project: string * releaseDefinitionId: float -> Promise<Release.ArtifactVersionQueryResult>
        /// <param name="artifacts">-</param>
        /// <param name="project">- Project ID or project name</param>
        abstract getArtifactVersionsForSources: artifacts: ResizeArray<Release.Artifact> * project: string -> Promise<Release.ArtifactVersionQueryResult>
        /// <param name="project">- Project ID or project name</param>
        /// <param name="releaseId">-</param>
        /// <param name="baseReleaseId">-</param>
        /// <param name="top">-</param>
        /// <param name="artifactAlias">-</param>
        abstract getReleaseWorkItemsRefs: project: string * releaseId: float * ?baseReleaseId: float * ?top: float * ?artifactAlias: string -> Promise<ResizeArray<Release.ReleaseWorkItemRef>>

    type [<AllowNullLiteral>] ReleaseRestClientStatic =
        [<Emit "new $0($1...)">] abstract Create: options: IVssRestClientOptions -> ReleaseRestClient
        abstract RESOURCE_AREA_ID: string
