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
    //[Authorize]
    public class ApiLocationController: ApiController
    {
        ILocationManager locationManager = UnityResolver.Resolve<ILocationManager>();

        public ApiLocation Get(int ID)
        {
            Location location=locationManager.FindLocationbyID(ID);

            ApiLocation apiLocation = new ApiLocation
            {
                ID = location.ID,
                Name=location.Name
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
                    Name = location.Name
                };

                apiLocationList.Add(apiLocation);
            }

            return apiLocationList;
        }

        public bool Create(ApiLocation apiLocation)
        {
            //string id = User.Identity.Name;
            Location location = new Location
            {
                ID = apiLocation.ID,
                Name = apiLocation.Name,
                CustomerID = Helper.getCustID()
            };

            return locationManager.RecordLocation(location);
        }
        public bool Delete(ApiLocation apiLocation)
        {
            //string id = User.Identity.Name;
            Location location = new Location
            {
                ID = apiLocation.ID,
                Name = apiLocation.Name,
                CustomerID = Helper.getCustID()
            };

            return locationManager.DeleteLocation(location);
        }
        public bool Update(ApiLocation apiLocation)
        {
            //string id = User.Identity.Name;
            Location location = new Location
            {
                ID = apiLocation.ID,
                Name = apiLocation.Name,
                CustomerID = Helper.getCustID()
            };

            return locationManager.UpdateLocation(location);
        }
    }
}