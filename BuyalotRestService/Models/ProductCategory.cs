using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BuyalotRestService.Models
{
    public class ProductCategory
    {
        public ProductCategory()
        {
            this.Products = new HashSet<Product>();
        }

        [Key]
        public int ProdCategoryID { get; set; }

        [Required(ErrorMessage = "Category Name is a required field")]
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}