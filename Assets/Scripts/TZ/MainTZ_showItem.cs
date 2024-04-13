using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace TestJustMoby.TZ {
	public class MainTZ_showItem : MonoBehaviour {
		[SerializeField] private InputField _inputField;
		[SerializeField] private Button     _button;

		private ShopConfig     _shopConfig;
		private ShopController _shopController;

		[Inject]
		public void Init(ShopConfig shopConfig, ShopController shopController) {
			_shopConfig = shopConfig;
			_shopController = shopController;
		}

		public void Start() {
			_button.onClick.RemoveAllListeners();
			_button.onClick.AddListener(ButtonHandler);
		}

		private void ButtonHandler() {
			_shopController.ShowWindow(_inputField.text);
		}
	}
}