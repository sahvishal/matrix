using System;
using System.Collections.Generic;
using Falcon.App.Core.Application;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.ViewModels;

namespace Falcon.App.Core.Medical.Interfaces
{
    public interface IEventCustomerResultRepository : IUniqueItemRepository<EventCustomerResult>
    {
        EventCustomerResult GetByCustomerIdAndEventId(long customerId, long eventId);
        // void ToggleFlagIsInterpretedforCustomer(long customerId, long eventId, bool turnOn);
        IEnumerable<CustomerResultStatusViewModel> GetTestResultStatusforEvent(long eventId);
        IEnumerable<EventCustomerResult> GetByEventId(long eventId);
        IEnumerable<EventCustomerResult> GetEventCustomerResults(int resultState, bool isPartial, int newResultState);

        IEnumerable<Test> GetCustomerTests(long eventcustomerId);
        void SetEventCustomerResultState(long eventId, long customerId, bool isChartSignedOff = true);
        void SetEventCustomerResultState(long eventCustomerResultId, IEnumerable<Test> customerTests, bool isChartSignedOff = true);

        IEnumerable<OrderedPair<long, int>> GetEventIdMissingCustomerResultCountPairForEventIds(IEnumerable<long> eventIds);
        IEnumerable<OrderedPair<long, int>> GetEventIdPreAuditPendingCountPairForEventIds(IEnumerable<long> eventIds);
        IEnumerable<OrderedPair<long, int>> GetEventIdReviewPendingCountPairForEventIds(IEnumerable<long> eventIds);
        IEnumerable<OrderedPair<long, int>> GetEventIdPostAuditPendingCountPairForEventIds(IEnumerable<long> eventIds);
        IEnumerable<OrderedPair<long, int>> GetEventIdResultsDeliveredCountPairForEventIds(IEnumerable<long> eventIds);
        IEnumerable<OrderedPair<long, int>> GetEventIdUnStableStateCountPairForEventIds(IEnumerable<long> eventIds);

        IEnumerable<OrderedPair<long, int>> GetEventIdEvaluatedCustomersCountForEventIds(IEnumerable<long> eventIds, bool filterForHospitalPartner = false);
        IEnumerable<OrderedPair<long, int>> GetResultSummaryIEventIdCustomersCountForEventIds(IEnumerable<long> eventIds, ResultInterpretation resultInterpretation, bool filterForHospitalPartner = false, int validityPeriod = 0);

        IEnumerable<EventCustomerResult> GetRecordsforRegeneration();
        IEnumerable<OrderedPair<long, long>> GetPdfGeneraredEventIdCustomerIdPair(IEnumerable<long> eventIds);
        void SetRecordforRegeneratingResultPacket(long eventId, long orgRoleId);
        bool SetRecordforRegeneratingResultPacket(long eventId, long customerId, long orgRoleId);
        IEnumerable<long> GetClinicalFormGeneratedEventIds(IEnumerable<long> eventId);

        void SetEventCustomerResultInterpPathwayRecomendation(long eventId, long customerId, long? resultInterpretation, long? pathwayRecommendation);

        IEnumerable<OrderedPair<long, long>> GetCriticalEventIdCustomerIdPairForPhysicianReview(IEnumerable<long> eventIds);
        IEnumerable<long> GetEventWithResultDeliveredRecords();
        CustomerResultStatusViewModel GetTestResultStatusforEventCustomer(long eventId, long customerId);
        IEnumerable<CustomerResultStatusViewModel> GetTestResultStatus(IEnumerable<long> eventCustomerIds);

        IEnumerable<EventCustomerResult> GetbyFilter(TechnicalLimitedScreeningCustomerListModelFilter filter, int pageNumber, int pageSize, out int totalRecords);

        IEnumerable<EventCustomerResult> GetByCriticalDataFilter(CustomerEventCriticalDataListModelFilter filter,
                                                                 int pageNumber, int pageSize, out int totalRecords);

        IEnumerable<EventCustomerResult> GetRecentCriticalAndUrgentCustomersForHospitalPartner(long hospitalPartnerId, int pageNumber, int pageSize, int validityPeriod = 0);

        IEnumerable<OrderedPair<long, long>> GetEvaluatedEventIdCustomerIdPair(IEnumerable<long> eventIds);
        IEnumerable<OrderedPair<long, long>> GetResultSummaryEventIdCustomerIdPair(IEnumerable<long> eventIds, ResultInterpretation resultInterpretation);

