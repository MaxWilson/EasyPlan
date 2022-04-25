// ts2fable 0.7.1
module rec Dashboard
open System
open Fable.Core
open Fable.Core.JS

/// Model of a Dashboard.
type [<AllowNullLiteral>] Dashboard =
    abstract _links: obj option with get, set
    /// Description of the dashboard.
    abstract description: string with get, set
    /// Server defined version tracking value, used for edit collision detection.
    abstract eTag: string with get, set
    /// ID of the Dashboard. Provided by service at creation time.
    abstract id: string with get, set
    /// Name of the Dashboard.
    abstract name: string with get, set
    /// ID of the Owner for a dashboard. For any legacy dashboards, this would be the unique identifier for the team associated with the dashboard.
    abstract ownerId: string with get, set
    /// Position of the dashboard, within a dashboard group. If unset at creation time, position is decided by the service.
    abstract position: float with get, set
    /// Interval for client to automatically refresh the dashboard. Expressed in minutes.
    abstract refreshInterval: float with get, set
    abstract url: string with get, set
    /// The set of Widgets on the dashboard.
    abstract widgets: ResizeArray<Widget> with get, set

/// Describes a list of dashboards associated to an owner. Currently, teams own dashboard groups.
type [<AllowNullLiteral>] DashboardGroup =
    abstract _links: obj option with get, set
    /// A list of Dashboards held by the Dashboard Group
    abstract dashboardEntries: ResizeArray<DashboardGroupEntry> with get, set
    /// Deprecated: The old permission model describing the level of permissions for the current team. Pre-M125.
    abstract permission: GroupMemberPermission with get, set
    /// A permissions bit mask describing the security permissions of the current team for dashboards. When this permission is the value None, use GroupMemberPermission. Permissions are evaluated based on the presence of a value other than None, else the GroupMemberPermission will be saved.
    abstract teamDashboardPermission: TeamDashboardPermission with get, set
    abstract url: string with get, set

/// Dashboard group entry, wrapping around Dashboard (needed?)
type [<AllowNullLiteral>] DashboardGroupEntry =
    inherit Dashboard

/// Response from RestAPI when saving and editing DashboardGroupEntry
type [<AllowNullLiteral>] DashboardGroupEntryResponse =
    inherit DashboardGroupEntry

type [<AllowNullLiteral>] DashboardResponse =
    inherit DashboardGroupEntry

type [<RequireQualifiedAccess>] DashboardScope =
    | Collection_User = 0
    | Project_Team = 1

type [<RequireQualifiedAccess>] GroupMemberPermission =
    | None = 0
    | Edit = 1
    | Manage = 2
    | ManagePermissions = 3

/// Lightbox configuration
type [<AllowNullLiteral>] LightboxOptions =
    /// Height of desired lightbox, in pixels
    abstract height: float with get, set
    /// True to allow lightbox resizing, false to disallow lightbox resizing, defaults to false.
    abstract resizable: bool with get, set
    /// Width of desired lightbox, in pixels
    abstract width: float with get, set

/// versioning for an artifact as described at: http://semver.org/, of the form major.minor.patch.
type [<AllowNullLiteral>] SemanticVersion =
    /// Major version when you make incompatible API changes
    abstract major: float with get, set
    /// Minor version when you add functionality in a backwards-compatible manner
    abstract minor: float with get, set
    /// Patch version when you make backwards-compatible bug fixes
    abstract patch: float with get, set

type [<RequireQualifiedAccess>] TeamDashboardPermission =
    | None = 0
    | Read = 1
    | Create = 2
    | Edit = 4
    | Delete = 8
    | ManagePermissions = 16

/// Widget data
type [<AllowNullLiteral>] Widget =
    abstract _links: obj option with get, set
    /// Refers to the allowed sizes for the widget. This gets populated when user wants to configure the widget
    abstract allowedSizes: ResizeArray<WidgetSize> with get, set
    /// Read-Only Property from Dashboard Service. Indicates if settings are blocked for the current user.
    abstract areSettingsBlockedForUser: bool with get, set
    /// Refers to unique identifier of a feature artifact. Used for pinning+unpinning a specific artifact.
    abstract artifactId: string with get, set
    abstract configurationContributionId: string with get, set
    abstract configurationContributionRelativeId: string with get, set
    abstract contentUri: string with get, set
    /// The id of the underlying contribution defining the supplied Widget Configuration.
    abstract contributionId: string with get, set
    /// Optional partial dashboard content, to support exchanging dashboard-level version ETag for widget-level APIs
    abstract dashboard: Dashboard with get, set
    abstract eTag: string with get, set
    abstract id: string with get, set
    abstract isEnabled: bool with get, set
    abstract isNameConfigurable: bool with get, set
    abstract lightboxOptions: LightboxOptions with get, set
    abstract loadingImageUrl: string with get, set
    abstract name: string with get, set
    abstract position: WidgetPosition with get, set
    abstract settings: string with get, set
    abstract settingsVersion: SemanticVersion with get, set
    abstract size: WidgetSize with get, set
    abstract typeId: string with get, set
    abstract url: string with get, set

