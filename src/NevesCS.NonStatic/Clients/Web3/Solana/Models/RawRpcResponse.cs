using System.Text.Json.Serialization;

namespace NevesCS.NonStatic.Clients.Web3.Solana.Models
{
    public sealed record RawRpcResponse<TValue>
    {
        [JsonPropertyName("result")]
        public RawRpcResponseResult<TValue> Result { get; set; }
    }

    public sealed record RawRpcResponseResult<TValue>
    {
        [JsonPropertyName("value")]
        public RawRpcResponseResultValue<TValue> Value { get; set; }
    }

    public sealed record RawRpcResponseResultValue<TData>
    {
        [JsonPropertyName("owner")]
        public string Owner { get; set; }

        [JsonPropertyName("value")]
        public RawRpcResponseResultValueData<TData> Data { get; set; }
    }

    public sealed record RawRpcResponseResultValueData<TData>
    {
        [JsonPropertyName("parsed")]
        public TData Parsed { get; set; }
    }
}
