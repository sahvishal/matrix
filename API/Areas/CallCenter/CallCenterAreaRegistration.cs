using System.Web.Http;
using System.Web.Mvc;

namespace API.Areas.CallCenter
{
    public class CallCenterAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "CallCenter";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.Routes.MapHttpRoute(
                "CallCenter_default",
                "CallCenter/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
