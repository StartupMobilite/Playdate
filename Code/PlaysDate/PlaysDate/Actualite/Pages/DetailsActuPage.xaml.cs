using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace PlaysDate
{
	public partial class DetailsActuPage : ContentPage
	{
		private ActuBaseDeDonnees _database;

		public DetailsActuPage (string titre)
		{
			InitializeComponent ();

			_database = new ActuBaseDeDonnees ();

			ActuBD a = _database.GetData(titre);

			NewsImage.Source = ImageSource.FromUri(new Uri("http://nouvellecaledonie.la1ere.fr/sites/regions_outremer/files/styles/top_big/public/assets/images/2015/08/18/actu-en-bref2015_660x367_1.png?itok=MrFW1r47"));

			NewsTitle.Text = a.ActuTitre;

			NewsDescription.Text = a.ActuDescription;
		}
	}
}

