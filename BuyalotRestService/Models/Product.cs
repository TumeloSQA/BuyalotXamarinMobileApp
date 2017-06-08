using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BuyalotRestService.Models
{
    public class Product
    {
        
        //public Product()
        //{
        //    this.Carts = new HashSet<Cart>();
        //    this.OrderDetails = new HashSet<OrderDetail>();
        //}

        [Key]
        public int ProductID { get; set; }

        [Required(ErrorMessage = "Product Name is a required field")]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Product Description is a required field")]
        [Display(Name = "Product Description")]
        [DataType(DataType.MultilineText)]
        public string ProductDescription { get; set; }

        [Required(ErrorMessage = "Category Name is a required field")]
        [Display(Name = "Category Name")]
        public int ProdCategoryID { get; set; }

        [Required(ErrorMessage = "Price is a required field")]
        [Display(Name = "Price")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Vendor is a required field")]
        [Display(Name = "Vendor")]
        public string Vendor { get; set; }

        [Required(ErrorMessage = "Quantity in Stock is a required field")]
        [Display(Name = "Quantity in Stock")]
        public int QuantityInStock { get; set; }

        [Display(Name = "Product Image")]
        public byte[] ProductImage { get; set; }

        //public virtual ICollection<Cart> Carts { get; set; }
       
        //public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ProductCategory ProductCategory { get; set; }
    }
}