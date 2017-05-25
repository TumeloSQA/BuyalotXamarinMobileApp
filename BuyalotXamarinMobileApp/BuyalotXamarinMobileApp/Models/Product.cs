using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyalotXamarinMobileApp.Models
{
    public class Product
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Category { get; set; }

        public string Description { get; set; }

        public string IconUrl { get; set; }

        public string ImageUrl { get; set; }

        public string Name { get; set; }
        public string Vendor { get; set; }

        public double Price { get; set; }

        public string ProductCode { get; set; }

        public int Rating { get; set; }

        public List<string> Tags { get; set; }
    }
}
