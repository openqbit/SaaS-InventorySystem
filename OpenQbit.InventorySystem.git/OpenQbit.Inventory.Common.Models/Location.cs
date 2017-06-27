using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenQbit.Inventory.Common.Models
{
    public class Location
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public int CustomerID { get; set; }
        public virtual Customer customer { get; set; }
        public virtual ICollection<TransferDetail> TransferDetails { get; set; }
    }
}
