// ts2fable 0.7.1
module rec CommonServices
open System
open Fable.Core
open Fable.Core.JS


module CommonServices =

    type [<StringEnum>] [<RequireQualifiedAccess>] CommonServiceIds =
        | [<CompiledName "ms.vss-features.extension-data-service">] ExtensionDataService
        | [<CompiledName "ms.vss-tfs-web.tfs-global-messages-service">] GlobalMessagesService
        | [<CompiledName "ms.vss-features.host-navigation-service">] HostNavigationService
        | [<CompiledName "ms.vss-features.host-page-layout-service">] HostPageLayoutService
        | [<CompiledName "ms.vss-features.location-service">] LocationService
        | [<CompiledName "ms.vss-tfs-web.tfs-page-data-service">] ProjectPageService

    /// Route information for the current page
    type [<AllowNullLiteral>] IPageRoute =
        /// Id of the contributed route
        abstract id: string with get, set
        /// The route values that were specified in the request
        abstract routeValues: IPageRouteRouteValues with get, set

    /// Information about a displayed navigation element
    type [<AllowNullLiteral>] INavigationElement =
        /// Unique id of the displayed navigation
        abstract id: string with get, set
        /// Name of the displayed navigation
        abstract name: string option with get, set
        /// Type of the navigation element
        abstract ``type``: string with get, set

    /// Service for interacting with the host window's navigation (URLs, new windows, etc.)
    type [<AllowNullLiteral>] IHostNavigationService =
        /// Gets the current hash.
        abstract getHash: unit -> Promise<string>
        /// Gets the set of navigation elements (like hubs and hub groups) selected on the current page.
        abstract getPageNavigationElements: unit -> Promise<ResizeArray<INavigationElement>>
        /// Gets information about the route that was matched for the current page
        abstract getPageRoute: unit -> Promise<IPageRoute>
        /// Gets the current set of query parameters in the host page's URL.
        abstract getQueryParams: unit -> Promise<IPageRouteRouteValues>
        /// <summary>Navigate the parent page to the specified url</summary>
        /// <param name="url">Url to navigate to</param>
        abstract navigate: url: string -> unit
        /// <summary>Add a callback to be invoked each time the hash navigation has changed</summary>
        /// <param name="callback">Method invoked on each navigation hash change</param>
        abstract onHashChanged: callback: (string -> unit) -> unit
        /// <summary>Open a new window to the specified url</summary>
        /// <param name="url">Url of the new window</param>
        /// <param name="features">Comma-separated list of features/specs sent as the 3rd parameter to window.open. For example: "height=400,width=400".</param>
        abstract openNewWindow: url: string * features: string -> unit
        /// Reloads the parent frame
        abstract reload: unit -> unit
        /// Replace existing hash with the provided hash from the hosted content.
        abstract replaceHash: hash: string -> unit
        /// <summary>Update the host document's title (appears as the browser tab title).</summary>
        /// <param name="title">The new title of the window</param>
        abstract setDocumentTitle: title: string -> unit
        /// Sets the provided hash from the hosted content.
        abstract setHash: hash: string -> unit
        /// <summary>Sets one or more query parameters on the host page</summary>
        /// <param name="parameters">Dictionary of query string parameters to add, update, or remove (pass an empty value to remove)</param>
        abstract setQueryParams: parameters: IHostNavigationServiceSetQueryParamsParameters -> unit

    type [<AllowNullLiteral>] IHostNavigationServiceSetQueryParamsParameters =
        [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> string with get, set

    type [<RequireQualifiedAccess>] TeamFoundationHostType =
        | Deployment = 1
        | Enterprise = 2
        | Organization = 4

    /// Service for external content to get locations
    type [<AllowNullLiteral>] ILocationService =
        /// <summary>Gets the URL for the given REST resource area</summary>
        /// <param name="resourceAreaId">- Id of the resource area</param>
        abstract getResourceAreaLocation: resourceAreaId: string -> Promise<string>
        /// <summary>Gets the location of a remote service at a given host type.</summary>
        /// <param name="serviceInstanceType">- The GUID of the service instance type to lookup</param>
        /// <param name="hostType">- The host type to lookup (defaults to the host type of the current page data)</param>
        abstract getServiceLocation: ?serviceInstanceType: string * ?hostType: TeamFoundationHostType -> Promise<string>
        /// <summary>Attemps to create a url for the specified route template and paramaters.  The url will include host path.
        /// For example, if the page url is https://dev.azure.com/foo and you try to create admin settings url for project "bar",
        /// the output will be /foo/bar/_admin.
        /// 
        /// This will asynchronously fetch a route contribution if it has not been included in page data.</summary>
        /// <param name="routeId">- Id of the route contribution</param>
        /// <param name="routeValues">- Route value replacements</param>
        /// <param name="hostPath">- Optional host path to use rather than the default host path for the page.</param>
        abstract routeUrl: routeId: string * ?routeValues: ILocationServiceRouteUrlRouteValues * ?hostPath: string -> Promise<string>

    type [<AllowNullLiteral>] ILocationServiceRouteUrlRouteValues =
        [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> string with get, set

    /// Options for showing host dialogs
    type [<AllowNullLiteral>] IDialogOptions<'TResult> =
        /// Dialog title
        abstract title: string option with get, set
        /// Callback invoked when the dialog is closed
        abstract onClose: ('TResult option -> unit) option with get, set
        /// Optional initial configuration for the dialog content
        abstract configuration: obj option with get, set
        /// If true, clicking outside the dialog closes it
        abstract lightDismiss: bool option with get, set

    /// Options for showing a message dialog
    type [<AllowNullLiteral>] IMessageDialogOptions =
        inherit IDialogOptions<bool>
        /// If true, show the cancel button
        abstract showCancel: bool option with get, set
        /// Custom text for the OK button
        abstract okText: string option with get, set
        /// Custom text for the Cancel button
        abstract cancelText: string option with get, set

    type [<RequireQualifiedAccess>] PanelSize =
        | Small = 0
        | Medium = 1
        | Large = 2

    /// Options for showing panels
    type [<AllowNullLiteral>] IPanelOptions<'TResult> =
        /// Callback invoked when the dialog is closed
        abstract onClose: ('TResult option -> unit) option with get, set
        /// The panel title you want to display.
        abstract title: string option with get, set
        /// Optional, description of panel.
        abstract description: string option with get, set
        /// Size of the panel. (defaults to PanelSize.Medium)
        abstract size: PanelSize option with get, set
        /// Optional initial configuration for the panel content
        abstract configuration: obj option with get, set

    /// Service for interacting with the layout of the page: managing full-screen mode,
    /// opening dialogs and panels
    type [<AllowNullLiteral>] IHostPageLayoutService =
        /// Gets whether the page is currently in full screen mode
        abstract getFullScreenMode: unit -> Promise<bool>
        /// Open a dialog in the host frame, showing custom external content
        abstract openCustomDialog: (string -> IDialogOptions<'TResult> -> unit) with get, set
        /// Open a dialog in the host frame, showing the specified text message, an OK and optional Cancel button
        abstract openMessageDialog: (string -> IMessageDialogOptions -> unit) with get, set
        /// Open a panel in the host frame, showing custom external content
        abstract openPanel: (string -> IPanelOptions<'TResult> -> unit) with get, set
        /// <summary>Enter or exit full screen mode</summary>
        /// <param name="fullScreenMode">True to enter full-screen mode, false to exit.</param>
        abstract setFullScreenMode: fullScreenMode: bool -> unit

    /// Interface for options that can be supplied with document actions
    type [<AllowNullLiteral>] IDocumentOptions =
        /// The scope of where the document is stored. Can be Default or User.
        abstract scopeType: string option with get, set
        /// The value of the scope where the document is stored. Can be Current or Me.
        abstract scopeValue: string option with get, set
        /// The default value to return when using getValue(). If the document has no value,
        /// this value will be used instead.
        abstract defaultValue: obj option with get, set

    /// Represents a single collection for extension data documents
    type [<AllowNullLiteral>] ExtensionDataCollection =
        /// The name of the collection
        abstract collectionName: string with get, set
        /// A list of documents belonging to the collection
        abstract documents: ResizeArray<obj option> with get, set
        /// The type of the collection's scope, such as Default or User
        abstract scopeType: string with get, set
        /// The value of the collection's scope, such as Current or Me
        abstract scopeValue: string with get, set

    type [<AllowNullLiteral>] IExtensionDataManager =
        /// <summary>Returns a promise for retrieving a setting at the provided key and scope</summary>
        /// <param name="key">- The key to retrieve a value for</param>
        /// <param name="documentOptions">- Extension document options, the default scope value is account-wide</param>
        abstract getValue: key: string * ?documentOptions: IDocumentOptions -> Promise<'T>
        /// <summary>Returns a promise for saving a setting at the provided key and scope</summary>
        /// <param name="key">- The key to save a value for</param>
        /// <param name="value">- The value to save</param>
        /// <param name="documentOptions">- Extension document options, the default scope value is account-wide</param>
        abstract setValue: key: string * value: 'T * ?documentOptions: IDocumentOptions -> Promise<'T>
        /// <summary>Returns a promise for getting a document with the provided id in the provided collection</summary>
        /// <param name="collectionName">- The name of the collection where the document lives</param>
        /// <param name="id">- The id of the document in the collection</param>
        /// <param name="documentOptions">- Extension document options, the default scope value is account-wide</param>
        abstract getDocument: collectionName: string * id: string * ?documentOptions: IDocumentOptions -> Promise<obj option>
        /// <summary>Returns a promise for getting all of the documents in the provided collection</summary>
        /// <param name="collectionName">- The name of the collection where the document lives</param>
        /// <param name="documentOptions">- Extension document options, the default scope value is account-wide</param>
        abstract getDocuments: collectionName: string * ?documentOptions: IDocumentOptions -> Promise<ResizeArray<obj option>>
        /// <summary>Returns a promise for creating a document in the provided collection</summary>
        /// <param name="collectionName">- The name of the collection where the document lives</param>
        /// <param name="doc">- The document to store</param>
        /// <param name="documentOptions">- Extension document options, the default scope value is account-wide</param>
        abstract createDocument: collectionName: string * doc: obj option * ?documentOptions: IDocumentOptions -> Promise<obj option>
        /// <summary>Returns a promise for setting a document in the provided collection
        /// Creates the document if it does not exist, otherwise updates the existing document with the id provided</summary>
        /// <param name="collectionName">- The name of the collection where the document lives</param>
        /// <param name="doc">- The document to store</param>
        /// <param name="documentOptions">- Extension document options, the default scope value is account-wide</param>
        abstract setDocument: collectionName: string * doc: obj option * ?documentOptions: IDocumentOptions -> Promise<obj option>
        /// <summary>Returns a promise for updating a document in the provided collection
        /// A document with the id provided must exist</summary>
        /// <param name="collectionName">- The name of the collection where the document lives</param>
        /// <param name="doc">- The document to store</param>
        /// <param name="documentOptions">- Extension document options, the default scope value is account-wide</param>
        abstract updateDocument: collectionName: string * doc: obj option * ?documentOptions: IDocumentOptions -> Promise<obj option>
        /// <summary>Returns a promise for deleting the document at the provided scope, collection and id</summary>
        /// <param name="collectionName">- The name of the collection where the document lives</param>
        /// <param name="id">- The id of the document in the collection</param>
        /// <param name="documentOptions">- Extension document options, the default scope value is account-wide</param>
        abstract deleteDocument: collectionName: string * id: string * ?documentOptions: IDocumentOptions -> Promise<unit>
        /// Returns a promise for querying a set of collections
        abstract queryCollectionsByName: collectionNames: ResizeArray<string> -> Promise<ResizeArray<ExtensionDataCollection>>
        /// <summary>Returns a promise for querying a set of collections</summary>
        /// <param name="collections">- The list of collections to query. Each collection will contain its collectionName, scopeType, and scopeValue</param>
        abstract queryCollections: collections: ResizeArray<ExtensionDataCollection> -> Promise<ResizeArray<ExtensionDataCollection>>

    type [<AllowNullLiteral>] IExtensionDataService =
        /// <summary>Gets a class that can be used to manage extension data.</summary>
        /// <param name="extensionId">- Id of the extension (publisher.extension)</param>
        /// <param name="accessToken">- Access token to use for the extension</param>
        abstract getExtensionDataManager: extensionId: string * accessToken: string -> Promise<IExtensionDataManager>

    type [<AllowNullLiteral>] IProjectInfo =
        /// Unique identifier (GUID) of the project
        abstract id: string with get, set
        /// Name of the project
        abstract name: string with get, set

    type [<AllowNullLiteral>] IProjectPageService =
        /// Gets the project associated with the current page
        abstract getProject: unit -> Promise<IProjectInfo option>

    /// Definition which can be specified in a contributions "icon" property which can specify a set of values for different themes.
    type [<AllowNullLiteral>] IContributedIconDefinition =
        /// Icon property (absolute url or relative asset path) to use when the current theme is a "light" theme.
        abstract light: string with get, set
        /// Icon property (absolute url or relative asset path) to use when the current theme is a "dark" theme.
        abstract dark: string with get, set

    /// Defines a button from a first- or third- party contribution
    type [<AllowNullLiteral>] IContributedButton =
        /// The id of a command contribution to execute when the button is clicked
        abstract command: string option with get, set
        /// Optional arugments to pass when invoking the supplied command
        abstract commandArguments: ResizeArray<obj option> option with get, set
        /// Id of the contribution that the button was defined in (optional, used to resolve relative icon URLs)
        abstract contributionId: string option with get, set
        /// If true, the button cannot be interacted with.
        abstract disabled: bool option with get, set
        /// Href to navigate to when the button is clicked.  Pass in if this is a link button.
        abstract href: string option with get, set
        /// Either a url (relative or fully qualified) or an IContributedIconDefinition with
        /// urls for light and dark themes. This allows the caller to use different styles of
        /// icons based on the theme type.
        abstract icon: U2<string, IContributedIconDefinition> option with get, set
        /// Set to true if this button should be styled with a primary color.
        abstract primary: bool option with get, set
        /// Optional,context in which the linked resource will open.
        abstract target: string option with get, set
        /// Text to render inside the button.
        abstract text: string option with get, set
        /// Optional value to use as an aria-label and tooltip for the button.
        abstract tooltip: string option with get, set

    /// Message links that will be formatted into the message.
    type [<AllowNullLiteral>] IGlobalMessageLink =
        /// Hyperlink text
        abstract name: string with get, set
        /// Url of the link target
        abstract href: string with get, set

    /// Optional help icon info to show after global message text
    type [<AllowNullLiteral>] IGlobalMessageHelpInfo =
        /// If supplied the help icon will act as a hyperlink to the specified target href
        abstract href: string option with get, set
        /// If supplied, hovering/focusing the help icon will show the given tooltip text
        abstract tooltip: string option with get, set

    type [<RequireQualifiedAccess>] MessageBannerLevel =
        | Info = 0
        | Warning = 1
        | Error = 2
        | Success = 3

    /// Banner Props specifying how it will be rendered by the service
    type [<AllowNullLiteral>] IGlobalMessageBanner =
        /// Buttons to display after the message
        abstract buttons: ResizeArray<IContributedButton> option with get, set
        /// Custom icon name. Must be an icon in the Azure DevOps icon font.
        abstract customIcon: string option with get, set
        /// Whether or not the message banner is dismissable. If false, do not show the close (X) icon.
        abstract dismissable: bool option with get, set
        /// Optional "?" icon to show after the message that has a tooltip with more information and/or a hyperlink.
        abstract helpInfo: IGlobalMessageHelpInfo option with get, set
        /// banner level (controls the background and icon of the banner)
        abstract level: MessageBannerLevel option with get, set
        /// Banner message. Ignored if messageFormat is also provided
        abstract message: string option with get, set
        /// Banner message format string. Arguments (like \{0\}, \{1\} are filled in with hyperlinks supplied in messageLinks)
        abstract messageFormat: string option with get, set
        /// Links to supply to the format arguments in `messageFormat`
        abstract messageLinks: ResizeArray<IGlobalMessageLink> option with get, set

    /// Toast Props with metadata to specify how it will be rendered by the service
    type [<AllowNullLiteral>] IToast =
        /// Optional text for the Call to Action
        abstract callToAction: string option with get, set
        /// Duration in ms the toast will appear for
        abstract duration: float with get, set
        /// If true, we'll immediately take down any existing toast and display this instead
        /// Otherwise, it adds it to an internal queue in the GlobalToast and will display after others in the queue
        abstract forceOverrideExisting: bool option with get, set
        /// Message to display on the Toast
        abstract message: string with get, set
        /// Optional handler for when the Call to Action is clicked
        abstract onCallToActionClick: (unit -> unit) option with get, set

    type [<AllowNullLiteral>] IGlobalMessagesService =
        /// <summary>Adds a new message banner to the displayed banners</summary>
        /// <param name="banner">- The message banner to display</param>
        abstract addBanner: banner: IGlobalMessageBanner -> unit
        /// <summary>Displays or queues a Toast to display at the bottom of the page</summary>
        /// <param name="toast">- The toast to display</param>
        abstract addToast: toast: IToast -> unit
        /// Closes the currently active global message banner
        abstract closeBanner: unit -> unit

    /// Color used in some UI components
    type [<AllowNullLiteral>] IColor =
        /// Red coordinate: 0-255
        abstract red: float with get, set
        /// Blue coordinate: 0-255
        abstract blue: float with get, set
        /// Green coordinate: 0-255
        abstract green: float with get, set
        /// Optional color name; may or may not be used by various controls
        abstract name: string option with get, set

    /// Defines a pill from a contribution
    type [<AllowNullLiteral>] IContributedPill =
        /// Background color for the pill
        /// Ignored unless variant is set to Colored
        /// If variant is set to Colored and this is not provided, we'll render as Standard and emit a warning to the console
        abstract color: IColor option with get, set
        /// Id of the contribution that the button was defined in (optional, used to resolve relative icon URLs)
        abstract contributionId: string option with get, set
        /// Either a url (relative or fully qualified) or an IContributedIconDefinition with
        /// urls for light and dark themes. This allows the caller to use different styles of
        /// icons based on the theme type.
        abstract icon: U2<string, IContributedIconDefinition> option with get, set
        /// onClick handler for the pill itself
        abstract onClick: (unit -> unit) option with get, set
        /// Renders the remove button if provided
        /// Handler to remove the pill
        abstract onRemoveClick: (unit -> unit) option with get, set
        /// The text to render inside the pill.
        abstract text: string with get, set
        /// Optional value to use as an aria-label and tooltip for the pill.
        abstract tooltip: string option with get, set

    type [<AllowNullLiteral>] IPageRouteRouteValues =
        [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> string with get, set
