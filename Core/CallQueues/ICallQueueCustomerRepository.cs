using Falcon.App.Core.CallCenter.ViewModels;
using Falcon.App.Core.CallQueues.Domain;
using Falcon.App.Core.CallQueues.Enum;
using Falcon.App.Core.CallQueues.ViewModels;
using System;
using System.Collections.Generic;
using Falcon.App.Core.Scheduling.Domain;

namespace Falcon.App.Core.CallQueues
{
    public interface ICallQueueCustomerRepository
    {
        CallQueueCustomer Save(CallQueueCustomer callQueueCustomer, bool refatch = true);
        CallQueueCustomer GetById(long callQueueCustomerId);
        bool IsCallQueueExist(long callQueueId, long prospectId, long customerId, long? eventId, int noofdaysToIncludeRemoved);
        IEnumerable<CallQueueCustomer> GetCallQueueCustomerByCallQueueId(long callQueueId);
        IEnumerable<long> GetCallQueueCustomerIdsByCallQueueIdAndStatus(long callQueueId, CallQueueStatus status);
        IEnumerable<CallQueueCustomer> GetCallQueueCustomers(long callQueueId, long assignedToOrgRoleUserId, int pageNumber, int pageSize, out int totalRecords);
        void UpdateOtherCustomerStatus(long customerId, long prospectCustomerId, CallQueueStatus status, long updatedBy);
        void UpdateOtherCustomerAttempt(long callQueueCustomerId, long customerId, long prospectCustomerId, long updatedBy, DateTime callDate, bool isRemovedFromQueue, long callQueueId, long? callOutcomeId = null,
            DateTime? contactedDate = null, bool isForParsing = false, string disposition = "");
        void UpdateAssignment(IEnumerable<long> callQueueCustomerIds, long assignedToOrgRoleUserId);
        IEnumerable<OrderedPair<long, long>> GetQueueIdTotalCustomersInQueuePairs(IEnumerable<long> callQueueIds);
        IEnumerable<OrderedPair<long, long>> GetQueueIdTotalCustomersPairs(IEnumerable<long> callQueueIds);
        IEnumerable<OrderedPair<long, long>> GetQueueIdTotalCustomersContactedPairs(IEnumerable<long> callQueueIds);

        IEnumerable<CallQueueCustomerStats> GetTotalCallQueueCustomerStats(IEnumerable<long> callQueueIds);
        IEnumerable<CallQueueCustomerStats> GetContactedCallCustomersStats(IEnumerable<long> callQueueIds);
        IEnumerable<CallQueueCustomer> PullBackCallQueueCustomer(int interval);
        void DeleteForInActiveCallQueueCriteria(long callQueueId);

        IEnumerable<CallQueueCustomer> GetCallQueueCustomerForZipCode(OutboundCallQueueFilter filter, int pageNumber, int pageSize, out int totalRecords);
        IEnumerable<CallQueueCustomer> GetCallQueueCustomerForFillEvents(OutboundCallQueueFilter filter, int pageNumber, int pageSize, long criteriaId, out int totalRecords);
        IEnumerable<CallQueueCustomer> GetbyIds(IEnumerable<long> ids);
        void DeletePastEventCallQueue();

        IEnumerable<CallQueueCustomer> GetCallQueueCustomerForUpsellAndConfirmation(OutboundCallQueueFilter filter, int pageNumber, int pageSize, CallQueue callQueue, long criteriaId, out int totalRecords);
        void UpdateCallQueueCustomerStatusByCallQueueId(long callQueueCustomerId, CallQueueStatus status);
        IEnumerable<CallQueueCustomer> GetCallQueueCustomerByEventId(long eventId, long callQueueId, int noofdaysToIncludeRemoved);
        CallQueueCustomer GetByCallQueueIdCustomerIdEventId(long callQueueId, long prospectId, long customerId, long eventId);

        IEnumerable<CallQueueCustomer> GetCallQueueCustomerByHealthPlanId(long healthPlanId, long callQueueId);

        IEnumerable<CallQueueCustomer> GetOutboundCallRoundCallQueue(OutboundCallQueueFilter filter, int pageNumber, int pageSize, CallQueue callQueue, long criteriaId, out int totalRecords);

        IEnumerable<CallQueueCustomer> GetCallQueueCustomerForHealthPlanFillEvents(OutboundCallQueueFilter filter, int pageNumber, int pageSize, long criteriaId, CallQueue callQueue, out int totalRecords, bool isNormalExecution = true);

        IEnumerable<CallQueueCustomer> GetNoShowCallQueueCustomer(OutboundCallQueueFilter filter, int pageNumber, int pageSize, long criteriaId, out int totalRecords);

        IEnumerable<CallQueueCustomer> GetZipRadiusCallQueueCustomer(OutboundCallQueueFilter filter, int pageNumber, int pageSize, long criteriaId, out int totalRecords);

        IEnumerable<CallQueueCustomer> GetUncontactedCallQueueCustomers(OutboundCallQueueFilter filter, int pageNumber, int pageSize, long criteriaId, int neverBeenCalledInDays, int noPastAppointmentInDays, out int totalRecords);
        bool DeleteCallQueueCustomersHasNotBeenCalled(long callQueueId);

