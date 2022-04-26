// ts2fable 0.7.1
module rec CoreClient
open System
open Fable.Core
open Fable.Core.JS

type IVssRestClientOptions = Context.IVssRestClientOptions
type RestClientBase = RestClientBase.RestClientBase

type [<AllowNullLiteral>] IExports =
    abstract CoreRestClient: CoreRestClientStatic

type [<AllowNullLiteral>] CoreRestClient =
    inherit RestClientBase
    /// <summary>Removes the avatar for the project.</summary>
    /// <param name="projectId">- The ID or name of the project.</param>
    abstract removeProjectAvatar: projectId: string -> Promise<unit>
    /// <summary>Sets the avatar for the project.</summary>
    /// <param name="avatarBlob">- The avatar blob data object to upload.</param>
    /// <param name="projectId">- The ID or name of the project.</param>
    abstract setProjectAvatar: avatarBlob: Core.ProjectAvatar * projectId: string -> Promise<unit>
    /// <param name="connectedServiceCreationData">-</param>
    /// <param name="projectId">-</param>
    abstract createConnectedService: connectedServiceCreationData: Core.WebApiConnectedServiceDetails * projectId: string -> Promise<Core.WebApiConnectedService>
    /// <param name="projectId">-</param>
    /// <param name="name">-</param>
    abstract getConnectedServiceDetails: projectId: string * name: string -> Promise<Core.WebApiConnectedServiceDetails>
    /// <param name="projectId">-</param>
    /// <param name="kind">-</param>
    abstract getConnectedServices: projectId: string * ?kind: Core.ConnectedServiceKind -> Promise<ResizeArray<Core.WebApiConnectedService>>
    /// <param name="mruData">-</param>
    /// <param name="mruName">-</param>
    abstract createIdentityMru: mruData: Core.IdentityData * mruName: string -> Promise<unit>
    /// <param name="mruData">-</param>
    /// <param name="mruName">-</param>
    abstract deleteIdentityMru: mruData: Core.IdentityData * mruName: string -> Promise<unit>
    /// <param name="mruName">-</param>
    abstract getIdentityMru: mruName: string -> Promise<ResizeArray<WebApi.IdentityRef>>
    /// <param name="mruData">-</param>
    /// <param name="mruName">-</param>
    abstract updateIdentityMru: mruData: Core.IdentityData * mruName: string -> Promise<unit>
    /// <summary>Get a list of members for a specific team.</summary>
    /// <param name="projectId">- The name or ID (GUID) of the team project the team belongs to.</param>
    /// <param name="teamId">- The name or ID (GUID) of the team .</param>
    /// <param name="top">-</param>
    /// <param name="skip">-</param>
    abstract getTeamMembersWithExtendedProperties: projectId: string * teamId: string * ?top: float * ?skip: float -> Promise<ResizeArray<WebApi.TeamMember>>
    /// <summary>Get a process by ID.</summary>
    /// <param name="processId">- ID for a process.</param>
    abstract getProcessById: processId: string -> Promise<Core.Process>
    /// Get a list of processes.
    abstract getProcesses: unit -> Promise<ResizeArray<Core.Process>>
    /// <summary>Get project collection with the specified id or name.</summary>
    /// <param name="collectionId">-</param>
    abstract getProjectCollection: collectionId: string -> Promise<Core.TeamProjectCollection>
    /// <summary>Get project collection references for this application.</summary>
    /// <param name="top">-</param>
    /// <param name="skip">-</param>
    abstract getProjectCollections: ?top: float * ?skip: float -> Promise<ResizeArray<Core.TeamProjectCollectionReference>>
    /// <summary>Gets the history of changes to the project.</summary>
    /// <param name="minRevision">- The minimum revision number to return in the history.</param>
    abstract getProjectHistoryEntries: ?minRevision: float -> Promise<ResizeArray<Core.ProjectInfo>>
    /// <summary>Get project with the specified id or name, optionally including capabilities.</summary>
    /// <param name="projectId">-</param>
    /// <param name="includeCapabilities">- Include capabilities (such as source control) in the team project result (default: false).</param>
    /// <param name="includeHistory">- Search within renamed projects (that had such name in the past).</param>
    abstract getProject: projectId: string * ?includeCapabilities: bool * ?includeHistory: bool -> Promise<Core.TeamProject>
    /// <summary>Get all projects in the organization that the authenticated user has access to.</summary>
    /// <param name="stateFilter">- Filter on team projects in a specific team project state (default: WellFormed).</param>
    /// <param name="top">-</param>
    /// <param name="skip">-</param>
    /// <param name="continuationToken">-</param>
    /// <param name="getDefaultTeamImageUrl">-</param>
    abstract getProjects: ?stateFilter: obj * ?top: float * ?skip: float * ?continuationToken: string * ?getDefaultTeamImageUrl: bool -> Promise<ResizeArray<Core.TeamProjectReference>>
    /// <summary>Queues a project to be created. Use the [GetOperation](../../operations/operations/get) to periodically check for create project status.</summary>
    /// <param name="projectToCreate">- The project to create.</param>
    abstract queueCreateProject: projectToCreate: Core.TeamProject -> Promise<Operations.OperationReference>
    /// <summary>Queues a project to be deleted. Use the [GetOperation](../../operations/operations/get) to periodically check for delete project status.</summary>
    /// <param name="projectId">- The project id of the project to delete.</param>
    abstract queueDeleteProject: projectId: string -> Promise<Operations.OperationReference>
    /// <summary>Update an existing project's name, abbreviation, description, or restore a project.</summary>
    /// <param name="projectUpdate">- The updates for the project. The state must be set to wellFormed to restore the project.</param>
    /// <param name="projectId">- The project id of the project to update.</param>
    abstract updateProject: projectUpdate: Core.TeamProject * projectId: string -> Promise<Operations.OperationReference>
    /// <summary>Get a collection of team project properties for multiple projects.</summary>
    /// <param name="projectIds">- A comma-delimited string of team project IDs</param>
    /// <param name="properties">-</param>
    abstract getProjectsProperties: projectIds: ResizeArray<string> * ?properties: ResizeArray<string> -> Promise<ResizeArray<Core.ProjectProperties>>
    /// <summary>Get a collection of team project properties.</summary>
    /// <param name="projectId">- The team project ID.</param>
    /// <param name="keys">- A comma-delimited string of team project property names. Wildcard characters ("?" and "*") are supported. If no key is specified, all properties will be returned.</param>
    abstract getProjectProperties: projectId: string * ?keys: ResizeArray<string> -> Promise<ResizeArray<Core.ProjectProperty>>
    /// <summary>Create, update, and delete team project properties.</summary>
    /// <param name="projectId">- The team project ID.</param>
    /// <param name="patchDocument">- A JSON Patch document that represents an array of property operations. See RFC 6902 for more details on JSON Patch. The accepted operation verbs are Add and Remove, where Add is used for both creating and updating properties. The path consists of a forward slash and a property name.</param>
    abstract setProjectProperties: projectId: string * patchDocument: WebApi.JsonPatchDocument -> Promise<unit>
    /// <param name="proxy">-</param>
    abstract createOrUpdateProxy: proxy: Core.Proxy -> Promise<Core.Proxy>
    /// <param name="proxyUrl">-</param>
    /// <param name="site">-</param>
    abstract deleteProxy: proxyUrl: string * ?site: string -> Promise<unit>
    /// <param name="proxyUrl">-</param>
    abstract getProxies: ?proxyUrl: string -> Promise<ResizeArray<Core.Proxy>>
    /// <summary>Get a list of all teams.</summary>
    /// <param name="mine">- If true, then return all teams requesting user is member. Otherwise return all teams user has read access.</param>
    /// <param name="top">- Maximum number of teams to return.</param>
    /// <param name="skip">- Number of teams to skip.</param>
    /// <param name="expandIdentity">- A value indicating whether or not to expand Identity information in the result WebApiTeam object.</param>
    abstract getAllTeams: ?mine: bool * ?top: float * ?skip: float * ?expandIdentity: bool -> Promise<ResizeArray<Core.WebApiTeam>>
    /// <summary>Create a team in a team project.</summary>
    /// <param name="team">- The team data used to create the team.</param>
    /// <param name="projectId">- The name or ID (GUID) of the team project in which to create the team.</param>
    abstract createTeam: team: Core.WebApiTeam * projectId: string -> Promise<Core.WebApiTeam>
    /// <summary>Delete a team.</summary>
    /// <param name="projectId">- The name or ID (GUID) of the team project containing the team to delete.</param>
    /// <param name="teamId">- The name or ID of the team to delete.</param>
    abstract deleteTeam: projectId: string * teamId: string -> Promise<unit>
    /// <summary>Get a specific team.</summary>
    /// <param name="projectId">- The name or ID (GUID) of the team project containing the team.</param>
    /// <param name="teamId">- The name or ID (GUID) of the team.</param>
    /// <param name="expandIdentity">- A value indicating whether or not to expand Identity information in the result WebApiTeam object.</param>
    abstract getTeam: projectId: string * teamId: string * ?expandIdentity: bool -> Promise<Core.WebApiTeam>
    /// <summary>Get a list of teams.</summary>
    /// <param name="projectId">-</param>
    /// <param name="mine">- If true return all the teams requesting user is member, otherwise return all the teams user has read access.</param>
    /// <param name="top">- Maximum number of teams to return.</param>
    /// <param name="skip">- Number of teams to skip.</param>
    /// <param name="expandIdentity">- A value indicating whether or not to expand Identity information in the result WebApiTeam object.</param>
    abstract getTeams: projectId: string * ?mine: bool * ?top: float * ?skip: float * ?expandIdentity: bool -> Promise<ResizeArray<Core.WebApiTeam>>
    /// <summary>Update a team's name and/or description.</summary>
    /// <param name="teamData">-</param>
    /// <param name="projectId">- The name or ID (GUID) of the team project containing the team to update.</param>
    /// <param name="teamId">- The name of ID of the team to update.</param>
    abstract updateTeam: teamData: Core.WebApiTeam * projectId: string * teamId: string -> Promise<Core.WebApiTeam>

type [<AllowNullLiteral>] CoreRestClientStatic =
    [<Emit "new $0($1...)">] abstract Create: options: IVssRestClientOptions -> CoreRestClient
    abstract RESOURCE_AREA_ID: string
