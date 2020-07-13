using System;
using System.Web.Routing;
using Falcon.SPA.App_Start;
using System.Web.Optimization;

namespace Falcon.SPA
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}