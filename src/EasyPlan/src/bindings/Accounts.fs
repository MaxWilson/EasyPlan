// ts2fable 0.7.1
module rec Accounts
open System
open Fable.Core
open Fable.Core.JS


module Accounts =

    type [<AllowNullLiteral>] Account =
        /// Identifier for an Account
        abstract accountId: string with get, set
        /// Name for an account
        abstract accountName: string with get, set
        /// Owner of account
        abstract accountOwner: string with get, set
        /// Current account status
        abstract accountStatus: AccountStatus with get, set
        /// Type of account: Personal, Organization
        abstract accountType: AccountType with get, set
        /// Uri for an account
        abstract accountUri: string with get, set
        /// Who created the account
        abstract createdBy: string with get, set
        /// Date account was created
        abstract createdDate: DateTime with get, set
        abstract hasMoved: bool with get, set
        /// Identity of last person to update the account
        abstract lastUpdatedBy: string with get, set
        /// Date account was last updated
        abstract lastUpdatedDate: DateTime with get, set
        /// Namespace for an account
        abstract namespaceId: string with get, set
        abstract newCollectionId: string with get, set
        /// Organization that created the account
        abstract organizationName: string with get, set
        /// Extended properties
        abstract properties: obj option with get, set
        /// Reason for current status
        abstract statusReason: string with get, set

    type [<AllowNullLiteral>] AccountCreateInfoInternal =
        abstract accountName: string with get, set
        abstract creator: string with get, set
        abstract organization: string with get, set
        abstract preferences: AccountPreferencesInternal with get, set
        abstract properties: obj option with get, set
        abstract serviceDefinitions: ResizeArray<AccountCreateInfoInternalServiceDefinitions> with get, set

    type [<AllowNullLiteral>] AccountPreferencesInternal =
        abstract culture: obj option with get, set
        abstract language: obj option with get, set
        abstract timeZone: obj option with get, set

    type [<RequireQualifiedAccess>] AccountStatus =
        | None = 0
        | Enabled = 1
        | Disabled = 2
        | Deleted = 3
        | Moved = 4

    type [<RequireQualifiedAccess>] AccountType =
        | Personal = 0
        | Organization = 1

    type [<RequireQualifiedAccess>] AccountUserStatus =
        | None = 0
        | Active = 1
        | Disabled = 2
        | Deleted = 3
        | Pending = 4
        | Expired = 5
        | PendingDisabled = 6

    type [<AllowNullLiteral>] AccountCreateInfoInternalServiceDefinitions =
        abstract key: string with get, set
        abstract value: string with get, set
