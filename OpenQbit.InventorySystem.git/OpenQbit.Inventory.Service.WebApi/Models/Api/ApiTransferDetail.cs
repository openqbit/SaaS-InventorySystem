using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpenQbit.Inventory.Service.WebApi.Models.Api
{
    public class ApiTransferDetail
    {
        public int ID { get; set; }
        public int BatchID { get; set; }
        public int LocationID { get; set; }
        public int DistributerID { get; set; }
    }
}