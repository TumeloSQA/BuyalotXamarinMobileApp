using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms;
using BuyalotXamarinMobileApp.DbConnection;
using SQLite.Net.Async;
using System.IO;
using SQLite.Net;
using SQLite.Net.Platform.XamarinIOS;

[assembly: Dependency(typeof(BuyalotXamarinMobileApp.iOS.DbConnectioniOS.SQLiteConnectionTouch))]
namespace BuyalotXamarinMobileApp.iOS.DbConnectioniOS
{
    public class SQLiteConnectionTouch : ISQLiteConnection
    {
        private SQLiteAsyncConnection _connection;

        public string GetDataBasePath()
        {
            string filename = "BuyalotDb5.db3";
            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libFolder = Path.Combine(docFolder, "..", "Library", "Databases");

            if (!Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);
            }

            return Path.Combine(libFolder, filename);
        }

        public SQLiteAsyncConnection GetConnection()
        {
            if (_connection != null)
            {
                return _connection;
            }

            SQLiteConnectionWithLock connectioonWithLock =
            new SQLiteConnectionWithLock(
            new SQLitePlatformIOS(),
            new SQLiteConnectionString(GetDataBasePath(), true));
            return _connection = new SQLiteAsyncConnection(() => connectioonWithLock);
        }
    }
}