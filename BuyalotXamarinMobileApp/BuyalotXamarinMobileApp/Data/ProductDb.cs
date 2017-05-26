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
    
    public class ProductDb
    {
        private SQLiteConnection _sqlconnection;
        public ProductDb()
        {
            //Getting conection and Creating table
            _sqlconnection = DependencyService.Get<ISQLite>().GetConnection();
            _sqlconnection.CreateTable<Product>();
        }

        //Get all products
        public IEnumerable<Product> GetProducts()
        {
            return (from t in _sqlconnection.Table<Product>() select t).ToList();
        }

        //Get specific product
        public Product GetProduct(int id)
        {
            return _sqlconnection.Table<Product>().FirstOrDefault(t => t.Id == id);
        }

        //Delete specific Product
        public int DeleteProduct(Product product)
        {
            return _sqlconnection.Delete(product);
        }

        //Add new product
        public void AddProduct(Product product)
        {
            _sqlconnection.Insert(product);
        }

        //Edit category
        public int EditCategory(Product product)
        {
            return _sqlconnection.Update(product);
        }

    }
}
