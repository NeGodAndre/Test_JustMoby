using TestJustMoby.UI;
using UnityEngine;

namespace TestJustMoby {
	public class ShopController {
		private readonly ShopWindow _shopWindow;
		private readonly ShopConfig _shopConfig;
		
		public ShopController(ShopConfig shopConfig, ShopWindow shopWindow) {
			_shopWindow = shopWindow;
			_shopConfig = shopConfig;
		}

		public void ShowWindow(string idItem) {
			if ( !_shopConfig.TryGetShopItem(idItem, out var shopItems) ) {
				Debug.LogFormat("ShopController: Item {0} don't purchase!!!", idItem);
				return;
			}
			// проверяем доступность этих оферов(ограничение на количество покупок, лимитирование деиствие и тд)
			_shopWindow.Open(shopItems);
		}

		public void ShowWindow(int count) {
			if ( (count < _shopConfig.LimitationItems.x) && (count > _shopConfig.LimitationItems.y) ) {
				Debug.LogErrorFormat("ShopController: {0} isn't include [{1};{2}]!!!", count, _shopConfig.LimitationItems.x, _shopConfig.LimitationItems.y);
				return;
			}
			var shopItem = _shopConfig.ShopItems[0].Clone();
			if ( shopItem.Items.Count > count ) {
				shopItem.Items.RemoveRange(count, shopItem.Items.Count - count);
			} else {
				//можно было бы ничего не делать
				while ( shopItem.Items.Count < count ) {
					shopItem.Items.Add(shopItem.Items[0]);
				}
			}
			_shopWindow.Open(shopItem);
		}

		public void BuyItem(string id) {
			Debug.LogFormat("Buy {0}!!! This create magic", id);
			// если покупка за фиат отправляем запрос пратформе
			// если нет, то покупка за харду проверяем хватает ли
			// если все норм - зачеслияем ресурсы
		}
	}
}