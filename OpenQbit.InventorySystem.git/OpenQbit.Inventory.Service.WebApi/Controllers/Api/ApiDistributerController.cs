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
    public class ApiDistributerController : ApiController
    {
        IDistributerManager distributorManager = UnityResolver.Resolve<IDistributerManager>();

        public ApiDistributer Get(int ID)
        {
            Distributer distributer = distributorManager.FindDistributerByID(ID);

            ApiDistributer distributor = new ApiDistributer
            {
                ID = distributer.ID,
                Name = distributer.Name,
                Telephone = distributer.Telephone,
                CustomerID=distributer.CustomerID
            };

            return distributor;
        }

        public List<ApiDistributer> GetList()
        {
            List<Distributer> distributerList = distributorManager.GetAllDistributers();

            List<ApiDistributer> apiDistributorList = new List<ApiDistributer>();

            foreach (Distributer distributer in distributerList)
            {
                ApiDistributer distributor = new ApiDistributer
                {
                    ID = distributer.ID,
                    Name = distributer.Name,
                    Telephone = distributer.Telephone,
                    CustomerID = distributer.CustomerID
                };

                apiDistributorList.Add(distributor);
            }

            return apiDistributorList;
        }

        public bool Create(ApiDistributer apiDistributer)
        {
            Distributer distributer = new Distributer
            {
                ID = apiDistributer.ID,
                Name = apiDistributer.Name,
                Telephone = apiDistributer.Telephone,
                CustomerID = apiDistributer.CustomerID
            };
            return distributorManager.RecordDistributer(distributer);
        }

        public bool Delete(ApiDistributer apiDistributer)
        {
            Distributer distributer = new Distributer
            {
                ID = apiDistributer.ID,
                Name = apiDistributer.Name,
                Telephone = apiDistributer.Telephone,
                CustomerID = apiDistributer.CustomerID
            };

            return distributorManager.DeleteDistributer(distributer);
        }

        public bool Update(ApiDistributer apiDistributer)
        {
            Distributer distributer = new Distributer
            {
                ID = apiDistributer.ID,
                Name = apiDistributer.Name,
                Telephone = apiDistributer.Telephone,
                CustomerID = apiDistributer.CustomerID
            };

            return distributorManager.UpdateDistributer(distributer);

        }
    }
}