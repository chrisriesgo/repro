using System;
using System.Collections.Generic;
using System.Linq;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

using Xamarin.Forms;

namespace XF_RootAsNavigationController.iOS
{
	[Register("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		UIWindow window;

		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			Forms.Init();

			window = new UIWindow(UIScreen.MainScreen.Bounds);

			var viewController = App.GetMainPage().CreateViewController();
			var navController = viewController as UINavigationController;
			if(navController == null)
			{
				var alert = new UIAlertView("Invalid Cast", "This ViewController should be of type UINavigationController. It's not.", null, "Sorry", null);
				alert.Show();
			}

			window.RootViewController = viewController;
			window.MakeKeyAndVisible();
			
			return true;
		}
	}
}

