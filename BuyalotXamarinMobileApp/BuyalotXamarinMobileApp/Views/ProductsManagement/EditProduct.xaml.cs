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
    public partial class EditProduct : ContentPage
    {

        public Product product;
        public ProductDb productDb;
        public EditProduct(Product pProduct)
        {
            InitializeComponent();
            product = pProduct;
            BindingContext = product;
        }

        public void OnSaveClicked(object sender, EventArgs args)
        {
            //productDb = new ProductDb();
            //product.Category = txtAdminName.Text;
            //product.Name = txtUsername.Text;
            //admin.Email = txtEmail.Text;
            //admin.Password = txtPassword.Text;
            //adminDb.EditAdmin(admin);
            //Navigation.PushAsync(new ManageAdmins());
        }

    }
}
