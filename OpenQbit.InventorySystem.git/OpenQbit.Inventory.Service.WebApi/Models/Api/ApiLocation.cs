using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpenQbit.Inventory.Service.WebApi.Models.Api
{
    public class ApiLocation
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public int CustomerID { get; set; }
    }
}