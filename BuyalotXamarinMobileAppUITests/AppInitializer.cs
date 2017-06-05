using System;
using System.IO;
using System.Linq;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace BuyalotXamarinMobileAppUITests
{
    public class AppInitializer
    {
        public static IApp StartApp(Platform platform)
        {
            if (platform == Platform.Android)
            {
                return ConfigureApp
                    .Android
                    .DeviceSerial("3100b9331d47a22d")
                    .ApkFile(@"C:\Dev\Project\BuyalotXamarinMobileApp\BuyalotXamarinMobileApp.Android.apk")
                    .PreferIdeSettings()
                    .StartApp();
            }

            return ConfigureApp
                .iOS
                .StartApp();
        }
    }
}