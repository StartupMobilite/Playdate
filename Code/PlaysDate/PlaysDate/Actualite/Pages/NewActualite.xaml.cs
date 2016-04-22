using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace PlaysDate
{
	public partial class NewActualite : ContentPage
	{
		private ActuBaseDeDonnees _database;

		public NewActualite ()
		{
			InitializeComponent ();
		}

		//Evenement losque l'on clique sur le boutton pour ajouter une actualité
		public void OnAddActuButtonClicked(object sender, EventArgs args)
		{
			//Connection a la base de données
			_database = new ActuBaseDeDonnees ();

			//Ajout de l'actualité dans la base de données ActuDB
			_database.AddData (newActuTitreEntry.Text, newActuDescriptionEntry.Text);

			//Retourne a la vue précédente
			App.Current.MainPage = new MainPage ();
		}
	}
}