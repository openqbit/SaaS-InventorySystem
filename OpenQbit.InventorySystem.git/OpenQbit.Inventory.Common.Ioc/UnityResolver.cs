using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenQbit.Inventory.Common.Utils.Logs;
using OpenQbit.Inventory.DAL.DataAccess;
using OpenQbit.Inventory.DAL.DataAccess.Contr;

using Microsoft.Practices.Unity;

namespace OpenQbit.Inventory.Common.Ioc
{
    public class UnityResolver
    {
        private static readonly IUnityContainer container = new UnityContainer();

        public static void Register()
        {
            container.RegisterType<IRepository, Repository>();
            container.RegisterType<ILogger, LoggerB>();
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
