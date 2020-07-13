using System.Collections.Generic;
using Falcon.App.Core.Finance.ViewModels;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Scheduling.Domain;

namespace Falcon.App.Core.Finance.Interfaces
{
    public interface IDailyRecapModelFactory
    {
        DailyRecapListModel Create(IEnumerable<Event> events, IEnumerable<Host> hosts, IEnumerable<Pod> pods,
                                   IEnumerable<OrderedPair<long, int>> totalRegistration,
                                   IEnumerable<OrderedPair<long, int>> customersAttended,
                                   IEnumerable<OrderedPair<long, int>> noShowCustomers,
                                   IEnumerable<OrderedPair<long, int>> cancelledCustomers,
                                   IEnumerable<OrderedPair<long, decimal>> eventOrderAmounts,
                                   IEnumerable<OrderedPair<long, int>> eventIdLeftWithoutScreeningCustomerCountPairs,
                                   IEnumerable<OrderedPair<long, int>> totalGcIssued);
    }
}
