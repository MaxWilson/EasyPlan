// ts2fable 0.7.1
module rec Serialization
open System
open Fable.Core
open Fable.Core.JS

type [<AllowNullLiteral>] IExports =
    /// <summary>Handle the raw text of a JSON response which may contain MSJSON style dates and
    /// deserialize (JSON.parse) the data in a way that restores Date objects rather than
    /// strings.
    ///
    /// MSJSON style dates are in the form:
    ///
    ///      "lastModified": "\/Date(1496158224000)\/"
    ///
    /// This format unnecessarily (but intentionally) escapes the "/" character. So the parsed
    /// JSON will have no trace of the escape character (\).</summary>
    /// <param name="text">The raw JSON text</param>
    abstract deserializeVssJsonObject: text: string -> 'T option
