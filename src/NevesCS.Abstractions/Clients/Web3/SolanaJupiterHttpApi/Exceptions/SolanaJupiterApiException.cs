using NevesCS.Abstractions.Exceptions;

namespace NevesCS.Abstractions.Clients.Web3.SolanaJupiterHttpApi.Exceptions
{
    public class SolanaJupiterApiException : HttpNevesCsException
    {
        public SolanaJupiterApiException()
        {
        }

        public SolanaJupiterApiException(string? message) : base(message)
        {
        }

        public SolanaJupiterApiException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        public SolanaJupiterApiException(HttpResponseMessage message, string? requestContent)
            : base(message, requestContent)
        {
        }
    }
}
