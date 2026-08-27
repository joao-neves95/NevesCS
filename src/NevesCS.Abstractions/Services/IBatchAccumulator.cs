namespace NevesCS.Abstractions.Services;

/// <summary>
/// Accumulates items and flushes them as a single batch once a sliding inactivity
/// window elapses. Every <see cref="Add"/> call restarts the window; when no item
/// arrives for the configured delay, the buffered items are handed to the registered
/// callback and the buffer is cleared.
///
/// </summary>
public interface IBatchAccumulator<T> : IDisposable
{
    public void Initialize(Action<IReadOnlyList<T>> action, int millisecondsDelay);

    /// <summary>
    /// Adds an item to the current batch and (re)starts the inactivity window.
    ///
    /// </summary>
    public void Add(T item);
}
