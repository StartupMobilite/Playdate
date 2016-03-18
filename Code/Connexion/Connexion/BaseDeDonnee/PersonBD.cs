using System;
using SQLite.Net.Attributes;

namespace Connexion
{
	public class PersonBD
	{
		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }

		public string PersonNom { get; set; }

		public string PersonPrenom { get; set; }

		public string PersonPseudo { get; set; }

		public string PersonMail { get; set; }

		public string PersonMotDePasse { get; set; }

		public override string ToString()
		{
			return string.Format("[SerieOrMovieIsFav : ID={0}, PersonNom={1}, PersonPrenom={2}, PersonPseudo={3}, PersonMail={4}, PersonMotDePasse={5}", ID, PersonNom, PersonPrenom, PersonPseudo, PersonMail, PersonMotDePasse);
		}

		public PersonBD ()
		{
			
		}
	}
}

