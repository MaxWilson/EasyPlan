// ts2fable 0.7.1
module rec ServiceEndpoint
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

type [<RequireQualifiedAccess>] AccessTokenRequestType =
    | None = 0
    | Oauth = 1
    | Direct = 2

type [<AllowNullLiteral>] AuthConfiguration =
    inherit OAuthConfiguration
    /// Gets or sets parameters contained in configuration object.
    abstract parameters: AuthConfigurationParameters with get, set

/// Specifies the authentication scheme to be used for authentication.
type [<AllowNullLiteral>] AuthenticationSchemeReference =
    /// Gets or sets the key and value of the fields used for authentication.
    abstract inputs: AuthenticationSchemeReferenceInputs with get, set
    /// Gets or sets the type of authentication scheme of an endpoint.
    abstract ``type``: string with get, set

/// Represents the header of the REST request.
type [<AllowNullLiteral>] AuthorizationHeader =
    /// Gets or sets the name of authorization header.
    abstract name: string with get, set
    /// Gets or sets the value of authorization header.
    abstract value: string with get, set

type [<AllowNullLiteral>] AzureKeyVaultPermission =
    inherit AzureResourcePermission
    abstract vault: string with get, set

/// Azure Management Group
type [<AllowNullLiteral>] AzureManagementGroup =
    /// Display name of azure management group
    abstract displayName: string with get, set
    /// Id of azure management group
    abstract id: string with get, set
    /// Azure management group name
    abstract name: string with get, set
    /// Id of tenant from which azure management group belogs
    abstract tenantId: string with get, set

/// Azure management group query result
type [<AllowNullLiteral>] AzureManagementGroupQueryResult =
    /// Error message in case of an exception
    abstract errorMessage: string with get, set
    /// List of azure management groups
    abstract value: ResizeArray<AzureManagementGroup> with get, set

type [<AllowNullLiteral>] AzureMLWorkspace =
    abstract id: string with get, set
    abstract location: string with get, set
    abstract name: string with get, set

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

/// Specifies the client certificate to be used for the endpoint request.
type [<AllowNullLiteral>] ClientCertificate =
    /// Gets or sets the value of client certificate.
    abstract value: string with get, set

/// Specifies the data sources for this endpoint.
type [<AllowNullLiteral>] DataSource =
    /// Gets or sets the authentication scheme for the endpoint request.
    abstract authenticationScheme: AuthenticationSchemeReference with get, set
    /// Gets or sets the pagination format supported by this data source(ContinuationToken/SkipTop).
    abstract callbackContextTemplate: string with get, set
    /// Gets or sets the template to check if subsequent call is needed.
    abstract callbackRequiredTemplate: string with get, set
    /// Gets or sets the endpoint url of the data source.
    abstract endpointUrl: string with get, set
    /// Gets or sets the authorization headers of the request.
    abstract headers: ResizeArray<AuthorizationHeader> with get, set
    /// Gets or sets the initial value of the query params.
    abstract initialContextTemplate: string with get, set
    /// Gets or sets the name of the data source.
    abstract name: string with get, set
    /// Gets or sets the request content of the endpoint request.
    abstract requestContent: string with get, set
    /// Gets or sets the request method of the endpoint request.
    abstract requestVerb: string with get, set
    /// Gets or sets the resource url of the endpoint request.
    abstract resourceUrl: string with get, set
    /// Gets or sets the result selector to filter the response of the endpoint request.
    abstract resultSelector: string with get, set

/// Represents the data source binding of the endpoint.
type [<AllowNullLiteral>] DataSourceBinding =
    inherit DistributedTaskCommon.DataSourceBindingBase

/// Represents details of the service endpoint data source.
type [<AllowNullLiteral>] DataSourceDetails =
    /// Gets or sets the data source name.
    abstract dataSourceName: string with get, set
    /// Gets or sets the data source url.
    abstract dataSourceUrl: string with get, set
    /// Gets or sets the request headers.
    abstract headers: ResizeArray<AuthorizationHeader> with get, set
    /// Gets or sets the initialization context used for the initial call to the data source
    abstract initialContextTemplate: string with get, set
    /// Gets the parameters of data source.
    abstract parameters: AuthenticationSchemeReferenceInputs with get, set
    /// Gets or sets the data source request content.
    abstract requestContent: string with get, set
    /// Gets or sets the data source request verb. Get/Post are the only implemented types
    abstract requestVerb: string with get, set
    /// Gets or sets the resource url of data source.
    abstract resourceUrl: string with get, set
    /// Gets or sets the result selector.
    abstract resultSelector: string with get, set

