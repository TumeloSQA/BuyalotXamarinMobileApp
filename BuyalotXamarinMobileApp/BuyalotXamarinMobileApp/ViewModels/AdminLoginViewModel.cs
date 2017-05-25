using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using BuyalotXamarinMobileApp.Models;
using BuyalotXamarinMobileApp.Data;

namespace BuyalotXamarinMobileApp.ViewModels
{
    public class AdminLoginViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        #endregion

        public Action DisplayInvalidLoginPrompt;
        public Action DisplayValidLoginPrompt;

        private string emailAddress;
        public string EmailAddress
        {
            get { return emailAddress; }
            set
            {
                emailAddress = value;
                PropertyChanged(this, new PropertyChangedEventArgs("EmailAddress"));
            }

        }

        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Password"));
            }
        }

        public ICommand SubmitCommand { protected set; get; }

        public AdminLoginViewModel()
        {
            SubmitCommand = new Command(OnSubmit);
        }
        public Admins admin;
        public AdminDb adminDb;
        public void OnSubmit()
        {
            admin = new Admins();
            adminDb = new AdminDb();
            //if (emailAddress != "Tumelophuti@gmail.com" || password != "123456")
            if (emailAddress != admin.Email && password != admin.Password)
                DisplayInvalidLoginPrompt();
            else DisplayValidLoginPrompt();
        }
    }
}
