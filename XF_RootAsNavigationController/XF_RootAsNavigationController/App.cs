using System;
using Xamarin.Forms;

namespace XF_RootAsNavigationController
{
	public class App
	{
		public static Page GetMainPage()
		{	
			var page = new ContentPage { 
				Content = new Label {
					Text = "Hello, Forms!",
					VerticalOptions = LayoutOptions.CenterAndExpand,
					HorizontalOptions = LayoutOptions.CenterAndExpand,
				},
			};

			return new NavigationPage(page);
		}
	}
}

