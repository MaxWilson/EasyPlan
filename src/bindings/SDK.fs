// ts2fable 0.7.1
module rec SDK
open System
open Fable.Core
open Fable.Core.JS

type Error = System.Exception

let [<Import("sdkVersion","SDK")>] sdkVersion: int = jsNative

type [<ImportMember("azure-devops-extension-sdk/SDK")>] [<AllowNullLiteral>] IExports =
    /// <summary>Initiates the handshake with the host window.</summary>
    /// <param name="options">- Initialization options for the extension.</param>
    abstract init: ?options: IExtensionInitOptions -> Promise<unit>
    /// Register a callback that gets called once the initial setup/handshake has completed.
    /// If the initial setup is already completed, the callback is invoked at the end of the current call stack.
    abstract ready: unit -> Promise<unit>
    /// Notifies the host that the extension successfully loaded (stop showing the loading indicator)
    abstract notifyLoadSucceeded: unit -> Promise<unit>
    /// Notifies the host that the extension failed to load
    abstract notifyLoadFailed: e: U2<Error, string> -> Promise<unit>
    /// Get the configuration data passed in the initial handshake from the parent frame
    abstract getConfiguration: unit -> GetConfigurationReturn
    /// Gets the information about the contribution that first caused this extension to load.
    abstract getContributionId: unit -> string
    /// Gets information about the current user
    abstract getUser: unit -> IUserContext
    /// Gets information about the host (i.e. an Azure DevOps organization) that the page is targeting
    abstract getHost: unit -> IHostContext
    /// Get the context about the extension that owns the content that is being hosted
    abstract getExtensionContext: unit -> IExtensionContext
    /// <summary>Get the contribution with the given contribution id. The returned contribution has a method to get a registered object within that contribution.</summary>
    /// <param name="contributionId">- Id of the contribution to get</param>
    abstract getService: contributionId: string -> Promise<'T>
    /// <summary>Register an object (instance or factory method) that this extension exposes to the host frame.</summary>
    /// <param name="instanceId">- unique id of the registered object</param>
    /// <param name="instance">- Either: (1) an object instance, or (2) a function that takes optional context data and returns an object instance.</param>
    abstract register: instanceId: string * instance: 'T -> unit
    /// <summary>Removes an object that this extension exposed to the host frame.</summary>
    /// <param name="instanceId">- unique id of the registered object</param>
    abstract unregister: instanceId: string -> unit
    /// Fetch an access token which will allow calls to be made to other DevOps services
    abstract getAccessToken: unit -> Promise<string>
    /// Fetch an token which can be used to identify the current user
    abstract getAppToken: unit -> Promise<string>
    /// <summary>Requests the parent window to resize the container for this extension based on the current extension size.</summary>
    /// <param name="width">- Optional width, defaults to scrollWidth</param>
    /// <param name="height">- Optional height, defaults to scrollHeight</param>
    abstract resize: ?width: int * ?height: int -> unit
    /// Applies theme variables to the current document
    abstract applyTheme: themeData: ApplyThemeThemeData -> unit

type [<AllowNullLiteral>] GetConfigurationReturn =
    [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

type [<AllowNullLiteral>] ApplyThemeThemeData =
    [<Emit "$0[$1]{{=$2}}">] abstract Item: varName: string -> string with get, set

/// Options for extension initialization -- passed to DevOps.init()
type [<AllowNullLiteral>] IExtensionInitOptions =
    /// True (the default) indicates that the content of this extension is ready to be shown/used as soon as the
    /// init handshake has completed. Otherwise (loaded: false), the extension must call DevOps.notifyLoadSucceeded()
    /// once it has finished loading.
    abstract loaded: bool option with get, set
    /// Extensions that show UI should specify this to true in order for the current user's theme
    /// to be applied to this extension content. Defaults to true.
    abstract applyTheme: bool option with get, set

/// Information about the current user
type [<AllowNullLiteral>] IUserContext =
    /// Identity descriptor used to represent this user. In the format of {subject-type}.{base64-encoded-subject-id}
    abstract descriptor: string with get, set
    /// Unique id for the user
    abstract id: string with get, set
    /// Name of the user (email/login)
    abstract name: string with get, set
    /// The user's display name (First name / Last name)
    abstract displayName: string with get, set
    /// Url to the user's profile image
    abstract imageUrl: string with get, set

type [<RequireQualifiedAccess>] HostType =
    | Deployment = 1
    | Enterprise = 2
    | Organization = 4

/// Information about the current DevOps host (organization)
type [<AllowNullLiteral>] IHostContext =
    /// Unique GUID for this host
    abstract id: string with get, set
    /// Name of the host (i.e. Organization name)
    abstract name: string with get, set
    /// Version of Azure DevOps used by the current host (organization)
    abstract serviceVersion: string with get, set
    /// DevOps host level
    abstract ``type``: HostType with get, set

/// Identifier for the current extension
type [<AllowNullLiteral>] IExtensionContext =
    /// Full id of the extension <publisher>.<extension>
    abstract id: string with get, set
    /// Id of the publisher
    abstract publisherId: string with get, set
    /// Id of the extension (without the publisher prefix)
    abstract extensionId: string with get, set
    /// Version of the extension
    abstract version: string with get, set

[<ImportAll("azure-devops-extension-sdk")>]
let sdk: SDK.IExports = jsNative
