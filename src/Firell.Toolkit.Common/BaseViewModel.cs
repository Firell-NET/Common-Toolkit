using System.ComponentModel;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;

using Firell.Toolkit.Common.Dispatching;

namespace Firell.Toolkit.Common;

public abstract class BaseViewModel : ObservableRecipient, IDisposable
{
    public BaseViewModel()
    {
        Initialization = Task.CompletedTask;
    }

    public BaseViewModel(IDispatcherQueue dispatcherQueue)
    {
        DispatcherQueue = dispatcherQueue;
    }

    /// <summary>
    /// The <see cref="IDispatcherQueue"/> that will be used to invoke <see cref="OnPropertyChanged(PropertyChangedEventArgs)"/> and <see cref="OnPropertyChanging(PropertyChangingEventArgs)"/> events.
    /// </summary>
    protected IDispatcherQueue? DispatcherQueue { get; set; }

    private TaskNotifier _initialization = null!;
    public Task Initialization
    {
        get => _initialization!;
        set => SetPropertyAndNotifyOnCompletion(ref _initialization, value);
    }

    /// <summary>
    /// Gets whether the view model has initialized.
    /// </summary>
    public bool IsInitialized
    {
        get => Initialization.IsCompleted;
    }

    /// <summary>
    /// Gets whether the view model has initialized sucessfully.
    /// </summary>
    public bool IsInitializedSucessfully
    {
        get => Initialization.IsCompletedSuccessfully;
    }

    protected override void OnPropertyChanged(PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(Initialization))
        {
            OnPropertyChanged(nameof(IsInitialized));
            OnPropertyChanged(nameof(IsInitializedSucessfully));
            return;
        }

        if (DispatcherQueue != null)
        {
            DispatcherQueue.Enqueue(() => base.OnPropertyChanged(e));
            return;
        }

        base.OnPropertyChanged(e);
    }

    protected override void OnPropertyChanging(PropertyChangingEventArgs e)
    {
        if (DispatcherQueue != null)
        {
            DispatcherQueue.Enqueue(() => base.OnPropertyChanging(e));
            return;
        }

        base.OnPropertyChanging(e);
    }

    public void Dispose()
    {
        WeakReferenceMessenger.Default.UnregisterAll(this);
        GC.SuppressFinalize(this);
    }
}
