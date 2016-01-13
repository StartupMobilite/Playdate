using System;

using Xamarin.Forms;

namespace Actualite
{
	public class ActualiteViewModel : ContentPage
	{
		public string Identifiant { get; set; }
		public string Titre { get; set; }
		//public string URLImage { get; set; }
		public ImageSource Image { get; set; }

		public ActualiteViewModel ()
		{
			
		}
	}
}


