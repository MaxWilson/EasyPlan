module Main

open Feliz
open Browser.Dom
open Fable.Core.JsInterop

importSideEffects "./styles/global.sass"

open Components
open Elmish
open Elmish.React
open WorkItemTracking
open WorkItemTrackingClient
open CommonServices
open UI.Konva
open Fable.Core

let sdk = SDK.sdk;

type 't Deferred =
    | NotStarted
    | InProgress
    | Ready of Result<'t, string>
type 't OperationTransition = Started | Finished of Result<'t, string>
let receive = function
    | Started -> InProgress
    | Finished result -> Ready result
type DisplayOrganization = ByBucket | ByDeliverable
type Capacity = {
    description: string
    daysOff: Work.DateRange list
    capacity: float
    capacityByDate: System.DateTime -> float
    }
type QueryData = {
    workItems: WorkItem list
    effectiveDate: System.DateTime
    baselineDate: System.DateTime option // for UI purposes: optional date at which to start showing (empty) days, for comparison's sake
    deliverables: Map<int, WorkItem>
    capacityMap: string -> Capacity
    ctx: WorkItem AssignmentContext
    assignments: WorkItem Assignment list
    dropped: WorkItem list
    }
type QueryResult = {
    current: QueryData
    past: QueryData option
    }
type QueryContext = {
    // TODO: there's got to be a better way to do this than root/project-scoped options separately
    options: Client.IVssRestClientOptions
    projectScopedOptions: Client.IVssRestClientOptions
    serverRoot: string option
    projectName: string option
    explicitTeam: string option
    effectiveDate: System.DateTime
    compareDate: System.DateTime option
    }
type ProgressStatus = OK | Warning of float | AtRisk of float
type EditMode = NotEditing | SelectingDependency of WorkItem Assignment
type Selection =
    | AssignmentSelection of WorkItem Assignment
    | WorkItemSelection of WorkItem
    | BucketSelection of txt:string
type ModalDialog = Help | TeamPicker of input: string
type Msg =
    | SetWiql of string
    | Message of string
    | SdkInitializationMsg of string OperationTransition
    | Query of QueryResult OperationTransition
    | SetPAT of string
    | SetServerOverrideURL of string
    | SetCompareDate of System.DateTime
    | TeamsQuery of string list OperationTransition
    | SetTeamPickerFilter of string
    | SetTeamPicker of string option
    | ToggleTeamPicker
    | ToggleHelp
    | ToggleSettings
    | ToggleDrilldown of bool
    | ToggleShowPast of bool
    | SetDisplayOrganization of DisplayOrganization
    | Select of Selection
    | SelectDependency
    | CancelDependencySelect
    | SetHasUnsavedChanges of bool
type Model = {
    userName: string Deferred
    wiql: string
    userFacingMessage: string option;
    ready: bool;
    query: QueryResult Deferred
    teamsToChooseFrom: (string list) Deferred
    serverUrlOverride: string option
    pat: string option
    modalDialog: ModalDialog list
    showSettings: bool
    showDetail: bool
    compareDate: System.DateTime option
    showPast: bool
    displayOrganization: DisplayOrganization
    selectedItem: Selection option
    selectedTeam: string option
    editMode: EditMode
    hasUnsavedChanges: bool
    }
    with
    static member fresh = { userName = NotStarted; userFacingMessage = None; ready = true; query = NotStarted; teamsToChooseFrom = NotStarted; wiql = ""; serverUrlOverride = None; pat = None; modalDialog = []; showSettings = false; displayOrganization = ByDeliverable; selectedItem = None; editMode = NotEditing; hasUnsavedChanges = false; showDetail = false; compareDate = None; showPast = false; selectedTeam = None }

let asyncOperation dispatch opMsg impl = promise {
    try
        Started |> opMsg |> dispatch
        let! result = impl()
        Finished (Ok result) |> opMsg |> dispatch
    with err ->
        Finished (Error $"{err}") |> opMsg |> dispatch
    }

let initializeSdk() = promise {
    do! sdk.init()
    return sdk.getUser().name
    }

module ResizeArray =
    let map f input =
        input |> Seq.map f |> ResizeArray

