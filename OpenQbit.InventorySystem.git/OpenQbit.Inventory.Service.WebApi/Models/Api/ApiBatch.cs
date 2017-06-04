using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpenQbit.Inventory.Service.WebApi.Models.Api
{
    public class ApiBatch
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public int Qty { get; set; }
        public double UnitPrice { get; set; }

        public int ItemID { get; set; }
        public int SupplierID { get; set; }
    }
}