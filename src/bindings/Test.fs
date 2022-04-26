// ts2fable 0.7.1
module rec Test
open System
open Fable.Core
open Fable.Core.JS

type [<AllowNullLiteral>] AbortTestRunRequest =
    abstract options: float with get, set
    abstract projectName: string with get, set
    abstract revision: float with get, set
    abstract testRunId: float with get, set

type [<AllowNullLiteral>] AfnStrip =
    /// Auxiliary Url to be consumed by MTM
    abstract auxiliaryUrl: string with get, set
    /// Creation date of the AfnStrip
    abstract creationDate: DateTime with get, set
    /// File name of the attachment created
    abstract fileName: string with get, set
    /// ID of AfnStrip. This is same as the attachment ID.
    abstract id: float with get, set
    /// Project identifier which contains AfnStrip
    abstract project: string with get, set
    /// Service in which this attachment is stored in
    abstract storedIn: string with get, set
    /// Afn strip stream.
    abstract stream: string with get, set
    /// ID of the testcase.
    abstract testCaseId: float with get, set
    /// Backing test result id.
    abstract testResultId: float with get, set
    /// Backing test run id.
    abstract testRunId: float with get, set
    /// Byte stream (uncompressed) length of Afn strip.
    abstract unCompressedStreamLength: float with get, set
    /// Url of the attachment created.
    abstract url: string with get, set

type [<AllowNullLiteral>] AggregatedDataForResultTrend =
    /// This is tests execution duration.
    abstract duration: obj option with get, set
    abstract resultsByOutcome: AggregatedDataForResultTrendResultsByOutcome with get, set
    abstract runSummaryByState: AggregatedDataForResultTrendRunSummaryByState with get, set
    abstract testResultsContext: TestResultsContext with get, set
    abstract totalTests: float with get, set

/// Result deatils for a particular test result outcome.
type [<AllowNullLiteral>] AggregatedResultDetailsByOutcome =
    /// Number of results for current outcome.
    abstract count: float with get, set
    /// Time taken by results.
    abstract duration: obj option with get, set
    /// Test result outcome
    abstract outcome: TestOutcome with get, set
    /// Number of results on rerun
    abstract rerunResultCount: float with get, set

type [<AllowNullLiteral>] AggregatedResultsAnalysis =
    abstract duration: obj option with get, set
    abstract notReportedResultsByOutcome: AggregatedDataForResultTrendResultsByOutcome with get, set
    abstract previousContext: TestResultsContext with get, set
    abstract resultsByOutcome: AggregatedDataForResultTrendResultsByOutcome with get, set
    abstract resultsDifference: AggregatedResultsDifference with get, set
    abstract runSummaryByOutcome: AggregatedResultsAnalysisRunSummaryByOutcome with get, set
    abstract runSummaryByState: AggregatedDataForResultTrendRunSummaryByState with get, set
    abstract totalTests: float with get, set

type [<AllowNullLiteral>] AggregatedResultsByOutcome =
    abstract count: float with get, set
    abstract duration: obj option with get, set
    abstract groupByField: string with get, set
    abstract groupByValue: obj option with get, set
    abstract outcome: TestOutcome with get, set
    abstract rerunResultCount: float with get, set

type [<AllowNullLiteral>] AggregatedResultsDifference =
    abstract increaseInDuration: obj option with get, set
    abstract increaseInFailures: float with get, set
    abstract increaseInNonImpactedTests: float with get, set
    abstract increaseInOtherTests: float with get, set
    abstract increaseInPassedTests: float with get, set
    abstract increaseInTotalTests: float with get, set

type [<AllowNullLiteral>] AggregatedRunsByOutcome =
    abstract outcome: TestRunOutcome with get, set
    abstract runsCount: float with get, set

type [<AllowNullLiteral>] AggregatedRunsByState =
    abstract resultsByOutcome: AggregatedDataForResultTrendResultsByOutcome with get, set
    abstract runsCount: float with get, set
    abstract state: TestRunState with get, set

type [<RequireQualifiedAccess>] AttachmentType =
    | GeneralAttachment = 0
    | AfnStrip = 1
    | BugFilingData = 2
    | CodeCoverage = 3
    | IntermediateCollectorData = 4
    | RunConfig = 5
    | TestImpactDetails = 6
    | TmiTestRunDeploymentFiles = 7
    | TmiTestRunReverseDeploymentFiles = 8
    | TmiTestResultDetail = 9
    | TmiTestRunSummary = 10
    | ConsoleLog = 11

type [<AllowNullLiteral>] BatchResponse =
    abstract error: string with get, set
    abstract responses: ResizeArray<Response> with get, set
    abstract status: string with get, set

/// BuildConfiguration Details.
type [<AllowNullLiteral>] BuildConfiguration =
    /// Branch name for which build is generated.
    abstract branchName: string with get, set
    /// BuildDefinitionId for build.
    abstract buildDefinitionId: float with get, set
    /// Build system.
    abstract buildSystem: string with get, set
    /// Build Creation Date.
    abstract creationDate: DateTime with get, set
    /// Build flavor (eg Build/Release).
    abstract flavor: string with get, set
    /// BuildConfiguration Id.
    abstract id: float with get, set
    /// Build Number.
    abstract number: string with get, set
    /// BuildConfiguration Platform.
    abstract platform: string with get, set
    /// Project associated with this BuildConfiguration.
    abstract project: ShallowReference with get, set
    /// Repository Guid for the Build.
    abstract repositoryGuid: string with get, set
    /// Repository Id.
    abstract repositoryId: float with get, set
    /// Repository Type (eg. TFSGit).
    abstract repositoryType: string with get, set
    /// Source Version(/first commit) for the build was triggered.
    abstract sourceVersion: string with get, set
    /// Target BranchName.
    abstract targetBranchName: string with get, set
    /// Build Uri.
    abstract uri: string with get, set

/// Build Coverage Detail
type [<AllowNullLiteral>] BuildCoverage =
    /// Code Coverage File Url
    abstract codeCoverageFileUrl: string with get, set
    /// Build Configuration
    abstract configuration: BuildConfiguration with get, set
    /// Last Error
    abstract lastError: string with get, set
    /// List of Modules
    abstract modules: ResizeArray<ModuleCoverage> with get, set
    /// State
    abstract state: string with get, set

/// Reference to a build.
type [<AllowNullLiteral>] BuildReference =
    /// Branch name.
    abstract branchName: string with get, set
    /// Build system.
    abstract buildSystem: string with get, set
    /// Build Definition ID.
    abstract definitionId: float with get, set
    /// Build ID.
    abstract id: float with get, set
    /// Build Number.
    abstract number: string with get, set
    /// Repository ID.
    abstract repositoryId: string with get, set
    /// Build URI.
    abstract uri: string with get, set

type [<AllowNullLiteral>] BuildReference2 =
    abstract branchName: string with get, set
    abstract buildConfigurationId: float with get, set
    abstract buildDefinitionId: float with get, set
    abstract buildDeleted: bool with get, set
    abstract buildFlavor: string with get, set
    abstract buildId: float with get, set
    abstract buildNumber: string with get, set
    abstract buildPlatform: string with get, set
    abstract buildSystem: string with get, set
    abstract buildUri: string with get, set
    abstract coverageId: float with get, set
    abstract createdDate: DateTime with get, set
    abstract projectId: string with get, set
    abstract repoId: string with get, set
    abstract repoType: string with get, set
    abstract sourceVersion: string with get, set

type [<AllowNullLiteral>] BulkResultUpdateRequest =
    abstract projectName: string with get, set
    abstract requests: ResizeArray<ResultUpdateRequest> with get, set

/// Detail About Clone Operation.
type [<AllowNullLiteral>] CloneOperationInformation =
    /// Clone Statistics
    abstract cloneStatistics: CloneStatistics with get, set
    /// If the operation is complete, the DateTime of completion. If operation is not complete, this is DateTime.MaxValue
    abstract completionDate: DateTime with get, set
    /// DateTime when the operation was started
    abstract creationDate: DateTime with get, set
    /// Shallow reference of the destination
    abstract destinationObject: ShallowReference with get, set
    /// Shallow reference of the destination
    abstract destinationPlan: ShallowReference with get, set
    /// Shallow reference of the destination
    abstract destinationProject: ShallowReference with get, set
    /// If the operation has Failed, Message contains the reason for failure. Null otherwise.
    abstract message: string with get, set
    /// The ID of the operation
    abstract opId: float with get, set
    /// The type of the object generated as a result of the Clone operation
    abstract resultObjectType: ResultObjectType with get, set
    /// Shallow reference of the source
    abstract sourceObject: ShallowReference with get, set
    /// Shallow reference of the source
    abstract sourcePlan: ShallowReference with get, set
    /// Shallow reference of the source
    abstract sourceProject: ShallowReference with get, set
    /// Current state of the operation. When State reaches Suceeded or Failed, the operation is complete
    abstract state: CloneOperationState with get, set
    /// Url for getting the clone information
    abstract url: string with get, set

type [<RequireQualifiedAccess>] CloneOperationState =
    | Failed = 2
    | InProgress = 1
    | Queued = 0
    | Succeeded = 3

/// Clone options for cloning the test suite.
type [<AllowNullLiteral>] CloneOptions =
    /// If set to true requirements will be cloned
    abstract cloneRequirements: bool with get, set
    /// copy all suites from a source plan
    abstract copyAllSuites: bool with get, set
    /// copy ancestor hierarchy
    abstract copyAncestorHierarchy: bool with get, set
    /// Name of the workitem type of the clone
    abstract destinationWorkItemType: string with get, set
    /// Key value pairs where the key value is overridden by the value.
    abstract overrideParameters: CloneOptionsOverrideParameters with get, set
    /// Comment on the link that will link the new clone  test case to the original Set null for no comment
    abstract relatedLinkComment: string with get, set

/// Clone Statistics Details.
type [<AllowNullLiteral>] CloneStatistics =
    /// Number of requirements cloned so far.
    abstract clonedRequirementsCount: float with get, set
    /// Number of shared steps cloned so far.
    abstract clonedSharedStepsCount: float with get, set
    /// Number of test cases cloned so far
    abstract clonedTestCasesCount: float with get, set
    /// Total number of requirements to be cloned
    abstract totalRequirementsCount: float with get, set
    /// Total number of test cases to be cloned
    abstract totalTestCasesCount: float with get, set

/// Represents the build configuration (platform, flavor) and coverage data for the build
type [<AllowNullLiteral>] CodeCoverageData =
    /// Flavor of build for which data is retrieved/published
    abstract buildFlavor: string with get, set
    /// Platform of build for which data is retrieved/published
    abstract buildPlatform: string with get, set
    /// List of coverage data for the build
    abstract coverageStats: ResizeArray<CodeCoverageStatistics> with get, set

/// Represents the code coverage statistics for a particular coverage label (modules, statements, blocks, etc.)
type [<AllowNullLiteral>] CodeCoverageStatistics =
    /// Covered units
    abstract covered: float with get, set
    /// Delta of coverage
    abstract delta: float with get, set
    /// Is delta valid
    abstract isDeltaAvailable: bool with get, set
    /// Label of coverage data ("Blocks", "Statements", "Modules", etc.)
    abstract label: string with get, set
    /// Position of label
    abstract position: float with get, set
    /// Total units
    abstract total: float with get, set

/// Represents the code coverage summary results Used to publish or retrieve code coverage summary against a build
type [<AllowNullLiteral>] CodeCoverageSummary =
    /// Uri of build for which data is retrieved/published
    abstract build: ShallowReference with get, set
    /// List of coverage data and details for the build
    abstract coverageData: ResizeArray<CodeCoverageData> with get, set
    /// Uri of build against which difference in coverage is computed
    abstract deltaBuild: ShallowReference with get, set
    /// Uri of build against which difference in coverage is computed
    abstract status: CoverageSummaryStatus with get, set

type [<AllowNullLiteral>] CodeCoverageSummary2 =
    abstract buildConfigurationId: float with get, set
    abstract covered: float with get, set
    abstract label: string with get, set
    abstract position: float with get, set
    abstract projectId: string with get, set
    abstract total: float with get, set

type [<AllowNullLiteral>] Coverage2 =
    abstract coverageId: float with get, set
    abstract dateCreated: DateTime with get, set
    abstract dateModified: DateTime with get, set
    abstract lastError: string with get, set
    abstract state: float with get, set

type [<RequireQualifiedAccess>] CoverageQueryFlags =
    | Modules = 1
    | Functions = 2
    | BlockData = 4

type [<AllowNullLiteral>] CoverageStatistics =
    abstract blocksCovered: float with get, set
    abstract blocksNotCovered: float with get, set
    abstract linesCovered: float with get, set
    abstract linesNotCovered: float with get, set
    abstract linesPartiallyCovered: float with get, set

type [<RequireQualifiedAccess>] CoverageStatus =
    | Covered = 0
    | NotCovered = 1
    | PartiallyCovered = 2

type [<RequireQualifiedAccess>] CoverageSummaryStatus =
    | None = 0
    | InProgress = 1
    | Completed = 2
    | Finalized = 3
    | Pending = 4

type [<AllowNullLiteral>] CreateTestMessageLogEntryRequest =
    abstract projectName: string with get, set
    abstract testMessageLogEntry: ResizeArray<TestMessageLogEntry> with get, set
    abstract testRunId: float with get, set

type [<AllowNullLiteral>] CreateTestResultsRequest =
    abstract projectName: string with get, set
    abstract results: ResizeArray<LegacyTestCaseResult> with get, set

type [<AllowNullLiteral>] CreateTestRunRequest =
    abstract projectName: string with get, set
    abstract results: ResizeArray<LegacyTestCaseResult> with get, set
    abstract testRun: LegacyTestRun with get, set
    abstract testSettings: LegacyTestSettings with get, set

/// A custom field information. Allowed Key : Value pairs - ( AttemptId: int value, IsTestResultFlaky: bool)
type [<AllowNullLiteral>] CustomTestField =
    /// Field Name.
    abstract fieldName: string with get, set
    /// Field value.
    abstract value: obj option with get, set

type [<AllowNullLiteral>] CustomTestFieldDefinition =
    abstract fieldId: float with get, set
    abstract fieldName: string with get, set
    abstract fieldType: CustomTestFieldType with get, set
    abstract scope: CustomTestFieldScope with get, set

type [<RequireQualifiedAccess>] CustomTestFieldScope =
    | None = 0
    | TestRun = 1
    | TestResult = 2
    | System = 4
    | All = 7

type [<RequireQualifiedAccess>] CustomTestFieldType =
    | Bit = 2
    | DateTime = 4
    | Int = 8
    | Float = 6
    | String = 12
    | Guid = 14

type [<AllowNullLiteral>] DatedTestFieldData =
    abstract date: DateTime with get, set
    abstract value: TestFieldData with get, set

type [<AllowNullLiteral>] DefaultAfnStripBinding =
    abstract testCaseId: float with get, set
    abstract testResultId: float with get, set
    abstract testRunId: float with get, set

type [<AllowNullLiteral>] DeleteTestRunRequest =
    abstract projectName: string with get, set
    abstract testRunIds: ResizeArray<float> with get, set

