// ts2fable 0.7.1
module rec ServiceEndpointClient
open System
open Fable.Core
open Fable.Core.JS

type IVssRestClientOptions = Context.IVssRestClientOptions
type RestClientBase = RestClientBase.RestClientBase

type [<AllowNullLiteral>] IExports =
    abstract ServiceEndpointRestClient: ServiceEndpointRestClientStatic

type [<AllowNullLiteral>] ServiceEndpointRestClient =
    inherit RestClientBase
    /// Returns list of azure subscriptions
    abstract getAzureManagementGroups: unit -> Promise<ServiceEndpoint.AzureManagementGroupQueryResult>
    /// Returns list of azure subscriptions
    abstract getAzureSubscriptions: unit -> Promise<ServiceEndpoint.AzureSubscriptionQueryResult>
    /// <summary>Proxy for a GET request defined by a service endpoint.</summary>
    /// <param name="serviceEndpointRequest">- Service endpoint request.</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="endpointId">- Id of the service endpoint.</param>
    abstract executeServiceEndpointRequest: serviceEndpointRequest: ServiceEndpoint.ServiceEndpointRequest * project: string * endpointId: string -> Promise<ServiceEndpoint.ServiceEndpointRequestResult>
    /// <summary>Proxy for a GET request defined by a service endpoint. The request is authorized using a data source in service endpoint. The response is filtered using an XPath/Json based selector.</summary>
    /// <param name="binding">- Describes the data source to fetch.</param>
    /// <param name="project">- Project ID or project name</param>
    abstract queryServiceEndpoint: binding: ServiceEndpoint.DataSourceBinding * project: string -> Promise<ResizeArray<string>>
    /// <summary>Create a service endpoint.</summary>
    /// <param name="endpoint">- Service endpoint to create.</param>
    /// <param name="project">- Project ID or project name</param>
    abstract createServiceEndpoint: endpoint: ServiceEndpoint.ServiceEndpoint * project: string -> Promise<ServiceEndpoint.ServiceEndpoint>
    /// <summary>Delete a service endpoint.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="endpointId">- Id of the service endpoint to delete.</param>
    /// <param name="deep">- Specific to AzureRM endpoint created in Automatic flow. When set to true, this will also delete corresponding AAD application in Azure. Default value is true.</param>
    abstract deleteServiceEndpoint: project: string * endpointId: string * ?deep: bool -> Promise<unit>
    /// <summary>Get the service endpoint details.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="endpointId">- Id of the service endpoint.</param>
    abstract getServiceEndpointDetails: project: string * endpointId: string -> Promise<ServiceEndpoint.ServiceEndpoint>
    /// <summary>Get the service endpoints.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="type">- Type of the service endpoints.</param>
    /// <param name="authSchemes">- Authorization schemes used for service endpoints.</param>
    /// <param name="endpointIds">- Ids of the service endpoints.</param>
    /// <param name="owner">- Owner for service endpoints.</param>
    /// <param name="includeFailed">- Failed flag for service endpoints.</param>
    /// <param name="includeDetails">- Flag to include more details for service endpoints. This is for internal use only and the flag will be treated as false for all other requests</param>
    abstract getServiceEndpoints: project: string * ?``type``: string * ?authSchemes: ResizeArray<string> * ?endpointIds: ResizeArray<string> * ?owner: string * ?includeFailed: bool * ?includeDetails: bool -> Promise<ResizeArray<ServiceEndpoint.ServiceEndpoint>>
    /// <summary>Get the service endpoints by name.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="endpointNames">- Names of the service endpoints.</param>
    /// <param name="type">- Type of the service endpoints.</param>
    /// <param name="authSchemes">- Authorization schemes used for service endpoints.</param>
    /// <param name="owner">- Owner for service endpoints.</param>
    /// <param name="includeFailed">- Failed flag for service endpoints.</param>
    /// <param name="includeDetails">- Flag to include more details for service endpoints. This is for internal use only and the flag will be treated as false for all other requests</param>
    abstract getServiceEndpointsByNames: project: string * endpointNames: ResizeArray<string> * ?``type``: string * ?authSchemes: ResizeArray<string> * ?owner: string * ?includeFailed: bool * ?includeDetails: bool -> Promise<ResizeArray<ServiceEndpoint.ServiceEndpoint>>
    /// <summary>Gets the service endpoints and patch new authorization parameters</summary>
    /// <param name="refreshAuthenticationParameters">- Scope, Validity of Token requested.</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="endpointIds">- Ids of the service endpoints.</param>
    abstract getServiceEndpointsWithRefreshedAuthentication: refreshAuthenticationParameters: ResizeArray<ServiceEndpoint.RefreshAuthenticationParameters> * project: string * endpointIds: ResizeArray<string> -> Promise<ResizeArray<ServiceEndpoint.ServiceEndpoint>>
    /// <summary>Update a service endpoint.</summary>
    /// <param name="endpoint">- Service endpoint to update.</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="endpointId">- Id of the service endpoint to update.</param>
    /// <param name="operation">- Operation for the service endpoint.</param>
    abstract updateServiceEndpoint: endpoint: ServiceEndpoint.ServiceEndpoint * project: string * endpointId: string * ?operation: string -> Promise<ServiceEndpoint.ServiceEndpoint>
    /// <summary>Update the service endpoints.</summary>
    /// <param name="endpoints">- Names of the service endpoints to update.</param>
    /// <param name="project">- Project ID or project name</param>
    abstract updateServiceEndpoints: endpoints: ResizeArray<ServiceEndpoint.ServiceEndpoint> * project: string -> Promise<ResizeArray<ServiceEndpoint.ServiceEndpoint>>
    /// <summary>Get service endpoint execution records.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="endpointId">- Id of the service endpoint.</param>
    /// <param name="top">- Number of service endpoint execution records to get.</param>
    /// <param name="continuationToken">- A continuation token, returned by a previous call to this method, that can be used to return the next set of records</param>
    abstract getServiceEndpointExecutionRecords: project: string * endpointId: string * ?top: int * ?continuationToken: int -> Promise<ResizeArray<ServiceEndpoint.ServiceEndpointExecutionRecord>>
    /// <summary>Add service endpoint execution records.</summary>
    /// <param name="input">- Service endpoint execution records to add.</param>
    /// <param name="project">- Project ID or project name</param>
    abstract addServiceEndpointExecutionRecords: input: ServiceEndpoint.ServiceEndpointExecutionRecordsInput * project: string -> Promise<ResizeArray<ServiceEndpoint.ServiceEndpointExecutionRecord>>
    /// <param name="configurationParams">-</param>
    abstract createOAuthConfiguration: configurationParams: ServiceEndpoint.OAuthConfigurationParams -> Promise<ServiceEndpoint.OAuthConfiguration>
    /// <param name="configurationId">-</param>
    abstract deleteOAuthConfiguration: configurationId: string -> Promise<ServiceEndpoint.OAuthConfiguration>
    /// <param name="configurationId">-</param>
    abstract getOAuthConfiguration: configurationId: string -> Promise<ServiceEndpoint.OAuthConfiguration>
    /// <param name="endpointType">-</param>
    /// <param name="actionFilter">-</param>
    abstract getOAuthConfigurations: ?endpointType: string * ?actionFilter: ServiceEndpoint.OAuthConfigurationActionFilter -> Promise<ResizeArray<ServiceEndpoint.OAuthConfiguration>>
    /// <param name="configurationParams">-</param>
    /// <param name="configurationId">-</param>
    abstract updateOAuthConfiguration: configurationParams: ServiceEndpoint.OAuthConfigurationParams * configurationId: string -> Promise<ServiceEndpoint.OAuthConfiguration>
    /// <param name="endpointId">-</param>
    /// <param name="project">-</param>
    abstract querySharedProjects: endpointId: string * project: string -> Promise<ResizeArray<ServiceEndpoint.ProjectReference>>
    /// <param name="endpointId">-</param>
    /// <param name="fromProject">-</param>
    /// <param name="withProject">-</param>
    abstract shareEndpointWithProject: endpointId: string * fromProject: string * withProject: string -> Promise<unit>
    /// <summary>Get service endpoint types.</summary>
    /// <param name="type">- Type of service endpoint.</param>
    /// <param name="scheme">- Scheme of service endpoint.</param>
    abstract getServiceEndpointTypes: ?``type``: string * ?scheme: string -> Promise<ResizeArray<ServiceEndpoint.ServiceEndpointType>>
    /// <param name="authenticationRequest">-</param>
    abstract acquireAccessToken: authenticationRequest: ServiceEndpoint.AadOauthTokenRequest -> Promise<ServiceEndpoint.AadOauthTokenResult>
    /// <param name="tenantId">-</param>
    /// <param name="redirectUri">-</param>
    /// <param name="promptOption">-</param>
    /// <param name="completeCallbackPayload">-</param>
    /// <param name="completeCallbackByAuthCode">-</param>
    abstract createAadOAuthRequest: tenantId: string * redirectUri: string * ?promptOption: ServiceEndpoint.AadLoginPromptOption * ?completeCallbackPayload: string * ?completeCallbackByAuthCode: bool -> Promise<string>
    abstract getVstsAadTenantId: unit -> Promise<string>

type [<AllowNullLiteral>] ServiceEndpointRestClientStatic =
    [<Emit "new $0($1...)">] abstract Create: options: IVssRestClientOptions -> ServiceEndpointRestClient
    abstract RESOURCE_AREA_ID: string
