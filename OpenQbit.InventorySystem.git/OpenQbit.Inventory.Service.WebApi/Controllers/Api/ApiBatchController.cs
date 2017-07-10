using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using OpenQbit.Inventory.Service.WebApi.Models.Api;
using OpenQbit.Inventory.BLL.BusinessService.Contr;
using OpenQbit.Inventory.Common.Ioc;
using OpenQbit.Inventory.Common.Models;

namespace OpenQbit.Inventory.Service.WebApi.Controllers.Api
{
    [Authorize]
    public class ApiBatchController : ApiController
    {
        
        public ApiBatch Get(int ID)
        {
            IBatchManager batchManager = UnityResolver.Resolve<IBatchManager>();
            Batch batchModel = batchManager.FindBatchByID(ID);

            string id = User.Identity.Name;
            ApiBatch batch = new ApiBatch
            {
                ID = batchModel.ID,
                Date = batchModel.Date,
                Qty = batchModel.Qty,
                UnitPrice = batchModel.UnitPrice,
                ItemID = batchModel.ItemID,
                SupplierID = batchModel.SupplierID
        };

            return batch;
        }

        public List<ApiBatch> GetList()
        {
            string id = User.Identity.Name;
            IBatchManager batchManager = UnityResolver.Resolve<IBatchManager>();
            List<Batch> batchModelList = batchManager.GetAllBatches();
            List<ApiBatch> batchList = new List<ApiBatch>();
            foreach (Batch batchModel in batchModelList)
            {
                ApiBatch batch = new ApiBatch
                {
                    ID = batchModel.ID,
                    Date = batchModel.Date,
                    Qty = batchModel.Qty,
                    UnitPrice = batchModel.UnitPrice,
                    ItemID = batchModel.ItemID,
                    SupplierID = batchModel.SupplierID
                };

                batchList.Add(batch);
            }

            return batchList;
        }

        public bool Create(ApiBatch apiBatch)
        {
            string id = User.Identity.Name;
            IBatchManager batchManager = UnityResolver.Resolve<IBatchManager>();
            Batch batch = new Batch
            {
                ID = apiBatch.ID,
                Date = apiBatch.Date,
                Qty = apiBatch.Qty,
                UnitPrice = apiBatch.UnitPrice,
                ItemID = apiBatch.ItemID,
                SupplierID = apiBatch.SupplierID,
                CustomerID = Convert.ToInt32(id)
            };

            return batchManager.RecoredBatch(batch);

        }

        public bool Delete(ApiBatch apiBatch)
        {
            string id = User.Identity.Name;
            IBatchManager batchManager = UnityResolver.Resolve<IBatchManager>();
            Batch batch = new Batch
            {
                ID = apiBatch.ID,
                Date = apiBatch.Date,
                Qty = apiBatch.Qty,
                UnitPrice = apiBatch.UnitPrice,
                ItemID = apiBatch.ItemID,
                SupplierID = apiBatch.SupplierID,
                CustomerID = Convert.ToInt32(id)
            };

            return batchManager.DeleteBatch(batch);
        }

        public  bool Update(ApiBatch apiBatch)
        {
            string id = User.Identity.Name;
            IBatchManager batchManager = UnityResolver.Resolve<IBatchManager>();
            Batch batch = new Batch
            {
                ID = apiBatch.ID,
                Date = apiBatch.Date,
                Qty = apiBatch.Qty,
                UnitPrice = apiBatch.UnitPrice,
                ItemID = apiBatch.ItemID,
                SupplierID = apiBatch.SupplierID,
                CustomerID = Convert.ToInt32(id)
            };

            return batchManager.UpdateBatch(batch);

        }
    }
}