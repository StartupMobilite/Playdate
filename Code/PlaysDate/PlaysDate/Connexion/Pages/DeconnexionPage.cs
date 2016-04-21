using System;

using Xamarin.Forms;

namespace PlaysDate
{
	public class DeconnexionPage : ContentPage
	{
		public DeconnexionPage ()
		{
			Navigation.PushModalAsync (new ConnexionPage());
		}
	}
}