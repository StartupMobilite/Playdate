using System;

using SQLite.Net;

using Xamarin.Forms;
using System.Collections.Generic;
using System.Linq;
using Playsdate;

namespace PlaysDate
{
	public class PersonneBaseDeDonnees
	{
		private SQLiteConnection _connection;

		public PersonneBaseDeDonnees ()
		{
			_connection = DependencyService.Get<ISQLite> ().GetConnection ();
			_connection.CreateTable<PersonBD> ();
		}

		public IEnumerable<PersonBD> GetDatas() 
		{
			return (from t in _connection.Table<PersonBD> ()
				select t).ToList ();
		}

		public PersonBD GetData(string pseudo) 
		{
			return _connection.Table<PersonBD> ().FirstOrDefault (t => t.PersonPseudo == pseudo);
		}

		public PersonBD PersonExistForConnexion(string pseudo, string mdp)
		{
			return _connection.Table<PersonBD> ().FirstOrDefault (t => (t.PersonPseudo == pseudo && t.PersonMotDePasse == mdp));
		}

		public void DeleteData(string pseudo) 
		{
			var retour = _connection.Table<PersonBD> ().FirstOrDefault (t => t.PersonPseudo.Equals(pseudo));

			if(retour != null)
			{
				_connection.Delete<PersonBD> (retour.ID);
			}
		}

		public void DeleteDatas()
		{
			_connection.DeleteAll<PersonBD> ();
		}

		public void AddData(string nom, string prenom, string pseudo, string email, string mdp, string imagePath) 
		{
			var newData = new PersonBD {
				PersonNom = nom,
				PersonPrenom = prenom,
				PersonPseudo = pseudo,
				PersonMail = email,
				PersonMotDePasse = mdp,
				PersonImagePath= imagePath
			};

			_connection.Insert (newData);
		}
	}
}