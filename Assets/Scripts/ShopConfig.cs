using System.Collections.Generic;
using UnityEngine;

namespace TestJustMoby {
	[CreateAssetMenu(fileName = "ShopConfig", menuName = "ShopConfig")]
	//в реальном бы проект я бы ShopItem и Item сделал бы json(или xml на крайнии случай), если бы не было запроса от тех кто с ними будет работать
	public class ShopConfig : ScriptableObject {
		public List<ShopItem> ShopItems;
		public List<Item>     Items;

		public Vector2 LimitationItems;

		public void OnValidate() {
			foreach ( var shopItem in ShopItems ) {
				if ( (shopItem.Items.Count < LimitationItems.x) && (shopItem.Items.Count > LimitationItems.y) ) {
					Debug.LogErrorFormat("ShopConfig: ShopItem {0} have incorrect count items!!!", shopItem.Id);
				}
			}
		}

		public bool TryGetShopItem(string idItem, out List<ShopItem> shopItem) {
			shopItem = ShopItems.FindAll(value => 
				value.Items.Exists(item => item == idItem)
				);
			return shopItem.Count > 0;
		}

		public bool TryGetItem(string id, out Item item) {
			var exists = Items.Exists(value => value.Id == id);
			if ( !exists ) {
				Debug.LogError("ShopConfig: Item doesn't find for " + id);
			}
			item = Items.Find(value => value.Id == id);
			return exists;
		}
	}
}