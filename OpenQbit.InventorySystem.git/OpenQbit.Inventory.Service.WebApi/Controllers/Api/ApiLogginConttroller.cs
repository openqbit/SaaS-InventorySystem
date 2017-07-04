using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using OpenQbit.Inventory.Service.WebApi.Models.Api;
using OpenQbit.Inventory.BLL.BusinessService.Contr;
using OpenQbit.Inventory.Common.Ioc;
using OpenQbit.Inventory.Common.Models;
using System.Security.Claims;
using Microsoft.Owin.Security;
using Microsoft.Owin;
using System.Net.Http;

namespace OpenQbit.Inventory.Service.WebApi.Controllers.Api
{
    public class ApiLogginConttroller : ApiController
    {
        public bool SearchCustomerByUserName(string userName, string password)
        {
            ApiCustomerController controller = new ApiCustomerController();
            ApiCustomer customer= controller.SearchCustomerByUserName(userName, password);
            if (customer != null)
            {
                    ClaimsIdentity identity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, customer.UserName),
                    new Claim(ClaimTypes.Sid, customer.ID.ToString())
                },
                "ApplicationCookie");

                IOwinContext ctx = Request.GetOwinContext();
                IAuthenticationManager authManager = ctx.Authentication;

                AuthenticationProperties authenticationproperties = new
                            AuthenticationProperties
                { IsPersistent = false };

                authManager.SignIn(authenticationproperties, identity);

                return true;

            }

            return false;
        }

        public bool Logoff()
        {
            IOwinContext ctx = Request.GetOwinContext();
            IAuthenticationManager authManager = ctx.Authentication;
            authManager.SignOut("ApplicationCookie");

            return true;
        }

    }
}