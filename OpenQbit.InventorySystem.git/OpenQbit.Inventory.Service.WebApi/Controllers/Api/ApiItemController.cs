using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using OpenQbit.Inventory.Service.WebApi.Models.Api;
using OpenQbit.Inventory.BLL.BusinessService.Contr;
using OpenQbit.Inventory.Common.Ioc;
using OpenQbit.Inventory.Common.Models;

namespace OpenQbit.Inventory.Service.WebApi.Controllers.Api
{
    public class ApiItemController:ApiController
    {
        public ApiItem Get(int ID)
        {
            IItemManager ItemManager = UnityResolver.Resolve<IItemManager>();
            Item itemModel =ItemManager.FindItemByID(ID);
            ApiItem item = new ApiItem
            {
                ID = itemModel.ID,
                Name = itemModel.Name,
                Active = itemModel.Active,
                reOrder=itemModel.reOrder
            };
            return item;  
        }

        public List<ApiItem> GetList()
        {
            IItemManager ItemManager = UnityResolver.Resolve<IItemManager>();
            List<Item> itemModelList = ItemManager.GetAllItems();
            List<ApiItem> itemList = new List<ApiItem>();

            foreach(Item itemModel in itemModelList)
            {
                ApiItem item = new ApiItem
                {
                    ID = itemModel.ID,
                    Name = itemModel.Name,
                    Active = itemModel.Active,
                    reOrder = itemModel.reOrder
                };

                itemList.Add(item);
            }
            
            return itemList;
        }

        public bool Create(ApiItem apiItem)
        {
            IItemManager ItemManager = UnityResolver.Resolve<IItemManager>();
            string id = User.Identity.Name;
            Item item = new Item
            {
                ID = apiItem.ID,
                Name = apiItem.Name,
                Active = apiItem.Active,
                reOrder = apiItem.reOrder,
                CustomerID = Convert.ToInt32(id)
            };

            if (ItemManager.RecordItem(item))
            {
                return true;
            }

            return false;
        }

        public bool Delete(ApiItem apiItem)
        {
            IItemManager ItemManager = UnityResolver.Resolve<IItemManager>();
            string id = User.Identity.Name;
            Item item = new Item
            {
                ID = apiItem.ID,
                Name = apiItem.Name,
                Active = apiItem.Active,
                reOrder = apiItem.reOrder,
                CustomerID = Convert.ToInt32(id)
            };

            if (ItemManager.DeleteItem(item))
            {
                return true;
            }

            return false;
        }

        public bool Update(ApiItem apiItem)
        {
            IItemManager ItemManager = UnityResolver.Resolve<IItemManager>();
            string id = User.Identity.Name;
            Item item = new Item
            {
                ID = apiItem.ID,
                Name = apiItem.Name,
                Active = apiItem.Active,
                reOrder = apiItem.reOrder,
                CustomerID = Convert.ToInt32(id)
            };

            if (ItemManager.UpdateItem(item))
            {
                return true;
            }

            return false;
        }
    }
}