using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using OpenQbit.Inventory.Service.WebApi.Models.Api;

namespace OpenQbit.Inventory.Service.WebApi.Controllers.Api
{
    public class ApiSupplierController:ApiController
    {
        public ApiSupplier Get(int ID)
        {
            ApiSupplier supplier = new ApiSupplier
            {
                ID = 1,
                name = "Dhanapala",
                address = "Galle Road,Kaluwella",
                company = "Harishchandra",
                telephone="077-1234567"
            };

            return supplier;
        }

        public List<ApiSupplier> GetList()
        {
            List<ApiSupplier> supplierList = new List<ApiSupplier>();

            ApiSupplier supplier1 = new ApiSupplier
            {
                ID = 1,
                name = "Dhanapala",
                address = "Galle Road,Kaluwella",
                company = "Harishchandra",
                telephone = "077-1234567"
            };

            ApiSupplier supplier2 = new ApiSupplier
            {
                ID = 2,
                name = "Somapala",
                address = "Galle Road,Kaluwella",
                company = "Keels",
                telephone = "077-1236787"
            };

            ApiSupplier supplier3 = new ApiSupplier
            {
                ID =3,
                name = "Ananda",
                address = "Galle Road,Kaluwella",
                company = "MDK",
                telephone = "077-1084567"
            };

            supplierList.Add(supplier1);
            supplierList.Add(supplier2);
            supplierList.Add(supplier3);

            return supplierList;
        }
    }
}