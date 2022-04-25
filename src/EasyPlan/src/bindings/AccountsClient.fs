// ts2fable 0.7.1
module rec AccountsClient
open System
open Fable.Core
open Fable.Core.JS

type IVssRestClientOptions = Context.IVssRestClientOptions
type RestClientBase = RestClientBase.RestClientBase

type [<AllowNullLiteral>] IExports =
    abstract AccountsRestClient: AccountsRestClientStatic

type [<AllowNullLiteral>] AccountsRestClient =
    inherit RestClientBase
    /// <param name="info">-</param>
    /// <param name="usePrecreated">-</param>
    abstract createAccount: info: Accounts.AccountCreateInfoInternal * ?usePrecreated: bool -> Promise<Accounts.Account>
    /// <param name="accountId">-</param>
    abstract getAccount: accountId: string -> Promise<Accounts.Account>
    /// <summary>Get a list of accounts for a specific owner or a specific member.</summary>
    /// <param name="ownerId">- ID for the owner of the accounts.</param>
    /// <param name="memberId">- ID for a member of the accounts.</param>
    /// <param name="properties">-</param>
    abstract getAccounts: ?ownerId: string * ?memberId: string * ?properties: string -> Promise<ResizeArray<Accounts.Account>>

type [<AllowNullLiteral>] AccountsRestClientStatic =
    [<Emit "new $0($1...)">] abstract Create: options: IVssRestClientOptions -> AccountsRestClient
    abstract RESOURCE_AREA_ID: string
