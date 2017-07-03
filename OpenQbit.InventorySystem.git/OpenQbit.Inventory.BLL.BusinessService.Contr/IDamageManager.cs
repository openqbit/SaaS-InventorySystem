using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQbit.Inventory.Common.Models;

namespace OpenQbit.Inventory.BLL.BusinessService.Contr
{
    public interface IDamageManager
    {
        bool RecoredDamage(Damage damage);

        bool UpdateDamage(Damage damage);

        bool DeleteDamage(Damage damage);

        Damage FindDamageByID(int id);

        List<Damage> getAllDamages();
    }
}
