// ts2fable 0.7.1
module rec TestPlan
open System
open Fable.Core
open Fable.Core.JS

/// The build definition reference resource
type [<AllowNullLiteral>] BuildDefinitionReference =
    /// ID of the build definition
    abstract id: float with get, set
    /// Name of the build definition
    abstract name: string with get, set

/// Common Response for clone operation
type [<AllowNullLiteral>] CloneOperationCommonResponse =
    /// Various statistics related to the clone operation
    abstract cloneStatistics: Test.CloneStatistics with get, set
    /// Completion data of the operation
    abstract completionDate: DateTime with get, set
    /// Creation data of the operation
    abstract creationDate: DateTime with get, set
    /// Reference links
    abstract links: obj option with get, set
    /// Message related to the job
    abstract message: string with get, set
    /// Clone operation Id
    abstract opId: float with get, set
    /// Clone operation state
    abstract state: Test.CloneOperationState with get, set

/// Response for Test Plan clone operation
type [<AllowNullLiteral>] CloneTestPlanOperationInformation =
    /// Various information related to the clone
    abstract cloneOperationResponse: CloneOperationCommonResponse with get, set
    /// Test Plan Clone create parameters
    abstract cloneOptions: Test.CloneOptions with get, set
    /// Information of destination Test Plan
    abstract destinationTestPlan: TestPlan with get, set
    /// Information of source Test Plan
    abstract sourceTestPlan: SourceTestplanResponse with get, set

/// Parameters for Test Plan clone operation
type [<AllowNullLiteral>] CloneTestPlanParams =
    /// Test Plan Clone create parameters
    abstract cloneOptions: Test.CloneOptions with get, set
    /// Information about destination Test Plan
    abstract destinationTestPlan: DestinationTestPlanCloneParams with get, set
    /// Information about source Test Plan
    abstract sourceTestPlan: SourceTestPlanInfo with get, set

/// Response for Test Suite clone operation
type [<AllowNullLiteral>] CloneTestSuiteOperationInformation =
    /// Information of newly cloned Test Suite
    abstract clonedTestSuite: TestSuiteReferenceWithProject with get, set
    /// Various information related to the clone
    abstract cloneOperationResponse: CloneOperationCommonResponse with get, set
    /// Test Plan Clone create parameters
    abstract cloneOptions: Test.CloneOptions with get, set
    /// Information of destination Test Suite
    abstract destinationTestSuite: TestSuiteReferenceWithProject with get, set
    /// Information of source Test Suite
    abstract sourceTestSuite: TestSuiteReferenceWithProject with get, set

/// Parameters for Test Suite clone operation
type [<AllowNullLiteral>] CloneTestSuiteParams =
    /// Test Plan Clone create parameters
    abstract cloneOptions: Test.CloneOptions with get, set
    /// Information about destination Test Suite
    abstract destinationTestSuite: DestinationTestSuiteInfo with get, set
    /// Information about source Test Suite
    abstract sourceTestSuite: SourceTestSuiteInfo with get, set

/// Configuration of the Test Point
type [<AllowNullLiteral>] Configuration =
    /// Id of the Configuration Assigned to the Test Point
    abstract configurationId: float with get, set

/// Destination Test Plan create parameters
type [<AllowNullLiteral>] DestinationTestPlanCloneParams =
    inherit TestPlanCreateParams
    /// Destination Project Name
    abstract project: string with get, set

/// Destination Test Suite information for Test Suite clone operation
type [<AllowNullLiteral>] DestinationTestSuiteInfo =
    /// Destination Suite Id
    abstract id: float with get, set
    /// Destination Project Name
    abstract project: string with get, set

type [<RequireQualifiedAccess>] ExcludeFlags =
    | None = 0
    | PointAssignments = 1
    | ExtraInformation = 2

type [<RequireQualifiedAccess>] FailureType =
    | None = 0
    | Regression = 1
    | New_Issue = 2
    | Known_Issue = 3
    | Unknown = 4
    | Null_Value = 5
    | MaxValue = 5

type [<RequireQualifiedAccess>] LastResolutionState =
    | None = 0
    | NeedsInvestigation = 1
    | TestIssue = 2
    | ProductIssue = 3
    | ConfigurationIssue = 4
    | NullValue = 5
    | MaxValue = 5

type [<RequireQualifiedAccess>] Outcome =
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

