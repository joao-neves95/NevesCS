using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace NevesCS.Abstractions.Clients.Web3.Solana.Models
{
    [ExcludeFromCodeCoverage]
    public sealed record RawRpcResponse<TValue>
    {
        [JsonPropertyName("result")]
        public RawRpcResponseResult<TValue> Result { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public sealed record RawRpcResponseResult<TValue>
    {
        [JsonPropertyName("value")]
        public RawRpcResponseResultValue<TValue> Value { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public sealed record RawRpcResponseResultValue<TData>
    {
        [JsonPropertyName("owner")]
        public string Owner { get; set; }

        [JsonPropertyName("value")]
        public RawRpcResponseResultValueData<TData> Data { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public sealed record RawRpcResponseResultValueData<TData>
    {
        [JsonPropertyName("parsed")]
        public TData Parsed { get; set; }
    }
}
