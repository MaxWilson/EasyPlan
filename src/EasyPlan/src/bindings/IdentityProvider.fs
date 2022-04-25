// ts2fable 0.7.1
module rec IdentityProvider
open System
open Fable.Core
open Fable.Core.JS


module IdentityProvider =
    type IIdentity = IdentityService.IIdentity
    type IdentitiesGetConnectionsResponseModel = IdentityService.IdentitiesGetConnectionsResponseModel

    type [<AllowNullLiteral>] IExports =
        abstract PeoplePickerProvider: PeoplePickerProviderStatic

    type [<AllowNullLiteral>] IPeoplePickerProvider =
        /// Add identities to the MRU
        abstract addIdentitiesToMRU: (ResizeArray<IIdentity> -> Promise<bool>) option with get, set
        /// Request Entity information given an entityId
        abstract getEntityFromUniqueAttribute: (string -> U2<IIdentity, PromiseLike<IIdentity>>) with get, set
        /// If no input is in the search box when clicked, provide a set of identities to show (used for MRU)
        abstract onEmptyInputFocus: (unit -> U2<ResizeArray<IIdentity>, PromiseLike<ResizeArray<IIdentity>>> option) option with get, set
        /// Given a list of currently selected items and a filter string, return a list of suggestions to put in the suggestion list
        abstract onFilterIdentities: (string -> ResizeArray<IIdentity> -> U2<ResizeArray<IIdentity>, PromiseLike<ResizeArray<IIdentity>>> option) with get, set
        /// Request connection information about a given Entity.
        abstract onRequestConnectionInformation: (IIdentity -> bool -> U2<IdentitiesGetConnectionsResponseModel, PromiseLike<IdentitiesGetConnectionsResponseModel>>) with get, set
        /// Remove identities from the MRU
        abstract removeIdentitiesFromMRU: (ResizeArray<IIdentity> -> Promise<bool>) option with get, set

    type [<AllowNullLiteral>] PeoplePickerProvider =
        inherit IPeoplePickerProvider
        /// Add identities to the MRU
        abstract addIdentitiesToMRU: (ResizeArray<IIdentity> -> Promise<bool>) with get, set
        /// Request Entity information given an entityId
        abstract getEntityFromUniqueAttribute: (string -> U2<IIdentity, PromiseLike<IIdentity>>) with get, set
        /// If no input is in the search box when clicked, provide a set of identities to show (used for MRU)
        abstract onEmptyInputFocus: (unit -> U2<ResizeArray<IIdentity>, PromiseLike<ResizeArray<IIdentity>>>) with get, set
        /// Given a list of currently selected items and a filter string, return a list of suggestions to put in the suggestion list
        abstract onFilterIdentities: (string -> ResizeArray<IIdentity> -> U2<ResizeArray<IIdentity>, Promise<ResizeArray<IIdentity>>>) with get, set
        /// Request connection information about a given Entity.
        abstract onRequestConnectionInformation: (IIdentity -> bool -> U2<IdentitiesGetConnectionsResponseModel, PromiseLike<IdentitiesGetConnectionsResponseModel>>) with get, set
        /// Remove identities from the MRU
        abstract removeIdentitiesFromMRU: (ResizeArray<IIdentity> -> Promise<bool>) with get, set

    type [<AllowNullLiteral>] PeoplePickerProviderStatic =
        [<Emit "new $0($1...)">] abstract Create: unit -> PeoplePickerProvider
