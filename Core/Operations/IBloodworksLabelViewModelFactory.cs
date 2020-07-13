using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Operations.ViewModels;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.Operations
{
    public interface IBloodworksLabelViewModelFactory
    {
        IEnumerable<BloodworksLabelViewModel> Create(IEnumerable<Customer> customers, Event eventData);

        BloodworksLabelViewModel Create(Customer customer, Event eventData, IEnumerable<Test> tests);
    }
}
