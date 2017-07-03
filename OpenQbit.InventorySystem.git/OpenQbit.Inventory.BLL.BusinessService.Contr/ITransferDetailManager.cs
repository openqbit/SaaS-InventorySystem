using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQbit.Inventory.Common.Models;

namespace OpenQbit.Inventory.BLL.BusinessService.Contr
{
    public interface ITransferDetailManager
    {
        bool RecoredTransferDetail(TransferDetail trensferdetail);
        bool UpdateTransferDetail(TransferDetail trensferdetail);
        bool DeleteTransferDetail(TransferDetail trensferdetail);
        List<TransferDetail> getAllTransferDetail();
        TransferDetail FindTransferDetail(int ID);
    }
}
