
using Android.App;
using Android.Content.PM;
using Android.OS;

using Xamarin.Forms.Platform.Android;


namespace EntryTextShift.Android
{
	[Activity(Theme="@style/Theme.Forms", MainLauncher = true, LaunchMode = LaunchMode.SingleTask,
		ConfigurationChanges = ConfigChanges.KeyboardHidden | ConfigChanges.Orientation | ConfigChanges.ScreenSize)]
	public partial class MainActivity : AndroidActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			if(!Xamarin.Forms.Forms.IsInitialized)
				Xamarin.Forms.Forms.Init (this, bundle);
			SetPage(App.GetMainPage());

			ActionBar.SetIcon(Resource.Drawable.Icon);
		}

		protected override void OnResume()
		{
			base.OnResume();

			App.Navigation.PushModalAsync(App.GetModalPage());
		}
	}
}

