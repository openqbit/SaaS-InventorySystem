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
    public class BatchManager:IBatchManager
    {
        private IRepository _repository;

        private ILogger _logger;

        [InjectionConstructor]
        public BatchManager(IRepository repository,ILogger logger)
        {
            this._repository = repository;
            this._logger = logger;
        }


        public bool RecoredBatch(Batch batch)
        {
            _logger.LogError("Batch Add Failed");

            return _repository.Create<Batch>(batch);
        }

        public bool DeleteBatch(Batch batch)
        {
            _logger.LogError("Batch Delete Failed");

            return _repository.Delete<Batch>(batch);
        }

        public bool UpdateBatch(Batch batch)
        {
            _logger.LogError("Batch Update Failed");

            return _repository.Update<Batch>(batch);
        }

        public Batch FindBatchByID(int id)
        {
            _logger.LogError("No Batch Found");

            return _repository.FindById<Batch>(id);
        }

        public List<Batch> GetAllBatches()
        {
            _logger.LogError("Get All Batches Failed");

            return _repository.GetAll<Batch>();
        }
    }
}
