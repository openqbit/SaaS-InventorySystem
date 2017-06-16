using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenQbit.Inventory.Common.Models
{
    public class Supplier
    {
        public int ID { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string company { get; set; }
        public string telephone { get; set; }

        public int CustomerID { get; set; }
        public virtual Customer customer { get; set; }
        public virtual ICollection<Batch> Batch { get; set; }
        public virtual ICollection<Return> Return { get; set; }
    }
}
