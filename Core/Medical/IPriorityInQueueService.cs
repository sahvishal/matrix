using Falcon.App.Core.Medical.ViewModels;

namespace Falcon.App.Core.Medical
{
    public interface IPriorityInQueueService
    {
        bool UpdatePriorityinQueue(PriorityInQueueEditModel model, long createdByOrgRoleUserId);

        bool RemovePriorityInQueue(long eventCustomerResultId, long createdByOrgRoleUserId);
    }
}
