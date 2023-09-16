using UnityEngine;
using UnityEngine.Events;

namespace lotecsoftware.items {
    public interface IItem {
        string Name { get; }
        string Description { get; }
        UnityEvent Added { get; set; } // TODO: Kanske ta bort denna...?
    }

    [System.Serializable]
    public class Item : IItem {
        [SerializeField] string _name;
        [SerializeField] string _description;
        [SerializeField] UnityEvent _added = new();

        public string Name => _name;
        public string Description => _description;
        public UnityEvent Added {
            get { return _added; }
            set { _added = value; }
        }

        public Item(string name = null, string description = null) {
            _name = name;
            _description = description;
        }
    }
}
