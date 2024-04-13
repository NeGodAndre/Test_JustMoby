using System;
using System.Collections.Generic;
using UnityEngine;

namespace TestJustMoby {
	[CreateAssetMenu(fileName = "SpriteConfig", menuName = "SpriteConfig")]
	public class IconsConfig : ScriptableObject {
		public List<IconInfo> Icons;

		public Sprite GetIcon(string id) {
			var info = Icons.Find(value => value.Id == id);
			if ( info != null ) {
				return info.Icon;
			}
			Debug.LogError("IconsConfig: Icon doesn't find for " + id);
			return null;
		}
	}

	[Serializable]
	public class IconInfo {
		public string Id;
		public Sprite Icon;
	}
}