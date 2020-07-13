using System;
using System.Collections.Generic;
using Falcon.App.Core.Application;
using Falcon.App.Core.Finance.Impl;
using Falcon.App.Core.Finance.ViewModels;
using Falcon.App.Core.InboundReport.ViewModels;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Operations.ViewModels;
using Falcon.App.Core.Sales.ViewModels;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Scheduling.Enum;

namespace Falcon.App.Core.Scheduling.Interfaces
{
    public interface IEventCustomerRepository : IUniqueItemRepository<EventCustomer>
    {
        bool UpdateMaketingSource(long eventCustomerId, string marketingSource);
        //bool UpdateSourceCode(long eventCustomerId, string sourceCode, OrganizationRoleUser byOrganizationRoleUser); - removed by yasir on 3/12 after database cleanup
        bool UpdateHippaStatus(long eventCustomerId, short hippaStatus);
        bool UpdateShowUp(long eventCustomerId, bool isNoShowUp, DateTime? noShowDate);
        bool UpdateAppointmentId(long eventCustomerId, long? appointmentId = null);
        string UpdateCheckInCheckOutTime(long eventCustomerId, long appointmentId, DateTime? checkInTime, DateTime? checkOutTime);
        string ClearCheckInCheckOutTime(long eventCustomerId, long appointmentId);

        EventMetricsViewData GetEventCustomerFlagMetrics(EventMetricsViewData eventMetricsViewData, long eventId);
        List<int> GetHipaaRatio(long eventId);

        bool UpdateFirstRegistrationMarketingSource(long customerId, string marketingSource);
        EventCustomer GetRegisteredEventForUser(long customerId, long eventId);
        EventCustomer GetCancelledEventForUser(long customerId, long eventId);
        List<EventCustomer> GetEventCustomersRegisteredByCallCenterRep(long callCenterCallCenterUserId,
                                                                       DateTime startDate, DateTime endDate);

        IEnumerable<EventCustomer> GetEventCustomersbyRegisterationDate(int pageNumber, int pageSize, AppointmentsBookedListModelFilter filter, out int totalRecords);

        IEnumerable<EventCustomer> GetEventCustomersforPatientSchedule(int pageNumber, int pageSize, CustomerScheduleModelFilter filter, out int totalRecords);

        IEnumerable<EventCustomer> GetNoShowEventCustomers(int pageNumber, int pageSize, NoShowCustomerModelFilter filter, out int totalRecords);

        IEnumerable<EventCustomer> GetEventCustomerswithCdPurchase(int pageNumber, int pageSize,
                                                                   CdImageStatusModelFilter filter, out int totalRecords);

        DateTime GetEventCustomerDataForNotification(long orgRoleUserId);
        IEnumerable<EventCustomer> GetbyEventId(long eventId);
        EventCustomer Get(long eventId, long customerId);
        IEnumerable<EventCustomer> GetbyCustomerId(long customerId);
        bool UpdatePartnerReleaseStatus(long eventCustomerId, short partnerReleaseStatus);

        IEnumerable<EventCustomer> GetEventCustomersWithCdPurchase(int pageNumber, int pageSize,
                                                                   CustomerCdConentTrackingModelFilter filter, out int totalRecords);

        DateTime? GetPreviousAttendedEventDate(long eventId, long customerId, DateTime eventDate);

        IEnumerable<EventCustomer> EventCustomersForHospitalPartner(int pageNumber, int pageSize, HospitalPartnerCustomerListModelFilter filter, out int totalRecords, int normalValidityPeriod = 0, int abnormalValidityPeriod = 0, int criticalValidityPeriod = 0);

        IEnumerable<EventCustomer> SearchCustomersForHospitalPartner(int pageNumber, int pageSize,
                                                                       HospitalPartnerCustomerListModelFilter filter, out int totalRecords, int normalValidityPeriod = 0, int abnormalValidityPeriod = 0, int criticalValidityPeriod = 0);

        IEnumerable<EventCustomer> GetEventCustomersForAuthorization(long eventId);

        IEnumerable<EventCustomer> GetEventCustomersForDeferredRevenue(int pageNumber, int pageSize,
                                                                       DeferredRevenueListModelFilter filter,
                                                                       out int totalRecords);

        IEnumerable<EventCustomer> GetEventCustomersForAggregateResultSummary(int pageNumber, int pageSize,
                                                                        HospitalPartnerCustomerListModelFilter filter,
                                                                        out int totalRecords);

        bool DeleteEventCustomer(long eventCustomerId);

        IEnumerable<EventCustomer> GetCancelledEventCustomers(int pageNumber, int pageSize, CancelledCustomerModelFilter filter, out int totalRecords);

        EventCustomer GetEventCustomerByOrderId(long orderId);
        IEnumerable<EventCustomer> GetEventCustomersForCdLabel(long eventId);

        IEnumerable<EventCustomer> GetEventCustomersForShippingRevenueDetail(int pageNumber, int pageSize, ShippingRevenueListModelFilter filter, out int totalRecords);

