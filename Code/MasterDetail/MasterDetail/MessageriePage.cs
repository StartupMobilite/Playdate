using System;

using Xamarin.Forms;

namespace MasterDetail
{
	public class MessageriePage : ContentPage
	{
		public MessageriePage ()
		{
			Content = new StackLayout { 
				Children = {
					new Label { Text = "Hello ContentPage" }
				}
			};
		}
	}
}


