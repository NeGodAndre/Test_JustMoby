using System.Collections.Generic;
using UnityEngine;

namespace TestJustMoby.UI {
	public class ShopWindow : MonoBehaviour {
		[SerializeField] private List<ShopItemView> _shopItemViews;

		public void Open(List<ShopItem> shopItems) {
			gameObject.SetActive(true);
			if ( _shopItemViews.Count < shopItems.Count ) {
				Debug.LogError("ShopWindow: ShopItem is larger than ShopItemView!!!");
			}
			var index = 0;
			for ( ; (index < _shopItemViews.Count) && (index < shopItems.Count); index++ ) {
				_shopItemViews[index].Open(shopItems[index]);
			}
			for ( ; index < _shopItemViews.Count; index++ ) {
				_shopItemViews[index].SetActive(false);
			}
		}

		public void Open(ShopItem shopItem) {
			gameObject.SetActive(true);
			_shopItemViews[0].Open(shopItem);
			for ( var i = 1; i < _shopItemViews.Count; i++ ) {
				_shopItemViews[i].SetActive(false);
			}
		}
	}
}