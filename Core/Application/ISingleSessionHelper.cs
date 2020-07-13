namespace Falcon.App.Core.Application
{
    public interface ISingleSessionHelper
    {
        void CreateAndStoreSessionToken(string userName, string sessionToken);
        bool ValidatingUserSession(string userName, string sessionToken);
        void RemoveUserSessionFromCache(string userName, string sessionId);
        bool IsUserExist(string userName);
    }
}