type [<AllowNullLiteral>] DownloadAttachmentsRequest =
    abstract ids: ResizeArray<float> with get, set
    abstract lengths: ResizeArray<float> with get, set

/// This is a temporary class to provide the details for the test run environment.
type [<AllowNullLiteral>] DtlEnvironmentDetails =
    abstract csmContent: string with get, set
    abstract csmParameters: string with get, set
    abstract subscriptionName: string with get, set

/// Failing since information of a test result.
type [<AllowNullLiteral>] FailingSince =
    /// Build reference since failing.
    abstract build: BuildReference with get, set
    /// Time since failing.
    abstract date: DateTime with get, set
    /// Release reference since failing.
    abstract release: ReleaseReference with get, set

type [<AllowNullLiteral>] FetchTestResultsRequest =
    abstract idAndRevs: ResizeArray<TestCaseResultIdAndRev> with get, set
    abstract includeActionResults: bool with get, set
    abstract projectName: string with get, set

type [<AllowNullLiteral>] FetchTestResultsResponse =
    abstract actionResults: ResizeArray<TestActionResult> with get, set
    abstract attachments: ResizeArray<TestResultAttachment> with get, set
    abstract deletedIds: ResizeArray<LegacyTestCaseResultIdentifier> with get, set
    abstract results: ResizeArray<LegacyTestCaseResult> with get, set
    abstract testParameters: ResizeArray<TestResultParameter> with get, set

type [<AllowNullLiteral>] FieldDetailsForTestResults =
    /// Group by field name
    abstract fieldName: string with get, set
    /// Group by field values
    abstract groupsForField: ResizeArray<obj option> with get, set

type [<AllowNullLiteral>] FileCoverage =
    /// List of line blocks along with their coverage status
    abstract lineBlocksCoverage: ResizeArray<LineBlockCoverage> with get, set
    /// File path for which coverage information is sought for
    abstract path: string with get, set

type [<AllowNullLiteral>] FileCoverageRequest =
    abstract filePath: string with get, set
    abstract pullRequestBaseIterationId: float with get, set
    abstract pullRequestId: float with get, set
    abstract pullRequestIterationId: float with get, set
    abstract repoId: string with get, set

type [<AllowNullLiteral>] FilterPointQuery =
    abstract planId: float with get, set
    abstract pointIds: ResizeArray<float> with get, set
    abstract pointOutcome: ResizeArray<float> with get, set
    abstract resultState: ResizeArray<float> with get, set

type [<AllowNullLiteral>] FlakyDetection =
    /// FlakyDetectionPipelines defines Pipelines for Detection.
    abstract flakyDetectionPipelines: FlakyDetectionPipelines with get, set
    /// FlakyDetectionType defines Detection type i.e. 1. System or 2. Manual.
    abstract flakyDetectionType: FlakyDetectionType with get, set

type [<AllowNullLiteral>] FlakyDetectionPipelines =
    /// AllowedPipelines - List All Pipelines allowed for detection.
    abstract allowedPipelines: ResizeArray<float> with get, set
    /// IsAllPipelinesAllowed if users configure all system's pipelines.
    abstract isAllPipelinesAllowed: bool with get, set

type [<RequireQualifiedAccess>] FlakyDetectionType =
    | Custom = 1
    | System = 2

type [<AllowNullLiteral>] FlakySettings =
    /// FlakyDetection defines types of detection.
    abstract flakyDetection: FlakyDetection with get, set
    /// FlakyInSummaryReport defines flaky data should show in summary report or not.
    abstract flakyInSummaryReport: bool with get, set
    /// IsFlakyBugCreated defines if there is any bug that has been created with flaky testresult.
    abstract isFlakyBugCreated: bool with get, set
    /// ManualMarkUnmarkFlaky defines manual marking unmarking of flaky testcase.
    abstract manualMarkUnmarkFlaky: bool with get, set

type [<AllowNullLiteral>] FunctionCoverage =
    abstract ``class``: string with get, set
    abstract name: string with get, set
    abstract ``namespace``: string with get, set
    abstract sourceFile: string with get, set
    abstract statistics: CoverageStatistics with get, set

type [<AllowNullLiteral>] FunctionCoverage2 =
    abstract blocksCovered: float with get, set
    abstract blocksNotCovered: float with get, set
    abstract ``class``: string with get, set
    abstract coverageId: float with get, set
    abstract functionId: float with get, set
    abstract linesCovered: float with get, set
    abstract linesNotCovered: float with get, set
    abstract linesPartiallyCovered: float with get, set
    abstract moduleId: float with get, set
    abstract name: string with get, set
    abstract ``namespace``: string with get, set
    abstract sourceFile: string with get, set

type [<AllowNullLiteral>] HttpPostedTcmAttachment =
    abstract attachmentContent: string with get, set
    abstract contentLength: float with get, set
    abstract contentType: string with get, set
    abstract fileName: string with get, set

/// Job in pipeline. This is related to matrixing in YAML.
type [<AllowNullLiteral>] JobReference =
    /// Attempt number of the job
    abstract attempt: float with get, set
    /// Matrixing in YAML generates copies of a job with different inputs in matrix. JobName is the name of those input. Maximum supported length for name is 256 character.
    abstract jobName: string with get, set

/// Last result details of test point.
type [<AllowNullLiteral>] LastResultDetails =
    /// CompletedDate of LastResult.
    abstract dateCompleted: DateTime with get, set
    /// Duration of LastResult.
    abstract duration: float with get, set
    /// RunBy.
    abstract runBy: WebApi.IdentityRef with get, set

type [<AllowNullLiteral>] LegacyBuildConfiguration =
    abstract branchName: string with get, set
    abstract buildConfigurationId: float with get, set
    abstract buildDefinitionId: float with get, set
    abstract buildDefinitionName: string with get, set
    abstract buildFlavor: string with get, set
    abstract buildId: float with get, set
    abstract buildNumber: string with get, set
    abstract buildPlatform: string with get, set
    abstract buildQuality: string with get, set
    abstract buildSystem: string with get, set
    abstract buildUri: string with get, set
    abstract completedDate: DateTime with get, set
    abstract createdDate: DateTime with get, set
    abstract oldBuildConfigurationId: float with get, set
    abstract repositoryId: string with get, set
    abstract repositoryType: string with get, set
    abstract sourceVersion: string with get, set
    abstract teamProjectName: string with get, set

type [<AllowNullLiteral>] LegacyReleaseReference =
    abstract attempt: float with get, set
    abstract environmentCreationDate: DateTime with get, set
    abstract primaryArtifactBuildId: float with get, set
    abstract primaryArtifactProjectId: string with get, set
    abstract primaryArtifactType: string with get, set
    abstract releaseCreationDate: DateTime with get, set
    abstract releaseDefId: float with get, set
    abstract releaseEnvDefId: float with get, set
    abstract releaseEnvId: float with get, set
    abstract releaseEnvName: string with get, set
    abstract releaseEnvUri: string with get, set
    abstract releaseId: float with get, set
    abstract releaseName: string with get, set
    abstract releaseRefId: float with get, set
    abstract releaseUri: string with get, set

type [<AllowNullLiteral>] LegacyTestCaseResult =
    abstract afnStripId: float with get, set
    abstract areaId: float with get, set
    abstract areaUri: string with get, set
    abstract automatedTestId: string with get, set
    abstract automatedTestName: string with get, set
    abstract automatedTestStorage: string with get, set
    abstract automatedTestType: string with get, set
    abstract automatedTestTypeId: string with get, set
    abstract buildNumber: string with get, set
    abstract buildReference: LegacyBuildConfiguration with get, set
    abstract comment: string with get, set
    abstract computerName: string with get, set
    abstract configurationId: float with get, set
    abstract configurationName: string with get, set
    abstract creationDate: DateTime with get, set
    abstract customFields: ResizeArray<TestExtensionField> with get, set
    abstract dateCompleted: DateTime with get, set
    abstract dateStarted: DateTime with get, set
    abstract duration: float with get, set
    abstract errorMessage: string with get, set
    abstract failingSince: FailingSince with get, set
    abstract failureType: float with get, set
    abstract id: LegacyTestCaseResultIdentifier with get, set
    abstract isRerun: bool with get, set
    abstract lastUpdated: DateTime with get, set
    abstract lastUpdatedBy: string with get, set
    abstract lastUpdatedByName: string with get, set
    abstract outcome: float with get, set
    abstract owner: string with get, set
    abstract ownerName: string with get, set
    abstract priority: float with get, set
    abstract releaseReference: LegacyReleaseReference with get, set
    abstract resetCount: float with get, set
    abstract resolutionStateId: float with get, set
    abstract resultGroupType: ResultGroupType with get, set
    abstract revision: float with get, set
    abstract runBy: string with get, set
    abstract runByName: string with get, set
    abstract sequenceId: float with get, set
    abstract stackTrace: TestExtensionField with get, set
    abstract state: float with get, set
    abstract subResultCount: float with get, set
    abstract suiteName: string with get, set
    abstract testCaseArea: string with get, set
    abstract testCaseAreaUri: string with get, set
    abstract testCaseId: float with get, set
    abstract testCaseReferenceId: float with get, set
    abstract testCaseRevision: float with get, set
    abstract testCaseTitle: string with get, set
    abstract testPlanId: float with get, set
    abstract testPointId: float with get, set
    abstract testResultId: float with get, set
    abstract testRunId: float with get, set
    abstract testRunTitle: string with get, set
    abstract testSuiteId: float with get, set

type [<AllowNullLiteral>] LegacyTestCaseResultIdentifier =
    abstract areaUri: string with get, set
    abstract testResultId: float with get, set
    abstract testRunId: float with get, set

type [<AllowNullLiteral>] LegacyTestRun =
    abstract bugsCount: float with get, set
    abstract buildConfigurationId: float with get, set
    abstract buildFlavor: string with get, set
    abstract buildNumber: string with get, set
    abstract buildPlatform: string with get, set
    abstract buildReference: LegacyBuildConfiguration with get, set
    abstract buildUri: string with get, set
    abstract comment: string with get, set
    abstract completeDate: DateTime with get, set
    abstract configurationIds: ResizeArray<float> with get, set
    abstract controller: string with get, set
    abstract creationDate: DateTime with get, set
    abstract csmContent: string with get, set
    abstract csmParameters: string with get, set
    abstract customFields: ResizeArray<TestExtensionField> with get, set
    abstract dropLocation: string with get, set
    abstract dtlAutEnvironment: ShallowReference with get, set
    abstract dtlTestEnvironment: ShallowReference with get, set
    abstract dueDate: DateTime with get, set
    abstract errorMessage: string with get, set
    abstract filter: RunFilter with get, set
    abstract incompleteTests: float with get, set
    abstract isAutomated: bool with get, set
    abstract isBvt: bool with get, set
    abstract iteration: string with get, set
    abstract iterationId: float with get, set
    abstract lastUpdated: DateTime with get, set
    abstract lastUpdatedBy: string with get, set
    abstract lastUpdatedByName: string with get, set
    abstract legacySharePath: string with get, set
    abstract notApplicableTests: float with get, set
    abstract owner: string with get, set
    abstract ownerName: string with get, set
    abstract passedTests: float with get, set
    abstract postProcessState: float with get, set
    abstract publicTestSettingsId: float with get, set
    abstract releaseEnvironmentUri: string with get, set
    abstract releaseReference: LegacyReleaseReference with get, set
    abstract releaseUri: string with get, set
    abstract revision: float with get, set
    abstract rowVersion: ResizeArray<float> with get, set
    abstract runHasDtlEnvironment: bool with get, set
    abstract runTimeout: obj option with get, set
    abstract serviceVersion: string with get, set
    abstract sourceWorkflow: string with get, set
    abstract startDate: DateTime with get, set
    abstract state: float with get, set
    abstract subscriptionName: string with get, set
    abstract substate: float with get, set
    abstract teamProject: string with get, set
    abstract teamProjectUri: string with get, set
    abstract testConfigurationsMapping: string with get, set
    abstract testEnvironmentId: string with get, set
    abstract testMessageLogEntries: ResizeArray<TestMessageLogDetails> with get, set
    abstract testMessageLogId: float with get, set
    abstract testPlanId: float with get, set
    abstract testRunId: float with get, set
    abstract testRunStatistics: ResizeArray<LegacyTestRunStatistic> with get, set
    abstract testSettingsId: float with get, set
    abstract title: string with get, set
    abstract totalTests: float with get, set
    abstract ``type``: float with get, set
    abstract unanalyzedTests: float with get, set
    abstract version: float with get, set

type [<AllowNullLiteral>] LegacyTestRunStatistic =
    abstract count: float with get, set
    abstract outcome: float with get, set
    abstract resolutionState: TestResolutionState with get, set
    abstract state: float with get, set
    abstract testRunId: float with get, set

type [<AllowNullLiteral>] LegacyTestSettings =
    abstract areaId: float with get, set
    abstract areaPath: string with get, set
    abstract createdBy: string with get, set
    abstract createdByName: string with get, set
    abstract createdDate: DateTime with get, set
    abstract description: string with get, set
    abstract id: float with get, set
    abstract isAutomated: bool with get, set
    abstract isPublic: bool with get, set
    abstract lastUpdated: DateTime with get, set
    abstract lastUpdatedBy: string with get, set
    abstract lastUpdatedByName: string with get, set
    abstract machineRoles: ResizeArray<TestSettingsMachineRole> with get, set
    abstract name: string with get, set
    abstract revision: float with get, set
    abstract settings: string with get, set
    abstract teamProjectUri: string with get, set

type [<AllowNullLiteral>] LineBlockCoverage =
    /// End of line block
    abstract ``end``: float with get, set
    /// Start of line block
    abstract start: float with get, set
    /// Coverage status. Covered: 0, NotCovered: 1,  PartiallyCovered: 2
    abstract status: float with get, set

type [<AllowNullLiteral>] LinkedWorkItemsQuery =
    abstract automatedTestNames: ResizeArray<string> with get, set
    abstract planId: float with get, set
    abstract pointIds: ResizeArray<float> with get, set
    abstract suiteIds: ResizeArray<float> with get, set
    abstract testCaseIds: ResizeArray<float> with get, set
    abstract workItemCategory: string with get, set

type [<AllowNullLiteral>] LinkedWorkItemsQueryResult =
    abstract automatedTestName: string with get, set
    abstract planId: float with get, set
    abstract pointId: float with get, set
    abstract suiteId: float with get, set
    abstract testCaseId: float with get, set
    abstract workItems: ResizeArray<WorkItemReference> with get, set

type [<RequireQualifiedAccess>] Metrics =
    | All = 1
    | ResultSummary = 2
    | ResultsAnalysis = 3
    | RunSummary = 4

type [<AllowNullLiteral>] ModuleCoverage =
    abstract blockCount: float with get, set
    abstract blockData: ResizeArray<float> with get, set
    /// Code Coverage File Url
    abstract fileUrl: string with get, set
    abstract functions: ResizeArray<FunctionCoverage> with get, set
    abstract name: string with get, set
    abstract signature: string with get, set
    abstract signatureAge: float with get, set
    abstract statistics: CoverageStatistics with get, set

