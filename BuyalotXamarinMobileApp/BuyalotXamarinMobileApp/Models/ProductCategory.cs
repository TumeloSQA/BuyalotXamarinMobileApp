using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyalotXamarinMobileApp.Models
{
    public class ProductCategory
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public int Count { get; set; }
        public ProductCategory()
        {
        }
    }
}

