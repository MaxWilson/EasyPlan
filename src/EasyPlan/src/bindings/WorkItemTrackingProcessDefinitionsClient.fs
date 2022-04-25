// ts2fable 0.7.1
module rec WorkItemTrackingProcessDefinitionsClient
open System
open Fable.Core
open Fable.Core.JS


module WorkItemTrackingProcessDefinitionsClient =
    module WorkItemTrackingProcessDefinitions = ___WorkItemTrackingProcessDefinitions_WorkItemTrackingProcessDefinitions
    type IVssRestClientOptions = _____Common_Context.IVssRestClientOptions
    type RestClientBase = _____Common_RestClientBase.RestClientBase

    type [<AllowNullLiteral>] IExports =
        abstract WorkItemTrackingProcessDefinitionsRestClient: WorkItemTrackingProcessDefinitionsRestClientStatic

    type [<AllowNullLiteral>] WorkItemTrackingProcessDefinitionsRestClient =
        inherit RestClientBase
        /// <summary>Creates a single behavior in the given process.</summary>
        /// <param name="behavior">-</param>
        /// <param name="processId">- The ID of the process</param>
        abstract createBehavior: behavior: WorkItemTrackingProcessDefinitions.BehaviorCreateModel * processId: string -> Promise<WorkItemTrackingProcessDefinitions.BehaviorModel>
        /// <summary>Removes a behavior in the process.</summary>
        /// <param name="processId">- The ID of the process</param>
        /// <param name="behaviorId">- The ID of the behavior</param>
        abstract deleteBehavior: processId: string * behaviorId: string -> Promise<unit>
        /// <summary>Returns a single behavior in the process.</summary>
        /// <param name="processId">- The ID of the process</param>
        /// <param name="behaviorId">- The ID of the behavior</param>
        abstract getBehavior: processId: string * behaviorId: string -> Promise<WorkItemTrackingProcessDefinitions.BehaviorModel>
        /// <summary>Returns a list of all behaviors in the process.</summary>
        /// <param name="processId">- The ID of the process</param>
        abstract getBehaviors: processId: string -> Promise<ResizeArray<WorkItemTrackingProcessDefinitions.BehaviorModel>>
        /// <summary>Replaces a behavior in the process.</summary>
        /// <param name="behaviorData">-</param>
        /// <param name="processId">- The ID of the process</param>
        /// <param name="behaviorId">- The ID of the behavior</param>
        abstract replaceBehavior: behaviorData: WorkItemTrackingProcessDefinitions.BehaviorReplaceModel * processId: string * behaviorId: string -> Promise<WorkItemTrackingProcessDefinitions.BehaviorModel>
        /// <summary>Creates a control in a group</summary>
        /// <param name="control">- The control</param>
        /// <param name="processId">- The ID of the process</param>
        /// <param name="witRefName">- The reference name of the work item type</param>
        /// <param name="groupId">- The ID of the group to add the control to</param>
        abstract addControlToGroup: control: WorkItemTrackingProcessDefinitions.Control * processId: string * witRefName: string * groupId: string -> Promise<WorkItemTrackingProcessDefinitions.Control>
        /// <summary>Updates a control on the work item form</summary>
        /// <param name="control">- The updated control</param>
        /// <param name="processId">- The ID of the process</param>
        /// <param name="witRefName">- The reference name of the work item type</param>
        /// <param name="groupId">- The ID of the group</param>
        /// <param name="controlId">- The ID of the control</param>
        abstract editControl: control: WorkItemTrackingProcessDefinitions.Control * processId: string * witRefName: string * groupId: string * controlId: string -> Promise<WorkItemTrackingProcessDefinitions.Control>
        /// <summary>Removes a control from the work item form</summary>
        /// <param name="processId">- The ID of the process</param>
        /// <param name="witRefName">- The reference name of the work item type</param>
        /// <param name="groupId">- The ID of the group</param>
        /// <param name="controlId">- The ID of the control to remove</param>
        abstract removeControlFromGroup: processId: string * witRefName: string * groupId: string * controlId: string -> Promise<unit>
        /// <summary>Moves a control to a new group</summary>
        /// <param name="control">- The control</param>
        /// <param name="processId">- The ID of the process</param>
        /// <param name="witRefName">- The reference name of the work item type</param>
        /// <param name="groupId">- The ID of the group to move the control to</param>
        /// <param name="controlId">- The id of the control</param>
        /// <param name="removeFromGroupId">- The group to remove the control from</param>
        abstract setControlInGroup: control: WorkItemTrackingProcessDefinitions.Control * processId: string * witRefName: string * groupId: string * controlId: string * ?removeFromGroupId: string -> Promise<WorkItemTrackingProcessDefinitions.Control>
        /// <summary>Creates a single field in the process.</summary>
        /// <param name="field">-</param>
        /// <param name="processId">- The ID of the process</param>
        abstract createField: field: WorkItemTrackingProcessDefinitions.FieldModel * processId: string -> Promise<WorkItemTrackingProcessDefinitions.FieldModel>
        /// <summary>Updates a given field in the process.</summary>
        /// <param name="field">-</param>
        /// <param name="processId">- The ID of the process</param>
        abstract updateField: field: WorkItemTrackingProcessDefinitions.FieldUpdate * processId: string -> Promise<WorkItemTrackingProcessDefinitions.FieldModel>
        /// <summary>Adds a group to the work item form</summary>
        /// <param name="group">- The group</param>
        /// <param name="processId">- The ID of the process</param>
        /// <param name="witRefName">- The reference name of the work item type</param>
        /// <param name="pageId">- The ID of the page to add the group to</param>
        /// <param name="sectionId">- The ID of the section to add the group to</param>
        abstract addGroup: group: WorkItemTrackingProcessDefinitions.Group * processId: string * witRefName: string * pageId: string * sectionId: string -> Promise<WorkItemTrackingProcessDefinitions.Group>
        /// <summary>Updates a group in the work item form</summary>
        /// <param name="group">- The updated group</param>
        /// <param name="processId">- The ID of the process</param>
        /// <param name="witRefName">- The reference name of the work item type</param>
        /// <param name="pageId">- The ID of the page the group is in</param>
        /// <param name="sectionId">- The ID of the section the group is in</param>
        /// <param name="groupId">- The ID of the group</param>
        abstract editGroup: group: WorkItemTrackingProcessDefinitions.Group * processId: string * witRefName: string * pageId: string * sectionId: string * groupId: string -> Promise<WorkItemTrackingProcessDefinitions.Group>
        /// <summary>Removes a group from the work item form</summary>
        /// <param name="processId">- The ID of the process</param>
        /// <param name="witRefName">- The reference name of the work item type</param>
        /// <param name="pageId">- The ID of the page the group is in</param>
        /// <param name="sectionId">- The ID of the section to the group is in</param>
        /// <param name="groupId">- The ID of the group</param>
        abstract removeGroup: processId: string * witRefName: string * pageId: string * sectionId: string * groupId: string -> Promise<unit>
        /// <summary>Moves a group to a different page and section</summary>
        /// <param name="group">- The updated group</param>
        /// <param name="processId">- The ID of the process</param>
        /// <param name="witRefName">- The reference name of the work item type</param>
        /// <param name="pageId">- The ID of the page the group is in</param>
        /// <param name="sectionId">- The ID of the section the group is in</param>
        /// <param name="groupId">- The ID of the group</param>
        /// <param name="removeFromPageId">- ID of the page to remove the group from</param>
        /// <param name="removeFromSectionId">- ID of the section to remove the group from</param>
        abstract setGroupInPage: group: WorkItemTrackingProcessDefinitions.Group * processId: string * witRefName: string * pageId: string * sectionId: string * groupId: string * removeFromPageId: string * removeFromSectionId: string -> Promise<WorkItemTrackingProcessDefinitions.Group>
        /// <summary>Moves a group to a different section</summary>
        /// <param name="group">- The updated group</param>
        /// <param name="processId">- The ID of the process</param>
        /// <param name="witRefName">- The reference name of the work item type</param>
        /// <param name="pageId">- The ID of the page the group is in</param>
        /// <param name="sectionId">- The ID of the section the group is in</param>
        /// <param name="groupId">- The ID of the group</param>
        /// <param name="removeFromSectionId">- ID of the section to remove the group from</param>
        abstract setGroupInSection: group: WorkItemTrackingProcessDefinitions.Group * processId: string * witRefName: string * pageId: string * sectionId: string * groupId: string * removeFromSectionId: string -> Promise<WorkItemTrackingProcessDefinitions.Group>
        /// <summary>Gets the form layout</summary>
        /// <param name="processId">- The ID of the process</param>
        /// <param name="witRefName">- The reference name of the work item type</param>
        abstract getFormLayout: processId: string * witRefName: string -> Promise<WorkItemTrackingProcessDefinitions.FormLayout>
        /// Returns meta data of the picklist.
        abstract getListsMetadata: unit -> Promise<ResizeArray<WorkItemTrackingProcessDefinitions.PickListMetadataModel>>
        /// <summary>Creates a picklist.</summary>
        /// <param name="picklist">-</param>
        abstract createList: picklist: WorkItemTrackingProcessDefinitions.PickListModel -> Promise<WorkItemTrackingProcessDefinitions.PickListModel>
        /// <summary>Removes a picklist.</summary>
        /// <param name="listId">- The ID of the list</param>
        abstract deleteList: listId: string -> Promise<unit>
        /// <summary>Returns a picklist.</summary>
        /// <param name="listId">- The ID of the list</param>
        abstract getList: listId: string -> Promise<WorkItemTrackingProcessDefinitions.PickListModel>
        /// <summary>Updates a list.</summary>
        /// <param name="picklist">-</param>
        /// <param name="listId">- The ID of the list</param>
        abstract updateList: picklist: WorkItemTrackingProcessDefinitions.PickListModel * listId: string -> Promise<WorkItemTrackingProcessDefinitions.PickListModel>
        /// <summary>Adds a page to the work item form</summary>
        /// <param name="page">- The page</param>
        /// <param name="processId">- The ID of the process</param>
        /// <param name="witRefName">- The reference name of the work item type</param>
        abstract addPage: page: WorkItemTrackingProcessDefinitions.Page * processId: string * witRefName: string -> Promise<WorkItemTrackingProcessDefinitions.Page>
        /// <summary>Updates a page on the work item form</summary>
        /// <param name="page">- The page</param>
        /// <param name="processId">- The ID of the process</param>
        /// <param name="witRefName">- The reference name of the work item type</param>
        abstract editPage: page: WorkItemTrackingProcessDefinitions.Page * processId: string * witRefName: string -> Promise<WorkItemTrackingProcessDefinitions.Page>
        /// <summary>Removes a page from the work item form</summary>
        /// <param name="processId">- The ID of the process</param>
        /// <param name="witRefName">- The reference name of the work item type</param>
        /// <param name="pageId">- The ID of the page</param>
        abstract removePage: processId: string * witRefName: string * pageId: string -> Promise<unit>
        /// <summary>Creates a state definition in the work item type of the process.</summary>
        /// <param name="stateModel">-</param>
        /// <param name="processId">- The ID of the process</param>
        /// <param name="witRefName">- The reference name of the work item type</param>
        abstract createStateDefinition: stateModel: WorkItemTrackingProcessDefinitions.WorkItemStateInputModel * processId: string * witRefName: string -> Promise<WorkItemTrackingProcessDefinitions.WorkItemStateResultModel>
        /// <summary>Removes a state definition in the work item type of the process.</summary>
        /// <param name="processId">- ID of the process</param>
        /// <param name="witRefName">- The reference name of the work item type</param>
        /// <param name="stateId">- ID of the state</param>
        abstract deleteStateDefinition: processId: string * witRefName: string * stateId: string -> Promise<unit>
        /// <summary>Returns a state definition in the work item type of the process.</summary>
        /// <param name="processId">- The ID of the process</param>
        /// <param name="witRefName">- The reference name of the work item type</param>
        /// <param name="stateId">- The ID of the state</param>
        abstract getStateDefinition: processId: string * witRefName: string * stateId: string -> Promise<WorkItemTrackingProcessDefinitions.WorkItemStateResultModel>
        /// <summary>Returns a list of all state definitions in the work item type of the process.</summary>
        /// <param name="processId">- The ID of the process</param>
        /// <param name="witRefName">- The reference name of the work item type</param>
        abstract getStateDefinitions: processId: string * witRefName: string -> Promise<ResizeArray<WorkItemTrackingProcessDefinitions.WorkItemStateResultModel>>
        /// <summary>Hides a state definition in the work item type of the process.</summary>
        /// <param name="hideStateModel">-</param>
        /// <param name="processId">- The ID of the process</param>
        /// <param name="witRefName">- The reference name of the work item type</param>
        /// <param name="stateId">- The ID of the state</param>
        abstract hideStateDefinition: hideStateModel: WorkItemTrackingProcessDefinitions.HideStateModel * processId: string * witRefName: string * stateId: string -> Promise<WorkItemTrackingProcessDefinitions.WorkItemStateResultModel>
        /// <summary>Updates a given state definition in the work item type of the process.</summary>
        /// <param name="stateModel">-</param>
        /// <param name="processId">- ID of the process</param>
        /// <param name="witRefName">- The reference name of the work item type</param>
        /// <param name="stateId">- ID of the state</param>
        abstract updateStateDefinition: stateModel: WorkItemTrackingProcessDefinitions.WorkItemStateInputModel * processId: string * witRefName: string * stateId: string -> Promise<WorkItemTrackingProcessDefinitions.WorkItemStateResultModel>
        /// <summary>Adds a behavior to the work item type of the process.</summary>
        /// <param name="behavior">-</param>
        /// <param name="processId">- The ID of the process</param>
        /// <param name="witRefNameForBehaviors">- Work item type reference name for the behavior</param>
        abstract addBehaviorToWorkItemType: behavior: WorkItemTrackingProcessDefinitions.WorkItemTypeBehavior * processId: string * witRefNameForBehaviors: string -> Promise<WorkItemTrackingProcessDefinitions.WorkItemTypeBehavior>
        /// <summary>Returns a behavior for the work item type of the process.</summary>
        /// <param name="processId">- The ID of the process</param>
        /// <param name="witRefNameForBehaviors">- Work item type reference name for the behavior</param>
        /// <param name="behaviorRefName">- The reference name of the behavior</param>
        abstract getBehaviorForWorkItemType: processId: string * witRefNameForBehaviors: string * behaviorRefName: string -> Promise<WorkItemTrackingProcessDefinitions.WorkItemTypeBehavior>
        /// <summary>Returns a list of all behaviors for the work item type of the process.</summary>
        /// <param name="processId">- The ID of the process</param>
        /// <param name="witRefNameForBehaviors">- Work item type reference name for the behavior</param>
        abstract getBehaviorsForWorkItemType: processId: string * witRefNameForBehaviors: string -> Promise<ResizeArray<WorkItemTrackingProcessDefinitions.WorkItemTypeBehavior>>
        /// <summary>Removes a behavior for the work item type of the process.</summary>
        /// <param name="processId">- The ID of the process</param>
        /// <param name="witRefNameForBehaviors">- Work item type reference name for the behavior</param>
        /// <param name="behaviorRefName">- The reference name of the behavior</param>
        abstract removeBehaviorFromWorkItemType: processId: string * witRefNameForBehaviors: string * behaviorRefName: string -> Promise<unit>
        /// <summary>Updates default work item type for the behavior of the process.</summary>
        /// <param name="behavior">-</param>
        /// <param name="processId">- The ID of the process</param>
        /// <param name="witRefNameForBehaviors">- Work item type reference name for the behavior</param>
        abstract updateBehaviorToWorkItemType: behavior: WorkItemTrackingProcessDefinitions.WorkItemTypeBehavior * processId: string * witRefNameForBehaviors: string -> Promise<WorkItemTrackingProcessDefinitions.WorkItemTypeBehavior>
        /// <summary>Creates a work item type in the process.</summary>
        /// <param name="workItemType">-</param>
        /// <param name="processId">- The ID of the process</param>
        abstract createWorkItemType: workItemType: WorkItemTrackingProcessDefinitions.WorkItemTypeModel * processId: string -> Promise<WorkItemTrackingProcessDefinitions.WorkItemTypeModel>
        /// <summary>Removes a work itewm type in the process.</summary>
        /// <param name="processId">- The ID of the process</param>
        /// <param name="witRefName">- The reference name of the work item type</param>
        abstract deleteWorkItemType: processId: string * witRefName: string -> Promise<unit>
        /// <summary>Returns a work item type of the process.</summary>
        /// <param name="processId">- The ID of the process</param>
        /// <param name="witRefName">- The reference name of the work item type</param>
        /// <param name="expand">-</param>
        abstract getWorkItemType: processId: string * witRefName: string * ?expand: WorkItemTrackingProcessDefinitions.GetWorkItemTypeExpand -> Promise<WorkItemTrackingProcessDefinitions.WorkItemTypeModel>
        /// <summary>Returns a list of all work item types in the process.</summary>
        /// <param name="processId">- The ID of the process</param>
        /// <param name="expand">-</param>
        abstract getWorkItemTypes: processId: string * ?expand: WorkItemTrackingProcessDefinitions.GetWorkItemTypeExpand -> Promise<ResizeArray<WorkItemTrackingProcessDefinitions.WorkItemTypeModel>>
        /// <summary>Updates a work item type of the process.</summary>
        /// <param name="workItemTypeUpdate">-</param>
        /// <param name="processId">- The ID of the process</param>
        /// <param name="witRefName">- The reference name of the work item type</param>
        abstract updateWorkItemType: workItemTypeUpdate: WorkItemTrackingProcessDefinitions.WorkItemTypeUpdateModel * processId: string * witRefName: string -> Promise<WorkItemTrackingProcessDefinitions.WorkItemTypeModel>
        /// <summary>Adds a field to the work item type in the process.</summary>
        /// <param name="field">-</param>
        /// <param name="processId">- The ID of the process</param>
        /// <param name="witRefNameForFields">- Work item type reference name for the field</param>
        abstract addFieldToWorkItemType: field: WorkItemTrackingProcessDefinitions.WorkItemTypeFieldModel2 * processId: string * witRefNameForFields: string -> Promise<WorkItemTrackingProcessDefinitions.WorkItemTypeFieldModel2>
        /// <summary>Returns a single field in the work item type of the process.</summary>
        /// <param name="processId">- The ID of the process</param>
        /// <param name="witRefNameForFields">- Work item type reference name for fields</param>
        /// <param name="fieldRefName">- The reference name of the field</param>
        abstract getWorkItemTypeField: processId: string * witRefNameForFields: string * fieldRefName: string -> Promise<WorkItemTrackingProcessDefinitions.WorkItemTypeFieldModel2>
        /// <summary>Returns a list of all fields in the work item type of the process.</summary>
        /// <param name="processId">- The ID of the process</param>
        /// <param name="witRefNameForFields">- Work item type reference name for fields</param>
        abstract getWorkItemTypeFields: processId: string * witRefNameForFields: string -> Promise<ResizeArray<WorkItemTrackingProcessDefinitions.WorkItemTypeFieldModel2>>
        /// <summary>Removes a field in the work item type of the process.</summary>
        /// <param name="processId">- The ID of the process</param>
        /// <param name="witRefNameForFields">- Work item type reference name for fields</param>
        /// <param name="fieldRefName">- The reference name of the field</param>
        abstract removeFieldFromWorkItemType: processId: string * witRefNameForFields: string * fieldRefName: string -> Promise<unit>

    type [<AllowNullLiteral>] WorkItemTrackingProcessDefinitionsRestClientStatic =
        [<Emit "new $0($1...)">] abstract Create: options: IVssRestClientOptions -> WorkItemTrackingProcessDefinitionsRestClient
        abstract RESOURCE_AREA_ID: string
