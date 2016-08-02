using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Meowtrix.ITask
{
    /// <summary>
    /// A wrapper for the <see cref="IAwaiter"/> interface.
    /// </summary>
    /// <remarks>This struct is necessary because awaiters must be concrete classes.</remarks>
    public struct AwaiterInterfaceWrapper : ICriticalNotifyCompletion
    {
        private readonly IAwaiter awaiter;
        /// <summary>
        /// Initializes a new instance of the <see cref="AwaiterInterfaceWrapper"/> struct.
        /// </summary>
        /// <param name="awaiter">
        /// The awaiter to wrap.
        /// </param>
        public AwaiterInterfaceWrapper(IAwaiter awaiter)
        {
            if (awaiter == null) throw new ArgumentNullException(nameof(awaiter));
            this.awaiter = awaiter;
        }

        /// <summary>Gets a value indicating whether the task being awaited is completed.</summary>
        /// <remarks>This property is intended for compiler user rather than use directly in code.</remarks>
        /// <exception cref="NullReferenceException">The awaiter was not properly initialized.</exception>
        public bool IsCompleted => awaiter.IsCompleted;

        /// <summary>Schedules the continuation onto the <see cref="Task"/> associated with this <see cref="TaskAwaiter"/>.</summary>
        /// <param name="continuation">The action to invoke when the await operation completes.</param>
        /// <exception cref="ArgumentNullException">The <paramref name="continuation"/> argument is null (Nothing in Visual Basic).</exception>
        /// <exception cref="InvalidOperationException">The awaiter was not properly initialized.</exception>
        /// <remarks>This method is intended for compiler user rather than use directly in code.</remarks>
        public void OnCompleted(Action continuation) => awaiter.OnCompleted(continuation);

        /// <summary>Schedules the continuation onto the <see cref="Task"/> associated with this <see cref="TaskAwaiter"/>.</summary>
        /// <param name="continuation">The action to invoke when the await operation completes.</param>
        /// <exception cref="ArgumentNullException">The <paramref name="continuation"/> argument is null (Nothing in Visual Basic).</exception>
        /// <exception cref="InvalidOperationException">The awaiter was not properly initialized.</exception>
        /// <remarks>This method is intended for compiler user rather than use directly in code.</remarks>
        public void UnsafeOnCompleted(Action continuation) => awaiter.UnsafeOnCompleted(continuation);

        /// <summary>Ends the await on the completed <see cref="IAwaiter"/>.</summary>
        /// <exception cref="NullReferenceException">The awaiter was not properly initialized.</exception>
        /// <exception cref="TaskCanceledException">The task was canceled.</exception>
        /// <exception cref="Exception">The task completed in a Faulted state.</exception>
        public void GetResult() => awaiter.GetResult();
    }

    /// <summary>
    /// A wrapper for the <see cref="IAwaiter{TResult}"/> interface.
    /// </summary>
    /// <typeparam name="TResult">
    /// The type of the result of the task.
    /// </typeparam>
    /// <remarks>This struct is necessary because awaiters must be concrete classes.</remarks>
    public struct AwaiterInterfaceWrapper<TResult> : ICriticalNotifyCompletion
    {
        private readonly IAwaiter<TResult> awaiter;

        /// <summary>
        /// Initializes a new instance of the <see cref="AwaiterInterfaceWrapper{TResult}"/> struct.
        /// </summary>
        /// <param name="awaiter">
        /// The awaiter to wrap.
        /// </param>
        public AwaiterInterfaceWrapper(IAwaiter<TResult> awaiter)
        {
            if (awaiter == null) throw new ArgumentNullException(nameof(awaiter));
            this.awaiter = awaiter;
        }

        /// <summary>Gets a value indicating whether the task being awaited is completed.</summary>
        /// <remarks>This property is intended for compiler user rather than use directly in code.</remarks>
        /// <exception cref="NullReferenceException">The awaiter was not properly initialized.</exception>
        public bool IsCompleted => awaiter.IsCompleted;

        /// <summary>Schedules the continuation onto the <see cref="Task{TResult}"/> associated with this <see cref="TaskAwaiter{TResult}"/>.</summary>
        /// <param name="continuation">The action to invoke when the await operation completes.</param>
        /// <exception cref="ArgumentNullException">The <paramref name="continuation"/> argument is null (Nothing in Visual Basic).</exception>
        /// <exception cref="InvalidOperationException">The awaiter was not properly initialized.</exception>
        /// <remarks>This method is intended for compiler user rather than use directly in code.</remarks>
        public void OnCompleted(Action continuation) => awaiter.OnCompleted(continuation);

        /// <summary>Schedules the continuation onto the <see cref="Task{TResult}"/> associated with this <see cref="TaskAwaiter{TResult}"/>.</summary>
        /// <param name="continuation">The action to invoke when the await operation completes.</param>
        /// <exception cref="ArgumentNullException">The <paramref name="continuation"/> argument is null (Nothing in Visual Basic).</exception>
        /// <exception cref="InvalidOperationException">The awaiter was not properly initialized.</exception>
        /// <remarks>This method is intended for compiler user rather than use directly in code.</remarks>
        public void UnsafeOnCompleted(Action continuation) => awaiter.UnsafeOnCompleted(continuation);

        /// <summary>Ends the await on the completed <see cref="IAwaiter{TResult}"/>.</summary>
        /// <returns>The result of the completed <see cref="IAwaiter{TResult}"/>.</returns>
        /// <exception cref="NullReferenceException">The awaiter was not properly initialized.</exception>
        /// <exception cref="TaskCanceledException">The task was canceled.</exception>
        /// <exception cref="Exception">The task completed in a Faulted state.</exception>
        public TResult GetResult() => awaiter.GetResult();
    }
}