type [<AllowNullLiteral>] ModuleCoverage2 =
    abstract blockCount: float with get, set
    abstract blockData: ResizeArray<float> with get, set
    abstract blockDataLength: float with get, set
    abstract blocksCovered: float with get, set
    abstract blocksNotCovered: float with get, set
    abstract coverageFileUrl: string with get, set
    abstract coverageId: float with get, set
    abstract linesCovered: float with get, set
    abstract linesNotCovered: float with get, set
    abstract linesPartiallyCovered: float with get, set
    abstract moduleId: float with get, set
    abstract name: string with get, set
    abstract signature: string with get, set
    abstract signatureAge: float with get, set

/// Name value pair
type [<AllowNullLiteral>] NameValuePair =
    /// Name
    abstract name: string with get, set
    /// Value
    abstract value: string with get, set

type [<RequireQualifiedAccess>] OperationType =
    | Add = 1
    | Delete = 2

/// Phase in pipeline
type [<AllowNullLiteral>] PhaseReference =
    /// Attempt number of the phase
    abstract attempt: float with get, set
    /// Name of the phase. Maximum supported length for name is 256 character.
    abstract phaseName: string with get, set

/// Pipeline reference
type [<AllowNullLiteral>] PipelineReference =
    /// Reference of the job
    abstract jobReference: JobReference with get, set
    /// Reference of the phase.
    abstract phaseReference: PhaseReference with get, set
    /// Reference of the pipeline with which this pipeline instance is related.
    abstract pipelineId: float with get, set
    /// Reference of the stage.
    abstract stageReference: StageReference with get, set

/// Test summary of a pipeline instance.
type [<AllowNullLiteral>] PipelineTestMetrics =
    /// Reference of Pipeline instance for which test summary is calculated.
    abstract currentContext: PipelineReference with get, set
    /// This is the return value for metric ResultsAnalysis Results insights which include failure analysis, increase/decrease in results count analysis.
    abstract resultsAnalysis: ResultsAnalysis with get, set
    /// This is the return value for metric ResultSummary Results summary based on results outcome.
    abstract resultSummary: ResultSummary with get, set
    /// This is the return value for metric RunSummary Run summary.
    abstract runSummary: RunSummary with get, set
    /// Summary at child node.
    abstract summaryAtChild: ResizeArray<PipelineTestMetrics> with get, set

/// A model class used for creating and updating test plans.
type [<AllowNullLiteral>] PlanUpdateModel =
    /// Area path to which the test plan belongs. This should be set to area path of the team that works on this test plan.
    abstract area: ShallowReference with get, set
    abstract automatedTestEnvironment: TestEnvironment with get, set
    abstract automatedTestSettings: TestSettings with get, set
    /// Build ID of the build whose quality is tested by the tests in this test plan. For automated testing, this build ID is used to find the test binaries that contain automated test methods.
    abstract build: ShallowReference with get, set
    /// The Build Definition that generates a build associated with this test plan.
    abstract buildDefinition: ShallowReference with get, set
    /// IDs of configurations to be applied when new test suites and test cases are added to the test plan.
    abstract configurationIds: ResizeArray<float> with get, set
    /// Description of the test plan.
    abstract description: string with get, set
    /// End date for the test plan.
    abstract endDate: string with get, set
    /// Iteration path assigned to the test plan. This indicates when the target iteration by which the testing in this plan is supposed to be complete and the product is ready to be released.
    abstract iteration: string with get, set
    abstract manualTestEnvironment: TestEnvironment with get, set
    abstract manualTestSettings: TestSettings with get, set
    /// Name of the test plan.
    abstract name: string with get, set
    /// Owner of the test plan.
    abstract owner: WebApi.IdentityRef with get, set
    /// Release Environment to be used to deploy the build and run automated tests from this test plan.
    abstract releaseEnvironmentDefinition: ReleaseEnvironmentDefinitionReference with get, set
    /// Start date for the test plan.
    abstract startDate: string with get, set
    /// State of the test plan.
    abstract state: string with get, set
    abstract status: string with get, set
    /// Test Outcome settings
    abstract testOutcomeSettings: TestOutcomeSettings with get, set

/// Adding test cases to a suite creates one of more test points based on the default configurations and testers assigned to the test suite. PointAssignment is the list of test points that were created for each of the test cases that were added to the test suite.
type [<AllowNullLiteral>] PointAssignment =
    /// Configuration that was assigned to the test case.
    abstract configuration: ShallowReference with get, set
    /// Tester that was assigned to the test case
    abstract tester: WebApi.IdentityRef with get, set

type [<AllowNullLiteral>] PointLastResult =
    abstract lastUpdatedDate: DateTime with get, set
    abstract pointId: float with get, set

/// Filter class for test point.
type [<AllowNullLiteral>] PointsFilter =
    /// List of Configurations for filtering.
    abstract configurationNames: ResizeArray<string> with get, set
    /// List of test case id for filtering.
    abstract testcaseIds: ResizeArray<float> with get, set
    /// List of tester for filtering.
    abstract testers: ResizeArray<WebApi.IdentityRef> with get, set

type [<AllowNullLiteral>] PointsReference2 =
    abstract planId: float with get, set
    abstract pointId: float with get, set

type [<AllowNullLiteral>] PointsResults2 =
    abstract changeNumber: float with get, set
    abstract lastFailureType: float with get, set
    abstract lastResolutionStateId: float with get, set
    abstract lastResultOutcome: float with get, set
    abstract lastResultState: float with get, set
    abstract lastTestResultId: float with get, set
    abstract lastTestRunId: float with get, set
    abstract lastUpdated: DateTime with get, set
    abstract lastUpdatedBy: string with get, set
    abstract planId: float with get, set
    abstract pointId: float with get, set

/// Model to update test point.
type [<AllowNullLiteral>] PointUpdateModel =
    /// Outcome to update.
    abstract outcome: string with get, set
    /// Reset test point to active.
    abstract resetToActive: bool with get, set
    /// Tester to update. Type IdentityRef.
    abstract tester: WebApi.IdentityRef with get, set

/// Test point workitem property.
type [<AllowNullLiteral>] PointWorkItemProperty =
    /// key value pair of test point work item property.
    abstract workItem: PointWorkItemPropertyWorkItem with get, set

/// The class to represent a Generic store for test session data.
type [<AllowNullLiteral>] PropertyBag =
    /// Generic store for test session data
    abstract bag: CloneOptionsOverrideParameters with get, set

type [<AllowNullLiteral>] QueryByPointRequest =
    abstract projectName: string with get, set
    abstract testPlanId: float with get, set
    abstract testPointId: float with get, set

type [<AllowNullLiteral>] QueryByRunRequest =
    abstract includeActionResults: bool with get, set
    abstract outcome: float with get, set
    abstract owner: string with get, set
    abstract pageSize: float with get, set
    abstract projectName: string with get, set
    abstract state: float with get, set
    abstract testRunId: float with get, set

type [<AllowNullLiteral>] QueryModel =
    abstract query: string with get, set

type [<AllowNullLiteral>] QueryTestActionResultRequest =
    abstract identifier: LegacyTestCaseResultIdentifier with get, set
    abstract projectName: string with get, set

type [<AllowNullLiteral>] QueryTestActionResultResponse =
    abstract testActionResults: ResizeArray<TestActionResult> with get, set
    abstract testAttachments: ResizeArray<TestResultAttachment> with get, set
    abstract testResultParameters: ResizeArray<TestResultParameter> with get, set

type [<AllowNullLiteral>] QueryTestMessageLogEntryRequest =
    abstract projectName: string with get, set
    abstract testMessageLogId: float with get, set
    abstract testRunId: float with get, set

type [<AllowNullLiteral>] QueryTestRuns2Request =
    abstract includeStatistics: bool with get, set
    abstract query: ResultsStoreQuery with get, set

type [<AllowNullLiteral>] QueryTestRunsRequest =
    abstract buildUri: string with get, set
    abstract owner: string with get, set
    abstract planId: float with get, set
    abstract skip: float with get, set
    abstract teamProjectName: string with get, set
    abstract testRunId: float with get, set
    abstract top: float with get, set

type [<AllowNullLiteral>] QueryTestRunStatsRequest =
    abstract teamProjectName: string with get, set
    abstract testRunId: float with get, set

/// Reference to release environment resource.
type [<AllowNullLiteral>] ReleaseEnvironmentDefinitionReference =
    /// ID of the release definition that contains the release environment definition.
    abstract definitionId: float with get, set
    /// ID of the release environment definition.
    abstract environmentDefinitionId: float with get, set

/// Reference to a release.
type [<AllowNullLiteral>] ReleaseReference =
    /// Number of Release Attempt.
    abstract attempt: float with get, set
    /// Release Creation Date.
    abstract creationDate: DateTime with get, set
    /// Release definition ID.
    abstract definitionId: float with get, set
    /// Environment creation Date.
    abstract environmentCreationDate: DateTime with get, set
    /// Release environment definition ID.
    abstract environmentDefinitionId: float with get, set
    /// Release environment definition name.
    abstract environmentDefinitionName: string with get, set
    /// Release environment ID.
    abstract environmentId: float with get, set
    /// Release environment name.
    abstract environmentName: string with get, set
    /// Release ID.
    abstract id: float with get, set
    /// Release name.
    abstract name: string with get, set

type [<AllowNullLiteral>] ReleaseReference2 =
    abstract attempt: float with get, set
    abstract environmentCreationDate: DateTime with get, set
    abstract projectId: string with get, set
    abstract releaseCreationDate: DateTime with get, set
    abstract releaseDefId: float with get, set
    abstract releaseEnvDefId: float with get, set
    abstract releaseEnvId: float with get, set
    abstract releaseEnvName: string with get, set
    abstract releaseEnvUri: string with get, set
    abstract releaseId: float with get, set
    abstract releaseName: string with get, set
    abstract releaseRefId: float with get, set
    abstract releaseUri: string with get, set

type [<AllowNullLiteral>] RequirementsToTestsMapping2 =
    abstract createdBy: string with get, set
    abstract creationDate: DateTime with get, set
    abstract deletedBy: string with get, set
    abstract deletionDate: DateTime with get, set
    abstract isMigratedToWIT: bool with get, set
    abstract projectId: string with get, set
    abstract testMetadataId: float with get, set
    abstract workItemId: float with get, set

type [<AllowNullLiteral>] ResetTestResultsRequest =
    abstract ids: ResizeArray<LegacyTestCaseResultIdentifier> with get, set
    abstract projectName: string with get, set

type [<AllowNullLiteral>] Response =
    abstract error: string with get, set
    abstract id: string with get, set
    abstract status: string with get, set
    abstract url: string with get, set

type [<RequireQualifiedAccess>] ResultDetails =
    | None = 0
    | Iterations = 1
    | WorkItems = 2
    | SubResults = 4
    | Point = 8

type [<RequireQualifiedAccess>] ResultGroupType =
    | None = 0
    | Rerun = 1
    | DataDriven = 2
    | OrderedTest = 3
    | Generic = 4

type [<RequireQualifiedAccess>] ResultMetadata =
    | Rerun = 1
    | Flaky = 2

type [<RequireQualifiedAccess>] ResultMetaDataDetails =
    | None = 0
    | FlakyIdentifiers = 1

type [<RequireQualifiedAccess>] ResultObjectType =
    | TestSuite = 0
    | TestPlan = 1

/// Test result retention settings
type [<AllowNullLiteral>] ResultRetentionSettings =
    /// Automated test result retention duration in days
    abstract automatedResultsRetentionDuration: float with get, set
    /// Last Updated by identity
    abstract lastUpdatedBy: WebApi.IdentityRef with get, set
    /// Last updated date
    abstract lastUpdatedDate: DateTime with get, set
    /// Manual test result retention duration in days
    abstract manualResultsRetentionDuration: float with get, set

/// Results insights for runs with state completed and NeedInvestigation.
type [<AllowNullLiteral>] ResultsAnalysis =
    /// Reference of pipeline instance from which to compare the results.
    abstract previousContext: PipelineReference with get, set
    /// Increase/Decrease in counts of results for a different outcome with respect to PreviousContext.
    abstract resultsDifference: AggregatedResultsDifference with get, set
    /// Failure analysis of results with respect to PreviousContext
    abstract testFailuresAnalysis: TestResultFailuresAnalysis with get, set

type [<AllowNullLiteral>] ResultsByQueryRequest =
    abstract pageSize: float with get, set
    abstract query: ResultsStoreQuery with get, set

type [<AllowNullLiteral>] ResultsByQueryResponse =
    abstract excessIds: ResizeArray<LegacyTestCaseResultIdentifier> with get, set
    abstract testResults: ResizeArray<LegacyTestCaseResult> with get, set

type [<AllowNullLiteral>] ResultsFilter =
    abstract automatedTestName: string with get, set
    abstract branch: string with get, set
    abstract executedIn: Service with get, set
    abstract groupBy: string with get, set
    abstract maxCompleteDate: DateTime with get, set
    abstract resultsCount: float with get, set
    abstract testCaseId: float with get, set
    abstract testCaseReferenceIds: ResizeArray<float> with get, set
    abstract testPlanId: float with get, set
    abstract testPointIds: ResizeArray<float> with get, set
    abstract testResultsContext: TestResultsContext with get, set
    abstract trendDays: float with get, set

type [<AllowNullLiteral>] ResultsStoreQuery =
    abstract dayPrecision: bool with get, set
    abstract queryText: string with get, set
    abstract teamProjectName: string with get, set
    abstract timeZone: string with get, set

/// Result summary by the outcome of test results.
type [<AllowNullLiteral>] ResultsSummaryByOutcome =
    /// Aggregated result details for each test result outcome.
    abstract aggregatedResultDetailsByOutcome: ResultsSummaryByOutcomeAggregatedResultDetailsByOutcome with get, set
    /// Time taken by results.
    abstract duration: obj option with get, set
    /// Total number of not reported test results.
    abstract notReportedTestCount: float with get, set
    /// Total number of test results. (It includes NotImpacted test results as well which need to exclude while calculating pass/fail test result percentage).
    abstract totalTestCount: float with get, set

/// Summary of results for a pipeline instance.
type [<AllowNullLiteral>] ResultSummary =
    /// Result summary of pipeline, group by TestRun state.
    abstract resultSummaryByRunState: ResultSummaryResultSummaryByRunState with get, set

type [<AllowNullLiteral>] ResultUpdateRequest =
    abstract actionResultDeletes: ResizeArray<TestActionResult> with get, set
    abstract actionResults: ResizeArray<TestActionResult> with get, set
    abstract attachmentDeletes: ResizeArray<TestResultAttachmentIdentity> with get, set
    abstract attachments: ResizeArray<TestResultAttachment> with get, set
    abstract parameterDeletes: ResizeArray<TestResultParameter> with get, set
    abstract parameters: ResizeArray<TestResultParameter> with get, set
    abstract testCaseResult: LegacyTestCaseResult with get, set
    abstract testResultId: float with get, set
    abstract testRunId: float with get, set

