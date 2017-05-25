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
    public partial class ManageAdmins : ContentPage
    {
        public AdminDb _database;
        public ManageAdmins()
        {
            InitializeComponent();

            _database = new AdminDb();

            var admins = _database.GetAllAdmins();
            lstData.ItemsSource = admins;
        }

        void OnSelection(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return;
                //ItemSelected is called on deselection, 
                //which results in SelectedItem being set to null
            }
            var vSelAdmin = (Admins)e.SelectedItem;
            Navigation.PushAsync(new ShowAdmin(vSelAdmin));
        }
        public void OnNewClicked(object sender, EventArgs args)
        {
            Navigation.PushAsync(new AddAdmin());
        }
    }
}
