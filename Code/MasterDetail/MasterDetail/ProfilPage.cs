﻿using System;

using Xamarin.Forms;

namespace MasterDetail
{
	public class ProfilPage : ContentPage
	{
		public ProfilPage ()
		{
			Content = new StackLayout { 
				Children = {
					new Label { Text = "Hello ContentPage" }
				}
			};
		}
	}
}


