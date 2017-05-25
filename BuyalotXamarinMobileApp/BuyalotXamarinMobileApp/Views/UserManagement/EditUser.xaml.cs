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
    public partial class EditUser : ContentPage
    {
        public Users user;
        public UsersDb usersDb;
        public EditUser(Users uUser)
        {
            InitializeComponent();
            user = uUser;
            BindingContext = user;
        }

        public void OnSaveClicked(object sender, EventArgs args)
        {
            usersDb = new UsersDb();
            user.Username = txtUserName.Text;
            user.Email = txtEmail.Text;
            user.Password = txtPassword.Text;
            user.ConfirmPassword = txtConfirmPassword.Text;
            usersDb.EditUser(user);
            Navigation.PushAsync(new ManageUsers());
        }
    }
}
