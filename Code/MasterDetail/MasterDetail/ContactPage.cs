using System;

using Xamarin.Forms;

namespace MasterDetail
{
	public class ContactPage : ContentPage
	{
		public ContactPage ()
		{
			Content = new StackLayout { 
				Children = {
					new Label { Text = "Hello ContentPage" }
				}
			};
		}
	}
}


