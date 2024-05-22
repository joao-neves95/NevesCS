using NevesCS.Abstractions.Traits;

namespace NevesCS.Abstractions.Types
{
    public abstract record AuditableCreationRecord : IAuditableUtcCreation
    {
        public DateTimeOffset CreationUtcDateTime { get; } = DateTimeOffset.UtcNow;
    }
}
