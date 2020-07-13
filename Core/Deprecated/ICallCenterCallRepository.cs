using System;
using System.Collections.Generic;
using Falcon.App.Core.CallCenter.Domain;
using Falcon.App.Core.CallQueues.ViewModels;
using Falcon.App.Core.InboundReport.ViewModels;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.CallCenter.Enum;

namespace Falcon.App.Core.Deprecated
{
    public interface ICallCenterCallRepository
    {
        string GetCallStarttime(long callId);
        bool UpdateCallCenterCallStatus(string status, long callId);
        bool UpdateCalledCustomerId(long customerId, long callId, long? healthPlanId, long ? ProductTypeId);
        bool UpdatePromoCode(string sourceCode, long callId);
        bool UpdateCallEnd(DateTime endTime, long callId);
        bool UpdateEventforaCall(long eventId, long callId);
        IEnumerable<Call> GetCallDetails(IEnumerable<Customer> customers);
        IEnumerable<Call> GetByIds(IEnumerable<long> ids);
        Call Save(Call call);
        Call GetById(long id);
        IEnumerable<CallQueueCustomerCallViewModel> GetCallsForCallQueueCustomer(long callId, long customerId, long prospectCustomerId);
        IEnumerable<CallQueueCustomerCallViewModel> GetCallForCallQueueCustomerList(IEnumerable<long> customerIds, IEnumerable<long> prospectCustomerIds);

        IEnumerable<CallQueueCustomerCallViewModel> GetCallForHealtPlanCallQueueCustomer(IEnumerable<long> customerIds, string customTags);
        IEnumerable<Call> GetOutreachCallQueueCustomer(OutreachCallReportModelFilter filter, int pageNumber, int pageSize, out int totalRecords);
        IEnumerable<Call> GetCallDetails(IEnumerable<long> customerIds);

        IEnumerable<Call> GetCallDetailsForOutreachCalls(IEnumerable<long> customerIds);

        IEnumerable<long> GetForResponseVendorReport(ResponseVendorReportFilter filter, int pageNumber, int pageSize, out int totalRecords);
        IEnumerable<long> GetForInterviewReport(InterviewInboundFilter filter, int pageNumber, int pageSize, out int totalRecords);

        long GetOutreachCallQueueCallsForLastSevenDays(DateTime fromDate, DateTime toDate);

        IEnumerable<Call> GetCallsForResponseVendorReport(ResponseVendorReportFilter filter, IEnumerable<long> customerIds);
        IEnumerable<Call> GetCallsForInterviewReport(InterviewInboundFilter filter, IEnumerable<long> customerIds);
        IEnumerable<long> GetCustomerIdsMarkedIncorrectPhoneNumber(IEnumerable<long> customerIds, DateTime lastTranctionDate);
        IEnumerable<Call> GetCallsByCustomerIds(IEnumerable<long> customerIds, DateTime? fromDate = null, DateTime? toDate = null, bool? isOutbound = null, CallAttemptFilterStatus callAttemptFilter = CallAttemptFilterStatus.All);
        IEnumerable<Call> GetCallCenterCallQueueCustomer(CallCenterCallReportModelFilter filter, int pageNumber, int pageSize, out int totalRecords);
        IEnumerable<Call> GetCallByCustomerId(IEnumerable<long> customerIds, DateTime startDate, bool excludeConfirmationCall);
        IEnumerable<Call> GetCallByCustomerIdAndCallQueue(IEnumerable<long> customerIds, string category);

        bool UpdateCallersPhoneNumber(long callId, string patientPhoneNumber);
        void SaveCallDispositionAndIsContacted(long callId, string disposition, long callQueueCustomerId);
        Call GetSecondLastCall(long customerId, long excludeLastCallId);
         bool UpdateCallCenterCallEvent(long eventId, long callId);
         IEnumerable<Call> GetCallByCustomerIdAndCallQueuePreAssessment(IEnumerable<long> customerIds, string category);
    }
}
