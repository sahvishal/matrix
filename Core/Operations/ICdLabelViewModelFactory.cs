using System.Collections.Generic;
using Falcon.App.Core.Operations.ViewModels;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.Operations
{
    public interface ICdLabelViewModelFactory
    {
        IEnumerable<CdLabelViewModel> Create(IEnumerable<EventCustomer> eventCustomers, IEnumerable<Customer> customers, Event eventData);
    }
}
