using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQbit.Inventory.BLL.BusinessService.Contr;
using OpenQbit.Inventory.Common.Models;
using OpenQbit.Inventory.Common.Utils.Logs;
using OpenQbit.Inventory.DAL.DataAccess.Contr;

using Microsoft.Practices.Unity;

namespace OpenQbit.Inventory.BLL.BusinessService
{
    public class SupplierManager : ISupplierManager
    {
        private IRepository _repository;
        private ILogger _log;

        [InjectionConstructor]
        public SupplierManager(IRepository repository, ILogger log)
        {
            this._repository = repository;
            this._log = log;
        }

       

        public bool RecoredSupplier(Supplier supplier)
        {
            _log.LogError("Supplier add fail");

            return _repository.Create<Supplier>(supplier);
        }

        public bool UpdateSupplier(Supplier supplier)
        {
            _log.LogError("Supplier update fail");

            return _repository.Update<Supplier>(supplier);
        }

        public bool DeleteSupplier(Supplier supplier)
        {
            _log.LogError("Supplier delete fail");

            return _repository.Delete<Supplier>(supplier);
        }

        public List<Supplier> getAllSupplier()
        {
            _log.LogError("Supplier list not found");

            return _repository.GetAll<Supplier>();
        }

        public Supplier FindSupplierById(int ID)
        {
            _log.LogError("supplier not found");

            return _repository.FindById<Supplier>(ID);
        }
    }
}
