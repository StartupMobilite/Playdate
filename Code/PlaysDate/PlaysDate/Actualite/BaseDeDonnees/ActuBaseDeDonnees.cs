using System;

using SQLite.Net;

using Xamarin.Forms;
using System.Collections.Generic;
using System.Linq;
using Playsdate;

namespace PlaysDate
{
	public class ActuBaseDeDonnees
	{
		private SQLiteConnection _connection;

		public ActuBaseDeDonnees ()
		{
			_connection = DependencyService.Get<ISQLite> ().GetConnection ();
			_connection.CreateTable<ActuBD> ();
		}

		public IEnumerable<ActuBD> GetDatas() 
		{
			return (from t in _connection.Table<ActuBD> ()
				select t).Reverse().ToList ();
		}

		public ActuBD GetData(string titre) 
		{
			return _connection.Table<ActuBD> ().FirstOrDefault (t => t.ActuTitre == titre);
		}

		public void DeleteData(string titre) 
		{
			var retour = _connection.Table<ActuBD> ().FirstOrDefault (t => t.ActuTitre.Equals(titre));

			if(retour != null)
			{
				_connection.Delete<ActuBD> (retour.ID);
			}
		}

		public void DeleteDatas()
		{
			_connection.DeleteAll<ActuBD> ();
		}

		public void AddData(string titre, string description) 
		{
			var newData = new ActuBD {
				ActuTitre = titre,
				ActuDescription = description
			};

			_connection.Insert (newData);
		}
	}
}

