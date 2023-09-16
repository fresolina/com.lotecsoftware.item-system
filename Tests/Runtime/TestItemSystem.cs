using System.Collections;
using NUnit.Framework;
using UnityEngine.TestTools;

namespace lotecsoftware.items.tests {
    public class TestItemSystem {
        protected IItem _simpleItem;
        protected IItem _simpleItem2;
        protected IItem _simpleItem3;
        protected IItem _bonusItem;
        protected IItem _bonusItem2;
        protected ItemController _itemController;
        protected IItem[] _items;

        [UnitySetUp]
        public virtual IEnumerator SetupAssets() {
            _itemController = new ItemController();

            _items = new Item[] {
                new Item("Bonus Item", "This item was added from a trigger"),
                new Item("Bonus Item 2"),
                new Item(description: "This item does not have a name"),
                new Item("Simple Item 2", "Adds a bonus item when picked up"),
                new Item("Simple Item 3", "Adds two extra items when picked up"),
            };

            _simpleItem = _items[0];
            _simpleItem2 = _items[1];
            _bonusItem = _items[2];
            _bonusItem2 = _items[3];
            _simpleItem3 = _items[4];

            _simpleItem2.Added.AddListener(() => {
                _itemController.AddItem(_bonusItem);
            });
            _simpleItem3.Added.AddListener(() => {
                _itemController.AddItem(_bonusItem);
                _itemController.AddItem(_bonusItem2);
            });

            Assert.AreEqual(0, _itemController.InventoryCount, "Starting with 0 items");
            yield return null;
        }

        [Test]
        public void AddItem_AddsToInventory() {
            Assert.IsFalse(_itemController.HasItem(_simpleItem), "Item not in inventory");
            _itemController.AddItem(_simpleItem);
            Assert.IsTrue(_itemController.HasItem(_simpleItem), "Item added to inventory");
        }

        [Test]
        public void AddItem_TwiceDoNotAddToInventory() {
            int count = _itemController.InventoryCount;
            _itemController.AddItem(_simpleItem);
            _itemController.AddItem(_simpleItem);
            Assert.AreEqual(count + 1, _itemController.InventoryCount, "Adding item twice does not add item to inventory twice");
        }

        [Test]
        public void AddItem_TriggersOneAction() {
            _itemController.AddItem(_simpleItem2);
            Assert.IsTrue(_itemController.HasItem(_simpleItem2), "Item added to inventory");
            Assert.IsTrue(_itemController.HasItem(_bonusItem), "Bonus item added to inventory");
        }

        [Test]
        public void AddItem_TriggersTwoActions() {
            _itemController.AddItem(_simpleItem3);
            Assert.IsTrue(_itemController.HasItem(_simpleItem3), "Item added to inventory");
            Assert.IsTrue(_itemController.HasItem(_bonusItem), "Bonus item added to inventory");
            Assert.IsTrue(_itemController.HasItem(_bonusItem2), "Bonus item 2 added to inventory");
        }
    }
}
