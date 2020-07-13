using System.Collections.Generic;
using Falcon.App.Core.Operations.Enum;
using Falcon.App.Core.Operations.ViewModels;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.Operations
{
    public interface ICdImageStatusModelFactory
    {
        CdImageStatusListModel Create(IEnumerable<EventCustomer> eventCustomers, IEnumerable<OrderedPair<long,
                                                                                     ShipmentStatus>> orderShipingStatus, 
                                      IEnumerable<Customer> customers, IEnumerable<Event> events);
    }
}