using RestClient.ViewModels;
using Xamarin.Forms;

namespace RestClient.Views
{
    public class TaskDetailsPageView : ContentPage
    {

        public TaskDetailsPageView(TasksViewModel tasksViewModel)
        {

            MessagingCenter.Subscribe<TasksViewModel, string>(this, "message", OnMessageReceived);

            BindingContext = tasksViewModel;

            Title = "Details";

            var postToolbarItem = new ToolbarItem
            {
                Text = "POST",
                Icon = "add.png",
                Order = ToolbarItemOrder.Primary,
                Command = tasksViewModel.PostCommand,
            };
            var deleteToolbarItem = new ToolbarItem
            {
                Text = "DELETE",
                Icon = "delete.png",
                Order = ToolbarItemOrder.Primary,
                Command = tasksViewModel.DeleteCommand,
            };
            var putToolbarItem = new ToolbarItem
            {
                Text = "PUT",
                Icon = "edit.png",
                Order = ToolbarItemOrder.Primary,
                Command = tasksViewModel.PutCommand,
            };

            ToolbarItems.Add(deleteToolbarItem);
            ToolbarItems.Add(putToolbarItem);
            ToolbarItems.Add(postToolbarItem);

            var titleLabel = new Label
            {
                Text = "Title",
                FontSize = 16
            };
            var titleEntry = new Entry();
            titleEntry.SetBinding(Entry.TextProperty, "SelectedTask.Title");

            var contentLabel = new Label
            {
                Text = "Content",
                FontSize = 16
            };
            var contentEntry = new Entry();
            contentEntry.SetBinding(Entry.TextProperty, "SelectedTask.Content");

            var createdAtLabel = new Label
            {
                Text = "Created At",
                FontSize = 16
            };
            var createdAtDatePicker = new DatePicker();
            createdAtDatePicker.SetBinding(
                DatePicker.DateProperty,
                "SelectedTask.CreatedAt",
                BindingMode.TwoWay);

            var activityIndicator = new ActivityIndicator
            {
                Color = Color.Navy,
                HeightRequest = 50,
            };
            activityIndicator.SetBinding(IsVisibleProperty, "IsBusy");
            activityIndicator.SetBinding(ActivityIndicator.IsRunningProperty, "IsBusy");

            var stackLayout = new StackLayout
            {
                Children =
                {
                    titleLabel,
                    titleEntry,
                    contentLabel,
                    contentEntry,
                    createdAtLabel,
                    createdAtDatePicker,
                    activityIndicator
                }
            };

            Content = stackLayout;
        }

        /// <summary>
        /// Will be invoked each time a message is sent 
        /// using the MessagingCenter from within the TasksViewModel.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="message"></param>
        private void OnMessageReceived(TasksViewModel sender, string message)
        {

            DisplayAlert("Notification", message, "Ok");
        }
    }
}
////////////////////////////////////////////////////////////////////
//    
//      The XAML equivalent of the above code is : TaskDetailsPage.xaml
//
//<? xml version="1.0" encoding="utf-8" ?>
//<ContentPage xmlns = "http://xamarin.com/schemas/2014/forms"
//             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
//             x:Class="RestClient.Views.TaskDetailsPage"
//             Title="Details">

//  <ContentPage.ToolbarItems>
//    <ToolbarItem Text = "POST"
//                 Icon="add.png"
//                 Command="{Binding PostCommand}"
//                 Order="Primary"
//                 Priority="0" />
//    <ToolbarItem Text = "PUT"
//                 Icon="edit.png"
//                 Command="{Binding PutCommand}"
//                 Order="Primary"
//                 Priority="0" />
//    <ToolbarItem Text = "DELETE"
//                 Icon="delete.png"
//                 Command="{Binding DeleteCommand}"
//                 Order="Primary"
//                 Priority="0" />
//  </ContentPage.ToolbarItems>

//  <StackLayout Orientation = "Vertical"
//               Padding="10,5">
//    <Label Text = "Title"
//           FontSize="16"/>
//    <Entry Text = "{Binding SelectedTask.Title}" />
//    < Label Text="Content"
//           FontSize="16"/>
//    <Entry Text = "{Binding SelectedTask.Content}" />
//    < Label Text="CreatedAt"
//           FontSize="16"/>
//    <DatePicker Date = "{Binding SelectedTask.CreatedAt, Mode=TwoWay}" />

//    < ActivityIndicator IsVisible="{Binding IsBusy}"
//                       Color="Navy"
//                       IsRunning="{Binding IsBusy}"
//                       HeightRequest="50"/>
//  </StackLayout>

//</ContentPage>

////////////////////////////////////////////////////////////////////
//
//    The code behind : TaskDetailsPage.xaml.cs
//
//using RestClient.ViewModels;
//using Xamarin.Forms;

//namespace RestClient.Views
//{
//    public partial class TaskDetailsPage : ContentPage
//    {
//        public TaskDetailsPage(TasksViewModel tasksViewModel)
//        {
//            InitializeComponent();

//            MessagingCenter.Subscribe<TasksViewModel, string>(this, "message", OnMessageReceived);

//            BindingContext = tasksViewModel;
//        }

//        /// <summary>
//        /// Will be invoked each time a message is sent 
//        /// using the MessagingCenter from within the TasksViewModel.
//        /// </summary>
//        /// <param name="sender"></param>
//        /// <param name="message"></param>
//        private void OnMessageReceived(TasksViewModel sender, string message)
//        {

//            DisplayAlert("Notification", message, "Ok");
//        }
//    }
//}
