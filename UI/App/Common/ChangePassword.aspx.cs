using System;
using System.Web.UI;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Users;
using Falcon.App.DependencyResolution;

public partial class App_Common_ChangePassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtPassword.Text = "";
        }
    }

    private void ReleaseUserLoginLock(long userId)
    {
        if (userId > 0)
        {
            var userLoginRepository = IoC.Resolve<IUserLoginRepository>();
            userLoginRepository.ReleaseUserLoginLock(userId);
        }
    }

    protected void ibtnChange_Click(object sender, ImageClickEventArgs e)
    {
        bool isLockedUser = false;
        bool releaseLock = true;
        long userId = 0;
        var userLoginRepository = IoC.Resolve<IUserLoginRepository>();

        if (Request.QueryString["UserEmail"] != null)
        {
            if (Request.QueryString["UserID"] != null)
                userId = Convert.ToInt32(Request.QueryString["UserID"]);

            var userlogin = userLoginRepository.GetByUserId(userId);
            var sessionContext = IoC.Resolve<ISessionContext>();
            if (userlogin != null && userlogin.IsActive)
            {
                var passwordChangeLogService = IoC.Resolve<IPasswordChangelogService>();
                var configurationSettingRepository = IoC.Resolve<IConfigurationSettingRepository>();
                var nonRepeatCount = configurationSettingRepository.GetConfigurationValue(ConfigurationSettingName.PreviousPasswordNonRepetitionCount);
                
                if (userlogin.Locked) isLockedUser = true;

                var currentRole = sessionContext.UserSession.CurrentOrganizationRole.GetSystemRoleId;
                var isSamePassword = currentRole == (long)Roles.Customer && passwordChangeLogService.IsPasswordRepeated(userId, txtPassword.Text);

                if (isSamePassword)
                {
                    var strJsCloseWindow = new System.Text.StringBuilder();
                    strJsCloseWindow.Append("<script language = 'Javascript'>alert('New password can not be same as last " + nonRepeatCount + " password(s). Please enter a different password.'); </script>");
                    ClientScript.RegisterStartupScript(typeof(string), "JSCode", strJsCloseWindow.ToString());
                    return;
                }
            }
        }
        if (Request.QueryString["UserID"] != null)
        {
            var sessionContext = IoC.Resolve<ISessionContext>();
            var userLoginService = IoC.Resolve<IUserLoginService>();

            var currentRole = sessionContext.UserSession.CurrentOrganizationRole.GetSystemRoleId;
            var passwordUpdated = currentRole == (long)Roles.Customer ? userLoginService.ForceChangePassword(userId, txtPassword.Text, false, sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId, true) : userLoginService.ForceChangePassword(userId, txtPassword.Text, true, sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId, false);

            var customerRepository = IoC.Resolve<ICustomerRepository>();
            var customer = customerRepository.GetCustomerByUserId(userId);

            if (!string.IsNullOrEmpty(customer.Tag))
            {
                var corporateAccountRepository = IoC.Resolve<ICorporateAccountRepository>();
                var account = corporateAccountRepository.GetByTag(customer.Tag);
                if (account != null)
                    releaseLock = account.AllowCustomerPortalLogin;
            }
            // UnLock User
            if (isLockedUser && releaseLock) ReleaseUserLoginLock(userId);

            if (passwordUpdated)
            {
                var strJsCloseWindow = new System.Text.StringBuilder();
                strJsCloseWindow.Append("<script language = 'Javascript'>alert('Password updated successfully.'); window.close(); </script>");
                ClientScript.RegisterStartupScript(typeof(string), "JSCode", strJsCloseWindow.ToString());

            }
            else
            {
                var strJsCloseWindow = new System.Text.StringBuilder();
                strJsCloseWindow.Append("<script language = 'Javascript'>alert('Error in updating password. Please try again later.'); </script>");
                ClientScript.RegisterStartupScript(typeof(string), "JSCode", strJsCloseWindow.ToString());
            }
        }
    }

}


