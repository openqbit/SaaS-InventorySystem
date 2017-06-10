using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using OpenQbit.Inventory.Service.WebApi.Models.Api;

namespace OpenQbit.Inventory.Service.WebApi.Controllers.Api
{
    public class ApiLocationController: ApiController
    {
        public ApiLocation Get(int ID)
        {
            ApiLocation location = new ApiLocation
            {
                ID=1,
                Name="Branch"
            };

            return location;
        }

        public List<ApiLocation> GetList()
        {
            List<ApiLocation> locationList = new List<ApiLocation>();

            ApiLocation location1 = new ApiLocation
            {
                ID = 1,
                Name = "Branch"
            };

            ApiLocation location2 = new ApiLocation
            {
                ID = 2,
                Name = "Head Quatest"
            };

            ApiLocation location3 = new ApiLocation
            {
                ID = 3,
                Name = "Ware House"
            };

            locationList.Add(location1);
            locationList.Add(location2);
            locationList.Add(location3);

            return locationList;
        }
        public bool Create(ApiLocation apiLocation)
        {
            return true;
        }
        public bool Delete(int ID)
        {
            return true;
        }
        public bool Update(ApiLocation apiLocation)
        {
            return true;
        }
    }
}