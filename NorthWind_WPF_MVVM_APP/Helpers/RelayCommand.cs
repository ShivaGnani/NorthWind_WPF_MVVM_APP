using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace NorthWind_WPF_MVVM_APP.Helpers
{
    class RelayCommand : ICommand
    {
        private Action<object> _executeMethod;
        private Func<object, bool> _canExecuteMethod;

        public RelayCommand(Action<object> executeMethod) : this(executeMethod, null)
        {

        }
        public RelayCommand(Action<object> executeMethod, Func<object, bool> canExecuteMethod)
        {
            if (executeMethod == null)
                throw new ArgumentNullException("executeMethod not provided");
            _executeMethod = executeMethod;
            _canExecuteMethod = canExecuteMethod;
        }
        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }

            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        public bool CanExecute(object parameter)
        {
            return _canExecuteMethod == null ? true : _canExecuteMethod(parameter);
        }

        public void Execute(object parameter)
        {
            _executeMethod(parameter);
        }
    }
}