        IEnumerable<EventCustomer> GetCustomerOpenOrder(int pageNumber, int pageSize, CustomerOpenOrderListModelFilter filter, out int totalRecords);

        IEnumerable<EventCustomer> GetEventsforCorporateAccountInvoice(int pageNumber, int pageSize, CorporateAccountInvoiceListModelFilter filter, out int totalRecords);

        IEnumerable<EventCustomer> GetByEventIds(IEnumerable<long> eventIds);

        IEnumerable<EventCustomer> GetEventCustomersWithCdPurchaseByEventId(long eventId);
        IEnumerable<EventCustomer> GetEventCustomersForShippingLabels(long eventId, int shippingStatus);
        IEnumerable<EventCustomer> GetByCustomerIds(IEnumerable<long> customerIds);
        IEnumerable<EventCustomer> GetEventCustomersForTestUpsellNotification(int days);
        IEnumerable<EventCustomer> GetEventCustomersForSecondScreeingReminderNotification(int hours, int interval);
        bool UpdateHospitalFacility(long eventCustomerId, long? hospitalfacilityId);

        IEnumerable<EventCustomer> GetEventCustomersForKynFirstNotification(int days, int pageNumber, int pageSize, out long totalRecords);
        IEnumerable<EventCustomer> GetEventCustomersForKynSecondNotification(int hours, int interval, int pageNumber, int pageSize, out long totalRecords);

        IEnumerable<EventCustomer> GetInsurancePayment(int pageNumber, int pageSize, InsurancePaymentListModelFilter filter, out int totalRecords);
        IEnumerable<EventCustomer> GetEventCustomersForInsuranceClaim(int daysAfter, long billingAccountId);

        IEnumerable<EventCustomer> GetKynEventCustomers(int pageNumber, int pageSize, KynCustomerModelFilter filter, out int totalRecords);

        IEnumerable<EventCustomer> GetEventCustomerBasedOnTime(DateTime fromDateTime, DateTime toDateTime, long eventId);

        IEnumerable<EventCustomer> GetEventsCustomersForDailyPatientRecap(int pageNumber, int pageSize, DailyPatientRecapModelFilter filter, out int totalRecords);

        IEnumerable<EventCustomer> GetEventsCustomersForDailyPatientRecapCustom(int pageNumber, int pageSize, DailyPatientRecapModelFilter filter, out int totalRecords);

        bool UpdateAbnStatus(long eventCustomerId, short abnStatus);

        bool UpdatePcpConsentStatus(long eventCustomerId, short pcpConsentStatus);

        bool UpdateInsuranceReleaseStatus(long eventCustomerId, short insuranceReleaseStatus);
        IEnumerable<OrderedPair<long, long>> GetCustomerForConfirmationCallQueue(int noOfDays);
        IEnumerable<OrderedPair<long, long>> GetCustomersForUpsellCallQueue(decimal amount, int days);

        IEnumerable<OrderedPair<long, long>> GetTestBooked(int pageNumber, int pageSize, TestsBookedListModelFilter filter, out int totalRecords);

        long GetEventIdAttendedByCustomerForTest(long customerId, long testId, int numberOfDays);

        IEnumerable<EventCustomer> GetEventCustomersByEventIdsCustomerIds(IEnumerable<long> eventIds, IEnumerable<long> customerIds);
        EventCustomer GetCustomersPreviousEventId(long eventId, long customerId);

        IEnumerable<EventCustomer> GetEventCustomersDoesNotAppearOnEvent(long eventId, DateTime currentTime, long minutesAfterAppointmentTime, int intervalInMinitus);

        IEnumerable<ViewPcpAppointmentDisposition> GetEventCustomersForPcpAppointmentReporting(PcpAppointmentListModelFilter filter, int pageNumber, int pageSize, out int totalRecords);

        bool UpdateLeftReason(long eventCustomerId, long? leftWithoutScreeningReasonId, long? noteId);

        IEnumerable<EventCustomer> GetCustomerLeftWithoutScreening(int pageNumber, int pageSize, CustomerLeftWithoutScreeningModelFilter filter, out int totalRecords);

        IEnumerable<EventCustomer> GetVoiceMailReminderReport(int pageNumber, int pageSize, VoiceMailReminderModelFilter filter, out int totalRecords);

        void UpdateEnableTexting(long customerId, bool enableTexting);

        bool UpdateEnableTextingById(long eventCustomerId, bool enableTexting);

        IEnumerable<EventCustomer> GetTextReminderReport(int pageNumber, int pageSize, TextReminderModelFilter filter, out int totalRecords);

        long GetEventCustomerCountForHealthPlanRevenueByCustomer(long accountId, DateTime dateFrom, DateTime dateTo);

        IEnumerable<OrderedPair<long, int>> GetEventCustomerCountForHealthPlanRevenueByPackage(long accountId, DateTime dateFrom, DateTime dateTo, IEnumerable<long> packageIds);

