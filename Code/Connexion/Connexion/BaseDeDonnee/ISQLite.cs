using System;
using SQLite.Net;

namespace Connexion
{
	public interface ISQLite
	{
		SQLiteConnection GetConnection();
	}
}