type [<AllowNullLiteral>] ResultUpdateRequestModel =
    abstract actionResultDeletes: ResizeArray<TestActionResultModel> with get, set
    abstract actionResults: ResizeArray<TestActionResultModel> with get, set
    abstract parameterDeletes: ResizeArray<TestResultParameterModel> with get, set
    abstract parameters: ResizeArray<TestResultParameterModel> with get, set
    abstract testCaseResult: TestCaseResultUpdateModel with get, set

type [<AllowNullLiteral>] ResultUpdateResponse =
    abstract attachmentIds: ResizeArray<float> with get, set
    abstract lastUpdated: DateTime with get, set
    abstract lastUpdatedBy: string with get, set
    abstract lastUpdatedByName: string with get, set
    abstract maxReservedSubResultId: float with get, set
    abstract revision: float with get, set
    abstract testPlanId: float with get, set
    abstract testResultId: float with get, set

type [<AllowNullLiteral>] ResultUpdateResponseModel =
    abstract revision: float with get, set

/// Test run create details.
type [<AllowNullLiteral>] RunCreateModel =
    /// true if test run is automated, false otherwise. By default it will be false.
    abstract automated: bool with get, set
    /// An abstracted reference to the build that it belongs.
    abstract build: ShallowReference with get, set
    /// Drop location of the build used for test run.
    abstract buildDropLocation: string with get, set
    /// Flavor of the build used for test run. (E.g: Release, Debug)
    abstract buildFlavor: string with get, set
    /// Platform of the build used for test run. (E.g.: x86, amd64)
    abstract buildPlatform: string with get, set
    /// BuildReference of the test run.
    abstract buildReference: BuildConfiguration with get, set
    /// Comments entered by those analyzing the run.
    abstract comment: string with get, set
    /// Completed date time of the run.
    abstract completeDate: string with get, set
    /// IDs of the test configurations associated with the run.
    abstract configurationIds: ResizeArray<float> with get, set
    /// Name of the test controller used for automated run.
    abstract controller: string with get, set
    /// Additional properties of test Run.
    abstract customTestFields: ResizeArray<CustomTestField> with get, set
    /// An abstracted reference to DtlAutEnvironment.
    abstract dtlAutEnvironment: ShallowReference with get, set
    /// An abstracted reference to DtlTestEnvironment.
    abstract dtlTestEnvironment: ShallowReference with get, set
    /// Due date and time for test run.
    abstract dueDate: string with get, set
    abstract environmentDetails: DtlEnvironmentDetails with get, set
    /// Error message associated with the run.
    abstract errorMessage: string with get, set
    /// Filter used for discovering the Run.
    abstract filter: RunFilter with get, set
    /// The iteration in which to create the run. Root iteration of the team project will be default
    abstract iteration: string with get, set
    /// Name of the test run.
    abstract name: string with get, set
    /// Display name of the owner of the run.
    abstract owner: WebApi.IdentityRef with get, set
    /// Reference of the pipeline to which this test run belongs. PipelineReference.PipelineId should be equal to RunCreateModel.Build.Id
    abstract pipelineReference: PipelineReference with get, set
    /// An abstracted reference to the plan that it belongs.
    abstract plan: ShallowReference with get, set
    /// IDs of the test points to use in the run.
    abstract pointIds: ResizeArray<float> with get, set
    /// URI of release environment associated with the run.
    abstract releaseEnvironmentUri: string with get, set
    /// Reference to release associated with test run.
    abstract releaseReference: ReleaseReference with get, set
    /// URI of release associated with the run.
    abstract releaseUri: string with get, set
    /// Run summary for run Type = NoConfigRun.
    abstract runSummary: ResizeArray<RunSummaryModel> with get, set
    /// Timespan till the run times out.
    abstract runTimeout: obj option with get, set
    /// SourceWorkFlow(CI/CD) of the test run.
    abstract sourceWorkflow: string with get, set
    /// Start date time of the run.
    abstract startDate: string with get, set
    /// The state of the run. Type TestRunState Valid states - Unspecified ,NotStarted, InProgress, Completed, Waiting, Aborted, NeedsInvestigation
    abstract state: string with get, set
    /// Tags to attach with the test run, maximum of 5 tags can be added to run.
    abstract tags: ResizeArray<TestTag> with get, set
    /// TestConfigurationMapping of the test run.
    abstract testConfigurationsMapping: string with get, set
    /// ID of the test environment associated with the run.
    abstract testEnvironmentId: string with get, set
    /// An abstracted reference to the test settings resource.
    abstract testSettings: ShallowReference with get, set
    /// Type of the run(RunType) Valid Values : (Unspecified, Normal, Blocking, Web, MtrRunInitiatedFromWeb, RunWithDtlEnv, NoConfigRun)
    abstract ``type``: string with get, set

/// This class is used to provide the filters used for discovery
type [<AllowNullLiteral>] RunFilter =
    /// filter for the test case sources (test containers)
    abstract sourceFilter: string with get, set
    /// filter for the test cases
    abstract testCaseFilter: string with get, set

/// Test run statistics per outcome.
type [<AllowNullLiteral>] RunStatistic =
    /// Test result count fo the given outcome.
    abstract count: float with get, set
    /// Test result outcome
    abstract outcome: string with get, set
    /// Test run Resolution State.
    abstract resolutionState: TestResolutionState with get, set
    /// ResultMetadata for the given outcome/count.
    abstract resultMetadata: ResultMetadata with get, set
    /// State of the test run
    abstract state: string with get, set

/// Summary of runs for a pipeline instance.
type [<AllowNullLiteral>] RunSummary =
    /// Total time taken by runs with state completed and NeedInvestigation.
    abstract duration: obj option with get, set
    /// NoConfig runs count.
    abstract noConfigRunsCount: float with get, set
    /// Runs count by outcome for runs with state completed and NeedInvestigation runs.
    abstract runSummaryByOutcome: RunSummaryRunSummaryByOutcome with get, set
    /// Runs count by state.
    abstract runSummaryByState: RunSummaryRunSummaryByOutcome with get, set
    /// Total runs count.
    abstract totalRunsCount: float with get, set

/// Run summary for each output type of test.
type [<AllowNullLiteral>] RunSummaryModel =
    /// Total time taken in milliseconds.
    abstract duration: float with get, set
    /// Number of results for Outcome TestOutcome
    abstract resultCount: float with get, set
    /// Summary is based on outcome
    abstract testOutcome: TestOutcome with get, set

type [<RequireQualifiedAccess>] RunType =
    | Unspecified = 0
    | Normal = 1
    | Blocking = 2
    | Web = 4
    | MtrRunInitiatedFromWeb = 8
    | RunWithDtlEnv = 16
    | NoConfigRun = 32

type [<AllowNullLiteral>] RunUpdateModel =
    /// An abstracted reference to the build that it belongs.
    abstract build: ShallowReference with get, set
    /// Drop location of the build used for test run.
    abstract buildDropLocation: string with get, set
    /// Flavor of the build used for test run. (E.g: Release, Debug)
    abstract buildFlavor: string with get, set
    /// Platform of the build used for test run. (E.g.: x86, amd64)
    abstract buildPlatform: string with get, set
    /// Comments entered by those analyzing the run.
    abstract comment: string with get, set
    /// Completed date time of the run.
    abstract completedDate: string with get, set
    /// Name of the test controller used for automated run.
    abstract controller: string with get, set
    /// true to delete inProgess Results , false otherwise.
    abstract deleteInProgressResults: bool with get, set
    /// An abstracted reference to DtlAutEnvironment.
    abstract dtlAutEnvironment: ShallowReference with get, set
    /// An abstracted reference to DtlEnvironment.
    abstract dtlEnvironment: ShallowReference with get, set
    abstract dtlEnvironmentDetails: DtlEnvironmentDetails with get, set
    /// Due date and time for test run.
    abstract dueDate: string with get, set
    /// Error message associated with the run.
    abstract errorMessage: string with get, set
    /// The iteration in which to create the run.
    abstract iteration: string with get, set
    /// Log entries associated with the run. Use a comma-separated list of multiple log entry objects. \{ logEntry \}, \{ logEntry \}, ...
    abstract logEntries: ResizeArray<TestMessageLogDetails> with get, set
    /// Name of the test run.
    abstract name: string with get, set
    /// URI of release environment associated with the run.
    abstract releaseEnvironmentUri: string with get, set
    /// URI of release associated with the run.
    abstract releaseUri: string with get, set
    /// Run summary for run Type = NoConfigRun.
    abstract runSummary: ResizeArray<RunSummaryModel> with get, set
    /// SourceWorkFlow(CI/CD) of the test run.
    abstract sourceWorkflow: string with get, set
    /// Start date time of the run.
    abstract startedDate: string with get, set
    /// The state of the test run Below are the valid values - NotStarted, InProgress, Completed, Aborted, Waiting
    abstract state: string with get, set
    /// The types of sub states for test run.
    abstract substate: TestRunSubstate with get, set
    /// Tags to attach with the test run.
    abstract tags: ResizeArray<TestTag> with get, set
    /// ID of the test environment associated with the run.
    abstract testEnvironmentId: string with get, set
    /// An abstracted reference to test setting resource.
    abstract testSettings: ShallowReference with get, set

type [<RequireQualifiedAccess>] Service =
    | Any = 0
    | Tcm = 1
    | Tfs = 2

/// An abstracted reference to some other resource. This class is used to provide the build data contracts with a uniform way to reference other resources in a way that provides easy traversal through links.
type [<AllowNullLiteral>] ShallowReference =
    /// ID of the resource
    abstract id: string with get, set
    /// Name of the linked resource (definition name, controller name, etc.)
    abstract name: string with get, set
    /// Full http link to the resource
    abstract url: string with get, set

type [<AllowNullLiteral>] ShallowTestCaseResult =
    abstract automatedTestName: string with get, set
    abstract automatedTestStorage: string with get, set
    abstract durationInMs: float with get, set
    abstract id: float with get, set
    abstract isReRun: bool with get, set
    abstract outcome: string with get, set
    abstract owner: string with get, set
    abstract priority: float with get, set
    abstract refId: float with get, set
    abstract runId: float with get, set
    abstract tags: ResizeArray<string> with get, set
    abstract testCaseTitle: string with get, set

/// Reference to shared step workitem.
type [<AllowNullLiteral>] SharedStepModel =
    /// WorkItem shared step ID.
    abstract id: float with get, set
    /// Shared step workitem revision.
    abstract revision: float with get, set

/// Stage in pipeline
type [<AllowNullLiteral>] StageReference =
    /// Attempt number of stage
    abstract attempt: float with get, set
    /// Name of the stage. Maximum supported length for name is 256 character.
    abstract stageName: string with get, set

/// Suite create model
type [<AllowNullLiteral>] SuiteCreateModel =
    /// Name of test suite.
    abstract name: string with get, set
    /// For query based suites, query string that defines the suite.
    abstract queryString: string with get, set
    /// For requirements test suites, the IDs of the requirements.
    abstract requirementIds: ResizeArray<float> with get, set
    /// Type of test suite to create. It can have value from DynamicTestSuite, StaticTestSuite and RequirementTestSuite.
    abstract suiteType: string with get, set

/// A suite entry defines properties for a test suite.
type [<AllowNullLiteral>] SuiteEntry =
    /// Id of child suite in the test suite.
    abstract childSuiteId: float with get, set
    /// Sequence number for the test case or child test suite in the test suite.
    abstract sequenceNumber: float with get, set
    /// Id for the test suite.
    abstract suiteId: float with get, set
    /// Id of a test case in the test suite.
    abstract testCaseId: float with get, set

/// A model to define sequence of test suite entries in a test suite.
type [<AllowNullLiteral>] SuiteEntryUpdateModel =
    /// Id of the child suite in the test suite.
    abstract childSuiteId: float with get, set
    /// Updated sequence number for the test case or child test suite in the test suite.
    abstract sequenceNumber: float with get, set
    /// Id of the test case in the test suite.
    abstract testCaseId: float with get, set

type [<RequireQualifiedAccess>] SuiteExpand =
    | Children = 1
    | DefaultTesters = 2

/// Test case for the suite.
type [<AllowNullLiteral>] SuiteTestCase =
    /// Point Assignment for test suite's test case.
    abstract pointAssignments: ResizeArray<PointAssignment> with get, set
    /// Test case workItem reference.
    abstract testCase: WorkItemReference with get, set

/// Test suite update model.
type [<AllowNullLiteral>] SuiteTestCaseUpdateModel =
    /// Shallow reference of configurations for the test cases in the suite.
    abstract configurations: ResizeArray<ShallowReference> with get, set

/// Test suite update model.
type [<AllowNullLiteral>] SuiteUpdateModel =
    /// Shallow reference of default configurations for the suite.
    abstract defaultConfigurations: ResizeArray<ShallowReference> with get, set
    /// Shallow reference of test suite.
    abstract defaultTesters: ResizeArray<ShallowReference> with get, set
    /// Specifies if the default configurations have to be inherited from the parent test suite in which the test suite is created.
    abstract inheritDefaultConfigurations: bool with get, set
    /// Test suite name
    abstract name: string with get, set
    /// Shallow reference of the parent.
    abstract parent: ShallowReference with get, set
    /// For query based suites, the new query string.
    abstract queryString: string with get, set

type [<AllowNullLiteral>] TCMPropertyBag2 =
    abstract artifactId: float with get, set
    abstract artifactType: float with get, set
    abstract name: string with get, set
    abstract value: string with get, set

type [<RequireQualifiedAccess>] TCMServiceDataMigrationStatus =
    | NotStarted = 0
    | InProgress = 1
    | Completed = 2
    | Failed = 3

type [<AllowNullLiteral>] TestActionResult =
    abstract actionPath: string with get, set
    abstract comment: string with get, set
    abstract creationDate: DateTime with get, set
    abstract dateCompleted: DateTime with get, set
    abstract dateStarted: DateTime with get, set
    abstract duration: float with get, set
    abstract errorMessage: string with get, set
    abstract id: LegacyTestCaseResultIdentifier with get, set
    abstract iterationId: float with get, set
    abstract lastUpdated: DateTime with get, set
    abstract lastUpdatedBy: string with get, set
    abstract outcome: float with get, set
    abstract sharedStepId: float with get, set
    abstract sharedStepRevision: float with get, set

type [<AllowNullLiteral>] TestActionResult2 =
    abstract actionPath: string with get, set
    abstract comment: string with get, set
    abstract creationDate: DateTime with get, set
    abstract dateCompleted: DateTime with get, set
    abstract dateStarted: DateTime with get, set
    abstract duration: float with get, set
    abstract errorMessage: string with get, set
    abstract iterationId: float with get, set
    abstract lastUpdated: DateTime with get, set
    abstract outcome: float with get, set
    abstract sharedStepId: float with get, set
    abstract sharedStepRevision: float with get, set
    abstract testResultId: float with get, set
    abstract testRunId: float with get, set

