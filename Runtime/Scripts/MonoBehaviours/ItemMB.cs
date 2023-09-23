using System.Collections.Generic;
using lotecsoftware.items;
using UnityEngine;
using UnityEngine.Events;

namespace lotecsoftware.items {
    /// <summary>
    /// MonoBehaviour wrapper for Item.
    /// </summary>
    public class ItemMB : MonoBehaviour, IItem {
        [SerializeField] Item _item;

        public string Name => ((IItem)_item).Name;
        public string Description => ((IItem)_item).Description;
        public UnityEvent Added => ((IItem)_item).Added;
    }
}
