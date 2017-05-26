using BuyalotXamarinMobileApp.Data;
using BuyalotXamarinMobileApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BuyalotXamarinMobileApp.Views.ProductsManagement
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShowProduct : ContentPage
    {
        public Product product;
        public ProductDb productDb;
        public ShowProduct(Product pProduct)
        {
            InitializeComponent();

            product = pProduct;
            BindingContext = product;
        }

        public void OnEditClicked(object sender, EventArgs args)
        {
            Navigation.PushAsync(new EditProduct(product));
        }
        public async void OnDeleteClicked(object sender, EventArgs args)
        {
            productDb = new ProductDb();
            bool accepted = await DisplayAlert("Confirm", "Are you Sure ?", "Yes", "No");
            if (accepted)
            {
                productDb.DeleteProduct(product);
            }
            await Navigation.PushAsync(new ManageProducts());
        }

    }
}
