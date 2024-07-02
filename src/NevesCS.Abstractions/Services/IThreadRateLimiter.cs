namespace NevesCS.Abstractions.Services
{
    public interface IThreadRateLimiter
    {
        public void Reset();

        public Task WaitAsync(CancellationToken cancellationToken = default);
    }
}
