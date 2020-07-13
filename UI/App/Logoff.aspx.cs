using System;
using System.Web;
using System.Web.Security;
using Falcon.App.Core.Application;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.DependencyResolution;
using Falcon.App.UI;
using Falcon.App.UI.Extentions;

public partial class Logoff : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        UpdateLoginInfo();
        Session.Abandon();
        Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
        FormsAuthentication.SignOut();
        if (Request.QueryString["st"] != null)
            Response.RedirectUser("~/login?sessionTimeout=1");
        else
        {
            Response.RedirectUser("~/login");
        }
    }

    private void UpdateLoginInfo()
    {
        var repository = IoC.Resolve<IUserLoginLogRepository>();
        var singleSessionHelper = IoC.Resolve<ISingleSessionHelper>();
        try
        {
            var sessionContext = IoC.Resolve<ISessionContext>();
            if (sessionContext == null || sessionContext.UserSession == null)
                return;

            IoC.Resolve<ILogManager>().GetLogger<Global>().Info(sessionContext.UserSession.UserName + " has been log out Logoff page");

            singleSessionHelper.RemoveUserSessionFromCache(sessionContext.UserSession.UserName, Session.SessionID);

            repository.UpdateLogOutTimeforUser(sessionContext.UserSession.UserLoginLogId);
        }
        catch (Exception)
        {
            return;
        }

        //var userLoginLog = Session["LoginLog"] as UserLoginLog;

        //if (userLoginLog == null)
        //{
        //    // This occurs when the user clicks Log Out when they are already logged out, or when the project has been rebuilt.
        //    return;
        //}

        //userLoginLog.LogOutDateTime = DateTime.Now;
        //IUniqueItemRepository<UserLoginLog> uniqueItemRepository = new UserLoginLogRepository();
        //uniqueItemRepository.Save(userLoginLog);

    }
}
