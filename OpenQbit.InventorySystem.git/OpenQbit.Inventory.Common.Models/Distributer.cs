using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenQbit.Inventory.Common.Models
{
    public class Distributer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Telephone { get; set; }

        public virtual ICollection<TransferDetail> TransferDetails { get; set; }
    }
}
