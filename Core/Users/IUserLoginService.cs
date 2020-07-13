using System;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.ViewModels;

namespace Falcon.App.Core.Users
{
    public delegate void UserLoginLocked();
    public delegate void UserLoginValidation(long userLoginId, bool isSuccess);

    public interface IUserLoginService
    {
        event UserLoginValidation OnLoginSuccessful;
        event UserLoginValidation OnLoginUnuccessful;
        event UserLoginLocked OnLoginAccountLocked;

        void ValidateUser(string userName, string password);

        UserSessionModel GetUserSessionModel(string userName);

        UserSessionModel SwitchOrganizationRole(UserSessionModel currentUserSession, long switchToRoleId,
                                                long switchToOrganizationId);

        UserSessionModel GetUserSessionModel(long userId);

        bool ForceChangePassword(long userLoginId, string password, bool forceChangePassword, long orgRoleUserId, bool updatePasswordLog);
        bool ResetPassword(long userLoginId, string password, bool userVerified, long orgRoleUserId, bool updatePasswordLog);

        UserLoginLog SaveLoginInfo(long userId, string userName, string browserSession, string browserName, string sessionIp, Uri refferedUrl);
        UserLoginLog GetLatestUserLogin(long userId);
    }
}
