using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Application.Attributes;

namespace Falcon.App.Infrastructure.Sales.Factories
{
    //TODO: Use AutoMapper instead of factory
    [DefaultImplementation]
    public class EventVolumeFactory : IEventVolumeFactory
    {
        public EventVolumeListModel Create(IEnumerable<Event> events, IEnumerable<Host> hosts, IEnumerable<Pod> pods, IEnumerable<EventAppointmentStatsModel> eventAppointmentStatsModels, IEnumerable<OrderedPair<long, string>> primaryPhysicians,
            IEnumerable<OrderedPair<long, string>> overReadPhysicians, IEnumerable<OrderedPair<long, string>> eventIdHospitalPartnerNamePairs, IEnumerable<OrderedPair<long, int>> customersAttended,
            IEnumerable<OrderedPair<long, string>> eventIdCorporateNamePairs, IEnumerable<EventStaffAssignment> staffAssignments, IEnumerable<OrderedPair<long, string>> idNamePairs)
        {
            var model = new EventVolumeListModel();
            var eventVolumeModels = new List<EventVolumeModel>();

            events.ToList().ForEach(e =>
            {
                var host = hosts.Where(h => h.Id == e.HostId).FirstOrDefault();
                var eventPods = (e.PodIds != null && e.PodIds.Count() > 0) ? pods.Where(p => e.PodIds.Contains(p.Id)).ToList() : null;

                var eventAppointmentStatsModel = eventAppointmentStatsModels.Where(easm => easm.EventId == e.Id).Select(easm => easm).Single();

                var bookedSlotCount = eventAppointmentStatsModel.BookedSlots;

                var totalSlotCount = eventAppointmentStatsModel.TotalSlots - eventAppointmentStatsModel.BlockedSlots;

                var availableSlotCount = eventAppointmentStatsModel.FreeSlots + eventAppointmentStatsModel.TemporaryBookedSlots;

                var primaryPhysician = primaryPhysicians.Where(pp => pp.FirstValue == e.Id).Select(pp => pp.SecondValue).FirstOrDefault();

                var overreadPhysician = overReadPhysicians.Where(orp => orp.FirstValue == e.Id).Select(orp => orp.SecondValue).FirstOrDefault();

                var hospitalPartnerName = eventIdHospitalPartnerNamePairs.Where(ehp => ehp.FirstValue == e.Id).Select(ehp => ehp.SecondValue).SingleOrDefault();

                var screenedCustomersCount = customersAttended.Where(bs => bs.FirstValue == e.Id).FirstOrDefault().SecondValue;

                var corporateName = eventIdCorporateNamePairs.Where(ehp => ehp.FirstValue == e.Id).Select(ehp => ehp.SecondValue).SingleOrDefault();

                var technicians = new List<string>();

                if (staffAssignments != null && staffAssignments.Any())
                {
                    var eventStaffAssignments = staffAssignments.Where(sa => sa.EventId == e.Id).Select(sa => sa).ToArray();
                    foreach (var eventStaff in eventStaffAssignments)
                    {
                        var staffId = eventStaff.ActualStaffOrgRoleUserId != null ? eventStaff.ActualStaffOrgRoleUserId.Value : eventStaff.ScheduledStaffOrgRoleUserId;
                        var idNamePair = idNamePairs.First(inp => inp.FirstValue == staffId);
                        technicians.Add(idNamePair.SecondValue);
                    }
                }

                technicians = technicians.OrderBy(t => t).Distinct().ToList();

                eventVolumeModels.Add(CreateSingleEventVolumeModel(e, host, eventPods, bookedSlotCount, totalSlotCount, availableSlotCount, primaryPhysician,
                    overreadPhysician, hospitalPartnerName, screenedCustomersCount, corporateName, technicians));
            });

            model.Collection = eventVolumeModels;

            return model;
        }

        public EventVolumeModel CreateSingleEventVolumeModel(Event evt, Host host, IEnumerable<Pod> pods, int bookedSlotCount, int totalSlotCount, int availableSlotCount, string primaryPhysician, string overReadPhysician,
            string hospitalPartnerName, int screenedCustomersCount, string corporateName, IEnumerable<string> technicians)
        {
            return new EventVolumeModel
                       {
                           Address =
                               host.Address,
                           AppointmentsBooked = bookedSlotCount,
                           TotalSlots = evt.IsDynamicScheduling ? availableSlotCount + bookedSlotCount : totalSlotCount,
                           AvailableSlots = availableSlotCount,
                           EventCode = evt.Id,
                           EventDate = evt.EventDate,
                           EventType = evt.EventType.ToString(),
                           Location = host.OrganizationName,
                           //Territory = string.Join(" | ", territories.Select(t => t.Name)),
                           Pod = pods != null ? string.Join(" | ", pods.Select(p => p.Name)) : string.Empty,
                           PrimaryPhysician = primaryPhysician,
                           OverReadPhysician = overReadPhysician,
                           HospitalPartner = hospitalPartnerName,
                           ScreenedCustomers = screenedCustomersCount,
                           CorporateAccount = corporateName,
                           IsCorporateEvent = evt.EventType == EventType.Corporate,
                           Technicians = technicians,
                           RecommendPackage = evt.RecommendPackage ,
                           Status = evt.Status
                       };
        }

