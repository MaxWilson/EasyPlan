// ts2fable 0.7.1
module rec FormInput
open System
open Fable.Core
open Fable.Core.JS


module FormInput =

    type [<RequireQualifiedAccess>] InputDataType =
        | None = 0
        | String = 10
        | Number = 20
        | Boolean = 30
        | Guid = 40
        | Uri = 50

    /// Describes an input for subscriptions.
    type [<AllowNullLiteral>] InputDescriptor =
        /// The ids of all inputs that the value of this input is dependent on.
        abstract dependencyInputIds: ResizeArray<string> with get, set
        /// Description of what this input is used for
        abstract description: string with get, set
        /// The group localized name to which this input belongs and can be shown as a header for the container that will include all the inputs in the group.
        abstract groupName: string with get, set
        /// If true, the value information for this input is dynamic and should be fetched when the value of dependency inputs change.
        abstract hasDynamicValueInformation: bool with get, set
        /// Identifier for the subscription input
        abstract id: string with get, set
        /// Mode in which the value of this input should be entered
        abstract inputMode: InputMode with get, set
        /// Gets whether this input is confidential, such as for a password or application key
        abstract isConfidential: bool with get, set
        /// Localized name which can be shown as a label for the subscription input
        abstract name: string with get, set
        /// Custom properties for the input which can be used by the service provider
        abstract properties: InputDescriptorProperties with get, set
        /// Underlying data type for the input value. When this value is specified, InputMode, Validation and Values are optional.
        abstract ``type``: string with get, set
        /// Gets whether this input is included in the default generated action description.
        abstract useInDefaultDescription: bool with get, set
        /// Information to use to validate this input's value
        abstract validation: InputValidation with get, set
        /// A hint for input value. It can be used in the UI as the input placeholder.
        abstract valueHint: string with get, set
        /// Information about possible values for this input
        abstract values: InputValues with get, set

    /// Defines a filter for subscription inputs. The filter matches a set of inputs if any (one or more) of the groups evaluates to true.
    type [<AllowNullLiteral>] InputFilter =
        /// Groups of input filter expressions. This filter matches a set of inputs if any (one or more) of the groups evaluates to true.
        abstract conditions: ResizeArray<InputFilterCondition> with get, set

    /// An expression which can be applied to filter a list of subscription inputs
    type [<AllowNullLiteral>] InputFilterCondition =
        /// Whether or not to do a case sensitive match
        abstract caseSensitive: bool with get, set
        /// The Id of the input to filter on
        abstract inputId: string with get, set
        /// The "expected" input value to compare with the actual input value
        abstract inputValue: string with get, set
        /// The operator applied between the expected and actual input value
        abstract operator: InputFilterOperator with get, set

    type [<RequireQualifiedAccess>] InputFilterOperator =
        | Equals = 0
        | NotEquals = 1

    type [<RequireQualifiedAccess>] InputMode =
        | None = 0
        | TextBox = 10
        | PasswordBox = 20
        | Combo = 30
        | RadioButtons = 40
        | CheckBox = 50
        | TextArea = 60

    /// Describes what values are valid for a subscription input
    type [<AllowNullLiteral>] InputValidation =
        /// Gets or sets the data data type to validate.
        abstract dataType: InputDataType with get, set
        /// Gets or sets if this is a required field.
        abstract isRequired: bool with get, set
        /// Gets or sets the maximum length of this descriptor.
        abstract maxLength: float with get, set
        /// Gets or sets the minimum value for this descriptor.
        abstract maxValue: float with get, set
        /// Gets or sets the minimum length of this descriptor.
        abstract minLength: float with get, set
        /// Gets or sets the minimum value for this descriptor.
        abstract minValue: float with get, set
        /// Gets or sets the pattern to validate.
        abstract pattern: string with get, set
        /// Gets or sets the error on pattern mismatch.
        abstract patternMismatchErrorMessage: string with get, set

    /// Information about a single value for an input
    type [<AllowNullLiteral>] InputValue =
        /// Any other data about this input
        abstract data: InputDescriptorProperties with get, set
        /// The text to show for the display of this value
        abstract displayValue: string with get, set
        /// The value to store for this input
        abstract value: string with get, set

    /// Information about the possible/allowed values for a given subscription input
    type [<AllowNullLiteral>] InputValues =
        /// The default value to use for this input
        abstract defaultValue: string with get, set
        /// Errors encountered while computing dynamic values.
        abstract error: InputValuesError with get, set
        /// The id of the input
        abstract inputId: string with get, set
        /// Should this input be disabled
        abstract isDisabled: bool with get, set
        /// Should the value be restricted to one of the values in the PossibleValues (True) or are the values in PossibleValues just a suggestion (False)
        abstract isLimitedToPossibleValues: bool with get, set
        /// Should this input be made read-only
        abstract isReadOnly: bool with get, set
        /// Possible values that this input can take
        abstract possibleValues: ResizeArray<InputValue> with get, set

    /// Error information related to a subscription input value.
    type [<AllowNullLiteral>] InputValuesError =
        /// The error message.
        abstract message: string with get, set

    type [<AllowNullLiteral>] InputValuesQuery =
        abstract currentValues: InputValuesQueryCurrentValues with get, set
        /// The input values to return on input, and the result from the consumer on output.
        abstract inputValues: ResizeArray<InputValues> with get, set
        /// Subscription containing information about the publisher/consumer and the current input values
        abstract resource: obj option with get, set

    type [<AllowNullLiteral>] InputDescriptorProperties =
        [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

    type [<AllowNullLiteral>] InputValuesQueryCurrentValues =
        [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> string with get, set
