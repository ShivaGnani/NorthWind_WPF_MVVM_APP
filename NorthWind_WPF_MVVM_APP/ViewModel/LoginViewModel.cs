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
            LoginCommand = new RelayCommand(validateUser);
        }
        protected void validateUser(object param)
        {
            Message = model.validateUser(User);
        }
    }
}
