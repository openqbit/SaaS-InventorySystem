using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenQbit.Inventory.Common.Models
{
    public class Item
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public int reOrder { get; set; }

        public virtual ICollection<Batch> Batchs { get; set; }
    }
}
