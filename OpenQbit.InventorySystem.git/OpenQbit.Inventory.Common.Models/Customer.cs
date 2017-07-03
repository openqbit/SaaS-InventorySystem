using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenQbit.Inventory.Common.Models
{
    public class Customer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Batch> Batch { get; set; }
        public virtual ICollection<Damage> Damage { get; set; }
        public virtual ICollection<Distributer> Distributer { get; set; }
        public virtual ICollection<Item> Item { get; set; }
        public virtual ICollection<Location> Location { get; set; }
        public virtual ICollection<Return> Return { get; set; }
        public virtual ICollection<Supplier> Supplier { get; set; }
        public virtual ICollection<TransferDetail> TransferDetails { get; set; }
    }
}
