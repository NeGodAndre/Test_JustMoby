using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace TestJustMoby.TZ {
	public class MainTZ : MonoBehaviour {
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
			_inputField.onValueChanged.RemoveAllListeners();
			_inputField.onValueChanged.AddListener(InputChangedHandler);
			_button.onClick.RemoveAllListeners();
			_button.onClick.AddListener(ButtonHandler);
		}

		private void InputChangedHandler(string newValue) {
			if ( int.TryParse(newValue, out var value) ) {
				if ( (value < _shopConfig.LimitationItems.x) || (value > _shopConfig.LimitationItems.y) ) {
					_inputField.text = string.Empty;
				}
			} else {
				_inputField.text = string.Empty;
			}
		}

		private void ButtonHandler() {
			if ( !int.TryParse(_inputField.text, out var value) ) {
				return;
			}
			_shopController.ShowWindow(value);
		}
	}
}
