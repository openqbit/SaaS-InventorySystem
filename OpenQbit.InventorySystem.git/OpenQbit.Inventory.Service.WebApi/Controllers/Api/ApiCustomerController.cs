using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using OpenQbit.Inventory.Service.WebApi.Models.Api;
using OpenQbit.Inventory.BLL.BusinessService.Contr;
using OpenQbit.Inventory.Common.Ioc;
using OpenQbit.Inventory.Common.Models;

namespace OpenQbit.Inventory.Service.WebApi.Controllers.Api
{
    public class ApiCustomerController : ApiController
    {
        public ApiCustomer SearchCustomerByUserName(string userName, string password)
        {
            ICustomerManager customerManager = UnityResolver.Resolve<ICustomerManager>();
            Customer customer=customerManager.SearchCustomerByUserName(userName, password);
            ApiCustomer cust = null;
            if (customer != null)
            {
                cust = new ApiCustomer
                {
                    ID = customer.ID,
                    Name = customer.Name,
                    Password = customer.Password,
                    UserName = customer.UserName
                };
                
            }

            return cust;

        }
    }
}