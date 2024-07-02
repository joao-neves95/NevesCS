namespace NevesCS.NonStatic.Clients
{
    public static class TickerUtils
    {
        public static string BuildCoingeckoTicker(string baseAsset, string quoteAsset)
        {
            return $"{baseAsset}/{quoteAsset}";
        }

        public static string BuildCoingeckoTickerId(string baseAddress, string quoteAddress)
        {
            return $"{baseAddress}_{quoteAddress}";
        }
    }
}