        IEnumerable<OrderedPair<long, int>> GetTestAvailedForHealthPlanRevenueByTest(long accountId, DateTime dateFrom, DateTime dateTo, IEnumerable<long> testIds);
        long GetCustomerCountForHealthPlanRevenueByTest(long accountId, DateTime dateFrom, DateTime dateTo, IEnumerable<long> testIds);

        IEnumerable<EventCustomer> GetEventCustomersForMemberResultSummary(int pageNumber, int pageSize, CorporateAccountCustomerListModelFilter filter, out int totalRecords);

        IEnumerable<EventCustomer> GetEventCustomerForFurtureEventsByCustomerId(long customerId, bool isTodayIncluded = true);
        IEnumerable<EventCustomer> GetCorporateEventCustomerbyEventId(int pageNumber, int pageSize, CorporateEventCustomerModelFilter filter, out int totalRecords);

        IEnumerable<EventCustomer> GetEventCustomersForInterviewReport(InterviewInboundFilter filter, int pageNumber, int pageSize, out int totalRecords);
        bool IsCustomerNoShowOrLeftWithoutScreening(long eventId, long customerId);

        IEnumerable<EventCustomer> GetForCustomerExport(IEnumerable<long> customerIds, CustomerExportListModelFilter filter);

        bool UpdateGiftCertificate(long eventCustomerId, string giftCode = null, long? giftCardNotGivenReasonId = null);

        IEnumerable<EventCustomer> GetForGiftCertificateReport(int pageNumber, int pageSize, GiftCertificateReportFilter giftCertificateReportFilter, out int totalRecords);

        EventCustomer GetByCustomerIdAndEventDate(long customerId, DateTime eventDate);

        EventCustomer GetByPatientDetailId(long patientDetailId);
        IEnumerable<EventCustomer> GetAppointmentBookedChartForLastSevenDays(AppointmentBookedChartStatus appointmentBookedType);
        EventCustomer GetByMedicareVisitId(long visitId);

        IEnumerable<EventCustomer> GetPayPeriodBookedCustomers(int pageNumber, int pageSize, PayPeriodBookedCustomerFilter filter, out int totalRecords);
        IEnumerable<EventCustomer> GetEventCustomerForBonusCalculation(DateTime startDate, DateTime endDate, IEnumerable<long> callCenterAgents);
        IEnumerable<EventCustomer> GetActualCustomerShowed(int pageNumber, int pageSize, PayPeriodBookedCustomerFilter filter, out int totalRecords);
        IEnumerable<EventCustomersViewServiceReport> GetEventCustomerResultByFilter(CustomTestPerformedReportFilter filter, int pageNumber, int pageSize, out int totalRecords);
        IEnumerable<EventCustomer> GetByCustomerIdEventDate(IEnumerable<long> customerIds, DateTime? eventDatefrom = null, DateTime? eventDateTo = null, long? technicianId = null);

        IEnumerable<EventCustomer> GetForHealthPlanGiftCertificateReport(int pageNumber, int pageSize, HealthPlanGiftCertificateReportFilter filter, out int totalRecords);

        IEnumerable<EventCustomer> GetByEventIdsOrCustomerIds(DateTime? startDate, IEnumerable<long> customerIds);

        IEnumerable<EventCustomer> GetHhynEventCustomers(int pageNumber, int pageSize, KynCustomerModelFilter filter,
            out int totalRecords);

        void UpdateCustomerProfileIdByCustomerId(long customerId, long customerProfileHistoryId);

        IEnumerable<EventCustomer> GetByEventDate(DateTime? fromDate, DateTime? toDate);
        int IsNoShowOrCancelled(long visitId);

        IEnumerable<EventCustomer> GetLatestEventCustomersByCustomerId(IEnumerable<long> customerIds);
        IEnumerable<EventCustomer> GetMyBioCheckEventCustomers(int pageNumber, int pageSize, MyBioCheckCustomerModelFilter filter, out int totalRecords);
        IEnumerable<long> GetCustomerIdsForNonTargetableReport(int pageNumber, int pageSize, NonTargetableReportModelFilter filter, out int totalRecords);
        IEnumerable<EventCustomer> GetAppointmentEncounterReport(int pageNumber, int pageSize, AppointmentEncounterFilter filter, out int totalRecords);
        IEnumerable<EventCustomer> GetEventCustomerForPcpChangeReport(int pageNumber, int pageSize, PotentialPcpChangeReportModelFilter filter, out int totalRecords);
        IEnumerable<EventCustomer> GetEventCustomersbyEventId(long eventId);
        void UpdatePreferredContactTypeByCustomerId(long customerId, long? preferredContactType);
        DateTime? GetFutureMostAppointmentDateForEventCustomerByCustomerId(long customerId);
        void UpddateIsAppointmentConfirmed(long eventid);

        bool IsTestPurchasedByEventIdCustomerId(long eventId, long customerId, long testId);
       // bool UpdateGeneratePreAssessmentCallQueueStatus(long eventCustomerId, bool isAssessmentCompleted);
    }
}