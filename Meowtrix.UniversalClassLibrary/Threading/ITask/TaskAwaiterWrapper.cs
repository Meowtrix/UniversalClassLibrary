using System;
using System.Runtime.CompilerServices;

namespace Meowtrix.ITask
{
    internal class TaskAwaiterWrapper : IAwaiter
    {
        private readonly TaskAwaiter taskAwaiter;

        public TaskAwaiterWrapper(TaskAwaiter awaiter)
        {
            taskAwaiter = awaiter;
        }

        bool IAwaiter.IsCompleted => taskAwaiter.IsCompleted;

        void INotifyCompletion.OnCompleted(Action continuation) => taskAwaiter.OnCompleted(continuation);

        void ICriticalNotifyCompletion.UnsafeOnCompleted(Action continuation) => taskAwaiter.UnsafeOnCompleted(continuation);

        void IAwaiter.GetResult() => taskAwaiter.GetResult();
    }

    internal class TaskAwaiterWrapper<TResult> : IAwaiter<TResult>
    {
        private readonly TaskAwaiter<TResult> taskAwaiter;

        public TaskAwaiterWrapper(TaskAwaiter<TResult> awaiter)
        {
            taskAwaiter = awaiter;
        }

        bool IAwaiter<TResult>.IsCompleted => taskAwaiter.IsCompleted;

        void INotifyCompletion.OnCompleted(Action continuation) => taskAwaiter.OnCompleted(continuation);

        void ICriticalNotifyCompletion.UnsafeOnCompleted(Action continuation) => taskAwaiter.UnsafeOnCompleted(continuation);

        TResult IAwaiter<TResult>.GetResult() => taskAwaiter.GetResult();
    }
}
