// ts2fable 0.7.1
module rec DistributedTaskCommon
open System
open Fable.Core
open Fable.Core.JS

type [<AllowNullLiteral>] AuthorizationHeader =
    abstract name: string with get, set
    abstract value: string with get, set

/// Represents binding of data source for the service endpoint request.
type [<AllowNullLiteral>] DataSourceBindingBase =
    /// Pagination format supported by this data source(ContinuationToken/SkipTop).
    abstract callbackContextTemplate: string with get, set
    /// Subsequent calls needed?
    abstract callbackRequiredTemplate: string with get, set
    /// Gets or sets the name of the data source.
    abstract dataSourceName: string with get, set
    /// Gets or sets the endpoint Id.
    abstract endpointId: string with get, set
    /// Gets or sets the url of the service endpoint.
    abstract endpointUrl: string with get, set
    /// Gets or sets the authorization headers.
    abstract headers: ResizeArray<AuthorizationHeader> with get, set
    /// Defines the initial value of the query params
    abstract initialContextTemplate: string with get, set
    /// Gets or sets the parameters for the data source.
    abstract parameters: DataSourceBindingBaseParameters with get, set
    /// Gets or sets http request body
    abstract requestContent: string with get, set
    /// Gets or sets http request verb
    abstract requestVerb: string with get, set
    /// Gets or sets the result selector.
    abstract resultSelector: string with get, set
    /// Gets or sets the result template.
    abstract resultTemplate: string with get, set
    /// Gets or sets the target of the data source.
    abstract target: string with get, set

type [<AllowNullLiteral>] ProcessParameters =
    abstract dataSourceBindings: ResizeArray<DataSourceBindingBase> with get, set
    abstract inputs: ResizeArray<TaskInputDefinitionBase> with get, set
    abstract sourceDefinitions: ResizeArray<TaskSourceDefinitionBase> with get, set

type [<AllowNullLiteral>] TaskInputDefinitionBase =
    abstract aliases: ResizeArray<string> with get, set
    abstract defaultValue: string with get, set
    abstract groupName: string with get, set
    abstract helpMarkDown: string with get, set
    abstract label: string with get, set
    abstract name: string with get, set
    abstract options: DataSourceBindingBaseParameters with get, set
    abstract properties: DataSourceBindingBaseParameters with get, set
    abstract required: bool with get, set
    abstract ``type``: string with get, set
    abstract validation: TaskInputValidation with get, set
    abstract visibleRule: string with get, set

type [<AllowNullLiteral>] TaskInputValidation =
    /// Conditional expression
    abstract expression: string with get, set
    /// Message explaining how user can correct if validation fails
    abstract message: string with get, set

type [<AllowNullLiteral>] TaskSourceDefinitionBase =
    abstract authKey: string with get, set
    abstract endpoint: string with get, set
    abstract keySelector: string with get, set
    abstract selector: string with get, set
    abstract target: string with get, set

type [<AllowNullLiteral>] DataSourceBindingBaseParameters =
    [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> string with get, set
