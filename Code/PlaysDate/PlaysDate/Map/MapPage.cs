using System;

using Xamarin.Forms;
using Xamarin.Forms.Maps;

using System.Collections.Generic;
using System.Threading.Tasks;

using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using System.Reflection;
using System.IO;
using Newtonsoft.Json;

namespace PlaysDate
{
	public class MapPage : ContentPage
	{
		Geocoder geoCoder;

		public MapPage ()
		{
			var customMap = new CustomMap 
			{
				MapType = MapType.Street,
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
		}
	}
}