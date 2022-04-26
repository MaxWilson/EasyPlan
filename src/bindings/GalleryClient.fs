// ts2fable 0.7.1
module rec GalleryClient
open System
open Fable.Core
open Fable.Core.JS
type IVssRestClientOptions = Context.IVssRestClientOptions
type RestClientBase = RestClientBase.RestClientBase

type [<AllowNullLiteral>] IExports =
    abstract GalleryRestClient: GalleryRestClientStatic

type [<AllowNullLiteral>] GalleryRestClient =
    inherit RestClientBase
    /// <param name="extensionId">-</param>
    /// <param name="accountName">-</param>
    abstract shareExtensionById: extensionId: string * accountName: string -> Promise<unit>
    /// <param name="extensionId">-</param>
    /// <param name="accountName">-</param>
    abstract unshareExtensionById: extensionId: string * accountName: string -> Promise<unit>
    /// <param name="publisherName">-</param>
    /// <param name="extensionName">-</param>
    /// <param name="accountName">-</param>
    abstract shareExtension: publisherName: string * extensionName: string * accountName: string -> Promise<unit>
    /// <param name="publisherName">-</param>
    /// <param name="extensionName">-</param>
    /// <param name="accountName">-</param>
    abstract unshareExtension: publisherName: string * extensionName: string * accountName: string -> Promise<unit>
    /// <param name="itemId">-</param>
    /// <param name="installationTarget">-</param>
    /// <param name="testCommerce">-</param>
    /// <param name="isFreeOrTrialInstall">-</param>
    abstract getAcquisitionOptions: itemId: string * installationTarget: string * ?testCommerce: bool * ?isFreeOrTrialInstall: bool -> Promise<Gallery.AcquisitionOptions>
    /// <param name="acquisitionRequest">-</param>
    abstract requestAcquisition: acquisitionRequest: Gallery.ExtensionAcquisitionRequest -> Promise<Gallery.ExtensionAcquisitionRequest>
    /// <param name="publisherName">-</param>
    /// <param name="extensionName">-</param>
    /// <param name="version">-</param>
    /// <param name="assetType">-</param>
    /// <param name="accountToken">-</param>
    /// <param name="acceptDefault">-</param>
    /// <param name="accountTokenHeader">- Header to pass the account token</param>
    abstract getAssetByName: publisherName: string * extensionName: string * version: string * assetType: string * ?accountToken: string * ?acceptDefault: bool * ?accountTokenHeader: String -> Promise<ArrayBuffer>
    /// <param name="extensionId">-</param>
    /// <param name="version">-</param>
    /// <param name="assetType">-</param>
    /// <param name="accountToken">-</param>
    /// <param name="acceptDefault">-</param>
    /// <param name="accountTokenHeader">- Header to pass the account token</param>
    abstract getAsset: extensionId: string * version: string * assetType: string * ?accountToken: string * ?acceptDefault: bool * ?accountTokenHeader: String -> Promise<ArrayBuffer>
    /// <param name="publisherName">-</param>
    /// <param name="extensionName">-</param>
    /// <param name="version">-</param>
    /// <param name="assetType">-</param>
    /// <param name="accountToken">-</param>
    /// <param name="accountTokenHeader">- Header to pass the account token</param>
    abstract getAssetAuthenticated: publisherName: string * extensionName: string * version: string * assetType: string * ?accountToken: string * ?accountTokenHeader: String -> Promise<ArrayBuffer>
    /// <param name="publisherName">-</param>
    /// <param name="azurePublisherId">-</param>
    abstract associateAzurePublisher: publisherName: string * azurePublisherId: string -> Promise<Gallery.AzurePublisher>
    /// <param name="publisherName">-</param>
    abstract queryAssociatedAzurePublisher: publisherName: string -> Promise<Gallery.AzurePublisher>
    /// <param name="languages">-</param>
    abstract getCategories: ?languages: string -> Promise<ResizeArray<string>>
    /// <param name="categoryName">-</param>
    /// <param name="languages">-</param>
    /// <param name="product">-</param>
    abstract getCategoryDetails: categoryName: string * ?languages: string * ?product: string -> Promise<Gallery.CategoriesResult>
    /// <param name="product">-</param>
    /// <param name="categoryId">-</param>
    /// <param name="lcid">-</param>
    /// <param name="source">-</param>
    /// <param name="productVersion">-</param>
    /// <param name="skus">-</param>
    /// <param name="subSkus">-</param>
    abstract getCategoryTree: product: string * categoryId: string * ?lcid: float * ?source: string * ?productVersion: string * ?skus: string * ?subSkus: string -> Promise<Gallery.ProductCategory>
    /// <param name="product">-</param>
    /// <param name="lcid">-</param>
    /// <param name="source">-</param>
    /// <param name="productVersion">-</param>
    /// <param name="skus">-</param>
    /// <param name="subSkus">-</param>
    abstract getRootCategories: product: string * ?lcid: float * ?source: string * ?productVersion: string * ?skus: string * ?subSkus: string -> Promise<Gallery.ProductCategoriesResult>
    /// <param name="publisherName">-</param>
    /// <param name="extensionName">-</param>
    /// <param name="version">-</param>
    abstract getCertificate: publisherName: string * extensionName: string * ?version: string -> Promise<ArrayBuffer>
    /// <param name="publisherName">-</param>
    /// <param name="extensionName">-</param>
    abstract getContentVerificationLog: publisherName: string * extensionName: string -> Promise<ArrayBuffer>
    /// <param name="publisherName">-</param>
    /// <param name="extensionName">-</param>
    abstract createDraftForEditExtension: publisherName: string * extensionName: string -> Promise<Gallery.ExtensionDraft>
    /// <param name="draftPatch">-</param>
    /// <param name="publisherName">-</param>
    /// <param name="extensionName">-</param>
    /// <param name="draftId">-</param>
    abstract performEditExtensionDraftOperation: draftPatch: Gallery.ExtensionDraftPatch * publisherName: string * extensionName: string * draftId: string -> Promise<Gallery.ExtensionDraft>
    /// <param name="content">- Content to upload</param>
    /// <param name="publisherName">-</param>
    /// <param name="extensionName">-</param>
    /// <param name="draftId">-</param>
    /// <param name="fileName">- Header to pass the filename of the uploaded data</param>
    abstract updatePayloadInDraftForEditExtension: content: obj option * publisherName: string * extensionName: string * draftId: string * ?fileName: String -> Promise<Gallery.ExtensionDraft>
    /// <param name="content">- Content to upload</param>
    /// <param name="publisherName">-</param>
    /// <param name="extensionName">-</param>
    /// <param name="draftId">-</param>
    /// <param name="assetType">-</param>
    abstract addAssetForEditExtensionDraft: content: string * publisherName: string * extensionName: string * draftId: string * assetType: string -> Promise<Gallery.ExtensionDraftAsset>
    /// <param name="content">- Content to upload</param>
    /// <param name="publisherName">-</param>
    /// <param name="product">- Header to pass the product type of the payload file</param>
    /// <param name="fileName">- Header to pass the filename of the uploaded data</param>
    abstract createDraftForNewExtension: content: obj option * publisherName: string * product: String * ?fileName: String -> Promise<Gallery.ExtensionDraft>
    /// <param name="draftPatch">-</param>
    /// <param name="publisherName">-</param>
    /// <param name="draftId">-</param>
    abstract performNewExtensionDraftOperation: draftPatch: Gallery.ExtensionDraftPatch * publisherName: string * draftId: string -> Promise<Gallery.ExtensionDraft>
    /// <param name="content">- Content to upload</param>
    /// <param name="publisherName">-</param>
    /// <param name="draftId">-</param>
    /// <param name="fileName">- Header to pass the filename of the uploaded data</param>
    abstract updatePayloadInDraftForNewExtension: content: obj option * publisherName: string * draftId: string * ?fileName: String -> Promise<Gallery.ExtensionDraft>
    /// <param name="content">- Content to upload</param>
    /// <param name="publisherName">-</param>
    /// <param name="draftId">-</param>
    /// <param name="assetType">-</param>
    abstract addAssetForNewExtensionDraft: content: string * publisherName: string * draftId: string * assetType: string -> Promise<Gallery.ExtensionDraftAsset>
    /// <param name="publisherName">-</param>
    /// <param name="draftId">-</param>
    /// <param name="assetType">-</param>
    /// <param name="extensionName">-</param>
    abstract getAssetFromEditExtensionDraft: publisherName: string * draftId: string * assetType: string * extensionName: string -> Promise<ArrayBuffer>
    /// <param name="publisherName">-</param>
    /// <param name="draftId">-</param>
    /// <param name="assetType">-</param>
    abstract getAssetFromNewExtensionDraft: publisherName: string * draftId: string * assetType: string -> Promise<ArrayBuffer>
    /// <summary>Get install/uninstall events of an extension. If both count and afterDate parameters are specified, count takes precedence.</summary>
    /// <param name="publisherName">- Name of the publisher</param>
    /// <param name="extensionName">- Name of the extension</param>
    /// <param name="count">- Count of events to fetch, applies to each event type.</param>
    /// <param name="afterDate">- Fetch events that occurred on or after this date</param>
    /// <param name="include">- Filter options. Supported values: install, uninstall, review, acquisition, sales. Default is to fetch all types of events</param>
    /// <param name="includeProperty">- Event properties to include. Currently only 'lastContactDetails' is supported for uninstall events</param>
    abstract getExtensionEvents: publisherName: string * extensionName: string * ?count: float * ?afterDate: DateTime * ?``include``: string * ?includeProperty: string -> Promise<Gallery.ExtensionEvents>
    /// <summary>API endpoint to publish extension install/uninstall events. This is meant to be invoked by EMS only for sending us data related to install/uninstall of an extension.</summary>
    /// <param name="extensionEvents">-</param>
    abstract publishExtensionEvents: extensionEvents: ResizeArray<Gallery.ExtensionEvents> -> Promise<unit>
    /// <param name="extensionQuery">-</param>
    /// <param name="accountToken">-</param>
    /// <param name="accountTokenHeader">- Header to pass the account token</param>
    abstract queryExtensions: extensionQuery: Gallery.ExtensionQuery * ?accountToken: string * ?accountTokenHeader: String -> Promise<Gallery.ExtensionQueryResult>
    /// <param name="content">- Content to upload</param>
    abstract createExtension: content: obj option -> Promise<Gallery.PublishedExtension>
    /// <param name="extensionId">-</param>
    /// <param name="version">-</param>
    abstract deleteExtensionById: extensionId: string * ?version: string -> Promise<unit>
    /// <param name="extensionId">-</param>
    /// <param name="version">-</param>
    /// <param name="flags">-</param>
    abstract getExtensionById: extensionId: string * ?version: string * ?flags: Gallery.ExtensionQueryFlags -> Promise<Gallery.PublishedExtension>
    /// <param name="extensionId">-</param>
    abstract updateExtensionById: extensionId: string -> Promise<Gallery.PublishedExtension>
    /// <param name="content">- Content to upload</param>
    /// <param name="publisherName">-</param>
    abstract createExtensionWithPublisher: content: obj option * publisherName: string -> Promise<Gallery.PublishedExtension>
    /// <param name="publisherName">-</param>
    /// <param name="extensionName">-</param>
    /// <param name="version">-</param>
    abstract deleteExtension: publisherName: string * extensionName: string * ?version: string -> Promise<unit>
    /// <param name="publisherName">-</param>
    /// <param name="extensionName">-</param>
    /// <param name="version">-</param>
    /// <param name="flags">-</param>
    /// <param name="accountToken">-</param>
    /// <param name="accountTokenHeader">- Header to pass the account token</param>
    abstract getExtension: publisherName: string * extensionName: string * ?version: string * ?flags: Gallery.ExtensionQueryFlags * ?accountToken: string * ?accountTokenHeader: String -> Promise<Gallery.PublishedExtension>
    /// <summary>REST endpoint to update an extension.</summary>
    /// <param name="content">- Content to upload</param>
    /// <param name="publisherName">- Name of the publisher</param>
    /// <param name="extensionName">- Name of the extension</param>
    /// <param name="bypassScopeCheck">- This parameter decides if the scope change check needs to be invoked or not</param>
    abstract updateExtension: content: obj option * publisherName: string * extensionName: string * ?bypassScopeCheck: bool -> Promise<Gallery.PublishedExtension>
    /// <param name="publisherName">-</param>
    /// <param name="extensionName">-</param>
    /// <param name="flags">-</param>
    abstract updateExtensionProperties: publisherName: string * extensionName: string * flags: Gallery.PublishedExtensionFlags -> Promise<Gallery.PublishedExtension>
    /// <param name="publisherName">-</param>
    /// <param name="extensionName">-</param>
    /// <param name="hostType">-</param>
    /// <param name="hostName">-</param>
    abstract shareExtensionWithHost: publisherName: string * extensionName: string * hostType: string * hostName: string -> Promise<unit>
    /// <param name="publisherName">-</param>
    /// <param name="extensionName">-</param>
    /// <param name="hostType">-</param>
    /// <param name="hostName">-</param>
    abstract unshareExtensionWithHost: publisherName: string * extensionName: string * hostType: string * hostName: string -> Promise<unit>
    /// <param name="azureRestApiRequestModel">-</param>
    abstract extensionValidator: azureRestApiRequestModel: Gallery.AzureRestApiRequestModel -> Promise<unit>
    /// <summary>Send Notification</summary>
    /// <param name="notificationData">- Denoting the data needed to send notification</param>
    abstract sendNotifications: notificationData: Gallery.NotificationsData -> Promise<unit>
    /// <summary>This endpoint gets hit when you download a VSTS extension from the Web UI</summary>
    /// <param name="publisherName">-</param>
    /// <param name="extensionName">-</param>
    /// <param name="version">-</param>
    /// <param name="accountToken">-</param>
    /// <param name="acceptDefault">-</param>
    /// <param name="accountTokenHeader">- Header to pass the account token</param>
    abstract getPackage: publisherName: string * extensionName: string * version: string * ?accountToken: string * ?acceptDefault: bool * ?accountTokenHeader: String -> Promise<ArrayBuffer>
    /// <param name="publisherName">-</param>
    /// <param name="extensionName">-</param>
    /// <param name="version">-</param>
    /// <param name="assetType">-</param>
    /// <param name="assetToken">-</param>
    /// <param name="accountToken">-</param>
    /// <param name="acceptDefault">-</param>
    /// <param name="accountTokenHeader">- Header to pass the account token</param>
    abstract getAssetWithToken: publisherName: string * extensionName: string * version: string * assetType: string * ?assetToken: string * ?accountToken: string * ?acceptDefault: bool * ?accountTokenHeader: String -> Promise<ArrayBuffer>
    /// <summary>Delete publisher asset like logo</summary>
    /// <param name="publisherName">- Internal name of the publisher</param>
    /// <param name="assetType">- Type of asset. Default value is 'logo'.</param>
    abstract deletePublisherAsset: publisherName: string * ?assetType: string -> Promise<unit>
    /// <summary>Get publisher asset like logo as a stream</summary>
    /// <param name="publisherName">- Internal name of the publisher</param>
    /// <param name="assetType">- Type of asset. Default value is 'logo'.</param>
    abstract getPublisherAsset: publisherName: string * ?assetType: string -> Promise<ArrayBuffer>
    /// <summary>Update publisher asset like logo. It accepts asset file as an octet stream and file name is passed in header values.</summary>
    /// <param name="content">- Content to upload</param>
    /// <param name="publisherName">- Internal name of the publisher</param>
    /// <param name="assetType">- Type of asset. Default value is 'logo'.</param>
    /// <param name="fileName">- Header to pass the filename of the uploaded data</param>
    abstract updatePublisherAsset: content: obj option * publisherName: string * ?assetType: string * ?fileName: String -> Promise<GalleryRestClientUpdatePublisherAssetPromise>
    /// <param name="publisherQuery">-</param>
    abstract queryPublishers: publisherQuery: Gallery.PublisherQuery -> Promise<Gallery.PublisherQueryResult>
    /// <param name="publisher">-</param>
    abstract createPublisher: publisher: Gallery.Publisher -> Promise<Gallery.Publisher>
    /// <param name="publisherName">-</param>
    abstract deletePublisher: publisherName: string -> Promise<unit>
    /// <param name="publisherName">-</param>
    /// <param name="flags">-</param>
    abstract getPublisher: publisherName: string * ?flags: float -> Promise<Gallery.Publisher>
    /// <param name="publisher">-</param>
    /// <param name="publisherName">-</param>
    abstract updatePublisher: publisher: Gallery.Publisher * publisherName: string -> Promise<Gallery.Publisher>
    /// <summary>Endpoint to add/modify publisher membership. Currently Supports only addition/modification of 1 user at a time Works only for adding members of same tenant.</summary>
    /// <param name="roleAssignments">- List of user identifiers(email address) and role to be added. Currently only one entry is supported.</param>
    /// <param name="publisherName">- The name/id of publisher to which users have to be added</param>
    /// <param name="limitToCallerIdentityDomain">- Should cross tenant addtions be allowed or not.</param>
    abstract updatePublisherMembers: roleAssignments: ResizeArray<Gallery.PublisherUserRoleAssignmentRef> * publisherName: string * ?limitToCallerIdentityDomain: bool -> Promise<ResizeArray<Gallery.PublisherRoleAssignment>>
    /// <summary>Returns a list of questions with their responses associated with an extension.</summary>
    /// <param name="publisherName">- Name of the publisher who published the extension.</param>
    /// <param name="extensionName">- Name of the extension.</param>
    /// <param name="count">- Number of questions to retrieve (defaults to 10).</param>
    /// <param name="page">- Page number from which set of questions are to be retrieved.</param>
    /// <param name="afterDate">- If provided, results questions are returned which were posted after this date</param>
    abstract getQuestions: publisherName: string * extensionName: string * ?count: float * ?page: float * ?afterDate: DateTime -> Promise<Gallery.QuestionsResult>
    /// <summary>Flags a concern with an existing question for an extension.</summary>
    /// <param name="concern">- User reported concern with a question for the extension.</param>
    /// <param name="pubName">- Name of the publisher who published the extension.</param>
    /// <param name="extName">- Name of the extension.</param>
    /// <param name="questionId">- Identifier of the question to be updated for the extension.</param>
    abstract reportQuestion: concern: Gallery.Concern * pubName: string * extName: string * questionId: float -> Promise<Gallery.Concern>
    /// <summary>Creates a new question for an extension.</summary>
    /// <param name="question">- Question to be created for the extension.</param>
    /// <param name="publisherName">- Name of the publisher who published the extension.</param>
    /// <param name="extensionName">- Name of the extension.</param>
    abstract createQuestion: question: Gallery.Question * publisherName: string * extensionName: string -> Promise<Gallery.Question>
    /// <summary>Deletes an existing question and all its associated responses for an extension. (soft delete)</summary>
    /// <param name="publisherName">- Name of the publisher who published the extension.</param>
    /// <param name="extensionName">- Name of the extension.</param>
    /// <param name="questionId">- Identifier of the question to be deleted for the extension.</param>
    abstract deleteQuestion: publisherName: string * extensionName: string * questionId: float -> Promise<unit>
    /// <summary>Updates an existing question for an extension.</summary>
    /// <param name="question">- Updated question to be set for the extension.</param>
    /// <param name="publisherName">- Name of the publisher who published the extension.</param>
    /// <param name="extensionName">- Name of the extension.</param>
    /// <param name="questionId">- Identifier of the question to be updated for the extension.</param>
    abstract updateQuestion: question: Gallery.Question * publisherName: string * extensionName: string * questionId: float -> Promise<Gallery.Question>
    /// <summary>Creates a new response for a given question for an extension.</summary>
    /// <param name="response">- Response to be created for the extension.</param>
    /// <param name="publisherName">- Name of the publisher who published the extension.</param>
    /// <param name="extensionName">- Name of the extension.</param>
    /// <param name="questionId">- Identifier of the question for which response is to be created for the extension.</param>
    abstract createResponse: response: Gallery.Response * publisherName: string * extensionName: string * questionId: float -> Promise<Gallery.Response>
    /// <summary>Deletes a response for an extension. (soft delete)</summary>
    /// <param name="publisherName">- Name of the publisher who published the extension.</param>
    /// <param name="extensionName">- Name of the extension.</param>
    /// <param name="questionId">- Identifies the question whose response is to be deleted.</param>
    /// <param name="responseId">- Identifies the response to be deleted.</param>
    abstract deleteResponse: publisherName: string * extensionName: string * questionId: float * responseId: float -> Promise<unit>
    /// <summary>Updates an existing response for a given question for an extension.</summary>
    /// <param name="response">- Updated response to be set for the extension.</param>
    /// <param name="publisherName">- Name of the publisher who published the extension.</param>
    /// <param name="extensionName">- Name of the extension.</param>
    /// <param name="questionId">- Identifier of the question for which response is to be updated for the extension.</param>
    /// <param name="responseId">- Identifier of the response which has to be updated.</param>
    abstract updateResponse: response: Gallery.Response * publisherName: string * extensionName: string * questionId: float * responseId: float -> Promise<Gallery.Response>
    /// <summary>Returns extension reports</summary>
    /// <param name="publisherName">- Name of the publisher who published the extension</param>
    /// <param name="extensionName">- Name of the extension</param>
    /// <param name="days">- Last n days report. If afterDate and days are specified, days will take priority</param>
    /// <param name="count">- Number of events to be returned</param>
    /// <param name="afterDate">- Use if you want to fetch events newer than the specified date</param>
    abstract getExtensionReports: publisherName: string * extensionName: string * ?days: float * ?count: float * ?afterDate: DateTime -> Promise<obj option>
    /// <summary>Returns a list of reviews associated with an extension</summary>
    /// <param name="publisherName">- Name of the publisher who published the extension</param>
    /// <param name="extensionName">- Name of the extension</param>
    /// <param name="count">- Number of reviews to retrieve (defaults to 5)</param>
    /// <param name="filterOptions">- FilterOptions to filter out empty reviews etcetera, defaults to none</param>
    /// <param name="beforeDate">- Use if you want to fetch reviews older than the specified date, defaults to null</param>
    /// <param name="afterDate">- Use if you want to fetch reviews newer than the specified date, defaults to null</param>
    abstract getReviews: publisherName: string * extensionName: string * ?count: float * ?filterOptions: Gallery.ReviewFilterOptions * ?beforeDate: DateTime * ?afterDate: DateTime -> Promise<Gallery.ReviewsResult>
    /// <summary>Returns a summary of the reviews</summary>
    /// <param name="pubName">- Name of the publisher who published the extension</param>
    /// <param name="extName">- Name of the extension</param>
    /// <param name="beforeDate">- Use if you want to fetch summary of reviews older than the specified date, defaults to null</param>
    /// <param name="afterDate">- Use if you want to fetch summary of reviews newer than the specified date, defaults to null</param>
    abstract getReviewsSummary: pubName: string * extName: string * ?beforeDate: DateTime * ?afterDate: DateTime -> Promise<Gallery.ReviewSummary>
    /// <summary>Creates a new review for an extension</summary>
    /// <param name="review">- Review to be created for the extension</param>
    /// <param name="pubName">- Name of the publisher who published the extension</param>
    /// <param name="extName">- Name of the extension</param>
    abstract createReview: review: Gallery.Review * pubName: string * extName: string -> Promise<Gallery.Review>
    /// <summary>Deletes a review</summary>
    /// <param name="pubName">- Name of the pubilsher who published the extension</param>
    /// <param name="extName">- Name of the extension</param>
    /// <param name="reviewId">- Id of the review which needs to be updated</param>
    abstract deleteReview: pubName: string * extName: string * reviewId: float -> Promise<unit>
    /// <summary>Updates or Flags a review</summary>
    /// <param name="reviewPatch">- ReviewPatch object which contains the changes to be applied to the review</param>
    /// <param name="pubName">- Name of the pubilsher who published the extension</param>
    /// <param name="extName">- Name of the extension</param>
    /// <param name="reviewId">- Id of the review which needs to be updated</param>
    abstract updateReview: reviewPatch: Gallery.ReviewPatch * pubName: string * extName: string * reviewId: float -> Promise<Gallery.ReviewPatch>
    /// <param name="category">-</param>
    abstract createCategory: category: Gallery.ExtensionCategory -> Promise<Gallery.ExtensionCategory>
    /// <summary>Get all setting entries for the given user/all-users scope</summary>
    /// <param name="userScope">- User-Scope at which to get the value. Should be "me" for the current user or "host" for all users.</param>
    /// <param name="key">- Optional key under which to filter all the entries</param>
    abstract getGalleryUserSettings: userScope: string * ?key: string -> Promise<GalleryRestClientGetGalleryUserSettingsPromise>
    /// <summary>Set all setting entries for the given user/all-users scope</summary>
    /// <param name="entries">- A key-value pair of all settings that need to be set</param>
    /// <param name="userScope">- User-Scope at which to get the value. Should be "me" for the current user or "host" for all users.</param>
    abstract setGalleryUserSettings: entries: GalleryRestClientSetGalleryUserSettingsEntries * userScope: string -> Promise<unit>
    /// <param name="keyType">-</param>
    /// <param name="expireCurrentSeconds">-</param>
    abstract generateKey: keyType: string * ?expireCurrentSeconds: float -> Promise<unit>
    /// <param name="keyType">-</param>
    abstract getSigningKey: keyType: string -> Promise<string>
    /// <param name="extensionStatisticsUpdate">-</param>
    /// <param name="publisherName">-</param>
    /// <param name="extensionName">-</param>
    abstract updateExtensionStatistics: extensionStatisticsUpdate: Gallery.ExtensionStatisticUpdate * publisherName: string * extensionName: string -> Promise<unit>
    /// <param name="publisherName">-</param>
    /// <param name="extensionName">-</param>
    /// <param name="days">-</param>
    /// <param name="aggregate">-</param>
    /// <param name="afterDate">-</param>
    abstract getExtensionDailyStats: publisherName: string * extensionName: string * ?days: float * ?aggregate: Gallery.ExtensionStatsAggregateType * ?afterDate: DateTime -> Promise<Gallery.ExtensionDailyStats>
    /// <summary>This route/location id only supports HTTP POST anonymously, so that the page view daily stat can be incremented from Marketplace client. Trying to call GET on this route should result in an exception. Without this explicit implementation, calling GET on this public route invokes the above GET implementation GetExtensionDailyStats.</summary>
    /// <param name="publisherName">- Name of the publisher</param>
    /// <param name="extensionName">- Name of the extension</param>
    /// <param name="version">- Version of the extension</param>
    abstract getExtensionDailyStatsAnonymous: publisherName: string * extensionName: string * version: string -> Promise<Gallery.ExtensionDailyStats>
    /// <summary>Increments a daily statistic associated with the extension</summary>
    /// <param name="publisherName">- Name of the publisher</param>
    /// <param name="extensionName">- Name of the extension</param>
    /// <param name="version">- Version of the extension</param>
    /// <param name="statType">- Type of stat to increment</param>
    abstract incrementExtensionDailyStat: publisherName: string * extensionName: string * version: string * statType: string -> Promise<unit>
    /// <param name="publisherName">-</param>
    /// <param name="extensionName">-</param>
    /// <param name="version">-</param>
    abstract getVerificationLog: publisherName: string * extensionName: string * version: string -> Promise<ArrayBuffer>

type [<AllowNullLiteral>] GalleryRestClientSetGalleryUserSettingsEntries =
    [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

type [<AllowNullLiteral>] GalleryRestClientStatic =
    [<Emit "new $0($1...)">] abstract Create: options: IVssRestClientOptions -> GalleryRestClient
    abstract RESOURCE_AREA_ID: string

type [<AllowNullLiteral>] GalleryRestClientUpdatePublisherAssetPromise =
    [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> string with get, set

type [<AllowNullLiteral>] GalleryRestClientGetGalleryUserSettingsPromise =
    [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set
