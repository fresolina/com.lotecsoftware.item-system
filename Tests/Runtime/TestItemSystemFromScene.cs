using System.Collections;
using NUnit.Framework;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

namespace lotecsoftware.items.tests {
    /// <summary>
    /// Test ItemApi SO asset, and item SO assets.
    /// </summary>
    public class TestItemSystemFromScene : TestItemSystem {
        [UnitySetUp]
        public override IEnumerator SetupAssets() {
            string guid = AssetDatabase.FindAssets($"TestItemSystem t:scene")[0];
            string path = AssetDatabase.GUIDToAssetPath(guid);
            yield return EditorSceneManager.LoadSceneAsyncInPlayMode(path, new LoadSceneParameters(LoadSceneMode.Single));
            _items = GameObject.FindAnyObjectByType<TestSettings>().ItemAssets;

            _simpleItem = _items[0];
            _simpleItem2 = _items[1];
            _bonusItem = _items[2];
            _bonusItem2 = _items[3];
            _simpleItem3 = _items[4];

            _itemController = new ItemController();
            Assert.AreEqual(0, _itemController.InventoryCount, "Starting with 0 items");
            GameObject.FindAnyObjectByType<TestSettings>().ItemApiAsset.Init(_itemController);
        }
    }
}
