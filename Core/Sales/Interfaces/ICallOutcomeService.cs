using Falcon.App.Core.Sales.ViewModels;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.Sales.Interfaces
{
    public interface ICallOutcomeService
    {
        Customer SaveCallOutCome(CallOutComeEditModel eModel, long organizationRoleUserId);
        CallOutComeEditModel GetCallOutCome(long callId, long callQueueCustomerId, long customerId);
        void EndHealthPlanActiveCall(EndHealthPlanCallEditModel model, long orgRoleUserId);
    }
}