/// Contribution based information describing Dashboard Widgets.
type [<AllowNullLiteral>] WidgetMetadata =
    /// Sizes supported by the Widget.
    abstract allowedSizes: ResizeArray<WidgetSize> with get, set
    /// Opt-in boolean that indicates if the widget requires the Analytics Service to function. Widgets requiring the analytics service are hidden from the catalog if the Analytics Service is not available.
    abstract analyticsServiceRequired: bool with get, set
    /// Resource for an icon in the widget catalog.
    abstract catalogIconUrl: string with get, set
    /// Opt-in URL string pointing at widget information. Defaults to extension marketplace URL if omitted
    abstract catalogInfoUrl: string with get, set
    /// The id of the underlying contribution defining the supplied Widget custom configuration UI. Null if custom configuration UI is not available.
    abstract configurationContributionId: string with get, set
    /// The relative id of the underlying contribution defining the supplied Widget custom configuration UI. Null if custom configuration UI is not available.
    abstract configurationContributionRelativeId: string with get, set
    /// Indicates if the widget requires configuration before being added to dashboard.
    abstract configurationRequired: bool with get, set
    /// Uri for the widget content to be loaded from .
    abstract contentUri: string with get, set
    /// The id of the underlying contribution defining the supplied Widget.
    abstract contributionId: string with get, set
    /// Optional default settings to be copied into widget settings.
    abstract defaultSettings: string with get, set
    /// Summary information describing the widget.
    abstract description: string with get, set
    /// Widgets can be disabled by the app store.  We'll need to gracefully handle for: - persistence (Allow) - Requests (Tag as disabled, and provide context)
    abstract isEnabled: bool with get, set
    /// Opt-out boolean that indicates if the widget supports widget name/title configuration. Widgets ignoring the name should set it to false in the manifest.
    abstract isNameConfigurable: bool with get, set
    /// Opt-out boolean indicating if the widget is hidden from the catalog. Commonly, this is used to allow developers to disable creation of a deprecated widget. A widget must have a functional default state, or have a configuration experience, in order to be visible from the catalog.
    abstract isVisibleFromCatalog: bool with get, set
    /// Keywords associated with this widget, non-filterable and invisible
    abstract keywords: ResizeArray<string> with get, set
    /// Opt-in properties for customizing widget presentation in a "lightbox" dialog.
    abstract lightboxOptions: LightboxOptions with get, set
    /// Resource for a loading placeholder image on dashboard
    abstract loadingImageUrl: string with get, set
    /// User facing name of the widget type. Each widget must use a unique value here.
    abstract name: string with get, set
    /// Publisher Name of this kind of widget.
    abstract publisherName: string with get, set
    /// Data contract required for the widget to function and to work in its container.
    abstract supportedScopes: ResizeArray<WidgetScope> with get, set
    /// Tags associated with this widget, visible on each widget and filterable.
    abstract tags: ResizeArray<string> with get, set
    /// Contribution target IDs
    abstract targets: ResizeArray<string> with get, set
    /// Deprecated: locally unique developer-facing id of this kind of widget. ContributionId provides a globally unique identifier for widget types.
    abstract typeId: string with get, set

type [<AllowNullLiteral>] WidgetMetadataResponse =
    abstract uri: string with get, set
    abstract widgetMetadata: WidgetMetadata with get, set

type [<AllowNullLiteral>] WidgetPosition =
    abstract column: float with get, set
    abstract row: float with get, set

/// Response from RestAPI when saving and editing Widget
type [<AllowNullLiteral>] WidgetResponse =
    inherit Widget

type [<RequireQualifiedAccess>] WidgetScope =
    | Collection_User = 0
    | Project_Team = 1

type [<AllowNullLiteral>] WidgetSize =
    /// The Width of the widget, expressed in dashboard grid columns.
    abstract columnSpan: float with get, set
    /// The height of the widget, expressed in dashboard grid rows.
    abstract rowSpan: float with get, set

/// Wrapper class to support HTTP header generation using CreateResponse, ClientHeaderParameter and ClientResponseType in WidgetV2Controller
type [<AllowNullLiteral>] WidgetsVersionedList =
    abstract eTag: ResizeArray<string> with get, set
    abstract widgets: ResizeArray<Widget> with get, set

type [<AllowNullLiteral>] WidgetTypesResponse =
    abstract _links: obj option with get, set
    abstract uri: string with get, set
    abstract widgetTypes: ResizeArray<WidgetMetadata> with get, set