/// Represents a test step result.
type [<AllowNullLiteral>] TestActionResultModel =
    inherit TestResultModelBase
    /// Path identifier test step in test case workitem.
    abstract actionPath: string with get, set
    /// Iteration ID of test action result.
    abstract iterationId: float with get, set
    /// Reference to shared step workitem.
    abstract sharedStepModel: SharedStepModel with get, set
    /// This is step Id of test case. For shared step, it is step Id of shared step in test case workitem; step Id in shared step. Example: TestCase workitem has two steps: 1) Normal step with Id = 1 2) Shared Step with Id = 2. Inside shared step: a) Normal Step with Id = 1 Value for StepIdentifier for First step: "1" Second step: "2;1"
    abstract stepIdentifier: string with get, set
    /// Url of test action result.
    abstract url: string with get, set

type [<AllowNullLiteral>] TestAttachment =
    /// Attachment type.
    abstract attachmentType: AttachmentType with get, set
    /// Comment associated with attachment.
    abstract comment: string with get, set
    /// Attachment created date.
    abstract createdDate: DateTime with get, set
    /// Attachment file name
    abstract fileName: string with get, set
    /// ID of the attachment.
    abstract id: float with get, set
    /// Attachment size.
    abstract size: float with get, set
    /// Attachment Url.
    abstract url: string with get, set

/// Reference to test attachment.
type [<AllowNullLiteral>] TestAttachmentReference =
    /// ID of the attachment.
    abstract id: float with get, set
    /// Url to download the attachment.
    abstract url: string with get, set

/// Test attachment request model
type [<AllowNullLiteral>] TestAttachmentRequestModel =
    /// Attachment type By Default it will be GeneralAttachment. It can be one of the following type. \{ GeneralAttachment, AfnStrip, BugFilingData, CodeCoverage, IntermediateCollectorData, RunConfig, TestImpactDetails, TmiTestRunDeploymentFiles, TmiTestRunReverseDeploymentFiles, TmiTestResultDetail, TmiTestRunSummary \}
    abstract attachmentType: string with get, set
    /// Comment associated with attachment
    abstract comment: string with get, set
    /// Attachment filename
    abstract fileName: string with get, set
    /// Base64 encoded file stream
    abstract stream: string with get, set

type [<AllowNullLiteral>] TestAuthoringDetails =
    abstract configurationId: float with get, set
    abstract isAutomated: bool with get, set
    abstract lastUpdated: DateTime with get, set
    abstract pointId: float with get, set
    abstract priority: float with get, set
    abstract runBy: string with get, set
    abstract state: TestPointState with get, set
    abstract suiteId: float with get, set
    abstract testerId: string with get, set

type [<AllowNullLiteral>] TestCaseMetadata2 =
    abstract container: string with get, set
    abstract name: string with get, set
    abstract projectId: string with get, set
    abstract testMetadataId: float with get, set

type [<AllowNullLiteral>] TestCaseReference2 =
    abstract areaId: float with get, set
    abstract automatedTestId: string with get, set
    abstract automatedTestName: string with get, set
    abstract automatedTestNameHash: ResizeArray<float> with get, set
    abstract automatedTestStorage: string with get, set
    abstract automatedTestStorageHash: ResizeArray<float> with get, set
    abstract automatedTestType: string with get, set
    abstract configurationId: float with get, set
    abstract createdBy: string with get, set
    abstract creationDate: DateTime with get, set
    abstract lastRefTestRunDate: DateTime with get, set
    abstract owner: string with get, set
    abstract priority: float with get, set
    abstract projectId: string with get, set
    abstract testCaseId: float with get, set
    abstract testCaseRefId: float with get, set
    abstract testCaseRevision: float with get, set
    abstract testCaseTitle: string with get, set
    abstract testPointId: float with get, set

/// Represents a test result.
type [<AllowNullLiteral>] TestCaseResult =
    /// Test attachment ID of action recording.
    abstract afnStripId: float with get, set
    /// Reference to area path of test.
    abstract area: ShallowReference with get, set
    /// Reference to bugs linked to test result.
    abstract associatedBugs: ResizeArray<ShallowReference> with get, set
    /// ID representing test method in a dll.
    abstract automatedTestId: string with get, set
    /// Fully qualified name of test executed.
    abstract automatedTestName: string with get, set
    /// Container to which test belongs.
    abstract automatedTestStorage: string with get, set
    /// Type of automated test.
    abstract automatedTestType: string with get, set
    /// TypeId of automated test.
    abstract automatedTestTypeId: string with get, set
    /// Shallow reference to build associated with test result.
    abstract build: ShallowReference with get, set
    /// Reference to build associated with test result.
    abstract buildReference: BuildReference with get, set
    /// Comment in a test result with maxSize= 1000 chars.
    abstract comment: string with get, set
    /// Time when test execution completed. Completed date should be greater than StartedDate.
    abstract completedDate: DateTime with get, set
    /// Machine name where test executed.
    abstract computerName: string with get, set
    /// Reference to test configuration. Type ShallowReference.
    abstract configuration: ShallowReference with get, set
    /// Timestamp when test result created.
    abstract createdDate: DateTime with get, set
    /// Additional properties of test result.
    abstract customFields: ResizeArray<CustomTestField> with get, set
    /// Duration of test execution in milliseconds. If not provided value will be set as CompletedDate - StartedDate
    abstract durationInMs: float with get, set
    /// Error message in test execution.
    abstract errorMessage: string with get, set
    /// Information when test results started failing.
    abstract failingSince: FailingSince with get, set
    /// Failure type of test result. Valid Value= (Known Issue, New Issue, Regression, Unknown, None)
    abstract failureType: string with get, set
    /// ID of a test result.
    abstract id: float with get, set
    /// Test result details of test iterations used only for Manual Testing.
    abstract iterationDetails: ResizeArray<TestIterationDetailsModel> with get, set
    /// Reference to identity last updated test result.
    abstract lastUpdatedBy: WebApi.IdentityRef with get, set
    /// Last updated datetime of test result.
    abstract lastUpdatedDate: DateTime with get, set
    /// Test outcome of test result. Valid values = (Unspecified, None, Passed, Failed, Inconclusive, Timeout, Aborted, Blocked, NotExecuted, Warning, Error, NotApplicable, Paused, InProgress, NotImpacted)
    abstract outcome: string with get, set
    /// Reference to test owner.
    abstract owner: WebApi.IdentityRef with get, set
    /// Priority of test executed.
    abstract priority: float with get, set
    /// Reference to team project.
    abstract project: ShallowReference with get, set
    /// Shallow reference to release associated with test result.
    abstract release: ShallowReference with get, set
    /// Reference to release associated with test result.
    abstract releaseReference: ReleaseReference with get, set
    /// ResetCount.
    abstract resetCount: float with get, set
    /// Resolution state of test result.
    abstract resolutionState: string with get, set
    /// ID of resolution state.
    abstract resolutionStateId: float with get, set
    /// Hierarchy type of the result, default value of None means its leaf node.
    abstract resultGroupType: ResultGroupType with get, set
    /// Revision number of test result.
    abstract revision: float with get, set
    /// Reference to identity executed the test.
    abstract runBy: WebApi.IdentityRef with get, set
    /// Stacktrace with maxSize= 1000 chars.
    abstract stackTrace: string with get, set
    /// Time when test execution started.
    abstract startedDate: DateTime with get, set
    /// State of test result. Type TestRunState.
    abstract state: string with get, set
    /// List of sub results inside a test result, if ResultGroupType is not None, it holds corresponding type sub results.
    abstract subResults: ResizeArray<TestSubResult> with get, set
    /// Reference to the test executed.
    abstract testCase: ShallowReference with get, set
    /// Reference ID of test used by test result. Type TestResultMetaData
    abstract testCaseReferenceId: float with get, set
    /// TestCaseRevision Number.
    abstract testCaseRevision: float with get, set
    /// Name of test.
    abstract testCaseTitle: string with get, set
    /// Reference to test plan test case workitem is part of.
    abstract testPlan: ShallowReference with get, set
    /// Reference to the test point executed.
    abstract testPoint: ShallowReference with get, set
    /// Reference to test run.
    abstract testRun: ShallowReference with get, set
    /// Reference to test suite test case workitem is part of.
    abstract testSuite: ShallowReference with get, set
    /// Url of test result.
    abstract url: string with get, set

/// Test attachment information in a test iteration.
type [<AllowNullLiteral>] TestCaseResultAttachmentModel =
    /// Path identifier test step in test case workitem.
    abstract actionPath: string with get, set
    /// Attachment ID.
    abstract id: float with get, set
    /// Iteration ID.
    abstract iterationId: float with get, set
    /// Name of attachment.
    abstract name: string with get, set
    /// Attachment size.
    abstract size: float with get, set
    /// Url to attachment.
    abstract url: string with get, set

type [<AllowNullLiteral>] TestCaseResultIdAndRev =
    abstract id: LegacyTestCaseResultIdentifier with get, set
    abstract revision: float with get, set

/// Reference to a test result.
type [<AllowNullLiteral>] TestCaseResultIdentifier =
    /// Test result ID.
    abstract testResultId: float with get, set
    /// Test run ID.
    abstract testRunId: float with get, set

type [<AllowNullLiteral>] TestCaseResultUpdateModel =
    abstract associatedWorkItems: ResizeArray<float> with get, set
    abstract automatedTestTypeId: string with get, set
    abstract comment: string with get, set
    abstract completedDate: string with get, set
    abstract computerName: string with get, set
    abstract customFields: ResizeArray<CustomTestField> with get, set
    abstract durationInMs: string with get, set
    abstract errorMessage: string with get, set
    abstract failureType: string with get, set
    abstract outcome: string with get, set
    abstract owner: WebApi.IdentityRef with get, set
    abstract resolutionState: string with get, set
    abstract runBy: WebApi.IdentityRef with get, set
    abstract stackTrace: string with get, set
    abstract startedDate: string with get, set
    abstract state: string with get, set
    abstract testCasePriority: string with get, set
    abstract testResult: ShallowReference with get, set

/// Test configuration
type [<AllowNullLiteral>] TestConfiguration =
    /// Area of the configuration
    abstract area: ShallowReference with get, set
    /// Description of the configuration
    abstract description: string with get, set
    /// Id of the configuration
    abstract id: float with get, set
    /// Is the configuration a default for the test plans
    abstract isDefault: bool with get, set
    /// Last Updated By  Reference
    abstract lastUpdatedBy: WebApi.IdentityRef with get, set
    /// Last Updated Data
    abstract lastUpdatedDate: DateTime with get, set
    /// Name of the configuration
    abstract name: string with get, set
    /// Project to which the configuration belongs
    abstract project: ShallowReference with get, set
    /// Revision of the the configuration
    abstract revision: float with get, set
    /// State of the configuration
    abstract state: TestConfigurationState with get, set
    /// Url of Configuration Resource
    abstract url: string with get, set
    /// Dictionary of Test Variable, Selected Value
    abstract values: ResizeArray<NameValuePair> with get, set

type [<RequireQualifiedAccess>] TestConfigurationState =
    | Active = 1
    | Inactive = 2

/// Test environment Detail.
type [<AllowNullLiteral>] TestEnvironment =
    /// Test Environment Id.
    abstract environmentId: string with get, set
    /// Test Environment Name.
    abstract environmentName: string with get, set

type [<AllowNullLiteral>] TestExecutionReportData =
    abstract reportData: ResizeArray<DatedTestFieldData> with get, set

type [<AllowNullLiteral>] TestExtensionField =
    abstract field: TestExtensionFieldDetails with get, set
    abstract value: obj option with get, set

type [<AllowNullLiteral>] TestExtensionFieldDetails =
    abstract id: float with get, set
    abstract isResultScoped: bool with get, set
    abstract isRunScoped: bool with get, set
    abstract isSystemField: bool with get, set
    abstract name: string with get, set
    abstract ``type``: SystemData.SqlDbType with get, set

type [<AllowNullLiteral>] TestFailureDetails =
    abstract count: float with get, set
    abstract testResults: ResizeArray<TestCaseResultIdentifier> with get, set

type [<AllowNullLiteral>] TestFailuresAnalysis =
    abstract existingFailures: TestFailureDetails with get, set
    abstract fixedTests: TestFailureDetails with get, set
    abstract newFailures: TestFailureDetails with get, set
    abstract previousContext: TestResultsContext with get, set

type [<AllowNullLiteral>] TestFailureType =
    abstract id: float with get, set
    abstract name: string with get, set
    abstract project: ShallowReference with get, set

type [<AllowNullLiteral>] TestFieldData =
    abstract dimensions: TestFieldDataDimensions with get, set
    abstract ``measure``: float with get, set

type [<AllowNullLiteral>] TestFieldsEx2 =
    abstract fieldId: float with get, set
    abstract fieldName: string with get, set
    abstract fieldType: float with get, set
    abstract isResultScoped: bool with get, set
    abstract isRunScoped: bool with get, set
    abstract isSystemField: bool with get, set
    abstract projectId: string with get, set

/// Test Flaky Identifier
type [<AllowNullLiteral>] TestFlakyIdentifier =
    /// Branch Name where Flakiness has to be Marked/Unmarked
    abstract branchName: string with get, set
    /// State for Flakiness
    abstract isFlaky: bool with get, set

/// Filter to get TestCase result history.
type [<AllowNullLiteral>] TestHistoryQuery =
    /// Automated test name of the TestCase.
    abstract automatedTestName: string with get, set
    /// Results to be get for a particular branches.
    abstract branch: string with get, set
    /// Get the results history only for this BuildDefinitionId. This to get used in query GroupBy should be Branch. If this is provided, Branch will have no use.
    abstract buildDefinitionId: float with get, set
    /// It will be filled by server. If not null means there are some results still to be get, and we need to call this REST API with this ContinuousToken. It is not supposed to be created (or altered, if received from server in last batch) by user.
    abstract continuationToken: string with get, set
    /// Group the result on the basis of TestResultGroupBy. This can be Branch, Environment or null(if results are fetched by BuildDefinitionId)
    abstract groupBy: TestResultGroupBy with get, set
    /// History to get between time interval MaxCompleteDate and  (MaxCompleteDate - TrendDays). Default is current date time.
    abstract maxCompleteDate: DateTime with get, set
    /// Get the results history only for this ReleaseEnvDefinitionId. This to get used in query GroupBy should be Environment.
    abstract releaseEnvDefinitionId: float with get, set
    /// List of TestResultHistoryForGroup which are grouped by GroupBy
    abstract resultsForGroup: ResizeArray<TestResultHistoryForGroup> with get, set
    /// Get the results history only for this testCaseId. This to get used in query to filter the result along with automatedtestname
    abstract testCaseId: float with get, set
    /// Number of days for which history to collect. Maximum supported value is 7 days. Default is 7 days.
    abstract trendDays: float with get, set

/// Represents a test iteration result.
type [<AllowNullLiteral>] TestIterationDetailsModel =
    /// Test step results in an iteration.
    abstract actionResults: ResizeArray<TestActionResultModel> with get, set
    /// Reference to attachments in test iteration result.
    abstract attachments: ResizeArray<TestCaseResultAttachmentModel> with get, set
    /// Comment in test iteration result.
    abstract comment: string with get, set
    /// Time when execution completed.
    abstract completedDate: DateTime with get, set
    /// Duration of execution.
    abstract durationInMs: float with get, set
    /// Error message in test iteration result execution.
    abstract errorMessage: string with get, set
    /// ID of test iteration result.
    abstract id: float with get, set
    /// Test outcome if test iteration result.
    abstract outcome: string with get, set
    /// Test parameters in an iteration.
    abstract parameters: ResizeArray<TestResultParameterModel> with get, set
    /// Time when execution started.
    abstract startedDate: DateTime with get, set
    /// Url to test iteration result.
    abstract url: string with get, set

