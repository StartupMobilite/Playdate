using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
using Xamarin.Forms;
using XLabs.Forms.Controls;
using XLabs.Forms;
using XLabs.Platform.Device;
using XLabs.Platform.Services.Media;
using XLabs.Ioc;
using XLabs.Platform.Services;

namespace PlaysDate.iOS
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : XFormsApplicationDelegate
	{
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init ();

			Forms.Init ();

			Xamarin.FormsMaps.Init();

			LoadApplication (new App ());

			return base.FinishedLaunching (app, options);
		}
	}
}