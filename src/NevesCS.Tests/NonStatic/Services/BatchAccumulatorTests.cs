using System.Collections.Concurrent;
using System.Diagnostics;

using FluentAssertions;

using NevesCS.NonStatic.Services;

namespace NevesCS.Tests.NonStatic.Services;

public class BatchAccumulatorTests
{
    private const int MillisecondsDelay = 60;

    private const int SettleMilliseconds = 2000;

    [Fact]
    public async Task Add__AfterQuietPeriod__InvokesActionOnceWithEveryAccumulatedItem()
    {
        var batches = new BatchCollector<int>();
        using var sut = new BatchAccumulator<int>(batches.Collect, MillisecondsDelay);

        sut.Add(1);
        sut.Add(2);
        sut.Add(3);

        await batches.WaitForBatchCountAsync(1);

        batches.Batches.Should().ContainSingle()
            .Which.Should().Equal(1, 2, 3);
    }

    [Fact]
    public async Task Add__WhileItemsKeepArrivingWithinTheWindow__DoesNotFlushEarly()
    {
        var batches = new BatchCollector<int>();
        using var sut = new BatchAccumulator<int>(batches.Collect, MillisecondsDelay);

        for (int i = 0; i < 5; ++i)
        {
            sut.Add(i);
            await Task.Delay(MillisecondsDelay / 3);
        }

        batches.Batches.Should().BeEmpty("the sliding window is reset by every Add");

        await batches.WaitForBatchCountAsync(1);

        batches.Batches.Should().ContainSingle()
            .Which.Should().Equal(0, 1, 2, 3, 4);
    }

    [Fact]
    public async Task Add__AfterAPreviousFlush__StartsAFreshBatch()
    {
        var batches = new BatchCollector<int>();
        using var sut = new BatchAccumulator<int>(batches.Collect, MillisecondsDelay);

        sut.Add(1);
        sut.Add(2);
        await batches.WaitForBatchCountAsync(1);

        sut.Add(3);
        sut.Add(4);
        await batches.WaitForBatchCountAsync(2);

        batches.Batches.Should().HaveCount(2);
        batches.Batches[0].Should().Equal(1, 2);
        batches.Batches[1].Should().Equal(3, 4);
    }

    [Fact]
    public async Task Add__AfterDispose__IsIgnoredAndDoesNotThrow()
    {
        var batches = new BatchCollector<int>();
        var sut = new BatchAccumulator<int>(batches.Collect, MillisecondsDelay);

        sut.Dispose();

        sut.Invoking(x => x.Add(1)).Should().NotThrow();

        await Task.Delay(SettleMilliseconds);

        batches.Batches.Should().BeEmpty();
    }

    [Fact]
    public async Task Dispose__BeforeThePendingFlush__CancelsIt()
    {
        var batches = new BatchCollector<int>();
        var sut = new BatchAccumulator<int>(batches.Collect, MillisecondsDelay);

        sut.Add(1);
        sut.Dispose();

        await Task.Delay(SettleMilliseconds);

        batches.Batches.Should().BeEmpty();
    }

    [Fact]
    public void Dispose__CalledRepeatedly__DoesNotThrow()
    {
        var sut = new BatchAccumulator<int>((_) => { }, MillisecondsDelay);

        sut.Invoking(x =>
        {
            x.Dispose();
            x.Dispose();
        }).Should().NotThrow();
    }

    [Fact]
    public void Initialize__WhenAlreadyInitialized__ThrowsInvalidOperationException()
    {
        using var sut = new BatchAccumulator<int>((_) => { }, MillisecondsDelay);

        sut.Invoking(x => x.Initialize((_) => { }, MillisecondsDelay))
            .Should().Throw<InvalidOperationException>();
    }

    [Fact]
    public async Task Initialize__OnAnInstanceBuiltWithTheParameterlessConstructor__EnablesAccumulation()
    {
        var batches = new BatchCollector<int>();
        using var sut = new BatchAccumulator<int>();

        sut.Initialize(batches.Collect, MillisecondsDelay);

        sut.Add(7);
        sut.Add(8);

        await batches.WaitForBatchCountAsync(1);

        batches.Batches.Should().ContainSingle()
            .Which.Should().Equal(7, 8);
    }

    [Fact]
    public async Task Add__FromManyThreadsConcurrently__DeliversEveryItemExactlyOnce()
    {
        const int threads = 8;
        const int itemsPerThread = 500;

        var batches = new BatchCollector<int>();
        using var sut = new BatchAccumulator<int>(batches.Collect, MillisecondsDelay);

        await Task.WhenAll(Enumerable.Range(0, threads).Select(threadIndex => Task.Run(() =>
        {
            for (int i = 0; i < itemsPerThread; ++i)
            {
                sut.Add((threadIndex * itemsPerThread) + i);
            }
        })));

        await batches.WaitForNoActivityAsync(TimeSpan.FromMilliseconds(MillisecondsDelay * 4));

        var delivered = batches.Batches.SelectMany(batch => batch).ToArray();

        delivered.Should().HaveCount(threads * itemsPerThread);
        delivered.Should().OnlyHaveUniqueItems();
        delivered.Should().BeEquivalentTo(Enumerable.Range(0, threads * itemsPerThread));
    }

    private sealed class BatchCollector<T>
    {
        private readonly object _gate = new();

        private readonly List<IReadOnlyList<T>> _batches = [];

        private long _lastActivityTimestamp = Stopwatch.GetTimestamp();

        public IReadOnlyList<IReadOnlyList<T>> Batches
        {
            get
            {
                lock (_gate)
                {
                    return _batches.ToArray();
                }
            }
        }

        public void Collect(IReadOnlyList<T> batch)
        {
            lock (_gate)
            {
                _batches.Add(batch);
                _lastActivityTimestamp = Stopwatch.GetTimestamp();
            }
        }

        public async Task WaitForBatchCountAsync(int expectedCount)
        {
            var timeout = TimeSpan.FromMilliseconds(SettleMilliseconds);
            var start = Stopwatch.GetTimestamp();

            while (Stopwatch.GetElapsedTime(start) < timeout)
            {
                lock (_gate)
                {
                    if (_batches.Count >= expectedCount)
                    {
                        return;
                    }
                }

                await Task.Delay(10);
            }

            throw new TimeoutException($"Expected at least {expectedCount} batch(es) within {timeout.TotalMilliseconds}ms.");
        }

        public async Task WaitForNoActivityAsync(TimeSpan quietFor)
        {
            while (true)
            {
                TimeSpan sinceLastActivity;

                lock (_gate)
                {
                    sinceLastActivity = Stopwatch.GetElapsedTime(_lastActivityTimestamp);
                }

                if (sinceLastActivity >= quietFor)
                {
                    return;
                }

                await Task.Delay(10);
            }
        }
    }
}
