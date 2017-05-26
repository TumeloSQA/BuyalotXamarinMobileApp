using BuyalotXamarinMobileApp.Data;
using BuyalotXamarinMobileApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BuyalotXamarinMobileApp.Views.ProductsManagement
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddProduct : ContentPage
    {
        public ProductDb productDb;
        public Product product;
        public AddProduct()
        {
            InitializeComponent();
            CategoryDb categories = new CategoryDb();
            
            picker.ItemsSource = categories.GetCategories().ToList();

        }

        void OnPickerSelectedIndexChanged(object sender, EventArgs e)
        {

            picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                lblCategory.Text = (string)picker.ItemsSource[selectedIndex];
                txtPrice.Text = (string)picker.ItemsSource[selectedIndex];
            }
        }

        public void OnSaveClicked(object sender, EventArgs args)
        {
            product = new Product();
            productDb = new ProductDb();
            product.Name = txtName.Text;
            product.Description = txtDescription.Text;
            product.Price = txtPrice.Text;
            product.Vendor = txtVendor.Text;
            product.Category = picker.SelectedIndex.ToString();
            productDb.AddProduct(product);

            DisplayAlert("Success", "Succesfully added product", "OK", product.Name);
            //Navigation.PushAsync(new WelcomeAdmin(txtAdminName.Text));
            Navigation.PushAsync(new ManageProducts());
        }
    }
}
