using System;
using System.Collections.Generic;
using System.Linq;

namespace Meowtrix.Linq
{
    /// <summary>
    /// Privodes extension methods that can be used for <see cref="IEnumerable{T}"/>  based types.
    /// </summary>
    public static class EnumerableEx
    {
        /// <summary>
        /// Add a group of values to end of an <see cref="ICollection{T}"/>, like <see cref="List{T}.AddRange(IEnumerable{T})"/>.
        /// </summary>
        /// <typeparam name="T">Type of the items.</typeparam>
        /// <param name="collection">The collection that will be added to.</param>
        /// <param name="items">The items to add.</param>
        /// <exception cref="ArgumentNullException"><paramref name="collection"/> is null.</exception>
        public static void AddRange<T>(this ICollection<T> collection, IEnumerable<T> items)
        {
            if (collection == null) throw new ArgumentNullException(nameof(collection));
            if (items == null) throw new ArgumentNullException(nameof(items));
            foreach (var item in items)
                collection.Add(item);
        }

        /// <summary>
        /// Insert a group of values into an <see cref="IList{T}"/>, like <see cref="List{T}.InsertRange(int, IEnumerable{T})"/>.
        /// </summary>
        /// <typeparam name="T">Type of the items.</typeparam>
        /// <param name="list">The list that will be inserted into.</param>
        /// <param name="index">The position to insert.</param>
        /// <param name="items">The items to insert.</param>
        /// <exception cref="ArgumentNullException"><paramref name="list"/> is null;</exception>
        public static void InsertRange<T>(this IList<T> list, int index, IEnumerable<T> items)
        {
            if (list == null) throw new ArgumentNullException(nameof(list));
            if (items == null) throw new ArgumentNullException(nameof(items));
            foreach (var item in items)
                list.Insert(index++, item);
        }

        /// <summary>
        /// Take the item if an <see cref="IEnumerable{T}"/> has only 1 item.
        /// </summary>
        /// <typeparam name="T">Type of the item.</typeparam>
        /// <param name="source">The sequence to check.</param>
        /// <returns>The item if the source has only 1 item, otherwise default value of <typeparamref name="T"/>. </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is null.</exception>
        public static T TakeIfSingle<T>(this IEnumerable<T> source)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            var list = source as IList<T>;
            if (list != null)
            {
                if (list.Count != 1) return default(T);
                else return list[0];
            }

            var readonlylist = source as IReadOnlyList<T>;
            if (readonlylist != null)
            {
                if (readonlylist.Count != 1) return default(T);
                else return readonlylist[0];
            }

            var collection = source as ICollection<T>;
            if (collection != null)
            {
                if (collection.Count != 1) return default(T);
                else return collection.First();
            }

            var readonlycollection = source as IReadOnlyCollection<T>;
            if (readonlycollection != null)
            {
                if (readonlycollection.Count != 1) return default(T);
                else return readonlycollection.First();
            }

            using (var e = source.GetEnumerator())
            {
                if (!e.MoveNext()) return default(T);
                T result = e.Current;
                if (e.MoveNext()) return default(T);
                return result;
            }
        }

        /// <summary>
        /// Take the item that has max value of key in a sequence, or default value if the sequence has no item.
        /// </summary>
        /// <typeparam name="T">Type of the items in the sequence.</typeparam>
        /// <typeparam name="TResult">Type of the key.</typeparam>
        /// <param name="source">The source sequence.</param>
        /// <param name="selector">The function to select key from items.</param>
        /// <returns>The item that has max value of key. Default value of <typeparamref name="T"/> if the sequence has no item.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is null.</exception>
        public static T TakeMaxOrDefault<T, TResult>(this IEnumerable<T> source, Func<T, TResult> selector)
            where TResult : IComparable<TResult>
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            using (var e = source.GetEnumerator())
            {
                if (!e.MoveNext()) return default(T);
                T max = e.Current;
                TResult key = selector(max);
                while (e.MoveNext())
                {
                    TResult key2 = selector(e.Current);
                    if (key2.CompareTo(key) > 0)
                    {
                        key = key2;
                        max = e.Current;
                    }
                }
                return max;
            }
        }
    }
}
