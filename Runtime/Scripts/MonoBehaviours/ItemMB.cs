using System.Collections.Generic;
using lotecsoftware.items;
using UnityEngine;
using UnityEngine.Events;

namespace lotecsoftware.items {
    public class ItemMB : MonoBehaviour, IItem {
        [SerializeField] Item _item;

        public string Name => ((IItem)_item).Name;
        public string Description => ((IItem)_item).Description;
        public UnityEvent Added { get => ((IItem)_item).Added; set => ((IItem)_item).Added = value; }
    }
}
