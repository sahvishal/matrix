using System.Web.Mvc;
using System.Web.Routing;

namespace Falcon.SPA.App_Start
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "CallCenter",
                url: "Home/{action}",
                defaults: new { controller = "Home", action = "Error"}
            );

            routes.MapRoute(
                name: "Online",
                url: "{statename}/{*someparam}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
             
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}