﻿using System;
using System.Reflection;

namespace ZenMvvm.Helpers
{
    /// <summary>
    /// From: http://paulstovell.com/blog/weakevents
    /// Note - this wrapper is kept alive and not GC'ed.
    /// Also good to read https://www.codeproject.com/Articles/29922/Weak-Events-in-C#heading0015
    /// </summary>
    /// <typeparam name="TEventArgs"></typeparam>
    public sealed class WeakEventHandler<TEventArgs> : IWeakEventHandler<TEventArgs> where TEventArgs : EventArgs
    {
        private readonly WeakReference _targetReference;
        private readonly MethodInfo _method;

        /// <summary>
        /// Instantiates a new instance of the <see cref="WeakEventHandler{TEventArgs}"/>
        ///  with provided <paramref name="callback"/>
        /// </summary>
        public WeakEventHandler(EventHandler<TEventArgs> callback)
        {
            _method = callback.GetMethodInfo();
            _targetReference = new WeakReference(callback.Target, true);
        }

        /// <summary>
        /// Invokes the callback
        /// </summary>
        public void Handler(object sender, TEventArgs e)
        {
            var target = _targetReference.Target;
            if (target != null)
            {
                ((Action<object, TEventArgs>)_method
                    .CreateDelegate(typeof(Action<object, TEventArgs>), target))
                    ?.Invoke(sender, e);
            }
        }

        //todo do we need this force-UI thread option? Can we replicate without Xamarin dependency?
        
        ///// <summary>
        ///// Invokes the callback on the Device main (UI) thread
        ///// </summary>
        //public void HandlerOnMainThread(object sender, TEventArgs e)
        //{
        //    var target = _targetReference.Target;

        //    if (target != null)
        //        Device.BeginInvokeOnMainThread(() =>
        //            ((Action<object, TEventArgs>)_method
        //                .CreateDelegate(typeof(Action<object, TEventArgs>), target))
        //                ?.Invoke(sender, e));
        //}
    }
}