/// Assignments for the Test Point
type [<AllowNullLiteral>] PointAssignment =
    inherit Configuration
    /// Name of the Configuration Assigned to the Test Point
    abstract configurationName: string with get, set
    /// Id of the Test Point
    abstract id: float with get, set
    /// Tester Assigned to the Test Point
    abstract tester: WebApi.IdentityRef with get, set

type [<RequireQualifiedAccess>] PointState =
    | None = 0
    | Ready = 1
    | Completed = 2
    | NotReady = 3
    | InProgress = 4
    | MaxValue = 4

/// Results class for Test Point
type [<AllowNullLiteral>] Results =
    /// Outcome of the Test Point
    abstract outcome: Outcome with get, set

type [<RequireQualifiedAccess>] ResultState =
    | Unspecified = 0
    | Pending = 1
    | Queued = 2
    | InProgress = 3
    | Paused = 4
    | Completed = 5
    | MaxValue = 5

/// Source Test Plan information for Test Plan clone operation
type [<AllowNullLiteral>] SourceTestPlanInfo =
    /// ID of the source Test Plan
    abstract id: float with get, set
    /// Id of suites to be cloned inside source Test Plan
    abstract suiteIds: ResizeArray<float> with get, set

/// Source Test Plan Response for Test Plan clone operation
type [<AllowNullLiteral>] SourceTestplanResponse =
    inherit TestPlanReference
    /// project reference
    abstract project: Core.TeamProjectReference with get, set
    /// Id of suites to be cloned inside source Test Plan
    abstract suiteIds: ResizeArray<float> with get, set

/// Source Test Suite information for Test Suite clone operation
type [<AllowNullLiteral>] SourceTestSuiteInfo =
    /// Id of the Source Test Suite
    abstract id: float with get, set

/// A suite entry defines properties for a test suite.
type [<AllowNullLiteral>] SuiteEntry =
    inherit SuiteEntryUpdateParams
    /// Id for the test suite.
    abstract suiteId: float with get, set

type [<RequireQualifiedAccess>] SuiteEntryTypes =
    | TestCase = 0
    | Suite = 1

/// A suite entry defines properties for a test suite.
type [<AllowNullLiteral>] SuiteEntryUpdateParams =
    /// Id of the suite entry in the test suite: either a test case id or child suite id.
    abstract id: float with get, set
    /// Sequence number for the suite entry object in the test suite.
    abstract sequenceNumber: float with get, set
    /// Defines whether the entry is of type test case or suite.
    abstract suiteEntryType: SuiteEntryTypes with get, set

type [<RequireQualifiedAccess>] SuiteExpand =
    | None = 0
    | Children = 1
    | DefaultTesters = 2

/// Create and Update Suite Test Case Parameters
type [<AllowNullLiteral>] SuiteTestCaseCreateUpdateParameters =
    /// Configurations Ids
    abstract pointAssignments: ResizeArray<Configuration> with get, set
    /// Id of Test Case to be updated or created
    abstract workItem: WorkItem with get, set

/// Test Case Class
type [<AllowNullLiteral>] TestCase =
    /// Reference links
    abstract links: obj option with get, set
    /// Order of the TestCase in the Suite
    abstract order: float with get, set
    /// List of Points associated with the Test Case
    abstract pointAssignments: ResizeArray<PointAssignment> with get, set
    /// Project under which the Test Case is
    abstract project: Core.TeamProjectReference with get, set
    /// Test Plan under which the Test Case is
    abstract testPlan: TestPlanReference with get, set
    /// Test Suite under which the Test Case is
    abstract testSuite: TestSuiteReference with get, set
    /// Work Item details of the TestCase
    abstract workItem: WorkItemDetails with get, set

type [<AllowNullLiteral>] TestCaseAssociatedResult =
    abstract completedDate: DateTime with get, set
    abstract configuration: TestConfigurationReference with get, set
    abstract outcome: UserFriendlyTestOutcome with get, set
    abstract plan: TestPlanReference with get, set
    abstract pointId: float with get, set
    abstract resultId: float with get, set
    abstract runBy: WebApi.IdentityRef with get, set
    abstract runId: float with get, set
    abstract suite: TestSuiteReference with get, set
    abstract tester: WebApi.IdentityRef with get, set

/// Test Case Reference
type [<AllowNullLiteral>] TestCaseReference =
    /// Identity to whom the test case is assigned
    abstract assignedTo: WebApi.IdentityRef with get, set
    /// Test Case Id
    abstract id: float with get, set
    /// Test Case Name
    abstract name: string with get, set
    /// State of the test case work item
    abstract state: string with get, set

