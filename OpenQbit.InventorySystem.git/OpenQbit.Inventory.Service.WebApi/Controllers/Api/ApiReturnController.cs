using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using OpenQbit.Inventory.Service.WebApi.Models.Api;

namespace OpenQbit.Inventory.Service.WebApi.Controllers.Api
{
    public class ApiReturnController:ApiController
    {
        public ApiReturn Get(int ID)
        {
            ApiReturn returns = new ApiReturn
            {
                ID = 1,
                Description = "Dates are expired",
                Qty = 2,
                BatchID = 1,
                SupplierID = 2
            };

            return returns;
        }

        public List<ApiReturn> GetList()
        {
            List<ApiReturn> returnList = new List<ApiReturn>();

            ApiReturn returns1 = new ApiReturn
            {
                ID = 1,
                Description = "Dates are expired",
                Qty = 3,
                BatchID = 1,
                SupplierID = 2
            };

            ApiReturn returns2 = new ApiReturn
            {
                ID = 2,
                Description = "Dates are expired",
                Qty = 2,
                BatchID = 3,
                SupplierID = 1
            };

            ApiReturn returns3 = new ApiReturn
            {
                ID = 3,
                Description = "Dates are expired",
                Qty = 5,
                BatchID = 2,
                SupplierID = 3
            };

            returnList.Add(returns1);
            returnList.Add(returns2);
            returnList.Add(returns3);

            return returnList;
        }
        public bool Create(ApiReturn apiReturn)
        {
            return true;
        }
        public bool Delete(int ID)
        {
            return true;
        }
        public bool Update(ApiReturn apiReturn)
        {
            return true;
        }
    }
}