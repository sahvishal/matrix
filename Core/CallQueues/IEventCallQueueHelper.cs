using System.Collections.Generic;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.CallQueues
{
    public interface IEventBasicInfoListHelper
    {
        EventBasicInfoListModel EventBasicInfoListForCallQueue(IEnumerable<Event> events);
        EventBasicInfoViewModel EventBasicInfoViewModel(IEnumerable<Host> hosts, Event theEvent, IEnumerable<Pod> pods, IEnumerable<EventAppointmentStatsModel> eventAppointmentStatsModels, IEnumerable<OrderedPair<long, long>> eventHpPairs, IEnumerable<Organization> organizations);

        HealthPlanEventViewModel HealthPlanEventViewModel(IEnumerable<Host> hosts, Event theEvent, IEnumerable<Pod> pods, IEnumerable<EventAppointmentStatsModel> eventAppointmentStatsModels);

        ShortEventInfoViewModel ShortEventInfoViewModel(IEnumerable<Host> hosts, Event theEvent, IEnumerable<Pod> pods,IEnumerable<EventAppointmentStatsModel> eventAppointmentStatsModels,IEnumerable<OrderedPair<long, long>> eventHpPairs, 
            IEnumerable<Organization> organizations);
    }

}