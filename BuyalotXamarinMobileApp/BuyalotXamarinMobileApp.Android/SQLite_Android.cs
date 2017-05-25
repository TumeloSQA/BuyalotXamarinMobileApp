using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using Xamarin.Forms;
using BuyalotXamarinMobileApp.Droid;


using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using BuyalotXamarinMobileApp.DbConnection;
using SQLite.Net.Async;

[assembly: Dependency(typeof(SQLite_Android))]
namespace BuyalotXamarinMobileApp.Droid
{
    public class SQLite_Android : ISQLite
    {
        public SQLite.Net.SQLiteConnection GetConnection()
        {
            var filename = "BuyalotDb4.db3";
            var documentspath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentspath, filename);

            var platform = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
            var connection = new SQLite.Net.SQLiteConnection(platform, path);
            return connection;
        }

    }
}