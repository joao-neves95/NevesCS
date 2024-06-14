using System.Text.Json.Serialization;

namespace NevesCS.NonStatic.Clients.Web3.SolanaJupiterHttpApi.Models
{
    public sealed record SolanaJupiterV6CoingeckoTickersResponse
    {
        /// <summary>
        /// "{base-addy}_{quote-addy}"
        /// </summary>
        [JsonPropertyName("ticker_id")]
        public string TickerId { get; set; }

        /// <summary>
        /// "{base-symbol}_{quote-symbol}"
        /// </summary>
        [JsonPropertyName("ticker")]
        public string Ticker { get; set; }

        [JsonPropertyName("base_currency")]
        public string BaseCurrency { get; set; }

        [JsonPropertyName("target_currency")]
        public string QuoteCurrency { get; set; }

        [JsonPropertyName("last_price")]
        public string LastPrice { get; set; }

        [JsonPropertyName("base_volume")]
        public string BaseVolume { get; set; }

        [JsonPropertyName("target_volume")]
        public string QuoteVolume { get; set; }

        [JsonPropertyName("high")]
        public string High { get; set; }

        [JsonPropertyName("low")]
        public string Low { get; set; }

        [JsonPropertyName("base_address")]
        public string BaseAddress { get; set; }

        [JsonPropertyName("target_address")]
        public string QuoteAddress { get; set; }
    }
}
