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
    public class ApiTransferDetailController : ApiController
    {
        ITransferDetailManager transferDetailManager = UnityResolver.Resolve<ITransferDetailManager>();

        public ApiTransferDetail Get(int ID)
        {
            TransferDetail transferDetail = transferDetailManager.FindTransferDetail(ID);

            ApiTransferDetail apiTransferDetail = new ApiTransferDetail
            {
                ID = transferDetail.ID,
                BatchID = transferDetail.BatchID,
                LocationID = transferDetail.LocationID,
                DistributerID = transferDetail.DistributerID,
                CustomerID= transferDetail.CustomerID
            };

            return apiTransferDetail;
        }

        public List<ApiTransferDetail> GetList()
        {
            List<TransferDetail> transferDetailsList = transferDetailManager.getAllTransferDetail();

            List<ApiTransferDetail> apiTransferDetailsList = new List<ApiTransferDetail>();

            foreach (TransferDetail transferDetail in transferDetailsList)
            {
                ApiTransferDetail apiTransferDetail = new ApiTransferDetail
                {
                    ID = transferDetail.ID,
                    BatchID = transferDetail.BatchID,
                    LocationID = transferDetail.LocationID,
                    DistributerID = transferDetail.DistributerID,
                    CustomerID = transferDetail.CustomerID
                };

                apiTransferDetailsList.Add(apiTransferDetail);
            }
            
            return apiTransferDetailsList;
        }

        public bool Create(ApiTransferDetail apiTransferDetail)
        {
            TransferDetail transferDetail = new TransferDetail
            {
                ID = apiTransferDetail.ID,
                BatchID = apiTransferDetail.BatchID,
                LocationID = apiTransferDetail.LocationID,
                DistributerID = apiTransferDetail.DistributerID,
                CustomerID = apiTransferDetail.CustomerID
            };

            return transferDetailManager.RecoredTransferDetail(transferDetail);
        }
        public bool Delete(ApiTransferDetail apiTransferDetail)
        {
            TransferDetail transferDetail = new TransferDetail
            {
                ID = apiTransferDetail.ID,
                BatchID = apiTransferDetail.BatchID,
                LocationID = apiTransferDetail.LocationID,
                DistributerID = apiTransferDetail.DistributerID,
                CustomerID = apiTransferDetail.CustomerID
            };

            return transferDetailManager.DeleteTransferDetail(transferDetail);
        }
        public bool Update(ApiTransferDetail apiTransferDetail)
        {
            TransferDetail transferDetail = new TransferDetail
            {
                ID = apiTransferDetail.ID,
                BatchID = apiTransferDetail.BatchID,
                LocationID = apiTransferDetail.LocationID,
                DistributerID = apiTransferDetail.DistributerID,
                CustomerID = apiTransferDetail.CustomerID
            };

            return transferDetailManager.UpdateTransferDetail(transferDetail);
        }
    }
}