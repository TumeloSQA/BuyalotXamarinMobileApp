using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using BuyalotXamarinMobileApp.DbConnection;
using Xamarin.Forms;
using SQLite.Net.Async;
using SQLite.Net;
using System.IO;
using SQLite.Net.Platform.XamarinAndroid;

[assembly: Dependency(typeof(BuyalotXamarinMobileApp.Droid.DbConnectionDroid.SQLiteConnectionDroid))]
namespace BuyalotXamarinMobileApp.Droid.DbConnectionDroid
{
    public class SQLiteConnectionDroid : ISQLiteConnection
    {
        private SQLiteAsyncConnection _connection;

        public string GetDataBasePath()
        {
            string filename = "BuyalotDb4.db3";
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData);
            return Path.Combine(path, filename);
        }

        public SQLiteAsyncConnection GetConnection()
        {
            if (_connection != null)
            {
                return _connection;
            }

            SQLiteConnectionWithLock connectioonWithLock =
            new SQLiteConnectionWithLock(new SQLitePlatformAndroid(), new SQLiteConnectionString(GetDataBasePath(), true));
            return _connection = new SQLiteAsyncConnection(() => connectioonWithLock);
        }
    }
}