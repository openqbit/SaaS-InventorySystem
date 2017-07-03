using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQbit.Inventory.Common.Models;

namespace OpenQbit.Inventory.BLL.BusinessService.Contr
{
    public interface ISupplierManager
    {
        bool RecoredSupplier(Supplier supplier);
        bool UpdateSupplier(Supplier supplier);
        bool DeleteSupplier(Supplier supplier);
        List<Supplier> getAllSupplier();
        Supplier FindSupplierById(int ID);
    }
}
