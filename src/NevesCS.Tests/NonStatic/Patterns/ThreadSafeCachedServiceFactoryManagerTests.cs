using FluentAssertions;

using NevesCS.Abstractions.Interfaces;
using NevesCS.NonStatic.Clients;
using NevesCS.NonStatic.Patterns;

namespace NevesCS.Tests.NonStatic.Patterns;

public class ThreadSafeCachedServiceFactoryManagerTests
{
    private sealed class TestService
    {
        public int Value { get; set; }
    }

    private sealed class TestServiceFactory : ICachedServiceFactory<TestService>
    {
        public TestService Create(string key)
        {
            return new TestService();
        }
    }

    [Fact]
    public async Task CreateAsync__WithSyncCallback__ReturnsTheCallbackResult()
    {
        using var sut = new ThreadSafeCachedServiceFactoryManager<TestService>(
            CachedFactoryOptions.NewMaxLifetime(),
            new TestServiceFactory());

        var result = await sut.CreateAsync("key", service =>
        {
            service.Value = 42;
            return service.Value;
        });

        result.Should().Be(42);
    }

    [Fact]
    public async Task CreateAsync__WithAsyncCallback__ReturnsTheCallbackResult()
    {
        using var sut = new ThreadSafeCachedServiceFactoryManager<TestService>(
            CachedFactoryOptions.NewMaxLifetime(),
            new TestServiceFactory());

        var result = await sut.CreateAsync("key", async service =>
        {
            await Task.Delay(1);
            service.Value = 7;
            return service.Value;
        });

        result.Should().Be(7);
    }

    [Fact]
    public async Task CreateAsync__WithSameKey__ReusesTheSameServiceInstance()
    {
        using var sut = new ThreadSafeCachedServiceFactoryManager<TestService>(
            CachedFactoryOptions.NewMaxLifetime(),
            new TestServiceFactory());

        var first = await sut.CreateAsync("key", service => service);
        var second = await sut.CreateAsync("key", service => service);

        second.Should().BeSameAs(first);
    }

    [Fact]
    public async Task CreateAsync__WithConcurrentCallsOnTheSameKey__SerializesAccess()
    {
        using var sut = new ThreadSafeCachedServiceFactoryManager<TestService>(
            CachedFactoryOptions.NewMaxLifetime(),
            new TestServiceFactory());

        var concurrentEntries = 0;
        var maxObservedConcurrentEntries = 0;
        var gate = new object();

        async Task<int> UseServiceAsync(TestService service)
        {
            lock (gate)
            {
                concurrentEntries++;
                maxObservedConcurrentEntries = Math.Max(maxObservedConcurrentEntries, concurrentEntries);
            }

            await Task.Delay(20);

            lock (gate)
            {
                concurrentEntries--;
            }

            return 0;
        }

        var calls = Enumerable.Range(0, 5)
            .Select(_ => sut.CreateAsync("key", UseServiceAsync));

        await Task.WhenAll(calls);

        maxObservedConcurrentEntries.Should().Be(1);
    }
}
