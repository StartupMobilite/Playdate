using System;
using System.Reflection;
using System.IO;

using Xamarin.Forms;
using System.Collections.Generic;
using Newtonsoft.Json;

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
		}
	}
}