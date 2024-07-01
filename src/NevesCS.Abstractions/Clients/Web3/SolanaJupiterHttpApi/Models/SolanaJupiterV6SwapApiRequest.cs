using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace NevesCS.Abstractions.Clients.Web3.SolanaJupiterHttpApi.Models
{
    [ExcludeFromCodeCoverage]
    public readonly record struct SolanaJupiterV6SwapApiRequest
    {
        [JsonPropertyName("quoteResponse")]
        public required SolanaJupiterV6QuoteApiResponse QuoteResponse { get; init; }

        [JsonPropertyName("userPublicKey")]
        public required string UserPublicKey { get; init; }
    }
}
