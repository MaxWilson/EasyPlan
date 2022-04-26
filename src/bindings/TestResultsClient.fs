// ts2fable 0.7.1
module rec TestResultsClient
open System
open Fable.Core
open Fable.Core.JS

type IVssRestClientOptions = Context.IVssRestClientOptions
type RestClientBase = RestClientBase.RestClientBase

type [<AllowNullLiteral>] IExports =
    abstract TestResultsRestClient: TestResultsRestClientStatic

type [<AllowNullLiteral>] TestResultsRestClient =
    inherit RestClientBase
    /// <param name="attachmentRequestModel">-</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="runId">-</param>
    /// <param name="testCaseResultId">-</param>
    /// <param name="iterationId">-</param>
    /// <param name="actionPath">-</param>
    abstract createTestIterationResultAttachment: attachmentRequestModel: Test.TestAttachmentRequestModel * project: string * runId: float * testCaseResultId: float * iterationId: float * ?actionPath: string -> Promise<Test.TestAttachmentReference>
    /// <param name="attachmentRequestModel">-</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="runId">-</param>
    /// <param name="testCaseResultId">-</param>
    abstract createTestResultAttachment: attachmentRequestModel: Test.TestAttachmentRequestModel * project: string * runId: float * testCaseResultId: float -> Promise<Test.TestAttachmentReference>
    /// <param name="attachmentRequestModel">-</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="runId">-</param>
    /// <param name="testCaseResultId">-</param>
    /// <param name="testSubResultId">-</param>
    abstract createTestSubResultAttachment: attachmentRequestModel: Test.TestAttachmentRequestModel * project: string * runId: float * testCaseResultId: float * testSubResultId: float -> Promise<Test.TestAttachmentReference>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="runId">-</param>
    /// <param name="testCaseResultId">-</param>
    /// <param name="attachmentId">-</param>
    abstract deleteTestResultAttachment: project: string * runId: float * testCaseResultId: float * attachmentId: float -> Promise<unit>
    /// <summary>Returns a test result attachment</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="runId">-</param>
    /// <param name="testCaseResultId">-</param>
    /// <param name="attachmentId">-</param>
    abstract getTestResultAttachmentContent: project: string * runId: float * testCaseResultId: float * attachmentId: float -> Promise<ArrayBuffer>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="runId">-</param>
    /// <param name="testCaseResultId">-</param>
    abstract getTestResultAttachments: project: string * runId: float * testCaseResultId: float -> Promise<ResizeArray<Test.TestAttachment>>
    /// <summary>Returns a test result attachment</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="runId">-</param>
    /// <param name="testCaseResultId">-</param>
    /// <param name="attachmentId">-</param>
    abstract getTestResultAttachmentZip: project: string * runId: float * testCaseResultId: float * attachmentId: float -> Promise<ArrayBuffer>
    /// <summary>Returns a test sub result attachment</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="runId">-</param>
    /// <param name="testCaseResultId">-</param>
    /// <param name="attachmentId">-</param>
    /// <param name="testSubResultId">-</param>
    abstract getTestSubResultAttachmentContent: project: string * runId: float * testCaseResultId: float * attachmentId: float * testSubResultId: float -> Promise<ArrayBuffer>
    /// <summary>Returns attachment references for test sub result.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="runId">-</param>
    /// <param name="testCaseResultId">-</param>
    /// <param name="testSubResultId">-</param>
    abstract getTestSubResultAttachments: project: string * runId: float * testCaseResultId: float * testSubResultId: float -> Promise<ResizeArray<Test.TestAttachment>>
    /// <summary>Returns a test sub result attachment</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="runId">-</param>
    /// <param name="testCaseResultId">-</param>
    /// <param name="attachmentId">-</param>
    /// <param name="testSubResultId">-</param>
    abstract getTestSubResultAttachmentZip: project: string * runId: float * testCaseResultId: float * attachmentId: float * testSubResultId: float -> Promise<ArrayBuffer>
    /// <param name="attachmentRequestModel">-</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="runId">-</param>
    abstract createTestRunAttachment: attachmentRequestModel: Test.TestAttachmentRequestModel * project: string * runId: float -> Promise<Test.TestAttachmentReference>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="runId">-</param>
    /// <param name="attachmentId">-</param>
    abstract deleteTestRunAttachment: project: string * runId: float * attachmentId: float -> Promise<unit>
    /// <summary>Returns a test run attachment</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="runId">-</param>
    /// <param name="attachmentId">-</param>
    abstract getTestRunAttachmentContent: project: string * runId: float * attachmentId: float -> Promise<ArrayBuffer>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="runId">-</param>
    abstract getTestRunAttachments: project: string * runId: float -> Promise<ResizeArray<Test.TestAttachment>>
    /// <summary>Returns a test run attachment</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="runId">-</param>
    /// <param name="attachmentId">-</param>
    abstract getTestRunAttachmentZip: project: string * runId: float * attachmentId: float -> Promise<ArrayBuffer>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="runId">-</param>
    /// <param name="testCaseResultId">-</param>
    abstract getBugsLinkedToTestResult: project: string * runId: float * testCaseResultId: float -> Promise<ResizeArray<Test.WorkItemReference>>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="buildId">-</param>
    /// <param name="flags">-</param>
    abstract getBuildCodeCoverage: project: string * buildId: float * flags: float -> Promise<ResizeArray<Test.BuildCoverage>>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="buildId">-</param>
    /// <param name="deltaBuildId">-</param>
    abstract getCodeCoverageSummary: project: string * buildId: float * ?deltaBuildId: float -> Promise<Test.CodeCoverageSummary>
    /// <summary>http://(tfsserver):8080/tfs/DefaultCollection/_apis/test/CodeCoverage?buildId=10 Request: Json of code coverage summary</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="buildId">-</param>
    /// <param name="coverageData">-</param>
    abstract updateCodeCoverageSummary: project: string * buildId: float * ?coverageData: Test.CodeCoverageData -> Promise<unit>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="runId">-</param>
    /// <param name="flags">-</param>
    abstract getTestRunCodeCoverage: project: string * runId: float * flags: float -> Promise<ResizeArray<Test.TestRunCoverage>>
    /// <summary>Get file coverage for the specified file</summary>
    /// <param name="fileCoverageRequest">- File details with pull request iteration context</param>
    /// <param name="project">- Project ID or project name</param>
    abstract getFileLevelCodeCoverage: fileCoverageRequest: Test.FileCoverageRequest * project: string -> Promise<string>
    /// <param name="filter">-</param>
    /// <param name="project">- Project ID or project name</param>
    abstract queryTestResultHistory: filter: Test.ResultsFilter * project: string -> Promise<Test.TestResultHistory>
    /// <summary>Get test run message logs</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="runId">- ID of the run to get.</param>
    abstract getTestRunMessageLogs: project: string * runId: float -> Promise<ResizeArray<Test.TestMessageLogDetails>>
    /// <summary>Get summary of test results.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="pipelineId">- Pipeline Id. This is same as build Id.</param>
    /// <param name="stageName">- Name of the stage. Maximum supported length for name is 256 character.</param>
    /// <param name="phaseName">- Name of the phase. Maximum supported length for name is 256 character.</param>
    /// <param name="jobName">- Matrixing in YAML generates copies of a job with different inputs in matrix. JobName is the name of those input. Maximum supported length for name is 256 character.</param>
    /// <param name="metricNames">-</param>
    /// <param name="groupByNode">- Group summary for each node of the pipleine heirarchy</param>
    abstract getTestPipelineMetrics: project: string * pipelineId: float * ?stageName: string * ?phaseName: string * ?jobName: string * ?metricNames: ResizeArray<Test.Metrics> * ?groupByNode: bool -> Promise<Test.PipelineTestMetrics>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="buildId">-</param>
    /// <param name="publishContext">-</param>
    /// <param name="groupBy">-</param>
    /// <param name="filter">-</param>
    /// <param name="orderby">-</param>
    /// <param name="shouldIncludeResults">-</param>
    /// <param name="queryRunSummaryForInProgress">-</param>
    abstract getTestResultDetailsForBuild: project: string * buildId: float * ?publishContext: string * ?groupBy: string * ?filter: string * ?orderby: string * ?shouldIncludeResults: bool * ?queryRunSummaryForInProgress: bool -> Promise<Test.TestResultsDetails>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="releaseId">-</param>
    /// <param name="releaseEnvId">-</param>
    /// <param name="publishContext">-</param>
    /// <param name="groupBy">-</param>
    /// <param name="filter">-</param>
    /// <param name="orderby">-</param>
    /// <param name="shouldIncludeResults">-</param>
    /// <param name="queryRunSummaryForInProgress">-</param>
    abstract getTestResultDetailsForRelease: project: string * releaseId: float * releaseEnvId: float * ?publishContext: string * ?groupBy: string * ?filter: string * ?orderby: string * ?shouldIncludeResults: bool * ?queryRunSummaryForInProgress: bool -> Promise<Test.TestResultsDetails>
    /// <param name="document">-</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="runId">-</param>
    abstract publishTestResultDocument: document: Test.TestResultDocument * project: string * runId: float -> Promise<Test.TestResultDocument>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="buildId">-</param>
    /// <param name="publishContext">-</param>
    /// <param name="fields">-</param>
    /// <param name="continuationToken">-</param>
    abstract getResultGroupsByBuild: project: string * buildId: float * publishContext: string * ?fields: ResizeArray<string> * ?continuationToken: string -> Promise<ResizeArray<Test.FieldDetailsForTestResults>>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="releaseId">-</param>
    /// <param name="publishContext">-</param>
    /// <param name="releaseEnvId">-</param>
    /// <param name="fields">-</param>
    /// <param name="continuationToken">-</param>
    abstract getResultGroupsByRelease: project: string * releaseId: float * publishContext: string * ?releaseEnvId: float * ?fields: ResizeArray<string> * ?continuationToken: string -> Promise<ResizeArray<Test.FieldDetailsForTestResults>>
    /// <summary>Get list of test Result meta data details for corresponding testcasereferenceId</summary>
    /// <param name="testCaseReferenceIds">-</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="detailsToInclude">- Details to include with test results metadata. Default is None. Other values are FlakyIdentifiers.</param>
    abstract queryTestResultsMetaData: testCaseReferenceIds: ResizeArray<string> * project: string * ?detailsToInclude: Test.ResultMetaDataDetails -> Promise<ResizeArray<Test.TestResultMetaData>>
    /// <summary>Update properties of test result meta data</summary>
    /// <param name="testResultMetaDataUpdateInput">- TestResultMetaData update input TestResultMetaDataUpdateInput</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="testCaseReferenceId">- TestCaseReference Id of Test Result to be updated.</param>
    abstract updateTestResultsMetaData: testResultMetaDataUpdateInput: Test.TestResultMetaDataUpdateInput * project: string * testCaseReferenceId: float -> Promise<Test.TestResultMetaData>
    /// <param name="query">-</param>
    /// <param name="project">- Project ID or project name</param>
    abstract getTestResultsByQuery: query: Test.TestResultsQuery * project: string -> Promise<Test.TestResultsQuery>
    /// <param name="queryModel">-</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="includeResultDetails">-</param>
    /// <param name="includeIterationDetails">-</param>
    /// <param name="skip">-</param>
    /// <param name="top">-</param>
    abstract getTestResultsByQueryWiql: queryModel: Test.QueryModel * project: string * ?includeResultDetails: bool * ?includeIterationDetails: bool * ?skip: float * ?top: float -> Promise<ResizeArray<Test.TestCaseResult>>
    /// <param name="results">-</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="runId">-</param>
    abstract addTestResultsToTestRun: results: ResizeArray<Test.TestCaseResult> * project: string * runId: float -> Promise<ResizeArray<Test.TestCaseResult>>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="runId">-</param>
    /// <param name="testResultId">-</param>
    /// <param name="detailsToInclude">-</param>
    abstract getTestResultById: project: string * runId: float * testResultId: float * ?detailsToInclude: Test.ResultDetails -> Promise<Test.TestCaseResult>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="runId">-</param>
    /// <param name="detailsToInclude">-</param>
    /// <param name="skip">-</param>
    /// <param name="top">-</param>
    /// <param name="outcomes">-</param>
    abstract getTestResults: project: string * runId: float * ?detailsToInclude: Test.ResultDetails * ?skip: float * ?top: float * ?outcomes: ResizeArray<Test.TestOutcome> -> Promise<ResizeArray<Test.TestCaseResult>>
    /// <param name="results">-</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="runId">-</param>
    abstract updateTestResults: results: ResizeArray<Test.TestCaseResult> * project: string * runId: float -> Promise<ResizeArray<Test.TestCaseResult>>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="buildId">-</param>
    /// <param name="publishContext">-</param>
    /// <param name="outcomes">-</param>
    /// <param name="top">-</param>
    /// <param name="continuationToken">-</param>
    abstract getTestResultsByBuild: project: string * buildId: float * ?publishContext: string * ?outcomes: ResizeArray<Test.TestOutcome> * ?top: float * ?continuationToken: string -> Promise<ResizeArray<Test.ShallowTestCaseResult>>
    /// <summary>Get a list of results.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="pipelineId">- Pipeline Id. This is same as build Id.</param>
    /// <param name="stageName">- Name of the stage. Maximum supported length for name is 256 character.</param>
    /// <param name="phaseName">- Name of the phase. Maximum supported length for name is 256 character.</param>
    /// <param name="jobName">- Matrixing in YAML generates copies of a job with different inputs in matrix. JobName is the name of those input. Maximum supported length for name is 256 character.</param>
    /// <param name="outcomes">- List of outcome of results</param>
    /// <param name="top">- Maximum number of results to return</param>
    /// <param name="continuationToken">- Header to pass the continuationToken</param>
    abstract getTestResultsByPipeline: project: string * pipelineId: float * ?stageName: string * ?phaseName: string * ?jobName: string * ?outcomes: ResizeArray<Test.TestOutcome> * ?top: float * ?continuationToken: String -> Promise<ResizeArray<Test.ShallowTestCaseResult>>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="releaseId">-</param>
    /// <param name="releaseEnvid">-</param>
    /// <param name="publishContext">-</param>
    /// <param name="outcomes">-</param>
    /// <param name="top">-</param>
    /// <param name="continuationToken">-</param>
    abstract getTestResultsByRelease: project: string * releaseId: float * ?releaseEnvid: float * ?publishContext: string * ?outcomes: ResizeArray<Test.TestOutcome> * ?top: float * ?continuationToken: string -> Promise<ResizeArray<Test.ShallowTestCaseResult>>
    /// <summary>Get all the available groups details and for these groups get failed and aborted results.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="pipelineId">- Pipeline Id. This is same as build Id.</param>
    /// <param name="stageName">- Name of the stage. Maximum supported length for name is 256 character.</param>
    /// <param name="phaseName">- Name of the phase. Maximum supported length for name is 256 character.</param>
    /// <param name="jobName">- Matrixing in YAML generates copies of a job with different inputs in matrix. JobName is the name of those input. Maximum supported length for name is 256 character.</param>
    /// <param name="shouldIncludeFailedAndAbortedResults">- If true, it will return Ids of failed and aborted results for each test group</param>
    /// <param name="queryGroupSummaryForInProgress">- If true, it will calculate summary for InProgress runs as well.</param>
    abstract testResultsGroupDetails: project: string * pipelineId: float * ?stageName: string * ?phaseName: string * ?jobName: string * ?shouldIncludeFailedAndAbortedResults: bool * ?queryGroupSummaryForInProgress: bool -> Promise<Test.TestResultsDetails>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="buildId">-</param>
    /// <param name="publishContext">-</param>
    /// <param name="includeFailureDetails">-</param>
    /// <param name="buildToCompare">-</param>
    abstract queryTestResultsReportForBuild: project: string * buildId: float * ?publishContext: string * ?includeFailureDetails: bool * ?buildToCompare: Test.BuildReference -> Promise<Test.TestResultSummary>
    /// <summary>Get summary of test results.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="pipelineId">- Pipeline Id. This is same as build Id.</param>
    /// <param name="stageName">- Name of the stage. Maximum supported length for name is 256 character.</param>
    /// <param name="phaseName">- Name of the phase. Maximum supported length for name is 256 character.</param>
    /// <param name="jobName">- Matrixing in YAML generates copies of a job with different inputs in matrix. JobName is the name of those input. Maximum supported length for name is 256 character.</param>
    /// <param name="includeFailureDetails">- If true returns failure insights</param>
    abstract queryTestResultsReportForPipeline: project: string * pipelineId: float * ?stageName: string * ?phaseName: string * ?jobName: string * ?includeFailureDetails: bool -> Promise<Test.TestResultSummary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="releaseId">-</param>
    /// <param name="releaseEnvId">-</param>
    /// <param name="publishContext">-</param>
    /// <param name="includeFailureDetails">-</param>
    /// <param name="releaseToCompare">-</param>
    abstract queryTestResultsReportForRelease: project: string * releaseId: float * releaseEnvId: float * ?publishContext: string * ?includeFailureDetails: bool * ?releaseToCompare: Test.ReleaseReference -> Promise<Test.TestResultSummary>
    /// <param name="releases">-</param>
    /// <param name="project">- Project ID or project name</param>
    abstract queryTestResultsSummaryForReleases: releases: ResizeArray<Test.ReleaseReference> * project: string -> Promise<ResizeArray<Test.TestResultSummary>>
    /// <param name="resultsContext">-</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="workItemIds">-</param>
    abstract queryTestSummaryByRequirement: resultsContext: Test.TestResultsContext * project: string * ?workItemIds: ResizeArray<float> -> Promise<ResizeArray<Test.TestSummaryForWorkItem>>
    /// <param name="filter">-</param>
    /// <param name="project">- Project ID or project name</param>
    abstract queryResultTrendForBuild: filter: Test.TestResultTrendFilter * project: string -> Promise<ResizeArray<Test.AggregatedDataForResultTrend>>
    /// <param name="filter">-</param>
    /// <param name="project">- Project ID or project name</param>
    abstract queryResultTrendForRelease: filter: Test.TestResultTrendFilter * project: string -> Promise<ResizeArray<Test.AggregatedDataForResultTrend>>
    /// <summary>Get test run statistics , used when we want to get summary of a run by outcome.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="runId">- ID of the run to get.</param>
    abstract getTestRunStatistics: project: string * runId: float -> Promise<Test.TestRunStatistic>
    /// <param name="testRun">-</param>
    /// <param name="project">- Project ID or project name</param>
    abstract createTestRun: testRun: Test.RunCreateModel * project: string -> Promise<Test.TestRun>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="runId">-</param>
    abstract deleteTestRun: project: string * runId: float -> Promise<unit>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="runId">-</param>
    /// <param name="includeDetails">-</param>
    /// <param name="includeTags">-</param>
    abstract getTestRunById: project: string * runId: float * ?includeDetails: bool * ?includeTags: bool -> Promise<Test.TestRun>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="buildUri">-</param>
    /// <param name="owner">-</param>
    /// <param name="tmiRunId">-</param>
    /// <param name="planId">-</param>
    /// <param name="includeRunDetails">-</param>
    /// <param name="automated">-</param>
    /// <param name="skip">-</param>
    /// <param name="top">-</param>
    abstract getTestRuns: project: string * ?buildUri: string * ?owner: string * ?tmiRunId: string * ?planId: float * ?includeRunDetails: bool * ?automated: bool * ?skip: float * ?top: float -> Promise<ResizeArray<Test.TestRun>>
    /// <summary>Query Test Runs based on filters. Mandatory fields are minLastUpdatedDate and maxLastUpdatedDate.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="minLastUpdatedDate">- Minimum Last Modified Date of run to be queried (Mandatory).</param>
    /// <param name="maxLastUpdatedDate">- Maximum Last Modified Date of run to be queried (Mandatory, difference between min and max date can be atmost 7 days).</param>
    /// <param name="state">- Current state of the Runs to be queried.</param>
    /// <param name="planIds">- Plan Ids of the Runs to be queried, comma seperated list of valid ids.</param>
    /// <param name="isAutomated">- Automation type of the Runs to be queried.</param>
    /// <param name="publishContext">- PublishContext of the Runs to be queried.</param>
    /// <param name="buildIds">- Build Ids of the Runs to be queried, comma seperated list of valid ids.</param>
    /// <param name="buildDefIds">- Build Definition Ids of the Runs to be queried, comma seperated list of valid ids.</param>
    /// <param name="branchName">- Source Branch name of the Runs to be queried.</param>
    /// <param name="releaseIds">- Release Ids of the Runs to be queried, comma seperated list of valid ids.</param>
    /// <param name="releaseDefIds">- Release Definition Ids of the Runs to be queried, comma seperated list of valid ids.</param>
    /// <param name="releaseEnvIds">- Release Environment Ids of the Runs to be queried, comma seperated list of valid ids.</param>
    /// <param name="releaseEnvDefIds">- Release Environment Definition Ids of the Runs to be queried, comma seperated list of valid ids.</param>
    /// <param name="runTitle">- Run Title of the Runs to be queried.</param>
    /// <param name="top">- Number of runs to be queried. Limit is 100</param>
    /// <param name="continuationToken">- continuationToken received from previous batch or null for first batch. It is not supposed to be created (or altered, if received from last batch) by user.</param>
    abstract queryTestRuns: project: string * minLastUpdatedDate: DateTime * maxLastUpdatedDate: DateTime * ?state: Test.TestRunState * ?planIds: ResizeArray<float> * ?isAutomated: bool * ?publishContext: Test.TestRunPublishContext * ?buildIds: ResizeArray<float> * ?buildDefIds: ResizeArray<float> * ?branchName: string * ?releaseIds: ResizeArray<float> * ?releaseDefIds: ResizeArray<float> * ?releaseEnvIds: ResizeArray<float> * ?releaseEnvDefIds: ResizeArray<float> * ?runTitle: string * ?top: float * ?continuationToken: string -> Promise<ResizeArray<Test.TestRun>>
    /// <param name="runUpdateModel">-</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="runId">-</param>
    abstract updateTestRun: runUpdateModel: Test.RunUpdateModel * project: string * runId: float -> Promise<Test.TestRun>
    /// <summary>Get TestResultsSettings data</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="settingsType">-</param>
    abstract getTestResultsSettings: project: string * ?settingsType: Test.TestResultsSettingsType -> Promise<Test.TestResultsSettings>
    /// <summary>Update project settings of test results</summary>
    /// <param name="testResultsUpdateSettings">-</param>
    /// <param name="project">- Project ID or project name</param>
    abstract updatePipelinesTestSettings: testResultsUpdateSettings: Test.TestResultsUpdateSettings * project: string -> Promise<Test.TestResultsSettings>
    /// <summary>Gets the list of results whose failure matches with the provided one.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="runId">- id of test run</param>
    /// <param name="testResultId">- id of test result inside a test run</param>
    /// <param name="testSubResultId">- id of subresult inside a test result</param>
    /// <param name="top">- Maximum number of results to return</param>
    /// <param name="continuationToken">- Header to pass the continuationToken</param>
    abstract getSimilarTestResults: project: string * runId: float * testResultId: float * testSubResultId: float * ?top: float * ?continuationToken: String -> Promise<ResizeArray<Test.TestCaseResult>>
    /// <summary>\<p\>Gets the coverage status for the last successful build of a definition, optionally scoped to a specific branch\</p\></summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="definition">- The ID or name of the definition.</param>
    /// <param name="branchName">- The branch name.</param>
    /// <param name="label">- The String to replace the default text on the left side of the badge.</param>
    abstract getCoverageStatusBadge: project: string * definition: string * ?branchName: string * ?label: string -> Promise<string>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="buildId">-</param>
    abstract getTestTagsForBuild: project: string * buildId: float -> Promise<ResizeArray<Test.TestTag>>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="releaseId">-</param>
    /// <param name="releaseEnvId">-</param>
    abstract getTestTagsForRelease: project: string * releaseId: float * releaseEnvId: float -> Promise<ResizeArray<Test.TestTag>>
    /// <param name="testTagsUpdateModel">-</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="runId">-</param>
    abstract updateTestRunTags: testTagsUpdateModel: Test.TestTagsUpdateModel * project: string * runId: float -> Promise<ResizeArray<Test.TestTag>>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="buildId">-</param>
    abstract getTestTagSummaryForBuild: project: string * buildId: float -> Promise<Test.TestTagSummary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="releaseId">-</param>
    /// <param name="releaseEnvId">-</param>
    abstract getTestTagSummaryForRelease: project: string * releaseId: float * releaseEnvId: float -> Promise<Test.TestTagSummary>
    /// <summary>Get history of a test method using TestHistoryQuery</summary>
    /// <param name="filter">- TestHistoryQuery to get history</param>
    /// <param name="project">- Project ID or project name</param>
    abstract queryTestHistory: filter: Test.TestHistoryQuery * project: string -> Promise<Test.TestHistoryQuery>
    /// <summary>Get list of build attachments reference</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="buildId">- Id of the build to get</param>
    /// <param name="type">- type of the attachment to get</param>
    /// <param name="directoryPath">- directory path for which attachments are needed</param>
    /// <param name="fileNamePrefix">- file name prefix to filter the list of attachment</param>
    /// <param name="fetchMetaData">- Default is false, set if metadata is needed</param>
    /// <param name="top">- Number of test attachments reference to return</param>
    /// <param name="continuationToken">- Header to pass the continuationToken</param>
    abstract getTestLogsForBuild: project: string * buildId: float * ``type``: Test.TestLogType * ?directoryPath: string * ?fileNamePrefix: string * ?fetchMetaData: bool * ?top: float * ?continuationToken: String -> Promise<ResizeArray<Test.TestLog>>
    /// <summary>Get list of test result attachments reference</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="runId">- Id of the test run that contains the result</param>
    /// <param name="resultId">- Id of the test result</param>
    /// <param name="type">- type of attachments to get</param>
    /// <param name="directoryPath">- directory path of attachments to get</param>
    /// <param name="fileNamePrefix">- file name prefix to filter the list of attachment</param>
    /// <param name="fetchMetaData">- Default is false, set if metadata is needed</param>
    /// <param name="top">- Numbe of attachments reference to return</param>
    /// <param name="continuationToken">- Header to pass the continuationToken</param>
    abstract getTestResultLogs: project: string * runId: float * resultId: float * ``type``: Test.TestLogType * ?directoryPath: string * ?fileNamePrefix: string * ?fetchMetaData: bool * ?top: float * ?continuationToken: String -> Promise<ResizeArray<Test.TestLog>>
    /// <summary>Get list of test subresult attachments reference</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="runId">- Id of the test run that contains the results</param>
    /// <param name="resultId">- Id of the test result that contains subresult</param>
    /// <param name="subResultId">- Id of the test subresult</param>
    /// <param name="type">- type of the attachments to get</param>
    /// <param name="directoryPath">- directory path of the attachment to get</param>
    /// <param name="fileNamePrefix">- file name prefix to filter the list of attachments</param>
    /// <param name="fetchMetaData">- Default is false, set if metadata is needed</param>
    /// <param name="top">- Number of attachments reference to return</param>
    /// <param name="continuationToken">- Header to pass the continuationToken</param>
    abstract getTestSubResultLogs: project: string * runId: float * resultId: float * subResultId: float * ``type``: Test.TestLogType * ?directoryPath: string * ?fileNamePrefix: string * ?fetchMetaData: bool * ?top: float * ?continuationToken: String -> Promise<ResizeArray<Test.TestLog>>
    /// <summary>Get list of test run attachments reference</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="runId">- Id of the test run</param>
    /// <param name="type">- type of the attachments to get</param>
    /// <param name="directoryPath">- directory path for which attachments are needed</param>
    /// <param name="fileNamePrefix">- file name prefix to filter the list of attachment</param>
    /// <param name="fetchMetaData">- Default is false, set if metadata is needed</param>
    /// <param name="top">- Number of attachments reference to return</param>
    /// <param name="continuationToken">- Header to pass the continuationToken</param>
    abstract getTestRunLogs: project: string * runId: float * ``type``: Test.TestLogType * ?directoryPath: string * ?fileNamePrefix: string * ?fetchMetaData: bool * ?top: float * ?continuationToken: String -> Promise<ResizeArray<Test.TestLog>>
    /// <summary>Get SAS Uri of a build attachment</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="build">- Id of the build to get</param>
    /// <param name="type">- type of the file</param>
    /// <param name="filePath">- filePath for which sas uri is needed</param>
    abstract getTestLogStoreEndpointDetailsForBuildLog: project: string * build: float * ``type``: Test.TestLogType * filePath: string -> Promise<Test.TestLogStoreEndpointDetails>
    /// <summary>Create and Get sas uri of the build container</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="buildId">- Id of the build to get</param>
    /// <param name="testLogStoreOperationType">- Type of operation to perform using sas uri</param>
    abstract testLogStoreEndpointDetailsForBuild: project: string * buildId: float * testLogStoreOperationType: Test.TestLogStoreOperationType -> Promise<Test.TestLogStoreEndpointDetails>
    /// <summary>Get SAS Uri of a test results attachment</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="runId">- Id of the test run that contains result</param>
    /// <param name="resultId">- Id of the test result whose files need to be downloaded</param>
    /// <param name="type">- type of the file</param>
    /// <param name="filePath">- filePath for which sas uri is needed</param>
    abstract getTestLogStoreEndpointDetailsForResultLog: project: string * runId: float * resultId: float * ``type``: Test.TestLogType * filePath: string -> Promise<Test.TestLogStoreEndpointDetails>
    /// <summary>Get SAS Uri of a test subresults attachment</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="runId">- Id of the test run that contains result</param>
    /// <param name="resultId">- Id of the test result that contains subresult</param>
    /// <param name="subResultId">- Id of the test subresult whose file sas uri is needed</param>
    /// <param name="type">- type of the file</param>
    /// <param name="filePath">- filePath for which sas uri is needed</param>
    abstract getTestLogStoreEndpointDetailsForSubResultLog: project: string * runId: float * resultId: float * subResultId: float * ``type``: Test.TestLogType * filePath: string -> Promise<Test.TestLogStoreEndpointDetails>
    /// <summary>Create empty file for a result and Get Sas uri for the file</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="runId">- Id of the test run that contains the result</param>
    /// <param name="resultId">- Id of the test results that contains sub result</param>
    /// <param name="subResultId">- Id of the test sub result whose file sas uri is needed</param>
    /// <param name="filePath">- file path inside the sub result for which sas uri is needed</param>
    /// <param name="type">- Type of the file for download</param>
    abstract testLogStoreEndpointDetailsForResult: project: string * runId: float * resultId: float * subResultId: float * filePath: string * ``type``: Test.TestLogType -> Promise<Test.TestLogStoreEndpointDetails>
    /// <summary>Get SAS Uri of a test run attachment</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="runId">- Id of the test run whose file has to be downloaded</param>
    /// <param name="type">- type of the file</param>
    /// <param name="filePath">- filePath for which sas uri is needed</param>
    abstract getTestLogStoreEndpointDetailsForRunLog: project: string * runId: float * ``type``: Test.TestLogType * filePath: string -> Promise<Test.TestLogStoreEndpointDetails>
    /// <summary>Create empty file for a run and Get Sas uri for the file</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="runId">- Id of the run to get endpoint details</param>
    /// <param name="testLogStoreOperationType">- Type of operation to perform using sas uri</param>
    /// <param name="filePath">- file path to create an empty file</param>
    /// <param name="type">- Default is GeneralAttachment, type of empty file to be created</param>
    abstract testLogStoreEndpointDetailsForRun: project: string * runId: float * testLogStoreOperationType: Test.TestLogStoreOperationType * ?filePath: string * ?``type``: Test.TestLogType -> Promise<Test.TestLogStoreEndpointDetails>
    /// <param name="testSettings">-</param>
    /// <param name="project">- Project ID or project name</param>
    abstract createTestSettings: testSettings: Test.TestSettings * project: string -> Promise<float>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="testSettingsId">-</param>
    abstract deleteTestSettings: project: string * testSettingsId: float -> Promise<unit>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="testSettingsId">-</param>
    abstract getTestSettingsById: project: string * testSettingsId: float -> Promise<Test.TestSettings>
    /// <param name="workItemToTestLinks">-</param>
    /// <param name="project">- Project ID or project name</param>
    abstract addWorkItemToTestLinks: workItemToTestLinks: Test.WorkItemToTestLinks * project: string -> Promise<Test.WorkItemToTestLinks>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="testName">-</param>
    /// <param name="workItemId">-</param>
    abstract deleteTestMethodToWorkItemLink: project: string * testName: string * workItemId: float -> Promise<bool>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="testName">-</param>
    abstract queryTestMethodLinkedWorkItems: project: string * testName: string -> Promise<Test.TestToWorkItemLinks>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="workItemCategory">-</param>
    /// <param name="automatedTestName">-</param>
    /// <param name="testCaseId">-</param>
    /// <param name="maxCompleteDate">-</param>
    /// <param name="days">-</param>
    /// <param name="workItemCount">-</param>
    abstract queryTestResultWorkItems: project: string * workItemCategory: string * ?automatedTestName: string * ?testCaseId: float * ?maxCompleteDate: DateTime * ?days: float * ?workItemCount: float -> Promise<ResizeArray<Test.WorkItemReference>>

type [<AllowNullLiteral>] TestResultsRestClientStatic =
    [<Emit "new $0($1...)">] abstract Create: options: IVssRestClientOptions -> TestResultsRestClient
