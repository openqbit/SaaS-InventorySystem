﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQbit.Inventory.Common.Models;

namespace OpenQbit.Inventory.BLL.BusinessService.Contr
{
    public interface IReturnManager
    {
        bool RecoredReturn(Return returns);
        bool UpdateReturn(Return returns);
        bool DeleteReturn(Return returns);
        List<Return> getAllReturn();
        Return FindReturnByID(int ID);
    }
}
