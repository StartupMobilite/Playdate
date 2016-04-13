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
	public class LoadJsonFile : ContentPage
	{
		public LoadJsonFile ()
		{
			var fileCheminEquipement = "PlaysDate.Map.Json.EquipementIleDeFrance.json";
			var fileCheminInstallement = "PlaysDate.Map.Json.InstallationIleDeFrance.json";

			var assembly = typeof(LoadJsonFile).GetTypeInfo().Assembly;
			Stream stream = assembly.GetManifestResourceStream (fileCheminEquipement);

			using (StreamReader r = new StreamReader(stream))
			{
				string json = r.ReadToEnd();
				dynamic array = JsonConvert.DeserializeObject(json);
			}
		}
	}
}