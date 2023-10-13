using UnityEngine;

namespace lotecsoftware.items {
    // NOTE: More like ItemInventoryApi, but maybe it's simpler to call it ItemApi.
    public interface IItemApi {
        void AddItem(IItem item);
        bool HasItem(IItem item);
    }

    /// <summary>
    /// Workaround for use in UnityEvents in inspector.
    /// Ensures void functions, and Unity Object arguments.
    /// </summary>
    public interface IItemApiUnity {
        void AddItem(ItemSO item);
    }

    /// <summary>
    /// API usable from UnityEvents must have void returns.
    /// Must be initialized with a handler from Init().
    /// </summary>
    [CreateAssetMenu(fileName = "ItemApi", menuName = "Items/ItemApi", order = 0)]
    public class ItemApiSO : ScriptableObject, IItemApiUnity {
        IItemApi _handler;

        public void Init(IItemApi handler) {
            _handler = handler;
        }

        public void AddItem(ItemSO item) => _handler.AddItem(item);
    }
}
