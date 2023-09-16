using System.Collections;
using NUnit.Framework;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

namespace lotecsoftware.items.tests {
    /// <summary>
    /// Test MonoBehaviour system and items.
    /// </summary>
    public class TestItemSystemMBFromScene : TestItemSystem {
        [UnitySetUp]
        public override IEnumerator SetupAssets() {
            string guid = AssetDatabase.FindAssets($"TestItemSystemMB t:scene")[0];
            string path = AssetDatabase.GUIDToAssetPath(guid);
            yield return EditorSceneManager.LoadSceneAsyncInPlayMode(path, new LoadSceneParameters(LoadSceneMode.Single));

            _simpleItem = GameObject.Find("SimpleItem_1").GetComponent<IItem>();
            _simpleItem2 = GameObject.Find("SimpleItem_2").GetComponent<IItem>();
            _simpleItem3 = GameObject.Find("SimpleItem_3").GetComponent<IItem>();
            _bonusItem = GameObject.Find("BonusItem_1").GetComponent<IItem>();
            _bonusItem2 = GameObject.Find("BonusItem_2").GetComponent<IItem>();

            _itemController = GameObject.Find("ItemController").GetComponent<ItemControllerMB>().ItemController;
            Assert.AreEqual(0, _itemController.InventoryCount, "Starting with 0 items");
        }
    }
}
