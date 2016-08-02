using System;
using System.Collections.Generic;

namespace Meowtrix.Linq
{
    /// <summary>
    /// Privodes extension methods that can be used for <see cref="IEnumerable{T}"/>  based types.
    /// </summary>
    public static class EnumerableEx
    {
        /// <summary>
        /// Add a group of values to end of a <see cref="ICollection{T}"/>, like <see cref="List{T}.AddRange(IEnumerable{T})"/>
        /// </summary>
        /// <typeparam name="T">The type of items.</typeparam>
        /// <param name="collection">The collection that will be added to.</param>
        /// <param name="items">The items to add.</param>
        /// <exception cref="ArgumentNullException"/>
        public static void AddRange<T>(this ICollection<T> collection, IEnumerable<T> items)
        {
            if (collection == null) throw new ArgumentNullException(nameof(collection));
            if (items == null) throw new ArgumentNullException(nameof(items));
            foreach (var item in items)
                collection.Add(item);
        }
    }
}
