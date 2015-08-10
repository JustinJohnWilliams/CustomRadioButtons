using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;

namespace RadioButtons.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : FormsApplicationDelegate
    {
        UIWindow _window;

        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            Forms.Init();

            _window = new UIWindow(UIScreen.MainScreen.Bounds);

            LoadApplication(new RadioButtons());

            return base.FinishedLaunching(app, options);
        }
    }
}