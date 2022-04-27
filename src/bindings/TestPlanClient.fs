// ts2fable 0.7.1
module rec TestPlanClient
open System
open Fable.Core
open Fable.Core.JS

type IVssRestClientOptions = Context.IVssRestClientOptions
type RestClientBase = RestClientBase.RestClientBase

type [<AllowNullLiteral>] IExports =
    abstract TestPlanRestClient: TestPlanRestClientStatic

type [<AllowNullLiteral>] TestPlanRestClient =
    inherit RestClientBase
    /// <summary>Create a test configuration.</summary>
    /// <param name="testConfigurationCreateUpdateParameters">- TestConfigurationCreateUpdateParameters</param>
    /// <param name="project">- Project ID or project name</param>
    abstract createTestConfiguration: testConfigurationCreateUpdateParameters: TestPlan.TestConfigurationCreateUpdateParameters * project: string -> Promise<TestPlan.TestConfiguration>
    /// <summary>Delete a test configuration by its ID.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="testConfiguartionId">- ID of the test configuration to delete.</param>
    abstract deleteTestConfguration: project: string * testConfiguartionId: int -> Promise<unit>
    /// <summary>Get a test configuration</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="testConfigurationId">- ID of the test configuration to get.</param>
    abstract getTestConfigurationById: project: string * testConfigurationId: int -> Promise<TestPlan.TestConfiguration>
    /// <summary>Get a list of test configurations.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="continuationToken">- If the list of configurations returned is not complete, a continuation token to query next batch of configurations is included in the response header as "x-ms-continuationtoken". Omit this parameter to get the first batch of test configurations.</param>
    abstract getTestConfigurations: project: string * ?continuationToken: string -> Promise<ResizeArray<TestPlan.TestConfiguration>>
    /// <summary>Update a test configuration by its ID.</summary>
    /// <param name="testConfigurationCreateUpdateParameters">- TestConfigurationCreateUpdateParameters</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="testConfiguartionId">- ID of the test configuration to update.</param>
    abstract updateTestConfiguration: testConfigurationCreateUpdateParameters: TestPlan.TestConfigurationCreateUpdateParameters * project: string * testConfiguartionId: int -> Promise<TestPlan.TestConfiguration>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="planId">-</param>
    /// <param name="states">-</param>
    /// <param name="outcome">-</param>
    /// <param name="configurations">-</param>
    /// <param name="testers">-</param>
    /// <param name="assignedTo">-</param>
    abstract getTestPointCountByPlanId: project: string * planId: int * ?states: string * ?outcome: TestPlan.UserFriendlyTestOutcome * ?configurations: string * ?testers: string * ?assignedTo: string -> Promise<ResizeArray<TestPlan.TestPointCount>>
    /// <summary>Create a test plan.</summary>
    /// <param name="testPlanCreateParams">- A testPlanCreateParams object.TestPlanCreateParams</param>
    /// <param name="project">- Project ID or project name</param>
    abstract createTestPlan: testPlanCreateParams: TestPlan.TestPlanCreateParams * project: string -> Promise<TestPlan.TestPlan>
    /// <summary>Delete a test plan.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="planId">- ID of the test plan to be deleted.</param>
    abstract deleteTestPlan: project: string * planId: int -> Promise<unit>
    /// <summary>Get a test plan by Id.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="planId">- ID of the test plan to get.</param>
    abstract getTestPlanById: project: string * planId: int -> Promise<TestPlan.TestPlan>
    /// <summary>Get a list of test plans</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="owner">- Filter for test plan by owner ID or name</param>
    /// <param name="continuationToken">- If the list of plans returned is not complete, a continuation token to query next batch of plans is included in the response header as "x-ms-continuationtoken". Omit this parameter to get the first batch of test plans.</param>
    /// <param name="includePlanDetails">- Get all properties of the test plan</param>
    /// <param name="filterActivePlans">- Get just the active plans</param>
    abstract getTestPlans: project: string * ?owner: string * ?continuationToken: string * ?includePlanDetails: bool * ?filterActivePlans: bool -> Promise<ResizeArray<TestPlan.TestPlan>>
    /// <summary>Update a test plan.</summary>
    /// <param name="testPlanUpdateParams">- A testPlanUpdateParams object.TestPlanUpdateParams</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="planId">- ID of the test plan to be updated.</param>
    abstract updateTestPlan: testPlanUpdateParams: TestPlan.TestPlanUpdateParams * project: string * planId: int -> Promise<TestPlan.TestPlan>
    /// <summary>Get a list of test suite entries in the test suite.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="suiteId">- Id of the parent suite.</param>
    /// <param name="suiteEntryType">-</param>
    abstract getSuiteEntries: project: string * suiteId: int * ?suiteEntryType: TestPlan.SuiteEntryTypes -> Promise<ResizeArray<TestPlan.SuiteEntry>>
    /// <summary>Reorder test suite entries in the test suite.</summary>
    /// <param name="suiteEntries">- List of SuiteEntry to reorder.</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="suiteId">- Id of the parent test suite.</param>
    abstract reorderSuiteEntries: suiteEntries: ResizeArray<TestPlan.SuiteEntryUpdateParams> * project: string * suiteId: int -> Promise<ResizeArray<TestPlan.SuiteEntry>>
    /// <summary>Create test suite.</summary>
    /// <param name="testSuiteCreateParams">- Parameters for suite creation</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="planId">- ID of the test plan that contains the suites.</param>
    abstract createTestSuite: testSuiteCreateParams: TestPlan.TestSuiteCreateParams * project: string * planId: int -> Promise<TestPlan.TestSuite>
    /// <summary>Delete test suite.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="planId">- ID of the test plan that contains the suite.</param>
    /// <param name="suiteId">- ID of the test suite to delete.</param>
    abstract deleteTestSuite: project: string * planId: int * suiteId: int -> Promise<unit>
    /// <summary>Get test suite by suite id.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="planId">- ID of the test plan that contains the suites.</param>
    /// <param name="suiteId">- ID of the suite to get.</param>
    /// <param name="expand">- Include the children suites and testers details</param>
    abstract getTestSuiteById: project: string * planId: int * suiteId: int * ?expand: TestPlan.SuiteExpand -> Promise<TestPlan.TestSuite>
    /// <summary>Get test suites for plan.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="planId">- ID of the test plan for which suites are requested.</param>
    /// <param name="expand">- Include the children suites and testers details.</param>
    /// <param name="continuationToken">- If the list of suites returned is not complete, a continuation token to query next batch of suites is included in the response header as "x-ms-continuationtoken". Omit this parameter to get the first batch of test suites.</param>
    /// <param name="asTreeView">- If the suites returned should be in a tree structure.</param>
    abstract getTestSuitesForPlan: project: string * planId: int * ?expand: TestPlan.SuiteExpand * ?continuationToken: string * ?asTreeView: bool -> Promise<ResizeArray<TestPlan.TestSuite>>
    /// <summary>Update test suite.</summary>
    /// <param name="testSuiteUpdateParams">- Parameters for suite updation</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="planId">- ID of the test plan that contains the suites.</param>
    /// <param name="suiteId">- ID of the parent suite.</param>
    abstract updateTestSuite: testSuiteUpdateParams: TestPlan.TestSuiteUpdateParams * project: string * planId: int * suiteId: int -> Promise<TestPlan.TestSuite>
    /// <summary>Find the list of all test suites in which a given test case is present. This is helpful if you need to find out which test suites are using a test case, when you need to make changes to a test case.</summary>
    /// <param name="testCaseId">- ID of the test case for which suites need to be fetched.</param>
    abstract getSuitesByTestCaseId: testCaseId: int -> Promise<ResizeArray<TestPlan.TestSuite>>
    /// <summary>Add test cases to a suite with specified configurations</summary>
    /// <param name="suiteTestCaseCreateUpdateParameters">- SuiteTestCaseCreateUpdateParameters object.</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="planId">- ID of the test plan to which test cases are to be added.</param>
    /// <param name="suiteId">- ID of the test suite to which test cases are to be added.</param>
    abstract addTestCasesToSuite: suiteTestCaseCreateUpdateParameters: ResizeArray<TestPlan.SuiteTestCaseCreateUpdateParameters> * project: string * planId: int * suiteId: int -> Promise<ResizeArray<TestPlan.TestCase>>
    /// <summary>Get Test Cases For a Suite.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="planId">- ID of the test plan for which test cases are requested.</param>
    /// <param name="suiteId">- ID of the test suite for which test cases are requested.</param>
    /// <param name="testCaseIds">- Test Case Ids to be fetched.</param>
    /// <param name="witFields">- Get the list of witFields.</param>
    /// <param name="returnIdentityRef">- If set to true, returns all identity fields, like AssignedTo, ActivatedBy etc., as IdentityRef objects. If set to false, these fields are returned as unique names in string format. This is false by default.</param>
    abstract getTestCase: project: string * planId: int * suiteId: int * testCaseIds: string * ?witFields: string * ?returnIdentityRef: bool -> Promise<ResizeArray<TestPlan.TestCase>>
    /// <summary>Get Test Case List return those test cases which have all the configuration Ids as mentioned in the optional paramter. If configuration Ids is null, it return all the test cases</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="planId">- ID of the test plan for which test cases are requested.</param>
    /// <param name="suiteId">- ID of the test suite for which test cases are requested.</param>
    /// <param name="testIds">- Test Case Ids to be fetched.</param>
    /// <param name="configurationIds">- Fetch Test Cases which contains all the configuration Ids specified.</param>
    /// <param name="witFields">- Get the list of witFields.</param>
    /// <param name="continuationToken">- If the list of test cases returned is not complete, a continuation token to query next batch of test cases is included in the response header as "x-ms-continuationtoken". Omit this parameter to get the first batch of test cases.</param>
    /// <param name="returnIdentityRef">- If set to true, returns all identity fields, like AssignedTo, ActivatedBy etc., as IdentityRef objects. If set to false, these fields are returned as unique names in string format. This is false by default.</param>
    /// <param name="expand">- If set to false, will get a smaller payload containing only basic details about the suite test case object</param>
    /// <param name="excludeFlags">- Flag to exclude various values from payload. For example to remove point assignments pass exclude = 1. To remove extra information (links, test plan , test suite) pass exclude = 2. To remove both extra information and point assignments pass exclude = 3 (1 + 2).</param>
    abstract getTestCaseList: project: string * planId: int * suiteId: int * ?testIds: string * ?configurationIds: string * ?witFields: string * ?continuationToken: string * ?returnIdentityRef: bool * ?expand: bool * ?excludeFlags: TestPlan.ExcludeFlags -> Promise<ResizeArray<TestPlan.TestCase>>
    /// <summary>Removes test cases from a suite based on the list of test case Ids provided.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="planId">- ID of the test plan from which test cases are to be removed.</param>
    /// <param name="suiteId">- ID of the test suite from which test cases are to be removed.</param>
    /// <param name="testCaseIds">- Test Case Ids to be removed.</param>
    abstract removeTestCasesFromSuite: project: string * planId: int * suiteId: int * testCaseIds: string -> Promise<unit>
    /// <summary>Update the configurations for test cases</summary>
    /// <param name="suiteTestCaseCreateUpdateParameters">- A SuiteTestCaseCreateUpdateParameters object.</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="planId">- ID of the test plan to which test cases are to be updated.</param>
    /// <param name="suiteId">- ID of the test suite to which test cases are to be updated.</param>
    abstract updateSuiteTestCases: suiteTestCaseCreateUpdateParameters: ResizeArray<TestPlan.SuiteTestCaseCreateUpdateParameters> * project: string * planId: int * suiteId: int -> Promise<ResizeArray<TestPlan.TestCase>>
    /// <summary>Delete a test case.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="testCaseId">- Id of test case to be deleted.</param>
    abstract deleteTestCase: project: string * testCaseId: int -> Promise<unit>
    /// <summary>Clone test plan</summary>
    /// <param name="cloneRequestBody">- Plan Clone Request Body detail TestPlanCloneRequest</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="deepClone">- Clones all the associated test cases as well</param>
    abstract cloneTestPlan: cloneRequestBody: TestPlan.CloneTestPlanParams * project: string * ?deepClone: bool -> Promise<TestPlan.CloneTestPlanOperationInformation>
    /// <summary>Get clone information.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="cloneOperationId">- Operation ID returned when we queue a clone operation</param>
    abstract getCloneInformation: project: string * cloneOperationId: int -> Promise<TestPlan.CloneTestPlanOperationInformation>
    /// <summary>Get a list of points based on point Ids provided.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="planId">- ID of the test plan for which test points are requested.</param>
    /// <param name="suiteId">- ID of the test suite for which test points are requested.</param>
    /// <param name="pointIds">- ID of test points to be fetched.</param>
    /// <param name="returnIdentityRef">- If set to true, returns the AssignedTo field in TestCaseReference as IdentityRef object.</param>
    /// <param name="includePointDetails">- If set to false, will get a smaller payload containing only basic details about the test point object</param>
    abstract getPoints: project: string * planId: int * suiteId: int * pointIds: string * ?returnIdentityRef: bool * ?includePointDetails: bool -> Promise<ResizeArray<TestPlan.TestPoint>>
    /// <summary>Get all the points inside a suite based on some filters</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="planId">- ID of the test plan for which test points are requested.</param>
    /// <param name="suiteId">- ID of the test suite for which test points are requested</param>
    /// <param name="testPointIds">- ID of test points to fetch.</param>
    /// <param name="testCaseId">- Get Test Points for specific test case Ids.</param>
    /// <param name="continuationToken">- If the list of test point returned is not complete, a continuation token to query next batch of test points is included in the response header as "x-ms-continuationtoken". Omit this parameter to get the first batch of test points.</param>
    /// <param name="returnIdentityRef">- If set to true, returns the AssignedTo field in TestCaseReference as IdentityRef object.</param>
    /// <param name="includePointDetails">- If set to false, will get a smaller payload containing only basic details about the test point object</param>
    abstract getPointsList: project: string * planId: int * suiteId: int * ?testPointIds: string * ?testCaseId: string * ?continuationToken: string * ?returnIdentityRef: bool * ?includePointDetails: bool -> Promise<ResizeArray<TestPlan.TestPoint>>
    /// <summary>Update Test Points. This is used to Reset test point to active, update the outcome of a test point or update the tester of a test point</summary>
    /// <param name="testPointUpdateParams">- A TestPointUpdateParams Object.</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="planId">- ID of the test plan for which test points are requested.</param>
    /// <param name="suiteId">- ID of the test suite for which test points are requested.</param>
    /// <param name="includePointDetails">- If set to false, will get a smaller payload containing only basic details about the test point object</param>
    /// <param name="returnIdentityRef">- If set to true, returns the AssignedTo field in TestCaseReference as IdentityRef object.</param>
    abstract updateTestPoints: testPointUpdateParams: ResizeArray<TestPlan.TestPointUpdateParams> * project: string * planId: int * suiteId: int * ?includePointDetails: bool * ?returnIdentityRef: bool -> Promise<ResizeArray<TestPlan.TestPoint>>
    /// <summary>Clone test suite</summary>
    /// <param name="cloneRequestBody">- Suite Clone Request Body detail TestSuiteCloneRequest</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="deepClone">- Clones all the associated test cases as well</param>
    abstract cloneTestSuite: cloneRequestBody: TestPlan.CloneTestSuiteParams * project: string * ?deepClone: bool -> Promise<TestPlan.CloneTestSuiteOperationInformation>
    /// <summary>Get clone information.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="cloneOperationId">- Operation ID returned when we queue a clone operation</param>
    abstract getSuiteCloneInformation: project: string * cloneOperationId: int -> Promise<TestPlan.CloneTestSuiteOperationInformation>
    /// <summary>Create a test variable.</summary>
    /// <param name="testVariableCreateUpdateParameters">- TestVariableCreateUpdateParameters</param>
    /// <param name="project">- Project ID or project name</param>
    abstract createTestVariable: testVariableCreateUpdateParameters: TestPlan.TestVariableCreateUpdateParameters * project: string -> Promise<TestPlan.TestVariable>
    /// <summary>Delete a test variable by its ID.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="testVariableId">- ID of the test variable to delete.</param>
    abstract deleteTestVariable: project: string * testVariableId: int -> Promise<unit>
    /// <summary>Get a test variable by its ID.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="testVariableId">- ID of the test variable to get.</param>
    abstract getTestVariableById: project: string * testVariableId: int -> Promise<TestPlan.TestVariable>
    /// <summary>Get a list of test variables.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="continuationToken">- If the list of variables returned is not complete, a continuation token to query next batch of variables is included in the response header as "x-ms-continuationtoken". Omit this parameter to get the first batch of test variables.</param>
    abstract getTestVariables: project: string * ?continuationToken: string -> Promise<ResizeArray<TestPlan.TestVariable>>
    /// <summary>Update a test variable by its ID.</summary>
    /// <param name="testVariableCreateUpdateParameters">- TestVariableCreateUpdateParameters</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="testVariableId">- ID of the test variable to update.</param>
    abstract updateTestVariable: testVariableCreateUpdateParameters: TestPlan.TestVariableCreateUpdateParameters * project: string * testVariableId: int -> Promise<TestPlan.TestVariable>

type [<AllowNullLiteral>] TestPlanRestClientStatic =
    [<Emit "new $0($1...)">] abstract Create: options: IVssRestClientOptions -> TestPlanRestClient
