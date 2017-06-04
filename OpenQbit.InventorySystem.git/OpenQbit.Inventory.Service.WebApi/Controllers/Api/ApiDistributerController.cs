using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using OpenQbit.Inventory.Service.WebApi.Models.Api;

namespace OpenQbit.Inventory.Service.WebApi.Controllers.Api
{
    public class ApiDistributerController : ApiController
    {
        public ApiDistributer Get(int ID)
        {
            ApiDistributer distributor = new ApiDistributer
            {
                ID = 1,
                Name = "Lasantha",
                Telephone = "0712345678"
            };

            return distributor;
        }

        public List<ApiDistributer> GetList()
        {
            List<ApiDistributer> distributorList = new List<ApiDistributer>();

            ApiDistributer distributor1 = new ApiDistributer
            {
                ID = 1,
                Name = "Lasantha",
                Telephone = "0712345678"
            };

            ApiDistributer distributor2 = new ApiDistributer
            {
                ID = 2,
                Name = "Nilantha",
                Telephone = "0712365478"
            };

            ApiDistributer distributor3 = new ApiDistributer
            {
                ID = 2,
                Name = "Susantha",
                Telephone = "0712368956"
            };

            distributorList.Add(distributor1);
            distributorList.Add(distributor2);
            distributorList.Add(distributor3);

            return distributorList;
        }
    }
}