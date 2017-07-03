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
    public class DamageManager:IDamageManager
    {
        private IRepository _repository;

        private ILogger _logger;

        [InjectionConstructor]
        public DamageManager(IRepository repository, ILogger logger)
        {
            this._repository = repository;
            this._logger = logger;
        }


        public bool RecoredDamage(Damage damage)
        {
            _logger.LogError("Damage Add Failed");

            return _repository.Create<Damage>(damage);
        }

        public bool DeleteDamage(Damage damage)
        {
            _logger.LogError("Damage Delete Failed");

            return _repository.Delete<Damage>(damage);
        }

        public bool UpdateDamage(Damage damage)
        {
            _logger.LogError("Damage Update Failed");

            return _repository.Update<Damage>(damage);
        }

        public Damage FindDamageByID(int id)
        {
            _logger.LogError("No Damage Found");

            return _repository.FindByID<Damage>(id);
        }

        public List<Damage> getAllDamages()
        {
            _logger.LogError("Get All Damages Failed");

            return _repository.GetAll<Damage>();
        }
    }
}
