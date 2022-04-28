[<AutoOpen>]
module Extensions
open System

[<Measure>] type realDays // realtime days that pass. Think of this as the x-axis on the visualized chart.
[<Measure>] type dayCost // amount of capacity consumed. Think of this as a ratio between realDays and work completion.

type Id = int
type BucketId = string
type AssignmentContext<'t> = {
    startTime: DateTime // NOT DateTimeOffset because we actually only care about calendar dates, not actual moments in time tied to time zones. My end-of-day doesn't have to match up with your end-of-day as long as we both finish that day.
    buckets: string list
    capacityCoefficient: AssignmentContext<'t> -> BucketId -> float<realDays> -> float<dayCost/realDays>
    prioritize: 't list -> 't list
    getId: 't -> Id
    getDependencies: 't -> Id list
    getBucket: 't -> BucketId option
    getCost: 't -> float<dayCost>
    }

type Assignment<'t> = {
    underlying: 't
    bucketId: BucketId
    startTime: float<realDays>
    duration: float<realDays>
    }

let toDate (ctx: _ AssignmentContext) (timeElapsed: float<realDays>) =
    let realDaysElapsed = floor (timeElapsed |> float) |> int
    ctx.startTime.AddDays realDaysElapsed

let inline append (dest:byref<_ list>) item =
    dest <- dest @ [item]

let inline remove (dest:byref<_ list>) item =
    dest <- dest |> List.filter ((<>) item)

let inline delta (delta:_ byref) amount =
    delta <- delta + amount

let remainingTimeToday (now: float<realDays>): float<realDays> =
    let now = float now
    if now = floor now then 1.<realDays> // full day remaining
    else (ceil now - now) * 1.<realDays>

let assignments (ctx: _ AssignmentContext) (items: 't list) =
    let mutable buckets = ctx.buckets |> List.map (fun bucket -> bucket, 0.<realDays>) |> Map.ofList
    let items = items |> ctx.prioritize
    let mutable todo = []
    let mutable wontBeDone = []
    let mutable finished = Set.empty
    let isFinished itemId =
        finished |> Set.contains itemId
    let mutable assignments = []

    for item' in items do
        append &todo item'
        // todo: allow breaking up of work items
        for item in todo do
            if item |> ctx.getDependencies |> List.every isFinished then
                remove &todo item
                match ctx.getBucket item with
                | None -> append &wontBeDone item
                | Some bucketId ->
                    match buckets |> Map.tryFind bucketId with
                    | None ->
                        append &wontBeDone item // maybe we should add a bucket instead in this case
                    | Some (daysPassed) ->
                        let startTime = daysPassed
                        let mutable workRemaining = ctx.getCost item
                        let mutable daysPassed = daysPassed
                        while workRemaining > 0.<dayCost> do
                            let workRatio = ctx.capacityCoefficient ctx bucketId daysPassed
                            let remainingTimeToday = remainingTimeToday daysPassed
                            let remainingCapacityToday = remainingTimeToday * workRatio
                            if workRemaining > remainingCapacityToday then
                                delta &workRemaining -remainingCapacityToday
                                daysPassed <- ((float daysPassed |> floor) + 1.) * 1.<realDays>
                            else
                                workRemaining <- 0.<dayCost>
                                delta &daysPassed remainingTimeToday
                        // write the computed end date back into the bucket
                        buckets <- buckets |> Map.add bucketId daysPassed
                        finished <- finished |> Set.add (ctx.getId item)
                        append &assignments {
                            underlying = item
                            bucketId = bucketId
                            startTime = startTime
                            duration = daysPassed - startTime
                            }
    assignments

module Test =
    type PseudoItem = {
        id: Id
        title: string
        assignedPerson: string option
        startTime: DateTime option
        priority: int
        dependencies: Id list
        remainingDays: float
        }
    type Assignment = PseudoItem Assignment
    type Context = PseudoItem AssignmentContext
    let items = [
        { id = 1; title = "Create data structures for work item visualizing"; assignedPerson = Some "max"; remainingDays = 0.1; startTime = None; priority = 1; dependencies = [] }
        { id = 2; title = "Write sorting algorithm for work item visualizer"; assignedPerson = Some "max"; remainingDays = 0.5; startTime = None; priority = 1; dependencies = [1] }
        { id = 3; title = "Write React views for visualized items"; assignedPerson = Some "max"; remainingDays = 0.5;  startTime = None; priority = 1; dependencies = [1] }
        { id = 4; title = "Change ADO work item types to reflect OSGS"; assignedPerson = Some "max"; remainingDays = 0.2; startTime = None; priority = 1; dependencies = [] }
        { id = 5; title = "Verify/manual test: Visualizing real work items works"; assignedPerson = Some "sasi"; remainingDays = 0.2; startTime = None; priority = 1; dependencies = [] }
        ]
    let measureCapacity (ctx: _ AssignmentContext) (bucket: string) (startTime: float<realDays>): float<dayCost/realDays> =
        let ratio = match bucket with "max" -> 0.75<dayCost/realDays> | _ -> 0.8<dayCost/realDays>
        match (ctx.startTime.AddDays (int startTime)).DayOfWeek |> int with
        | 0 | 6 -> 0.<dayCost/realDays> // not Saturday/Sunday. For some reason can't refer directly to Saturday/Sunday.
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
        }

open Test
for work in assignments ctx items do
    let date time = (ctx.startTime.AddDays (int time)).ToString("MM/dd")
    let range =
        let start = work.startTime |> date
        let finish = work.duration + work.startTime |> date
        if finish <> start then $"{start}-{finish}" else start
    printfn $"{work.underlying.title} {range}"

