using Falcon.App.Core.CallQueues.Domain;
using Falcon.App.Core.CallQueues.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Falcon.App.Core.CallQueues
{
    public interface IPreAssessmentCustomerCallQueueCallAttemptRepository
    {
        PreAssessmentCustomerCallQueueCallAttempt GetCustomerCallQueueCallPreAssessmentAttemptIfCustomerLockedforAgent(long customerId, long createdBy, long eventId);
        PreAssessmentCustomerCallQueueCallAttempt Save(PreAssessmentCustomerCallQueueCallAttempt domain, bool refatch = true);
        PreAssessmentCustomerCallQueueCallAttempt GetByCallId(long callId);
        //CallQueueCustomer GetByCallIdAndcustomerId(long callId, long customerId);
        IEnumerable<PreAssessmentCallCustomer> GetForPreAssessmentReport(PreAssessmentReportFilter filter, int pageNumber, int pageSize, out int totalRecords);
        
    }
}