module Properties =
    let get<'t> fieldName (item:WorkItem) =
        match item.fields[fieldName] with
        | Some v ->
            try
                unbox<'t> v |> Some
            with _ -> None
        | None -> None
    let getId (workItem: WorkItem) = workItem.id
    let getState = get<string> "System.State"
    let getOwner item : string option = item |> get "System.AssignedTo" |> Option.map (fun p -> p?displayName)
    let getRemainingWork item =
        // if an item is cut/completed/closed, ignore it even if it still has Remaining Days listed.
        let explicitRemainingDays = item |> get<float> "Microsoft.VSTS.Scheduling.RemainingWork" |> Option.orElse (item |> get<float> "OSG.RemainingDays")
        match item |> getState, explicitRemainingDays with
        | Some ("Closed" | "Completed" | "Cut"), _ -> 0.
        | Some ("Resolved"), None -> 0.3 // assume resolution is pretty fast usually
        | _, Some v -> v
        | _ -> 1. // if no Remaining Days estimate but there is still work to do, it might be a new item. Default to 1 just so the timeline doesn't collapse.
        |> (fun w -> w * 1.<dayCost>)
    let getTitle = get<string> "System.Title" >> Option.defaultValue "Untitled"
    let getDeliverableId = get<int option> "System.Parent" >> Option.flatten >> Option.defaultValue 0
    let getWorkItemType = get<string> "System.WorkItemType"
    let getPriority item =
        match get<int> "Microsoft.VSTS.Common.Priority" item with
        | Some pri -> float pri
        | None -> match getWorkItemType item with | Some "Task" | Some "Deliverable" -> 2.0 | _ -> 2.0
    let getDueDate = get<System.DateTime> "Microsoft.VSTS.Scheduling.DueDate"
    let getPrioritization = (fun (i:WorkItem) ->
        // treat work items as less important than P1 bugs and equal to P2
        let pri = getPriority i

        // also respect DueDate as a secondary ordering factor, with no due date as the least-urgent
        let due = getDueDate i
        pri, due |> Option.defaultValue System.DateTime.MaxValue
        )
    let getFinalNumber (url: string) =
        let result = System.Text.RegularExpressions.Regex.Match(url, "([0-9]+)$")
        if result.Success then
            result.Groups.[1].Value |> System.Int32.Parse
        else
            failwith $"{url} does not end in a number"
    let getDependencies (workItem: WorkItem) =
        if workItem.relations = null then []
        else
            [for rel in workItem.relations do
                match rel.attributes["name"] |> string with
                | "Dependent On" | "Predecessor" ->
                    rel.url |> getFinalNumber
                | _ -> ()
                ] |> List.distinct

open Properties

let makeAssignmentContext (effectiveDate, workItems, capacityMap): _ AssignmentContext =
    let capacity (ctx: _ AssignmentContext) (bucket: string) (startTime: float<realDay>): float<dayCost/realDay> =
        let capacity = capacityMap bucket
        let dt = ctx.startTime.AddDays (float startTime)
        if capacity.daysOff |> List.exists (fun range -> range.start.LocalDateTime <= dt && dt <= range.``end``.LocalDateTime ) then 0.0<dayCost/realDay> // no capacity on days off
        else capacity.capacityByDate dt * 1.<dayCost/realDay>

    let getBucket item =
        match getOwner item with
        // ignore buckets that have no actual person assigned--they will just cause infinite loops. Instead, return None so those work items get listed as dropped/won't be done.
        | Some bucket when (capacityMap bucket).capacity > 0. -> Some bucket
        | _ -> None
    {
        startTime = effectiveDate
        buckets = workItems |> Seq.map getBucket |> Seq.filter Option.isSome |> Seq.map Option.get |> List.ofSeq // todo: find a better way than filter
        capacityCoefficient = capacity // todo: make this real
        prioritize = fun items -> items |> List.sortBy getPrioritization
        getId = getId
        getDependencies = getDependencies
        getBucket = getBucket
        getCost = getRemainingWork
        getDeliverable = getDeliverableId
        }

let options(address:string option, pat) =
    jsOptions<Client.IVssRestClientOptions>(fun options ->
        match address, pat with
        | Some address, Some pat ->
            options.rootPath <- Some (Fable.Core.Case1 address)
            options.authTokenProvider <- Some { new Context.IAuthorizationTokenProvider with
                                                    member this.getAuthorizationHeader(forceRefresh: bool option): Fable.Core.JS.Promise<string> =
                                                        promise {
                                                            return "basic " + System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(":"+pat))
                                                            }
                                                        }
        | _ -> ()
        )


let queryContext compareDate (model: Model) : QueryContext =
    let serverRoot, projectName =
        match model.serverUrlOverride with
        | Some(Regex "(https://[^/]+/[^/]+/)([^/]+).*" [serverRoot; teamName]) ->
            Some serverRoot, Some teamName
        | _ -> None, None
    {
        options = options(model.serverUrlOverride, model.pat)
        projectScopedOptions = options(serverRoot |> Option.orElse model.serverUrlOverride, model.pat)
        serverRoot = serverRoot
        projectName = projectName
        explicitTeam = model.selectedTeam
        effectiveDate = System.DateTime.Today
        compareDate = compareDate
    }

let getWorkClient options = promise {
    return Client.exports.getClient<WorkItemTrackingClient.WorkItemTrackingRestClient>(unbox WorkItemTrackingClient.exports.WorkItemTrackingRestClient, options)
    }

// used for picking a selected team on the Settings screen
let getAllTeams (ctx: QueryContext) = promise {
    let coreClient = Client.exports.getClient<CoreClient.CoreRestClient>(unbox CoreClient.exports.CoreRestClient, ctx.projectScopedOptions)
    let! teams = coreClient.getTeams(ctx.projectName |> Option.defaultValue null, mine=false)
    return teams |> Seq.map (fun team -> team.name) |> List.ofSeq
    }

let getTeams (project:IProjectInfo) (ctx: QueryContext) = promise {
    match ctx.explicitTeam with
    | Some team ->
        return [team]
    | None ->
        let coreClient = Client.exports.getClient<CoreClient.CoreRestClient>(unbox CoreClient.exports.CoreRestClient, ctx.projectScopedOptions)
        let! teams = coreClient.getTeams(ctx.projectName |> Option.defaultValue null, mine=true)
        return teams |> Seq.map (fun team -> team.name) |> List.ofSeq
    }

