using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using RestClient.Client;
using RestClient.Models;
using Xamarin.Forms;

namespace RestClient.ViewModels
{
    public class TasksViewModel : INotifyPropertyChanged
    {

        private List<TaskModel> _tasks;
        private TaskModel _selectedTask;
        private GenericRestClient<TaskModel> _genericRestClient;
        private bool _isBusy = false;

        public List<TaskModel> Tasks
        {
            get { return _tasks; }
            set
            {
                _tasks = value;
                OnPropertyChanged();
            }
        }

        public TaskModel SelectedTask
        {
            get { return _selectedTask; }
            set
            {
                _selectedTask = value;
                OnPropertyChanged();
            }
        }

        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                OnPropertyChanged();
            }
        }

        public ICommand GetCommand
        {
            get
            {
                return new Command(async () =>
                {
                    IsBusy = true;

                    await DownloadDataAsync();

                    IsBusy = false;
                });
            }
        }

        public ICommand PostCommand
        {
            get
            {
                return new Command(async () =>
                {
                    IsBusy = true;

                    await _genericRestClient.PostAsync(_selectedTask);

                    IsBusy = false;

                    MessagingCenter.Send(this, "message", "POST executed successfully!");
                });
            }
        }

        public ICommand PutCommand
        {
            get
            {
                return new Command(async () =>
                {
                    IsBusy = true;

                    await _genericRestClient.PutAsync(_selectedTask.Id, _selectedTask);
                    
                    IsBusy = false;

                    MessagingCenter.Send(this, "message", "POST executed successfully!");
                });
            }
        }

        public ICommand DeleteCommand
        {
            get
            {
                return new Command(async () =>
                {
                    IsBusy = true;

                    await _genericRestClient.DeleteAsync(_selectedTask.Id, _selectedTask);

                    IsBusy = false;

                    MessagingCenter.Send(this, "message", "POST executed successfully!");
                });
            }
        }

        public TasksViewModel()
        {

            _genericRestClient = new GenericRestClient<TaskModel>();

            DownloadDataAsync();
        }

        public async Task DownloadDataAsync()
        {

            Tasks = await _genericRestClient.GetAsync();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
