using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQbit.Inventory.Common.Models;

namespace OpenQbit.Inventory.BLL.BusinessService.Contr
{
    public interface ILocationManager
    {
        bool RecordLocation(Location location);
        bool UpdateLocation(Location location);
        bool DeleteLocation(Location location);
        List<Location> getAllLocation();
        Location FindLocationbyID(int ID);

    }
}
