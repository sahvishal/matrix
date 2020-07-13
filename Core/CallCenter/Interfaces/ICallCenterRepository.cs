using System.Collections.Generic;
using Falcon.App.Core.CallCenter.Domain;
using Falcon.App.Core.CallCenter.ViewModels;

namespace Falcon.App.Core.CallCenter.Interfaces
{
    public interface ICallCenterRepository
    {
        bool CreateCallNotificationfortheCallStarted(long callId, long notificationId);
        int CreateCallRecordforCallStarted(Call call);
        List<Call> GetOutboundCallQueue(long callCenterRepId);
        int UpdateCallStatusforCallFinished();
        long GetProspectCustomerIdifCallforLeadConversion(long callId);
        bool IsCallTypeOutbound(long callId);
        bool BindCallToProspectCustomer(long callId, long prospectCustomerId);
        bool BindCallToProspectCustomerForCallQueue(long callId, long prospectCustomerId);
        bool IsCallTiedToTheProspectCustomer(long callId, long prospectCustomerId);

        long[] GetCallCenterAgentsForConversionReport(AgentConversionReportFilter filter, int pageNumber, int pageSize, out int totalRecords);
        IEnumerable<OutboundCall> GetoutboundCallsForAgents(AgentConversionReportFilter filter, long[] agentIds);
    }
}
