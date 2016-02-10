using System;

using Xamarin.Forms;
using System.Collections.ObjectModel;
using Actualite;

namespace MasterDetail
{
	public class ActualitePage : ContentPage
	{
		public ObservableCollection<ActualiteViewModel> actus { get; set; }

		public ActualitePage ()
		{
			actus = new ObservableCollection<ActualiteViewModel> ();

			ListView listView = new ListView ();

			listView.RowHeight = 300;

			listView.ItemsSource = actus;
			listView.ItemTemplate = new DataTemplate (typeof(CustomActualiteCell));

			Content = listView;

			getActus ();

			listView.ItemSelected += async (sender, e) => {

				if (e.SelectedItem != null)
				{
					//Deselect row
					listView.SelectedItem= null;

					//Ouvre la page de detail
					await Navigation.PushAsync (new DetailActuPage());
				}
				return;
			};
		}

		public class CustomActualiteCell : ViewCell
		{
			public CustomActualiteCell()
			{
				StackLayout cellView = new StackLayout (){};

				cellView.Orientation = StackOrientation.Vertical;
				StackLayout cellWrapper = new StackLayout ();

				//Set Labels et Image
				var image = new Image ();
				var nameLabel = new Label ();

				//Set bindings
				image.SetBinding (Image.SourceProperty, "Image");
				nameLabel.SetBinding (Label.TextProperty, "Titre");

				//Add to cells
				cellView.Children.Add (image);
				cellView.Children.Add (nameLabel);
				cellWrapper.Children.Add (cellView);
				View = cellWrapper;

				this.View = cellView;
			}
		}

		public void getActus()
		{
			for (int i = 0; i < 10; i++) 
			{
				var webimage = new Image { Aspect = Aspect.AspectFit };
				webimage.Source = ImageSource.FromUri (new Uri ("http://nouvellecaledonie.la1ere.fr/sites/regions_outremer/files/styles/top_big/public/assets/images/2015/08/18/actu-en-bref2015_660x367_1.png?itok=MrFW1r47"));
				actus.Add (new ActualiteViewModel{ Identifiant = "1", Titre = "1er Actu !!!", Image = webimage.Source});
			}
		}
	}
}


