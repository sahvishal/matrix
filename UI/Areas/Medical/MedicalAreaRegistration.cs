using System.Web.Mvc;

namespace Falcon.App.UI.Areas.Medical
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
            context.MapRoute(
                "Medical_default",
                "Medical/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
