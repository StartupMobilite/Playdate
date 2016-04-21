using System;
using SQLite.Net.Attributes;

namespace PlaysDate
{
	public class ActuBD
	{
		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }

		public string ActuTitre { get; set; }

		public string ActuDescription { get; set; }

		public override string ToString()
		{
			return string.Format("[Person : ID={0}, ActuTitre={1}, ActuDescription={2}", ID, ActuTitre, ActuDescription);
		}

		public ActuBD ()
		{

		}
	}
}

