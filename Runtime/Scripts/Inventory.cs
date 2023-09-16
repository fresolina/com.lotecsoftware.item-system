using System;
using System.Collections.Generic;
using UnityEngine;

namespace lotecsoftware.items {
    public interface IInventory<T> {
        int Count { get; }
        List<T> Items { get; }
        Action<T> Added { get; set; }
        bool Add(T item);
        bool Contains(T item);
    }

    /// <summary>
    /// Runtime object. TODO: Save contents when saving game progress.
    /// </summary>
    [Serializable]
    public class Inventory<T> : IInventory<T> {
        [SerializeField] List<T> _items = new();

        public int Count => _items.Count;
        public List<T> Items => _items;
        public Action<T> Added { get; set; }

        /// <summary>
        /// Adds an item, if it does not already exist.
        /// </summary>
        /// <param name="item"></param>
        /// <returns>if item was added</returns>
        public bool Add(T item) {
            if (_items.Contains(item)) {
                return false;
            }
            _items.Add(item);
            Added?.Invoke(item);
            return true;
        }

        public bool Contains(T item) {
            return _items.Contains(item);
        }
    }
}
