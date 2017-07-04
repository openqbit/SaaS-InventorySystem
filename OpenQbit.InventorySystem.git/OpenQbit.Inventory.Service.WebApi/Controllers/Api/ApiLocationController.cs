using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using OpenQbit.Inventory.Service.WebApi.Models.Api;
using OpenQbit.Inventory.BLL.BusinessService.Contr;
using OpenQbit.Inventory.BLL.BusinessService;
using OpenQbit.Inventory.Common.Ioc;
using OpenQbit.Inventory.Common.Models;

namespace OpenQbit.Inventory.Service.WebApi.Controllers.Api
{
    public class ApiLocationController: ApiController
    {
        ILocationManager locationManager = UnityResolver.Resolve<ILocationManager>();

        public ApiLocation Get(int ID)
        {
            Location location=locationManager.FindLocationbyID(ID);

            ApiLocation apiLocation = new ApiLocation
            {
                ID = location.ID,
                Name=location.Name,
                CustomerID=location.CustomerID
            };

            return apiLocation;
        }

        public List<ApiLocation> GetList()
        {
            List<Location> locationsList = locationManager.getAllLocation();

            List<ApiLocation> apiLocationList = new List<ApiLocation>();

            foreach (Location location in locationsList)
            {
                ApiLocation apiLocation = new ApiLocation
                {
                    ID = location.ID,
                    Name = location.Name,
                    CustomerID = location.CustomerID
                };

                apiLocationList.Add(apiLocation);
            }

            return apiLocationList;
        }

        public bool Create(ApiLocation apiLocation)
        {
            Location location = new Location
            {
                ID = apiLocation.ID,
                Name = apiLocation.Name,
                CustomerID = apiLocation.CustomerID
            };

            return locationManager.RecordLocation(location);
        }
        public bool Delete(ApiLocation apiLocation)
        {
            Location location = new Location
            {
                ID = apiLocation.ID,
                Name = apiLocation.Name,
                CustomerID = apiLocation.CustomerID
            };

            return locationManager.DeleteLocation(location);
        }
        public bool Update(ApiLocation apiLocation)
        {
            Location location = new Location
            {
                ID = apiLocation.ID,
                Name = apiLocation.Name,
                CustomerID = apiLocation.CustomerID
            };

            return locationManager.UpdateLocation(location);
        }
    }
}