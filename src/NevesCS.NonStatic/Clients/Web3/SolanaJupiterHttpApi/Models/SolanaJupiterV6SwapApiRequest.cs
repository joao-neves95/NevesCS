using System.Text.Json.Serialization;

namespace NevesCS.NonStatic.Clients.Web3.SolanaJupiterHttpApi.Models
{
    public readonly record struct SolanaJupiterV6SwapApiRequest
    {
        [JsonPropertyName("quoteResponse")]
        public required SolanaJupiterV6QuoteApiResponse QuoteResponse { get; init; }

        [JsonPropertyName("userPublicKey")]
        public required string UserPublicKey { get; init; }
    }
}
