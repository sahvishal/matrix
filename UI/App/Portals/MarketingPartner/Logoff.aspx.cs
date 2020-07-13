using System;
using System.Web;
using System.Web.Security;
using Falcon.App.Core.Application;
using Falcon.App.Core.Users;
using Falcon.App.DependencyResolution;
using Falcon.App.UI.Extentions;

namespace Falcon.App.UI.App.Portals.MarketingPartner
{
    public partial class Logoff : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UpdateLoginInfo();
            Session.Abandon();
            Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
            FormsAuthentication.SignOut();
            Response.RedirectUser("~/login");
      
        }

        private void UpdateLoginInfo()
        {
            var repository = IoC.Resolve<IUserLoginLogRepository>();
            try
            {
                var sessionContext = IoC.Resolve<ISessionContext>();
                if (sessionContext == null || sessionContext.UserSession == null)
                    return;

                repository.UpdateLogOutTimeforUser(sessionContext.UserSession.UserLoginLogId);
            }
            catch (Exception)
            {
                return;
            }
        }

    }

  
    
}
