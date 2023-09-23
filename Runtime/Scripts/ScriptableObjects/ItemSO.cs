using UnityEngine;
using UnityEngine.Events;

namespace lotecsoftware.items {
    /// <summary>
    /// ScriptableObject wrapper for Item
    /// </summary>
    [CreateAssetMenu(fileName = "SimpleItem", menuName = "Items/SimpleItem")]
    public class ItemSO : ScriptableObject, IItem {
        [SerializeField] Item _item;
        string _toStringCache;

        public string Name => ((IItem)_item).Name;
        public string Description => ((IItem)_item).Description;
        public UnityEvent Added => ((IItem)_item).Added;

        public override string ToString() {
            if (string.IsNullOrEmpty(_toStringCache)) {
                _toStringCache = $"{name} - {Name} ({Description})";
            }
            return _toStringCache;
        }
    }
}
