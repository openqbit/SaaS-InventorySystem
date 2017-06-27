using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using OpenQbit.Inventory.Service.WebApi.Models.Api;

namespace OpenQbit.Inventory.Service.WebApi.Controllers.Api
{
    public class ApiBatchController : ApiController
    {
        public ApiBatch Get(int ID)
        {       
            ApiBatch batch = new ApiBatch
            {
                ID = 1,
                Date = DateTime.Today,
                Qty = 20,
                UnitPrice = 120.00,
                ItemID = 1,
                SupplierID = 1
            };
            return batch;
        }

        public List<ApiBatch> GetList()
        {
            List<ApiBatch> batchList = new List<ApiBatch>();

            ApiBatch batch1 = new ApiBatch
            {
                ID = 1,
                Date = DateTime.Today,
                Qty = 20,
                UnitPrice = 120.00,
                ItemID = 1,
                SupplierID = 1
            };

            ApiBatch batch2 = new ApiBatch
            {
                ID = 2,
                Date = DateTime.Today,
                Qty = 30,
                UnitPrice = 100.00,
                ItemID = 2,
                SupplierID = 1
            };

            ApiBatch batch3 = new ApiBatch
            {
                ID = 3,
                Date = DateTime.Today,
                Qty = 3,
                UnitPrice = 100.00,
                ItemID = 3,
                SupplierID = 3
            };

            batchList.Add(batch1);
            batchList.Add(batch2);
            batchList.Add(batch3);

            return batchList;
        }

        public bool Create(ApiBatch apiBatch)
        {
            return true;
        }

        public bool Delete(int ID)
        {
            return true;
        }

        public  bool Update(ApiBatch apiBatch)
        {
            return true;

        }
    }
}