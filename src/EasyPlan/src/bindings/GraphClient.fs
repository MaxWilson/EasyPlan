// ts2fable 0.7.1
module rec GraphClient
open System
open Fable.Core
open Fable.Core.JS

type IVssRestClientOptions = Context.IVssRestClientOptions
type RestClientBase = RestClientBase.RestClientBase

type [<AllowNullLiteral>] IExports =
    abstract GraphRestClient: GraphRestClientStatic

type [<AllowNullLiteral>] GraphRestClient =
    inherit RestClientBase
    /// <param name="subjectDescriptor">-</param>
    abstract deleteAvatar: subjectDescriptor: string -> Promise<unit>
    /// <param name="subjectDescriptor">-</param>
    /// <param name="size">-</param>
    /// <param name="format">-</param>
    abstract getAvatar: subjectDescriptor: string * ?size: Profile.AvatarSize * ?format: string -> Promise<Profile.Avatar>
    /// <param name="avatar">-</param>
    /// <param name="subjectDescriptor">-</param>
    abstract setAvatar: avatar: Profile.Avatar * subjectDescriptor: string -> Promise<unit>
    abstract getCachePolicies: unit -> Promise<Graph.GraphCachePolicies>
    /// <summary>Resolve a storage key to a descriptor</summary>
    /// <param name="storageKey">- Storage key of the subject (user, group, scope, etc.) to resolve</param>
    abstract getDescriptor: storageKey: string -> Promise<Graph.GraphDescriptorResult>
    /// <summary>Acquires the full set of federated provider authentication data available for the given graph subject and provider name.</summary>
    /// <param name="subjectDescriptor">- the descriptor of the graph subject that we should acquire data for</param>
    /// <param name="providerName">- the name of the provider to acquire data for, e.g. "github.com"</param>
    /// <param name="versionHint">- a version hint that can be used for optimistic cache concurrency and to support retries on access token failures; note that this is a hint only and does not guarantee a particular version on the response</param>
    abstract getFederatedProviderData: subjectDescriptor: string * providerName: string * ?versionHint: float -> Promise<Graph.GraphFederatedProviderData>
    /// <summary>Create a new Azure DevOps group or materialize an existing AAD group.</summary>
    /// <param name="creationContext">- The subset of the full graph group used to uniquely find the graph subject in an external provider.</param>
    /// <param name="scopeDescriptor">- A descriptor referencing the scope (collection, project) in which the group should be created. If omitted, will be created in the scope of the enclosing account or organization. Valid only for VSTS groups.</param>
    /// <param name="groupDescriptors">- A comma separated list of descriptors referencing groups you want the graph group to join</param>
    abstract createGroup: creationContext: Graph.GraphGroupCreationContext * ?scopeDescriptor: string * ?groupDescriptors: ResizeArray<string> -> Promise<Graph.GraphGroup>
    /// <summary>Removes an Azure DevOps group from all of its parent groups.</summary>
    /// <param name="groupDescriptor">- The descriptor of the group to delete.</param>
    abstract deleteGroup: groupDescriptor: string -> Promise<unit>
    /// <summary>Get a group by its descriptor.</summary>
    /// <param name="groupDescriptor">- The descriptor of the desired graph group.</param>
    abstract getGroup: groupDescriptor: string -> Promise<Graph.GraphGroup>
    /// <summary>Update the properties of an Azure DevOps group.</summary>
    /// <param name="groupDescriptor">- The descriptor of the group to modify.</param>
    /// <param name="patchDocument">- The JSON+Patch document containing the fields to alter.</param>
    abstract updateGroup: groupDescriptor: string * patchDocument: WebApi.JsonPatchDocument -> Promise<Graph.GraphGroup>
    /// <param name="memberLookup">-</param>
    abstract lookupMembers: memberLookup: Graph.GraphSubjectLookup -> Promise<GraphRestClientLookupMembersPromise>
    /// <summary>This endpoint returns a result for any member that has ever been valid in the system, even if the member has since been deleted or has had all their memberships deleted. The current validity of the member is indicated through its disabled property, which is omitted when false.</summary>
    /// <param name="memberDescriptor">- The descriptor of the desired member.</param>
    abstract getMemberByDescriptor: memberDescriptor: string -> Promise<Graph.GraphMember>
    /// <summary>Create a new membership between a container and subject.</summary>
    /// <param name="subjectDescriptor">- A descriptor to a group or user that can be the child subject in the relationship.</param>
    /// <param name="containerDescriptor">- A descriptor to a group that can be the container in the relationship.</param>
    abstract addMembership: subjectDescriptor: string * containerDescriptor: string -> Promise<Graph.GraphMembership>
    /// <summary>Check to see if a membership relationship between a container and subject exists.</summary>
    /// <param name="subjectDescriptor">- The group or user that is a child subject of the relationship.</param>
    /// <param name="containerDescriptor">- The group that is the container in the relationship.</param>
    abstract checkMembershipExistence: subjectDescriptor: string * containerDescriptor: string -> Promise<bool>
    /// <summary>Get a membership relationship between a container and subject.</summary>
    /// <param name="subjectDescriptor">- A descriptor to the child subject in the relationship.</param>
    /// <param name="containerDescriptor">- A descriptor to the container in the relationship.</param>
    abstract getMembership: subjectDescriptor: string * containerDescriptor: string -> Promise<Graph.GraphMembership>
    /// <summary>Deletes a membership between a container and subject.</summary>
    /// <param name="subjectDescriptor">- A descriptor to a group or user that is the child subject in the relationship.</param>
    /// <param name="containerDescriptor">- A descriptor to a group that is the container in the relationship.</param>
    abstract removeMembership: subjectDescriptor: string * containerDescriptor: string -> Promise<unit>
    /// <summary>Get all the memberships where this descriptor is a member in the relationship.</summary>
    /// <param name="subjectDescriptor">- Fetch all direct memberships of this descriptor.</param>
    /// <param name="direction">- Defaults to Up.</param>
    /// <param name="depth">- The maximum number of edges to traverse up or down the membership tree. Currently the only supported value is '1'.</param>
    abstract listMemberships: subjectDescriptor: string * ?direction: Graph.GraphTraversalDirection * ?depth: float -> Promise<ResizeArray<Graph.GraphMembership>>
    /// <summary>Check whether a subject is active or inactive.</summary>
    /// <param name="subjectDescriptor">- Descriptor of the subject (user, group, scope, etc.) to check state of</param>
    abstract getMembershipState: subjectDescriptor: string -> Promise<Graph.GraphMembershipState>
    /// <summary>Traverse memberships of the given subject descriptors.</summary>
    /// <param name="membershipTraversalLookup">- Fetch the descendants/ancestors of the list of descriptors depending on direction.</param>
    /// <param name="direction">- The default value is Unknown.</param>
    /// <param name="depth">- The default value is '1'.</param>
    abstract lookupMembershipTraversals: membershipTraversalLookup: Graph.GraphSubjectLookup * ?direction: Graph.GraphTraversalDirection * ?depth: float -> Promise<GraphRestClientLookupMembershipTraversalsPromise>
    /// <summary>Traverse memberships of the given subject descriptor.</summary>
    /// <param name="subjectDescriptor">- Fetch the descendants/ancestors of this descriptor depending on direction.</param>
    /// <param name="direction">- The default value is Unknown.</param>
    /// <param name="depth">- The default value is '1'.</param>
    abstract traverseMemberships: subjectDescriptor: string * ?direction: Graph.GraphTraversalDirection * ?depth: float -> Promise<Graph.GraphMembershipTraversal>
    /// <param name="userDescriptor">-</param>
    abstract getProviderInfo: userDescriptor: string -> Promise<Graph.GraphProviderInfo>
    /// <param name="jsondocument">-</param>
    abstract requestAccess: jsondocument: obj option -> Promise<unit>
    /// <param name="creationContext">-</param>
    /// <param name="scopeDescriptor">-</param>
    abstract createScope: creationContext: Graph.GraphScopeCreationContext * ?scopeDescriptor: string -> Promise<Graph.GraphScope>
    /// <param name="scopeDescriptor">-</param>
    abstract deleteScope: scopeDescriptor: string -> Promise<unit>
    /// <summary>Get a scope identified by its descriptor</summary>
    /// <param name="scopeDescriptor">- A descriptor that uniquely identifies a scope.</param>
    abstract getScope: scopeDescriptor: string -> Promise<Graph.GraphScope>
    /// <param name="scopeDescriptor">-</param>
    /// <param name="patchDocument">-</param>
    abstract updateScope: scopeDescriptor: string * patchDocument: WebApi.JsonPatchDocument -> Promise<unit>
    /// <summary>Resolve a descriptor to a storage key.</summary>
    /// <param name="subjectDescriptor">-</param>
    abstract getStorageKey: subjectDescriptor: string -> Promise<Graph.GraphStorageKeyResult>
    /// <summary>Resolve descriptors to users, groups or scopes (Subjects) in a batch.</summary>
    /// <param name="subjectLookup">- A list of descriptors that specifies a subset of subjects to retrieve. Each descriptor uniquely identifies the subject across all instance scopes, but only at a single point in time.</param>
    abstract lookupSubjects: subjectLookup: Graph.GraphSubjectLookup -> Promise<GraphRestClientLookupSubjectsPromise>
    /// <summary>Search for Azure Devops users, or/and groups. Results will be returned in a batch with no more than 100 graph subjects.</summary>
    /// <param name="subjectQuery">- The query that we'll be using to search includes the following: Query: the search term. The search will be prefix matching only. SubjectKind: "User" or "Group" can be specified, both or either ScopeDescriptor: Non-default scope can be specified, i.e. project scope descriptor</param>
    abstract querySubjects: subjectQuery: Graph.GraphSubjectQuery -> Promise<ResizeArray<Graph.GraphSubject>>
    /// <param name="subjectDescriptor">-</param>
    abstract getSubject: subjectDescriptor: string -> Promise<Graph.GraphSubject>
    /// <summary>Materialize an existing AAD or MSA user into the VSTS account.</summary>
    /// <param name="creationContext">- The subset of the full graph user used to uniquely find the graph subject in an external provider.</param>
    /// <param name="groupDescriptors">- A comma separated list of descriptors of groups you want the graph user to join</param>
    abstract createUser: creationContext: Graph.GraphUserCreationContext * ?groupDescriptors: ResizeArray<string> -> Promise<Graph.GraphUser>
    /// <summary>Disables a user.</summary>
    /// <param name="userDescriptor">- The descriptor of the user to delete.</param>
    abstract deleteUser: userDescriptor: string -> Promise<unit>
    /// <summary>Get a user by its descriptor.</summary>
    /// <param name="userDescriptor">- The descriptor of the desired user.</param>
    abstract getUser: userDescriptor: string -> Promise<Graph.GraphUser>
    /// <summary>Map an existing user to a different identity</summary>
    /// <param name="updateContext">- The subset of the full graph user used to uniquely find the graph subject in an external provider.</param>
    /// <param name="userDescriptor">- the descriptor of the user to update</param>
    abstract updateUser: updateContext: Graph.GraphUserUpdateContext * userDescriptor: string -> Promise<Graph.GraphUser>

type [<AllowNullLiteral>] GraphRestClientStatic =
    [<Emit "new $0($1...)">] abstract Create: options: IVssRestClientOptions -> GraphRestClient
    abstract RESOURCE_AREA_ID: string

type [<AllowNullLiteral>] GraphRestClientLookupMembersPromise =
    [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> Graph.GraphMember with get, set

type [<AllowNullLiteral>] GraphRestClientLookupMembershipTraversalsPromise =
    [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> Graph.GraphMembershipTraversal with get, set

type [<AllowNullLiteral>] GraphRestClientLookupSubjectsPromise =
    [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> Graph.GraphSubject with get, set
