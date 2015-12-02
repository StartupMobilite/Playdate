using System;

using Xamarin.Forms;

using Xamarin.Forms.Maps;
using Plugin.Geolocator;
using System.Diagnostics;

namespace PlaysDate
{
	public class MapPage : ContentPage
	{
		Geocoder geoCoder;

		public MapPage ()
		{
			var geoCoder = new Geocoder ();

			var address = "139 Rue des Pyrénées, 75020 Paris";

			var approximateLocations = geoCoder.GetPositionsForAddressAsync (address);

			var centerPosition = new Position (48.856614, 2.352222);

			var distanceFromCenter = Distance.FromKilometers (0.5);

			var mapSpan = MapSpan.FromCenterAndRadius (centerPosition, distanceFromCenter);

			var map = new CustomMap(mapSpan);

			var pin = new Pin {
				Type = PinType.Generic,
				Position = centerPosition,
				Label = "Ma Position",
				Address = "139 Rue des Pyrénées, 75020 Paris"
			};

			var slider = new Slider (1, 18, 1);
			slider.ValueChanged += (sender, e) => {
				var zoomLevel = e.NewValue;
				var latlongdegrees = 360 / (Math.Pow(2, zoomLevel));
				map.MoveToRegion(new MapSpan (map.VisibleRegion.Center, latlongdegrees, latlongdegrees));
			};

			map.Pins.Add(pin);

			Content = map;
		}
	}
}