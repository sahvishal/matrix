using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medicare.ViewModels;
using Falcon.App.Core.Users.Domain;
using System.Collections.Generic;

namespace Falcon.App.Core.Medicare
{
    public interface IMedicareFactory
    {
        MedicareCustomerViewModel CreateCustomerViewModel(Customer domain);
        void UpdateCustomer(MedicareCustomerViewModel model, Customer domain);
        IEnumerable<MedicareEventCustomerAcesViewModel> GetMedicareEventCustomerAcesViewModelList(IEnumerable<EventCustomerResult> eventCustomerResults, IEnumerable<Customer> customers);
    }
}
