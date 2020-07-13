using System;
using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Communication.ViewModels;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Operations.ViewModels;
using Falcon.App.Core.Sales.ViewModels;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.Scheduling.Interfaces
{
    public interface IEventService
    {
        EventHostViewData GetById(long eventId);

        List<EventHostViewData> GetEventHostViewData(ViewType viewType, string stateName, string cityName, string invitationCode, string zipCode, int zipRange, DateTime? fromDate, DateTime? toDate, long corporateId = 0,
            bool enableForCallcenter = false, long excludeEventId = 0, string tag = "", bool hasMammo = false, bool allEvents = false, long? ProductType=null); //, long customerId = 0
        List<EventHostViewData> GetEventByInvitataionCd(string pInvitationCode); //Used for getting data w\ invitation code

        EventBasicInfoViewModel GetEventBasicInfoFor(long eventId);
        IEnumerable<EventBasicInfoViewModel> GetEventBasicInfoFor(EventStaffAssignmentListModelFilter filter, bool isForExport = false);

        EventBasicInfoListModel GetEventBasicInfo(EventBasicInfoViewModelFilter filter, int pageNumber, int pageSize, out int totalRecords);

        EventNotes GetAllEventNotes(long eventId);
        EventNotes GetCallCenterEventNotes(long eventId);
        EventNotes GetTechnicianEventNotes(long eventId);
        EventSummaryViewModel GetEventSummary(long eventId);

        ListModelBase<CorporateAccountEventViewModel, CorporateAccountEventListModelFilter> GetCorporateAccountEvents(
            int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords);

        OnlineSchedulingEventListModel GetOnlineSchedulingEventCollection(OnlineSchedulingEventListModelFilter filter, SortOrderBy sortOrderBy, SortOrderType sortOrderType, int maxNumberofRecordstoFetch, int pageNumber, int pageSize, out int totalRecords);
        OnlineSchedulingEventViewModel GetSelectedEvent(long eventId);

        EventCustomerListModel GetEventInfoforEventCustomerListModel(long eventId, CorporateAccount account);
        EventStaffAssignmentListModel GetEventStaff(EventStaffAssignmentListModelFilter filter, bool isForExport = false);
        EventStaffAssignmentEditModel GetEventStaff(long eventId);
        IEnumerable<Event> GetEventsByCustomerId(long customerId);
        EventCdContentStatusViewModel GetEventCdContentStatus(long eventId);
        EventCustomerBrifListModel GetEventCustomerBrifListModel(long eventId);
        IEnumerable<ShortEventInfoViewModel> GetEventBasicInfoForStaff(EventSearchModelFilter filter);
        IEnumerable<EventBasicInfoViewModel> GetEventBasicInfoEventIds(IEnumerable<long> eventIds);

        EventBasicInfoListModel GetEventBasicInfoForCallQueue(FillEventsCallQueueFilter filter, int pageSize, out int totalRecords);
        IEnumerable<EventHostViewData> SearchEventForCallCenter(EventSearchFilterCallQueueCustomer filter, out int totalCount);


        ListModelBase<HealthPlanEventViewModel, EventBasicInfoViewModelFilter> GetHealthPlanEvents(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords);

        AddNotesListModel GetEventForAddNotes(AddNotesModelFilter filter, long eventNoteId);
        AddNotesListModel SaveEventNotes(AddNotesListModel model, long createdBy);
        ListModelBase<EventNotesViewModel, EventNotesModelFilter> GetEventNotes(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords);
        MapEventListModel GetActiveEvents(EventsDateRangeType duration);

        void SaveCustomEventNotification(CustomEventNotificationEditModel model, CorporateAccount account, long createdBy);

        IEnumerable<ShortEventInfoViewModel> GetShortEventInfoList(IEnumerable<Event> events);
        ShortEventInfoViewModel GetEventBasicDetailsForStaff(EventSearchModelFilter filter);
    }
}