        public ClientEventVolumeListModel Create(IEnumerable<Event> events, IEnumerable<Host> hosts, IEnumerable<Pod> pods, IEnumerable<EventAppointmentStatsModel> eventAppointmentStatsModels, IEnumerable<OrderedPair<long, string>> eventIdHospitalPartnerNamePairs, IEnumerable<OrderedPair<long, int>> customersAttended,
           IEnumerable<OrderedPair<long, string>> eventIdCorporateNamePairs, IEnumerable<EventStaffAssignment> staffAssignments, IEnumerable<OrderedPair<long, string>> idNamePairs)
        {
            var model = new ClientEventVolumeListModel();
            var clientEventVolumeModels = new List<ClientEventVolumeModel>();

            events.ToList().ForEach(e =>
            {
                var host = hosts.Where(h => h.Id == e.HostId).FirstOrDefault();
                var eventPods = (e.PodIds != null && e.PodIds.Count() > 0) ? pods.Where(p => e.PodIds.Contains(p.Id)).ToList() : null;

                var eventAppointmentStatsModel = eventAppointmentStatsModels.Where(easm => easm.EventId == e.Id).Select(easm => easm).Single();

                var bookedSlotCount = eventAppointmentStatsModel.BookedSlots;

                var totalSlotCount = eventAppointmentStatsModel.TotalSlots - eventAppointmentStatsModel.BlockedSlots;

                var availableSlotCount = eventAppointmentStatsModel.FreeSlots + eventAppointmentStatsModel.TemporaryBookedSlots;

                var hospitalPartnerName = eventIdHospitalPartnerNamePairs.Where(ehp => ehp.FirstValue == e.Id).Select(ehp => ehp.SecondValue).SingleOrDefault();

                var screenedCustomersCount = customersAttended.Where(bs => bs.FirstValue == e.Id).FirstOrDefault().SecondValue;

                var corporateName = eventIdCorporateNamePairs.Where(ehp => ehp.FirstValue == e.Id).Select(ehp => ehp.SecondValue).SingleOrDefault();

                if (staffAssignments != null && staffAssignments.Any())
                {
                    var eventStaffAssignments = staffAssignments.Where(sa => sa.EventId == e.Id).Select(sa => sa).ToArray();
                    foreach (var eventStaff in eventStaffAssignments)
                    {
                        var staffId = eventStaff.ActualStaffOrgRoleUserId != null ? eventStaff.ActualStaffOrgRoleUserId.Value : eventStaff.ScheduledStaffOrgRoleUserId;
                        var idNamePair = idNamePairs.First(inp => inp.FirstValue == staffId);
                    }
                }

                clientEventVolumeModels.Add(CreateSingleEventVolumeModel(e, host, eventPods, bookedSlotCount, totalSlotCount, availableSlotCount, hospitalPartnerName, screenedCustomersCount, corporateName));
            });

            model.Collection = clientEventVolumeModels;

            return model;
        }

        private ClientEventVolumeModel CreateSingleEventVolumeModel(Event evt, Host host, IEnumerable<Pod> pods, int bookedSlotCount, int totalSlotCount, int availableSlotCount,string hospitalPartnerName, int screenedCustomersCount, string corporateName)
        {          
            return new ClientEventVolumeModel
            {
                Address =host.Address,
                AppointmentsBooked = bookedSlotCount,
                TotalSlots = evt.IsDynamicScheduling ? availableSlotCount + bookedSlotCount : totalSlotCount,
                AvailableSlots = availableSlotCount,
                EventCode = evt.Id,
                EventDate = evt.EventDate,
                EventType = evt.EventType.ToString(),
                Location = host.OrganizationName,
                Pod = pods != null ? string.Join(" | ", pods.Select(p => p.Name)) : string.Empty,
                HospitalPartner = hospitalPartnerName,
                ScreenedCustomers = screenedCustomersCount,
                CorporateAccount = corporateName,
                Status = evt.Status,              
            };
        }
    }
}
