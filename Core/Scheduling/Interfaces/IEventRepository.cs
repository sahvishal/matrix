using System;
using System.Collections.Generic;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.Finance.ViewModels;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Operations.ViewModels;
using Falcon.App.Core.Sales.ViewModels;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Scheduling.ViewModels;

namespace Falcon.App.Core.Scheduling.Interfaces
{
    public interface IEventRepository
    {
        decimal GetEventRevenue(long eventId);

        bool ValidateInvitationCode(long eventId, string invitationCode);
        Event GetEventForShippingDetail(long shippingDetailId);

        List<Event> GetEventsByFilters(string zipCode, int? zipRange, string stateName, string cityName, DateTime? fromDate, DateTime? toDate, string invitationCode, int pageNumber, int pageSize, bool enableForCallcenter = false,
            long excludeEventId = 0, string tag = "", bool hasMammo = false, long zipCodeId = 0, bool allEvents = false, long? ProductType=null); //, long customerId = 0

        List<OrderedPair<long, int>> GetTotalAppointmentSlots(IEnumerable<long> eventIds);
        List<OrderedPair<long, int>> GetBookedAppointmentSlots(IEnumerable<long> eventIds);
        List<OrderedPair<long, int>> GetAvailableAppointmentSlots(IEnumerable<long> eventIds);
        //List<Event> GetFuturePublicEventsWithInRange(string zipCode, int zipRange, long corporateId, int pageNumber, int pageSize);
        List<Event> GetEventByInvitataionCd(string pInvitationCd);
        List<Event> GetCorporteEvents(int pageNumber, int pageSize, EventVolumeListModelFilter filter, out int totalRecords);
        List<Event> GetRetailEvents(int pageNumber, int pageSize, EventVolumeListModelFilter filter, out int totalRecords);
        IEnumerable<Event> GetEventswithPodbyIds(IEnumerable<long> ids);

        IEnumerable<Event> GetEventsforDetailOpenOrder(int pageNumber, int pageSize, DetailOpenOrderModelFilter filter, out int totalRecords);
        IEnumerable<Event> GetEventsbyFilters(EventBasicInfoViewModelFilter filter, int pageNumber, int pageSize, out int totalRecords);

        IEnumerable<Event> GetEventsbyFilters(OnlineSchedulingEventListModelFilter filter, out int totalRecords);

        IEnumerable<Event> GetForMonth(int month, int year);
        IEnumerable<Event> GetForStaffCalendar(EventStaffAssignmentListModelFilter filterbool, bool isForExport = false);
        Event GetEventbyHostName(string hostName, DateTime? dateTime);
        Event GetById(long eventId);
        IEnumerable<long> GetEventIdsforaTechnicianasStaff(long technicianId, IEnumerable<long> filterFromEventIds);
        IEnumerable<Event> GetEventsForDailyRecap(int pageNumber, int pageSize, DailyRecapModelFilter filter, out int totalRecords);

        List<OrderedPair<long, int>> GetTotalRegistration(IEnumerable<long> eventIds);
        List<OrderedPair<long, int>> GetAttendedCustomers(IEnumerable<long> eventIds);
        List<OrderedPair<long, int>> GetAttendedCustomersByHospitalPartnerId(long hospitalPartnerId);
        List<OrderedPair<long, int>> GetNoShowCustomers(IEnumerable<long> eventIds);
        List<OrderedPair<long, int>> GetCancelledCustomers(IEnumerable<long> eventIds);
        List<OrderedPair<long, int>> GetCustomersWithAppointment(IEnumerable<long> eventIds);
        List<OrderedPair<long, int>> GetCustomersWithAppointmentByHospitalPartnerId(long hospitalPartnerId);

        string GetTechnicianNotes(long eventId);
        string GetCallCenterNotes(long eventId);
        bool IsHospitalPartnerAttached(long eventId);

