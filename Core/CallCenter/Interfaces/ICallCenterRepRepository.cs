using System.Collections.Generic;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.CallCenter.Interfaces
{
    public interface ICallCenterRepRepository
    {
        CallCenterRep GetCallCenterRep(long callCenterCallCenterUserId);
        List<CallCenterRep> GetCallCenterReps(List<long> callCenterCallCenterUserIds);
        List<OrderedPair<long, string>> GetCallCenterRepIdNamePair();
        bool CanRefund(long callCenterRepId);
        List<string> GetCallCenterRepsAuthorizedToRefund();
        CallCenterRep Save(CallCenterRep callCenterRep, long organizationRoleUserId);
        bool CanChangeNotes(long callCenterRepId);
    }
}