// ts2fable 0.7.1
module rec BuildClient
open System
open Fable.Core
open Fable.Core.JS


type IVssRestClientOptions = Context.IVssRestClientOptions
type RestClientBase = RestClientBase.RestClientBase

type [<AllowNullLiteral>] IExports =
    abstract BuildRestClient: BuildRestClientStatic

type [<AllowNullLiteral>] BuildRestClient =
    inherit RestClientBase
    /// <summary>Associates an artifact with a build.</summary>
    /// <param name="artifact">- The artifact.</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="buildId">- The ID of the build.</param>
    abstract createArtifact: artifact: Build.BuildArtifact * project: string * buildId: int -> Promise<Build.BuildArtifact>
    /// <summary>Gets a specific artifact for a build.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="buildId">- The ID of the build.</param>
    /// <param name="artifactName">- The name of the artifact.</param>
    abstract getArtifact: project: string * buildId: int * artifactName: string -> Promise<Build.BuildArtifact>
    /// <summary>Gets a specific artifact for a build.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="buildId">- The ID of the build.</param>
    /// <param name="artifactName">- The name of the artifact.</param>
    abstract getArtifactContentZip: project: string * buildId: int * artifactName: string -> Promise<ArrayBuffer>
    /// <summary>Gets all artifacts for a build.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="buildId">- The ID of the build.</param>
    abstract getArtifacts: project: string * buildId: int -> Promise<ResizeArray<Build.BuildArtifact>>
    /// <summary>Gets a file from the build.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="buildId">- The ID of the build.</param>
    /// <param name="artifactName">- The name of the artifact.</param>
    /// <param name="fileId">- The primary key for the file.</param>
    /// <param name="fileName">- The name that the file will be set to.</param>
    abstract getFile: project: string * buildId: int * artifactName: string * fileId: string * fileName: string -> Promise<ArrayBuffer>
    /// <summary>Gets the list of attachments of a specific type that are associated with a build.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="buildId">- The ID of the build.</param>
    /// <param name="type">- The type of attachment.</param>
    abstract getAttachments: project: string * buildId: int * ``type``: string -> Promise<ResizeArray<Build.Attachment>>
    /// <summary>Gets a specific attachment.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="buildId">- The ID of the build.</param>
    /// <param name="timelineId">- The ID of the timeline.</param>
    /// <param name="recordId">- The ID of the timeline record.</param>
    /// <param name="type">- The type of the attachment.</param>
    /// <param name="name">- The name of the attachment.</param>
    abstract getAttachment: project: string * buildId: int * timelineId: string * recordId: string * ``type``: string * name: string -> Promise<ArrayBuffer>
    /// <param name="resources">-</param>
    /// <param name="project">- Project ID or project name</param>
    abstract authorizeProjectResources: resources: ResizeArray<Build.DefinitionResourceReference> * project: string -> Promise<ResizeArray<Build.DefinitionResourceReference>>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="type">-</param>
    /// <param name="id">-</param>
    abstract getProjectResources: project: string * ?``type``: string * ?id: string -> Promise<ResizeArray<Build.DefinitionResourceReference>>
    /// <summary>Gets a badge that indicates the status of the most recent build for a definition. Note that this API is deprecated. Prefer StatusBadgeController.GetStatusBadge.</summary>
    /// <param name="project">- The project ID or name.</param>
    /// <param name="definitionId">- The ID of the definition.</param>
    /// <param name="branchName">- The name of the branch.</param>
    abstract getBadge: project: string * definitionId: int * ?branchName: string -> Promise<string>
    /// <summary>Gets a list of branches for the given source code repository.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="providerName">- The name of the source provider.</param>
    /// <param name="serviceEndpointId">- If specified, the ID of the service endpoint to query. Can only be omitted for providers that do not use service endpoints, e.g. TFVC or TFGit.</param>
    /// <param name="repository">- The vendor-specific identifier or the name of the repository to get branches. Can only be omitted for providers that do not support multiple repositories.</param>
    /// <param name="branchName">- If supplied, the name of the branch to check for specifically.</param>
    abstract listBranches: project: string * providerName: string * ?serviceEndpointId: string * ?repository: string * ?branchName: string -> Promise<ResizeArray<string>>
    /// <summary>Gets a badge that indicates the status of the most recent build for the specified branch.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="repoType">- The repository type.</param>
    /// <param name="repoId">- The repository ID.</param>
    /// <param name="branchName">- The branch name.</param>
    abstract getBuildBadge: project: string * repoType: string * ?repoId: string * ?branchName: string -> Promise<Build.BuildBadge>
    /// <summary>Gets a badge that indicates the status of the most recent build for the specified branch.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="repoType">- The repository type.</param>
    /// <param name="repoId">- The repository ID.</param>
    /// <param name="branchName">- The branch name.</param>
    abstract getBuildBadgeData: project: string * repoType: string * ?repoId: string * ?branchName: string -> Promise<string>
    /// <summary>Deletes a build.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="buildId">- The ID of the build.</param>
    abstract deleteBuild: project: string * buildId: int -> Promise<unit>
    /// <summary>Gets a build</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="buildId">-</param>
    /// <param name="propertyFilters">-</param>
    abstract getBuild: project: string * buildId: int * ?propertyFilters: string -> Promise<Build.Build>
    /// <summary>Gets a list of builds.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="definitions">- A comma-delimited list of definition IDs. If specified, filters to builds for these definitions.</param>
    /// <param name="queues">- A comma-delimited list of queue IDs. If specified, filters to builds that ran against these queues.</param>
    /// <param name="buildNumber">- If specified, filters to builds that match this build number. Append * to do a prefix search.</param>
    /// <param name="minTime">- If specified, filters to builds that finished/started/queued after this date based on the queryOrder specified.</param>
    /// <param name="maxTime">- If specified, filters to builds that finished/started/queued before this date based on the queryOrder specified.</param>
    /// <param name="requestedFor">- If specified, filters to builds requested for the specified user.</param>
    /// <param name="reasonFilter">- If specified, filters to builds that match this reason.</param>
    /// <param name="statusFilter">- If specified, filters to builds that match this status.</param>
    /// <param name="resultFilter">- If specified, filters to builds that match this result.</param>
    /// <param name="tagFilters">- A comma-delimited list of tags. If specified, filters to builds that have the specified tags.</param>
    /// <param name="properties">- A comma-delimited list of properties to retrieve.</param>
    /// <param name="top">- The maximum number of builds to return.</param>
    /// <param name="continuationToken">- A continuation token, returned by a previous call to this method, that can be used to return the next set of builds.</param>
    /// <param name="maxBuildsPerDefinition">- The maximum number of builds to return per definition.</param>
    /// <param name="deletedFilter">- Indicates whether to exclude, include, or only return deleted builds.</param>
    /// <param name="queryOrder">- The order in which builds should be returned.</param>
    /// <param name="branchName">- If specified, filters to builds that built branches that built this branch.</param>
    /// <param name="buildIds">- A comma-delimited list that specifies the IDs of builds to retrieve.</param>
    /// <param name="repositoryId">- If specified, filters to builds that built from this repository.</param>
    /// <param name="repositoryType">- If specified, filters to builds that built from repositories of this type.</param>
    abstract getBuilds: project: string * ?definitions: ResizeArray<float> * ?queues: ResizeArray<float> * ?buildNumber: string * ?minTime: DateTime * ?maxTime: DateTime * ?requestedFor: string * ?reasonFilter: Build.BuildReason * ?statusFilter: Build.BuildStatus * ?resultFilter: Build.BuildResult * ?tagFilters: ResizeArray<string> * ?properties: ResizeArray<string> * ?top: int * ?continuationToken: string * ?maxBuildsPerDefinition: int * ?deletedFilter: Build.QueryDeletedOption * ?queryOrder: Build.BuildQueryOrder * ?branchName: string * ?buildIds: ResizeArray<float> * ?repositoryId: string * ?repositoryType: string -> Promise<ResizeArray<Build.Build>>
    /// <summary>Queues a build</summary>
    /// <param name="build">-</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="ignoreWarnings">-</param>
    /// <param name="checkInTicket">-</param>
    /// <param name="sourceBuildId">-</param>
    abstract queueBuild: build: Build.Build * project: string * ?ignoreWarnings: bool * ?checkInTicket: string * ?sourceBuildId: int -> Promise<Build.Build>
    /// <summary>Updates a build.</summary>
    /// <param name="build">- The build.</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="buildId">- The ID of the build.</param>
    /// <param name="retry">-</param>
    abstract updateBuild: build: Build.Build * project: string * buildId: int * ?retry: bool -> Promise<Build.Build>
    /// <summary>Updates multiple builds.</summary>
    /// <param name="builds">- The builds to update.</param>
    /// <param name="project">- Project ID or project name</param>
    abstract updateBuilds: builds: ResizeArray<Build.Build> * project: string -> Promise<ResizeArray<Build.Build>>
    /// <summary>Gets the changes associated with a build</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="buildId">-</param>
    /// <param name="continuationToken">-</param>
    /// <param name="top">- The maximum number of changes to return</param>
    /// <param name="includeSourceChange">-</param>
    abstract getBuildChanges: project: string * buildId: int * ?continuationToken: string * ?top: int * ?includeSourceChange: bool -> Promise<ResizeArray<Build.Change>>
    /// <summary>Gets the changes made to the repository between two given builds.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="fromBuildId">- The ID of the first build.</param>
    /// <param name="toBuildId">- The ID of the last build.</param>
    /// <param name="top">- The maximum number of changes to return.</param>
    abstract getChangesBetweenBuilds: project: string * ?fromBuildId: int * ?toBuildId: int * ?top: int -> Promise<ResizeArray<Build.Change>>
    /// <summary>Gets a controller</summary>
    /// <param name="controllerId">-</param>
    abstract getBuildController: controllerId: int -> Promise<Build.BuildController>
    /// <summary>Gets controller, optionally filtered by name</summary>
    /// <param name="name">-</param>
    abstract getBuildControllers: ?name: string -> Promise<ResizeArray<Build.BuildController>>
    /// <summary>Creates a new definition.</summary>
    /// <param name="definition">- The definition.</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="definitionToCloneId">-</param>
    /// <param name="definitionToCloneRevision">-</param>
    abstract createDefinition: definition: Build.BuildDefinition * project: string * ?definitionToCloneId: int * ?definitionToCloneRevision: int -> Promise<Build.BuildDefinition>
    /// <summary>Deletes a definition and all associated builds.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="definitionId">- The ID of the definition.</param>
    abstract deleteDefinition: project: string * definitionId: int -> Promise<unit>
    /// <summary>Gets a definition, optionally at a specific revision.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="definitionId">- The ID of the definition.</param>
    /// <param name="revision">- The revision number to retrieve. If this is not specified, the latest version will be returned.</param>
    /// <param name="minMetricsTime">- If specified, indicates the date from which metrics should be included.</param>
    /// <param name="propertyFilters">- A comma-delimited list of properties to include in the results.</param>
    /// <param name="includeLatestBuilds">-</param>
    abstract getDefinition: project: string * definitionId: int * ?revision: int * ?minMetricsTime: DateTime * ?propertyFilters: ResizeArray<string> * ?includeLatestBuilds: bool -> Promise<Build.BuildDefinition>
    /// <summary>Gets a list of definitions.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="name">- If specified, filters to definitions whose names match this pattern.</param>
    /// <param name="repositoryId">- A repository ID. If specified, filters to definitions that use this repository.</param>
    /// <param name="repositoryType">- If specified, filters to definitions that have a repository of this type.</param>
    /// <param name="queryOrder">- Indicates the order in which definitions should be returned.</param>
    /// <param name="top">- The maximum number of definitions to return.</param>
    /// <param name="continuationToken">- A continuation token, returned by a previous call to this method, that can be used to return the next set of definitions.</param>
    /// <param name="minMetricsTime">- If specified, indicates the date from which metrics should be included.</param>
    /// <param name="definitionIds">- A comma-delimited list that specifies the IDs of definitions to retrieve.</param>
    /// <param name="path">- If specified, filters to definitions under this folder.</param>
    /// <param name="builtAfter">- If specified, filters to definitions that have builds after this date.</param>
    /// <param name="notBuiltAfter">- If specified, filters to definitions that do not have builds after this date.</param>
    /// <param name="includeAllProperties">- Indicates whether the full definitions should be returned. By default, shallow representations of the definitions are returned.</param>
    /// <param name="includeLatestBuilds">- Indicates whether to return the latest and latest completed builds for this definition.</param>
    /// <param name="taskIdFilter">- If specified, filters to definitions that use the specified task.</param>
    /// <param name="processType">- If specified, filters to definitions with the given process type.</param>
    /// <param name="yamlFilename">- If specified, filters to YAML definitions that match the given filename.</param>
    abstract getDefinitions: project: string * ?name: string * ?repositoryId: string * ?repositoryType: string * ?queryOrder: Build.DefinitionQueryOrder * ?top: int * ?continuationToken: string * ?minMetricsTime: DateTime * ?definitionIds: ResizeArray<float> * ?path: string * ?builtAfter: DateTime * ?notBuiltAfter: DateTime * ?includeAllProperties: bool * ?includeLatestBuilds: bool * ?taskIdFilter: string * ?processType: int * ?yamlFilename: string -> Promise<ResizeArray<Build.BuildDefinitionReference>>
    /// <summary>Restores a deleted definition</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="definitionId">- The identifier of the definition to restore.</param>
    /// <param name="deleted">- When false, restores a deleted definition.</param>
    abstract restoreDefinition: project: string * definitionId: int * deleted: bool -> Promise<Build.BuildDefinition>
    /// <summary>Updates an existing definition.</summary>
    /// <param name="definition">- The new version of the defintion.</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="definitionId">- The ID of the definition.</param>
    /// <param name="secretsSourceDefinitionId">-</param>
    /// <param name="secretsSourceDefinitionRevision">-</param>
    abstract updateDefinition: definition: Build.BuildDefinition * project: string * definitionId: int * ?secretsSourceDefinitionId: int * ?secretsSourceDefinitionRevision: int -> Promise<Build.BuildDefinition>
    /// <summary>Gets the contents of a file in the given source code repository.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="providerName">- The name of the source provider.</param>
    /// <param name="serviceEndpointId">- If specified, the ID of the service endpoint to query. Can only be omitted for providers that do not use service endpoints, e.g. TFVC or TFGit.</param>
    /// <param name="repository">- If specified, the vendor-specific identifier or the name of the repository to get branches. Can only be omitted for providers that do not support multiple repositories.</param>
    /// <param name="commitOrBranch">- The identifier of the commit or branch from which a file's contents are retrieved.</param>
    /// <param name="path">- The path to the file to retrieve, relative to the root of the repository.</param>
    abstract getFileContents: project: string * providerName: string * ?serviceEndpointId: string * ?repository: string * ?commitOrBranch: string * ?path: string -> Promise<string>
    /// <summary>Creates a new folder.</summary>
    /// <param name="folder">- The folder.</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="path">- The full path of the folder.</param>
    abstract createFolder: folder: Build.Folder * project: string * path: string -> Promise<Build.Folder>
    /// <summary>Deletes a definition folder. Definitions and their corresponding builds will also be deleted.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="path">- The full path to the folder.</param>
    abstract deleteFolder: project: string * path: string -> Promise<unit>
    /// <summary>Gets a list of build definition folders.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="path">- The path to start with.</param>
    /// <param name="queryOrder">- The order in which folders should be returned.</param>
    abstract getFolders: project: string * ?path: string * ?queryOrder: Build.FolderQueryOrder -> Promise<ResizeArray<Build.Folder>>
    /// <summary>Updates an existing folder at given  existing path</summary>
    /// <param name="folder">- The new version of the folder.</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="path">- The full path to the folder.</param>
    abstract updateFolder: folder: Build.Folder * project: string * path: string -> Promise<Build.Folder>
    /// <summary>Gets the latest build for a definition, optionally scoped to a specific branch.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="definition">- definition name with optional leading folder path, or the definition id</param>
    /// <param name="branchName">- optional parameter that indicates the specific branch to use</param>
    abstract getLatestBuild: project: string * definition: string * ?branchName: string -> Promise<Build.Build>
    /// <summary>Gets an individual log file for a build.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="buildId">- The ID of the build.</param>
    /// <param name="logId">- The ID of the log file.</param>
    /// <param name="startLine">- The start line.</param>
    /// <param name="endLine">- The end line.</param>
    abstract getBuildLog: project: string * buildId: int * logId: int * ?startLine: int * ?endLine: int -> Promise<string>
    /// <summary>Gets an individual log file for a build.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="buildId">- The ID of the build.</param>
    /// <param name="logId">- The ID of the log file.</param>
    /// <param name="startLine">- The start line.</param>
    /// <param name="endLine">- The end line.</param>
    abstract getBuildLogLines: project: string * buildId: int * logId: int * ?startLine: int * ?endLine: int -> Promise<ResizeArray<string>>
    /// <summary>Gets the logs for a build.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="buildId">- The ID of the build.</param>
    abstract getBuildLogs: project: string * buildId: int -> Promise<ResizeArray<Build.BuildLog>>
    /// <summary>Gets the logs for a build.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="buildId">- The ID of the build.</param>
    abstract getBuildLogsZip: project: string * buildId: int -> Promise<ArrayBuffer>
    /// <summary>Gets an individual log file for a build.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="buildId">- The ID of the build.</param>
    /// <param name="logId">- The ID of the log file.</param>
    /// <param name="startLine">- The start line.</param>
    /// <param name="endLine">- The end line.</param>
    abstract getBuildLogZip: project: string * buildId: int * logId: int * ?startLine: int * ?endLine: int -> Promise<ArrayBuffer>
    /// <summary>Gets build metrics for a project.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="metricAggregationType">- The aggregation type to use (hourly, daily).</param>
    /// <param name="minMetricsTime">- The date from which to calculate metrics.</param>
    abstract getProjectMetrics: project: string * ?metricAggregationType: string * ?minMetricsTime: DateTime -> Promise<ResizeArray<Build.BuildMetric>>
    /// <summary>Gets build metrics for a definition.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="definitionId">- The ID of the definition.</param>
    /// <param name="minMetricsTime">- The date from which to calculate metrics.</param>
    abstract getDefinitionMetrics: project: string * definitionId: int * ?minMetricsTime: DateTime -> Promise<ResizeArray<Build.BuildMetric>>
    /// <summary>Gets all build definition options supported by the system.</summary>
    /// <param name="project">- Project ID or project name</param>
    abstract getBuildOptionDefinitions: ?project: string -> Promise<ResizeArray<Build.BuildOptionDefinition>>
    /// <summary>Gets the contents of a directory in the given source code repository.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="providerName">- The name of the source provider.</param>
    /// <param name="serviceEndpointId">- If specified, the ID of the service endpoint to query. Can only be omitted for providers that do not use service endpoints, e.g. TFVC or TFGit.</param>
    /// <param name="repository">- If specified, the vendor-specific identifier or the name of the repository to get branches. Can only be omitted for providers that do not support multiple repositories.</param>
    /// <param name="commitOrBranch">- The identifier of the commit or branch from which a file's contents are retrieved.</param>
    /// <param name="path">- The path contents to list, relative to the root of the repository.</param>
    abstract getPathContents: project: string * providerName: string * ?serviceEndpointId: string * ?repository: string * ?commitOrBranch: string * ?path: string -> Promise<ResizeArray<Build.SourceRepositoryItem>>
    /// <summary>Gets properties for a build.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="buildId">- The ID of the build.</param>
    /// <param name="filter">- A comma-delimited list of properties. If specified, filters to these specific properties.</param>
    abstract getBuildProperties: project: string * buildId: int * ?filter: ResizeArray<string> -> Promise<obj option>
    /// <summary>Updates properties for a build.</summary>
    /// <param name="document">- A json-patch document describing the properties to update.</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="buildId">- The ID of the build.</param>
    abstract updateBuildProperties: document: WebApi.JsonPatchDocument * project: string * buildId: int -> Promise<obj option>
    /// <summary>Gets properties for a definition.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="definitionId">- The ID of the definition.</param>
    /// <param name="filter">- A comma-delimited list of properties. If specified, filters to these specific properties.</param>
    abstract getDefinitionProperties: project: string * definitionId: int * ?filter: ResizeArray<string> -> Promise<obj option>
    /// <summary>Updates properties for a definition.</summary>
    /// <param name="document">- A json-patch document describing the properties to update.</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="definitionId">- The ID of the definition.</param>
    abstract updateDefinitionProperties: document: WebApi.JsonPatchDocument * project: string * definitionId: int -> Promise<obj option>
    /// <summary>Gets a pull request object from source provider.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="providerName">- The name of the source provider.</param>
    /// <param name="pullRequestId">- Vendor-specific id of the pull request.</param>
    /// <param name="repositoryId">- Vendor-specific identifier or the name of the repository that contains the pull request.</param>
    /// <param name="serviceEndpointId">- If specified, the ID of the service endpoint to query. Can only be omitted for providers that do not use service endpoints, e.g. TFVC or TFGit.</param>
    abstract getPullRequest: project: string * providerName: string * pullRequestId: string * ?repositoryId: string * ?serviceEndpointId: string -> Promise<Build.PullRequest>
    /// <summary>Gets a build report.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="buildId">- The ID of the build.</param>
    /// <param name="type">-</param>
    abstract getBuildReport: project: string * buildId: int * ?``type``: string -> Promise<Build.BuildReportMetadata>
    /// <summary>Gets a build report.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="buildId">- The ID of the build.</param>
    /// <param name="type">-</param>
    abstract getBuildReportHtmlContent: project: string * buildId: int * ?``type``: string -> Promise<obj option>
    /// <summary>Gets a list of source code repositories.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="providerName">- The name of the source provider.</param>
    /// <param name="serviceEndpointId">- If specified, the ID of the service endpoint to query. Can only be omitted for providers that do not use service endpoints, e.g. TFVC or TFGit.</param>
    /// <param name="repository">- If specified, the vendor-specific identifier or the name of a single repository to get.</param>
    /// <param name="resultSet">- 'top' for the repositories most relevant for the endpoint. If not set, all repositories are returned. Ignored if 'repository' is set.</param>
    /// <param name="pageResults">- If set to true, this will limit the set of results and will return a continuation token to continue the query.</param>
    /// <param name="continuationToken">- When paging results, this is a continuation token, returned by a previous call to this method, that can be used to return the next set of repositories.</param>
    abstract listRepositories: project: string * providerName: string * ?serviceEndpointId: string * ?repository: string * ?resultSet: Build.ResultSet * ?pageResults: bool * ?continuationToken: string -> Promise<Build.SourceRepositories>
    /// <param name="resources">-</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="definitionId">-</param>
    abstract authorizeDefinitionResources: resources: ResizeArray<Build.DefinitionResourceReference> * project: string * definitionId: int -> Promise<ResizeArray<Build.DefinitionResourceReference>>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="definitionId">-</param>
    abstract getDefinitionResources: project: string * definitionId: int -> Promise<ResizeArray<Build.DefinitionResourceReference>>
    /// Gets information about build resources in the system.
    abstract getResourceUsage: unit -> Promise<Build.BuildResourceUsage>
    /// <summary>Gets the project's retention settings.</summary>
    /// <param name="project">- Project ID or project name</param>
    abstract getRetentionSettings: project: string -> Promise<Build.ProjectRetentionSetting>
    /// <summary>Updates the project's retention settings.</summary>
    /// <param name="updateModel">-</param>
    /// <param name="project">- Project ID or project name</param>
    abstract updateRetentionSettings: updateModel: Build.UpdateProjectRetentionSettingModel * project: string -> Promise<Build.ProjectRetentionSetting>
    /// <summary>Gets all revisions of a definition.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="definitionId">- The ID of the definition.</param>
    abstract getDefinitionRevisions: project: string * definitionId: int -> Promise<ResizeArray<Build.BuildDefinitionRevision>>
    /// <summary>Gets the build settings.</summary>
    /// <param name="project">- Project ID or project name</param>
    abstract getBuildSettings: ?project: string -> Promise<Build.BuildSettings>
    /// <summary>Updates the build settings.</summary>
    /// <param name="settings">- The new settings.</param>
    /// <param name="project">- Project ID or project name</param>
    abstract updateBuildSettings: settings: Build.BuildSettings * ?project: string -> Promise<Build.BuildSettings>
    /// <summary>Get a list of source providers and their capabilities.</summary>
    /// <param name="project">- Project ID or project name</param>
    abstract listSourceProviders: project: string -> Promise<ResizeArray<Build.SourceProviderAttributes>>
    /// <summary>Update a build stage</summary>
    /// <param name="updateParameters">-</param>
    /// <param name="buildId">-</param>
    /// <param name="stageRefName">-</param>
    /// <param name="project">- Project ID or project name</param>
    abstract updateStage: updateParameters: Build.UpdateStageParameters * buildId: int * stageRefName: string * ?project: string -> Promise<unit>
    /// <summary>\<p\>Gets the build status for a definition, optionally scoped to a specific branch, stage, job, and configuration.\</p\> \<p\>If there are more than one, then it is required to pass in a stageName value when specifying a jobName, and the same rule then applies for both if passing a configuration parameter.\</p\></summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="definition">- Either the definition name with optional leading folder path, or the definition id.</param>
    /// <param name="branchName">- Only consider the most recent build for this branch.</param>
    /// <param name="stageName">- Use this stage within the pipeline to render the status.</param>
    /// <param name="jobName">- Use this job within a stage of the pipeline to render the status.</param>
    /// <param name="configuration">- Use this job configuration to render the status</param>
    /// <param name="label">- Replaces the default text on the left side of the badge.</param>
    abstract getStatusBadge: project: string * definition: string * ?branchName: string * ?stageName: string * ?jobName: string * ?configuration: string * ?label: string -> Promise<string>
    /// <summary>Adds a tag to a build.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="buildId">- The ID of the build.</param>
    /// <param name="tag">- The tag to add.</param>
    abstract addBuildTag: project: string * buildId: int * tag: string -> Promise<ResizeArray<string>>
    /// <summary>Adds tags to a build.</summary>
    /// <param name="tags">- The tags to add.</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="buildId">- The ID of the build.</param>
    abstract addBuildTags: tags: ResizeArray<string> * project: string * buildId: int -> Promise<ResizeArray<string>>
    /// <summary>Removes a tag from a build.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="buildId">- The ID of the build.</param>
    /// <param name="tag">- The tag to remove.</param>
    abstract deleteBuildTag: project: string * buildId: int * tag: string -> Promise<ResizeArray<string>>
    /// <summary>Gets the tags for a build.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="buildId">- The ID of the build.</param>
    abstract getBuildTags: project: string * buildId: int -> Promise<ResizeArray<string>>
    /// <summary>Adds a tag to a definition</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="definitionId">- The ID of the definition.</param>
    /// <param name="tag">- The tag to add.</param>
    abstract addDefinitionTag: project: string * definitionId: int * tag: string -> Promise<ResizeArray<string>>
    /// <summary>Adds multiple tags to a definition.</summary>
    /// <param name="tags">- The tags to add.</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="definitionId">- The ID of the definition.</param>
    abstract addDefinitionTags: tags: ResizeArray<string> * project: string * definitionId: int -> Promise<ResizeArray<string>>
    /// <summary>Removes a tag from a definition.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="definitionId">- The ID of the definition.</param>
    /// <param name="tag">- The tag to remove.</param>
    abstract deleteDefinitionTag: project: string * definitionId: int * tag: string -> Promise<ResizeArray<string>>
    /// <summary>Gets the tags for a definition.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="definitionId">- The ID of the definition.</param>
    /// <param name="revision">- The definition revision number. If not specified, uses the latest revision of the definition.</param>
    abstract getDefinitionTags: project: string * definitionId: int * ?revision: int -> Promise<ResizeArray<string>>
    /// <summary>Removes a tag from builds, definitions, and from the tag store</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="tag">- The tag to remove.</param>
    abstract deleteTag: project: string * tag: string -> Promise<ResizeArray<string>>
    /// <summary>Gets a list of all build tags in the project.</summary>
    /// <param name="project">- Project ID or project name</param>
    abstract getTags: project: string -> Promise<ResizeArray<string>>
    /// <summary>Deletes a build definition template.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="templateId">- The ID of the template.</param>
    abstract deleteTemplate: project: string * templateId: string -> Promise<unit>
    /// <summary>Gets a specific build definition template.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="templateId">- The ID of the requested template.</param>
    abstract getTemplate: project: string * templateId: string -> Promise<Build.BuildDefinitionTemplate>
    /// <summary>Gets all definition templates.</summary>
    /// <param name="project">- Project ID or project name</param>
    abstract getTemplates: project: string -> Promise<ResizeArray<Build.BuildDefinitionTemplate>>
    /// <summary>Updates an existing build definition template.</summary>
    /// <param name="template">- The new version of the template.</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="templateId">- The ID of the template.</param>
    abstract saveTemplate: template: Build.BuildDefinitionTemplate * project: string * templateId: string -> Promise<Build.BuildDefinitionTemplate>
    /// <summary>Gets details for a build</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="buildId">-</param>
    /// <param name="timelineId">-</param>
    /// <param name="changeId">-</param>
    /// <param name="planId">-</param>
    abstract getBuildTimeline: project: string * buildId: int * ?timelineId: string * ?changeId: int * ?planId: string -> Promise<Build.Timeline>
    /// <summary>Recreates the webhooks for the specified triggers in the given source code repository.</summary>
    /// <param name="triggerTypes">- The types of triggers to restore webhooks for.</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="providerName">- The name of the source provider.</param>
    /// <param name="serviceEndpointId">- If specified, the ID of the service endpoint to query. Can only be omitted for providers that do not use service endpoints, e.g. TFVC or TFGit.</param>
    /// <param name="repository">- If specified, the vendor-specific identifier or the name of the repository to get webhooks. Can only be omitted for providers that do not support multiple repositories.</param>
    abstract restoreWebhooks: triggerTypes: ResizeArray<Build.DefinitionTriggerType> * project: string * providerName: string * ?serviceEndpointId: string * ?repository: string -> Promise<unit>
    /// <summary>Gets a list of webhooks installed in the given source code repository.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="providerName">- The name of the source provider.</param>
    /// <param name="serviceEndpointId">- If specified, the ID of the service endpoint to query. Can only be omitted for providers that do not use service endpoints, e.g. TFVC or TFGit.</param>
    /// <param name="repository">- If specified, the vendor-specific identifier or the name of the repository to get webhooks. Can only be omitted for providers that do not support multiple repositories.</param>
    abstract listWebhooks: project: string * providerName: string * ?serviceEndpointId: string * ?repository: string -> Promise<ResizeArray<Build.RepositoryWebhook>>
    /// <summary>Gets the work items associated with a build.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="buildId">- The ID of the build.</param>
    /// <param name="top">- The maximum number of work items to return.</param>
    abstract getBuildWorkItemsRefs: project: string * buildId: int * ?top: int -> Promise<ResizeArray<WebApi.ResourceRef>>
    /// <summary>Gets the work items associated with a build, filtered to specific commits.</summary>
    /// <param name="commitIds">- A comma-delimited list of commit IDs.</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="buildId">- The ID of the build.</param>
    /// <param name="top">- The maximum number of work items to return, or the number of commits to consider if no commit IDs are specified.</param>
    abstract getBuildWorkItemsRefsFromCommits: commitIds: ResizeArray<string> * project: string * buildId: int * ?top: int -> Promise<ResizeArray<WebApi.ResourceRef>>
    /// <summary>Gets all the work items between two builds.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="fromBuildId">- The ID of the first build.</param>
    /// <param name="toBuildId">- The ID of the last build.</param>
    /// <param name="top">- The maximum number of work items to return.</param>
    abstract getWorkItemsBetweenBuilds: project: string * fromBuildId: int * toBuildId: int * ?top: int -> Promise<ResizeArray<WebApi.ResourceRef>>

type [<AllowNullLiteral>] BuildRestClientStatic =
    [<Emit "new $0($1...)">] abstract Create: options: IVssRestClientOptions -> BuildRestClient
    abstract RESOURCE_AREA_ID: string
