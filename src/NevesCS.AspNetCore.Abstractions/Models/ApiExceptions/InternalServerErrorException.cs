
namespace NevesCS.AspNetCore.Abstractions.Models.ApiExceptions
{
    public class InternalServerErrorException : Exception
    {
        public InternalServerErrorException() : base()
        {
        }

        public InternalServerErrorException(string? message) : base(message)
        {
        }

        public InternalServerErrorException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
