namespace Firell.Toolkit.Common.Dispatching;

public enum DispatcherQueuePriority
{
    /// <summary>
    /// <see cref="Low"/> priority work will be scheduled when there isn't any other work to process.
    /// Work at low priority can be preempted by new incoming <see cref="High"/> and <see cref="Normal"/> priority tasks.
    /// </summary>
    Low,

    /// <summary>
    /// Work will be dispatched once all <see cref="High"/> priority tasks are dispatched.
    /// If a new <see cref="High"/> priority work is scheduled, all new <see cref="High"/> priority tasks are processed before resuming <see cref="Normal"/> tasks.
    /// This is the default priority.
    /// </summary>
    Normal,

    /// <summary>
    /// Work scheduled at <see cref="High"/> priority will be dispatched first, along with other <see cref="High"/> priority System tasks, before processing <see cref="Normal"/> or <see cref="Low"/> priority work.
    /// </summary>
    High
}
