using System.Web.Mvc;

namespace Falcon.App.UI.Areas.AccessControl
{
    public class AccessControlAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "AccessControl";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "AccessControl_default",
                "AccessControl/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
