using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenQbit.Inventory.Common.Models
{
    public class TransferDetail
    {
        public int ID { get; set; }
        public int qty { get; set; }
        public int CustomerID { get; set; }
        public virtual Customer customer { get; set; }
        public int BatchID { get; set; }
        public virtual Batch Batch { get; set; }
        public int LocationID { get; set; }
        public virtual Location Location { get; set; }
        public int DistributerID { get; set; }
        public virtual Distributer Distributer { get; set; }
    }
}
