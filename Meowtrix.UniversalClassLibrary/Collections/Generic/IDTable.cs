using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

namespace Meowtrix.Collections.Generic
{
    /// <summary>
    /// A collection for <see cref="IIdentifiable{T}"/> that can be accessed by <see cref="IIdentifiable{T}.Id"/>.
    /// </summary>
    /// <typeparam name="TId">Type of id getting from <see cref="IIdentifiable{T}"/>.</typeparam>
    /// <typeparam name="TValue">Type of items.</typeparam>
    public class IDTable<TId, TValue> : ICollection<TValue>, IReadOnlyCollection<TValue>, INotifyCollectionChanged
        where TValue : IIdentifiable<TId>
    {
        private readonly SortedList<TId, TValue> _innerList = new SortedList<TId, TValue>();

        /// <summary>
        /// Create an empty <see cref="IDTable{TId, TValue}"/>.
        /// </summary>
        public IDTable() { }

        /// <summary>
        /// Create an empty <see cref="IDTable{TId, TValue}"/> with specified initial capacity.
        /// </summary>
        /// <param name="capacity">Initial capacity of the <see cref="IDTable{TId, TValue}"/>.</param>
        public IDTable(int capacity) { _innerList = new SortedList<TId, TValue>(capacity); }

        /// <summary>
        /// Create an <see cref="IDTable{TId, TValue}"/> from a collection.
        /// </summary>
        /// <param name="collection">The original collection.</param>
        public IDTable(IEnumerable<TValue> collection) { _innerList = new SortedList<TId, TValue>(collection.ToDictionary(x => x.Id)); }

        /// <summary>
        /// Adds an item to the <see cref="IDTable{TId, TValue}"/>.
        /// </summary>
        /// <param name="item">The item to add.</param>
        public void Add(TValue item)
        {
            _innerList.Add(item.Id, item);
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, item));
        }

        /// <summary>
        /// Adds multiple items to the <see cref="IDTable{TId, TValue}"/>.
        /// </summary>
        /// <param name="items">The items to add.</param>
        public void AddMany(IEnumerable<TValue> items)
        {
            IList<TValue> itemlist = items as IList<TValue> ?? items.ToList();
            IList ilist = items as IList ?? itemlist as IList ?? items.ToList();
            foreach (var item in itemlist)
                _innerList.Add(item.Id, item);
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, ilist));
        }

        /// <summary>
        /// Removes an item from the <see cref="IDTable{TId, TValue}"/>.
        /// </summary>
        /// <param name="item">The item to remove.</param>
        /// <returns>If <paramref name="item"/> is found.</returns>
        public bool Remove(TValue item)
        {
            int rawindex = _innerList.IndexOfValue(item);
            bool found = _innerList.Remove(item.Id);
            if (found) OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, item, rawindex));
            return found;
        }

        /// <summary>
        /// Removes an item by id.
        /// </summary>
        /// <param name="id">Id of the item to remove.</param>
        /// <returns>If an item with <paramref name="id"/> is found.</returns>
        public bool Remove(TId id) => Remove(_innerList[id]);

        /// <summary>
        /// Remove multiple items from the <see cref="IDTable{TId, TValue}"/>.
        /// </summary>
        /// <param name="items">Items to remove.</param>
        public void RemoveMany(IEnumerable<TValue> items)
        {
            foreach (var item in items)
                Remove(item);
        }

        /// <summary>
        /// Remove multiple items from the <see cref="IDTable{TId, TValue}"/> by id.
        /// </summary>
        /// <param name="ids">Ids of items to remove.</param>
        public void RemoveMany(IEnumerable<TId> ids)
        {
            foreach (var item in ids)
                Remove(item);
        }

        /// <summary>
        /// Enumerates items in the <see cref="IDTable{TId, TValue}"/>.
        /// </summary>
        /// <returns>The enumerator.</returns>
        public IEnumerator<TValue> GetEnumerator() => _innerList.Values.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        IEnumerator<TValue> IEnumerable<TValue>.GetEnumerator() => GetEnumerator();

        /// <summary>
        /// Removes all items from the <see cref="IDTable{TId, TValue}"/>.
        /// </summary>
        public void Clear()
        {
            _innerList.Clear();
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }
        /// <summary>
        /// Determines whether the <see cref="IDTable{TId, TValue}"/> contains a specific value.
        /// </summary>
        /// <param name="item">The item to locate.</param>
        /// <returns>If <paramref name="item"/> is found.</returns>
        public bool Contains(TValue item) => _innerList.ContainsKey(item.Id);

        /// <summary>
        /// Copies the elements of the <see cref="IDTable{TId, TValue}"/> to an <see cref="Array"/>, starting at a particular <see cref="Array"/> index.
        /// </summary>
        /// <param name="array">The <see cref="Array"/> to copy to. Must be one-dimension, zero-based.</param>
        /// <param name="index">The zero-based index in <paramref name="array"/> at which copying begins.</param>
        public void CopyTo(TValue[] array, int index) => _innerList.Values.CopyTo(array, index);

        /// <summary>
        /// Gets the number of elements contained in the <see cref="IDTable{TId, TValue}"/>.
        /// </summary>
        public int Count => _innerList.Count;
        bool ICollection<TValue>.IsReadOnly => false;

        /// <summary>
        /// Gets or sets the capacity of the <see cref="IDTable{TId, TValue}"/>.
        /// </summary>
        public int Capacity
        {
            get { return _innerList.Capacity; }
            set { _innerList.Capacity = value; }
        }

        /// <summary>
        /// Occurs when the collection changes.
        /// </summary>
        public event NotifyCollectionChangedEventHandler CollectionChanged;

        /// <summary>
        /// Raise the <see cref="CollectionChanged"/> event.
        /// </summary>
        /// <param name="args">The EventArgs to use.</param>
        protected void OnCollectionChanged(NotifyCollectionChangedEventArgs args)
        {
            var temp = CollectionChanged;
            temp?.Invoke(this, args);
        }

        /// <summary>
        /// Gets or sets the item with id.
        /// </summary>
        /// <param name="index">The id of item to get or set.</param>
        /// <returns>Item with <paramref name="index"/>.</returns>
        public TValue this[TId index]
        {
            get
            {
                TValue item;
                _innerList.TryGetValue(index, out item);
                return item;
            }
            set
            {
                if (!EqualityComparer<TId>.Default.Equals(index, value.Id)) throw new ArgumentException("Index mismatched with value.");
                var olditem = _innerList[index];
                if (_innerList.ContainsKey(index))
                {
                    _innerList[index] = value;
                    int rawindex = _innerList.Values.IndexOf(value);
                    OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace, value, olditem, rawindex));
                }
                else Add(value);
            }
        }
    }
}
