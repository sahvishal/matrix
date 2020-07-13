using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Geo.ViewModels;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Sales.Interfaces;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Infrastructure.Service
{

    [DefaultImplementation]
    public class EventBasicInfoListHelper : IEventBasicInfoListHelper
    {
        private readonly IHostRepository _hostRepository;
        private readonly IPodRepository _podRepository;
        private readonly IEventAppointmentStatsService _eventAppointmentStatsService;
        private readonly IHospitalPartnerRepository _hospitalPartnerRepository;
        private readonly IOrganizationRepository _organizationRepository;
        public EventBasicInfoListHelper(IHostRepository hostRepository, IPodRepository podRepository, IEventAppointmentStatsService eventAppointmentStatsService,
            IHospitalPartnerRepository hospitalPartnerRepository, IOrganizationRepository organizationRepository)
        {
            _hostRepository = hostRepository;
            _podRepository = podRepository;
            _eventAppointmentStatsService = eventAppointmentStatsService;
            _hospitalPartnerRepository = hospitalPartnerRepository;
            _organizationRepository = organizationRepository;
        }

        public EventBasicInfoListModel EventBasicInfoListForCallQueue(IEnumerable<Event> events)
        {
            var eventIds = events.Select(e => e.Id).ToArray();
            var hosts = _hostRepository.GetEventHosts(eventIds);
            var pods = _podRepository.GetPodsForEvents(eventIds);

            var eventAppointmentStatsModels = _eventAppointmentStatsService.Get(eventIds);

            var eventHpPairs = _hospitalPartnerRepository.GetEventAndHospitalPartnerOrderedPair(eventIds);


            var organizationIds = new List<long>();
            if (eventHpPairs != null && eventHpPairs.Any())
                organizationIds.AddRange(eventHpPairs.Select(o => o.SecondValue).ToArray());

            organizationIds.AddRange(
                events.Where(e => e.AccountId.HasValue && e.AccountId.Value > 0).Select(e => e.AccountId.Value).ToArray());

            var organizations = _organizationRepository.GetOrganizations(organizationIds.Distinct().ToArray());

            var eventModels = new List<EventBasicInfoViewModel>();

            foreach (var theEvent in events) // Should go inside a mapper
            {
                var eventModel = EventBasicInfoViewModel(hosts, theEvent, pods, eventAppointmentStatsModels, eventHpPairs, organizations);

                eventModels.Add(eventModel);
            }
            return new EventBasicInfoListModel() { Events = eventModels };
        }

        public EventBasicInfoViewModel EventBasicInfoViewModel(IEnumerable<Host> hosts, Event theEvent, IEnumerable<Pod> pods, IEnumerable<EventAppointmentStatsModel> eventAppointmentStatsModels, IEnumerable<OrderedPair<long, long>> eventHpPairs, IEnumerable<Organization> organizations)
        {
            var eventModel = new EventBasicInfoViewModel();
            var host = hosts.First(h => h.Id == theEvent.HostId);
            eventModel = Mapper.Map<Event, EventBasicInfoViewModel>(theEvent);
            eventModel.HostAddress = Mapper.Map<Address, AddressViewModel>(host.Address);
            eventModel.HostName = host.OrganizationName;
            eventModel.Pods = pods != null
                ? pods.Where(p => theEvent.PodIds.Contains(p.Id))
                    .Select(p => new OrderedPair<long, string>(p.Id, p.Name)).ToArray()
                : null;

            var eventAppointmentStatsModel =
                eventAppointmentStatsModels.Where(easm => easm.EventId == theEvent.Id).Select(easm => easm).Single();

            eventModel.TotalAppointmentSlots = eventAppointmentStatsModel.TotalSlots -
                                               eventAppointmentStatsModel.BlockedSlots;

            eventModel.FilledAppintmentSlots = eventAppointmentStatsModel.BookedSlots;
            eventModel.BookedSlots = eventAppointmentStatsModel.FilledSlots;

            eventModel.IsDynamicScheduling = eventAppointmentStatsModel.IsDynamicScheduling;

            eventModel.AfternoonAvailableSlots = eventAppointmentStatsModel.AfternoonAvailableSlots;
            eventModel.MorningAvailableSlots = eventAppointmentStatsModel.MorningAvailableSlots;
            eventModel.EveningAvailableSlots = eventAppointmentStatsModel.EveningAvailableSlots;

            var sponsor = string.Empty;
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

            eventModel.Sponsor = sponsor;
            return eventModel;
        }

        public HealthPlanEventViewModel HealthPlanEventViewModel(IEnumerable<Host> hosts, Event theEvent, IEnumerable<Pod> pods, IEnumerable<EventAppointmentStatsModel> eventAppointmentStatsModels)
        {
            var eventModel = new HealthPlanEventViewModel();
            var host = hosts.First(h => h.Id == theEvent.HostId);
            eventModel.Id = theEvent.Id;
            eventModel.EventDate = theEvent.EventDate;
            eventModel.HostAddress = Mapper.Map<Address, AddressViewModel>(host.Address);
            eventModel.HostId = host.Id;
            eventModel.HostName = host.OrganizationName;
            eventModel.Pods = pods != null ? pods.Where(p => theEvent.PodIds.Contains(p.Id)).Select(p => new OrderedPair<long, string>(p.Id, p.Name)).ToArray() : null;

            var eventAppointmentStatsModel = eventAppointmentStatsModels.Where(easm => easm.EventId == theEvent.Id).Select(easm => easm).Single();

            eventModel.TotalAppointmentSlots = eventAppointmentStatsModel.TotalSlots - eventAppointmentStatsModel.BlockedSlots;

            eventModel.FilledAppintmentSlots = eventAppointmentStatsModel.BookedSlots;

            return eventModel;
        }

        public ShortEventInfoViewModel ShortEventInfoViewModel(IEnumerable<Host> hosts, Event theEvent, IEnumerable<Pod> pods, IEnumerable<EventAppointmentStatsModel> eventAppointmentStatsModels, IEnumerable<OrderedPair<long, long>> eventHpPairs, IEnumerable<Organization> organizations)
        {
            var eventModel = new ShortEventInfoViewModel();
            var host = hosts.First(h => h.Id == theEvent.HostId);
            eventModel = Mapper.Map<Event, ShortEventInfoViewModel>(theEvent);
            eventModel.HostAddress = Mapper.Map<Address, AddressViewModel>(host.Address);
            eventModel.HostName = host.OrganizationName;
            eventModel.Pods = pods != null ? string.Join(",", pods.Where(p => theEvent.PodIds.Contains(p.Id)).Select(p => p.Name).ToArray()) : "";

            var eventAppointmentStatsModel =
                eventAppointmentStatsModels.Where(easm => easm.EventId == theEvent.Id).Select(easm => easm).Single();

            eventModel.TotalAppointmentSlots = eventAppointmentStatsModel.TotalSlots -
                                               eventAppointmentStatsModel.BlockedSlots;

            eventModel.FilledAppintmentSlots = eventAppointmentStatsModel.BookedSlots;
            eventModel.BookedSlots = eventAppointmentStatsModel.FilledSlots;

            var sponsor = string.Empty;
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

            eventModel.Sponsor = sponsor;
            return eventModel;
        }
    }
}