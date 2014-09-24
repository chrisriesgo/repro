using Xamarin.Forms;

namespace EntryTextShift
{
	public class App
	{
		public static INavigation Navigation { get; internal set; }

		public static Page GetMainPage()
		{
			var page = new ContentPage();
			var rootNav = new NavigationPage(page);

			// Attention! -- commenting out this line "fixes" the issue
			NavigationPage.SetHasNavigationBar(page, false);

			Navigation = rootNav.Navigation;
			return rootNav;
		}

		public static Page GetModalPage()
		{	
			return new NavigationPage(new ModalPage());
		}
	}

	public class ModalPage : ContentPage
	{
		public ModalPage()
		{
			BackgroundColor = Color.Black;
			Content = new StackLayout {
				Padding = new Thickness(0, 0, 0, 0),
				VerticalOptions = LayoutOptions.CenterAndExpand,
				Children = {
					new Entry { 
						Placeholder = "Email Address", 
						HeightRequest = 60.0f,
						BackgroundColor = Color.White,
						TextColor = Color.Gray,
					},
				}
			};
		}
	}
}

