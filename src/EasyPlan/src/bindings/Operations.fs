// ts2fable 0.7.1
module rec Operations
open System
open Fable.Core
open Fable.Core.JS


/// Contains information about the progress or result of an async operation.
type [<AllowNullLiteral>] Operation =
    inherit OperationReference
    /// Links to other related objects.
    abstract _links: obj option with get, set
    /// Detailed messaged about the status of an operation.
    abstract detailedMessage: string with get, set
    /// Result message for an operation.
    abstract resultMessage: string with get, set
    /// URL to the operation result.
    abstract resultUrl: OperationResultReference with get, set

/// Reference for an async operation.
type [<AllowNullLiteral>] OperationReference =
    /// Unique identifier for the operation.
    abstract id: string with get, set
    /// Unique identifier for the plugin.
    abstract pluginId: string with get, set
    /// The current status of the operation.
    abstract status: OperationStatus with get, set
    /// URL to get the full operation object.
    abstract url: string with get, set

type [<AllowNullLiteral>] OperationResultReference =
    /// URL to the operation result.
    abstract resultUrl: string with get, set

type [<RequireQualifiedAccess>] OperationStatus =
    | NotSet = 0
    | Queued = 1
    | InProgress = 2
    | Cancelled = 3
    | Succeeded = 4
    | Failed = 5
