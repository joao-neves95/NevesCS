namespace NevesCS.Abstractions.Traits
{
    public interface IAuditableUtcCreation
    {
        public DateTimeOffset CreationUtcDateTime { get; }
    }
}
