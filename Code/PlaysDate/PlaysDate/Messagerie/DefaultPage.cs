using System;

using Xamarin.Forms;

namespace PlaysDate
{
	public class DefaultPage : ContentPage
	{
		public DefaultPage ()
		{
			Content = new StackLayout { 
				Children = {
					new Label { Text = "Hello ContentPage" }
				}
			};
		}
	}
}