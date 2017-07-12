using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace TonquishCreek.TeamManagement.Web
{
    public sealed class RouteConfig
    {
        #region Constructor(s)
        private RouteConfig()
        {
        }
        #endregion

        #region Public Method(s)
        public static void RegisterRoutes(RouteCollection routes)
        {
            if (routes == null)
            {
                throw new ArgumentNullException(nameof(routes));
            }

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
        #endregion
    }
}
