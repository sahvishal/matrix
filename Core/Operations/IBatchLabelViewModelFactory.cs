using System.Collections.Generic;
using Falcon.App.Core.Operations.ViewModels;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.Operations
{
    public interface IBatchLabelViewModelFactory
    {
        IEnumerable<BatchLabelViewModel> Create(IEnumerable<Customer> customers, IEnumerable<EventCustomer> eventCustomers);
    }
}