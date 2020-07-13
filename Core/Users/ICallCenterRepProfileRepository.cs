using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.Users
{
    public interface ICallCenterRepProfileRepository
    {
        CallCenterRepProfile Get(long orgRoleUserId);

        void Save(CallCenterRepProfile callCenterRepProfile);
    }
}
