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
    public class DistributerManager : IDistributerManager
    {
        private IRepository _repository;

        private ILogger _log;

        [InjectionConstructor]
        public DistributerManager(IRepository repository, ILogger log)
        {
            this._repository = repository;
            this._log = log;
        }


        public bool RecordDistributer(Distributer distributer)
        {
            _log.LogError("Distributer Add Failed");
            return _repository.Create<Distributer>(distributer);
        }

        public bool DeleteDistributer(Distributer distributer)
        {
            _log.LogError("Distributer Delete Failed");

            return _repository.Delete<Distributer>(distributer);
        }

        public bool UpdateDistributer(Distributer distributer)
        {
            _log.LogError("Distributer Update Failed");

            return _repository.Update<Distributer>(distributer);
        }

        public Distributer FindDistributerByID(int id)
        {
            _log.LogError("No Distributer Found");

            return _repository.FindByID<Distributer>(id);
        }

        public List<Distributer> GetAllDistributers()
        {
            _log.LogError("Get All Distributers Failed");

            return _repository.GetAll<Distributer>();
        }

    }

}
