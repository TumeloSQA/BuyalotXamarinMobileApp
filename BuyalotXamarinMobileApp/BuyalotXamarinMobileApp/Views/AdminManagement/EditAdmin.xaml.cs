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
    public partial class EditAdmin : ContentPage
    {
        public Admins admin;
        public AdminDb adminDb;
        public EditAdmin(Admins aAdmin)
        {
            InitializeComponent();
            admin = aAdmin;
            BindingContext = admin;
        }

        public void OnSaveClicked(object sender, EventArgs args)
        {
            adminDb = new AdminDb();
            admin.AdminName = txtAdminName.Text;
            admin.Username = txtUsername.Text;
            admin.Email = txtEmail.Text;
            admin.Password = txtPassword.Text;
            adminDb.EditAdmin(admin);
            Navigation.PushAsync(new ManageAdmins());
        }
    }
}
