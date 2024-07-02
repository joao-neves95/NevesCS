using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace NevesCS.Abstractions.Clients.Web3.Solana.Models
{
    [ExcludeFromCodeCoverage]
    public sealed record TokenAccountInfoResponse
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("info")]
        public TokenAccountInfoResponseResultValueDataParsedInfo Info { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public sealed record TokenAccountInfoResponseResultValueDataParsedInfo
    {
        [JsonPropertyName("decimals")]
        public int Decimals { get; set; }
    }
}
