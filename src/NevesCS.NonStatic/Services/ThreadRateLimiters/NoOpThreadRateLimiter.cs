using NevesCS.Abstractions.Services;

namespace NevesCS.NonStatic.Services.ThreadRateLimiters
{
    public sealed class NoOpThreadRateLimiter : IThreadRateLimiter
    {
        public void Reset()
        {
        }

        public Task WaitAsync(CancellationToken cancellationToken = default)
        {
            return Task.CompletedTask;
        }
    }
}
