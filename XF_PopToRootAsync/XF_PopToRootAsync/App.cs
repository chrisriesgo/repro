using System;
using Xamarin.Forms;

namespace XF_PopToRootAsync
{
	public class App
	{
		public static INavigation Navigation { get; private set; }

		public static Page GetMainPage()
		{	
			var label = new Label {
				Text = "Hello, Forms!",
				VerticalOptions = LayoutOptions.CenterAndExpand,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
			};

			var page2button = new Button()
			{
				Text = "Go To Page 2",
				VerticalOptions = LayoutOptions.CenterAndExpand,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
			};
			page2button.Clicked += (sender, e) => 
			{
				App.Navigation.PushAsync(App.GetSecondPage());
			};


			var mainpage = new ContentPage { 
				Content = new StackLayout { Children = { label, page2button} },
			};

			var navigationpage = new NavigationPage(mainpage);

			Navigation = navigationpage.Navigation;

			return navigationpage;
		}

		public static Page GetSecondPage()
		{
			var popbutton = new Button()
			{
				Text = "Pop To Root",
				VerticalOptions = LayoutOptions.CenterAndExpand,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
			};

			popbutton.Clicked += (sender, e) => 
			{
				App.Navigation.PopToRootAsync();
			};

			return new ContentPage { 
				Title = "Page 2",
				Content = popbutton,
			};
		}
	}
}

