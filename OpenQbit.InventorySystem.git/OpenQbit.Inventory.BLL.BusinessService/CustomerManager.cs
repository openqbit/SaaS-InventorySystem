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

    
        public bool RecoredCustomer(Customer customer)
        {
            _logger.LogError("");

            return _repository.Create<Customer>(customer);
        }

        public bool UpdateCustomer(Customer customer)
        {
            _logger.LogError("");

            return _repository.Update<Customer>(customer);
        }

        public bool DeleteCustomer(Customer customer)
        {
            _logger.LogError("");

            return _repository.Delete<Customer>(customer);
        }

        public Customer FindCustomerByID(int id)
        {
            _logger.LogError("");

            return _repository.FindByID<Customer>(id);
        }

        public List<Customer> GetAllCustomers()
        {
            _logger.LogError("");

            return _repository.GetAll<Customer>();
        }

        public Customer SearchCustomerByUserName(string userName)
        {
            _logger.LogError("");

            return _repository.Find<Customer>(C =>C.UserName == userName);
        }
    }
}