/// Represents the details of the input on which a given input is dependent.
type [<AllowNullLiteral>] DependencyBinding =
    /// Gets or sets the value of the field on which url is dependent.
    abstract key: string with get, set
    /// Gets or sets the corresponding value of url.
    abstract value: string with get, set

/// Represents the dependency data for the endpoint inputs.
type [<AllowNullLiteral>] DependencyData =
    /// Gets or sets the category of dependency data.
    abstract input: string with get, set
    /// Gets or sets the key-value pair to specify properties and their values.
    abstract map: ResizeArray<DependencyDataMap> with get, set

/// Represents the inputs on which any given input is dependent.
type [<AllowNullLiteral>] DependsOn =
    /// Gets or sets the ID of the field on which URL's value is dependent.
    abstract input: string with get, set
    /// Gets or sets key-value pair containing other's field value and corresponding url value.
    abstract map: ResizeArray<DependencyBinding> with get, set

/// Represents the authorization used for service endpoint.
type [<AllowNullLiteral>] EndpointAuthorization =
    /// Gets or sets the parameters for the selected authorization scheme.
    abstract parameters: AuthenticationSchemeReferenceInputs with get, set
    /// Gets or sets the scheme used for service endpoint authentication.
    abstract scheme: string with get, set

type [<AllowNullLiteral>] EndpointOperationStatus =
    abstract state: string with get, set
    abstract statusMessage: string with get, set

/// Represents url of the service endpoint.
type [<AllowNullLiteral>] EndpointUrl =
    /// Gets or sets the dependency bindings.
    abstract dependsOn: DependsOn with get, set
    /// Gets or sets the display name of service endpoint url.
    abstract displayName: string with get, set
    /// Gets or sets the format of the url.
    abstract format: string with get, set
    /// Gets or sets the help text of service endpoint url.
    abstract helpText: string with get, set
    /// Gets or sets the visibility of service endpoint url.
    abstract isVisible: string with get, set
    /// Gets or sets the value of service endpoint url.
    abstract value: string with get, set

/// Specifies the public url of the help documentation.
type [<AllowNullLiteral>] HelpLink =
    /// Gets or sets the help text.
    abstract text: string with get, set
    /// Gets or sets the public url of the help documentation.
    abstract url: string with get, set

type [<AllowNullLiteral>] OAuth2TokenResult =
    abstract accessToken: string with get, set
    abstract error: string with get, set
    abstract errorDescription: string with get, set
    abstract expiresIn: string with get, set
    abstract issuedAt: string with get, set
    abstract refreshToken: string with get, set
    abstract scope: string with get, set

type [<AllowNullLiteral>] OAuthConfiguration =
    /// Gets or sets the ClientId
    abstract clientId: string with get, set
    /// Gets or sets the ClientSecret
    abstract clientSecret: string with get, set
    /// Gets or sets the identity who created the config.
    abstract createdBy: WebApi.IdentityRef with get, set
    /// Gets or sets the time when config was created.
    abstract createdOn: DateTime with get, set
    /// Gets or sets the type of the endpoint.
    abstract endpointType: string with get, set
    /// Gets or sets the unique identifier of this field
    abstract id: string with get, set
    /// Gets or sets the identity who modified the config.
    abstract modifiedBy: WebApi.IdentityRef with get, set
    /// Gets or sets the time when variable group was modified
    abstract modifiedOn: DateTime with get, set
    /// Gets or sets the name
    abstract name: string with get, set
    /// Gets or sets the Url
    abstract url: string with get, set

type [<RequireQualifiedAccess>] OAuthConfigurationActionFilter =
    | None = 0
    | Manage = 2
    | Use = 16