        IEnumerable<Event> GetEventsForEventResultStatus(int pageNumber, int pageSize, EventResultStatusViewModelFilter filter, out int totalRecords);
        IEnumerable<Event> GetEventsForHospitalPartnerDashboard(long hospitalPartnerId);
        IEnumerable<Event> GetEventsForHospitalPartner(int pageNumber, int pageSize, HospitalPartnerEventListModelFilter filter, out int totalRecords, int normalValidityPeriod = 0, int abnormalValidityPeriod = 0, int criticalValidityPeriod = 0);
        IEnumerable<Event> GetEventsForCorporateAccount(int pageNumber, int pageSize, CorporateAccountEventListModelFilter filter, out int totalRecords);

        Event GetEventForAuthorization(long physicianId);

        void SetCommandforGenrateHealthAssesmentForm(long eventId);

        Notes GetEmrNotes(long eventId);
        Notes SaveEmrNotes(long eventId, Notes notes);
        IEnumerable<Event> GetEventsForCorporateAccountDashboard(long accountId);
        IEnumerable<long> GetEventIdsForCorporateAccount(long accountId);
        void SaveEventSignoffData(long orgRoleUserId, long eventId);
        bool AttachHospitalMaterial(long eventId);
        Event CheckDuplicateEventCreationOnSameHost(long hostId, DateTime eventDate, long eventId);
        IEnumerable<OrderedPair<long, int>> GetUnServicedAppointments(IEnumerable<long> eventIds);
        IEnumerable<OrderedPair<long, int>> GetNoShowAppointmentsForOpenOrder(IEnumerable<long> eventIds);
        IEnumerable<OrderedPair<long, int>> GetCancelledAppointmentsForOpenOrder(IEnumerable<long> eventIds);

        bool CheckCustomerRegisteredForFutureEvent(long customerId);

        IEnumerable<Event> GetEventsForShippingRevenueSummary(int pageNumber, int pageSize, ShippingRevenueListModelFilter filter, out int totalRecords);
        bool CaptureSsn(long eventId);
        List<OrderedPair<long, int>> GetCustomersWithAppointmentByHospitalFacilityId(long hospitalFacilityId);
        List<OrderedPair<long, int>> GetAttendedCustomersByHospitalFacilityId(long hospitalFacilityId);

        IEnumerable<Event> GetEventsForHospitalFacility(int pageNumber, int pageSize, HospitalPartnerEventListModelFilter filter, out int totalRecords, int normalValidityPeriod = 0, int abnormalValidityPeriod = 0, int criticalValidityPeriod = 0);
        List<OrderedPair<long, int>> GetAttendedCustomersByEventIdsAndHospitalFacilityId(IEnumerable<long> eventIds, long hospitalFacilityId);

        IEnumerable<Event> GetEventsForGenerateKynXml();
        void UpateGenerateXMLStatusField(long eventId, GenerateKynXmlStatus status);

        IEnumerable<Event> GetEventsToSendSms(DateTime fromDate, DateTime toDate);

        IEnumerable<Event> GetEventForKynXml();
        IEnumerable<Event> GetEventsForStaff(EventSearchModelFilter filter);
        IEnumerable<OrderedPair<long, long>> GetEventStaffPairs(IEnumerable<long> eventIds);
        Event GetEventByInvitationCode(string invitationCode);
        void UpdatePackageTrackingNumbers(long eventId, string bloodPackageTrackingNumber, string recordsPackageTrackingNumber);

        IEnumerable<Event> GetEventsForCallQueue(FillEventsCallQueueFilter filter, long criteriaId);
        Event GetPreviousAttendedEvent(long customerId);
        IEnumerable<Event> GetEventsForFillEventsCallQueue(DateTime dtDateTime);
        IEnumerable<Event> GetCancelledEvents(int pageNumber, int pageSize, EventCancellationModelFilter filter, out int totalRecords);

        bool ValidateEventForAccount(long eventId, long accountId);
        IEnumerable<long> GetEventsToArchive(DateTime toTime, DateTime? fromTime);

        IEnumerable<long> GetLockedEventIds();
        void UnlockLockedCorporateEvents();
        IEnumerable<long> LockCorporateEvents(long accountId, DateTime eventDate);

