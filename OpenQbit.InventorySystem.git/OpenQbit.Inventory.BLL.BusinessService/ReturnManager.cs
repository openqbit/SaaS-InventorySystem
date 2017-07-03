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
    public class ReturnManager : IReturnManager
    {
        private IRepository _repository;
        private ILogger _log;
        
        [InjectionConstructor]
        public ReturnManager(IRepository repository, ILogger log)
        {
            this._repository = repository;
            this._log = log;
        }

       
        public bool RecoredReturn(Return returns)
        {
            _log.LogError("return add fail");

            return _repository.Create<Return>(returns);
        }

        public bool UpdateReturn(Return returns)
        {

            _log.LogError("return update fail");

            return _repository.Update<Return>(returns);
        }

        public bool DeleteReturn(Return returns)
        {
            _log.LogError("return delete fail");

            return _repository.Delete<Return>(returns);
        }

        public List<Return> getAllReturn()
        {
            _log.LogError("no returns list found");

            return _repository.GetAll<Return>();
        }

        public Return FindReturnByID(int ID)
        {
            _log.LogError("no returns found");

            return _repository.FindById<Return>(ID);
        }
    }
}
