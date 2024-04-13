using UnityEngine;
using UnityEngine.UI;

namespace TestJustMoby.UI {
	public class ItemView : MonoBehaviour {
		[SerializeField] private Image _icon;
		[SerializeField] private Text  _cost;

		public void Set(Sprite icon, string cost) {
			_icon.sprite = icon;
			_cost.text = cost;
		}

		public void SetActive(bool isActive) {
			gameObject.SetActive(isActive);
		}
	}
}