using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TonquishCreek.TeamManagement.Web.Startup))]
namespace TonquishCreek.TeamManagement.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ContainerConfig.Configure();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
