using System;
using System.IO;

using SQLite;
using Xamarin.Forms;

using PlaysDate.Android;

[assembly: Dependency(typeof(SQLite_Android_Person))]

namespace PlaysDate.Android
{
	public class SQLite_Android_Person: ISQLite
	{
		public SQLite_Android_Person ()
		{

		}

		#region ISQLite implementation

		public SQLite.Net.SQLiteConnection GetConnection ()
		{
			var fileName = "Person.db3";
			var documentsPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal);
			var path = Path.Combine (documentsPath, fileName);

			var platform = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid ();
			var connection = new SQLite.Net.SQLiteConnection (platform, path);

			return connection;
		}

		#endregion
	}
}