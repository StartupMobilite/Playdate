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
	public class JsonfileRead : ContentPage
	{
		public JsonfileRead ()
		{
			var fileCheminEquipement = "PlaysDate.Json.EquipementIleDeFrance.json";
			//var fileCheminInstallement = "PlaysDate.Json.InstallationIleDeFrance.json";

			var assembly = typeof(JsonfileRead).GetTypeInfo().Assembly;
			Stream stream = assembly.GetManifestResourceStream (fileCheminEquipement);

			string text = "";
			using (var reader = new System.IO.StreamReader (stream)) 
			{
				String responseData = reader.ReadToEnd();
			}
		}
	}
}


