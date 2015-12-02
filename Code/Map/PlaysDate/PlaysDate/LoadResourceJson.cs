using System;
using System.Reflection;
using System.IO;

using Xamarin.Forms;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;

namespace PlaysDate
{
	public class LoadResourceJson : ContentPage
	{
		public LoadResourceJson ()
		{
			var fileCheminEquipement = "PlaysDate.Json.EquipementIleDeFrance.json";
			//var fileCheminInstallement = "PlaysDate.Json.InstallationIleDeFrance.json";
			
			var assembly = typeof(LoadResourceJson).GetTypeInfo().Assembly;
			Stream stream = assembly.GetManifestResourceStream (fileCheminEquipement);

			string text = "";
			using (var reader = new System.IO.StreamReader (stream)) 
			{
				String responseData = reader.ReadToEnd();
			}

//			JsonSchema schema = JsonSchema.Parse(@"{
//			    ""ins_nom"":""WAOU CLUB MED GYM PORTE MAILLOT"",
//			    ""ins_com"":""Paris 17e  Arrondissement"",
//			    ""eqt_nom"":""SALLE DE CYCLING"",
//			    ""eqt_type"":""Salle de cours collectifs"",
//			    ""eqt_fam"":""Equipement d'activités de forme et de santé"",
//			    ""eqt_fam_id"":9,
//			    ""eqt_typ_id"":60,
//			    ""eqt_id"":142210,
//			    ""ins_id"":750560618,
//			    ""eqt_pro_id"":5,
//			    ""eqt_pro"":""Etablissement privé commercial"",
//			    ""eqt_public"":""Non"",
//			    ""eqt_nb"":1,
//			    ""ins_insee"":75117,
//			    ""geo_point_2d"":""48.8807159009, 2.2850221"",
//			    ""geo_shape"":""{\""type\"": \""Point\"", \""coordinates\"": [2.2850221, 48.88071590092074]}""
//			 }");
//
//			JObject user = JObject.Parse(@"{
//				'ins_nom': 'COLLEGE MARIE CURIE',
//				'geo_point_2d': '48.8927000009, 2.35764'
//			}");
//
//			JsonSchema schema = JsonSchema.Parse(@"{
//			  'type': 'object',
//			  'properties': {
//			    'name': {'type':'string'},
//			    'roles': {'type': 'array'}
//			  }
//			}");
//
//			JObject user = JObject.Parse(@"{
//			  'name': 'Arnie Admin',
//			  'roles': ['Developer', 'Administrator']
//			}");
//
//			bool valid = user.IsValid(schema);
		}
	}
}