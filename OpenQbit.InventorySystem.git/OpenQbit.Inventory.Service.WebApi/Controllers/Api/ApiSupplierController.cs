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
    //[Authorize]
    public class ApiSupplierController:ApiController
    {
        public ApiSupplier Get(int ID)
        {
            ISupplierManager SupplierManager = UnityResolver.Resolve<ISupplierManager>();
            Supplier supplierModel = SupplierManager.FindSupplierById(ID);
            ApiSupplier supplier = new ApiSupplier
            {
                ID = supplierModel.ID,
                name = supplierModel.name,
                address = supplierModel.address,
                company = supplierModel.company,
                telephone = supplierModel.telephone
            };

            return supplier;
        }

        public List<ApiSupplier> GetList()
        {
            ISupplierManager SupplierManager = UnityResolver.Resolve<ISupplierManager>();
            List<Supplier> supplierModelList = SupplierManager.getAllSupplier();
            List<ApiSupplier> supplierList = new List<ApiSupplier>();

            foreach(Supplier supplierModel in supplierModelList)
            {
                ApiSupplier supplier = new ApiSupplier
                {
                    ID = supplierModel.ID,
                    name = supplierModel.name,
                    address = supplierModel.address,
                    company = supplierModel.company,
                    telephone = supplierModel.telephone
                };

                supplierList.Add(supplier);
            }
            
            return supplierList;
        }
        public bool Create(ApiSupplier apiSupplier)
        {
           // string id = User.Identity.Name;
            ISupplierManager SupplierManager = UnityResolver.Resolve<ISupplierManager>();
            Supplier supplier = new Supplier
            {
                ID = apiSupplier.ID,
                name = apiSupplier.name,
                address = apiSupplier.address,
                company = apiSupplier.company,
                telephone = apiSupplier.telephone,
                CustomerID = Helper.getCustID()
            };

            return SupplierManager.RecoredSupplier(supplier);
        
        }
        public bool Delete(ApiSupplier apiSupplier)
        {
         //   string id = User.Identity.Name;
            ISupplierManager SupplierManager = UnityResolver.Resolve<ISupplierManager>();
            Supplier supplier = new Supplier
            {
                ID = apiSupplier.ID,
                name = apiSupplier.name,
                address = apiSupplier.address,
                company = apiSupplier.company,
                telephone = apiSupplier.telephone,
                CustomerID = Helper.getCustID()
            };

            return SupplierManager.DeleteSupplier(supplier);
        }
        public bool Update(ApiSupplier apiSupplier)
        {
           // string id = User.Identity.Name;
            ISupplierManager SupplierManager = UnityResolver.Resolve<ISupplierManager>();
            Supplier supplier = new Supplier
            {
                ID = apiSupplier.ID,
                name = apiSupplier.name,
                address = apiSupplier.address,
                company = apiSupplier.company,
                telephone = apiSupplier.telephone,
                CustomerID = Helper.getCustID()
            };

            return SupplierManager.UpdateSupplier(supplier);
        }
    }
}