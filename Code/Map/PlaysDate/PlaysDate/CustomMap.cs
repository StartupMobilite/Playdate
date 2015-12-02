using System;

using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace PlaysDate
{
	public class CustomMap : Xamarin.Forms.Maps.Map
	{
		public Position firstPosition;

		public CustomMap(MapSpan mapspan) : base (mapspan)
		{
			firstPosition = mapspan.Center;
		}
	}
}