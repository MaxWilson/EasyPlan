// ts2fable 0.7.1
module rec TestClient
open System
open Fable.Core
open Fable.Core.JS


type IVssRestClientOptions = Context.IVssRestClientOptions
type RestClientBase = RestClientBase.RestClientBase

type [<AllowNullLiteral>] IExports =
    abstract TestRestClient: TestRestClientStatic

type [<AllowNullLiteral>] TestRestClient =
    inherit RestClientBase
    /// <summary>Gets the action results for an iteration in a test result.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="runId">- ID of the test run that contains the result.</param>
    /// <param name="testCaseResultId">- ID of the test result that contains the iterations.</param>
    /// <param name="iterationId">- ID of the iteration that contains the actions.</param>
    /// <param name="actionPath">- Path of a specific action, used to get just that action.</param>
    abstract getActionResults: project: string * runId: float * testCaseResultId: float * iterationId: float * ?actionPath: string -> Promise<ResizeArray<Test.TestActionResultModel>>
    /// <summary>Attach a file to test step result</summary>
    /// <param name="attachmentRequestModel">- Attachment details TestAttachmentRequestModel</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="runId">- ID of the test run that contains the result.</param>
    /// <param name="testCaseResultId">- ID of the test result that contains the iteration</param>
    /// <param name="iterationId">- ID of the test result iteration.</param>
    /// <param name="actionPath">- Hex value of test result action path.</param>
    abstract createTestIterationResultAttachment: attachmentRequestModel: Test.TestAttachmentRequestModel * project: string * runId: float * testCaseResultId: float * iterationId: float * ?actionPath: string -> Promise<Test.TestAttachmentReference>
    /// <summary>Attach a file to a test result.</summary>
    /// <param name="attachmentRequestModel">- Attachment details TestAttachmentRequestModel</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="runId">- ID of the test run that contains the result.</param>
    /// <param name="testCaseResultId">- ID of the test result against which attachment has to be uploaded.</param>
    abstract createTestResultAttachment: attachmentRequestModel: Test.TestAttachmentRequestModel * project: string * runId: float * testCaseResultId: float -> Promise<Test.TestAttachmentReference>
    /// <summary>Attach a file to a test result</summary>
    /// <param name="attachmentRequestModel">- Attachment Request Model.</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="runId">- ID of the test run that contains the result.</param>
    /// <param name="testCaseResultId">- ID of the test results that contains sub result.</param>
    /// <param name="testSubResultId">- ID of the test sub results against which attachment has to be uploaded.</param>
    abstract createTestSubResultAttachment: attachmentRequestModel: Test.TestAttachmentRequestModel * project: string * runId: float * testCaseResultId: float * testSubResultId: float -> Promise<Test.TestAttachmentReference>
    /// <summary>Download a test result attachment by its ID.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="runId">- ID of the test run that contains the testCaseResultId.</param>
    /// <param name="testCaseResultId">- ID of the test result whose attachment has to be downloaded.</param>
    /// <param name="attachmentId">- ID of the test result attachment to be downloaded.</param>
    abstract getTestResultAttachmentContent: project: string * runId: float * testCaseResultId: float * attachmentId: float -> Promise<ArrayBuffer>
    /// <summary>Get list of test result attachments reference.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="runId">- ID of the test run that contains the result.</param>
    /// <param name="testCaseResultId">- ID of the test result.</param>
    abstract getTestResultAttachments: project: string * runId: float * testCaseResultId: float -> Promise<ResizeArray<Test.TestAttachment>>
    /// <summary>Download a test result attachment by its ID.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="runId">- ID of the test run that contains the testCaseResultId.</param>
    /// <param name="testCaseResultId">- ID of the test result whose attachment has to be downloaded.</param>
    /// <param name="attachmentId">- ID of the test result attachment to be downloaded.</param>
    abstract getTestResultAttachmentZip: project: string * runId: float * testCaseResultId: float * attachmentId: float -> Promise<ArrayBuffer>
    /// <summary>Download a test sub result attachment</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="runId">- ID of the test run that contains the result.</param>
    /// <param name="testCaseResultId">- ID of the test results that contains sub result.</param>
    /// <param name="attachmentId">- ID of the test result attachment to be downloaded</param>
    /// <param name="testSubResultId">- ID of the test sub result whose attachment has to be downloaded</param>
    abstract getTestSubResultAttachmentContent: project: string * runId: float * testCaseResultId: float * attachmentId: float * testSubResultId: float -> Promise<ArrayBuffer>
    /// <summary>Get list of test sub result attachments</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="runId">- ID of the test run that contains the result.</param>
    /// <param name="testCaseResultId">- ID of the test results that contains sub result.</param>
    /// <param name="testSubResultId">- ID of the test sub result whose attachment has to be downloaded</param>
    abstract getTestSubResultAttachments: project: string * runId: float * testCaseResultId: float * testSubResultId: float -> Promise<ResizeArray<Test.TestAttachment>>
    /// <summary>Download a test sub result attachment</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="runId">- ID of the test run that contains the result.</param>
    /// <param name="testCaseResultId">- ID of the test results that contains sub result.</param>
    /// <param name="attachmentId">- ID of the test result attachment to be downloaded</param>
    /// <param name="testSubResultId">- ID of the test sub result whose attachment has to be downloaded</param>
    abstract getTestSubResultAttachmentZip: project: string * runId: float * testCaseResultId: float * attachmentId: float * testSubResultId: float -> Promise<ArrayBuffer>
    /// <summary>Attach a file to a test run.</summary>
    /// <param name="attachmentRequestModel">- Attachment details TestAttachmentRequestModel</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="runId">- ID of the test run against which attachment has to be uploaded.</param>
    abstract createTestRunAttachment: attachmentRequestModel: Test.TestAttachmentRequestModel * project: string * runId: float -> Promise<Test.TestAttachmentReference>
    /// <summary>Download a test run attachment by its ID.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="runId">- ID of the test run whose attachment has to be downloaded.</param>
    /// <param name="attachmentId">- ID of the test run attachment to be downloaded.</param>
    abstract getTestRunAttachmentContent: project: string * runId: float * attachmentId: float -> Promise<ArrayBuffer>
    /// <summary>Get list of test run attachments reference.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="runId">- ID of the test run.</param>
    abstract getTestRunAttachments: project: string * runId: float -> Promise<ResizeArray<Test.TestAttachment>>
    /// <summary>Download a test run attachment by its ID.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="runId">- ID of the test run whose attachment has to be downloaded.</param>
    /// <param name="attachmentId">- ID of the test run attachment to be downloaded.</param>
    abstract getTestRunAttachmentZip: project: string * runId: float * attachmentId: float -> Promise<ArrayBuffer>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="runId">-</param>
    /// <param name="testCaseResultId">-</param>
    abstract getBugsLinkedToTestResult: project: string * runId: float * testCaseResultId: float -> Promise<ResizeArray<Test.WorkItemReference>>
    /// <summary>Get code coverage data for a build.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="buildId">- ID of the build for which code coverage data needs to be fetched.</param>
    /// <param name="flags">- Value of flags determine the level of code coverage details to be fetched. Flags are additive. Expected Values are 1 for Modules, 2 for Functions, 4 for BlockData.</param>
    abstract getBuildCodeCoverage: project: string * buildId: float * flags: float -> Promise<ResizeArray<Test.BuildCoverage>>
    /// <summary>Get Code Coverage Summary for Build.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="buildId">- ID of the build for which code coverage data needs to be fetched.</param>
    /// <param name="deltaBuildId">- Delta Build id (optional)</param>
    abstract getCodeCoverageSummary: project: string * buildId: float * ?deltaBuildId: float -> Promise<Test.CodeCoverageSummary>
    /// <summary>http://(tfsserver):8080/tfs/DefaultCollection/_apis/test/CodeCoverage?buildId=10 Request: Json of code coverage summary</summary>
    /// <param name="coverageData">-</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="buildId">-</param>
    abstract updateCodeCoverageSummary: coverageData: Test.CodeCoverageData * project: string * buildId: float -> Promise<unit>
    /// <summary>Get code coverage data for a test run</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="runId">- ID of the test run for which code coverage data needs to be fetched.</param>
    /// <param name="flags">- Value of flags determine the level of code coverage details to be fetched. Flags are additive. Expected Values are 1 for Modules, 2 for Functions, 4 for BlockData.</param>
    abstract getTestRunCodeCoverage: project: string * runId: float * flags: float -> Promise<ResizeArray<Test.TestRunCoverage>>
    /// <param name="newFields">-</param>
    /// <param name="project">- Project ID or project name</param>
    abstract addCustomFields: newFields: ResizeArray<Test.CustomTestFieldDefinition> * project: string -> Promise<ResizeArray<Test.CustomTestFieldDefinition>>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="scopeFilter">-</param>
    abstract queryCustomFields: project: string * scopeFilter: Test.CustomTestFieldScope -> Promise<ResizeArray<Test.CustomTestFieldDefinition>>
    /// <param name="filter">-</param>
    /// <param name="project">- Project ID or project name</param>
    abstract queryTestResultHistory: filter: Test.ResultsFilter * project: string -> Promise<Test.TestResultHistory>
    /// <summary>Get iteration for a result</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="runId">- ID of the test run that contains the result.</param>
    /// <param name="testCaseResultId">- ID of the test result that contains the iterations.</param>
    /// <param name="iterationId">- Id of the test results Iteration.</param>
    /// <param name="includeActionResults">- Include result details for each action performed in the test iteration. ActionResults refer to outcome (pass/fail) of test steps that are executed as part of a running a manual test. Including the ActionResults flag gets the outcome of test steps in the actionResults section and test parameters in the parameters section for each test iteration.</param>
    abstract getTestIteration: project: string * runId: float * testCaseResultId: float * iterationId: float * ?includeActionResults: bool -> Promise<Test.TestIterationDetailsModel>
    /// <summary>Get iterations for a result</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="runId">- ID of the test run that contains the result.</param>
    /// <param name="testCaseResultId">- ID of the test result that contains the iterations.</param>
    /// <param name="includeActionResults">- Include result details for each action performed in the test iteration. ActionResults refer to outcome (pass/fail) of test steps that are executed as part of a running a manual test. Including the ActionResults flag gets the outcome of test steps in the actionResults section and test parameters in the parameters section for each test iteration.</param>
    abstract getTestIterations: project: string * runId: float * testCaseResultId: float * ?includeActionResults: bool -> Promise<ResizeArray<Test.TestIterationDetailsModel>>
    /// <param name="workItemQuery">-</param>
    /// <param name="project">- Project ID or project name</param>
    abstract getLinkedWorkItemsByQuery: workItemQuery: Test.LinkedWorkItemsQuery * project: string -> Promise<ResizeArray<Test.LinkedWorkItemsQueryResult>>
    /// <summary>Get test run message logs</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="runId">- ID of the run to get.</param>
    abstract getTestRunLogs: project: string * runId: float -> Promise<ResizeArray<Test.TestMessageLogDetails>>
    /// <summary>Get a list of parameterized results</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="runId">- ID of the test run that contains the result.</param>
    /// <param name="testCaseResultId">- ID of the test result that contains the iterations.</param>
    /// <param name="iterationId">- ID of the iteration that contains the parameterized results.</param>
    /// <param name="paramName">- Name of the parameter.</param>
    abstract getResultParameters: project: string * runId: float * testCaseResultId: float * iterationId: float * ?paramName: string -> Promise<ResizeArray<Test.TestResultParameterModel>>
    /// <summary>Get a test point.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="planId">- ID of the test plan.</param>
    /// <param name="suiteId">- ID of the suite that contains the point.</param>
    /// <param name="pointIds">- ID of the test point to get.</param>
    /// <param name="witFields">- Comma-separated list of work item field names.</param>
    abstract getPoint: project: string * planId: float * suiteId: float * pointIds: float * ?witFields: string -> Promise<Test.TestPoint>
    /// <summary>Get a list of test points.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="planId">- ID of the test plan.</param>
    /// <param name="suiteId">- ID of the suite that contains the points.</param>
    /// <param name="witFields">- Comma-separated list of work item field names.</param>
    /// <param name="configurationId">- Get test points for specific configuration.</param>
    /// <param name="testCaseId">- Get test points for a specific test case, valid when configurationId is not set.</param>
    /// <param name="testPointIds">- Get test points for comma-separated list of test point IDs, valid only when configurationId and testCaseId are not set.</param>
    /// <param name="includePointDetails">- Include all properties for the test point.</param>
    /// <param name="skip">- Number of test points to skip..</param>
    /// <param name="top">- Number of test points to return.</param>
    abstract getPoints: project: string * planId: float * suiteId: float * ?witFields: string * ?configurationId: string * ?testCaseId: string * ?testPointIds: string * ?includePointDetails: bool * ?skip: float * ?top: float -> Promise<ResizeArray<Test.TestPoint>>
    /// <summary>Update test points.</summary>
    /// <param name="pointUpdateModel">- Data to update.</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="planId">- ID of the test plan.</param>
    /// <param name="suiteId">- ID of the suite that contains the points.</param>
    /// <param name="pointIds">- ID of the test point to get. Use a comma-separated list of IDs to update multiple test points.</param>
    abstract updateTestPoints: pointUpdateModel: Test.PointUpdateModel * project: string * planId: float * suiteId: float * pointIds: string -> Promise<ResizeArray<Test.TestPoint>>
    /// <summary>Get test points using query.</summary>
    /// <param name="query">- TestPointsQuery to get test points.</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="skip">- Number of test points to skip..</param>
    /// <param name="top">- Number of test points to return.</param>
    abstract getPointsByQuery: query: Test.TestPointsQuery * project: string * ?skip: float * ?top: float -> Promise<Test.TestPointsQuery>
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
    /// <param name="testReferenceIds">- TestCaseReference Ids of the test Result to be queried, comma seperated list of valid ids (limit no. of ids 200).</param>
    /// <param name="project">- Project ID or project name</param>
    abstract queryTestResultsMetaData: testReferenceIds: ResizeArray<string> * project: string -> Promise<ResizeArray<Test.TestResultMetaData>>
    /// <summary>Get test result retention settings</summary>
    /// <param name="project">- Project ID or project name</param>
    abstract getResultRetentionSettings: project: string -> Promise<Test.ResultRetentionSettings>
    /// <summary>Update test result retention settings</summary>
    /// <param name="retentionSettings">- Test result retention settings details to be updated</param>
    /// <param name="project">- Project ID or project name</param>
    abstract updateResultRetentionSettings: retentionSettings: Test.ResultRetentionSettings * project: string -> Promise<Test.ResultRetentionSettings>
    /// <summary>Add test results to a test run.</summary>
    /// <param name="results">- List of test results to add.</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="runId">- Test run ID into which test results to add.</param>
    abstract addTestResultsToTestRun: results: ResizeArray<Test.TestCaseResult> * project: string * runId: float -> Promise<ResizeArray<Test.TestCaseResult>>
    /// <summary>Get a test result for a test run.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="runId">- Test run ID of a test result to fetch.</param>
    /// <param name="testCaseResultId">- Test result ID.</param>
    /// <param name="detailsToInclude">- Details to include with test results. Default is None. Other values are Iterations, WorkItems and SubResults.</param>
    abstract getTestResultById: project: string * runId: float * testCaseResultId: float * ?detailsToInclude: Test.ResultDetails -> Promise<Test.TestCaseResult>
    /// <summary>Get test results for a test run.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="runId">- Test run ID of test results to fetch.</param>
    /// <param name="detailsToInclude">- Details to include with test results. Default is None. Other values are Iterations and WorkItems.</param>
    /// <param name="skip">- Number of test results to skip from beginning.</param>
    /// <param name="top">- Number of test results to return. Maximum is 1000 when detailsToInclude is None and 200 otherwise.</param>
    /// <param name="outcomes">- Comma separated list of test outcomes to filter test results.</param>
    abstract getTestResults: project: string * runId: float * ?detailsToInclude: Test.ResultDetails * ?skip: float * ?top: float * ?outcomes: ResizeArray<Test.TestOutcome> -> Promise<ResizeArray<Test.TestCaseResult>>
    /// <summary>Update test results in a test run.</summary>
    /// <param name="results">- List of test results to update.</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="runId">- Test run ID whose test results to update.</param>
    abstract updateTestResults: results: ResizeArray<Test.TestCaseResult> * project: string * runId: float -> Promise<ResizeArray<Test.TestCaseResult>>
    /// <param name="query">-</param>
    /// <param name="project">- Project ID or project name</param>
    abstract getTestResultsByQuery: query: Test.TestResultsQuery * project: string -> Promise<Test.TestResultsQuery>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="buildId">-</param>
    /// <param name="publishContext">-</param>
    /// <param name="outcomes">-</param>
    /// <param name="top">-</param>
    /// <param name="continuationToken">-</param>
    abstract getTestResultsByBuild: project: string * buildId: float * ?publishContext: string * ?outcomes: ResizeArray<Test.TestOutcome> * ?top: float * ?continuationToken: string -> Promise<ResizeArray<Test.ShallowTestCaseResult>>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="releaseId">-</param>
    /// <param name="releaseEnvid">-</param>
    /// <param name="publishContext">-</param>
    /// <param name="outcomes">-</param>
    /// <param name="top">-</param>
    /// <param name="continuationToken">-</param>
    abstract getTestResultsByRelease: project: string * releaseId: float * ?releaseEnvid: float * ?publishContext: string * ?outcomes: ResizeArray<Test.TestOutcome> * ?top: float * ?continuationToken: string -> Promise<ResizeArray<Test.ShallowTestCaseResult>>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="buildId">-</param>
    /// <param name="publishContext">-</param>
    /// <param name="includeFailureDetails">-</param>
    /// <param name="buildToCompare">-</param>
    abstract queryTestResultsReportForBuild: project: string * buildId: float * ?publishContext: string * ?includeFailureDetails: bool * ?buildToCompare: Test.BuildReference -> Promise<Test.TestResultSummary>
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
    /// <summary>Create new test run.</summary>
    /// <param name="testRun">- Run details RunCreateModel</param>
    /// <param name="project">- Project ID or project name</param>
    abstract createTestRun: testRun: Test.RunCreateModel * project: string -> Promise<Test.TestRun>
    /// <summary>Delete a test run by its ID.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="runId">- ID of the run to delete.</param>
    abstract deleteTestRun: project: string * runId: float -> Promise<unit>
    /// <summary>Get a test run by its ID.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="runId">- ID of the run to get.</param>
    /// <param name="includeDetails">- Defualt value is true. It includes details like run statistics,release,build,Test enviornment,Post process state and more</param>
    abstract getTestRunById: project: string * runId: float * ?includeDetails: bool -> Promise<Test.TestRun>
    /// <summary>Get a list of test runs.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="buildUri">- URI of the build that the runs used.</param>
    /// <param name="owner">- Team foundation ID of the owner of the runs.</param>
    /// <param name="tmiRunId">-</param>
    /// <param name="planId">- ID of the test plan that the runs are a part of.</param>
    /// <param name="includeRunDetails">- If true, include all the properties of the runs.</param>
    /// <param name="automated">- If true, only returns automated runs.</param>
    /// <param name="skip">- Number of test runs to skip.</param>
    /// <param name="top">- Number of test runs to return.</param>
    abstract getTestRuns: project: string * ?buildUri: string * ?owner: string * ?tmiRunId: string * ?planId: float * ?includeRunDetails: bool * ?automated: bool * ?skip: float * ?top: float -> Promise<ResizeArray<Test.TestRun>>
    /// <summary>Query Test Runs based on filters. Mandatory fields are minLastUpdatedDate and maxLastUpdatedDate.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="minLastUpdatedDate">- Minimum Last Modified Date of run to be queried (Mandatory).</param>
    /// <param name="maxLastUpdatedDate">- Maximum Last Modified Date of run to be queried (Mandatory, difference between min and max date can be atmost 7 days).</param>
    /// <param name="state">- Current state of the Runs to be queried.</param>
    /// <param name="planIds">- Plan Ids of the Runs to be queried, comma seperated list of valid ids (limit no. of ids 10).</param>
    /// <param name="isAutomated">- Automation type of the Runs to be queried.</param>
    /// <param name="publishContext">- PublishContext of the Runs to be queried.</param>
    /// <param name="buildIds">- Build Ids of the Runs to be queried, comma seperated list of valid ids (limit no. of ids 10).</param>
    /// <param name="buildDefIds">- Build Definition Ids of the Runs to be queried, comma seperated list of valid ids (limit no. of ids 10).</param>
    /// <param name="branchName">- Source Branch name of the Runs to be queried.</param>
    /// <param name="releaseIds">- Release Ids of the Runs to be queried, comma seperated list of valid ids (limit no. of ids 10).</param>
    /// <param name="releaseDefIds">- Release Definition Ids of the Runs to be queried, comma seperated list of valid ids (limit no. of ids 10).</param>
    /// <param name="releaseEnvIds">- Release Environment Ids of the Runs to be queried, comma seperated list of valid ids (limit no. of ids 10).</param>
    /// <param name="releaseEnvDefIds">- Release Environment Definition Ids of the Runs to be queried, comma seperated list of valid ids (limit no. of ids 10).</param>
    /// <param name="runTitle">- Run Title of the Runs to be queried.</param>
    /// <param name="top">- Number of runs to be queried. Limit is 100</param>
    /// <param name="continuationToken">- continuationToken received from previous batch or null for first batch. It is not supposed to be created (or altered, if received from last batch) by user.</param>
    abstract queryTestRuns: project: string * minLastUpdatedDate: DateTime * maxLastUpdatedDate: DateTime * ?state: Test.TestRunState * ?planIds: ResizeArray<float> * ?isAutomated: bool * ?publishContext: Test.TestRunPublishContext * ?buildIds: ResizeArray<float> * ?buildDefIds: ResizeArray<float> * ?branchName: string * ?releaseIds: ResizeArray<float> * ?releaseDefIds: ResizeArray<float> * ?releaseEnvIds: ResizeArray<float> * ?releaseEnvDefIds: ResizeArray<float> * ?runTitle: string * ?top: float * ?continuationToken: string -> Promise<ResizeArray<Test.TestRun>>
    /// <summary>Update test run by its ID.</summary>
    /// <param name="runUpdateModel">- Run details RunUpdateModel</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="runId">- ID of the run to update.</param>
    abstract updateTestRun: runUpdateModel: Test.RunUpdateModel * project: string * runId: float -> Promise<Test.TestRun>
    /// <summary>Create a test session</summary>
    /// <param name="testSession">- Test session details for creation</param>
    /// <param name="teamContext">- The team context for the operation</param>
    abstract createTestSession: testSession: Test.TestSession * teamContext: Core.TeamContext -> Promise<Test.TestSession>
    /// <summary>Get a list of test sessions</summary>
    /// <param name="teamContext">- The team context for the operation</param>
    /// <param name="period">- Period in days from now, for which test sessions are fetched.</param>
    /// <param name="allSessions">- If false, returns test sessions for current user. Otherwise, it returns test sessions for all users</param>
    /// <param name="includeAllProperties">- If true, it returns all properties of the test sessions. Otherwise, it returns the skinny version.</param>
    /// <param name="source">- Source of the test session.</param>
    /// <param name="includeOnlyCompletedSessions">- If true, it returns test sessions in completed state. Otherwise, it returns test sessions for all states</param>
    abstract getTestSessions: teamContext: Core.TeamContext * ?period: float * ?allSessions: bool * ?includeAllProperties: bool * ?source: Test.TestSessionSource * ?includeOnlyCompletedSessions: bool -> Promise<ResizeArray<Test.TestSession>>
    /// <summary>Update a test session</summary>
    /// <param name="testSession">- Test session details for update</param>
    /// <param name="teamContext">- The team context for the operation</param>
    abstract updateTestSession: testSession: Test.TestSession * teamContext: Core.TeamContext -> Promise<Test.TestSession>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="sharedParameterId">-</param>
    abstract deleteSharedParameter: project: string * sharedParameterId: float -> Promise<unit>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="sharedStepId">-</param>
    abstract deleteSharedStep: project: string * sharedStepId: float -> Promise<unit>
    /// <summary>Add test cases to suite.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="planId">- ID of the test plan that contains the suite.</param>
    /// <param name="suiteId">- ID of the test suite to which the test cases must be added.</param>
    /// <param name="testCaseIds">- IDs of the test cases to add to the suite. Ids are specified in comma separated format.</param>
    abstract addTestCasesToSuite: project: string * planId: float * suiteId: float * testCaseIds: string -> Promise<ResizeArray<Test.SuiteTestCase>>
    /// <summary>Get a specific test case in a test suite with test case id.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="planId">- ID of the test plan that contains the suites.</param>
    /// <param name="suiteId">- ID of the suite that contains the test case.</param>
    /// <param name="testCaseIds">- ID of the test case to get.</param>
    abstract getTestCaseById: project: string * planId: float * suiteId: float * testCaseIds: float -> Promise<Test.SuiteTestCase>
    /// <summary>Get all test cases in a suite.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="planId">- ID of the test plan that contains the suites.</param>
    /// <param name="suiteId">- ID of the suite to get.</param>
    abstract getTestCases: project: string * planId: float * suiteId: float -> Promise<ResizeArray<Test.SuiteTestCase>>
    /// <summary>The test points associated with the test cases are removed from the test suite. The test case work item is not deleted from the system. See test cases resource to delete a test case permanently.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="planId">- ID of the test plan that contains the suite.</param>
    /// <param name="suiteId">- ID of the suite to get.</param>
    /// <param name="testCaseIds">- IDs of the test cases to remove from the suite.</param>
    abstract removeTestCasesFromSuiteUrl: project: string * planId: float * suiteId: float * testCaseIds: string -> Promise<unit>
    /// <summary>Updates the properties of the test case association in a suite.</summary>
    /// <param name="suiteTestCaseUpdateModel">- Model for updation of the properties of test case suite association.</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="planId">- ID of the test plan that contains the suite.</param>
    /// <param name="suiteId">- ID of the test suite to which the test cases must be added.</param>
    /// <param name="testCaseIds">- IDs of the test cases to add to the suite. Ids are specified in comma separated format.</param>
    abstract updateSuiteTestCases: suiteTestCaseUpdateModel: Test.SuiteTestCaseUpdateModel * project: string * planId: float * suiteId: float * testCaseIds: string -> Promise<ResizeArray<Test.SuiteTestCase>>
    /// <summary>Delete a test case.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="testCaseId">- Id of test case to delete.</param>
    abstract deleteTestCase: project: string * testCaseId: float -> Promise<unit>
    /// <summary>Get history of a test method using TestHistoryQuery</summary>
    /// <param name="filter">- TestHistoryQuery to get history</param>
    /// <param name="project">- Project ID or project name</param>
    abstract queryTestHistory: filter: Test.TestHistoryQuery * project: string -> Promise<Test.TestHistoryQuery>
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

type [<AllowNullLiteral>] TestRestClientStatic =
    [<Emit "new $0($1...)">] abstract Create: options: IVssRestClientOptions -> TestRestClient
    abstract RESOURCE_AREA_ID: string
