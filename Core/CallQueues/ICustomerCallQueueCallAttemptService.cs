using System.Collections.Generic;
using Falcon.App.Core.CallCenter.ViewModels;
using Falcon.App.Core.CallQueues.Domain;

namespace Falcon.App.Core.CallQueues
{
    public interface ICustomerCallQueueCallAttemptService
    {
        void SetReadAndUnderstoodNotes(long callAttemptId);
        IEnumerable<CallCentreAgentQueueListViewModel> CallCenterAgentDashboardData(CallCentreAgentQueueFilter filter, int pageNumber, int pageSize, out int totalRecords);
        void SetCallIdCallAttempt(long attemptId, long callId);
        long CustomerCountForHealthPlanCriteria(HealthPlanCallQueueCriteria criteria, IEnumerable<CallQueue> callQueues, bool isForDashboard = false);
    }
}