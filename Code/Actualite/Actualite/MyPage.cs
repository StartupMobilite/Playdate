using System;

using Xamarin.Forms;

namespace Actualite
{
	public class MyPage : Application
	{
		public MyPage ()
		{
			MainPage = new NavigationPage(new ActualitePage());
		}
	}
}


