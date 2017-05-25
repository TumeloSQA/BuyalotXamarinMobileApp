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
    public partial class ShowAdmin : ContentPage
    {
        public Admins admin;
        public AdminDb adminDb;
        public ShowAdmin(Admins aAdmin)
        {
            InitializeComponent();
            admin = aAdmin;
            BindingContext = admin;
        }

        public void OnEditClicked(object sender, EventArgs args)
        {
            Navigation.PushAsync(new EditAdmin(admin));
        }
        public async void OnDeleteClicked(object sender, EventArgs args)
        {
            adminDb = new AdminDb();
            bool accepted = await DisplayAlert("Confirm", "Are you Sure ?", "Yes", "No");
            if (accepted)
            {
                adminDb.DeleteAdmin(admin);
            }
            await Navigation.PushAsync(new ManageAdmins());
        }
    }
}
