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
    public partial class ShowUser : ContentPage
    {
        public Users user;
        public UsersDb usersDb;
        public ShowUser(Users aUsers)
        {
            InitializeComponent();
            user = aUsers;
            BindingContext = user;
        }

        public void OnEditClicked(object sender, EventArgs args)
        {
            Navigation.PushAsync(new EditUser(user));
        }
        public async void OnDeleteClicked(object sender, EventArgs args)
        {
            usersDb = new UsersDb();
            bool accepted = await DisplayAlert("Confirm", "Are you Sure ?", "Yes", "No");
            if (accepted)
            {
                usersDb.DeleteUser(user);
            }
            await Navigation.PushAsync(new ManageUsers());
        }
    }
}
