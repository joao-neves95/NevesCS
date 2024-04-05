using System.Diagnostics.CodeAnalysis;

namespace NevesCS.AspNetCore.Abstractions.Models.Configuration
{
    [ExcludeFromCodeCoverage]
    public class HttpConfig
    {
        public int NumberOfHttpRetries { get; set; }
    }
}
