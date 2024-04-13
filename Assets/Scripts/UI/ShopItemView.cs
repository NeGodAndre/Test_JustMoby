using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace TestJustMoby.UI {
	public class ShopItemView : MonoBehaviour {
		[SerializeField] private Text           _headerText;
		[SerializeField] private Text           _descriptionText;
		[SerializeField] private Image          _icon;
		[Space]
		[SerializeField] private List<ItemView> _itemViews;
		[Space]
		[SerializeField] private Text           _costText;
		[SerializeField] private Text           _newCostText;
		[SerializeField] private GameObject     _lineCostObj;
		[SerializeField] private Button         _buyButton;
		[Space]
		[SerializeField] private Text           _discountText;
		[SerializeField] private GameObject     _discountObj;

		private IconsConfig    _iconsConfig;
		private ShopConfig     _shopConfig;
		private ShopController _shopController;
		
		[Inject]
		public void Init(IconsConfig iconsConfig, ShopConfig shopConfig) {
			_iconsConfig = iconsConfig;
			_shopConfig = shopConfig;
		}

		public void SetActive(bool isActive) {
			gameObject.SetActive(isActive);
		}

		public void Open(ShopItem shopItem) {
			SetActive(true);
			_headerText.text = shopItem.Name;
			_descriptionText.text = shopItem.Description;
			_icon.sprite = _iconsConfig.GetIcon(shopItem.IdIcon);
			SettingItems(shopItem.Items);
			_costText.text = shopItem.Cost.ToString();
			_newCostText.gameObject.SetActive(shopItem.Discount > 0);
			_lineCostObj.SetActive(shopItem.Discount > 0);
			_discountObj.SetActive(shopItem.Discount > 0);
			if ( shopItem.Discount > 0 ) {
				_newCostText.text = shopItem.NewCost.ToString();
				_discountText.text = "-" + shopItem.Discount + "%";
			}

			_buyButton.onClick.RemoveAllListeners();
			_buyButton.onClick.AddListener(() => _shopController.BuyItem(shopItem.Id));
		}

		private void SettingItems(List<string> idItems) {
			var index = 0;
			foreach ( var idItem in idItems ) {
				if ( !_shopConfig.TryGetItem(idItem, out var item) ) {
					continue;
				}
				if ( index >= _itemViews.Count ) {
					Debug.LogError("ShopItemView: More item then view!");
					break;
				}
				_itemViews[index].SetActive(true);
				_itemViews[index].Set(_iconsConfig.GetIcon(item.Id), item.Count.ToString());
				index++;
			}
			for ( ; index < _itemViews.Count; index++ ) {
				_itemViews[index].SetActive(false);
			}
		}
	}
}