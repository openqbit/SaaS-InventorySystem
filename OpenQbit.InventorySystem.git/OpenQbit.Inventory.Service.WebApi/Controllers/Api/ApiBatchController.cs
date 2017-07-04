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

            ApiBatch batch = new ApiBatch
            {
                ID = batchModel.ID,
                Date = batchModel.Date,
                Qty = batchModel.Qty,
                UnitPrice = batchModel.UnitPrice,
                ItemID = batchModel.ItemID,
                SupplierID = batchModel.SupplierID,
                CustomerID = batchModel.CustomerID
            };

            return batch;
        }

        public List<ApiBatch> GetList()
        {
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
                    SupplierID = batchModel.SupplierID,
                    CustomerID = batchModel.CustomerID
                };

                batchList.Add(batch);
            }

            return batchList;
        }

        public bool Create(ApiBatch apiBatch)
        {
            IBatchManager batchManager = UnityResolver.Resolve<IBatchManager>();
            Batch batch = new Batch
            {
                ID = apiBatch.ID,
                Date = apiBatch.Date,
                Qty = apiBatch.Qty,
                UnitPrice = apiBatch.UnitPrice,
                ItemID = apiBatch.ItemID,
                SupplierID = apiBatch.SupplierID,
                CustomerID = apiBatch.CustomerID
            };

            return batchManager.RecoredBatch(batch);

        }

        public bool Delete(ApiBatch apiBatch)
        {
            IBatchManager batchManager = UnityResolver.Resolve<IBatchManager>();
            Batch batch = new Batch
            {
                ID = apiBatch.ID,
                Date = apiBatch.Date,
                Qty = apiBatch.Qty,
                UnitPrice = apiBatch.UnitPrice,
                ItemID = apiBatch.ItemID,
                SupplierID = apiBatch.SupplierID,
                CustomerID = apiBatch.CustomerID
            };

            return batchManager.DeleteBatch(batch);
        }

        public  bool Update(ApiBatch apiBatch)
        {
            IBatchManager batchManager = UnityResolver.Resolve<IBatchManager>();
            Batch batch = new Batch
            {
                ID = apiBatch.ID,
                Date = apiBatch.Date,
                Qty = apiBatch.Qty,
                UnitPrice = apiBatch.UnitPrice,
                ItemID = apiBatch.ItemID,
                SupplierID = apiBatch.SupplierID,
                CustomerID = apiBatch.CustomerID
            };

            return batchManager.UpdateBatch(batch);

        }
    }
}