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
    public partial class AddCategory : ContentPage
    {
        public CategoryDb categoryDb;
        public ProductCategory category;
        public AddCategory()
        {
            InitializeComponent();
        }
        public void OnSaveClicked(object sender, EventArgs args, string usreName)
        {
            category = new ProductCategory();
            categoryDb = new CategoryDb();
            category.CategoryName = txtcategoryName.Text;
            categoryDb.AddCategory(category);

            Navigation.PushAsync(new ManageCategories());
        }

    }
}
