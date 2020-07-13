using System.Collections.Generic;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.ViewModels;

namespace Falcon.App.Core.Scheduling
{
    public interface IEventScheduleReportFactory
    {
        EventScheduleListModel Create(IEnumerable<Event> events, IEnumerable<Host> hosts, IEnumerable<Pod> pods, IEnumerable<EventAppointmentStatsModel> eventAppointmentStatsModels,
            IEnumerable<OrderedPair<long, int>> customersAttendeds, IEnumerable<OrderedPair<long, int>> noshowCustomerCounts, IEnumerable<long> mamoeventIds);
    }
}