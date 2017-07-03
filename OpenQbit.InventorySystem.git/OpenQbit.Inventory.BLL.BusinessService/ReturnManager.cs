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
            _log.LogError("");

            return _repository.Create<Return>(returns);
        }
    }
}
