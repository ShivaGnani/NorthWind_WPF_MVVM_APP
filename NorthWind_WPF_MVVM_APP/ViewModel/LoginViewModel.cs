using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NorthWind_WPF_MVVM_APP.Model;
using NorthWind_WPF_MVVM_APP.Helpers;
using System.Windows.Input;
using System.Windows;

namespace NorthWind_WPF_MVVM_APP.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        private User _user;

        public User User
        {
            get { return _user; }
            set
            {
                _user = value;
                RaisePropertyChanged("User");
            }
        }

        private string _Message;

        public string Message
        {
            get { return _Message; }
            set
            {
                if (_Message != value)
                {
                    _Message = value;
                    RaisePropertyChanged("Message");
                }
            }
        }
        public ICommand LoginCommand { get; set; }
        MasterModel model;
        public LoginViewModel()
        {
            model = new MasterModel();
            User = new User();
            LoginCommand = new RelayCommand(validateUser, canValidateUser);
        }
        protected void validateUser(object param)
        {
            User user = model.validateUser(User);
            if (user == null)
                Message = "User doesn't exist.";
            MainViewModel.Instance.SelectedViewModel = new HomeViewModel(user.UserName);
        }

        protected bool canValidateUser(object param)
        {
            if (string.IsNullOrEmpty(User.UserName) || string.IsNullOrEmpty(User.Password))
                return false;
            return true;
        }
    }
}
