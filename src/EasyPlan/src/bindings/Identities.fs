// ts2fable 0.7.1
module rec Identities
open System
open Fable.Core
open Fable.Core.JS

/// Container class for changed identities
type [<AllowNullLiteral>] ChangedIdentities =
    /// Changed Identities
    abstract identities: ResizeArray<Identity> with get, set
    /// More data available, set to true if pagesize is specified.
    abstract moreData: bool with get, set
    /// Last Identity SequenceId
    abstract sequenceContext: ChangedIdentitiesContext with get, set

/// Context class for changed identities
type [<AllowNullLiteral>] ChangedIdentitiesContext =
    /// Last Group SequenceId
    abstract groupSequenceId: float with get, set
    /// Last Identity SequenceId
    abstract identitySequenceId: float with get, set
    /// Last Group OrganizationIdentitySequenceId
    abstract organizationIdentitySequenceId: float with get, set
    /// Page size
    abstract pageSize: float with get, set

type [<AllowNullLiteral>] CreateScopeInfo =
    abstract adminGroupDescription: string with get, set
    abstract adminGroupName: string with get, set
    abstract creatorId: string with get, set
    abstract parentScopeId: string with get, set
    abstract scopeName: string with get, set
    abstract scopeType: GroupScopeType with get, set

type [<AllowNullLiteral>] FrameworkIdentityInfo =
    abstract displayName: string with get, set
    abstract identifier: string with get, set
    abstract identityType: FrameworkIdentityType with get, set
    abstract role: string with get, set

type [<RequireQualifiedAccess>] FrameworkIdentityType =
    | None = 0
    | ServiceIdentity = 1
    | AggregateIdentity = 2
    | ImportedIdentity = 3

type [<AllowNullLiteral>] GroupMembership =
    abstract active: bool with get, set
    abstract descriptor: IdentityDescriptor with get, set
    abstract id: string with get, set
    abstract queriedId: string with get, set

type [<RequireQualifiedAccess>] GroupScopeType =
    | Generic = 0
    | ServiceHost = 1
    | TeamProject = 2

type [<AllowNullLiteral>] Identity =
    inherit IdentityBase

/// Base Identity class to allow "trimmed" identity class in the GetConnectionData API Makes sure that on-the-wire representations of the derived classes are compatible with each other (e.g. Server responds with PublicIdentity object while client deserializes it as Identity object) Derived classes should not have additional [DataMember] properties
type [<AllowNullLiteral>] IdentityBase =
    /// The custom display name for the identity (if any). Setting this property to an empty string will clear the existing custom display name. Setting this property to null will not affect the existing persisted value (since null values do not get sent over the wire or to the database)
    abstract customDisplayName: string with get, set
    abstract descriptor: IdentityDescriptor with get, set
    abstract id: string with get, set
    abstract isActive: bool with get, set
    abstract isContainer: bool with get, set
    abstract masterId: string with get, set
    abstract memberIds: ResizeArray<string> with get, set
    abstract memberOf: ResizeArray<IdentityDescriptor> with get, set
    abstract members: ResizeArray<IdentityDescriptor> with get, set
    abstract metaTypeId: float with get, set
    abstract properties: obj option with get, set
    /// The display name for the identity as specified by the source identity provider.
    abstract providerDisplayName: string with get, set
    abstract resourceVersion: float with get, set
    abstract socialDescriptor: string with get, set
    abstract subjectDescriptor: string with get, set
    abstract uniqueUserId: float with get, set

type [<AllowNullLiteral>] IdentityBatchInfo =
    abstract descriptors: ResizeArray<IdentityDescriptor> with get, set
    abstract identityIds: ResizeArray<string> with get, set
    abstract includeRestrictedVisibility: bool with get, set
    abstract propertyNames: ResizeArray<string> with get, set
    abstract queryMembership: QueryMembership with get, set
    abstract socialDescriptors: ResizeArray<string> with get, set
    abstract subjectDescriptors: ResizeArray<string> with get, set

