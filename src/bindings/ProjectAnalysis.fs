// ts2fable 0.7.1
module rec ProjectAnalysis
open System
open Fable.Core
open Fable.Core.JS
type [<RequireQualifiedAccess>] AggregationType =
    | Hourly = 0
    | Daily = 1

type [<AllowNullLiteral>] AnalyzerDescriptor =
    abstract description: string with get, set
    abstract id: string with get, set
    abstract majorVersion: int with get, set
    abstract minorVersion: int with get, set
    abstract name: string with get, set
    abstract patchVersion: int with get, set

type [<AllowNullLiteral>] CodeChangeTrendItem =
    abstract time: DateTime with get, set
    abstract value: int with get, set

type [<AllowNullLiteral>] LanguageMetricsSecuredObject =
    abstract namespaceId: string with get, set
    abstract projectId: string with get, set
    abstract requiredPermissions: int with get, set

type [<AllowNullLiteral>] LanguageStatistics =
    inherit LanguageMetricsSecuredObject
    abstract bytes: int with get, set
    abstract files: int with get, set
    abstract filesPercentage: int with get, set
    abstract languagePercentage: int with get, set
    abstract name: string with get, set

type [<AllowNullLiteral>] ProjectActivityMetrics =
    abstract authorsCount: int with get, set
    abstract codeChangesCount: int with get, set
    abstract codeChangesTrend: ResizeArray<CodeChangeTrendItem> with get, set
    abstract projectId: string with get, set
    abstract pullRequestsCompletedCount: int with get, set
    abstract pullRequestsCreatedCount: int with get, set

type [<AllowNullLiteral>] ProjectLanguageAnalytics =
    inherit LanguageMetricsSecuredObject
    abstract id: string with get, set
    abstract languageBreakdown: ResizeArray<LanguageStatistics> with get, set
    abstract repositoryLanguageAnalytics: ResizeArray<RepositoryLanguageAnalytics> with get, set
    abstract resultPhase: ResultPhase with get, set
    abstract url: string with get, set

type [<AllowNullLiteral>] RepositoryActivityMetrics =
    abstract codeChangesCount: int with get, set
    abstract codeChangesTrend: ResizeArray<CodeChangeTrendItem> with get, set
    abstract repositoryId: string with get, set

type [<AllowNullLiteral>] RepositoryLanguageAnalytics =
    inherit LanguageMetricsSecuredObject
    abstract id: string with get, set
    abstract languageBreakdown: ResizeArray<LanguageStatistics> with get, set
    abstract name: string with get, set
    abstract resultPhase: ResultPhase with get, set
    abstract updatedTime: DateTime with get, set

type [<RequireQualifiedAccess>] ResultPhase =
    | Preliminary = 0
    | Full = 1
