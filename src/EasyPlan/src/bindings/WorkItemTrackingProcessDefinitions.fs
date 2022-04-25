// ts2fable 0.7.1
module rec WorkItemTrackingProcessDefinitions
open System
open Fable.Core
open Fable.Core.JS

type [<AllowNullLiteral>] BehaviorCreateModel =
    /// Color
    abstract color: string with get, set
    /// Optional - Id
    abstract id: string with get, set
    /// Parent behavior id
    abstract inherits: string with get, set
    /// Name of the behavior
    abstract name: string with get, set

type [<AllowNullLiteral>] BehaviorModel =
    /// Is the behavior abstract (i.e. can not be associated with any work item type)
    abstract ``abstract``: bool with get, set
    /// Color
    abstract color: string with get, set
    /// Description
    abstract description: string with get, set
    /// Behavior Id
    abstract id: string with get, set
    /// Parent behavior reference
    abstract inherits: WorkItemBehaviorReference with get, set
    /// Behavior Name
    abstract name: string with get, set
    /// Is the behavior overrides a behavior from system process
    abstract overridden: bool with get, set
    /// Rank
    abstract rank: float with get, set
    /// Url of the behavior
    abstract url: string with get, set

type [<AllowNullLiteral>] BehaviorReplaceModel =
    /// Color
    abstract color: string with get, set
    /// Behavior Name
    abstract name: string with get, set

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
    /// A value indicating whether this layout node has been inherited from a parent layout.  This is expected to only be only set by the combiner.
    abstract inherited: bool with get, set
    /// A value indicating if the layout node is contribution or not.
    abstract isContribution: bool with get, set
    /// Label for the field
    abstract label: string with get, set
    /// Inner text of the control.
    abstract metadata: string with get, set
    abstract order: float with get, set
    /// A value indicating whether this layout node has been overridden by a child layout.
    abstract overridden: bool with get, set
    /// A value indicating if the control is readonly.
    abstract readOnly: bool with get, set
    /// A value indicating if the control should be hidden or not.
    abstract visible: bool with get, set
    /// Watermark text for the textbox.
    abstract watermark: string with get, set

/// Represents the extensions part of the layout
type [<AllowNullLiteral>] Extension =
    abstract id: string with get, set

type [<AllowNullLiteral>] FieldModel =
    /// Description about field
    abstract description: string with get, set
    /// ID of the field
    abstract id: string with get, set
    /// Name of the field
    abstract name: string with get, set
    /// Reference to picklist in this field
    abstract pickList: PickListMetadataModel with get, set
    /// Type of field
    abstract ``type``: FieldType with get, set
    /// Url to the field
    abstract url: string with get, set

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

type [<AllowNullLiteral>] FieldUpdate =
    abstract description: string with get, set
    abstract id: string with get, set

type [<AllowNullLiteral>] FormLayout =
    /// Gets and sets extensions list
    abstract extensions: ResizeArray<Extension> with get, set
    /// Top level tabs of the layout.
    abstract pages: ResizeArray<Page> with get, set
    /// Headers controls of the layout.
    abstract systemControls: ResizeArray<Control> with get, set

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

type [<AllowNullLiteral>] HideStateModel =
    abstract hidden: bool with get, set

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

type [<AllowNullLiteral>] PickListItemModel =
    abstract id: string with get, set
    abstract value: string with get, set

type [<AllowNullLiteral>] PickListMetadataModel =
    /// ID of the picklist
    abstract id: string with get, set
    /// Is input values by user only limited to suggested values
    abstract isSuggested: bool with get, set
    /// Name of the picklist
    abstract name: string with get, set
    /// Type of picklist
    abstract ``type``: string with get, set
    /// Url of the picklist
    abstract url: string with get, set

type [<AllowNullLiteral>] PickListModel =
    inherit PickListMetadataModel
    /// A list of PicklistItemModel
    abstract items: ResizeArray<PickListItemModel> with get, set

/// A layout node holding groups together in a page
type [<AllowNullLiteral>] Section =
    abstract groups: ResizeArray<Group> with get, set
    /// The id for the layout node.
    abstract id: string with get, set
    /// A value indicating whether this layout node has been overridden by a child layout.
    abstract overridden: bool with get, set