/// Represents Test Log Result object.
type [<AllowNullLiteral>] TestLog =
    /// Test Log Context run, build
    abstract logReference: TestLogReference with get, set
    /// Meta data for Log file
    abstract metaData: CloneOptionsOverrideParameters with get, set
    /// LastUpdatedDate for Log file
    abstract modifiedOn: DateTime with get, set
    /// Size in Bytes for Log file
    abstract size: float with get, set

/// Test Log Reference object
type [<AllowNullLiteral>] TestLogReference =
    /// BuildId for test log, if context is build
    abstract buildId: float with get, set
    /// FileName for log file
    abstract filePath: string with get, set
    /// ReleaseEnvId for test log, if context is Release
    abstract releaseEnvId: float with get, set
    /// ReleaseId for test log, if context is Release
    abstract releaseId: float with get, set
    /// Resultid for test log, if context is run and log is related to result
    abstract resultId: float with get, set
    /// runid for test log, if context is run
    abstract runId: float with get, set
    /// Test Log Scope
    abstract scope: TestLogScope with get, set
    /// SubResultid for test log, if context is run and log is related to subresult
    abstract subResultId: float with get, set
    /// Log Type
    abstract ``type``: TestLogType with get, set

type [<RequireQualifiedAccess>] TestLogScope =
    | Run = 0
    | Build = 1
    | Release = 2

/// Represents Test Log Status object.
type [<AllowNullLiteral>] TestLogStatus =
    /// Exception message
    abstract ``exception``: string with get, set
    /// Test Log Status code
    abstract status: TestLogStatusCode with get, set
    /// Blob Transfer Error code
    abstract transferFailureType: string with get, set

type [<RequireQualifiedAccess>] TestLogStatusCode =
    | Success = 0
    | Failed = 1
    | FileAlreadyExists = 2
    | InvalidInput = 3
    | InvalidFileName = 4
    | InvalidContainer = 5
    | TransferFailed = 6
    | FeatureDisabled = 7
    | BuildDoesNotExist = 8
    | RunDoesNotExist = 9
    | ContainerNotCreated = 10
    | APINotSupported = 11
    | FileSizeExceeds = 12
    | ContainerNotFound = 13
    | FileNotFound = 14
    | DirectoryNotFound = 15
    | StorageCapacityExceeded = 16

/// Represents Test Log store endpoint details.
type [<AllowNullLiteral>] TestLogStoreEndpointDetails =
    /// Test log store connection Uri.
    abstract endpointSASUri: string with get, set
    /// Test log store endpoint type.
    abstract endpointType: TestLogStoreEndpointType with get, set
    /// Test log store status code
    abstract status: TestLogStatusCode with get, set

type [<RequireQualifiedAccess>] TestLogStoreEndpointType =
    | Root = 1
    | File = 2

type [<RequireQualifiedAccess>] TestLogStoreOperationType =
    | Read = 1
    | Create = 2
    | ReadAndCreate = 3

type [<RequireQualifiedAccess>] TestLogType =
    | GeneralAttachment = 1
    | CodeCoverage = 2
    | TestImpact = 3
    | Intermediate = 4
    | System = 5

type [<AllowNullLiteral>] TestMessageLog2 =
    abstract testMessageLogId: float with get, set

/// An abstracted reference to some other resource. This class is used to provide the build data contracts with a uniform way to reference other resources in a way that provides easy traversal through links.
type [<AllowNullLiteral>] TestMessageLogDetails =
    /// Date when the resource is created
    abstract dateCreated: DateTime with get, set
    /// Id of the resource
    abstract entryId: float with get, set
    /// Message of the resource
    abstract message: string with get, set

type [<AllowNullLiteral>] TestMessageLogEntry =
    abstract dateCreated: DateTime with get, set
    abstract entryId: float with get, set
    abstract logLevel: float with get, set
    abstract logUser: string with get, set
    abstract logUserName: string with get, set
    abstract message: string with get, set
    abstract testMessageLogId: float with get, set

type [<AllowNullLiteral>] TestMessageLogEntry2 =
    abstract dateCreated: DateTime with get, set
    abstract entryId: float with get, set
    abstract logLevel: float with get, set
    abstract logUser: string with get, set
    abstract message: string with get, set
    abstract testMessageLogId: float with get, set

type [<AllowNullLiteral>] TestMethod =
    abstract container: string with get, set
    abstract name: string with get, set

/// Class representing a reference to an operation.
type [<AllowNullLiteral>] TestOperationReference =
    abstract id: string with get, set
    abstract status: string with get, set
    abstract url: string with get, set

type [<RequireQualifiedAccess>] TestOutcome =
    | Unspecified = 0
    | None = 1
    | Passed = 2
    | Failed = 3
    | Inconclusive = 4
    | Timeout = 5
    | Aborted = 6
    | Blocked = 7
    | NotExecuted = 8
    | Warning = 9
    | Error = 10
    | NotApplicable = 11
    | Paused = 12
    | InProgress = 13
    | NotImpacted = 14
    | MaxValue = 14

/// Test outcome settings
type [<AllowNullLiteral>] TestOutcomeSettings =
    /// Value to configure how test outcomes for the same tests across suites are shown
    abstract syncOutcomeAcrossSuites: bool with get, set

type [<AllowNullLiteral>] TestParameter2 =
    abstract actionPath: string with get, set
    abstract actual: ResizeArray<float> with get, set
    abstract creationDate: DateTime with get, set
    abstract dataType: float with get, set
    abstract dateModified: DateTime with get, set
    abstract expected: ResizeArray<float> with get, set
    abstract iterationId: float with get, set
    abstract parameterName: string with get, set
    abstract testResultId: float with get, set
    abstract testRunId: float with get, set

/// The test plan resource.
type [<AllowNullLiteral>] TestPlan =
    /// Area of the test plan.
    abstract area: ShallowReference with get, set
    abstract automatedTestEnvironment: TestEnvironment with get, set
    abstract automatedTestSettings: TestSettings with get, set
    /// Build to be tested.
    abstract build: ShallowReference with get, set
    /// The Build Definition that generates a build associated with this test plan.
    abstract buildDefinition: ShallowReference with get, set
    abstract clientUrl: string with get, set
    /// Description of the test plan.
    abstract description: string with get, set
    /// End date for the test plan.
    abstract endDate: DateTime with get, set
    /// ID of the test plan.
    abstract id: float with get, set
    /// Iteration path of the test plan.
    abstract iteration: string with get, set
    abstract manualTestEnvironment: TestEnvironment with get, set
    abstract manualTestSettings: TestSettings with get, set
    /// Name of the test plan.
    abstract name: string with get, set
    /// Owner of the test plan.
    abstract owner: WebApi.IdentityRef with get, set
    abstract previousBuild: ShallowReference with get, set
    /// Project which contains the test plan.
    abstract project: ShallowReference with get, set
    /// Release Environment to be used to deploy the build and run automated tests from this test plan.
    abstract releaseEnvironmentDefinition: ReleaseEnvironmentDefinitionReference with get, set
    /// Revision of the test plan.
    abstract revision: float with get, set
    /// Root test suite of the test plan.
    abstract rootSuite: ShallowReference with get, set
    /// Start date for the test plan.
    abstract startDate: DateTime with get, set
    /// State of the test plan.
    abstract state: string with get, set
    /// Value to configure how same tests across test suites under a test plan need to behave
    abstract testOutcomeSettings: TestOutcomeSettings with get, set
    abstract updatedBy: WebApi.IdentityRef with get, set
    abstract updatedDate: DateTime with get, set
    /// URL of the test plan resource.
    abstract url: string with get, set

type [<AllowNullLiteral>] TestPlanCloneRequest =
    abstract destinationTestPlan: TestPlan with get, set
    abstract options: CloneOptions with get, set
    abstract suiteIds: ResizeArray<float> with get, set

type [<AllowNullLiteral>] TestPlanHubData =
    abstract selectedSuiteId: float with get, set
    abstract testPlan: TestPlan with get, set
    abstract testPoints: ResizeArray<TestPoint> with get, set
    abstract testSuites: ResizeArray<TestSuite> with get, set
    abstract totalTestPoints: float with get, set

type [<AllowNullLiteral>] TestPlansWithSelection =
    abstract lastSelectedPlan: float with get, set
    abstract lastSelectedSuite: float with get, set
    abstract plans: ResizeArray<TestPlan> with get, set

/// Test point.
type [<AllowNullLiteral>] TestPoint =
    /// AssignedTo. Type IdentityRef.
    abstract assignedTo: WebApi.IdentityRef with get, set
    /// Automated.
    abstract automated: bool with get, set
    /// Comment associated with test point.
    abstract comment: string with get, set
    /// Configuration. Type ShallowReference.
    abstract configuration: ShallowReference with get, set
    /// Failure type of test point.
    abstract failureType: string with get, set
    /// ID of the test point.
    abstract id: float with get, set
    /// Last date when test point was reset to Active.
    abstract lastResetToActive: DateTime with get, set
    /// Last resolution state id of test point.
    abstract lastResolutionStateId: float with get, set
    /// Last result of test point. Type ShallowReference.
    abstract lastResult: ShallowReference with get, set
    /// Last result details of test point. Type LastResultDetails.
    abstract lastResultDetails: LastResultDetails with get, set
    /// Last result state of test point.
    abstract lastResultState: string with get, set
    /// LastRun build number of test point.
    abstract lastRunBuildNumber: string with get, set
    /// Last testRun of test point. Type ShallowReference.
    abstract lastTestRun: ShallowReference with get, set
    /// Test point last updated by. Type IdentityRef.
    abstract lastUpdatedBy: WebApi.IdentityRef with get, set
    /// Last updated date of test point.
    abstract lastUpdatedDate: DateTime with get, set
    /// Outcome of test point.
    abstract outcome: string with get, set
    /// Revision number.
    abstract revision: float with get, set
    /// State of test point.
    abstract state: string with get, set
    /// Suite of test point. Type ShallowReference.
    abstract suite: ShallowReference with get, set
    /// TestCase associated to test point. Type WorkItemReference.
    abstract testCase: WorkItemReference with get, set
    /// TestPlan of test point. Type ShallowReference.
    abstract testPlan: ShallowReference with get, set
    /// Test point Url.
    abstract url: string with get, set
    /// Work item properties of test point.
    abstract workItemProperties: ResizeArray<obj option> with get, set

type [<AllowNullLiteral>] TestPointReference =
    abstract id: float with get, set
    abstract state: TestPointState with get, set

type [<AllowNullLiteral>] TestPointsEvent =
    abstract projectName: string with get, set
    abstract testPoints: ResizeArray<TestPointReference> with get, set

/// Test point query class.
type [<AllowNullLiteral>] TestPointsQuery =
    /// Order by results.
    abstract orderBy: string with get, set
    /// List of test points
    abstract points: ResizeArray<TestPoint> with get, set
    /// Filter
    abstract pointsFilter: PointsFilter with get, set
    /// List of workitem fields to get.
    abstract witFields: ResizeArray<string> with get, set

type [<RequireQualifiedAccess>] TestPointState =
    | None = 0
    | Ready = 1
    | Completed = 2
    | NotReady = 3
    | InProgress = 4
    | MaxValue = 4

type [<AllowNullLiteral>] TestPointsUpdatedEvent =
    inherit TestPointsEvent

/// Test Resolution State Details.
type [<AllowNullLiteral>] TestResolutionState =
    /// Test Resolution state Id.
    abstract id: float with get, set
    /// Test Resolution State Name.
    abstract name: string with get, set
    abstract project: ShallowReference with get, set

type [<AllowNullLiteral>] TestResult2 =
    abstract afnStripId: float with get, set
    abstract computerName: string with get, set
    abstract creationDate: DateTime with get, set
    abstract dateCompleted: DateTime with get, set
    abstract dateStarted: DateTime with get, set
    abstract effectivePointState: float with get, set
    abstract failureType: float with get, set
    abstract lastUpdated: DateTime with get, set
    abstract lastUpdatedBy: string with get, set
    abstract outcome: float with get, set
    abstract owner: string with get, set
    abstract projectId: string with get, set
    abstract resetCount: float with get, set
    abstract resolutionStateId: float with get, set
    abstract revision: float with get, set
    abstract runBy: string with get, set
    abstract state: float with get, set
    abstract testCaseRefId: float with get, set
    abstract testResultId: float with get, set
    abstract testRunId: float with get, set

type [<AllowNullLiteral>] TestResultAcrossProjectResponse =
    abstract projectName: string with get, set
    abstract testResult: LegacyTestCaseResult with get, set

type [<AllowNullLiteral>] TestResultAttachment =
    abstract actionPath: string with get, set
    abstract attachmentType: AttachmentType with get, set
    abstract comment: string with get, set
    abstract creationDate: DateTime with get, set
    abstract downloadQueryString: string with get, set
    abstract fileName: string with get, set
    abstract id: float with get, set
    abstract isComplete: bool with get, set
    abstract iterationId: float with get, set
    abstract length: float with get, set
    abstract sessionId: float with get, set
    abstract testResultId: float with get, set
    abstract testRunId: float with get, set
    abstract tmiRunId: string with get, set

type [<AllowNullLiteral>] TestResultAttachmentIdentity =
    abstract attachmentId: float with get, set
    abstract sessionId: float with get, set
    abstract testResultId: float with get, set
    abstract testRunId: float with get, set

type [<AllowNullLiteral>] TestResultCreateModel =
    abstract area: ShallowReference with get, set
    abstract associatedWorkItems: ResizeArray<float> with get, set
    abstract automatedTestId: string with get, set
    abstract automatedTestName: string with get, set
    abstract automatedTestStorage: string with get, set
    abstract automatedTestType: string with get, set
    abstract automatedTestTypeId: string with get, set
    abstract comment: string with get, set
    abstract completedDate: string with get, set
    abstract computerName: string with get, set
    abstract configuration: ShallowReference with get, set
    abstract customFields: ResizeArray<CustomTestField> with get, set
    abstract durationInMs: string with get, set
    abstract errorMessage: string with get, set
    abstract failureType: string with get, set
    abstract outcome: string with get, set
    abstract owner: WebApi.IdentityRef with get, set
    abstract resolutionState: string with get, set
    abstract runBy: WebApi.IdentityRef with get, set
    abstract stackTrace: string with get, set
    abstract startedDate: string with get, set
    abstract state: string with get, set
    abstract testCase: ShallowReference with get, set
    abstract testCasePriority: string with get, set
    abstract testCaseTitle: string with get, set
    abstract testPoint: ShallowReference with get, set

type [<AllowNullLiteral>] TestResultDocument =
    abstract operationReference: TestOperationReference with get, set
    abstract payload: TestResultPayload with get, set

type [<AllowNullLiteral>] TestResultFailuresAnalysis =
    abstract existingFailures: TestFailureDetails with get, set
    abstract fixedTests: TestFailureDetails with get, set
    abstract newFailures: TestFailureDetails with get, set

