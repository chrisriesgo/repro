using System;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Linq;

namespace XF_1_3_4_CellBindingContext
{
	public class MainPage : ContentPage
	{
		public MainPage()
		{
			BindingContext = new ViewModel();

			var list = new ListView {
				HasUnevenRows = true,
				VerticalOptions = LayoutOptions.FillAndExpand,
				RowHeight = -1,
				ItemTemplate = new DataTemplate(typeof(CustomCell)),
			};

			list.SetBinding<ViewModel>(ItemsView<Cell>.ItemsSourceProperty, vm => vm.Items);
			list.ItemTapped += HandleItemTapped;

			Content = list;
		}

		void HandleItemTapped (object sender, ItemTappedEventArgs e)
		{
			var list = sender as ListView;
			var vm = BindingContext as ViewModel;
			var item = vm.Items.FindIndex(m => m == e.Item);
			var a = vm.Items.FirstOrDefault(i => i == e.Item);
			Console.WriteLine("Tapped: " + item.ToString());
			list.SelectedItem = null;
		}
	}

	public class ViewModel// : ObservableBase
	{
		public ViewModel()
		{
			Items = new List<string>();
			for(var i = 1; i <= 100; i++)
			{
				Items.Add(i.ToString());
			}
		}

		private List<string> _items;
		public List<string> Items { get; set; }
//		public List<string> Items
//		{
//			get
//			{
//				return _items;
//			}
//			set
//			{
//				SetField(ref _items, value);
//			}
//		}
	}
}

