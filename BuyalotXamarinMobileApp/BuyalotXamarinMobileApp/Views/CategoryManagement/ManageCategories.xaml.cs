using BuyalotXamarinMobileApp.Data;
using BuyalotXamarinMobileApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BuyalotXamarinMobileApp.Views.CategoryManagement
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ManageCategories : ContentPage
    {
        public CategoryDb _database;
        public ManageCategories()
        {
            InitializeComponent();

            _database = new CategoryDb();

            var categories = _database.GetCategories();
            lstData.ItemsSource = categories;
        }

        void OnSelection(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return;
                //ItemSelected is called on deselection, 
                //which results in SelectedItem being set to null
            }
            var vSelCat = (ProductCategory)e.SelectedItem;
            Navigation.PushAsync(new ShowCategory(vSelCat));
        }
        public void OnNewClicked(object sender, EventArgs args)
        {
            Navigation.PushAsync(new AddCategory());
        }
    }
}
