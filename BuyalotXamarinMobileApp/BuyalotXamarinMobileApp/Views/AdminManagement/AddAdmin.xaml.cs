using BuyalotXamarinMobileApp.Data;
using BuyalotXamarinMobileApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BuyalotXamarinMobileApp.Views.AdminManagement
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddAdmin : ContentPage
    {
        public AdminDb adminDb;
        public Admins admin;
        public AddAdmin()
        {
            InitializeComponent();
        }

        public void OnSaveClicked(object sender, EventArgs args)
        {
            admin = new Admins();
            adminDb = new AdminDb();
            admin.AdminName = txtAdminName.Text;
            admin.Username = txtUsername.Text;
            admin.Email = txtEmail.Text;
            admin.Password = txtPassword.Text;
            adminDb.SaveAdmin(admin);

            DisplayAlert("Success", "Succesfully added admin", "OK", admin.AdminName);
            //Navigation.PushAsync(new WelcomeAdmin(txtAdminName.Text));
            Navigation.PushAsync(new ManageAdmins());
        }
    }
}
