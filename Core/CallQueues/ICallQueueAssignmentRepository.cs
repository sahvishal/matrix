using System.Collections.Generic;
using Falcon.App.Core.CallQueues.Domain;
using Falcon.App.Core.CallQueues.ViewModels;

namespace Falcon.App.Core.CallQueues
{
    public interface ICallQueueAssignmentRepository
    {
        IEnumerable<CallQueueAssignment> GetByCallQueueId(long callQueueId);
        void Save(IEnumerable<CallQueueAssignment> callQueueAssignments, long callQueueId);
        IEnumerable<CallQueueAssignment> GetByCallQueueIds(IEnumerable<long> callQueueIds);
        IEnumerable<CallQueueAssignment> GetCallQueueAssignment(CallQueueReportModelFilter filter, int pageNumber, int pageSize, out int totalRecords);
    }
}
