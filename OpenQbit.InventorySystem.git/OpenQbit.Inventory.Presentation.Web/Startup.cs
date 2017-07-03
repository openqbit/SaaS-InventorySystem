using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OpenQbit.Inventory.Presentation.Web.Startup))]
namespace OpenQbit.Inventory.Presentation.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
