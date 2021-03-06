﻿using System;

using Xamarin.Forms;

namespace PlaysDate
{
	public class App : Application
	{
		public App ()
		{
			MainPage = new ConnexionPage ();
		}

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