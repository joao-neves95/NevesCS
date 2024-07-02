using NevesCS.Abstractions.Exceptions;

namespace NevesCS.Abstractions.Clients.Web3.Solana.Exceptions
{
    public class SolanaRpcException : NevesCsException
    {
        public SolanaRpcException()
        {
        }

        public SolanaRpcException(string? message) : base(message)
        {
        }

        public SolanaRpcException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
