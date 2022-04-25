// ts2fable 0.7.1
module rec ExtensionManagementClient
open System
open Fable.Core
open Fable.Core.JS


module ExtensionManagementClient =
    module ExtensionManagement = ___ExtensionManagement_ExtensionManagement
    module Gallery = ___Gallery_Gallery
    type IVssRestClientOptions = Context.IVssRestClientOptions
    type RestClientBase = RestClientBase.RestClientBase

    type [<AllowNullLiteral>] IExports =
        abstract ExtensionManagementRestClient: ExtensionManagementRestClientStatic

    type [<AllowNullLiteral>] ExtensionManagementRestClient =
        inherit RestClientBase
        /// <param name="itemId">-</param>
        /// <param name="testCommerce">-</param>
        /// <param name="isFreeOrTrialInstall">-</param>
        /// <param name="isAccountOwner">-</param>
        /// <param name="isLinked">-</param>
        /// <param name="isConnectedServer">-</param>
        /// <param name="isBuyOperationValid">-</param>
        abstract getAcquisitionOptions: itemId: string * ?testCommerce: bool * ?isFreeOrTrialInstall: bool * ?isAccountOwner: bool * ?isLinked: bool * ?isConnectedServer: bool * ?isBuyOperationValid: bool -> Promise<ExtensionManagement.AcquisitionOptions>
        /// <param name="acquisitionRequest">-</param>
        abstract requestAcquisition: acquisitionRequest: ExtensionManagement.ExtensionAcquisitionRequest -> Promise<ExtensionManagement.ExtensionAcquisitionRequest>
        /// <param name="publisherName">-</param>
        /// <param name="extensionName">-</param>
        abstract getAuditLog: publisherName: string * extensionName: string -> Promise<ExtensionManagement.ExtensionAuditLog>
        /// <param name="publisherName">-</param>
        /// <param name="extensionName">-</param>
        /// <param name="registrationId">-</param>
        abstract registerAuthorization: publisherName: string * extensionName: string * registrationId: string -> Promise<ExtensionManagement.ExtensionAuthorization>
        /// <param name="doc">-</param>
        /// <param name="publisherName">-</param>
        /// <param name="extensionName">-</param>
        /// <param name="scopeType">-</param>
        /// <param name="scopeValue">-</param>
        /// <param name="collectionName">-</param>
        abstract createDocumentByName: doc: obj option * publisherName: string * extensionName: string * scopeType: string * scopeValue: string * collectionName: string -> Promise<obj option>
        /// <param name="publisherName">-</param>
        /// <param name="extensionName">-</param>
        /// <param name="scopeType">-</param>
        /// <param name="scopeValue">-</param>
        /// <param name="collectionName">-</param>
        /// <param name="documentId">-</param>
        abstract deleteDocumentByName: publisherName: string * extensionName: string * scopeType: string * scopeValue: string * collectionName: string * documentId: string -> Promise<unit>
        /// <param name="publisherName">-</param>
        /// <param name="extensionName">-</param>
        /// <param name="scopeType">-</param>
        /// <param name="scopeValue">-</param>
        /// <param name="collectionName">-</param>
        /// <param name="documentId">-</param>
        abstract getDocumentByName: publisherName: string * extensionName: string * scopeType: string * scopeValue: string * collectionName: string * documentId: string -> Promise<obj option>
        /// <param name="publisherName">-</param>
        /// <param name="extensionName">-</param>
        /// <param name="scopeType">-</param>
        /// <param name="scopeValue">-</param>
        /// <param name="collectionName">-</param>
        abstract getDocumentsByName: publisherName: string * extensionName: string * scopeType: string * scopeValue: string * collectionName: string -> Promise<ResizeArray<obj option>>
        /// <param name="doc">-</param>
        /// <param name="publisherName">-</param>
        /// <param name="extensionName">-</param>
        /// <param name="scopeType">-</param>
        /// <param name="scopeValue">-</param>
        /// <param name="collectionName">-</param>
        abstract setDocumentByName: doc: obj option * publisherName: string * extensionName: string * scopeType: string * scopeValue: string * collectionName: string -> Promise<obj option>
        /// <param name="doc">-</param>
        /// <param name="publisherName">-</param>
        /// <param name="extensionName">-</param>
        /// <param name="scopeType">-</param>
        /// <param name="scopeValue">-</param>
        /// <param name="collectionName">-</param>
        abstract updateDocumentByName: doc: obj option * publisherName: string * extensionName: string * scopeType: string * scopeValue: string * collectionName: string -> Promise<obj option>
        /// <summary>Query for one or more data collections for the specified extension.  Note: the token used for authorization must have been issued on behalf of the specified extension.</summary>
        /// <param name="collectionQuery">-</param>
        /// <param name="publisherName">- Name of the publisher. Example: "fabrikam".</param>
        /// <param name="extensionName">- Name of the extension. Example: "ops-tools".</param>
        abstract queryCollectionsByName: collectionQuery: ExtensionManagement.ExtensionDataCollectionQuery * publisherName: string * extensionName: string -> Promise<ResizeArray<ExtensionManagement.ExtensionDataCollection>>
        /// <summary>List state and version information for all installed extensions.</summary>
        /// <param name="includeDisabled">- If true (the default), include disabled extensions in the results.</param>
        /// <param name="includeErrors">- If true, include installed extensions in an error state in the results.</param>
        /// <param name="includeInstallationIssues">-</param>
        /// <param name="forceRefresh">-</param>
        abstract getStates: ?includeDisabled: bool * ?includeErrors: bool * ?includeInstallationIssues: bool * ?forceRefresh: bool -> Promise<ResizeArray<ExtensionManagement.ExtensionState>>
        /// <param name="query">-</param>
        abstract queryExtensions: query: ExtensionManagement.InstalledExtensionQuery -> Promise<ResizeArray<ExtensionManagement.InstalledExtension>>
        /// <summary>List the installed extensions in the account / project collection.</summary>
        /// <param name="includeDisabledExtensions">- If true (the default), include disabled extensions in the results.</param>
        /// <param name="includeErrors">- If true, include installed extensions with errors.</param>
        /// <param name="assetTypes">-</param>
        /// <param name="includeInstallationIssues">-</param>
        abstract getInstalledExtensions: ?includeDisabledExtensions: bool * ?includeErrors: bool * ?assetTypes: ResizeArray<string> * ?includeInstallationIssues: bool -> Promise<ResizeArray<ExtensionManagement.InstalledExtension>>
        /// <summary>Update an installed extension. Typically this API is used to enable or disable an extension.</summary>
        /// <param name="extension">-</param>
        abstract updateInstalledExtension: extension: ExtensionManagement.InstalledExtension -> Promise<ExtensionManagement.InstalledExtension>
        /// <summary>Get an installed extension by its publisher and extension name.</summary>
        /// <param name="publisherName">- Name of the publisher. Example: "fabrikam".</param>
        /// <param name="extensionName">- Name of the extension. Example: "ops-tools".</param>
        /// <param name="assetTypes">-</param>
        abstract getInstalledExtensionByName: publisherName: string * extensionName: string * ?assetTypes: ResizeArray<string> -> Promise<ExtensionManagement.InstalledExtension>
        /// <summary>Install the specified extension into the account / project collection.</summary>
        /// <param name="publisherName">- Name of the publisher. Example: "fabrikam".</param>
        /// <param name="extensionName">- Name of the extension. Example: "ops-tools".</param>
        /// <param name="version">-</param>
        abstract installExtensionByName: publisherName: string * extensionName: string * ?version: string -> Promise<ExtensionManagement.InstalledExtension>
        /// <summary>Uninstall the specified extension from the account / project collection.</summary>
        /// <param name="publisherName">- Name of the publisher. Example: "fabrikam".</param>
        /// <param name="extensionName">- Name of the extension. Example: "ops-tools".</param>
        /// <param name="reason">-</param>
        /// <param name="reasonCode">-</param>
        abstract uninstallExtensionByName: publisherName: string * extensionName: string * ?reason: string * ?reasonCode: string -> Promise<unit>
        /// <param name="userId">-</param>
        abstract getPolicies: userId: string -> Promise<Gallery.UserExtensionPolicy>
        /// <param name="rejectMessage">-</param>
        /// <param name="publisherName">-</param>
        /// <param name="extensionName">-</param>
        /// <param name="requesterId">-</param>
        /// <param name="state">-</param>
        abstract resolveRequest: rejectMessage: string * publisherName: string * extensionName: string * requesterId: string * state: ExtensionManagement.ExtensionRequestState -> Promise<float>
        abstract getRequests: unit -> Promise<ResizeArray<ExtensionManagement.RequestedExtension>>
        /// <param name="rejectMessage">-</param>
        /// <param name="publisherName">-</param>
        /// <param name="extensionName">-</param>
        /// <param name="state">-</param>
        abstract resolveAllRequests: rejectMessage: string * publisherName: string * extensionName: string * state: ExtensionManagement.ExtensionRequestState -> Promise<float>
        /// <param name="publisherName">-</param>
        /// <param name="extensionName">-</param>
        abstract deleteRequest: publisherName: string * extensionName: string -> Promise<unit>
        /// <param name="publisherName">-</param>
        /// <param name="extensionName">-</param>
        /// <param name="requestMessage">-</param>
        abstract requestExtension: publisherName: string * extensionName: string * requestMessage: string -> Promise<ExtensionManagement.RequestedExtension>
        abstract getToken: unit -> Promise<string>

    type [<AllowNullLiteral>] ExtensionManagementRestClientStatic =
        [<Emit "new $0($1...)">] abstract Create: options: IVssRestClientOptions -> ExtensionManagementRestClient
        abstract RESOURCE_AREA_ID: string
