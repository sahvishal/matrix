using System.Collections.Generic;
using Falcon.App.Core.CallCenter.Domain;
using Falcon.App.Core.CallQueues.Domain;
using Falcon.App.Core.CallQueues.ViewModels;

namespace Falcon.App.Core.CallQueues
{
    public interface ICallQueueCustomerCallRepository
    {
        IEnumerable<CallQueueCustomerCall> GetByCallQueueCustomerIds(IEnumerable<long> callQueueCustomerIds);
        void Save(CallQueueCustomerCall domain, bool refatch = true);

        IEnumerable<CallQueueCustomerCallDetails> GetHealthPlanCallQueueCallReports(CallQueueSchedulingReportFilter filter, int pageNumber, int pageSize, out int totalRecords);

        long GetCallQueueCustomerIdByCallId(long callId);
    }
}
