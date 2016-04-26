using System;

using Xamarin.Forms;
using Xamarin.Forms.Maps;

using System.Collections.Generic;
using System.Threading.Tasks;

using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PlaysDate
{
	public class MapPage : ContentPage
	{
		Geocoder geoCoder;

		public MapPage ()
		{
			var fileCheminEquipement = "Maps.Json.EquipementIleDeFrance.json";
			var fileCheminInstallement = "Maps.Json.InstallationIleDeFrance.json";

			var assembly = typeof(JsonfileRead).GetTypeInfo().Assembly;
			Stream stream = assembly.GetManifestResourceStream (fileCheminEquipement);

			var customMap = new CustomMap 
			{
				MapType = MapType.Street
			};

			geoCoder = new Geocoder ();

			var locator = CrossGeolocator.Current;
			locator.DesiredAccuracy = 50;

			locator.GetPositionAsync (timeoutMilliseconds: 10000).ContinueWith (t => {

				var pin = new CustomPin {
					Pin = new Pin {
						Type = PinType.Place,
						Position = new Xamarin.Forms.Maps.Position (t.Result.Latitude, t.Result.Longitude),
						Label = "Ma Position",
						//Address = "394 Pacific Ave, San Francisco CA"
					},
					Name = "Xam",
					Id = "Xamarin"
				};

				customMap.CustomPins = new List<CustomPin> { pin };
				customMap.Pins.Add (pin.Pin);
				customMap.MoveToRegion (MapSpan.FromCenterAndRadius (new Xamarin.Forms.Maps.Position (t.Result.Latitude, t.Result.Longitude), Distance.FromMiles (0.3)));

				Content = customMap;
			}, TaskScheduler.FromCurrentSynchronizationContext());

			StreamReader r = new StreamReader (stream);
				
			string json = r.ReadToEnd ();

			JArray array = JArray.Parse (json);

			foreach (JObject content in array.Children<JObject>()) {
				foreach (JProperty prop in content.Properties()) {
					if (prop.Name == "geo_point_2d") {
						string s = (string)prop.Value;

						string[] words = s.Split (',');

						string latitudeString = words [0];
						string longitudeString = words [1].TrimStart ();

						double lat = Convert.ToDouble (latitudeString);
						double lon = Convert.ToDouble (longitudeString);

						var position = new Xamarin.Forms.Maps.Position (lat, lon);

						var possibleAddresses = geoCoder.GetAddressesForPositionAsync (position);

						var pin = new CustomPin {
							Pin = new Pin {
								Type = PinType.Place,
								Position = position,
								Label = ""
								//Address = possibleAddresses.Result.ToString()
							}
						};

						customMap.CustomPins = new List<CustomPin> { pin };
						customMap.Pins.Add (pin.Pin);

						Content = customMap;
					}
				}
			}
		}
	}
}