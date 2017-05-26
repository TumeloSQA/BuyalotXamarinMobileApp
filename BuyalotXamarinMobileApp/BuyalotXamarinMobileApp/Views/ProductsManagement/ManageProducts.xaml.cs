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
    public partial class ManageProducts : ContentPage
    {
        public ProductDb _database;
        public ManageProducts()
        {
            InitializeComponent();

            _database = new ProductDb();

            var products = _database.GetProducts();
            lstData.ItemsSource = products;
        }

        void OnSelection(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return;
                //ItemSelected is called on deselection, 
                //which results in SelectedItem being set to null
            }
            var vSelProduct = (Product)e.SelectedItem;
            Navigation.PushAsync(new ShowProduct(vSelProduct));
        }
        public void OnNewClicked(object sender, EventArgs args)
        {
            Navigation.PushAsync(new AddProduct());
        }
    }
}
