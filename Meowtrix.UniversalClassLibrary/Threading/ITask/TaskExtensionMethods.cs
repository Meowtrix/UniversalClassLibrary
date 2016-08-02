using System;
using System.Threading.Tasks;

namespace Meowtrix.ITask
{
    /// <summary>
    /// Class providing task extension methods.
    /// </summary>
    public static class TaskExtensionMethods
    {
        /// <summary>
        /// Converts the <see cref="Task"/> instance into an <see cref="ITask"/>.
        /// </summary>
        /// <param name="task">
        /// The task to convert.
        /// </param>
        /// <returns>
        /// The <see cref="ITask"/>.
        /// </returns>
        public static ITask AsITask(this Task task)
        {
            if (task == null) throw new ArgumentNullException(nameof(task));
            return new TaskWrapper(task);
        }

        /// <summary>
        /// Converts the <see cref="Task{TResult}"/> instance into an <see cref="ITask{TResult}"/>.
        /// </summary>
        /// <param name="task">
        /// The task to convert.
        /// </param>
        /// <typeparam name="TResult">
        /// The type of the result of the task.
        /// </typeparam>
        /// <returns>
        /// The <see cref="ITask{TResult}"/>.
        /// </returns>
        public static ITask<TResult> AsITask<TResult>(this Task<TResult> task)
        {
            if (task == null) throw new ArgumentNullException(nameof(task));
            return new TaskWrapper<TResult>(task);
        }

        /// <summary>
        /// Converts the <see cref="ITask"/> instance into a <see cref="Task"/>.
        /// </summary>
        /// <param name="task">
        /// The task to convert.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public static async Task AsTask(this ITask task)
        {
            if (task == null) throw new ArgumentNullException(nameof(task));
            await task.ConfigureAwait(false);
        }

        /// <summary>
        /// Converts the <see cref="ITask{TResult}"/> instance into a <see cref="Task{TResult}"/>.
        /// </summary>
        /// <param name="task">
        /// The task to convert.
        /// </param>
        /// <typeparam name="TResult">
        /// The type of the result of the task.
        /// </typeparam>
        /// <returns>
        /// The <see cref="Task{TResult}"/>.
        /// </returns>
        public static async Task<TResult> AsTask<TResult>(this ITask<TResult> task)
        {
            if (task == null) throw new ArgumentNullException(nameof(task));
            return await task.ConfigureAwait(false);
        }

        /// <summary>
        /// Gets a concrete awaiter.
        /// </summary>
        /// <param name="awaitable">
        /// The awaitable.
        /// </param>
        /// <returns>
        /// The <see cref="AwaiterInterfaceWrapper"/>.
        /// </returns>
        /// <remarks>This method is intended for compiler user rather than use directly in code.</remarks>
        public static AwaiterInterfaceWrapper GetAwaiter(this ITask awaitable)
        {
            if (awaitable == null) throw new ArgumentNullException(nameof(awaitable));
            return new AwaiterInterfaceWrapper(awaitable.GetAwaiter());
        }

        /// <summary>
        /// Gets a concrete awaiter.
        /// </summary>
        /// <param name="awaitable">
        /// The awaitable.
        /// </param>
        /// <returns>
        /// The <see cref="AwaiterInterfaceWrapper"/>.
        /// </returns>
        public static AwaiterInterfaceWrapper GetAwaiter(this IConfiguredTask awaitable)
        {
            if (awaitable == null) throw new ArgumentNullException(nameof(awaitable));
            return new AwaiterInterfaceWrapper(awaitable.GetAwaiter());
        }

        /// <summary>
        /// Gets a concrete awaiter.
        /// </summary>
        /// <param name="awaitable">
        /// The awaitable.
        /// </param>
        /// <typeparam name="TResult">
        /// The type of the result of the task.
        /// </typeparam>
        /// <returns>
        /// The <see cref="AwaiterInterfaceWrapper{TResult}"/>.
        /// </returns>
        public static AwaiterInterfaceWrapper<TResult> GetAwaiter<TResult>(this ITask<TResult> awaitable)
        {
            if (awaitable == null) throw new ArgumentNullException(nameof(awaitable));
            return new AwaiterInterfaceWrapper<TResult>(awaitable.GetAwaiter());
        }

        /// <summary>
        /// Gets a concrete awaiter.
        /// </summary>
        /// <param name="awaitable">
        /// The awaitable.
        /// </param>
        /// <typeparam name="TResult">
        /// The type of the result of the task.
        /// </typeparam>
        /// <returns>
        /// The <see cref="AwaiterInterfaceWrapper{TResult}"/>.
        /// </returns>
        public static AwaiterInterfaceWrapper<TResult> GetAwaiter<TResult>(this IConfiguredTask<TResult> awaitable)
        {
            if (awaitable == null) throw new ArgumentNullException(nameof(awaitable));
            return new AwaiterInterfaceWrapper<TResult>(awaitable.GetAwaiter());
        }
    }
}