        IEnumerable<Event> GetEventsForHealthPlanFillEventsCallQueue(DateTime dtDateTime, long healthPlanId, bool eventForNonMammoPatient);

        IEnumerable<Event> GetHealthPlanEventsForCallQueue(FillEventsCallQueueFilter filter, long criteriaId);
        List<Event> GetEventsByFiltersForCallQueue(EventSearchFilterCallQueueCustomer filter);

        List<Event> GetHealthPlanEvents(int pageNumber, int pageSize, ClientEventVolumeListModelFilter filter, out int totalRecords);

        IEnumerable<Event> GetEventsforDailyVolumeReport(int pageNumber, int pageSize, DailyVolumeListModelFilter filter, out int totalRecords);

        List<OrderedPair<long, int>> GetCustomersCancelledOnDayOfEvent(IEnumerable<long> eventIds);
        bool IsCustomerRegisterForCurrentEvent(long customerId, long eventId);
        List<OrderedPair<long, int>> GetLeftWithoutScreeningCustomers(IEnumerable<long> eventIds);
        IEnumerable<Event> GetEventListByHealthPlanId(int pageNumber, int pageSize, HealthPlanRevenueEventModelFilter filter, out int totalRecords);

        List<Event> GetUpcomingHealthPlanEvents(int pageNumber, int pageSize, long accountId);

        IEnumerable<Event> GetEvents(IEnumerable<long> eventIds);

        IEnumerable<long> GetForAddNotes(AddNotesModelFilter filter);

        IEnumerable<OrderedPair<long, int>> GetGcIssuedCountByEventIds(List<long> eventIds);

        IEnumerable<Event> GetActiveEvents(EventsDateRangeType duration);

        IEnumerable<long> GetEventIdsByAccountIdAndDate(long accountId, DateTime fromDate, DateTime? toDate = null, bool getActiveEventsOnly = false);

        IEnumerable<Event> GetEventForHkynXml();

        IEnumerable<Event> GetEventsForGenerateHkynXml();

        void UpateGeneratehkynXmlStatusField(long eventId, GenerateKynXmlStatus status);

        List<long> GetEventsByTag(DateTime onDate, string tag);

        IEnumerable<Event> GetEventsForGenerateMyBioCheckAssessment();
        IEnumerable<Event> GetEventForMyBioCheckAssessment();
        void UpateGenerateMyBioCheckStatusField(long eventId, GenerateKynXmlStatus status);
        List<Event> GetActiveHealthPlanEventsForGmsEventList(EventListGmsModelFilter filter, int pageNumber, int pageSize, out int totalRecords);
        IEnumerable<Event> GetFutureEventsForHealthPlan(long healthPlanId, DateTime fromDate);
        IEnumerable<long> GetEventStateByAccountId(EventScheduleListModelFilter accountId);
        IEnumerable<Event> GetEventScheduleListModel(int pageNumber, int pageSize, EventScheduleListModelFilter filter, out int totalRecords);

        IEnumerable<Event> GetEventsByIdsWithHostDetails(IEnumerable<long> eventIds);
        IEnumerable<Event> GetEventsByIds(IEnumerable<long> eventIds);

        Event GetEventWithEventTypeAndHostEventById(long eventId);
        Event GetEventOnlyById(long eventId);
        IEnumerable<Event> GetEventsforGenerateHealthAssesmentForm();

        void SetGenrateHealthAssesmentFormStatus(long eventId, bool isFormGenerated, long generateHealthAssesmentFormStatus);
        IEnumerable<Event> GetEventByEventDateAndPod(DateTime eventDate, string pod);

        IEnumerable<Event> GetEventsByAccountIdAndDate(long accountId, DateTime fromDate, DateTime? toDate = null, bool getActiveEventsOnly = false);
        bool IsEventHasNewResultFlow(long eventId);
        bool IsHealthPlanEvent(long eventId);
        IEnumerable<Event> GetEventsFutureDate(DateTime fromDate);
    }
}