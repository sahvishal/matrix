using System.Collections.Generic;
using Falcon.App.Core.CallQueues.Domain;
using Falcon.App.Core.CallQueues.ViewModels;

namespace Falcon.App.Core.CallQueues
{
    public interface ICallQueueRepository
    {
        CallQueue GetById(long id);
        IEnumerable<CallQueue> GetByIds(IEnumerable<long> ids, bool isManual = true, bool isHealthPlan = false);
        IEnumerable<CallQueue> GetAll(bool isManual = true, bool isHealthPlan = false);
        CallQueue Save(CallQueue callQueue);

        IEnumerable<CallQueue> GetCallQueueList(CallQueueListModelFilter filter, int pageNumber, int pageSize, out int totalRecords);
        IEnumerable<CallQueue> GetByAssignedToOrgRoleUserId(long assignedToOrgRoleUserId);
        void SetCallQueueIsActiveState(long callQueueId, bool isActive);
        CallQueue GetCallQueueByCategory(string category);
        void SetCallQueueIsGenerated(long callQueueId, bool isQueueGenerated);
    }
}
