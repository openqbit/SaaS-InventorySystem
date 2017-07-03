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
    public class CustomerManager:ICustomerManager
    {
        private IRepository _repository;

        private ILogger _logger;

        [InjectionConstructor]
        public CustomerManager(IRepository repository, ILogger logger)
        {
            this._repository = repository;
            this._logger = logger;
        }

        [Dependency]
        public IRepository Repository
        {
            get { return _repository; }
            set { _repository = value; }
        }

        [Dependency]
        public ILogger Logger
        {
            get { return _logger; }
            set { _logger = value; }
        }

        [InjectionMethod]
        public void SetRepository(IRepository repository)
        {
            _repository = repository;
        }

        public bool RecoredCustomer(Customer customer)
        {
            _logger.LogError("");

            return _repository.Create<Customer>(customer);
        }
    }
}
