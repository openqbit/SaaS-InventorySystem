﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQbit.Inventory.Common.Models;

namespace OpenQbit.Inventory.BLL.BusinessService.Contr
{
    public interface IBatchManager
    {
        bool RecoredBatch(Batch batch);

        bool DeleteBatch(Batch batch);

        bool UpdateBatch(Batch batch);

        Batch FindBatchByID(int id);

        List<Batch> GetAllBatches();
    }
}
