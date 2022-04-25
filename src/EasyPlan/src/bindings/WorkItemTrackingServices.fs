// ts2fable 0.7.1
module rec WorkItemTrackingServices
open System
open Fable.Core
open Fable.Core.JS


module WorkItemTrackingServices =
    type WorkItem = WorkItemTracking.WorkItem
    type WorkItemField = WorkItemTracking.WorkItemField
    type WorkItemRelation = WorkItemTracking.WorkItemRelation
    type WorkItemRelationType = WorkItemTracking.WorkItemRelationType
    type IdentityRef = _____WebApi.IdentityRef

    type [<StringEnum>] [<RequireQualifiedAccess>] WorkItemTrackingServiceIds =
        | [<CompiledName "ms.vss-work-web.work-item-form-navigation-service">] WorkItemFormNavigationService
        | [<CompiledName "ms.vss-work-web.work-item-form">] WorkItemFormService

    /// Options for getting the values of a work item
    type [<AllowNullLiteral>] WorkItemOptions =
        /// Returns the original instead of updated value for the field
        abstract returnOriginalValue: bool with get, set

    /// Host service for opening the work item form
    type [<AllowNullLiteral>] IWorkItemFormNavigationService =
        /// <summary>Opens the specified work item. The host page will display the work item in a dialog,
        /// or it may update the current page view, depending on the current page.</summary>
        /// <param name="workItemId">The id of the work item to open</param>
        /// <param name="openInNewTab">(Optional) If true, opens the work item in a new tab. Default is false</param>
        abstract openWorkItem: workItemId: float * ?openInNewTab: bool -> Promise<WorkItem>
        /// <summary>Opens a new work item of the specified type. The host page will display the new work item in a dialog,
        /// or it may update the current page view, depending on the current page.</summary>
        /// <param name="workItemTypeName">The name of the work item type to open</param>
        /// <param name="initialValues">(Optional) A dictionary of any initial field values to set after opening the new work item.</param>
        abstract openNewWorkItem: workItemTypeName: string * ?initialValues: IWorkItemFormNavigationServiceOpenNewWorkItemInitialValues -> Promise<WorkItem>

    type [<AllowNullLiteral>] IWorkItemFormNavigationServiceOpenNewWorkItemInitialValues =
        [<Emit "$0[$1]{{=$2}}">] abstract Item: fieldName: string -> Object with get, set

    /// Host service for interacting with the currently active work item form (work item currently displayed in the UI).
    /// Form service depends on the current active work item context. Will throw an error when there is no open work item.
    type [<AllowNullLiteral>] IWorkItemFormService =
        /// Gets id of active work item.
        abstract getId: unit -> Promise<float>
        /// Gets active work item's latest revision.
        abstract getRevision: unit -> Promise<float>
        /// Gets active work item fields.
        abstract getFields: unit -> Promise<ResizeArray<WorkItemField>>
        /// <summary>Gets field value of the active work item.</summary>
        /// <param name="fieldReferenceName">Field reference name</param>
        /// <param name="returnOriginalValue">(Optional) If false, gets unsaved field values. Default is false.</param>
        abstract getFieldValue: fieldReferenceName: string * ?returnOriginalValue: bool -> Promise<Object>
        /// <summary>Gets field value of the active work item.</summary>
        /// <param name="fieldReferenceName">Field reference name</param>
        /// <param name="options">work item options</param>
        abstract getFieldValue: fieldReferenceName: string * ?options: WorkItemOptions -> Promise<Object>
        /// <summary>Gets identity field value of the active work item.</summary>
        /// <param name="fieldReferenceName">Field reference name</param>
        /// <param name="options">work item options</param>
        abstract getIdentityFieldValue: fieldReferenceName: string * ?options: WorkItemOptions -> Promise<IdentityRef>
        /// <summary>Gets field values of the active work item.</summary>
        /// <param name="fieldReferenceNames">An arrary of field reference names</param>
        /// <param name="returnOriginalValue">(Optional) If false, gets unsaved field values. Default is false.</param>
        abstract getFieldValues: fieldReferenceNames: ResizeArray<string> * ?returnOriginalValue: bool -> Promise<IWorkItemFormServiceGetFieldValuesPromise>
        /// <summary>Gets field values of the active work item.</summary>
        /// <param name="fieldReferenceNames">An arrary of field reference names</param>
        /// <param name="options">work item options</param>
        abstract getFieldValues: fieldReferenceNames: ResizeArray<string> * ?options: WorkItemOptions -> Promise<IWorkItemFormServiceGetFieldValuesPromise>
        /// <summary>Sets field value of the active work item.</summary>
        /// <param name="fieldReferenceName">Field reference name</param>
        /// <param name="value">Field value</param>
        abstract setFieldValue: fieldReferenceName: string * value: Object -> Promise<bool>
        /// <summary>Sets field values of the active work item.</summary>
        /// <param name="fields">A dictionary of field refName/values</param>
        abstract setFieldValues: fields: IWorkItemFormServiceSetFieldValuesFields -> Promise<IWorkItemFormServiceSetFieldValuesPromise>
        /// <summary>Gets the allowed values for the field on the active work item.</summary>
        /// <param name="fieldReferenceName">Field reference name</param>
        abstract getAllowedFieldValues: fieldReferenceName: string -> Promise<ResizeArray<Object>>
        /// Returns true if the active work item is dirty.
        abstract isDirty: unit -> Promise<bool>
        /// Returns true if the active work item is new.
        abstract isNew: unit -> Promise<bool>
        /// Returns true if the active work item fields are all valid.
        abstract isValid: unit -> Promise<bool>
        /// <summary>Marks the work item as invalid and disable saving the work item on the form.</summary>
        /// <param name="errorMessage">A custom error message that would be shown on top of the work item form.</param>
        abstract setError: errorMessage: string -> Promise<unit>
        /// Clears the error set by setError method and unblocks saving of the work item in the form.
        abstract clearError: unit -> Promise<unit>
        /// Saves the active work item.
        abstract save: unit -> Promise<unit>
        /// Refreshes the active work item. Will prompt the user if the work item is dirty.
        abstract refresh: unit -> Promise<unit>
        /// Reset any changes in the active work item. Will prompt the user to confirm.
        abstract reset: unit -> Promise<unit>
        /// Gets fields who are in an invalid state according to the work item rules. These fields need to be changed before the work item can be saved.
        abstract getInvalidFields: unit -> Promise<ResizeArray<WorkItemField>>
        /// <summary>Gets fields that have been changed either by user or by a work item rule and are in a dirty state.</summary>
        /// <param name="includeSystemChanges">A boolean value indicating if the result should include changes set by work item rules.</param>
        abstract getDirtyFields: ?includeSystemChanges: bool -> Promise<ResizeArray<WorkItemField>>
        /// <summary>Adds links of another work items or artifacts (e.g. commits, hyperlinks) to the work item. Attachment is currently not supported by this function.</summary>
        /// <param name="workItemRelations">Work item links to add.</param>
        abstract addWorkItemRelations: workItemRelations: ResizeArray<WorkItemRelation> -> Promise<unit>
        /// <summary>Removes links to another work items or artifacts (e.g. commits, hyperlinks) from the work item. Attachment is currently not supported by this function.</summary>
        /// <param name="workItemRelations">Work item links to remove.</param>
        abstract removeWorkItemRelations: workItemRelations: ResizeArray<WorkItemRelation> -> Promise<unit>
        /// Returns an array of  work item links to other work items or artifacts (e.g. commits, hyperlinks). Attachment is currently not supported by this function.
        abstract getWorkItemRelations: unit -> Promise<ResizeArray<WorkItemRelation>>
        /// <summary>Returns the REST API url of the specified work item resource.</summary>
        /// <param name="workItemId">Id of the work item that the resource url is requested for.</param>
        abstract getWorkItemResourceUrl: workItemId: float -> Promise<string>
        /// Returns an array of work item relation types.
        abstract getWorkItemRelationTypes: unit -> Promise<ResizeArray<WorkItemRelationType>>
        /// Returns true if the active work item available.
        abstract hasActiveWorkItem: unit -> Promise<bool>
        abstract beginSaveWorkItem: successCallback: (unit -> unit) * errorCallback: (unit -> unit) -> Promise<unit>

    type [<AllowNullLiteral>] IWorkItemFormServiceSetFieldValuesFields =
        [<Emit "$0[$1]{{=$2}}">] abstract Item: fieldName: string -> Object with get, set

    /// Interface defining the arguments for notifications sent by the ActiveWorkItemService
    type [<AllowNullLiteral>] IWorkItemChangedArgs =
        /// Id of the work item.
        abstract id: float with get, set

    /// Interface defining the arguments for the 'onLoaded' notification sent by the ActiveWorkItemService
    type [<AllowNullLiteral>] IWorkItemLoadedArgs =
        inherit IWorkItemChangedArgs
        /// 'true' if the work item is a 'new', unsaved work item, 'false' otherwise.
        abstract isNew: bool with get, set
        /// 'true' write rest apis are disabled. All controls should be rendered as readonly
        abstract isReadOnly: bool with get, set

    /// Interface defining the arguments for the 'onFieldChanged' notification sent by the ActiveWorkItemService
    type [<AllowNullLiteral>] IWorkItemFieldChangedArgs =
        inherit IWorkItemChangedArgs
        /// Set of fields that have been changed.  'key' is the field reference name.
        abstract changedFields: IWorkItemFieldChangedArgsChangedFields with get, set

    /// Interface defining notifications provided by the ActiveWorkItemService
    type [<AllowNullLiteral>] IWorkItemNotificationListener =
        /// <summary>Called when an extension is loaded</summary>
        /// <param name="workItemLoadedArgs">Information about the work item that was loaded.</param>
        abstract onLoaded: workItemLoadedArgs: IWorkItemLoadedArgs -> unit
        /// <summary>Called when a field is modified</summary>
        /// <param name="fieldChangedArgs">Information about the work item that was modified and the fields that were changed.</param>
        abstract onFieldChanged: fieldChangedArgs: IWorkItemFieldChangedArgs -> unit
        /// <summary>Called when a work item is saved</summary>
        /// <param name="savedEventArgs">Information about the work item that was saved.</param>
        abstract onSaved: savedEventArgs: IWorkItemChangedArgs -> unit
        /// <summary>Called when a work item is refreshed</summary>
        /// <param name="refreshEventArgs">Information about the work item that was refreshed.</param>
        abstract onRefreshed: refreshEventArgs: IWorkItemChangedArgs -> unit
        /// <summary>Called when a work item is reset (undo back to unchanged state)</summary>
        /// <param name="undoEventArgs">Information about the work item that was reset.</param>
        abstract onReset: undoEventArgs: IWorkItemChangedArgs -> unit
        /// <summary>Called when a work item is unloaded</summary>
        /// <param name="unloadedEventArgs">Information about the work item that was saved.</param>
        abstract onUnloaded: unloadedEventArgs: IWorkItemChangedArgs -> unit

    type [<AllowNullLiteral>] IWorkItemFormServiceGetFieldValuesPromise =
        [<Emit "$0[$1]{{=$2}}">] abstract Item: fieldName: string -> Object with get, set

    type [<AllowNullLiteral>] IWorkItemFormServiceSetFieldValuesPromise =
        [<Emit "$0[$1]{{=$2}}">] abstract Item: fieldName: string -> bool with get, set

    type [<AllowNullLiteral>] IWorkItemFieldChangedArgsChangedFields =
        [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set
