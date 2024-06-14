using Solnet.Wallet;

namespace NevesCS.Static.Utils.Web3.Solana
{
    public static class SolanaTransactionUtils
    {
        public static byte[] SignRawTransaction(string base64EncodedTx, Wallet wallet)
        {
            var rawTxData = Convert.FromBase64String(base64EncodedTx);
            SignRawTransaction(ref rawTxData, wallet);

            return rawTxData;
        }

        public static void SignRawTransaction(ref byte[] rawTx, Wallet wallet)
        {
            var txMessage = rawTx[(1 + 64 * 2)..]; // Advance sig count byte + signature bytes.
            var signature = wallet.Account.PrivateKey.Sign(txMessage);
            Array.Copy(signature, 0, rawTx, 1, signature.Length);
        }
    }
}
