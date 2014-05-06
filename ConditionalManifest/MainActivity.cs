using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace ConditionalManifest
{
	#if DEBUG
	[Activity(Label = "Conditional Manifest DEBUG", MainLauncher = true)]
	#else
	[Activity(Label = "Conditional Manifest", MainLauncher = true)]
	#endif
	public class MainActivity : Activity
	{
		// 	TODO:	See the csproj file Debug Conditional:
		//	I expect this to evaluate and overwrite which manifest template to use
		//	<AndroidManifest>Properties\AndroidManifestDebug.xml</AndroidManifest>

		int count = 1;

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button>(Resource.Id.myButton);
			
			button.Click += delegate
			{
				button.Text = string.Format("{0} clicks!", count++);
			};
		}
	}
}


