using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind_WPF_MVVM_APP.ViewModel
{
    public class MainViewModel:ViewModelBase
    {
        private object _selectedViewModel;

        public object SelectedViewModel
        {
            get { return _selectedViewModel; }
            set { _selectedViewModel = value;
                RaisePropertyChanged("SelectedViewModel");
            }
        }

        public static MainViewModel Instance { get;  set; }
        public MainViewModel()
        {
            Instance = this;
            SelectedViewModel = new LoginViewModel();
        }

    }
}
