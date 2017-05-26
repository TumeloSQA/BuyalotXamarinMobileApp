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
    public partial class AddProduct : ContentPage
    {
        
        public AddProduct()
        {
            InitializeComponent();
            CategoryDb categories = new CategoryDb();
            picker.ItemsSource = categories.GetCategories().ToList();

        }

        //void OnPickerSelectedIndexChanged(object sender, EventArgs e)
        //{

        //    var picker = (Picker)sender;
        //    int selectedIndex = picker.SelectedIndex;

        //    if (selectedIndex != -1)
        //    {
        //        picker.SelectedItem = picker.Items[selectedIndex];
        //        lblCategory.Text = picker.SelectedIndex.ToString();
        //    }
        //}
    }
}