        //IEnumerable<CustomerEventTestState> GetTestPerformed(TestPerformedListModelFilter filter, int pageNumber, int pageSize, out int totalRecords);
        IEnumerable<VwGetTestPerformedReport> GetTestPerformed(TestPerformedListModelFilter filter, int pageNumber, int pageSize, out int totalRecords);
        IEnumerable<CustomerEventScreeningTests> GetCustomerEventScreeningTestsByIds(IEnumerable<long> ids);
        IEnumerable<OrderedPair<long, int>> GetCriticalEventIdCustomersCountForEventIds(IEnumerable<long> eventIds, ResultInterpretation resultInterpretation, bool filterForHospitalPartner = false, int validityPeriod = 0);
        IEnumerable<OrderedPair<long, int>> GetResultSummaryEventIdCustomersCountForHospitalPartner(long hospitalPartnerId, ResultInterpretation resultInterpretation, bool filterForHospitalPartner = false, int validityPeriod = 0);
        IEnumerable<OrderedPair<long, int>> GetCriticalEventIdCustomersCountForHospitalPartner(long hospitalPartnerId, ResultInterpretation resultInterpretation, bool filterForHospitalPartner = false, int validityPeriod = 0);

        IEnumerable<EventCustomerResult> GetEventCustomerResultsForResultReadyNotification(int days);
        IEnumerable<long> GetEventIdsForEventResultReadyNotiFication();
        bool CheckAllCustomerResultsReadyForEvent(long eventId);
        IEnumerable<EventCustomerResult> GetRecentCriticalAndUrgentCustomersForHospitalFacility(long hospitalFacilityId, int pageNumber, int pageSize, int validityPeriod = 0);
        IEnumerable<OrderedPair<long, int>> GetResultSummaryEventIdCustomersCountForHospitalFacility(long hospitalFacilityId, ResultInterpretation resultInterpretation, bool filterForHospitalPartner = false, int validityPeriod = 0);
        IEnumerable<OrderedPair<long, int>> GetCriticalEventIdCustomersCountForHospitalFacility(long hospitalFacilityId, ResultInterpretation resultInterpretation, bool filterForHospitalPartner = false, int validityPeriod = 0);

        IEnumerable<OrderedPair<long, int>> GetResultSummaryEventIdCustomersCountForEventIdsAndHospitalFacility(IEnumerable<long> eventIds, ResultInterpretation resultInterpretation, long hospitalFacilityId,
            bool filterForHospitalPartner = false, int validityPeriod = 0);

        IEnumerable<OrderedPair<long, int>> GetCriticalEventIdCustomersCountForEventIdsAndHospitalFacility(IEnumerable<long> eventIds, ResultInterpretation resultInterpretation, long hospitalFacilityId,
            bool filterForHospitalPartner = false, int validityPeriod = 0);

        IEnumerable<EventCustomerResult> GetEventCustomerResultsToFax(int oldFlowResultState, int newFlowResultState, bool isPartial, DateTime toTime, DateTime? fromTime, long accountId, string corporateTag, bool considerRegeneration = false, string[] customTags = null, bool includeCustomerWithTag = false, bool considerEventDate = false, DateTime? eventDate = null, DateTime? toEventDate = null, DateTime? stopSendingPdftoHealthPlanDate = null);
        bool IsCustomerScreeningTestResultExists(long eventCustomerResultId);

        bool CheckAnyCustomerResultsReadyAndSignedPartnerRelease(long eventId);

        IEnumerable<EventCustomerResult> GetEventCustomerResultsByEventIdTestId(long eventId, long testId, string tag);
        bool Update(long eventCustomerResultId, bool? isFasting);

        IEnumerable<EventCustomerResult> GetRecentCriticalAndUrgentCustomersForCorporateAccountCoordinator(long accountId, int pageNumber, int pageSize);
        IEnumerable<long> GetEventIdsForCorporateAccountEventResultReadyNotiFication(DateTime cutOfDate);

