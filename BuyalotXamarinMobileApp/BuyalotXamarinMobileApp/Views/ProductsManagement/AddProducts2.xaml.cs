using BuyalotXamarinMobileApp.Data;
using BuyalotXamarinMobileApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BuyalotXamarinMobileApp.Views.ProductsManagement
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddProducts2 : ContentPage
    {
        public ProductDb productDb;
        public Product product;
        public AddProducts2()
        {
            InitializeComponent();
            CategoryDb categories = new CategoryDb();

            picker.ItemsSource = categories.GetCategories().ToList();
        }

        void OnPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                monkeyNameLabel.Text = (string)picker.ItemsSource[selectedIndex];
            }
        }
    }

    
}
