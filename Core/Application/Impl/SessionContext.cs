using System.Web;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Users.ViewModels;

namespace Falcon.App.Core.Application.Impl
{
    [DefaultImplementation]
    public class SessionContext : ISessionContext
    {

        public UserSessionModel UserSession
        {
            get { return HttpContext.Current.Session != null && HttpContext.Current.Session["_UserSessionModel_"] != null ? HttpContext.Current.Session["_UserSessionModel_"] as UserSessionModel : null; }
            set { HttpContext.Current.Session["_UserSessionModel_"] = value; }
        }

        public string LastLoggedInTime
        {
            get { return HttpContext.Current.Session["_LastLoggedInTime_"] as string; }
            set { HttpContext.Current.Session["_LastLoggedInTime_"] = value; }
        }
    }
}