/// This data model is used in TestCaseResultsDataProvider and populates the data required for initial page load
type [<AllowNullLiteral>] TestCaseResultsData =
    /// Point information from where the execution history was viewed. Used to set initial filters.
    abstract contextPoint: TestPointDetailedReference with get, set
    /// Use to store the results displayed in the table
    abstract results: ResizeArray<TestCaseAssociatedResult> with get, set
    /// Test Case Name to be displayed in the table header
    abstract testCaseName: string with get, set

/// Test configuration
type [<AllowNullLiteral>] TestConfiguration =
    inherit TestConfigurationCreateUpdateParameters
    /// Id of the configuration
    abstract id: float with get, set
    /// Id of the test configuration variable
    abstract project: Core.TeamProjectReference with get, set

/// Test Configuration Create or Update Parameters
type [<AllowNullLiteral>] TestConfigurationCreateUpdateParameters =
    /// Description of the configuration
    abstract description: string with get, set
    /// Is the configuration a default for the test plans
    abstract isDefault: bool with get, set
    /// Name of the configuration
    abstract name: string with get, set
    /// State of the configuration
    abstract state: Test.TestConfigurationState with get, set
    /// Dictionary of Test Variable, Selected Value
    abstract values: ResizeArray<Test.NameValuePair> with get, set

/// Test Configuration Reference
type [<AllowNullLiteral>] TestConfigurationReference =
    /// Id of the configuration
    abstract id: float with get, set
    /// Name of the configuration
    abstract name: string with get, set

/// The test plan resource.
type [<AllowNullLiteral>] TestPlan =
    inherit TestPlanUpdateParams
    /// Relevant links
    abstract _links: obj option with get, set
    /// ID of the test plan.
    abstract id: float with get, set
    /// Previous build Id associated with the test plan
    abstract previousBuildId: float with get, set
    /// Project which contains the test plan.
    abstract project: Core.TeamProjectReference with get, set
    /// Root test suite of the test plan.
    abstract rootSuite: TestSuiteReference with get, set
    /// Identity Reference for the last update of the test plan
    abstract updatedBy: WebApi.IdentityRef with get, set
    /// Updated date of the test plan
    abstract updatedDate: DateTime with get, set

/// The test plan create parameters.
type [<AllowNullLiteral>] TestPlanCreateParams =
    /// Area of the test plan.
    abstract areaPath: string with get, set
    abstract automatedTestEnvironment: Test.TestEnvironment with get, set
    abstract automatedTestSettings: Test.TestSettings with get, set
    /// The Build Definition that generates a build associated with this test plan.
    abstract buildDefinition: BuildDefinitionReference with get, set
    /// Build to be tested.
    abstract buildId: float with get, set
    /// Description of the test plan.
    abstract description: string with get, set
    /// End date for the test plan.
    abstract endDate: DateTime with get, set
    /// Iteration path of the test plan.
    abstract iteration: string with get, set
    abstract manualTestEnvironment: Test.TestEnvironment with get, set
    abstract manualTestSettings: Test.TestSettings with get, set
    /// Name of the test plan.
    abstract name: string with get, set
    /// Owner of the test plan.
    abstract owner: WebApi.IdentityRef with get, set
    /// Release Environment to be used to deploy the build and run automated tests from this test plan.
    abstract releaseEnvironmentDefinition: Test.ReleaseEnvironmentDefinitionReference with get, set
    /// Start date for the test plan.
    abstract startDate: DateTime with get, set
    /// State of the test plan.
    abstract state: string with get, set
    /// Value to configure how same tests across test suites under a test plan need to behave
    abstract testOutcomeSettings: Test.TestOutcomeSettings with get, set

/// The test plan detailed reference resource. Contains additional workitem realted information
type [<AllowNullLiteral>] TestPlanDetailedReference =
    inherit TestPlanReference
    /// Area of the test plan.
    abstract areaPath: string with get, set
    /// End date for the test plan.
    abstract endDate: DateTime with get, set
    /// Iteration path of the test plan.
    abstract iteration: string with get, set
    /// Root Suite Id
    abstract rootSuiteId: float with get, set
    /// Start date for the test plan.
    abstract startDate: DateTime with get, set

