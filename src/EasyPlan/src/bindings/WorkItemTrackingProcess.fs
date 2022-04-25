// ts2fable 0.7.1
module rec WorkItemTrackingProcess
open System
open Fable.Core
open Fable.Core.JS


module WorkItemTrackingProcess =

    /// Class that describes a request to add a field in a work item type.
    type [<AllowNullLiteral>] AddProcessWorkItemTypeFieldRequest =
        /// The list of field allowed values.
        abstract allowedValues: ResizeArray<string> with get, set
        /// Allow setting field value to a group identity. Only applies to identity fields.
        abstract allowGroups: bool with get, set
        /// The default value of the field.
        abstract defaultValue: obj option with get, set
        /// If true the field cannot be edited.
        abstract readOnly: bool with get, set
        /// Reference name of the field.
        abstract referenceName: string with get, set
        /// If true the field cannot be empty.
        abstract required: bool with get, set

    /// Represent a control in the form.
    type [<AllowNullLiteral>] Control =
        /// Contribution for the control.
        abstract contribution: WitContribution with get, set
        /// Type of the control.
        abstract controlType: string with get, set
        /// Height of the control, for html controls.
        abstract height: float with get, set
        /// The id for the layout node.
        abstract id: string with get, set
        /// A value indicating whether this layout node has been inherited. from a parent layout.  This is expected to only be only set by the combiner.
        abstract inherited: bool with get, set
        /// A value indicating if the layout node is contribution or not.
        abstract isContribution: bool with get, set
        /// Label for the field.
        abstract label: string with get, set
        /// Inner text of the control.
        abstract metadata: string with get, set
        /// Order in which the control should appear in its group.
        abstract order: float with get, set
        /// A value indicating whether this layout node has been overridden . by a child layout.
        abstract overridden: bool with get, set
        /// A value indicating if the control is readonly.
        abstract readOnly: bool with get, set
        /// A value indicating if the control should be hidden or not.
        abstract visible: bool with get, set
        /// Watermark text for the textbox.
        abstract watermark: string with get, set

    /// Describes a process being created.
    type [<AllowNullLiteral>] CreateProcessModel =
        /// Description of the process
        abstract description: string with get, set
        /// Name of the process
        abstract name: string with get, set
        /// The ID of the parent process
        abstract parentProcessTypeId: string with get, set
        /// Reference name of process being created. If not specified, server will assign a unique reference name
        abstract referenceName: string with get, set

    /// Request object/class for creating a rule on a work item type.
    type [<AllowNullLiteral>] CreateProcessRuleRequest =
        /// List of actions to take when the rule is triggered.
        abstract actions: ResizeArray<RuleAction> with get, set
        /// List of conditions when the rule should be triggered.
        abstract conditions: ResizeArray<RuleCondition> with get, set
        /// Indicates if the rule is disabled.
        abstract isDisabled: bool with get, set
        /// Name for the rule.
        abstract name: string with get, set

    /// Class for create work item type request
    type [<AllowNullLiteral>] CreateProcessWorkItemTypeRequest =
        /// Color hexadecimal code to represent the work item type
        abstract color: string with get, set
        /// Description of the work item type
        abstract description: string with get, set
        /// Icon to represent the work item type
        abstract icon: string with get, set
        /// Parent work item type for work item type
        abstract inheritsFrom: string with get, set
        /// True if the work item type need to be disabled
        abstract isDisabled: bool with get, set
        /// Name of work item type
        abstract name: string with get, set

    type [<RequireQualifiedAccess>] CustomizationType =
        | System = 1
        | Inherited = 2
        | Custom = 3

    /// Represents the extensions part of the layout
    type [<AllowNullLiteral>] Extension =
        /// Id of the extension
        abstract id: string with get, set

    type [<AllowNullLiteral>] FieldModel =
        abstract description: string with get, set
        abstract id: string with get, set
        abstract isIdentity: bool with get, set
        abstract name: string with get, set
        abstract ``type``: FieldType with get, set
        abstract url: string with get, set

    type [<AllowNullLiteral>] FieldRuleModel =
        abstract actions: ResizeArray<RuleActionModel> with get, set
        abstract conditions: ResizeArray<RuleConditionModel> with get, set
        abstract friendlyName: string with get, set
        abstract id: string with get, set
        abstract isDisabled: bool with get, set
        abstract isSystem: bool with get, set

    type [<RequireQualifiedAccess>] FieldType =
        | String = 1
        | Integer = 2
        | DateTime = 3
        | PlainText = 5
        | Html = 7
        | TreePath = 8
        | History = 9
        | Double = 10
        | Guid = 11
        | Boolean = 12
        | Identity = 13
        | PicklistInteger = 14
        | PicklistString = 15
        | PicklistDouble = 16

    /// Describes the layout of a work item type
    type [<AllowNullLiteral>] FormLayout =
        /// Gets and sets extensions list.
        abstract extensions: ResizeArray<Extension> with get, set
        /// Top level tabs of the layout.
        abstract pages: ResizeArray<Page> with get, set
        /// Headers controls of the layout.
        abstract systemControls: ResizeArray<Control> with get, set

    type [<RequireQualifiedAccess>] GetBehaviorsExpand =
        | None = 0
        | Fields = 1
        | CombinedFields = 2

    type [<RequireQualifiedAccess>] GetProcessExpandLevel =
        | None = 0
        | Projects = 1

    type [<RequireQualifiedAccess>] GetWorkItemTypeExpand =
        | None = 0
        | States = 1
        | Behaviors = 2
        | Layout = 4

    /// Represent a group in the form that holds controls in it.
    type [<AllowNullLiteral>] Group =
        /// Contribution for the group.
        abstract contribution: WitContribution with get, set
        /// Controls to be put in the group.
        abstract controls: ResizeArray<Control> with get, set
        /// The height for the contribution.
        abstract height: float with get, set
        /// The id for the layout node.
        abstract id: string with get, set
        /// A value indicating whether this layout node has been inherited from a parent layout.  This is expected to only be only set by the combiner.
        abstract inherited: bool with get, set
        /// A value indicating if the layout node is contribution are not.
        abstract isContribution: bool with get, set
        /// Label for the group.
        abstract label: string with get, set
        /// Order in which the group should appear in the section.
        abstract order: float with get, set
        /// A value indicating whether this layout node has been overridden by a child layout.
        abstract overridden: bool with get, set
        /// A value indicating if the group should be hidden or not.
        abstract visible: bool with get, set

    /// Class that describes the work item state is hidden.
    type [<AllowNullLiteral>] HideStateModel =
        /// Returns 'true', if workitem state is hidden, 'false' otherwise.
        abstract hidden: bool with get, set

    /// Describes a page in the work item form layout
    type [<AllowNullLiteral>] Page =
        /// Contribution for the page.
        abstract contribution: WitContribution with get, set
        /// The id for the layout node.
        abstract id: string with get, set
        /// A value indicating whether this layout node has been inherited from a parent layout.  This is expected to only be only set by the combiner.
        abstract inherited: bool with get, set
        /// A value indicating if the layout node is contribution are not.
        abstract isContribution: bool with get, set
        /// The label for the page.
        abstract label: string with get, set
        /// A value indicating whether any user operations are permitted on this page and the contents of this page
        abstract locked: bool with get, set
        /// Order in which the page should appear in the layout.
        abstract order: float with get, set
        /// A value indicating whether this layout node has been overridden by a child layout.
        abstract overridden: bool with get, set
        /// The icon for the page.
        abstract pageType: PageType with get, set
        /// The sections of the page.
        abstract sections: ResizeArray<Section> with get, set
        /// A value indicating if the page should be hidden or not.
        abstract visible: bool with get, set

    type [<RequireQualifiedAccess>] PageType =
        | Custom = 1
        | History = 2
        | Links = 3
        | Attachments = 4

    /// Picklist.
    type [<AllowNullLiteral>] PickList =
        inherit PickListMetadata
        /// A list of PicklistItemModel.
        abstract items: ResizeArray<string> with get, set

    /// Metadata for picklist.
    type [<AllowNullLiteral>] PickListMetadata =
        /// ID of the picklist
        abstract id: string with get, set
        /// Indicates whether items outside of suggested list are allowed
        abstract isSuggested: bool with get, set
        /// Name of the picklist
        abstract name: string with get, set
        /// DataType of picklist
        abstract ``type``: string with get, set
        /// Url of the picklist
        abstract url: string with get, set

    /// Process Behavior Model.
    type [<AllowNullLiteral>] ProcessBehavior =
        /// Color.
        abstract color: string with get, set
        /// Indicates the type of customization on this work item. System behaviors are inherited from parent process but not modified. Inherited behaviors are modified modified behaviors that were inherited from parent process. Custom behaviors are behaviors created by user in current process.
        abstract customization: CustomizationType with get, set
        /// . Description
        abstract description: string with get, set
        /// Process Behavior Fields.
        abstract fields: ResizeArray<ProcessBehaviorField> with get, set
        /// Parent behavior reference.
        abstract inherits: ProcessBehaviorReference with get, set
        /// Behavior Name.
        abstract name: string with get, set
        /// Rank of the behavior
        abstract rank: float with get, set
        /// Behavior Id
        abstract referenceName: string with get, set
        /// Url of the behavior.
        abstract url: string with get, set

    /// Process Behavior Create Payload.
    type [<AllowNullLiteral>] ProcessBehaviorCreateRequest =
        /// Color.
        abstract color: string with get, set
        /// Parent behavior id.
        abstract inherits: string with get, set
        /// Name of the behavior.
        abstract name: string with get, set
        /// ReferenceName is optional, if not specified will be auto-generated.
        abstract referenceName: string with get, set

    /// Process Behavior Field.
    type [<AllowNullLiteral>] ProcessBehaviorField =
        /// Name of the field.
        abstract name: string with get, set
        /// Reference name of the field.
        abstract referenceName: string with get, set
        /// Url to field.
        abstract url: string with get, set

    /// Process behavior Reference.
    type [<AllowNullLiteral>] ProcessBehaviorReference =
        /// Id of a Behavior.
        abstract behaviorRefName: string with get, set
        /// Url to behavior.
        abstract url: string with get, set

    /// Process Behavior Replace Payload.
    type [<AllowNullLiteral>] ProcessBehaviorUpdateRequest =
        /// Color.
        abstract color: string with get, set
        /// Behavior Name.
        abstract name: string with get, set

    type [<RequireQualifiedAccess>] ProcessClass =
        | System = 0
        | Derived = 1
        | Custom = 2

    /// Process.
    type [<AllowNullLiteral>] ProcessInfo =
        /// Indicates the type of customization on this process. System Process is default process. Inherited Process is modified process that was System process before.
        abstract customizationType: CustomizationType with get, set
        /// Description of the process.
        abstract description: string with get, set
        /// Is the process default.
        abstract isDefault: bool with get, set
        /// Is the process enabled.
        abstract isEnabled: bool with get, set
        /// Name of the process.
        abstract name: string with get, set
        /// ID of the parent process.
        abstract parentProcessTypeId: string with get, set
        /// Projects in this process to which the user is subscribed to.
        abstract projects: ResizeArray<ProjectReference> with get, set
        /// Reference name of the process.
        abstract referenceName: string with get, set
        /// The ID of the process.
        abstract typeId: string with get, set

    type [<AllowNullLiteral>] ProcessModel =
        /// Description of the process
        abstract description: string with get, set
        /// Name of the process
        abstract name: string with get, set
        /// Projects in this process
        abstract projects: ResizeArray<ProjectReference> with get, set
        /// Properties of the process
        abstract properties: ProcessProperties with get, set
        /// Reference name of the process
        abstract referenceName: string with get, set
        /// The ID of the process
        abstract typeId: string with get, set

    /// Properties of the process.
    type [<AllowNullLiteral>] ProcessProperties =
        /// Class of the process.
        abstract ``class``: ProcessClass with get, set
        /// Is the process default process.
        abstract isDefault: bool with get, set
        /// Is the process enabled.
        abstract isEnabled: bool with get, set
        /// ID of the parent process.
        abstract parentProcessTypeId: string with get, set
        /// Version of the process.
        abstract version: string with get, set

    /// Process Rule Response.
    type [<AllowNullLiteral>] ProcessRule =
        inherit CreateProcessRuleRequest
        /// Indicates if the rule is system generated or created by user.
        abstract customizationType: CustomizationType with get, set
        /// Id to uniquely identify the rule.
        abstract id: string with get, set
        /// Resource Url.
        abstract url: string with get, set

    /// Class that describes a work item type object
    type [<AllowNullLiteral>] ProcessWorkItemType =
        abstract behaviors: ResizeArray<WorkItemTypeBehavior> with get, set
        /// Color hexadecimal code to represent the work item type
        abstract color: string with get, set
        /// Indicates the type of customization on this work item System work item types are inherited from parent process but not modified Inherited work item types are modified work item that were inherited from parent process Custom work item types are work item types that were created in the current process
        abstract customization: CustomizationType with get, set
        /// Description of the work item type
        abstract description: string with get, set
        /// Icon to represent the work item typ
        abstract icon: string with get, set
        /// Reference name of the parent work item type
        abstract inherits: string with get, set
        /// Indicates if a work item type is disabled
        abstract isDisabled: bool with get, set
        abstract layout: FormLayout with get, set
        /// Name of the work item type
        abstract name: string with get, set
        /// Reference name of work item type
        abstract referenceName: string with get, set
        abstract states: ResizeArray<WorkItemStateResultModel> with get, set
        /// Url of the work item type
        abstract url: string with get, set

    /// Class that describes a field in a work item type and its properties.
    type [<AllowNullLiteral>] ProcessWorkItemTypeField =
        /// The list of field allowed values.
        abstract allowedValues: ResizeArray<obj option> with get, set
        /// Allow setting field value to a group identity. Only applies to identity fields.
        abstract allowGroups: bool with get, set
        /// Indicates the type of customization on this work item.
        abstract customization: CustomizationType with get, set
        /// The default value of the field.
        abstract defaultValue: obj option with get, set
        /// Description of the field.
        abstract description: string with get, set
        /// Name of the field.
        abstract name: string with get, set
        /// If true the field cannot be edited.
        abstract readOnly: bool with get, set
        /// Reference name of the field.
        abstract referenceName: string with get, set
        /// If true the field cannot be empty.
        abstract required: bool with get, set
        /// Type of the field.
        abstract ``type``: FieldType with get, set
        /// Resource URL of the field.
        abstract url: string with get, set

    type [<RequireQualifiedAccess>] ProcessWorkItemTypeFieldsExpandLevel =
        | None = 0
        | AllowedValues = 1
        | All = 2

    /// Defines the project reference class.
    type [<AllowNullLiteral>] ProjectReference =
        /// Description of the project
        abstract description: string with get, set
        /// The ID of the project
        abstract id: string with get, set
        /// Name of the project
        abstract name: string with get, set
        /// Url of the project
        abstract url: string with get, set

    /// Action to take when the rule is triggered.
    type [<AllowNullLiteral>] RuleAction =
        /// Type of action to take when the rule is triggered.
        abstract actionType: RuleActionType with get, set
        /// Field on which the action should be taken.
        abstract targetField: string with get, set
        /// Value to apply on target field, once the action is taken.
        abstract value: string with get, set

    /// Action to take when the rule is triggered.
    type [<AllowNullLiteral>] RuleActionModel =
        abstract actionType: string with get, set
        abstract targetField: string with get, set
        abstract value: string with get, set

    type [<RequireQualifiedAccess>] RuleActionType =
        | MakeRequired = 1
        | MakeReadOnly = 2
        | SetDefaultValue = 3
        | SetDefaultFromClock = 4
        | SetDefaultFromCurrentUser = 5
        | SetDefaultFromField = 6
        | CopyValue = 7
        | CopyFromClock = 8
        | CopyFromCurrentUser = 9
        | CopyFromField = 10
        | SetValueToEmpty = 11
        | CopyFromServerClock = 12
        | CopyFromServerCurrentUser = 13
        | HideTargetField = 14

    /// Defines a condition on a field when the rule should be triggered.
    type [<AllowNullLiteral>] RuleCondition =
        /// Type of condition. $When. This condition limits the execution of its children to cases when another field has a particular value, i.e. when the Is value of the referenced field is equal to the given literal value. $WhenNot.This condition limits the execution of its children to cases when another field does not have a particular value, i.e.when the Is value of the referenced field is not equal to the given literal value. $WhenChanged.This condition limits the execution of its children to cases when another field has changed, i.e.when the Is value of the referenced field is not equal to the Was value of that field. $WhenNotChanged.This condition limits the execution of its children to cases when another field has not changed, i.e.when the Is value of the referenced field is equal to the Was value of that field.
        abstract conditionType: RuleConditionType with get, set
        /// Field that defines condition.
        abstract field: string with get, set
        /// Value of field to define the condition for rule.
        abstract value: string with get, set

    type [<AllowNullLiteral>] RuleConditionModel =
        abstract conditionType: string with get, set
        abstract field: string with get, set
        abstract value: string with get, set

    type [<RequireQualifiedAccess>] RuleConditionType =
        | When = 1
        | WhenNot = 2
        | WhenChanged = 3
        | WhenNotChanged = 4
        | WhenWas = 5
        | WhenStateChangedTo = 6
        | WhenStateChangedFromAndTo = 7
        | WhenWorkItemIsCreated = 8
        | WhenValueIsDefined = 9
        | WhenValueIsNotDefined = 10
        | WhenCurrentUserIsMemberOfGroup = 11
        | WhenCurrentUserIsNotMemberOfGroup = 12

    /// Defines a section of the work item form layout
    type [<AllowNullLiteral>] Section =
        /// List of child groups in this section
        abstract groups: ResizeArray<Group> with get, set
        /// The id for the layout node.
        abstract id: string with get, set
        /// A value indicating whether this layout node has been overridden by a child layout.
        abstract overridden: bool with get, set

    /// Describes a request to update a process
    type [<AllowNullLiteral>] UpdateProcessModel =
        /// New description of the process
        abstract description: string with get, set
        /// If true new projects will use this process by default
        abstract isDefault: bool with get, set
        /// If false the process will be disabled and cannot be used to create projects
        abstract isEnabled: bool with get, set
        /// New name of the process
        abstract name: string with get, set

    /// Request class/object to update the rule.
    type [<AllowNullLiteral>] UpdateProcessRuleRequest =
        inherit CreateProcessRuleRequest
        /// Id to uniquely identify the rule.
        abstract id: string with get, set

    /// Class to describe a request that updates a field's properties in a work item type.
    type [<AllowNullLiteral>] UpdateProcessWorkItemTypeFieldRequest =
        /// The list of field allowed values.
        abstract allowedValues: ResizeArray<string> with get, set
        /// Allow setting field value to a group identity. Only applies to identity fields.
        abstract allowGroups: bool with get, set
        /// The default value of the field.
        abstract defaultValue: obj option with get, set
        /// If true the field cannot be edited.
        abstract readOnly: bool with get, set
        /// The default value of the field.
        abstract required: bool with get, set

    /// Class for update request on a work item type
    type [<AllowNullLiteral>] UpdateProcessWorkItemTypeRequest =
        /// Color of the work item type
        abstract color: string with get, set
        /// Description of the work item type
        abstract description: string with get, set
        /// Icon of the work item type
        abstract icon: string with get, set
        /// If set will disable the work item type
        abstract isDisabled: bool with get, set

    /// Properties of a work item form contribution
    type [<AllowNullLiteral>] WitContribution =
        /// The id for the contribution.
        abstract contributionId: string with get, set
        /// The height for the contribution.
        abstract height: float with get, set
        /// A dictionary holding key value pairs for contribution inputs.
        abstract inputs: WitContributionInputs with get, set
        /// A value indicating if the contribution should be show on deleted workItem.
        abstract showOnDeletedWorkItem: bool with get, set

    type [<AllowNullLiteral>] WorkItemBehavior =
        abstract ``abstract``: bool with get, set
        abstract color: string with get, set
        abstract description: string with get, set
        abstract fields: ResizeArray<WorkItemBehaviorField> with get, set
        abstract id: string with get, set
        abstract inherits: WorkItemBehaviorReference with get, set
        abstract name: string with get, set
        abstract overriden: bool with get, set
        abstract rank: float with get, set
        abstract url: string with get, set

    type [<AllowNullLiteral>] WorkItemBehaviorField =
        abstract behaviorFieldId: string with get, set
        abstract id: string with get, set
        abstract url: string with get, set

    /// Reference to the behavior of a work item type.
    type [<AllowNullLiteral>] WorkItemBehaviorReference =
        /// The ID of the reference behavior.
        abstract id: string with get, set
        /// The url of the reference behavior.
        abstract url: string with get, set

    /// Class That represents a work item state input.
    type [<AllowNullLiteral>] WorkItemStateInputModel =
        /// Color of the state
        abstract color: string with get, set
        /// Name of the state
        abstract name: string with get, set
        /// Order in which state should appear
        abstract order: float with get, set
        /// Category of the state
        abstract stateCategory: string with get, set

    /// Class that represents a work item state result.
    type [<AllowNullLiteral>] WorkItemStateResultModel =
        /// Work item state color.
        abstract color: string with get, set
        /// Work item state customization type.
        abstract customizationType: CustomizationType with get, set
        /// If the Work item state is hidden.
        abstract hidden: bool with get, set
        /// Id of the Workitemstate.
        abstract id: string with get, set
        /// Work item state name.
        abstract name: string with get, set
        /// Work item state order.
        abstract order: float with get, set
        /// Work item state statecategory.
        abstract stateCategory: string with get, set
        /// Work item state url.
        abstract url: string with get, set

    /// Association between a work item type and it's behavior
    type [<AllowNullLiteral>] WorkItemTypeBehavior =
        /// Reference to the behavior of a work item type
        abstract behavior: WorkItemBehaviorReference with get, set
        /// If true the work item type is the default work item type in the behavior
        abstract isDefault: bool with get, set
        /// URL of the work item type behavior
        abstract url: string with get, set

    type [<RequireQualifiedAccess>] WorkItemTypeClass =
        | System = 0
        | Derived = 1
        | Custom = 2

    type [<AllowNullLiteral>] WorkItemTypeModel =
        abstract behaviors: ResizeArray<WorkItemTypeBehavior> with get, set
        abstract ``class``: WorkItemTypeClass with get, set
        abstract color: string with get, set
        abstract description: string with get, set
        abstract icon: string with get, set
        abstract id: string with get, set
        /// Parent WIT Id/Internal ReferenceName that it inherits from
        abstract inherits: string with get, set
        abstract isDisabled: bool with get, set
        abstract layout: FormLayout with get, set
        abstract name: string with get, set
        abstract states: ResizeArray<WorkItemStateResultModel> with get, set
        abstract url: string with get, set

    type [<AllowNullLiteral>] WitContributionInputs =
        [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set
