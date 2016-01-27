using System;

using Xamarin.Forms;

namespace MasterDetail
{
	public class ContactPage : ContentPage
	{
		public ContactPage ()
		{
			Title = "Contacts Page";
			Content = new StackLayout { 
				Children = {
					new Label {
						Text = "Contacts data goes here",
						HorizontalOptions = LayoutOptions.Center,
						VerticalOptions = LayoutOptions.CenterAndExpand
					}
				}
			};
		}
	}
}


