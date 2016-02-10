using System;

using Xamarin.Forms;

namespace PlaysDate
{
	public class AjoutEvenement : ContentPage
	{
		public AjoutEvenement (string date)
		{
			Content = new Label { Text = "Date selectionnée : " + date};
		}
	}
}