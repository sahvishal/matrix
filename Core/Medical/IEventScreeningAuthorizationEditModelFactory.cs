using System.Collections.Generic;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.Medical
{
    public interface IEventScreeningAuthorizationEditModelFactory
    {
        EventScreeningAuthorizationEditModel Create(Event theEvent, IEnumerable<EventTest> eventTests,
                                                    IEnumerable<EventCustomer> eventCustomers,
                                                    IEnumerable<Customer> customers,
                                                    IEnumerable<EventPackage> packages,
                                                    IEnumerable<OrderedPair<long, long>> ecIdPackageIdpairs,
                                                    IEnumerable<OrderedPair<long, long>> ecIdTestIdPairs, Host host);
    }
}
