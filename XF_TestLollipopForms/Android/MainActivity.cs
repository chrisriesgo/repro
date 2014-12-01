using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using Xamarin.Forms.Platform.Android;


namespace TestLollipopForms.Android
{
	[Activity(Label = "TestLollipopForms.Android.Android", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : AndroidActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			Xamarin.Forms.Forms.Init(this, bundle);

			SetPage(App.GetAndroidNavigationPage());
		}

		protected override void OnResume()
		{
			base.OnResume();

			App.Navigation.PushModalAsync(App.GetAnotherPage());
		}
	}
}