let tryGetTeamCapacity (ctx: QueryContext) (teamName: string) = promise {
    let! projectService = sdk.getService<IProjectPageService>(CommonServiceIds.ProjectPageService)
    let! project = projectService.getProject()
    let teamCtx : Core.TeamContext = !! {|
        project = ctx.projectName |> Option.defaultValue project.Value.name
        projectId = ""
        team = teamName
        teamId = ""
        |}
    let client = Client.exports.getClient<WorkClient.WorkRestClient>(unbox WorkClient.exports.WorkRestClient, ctx.projectScopedOptions)
    let! iterations = client.getTeamIterations(teamCtx)
    let inScope (targetDate: System.DateTime) (iteration: Work.TeamSettingsIteration) =
        iteration.attributes.startDate <= targetDate && targetDate <= iteration.attributes.finishDate
    let capacityForIteration (iteration: Work.TeamSettingsIteration) =
        client.getCapacitiesWithIdentityRef(teamCtx, iteration.id)
    let! capacities = iterations |> Seq.filter (inScope ctx.effectiveDate) |> Seq.map capacityForIteration |> Promise.all
    let capacities = capacities |> Seq.flatten |> Array.ofSeq
    let! teamSettings = client.getTeamSettings(teamCtx)
    let capacityForDay (name:string) (dt: System.DateTime) =
        // capacity applies only to working team days, which doesn't include weekends and holidays. Individual days off are tracked separately.
        if teamSettings.workingDays.Contains dt.DayOfWeek then
            capacities |> Array.sumBy(fun c -> if c.teamMember.displayName = name then c.activities |> Seq.sumBy(fun act -> act.capacityPerDay) else 0.)
        else 0.
    return capacities, capacityForDay
    }

let tryGetCapacity (ctx: QueryContext) = promise {
    try
        let! projectService = sdk.getService<IProjectPageService>(CommonServiceIds.ProjectPageService)
        let! project = projectService.getProject()
        let! teams = getTeams project.Value ctx
        let! capacityByNameAndDate, capacities = promise {
            let! itemsAndWorkingDays = teams |> Seq.map (tryGetTeamCapacity ctx) |> Promise.Parallel
            let items, capacityByNameAndDate = itemsAndWorkingDays |> List.ofSeq |> List.unzip
            return capacityByNameAndDate, items |> Seq.flatten |> Array.ofSeq
            }

        let capacityForTeamMember (teamMemberName: string) =
            let capacitiesAndDaysOff =
                [
                for capacity in capacities do
                    if capacity.teamMember.displayName = teamMemberName then
                        (capacity.activities |> Seq.sumBy(fun activity -> activity.capacityPerDay)), capacity.daysOff
                ]
            let capacity = capacitiesAndDaysOff |> Seq.sumBy fst
            let daysOff = capacitiesAndDaysOff |> Seq.map snd |> Seq.flatten |> List.ofSeq
            let daysOffDescr =
                match daysOff
                    |> List.map (fun daysOff -> $"{daysOff.start.Date |> convertJSDateToString} to {daysOff.``end``.Date |> convertJSDateToString}") with
                | [] -> ""
                | daysOff -> $""", off {String.join ", " daysOff}"""
            {
                description = $"{teamMemberName}: {capacity} capacity{daysOffDescr}"
                capacity = capacity
                daysOff = daysOff
                capacityByDate = (fun dt -> capacityByNameAndDate |> List.sumBy (fun capacityFunc -> capacityFunc teamMemberName dt))
                }
        return capacityForTeamMember
    with _err ->
        printfn "tryGetCapacity failed: %A" _err
        return fun (teamMemberName:string) -> { description = (sprintf "Error: %A" _err); capacity = 0; daysOff = []; capacityByDate = thunk 0. }
    }

let getWorkItems (ctx: QueryContext) (wiql) = promise {
    let! capacityMap = tryGetCapacity ctx
    let! client = getWorkClient ctx.options
    let queryForDate (asOf: System.DateTime option) = promise {
        let query = jsOptions<Wiql>(fun o ->
            o.query <- wiql + match asOf with Some dt -> $""" asof '{dt.ToString("MM-dd-yyyy")}'""" | None -> ""
            )
        let! wiqlResult = client.queryByWiql(query)
        let! details = promise {
            if wiqlResult.workItems.Count = 0 then
                return []
            else
                let! details =
                    match asOf with
                    | Some asOf ->
                        client.getWorkItems(wiqlResult.workItems |> ResizeArray.map (fun ref -> ref.id), expand=WorkItemExpand.All, asOf = asOf)
                    | None ->
                        client.getWorkItems(wiqlResult.workItems |> ResizeArray.map (fun ref -> ref.id), expand=WorkItemExpand.All)
                    |> Promise.map List.ofSeq
                return details
            }
        return details;
        }

    let! current = queryForDate None
    let! past = match ctx.compareDate with None -> promise { return None } | dt -> queryForDate dt |> Promise.map Some

    let deliverableIds = (current @ (past |> Option.defaultValue []))|> List.map getDeliverableId |> List.distinct
    let! deliverables = promise {
        if deliverableIds.IsEmpty then
            return []
        else
            return! client.getWorkItems(deliverableIds |> List.filter (fun id -> id > 0) |> ResizeArray) |> Promise.map List.ofSeq
        }
    let deliverablesById = deliverables |> List.collect (fun wi -> [wi.id, wi]) |> Map.ofList

    let result startDate baseline details =
        let ctx = makeAssignmentContext (startDate, details, capacityMap)
        let asn, dropped = Extensions.assignments ctx details
        { workItems = details; deliverables = deliverablesById; capacityMap = capacityMap; effectiveDate = startDate; baselineDate = baseline; ctx = ctx; assignments = asn; dropped = dropped }

    return {
        QueryResult.current = result ctx.effectiveDate ctx.compareDate current
        past = past |> Option.map (fun past -> result ctx.compareDate.Value (Some ctx.effectiveDate) past)
        }
    }

