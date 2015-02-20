using System;
using Xamarin.Forms;
using Newtonsoft.Json;

namespace XF_1_3_4_CellBindingContext
{
	public class CustomCell : ViewCell
	{
		public Label DescriptionLabel { get; set; }
		public Image Icon { get; set; }
		public TapGestureRecognizer TapRecognizer { get; set; }
		EventHandler _iconTapped;

		public CustomCell()
		{
			DescriptionLabel = new Label 
			{
				TextColor = Color.Black,
				FontSize = 14
			};

			DescriptionLabel.SetBinding(Label.TextProperty,
				new Binding("."));

			Icon = new Image 
			{
				BackgroundColor = Color.Red,
				WidthRequest = 30,
				HeightRequest = 30,
				VerticalOptions = LayoutOptions.Start,
				HorizontalOptions = LayoutOptions.End
			};

			View = new StackLayout {
				Orientation = StackOrientation.Vertical,
				HorizontalOptions = LayoutOptions.StartAndExpand,
				Children = {
					Icon,
					DescriptionLabel
				}
			};

			TapRecognizer = new TapGestureRecognizer();
			TapRecognizer.NumberOfTapsRequired = 1;
			_iconTapped = (sender, e) =>
			{
				var msg = BindingContext as string;
				Console.WriteLine(String.Format("\nBindingContext Cell '{0}'", msg));
			};
			TapRecognizer.Tapped += _iconTapped;

			Icon.GestureRecognizers.Add(TapRecognizer);
		}

		string _stash;

		protected override void OnAppearing()
		{
			base.OnAppearing();
			var msg = BindingContext as string;
			var json = JsonConvert.SerializeObject(msg);
			_stash = JsonConvert.DeserializeObject<string>(json);
			if(TapRecognizer != null)
			{
				TapRecognizer.Tapped -= _iconTapped;
				_iconTapped = (sender, e) =>
				{
					this.BindingContext = _stash;
					Console.WriteLine(String.Format("\nBindingContext Cell '{0}'", msg));
				};
				TapRecognizer.Tapped += _iconTapped;
				TapRecognizer.BindingContext = _stash;
			}

			Console.WriteLine("OnAppearing Row is: " + msg);
		}

		protected override void OnDisappearing()
		{
			base.OnDisappearing();
		}

//		void IconTapped(object sender, EventArgs e)
//		{
//			var msg = BindingContext as string;
//			Console.WriteLine(String.Format("\nBindingContext Cell '{0}'", msg));
//		}
	}
}

