// ts2fable 0.7.1
module rec DashboardClient
open System
open Fable.Core
open Fable.Core.JS


module DashboardClient =
    module TfsCore = ___Core_Core
    module Dashboard = ___Dashboard_Dashboard
    type IVssRestClientOptions = _____Common_Context.IVssRestClientOptions
    type RestClientBase = _____Common_RestClientBase.RestClientBase

    type [<AllowNullLiteral>] IExports =
        abstract DashboardRestClient: DashboardRestClientStatic

    type [<AllowNullLiteral>] DashboardRestClient =
        inherit RestClientBase
        /// <summary>Create the supplied dashboard.</summary>
        /// <param name="dashboard">- The initial state of the dashboard</param>
        /// <param name="teamContext">- The team context for the operation</param>
        abstract createDashboard: dashboard: Dashboard.Dashboard * teamContext: TfsCore.TeamContext -> Promise<Dashboard.Dashboard>
        /// <summary>Delete a dashboard given its ID. This also deletes the widgets associated with this dashboard.</summary>
        /// <param name="teamContext">- The team context for the operation</param>
        /// <param name="dashboardId">- ID of the dashboard to delete.</param>
        abstract deleteDashboard: teamContext: TfsCore.TeamContext * dashboardId: string -> Promise<unit>
        /// <summary>Get a dashboard by its ID.</summary>
        /// <param name="teamContext">- The team context for the operation</param>
        /// <param name="dashboardId">-</param>
        abstract getDashboard: teamContext: TfsCore.TeamContext * dashboardId: string -> Promise<Dashboard.Dashboard>
        /// <summary>Get a list of dashboards.</summary>
        /// <param name="teamContext">- The team context for the operation</param>
        abstract getDashboards: teamContext: TfsCore.TeamContext -> Promise<Dashboard.DashboardGroup>
        /// <summary>Replace configuration for the specified dashboard. Replaces Widget list on Dashboard, only if property is supplied.</summary>
        /// <param name="dashboard">- The Configuration of the dashboard to replace.</param>
        /// <param name="teamContext">- The team context for the operation</param>
        /// <param name="dashboardId">- ID of the dashboard to replace.</param>
        abstract replaceDashboard: dashboard: Dashboard.Dashboard * teamContext: TfsCore.TeamContext * dashboardId: string -> Promise<Dashboard.Dashboard>
        /// <summary>Update the name and position of dashboards in the supplied group, and remove omitted dashboards. Does not modify dashboard content.</summary>
        /// <param name="group">-</param>
        /// <param name="teamContext">- The team context for the operation</param>
        abstract replaceDashboards: group: Dashboard.DashboardGroup * teamContext: TfsCore.TeamContext -> Promise<Dashboard.DashboardGroup>
        /// <summary>Create a widget on the specified dashboard.</summary>
        /// <param name="widget">- State of the widget to add</param>
        /// <param name="teamContext">- The team context for the operation</param>
        /// <param name="dashboardId">- ID of dashboard the widget will be added to.</param>
        abstract createWidget: widget: Dashboard.Widget * teamContext: TfsCore.TeamContext * dashboardId: string -> Promise<Dashboard.Widget>
        /// <summary>Delete the specified widget.</summary>
        /// <param name="teamContext">- The team context for the operation</param>
        /// <param name="dashboardId">- ID of the dashboard containing the widget.</param>
        /// <param name="widgetId">- ID of the widget to update.</param>
        abstract deleteWidget: teamContext: TfsCore.TeamContext * dashboardId: string * widgetId: string -> Promise<Dashboard.Dashboard>
        /// <summary>Get the current state of the specified widget.</summary>
        /// <param name="teamContext">- The team context for the operation</param>
        /// <param name="dashboardId">- ID of the dashboard containing the widget.</param>
        /// <param name="widgetId">- ID of the widget to read.</param>
        abstract getWidget: teamContext: TfsCore.TeamContext * dashboardId: string * widgetId: string -> Promise<Dashboard.Widget>
        /// <summary>Override the  state of the specified widget.</summary>
        /// <param name="widget">- State to be written for the widget.</param>
        /// <param name="teamContext">- The team context for the operation</param>
        /// <param name="dashboardId">- ID of the dashboard containing the widget.</param>
        /// <param name="widgetId">- ID of the widget to update.</param>
        abstract replaceWidget: widget: Dashboard.Widget * teamContext: TfsCore.TeamContext * dashboardId: string * widgetId: string -> Promise<Dashboard.Widget>
        /// <summary>Perform a partial update of the specified widget.</summary>
        /// <param name="widget">- Description of the widget changes to apply. All non-null fields will be replaced.</param>
        /// <param name="teamContext">- The team context for the operation</param>
        /// <param name="dashboardId">- ID of the dashboard containing the widget.</param>
        /// <param name="widgetId">- ID of the widget to update.</param>
        abstract updateWidget: widget: Dashboard.Widget * teamContext: TfsCore.TeamContext * dashboardId: string * widgetId: string -> Promise<Dashboard.Widget>
        /// <summary>Get the widget metadata satisfying the specified contribution ID.</summary>
        /// <param name="contributionId">- The ID of Contribution for the Widget</param>
        /// <param name="project">- Project ID or project name</param>
        abstract getWidgetMetadata: contributionId: string * ?project: string -> Promise<Dashboard.WidgetMetadataResponse>
        /// <summary>Get all available widget metadata in alphabetical order, including widgets marked with isVisibleFromCatalog == false.</summary>
        /// <param name="scope">-</param>
        /// <param name="project">- Project ID or project name</param>
        abstract getWidgetTypes: scope: Dashboard.WidgetScope * ?project: string -> Promise<Dashboard.WidgetTypesResponse>

    type [<AllowNullLiteral>] DashboardRestClientStatic =
        [<Emit "new $0($1...)">] abstract Create: options: IVssRestClientOptions -> DashboardRestClient
        abstract RESOURCE_AREA_ID: string
