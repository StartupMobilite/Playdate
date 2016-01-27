using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
using Xamarin.Forms;
using XLabs.Forms.Controls;

namespace Calendrier.iOS
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		UIWindow window;

		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			new CalendarViewRenderer ();

			Forms.Init ();

			window = new UIWindow(UIScreen.MainScreen.Bounds);

			window.RootViewController = App.GetMainPage().CreateViewController();
			window.MakeKeyAndVisible();

			return true;
		}
	}
}