/// The test plan reference resource.
type [<AllowNullLiteral>] TestPlanReference =
    /// ID of the test plan.
    abstract id: float with get, set
    /// Name of the test plan.
    abstract name: string with get, set

/// This data model is used in TestPlansHubRefreshDataProvider and populates the data required for initial page load
type [<AllowNullLiteral>] TestPlansHubRefreshData =
    abstract defineColumnOptionFields: ResizeArray<string> with get, set
    abstract executeColumnOptionFields: ResizeArray<string> with get, set
    abstract isAdvancedExtensionEnabled: bool with get, set
    abstract selectedSuiteId: float with get, set
    abstract testCasePageSize: float with get, set
    abstract testCases: ResizeArray<TestCase> with get, set
    abstract testCasesContinuationToken: string with get, set
    abstract testPlan: TestPlanDetailedReference with get, set
    abstract testPointPageSize: float with get, set
    abstract testPoints: ResizeArray<TestPoint> with get, set
    abstract testPointsContinuationToken: string with get, set
    abstract testSuites: ResizeArray<TestSuite> with get, set
    abstract testSuitesContinuationToken: string with get, set

/// The test plan update parameters.
type [<AllowNullLiteral>] TestPlanUpdateParams =
    inherit TestPlanCreateParams
    /// Revision of the test plan.
    abstract revision: float with get, set

/// Test Point Class
type [<AllowNullLiteral>] TestPoint =
    /// Comment associated to the Test Point
    abstract comment: string with get, set
    /// Configuration associated with the Test Point
    abstract configuration: TestConfigurationReference with get, set
    /// Id of the Test Point
    abstract id: float with get, set
    /// Variable to decide whether the test case is Active or not
    abstract isActive: bool with get, set
    /// Is the Test Point for Automated Test Case or Manual
    abstract isAutomated: bool with get, set
    /// Last Reset to Active Time Stamp for the Test Point
    abstract lastResetToActive: DateTime with get, set
    /// Last Updated details for the Test Point
    abstract lastUpdatedBy: WebApi.IdentityRef with get, set
    /// Last Update Time Stamp for the Test Point
    abstract lastUpdatedDate: DateTime with get, set
    /// Reference links
    abstract links: obj option with get, set
    /// Project under which the Test Point is
    abstract project: Core.TeamProjectReference with get, set
    /// Results associated to the Test Point
    abstract results: TestPointResults with get, set
    /// Test Case Reference
    abstract testCaseReference: TestCaseReference with get, set
    /// Tester associated with the Test Point
    abstract tester: WebApi.IdentityRef with get, set
    /// Test Plan under which the Test Point is
    abstract testPlan: TestPlanReference with get, set
    /// Test Suite under which the Test Point is
    abstract testSuite: TestSuiteReference with get, set

/// Test Point Count
type [<AllowNullLiteral>] TestPointCount =
    /// Test Point Count
    abstract count: float with get, set
    /// Test Plan under which the Test Points are
    abstract testPlanId: float with get, set
    /// Test Suite under which the Test Points are
    abstract testSuiteId: float with get, set

type [<AllowNullLiteral>] TestPointDetailedReference =
    abstract configuration: TestConfigurationReference with get, set
    abstract plan: TestPlanReference with get, set
    abstract pointId: float with get, set
    abstract suite: TestSuiteReference with get, set
    abstract tester: WebApi.IdentityRef with get, set

/// Test Point Results
type [<AllowNullLiteral>] TestPointResults =
    /// Failure Type for the Test Point
    abstract failureType: FailureType with get, set
    /// Last Resolution State Id for the Test Point
    abstract lastResolutionState: LastResolutionState with get, set
    /// Last Result Details for the Test Point
    abstract lastResultDetails: Test.LastResultDetails with get, set
    /// Last Result Id
    abstract lastResultId: float with get, set
    /// Last Result State of the Test Point
    abstract lastResultState: ResultState with get, set
    /// Last RUn Build Number for the Test Point
    abstract lastRunBuildNumber: string with get, set
    /// Last Test Run Id for the Test Point
    abstract lastTestRunId: float with get, set
    /// Outcome of the Test Point
    abstract outcome: Outcome with get, set
    /// State of the Test Point
    abstract state: PointState with get, set

/// Test Point Update Parameters
type [<AllowNullLiteral>] TestPointUpdateParams =
    /// Id of Test Point to be updated
    abstract id: float with get, set
    /// Reset the Test Point to Active
    abstract isActive: bool with get, set
    /// Results of the test point
    abstract results: Results with get, set
    /// Tester of the Test Point
    abstract tester: WebApi.IdentityRef with get, set

