// ts2fable 0.7.1
module rec XDM
open System
open Fable.Core
open Fable.Core.JS
open Browser.Types

type Error = System.Exception

let [<Import("globalObjectRegistry","XDM")>] globalObjectRegistry: IXDMObjectRegistry = jsNative
let [<Import("channelManager","XDM")>] channelManager: IXDMChannelManager = jsNative

type [<AllowNullLiteral>] IExports =
    abstract XDMObjectRegistry: XDMObjectRegistryStatic
    abstract XDMChannel: XDMChannelStatic

/// Interface for a single XDM channel
type [<AllowNullLiteral>] IXDMChannel =
    /// <summary>Invoke a method via RPC. Lookup the registered object on the remote end of the channel and invoke the specified method.</summary>
    /// <param name="instanceId">- unique id of the registered object</param>
    /// <param name="params">- Arguments to the method to invoke</param>
    /// <param name="instanceContextData">- Optional context data to pass to a registered object's factory method</param>
    abstract invokeRemoteMethod: methodName: string * instanceId: string * ?``params``: ResizeArray<obj option> * ?instanceContextData: Object -> Promise<'T>
    /// <summary>Get a proxied object that represents the object registered with the given instance id on the remote side of this channel.</summary>
    /// <param name="instanceId">- unique id of the registered object</param>
    /// <param name="contextData">- Optional context data to pass to a registered object's factory method</param>
    abstract getRemoteObjectProxy: instanceId: string * ?contextData: Object -> Promise<'T>
    /// Get the object registry to handle messages from this specific channel.
    /// Upon receiving a message, this channel registry will be used first, then
    /// the global registry will be used if no handler is found here.
    abstract getObjectRegistry: unit -> IXDMObjectRegistry

/// Registry of XDM channels kept per target frame/window
type [<AllowNullLiteral>] IXDMChannelManager =
    /// <summary>Add an XDM channel for the given target window/iframe</summary>
    /// <param name="window">- Target iframe window to communicate with</param>
    /// <param name="targetOrigin">- Url of the target iframe (if known)</param>
    abstract addChannel: window: Window * ?targetOrigin: string -> IXDMChannel
    /// <summary>Removes an XDM channel, allowing it to be disposed</summary>
    /// <param name="channel">- The channel to remove from the channel manager</param>
    abstract removeChannel: channel: IXDMChannel -> unit

/// Registry of XDM objects that can be invoked by an XDM channel
type [<AllowNullLiteral>] IXDMObjectRegistry =
    /// <summary>Register an object (instance or factory method) exposed by this frame to callers in a remote frame</summary>
    /// <param name="instanceId">- unique id of the registered object</param>
    /// <param name="instance">- Either: (1) an object instance, or (2) a function that takes optional context data and returns an object instance.</param>
    abstract register: instanceId: string * instance: U2<Object, IXDMObjectRegistryRegister> -> unit
    /// <summary>Unregister an object (instance or factory method) that was previously registered by this frame</summary>
    /// <param name="instanceId">- unique id of the registered object</param>
    abstract unregister: instanceId: string -> unit
    /// <summary>Get an instance of an object registered with the given id</summary>
    /// <param name="instanceId">- unique id of the registered object</param>
    /// <param name="contextData">- Optional context data to pass to the contructor of an object factory method</param>
    abstract getInstance: instanceId: string * ?contextData: Object -> 'T option

/// Settings related to the serialization of data across iframe boundaries.
type [<AllowNullLiteral>] ISerializationSettings =
    /// By default, properties that begin with an underscore are not serialized across
    /// the iframe boundary. Set this option to true to serialize such properties.
    abstract includeUnderscoreProperties: bool with get, set

/// Represents a remote procedure call (rpc) between frames.
type [<AllowNullLiteral>] IJsonRpcMessage =
    abstract id: int with get, set
    abstract instanceId: string option with get, set
    abstract instanceContext: Object option with get, set
    abstract methodName: string option with get, set
    abstract ``params``: ResizeArray<obj option> option with get, set
    abstract result: obj option with get, set
    abstract error: obj option with get, set
    abstract handshakeToken: string option with get, set
    abstract serializationSettings: ISerializationSettings option with get, set

/// Catalog of objects exposed for XDM
type [<AllowNullLiteral>] XDMObjectRegistry =
    inherit IXDMObjectRegistry
    /// <summary>Register an object (instance or factory method) exposed by this frame to callers in a remote frame</summary>
    /// <param name="instanceId">- unique id of the registered object</param>
    /// <param name="instance">- Either: (1) an object instance, or (2) a function that takes optional context data and returns an object instance.</param>
    abstract register: instanceId: string * instance: U2<Object, IXDMObjectRegistryRegister> -> unit
    /// <summary>Unregister an object (instance or factory method) that was previously registered by this frame</summary>
    /// <param name="instanceId">- unique id of the registered object</param>
    abstract unregister: instanceId: string -> unit
    /// <summary>Get an instance of an object registered with the given id</summary>
    /// <param name="instanceId">- unique id of the registered object</param>
    /// <param name="contextData">- Optional context data to pass to a registered object's factory method</param>
    abstract getInstance: instanceId: string * ?contextData: Object -> 'T option

/// Catalog of objects exposed for XDM
type [<AllowNullLiteral>] XDMObjectRegistryStatic =
    [<Emit "new $0($1...)">] abstract Create: unit -> XDMObjectRegistry

/// Represents a channel of communication between frames\document
/// Stays "alive" across multiple funtion\method calls
type [<AllowNullLiteral>] XDMChannel =
    inherit IXDMChannel
    /// Get the object registry to handle messages from this specific channel.
    /// Upon receiving a message, this channel registry will be used first, then
    /// the global registry will be used if no handler is found here.
    abstract getObjectRegistry: unit -> IXDMObjectRegistry
    /// <summary>Invoke a method via RPC. Lookup the registered object on the remote end of the channel and invoke the specified method.</summary>
    /// <param name="instanceId">- unique id of the registered object</param>
    /// <param name="params">- Arguments to the method to invoke</param>
    /// <param name="instanceContextData">- Optional context data to pass to a registered object's factory method</param>
    /// <param name="serializationSettings">- Optional serialization settings</param>
    abstract invokeRemoteMethod: methodName: string * instanceId: string * ?``params``: ResizeArray<obj option> * ?instanceContextData: Object * ?serializationSettings: ISerializationSettings -> Promise<'T>
    /// <summary>Get a proxied object that represents the object registered with the given instance id on the remote side of this channel.</summary>
    /// <param name="instanceId">- unique id of the registered object</param>
    /// <param name="contextData">- Optional context data to pass to a registered object's factory method</param>
    abstract getRemoteObjectProxy: instanceId: string * ?contextData: Object -> Promise<'T>
    /// <summary>Handle a received message on this channel. Dispatch to the appropriate object found via object registry</summary>
    /// <param name="rpcMessage">- Message data</param>
    abstract onMessage: rpcMessage: IJsonRpcMessage -> bool
    abstract owns: source: Window * origin: string * rpcMessage: IJsonRpcMessage -> bool
    abstract error: messageObj: IJsonRpcMessage * errorObj: Error -> unit

/// Represents a channel of communication between frames\document
/// Stays "alive" across multiple funtion\method calls
type [<AllowNullLiteral>] XDMChannelStatic =
    [<Emit "new $0($1...)">] abstract Create: postToWindow: Window * ?targetOrigin: string -> XDMChannel

type [<AllowNullLiteral>] IXDMObjectRegistryRegister =
    [<Emit "$0($1...)">] abstract Invoke: ?contextData: obj -> Object
