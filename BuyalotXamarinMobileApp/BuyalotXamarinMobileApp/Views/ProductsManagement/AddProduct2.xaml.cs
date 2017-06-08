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
    public partial class AddProduct2 : ContentPage
    {
        public ProductDb productDb;
        public Product product;
        public class RegistrationPageViewModel : INotifyPropertyChanged
        {
            #region INotifyPropertyChanged implementation
            public event PropertyChangedEventHandler PropertyChanged = delegate { };
            #endregion

            List<string> countries = new List<string>
    {
        "Afghanistan",
        "Albania",
        "Algeria",
        "Andorra",
        "Angola",

    };
            public List<string> Countries => countries;

        }

        public AddProduct2()
        {
            InitializeComponent();
        }
    }
}
