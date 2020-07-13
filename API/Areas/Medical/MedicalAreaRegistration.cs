using System.Web.Http;
using System.Web.Mvc;

namespace API.Areas.Medical
{
    public class MedicalAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Medical";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.Routes.MapHttpRoute(
                "Medical_default",
                "Medical/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
