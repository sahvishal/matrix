using System;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.Users
{
    public interface IUserLoginLogRepository
    {
        UserLoginLog GetCurrentLoggedInLogforUser(long userId);
        void UpdateLogOutTimeforUser(long userId, DateTime? loggedOutTime = null);
        DateTime? GetLastLoginTime(long userId);
        long GetAuthenticatedUserSessionIdUserId(string sessionId, long userId);
        string GetMedicareToken(long userLoginLogId);
    }
}
