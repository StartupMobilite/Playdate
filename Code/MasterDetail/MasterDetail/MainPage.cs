using System;
using Xamarin.Forms;

namespace MasterDetail
{
	public class MainPage : MasterDetailPage
	{
		MasterPage masterPage;

		public MainPage ()
		{
			masterPage = new MasterPage ();
			Master = masterPage;
			Detail = new NavigationPage (new ActualitePage());

			masterPage.ListView.ItemSelected += OnItemSelected;
		}

		void OnItemSelected (object sender, SelectedItemChangedEventArgs e)
		{
			var item = e.SelectedItem as MasterPageItem;

			if (item != null) 
			{
				Detail = new NavigationPage ((Page)Activator.CreateInstance (item.TargetType));
				masterPage.ListView.SelectedItem = null;
				IsPresented = false;
			}
		}
	}
}

