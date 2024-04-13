using System;
using System.Collections.Generic;

namespace TestJustMoby {
	[Serializable]
	public struct ShopItem {
		public string       Id;
		public string       Name;
		public string       Description;
		public List<string> Items;
		public float        Cost;
		public float        NewCost; //для красивых циферок, при расчете они могут не получится
		public float        Discount;
		public string       IdIcon;

		public ShopItem Clone() {
			return new ShopItem {
				Id = Id,
				Name = Name,
				Description = Description,
				Cost = Cost,
				Discount = Discount,
				NewCost = NewCost,
				IdIcon = IdIcon,
				Items = new List<string>(Items)
			};
		}
	}
}