type [<AllowNullLiteral>] WitContribution =
    /// The id for the contribution.
    abstract contributionId: string with get, set
    /// The height for the contribution.
    abstract height: float with get, set
    /// A dictionary holding key value pairs for contribution inputs.
    abstract inputs: WitContributionInputs with get, set
    /// A value indicating if the contribution should be show on deleted workItem.
    abstract showOnDeletedWorkItem: bool with get, set

type [<AllowNullLiteral>] WorkItemBehaviorReference =
    /// The ID of the reference behavior
    abstract id: string with get, set
    /// The url of the reference behavior
    abstract url: string with get, set

type [<AllowNullLiteral>] WorkItemStateInputModel =
    /// Color of the state
    abstract color: string with get, set
    /// Name of the state
    abstract name: string with get, set
    /// Order in which state should appear
    abstract order: float with get, set
    /// Category of the state
    abstract stateCategory: string with get, set

type [<AllowNullLiteral>] WorkItemStateResultModel =
    /// Color of the state
    abstract color: string with get, set
    /// Is the state hidden
    abstract hidden: bool with get, set
    /// The ID of the State
    abstract id: string with get, set
    /// Name of the state
    abstract name: string with get, set
    /// Order in which state should appear
    abstract order: float with get, set
    /// Category of the state
    abstract stateCategory: string with get, set
    /// Url of the state
    abstract url: string with get, set

type [<AllowNullLiteral>] WorkItemTypeBehavior =
    abstract behavior: WorkItemBehaviorReference with get, set
    abstract isDefault: bool with get, set
    abstract url: string with get, set

type [<RequireQualifiedAccess>] WorkItemTypeClass =
    | System = 0
    | Derived = 1
    | Custom = 2

type [<AllowNullLiteral>] WorkItemTypeFieldModel =
    abstract allowGroups: bool with get, set
    abstract defaultValue: string with get, set
    abstract name: string with get, set
    abstract pickList: PickListMetadataModel with get, set
    abstract readOnly: bool with get, set
    abstract referenceName: string with get, set
    abstract required: bool with get, set
    abstract ``type``: FieldType with get, set
    abstract url: string with get, set

/// New version of WorkItemTypeFieldModel supporting defaultValue as object (such as IdentityRef)
type [<AllowNullLiteral>] WorkItemTypeFieldModel2 =
    abstract allowGroups: bool with get, set
    abstract defaultValue: obj option with get, set
    abstract name: string with get, set
    abstract pickList: PickListMetadataModel with get, set
    abstract readOnly: bool with get, set
    abstract referenceName: string with get, set
    abstract required: bool with get, set
    abstract ``type``: FieldType with get, set
    abstract url: string with get, set

type [<AllowNullLiteral>] WorkItemTypeModel =
    /// Behaviors of the work item type
    abstract behaviors: ResizeArray<WorkItemTypeBehavior> with get, set
    /// Class of the work item type
    abstract ``class``: WorkItemTypeClass with get, set
    /// Color of the work item type
    abstract color: string with get, set
    /// Description of the work item type
    abstract description: string with get, set
    /// Icon of the work item type
    abstract icon: string with get, set
    /// The ID of the work item type
    abstract id: string with get, set
    /// Parent WIT Id/Internal ReferenceName that it inherits from
    abstract inherits: string with get, set
    /// Is work item type disabled
    abstract isDisabled: bool with get, set
    /// Layout of the work item type
    abstract layout: FormLayout with get, set
    /// Name of the work item type
    abstract name: string with get, set
    /// States of the work item type
    abstract states: ResizeArray<WorkItemStateResultModel> with get, set
    /// Url of the work item type
    abstract url: string with get, set

type [<AllowNullLiteral>] WorkItemTypeUpdateModel =
    /// Color of the work item type
    abstract color: string with get, set
    /// Description of the work item type
    abstract description: string with get, set
    /// Icon of the work item type
    abstract icon: string with get, set
    /// Is the workitem type to be disabled
    abstract isDisabled: bool with get, set

type [<AllowNullLiteral>] WitContributionInputs =
    [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set