type [<AllowNullLiteral>] OAuthConfigurationParams =
    /// Gets or sets the ClientId
    abstract clientId: string with get, set
    /// Gets or sets the ClientSecret
    abstract clientSecret: string with get, set
    /// Gets or sets the type of the endpoint.
    abstract endpointType: string with get, set
    /// Gets or sets the name
    abstract name: string with get, set
    /// Gets or sets the Url
    abstract url: string with get, set

type [<AllowNullLiteral>] OAuthEndpointStatus =
    abstract state: string with get, set
    abstract statusMessage: string with get, set

type [<AllowNullLiteral>] Parameter =
    abstract isSecret: bool with get, set
    abstract value: string with get, set

type [<AllowNullLiteral>] ProjectReference =
    abstract id: string with get, set
    abstract name: string with get, set

/// Specify the properties for refreshing the endpoint authentication object being queried
type [<AllowNullLiteral>] RefreshAuthenticationParameters =
    /// EndpointId which needs new authentication params
    abstract endpointId: string with get, set
    /// Scope of the token requested. For GitHub marketplace apps, scope contains repository Ids
    abstract scope: ResizeArray<float> with get, set
    /// The requested endpoint authentication should be valid for _ minutes. Authentication params will not be refreshed if the token contained in endpoint already has active token.
    abstract tokenValidityInMinutes: int with get, set

/// Represents template to transform the result data.
type [<AllowNullLiteral>] ResultTransformationDetails =
    /// Gets or sets the template for callback parameters
    abstract callbackContextTemplate: string with get, set
    /// Gets or sets the template to decide whether to callback or not
    abstract callbackRequiredTemplate: string with get, set
    /// Gets or sets the template for result transformation.
    abstract resultTemplate: string with get, set

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
    /// This is a deprecated field.
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
    /// Owner of the endpoint Supported values are "library", "agentcloud"
    abstract owner: string with get, set
    /// Gets or sets the identity reference for the readers group of the service endpoint.
    abstract readersGroup: WebApi.IdentityRef with get, set
    /// All other project references where the service endpoint is shared.
    abstract serviceEndpointProjectReferences: ResizeArray<ServiceEndpointProjectReference> with get, set
    /// Gets or sets the type of the endpoint.
    abstract ``type``: string with get, set
    /// Gets or sets the url of the endpoint.
    abstract url: string with get, set

type [<RequireQualifiedAccess>] ServiceEndpointActionFilter =
    | None = 0
    | Manage = 2
    | Use = 16

/// Represents the authentication scheme used to authenticate the endpoint.
type [<AllowNullLiteral>] ServiceEndpointAuthenticationScheme =
    /// Gets or sets the authorization headers of service endpoint authentication scheme.
    abstract authorizationHeaders: ResizeArray<AuthorizationHeader> with get, set
    /// Gets or sets the Authorization url required to authenticate using OAuth2
    abstract authorizationUrl: string with get, set
    /// Gets or sets the certificates of service endpoint authentication scheme.
    abstract clientCertificates: ResizeArray<ClientCertificate> with get, set
    /// Gets or sets the data source bindings of the endpoint.
    abstract dataSourceBindings: ResizeArray<DataSourceBinding> with get, set
    /// Gets or sets the display name for the service endpoint authentication scheme.
    abstract displayName: string with get, set
    /// Gets or sets the input descriptors for the service endpoint authentication scheme.
    abstract inputDescriptors: ResizeArray<FormInput.InputDescriptor> with get, set
    /// Gets or sets the properties of service endpoint authentication scheme.
    abstract properties: AuthenticationSchemeReferenceInputs with get, set
    /// Gets or sets whether this auth scheme requires OAuth2 configuration or not.
    abstract requiresOAuth2Configuration: bool with get, set
    /// Gets or sets the scheme for service endpoint authentication.
    abstract scheme: string with get, set

/// Represents details of the service endpoint.
type [<AllowNullLiteral>] ServiceEndpointDetails =
    /// Gets or sets the authorization of service endpoint.
    abstract authorization: EndpointAuthorization with get, set
    /// Gets or sets the data of service endpoint.
    abstract data: AuthenticationSchemeReferenceInputs with get, set
    /// Gets or sets the type of service endpoint.
    abstract ``type``: string with get, set
    /// Gets or sets the connection url of service endpoint.
    abstract url: string with get, set