let getProgressStatus (ctx: _ AssignmentContext) (asn: WorkItem Assignment) =
    match asn.underlying |> getDueDate with
    | Some dueDate ->
        let finishTime = ctx.startTime.AddDays(asn.startTime + asn.duration |> float)
        let percentOverdue =
            let dueDateInRealDays = (dueDate - ctx.startTime).TotalDays * 1.<realDay>
            ((asn.startTime + asn.duration) - dueDateInRealDays)/asn.duration |> min 1.
        if finishTime < dueDate then
            OK
        elif finishTime < dueDate.AddDays(1) then
            Warning percentOverdue
        else
            AtRisk percentOverdue
    | None -> OK

let addDependency (target: WorkItem Assignment) (dependency: WorkItem Assignment) (queryResult: QueryData) =
    queryResult

let saveChanges (model:Model) dispatch =
    promise {
        dispatch (SetHasUnsavedChanges false)
    } |> Promise.start

let init _ = { Model.fresh with pat = LocalStorage.PAT.read(); serverUrlOverride = LocalStorage.ServerUrlOverride.read(); selectedTeam = LocalStorage.Team.read() }
let update msg model =
    try
        match msg with
        | Message msg -> { model with userFacingMessage = msg |> Some }
        | Query op ->
            { model with query = receive op }
        | TeamsQuery op ->
            { model with teamsToChooseFrom = receive op }
        | SdkInitializationMsg op -> { model with userName = receive op; wiql = Extensions.LocalStorage.Wiql.read() }
        | SetWiql wiql ->
            LocalStorage.Wiql.write wiql
            { model with wiql = wiql }
        | SetPAT pat ->
            let pat = if pat.Trim().Length > 0 then Some (pat.Trim()) else None
            LocalStorage.PAT.write pat
            { model with pat = pat }
        | SetServerOverrideURL url ->
            let url = if url.Trim().Length > 0 then Some (url.Trim()) else None
            LocalStorage.ServerUrlOverride.write url
            { model with serverUrlOverride = url }
        | ToggleHelp ->
            match model.modalDialog with
            | Help::rest -> { model with modalDialog = rest }
            | rest -> { model with modalDialog = Help::rest }
        | ToggleSettings ->
            { model with showSettings = not model.showSettings }
        | ToggleDrilldown v ->
            { model with showDetail = v }
        | SetDisplayOrganization displayOrganization ->
            { model with displayOrganization = displayOrganization }
        | Select workItemAssignment ->
            // SELECT is a user action which has different effects in different modes (not sure if I love that idea, but for now...)
            // When we're selecting dependencies, it adds a new dependency, clears edit mode, and recomputes assignments, while preserving the currently-selected item.
            // Otherwise, it changes what the currently-selected item is (which affects detail display at the bottom of the screen).
            match model.editMode, workItemAssignment, model.query with
            | EditMode.SelectingDependency target, (AssignmentSelection asn), Ready (Ok queryResult) ->
                // update the source of truth
                let queryData = queryResult.current |> addDependency target asn
                let ctx = makeAssignmentContext (queryData.effectiveDate, queryData.workItems, queryData.capacityMap)
                let asn', dropped = Extensions.assignments ctx queryData.workItems
                // for UX reasons, preserve selection (up to underlying id)
                let selection' = asn' |> List.tryFind (fun a -> a.underlying.id = asn.underlying.id) |> Option.map (AssignmentSelection)
                { model with query = (Ready (Ok { queryResult with current = { queryData with ctx = ctx; assignments = asn'; dropped = dropped}})); editMode = EditMode.NotEditing; selectedItem = selection'; hasUnsavedChanges = true }
            | _ ->
                { model with selectedItem = workItemAssignment |> Some }
        | SetHasUnsavedChanges v ->
            { model with hasUnsavedChanges = v }
        | CancelDependencySelect ->
            { model with editMode = EditMode.NotEditing }
        | SelectDependency ->
            { model with editMode = match model.selectedItem with | Some (AssignmentSelection asn) -> EditMode.SelectingDependency asn | _ -> model.editMode }
        | SetTeamPickerFilter value' ->
            match model.modalDialog with
            | TeamPicker(msg)::rest ->
                { model with modalDialog = TeamPicker(value')::rest }
            | _ -> model
        | SetTeamPicker value' ->
            { model with selectedTeam = value' }
        | ToggleTeamPicker ->
            match model.modalDialog with
            | TeamPicker _::rest -> { model with modalDialog = rest }
            | rest -> { model with modalDialog = TeamPicker ""::rest }
        | ToggleShowPast v ->
            { model with showPast = v }
        | SetCompareDate dt ->
            { model with compareDate = Some dt }
    with err ->
        Browser.Dom.window.alert("Error: " + err.ToString())
        model


let viewAssignments (ctx: WorkItem AssignmentContext) (queryData: QueryData) (finishedData: QueryData option) org dispatch =
    let deliverables = queryData.deliverables
    let height = 20
    let bucketWidth = 200
    let width = 50
    let margin = 10.
    let headerHeight = height
    let timeRatio = (float width/1.<realDay>)
    let work = queryData.assignments
    let yCoord, (rows : (BucketId * int * (_ -> unit)) list) =
        match org with
        | ByBucket ->
            let rows = work |> List.map (fun w -> w.bucketId) |> List.distinct |> List.sort
            let yCoord (asn: _ Assignment) =
                match rows |> List.tryFindIndex ((=) asn.bucketId) with
                | Some ix ->
                    headerHeight + ix * height |> Some
                | None -> None
            yCoord, rows |> List.map (fun row -> row, 1, (fun _ -> (queryData.capacityMap row).description |> BucketSelection |> Select |> dispatch))
        | ByDeliverable ->
            let getDeliverableId w = w.underlying |> getDeliverableId
            let getDeliverable deliverableId =
                deliverables |> Map.tryFind deliverableId
            let rows =
                work
                |> List.map (fun wi ->
                                let parentId = getDeliverableId wi
                                let onClick dispatch =
                                    match deliverables |> Map.tryFind parentId with
                                    | Some deliverable ->
                                        WorkItemSelection deliverable |> Select |> dispatch
                                    | None -> ()
                                let height = work |> List.filter (fun wi -> getDeliverableId wi = parentId) |> List.map (fun wi -> wi.resourceRow) |> List.max
                                {| workItem = wi; parentId = parentId; height = height; onClick = onClick |})
                |> List.distinctBy (fun row -> row.parentId)
                |> List.sortBy (fun row -> row.parentId)
            let yCoord (asn: _ Assignment) =
                let parent = asn |> getDeliverableId
                match rows |> List.tryFindIndex (fun row -> row.parentId = parent) with
                | Some ix ->
                    let rowHeight = asn.resourceRow + (rows |> List.take ix |> List.sumBy (fun wi -> wi.height))
                    rowHeight * height |> Some
                | None -> None
            yCoord, rows |> List.map (fun row -> match deliverables |> Map.tryFind row.parentId with Some workItem -> (getTitle workItem, row.height, row.onClick) | None -> (row.parentId |> toString, 1, row.onClick))
    let msg (item: WorkItem) =
        getTitle item
    let date (asn: _ Assignment) msg =
        $"""{ctx.startTime.AddDays(asn.startTime |> float).ToString("MM/dd")} {msg}"""
    let preDroppedHeight = headerHeight + ((height + (work |> List.map (fun item -> yCoord item |> Option.defaultValue 0) |> List.append [0] |> List.max)))
    let stageHeight = preDroppedHeight + (queryData.dropped.Length * height)
    let stageWidth = (match work with [] -> 0. | _ -> ((work |> List.map (fun w -> w.startTime + w.duration)) |> List.max) * timeRatio + (float width) + 0.)
    let startLeft = bucketWidth + 20
    let startTime, paddingTime =
        match queryData.baselineDate with
        | Some baseline when baseline < ctx.startTime -> baseline, (ctx.startTime - baseline).TotalDays * 1.<realDay>
        | _ -> ctx.startTime, 0.<realDay>
    Html.div [
        prop.className "stage"
        prop.style [
            style.width (int stageWidth)
            style.height stageHeight
            ]
        prop.children [
            let maxDaySpan = paddingTime + if work.IsEmpty then 0.<realDay> else (work |> List.map (fun wi -> (wi.startTime + wi.duration)) |> List.max)
            for x in (0.<realDay>)..1.<realDay>..(maxDaySpan) do
                let day = startTime.AddDays(x |> float)
                let startX = (startLeft + (x * timeRatio |> int))
                Html.div [
                    prop.className "header"
                    prop.style [
                        style.top 0
                        style.left startX
                        style.height stageHeight
                        style.borderLeft(2, borderStyle.solid, color.black)
                        ]
                    prop.text $"""{day.ToString("M/d")}"""
                    ]
                let verticalLineAt (xPos: int) =
                    Html.div [
                        prop.className "divider"
                        prop.style [
                            style.top 0
                            style.left xPos
                            style.height stageHeight
                            style.borderLeft(2, borderStyle.solid, color.black)
                            ]
                        ]
                verticalLineAt startX
                match day.DayOfWeek |> int with
                | 6 | 0 -> // Saturday, Sunday
                    // draw some blue shade for weekends to visually distinguish them
                    Html.div [
                        prop.className "divider"
                        prop.style [
                            style.top 0
                            style.left startX
                            style.height stageHeight
                            style.width width
                            style.opacity 0.22
                            style.backgroundColor.blue
                            ]
                        ]
                | dayOfWeek ->
                    ()
            let mutable rowTop = 0
            for ix, (row, rowHeight, onclick) in rows |> List.mapi tup2 do
                Html.input [
                    prop.className "bucket"
                    prop.style [
                        style.top (headerHeight + rowTop * height)
                        style.left 0
                        style.width bucketWidth
                        ]
                    prop.value row
                    prop.readOnly true
                    prop.onClick (fun _ -> onclick dispatch)
                    ]
                rowTop <- rowHeight + rowTop
            for asn in work do
                let item = asn.underlying
                Html.input [
                    prop.className "item"
                    prop.style [
                        match yCoord asn with
                        | Some y -> style.top y
                        | None -> ()
                        style.left (((paddingTime + asn.startTime) * timeRatio |> int) + startLeft)
                        style.width (asn.duration * timeRatio - margin |> int |> max 0)
                        match asn |> getProgressStatus ctx with
                        | AtRisk percentOverdue ->
                            let percent = (100. - percentOverdue * 100.) |> int
                            style.backgroundImage $"linear-gradient(to right, blue, blue {percent}%%, red {percent}%%, red 100%%)"
                        | Warning percentOverdue ->
                            let percent = (100. - percentOverdue * 100.) |> int
                            style.backgroundImage $"linear-gradient(to right, blue, blue {percent}%%, #FEBE10 {percent}%%, #FEBE10 100%%)"
                        | _ -> ()
                        ]
                    prop.value (msg item)
                    prop.readOnly true
                    prop.onClick (thunk1 dispatch (Select (AssignmentSelection asn)))
                    ]
            match finishedData with
            | None -> ()
            | Some { assignments = finished } ->
                for fin in finished do
                    // show recently-finished items from the past in their original location so we can see recent progress
                    let isFinished =
                        queryData.workItems |> List.exists (fun wi -> wi.id = fin.underlying.id && wi |> getRemainingWork = 0.<dayCost>)
                    match yCoord fin with
                    | Some y when isFinished ->
                        let item = fin.underlying
                        Html.input [
                            prop.className ["item";"finished"]
                            prop.style [
                                match yCoord fin with
                                | Some y -> style.top y
                                | None -> ()
                                style.left (((fin.startTime) * timeRatio |> int) + startLeft)
                                style.width (fin.duration * timeRatio - margin |> int)
                                ]
                            prop.value (msg item)
                            prop.readOnly true
                            prop.onClick (thunk1 dispatch (Select (AssignmentSelection fin)))
                            ]
                    | _ -> ()
            for ix, item in queryData.dropped |> List.mapi tup2 do
                Html.span [
                    prop.className "dropped"
                    prop.style [
                        style.top (preDroppedHeight + (height * ix))
                        style.left startLeft
                        ]
                    prop.onClick (thunk1 dispatch (Select (WorkItemSelection item)))
                    prop.text ("Won't be done: " + msg item)
                    ]
            ]
        ]


let viewDetails (model: Model) (ctx: _ AssignmentContext) (item: WorkItem) (asn: _ Assignment option) linkBase = [
    let whom = getOwner item
    let typ = match item.fields["System.WorkItemType"] with | Some typ -> unbox<string> typ | None -> "None"
    Html.div [
        prop.key $"WorkItem{item.id}"
        prop.children [
                let link (indent: int) (msg: string) href =
                    Html.a [
                        prop.text msg
                        prop.style [style.marginLeft indent]
                        prop.href href
                        ]
                let emit (indent: int) (msg: string) =
                    Html.div [
                        prop.text msg
                        prop.style [style.marginLeft indent]
                        ]
                let href =
                    match linkBase with
                    | Some linkBase -> $"{linkBase}/_workitems/edit/{item.id}"
                    | None -> $"../../../_workitems/edit/{item.id}"
                link 0 $"""{item.id} P{getPriority item |> int} {typ}: { whom } {item.fields["System.Title"]}""" href
                let due = item |> getDueDate
                let ETA, overdueBy =
                    match due, asn with
                    | Some due, Some asn ->
                        let eta = ctx.startTime.AddDays((asn.startTime + asn.duration)/1.<realDay>)
                        if eta > due then
                            eta |> Some, Some (eta - due).TotalDays
                        else
                            eta |> Some, None
                    | None, Some asn ->
                        ctx.startTime.AddDays((asn.startTime + asn.duration)/1.<realDay>) |> Some, None
                    | _ -> None, None
                let dateToString label = function Some (v: System.DateTime) -> $"""{label}: {convertJSDateToString v}""" | None -> $"{label}: N/A"
                emit 0 $"""{dateToString "Due" due} {dateToString "ETA" ETA} [{getState item}, {getRemainingWork item} remaining] {match overdueBy with Some v -> $"(overdue by %.2f{v} days)" | None -> "(on time)"}"""
                if model.showDetail then
                    emit 0 "-----"
                    emit 0 "Fields:"
                    let rec unpack margin src =
                        [
                        for k in Fable.Core.JS.Constructors.Object.keys src do
                            let value = jsLookup src k
                            match jsTypeof value, value with
                            | "object", Some value ->
                                if isJSDate value then
                                    emit margin $"{k}: {value}"
                                else
                                    emit margin $"{k}:"
                                    yield! unpack (margin+20) value
                            | _else ->
                                emit margin $"{k}: {value}"
                            ]
                    yield! unpack 20 item.fields
                    emit 0 "Relations:"
                    match item.relations |> unbox<WorkItemRelation array option> with
                    | Some relations ->
                        for rel in relations do
                            emit 20 $"{rel.rel}: {rel.url}"
                            match rel.attributes |> unbox with
                            | Some attr ->
                                yield! unpack 40 attr
                            | None -> ()
                    | None -> emit 20 "No relations"
            ]
        ]
    ]

let viewSelected (model:Model) (ctx: _ AssignmentContext) linkBase dispatch =
    let item = model.selectedItem
    match item with
    | Some (BucketSelection txt) -> Html.div txt
    | Some (AssignmentSelection item) ->
        Html.div [
            let date days =
                $"""{ctx.startTime.AddDays(days |> float).ToString("M/d")}"""
            let dateRange = $"{item.startTime |> date} to {(item.startTime + item.duration) |> date}"
            Html.div [Html.text dateRange]
            Html.input [prop.value (getTitle item.underlying); prop.className "selected"; prop.readOnly true; prop.disabled true]
            Html.div [
                Html.br []
                yield! viewDetails model ctx item.underlying (Some item) linkBase
                ]
            ]
    | Some (WorkItemSelection item) ->
        Html.div [
            Html.div [
                Html.br []
                yield! viewDetails model ctx item None linkBase
                ]
            ]
    | None -> Html.div []

let viewTeamPicker (msg: string) (model:Model) dispatch =
    Html.div [
        prop.className "teamPicker"
        prop.children [
            match model.teamsToChooseFrom with
            | NotStarted | InProgress ->
                Html.div "Please wait while we retrieve the list of teams..."
            | Ready (Error err) ->
                Html.div $"Something went wrong while retrieving the list of teams, sorry. Please check that your serverOverrideUrl and PAT are both valid. Error: {err}"
            | Ready (Ok teams) ->
                Html.div [
                    Html.text "Optional: Choose which team to use for capacity picking, etc. This can help avoid \"Won't be done\" errors if you have work items on a team that you don't own in ADO."
                    ]
                Html.div [
                    Html.input [prop.value msg; prop.placeholder "Enter search text, e.g. SD365CPI"; prop.onChange (SetTeamPickerFilter >> dispatch)]
                    Html.div [prop.text $"""Selected: {match model.selectedTeam with Some v -> v.ToString() | None -> "None"}"""]
                    for option in teams |> List.filter (fun option -> option.StartsWith(msg, System.StringComparison.InvariantCultureIgnoreCase)) do
                        Html.div [
                            prop.text option
                            if model.selectedTeam = Some option then
                                prop.className "selected"
                            prop.onClick (fun _ -> dispatch (SetTeamPicker (if model.selectedTeam = Some option then None else Some option)))]
                    ]
                Html.button [prop.text "OK"; prop.onClick(fun _ -> dispatch ToggleTeamPicker)]
            ]
        ]

let teamPickerDiv (model: Model) dispatch =
    let pickTeams _ =
        dispatch ToggleTeamPicker
        match model.teamsToChooseFrom with
        | Ready (Ok _) -> ()
        | _ ->
            asyncOperation dispatch TeamsQuery (fun _ -> promise {
                return! getAllTeams (queryContext None model)
            }) |> Promise.start
    Html.div [
        Html.span $"""Team override: {match model.selectedTeam with Some v -> v.ToString() | _ -> "None"}"""
        Html.button [prop.text "Change team"; prop.onClick pickTeams]
        ]

let viewHelp (model:Model) dispatch =
    Html.div [
        prop.className "help"
        prop.children [
            Html.div [
                Html.text "Helpful tip: "
                Html.text "To set dependencies, select an item and press Ctrl-D or hit the Add Dependencies button, and then select the item it depends on. Hit Ctrl-S or the Save button to save."
                ]
            Html.div [
                Html.span [prop.text "For cross-tenant access to OSGS, get a PAT from "]
                Html.a [prop.href "https://dev.azure.com/microsoft/_usersSettings/tokens"; prop.text "https://dev.azure.com/microsoft/_usersSettings/tokens"]
                Html.span [prop.text " with read permission to Work Items, Project and Team, and User Profile, and with write permission if you want to save your changes back to OSGS"]
                ]
            Html.div [
                Html.input [prop.value (defaultArg model.serverUrlOverride ""); prop.className "serverUrlOverride"; prop.placeholder "Server URL e.g. https://dev.azure.com/microsoft/OSGS/"; prop.onChange (SetServerOverrideURL >> dispatch)]
                Html.input [prop.value (defaultArg model.pat ""); prop.className "PAT"; prop.placeholder "Personal access token with work scope, generated at e.g. https://dev.azure.com/microsoft/_usersSettings/tokens"; prop.onChange (SetPAT >> dispatch)]
                ]
            teamPickerDiv model dispatch
            Html.button [prop.text "OK"; prop.onClick(fun _ -> dispatch ToggleHelp)]
            ]
        ]

let viewError errMsg = Html.div [prop.text $"Error: {errMsg}"; prop.className "error"]

let viewApp (model: Model) dispatch =
    let operation opMsg impl _ =
        asyncOperation dispatch opMsg impl |> Promise.start

    Html.div [
        let executeQuery compareDate _ = operation Query (thunk2 getWorkItems (queryContext compareDate model) model.wiql)()

        match model.userName with
        | NotStarted | InProgress ->
            Html.div [prop.text $"Initializing..."]
        | Ready(Error errMsg) ->
            Html.div [prop.text $"Initialization error: {errMsg}"; prop.className "error"]
        | Ready(Ok userName) ->
            Html.div [
                Html.text $"Hello, {userName}"
                Html.a [prop.text "Settings"; prop.className "menuItem"; prop.href "."; prop.onClick(fun ev -> ev.preventDefault(); dispatch ToggleSettings)]
                Html.a [prop.text "Help"; prop.className "menuItem"; prop.href "."; prop.onClick(fun ev -> ev.preventDefault(); dispatch ToggleHelp)]
                ]
            if model.showSettings then
                Html.div [
                    Html.input [prop.valueOrDefault (defaultArg model.serverUrlOverride ""); prop.className "serverUrlOverride"; prop.placeholder "Server URL e.g. https://dev.azure.com/microsoft/OSGS/"; prop.onChange (SetServerOverrideURL >> dispatch)]
                    Html.input [prop.valueOrDefault (defaultArg model.pat ""); prop.className "PAT"; prop.placeholder "Personal access token with work scope, generated at e.g. https://dev.azure.com/microsoft/_usersSettings/tokens"; prop.onChange (SetPAT >> dispatch)]
                    teamPickerDiv model dispatch
                    Html.div [
                        let id = "chkShowDetail"
                        Html.input [prop.type'.checkbox; prop.id id; prop.isChecked model.showDetail; prop.onChange (ToggleDrilldown >> dispatch)]
                        Html.label [prop.htmlFor id; prop.text "Show detailed fields for selected item"]
                        ]
                    ]

            Html.div [prop.text (model.userFacingMessage |> Option.defaultValue "")]
            Html.textarea [
                prop.className "wiql"
                prop.valueOrDefault model.wiql
                prop.autoFocus true
                prop.placeholder "Enter a WIQL query"
                prop.onKeyDown (fun e -> if e.code = "Enter" then executeQuery model.compareDate ())
                prop.onChange(fun e -> e |> SetWiql |> dispatch)
                ]
            Html.button [prop.text "Get work items"; prop.onClick (executeQuery model.compareDate)]

            match model.query with
            | NotStarted -> ()
            | InProgress ->
                Html.div [prop.text "Fetching..."]
            | Ready(Error err) ->
                viewError err
            | Ready(Ok queryResult) ->
                let queryData, finishedData =
                    match queryResult with
                    | { past = Some data } when model.showPast -> data, None
                    | _ -> queryResult.current, queryResult.past
                let ctx = queryData.ctx
                let dest = match model.displayOrganization with | ByBucket -> ByDeliverable | ByDeliverable -> ByBucket
                Html.button [prop.text $"Switch to {dest} view"; prop.onClick (thunk1 dispatch (SetDisplayOrganization dest))]
                match model.selectedItem with
                | Some (AssignmentSelection _) ->
                    Html.button [prop.text "Add dependency"; prop.disabled (model.editMode <> NotEditing); prop.onClick (thunk1 dispatch SelectDependency)]
                | _ -> ()
                class' Html.span "compareWithPast" [
                    let id = "chkCompareWithPast"
                    Html.input [prop.type'.checkbox; prop.id id; prop.isChecked model.showPast; prop.onChange (ToggleShowPast >> dispatch)]
                    Html.label [prop.htmlFor id; prop.text "Show past"]
                    let onDateChange (dt:System.DateTime) =
                        match queryResult.past with
                        | Some d when d.effectiveDate = dt -> ()
                        | _ ->
                            SetCompareDate dt |> dispatch // asynchronously update the UI
                            executeQuery (Some dt) () // because async update hasn't occurred yet, pass in dt directly
                    SimpleDateInput(model.compareDate, model.showPast, onDateChange)
                    ]
                if model.hasUnsavedChanges then
                    Html.button [prop.text "Save"; prop.onClick (fun _ -> saveChanges model dispatch)]
                viewAssignments ctx queryData finishedData model.displayOrganization dispatch
                viewSelected model ctx model.serverUrlOverride dispatch
        ]

let view (model:Model) dispatch =
    match model.modalDialog with
    | TeamPicker msg::_ ->
        viewTeamPicker msg model dispatch
    | Help::_ ->
        viewHelp model dispatch
    | _ ->
        viewApp model dispatch

let mutable lastError = ""
let mutable lastErrorTime = None

let showError msg dispatch =
    // crude debouncer.
    // todo: use a better, more concise debouncer.
    let longEnough =
        match lastErrorTime with
        | Some last -> (last - System.DateTimeOffset.UtcNow).Seconds > 10
        | None -> true
    if msg <> lastError && longEnough then
        Browser.Dom.window.alert ("Unhandled Exception: " + msg)
    lastError <- msg
    lastErrorTime <- Some System.DateTimeOffset.Now
    Message $"Error: {msg}" |> dispatch


Program.mkSimple init update view
|> Program.withSubscription(fun m -> Cmd.ofSub(fun dispatch ->
    Browser.Dom.window.onerror <-
        fun msg ->
            if msg.ToString().Contains "SocketProtocolError" = false then
                showError (msg.ToString()) dispatch
    Browser.Dom.window.addEventListener("unhandledrejection", fun e ->
        let msg = e.ToString()
        showError msg dispatch
        )
    Browser.Dom.window.addEventListener("keydown", fun e ->
        if e?key = "d" && e?ctrlKey then
            dispatch (SelectDependency)
            e.preventDefault()
        elif e?key = "Escape" then
            dispatch (CancelDependencySelect)
            e.preventDefault()
        )

    let initialize() = promise {
        do! sdk.init()
        return sdk.getUser().name |> Ok
        }

    asyncOperation dispatch SdkInitializationMsg initializeSdk
    |> Promise.start
    ))
|> Program.withReactBatched "feliz-app"
|> Program.run
