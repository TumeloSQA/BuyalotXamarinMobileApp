using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using BuyalotXamarinMobileApp.MenuItems;
using BuyalotXamarinMobileApp.Views;
using BuyalotXamarinMobileApp.Views.CategoryManagement;
using BuyalotXamarinMobileApp.Views.UserManagement;
using BuyalotXamarinMobileApp.Views.AdminManagement;
using BuyalotXamarinMobileApp.Views.Products;
using BuyalotXamarinMobileApp.Views.ProductsManagement;
//using BuyalotXamarinMobileApp.Views.ShoppingCart;
//using BuyalotXamarinApp.View.AdminAccount;

namespace BuyalotXamarinMobileApp
{
    public partial class MainPage : MasterDetailPage
    {
        public List<MasterPageItem> MenuList { get; set; }
        public MainPage()
        {

            InitializeComponent();

            MenuList = new List<MasterPageItem>();

            // Creating our pages for menu navigation
            // Here you can define title for item, 
            // icon on the left side, and page that you want to open after selection
            var page1 = new MasterPageItem() { Title = "Category Management", Icon = "itemIcon1.png", TargetType = typeof(ManageCategories) };
            var page2 = new MasterPageItem() { Title = "User Management", Icon = "itemIcon2.png", TargetType = typeof(ManageUsers) };
            var page3 = new MasterPageItem() { Title = "Admin Management", Icon = "itemIcon2.png", TargetType = typeof(ManageAdmins) };
            var page4 = new MasterPageItem() { Title = "Products", Icon = "itemIcon2.png", TargetType = typeof(ViewProducts) };
            var page5 = new MasterPageItem() { Title = "Products Management", Icon = "burger.jpg", TargetType = typeof(AddProduct) };



            // Adding menu items to menuList
            MenuList.Add(page1);
            MenuList.Add(page2);
            MenuList.Add(page3);
            MenuList.Add(page4);
            MenuList.Add(page5);



            // Setting our list to be ItemSource for ListView in MainPage.xaml
            navigationDrawerList.ItemsSource = MenuList;

            // Initial navigation, this can be used for our home page
            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(ManageCategories)));
        }

        // Event for Menu Item selection, here we are going to handle navigation based
        // on user selection in menu ListView
        private void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            var item = (MasterPageItem)e.SelectedItem;
            Type page = item.TargetType;

            Detail = new NavigationPage((Page)Activator.CreateInstance(page));
            IsPresented = false;
        }
    }

}
