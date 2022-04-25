// ts2fable 0.7.1
module rec Graph
open System
open Fable.Core
open Fable.Core.JS


module Graph =
    module Identities = ___Identities_Identities

    type [<AllowNullLiteral>] GraphCachePolicies =
        /// Size of the cache
        abstract cacheSize: float with get, set

    /// Subject descriptor of a Graph entity
    type [<AllowNullLiteral>] GraphDescriptorResult =
        /// This field contains zero or more interesting links about the graph descriptor. These links may be invoked to obtain additional relationships or more detailed information about this graph descriptor.
        abstract _links: obj option with get, set
        abstract value: string with get, set

    /// Represents a set of data used to communicate with a federated provider on behalf of a particular user.
    type [<AllowNullLiteral>] GraphFederatedProviderData =
        /// The access token that can be used to communicated with the federated provider on behalf on the target identity, if we were able to successfully acquire one, otherwise \<code\>null\</code\>, if we were not.
        abstract accessToken: string with get, set
        /// The name of the federated provider, e.g. "github.com".
        abstract providerName: string with get, set
        /// The descriptor of the graph subject to which this federated provider data corresponds.
        abstract subjectDescriptor: string with get, set
        /// The version number of this federated provider data, which corresponds to when it was last updated. Can be used to prevent returning stale provider data from the cache when the caller is aware of a newer version, such as to prevent local cache poisoning from a remote cache or store. This is the app layer equivalent of the data layer sequence ID.
        abstract version: float with get, set

    type [<AllowNullLiteral>] GraphGlobalExtendedPropertyBatch =
        abstract propertyNameFilters: ResizeArray<string> with get, set
        abstract subjectDescriptors: ResizeArray<string> with get, set

    /// Graph group entity
    type [<AllowNullLiteral>] GraphGroup =
        inherit GraphMember
        /// A short phrase to help human readers disambiguate groups with similar names
        abstract description: string with get, set
        abstract isCrossProject: bool with get, set
        abstract isDeleted: bool with get, set
        abstract isGlobalScope: bool with get, set
        abstract isRestrictedVisible: bool with get, set
        abstract localScopeId: string with get, set
        abstract scopeId: string with get, set
        abstract scopeName: string with get, set
        abstract scopeType: string with get, set
        abstract securingHostId: string with get, set
        abstract specialType: string with get, set

    /// Do not attempt to use this type to create a new group. This type does not contain sufficient fields to create a new group.
    type [<AllowNullLiteral>] GraphGroupCreationContext =
        /// Optional: If provided, we will use this identifier for the storage key of the created group
        abstract storageKey: string with get, set

    /// Use this type to create a new group using the mail address as a reference to an existing group from an external AD or AAD backed provider. This is the subset of GraphGroup fields required for creation of a group for the AAD and AD use case.
    type [<AllowNullLiteral>] GraphGroupMailAddressCreationContext =
        inherit GraphGroupCreationContext
        /// This should be the mail address or the group in the source AD or AAD provider. Example: jamal\@contoso.com Team Services will communicate with the source provider to fill all other fields on creation.
        abstract mailAddress: string with get, set

    /// Use this type to create a new group using the OriginID as a reference to an existing group from an external AD or AAD backed provider. This is the subset of GraphGroup fields required for creation of a group for the AD and AAD use case.
    type [<AllowNullLiteral>] GraphGroupOriginIdCreationContext =
        inherit GraphGroupCreationContext
        /// This should be the object id or sid of the group from the source AD or AAD provider. Example: d47d025a-ce2f-4a79-8618-e8862ade30dd Team Services will communicate with the source provider to fill all other fields on creation.
        abstract originId: string with get, set

    /// Use this type to create a new Vsts group that is not backed by an external provider.
    type [<AllowNullLiteral>] GraphGroupVstsCreationContext =
        inherit GraphGroupCreationContext
        /// For internal use only in back compat scenarios.
        abstract crossProject: bool with get, set
        /// Used by VSTS groups; if set this will be the group description, otherwise ignored
        abstract description: string with get, set
        abstract descriptor: string with get, set
        /// Used by VSTS groups; if set this will be the group DisplayName, otherwise ignored
        abstract displayName: string with get, set
        /// For internal use only in back compat scenarios.
        abstract restrictedVisibility: bool with get, set
        /// For internal use only in back compat scenarios.
        abstract specialGroupType: string with get, set

    type [<AllowNullLiteral>] GraphMember =
        inherit GraphSubject
        /// This represents the name of the container of origin for a graph member. (For MSA this is "Windows Live ID", for AD the name of the domain, for AAD the tenantID of the directory, for VSTS groups the ScopeId, etc)
        abstract domain: string with get, set
        /// The email address of record for a given graph member. This may be different than the principal name.
        abstract mailAddress: string with get, set
        /// This is the PrincipalName of this graph member from the source provider. The source provider may change this field over time and it is not guaranteed to be immutable for the life of the graph member by VSTS.
        abstract principalName: string with get, set

    /// Relationship between a container and a member
    type [<AllowNullLiteral>] GraphMembership =
        /// This field contains zero or more interesting links about the graph membership. These links may be invoked to obtain additional relationships or more detailed information about this graph membership.
        abstract _links: obj option with get, set
        abstract containerDescriptor: string with get, set
        abstract memberDescriptor: string with get, set

    /// Status of a Graph membership (active/inactive)
    type [<AllowNullLiteral>] GraphMembershipState =
        /// This field contains zero or more interesting links about the graph membership state. These links may be invoked to obtain additional relationships or more detailed information about this graph membership state.
        abstract _links: obj option with get, set
        /// When true, the membership is active
        abstract active: bool with get, set

    type [<AllowNullLiteral>] GraphMembershipTraversal =
        /// Reason why the subject could not be traversed completely
        abstract incompletenessReason: string with get, set
        /// When true, the subject is traversed completely
        abstract isComplete: bool with get, set
        /// The traversed subject descriptor
        abstract subjectDescriptor: string with get, set
        /// Subject descriptor ids of the traversed members
        abstract traversedSubjectIds: ResizeArray<string> with get, set
        /// Subject descriptors of the traversed members
        abstract traversedSubjects: ResizeArray<string> with get, set

    /// Who is the provider for this user and what is the identifier and domain that is used to uniquely identify the user.
    type [<AllowNullLiteral>] GraphProviderInfo =
        /// The descriptor is the primary way to reference the graph subject while the system is running. This field will uniquely identify the same graph subject across both Accounts and Organizations.
        abstract descriptor: string with get, set
        /// This represents the name of the container of origin for a graph member. (For MSA this is "Windows Live ID", for AAD the tenantID of the directory.)
        abstract domain: string with get, set
        /// The type of source provider for the origin identifier (ex: "aad", "msa")
        abstract origin: string with get, set
        /// The unique identifier from the system of origin. (For MSA this is the PUID in hex notation, for AAD this is the object id.)
        abstract originId: string with get, set

    /// Container where a graph entity is defined (organization, project, team)
    type [<AllowNullLiteral>] GraphScope =
        inherit GraphSubject
        /// The subject descriptor that references the administrators group for this scope. Only members of this group can change the contents of this scope or assign other users permissions to access this scope.
        abstract administratorDescriptor: string with get, set
        /// When true, this scope is also a securing host for one or more scopes.
        abstract isGlobal: bool with get, set
        /// The subject descriptor for the closest account or organization in the ancestor tree of this scope.
        abstract parentDescriptor: string with get, set
        /// The type of this scope. Typically ServiceHost or TeamProject.
        abstract scopeType: Identities.GroupScopeType with get, set
        /// The subject descriptor for the containing organization in the ancestor tree of this scope.
        abstract securingHostDescriptor: string with get, set

    /// This type is the subset of fields that can be provided by the user to create a Vsts scope. Scope creation is currently limited to internal back-compat scenarios. End users that attempt to create a scope with this API will fail.
    type [<AllowNullLiteral>] GraphScopeCreationContext =
        /// Set this field to override the default description of this scope's admin group.
        abstract adminGroupDescription: string with get, set
        /// All scopes have an Administrator Group that controls access to the contents of the scope. Set this field to use a non-default group name for that administrators group.
        abstract adminGroupName: string with get, set
        /// Set this optional field if this scope is created on behalf of a user other than the user making the request. This should be the Id of the user that is not the requester.
        abstract creatorId: string with get, set
        /// The scope must be provided with a unique name within the parent scope. This means the created scope can have a parent or child with the same name, but no siblings with the same name.
        abstract name: string with get, set
        /// The type of scope being created.
        abstract scopeType: Identities.GroupScopeType with get, set
        /// An optional ID that uniquely represents the scope within it's parent scope. If this parameter is not provided, Vsts will generate on automatically.
        abstract storageKey: string with get, set

    /// Storage key of a Graph entity
    type [<AllowNullLiteral>] GraphStorageKeyResult =
        /// This field contains zero or more interesting links about the graph storage key. These links may be invoked to obtain additional relationships or more detailed information about this graph storage key.
        abstract _links: obj option with get, set
        abstract value: string with get, set

    /// Top-level graph entity
    type [<AllowNullLiteral>] GraphSubject =
        inherit GraphSubjectBase
        /// [Internal Use Only] The legacy descriptor is here in case you need to access old version IMS using identity descriptor.
        abstract legacyDescriptor: string with get, set
        /// The type of source provider for the origin identifier (ex:AD, AAD, MSA)
        abstract origin: string with get, set
        /// The unique identifier from the system of origin. Typically a sid, object id or Guid. Linking and unlinking operations can cause this value to change for a user because the user is not backed by a different provider and has a different unique id in the new provider.
        abstract originId: string with get, set
        /// This field identifies the type of the graph subject (ex: Group, Scope, User).
        abstract subjectKind: string with get, set

    type [<AllowNullLiteral>] GraphSubjectBase =
        /// This field contains zero or more interesting links about the graph subject. These links may be invoked to obtain additional relationships or more detailed information about this graph subject.
        abstract _links: obj option with get, set
        /// The descriptor is the primary way to reference the graph subject while the system is running. This field will uniquely identify the same graph subject across both Accounts and Organizations.
        abstract descriptor: string with get, set
        /// This is the non-unique display name of the graph subject. To change this field, you must alter its value in the source provider.
        abstract displayName: string with get, set
        /// This url is the full route to the source resource of this graph subject.
        abstract url: string with get, set

    /// Batching of subjects to lookup using the Graph API
    type [<AllowNullLiteral>] GraphSubjectLookup =
        abstract lookupKeys: ResizeArray<GraphSubjectLookupKey> with get, set

    type [<AllowNullLiteral>] GraphSubjectLookupKey =
        abstract descriptor: string with get, set

    /// Subject to search using the Graph API
    type [<AllowNullLiteral>] GraphSubjectQuery =
        /// Search term to search for Azure Devops users or/and groups
        abstract query: string with get, set
        /// Optional parameter. Specify a non-default scope (collection, project) to search for users or groups within the scope.
        abstract scopeDescriptor: string with get, set
        /// "User" or "Group" can be specified, both or either
        abstract subjectKind: ResizeArray<string> with get, set

    type [<AllowNullLiteral>] GraphSystemSubject =
        inherit GraphSubject

    type [<RequireQualifiedAccess>] GraphTraversalDirection =
        | Unknown = 0
        | Down = 1
        | Up = 2

    /// Graph user entity
    type [<AllowNullLiteral>] GraphUser =
        inherit GraphMember
        /// The short, generally unique name for the user in the backing directory. For AAD users, this corresponds to the mail nickname, which is often but not necessarily similar to the part of the user's mail address before the \@ sign. For GitHub users, this corresponds to the GitHub user handle.
        abstract directoryAlias: string with get, set
        /// When true, the group has been deleted in the identity provider
        abstract isDeletedInOrigin: bool with get, set
        abstract metadataUpdateDate: DateTime with get, set
        /// The meta type of the user in the origin, such as "member", "guest", etc. See UserMetaType for the set of possible values.
        abstract metaType: string with get, set

    /// Do not attempt to use this type to create a new user. Use one of the subclasses instead. This type does not contain sufficient fields to create a new user.
    type [<AllowNullLiteral>] GraphUserCreationContext =
        /// Optional: If provided, we will use this identifier for the storage key of the created user
        abstract storageKey: string with get, set

    /// Use this type to create a new user using the mail address as a reference to an existing user from an external AD or AAD backed provider. This is the subset of GraphUser fields required for creation of a GraphUser for the AD and AAD use case when looking up the user by its mail address in the backing provider.
    type [<AllowNullLiteral>] GraphUserMailAddressCreationContext =
        inherit GraphUserCreationContext
        abstract mailAddress: string with get, set

    /// Use this type to create a new user using the OriginID as a reference to an existing user from an external AD or AAD backed provider. This is the subset of GraphUser fields required for creation of a GraphUser for the AD and AAD use case when looking up the user by its unique ID in the backing provider.
    type [<AllowNullLiteral>] GraphUserOriginIdCreationContext =
        inherit GraphUserCreationContext
        /// This should be the name of the origin provider. Example: github.com
        abstract origin: string with get, set
        /// This should be the object id or sid of the user from the source AD or AAD provider. Example: d47d025a-ce2f-4a79-8618-e8862ade30dd Team Services will communicate with the source provider to fill all other fields on creation.
        abstract originId: string with get, set

    /// Use this type to update an existing user using the OriginID as a reference to an existing user from an external AD or AAD backed provider. This is the subset of GraphUser fields required for creation of a GraphUser for the AD and AAD use case when looking up the user by its unique ID in the backing provider.
    type [<AllowNullLiteral>] GraphUserOriginIdUpdateContext =
        inherit GraphUserUpdateContext
        /// This should be the object id or sid of the user from the source AD or AAD provider. Example: d47d025a-ce2f-4a79-8618-e8862ade30dd Azure Devops will communicate with the source provider to fill all other fields on creation.
        abstract originId: string with get, set

    /// Use this type to create a new user using the principal name as a reference to an existing user from an external AD or AAD backed provider. This is the subset of GraphUser fields required for creation of a GraphUser for the AD and AAD use case when looking up the user by its principal name in the backing provider.
    type [<AllowNullLiteral>] GraphUserPrincipalNameCreationContext =
        inherit GraphUserCreationContext
        /// This should be the principal name or upn of the user in the source AD or AAD provider. Example: jamal\@contoso.com Team Services will communicate with the source provider to fill all other fields on creation.
        abstract principalName: string with get, set

    /// Do not attempt to use this type to update user. Use one of the subclasses instead. This type does not contain sufficient fields to create a new user.
    type [<AllowNullLiteral>] GraphUserUpdateContext =
        /// Storage key should not be specified in case of updating user
        abstract storageKey: string with get, set

    type [<AllowNullLiteral>] PagedGraphGroups =
        /// This will be non-null if there is another page of data. There will never be more than one continuation token returned by a request.
        abstract continuationToken: ResizeArray<string> with get, set
        /// The enumerable list of groups found within a page.
        abstract graphGroups: ResizeArray<GraphGroup> with get, set

    type [<AllowNullLiteral>] PagedGraphUsers =
        /// This will be non-null if there is another page of data. There will never be more than one continuation token returned by a request.
        abstract continuationToken: ResizeArray<string> with get, set
        /// The enumerable set of users found within a page.
        abstract graphUsers: ResizeArray<GraphUser> with get, set

    type [<AllowNullLiteral>] RequestAccessPayLoad =
        abstract message: string with get, set
        abstract urlRequested: string with get, set
