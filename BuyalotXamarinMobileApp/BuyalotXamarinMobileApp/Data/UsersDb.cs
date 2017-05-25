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
    public class UsersDb
    {
        private SQLiteConnection _sqlconnection;

        public UsersDb()
        {
            //Getting conection and Creating table
            _sqlconnection = DependencyService.Get<ISQLite>().GetConnection();
            _sqlconnection.CreateTable<Users>();
        }

        //Get all users
        public IEnumerable<Users> GetUsers()
        {
            return (from t in _sqlconnection.Table<Users>() select t).ToList();
        }

        //Get specific user
        public Users GetUser(int id)
        {
            return _sqlconnection.Table<Users>().FirstOrDefault(t => t.Id == id);
        }

        public int DeleteUser(Users user)
        {
            return _sqlconnection.Delete(user);
        }
        //Add new user to DB
        public void AddUser(Users user)
        {
            _sqlconnection.Insert(user);

        }

        public int EditUser(Users user)
        {
            return _sqlconnection.Update(user);
        }
    }
}