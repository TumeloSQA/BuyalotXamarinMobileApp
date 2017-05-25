using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net;
using Xamarin.Forms;
using BuyalotXamarinMobileApp.DbConnection;
using BuyalotXamarinMobileApp.Models;

namespace BuyalotXamarinMobileApp.Data
{
    public class AdminDb
    {
        SQLiteConnection dbConn;

        public AdminDb()
        {
            //Getting conection and Creating table
            dbConn = DependencyService.Get<ISQLite>().GetConnection();
            dbConn.CreateTable<Admins>();

        }

        public List<Admins> GetAllAdmins()
        {
            return dbConn.Query<Admins>("Select * From [Admins]");
        }
        public List<Admins> AdminLogin()
        {
            return dbConn.Query<Admins>("Select * From [Admins]");
        }
        public int SaveAdmin(Admins admin)
        {
            return dbConn.Insert(admin);
        }
        public int DeleteAdmin(Admins admin)
        {
            return dbConn.Delete(admin);
        }
        public int EditAdmin(Admins admin)
        {
            return dbConn.Update(admin);
        }
    }
}