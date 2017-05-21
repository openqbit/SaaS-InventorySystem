using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenQbit.Inventory.Common.Models
{
    public class Return
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public int Qty { get; set; }

        public int BatchID { get; set; }
        public virtual Batch Batch { get; set; }
        public int SupplierID { get; set; }
        public virtual Supplier Supplier { get; set; }

    }
}
