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
    public class ApiReturnController:ApiController
    {
        public ApiReturn Get(int ID)
        {
            IReturnManager returnManager = UnityResolver.Resolve<IReturnManager>();
            Return returnModel = returnManager.FindReturnByID(ID);
            ApiReturn returns = new ApiReturn
            {
                ID = returnModel.ID,
                Description = returnModel.Description,
                Qty = returnModel.Qty,
                BatchID = returnModel.BatchID,
                SupplierID = returnModel.SupplierID,
                CustomerID = returnModel.CustomerID
            };

            return returns;
        }

        public List<ApiReturn> GetList()
        {
            IReturnManager returnManager = UnityResolver.Resolve<IReturnManager>();
            List<ApiReturn> returnList = new List<ApiReturn>();
            List<Return> returnModelList = new List<Return>();

            foreach(Return returnModel in returnModelList)
            {
                ApiReturn returns = new ApiReturn
                {
                    ID = returnModel.ID,
                    Description = returnModel.Description,
                    Qty = returnModel.Qty,
                    BatchID = returnModel.BatchID,
                    SupplierID = returnModel.SupplierID,
                    CustomerID = returnModel.CustomerID
                };
                returnList.Add(returns);
            }
            
            return returnList;
        }
        public bool Create(ApiReturn apiReturn)
        {
            IReturnManager returnManager = UnityResolver.Resolve<IReturnManager>();
            Return returns = new Return
            {
                ID = apiReturn.ID,
                Description = apiReturn.Description,
                Qty = apiReturn.Qty,
                BatchID = apiReturn.BatchID,
                SupplierID = apiReturn.SupplierID,
                CustomerID = apiReturn.CustomerID
            };
            return returnManager.RecoredReturn(returns);
        }
        public bool Delete(ApiReturn apiReturn)
        {
            IReturnManager returnManager = UnityResolver.Resolve<IReturnManager>();
            Return returns = new Return
            {
                ID = apiReturn.ID,
                Description = apiReturn.Description,
                Qty = apiReturn.Qty,
                BatchID = apiReturn.BatchID,
                SupplierID = apiReturn.SupplierID,
                CustomerID = apiReturn.CustomerID
            };
            return returnManager.DeleteReturn(returns);
        }
        public bool Update(ApiReturn apiReturn)
        {
            IReturnManager returnManager = UnityResolver.Resolve<IReturnManager>();
            Return returns = new Return
            {
                ID = apiReturn.ID,
                Description = apiReturn.Description,
                Qty = apiReturn.Qty,
                BatchID = apiReturn.BatchID,
                SupplierID = apiReturn.SupplierID,
                CustomerID = apiReturn.CustomerID
            };
            return returnManager.UpdateReturn(returns);
        }
    }
}