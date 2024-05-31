using NevesCS.Abstractions.Services;

using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace NevesCS.NonStatic.Services
{
    public sealed class FrozenClock([NotNull, DisallowNull, Required] DateTimeOffset FrozenDateTime)

        : IClock
    {
        public DateTimeOffset GetTime()
        {
            return FrozenDateTime;
        }
    }
}
