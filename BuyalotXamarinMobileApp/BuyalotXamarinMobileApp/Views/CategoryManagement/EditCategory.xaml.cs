using BuyalotXamarinMobileApp.Data;
using BuyalotXamarinMobileApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BuyalotXamarinMobileApp.Views.CategoryManagement
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditCategory : ContentPage
    {
        public ProductCategory productCategory;
        public CategoryDb categoryDb;
        public EditCategory(ProductCategory pProductCategory)
        {
            InitializeComponent();

            productCategory = pProductCategory;
            BindingContext = productCategory;
        }

        public void OnSaveClicked(object sender, EventArgs args)
        {
            categoryDb = new CategoryDb();
            productCategory.CategoryName = txtCateName.Text;
            categoryDb.EditAdmin(productCategory);
            Navigation.PushAsync(new ManageCategories());
        }
    }
}
