using System.Diagnostics.CodeAnalysis;

namespace NevesCS.AspNetCore.Abstractions.Models.ApiExceptions
{
    [ExcludeFromCodeCoverage]
    public class NotFoundException : Exception
    {
        public NotFoundException() : base()
        {
        }

        public NotFoundException(string? message) : base(message)
        {
        }

        public NotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
