# ITask
An interface wrapper for Task Parallel Library, provides covariance.

## Purpose

The built-in `System.Threading.Tasks.Task` and `System.Threading.Tasks.Task<TResult>` classes allow for compiler support of the `async` and `await` keywords.  However, since these types must be used as the return values of the methods which leverage the support of the keywords, any interface containing one of these methods may not be covariant over the type `TResult`.  This can cause problems, especially when converting methods on existing interfaces from being synchronous to asynchronous.

This is where the `ITask` interface comes in.  Both `ITask` and `ITask<TResult>` interfaces are included for consistency, but the real power lies in the `ITask<TResult>` interface.  It exposes the same functionality as `System.Threading.Tasks.Task<TResult>`, simply through an interface.  Because `TResult` is only used in the output position for this interface, it is covariant (its definition is `public interface ITask<out TResult>`) and may be used as a return value within another generic interface without breaking its covariance.

## Usage

### Using ITask in and classes and interfaces

A method providing a TResult value may be like this:

```C#
TResult GetSomeValue();
```

When making it asynchronous, it will be:

```C#
Task<TResult> GetSomeValueAsync();
```

Now with ITask, you can make it like this:

```C#
ITask<TResult> GetSomeValueIAsync();
```

### Awaiting an ITask

An awaitable class should contains a ```GetAwaiter()``` method or extension method, which returns a type that has the same methods with ```System.Runtime.CompilerServices.TaskAwaiter```. There is an extension method that returns a wrapper for ```IAwater```, so the interface ```ITask``` is awaitable.
You can await it just like a ```Task```:

```C#
var result = await someobj.GetSomeValueIAsync();
```

### Converting between Task and ITask

Since you can create a ```Task``` very easily using the __async__ keyword, the easiest way to create an ```ITask``` is converting from a ```Task```.
There's an extension method that returns a wrapper for ```Task```:

```C#
ITask<TResult> itask = someobj.GetSomeValueAsync().AsITask();
```

Now you get covariance on it:

```C#
ITask<TResultBase> itaskbase = itask;
```

You can also convert it back to ```Task``` when needed by some methods:

```C#
Task<TResultBase> taskbase = itaskbase.AsTask();
```