/// An Identity descriptor is a wrapper for the identity type (Windows SID, Passport) along with a unique identifier such as the SID or PUID.
type [<AllowNullLiteral>] IdentityDescriptor =
    /// The unique identifier for this identity, not exceeding 256 chars, which will be persisted.
    abstract identifier: string with get, set
    /// Type of descriptor (for example, Windows, Passport, etc.).
    abstract identityType: string with get, set

type [<AllowNullLiteral>] IdentityRightsTransferData =
    abstract userPrincipalNameMappings: IdentityRightsTransferDataUserPrincipalNameMappings with get, set

type [<AllowNullLiteral>] IdentityScope =
    abstract administrators: IdentityDescriptor with get, set
    abstract id: string with get, set
    abstract isActive: bool with get, set
    abstract isGlobal: bool with get, set
    abstract localScopeId: string with get, set
    abstract name: string with get, set
    abstract parentId: string with get, set
    abstract scopeType: GroupScopeType with get, set
    abstract securingHostId: string with get, set
    abstract subjectDescriptor: string with get, set

/// Identity information.
type [<AllowNullLiteral>] IdentitySelf =
    /// The UserPrincipalName (UPN) of the account. This value comes from the source provider.
    abstract accountName: string with get, set
    /// The display name. For AAD accounts with multiple tenants this is the display name of the profile in the home tenant.
    abstract displayName: string with get, set
    /// This represents the name of the container of origin. For AAD accounts this is the tenantID of the home tenant. For MSA accounts this is the string "Windows Live ID".
    abstract domain: string with get, set
    /// This is the VSID of the home tenant profile. If the profile is signed into the home tenant or if the profile has no tenants then this Id is the same as the Id returned by the profile/profiles/me endpoint. Going forward it is recommended that you use the combined values of Origin, OriginId and Domain to uniquely identify a user rather than this Id.
    abstract id: string with get, set
    /// The type of source provider for the origin identifier. For MSA accounts this is "msa". For AAD accounts this is "aad".
    abstract origin: string with get, set
    /// The unique identifier from the system of origin. If there are multiple tenants this is the unique identifier of the account in the home tenant. (For MSA this is the PUID in hex notation, for AAD this is the object id.)
    abstract originId: string with get, set
    /// For AAD accounts this is all of the tenants that this account is a member of.
    abstract tenants: ResizeArray<TenantInfo> with get, set

type [<AllowNullLiteral>] IdentitySnapshot =
    abstract groups: ResizeArray<Identity> with get, set
    abstract identityIds: ResizeArray<string> with get, set
    abstract memberships: ResizeArray<GroupMembership> with get, set
    abstract scopeId: string with get, set
    abstract scopes: ResizeArray<IdentityScope> with get, set

type [<AllowNullLiteral>] IdentityUpdateData =
    abstract id: string with get, set
    abstract index: float with get, set
    abstract updated: bool with get, set

type [<AllowNullLiteral>] PagedIdentities =
    abstract continuationToken: ResizeArray<string> with get, set
    abstract identities: ResizeArray<Identity> with get, set

type [<RequireQualifiedAccess>] QueryMembership =
    | None = 0
    | Direct = 1
    | Expanded = 2
    | ExpandedUp = 3
    | ExpandedDown = 4

type [<RequireQualifiedAccess>] ReadIdentitiesOptions =
    | None = 0
    | FilterIllegalMemberships = 1

type [<AllowNullLiteral>] SwapIdentityInfo =
    abstract id1: string with get, set
    abstract id2: string with get, set

type [<AllowNullLiteral>] TenantInfo =
    abstract homeTenant: bool with get, set
    abstract tenantId: string with get, set
    abstract tenantName: string with get, set
    abstract verifiedDomains: ResizeArray<string> with get, set

type [<AllowNullLiteral>] IdentityRightsTransferDataUserPrincipalNameMappings =
    [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> string with get, set
