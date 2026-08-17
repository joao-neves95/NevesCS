using FluentAssertions;

using NevesCS.Abstractions.Interfaces;
using NevesCS.NonStatic.Clients;
using NevesCS.NonStatic.Patterns;

namespace NevesCS.Tests.NonStatic.Patterns;

public class CachedServiceFactoryManagerTests
{
    private sealed class DisposableTestService : IDisposable
    {
        public bool IsDisposed { get; private set; }

        public void Dispose()
        {
            IsDisposed = true;
        }
    }

    private sealed class TestServiceFactory : ICachedServiceFactory<DisposableTestService>
    {
        public int CreateCallCount;

        public DisposableTestService Create(string key)
        {
            Interlocked.Increment(ref CreateCallCount);

            return new DisposableTestService();
        }
    }

    private static async Task WaitUntilAsync(Func<bool> condition, TimeSpan timeout)
    {
        using var cts = new CancellationTokenSource(timeout);

        while (!condition())
        {
            if (cts.IsCancellationRequested)
            {
                throw new TimeoutException("Condition was not met within the given timeout.");
            }

            await Task.Delay(5);
        }
    }

    [Fact]
    public void Create__WhenCalledTwiceWithTheSameKey__ReturnsTheSameInstance()
    {
        var factory = new TestServiceFactory();
        using var sut = new CachedServiceFactoryManager<DisposableTestService>(
            CachedFactoryOptions.NewMaxLifetime(),
            factory);

        var first = sut.Create("key");
        var second = sut.Create("key");

        second.Should().BeSameAs(first);
        factory.CreateCallCount.Should().Be(1);
    }

    [Fact]
    public void Create__WhenCalledWithDifferentKeys__ReturnsDifferentInstances()
    {
        var factory = new TestServiceFactory();
        using var sut = new CachedServiceFactoryManager<DisposableTestService>(
            CachedFactoryOptions.NewMaxLifetime(),
            factory);

        var a = sut.Create("a");
        var b = sut.Create("b");

        a.Should().NotBeSameAs(b);
    }

    [Fact]
    public void Constructor__WhenServiceFactoryIsNull__Throws()
    {
        var act = () => new CachedServiceFactoryManager<DisposableTestService>(
            CachedFactoryOptions.NewMaxLifetime(),
            null!);

        act.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public async Task ExpiredItem__IsNotDisposedByTheSweepThatRemovesItFromTheCache()
    {
        var factory = new TestServiceFactory();
        var options = new CachedFactoryOptions(
            maxLifetime: TimeSpan.FromMilliseconds(20),
            checkExpiredCacheItemsEvery: TimeSpan.FromMilliseconds(200));

        using var sut = new CachedServiceFactoryManager<DisposableTestService>(options, factory);

        var service = sut.Create("key");

        // Wait past MaxLifetime and the first sweep tick, so the item is expired and removed from
        // the cache (a subsequent Create() call would build a fresh instance), but not yet disposed:
        // disposal of items removed by a given sweep is deferred to the *next* sweep, giving callers
        // that already hold the instance a full interval to finish using it safely.
        await Task.Delay(TimeSpan.FromMilliseconds(230));

        service.IsDisposed.Should().BeFalse();

        var afterExpiry = sut.Create("key");
        afterExpiry.Should().NotBeSameAs(service);
    }

    [Fact]
    public async Task ExpiredItem__IsDisposedOnceTheGracePeriodElapses()
    {
        var factory = new TestServiceFactory();
        var options = new CachedFactoryOptions(
            maxLifetime: TimeSpan.FromMilliseconds(20),
            checkExpiredCacheItemsEvery: TimeSpan.FromMilliseconds(50));

        using var sut = new CachedServiceFactoryManager<DisposableTestService>(options, factory);

        var service = sut.Create("key");

        await WaitUntilAsync(() => service.IsDisposed, TimeSpan.FromSeconds(5));

        service.IsDisposed.Should().BeTrue();
    }

    [Fact]
    public void Dispose__DisposesAllCurrentlyCachedItems()
    {
        var factory = new TestServiceFactory();
        var sut = new CachedServiceFactoryManager<DisposableTestService>(
            CachedFactoryOptions.NewMaxLifetime(),
            factory);

        var service = sut.Create("key");

        sut.Dispose();

        service.IsDisposed.Should().BeTrue();
    }

    [Fact]
    public async Task Dispose__DisposesItemsPendingDeferredDisposal()
    {
        var factory = new TestServiceFactory();
        var options = new CachedFactoryOptions(
            maxLifetime: TimeSpan.FromMilliseconds(20),
            checkExpiredCacheItemsEvery: TimeSpan.FromMilliseconds(200));

        var sut = new CachedServiceFactoryManager<DisposableTestService>(options, factory);

        var service = sut.Create("key");

        // Push the item into the "pending disposal" state (expired, removed from the cache by the
        // first sweep, awaiting the deferred dispose on the second) without waiting for the second
        // sweep to actually dispose it.
        await Task.Delay(TimeSpan.FromMilliseconds(230));
        service.IsDisposed.Should().BeFalse();

        sut.Dispose();

        service.IsDisposed.Should().BeTrue();
    }
}
