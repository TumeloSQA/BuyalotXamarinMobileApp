using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net;
using Xamarin.Forms;
using BuyalotXamarinMobileApp.Models;
using BuyalotXamarinMobileApp.DbConnection;

namespace BuyalotXamarinMobileApp.Data
{
    public class CategoryDb
    {
        private SQLiteConnection _sqlconnection;

        public CategoryDb()
        {
            //Getting conection and Creating table
            _sqlconnection = DependencyService.Get<ISQLite>().GetConnection();
            _sqlconnection.CreateTable<ProductCategory>();
        }

        //Get all categories
        public IEnumerable<ProductCategory> GetCategories()
        {
            return (from t in _sqlconnection.Table<ProductCategory>() select t).ToList();
        }

        //Get specific category
        public ProductCategory GetCategory(int id)
        {
            return _sqlconnection.Table<ProductCategory>().FirstOrDefault(t => t.Id == id);
        }

        //Delete specific category
        public int DeleteCategory(ProductCategory productCategory)
        {
            return _sqlconnection.Delete(productCategory);
        }

        //Add new category
        public void AddCategory(ProductCategory productCategory)
        {
            _sqlconnection.Insert(productCategory);
        }

        public int EditAdmin(ProductCategory productCategory)
        {
            return _sqlconnection.Update(productCategory);
        }
    }
}