type [<RequireQualifiedAccess>] TestResultGroupBy =
    | Branch = 1
    | Environment = 2

type [<AllowNullLiteral>] TestResultHistory =
    abstract groupByField: string with get, set
    abstract resultsForGroup: ResizeArray<TestResultHistoryDetailsForGroup> with get, set

type [<AllowNullLiteral>] TestResultHistoryDetailsForGroup =
    abstract groupByValue: obj option with get, set
    abstract latestResult: TestCaseResult with get, set

/// List of test results filtered on the basis of GroupByValue
type [<AllowNullLiteral>] TestResultHistoryForGroup =
    /// Display name of the group.
    abstract displayName: string with get, set
    /// Name or Id of the group identifier by which results are grouped together.
    abstract groupByValue: string with get, set
    /// List of results for GroupByValue
    abstract results: ResizeArray<TestCaseResult> with get, set

/// Represents a Meta Data of a test result.
type [<AllowNullLiteral>] TestResultMetaData =
    /// AutomatedTestName of test result.
    abstract automatedTestName: string with get, set
    /// AutomatedTestStorage of test result.
    abstract automatedTestStorage: string with get, set
    /// List of Flaky Identifier for TestCaseReferenceId
    abstract flakyIdentifiers: ResizeArray<TestFlakyIdentifier> with get, set
    /// Owner of test result.
    abstract owner: string with get, set
    /// Priority of test result.
    abstract priority: float with get, set
    /// ID of TestCaseReference.
    abstract testCaseReferenceId: float with get, set
    /// TestCaseTitle of test result.
    abstract testCaseTitle: string with get, set

/// Represents a TestResultMetaData Input
type [<AllowNullLiteral>] TestResultMetaDataUpdateInput =
    /// List of Flaky Identifiers
    abstract flakyIdentifiers: ResizeArray<TestFlakyIdentifier> with get, set

type [<AllowNullLiteral>] TestResultMetaDataUpdateResponse =
    abstract status: string with get, set

type [<AllowNullLiteral>] TestResultModelBase =
    /// Comment in result.
    abstract comment: string with get, set
    /// Time when execution completed.
    abstract completedDate: DateTime with get, set
    /// Duration of execution.
    abstract durationInMs: float with get, set
    /// Error message in result.
    abstract errorMessage: string with get, set
    /// Test outcome of result.
    abstract outcome: string with get, set
    /// Time when execution started.
    abstract startedDate: DateTime with get, set

type [<AllowNullLiteral>] TestResultParameter =
    abstract actionPath: string with get, set
    abstract actual: ResizeArray<float> with get, set
    abstract expected: ResizeArray<float> with get, set
    abstract iterationId: float with get, set
    abstract parameterName: string with get, set
    abstract testResultId: float with get, set
    abstract testRunId: float with get, set

/// Test parameter information in a test iteration.
type [<AllowNullLiteral>] TestResultParameterModel =
    /// Test step path where parameter is referenced.
    abstract actionPath: string with get, set
    /// Iteration ID.
    abstract iterationId: float with get, set
    /// Name of parameter.
    abstract parameterName: string with get, set
    /// This is step Id of test case. For shared step, it is step Id of shared step in test case workitem; step Id in shared step. Example: TestCase workitem has two steps: 1) Normal step with Id = 1 2) Shared Step with Id = 2. Inside shared step: a) Normal Step with Id = 1 Value for StepIdentifier for First step: "1" Second step: "2;1"
    abstract stepIdentifier: string with get, set
    /// Url of test parameter.
    abstract url: string with get, set
    /// Value of parameter.
    abstract value: string with get, set

type [<AllowNullLiteral>] TestResultPayload =
    abstract comment: string with get, set
    abstract name: string with get, set
    abstract stream: string with get, set

type [<AllowNullLiteral>] TestResultReset2 =
    abstract auditIdentity: string with get, set
    abstract dateModified: DateTime with get, set
    abstract projectId: string with get, set
    abstract revision: float with get, set
    abstract testResultId: float with get, set
    abstract testResultRV: ResizeArray<float> with get, set
    abstract testRunId: float with get, set

type [<AllowNullLiteral>] TestResultsContext =
    abstract build: BuildReference with get, set
    abstract contextType: TestResultsContextType with get, set
    abstract pipelineReference: PipelineReference with get, set
    abstract release: ReleaseReference with get, set

type [<RequireQualifiedAccess>] TestResultsContextType =
    | Build = 1
    | Release = 2
    | Pipeline = 3

type [<AllowNullLiteral>] TestResultsDetails =
    abstract groupByField: string with get, set
    abstract resultsForGroup: ResizeArray<TestResultsDetailsForGroup> with get, set

type [<AllowNullLiteral>] TestResultsDetailsForGroup =
    abstract groupByValue: obj option with get, set
    abstract results: ResizeArray<TestCaseResult> with get, set
    abstract resultsCountByOutcome: AggregatedDataForResultTrendResultsByOutcome with get, set
    abstract tags: ResizeArray<string> with get, set

type [<AllowNullLiteral>] TestResultsEx2 =
    abstract bitValue: bool with get, set
    abstract creationDate: DateTime with get, set
    abstract dateTimeValue: DateTime with get, set
    abstract fieldId: float with get, set
    abstract fieldName: string with get, set
    abstract floatValue: float with get, set
    abstract guidValue: string with get, set
    abstract intValue: float with get, set
    abstract projectId: string with get, set
    abstract stringValue: string with get, set
    abstract testResultId: float with get, set
    abstract testRunId: float with get, set

type [<AllowNullLiteral>] TestResultsGroupsForBuild =
    /// BuildId for which groupby result is fetched.
    abstract buildId: float with get, set
    /// The group by results
    abstract fields: ResizeArray<FieldDetailsForTestResults> with get, set

type [<AllowNullLiteral>] TestResultsGroupsForRelease =
    /// The group by results
    abstract fields: ResizeArray<FieldDetailsForTestResults> with get, set
    /// Release Environment Id for which groupby result is fetched.
    abstract releaseEnvId: float with get, set
    /// ReleaseId for which groupby result is fetched.
    abstract releaseId: float with get, set

type [<AllowNullLiteral>] TestResultsQuery =
    abstract fields: ResizeArray<string> with get, set
    abstract results: ResizeArray<TestCaseResult> with get, set
    abstract resultsFilter: ResultsFilter with get, set

type [<AllowNullLiteral>] TestResultsSettings =
    /// IsRequired and EmitDefaultValue are passed as false as if users doesn't pass anything, should not come for serialisation and deserialisation.
    abstract flakySettings: FlakySettings with get, set

type [<RequireQualifiedAccess>] TestResultsSettingsType =
    | All = 1
    | Flaky = 2

type [<AllowNullLiteral>] TestResultSummary =
    abstract aggregatedResultsAnalysis: AggregatedResultsAnalysis with get, set
    abstract noConfigRunsCount: float with get, set
    abstract teamProject: Core.TeamProjectReference with get, set
    abstract testFailures: TestFailuresAnalysis with get, set
    abstract testResultsContext: TestResultsContext with get, set
    abstract totalRunsCount: float with get, set

type [<AllowNullLiteral>] TestResultsUpdateSettings =
    /// FlakySettings defines Flaky Settings Data.
    abstract flakySettings: FlakySettings with get, set

type [<AllowNullLiteral>] TestResultsWithWatermark =
    abstract changedDate: DateTime with get, set
    abstract pointsResults: ResizeArray<PointsResults2> with get, set
    abstract resultId: float with get, set
    abstract runId: float with get, set

type [<AllowNullLiteral>] TestResultTrendFilter =
    abstract branchNames: ResizeArray<string> with get, set
    abstract buildCount: float with get, set
    abstract definitionIds: ResizeArray<float> with get, set
    abstract envDefinitionIds: ResizeArray<float> with get, set
    abstract maxCompleteDate: DateTime with get, set
    abstract publishContext: string with get, set
    abstract testRunTitles: ResizeArray<string> with get, set
    abstract trendDays: float with get, set

/// Test run details.
type [<AllowNullLiteral>] TestRun =
    /// Build associated with this test run.
    abstract build: ShallowReference with get, set
    /// Build configuration details associated with this test run.
    abstract buildConfiguration: BuildConfiguration with get, set
    /// Comments entered by those analyzing the run.
    abstract comment: string with get, set
    /// Completed date time of the run.
    abstract completedDate: DateTime with get, set
    /// Test Run Controller.
    abstract controller: string with get, set
    /// Test Run CreatedDate.
    abstract createdDate: DateTime with get, set
    /// List of Custom Fields for TestRun.
    abstract customFields: ResizeArray<CustomTestField> with get, set
    /// Drop Location for the test Run.
    abstract dropLocation: string with get, set
    abstract dtlAutEnvironment: ShallowReference with get, set
    abstract dtlEnvironment: ShallowReference with get, set
    abstract dtlEnvironmentCreationDetails: DtlEnvironmentDetails with get, set
    /// Due date and time for test run.
    abstract dueDate: DateTime with get, set
    /// Error message associated with the run.
    abstract errorMessage: string with get, set
    abstract filter: RunFilter with get, set
    /// ID of the test run.
    abstract id: float with get, set
    /// Number of Incomplete Tests.
    abstract incompleteTests: float with get, set
    /// true if test run is automated, false otherwise.
    abstract isAutomated: bool with get, set
    /// The iteration to which the run belongs.
    abstract iteration: string with get, set
    /// Team foundation ID of the last updated the test run.
    abstract lastUpdatedBy: WebApi.IdentityRef with get, set
    /// Last updated date and time
    abstract lastUpdatedDate: DateTime with get, set
    /// Name of the test run.
    abstract name: string with get, set
    /// Number of Not Applicable Tests.
    abstract notApplicableTests: float with get, set
    /// Team Foundation ID of the owner of the runs.
    abstract owner: WebApi.IdentityRef with get, set
    /// Number of passed tests in the run
    abstract passedTests: float with get, set
    /// Phase/State for the testRun.
    abstract phase: string with get, set
    /// Reference of the pipeline to which this test run belongs.
    abstract pipelineReference: PipelineReference with get, set
    /// Test plan associated with this test run.
    abstract plan: ShallowReference with get, set
    /// Post Process State.
    abstract postProcessState: string with get, set
    /// Project associated with this run.
    abstract project: ShallowReference with get, set
    /// Release Reference for the Test Run.
    abstract release: ReleaseReference with get, set
    /// Release Environment Uri for TestRun.
    abstract releaseEnvironmentUri: string with get, set
    /// Release Uri for TestRun.
    abstract releaseUri: string with get, set
    abstract revision: float with get, set
    /// RunSummary by outcome.
    abstract runStatistics: ResizeArray<RunStatistic> with get, set
    /// Start date time of the run.
    abstract startedDate: DateTime with get, set
    /// The state of the run. Type TestRunState Valid states - Unspecified ,NotStarted, InProgress, Completed, Waiting, Aborted, NeedsInvestigation
    abstract state: string with get, set
    /// TestRun Substate.
    abstract substate: TestRunSubstate with get, set
    /// Tags attached with this test run.
    abstract tags: ResizeArray<TestTag> with get, set
    /// Test environment associated with the run.
    abstract testEnvironment: TestEnvironment with get, set
    abstract testMessageLogId: float with get, set
    abstract testSettings: ShallowReference with get, set
    /// Total tests in the run
    abstract totalTests: float with get, set
    /// Number of failed tests in the run.
    abstract unanalyzedTests: float with get, set
    /// Url of the test run
    abstract url: string with get, set
    /// Web Access Url for TestRun.
    abstract webAccessUrl: string with get, set

type [<AllowNullLiteral>] TestRun2 =
    abstract buildConfigurationId: float with get, set
    abstract buildNumber: string with get, set
    abstract comment: string with get, set
    abstract completeDate: DateTime with get, set
    abstract controller: string with get, set
    abstract coverageId: float with get, set
    abstract creationDate: DateTime with get, set
    abstract deletedOn: DateTime with get, set
    abstract dropLocation: string with get, set
    abstract dueDate: DateTime with get, set
    abstract errorMessage: string with get, set
    abstract incompleteTests: float with get, set
    abstract isAutomated: bool with get, set
    abstract isBvt: bool with get, set
    abstract isMigrated: bool with get, set
    abstract iterationId: float with get, set
    abstract lastUpdated: DateTime with get, set
    abstract lastUpdatedBy: string with get, set
    abstract legacySharePath: string with get, set
    abstract maxReservedResultId: float with get, set
    abstract notApplicableTests: float with get, set
    abstract owner: string with get, set
    abstract passedTests: float with get, set
    abstract postProcessState: float with get, set
    abstract projectId: string with get, set
    abstract publicTestSettingsId: float with get, set
    abstract releaseEnvironmentUri: string with get, set
    abstract releaseUri: string with get, set
    abstract revision: float with get, set
    abstract startDate: DateTime with get, set
    abstract state: float with get, set
    abstract testEnvironmentId: string with get, set
    abstract testMessageLogId: float with get, set
    abstract testPlanId: float with get, set
    abstract testRunContextId: float with get, set
    abstract testRunId: float with get, set
    abstract testSettingsId: float with get, set
    abstract title: string with get, set
    abstract totalTests: float with get, set
    abstract ``type``: float with get, set
    abstract unanalyzedTests: float with get, set
    abstract version: float with get, set

type [<AllowNullLiteral>] TestRunCanceledEvent =
    inherit TestRunEvent

type [<AllowNullLiteral>] TestRunContext2 =
    abstract buildRefId: float with get, set
    abstract projectId: string with get, set
    abstract releaseRefId: float with get, set
    abstract sourceWorkflow: string with get, set
    abstract testRunContextId: float with get, set

/// Test Run Code Coverage Details
type [<AllowNullLiteral>] TestRunCoverage =
    /// Last Error
    abstract lastError: string with get, set
    /// List of Modules Coverage
    abstract modules: ResizeArray<ModuleCoverage> with get, set
    /// State
    abstract state: string with get, set
    /// Reference of test Run.
    abstract testRun: ShallowReference with get, set

type [<AllowNullLiteral>] TestRunCreatedEvent =
    inherit TestRunEvent

type [<AllowNullLiteral>] TestRunEvent =
    abstract testRun: TestRun with get, set

type [<AllowNullLiteral>] TestRunEx2 =
    abstract bitValue: bool with get, set
    abstract createdDate: DateTime with get, set
    abstract dateTimeValue: DateTime with get, set
    abstract fieldId: float with get, set
    abstract fieldName: string with get, set
    abstract floatValue: float with get, set
    abstract guidValue: string with get, set
    abstract intValue: float with get, set
    abstract projectId: string with get, set
    abstract stringValue: string with get, set
    abstract testRunId: float with get, set

type [<AllowNullLiteral>] TestRunExtended2 =
    abstract autEnvironmentUrl: string with get, set
    abstract csmContent: string with get, set
    abstract csmParameters: string with get, set
    abstract projectId: string with get, set
    abstract sourceFilter: string with get, set
    abstract subscriptionName: string with get, set
    abstract substate: float with get, set
    abstract testCaseFilter: string with get, set
    abstract testEnvironmentUrl: string with get, set
    abstract testRunId: float with get, set

