// ts2fable 0.7.1
module rec ProjectAnalysisClient
open System
open Fable.Core
open Fable.Core.JS
type IVssRestClientOptions = Context.IVssRestClientOptions
type RestClientBase = RestClientBase.RestClientBase

type [<AllowNullLiteral>] IExports =
    abstract ProjectAnalysisRestClient: ProjectAnalysisRestClientStatic

type [<AllowNullLiteral>] ProjectAnalysisRestClient =
    inherit RestClientBase
    /// <param name="project">- Project ID or project name</param>
    abstract getProjectLanguageAnalytics: project: string -> Promise<ProjectAnalysis.ProjectLanguageAnalytics>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="fromDate">-</param>
    /// <param name="aggregationType">-</param>
    abstract getProjectActivityMetrics: project: string * fromDate: DateTime * aggregationType: ProjectAnalysis.AggregationType -> Promise<ProjectAnalysis.ProjectActivityMetrics>
    /// <summary>Retrieves git activity metrics for repositories matching a specified criteria.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="fromDate">- Date from which, the trends are to be fetched.</param>
    /// <param name="aggregationType">- Bucket size on which, trends are to be aggregated.</param>
    /// <param name="skip">- The number of repositories to ignore.</param>
    /// <param name="top">- The number of repositories for which activity metrics are to be retrieved.</param>
    abstract getGitRepositoriesActivityMetrics: project: string * fromDate: DateTime * aggregationType: ProjectAnalysis.AggregationType * skip: float * top: float -> Promise<ResizeArray<ProjectAnalysis.RepositoryActivityMetrics>>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="repositoryId">-</param>
    /// <param name="fromDate">-</param>
    /// <param name="aggregationType">-</param>
    abstract getRepositoryActivityMetrics: project: string * repositoryId: string * fromDate: DateTime * aggregationType: ProjectAnalysis.AggregationType -> Promise<ProjectAnalysis.RepositoryActivityMetrics>

type [<AllowNullLiteral>] ProjectAnalysisRestClientStatic =
    [<Emit "new $0($1...)">] abstract Create: options: IVssRestClientOptions -> ProjectAnalysisRestClient
    abstract RESOURCE_AREA_ID: string
