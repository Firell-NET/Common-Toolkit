namespace Firell.Toolkit.Common.Dispatching;

public interface IDispatcherQueue
{
    public bool HasThreadAccess { get; }

    public bool Enqueue(Action action, DispatcherQueuePriority priority = DispatcherQueuePriority.Normal);
    public Task EnqueueAsync(Action action, DispatcherQueuePriority priority = DispatcherQueuePriority.Normal);

    public Task EnqueueAsync(Func<Task> function, DispatcherQueuePriority priority = DispatcherQueuePriority.Normal);
    public Task<T> EnqueueAsync<T>(Func<T> function, DispatcherQueuePriority priority = DispatcherQueuePriority.Normal);
}
