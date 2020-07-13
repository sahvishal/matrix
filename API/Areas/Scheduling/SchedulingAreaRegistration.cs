using System.Web.Http;
using System.Web.Mvc;

namespace API.Areas.Scheduling
{
    public class SchedulingAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Scheduling";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.Routes.MapHttpRoute(
                "Scheduling_default",
                "Scheduling/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
