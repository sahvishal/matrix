using System;
using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Medicare.ViewModels;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.Users
{
    public interface IUserLoginRepository
    {
        bool UniqueUserName(long userLoginId, string userName);
        UserLogin GetByUserName(string userName);
        UserLogin GetByUserId(long userId);
        UserLogin SaveUserLogin(UserLogin userLogin, long userId);
        UserLogin UpdateLoginStatus(long userLoginId, bool isSuccessfulLogin);
        Boolean ValidateUser(string userName, string password);
        string[] GetRolesForUser(string username);
        bool ReleaseUserLoginLock(long userId);
        SecureHash ResetPassword(long userLoginId, string password, bool userVerified = true);
        bool SaveSecurityQuestionAnswer(long userLoginId, string question, string answer);
        bool UpdateUserName(long userLoginId, string userName);
        bool UpdateUserLoginIsActiveStatus(long userLoginId, bool isActive);
        SecureHash ForceChangePassword(long userLoginId, string password, bool forceChangePassword);
        bool UpdateResetPasswordQueryString(long userLoginId, string resetPasswordQueryString);
        bool ForceUserToChangePassword(long userId);
        bool ForceUserToChangeQuestion(long userId);
        bool IsPasswordExpired(string userName, int daysInExpire);

        bool AssignUserLoginLock(long userId);
        bool IsUserLocked(long userId);
        double PasswordWillExpiredInDays(string userName, int daysInExpire);

        IEnumerable<UserLogin> GetUsersNotLoggedInWithinDays(int numberOfDays);
        MedicareUserCredentialModel[] GetUserForMedicareSync(DateTime exportFromTime);
    }
}