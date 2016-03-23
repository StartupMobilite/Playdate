using System;

using Xamarin.Forms;
using System.Collections.Generic;
using Xamarin.Forms.Maps;

namespace PlaysDate
{
	public class CustomMap : Map
	{
		public List<CustomPin> CustomPins { get; set; }
	}
}