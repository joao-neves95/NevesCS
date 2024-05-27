using System.Text.Json.Serialization;

namespace NevesCS.NonStatic.Clients.Web3.SolanaJupiterHttpApi.Models
{
    public record SolanaJupiterV6GetPriceResponse
    {
        [JsonPropertyName("data")]
        public Dictionary<string, SolanaJupiterTokenPriceInfo> Data { get; set; }

        [JsonPropertyName("timeTaken")]
        public decimal TimeTaken { get; set; }
    }

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
