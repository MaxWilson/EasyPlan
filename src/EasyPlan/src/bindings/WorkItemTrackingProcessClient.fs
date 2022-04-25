// ts2fable 0.7.1
module rec WorkItemTrackingProcessClient
open System
open Fable.Core
open Fable.Core.JS


type IVssRestClientOptions = Context.IVssRestClientOptions
type RestClientBase = RestClientBase.RestClientBase

type [<AllowNullLiteral>] IExports =
    abstract WorkItemTrackingProcessRestClient: WorkItemTrackingProcessRestClientStatic

type [<AllowNullLiteral>] WorkItemTrackingProcessRestClient =
    inherit RestClientBase
    /// <summary>Creates a single behavior in the given process.</summary>
    /// <param name="behavior">-</param>
    /// <param name="processId">- The ID of the process</param>
    abstract createProcessBehavior: behavior: WorkItemTrackingProcess.ProcessBehaviorCreateRequest * processId: string -> Promise<WorkItemTrackingProcess.ProcessBehavior>
    /// <summary>Removes a behavior in the process.</summary>
    /// <param name="processId">- The ID of the process</param>
    /// <param name="behaviorRefName">- The reference name of the behavior</param>
    abstract deleteProcessBehavior: processId: string * behaviorRefName: string -> Promise<unit>
    /// <summary>Returns a behavior of the process.</summary>
    /// <param name="processId">- The ID of the process</param>
    /// <param name="behaviorRefName">- The reference name of the behavior</param>
    /// <param name="expand">-</param>
    abstract getProcessBehavior: processId: string * behaviorRefName: string * ?expand: WorkItemTrackingProcess.GetBehaviorsExpand -> Promise<WorkItemTrackingProcess.ProcessBehavior>
    /// <summary>Returns a list of all behaviors in the process.</summary>
    /// <param name="processId">- The ID of the process</param>
    /// <param name="expand">-</param>
    abstract getProcessBehaviors: processId: string * ?expand: WorkItemTrackingProcess.GetBehaviorsExpand -> Promise<ResizeArray<WorkItemTrackingProcess.ProcessBehavior>>
    /// <summary>Replaces a behavior in the process.</summary>
    /// <param name="behaviorData">-</param>
    /// <param name="processId">- The ID of the process</param>
    /// <param name="behaviorRefName">- The reference name of the behavior</param>
    abstract updateProcessBehavior: behaviorData: WorkItemTrackingProcess.ProcessBehaviorUpdateRequest * processId: string * behaviorRefName: string -> Promise<WorkItemTrackingProcess.ProcessBehavior>
    /// <summary>Creates a control in a group.</summary>
    /// <param name="control">- The control.</param>
    /// <param name="processId">- The ID of the process.</param>
    /// <param name="witRefName">- The reference name of the work item type.</param>
    /// <param name="groupId">- The ID of the group to add the control to.</param>
    abstract createControlInGroup: control: WorkItemTrackingProcess.Control * processId: string * witRefName: string * groupId: string -> Promise<WorkItemTrackingProcess.Control>
    /// <summary>Moves a control to a specified group.</summary>
    /// <param name="control">- The control.</param>
    /// <param name="processId">- The ID of the process.</param>
    /// <param name="witRefName">- The reference name of the work item type.</param>
    /// <param name="groupId">- The ID of the group to move the control to.</param>
    /// <param name="controlId">- The ID of the control.</param>
    /// <param name="removeFromGroupId">- The group ID to remove the control from.</param>
    abstract moveControlToGroup: control: WorkItemTrackingProcess.Control * processId: string * witRefName: string * groupId: string * controlId: string * ?removeFromGroupId: string -> Promise<WorkItemTrackingProcess.Control>
    /// <summary>Removes a control from the work item form.</summary>
    /// <param name="processId">- The ID of the process.</param>
    /// <param name="witRefName">- The reference name of the work item type.</param>
    /// <param name="groupId">- The ID of the group.</param>
    /// <param name="controlId">- The ID of the control to remove.</param>
    abstract removeControlFromGroup: processId: string * witRefName: string * groupId: string * controlId: string -> Promise<unit>
    /// <summary>Updates a control on the work item form.</summary>
    /// <param name="control">- The updated control.</param>
    /// <param name="processId">- The ID of the process.</param>
    /// <param name="witRefName">- The reference name of the work item type.</param>
    /// <param name="groupId">- The ID of the group.</param>
    /// <param name="controlId">- The ID of the control.</param>
    abstract updateControl: control: WorkItemTrackingProcess.Control * processId: string * witRefName: string * groupId: string * controlId: string -> Promise<WorkItemTrackingProcess.Control>
    /// <summary>Adds a field to a work item type.</summary>
    /// <param name="field">-</param>
    /// <param name="processId">- The ID of the process.</param>
    /// <param name="witRefName">- The reference name of the work item type.</param>
    abstract addFieldToWorkItemType: field: WorkItemTrackingProcess.AddProcessWorkItemTypeFieldRequest * processId: string * witRefName: string -> Promise<WorkItemTrackingProcess.ProcessWorkItemTypeField>
    /// <summary>Returns a list of all fields in a work item type.</summary>
    /// <param name="processId">- The ID of the process.</param>
    /// <param name="witRefName">- The reference name of the work item type.</param>
    abstract getAllWorkItemTypeFields: processId: string * witRefName: string -> Promise<ResizeArray<WorkItemTrackingProcess.ProcessWorkItemTypeField>>
    /// <summary>Returns a field in a work item type.</summary>
    /// <param name="processId">- The ID of the process.</param>
    /// <param name="witRefName">- The reference name of the work item type.</param>
    /// <param name="fieldRefName">- The reference name of the field.</param>
    /// <param name="expand">-</param>
    abstract getWorkItemTypeField: processId: string * witRefName: string * fieldRefName: string * ?expand: WorkItemTrackingProcess.ProcessWorkItemTypeFieldsExpandLevel -> Promise<WorkItemTrackingProcess.ProcessWorkItemTypeField>
    /// <summary>Removes a field from a work item type. Does not permanently delete the field.</summary>
    /// <param name="processId">- The ID of the process.</param>
    /// <param name="witRefName">- The reference name of the work item type.</param>
    /// <param name="fieldRefName">- The reference name of the field.</param>
    abstract removeWorkItemTypeField: processId: string * witRefName: string * fieldRefName: string -> Promise<unit>
    /// <summary>Updates a field in a work item type.</summary>
    /// <param name="field">-</param>
    /// <param name="processId">- The ID of the process.</param>
    /// <param name="witRefName">- The reference name of the work item type.</param>
    /// <param name="fieldRefName">- The reference name of the field.</param>
    abstract updateWorkItemTypeField: field: WorkItemTrackingProcess.UpdateProcessWorkItemTypeFieldRequest * processId: string * witRefName: string * fieldRefName: string -> Promise<WorkItemTrackingProcess.ProcessWorkItemTypeField>
    /// <summary>Adds a group to the work item form.</summary>
    /// <param name="group">- The group.</param>
    /// <param name="processId">- The ID of the process.</param>
    /// <param name="witRefName">- The reference name of the work item type.</param>
    /// <param name="pageId">- The ID of the page to add the group to.</param>
    /// <param name="sectionId">- The ID of the section to add the group to.</param>
    abstract addGroup: group: WorkItemTrackingProcess.Group * processId: string * witRefName: string * pageId: string * sectionId: string -> Promise<WorkItemTrackingProcess.Group>
    /// <summary>Moves a group to a different page and section.</summary>
    /// <param name="group">- The updated group.</param>
    /// <param name="processId">- The ID of the process.</param>
    /// <param name="witRefName">- The reference name of the work item type.</param>
    /// <param name="pageId">- The ID of the page the group is in.</param>
    /// <param name="sectionId">- The ID of the section the group is i.n</param>
    /// <param name="groupId">- The ID of the group.</param>
    /// <param name="removeFromPageId">- ID of the page to remove the group from.</param>
    /// <param name="removeFromSectionId">- ID of the section to remove the group from.</param>
    abstract moveGroupToPage: group: WorkItemTrackingProcess.Group * processId: string * witRefName: string * pageId: string * sectionId: string * groupId: string * removeFromPageId: string * removeFromSectionId: string -> Promise<WorkItemTrackingProcess.Group>
    /// <summary>Moves a group to a different section.</summary>
    /// <param name="group">- The updated group.</param>
    /// <param name="processId">- The ID of the process.</param>
    /// <param name="witRefName">- The reference name of the work item type.</param>
    /// <param name="pageId">- The ID of the page the group is in.</param>
    /// <param name="sectionId">- The ID of the section the group is in.</param>
    /// <param name="groupId">- The ID of the group.</param>
    /// <param name="removeFromSectionId">- ID of the section to remove the group from.</param>
    abstract moveGroupToSection: group: WorkItemTrackingProcess.Group * processId: string * witRefName: string * pageId: string * sectionId: string * groupId: string * removeFromSectionId: string -> Promise<WorkItemTrackingProcess.Group>
    /// <summary>Removes a group from the work item form.</summary>
    /// <param name="processId">- The ID of the process</param>
    /// <param name="witRefName">- The reference name of the work item type</param>
    /// <param name="pageId">- The ID of the page the group is in</param>
    /// <param name="sectionId">- The ID of the section to the group is in</param>
    /// <param name="groupId">- The ID of the group</param>
    abstract removeGroup: processId: string * witRefName: string * pageId: string * sectionId: string * groupId: string -> Promise<unit>
    /// <summary>Updates a group in the work item form.</summary>
    /// <param name="group">- The updated group.</param>
    /// <param name="processId">- The ID of the process.</param>
    /// <param name="witRefName">- The reference name of the work item type.</param>
    /// <param name="pageId">- The ID of the page the group is in.</param>
    /// <param name="sectionId">- The ID of the section the group is in.</param>
    /// <param name="groupId">- The ID of the group.</param>
    abstract updateGroup: group: WorkItemTrackingProcess.Group * processId: string * witRefName: string * pageId: string * sectionId: string * groupId: string -> Promise<WorkItemTrackingProcess.Group>
    /// <summary>Gets the form layout.</summary>
    /// <param name="processId">- The ID of the process.</param>
    /// <param name="witRefName">- The reference name of the work item type.</param>
    abstract getFormLayout: processId: string * witRefName: string -> Promise<WorkItemTrackingProcess.FormLayout>
    /// <summary>Creates a picklist.</summary>
    /// <param name="picklist">- Picklist</param>
    abstract createList: picklist: WorkItemTrackingProcess.PickList -> Promise<WorkItemTrackingProcess.PickList>
    /// <summary>Removes a picklist.</summary>
    /// <param name="listId">- The ID of the list</param>
    abstract deleteList: listId: string -> Promise<unit>
    /// <summary>Returns a picklist.</summary>
    /// <param name="listId">- The ID of the list</param>
    abstract getList: listId: string -> Promise<WorkItemTrackingProcess.PickList>
    /// Returns meta data of the picklist.
    abstract getListsMetadata: unit -> Promise<ResizeArray<WorkItemTrackingProcess.PickListMetadata>>
    /// <summary>Updates a list.</summary>
    /// <param name="picklist">-</param>
    /// <param name="listId">- The ID of the list</param>
    abstract updateList: picklist: WorkItemTrackingProcess.PickList * listId: string -> Promise<WorkItemTrackingProcess.PickList>
    /// <summary>Adds a page to the work item form.</summary>
    /// <param name="page">- The page.</param>
    /// <param name="processId">- The ID of the process.</param>
    /// <param name="witRefName">- The reference name of the work item type.</param>
    abstract addPage: page: WorkItemTrackingProcess.Page * processId: string * witRefName: string -> Promise<WorkItemTrackingProcess.Page>
    /// <summary>Removes a page from the work item form</summary>
    /// <param name="processId">- The ID of the process</param>
    /// <param name="witRefName">- The reference name of the work item type</param>
    /// <param name="pageId">- The ID of the page</param>
    abstract removePage: processId: string * witRefName: string * pageId: string -> Promise<unit>
    /// <summary>Updates a page on the work item form</summary>
    /// <param name="page">- The page</param>
    /// <param name="processId">- The ID of the process</param>
    /// <param name="witRefName">- The reference name of the work item type</param>
    abstract updatePage: page: WorkItemTrackingProcess.Page * processId: string * witRefName: string -> Promise<WorkItemTrackingProcess.Page>
    /// <summary>Creates a process.</summary>
    /// <param name="createRequest">- CreateProcessModel.</param>
    abstract createNewProcess: createRequest: WorkItemTrackingProcess.CreateProcessModel -> Promise<WorkItemTrackingProcess.ProcessInfo>
    /// <summary>Removes a process of a specific ID.</summary>
    /// <param name="processTypeId">-</param>
    abstract deleteProcessById: processTypeId: string -> Promise<unit>
    /// <summary>Edit a process of a specific ID.</summary>
    /// <param name="updateRequest">-</param>
    /// <param name="processTypeId">-</param>
    abstract editProcess: updateRequest: WorkItemTrackingProcess.UpdateProcessModel * processTypeId: string -> Promise<WorkItemTrackingProcess.ProcessInfo>
    /// <summary>Get list of all processes including system and inherited.</summary>
    /// <param name="expand">-</param>
    abstract getListOfProcesses: ?expand: WorkItemTrackingProcess.GetProcessExpandLevel -> Promise<ResizeArray<WorkItemTrackingProcess.ProcessInfo>>
    /// <summary>Get a single process of a specified ID.</summary>
    /// <param name="processTypeId">-</param>
    /// <param name="expand">-</param>
    abstract getProcessByItsId: processTypeId: string * ?expand: WorkItemTrackingProcess.GetProcessExpandLevel -> Promise<WorkItemTrackingProcess.ProcessInfo>
    /// <summary>Adds a rule to work item type in the process.</summary>
    /// <param name="processRuleCreate">-</param>
    /// <param name="processId">- The ID of the process</param>
    /// <param name="witRefName">- The reference name of the work item type</param>
    abstract addProcessWorkItemTypeRule: processRuleCreate: WorkItemTrackingProcess.CreateProcessRuleRequest * processId: string * witRefName: string -> Promise<WorkItemTrackingProcess.ProcessRule>
    /// <summary>Removes a rule from the work item type in the process.</summary>
    /// <param name="processId">- The ID of the process</param>
    /// <param name="witRefName">- The reference name of the work item type</param>
    /// <param name="ruleId">- The ID of the rule</param>
    abstract deleteProcessWorkItemTypeRule: processId: string * witRefName: string * ruleId: string -> Promise<unit>
    /// <summary>Returns a single rule in the work item type of the process.</summary>
    /// <param name="processId">- The ID of the process</param>
    /// <param name="witRefName">- The reference name of the work item type</param>
    /// <param name="ruleId">- The ID of the rule</param>
    abstract getProcessWorkItemTypeRule: processId: string * witRefName: string * ruleId: string -> Promise<WorkItemTrackingProcess.ProcessRule>
    /// <summary>Returns a list of all rules in the work item type of the process.</summary>
    /// <param name="processId">- The ID of the process</param>
    /// <param name="witRefName">- The reference name of the work item type</param>
    abstract getProcessWorkItemTypeRules: processId: string * witRefName: string -> Promise<ResizeArray<WorkItemTrackingProcess.ProcessRule>>
    /// <summary>Updates a rule in the work item type of the process.</summary>
    /// <param name="processRule">-</param>
    /// <param name="processId">- The ID of the process</param>
    /// <param name="witRefName">- The reference name of the work item type</param>
    /// <param name="ruleId">- The ID of the rule</param>
    abstract updateProcessWorkItemTypeRule: processRule: WorkItemTrackingProcess.UpdateProcessRuleRequest * processId: string * witRefName: string * ruleId: string -> Promise<WorkItemTrackingProcess.ProcessRule>
    /// <summary>Creates a state definition in the work item type of the process.</summary>
    /// <param name="stateModel">-</param>
    /// <param name="processId">- The ID of the process</param>
    /// <param name="witRefName">- The reference name of the work item type</param>
    abstract createStateDefinition: stateModel: WorkItemTrackingProcess.WorkItemStateInputModel * processId: string * witRefName: string -> Promise<WorkItemTrackingProcess.WorkItemStateResultModel>
    /// <summary>Removes a state definition in the work item type of the process.</summary>
    /// <param name="processId">- ID of the process</param>
    /// <param name="witRefName">- The reference name of the work item type</param>
    /// <param name="stateId">- ID of the state</param>
    abstract deleteStateDefinition: processId: string * witRefName: string * stateId: string -> Promise<unit>
    /// <summary>Returns a single state definition in a work item type of the process.</summary>
    /// <param name="processId">- The ID of the process</param>
    /// <param name="witRefName">- The reference name of the work item type</param>
    /// <param name="stateId">- The ID of the state</param>
    abstract getStateDefinition: processId: string * witRefName: string * stateId: string -> Promise<WorkItemTrackingProcess.WorkItemStateResultModel>
    /// <summary>Returns a list of all state definitions in a work item type of the process.</summary>
    /// <param name="processId">- The ID of the process</param>
    /// <param name="witRefName">- The reference name of the work item type</param>
    abstract getStateDefinitions: processId: string * witRefName: string -> Promise<ResizeArray<WorkItemTrackingProcess.WorkItemStateResultModel>>
    /// <summary>Hides a state definition in the work item type of the process.Only states with customizationType:System can be hidden.</summary>
    /// <param name="hideStateModel">-</param>
    /// <param name="processId">- The ID of the process</param>
    /// <param name="witRefName">- The reference name of the work item type</param>
    /// <param name="stateId">- The ID of the state</param>
    abstract hideStateDefinition: hideStateModel: WorkItemTrackingProcess.HideStateModel * processId: string * witRefName: string * stateId: string -> Promise<WorkItemTrackingProcess.WorkItemStateResultModel>
    /// <summary>Updates a given state definition in the work item type of the process.</summary>
    /// <param name="stateModel">-</param>
    /// <param name="processId">- ID of the process</param>
    /// <param name="witRefName">- The reference name of the work item type</param>
    /// <param name="stateId">- ID of the state</param>
    abstract updateStateDefinition: stateModel: WorkItemTrackingProcess.WorkItemStateInputModel * processId: string * witRefName: string * stateId: string -> Promise<WorkItemTrackingProcess.WorkItemStateResultModel>
    /// <summary>Deletes a system control modification on the work item form.</summary>
    /// <param name="processId">- The ID of the process.</param>
    /// <param name="witRefName">- The reference name of the work item type.</param>
    /// <param name="controlId">- The ID of the control.</param>
    abstract deleteSystemControl: processId: string * witRefName: string * controlId: string -> Promise<ResizeArray<WorkItemTrackingProcess.Control>>
    /// <summary>Gets edited system controls for a work item type in a process. To get all system controls (base + edited) use layout API(s)</summary>
    /// <param name="processId">- The ID of the process.</param>
    /// <param name="witRefName">- The reference name of the work item type.</param>
    abstract getSystemControls: processId: string * witRefName: string -> Promise<ResizeArray<WorkItemTrackingProcess.Control>>
    /// <summary>Updates/adds a system control on the work item form.</summary>
    /// <param name="control">-</param>
    /// <param name="processId">- The ID of the process.</param>
    /// <param name="witRefName">- The reference name of the work item type.</param>
    /// <param name="controlId">- The ID of the control.</param>
    abstract updateSystemControl: control: WorkItemTrackingProcess.Control * processId: string * witRefName: string * controlId: string -> Promise<WorkItemTrackingProcess.Control>
    /// <summary>Creates a work item type in the process.</summary>
    /// <param name="workItemType">-</param>
    /// <param name="processId">- The ID of the process on which to create work item type.</param>
    abstract createProcessWorkItemType: workItemType: WorkItemTrackingProcess.CreateProcessWorkItemTypeRequest * processId: string -> Promise<WorkItemTrackingProcess.ProcessWorkItemType>
    /// <summary>Removes a work itewm type in the process.</summary>
    /// <param name="processId">- The ID of the process.</param>
    /// <param name="witRefName">- The reference name of the work item type.</param>
    abstract deleteProcessWorkItemType: processId: string * witRefName: string -> Promise<unit>
    /// <summary>Returns a single work item type in a process.</summary>
    /// <param name="processId">- The ID of the process</param>
    /// <param name="witRefName">- The reference name of the work item type</param>
    /// <param name="expand">- Flag to determine what properties of work item type to return</param>
    abstract getProcessWorkItemType: processId: string * witRefName: string * ?expand: WorkItemTrackingProcess.GetWorkItemTypeExpand -> Promise<WorkItemTrackingProcess.ProcessWorkItemType>
    /// <summary>Returns a list of all work item types in a process.</summary>
    /// <param name="processId">- The ID of the process</param>
    /// <param name="expand">- Flag to determine what properties of work item type to return</param>
    abstract getProcessWorkItemTypes: processId: string * ?expand: WorkItemTrackingProcess.GetWorkItemTypeExpand -> Promise<ResizeArray<WorkItemTrackingProcess.ProcessWorkItemType>>
    /// <summary>Updates a work item type of the process.</summary>
    /// <param name="workItemTypeUpdate">-</param>
    /// <param name="processId">- The ID of the process</param>
    /// <param name="witRefName">- The reference name of the work item type</param>
    abstract updateProcessWorkItemType: workItemTypeUpdate: WorkItemTrackingProcess.UpdateProcessWorkItemTypeRequest * processId: string * witRefName: string -> Promise<WorkItemTrackingProcess.ProcessWorkItemType>
    /// <summary>Adds a behavior to the work item type of the process.</summary>
    /// <param name="behavior">-</param>
    /// <param name="processId">- The ID of the process</param>
    /// <param name="witRefNameForBehaviors">- Work item type reference name for the behavior</param>
    abstract addBehaviorToWorkItemType: behavior: WorkItemTrackingProcess.WorkItemTypeBehavior * processId: string * witRefNameForBehaviors: string -> Promise<WorkItemTrackingProcess.WorkItemTypeBehavior>
    /// <summary>Returns a behavior for the work item type of the process.</summary>
    /// <param name="processId">- The ID of the process</param>
    /// <param name="witRefNameForBehaviors">- Work item type reference name for the behavior</param>
    /// <param name="behaviorRefName">- The reference name of the behavior</param>
    abstract getBehaviorForWorkItemType: processId: string * witRefNameForBehaviors: string * behaviorRefName: string -> Promise<WorkItemTrackingProcess.WorkItemTypeBehavior>
    /// <summary>Returns a list of all behaviors for the work item type of the process.</summary>
    /// <param name="processId">- The ID of the process</param>
    /// <param name="witRefNameForBehaviors">- Work item type reference name for the behavior</param>
    abstract getBehaviorsForWorkItemType: processId: string * witRefNameForBehaviors: string -> Promise<ResizeArray<WorkItemTrackingProcess.WorkItemTypeBehavior>>
    /// <summary>Removes a behavior for the work item type of the process.</summary>
    /// <param name="processId">- The ID of the process</param>
    /// <param name="witRefNameForBehaviors">- Work item type reference name for the behavior</param>
    /// <param name="behaviorRefName">- The reference name of the behavior</param>
    abstract removeBehaviorFromWorkItemType: processId: string * witRefNameForBehaviors: string * behaviorRefName: string -> Promise<unit>
    /// <summary>Updates a behavior for the work item type of the process.</summary>
    /// <param name="behavior">-</param>
    /// <param name="processId">- The ID of the process</param>
    /// <param name="witRefNameForBehaviors">- Work item type reference name for the behavior</param>
    abstract updateBehaviorToWorkItemType: behavior: WorkItemTrackingProcess.WorkItemTypeBehavior * processId: string * witRefNameForBehaviors: string -> Promise<WorkItemTrackingProcess.WorkItemTypeBehavior>

type [<AllowNullLiteral>] WorkItemTrackingProcessRestClientStatic =
    [<Emit "new $0($1...)">] abstract Create: options: IVssRestClientOptions -> WorkItemTrackingProcessRestClient
    abstract RESOURCE_AREA_ID: string
