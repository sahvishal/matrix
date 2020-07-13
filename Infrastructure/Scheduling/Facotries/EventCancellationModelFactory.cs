using System.Collections.Generic;
using System.Linq; 
using AutoMapper;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Geo.ViewModels;
using Falcon.App.Core.Sales.Interfaces;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users;

namespace Falcon.App.Infrastructure.Scheduling.Facotries
{
    [DefaultImplementation]
    public class EventCancellationModelFactory : IEventCancellationModelFactory
    {
        private readonly ILookupRepository _lookupRepository;
        private readonly IOrganizationRoleUserRepository _organizationRoleUserRepository;
        private readonly IHostRepository _hostRepository;

        public EventCancellationModelFactory(ILookupRepository lookupRepository,IOrganizationRoleUserRepository organizationRoleUserRepository,IHostRepository hostRepository)
        {
            _lookupRepository = lookupRepository;
            _organizationRoleUserRepository = organizationRoleUserRepository;
            _hostRepository = hostRepository;
        }

        public EventCancellationListModel Create(IEnumerable<Event> events)
        {
            var eventIds = events.Select(x => x.Id);
            var agentIds = events.Select(e => e.DataRecorderMetaData.DataRecorderModifier != null ? e.DataRecorderMetaData.DataRecorderModifier.Id : e.DataRecorderMetaData.DataRecorderCreator.Id).Distinct();
            var agents = _organizationRoleUserRepository.GetNameIdPairofUsers(agentIds.ToArray());
            var eventCancellationReasons = _lookupRepository.GetByLookupId((long)EventCancellationReason.DateChange); 
            var eventModels = new List<EventCancellationModel>();
            var hosts = _hostRepository.GetEventHosts(eventIds); 

            foreach (var @event in events) 
            {
                var eventModel = new EventCancellationModel();
                eventModel.EventId = @event.Id;
                eventModel.EventDate = @event.EventDate;
                eventModel.Notes = @event.EventNotes;
                if (@event.EventCancellationReasonId.HasValue)
                {
                    eventModel.Reason = eventCancellationReasons.First(x => x.Id == @event.EventCancellationReasonId).DisplayName;
                }
                else
                {
                    eventModel.Reason = "N/A";
                }
                eventModel.AgentName = agents.First(x => x.FirstValue == (@event.DataRecorderMetaData.DataRecorderModifier != null ? @event.DataRecorderMetaData.DataRecorderModifier.Id : @event.DataRecorderMetaData.DataRecorderCreator.Id)).SecondValue;
                var host = hosts.First(h => h.Id == @event.HostId);
                eventModel.HostName = host.OrganizationName;
                eventModel.HostAddress = Mapper.Map<Address, AddressViewModel>(host.Address);
                eventModels.Add(eventModel);
            }
            return new EventCancellationListModel() { Collection = eventModels };
        }
    }
}
