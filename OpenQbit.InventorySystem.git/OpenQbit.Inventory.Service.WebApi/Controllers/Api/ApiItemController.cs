using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using OpenQbit.Inventory.Service.WebApi.Models.Api;

namespace OpenQbit.Inventory.Service.WebApi.Controllers.Api
{
    public class ApiItemController:ApiController
    {
        public ApiItem Get(int ID)
        {
            ApiItem item = new ApiItem
            {
                ID = 1,
                Name = "Dhal",
                Active = true,
                reOrder=10
            };
            return item;  
        }

        public List<ApiItem> GetList()
        {
            List<ApiItem> itemList = new List<ApiItem>();

            ApiItem item1 = new ApiItem
            {
                ID = 1,
                Name = "Dhal",
                Active = true,
                reOrder = 10
            };

            ApiItem item2 = new ApiItem
            {
                ID = 2,
                Name = "Rice",
                Active = true,
                reOrder = 25
            };

            ApiItem item3 = new ApiItem
            {
                ID = 3,
                Name = "Soap",
                Active = true,
                reOrder = 10
            };

            itemList.Add(item1);
            itemList.Add(item2);
            itemList.Add(item3);

            return itemList;
        }
    }
}