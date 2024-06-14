using System.Text.Json.Serialization;

namespace NevesCS.NonStatic.Clients.Web3.SolanaJupiterHttpApi.Models
{
    public readonly record struct SolanaJupiterV6SwapApiResponse
    {
        [JsonPropertyName("swapTransaction")]
        public required string SwapTransaction { get; init; }

        [JsonPropertyName("lastValidBlockHeight")]
        public required int LastValidBlockHeight { get; init; }
    }
}
