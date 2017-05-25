using BuyalotXamarinMobileApp.Data;
using BuyalotXamarinMobileApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BuyalotXamarinMobileApp.Views.UserManagement
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddUser : ContentPage
    {
        public UsersDb usersDb;
        public Users user;
        public AddUser()
        {
            InitializeComponent();
        }

        public void OnSaveClicked(object sender, EventArgs args)
        {
            user = new Users();
            usersDb = new UsersDb();
            user.Username = txtUsername.Text;
            user.Email = txtEmail.Text;
            user.Password = txtPassword.Text;
            user.ConfirmPassword = txtConfirmPassword.Text;
            usersDb.AddUser(user);

            Navigation.PushAsync(new ManageUsers());
        }
    }
}
