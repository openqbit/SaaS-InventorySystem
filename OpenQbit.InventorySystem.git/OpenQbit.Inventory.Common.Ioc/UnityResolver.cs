using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenQbit.Inventory.Common.Utils.Logs;
using OpenQbit.Inventory.DAL.DataAccess;
using OpenQbit.Inventory.DAL.DataAccess.Contr;

using Microsoft.Practices.Unity;
using OpenQbit.Inventory.BLL.BusinessService.Contr;
using OpenQbit.Inventory.BLL.BusinessService;

namespace OpenQbit.Inventory.Common.Ioc
{
    public class UnityResolver
    {
        private static readonly IUnityContainer container = new UnityContainer();

        public static void Register()
        {
            container.RegisterType<IRepository, Repository>();
            container.RegisterType<ILogger, Logger>();
            container.RegisterType<ICustomerManager, CustomerManager>();
            container.RegisterType<IItemManager, ItemManager>();
            container.RegisterType<ISupplierManager, SupplierManager>();
            container.RegisterType<IBatchManager, BatchManager>();
            container.RegisterType<IDamageManager, DamageManager>();
            container.RegisterType<IReturnManager, ReturnManager>();
            container.RegisterType<IDistributerManager, DistributerManager>();
            container.RegisterType<ILocationManager, LocationManager>();
            container.RegisterType<ITransferDetailManager, TransferDetailManager>();
        }

        public static T Resolve<T>()
        {
            T defaultT = default(T);
            var resolved = container.Resolve<T>();
            return (resolved == null) ? defaultT : resolved;
        }

        public static IUnityContainer GetContainer()
        {
            return container;
        }
    }
}
