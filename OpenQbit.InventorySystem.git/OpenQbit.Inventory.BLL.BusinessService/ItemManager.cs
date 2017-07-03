using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQbit.Inventory.Common.Models;
using OpenQbit.Inventory.Common.Utils.Logs;
using OpenQbit.Inventory.DAL.DataAccess.Contr;
using OpenQbit.Inventory.BLL.BusinessService.Contr;
using Microsoft.Practices.Unity;

namespace OpenQbit.Inventory.BLL.BusinessService
{
    public class ItemManager : IItemManager
    {
        private IRepository _repository;

        private ILogger _log;

        [InjectionConstructor]
        public ItemManager(IRepository repository, ILogger log)
        {
            this._repository = repository;
            this._log = log;
        }


        public bool RecordItem(Item item)
        {
            _log.LogError("Item Add Failed");
            return _repository.Create<Item>(item);
        }

        public bool DeleteItem(Item item)
        {
            _log.LogError("Item Delete Failed");

            return _repository.Delete<Item>(item);
        }

        public bool UpdateItem(Item item)
        {
            _log.LogError("Item Update Failed");

            return _repository.Update<Item>(item);
        }

        public Item FindItemByID(int id)
        {
            _log.LogError("No Item Found");

            return _repository.FindByID<Item>(id);
        }

        public List<Item> GetAllItems()
        {
            _log.LogError("Get All Items Failed");

            return _repository.GetAll<Item>();
        }
    }
}
