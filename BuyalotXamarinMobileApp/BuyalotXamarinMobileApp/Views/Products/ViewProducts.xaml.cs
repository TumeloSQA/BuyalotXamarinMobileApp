using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BuyalotXamarinMobileApp.Views.Products
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewProducts : ContentPage
    {
        public ViewProducts()
        {
            InitializeComponent();
            var beachImage = new Image { Aspect = Aspect.AspectFit };
            beachImage.Source = ImageSource.FromFile("AcerTravelMate.jpg");
        }
    }
}
