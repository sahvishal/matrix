using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Dependencies;
using API.Areas.Application.Controllers;
using Falcon.App.DependencyResolution;

namespace API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            config.Routes.MapHttpRoute(
                name: "DefaultApiForAction",
                routeTemplate: "{area}/{controller}/{action}"

            );
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{area}/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional, area="Users" }
            );

            config.DependencyResolver = new DependencyResolver();

            // Uncomment the following line of code to enable query support for actions with an IQueryable or IQueryable<T> return type.
            // To avoid processing unexpected or malicious queries, use the validation settings on QueryableAttribute to validate incoming queries.
            // For more information, visit http://go.microsoft.com/fwlink/?LinkId=279712.
            //config.EnableQuerySupport();

            // To disable tracing in your application, please comment out or remove the following line of code
            // For more information, refer to: http://www.asp.net/web-api
            //config.EnableSystemDiagnosticsTracing();
        }
    }

    public class DependencyResolver : IDependencyResolver
    {
        public void Dispose()
        {

        }

        public object GetService(Type serviceType)
        {
            if (serviceType.BaseType != typeof(BaseController) && serviceType.BaseType != typeof(ApiController))
                return null;

            return IoC.Resolve(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return new List<object>();
        }

        public IDependencyScope BeginScope()
        {
            return this;
        }

    }
}
