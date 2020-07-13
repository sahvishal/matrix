using System.Web.Http;
using System.Web.Mvc;

namespace API.Areas.Marketing
{
    public class MarketingAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Marketing";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.Routes.MapHttpRoute(
                "Marketing_default",
                "Marketing/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
