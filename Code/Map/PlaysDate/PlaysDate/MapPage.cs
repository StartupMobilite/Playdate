using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Reflection;

using Xamarin.Forms;
using Xamarin.Forms.Maps;

using Plugin.Geolocator;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PlaysDate
{
	public class MapPage : ContentPage
	{
		Geocoder geoCoder;

		public MapPage ()
		{
			FirstMapPage();
		}

		//Fonction permettant de placer un marqueur sur la carte indiquant ma position
		public void FirstMapPage()
		{
			var geoCoder = new Geocoder ();

			var address = "139 Rue des Pyrénées, 75020 Paris";

			var centerPosition = new Position (48.856614, 2.352222);

			var approximateLocations = geoCoder.GetPositionsForAddressAsync (address);

			var pin = new Pin {
				Type = PinType.Generic,
				Position = centerPosition,
				Label = "Ma Position",
				Address = address
			};

			var distanceFromCenter = Distance.FromKilometers (0.5);

			var mapSpan = MapSpan.FromCenterAndRadius (centerPosition, distanceFromCenter);

			var map = new CustomMap(mapSpan);

			map.Pins.Add(pin);

			Content = map;
		}
	}
}