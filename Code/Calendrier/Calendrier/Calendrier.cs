using System;
using Xamarin.Forms;
using XLabs.Forms.Controls;

namespace Calendrier
{
	public class App : Application
	{
		public static Page GetMainPage ()
		{	
			return new NavigationPage(
				new CalendrierPage()
			);
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

