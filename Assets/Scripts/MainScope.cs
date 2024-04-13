using TestJustMoby.UI;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace TestJustMoby
{
	public class MainScope : LifetimeScope {
		[SerializeField] private IconsConfig _iconsConfig;
		[SerializeField] private ShopConfig  _shopConfig;
		[Space]
		[SerializeField] private ShopWindow  _showWindow; 
		
		protected override void Configure(IContainerBuilder builder) {
			builder.RegisterInstance(_iconsConfig);
			builder.RegisterInstance(_shopConfig);
			builder.RegisterComponent(_showWindow);
			builder.Register<ShopController>(Lifetime.Singleton);
		}
	}
}
