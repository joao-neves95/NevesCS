namespace NevesCS.Abstractions.Traits
{
    public interface IDuration
    {
        public DateTimeOffset Start { get; set; }

        public DateTimeOffset? End { get; set; }
    }
}
