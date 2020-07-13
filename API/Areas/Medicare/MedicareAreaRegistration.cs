using System.Web.Http;
using System.Web.Mvc;

namespace API.Areas.Medicare
{
    public class MedicareAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Medicare";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.Routes.MapHttpRoute(
                "Medicare_default",
                 "Medicare/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
