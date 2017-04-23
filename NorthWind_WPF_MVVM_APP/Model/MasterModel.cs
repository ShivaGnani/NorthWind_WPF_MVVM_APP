using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NorthWind_WPF_MVVM_APP.Model
{
    public class MasterModel
    {
        public LoginService.LoginServiceClient loginSvc = null;
        public ProductsService.ProductsServiceClient productSvc = null;
        public User validateUser(User user)
        {

            loginSvc = new LoginService.LoginServiceClient();
            LoginService.User objSvcUser = loginSvc.Login(user.UserName, user.Password);
            if (objSvcUser == null)
                return null;
            else
                return new User() {
                    UserID = objSvcUser.UserID,
                    UserName = objSvcUser.UserName,
                    Password = objSvcUser.Password,
                    Role = objSvcUser.Role
                };

        }
      public ObservableCollection<Product> getAllProducts()
        {
            productSvc = new ProductsService.ProductsServiceClient();
            ObservableCollection<Product> products = new ObservableCollection<Product>();
            var dbProducts = productSvc.GetAllProducts();
            foreach (var product in dbProducts)
            {
                products.Add(new Product
                {
                    ProductID = product.ProductID,
                    ProductName = product.ProductName,
                    CategoryID = product.CategoryID,
                    QuantityPerUnit = product.QuantityPerUnit,
                    UnitPrice = product.UnitPrice,
                    UnitsInStock = product.UnitsInStock,
                    Discontinued = product.Discontinued
                });
            }
            return products;
        }
    }
}
