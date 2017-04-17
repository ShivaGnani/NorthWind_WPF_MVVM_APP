using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NorthWind_WPF_MVVM_APP.Model
{
    public class MasterModel
    {
        public LoginService.LoginServiceClient svc = null;
        public string validateUser(User user)
        {
            string result = string.Empty;
            svc = new LoginService.LoginServiceClient();
            result = svc.Login(user.UserName, user.Password);
            if (string.IsNullOrEmpty(result))
                return "User doesn't exist.";
            return result;
        }
    }
}
