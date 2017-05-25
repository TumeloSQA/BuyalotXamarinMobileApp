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
    public partial class ShowCategory : ContentPage
    {
        public ProductCategory productCategory;
        public CategoryDb categoryDb;
        public ShowCategory(ProductCategory aproductCategory)
        {
            InitializeComponent();
            productCategory = aproductCategory;
            BindingContext = productCategory;
        }

        public void OnEditClicked(object sender, EventArgs args)
        {
            Navigation.PushAsync(new EditCategory(productCategory));
        }
        public async void OnDeleteClicked(object sender, EventArgs args)
        {
            categoryDb = new CategoryDb();
            bool accepted = await DisplayAlert("Confirm", "Are you Sure ?", "Yes", "No");
            if (accepted)
            {
                categoryDb.DeleteCategory(productCategory);
            }
            await Navigation.PushAsync(new ManageCategories());
        }
    }
}
