using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using OpenQbit.Inventory.Service.WebApi.Models.Api;

namespace OpenQbit.Inventory.Service.WebApi.Controllers.Api
{
    public class ApiTransferDetailController : ApiController
    {
        public ApiTransferDetail Get(int ID)
        {
            ApiTransferDetail transferDetail = new ApiTransferDetail
            {
                ID = 1,
                BatchID = 1,
                LocationID = 1,
                DistributerID = 1
            };

            return transferDetail;
        }

        public List<ApiTransferDetail> GetList()
        {
            List<ApiTransferDetail> transferDetailsList = new List<ApiTransferDetail>();

            ApiTransferDetail transferDetail1 = new ApiTransferDetail
            {
                ID = 1,
                BatchID = 1,
                LocationID = 1,
                DistributerID = 1
            };

            ApiTransferDetail transferDetail2 = new ApiTransferDetail
            {
                ID = 2,
                BatchID = 2,
                LocationID = 2,
                DistributerID = 2
            };

            ApiTransferDetail transferDetail3 = new ApiTransferDetail
            {
                ID = 2,
                BatchID = 3,
                LocationID = 3,
                DistributerID = 3
            };

            transferDetailsList.Add(transferDetail1);
            transferDetailsList.Add(transferDetail2);
            transferDetailsList.Add(transferDetail3);

            return transferDetailsList;
        }

        public bool Create(ApiTransferDetail apiTransferDetail)
        {
            return true;
        }
        public bool Delete(int ID)
        {
            return true;
        }
        public bool Update(ApiTransferDetail apiTransferDetail)
        {
            return true;
        }
    }
}