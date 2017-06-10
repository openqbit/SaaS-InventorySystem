using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using OpenQbit.Inventory.Service.WebApi.Models.Api;

namespace OpenQbit.Inventory.Service.WebApi.Controllers.Api
{
    public class ApiDamageController : ApiController
    {
        public ApiDamage Get(int ID)
        {
            ApiDamage damage = new ApiDamage
            {
                ID = 1,
                Description = "Damaged when storing",
                Qty = 5,
                BatchID = 1
            };

            return damage;
        }

        public List<ApiDamage> GetList()
        {
            List<ApiDamage> damageList = new List<ApiDamage>();

            ApiDamage damage1 = new ApiDamage
            {
                ID = 1,
                Description = "Damaged when storing",
                Qty = 5,
                BatchID = 1
            };

            ApiDamage damage2 = new ApiDamage
            {
                ID = 2,
                Description = "Damaged when storing",
                Qty = 10,
                BatchID = 2
            };

            ApiDamage damage3 = new ApiDamage
            {
                ID = 2,
                Description = "Damaged when transport",
                Qty = 8,
                BatchID = 3
            };

            damageList.Add(damage1);
            damageList.Add(damage2);
            damageList.Add(damage3);

            return damageList;
        }

        public bool Create(ApiDamage apiDamage)
        {
            return true;
        }

        public bool Delete(int ID)
        {
            return true;
        }

        public bool Update(ApiDamage apiDamage)
        {
            return true;

        }
    }
}