using System;

using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace PlaysDate
{
	public class ActualitePage : ContentPage
	{
		private ActuBaseDeDonnees _database;

		public ObservableCollection<ActualiteViewModel> actus { get; set; }

		public static ListView listView = new ListView ();

		public ActualitePage ()
		{
			actus = new ObservableCollection<ActualiteViewModel> ();

			_database = new ActuBaseDeDonnees ();

			ListView listView = new ListView ();

			listView.RowHeight = 200;

			listView.ItemsSource = _database.GetDatas();
			listView.ItemTemplate = new DataTemplate (typeof(CustomActualiteCell));

			var stack = new StackLayout () 
			{
				Children = 
				{
					listView
				}
			};

			Content = stack;

			ToolbarItems.Add(new ToolbarItem("Ajout Actualité", "AddActu.png", async () =>
			{
					await Navigation.PushAsync(new NewActualite());
			}));

			listView.ItemSelected += async (sender, e) => {

				if (e.SelectedItem != null)
				{
					//Deselect row
					listView.SelectedItem= null;

					//Ouvre la page de detail
					await Navigation.PushAsync (new DetailActuPage());

					listView.IsEnabled = true;
				}
				return;
			};
		}

		protected override void OnAppearing ()
		{
			listView.ItemsSource = _database.GetDatas ();
		}

		public static ListView getListView() 
		{
			return listView;
		}

		public class CustomActualiteCell : ViewCell
		{
			public CustomActualiteCell()
			{
				StackLayout cellView = new StackLayout (){};

				cellView.Orientation = StackOrientation.Vertical;
				StackLayout cellWrapper = new StackLayout ();

				//Set Labels et Image
				var nameLabel = new Label ();
				var webimage = new Image { Aspect = Aspect.AspectFit };

				webimage.Source = ImageSource.FromUri (new Uri ("http://nouvellecaledonie.la1ere.fr/sites/regions_outremer/files/styles/top_big/public/assets/images/2015/08/18/actu-en-bref2015_660x367_1.png?itok=MrFW1r47"));

				webimage.WidthRequest = 250.0;

				//Set bindings
				//webimage.SetBinding (Image.SourceProperty, "Image");
				nameLabel.SetBinding (Label.TextProperty, "ActuTitre");

				//Add to cells
				cellView.Children.Add (webimage);
				cellView.Children.Add (nameLabel);
				cellWrapper.Children.Add (cellView);
				View = cellWrapper;

				this.View = cellView;
			}
		}
	}
}


