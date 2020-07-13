using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Operations.ViewModels;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;

namespace Falcon.App.Infrastructure.Operations.Impl
{
    [DefaultImplementation]
    public class StaffEventScheduleExportService : IStaffEventScheduleExportService
    {
        private readonly IEventStaffAssignmentService _eventStaffAssignmentService;
        private readonly IEventService _eventService;
        private readonly IHospitalPartnerRepository _hospitalPartnerRepository;
        private readonly IOrganizationRepository _organizationRepository;
        private readonly IEventRepository _eventRepository;

        public StaffEventScheduleExportService(IEventStaffAssignmentService eventStaffAssignmentService, IEventService eventService, IHospitalPartnerRepository hospitalPartnerRepository,
            IOrganizationRepository organizationRepository, IEventRepository eventRepository)
        {
            _eventStaffAssignmentService = eventStaffAssignmentService;
            _eventService = eventService;
            _hospitalPartnerRepository = hospitalPartnerRepository;
            _organizationRepository = organizationRepository;
            _eventRepository = eventRepository;
        }

        public ListModelBase<StaffEventSchedulingModel, EventStaffAssignmentListModelFilter> GetStaffScheduleForCsvExport(int pageNumber, int pageSize, ModelFilterBase staffEventScheduleModelFilter, out int totalRecords)
        {
            bool isCurrentRoleTechnician = (staffEventScheduleModelFilter as EventStaffAssignmentListModelFilter).UserSessionModel.CurrentOrganizationRole.RoleId == (long)Roles.Technician;

            var eventStaffAssignmentListModel = _eventStaffAssignmentService.GetforStaffCalendar(isCurrentRoleTechnician, staffEventScheduleModelFilter as EventStaffAssignmentListModelFilter);
            var filter = eventStaffAssignmentListModel.Filter;

            filter.PageNumber = pageNumber;
            filter.PageSize = pageSize;
            var data = _eventService.GetEventStaff(filter, true);

            var eventIdSponsorPair = GetEventIdSponsorPair(data);
            totalRecords = filter.TotalRecords;
            return GetStaffEventScheduleCsvModel(data.StaffEventAssignments, eventIdSponsorPair);
        }

        private StaffEventSchedulingListModel GetStaffEventScheduleCsvModel(IEnumerable<EventStaffAssignmentViewModel> collection, IEnumerable<OrderedPair<long, string>> eventIdSponsorPairs)
        {
            var listModel = new StaffEventSchedulingListModel();
            var exportList = new List<StaffEventSchedulingModel>();

            foreach (var eventStaffAssignmentViewModel in collection)
            {
                var esavm = eventStaffAssignmentViewModel;
                foreach (var staff in esavm.AssignedStaff)
                {
                    var staffDetails = staff;
                    var eventIdSponsorPair = eventIdSponsorPairs.FirstOrDefault(x => x.FirstValue == esavm.Event.Id);
                    var sponsor = eventIdSponsorPair == null ? "N/A" : eventIdSponsorPair.SecondValue;

                    var staffEventSchedulingModel = new StaffEventSchedulingModel
                    {
                        EventAddressStreet12 = esavm.Event.HostAddress.StreetAddressLine1 + " " + eventStaffAssignmentViewModel.Event.HostAddress.StreetAddressLine2,
                        EventCity = esavm.Event.HostAddress.City,
                        EventDate = esavm.Event.EventDate,
                        EventId = esavm.Event.Id,
                        EventStateName = esavm.Event.HostAddress.State,
                        EventZipCode = esavm.Event.HostAddress.ZipCode,
                        Pod = esavm.Event.PodNames(),
                        StaffEventRole = staffDetails.EventRole,
                        StaffFullName = staffDetails.FullName,
                        Sponsor = sponsor,
                        EmployeeId = string.IsNullOrEmpty(staffDetails.EmployeeId) ? "N/A" : staffDetails.EmployeeId
                    };
                    exportList.Add(staffEventSchedulingModel);
                }
            }
            listModel.Collection = exportList;
            return listModel;
        }

        private IEnumerable<OrderedPair<long, string>> GetEventIdSponsorPair(EventStaffAssignmentListModel data)
        {
            var eventIdSponsorPair = new List<OrderedPair<long, string>>();

            var eventIds = data.StaffEventAssignments.Select(x => x.Event.Id).Distinct();
            var events = _eventRepository.GetEventsByIds(eventIds);

            var eventHpPairs = _hospitalPartnerRepository.GetEventAndHospitalPartnerOrderedPair(eventIds);
            var organizationIds = new List<long>();
            if (eventHpPairs != null && eventHpPairs.Any())
                organizationIds.AddRange(eventHpPairs.Select(o => o.SecondValue).ToArray());

            organizationIds.AddRange(events.Where(e => e.AccountId.HasValue && e.AccountId.Value > 0).Select(e => e.AccountId.Value).ToArray());

            var organizations = _organizationRepository.GetOrganizations(organizationIds.Distinct().ToArray());
            var sponsor = string.Empty;
            foreach (var theEvent in events)
            {
                if (eventHpPairs != null && eventHpPairs.Any())
                {
                    var hospitalPartnerId =
                        eventHpPairs.Where(o => o.FirstValue == theEvent.Id).Select(o => o.SecondValue).FirstOrDefault();
                    if (hospitalPartnerId > 0)
                        sponsor = organizations.Where(o => o.Id == hospitalPartnerId).Select(o => o.Name).First();
                }

                if (string.IsNullOrEmpty(sponsor))
                {
                    if (theEvent.AccountId.HasValue && theEvent.AccountId.Value > 0)
                        sponsor = organizations.Where(o => o.Id == theEvent.AccountId.Value).Select(o => o.Name).First();
                }
                eventIdSponsorPair.Add(new OrderedPair<long, string>(theEvent.Id, sponsor));
            }
            return eventIdSponsorPair;
        }
    }
}
