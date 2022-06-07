[<AutoOpen>]
module Extensions
open System

[<Measure>] type realDay // realtime days that pass. Think of this as the x-axis on the visualized chart.
[<Measure>] type dayCost // amount of capacity consumed. Think of this as a ratio between realDay and work completion.

type Id = int
type BucketId = string
type AssignmentContext<'t> = {
    startTime: DateTime // NOT DateTimeOffset because we actually only care about calendar dates, not actual moments in time tied to time zones. My end-of-day doesn't have to match up with your end-of-day as long as we both finish that day.
    buckets: string list
    capacityCoefficient: AssignmentContext<'t> -> BucketId -> float<realDay> -> float<dayCost/realDay>
    prioritize: 't list -> 't list
    getId: 't -> Id
    getDependencies: 't -> Id list
    getBucket: 't -> BucketId option
    getDeliverable: 't -> Id
    getCost: 't -> float<dayCost>
    }

type Assignment<'t> = {
    underlying: 't
    bucketId: BucketId
    startTime: float<realDay>
    duration: float<realDay>
    resourceRow: int
    }

let toDate (ctx: _ AssignmentContext) (timeElapsed: float<realDay>) =
    let realDayElapsed = floor (timeElapsed |> float) |> int
    ctx.startTime.AddDays realDayElapsed

let inline append (dest:byref<_ list>) item =
    dest <- dest @ [item]

let inline remove (dest:byref<_ list>) item =
    dest <- dest |> List.filter ((<>) item)

let inline delta (delta:_ byref) amount =
    delta <- delta + amount

let remainingTimeToday (now: float<realDay>): float<realDay> =
    let now = float now
    if now = floor now then 1.<realDay> // full day remaining
    else (ceil now - now) * 1.<realDay>

let assignments (ctx: _ AssignmentContext) (items: 't list) =
    let mutable buckets = ctx.buckets |> List.map (fun bucket -> bucket, 0.<realDay>) |> Map.ofList
    let items = items |> ctx.prioritize
    let mutable todo = []
    let mutable wontBeDone = []
    let mutable finished = items |> List.filter (fun i -> ctx.getCost i <= 0.<dayCost>) |> List.map ctx.getId |> Set.ofList
    let isFinished itemId =
        finished |> Set.contains itemId
    let mutable assignments = []

    let processItem item =
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
                            daysPassed <- ((float daysPassed |> floor) + 1.) * 1.<realDay>
                        else
                            delta &daysPassed (workRemaining / workRatio)
                            workRemaining <- 0.<dayCost>
                    // write the computed end date back into the bucket
                    buckets <- buckets |> Map.add bucketId daysPassed
                    finished <- finished |> Set.add (ctx.getId item)
                    append &assignments {
                        underlying = item
                        bucketId = bucketId
                        startTime = startTime
                        duration = daysPassed - startTime
                        resourceRow = 0
                        }
    for item' in items |> List.filter (fun i -> ctx.getCost i > 0.<dayCost>) do
        append &todo item'
        // todo: allow breaking up of work items
        for item in todo do
            processItem item
    // ensure nothing goes unprocessed even if todo is in a weird order
    while todo.Length > 0 do
        for item in todo do
            processItem item
    let assignResourceRows assignments =
        let getUnderlying asn = asn.underlying
        let byDeliverable = assignments |> List.groupBy (getUnderlying >> ctx.getDeliverable)
        [
            for _, group in byDeliverable do
                let mutable buckets = []
                for assignment in group do
                    let bucketId = (assignment.underlying |> ctx.getBucket)
                    match buckets |> List.tryFindIndex (fun bucketId' -> bucketId = bucketId') with
                    | Some rowId ->
                        { assignment with resourceRow = rowId + 1 }
                    | None ->
                        let rowId = buckets.Length
                        buckets <- buckets @ [bucketId]
                        { assignment with resourceRow = rowId + 1 }
            ]
    assignments |> assignResourceRows, wontBeDone

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
        let ratio = match bucket with "max" -> 0.75<dayCost/realDay> | _ -> 0.8<dayCost/realDay>
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

module TestExecute =
    open Test
    let execute() =
        for work in assignments ctx items |> fst do
            let date time = (ctx.startTime.AddDays (int time)).ToString("MM/dd")
            let range =
                let start = work.startTime |> date
                let finish = work.duration + work.startTime |> date
                if finish <> start then $"{start}-{finish}" else start
            printfn $"{work.underlying.title} {range} {work.startTime} {work.duration}"

module LocalStorage =
    open Thoth.Json
    open Browser.Dom

    let inline jsonParse<'t> fallback str : 't =
        match Decode.Auto.fromString str with
        | Ok result -> result
        | Result.Error err ->
            fallback

    let inline read (key: string) fallback =
        try
            Browser.Dom.window.localStorage[key] |> jsonParse<'t> fallback
        with _ ->
            fallback
    let inline write (key: string) value =
        Browser.Dom.window.localStorage[key] <- Encode.Auto.toString<'t>(0, value)

    module PAT =
        let key = "PAT"
        let read (): string option = read key None
        let write (v: string option) = write key v
    module ServerUrlOverride =
        let key = "ServerURLOverride"
        let read (): string option = read key (Some "https://dev.azure.com/microsoft/OSGS/")
        let write (v: string option) = write key v
    module Wiql =
        let key = "Wiql"
        let read () : string = read key """SELECT [System.Id] FROM workitems
        WHERE [System.TeamProject] = @project and System.AreaPath = 'OSGS\Storefronts\MSE\SD365CPI' and System.IterationPath = 'OSGS\2206' and System.WorkItemType in ('Task', 'Bug')"""
        let write (v: string) = write key v


