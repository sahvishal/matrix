using System;
using Falcon.App.Core.Application;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.DependencyResolution;
using Falcon.App.UI.Extentions;
using Falcon.DataAccess.Other;

public partial class App_ResetPassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["UserID"] != null && Request.QueryString["AuthStr"] != null)
        {
            var otherDal = new OtherDAL();
            if (otherDal.VerifyUser(Convert.ToInt64(Request.QueryString["UserID"]), Request.QueryString["AuthStr"]))
            {
                var userRepository = IoC.Resolve<IUserRepository<User>>();
                var user = userRepository.GetUser(Convert.ToInt64(Request.QueryString["UserID"]));
                var sessionContext = IoC.Resolve<ISessionContext>();
                //Check this - Bidhan

                sessionContext.UserSession = IoC.Resolve<IUserLoginService>().GetUserSessionModel(user.UserLogin.UserName);
                Response.RedirectUser("FirstTimeLoginStep.aspx?rstpwd='Y'");
            }
            else
            {
                Response.RedirectUser("/App/?UnAuthStr=True");
            }
        }
    }
}
