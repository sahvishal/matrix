using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Infrastructure.Users.Interfaces
{
    public interface ICallCenterRepService
    {
        CallCenterRep SaveCallCenterRep(CallCenterRep callCenterRep, long organizationId);
        CallCenterRep GetUser(long organizationRoleUserId);
    }
}