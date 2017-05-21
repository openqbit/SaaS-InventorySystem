using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenQbit.Inventory.Common.Models
{
    public class Batch
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public int Qty { get; set; }
        public double UnitPrice { get; set; }

        public int ItemID { get; set; }
        public int SupplierID { get; set; }
        public virtual Item Item { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual ICollection<Damage> Damages { get; set; }
        public virtual ICollection<Return> Returns { get; set; }
        public virtual ICollection<TransferDetail> TransferDetails { get; set; }

    }
}
