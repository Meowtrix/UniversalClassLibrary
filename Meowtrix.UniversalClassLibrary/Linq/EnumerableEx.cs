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
        /// Add a group of values to end of an <see cref="ICollection{T}"/>, like <see cref="List{T}.AddRange(IEnumerable{T})"/>
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

        /// <summary>
        /// Insert a group of values into an <see cref="IList{T}"/>, like <see cref="List{T}.InsertRange(int, IEnumerable{T})"/>
        /// </summary>
        /// <typeparam name="T">The type of items.</typeparam>
        /// <param name="list">The list that will be inserted into.</param>
        /// <param name="index">The position to insert.</param>
        /// <param name="items">The items to insert.</param>
        public static void InsertRange<T>(this IList<T> list, int index, IEnumerable<T> items)
        {
            if (list == null) throw new ArgumentNullException(nameof(list));
            if (items == null) throw new ArgumentNullException(nameof(items));
            foreach (var item in items)
                list.Insert(index++, item);
        }
    }
}
