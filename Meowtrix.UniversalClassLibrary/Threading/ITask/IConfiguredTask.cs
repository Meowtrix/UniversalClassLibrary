namespace Meowtrix.ITask
{
    /// <summary>Provides an awaitable object that allows for configured awaits on <see cref="ITask"/>.</summary>
    /// <remarks>This type is intended for compiler use only.</remarks>
    public interface IConfiguredTask
    {
        /// <summary>Creates an awaiter used to await this <see cref="IConfiguredTask"/>.</summary>
        /// <returns>An awaiter instance.</returns>
        /// <remarks>This method is intended for compiler user rather than use directly in code.</remarks>
        IAwaiter GetAwaiter();
    }

    /// <summary>Provides an awaitable object that allows for configured awaits on <see cref="ITask{TResult}"/>.</summary>
    /// <typeparam name="TResult">
    /// The type of the result of the task.
    /// </typeparam>
    /// <remarks>This type is intended for compiler use only.</remarks>
    public interface IConfiguredTask<out TResult>
    {
        /// <summary>Creates an awaiter used to await this <see cref="IConfiguredTask{TResult}"/>.</summary>
        /// <returns>An awaiter instance.</returns>
        /// <remarks>This method is intended for compiler user rather than use directly in code.</remarks>
        IAwaiter<TResult> GetAwaiter();
    }
}
