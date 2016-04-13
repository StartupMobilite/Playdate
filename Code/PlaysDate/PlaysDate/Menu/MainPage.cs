using System;
using Xamarin.Forms;

namespace PlaysDate
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
			var masterpage = e.SelectedItem as MasterPageItem;

			if (masterpage != null) 
			{
				Detail = new NavigationPage ((Page)Activator.CreateInstance (masterpage.TargetType));
				masterPage.ListView.SelectedItem = null;
				IsPresented = false;
			}
		}
	}
}