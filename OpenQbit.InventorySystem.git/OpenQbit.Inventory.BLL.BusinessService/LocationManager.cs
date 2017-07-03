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
    public class LocationManager : ILocationManager
    {
        private IRepository _repository;

        private ILogger _log;

        [InjectionConstructor]
        public LocationManager(IRepository repository, ILogger log)
        {
            this._repository = repository;
            this._log = log;
        }


        public bool RecordLocation(Location location)
        {
            _log.LogError("Not Added Location");
            return _repository.Create<Location>(location);
        }

        public bool UpdateLocation(Location location)
        {
            _log.LogError("Not Updated Location");
            return _repository.Update<Location>(location);
        }

        public bool DeleteLocation(Location location)
        {
            _log.LogError("Not Deleted Location");
            return _repository.Delete<Location>(location);
        }

        public List<Location> getAllLocation()
        {
            _log.LogError("Loction list not found");
            return _repository.GetAll<Location>();
        }

        //public Location FindLocation(int ID)
        //{
        //    _log.LogError("Loction  not found");
        //    return _repository.Find<Location>(L => L.ID == ID);
        //}

        

        public Location FindLocationbyID(int ID)
        {
            _log.LogError("Loction  not found");
            return _repository.FindById<Location>(ID);
        }

    }
}
