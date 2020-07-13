using System.Collections.Generic;
using Falcon.App.Core.CallCenter.ViewModels;
using Falcon.App.Core.CallQueues.Domain;

namespace Falcon.App.Core.CallQueues
{
    public interface ICustomerCallQueueCallAttemptRepository
    {
        CustomerCallQueueCallAttempt Save(CustomerCallQueueCallAttempt domain, bool refatch = true);
        CustomerCallQueueCallAttempt GetByCallQueueCustomerId(long callQueueCustomerId);
        IEnumerable<CustomerCallQueueCallAttempt> GetAllByCallQueueCustomerId(long callQueueCustomerId);
        CustomerCallQueueCallAttempt GetById(long callAttemptId);
        CustomerCallQueueCallAttempt GetByCallId(long callId);
        IEnumerable<CallSkippedReportEditModel> GetForCallSkippedReport(int pageNumber, int pageSize, CallSkippedReportFilter filter, out int totalRecords);
        CustomerCallQueueCallAttempt GetCustomerCallQueueCallAttemptIfCustomerLockedforAgent(long customerId, long createdBy);
    }
}
