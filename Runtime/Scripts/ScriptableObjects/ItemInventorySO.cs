using System;
using System.Collections.Generic;
using UnityEngine;

namespace lotecsoftware.items {
    [CreateAssetMenu(fileName = "ItemInventory", menuName = "Items/ItemInventory", order = 0)]
    public class ItemInventorySO : ScriptableObject, IInventory<ItemSO> {
        readonly Inventory<ItemSO> _inventory = new();
        [SerializeField] ItemSO[] _startingItems;

        public int Count => ((IInventory<ItemSO>)_inventory).Count;
        public List<ItemSO> Items => ((IInventory<ItemSO>)_inventory).Items;
        public Action<ItemSO> Added { get => ((IInventory<ItemSO>)_inventory).Added; set => ((IInventory<ItemSO>)_inventory).Added = value; }
        public bool Add(ItemSO item) => ((IInventory<ItemSO>)_inventory).Add(item);
        public bool Contains(ItemSO item) => ((IInventory<ItemSO>)_inventory).Contains(item);

        void Awake() {
            if (_startingItems == null)
                return;

            for (int i = 0; i < _startingItems.Length; i++) {
                ItemSO item = _startingItems[i];
                _inventory.Add(item);
            }
        }
    }
}
