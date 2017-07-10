using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpenQbit.Inventory.Service.WebApi.Models.Api
{
    public class ApiSupplier
    {
        public int ID { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string company { get; set; }
        public string telephone { get; set; }
}