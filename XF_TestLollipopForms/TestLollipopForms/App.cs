using Xamarin.Forms;

namespace TestLollipopForms
{
	public class App
	{
		public static INavigation Navigation { get; internal set; }

		public static NavigationPage GetAndroidNavigationPage()
		{
			var page = GetMainPage();
			var rootNav = new NavigationPage(page);

			Navigation = rootNav.Navigation;

			return rootNav;
		}

		public static Page GetMainPage()
		{	
			var page = new ContentPage { 
				Content = new Label {
					Text = "Hello, Forms!",
					VerticalOptions = LayoutOptions.CenterAndExpand,
					HorizontalOptions = LayoutOptions.CenterAndExpand,
				},
			};

			return page;
		}

		public static Page GetAnotherPage()
		{
			var page = new ContentPage { 
				Content = new Label {
					Text = "Forms Modal",
					VerticalOptions = LayoutOptions.CenterAndExpand,
					HorizontalOptions = LayoutOptions.CenterAndExpand,
				},
			};
			return page;
		}
	}
}

