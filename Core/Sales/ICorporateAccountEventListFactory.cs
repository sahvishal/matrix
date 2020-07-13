using System.Collections.Generic;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Sales.ViewModels;
using Falcon.App.Core.Scheduling.Domain;

namespace Falcon.App.Core.Sales
{
    public interface ICorporateAccountEventListFactory
    {
        IEnumerable<CorporateAccountEventViewModel> Create(IEnumerable<Event> events, IEnumerable<Host> hosts, IEnumerable<OrderedPair<long, int>> screenedCustomersCount,
                                                           IEnumerable<OrderedPair<long, int>> normalCustomersCount, IEnumerable<OrderedPair<long, int>> criticalCustomersCount, IEnumerable<OrderedPair<long, int>> abnormalCustomersCount);
    }
}