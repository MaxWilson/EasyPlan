// ts2fable 0.7.1
module rec ProfileClient
open System
open Fable.Core
open Fable.Core.JS

type IVssRestClientOptions = Context.IVssRestClientOptions
type RestClientBase = RestClientBase.RestClientBase

type [<AllowNullLiteral>] IExports =
    abstract ProfileRestClient: ProfileRestClientStatic

type [<AllowNullLiteral>] ProfileRestClient =
    inherit RestClientBase
    /// <param name="id">-</param>
    /// <param name="descriptor">-</param>
    abstract deleteProfileAttribute: id: string * descriptor: string -> Promise<unit>
    /// <param name="id">-</param>
    /// <param name="descriptor">-</param>
    abstract getProfileAttribute: id: string * descriptor: string -> Promise<Profile.ProfileAttribute>
    /// <param name="id">-</param>
    /// <param name="partition">-</param>
    /// <param name="modifiedSince">-</param>
    /// <param name="modifiedAfterRevision">-</param>
    /// <param name="withCoreAttributes">-</param>
    /// <param name="coreAttributes">-</param>
    abstract getProfileAttributes: id: string * partition: string * ?modifiedSince: string * ?modifiedAfterRevision: string * ?withCoreAttributes: bool * ?coreAttributes: string -> Promise<ResizeArray<Profile.ProfileAttribute>>
    /// <param name="container">-</param>
    /// <param name="id">-</param>
    /// <param name="descriptor">-</param>
    abstract setProfileAttribute: container: obj option * id: string * descriptor: string -> Promise<unit>
    /// <param name="attributesCollection">-</param>
    /// <param name="id">-</param>
    abstract setProfileAttributes: attributesCollection: WebApi.VssJsonCollectionWrapperV<ResizeArray<Profile.ProfileAttributeBase<obj option>>> * id: string -> Promise<unit>
    /// <param name="id">-</param>
    /// <param name="size">-</param>
    /// <param name="format">-</param>
    abstract getAvatar: id: string * ?size: string * ?format: string -> Promise<Profile.Avatar>
    /// <param name="container">-</param>
    /// <param name="id">-</param>
    /// <param name="size">-</param>
    /// <param name="format">-</param>
    /// <param name="displayName">-</param>
    abstract getAvatarPreview: container: obj option * id: string * ?size: string * ?format: string * ?displayName: string -> Promise<Profile.Avatar>
    /// <param name="id">-</param>
    abstract resetAvatar: id: string -> Promise<unit>
    /// <param name="container">-</param>
    /// <param name="id">-</param>
    abstract setAvatar: container: obj option * id: string -> Promise<unit>
    /// <summary>Create profile</summary>
    /// <param name="createProfileContext">- Context for profile creation</param>
    /// <param name="autoCreate">- Create profile automatically</param>
    abstract createProfile: createProfileContext: Profile.CreateProfileContext * ?autoCreate: bool -> Promise<Profile.Profile>
    /// <summary>Gets a user profile.</summary>
    /// <param name="id">- The ID of the target user profile within the same organization, or 'me' to get the profile of the current authenticated user.</param>
    /// <param name="details">- Return public profile information such as display name, email address, country, etc. If false, the withAttributes parameter is ignored.</param>
    /// <param name="withAttributes">- If true, gets the attributes (named key-value pairs of arbitrary data) associated with the profile. The partition parameter must also have a value.</param>
    /// <param name="partition">- The partition (named group) of attributes to return.</param>
    /// <param name="coreAttributes">- A comma-delimited list of core profile attributes to return. Valid values are Email, Avatar, DisplayName, and ContactWithOffers.</param>
    /// <param name="forceRefresh">- Not used in this version of the API.</param>
    abstract getProfile: id: string * ?details: bool * ?withAttributes: bool * ?partition: string * ?coreAttributes: string * ?forceRefresh: bool -> Promise<Profile.Profile>
    /// <summary>Update profile</summary>
    /// <param name="profile">- Update profile</param>
    /// <param name="id">- Profile ID</param>
    abstract updateProfile: profile: Profile.Profile * id: string -> Promise<unit>

type [<AllowNullLiteral>] ProfileRestClientStatic =
    [<Emit "new $0($1...)">] abstract Create: options: IVssRestClientOptions -> ProfileRestClient
    abstract RESOURCE_AREA_ID: string
