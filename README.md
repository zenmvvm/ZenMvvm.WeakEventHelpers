# ![Logo](art/icon@64x64.png) ZenMvvm.WeakEventHelpers
Avoid memory leaks by using Weak Events. This package provides a Weak Event Manager to create weak events and a Weak Event Handler to weakly subscribe to standard events.

[![Coverage](https://raw.githubusercontent.com/zenmvvm/ZenMvvm.WeakEventHelpers/develop/coverage/badge_linecoverage.svg)](https://htmlpreview.github.io/?https://raw.githubusercontent.com/zenmvvm/ZenMvvm.WeakEventHelpers/develop/coverage/index.html) [![NuGet](https://buildstats.info/nuget/ZenMvvm.WeakEventHelpers?includePreReleases=false)](https://www.nuget.org/packages/ZenMvvm.WeakEventHelpers/)

## WeakEvents

Listening for events can lead to memory leaks. The typical pattern for listening to an event, creates a strong reference from the event source to the event listener. The listener won't be garbage collected until the  event handler is explicitly removed. It is easy to forget to remove listeners, resulting in unintended memory leaks. Furthermore, in certain circumstances, you might want the object lifetime of the listener to be controlled by other factors, such as whether it currently belongs to the visual tree of the application, and not by the lifetime of the source.

If you want to provide a weak event, use WeakEventManager. Listeners can then subscribe using the usual syntax `source.MyWeakEvent += OnSomeEvent;`

If you want to consume a strong event with a weak reference, use WeakEventHandler: `source.SomeStrongEvent += new WeakEventHandler<EventArgs>(OnSomeEvent).Handler;`


## WeakEventManager

Taken from [Xamarin.Forms.WeakEventManager](https://github.com/xamarin/Xamarin.Forms/blob/master/Xamarin.Forms.Core/WeakEventManager.cs) where Xamarin has kept the class private. WeakEventHelpers exposes this class publically so that you can use it in your own projects.

Creating events using the WeakEventManager, will ensure that they maintain a weak reference to their listeners:

```c#
readonly WeakEventManager _weakEventManager = new WeakEventManager();

public event EventHandler CanExecuteChanged
{
    add => _weakEventManager.AddEventHandler(value);
    remove => _weakEventManager.RemoveEventHandler(value);
}
public void RaiseCanExecuteChanged() => _weakEventManager.HandleEvent(this, EventArgs.Empty, nameof(CanExecuteChanged));

```

## WeakEventHandler

From [Paul Stovell's Blog](http://paulstovell.com/blog/weakevents). Instead of subscribing to an event with your handler:

```c#
source.SomeStrongEvent += OnSomeEvent;
```

, wrap it in the WeakEventHandler:

```c#
source.SomeStrongEvent += new WeakEventHandler<EventArgs>(OnSomeEvent).Handler;
```


> :memo: Note that the WeakEventHandler wrapper won't be GC'ed, leaving a small "sacrifice" object alive in place of your listener. Not a complete solution, but a better alternative.

