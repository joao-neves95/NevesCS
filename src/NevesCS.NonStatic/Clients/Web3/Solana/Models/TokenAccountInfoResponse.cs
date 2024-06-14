using System.Text.Json.Serialization;

namespace NevesCS.NonStatic.Clients.Web3.Solana.Models
{
    public sealed record TokenAccountInfoResponse
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("info")]
        public TokenAccountInfoResponseResultValueDataParsedInfo Info { get; set; }
    }

    public sealed record TokenAccountInfoResponseResultValueDataParsedInfo
    {
        [JsonPropertyName("decimals")]
        public int Decimals { get; set; }
    }
}
