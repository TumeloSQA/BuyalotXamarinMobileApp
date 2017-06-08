using System.Threading.Tasks;
using RestClient.Models;
using RestClient.ViewModels;
using Xamarin.Forms;

namespace RestClient.Views
{
    public class TasksPageView : ContentPage
    {

        public TasksPageView()
        {

            InitializeUiAsync();
        }

        private async Task InitializeUiAsync()
        {
            var tasksViewModel = new TasksViewModel();

            await tasksViewModel.DownloadDataAsync();

            BindingContext = tasksViewModel;

            Title = "Home";

            BackgroundColor = Color.White;

            var getToolbarItem = new ToolbarItem
            {
                Text = "GET",
                Icon = "refresh.png",
                Order = ToolbarItemOrder.Primary,
            };

            ToolbarItems.Add(getToolbarItem);

            var dataTemplate = new DataTemplate(typeof(TaskViewCell));

            var listView = new ListView
            {
                HasUnevenRows = true,
                SeparatorVisibility = SeparatorVisibility.Default,
                SeparatorColor = Color.Gray,
                BindingContext = tasksViewModel.Tasks,
                ItemTemplate = dataTemplate,
                ItemsSource = tasksViewModel.Tasks
            };

            listView.ItemTapped += ListView_OnItemTapped;

            getToolbarItem.Clicked += async (sender, args) =>
            {
                await tasksViewModel.DownloadDataAsync();
                listView.ItemsSource = tasksViewModel.Tasks;
            };

            Content = listView;
        }

        private async void ListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {

            var tasksViewModel = BindingContext as TasksViewModel;

            if (tasksViewModel != null)
            {
                tasksViewModel.SelectedTask = e.Item as TaskModel;

                await Navigation.PushAsync(new TaskDetailsPageView(tasksViewModel));
            }
        }
    }

    public class TaskViewCell : ViewCell
    {

        public TaskViewCell()
        {

            var titleLabel = new Label
            {
                FontSize = 20,
                TextColor = Color.Navy,
            };
            titleLabel.SetBinding(Label.TextProperty, "Title");

            var contentLabel = new Label
            {
                FontSize = 20,
                TextColor = Color.Black,
            };
            contentLabel.SetBinding(Label.TextProperty, "Content");

            var createdAtLabel = new Label
            {
                FontSize = 14,
                TextColor = Color.Gray,
            };
            createdAtLabel.SetBinding(Label.TextProperty, "CreatedAt");

            var stackLayout = new StackLayout
            {
                Padding = new Thickness(10, 5),
                Children =
                {
                    titleLabel,
                    contentLabel,
                    createdAtLabel,
                }
            };

            View = stackLayout;
        }
    }
}

///////////////////////////////////////////////////////////
//
//       The XAML equivalent of the above code is : TasksPage.xaml
//
//<? xml version="1.0" encoding="utf-8" ?>
//<ContentPage xmlns = "http://xamarin.com/schemas/2014/forms"
//             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
//             xmlns:viewModels="clr-namespace:RestClient.ViewModels;assembly=RestClient"
//             x:Class="RestClient.Views.TasksPage"
//             BackgroundColor="White"
//             Title="Home">

//  <ContentPage.BindingContext>
//    <viewModels:TasksViewModel />
//  </ContentPage.BindingContext>

//  <ContentPage.ToolbarItems>
//    <ToolbarItem Text = "GET"
//                 Icon="refresh.png"
//                 Command="{Binding GetCommand}"
//                 Order="Primary"
//                 Priority="0" />
//  </ContentPage.ToolbarItems>

//  <ListView ItemsSource = "{Binding Tasks}"
//            HasUnevenRows="True"
//            ItemTapped="ListView_OnItemTapped"
//            IsPullToRefreshEnabled="True"
//            IsRefreshing="{Binding IsBusy}"
//            RefreshCommand="{Binding GetCommand}"
//            SeparatorVisibility="Default"
//            SeparatorColor="Gray">
//    <ListView.ItemTemplate>
//      <DataTemplate>
//        <ViewCell>
//          <StackLayout Orientation = "Vertical"
//                       Padding="10,5">
//            <Label Text = "{Binding Title}"
//                   Font="Bold"
//                   FontSize="20"
//                   TextColor="Navy"/>
//            <Label Text = "{Binding Content}"
//                   TextColor="Black"
//                   FontSize="20"/>
//            <Label Text = "{Binding CreatedAt}"
//                   TextColor="Gray"
//                   FontSize="14"/>
//          </StackLayout>
//        </ViewCell>
//      </DataTemplate>
//    </ListView.ItemTemplate>
//  </ListView>
//</ContentPage>
//
////////////////////////////////////////////////////////////////////
//
//    The code behind : TasksPage.xaml.cs
//
//using RestClient.Models;
//using RestClient.ViewModels;
//using Xamarin.Forms;

//namespace RestClient.Views
//{
//    public partial class TasksPage : ContentPage
//    {
//        public TasksPage()
//        {
//            InitializeComponent();
//        }

//        private async void ListView_OnItemTapped(object sender, ItemTappedEventArgs e)
//        {

//            TasksViewModel tasksViewModel = BindingContext as TasksViewModel;
//            tasksViewModel.SelectedTask = e.Item as TaskModel;

//            await Navigation.PushAsync(new TaskDetailsPage(tasksViewModel));
//        }
//    }
//}

