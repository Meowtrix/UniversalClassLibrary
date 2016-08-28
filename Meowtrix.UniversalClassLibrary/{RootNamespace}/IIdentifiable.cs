using System;

namespace Meowtrix
{
    /// <summary>
    /// Provides an id to identify the object.
    /// </summary>
    /// <typeparam name="T">Type of id.</typeparam>
    public interface IIdentifiable<out T>
        where T : IEquatable<T>
    {
        /// <summary>
        /// The id to identify the object.
        /// </summary>
        T Id { get; }
    }
}
