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
            _log.LogError("Transfer Detail add fail");

            return _repository.Create<TransferDetail>(trensferdetail);
        }

        public bool UpdateTransferDetail(TransferDetail trensferdetail)
        {
            _log.LogError("Transfer Detail update fail");

            return _repository.Update<TransferDetail>(trensferdetail);
        }

        public bool DeleteTransferDetail(TransferDetail trensferdetail)
        {
            _log.LogError("Transfer Detail delete fail");

            return _repository.Delete<TransferDetail>(trensferdetail);
        }

        public List<TransferDetail> getAllTransferDetail()
        {
            _log.LogError("Transfer Detail list not found ");

            return _repository.GetAll<TransferDetail>();
        }

        public TransferDetail FindTransferDetail(int ID)
        {
            _log.LogError("Transfer Detail list not found ");

            return _repository.FindById<TransferDetail>(ID);
        }
    }
}
