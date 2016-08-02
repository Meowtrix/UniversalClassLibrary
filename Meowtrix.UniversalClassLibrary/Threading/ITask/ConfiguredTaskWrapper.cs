using System.Runtime.CompilerServices;

namespace Meowtrix.ITask
{
    internal class ConfiguredTaskWrapper : IConfiguredTask
    {
        private readonly ConfiguredTaskAwaitable task;

        public ConfiguredTaskWrapper(ConfiguredTaskAwaitable configuredTask)
        {
            task = configuredTask;
        }

        IAwaiter IConfiguredTask.GetAwaiter() => new ConfiguredTaskAwaiterWrapper(task.GetAwaiter());
    }

    internal class ConfiguredTaskWrapper<TResult> : IConfiguredTask<TResult>
    {
        private readonly ConfiguredTaskAwaitable<TResult> task;

        public ConfiguredTaskWrapper(ConfiguredTaskAwaitable<TResult> configuredTask)
        {
            task = configuredTask;
        }

        IAwaiter<TResult> IConfiguredTask<TResult>.GetAwaiter() => new ConfiguredTaskAwaiterWrapper<TResult>(task.GetAwaiter());
    }
}
