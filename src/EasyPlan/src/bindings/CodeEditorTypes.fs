// ts2fable 0.7.1
module rec CodeEditorTypes
open System
open Fable.Core
open Fable.Core.JS

type RegExp = System.Text.RegularExpressions.Regex


module CodeEditorTypes =
    type GitVersionDescriptor = Git.GitVersionDescriptor
    type TfvcVersionDescriptor = Git.TfvcVersionDescriptor

    /// Extensions to the code editor should implement this interface, which will be called when the exension is loaded.
    type [<AllowNullLiteral>] ICodeEditorContribution =
        abstract register: editorEndpoints: ICodeEditorContributionEndpoints -> unit

    type [<AllowNullLiteral>] ResourceChangedCallback =
        [<Emit "$0($1...)">] abstract Invoke: resource: IResource -> unit

    /// These functions will be made available to extensions to interact with the code editor.
    type [<AllowNullLiteral>] ICodeEditorContributionEndpoints =
        /// Get a resource URI for the specified resource.
        abstract getResourceUriFromResourceVersion: version: IResourceVersion -> Promise<string>
        /// Get resource version from specified resource URI.
        abstract getResourceVersion: uri: string -> Promise<IResourceVersion>
        /// Get the list of currently registered JSON schemas.
        abstract getJsonSchemas: unit -> Promise<ResizeArray<IJsonSchemaRegistration>>
        /// Register a callback to be informed when a change happens to the current resource:
        ///   - a new file is loaded
        ///   - the user edits the file in the web UI
        ///   - the detected language changes (ie after an extension registered a new language, and the file was detected to have that language)
        abstract onResourceChanged: callback: ResourceChangedCallback -> unit
        /// Register a language with the code editor.
        abstract registerLanguage: registration: ILanguageRegistration -> unit
        /// Register schemas with the code editor's built-in JSON language
        abstract registerJsonSchemas: schemas: ResizeArray<IJsonSchemaRegistration> -> unit

    type [<AllowNullLiteral>] IResource =
        abstract uri: string with get, set
        abstract getValue: unit -> Promise<string>
        abstract languageId: string with get, set
        abstract versionInfo: IResourceVersion with get, set

    type IResourceVersion =
        U2<IGitResourceVersion, ITfvcResourceVersion>

    /// Identifies a file in Git.
    type [<AllowNullLiteral>] IGitResourceVersion =
        abstract repositoryId: string with get, set
        abstract versionControlType: string with get, set
        abstract version: GitVersionDescriptor with get, set
        abstract path: string with get, set

    type [<StringEnum>] [<RequireQualifiedAccess>] VersionControlType =
        | Git
        | Tfvc

    /// Identifies a file in TFVC.
    type [<AllowNullLiteral>] ITfvcResourceVersion =
        abstract versionControlType: string with get, set
        abstract version: TfvcVersionDescriptor with get, set
        abstract path: string with get, set

    /// Everything needed to register a language.
    /// See https://github.com/Microsoft/monaco-languages/ for examples.
    type [<AllowNullLiteral>] ILanguageRegistration =
        abstract extensionPoint: ILanguageExtensionPoint with get, set
        abstract configuration: LanguageConfiguration with get, set
        abstract monarchLanguage: IMonarchLanguage with get, set

    /// Describes a JSON schema
    type [<AllowNullLiteral>] IJsonSchemaRegistration =
        /// URI of the schema
        abstract uri: string with get, set
        /// File patterns the schema applies to.
        abstract fileMatch: ResizeArray<string> option with get, set
        /// The JSON schema.
        /// See https://github.com/Microsoft/vscode-json-languageservice/blob/master/src/jsonSchema.ts
        abstract schema: obj option with get, set

    /// A monaco language extension point.
    /// See https://github.com/Microsoft/monaco-editor/blob/master/monaco.d.ts
    type [<AllowNullLiteral>] ILanguageExtensionPoint =
        abstract id: string with get, set
        abstract extensions: ResizeArray<string> option with get, set
        abstract filenames: ResizeArray<string> option with get, set
        abstract filenamePatterns: ResizeArray<string> option with get, set
        abstract firstLine: string option with get, set
        abstract aliases: ResizeArray<string> option with get, set
        abstract mimetypes: ResizeArray<string> option with get, set
        abstract configuration: string option with get, set

    /// A Monarch language definition
    type [<AllowNullLiteral>] IMonarchLanguage =
        interface end

    /// Describes how comments for a language work.
    type [<AllowNullLiteral>] CommentRule =
        /// The line comment token, like `// this is a comment`
        abstract lineComment: string option with get, set
        /// The block comment character pair, like `/* block comment *&#47;`
        abstract blockComment: CharacterPair option with get, set

    /// The language configuration interface defines the contract between extensions and
    /// various editor features, like automatic bracket insertion, automatic indentation etc.
    type [<AllowNullLiteral>] LanguageConfiguration =
        /// The language's comment settings.
        abstract comments: CommentRule option with get, set
        /// The language's brackets.
        /// This configuration implicitly affects pressing Enter around these brackets.
        abstract brackets: ResizeArray<CharacterPair> option with get, set
        /// The language's word definition.
        /// If the language supports Unicode identifiers (e.g. JavaScript), it is preferable
        /// to provide a word definition that uses exclusion of known separators.
        /// e.g.: A regex that matches anything except known separators (and dot is allowed to occur in a floating point number):
        ///    /(-?\d*\.\d\w*)|([^\`\~\!\@\#\%\^\&\*\(\)\-\=\+\[\{\]\}\\\|\;\:\'\"\,\.\<\>\/\?\s]+)/g
        abstract wordPattern: RegExp option with get, set
        /// The language's indentation settings.
        abstract indentationRules: IndentationRule option with get, set
        /// The language's rules to be evaluated when pressing Enter.
        abstract onEnterRules: ResizeArray<OnEnterRule> option with get, set
        /// The language's auto closing pairs. The 'close' character is automatically inserted with the
        /// 'open' character is typed. If not set, the configured brackets will be used.
        abstract autoClosingPairs: ResizeArray<IAutoClosingPairConditional> option with get, set
        /// The language's surrounding pairs. When the 'open' character is typed on a selection, the
        /// selected string is surrounded by the open and close characters. If not set, the autoclosing pairs
        /// settings will be used.
        abstract surroundingPairs: ResizeArray<IAutoClosingPair> option with get, set
        /// The language's folding rules.
        abstract folding: FoldingRules option with get, set

    /// Describes indentation rules for a language.
    type [<AllowNullLiteral>] IndentationRule =
        /// If a line matches this pattern, then all the lines after it should be unindendented once (until another rule matches).
        abstract decreaseIndentPattern: RegExp with get, set
        /// If a line matches this pattern, then all the lines after it should be indented once (until another rule matches).
        abstract increaseIndentPattern: RegExp with get, set
        /// If a line matches this pattern, then **only the next line** after it should be indented once.
        abstract indentNextLinePattern: RegExp option with get, set
        /// If a line matches this pattern, then its indentation should not be changed and it should not be evaluated against the other rules.
        abstract unIndentedLinePattern: RegExp option with get, set

    /// Describes language specific folding markers such as '#region' and '#endregion'.
    /// The start and end regexes will be tested against the contents of all lines and must be designed efficiently:
    /// - the regex should start with '^'
    /// - regexp flags (i, g) are ignored
    type [<AllowNullLiteral>] FoldingMarkers =
        abstract start: RegExp with get, set
        abstract ``end``: RegExp with get, set

    /// Describes folding rules for a language.
    type [<AllowNullLiteral>] FoldingRules =
        /// Used by the indentation based strategy to decide wheter empty lines belong to the previous or the next block.
        /// A language adheres to the off-side rule if blocks in that language are expressed by their indentation.
        /// See [wikipedia](https://en.wikipedia.org/wiki/Off-side_rule) for more information.
        /// If not set, `false` is used and empty lines belong to the previous block.
        abstract offSide: bool option with get, set
        /// Region markers used by the language.
        abstract markers: FoldingMarkers option with get, set

    /// Describes a rule to be evaluated when pressing Enter.
    type [<AllowNullLiteral>] OnEnterRule =
        /// This rule will only execute if the text before the cursor matches this regular expression.
        abstract beforeText: RegExp with get, set
        /// This rule will only execute if the text after the cursor matches this regular expression.
        abstract afterText: RegExp option with get, set
        /// The action to execute.
        abstract action: EnterAction with get, set

    /// Describes what to do when pressing Enter.
    type [<AllowNullLiteral>] EnterAction =
        /// Describe what to do with the indentation.
        abstract indentAction: IndentAction with get, set
        /// Describe whether to outdent current line.
        abstract outdentCurrentLine: bool option with get, set
        /// Describes text to be appended after the new line and after the indentation.
        abstract appendText: string option with get, set
        /// Describes the number of characters to remove from the new line's indentation.
        abstract removeText: float option with get, set

    /// Definition of documentation comments (e.g. Javadoc/JSdoc)
    type [<AllowNullLiteral>] IDocComment =
        /// The string that starts a doc comment (e.g. '/**')
        abstract ``open``: string with get, set
        /// The string that appears on the last line and closes the doc comment (e.g. ' * /').
        abstract close: string with get, set

    type CharacterPair =
        string * string

    type [<AllowNullLiteral>] IAutoClosingPair =
        abstract ``open``: string with get, set
        abstract close: string with get, set

    type [<AllowNullLiteral>] IAutoClosingPairConditional =
        inherit IAutoClosingPair
        abstract notIn: ResizeArray<string> option with get, set

    type [<RequireQualifiedAccess>] IndentAction =
        | None = 0
        | Indent = 1
        | IndentOutdent = 2
        | Outdent = 3
