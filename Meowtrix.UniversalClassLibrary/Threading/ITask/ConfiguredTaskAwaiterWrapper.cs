using System;
using System.Runtime.CompilerServices;

namespace Meowtrix.ITask
{
    internal class ConfiguredTaskAwaiterWrapper : IAwaiter
    {
        private readonly ConfiguredTaskAwaitable.ConfiguredTaskAwaiter taskAwaiter;

        public ConfiguredTaskAwaiterWrapper(ConfiguredTaskAwaitable.ConfiguredTaskAwaiter awaiter)
        {
            taskAwaiter = awaiter;
        }

        bool IAwaiter.IsCompleted => taskAwaiter.IsCompleted;

        void INotifyCompletion.OnCompleted(Action continuation) => taskAwaiter.OnCompleted(continuation);

        void ICriticalNotifyCompletion.UnsafeOnCompleted(Action continuation) => taskAwaiter.UnsafeOnCompleted(continuation);

        void IAwaiter.GetResult() => taskAwaiter.GetResult();
    }
    internal class ConfiguredTaskAwaiterWrapper<TResult> : IAwaiter<TResult>
    {
        private readonly ConfiguredTaskAwaitable<TResult>.ConfiguredTaskAwaiter taskAwaiter;

        public ConfiguredTaskAwaiterWrapper(ConfiguredTaskAwaitable<TResult>.ConfiguredTaskAwaiter awaiter)
        {
            taskAwaiter = awaiter;
        }

        bool IAwaiter<TResult>.IsCompleted => taskAwaiter.IsCompleted;

        void INotifyCompletion.OnCompleted(Action continuation) => taskAwaiter.OnCompleted(continuation);

        void ICriticalNotifyCompletion.UnsafeOnCompleted(Action continuation) => taskAwaiter.UnsafeOnCompleted(continuation);

        TResult IAwaiter<TResult>.GetResult() => taskAwaiter.GetResult();
    }
}
