// ts2fable 0.7.1
module rec GitServices
open System
open Fable.Core
open Fable.Core.JS
open Git

type [<StringEnum>] [<RequireQualifiedAccess>] GitServiceIds =
    | [<CompiledName "ms.vss-code-web.vc-repository-service">] VersionControlRepositoryService

/// Host service for accessing repository information.
type [<AllowNullLiteral>] IVersionControlRepositoryService =
    /// Gets the currently selected Git repository. Returns null if a Git repository is not currently selected.
    abstract getCurrentGitRepository: unit -> Promise<GitRepository option>
