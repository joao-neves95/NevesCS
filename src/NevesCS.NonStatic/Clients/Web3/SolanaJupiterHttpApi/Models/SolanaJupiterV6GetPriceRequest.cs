namespace NevesCS.NonStatic.Clients.Web3.SolanaJupiterHttpApi.Models
{
    public readonly record struct SolanaJupiterV6GetPriceRequest(IEnumerable<string> Ids, string VsToken);
}