/// Test suite
type [<AllowNullLiteral>] TestSuite =
    inherit TestSuiteCreateParams
    /// Links: self, testPoints, testCases, parent
    abstract _links: obj option with get, set
    /// Child test suites of current test suite.
    abstract children: ResizeArray<TestSuite> with get, set
    /// Boolean value dictating if Child test suites are present
    abstract hasChildren: bool with get, set
    /// Id of test suite.
    abstract id: float with get, set
    /// Last error for test suite.
    abstract lastError: string with get, set
    /// Last populated date.
    abstract lastPopulatedDate: DateTime with get, set
    /// IdentityRef of user who has updated test suite recently.
    abstract lastUpdatedBy: WebApi.IdentityRef with get, set
    /// Last update date.
    abstract lastUpdatedDate: DateTime with get, set
    /// Test plan to which the test suite belongs.
    abstract plan: TestPlanReference with get, set
    /// Test suite project shallow reference.
    abstract project: Core.TeamProjectReference with get, set
    /// Test suite revision.
    abstract revision: float with get, set

/// Test suite Create Parameters
type [<AllowNullLiteral>] TestSuiteCreateParams =
    inherit TestSuiteCreateUpdateCommonParams
    /// Test suite requirement id.
    abstract requirementId: float with get, set
    /// Test suite type.
    abstract suiteType: TestSuiteType with get, set

/// Test Suite Create/Update Common Parameters
type [<AllowNullLiteral>] TestSuiteCreateUpdateCommonParams =
    /// Test suite default configurations.
    abstract defaultConfigurations: ResizeArray<TestConfigurationReference> with get, set
    /// Test suite default testers.
    abstract defaultTesters: ResizeArray<WebApi.IdentityRef> with get, set
    /// Default configuration was inherited or not.
    abstract inheritDefaultConfigurations: bool with get, set
    /// Name of test suite.
    abstract name: string with get, set
    /// Test suite parent shallow reference.
    abstract parentSuite: TestSuiteReference with get, set
    /// Test suite query string, for dynamic suites.
    abstract queryString: string with get, set

/// The test suite reference resource.
type [<AllowNullLiteral>] TestSuiteReference =
    /// ID of the test suite.
    abstract id: float with get, set
    /// Name of the test suite.
    abstract name: string with get, set

/// Test Suite Reference with Project
type [<AllowNullLiteral>] TestSuiteReferenceWithProject =
    inherit TestSuiteReference
    /// Reference of destination Project
    abstract project: Core.TeamProjectReference with get, set

type [<RequireQualifiedAccess>] TestSuiteType =
    | None = 0
    | DynamicTestSuite = 1
    | StaticTestSuite = 2
    | RequirementTestSuite = 3

/// Test Suite Update Parameters
type [<AllowNullLiteral>] TestSuiteUpdateParams =
    inherit TestSuiteCreateUpdateCommonParams
    /// Test suite revision.
    abstract revision: float with get, set

/// Test Variable
type [<AllowNullLiteral>] TestVariable =
    inherit TestVariableCreateUpdateParameters
    /// Id of the test variable
    abstract id: float with get, set
    /// Id of the test variable
    abstract project: Core.TeamProjectReference with get, set

/// Test Variable Create or Update Parameters
type [<AllowNullLiteral>] TestVariableCreateUpdateParameters =
    /// Description of the test variable
    abstract description: string with get, set
    /// Name of the test variable
    abstract name: string with get, set
    /// List of allowed values
    abstract values: ResizeArray<string> with get, set

type [<RequireQualifiedAccess>] UserFriendlyTestOutcome =
    | InProgress = 0
    | Blocked = 1
    | Failed = 2
    | Passed = 3
    | Ready = 4
    | NotApplicable = 5
    | Paused = 6
    | MaxValue = 6

/// Work Item
type [<AllowNullLiteral>] WorkItem =
    /// Id of the Work Item
    abstract id: float with get, set

/// Work Item Class
type [<AllowNullLiteral>] WorkItemDetails =
    /// Work Item Id
    abstract id: float with get, set
    /// Work Item Name
    abstract name: string with get, set
    /// Work Item Fields
    abstract workItemFields: ResizeArray<obj option> with get, set
