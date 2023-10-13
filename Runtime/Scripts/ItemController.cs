namespace lotecsoftware.items {
    /// <summary>
    /// Has an Inventory of items.
    /// Handles adding an item to the inventory.
    /// </summary>
    [System.Serializable]
    public class ItemController : IItemApi {
        public Inventory<IItem> Inventory { get; }

        public ItemController() {
            Inventory = new();
            Inventory.Added += (item) => item.Added?.Invoke();
        }

        public int InventoryCount => Inventory.Count;

        // IItemApi
        public void AddItem(IItem item) {
            Inventory.Add(item);
        }
        public bool HasItem(IItem item) => Inventory.Contains(item);
    }
}
