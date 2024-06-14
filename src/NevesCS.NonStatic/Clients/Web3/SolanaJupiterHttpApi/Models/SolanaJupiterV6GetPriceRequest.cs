namespace NevesCS.NonStatic.Clients.Web3.SolanaJupiterHttpApi.Models
{
    public readonly record struct SolanaJupiterV6GetPriceRequest
    {
        public required IEnumerable<string> Ids { get; init; }

        public required string VsToken { get; init; }
    }
}
