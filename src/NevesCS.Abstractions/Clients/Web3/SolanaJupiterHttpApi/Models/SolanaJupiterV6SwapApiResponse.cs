using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace NevesCS.Abstractions.Clients.Web3.SolanaJupiterHttpApi.Models
{
    [ExcludeFromCodeCoverage]
    public readonly record struct SolanaJupiterV6SwapApiResponse
    {
        [JsonPropertyName("swapTransaction")]
        public required string SwapTransaction { get; init; }

        [JsonPropertyName("lastValidBlockHeight")]
        public required int LastValidBlockHeight { get; init; }
    }
}
