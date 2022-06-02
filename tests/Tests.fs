module Tests

open System
#if FABLE_COMPILER
open Fable.Mocha
#else
open Expecto
#endif

module Test =
    type PseudoItem = {
        id: Id
        title: string
        assignedPerson: string option
        startTime: DateTime option
        priority: int
        dependencies: Id list
        remainingDays: float
        deliverableId: Id
        }
    type Assignment = PseudoItem Assignment
    type Context = PseudoItem AssignmentContext
    let items = [
        { id = 1; title = "Create data structures for work item visualizing"; assignedPerson = Some "max"; remainingDays = 0.1; startTime = None; priority = 1; dependencies = []; deliverableId = 1 }
        { id = 2; title = "Write sorting algorithm for work item visualizer"; assignedPerson = Some "max"; remainingDays = 0.5; startTime = None; priority = 1; dependencies = [1]; deliverableId = 1 }
        { id = 3; title = "Write React views for visualized items"; assignedPerson = Some "max"; remainingDays = 0.5;  startTime = None; priority = 1; dependencies = [1]; deliverableId = 1 }
        { id = 4; title = "Change ADO work item types to reflect OSGS"; assignedPerson = Some "max"; remainingDays = 0.2; startTime = None; priority = 1; dependencies = []; deliverableId = 1 }
        { id = 5; title = "Verify/manual test: Visualizing real work items works"; assignedPerson = Some "sasi"; remainingDays = 0.2; startTime = None; priority = 1; dependencies = []; deliverableId = 1 }
        ]
    let measureCapacity (ctx: _ AssignmentContext) (bucket: string) (startTime: float<realDay>): float<dayCost/realDay> =
        let ratio = match bucket with "sasi" -> 0.4<dayCost/realDay> | _ -> 0.75<dayCost/realDay>
        match (ctx.startTime.AddDays (int startTime)).DayOfWeek |> int with
        | 0 | 6 -> 0.<dayCost/realDay> // not Saturday/Sunday. For some reason can't refer directly to Saturday/Sunday.
        | _ ->
            ratio
    let prioritize (items: PseudoItem list) =
        items |> List.sortBy (fun item -> item.priority)

    let ctx : _ AssignmentContext = {
        buckets = ["max";"sasi"]
        startTime = DateTimeOffset.Now.Date
        capacityCoefficient = measureCapacity
        prioritize = prioritize
        getId = (fun item -> item.id)
        getDependencies = (fun item -> item.dependencies)
        getBucket = (fun item -> item.assignedPerson)
        getCost = (fun item -> item.remainingDays * 1.<dayCost>)
        getDeliverable = (fun item -> item.deliverableId)
        }
open Test

[<Tests>]
let appTests = testList "App tests" [
    testCase "Check Assignments" <| fun _ ->
        let assignments = assignments ctx items |> fst
        let sumDuration = assignments |> List.sumBy (fun asn -> asn.duration)
        let expectedSum = (0.1/0.75+0.5/0.75+0.5/0.75+0.2/0.75+0.2/0.4)
        Expect.equal sumDuration (expectedSum*1.<realDay>) "Duration should be task duration times capacity coefficient!"
]

#if FABLE_COMPILER
[<EntryPoint>]
let main (args: string[]) = Mocha.runTests allTests
#else
[<EntryPoint>]
let main (args: string[]) = Tests.runTestsInAssembly defaultConfig args
#endif