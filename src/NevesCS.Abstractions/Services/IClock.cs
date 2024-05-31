namespace NevesCS.Abstractions.Services
{
    public interface IClock
    {
        public DateTimeOffset GetTime();
    }
}
