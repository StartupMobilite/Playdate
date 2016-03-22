using System;
using SQLite.Net;

namespace PlaysDate
{
	public interface ISQLite
	{
		SQLiteConnection GetConnection();
	}
}