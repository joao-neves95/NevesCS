using System.Diagnostics.CodeAnalysis;

namespace NevesCS.Abstractions.Exceptions
{
    [ExcludeFromCodeCoverage]
    public class NevesCsException : Exception
    {
        public NevesCsException() : base()
        {
        }

        public NevesCsException(string? message) : base(message)
        {
        }

        public NevesCsException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