type [<RequireQualifiedAccess>] TestRunOutcome =
    | Passed = 0
    | Failed = 1
    | NotImpacted = 2
    | Others = 3

type [<RequireQualifiedAccess>] TestRunPublishContext =
    | Build = 1
    | Release = 2
    | All = 3

type [<AllowNullLiteral>] TestRunStartedEvent =
    inherit TestRunEvent

type [<RequireQualifiedAccess>] TestRunState =
    | Unspecified = 0
    | NotStarted = 1
    | InProgress = 2
    | Completed = 3
    | Aborted = 4
    | Waiting = 5
    | NeedsInvestigation = 6

/// Test run statistics.
type [<AllowNullLiteral>] TestRunStatistic =
    abstract run: ShallowReference with get, set
    abstract runStatistics: ResizeArray<RunStatistic> with get, set

type [<RequireQualifiedAccess>] TestRunSubstate =
    | None = 0
    | CreatingEnvironment = 1
    | RunningTests = 2
    | CanceledByUser = 3
    | AbortedBySystem = 4
    | TimedOut = 5
    | PendingAnalysis = 6
    | Analyzed = 7
    | CancellationInProgress = 8

type [<AllowNullLiteral>] TestRunSummary2 =
    abstract isRerun: bool with get, set
    abstract projectId: string with get, set
    abstract resultCount: float with get, set
    abstract resultDuration: float with get, set
    abstract runDuration: float with get, set
    abstract testOutcome: float with get, set
    abstract testRunCompletedDate: DateTime with get, set
    abstract testRunContextId: float with get, set
    abstract testRunId: float with get, set
    abstract testRunStatsId: float with get, set

type [<AllowNullLiteral>] TestRunWithDtlEnvEvent =
    inherit TestRunEvent
    abstract configurationIds: ResizeArray<float> with get, set
    abstract mappedTestRunEventType: string with get, set
    abstract runTimeout: obj option with get, set
    abstract testConfigurationsMapping: string with get, set

/// Test Session
type [<AllowNullLiteral>] TestSession =
    /// Area path of the test session
    abstract area: ShallowReference with get, set
    /// Comments in the test session
    abstract comment: string with get, set
    /// Duration of the session
    abstract endDate: DateTime with get, set
    /// Id of the test session
    abstract id: float with get, set
    /// Last Updated By  Reference
    abstract lastUpdatedBy: WebApi.IdentityRef with get, set
    /// Last updated date
    abstract lastUpdatedDate: DateTime with get, set
    /// Owner of the test session
    abstract owner: WebApi.IdentityRef with get, set
    /// Project to which the test session belongs
    abstract project: ShallowReference with get, set
    /// Generic store for test session data
    abstract propertyBag: PropertyBag with get, set
    /// Revision of the test session
    abstract revision: float with get, set
    /// Source of the test session
    abstract source: TestSessionSource with get, set
    /// Start date
    abstract startDate: DateTime with get, set
    /// State of the test session
    abstract state: TestSessionState with get, set
    /// Title of the test session
    abstract title: string with get, set
    /// Url of Test Session Resource
    abstract url: string with get, set

type [<AllowNullLiteral>] TestSessionExploredWorkItemReference =
    inherit TestSessionWorkItemReference
    /// Workitem references of workitems filed as a part of the current workitem exploration.
    abstract associatedWorkItems: ResizeArray<TestSessionWorkItemReference> with get, set
    /// Time when exploration of workitem ended.
    abstract endTime: DateTime with get, set
    /// Time when explore of workitem was started.
    abstract startTime: DateTime with get, set

type [<RequireQualifiedAccess>] TestSessionSource =
    | Unknown = 0
    | XTDesktop = 1
    | FeedbackDesktop = 2
    | XTWeb = 3
    | FeedbackWeb = 4
    | XTDesktop2 = 5
    | SessionInsightsForAll = 6

type [<RequireQualifiedAccess>] TestSessionState =
    | Unspecified = 0
    | NotStarted = 1
    | InProgress = 2
    | Paused = 3
    | Completed = 4
    | Declined = 5

type [<AllowNullLiteral>] TestSessionWorkItemReference =
    /// Id of the workitem
    abstract id: float with get, set
    /// Type of the workitem
    abstract ``type``: string with get, set

/// Represents the test settings of the run. Used to create test settings and fetch test settings
type [<AllowNullLiteral>] TestSettings =
    /// Area path required to create test settings
    abstract areaPath: string with get, set
    /// Description of the test settings. Used in create test settings.
    abstract description: string with get, set
    /// Indicates if the tests settings is public or private.Used in create test settings.
    abstract isPublic: bool with get, set
    /// Xml string of machine roles. Used in create test settings.
    abstract machineRoles: string with get, set
    /// Test settings content.
    abstract testSettingsContent: string with get, set
    /// Test settings id.
    abstract testSettingsId: float with get, set
    /// Test settings name.
    abstract testSettingsName: string with get, set

/// Represents the test settings of the run. Used to create test settings and fetch test settings
type [<AllowNullLiteral>] TestSettings2 =
    /// Area path required to create test settings
    abstract areaPath: string with get, set
    abstract createdBy: WebApi.IdentityRef with get, set
    abstract createdDate: DateTime with get, set
    /// Description of the test settings. Used in create test settings.
    abstract description: string with get, set
    /// Indicates if the tests settings is public or private.Used in create test settings.
    abstract isPublic: bool with get, set
    abstract lastUpdatedBy: WebApi.IdentityRef with get, set
    abstract lastUpdatedDate: DateTime with get, set
    /// Xml string of machine roles. Used in create test settings.
    abstract machineRoles: string with get, set
    /// Test settings content.
    abstract testSettingsContent: string with get, set
    /// Test settings id.
    abstract testSettingsId: float with get, set
    /// Test settings name.
    abstract testSettingsName: string with get, set

type [<AllowNullLiteral>] TestSettingsMachineRole =
    abstract isExecution: bool with get, set
    abstract name: string with get, set

/// Represents a sub result of a test result.
type [<AllowNullLiteral>] TestSubResult =
    /// Comment in sub result.
    abstract comment: string with get, set
    /// Time when test execution completed.
    abstract completedDate: DateTime with get, set
    /// Machine where test executed.
    abstract computerName: string with get, set
    /// Reference to test configuration.
    abstract configuration: ShallowReference with get, set
    /// Additional properties of sub result.
    abstract customFields: ResizeArray<CustomTestField> with get, set
    /// Name of sub result.
    abstract displayName: string with get, set
    /// Duration of test execution.
    abstract durationInMs: float with get, set
    /// Error message in sub result.
    abstract errorMessage: string with get, set
    /// ID of sub result.
    abstract id: float with get, set
    /// Time when result last updated.
    abstract lastUpdatedDate: DateTime with get, set
    /// Outcome of sub result.
    abstract outcome: string with get, set
    /// Immediate parent ID of sub result.
    abstract parentId: float with get, set
    /// Hierarchy type of the result, default value of None means its leaf node.
    abstract resultGroupType: ResultGroupType with get, set
    /// Index number of sub result.
    abstract sequenceId: float with get, set
    /// Stacktrace.
    abstract stackTrace: string with get, set
    /// Time when test execution started.
    abstract startedDate: DateTime with get, set
    /// List of sub results inside a sub result, if ResultGroupType is not None, it holds corresponding type sub results.
    abstract subResults: ResizeArray<TestSubResult> with get, set
    /// Reference to test result.
    abstract testResult: TestCaseResultIdentifier with get, set
    /// Url of sub result.
    abstract url: string with get, set

/// Test suite
type [<AllowNullLiteral>] TestSuite =
    /// Area uri of the test suite.
    abstract areaUri: string with get, set
    /// Child test suites of current test suite.
    abstract children: ResizeArray<TestSuite> with get, set
    /// Test suite default configuration.
    abstract defaultConfigurations: ResizeArray<ShallowReference> with get, set
    /// Test suite default testers.
    abstract defaultTesters: ResizeArray<ShallowReference> with get, set
    /// Id of test suite.
    abstract id: float with get, set
    /// Default configuration was inherited or not.
    abstract inheritDefaultConfigurations: bool with get, set
    /// Last error for test suite.
    abstract lastError: string with get, set
    /// Last populated date.
    abstract lastPopulatedDate: DateTime with get, set
    /// IdentityRef of user who has updated test suite recently.
    abstract lastUpdatedBy: WebApi.IdentityRef with get, set
    /// Last update date.
    abstract lastUpdatedDate: DateTime with get, set
    /// Name of test suite.
    abstract name: string with get, set
    /// Test suite parent shallow reference.
    abstract parent: ShallowReference with get, set
    /// Test plan to which the test suite belongs.
    abstract plan: ShallowReference with get, set
    /// Test suite project shallow reference.
    abstract project: ShallowReference with get, set
    /// Test suite query string, for dynamic suites.
    abstract queryString: string with get, set
    /// Test suite requirement id.
    abstract requirementId: float with get, set
    /// Test suite revision.
    abstract revision: float with get, set
    /// State of test suite.
    abstract state: string with get, set
    /// List of shallow reference of suites.
    abstract suites: ResizeArray<ShallowReference> with get, set
    /// Test suite type.
    abstract suiteType: string with get, set
    /// Test cases count.
    abstract testCaseCount: float with get, set
    /// Test case url.
    abstract testCasesUrl: string with get, set
    /// Used in tree view. If test suite is root suite then, it is name of plan otherwise title of the suite.
    abstract text: string with get, set
    /// Url of test suite.
    abstract url: string with get, set

/// Test suite clone request
type [<AllowNullLiteral>] TestSuiteCloneRequest =
    /// Clone options for cloning the test suite.
    abstract cloneOptions: CloneOptions with get, set
    /// Suite id under which, we have to clone the suite.
    abstract destinationSuiteId: float with get, set
    /// Destination suite project name.
    abstract destinationSuiteProjectName: string with get, set

type [<AllowNullLiteral>] TestSummaryForWorkItem =
    abstract summary: AggregatedDataForResultTrend with get, set
    abstract workItem: WorkItemReference with get, set

/// Tag attached to a run or result.
type [<AllowNullLiteral>] TestTag =
    /// Name of the tag, alphanumeric value less than 30 chars
    abstract name: string with get, set

/// Test tag summary for build or release grouped by test run.
type [<AllowNullLiteral>] TestTagSummary =
    /// Dictionary which contains tags associated with a test run.
    abstract tagsGroupByTestArtifact: TestTagSummaryTagsGroupByTestArtifact with get, set

/// Tags to update to a run or result.
type [<AllowNullLiteral>] TestTagsUpdateModel =
    abstract tags: ResizeArray<TestTagsUpdateModelTags> with get, set

type [<AllowNullLiteral>] TestToWorkItemLinks =
    abstract test: TestMethod with get, set
    abstract workItems: ResizeArray<WorkItemReference> with get, set

type [<AllowNullLiteral>] TestVariable =
    /// Description of the test variable
    abstract description: string with get, set
    /// Id of the test variable
    abstract id: float with get, set
    /// Name of the test variable
    abstract name: string with get, set
    /// Project to which the test variable belongs
    abstract project: ShallowReference with get, set
    /// Revision
    abstract revision: float with get, set
    /// Url of the test variable
    abstract url: string with get, set
    /// List of allowed values
    abstract values: ResizeArray<string> with get, set

type [<AllowNullLiteral>] UpdatedProperties =
    abstract id: float with get, set
    abstract lastUpdated: DateTime with get, set
    abstract lastUpdatedBy: string with get, set
    abstract lastUpdatedByName: string with get, set
    abstract revision: float with get, set

type [<AllowNullLiteral>] UpdateTestRunRequest =
    abstract attachmentsToAdd: ResizeArray<TestResultAttachment> with get, set
    abstract attachmentsToDelete: ResizeArray<TestResultAttachmentIdentity> with get, set
    abstract projectName: string with get, set
    abstract shouldHyderate: bool with get, set
    abstract testRun: LegacyTestRun with get, set

type [<AllowNullLiteral>] UpdateTestRunResponse =
    abstract attachmentIds: ResizeArray<float> with get, set
    abstract updatedProperties: UpdatedProperties with get, set

type [<AllowNullLiteral>] UploadAttachmentsRequest =
    abstract attachments: ResizeArray<HttpPostedTcmAttachment> with get, set
    abstract requestParams: CloneOptionsOverrideParameters with get, set

/// WorkItem reference Details.
type [<AllowNullLiteral>] WorkItemReference =
    /// WorkItem Id.
    abstract id: string with get, set
    /// WorkItem Name.
    abstract name: string with get, set
    /// WorkItem Type.
    abstract ``type``: string with get, set
    /// WorkItem Url. Valid Values : (Bug, Task, User Story, Test Case)
    abstract url: string with get, set
    /// WorkItem WebUrl.
    abstract webUrl: string with get, set

type [<AllowNullLiteral>] WorkItemToTestLinks =
    abstract executedIn: Service with get, set
    abstract tests: ResizeArray<TestMethod> with get, set
    abstract workItem: WorkItemReference with get, set

type [<AllowNullLiteral>] AggregatedDataForResultTrendResultsByOutcome =
    [<Emit "$0[$1]{{=$2}}">] abstract Item: key: float -> AggregatedResultsByOutcome with get, set

type [<AllowNullLiteral>] AggregatedDataForResultTrendRunSummaryByState =
    [<Emit "$0[$1]{{=$2}}">] abstract Item: key: float -> AggregatedRunsByState with get, set

type [<AllowNullLiteral>] AggregatedResultsAnalysisRunSummaryByOutcome =
    [<Emit "$0[$1]{{=$2}}">] abstract Item: key: float -> AggregatedRunsByOutcome with get, set

type [<AllowNullLiteral>] CloneOptionsOverrideParameters =
    [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> string with get, set

type [<AllowNullLiteral>] PointWorkItemPropertyWorkItem =
    abstract key: string with get, set
    abstract value: obj option with get, set

type [<AllowNullLiteral>] ResultsSummaryByOutcomeAggregatedResultDetailsByOutcome =
    [<Emit "$0[$1]{{=$2}}">] abstract Item: key: float -> AggregatedResultDetailsByOutcome with get, set

type [<AllowNullLiteral>] ResultSummaryResultSummaryByRunState =
    [<Emit "$0[$1]{{=$2}}">] abstract Item: key: float -> ResultsSummaryByOutcome with get, set

type [<AllowNullLiteral>] RunSummaryRunSummaryByOutcome =
    [<Emit "$0[$1]{{=$2}}">] abstract Item: key: float -> float with get, set

type [<AllowNullLiteral>] TestFieldDataDimensions =
    [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

type [<AllowNullLiteral>] TestTagSummaryTagsGroupByTestArtifact =
    [<Emit "$0[$1]{{=$2}}">] abstract Item: key: float -> ResizeArray<TestTag> with get, set

type [<AllowNullLiteral>] TestTagsUpdateModelTags =
    abstract key: OperationType with get, set
    abstract value: ResizeArray<TestTag> with get, set
