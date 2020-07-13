using System;
using System.Web;
using System.Web.UI;
using Falcon.App.Core.Application;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Service;
using Falcon.App.UI.Extentions;

public partial class FirstTimeLoginStep : Page
{
    public bool isResetPassword { get; set; }
    public bool isPasswordExpired { get; set; }
    protected string Heading { get; set; }
    protected string ReturnUrl { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {
        if ((Request.QueryString["PwdExpire"] != null) &&
            (Request.QueryString["PwdExpire"] == "Y" || Request.QueryString["PwdExpire"] == "'Y'"))
        {
            isPasswordExpired = true;
        }
        if ((Request.QueryString["rstpwd"] != null) &&
            (Request.QueryString["rstpwd"] == "Y" || Request.QueryString["rstpwd"] == "'Y'"))
        {
            isResetPassword = true;
        }
        if (Request.QueryString["returnUrl"] != null)
        {
            ReturnUrl = Request.QueryString["returnUrl"];
        }
        Heading = isResetPassword ? "Reset Password" : "First Time Login – Security Setup";
        if (isPasswordExpired)
            Heading = "Your password has expired, please set a new password";
        Page.Title = Heading;
        if (IsPostBack) return;

        var sessionContext = IoC.Resolve<ISessionContext>();

        if (sessionContext.UserSession == null) Response.RedirectUser("/App/");

        var loggedinUser = IoC.Resolve<IUserService>().GetUser(sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId).UserLogin;

        trSecQues.Style.Add(HtmlTextWriterStyle.Display, "none");
        //trSecQues.Style.Add(HtmlTextWriterStyle.Visibility, "hidden");



        if (loggedinUser.UserVerified && isPasswordExpired == false)
        {
            string redirectPath = "/Users/Role/Switch?roleId=" +
                     sessionContext.UserSession.CurrentOrganizationRole.RoleId +
                     "&organizationId=" +
                     sessionContext.UserSession.CurrentOrganizationRole.OrganizationId;

            Response.RedirectUser(redirectPath);
        }

        trResetPass.Style.Add(HtmlTextWriterStyle.Display, "block");

        Session["UserId"] = sessionContext.UserSession.UserId;
        Session["OrganizationRoleUserId"] = sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId;
        sessionContext.UserSession = null;


        if ((Request.QueryString["FirstTimeLogin"] == null) || (Request.QueryString["FirstTimeLogin"] != "Y")) return;

        if (!loggedinUser.IsSecurityQuestionVerified)
        {
            trSecQues.Style.Add(HtmlTextWriterStyle.Display, "block");
        }

    }

    private void ResetPassword()
    {
        var organizationRoleUserId = (long)Session["OrganizationRoleUserId"];

        var userRepopsitory = IoC.Resolve<IUserLoginRepository>();
        var userId = (long)Session["UserId"];
        var loggedinUser = IoC.Resolve<IUserService>().GetUser(organizationRoleUserId).UserLogin;

        var isPasswordRepeated = IoC.Resolve<IPasswordChangelogService>().IsPasswordRepeated(loggedinUser.Id, txtNewPassword.Text);

        if (isPasswordRepeated)
        {
            var nonRepeatCount = IoC.Resolve<IConfigurationSettingRepository>().GetConfigurationValue(ConfigurationSettingName.PreviousPasswordNonRepetitionCount);
            var strJsCloseWindow = new System.Text.StringBuilder();
            strJsCloseWindow.Append("<script language = 'Javascript'>alert('New password can not be same as last " + nonRepeatCount + " password(s). Please enter a different password.'); </script>");
            ClientScript.RegisterStartupScript(typeof(string), "JSCode", strJsCloseWindow.ToString());
            return;
        }

        var userLoginService = IoC.Resolve<IUserLoginService>();
        var sessionContext = IoC.Resolve<ISessionContext>();
        userLoginService.ResetPassword(userId, txtNewPassword.Text, true, organizationRoleUserId, true);

        sessionContext.UserSession = userLoginService.GetUserSessionModel(userId);

        if (sessionContext.UserSession != null)
        {
            //string redirectPath = "/Users/Role/Switch?roleId=" +
            //                      IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.RoleId +
            //                      "&organizationId=" + IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.OrganizationId;

            var redirectPath = "/login";

            if (userRepopsitory.ReleaseUserLoginLock(userId))
            {

                ClientScript.RegisterStartupScript(typeof(Page), "jsRedirectAfterReset",
                    " alert('Your Password has been set. Redirecting to the Login Page!'); window.location ='" + redirectPath + "'; ", true);
            }


            sessionContext.LastLoggedInTime = loggedinUser.LastLogged.ToString();
            if (!((Request.QueryString["rstpwd"] != null) &&
                (Request.QueryString["rstpwd"] == "Y" || Request.QueryString["rstpwd"] == "'Y'")))
            {
                userRepopsitory.UpdateLoginStatus(sessionContext.UserSession.UserId, true);
            }
            else
            {
                return;
            }

            var browserName = Request.Browser.Browser + " " + Request.Browser.Version;
            var sessionId = Session.SessionID;

            var loginLog = IoC.Resolve<IUserLoginService>().SaveLoginInfo(loggedinUser.Id, loggedinUser.UserName, sessionId, browserName, Request.UserHostAddress, Request.UrlReferrer);

            sessionContext.UserSession.UserLoginLogId = loginLog.Id;

            //Response.RedirectUser(redirectPath);
        }
    }



    protected void btnSubmit_Click(object sender, ImageClickEventArgs e)
    {
        var userRepopsitory = IoC.Resolve<IUserLoginRepository>();

        if ((Request.QueryString["rstpwd"] != null) && (Request.QueryString["rstpwd"] == "Y" || Request.QueryString["rstpwd"] == "'Y'"))
        {
            ResetPassword();
            return;
        }

        if (Session["OrganizationRoleUserId"] == null || Session["UserId"] == null)
        {
            Session.Abandon();
            Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
            Response.RedirectUser("/login" + (!string.IsNullOrEmpty(ReturnUrl) ? "?returnUrl=" + ReturnUrl : ""));
            return;

        }
        var organizationRoleUserId = (long)Session["OrganizationRoleUserId"];
        var userId = (long)Session["UserId"];
        var loggedinUser = IoC.Resolve<IUserService>().GetUser(organizationRoleUserId).UserLogin;
        var isPasswordRepeated = IoC.Resolve<IPasswordChangelogService>().IsPasswordRepeated(loggedinUser.Id, txtNewPassword.Text);

        if (isPasswordRepeated)
        {
            var nonRepeatCount = IoC.Resolve<IConfigurationSettingRepository>().GetConfigurationValue(ConfigurationSettingName.PreviousPasswordNonRepetitionCount);
            var strJsCloseWindow = new System.Text.StringBuilder();
            strJsCloseWindow.Append("<script language = 'Javascript'>alert('New password can not be same as last " + nonRepeatCount + " password(s). Please enter a different password.'); </script>");
            ClientScript.RegisterStartupScript(typeof(string), "JSCode", strJsCloseWindow.ToString());
            return;
        }

        var userLoginService = IoC.Resolve<IUserLoginService>();
        userLoginService.ResetPassword(userId, txtNewPassword.Text, true, organizationRoleUserId, true);

        if ((Request.QueryString["FirstTimeLogin"] != null) && (Request.QueryString["FirstTimeLogin"] == "Y") && !loggedinUser.IsSecurityQuestionVerified)
        {
            userRepopsitory.SaveSecurityQuestionAnswer(userId, txtQuestion.Text, txtAnswer.Text);
        }
        var sessionContext = IoC.Resolve<ISessionContext>();
        var userloginService = IoC.Resolve<UserLoginService>();


        sessionContext.UserSession = userloginService.GetUserSessionModel(userId);

        if (sessionContext.UserSession != null)
        {

            string redirectPath = "/Users/Role/Switch?roleId=" +
                     sessionContext.UserSession.CurrentOrganizationRole.RoleId +
                     "&organizationId=" +
                     sessionContext.UserSession.CurrentOrganizationRole.OrganizationId;

            if (sessionContext.UserSession.CurrentOrganizationRole.GetSystemRoleId == (long)Roles.CallCenterRep && !string.IsNullOrEmpty(ReturnUrl))
                redirectPath = ReturnUrl;

            sessionContext.LastLoggedInTime = loggedinUser.LastLogged.ToString();
            userRepopsitory.UpdateLoginStatus(sessionContext.UserSession.UserId, true);

            var browserName = Request.Browser.Browser + " " + Request.Browser.Version;
            var sessionId = Session.SessionID;

            var loginLog = IoC.Resolve<IUserLoginService>().SaveLoginInfo(loggedinUser.Id, loggedinUser.UserName, sessionId, browserName, Request.UserHostAddress, Request.UrlReferrer);

            sessionContext.UserSession.UserLoginLogId = loginLog.Id;

            Response.RedirectUser(redirectPath);
            return;
        }

        Session.Abandon();
        Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
        Response.RedirectUser("/login" + (!string.IsNullOrEmpty(ReturnUrl) ? "?returnUrl=" + ReturnUrl : ""));

    }

    protected void btnCancel_Click(object sender, ImageClickEventArgs e)
    {
        Session.Abandon();
        Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
        Response.RedirectUser("/login" + (!string.IsNullOrEmpty(ReturnUrl) ? "?returnUrl=" + ReturnUrl : ""));
    }

}