        IEnumerable<CallQueueCustomer> GetCallQueueCustomersBuCustomerIds(IEnumerable<long> customerIds, long callqueueId);

        IEnumerable<CallQueueCustomer> GetCallQueueCustomerByCampaignIdAndHealthPlanId(long campaignId, long healthPlanId, long callQueueId);

        IEnumerable<CallQueueCustomer> GetMailRoundCallqueueCustomer(OutboundCallQueueFilter filter, int pageNumber, int pageSize, long criteriaId, CallQueue callQueue, out int totalRecords, bool isNormalExecution = true);

        IEnumerable<CallQueueCustomer> GetLanguageBarrierCallQueueCustomer(OutboundCallQueueFilter filter, int pageNumber, int pageSize, long criteriaId, CallQueue callQueue, out int totalRecords, bool isNormalExecution = true);

        bool IsCallQueueCustomerCalledToday(long customerId, long callQueueCustomerId);

        CallQueueEstimatedCustomerReportModel GetCallQueueEstimatedNumbers(OutboundCallQueueFilter filter);

        void UpdateCallqueueCustomerByCustomerId(CallQueueCustomerCallDetailsEditModel model, long customerId, bool setOtherCustomerStatus = true);
        void UpdateCustomerField(CallQueueCustomerPubViewModel customer);
        void UpdateFutureAppointment(FutureAppointmentFlagViewModel model);
        void UpdateCancelAppointment(CancelAppointmentFlagViewModel model);
        void ReleaseCallQueueCustomerFromLock(long customerId, long callQueueCustomerId);

        IEnumerable<CallQueueCustomer> GetByHealthPlanIdAndCallQueueId(long healthPlanId, long callQueueId);

        IEnumerable<CallQueueCustomer> GetConfirmationCallQueueCustomer(OutboundCallQueueFilter filter, int pageNumber, int pageSize, long criteriaId, CallQueue callQueue, out int totalRecords, bool isNormalExecution = true);

        CallQueueCustomer GetCallQueueCustomerByCustomerId(long customerId, string callQueueCategoryName);
        IEnumerable<CallQueueCustomerCriteraAssignmentForStats> GetCallQueueCustomersForRejectedList(IEnumerable<long> customerIds, long campaignId, long healthPlanId);
        IEnumerable<long> GetAccountZip(long healthPlanId);
        CallQueueCustomer GetCallQueueCustomerByCustomerIdAndHealthPlanId(long customerId, long healthPlanId, string category);

        long GetCallQueueCustomerCountForHealthPlanFillEvents(OutboundCallQueueFilter filter, bool isForDashboard = false);
        long GetMailRoundCallqueueCustomerCount(OutboundCallQueueFilter filter, bool isForDashboard = false);
        long GetLanguageBarrierCallQueueCustomerCount(OutboundCallQueueFilter filter, bool isForDashboard = false);
        long GetConfirmationCallQueueCustomerCount(OutboundCallQueueFilter filter);

        void UpdateConfirmationQueueCustomers(long customerId, long eventCustomerId, long callId = 0);

        IEnumerable<CallQueueCustomer> GetForConfirmationReport(ConfirmationReportFilter filter, int pageNumber, int pageSize, out int totalRecords);
        bool UpdateCallQueueCustomerEligibility(long customerId, bool? eligibility);

        IEnumerable<long> GetMailRoundCustomerIdsForMatrixReport(OutboundCallQueueFilter filter, CallQueue callQueue, int pageNumber, int pageSize, out int totalRecords);
        IEnumerable<long> GetFillEventCustomerIDsForMatrixReport(OutboundCallQueueFilter filter, CallQueue callQueue, int pageNumber, int pageSize, out int totalRecords);
        IEnumerable<long> GetLanguageBarrierCustomerIDsForMatrixReport(OutboundCallQueueFilter filter, CallQueue callQueue, int pageNumber, int pageSize, out int totalRecords);

        IEnumerable<long> GetHealthPlanEventsForCriteria(OutboundCallQueueFilter filter);
        CallQueueCustomer GetCallQueueCustomerByCustomerIdForAppointmentConfirmation(long customerId, long callQueueId, long eventId);

        IEnumerable<CallQueueCustomer> GetMailRoundCustomersForGms(OutboundCallQueueFilter filter, int pageNumber, int pageSize, long criteriaId, CallQueue callQueue,
            out int totalRecords, bool isNormalExecution = true);

        bool UpdateCallQueueCustomerForNoShow(long customerId, DateTime? appointmentDate, DateTime? noshowDateTime, long callQueueToExcludeFromUpdate);

        CallQueueCustomer GetCallQueueCustomerByCustomerIdForGms(long customerId, string callQueueCategoryName);

        void UpdateConfirmationQueueCustomersOnReschedule(EventCustomer eventCustomer, DateTime appointmentDateTime, DateTime appointmentwithTimeZone);
        bool UpdateCallQueueCustomerTargeted(long customerId, int targetedYear, bool? isTargeted);
        
        bool UpdateCallQueueCustomerProductType(long customerId, long? productTypeId);
    }
}
