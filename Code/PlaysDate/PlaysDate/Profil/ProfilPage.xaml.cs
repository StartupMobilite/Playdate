using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Playsdate;

namespace PlaysDate
{
	public partial class ProfilPage : ContentPage
	{
		private PersonneBaseDeDonnees _database;

		public ProfilPage ()
		{
			InitializeComponent ();

			_database = new PersonneBaseDeDonnees ();

			PersonBD personConnecte = _database.GetData (ConnexionPage.personConnecte);

			ProfilImage.Source = ImageSource.FromFile (personConnecte.PersonImagePath);

			Nom.Text = personConnecte.PersonNom;
			Prenom.Text = personConnecte.PersonPrenom;
			Email.Text = personConnecte.PersonMail;
		}
	}
}

