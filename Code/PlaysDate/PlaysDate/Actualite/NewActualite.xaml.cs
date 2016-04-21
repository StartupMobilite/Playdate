using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace PlaysDate
{
	public partial class NewActualite : ContentPage
	{
		public NewActualite ()
		{
			InitializeComponent ();
		}

		public void OnAddActuButtonClicked(object sender, EventArgs args)
		{
			System.Diagnostics.Debug.WriteLine ("Clicked !!!");
		}
	}
}

