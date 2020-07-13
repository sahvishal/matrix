using System.Web.Http;
using System.Web.Mvc;

namespace API.Areas.Application
{
    public class ApplicationAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Application";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.Routes.MapHttpRoute(
                "Application_default",
                 "Application/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
