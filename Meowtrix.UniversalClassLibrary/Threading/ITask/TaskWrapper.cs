using System;
using System.Threading.Tasks;

namespace Meowtrix.ITask
{
    internal class TaskWrapper : ITask
    {
        private readonly Task task;

        public TaskWrapper(Task task)
        {
            if (task == null) throw new ArgumentNullException(nameof(task));
            this.task = task;
        }

        IAwaiter ITask.GetAwaiter() => new TaskAwaiterWrapper(task.GetAwaiter());

        IConfiguredTask ITask.ConfigureAwait(bool continueOnCapturedContext) => new ConfiguredTaskWrapper(task.ConfigureAwait(continueOnCapturedContext));
    }

    internal class TaskWrapper<TResult> : ITask<TResult>
    {
        private readonly Task<TResult> task;

        public TaskWrapper(Task<TResult> task)
        {
            if (task == null) throw new ArgumentNullException(nameof(task));
            this.task = task;
        }

        TResult ITask<TResult>.Result => task.Result;

        IAwaiter ITask.GetAwaiter() => new TaskAwaiterWrapper(((Task)task).GetAwaiter());

        IAwaiter<TResult> ITask<TResult>.GetAwaiter() => new TaskAwaiterWrapper<TResult>(task.GetAwaiter());

        IConfiguredTask ITask.ConfigureAwait(bool continueOnCapturedContext) => new ConfiguredTaskWrapper(((Task)task).ConfigureAwait(continueOnCapturedContext));

        IConfiguredTask<TResult> ITask<TResult>.ConfigureAwait(bool continueOnCapturedContext) => new ConfiguredTaskWrapper<TResult>(task.ConfigureAwait(continueOnCapturedContext));
    }
}
