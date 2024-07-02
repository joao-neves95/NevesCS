using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace NevesCS.Abstractions.Clients.Web3.SolanaJupiterHttpApi.Models
{
    [ExcludeFromCodeCoverage]
    public record SolanaJupiterV6GetPriceApiResponse
    {
        [JsonPropertyName("data")]
        public Dictionary<string, SolanaJupiterTokenPriceInfo> Data { get; set; }

        [JsonPropertyName("timeTaken")]
        public decimal TimeTaken { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public record SolanaJupiterTokenPriceInfo
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("mintSymbol")]
        public string MintSymbol { get; set; }

        [JsonPropertyName("vsToken")]
        public string VsToken { get; set; }

        [JsonPropertyName("vsTokenSymbol")]
        public string VsTokenSymbol { get; set; }

        [JsonPropertyName("price")]
        public decimal Price { get; set; }
    }
}
