using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NorthWind_WPF_MVVM_APP.Model;

namespace NorthWind_WPF_MVVM_APP.ViewModel
{
    public class HomeViewModel : ViewModelBase
    {
        private string _userName;

        public string UserName
        {
            get { return _userName; }
            set
            {
                if (_userName != value)
                {
                    _userName = value;
                    RaisePropertyChanged("UserName");
                }
            }
        }
        private ObservableCollection<Product> _products;

        public ObservableCollection<Product> Products
        {
            get { return _products; }
            set { _products = value; }
        }

        MasterModel model;
        public HomeViewModel(string UserName)
        {
            this.UserName = UserName;
            model = new MasterModel();
            Products = model.getAllProducts();
        }

    }
}
