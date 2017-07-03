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

namespace OpenQbit.Inventory.BLL.BusinessService.Contr
{
    public class TransferDetailManager : ITransferDetailManager
    {
        private IRepository _repository;
        private ILogger _log;

        [InjectionConstructor]
        public TransferDetailManager(IRepository repository, ILogger log)
        {
            this._repository = repository;
            this._log = log;
        }


        public bool RecoredTransferDetail(TransferDetail trensferdetail)
        {
            _log.LogError("");

            return _repository.Create<TransferDetail>(trensferdetail);
        }
    }
}
