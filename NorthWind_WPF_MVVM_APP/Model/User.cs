using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind_WPF_MVVM_APP.Model
{
    public class User:IDataErrorInfo
    {
        private int _userID;

        public int UserID
        {
            get { return _userID; }
            set { _userID = value; }
        }

        private string _userName;

        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        private string _password;

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        private string _role;

        public string Role
        {
            get { return _role; }
            set { _role = value; }
        }

        public string Error
        {
            get
            {
                return null;
            }
        }

        public string this[string PropertyName]
        {
            get
            {
                string result = string.Empty;
                switch (PropertyName)
                {
                    case "UserName":
                        if (string.IsNullOrEmpty(UserName))
                            result = "User name should not be empty";
                        break;
                    case "Password":
                        if (string.IsNullOrEmpty(Password))
                            result = "Please enter password.";
                        break;
                }
                return result;
            }
        }
    }
}
