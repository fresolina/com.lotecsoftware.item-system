using UnityEngine;

namespace lotecsoftware.items {
    public class ItemControllerMB : MonoBehaviour, IItemApi {
        [SerializeField] ItemMB[] _startingItems;
        public ItemController ItemController { get; } = new();

        public void AddItem(IItem item) => ((IItemApi)ItemController).AddItem(item);
        public bool HasItem(IItem item) => ((IItemApi)ItemController).HasItem(item);
        // Make it so method is callable from UnityEvent
        public void AddItem(ItemMB item) => ((IItemApi)ItemController).AddItem(item);

        void Awake() {
            if (_startingItems == null)
                return;

            for (int i = 0; i < _startingItems.Length; i++) {
                AddItem(_startingItems[i]);
            }
        }
    }
}