/// Represents service endpoint execution data.
type [<AllowNullLiteral>] ServiceEndpointExecutionData =
    /// Gets the definition of service endpoint execution owner.
    abstract definition: ServiceEndpointExecutionOwner with get, set
    /// Gets the finish time of service endpoint execution.
    abstract finishTime: DateTime with get, set
    /// Gets the Id of service endpoint execution data.
    abstract id: int with get, set
    /// Gets the owner of service endpoint execution data.
    abstract owner: ServiceEndpointExecutionOwner with get, set
    /// Gets the plan type of service endpoint execution data.
    abstract planType: string with get, set
    /// Gets the result of service endpoint execution.
    abstract result: ServiceEndpointExecutionResult with get, set
    /// Gets the start time of service endpoint execution.
    abstract startTime: DateTime with get, set

/// Represents execution owner of the service endpoint.
type [<AllowNullLiteral>] ServiceEndpointExecutionOwner =
    abstract _links: obj option with get, set
    /// Gets or sets the Id of service endpoint execution owner.
    abstract id: int with get, set
    /// Gets or sets the name of service endpoint execution owner.
    abstract name: string with get, set

/// Represents the details of service endpoint execution.
type [<AllowNullLiteral>] ServiceEndpointExecutionRecord =
    /// Gets the execution data of service endpoint execution.
    abstract data: ServiceEndpointExecutionData with get, set
    /// Gets the Id of service endpoint.
    abstract endpointId: string with get, set

type [<AllowNullLiteral>] ServiceEndpointExecutionRecordsInput =
    abstract data: ServiceEndpointExecutionData with get, set
    abstract endpointIds: ResizeArray<string> with get, set

type [<RequireQualifiedAccess>] ServiceEndpointExecutionResult =
    | Succeeded = 0
    | SucceededWithIssues = 1
    | Failed = 2
    | Canceled = 3
    | Skipped = 4
    | Abandoned = 5

type [<AllowNullLiteral>] ServiceEndpointOAuthConfigurationReference =
    abstract configurationId: string with get, set
    abstract serviceEndpointId: string with get, set
    abstract serviceEndpointProjectId: string with get, set

type [<AllowNullLiteral>] ServiceEndpointProjectReference =
    /// Gets or sets description of the service endpoint.
    abstract description: string with get, set
    /// Gets or sets name of the service endpoint.
    abstract name: string with get, set
    /// Gets or sets project reference of the service endpoint.
    abstract projectReference: ProjectReference with get, set

type [<AllowNullLiteral>] ServiceEndpointRequest =
    /// Gets or sets the data source details for the service endpoint request.
    abstract dataSourceDetails: DataSourceDetails with get, set
    /// Gets or sets the result transformation details for the service endpoint request.
    abstract resultTransformationDetails: ResultTransformationDetails with get, set
    /// Gets or sets the service endpoint details for the service endpoint request.
    abstract serviceEndpointDetails: ServiceEndpointDetails with get, set

/// Represents result of the service endpoint request.
type [<AllowNullLiteral>] ServiceEndpointRequestResult =
    /// Gets or sets the parameters used to make subsequent calls to the data source
    abstract callbackContextParameters: AuthenticationSchemeReferenceInputs with get, set
    /// Gets or sets the flat that decides if another call to the data source is to be made
    abstract callbackRequired: bool with get, set
    /// Gets or sets the error message of the service endpoint request result.
    abstract errorMessage: string with get, set
    /// Gets or sets the result of service endpoint request.
    abstract result: obj option with get, set
    /// Gets or sets the status code of the service endpoint request result.
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
    /// Gets or sets the help text shown at the endpoint create dialog.
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

type [<AllowNullLiteral>] AuthConfigurationParameters =
    [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> Parameter with get, set

type [<AllowNullLiteral>] AuthenticationSchemeReferenceInputs =
    [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> string with get, set

type [<AllowNullLiteral>] DependencyDataMapValue =
    abstract key: string with get, set
    abstract value: string with get, set

type [<AllowNullLiteral>] DependencyDataMap =
    abstract key: string with get, set
    abstract value: ResizeArray<DependencyDataMapValue> with get, set
