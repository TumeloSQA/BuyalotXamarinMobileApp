using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BuyalotXamarinMobileApp.Data;
using BuyalotXamarinMobileApp.Models;

namespace BuyalotXamarinMobileApp.Views.AdminAccount
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AdminLogin : ContentPage                                                                                                                                                           
    {

        public AdminDb AdminDb;
        public Admins aAdmins;
        public AdminLogin()
        {
            InitializeComponent();
        }

        //public void OnSaveClicked(object sender, EventArgs args, string usreName)
        //{
        //    aAdmins = new Admins();
        //    AdminDb = new AdminDb();
        //    aAdmins.Email = EmailEntry.Text;
        //    aAdmins.Password = PasswordEntry.Text;
        //    var data1 = AdminDb.(x => x.username == txtusername.Text && x.password == txtPassword.Text).FirstOrDefault(); //Linq Query

        //    Navigation.PushAsync(new ManageCategories());
        //}
    }
}