        IEnumerable<EventCustomerResult> GetForCrosswalkLabReport(int oldResultFlowResultState, int newResultFlowResultState, bool isPartial, DateTime toTime, DateTime? fromTime, long accountId, string corporateTag, bool considerRegeneration = false, string[] customTags = null);
        IEnumerable<CustomerEventScreeningTests> GetByEventCustomerResultAndTestIds(IEnumerable<long> eventCustomerIds, long[] testIds);
        IEnumerable<OrderedPair<long, long>> GetCustomerEventScreeningTestIdFileIdPairs(IEnumerable<long> customerEventScreeningTestIds);
        IEnumerable<CustomerEventScreeningTests> GetCustomerEventScreeningTestsByEventCustomerResultIds(IEnumerable<long> eventCustomerResultIds);

        IEnumerable<EventCustomerResult> GetEventCustomerResultsByCustomerIds(long oldResultFlowResultState, long newResultFlowResultState, bool isPartial, long accountId, IEnumerable<long> customerIds, DateTime cutOfDate);
        IEnumerable<EventCustomerResult> GetEventCustomerResultsByMrnCustomerIds(long oldResultFlowResultState, long newResultFlowResultState, bool isPartial, long accountId, IEnumerable<long> customerIds, DateTime cutOfDate);

        IEnumerable<EventCustomerResult> GetEventCustomerResultsbyEventDate(int resultState, bool isPartial, DateTime toDate, DateTime fromDate, long accountId, string tag);

        IEnumerable<EventCustomerResult> GetPatientsByResultStateAndDate(long resultState, DateTime fromDate, DateTime toDate);

        // void SetEventCustomerRevertedToEvaluation(long eventId, long customerId, bool isRevertedToEvaluation);
        void SetEventCustomerPennedBack(long eventId, long customerId, bool isPennedBack);

        IEnumerable<EventCustomerResult> GetEventCustomerResultsForCustomerIds(int resultState, bool isPartial, DateTime toTime, DateTime? fromTime, long accountId, long[] customerIds, bool considerRegeneration = false, string[] customTags = null,
            bool includeCustomerWithTag = false, bool considerEventDate = false, DateTime? eventDate = null, DateTime? toEventDate = null);

        IEnumerable<EventCustomerResult> GetEventCustomerResultsByIdsAndResultState(IEnumerable<long> eventCustomerResultIds, int oldFlowResultState, int newFlowResultState, bool isPartial);
        IEnumerable<OrderedPair<long, long>> GetTestNotPerformedTestsByReason(long eventCustomerId, long testNotPerfomredReasonId);

        IEnumerable<OrderedPair<long, string>> GetLabKitValueByEventCustomerResultId(IEnumerable<long> eventCustomerResultIds, long testId, long readingLableId);
        IEnumerable<EventCustomerResult> GetLabKitDistributionReport(BiWeeklyMicroAlbuminFobtReportModelFilter filter, int pageNumber, int pageSize, out int totalRecords);
        IEnumerable<EventCustomerResult> GetEventCustomerResultByResultState(int resultState, bool isPartial, DateTime resultFlowChangeDate);
        IEnumerable<EventCustomerResult> GetEventCustomerResultsForResultReadyNotification(int oldResultState, int newResultState, bool isPartial);
        IEnumerable<EventCustomerResult> GetResultsNpVerified(int resultState, bool isPartial, DateTime resultFlowChangeDate);
        IEnumerable<EventCustomerResult> GetEventCustomerResultDelivered(DateTime toTime, DateTime fromTime, long accountId, string corporateTag,
             DateTime? eventDate, bool includeCustomerWithTag, string[] customTags = null, DateTime? stopSendingPdftoHealthPlanDate = null);

        IEnumerable<EventCustomerResult> GetEventCustomerResultForInvoicing(DateTime resultFlowChangeDate);
        IEnumerable<OrderedPair<long, long>> GetEawvTestNotPerformedReason(IEnumerable<long> eventCustomerResultIds);
        IEnumerable<EventCustomerResult> GetEvaluatedByPhysicianEventCustomerResult();
        bool UpdateIsIpResultGenerated(long eventCustomerResultId, bool isIpResultGenerated);
        IEnumerable<EventCustomerResult> GetEventCustomerResultByTestIds(IEnumerable<long> testIds, DateTime startDate, DateTime endDate);
        IEnumerable<string> GetMediaByEventIdAndCustomerId(long eventId, long customerId, IEnumerable<long> testIds);

        IEnumerable<OrderedPair<string, long>> GetMediaAndTestIdByEventIdAndCustomerId(long eventId, long customerId, IEnumerable<long> testIds);

    }
}