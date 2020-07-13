using System.Collections.Generic;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.ViewModels;

namespace Falcon.App.Core.Scheduling
{
    public interface IDailyVolumeFactory
    {
        DailyVolumeListModel Create(IEnumerable<Event> events, IEnumerable<Host> hosts, IEnumerable<Pod> pods, IEnumerable<EventAppointmentStatsModel> eventAppointmentStatsModels,
            IEnumerable<OrderedPair<long, string>> eventIdCorporateNamePairs, List<OrderedPair<long, int>> noShowCustomers,List<OrderedPair<long, int>> customersAttended,
            List<OrderedPair<long, int>> cancellationOnDayofEvent, List<OrderedPair<long, int>> movedOutEventCustomerCountPair,  List<OrderedPair<long, int>> leftWithoutScreeningCustomers);
    }
}