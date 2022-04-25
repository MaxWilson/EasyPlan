// ts2fable 0.7.1
module rec BuildServices
open System
open Fable.Core
open Fable.Core.JS


module BuildServices =
    type BuildDefinitionReference = Build.BuildDefinitionReference
    type BuildReference = Build.BuildReference

    type [<StringEnum>] [<RequireQualifiedAccess>] BuildServiceIds =
        | [<CompiledName "ms.vss-build-web.build-page-data-service">] BuildPageDataService

    /// Contextual information for a build page
    type [<AllowNullLiteral>] IBuildPageData =
        /// The currently selected build result when on a build page
        abstract build: BuildReference option with get, set
        /// The currently selected build definition when on a build page
        abstract definition: BuildDefinitionReference option with get, set

    /// Service for getting contextual information when on a builds page
    type [<AllowNullLiteral>] IBuildPageDataService =
        /// Gets contextual information for a build page
        abstract getBuildPageData: unit -> IBuildPageData option
