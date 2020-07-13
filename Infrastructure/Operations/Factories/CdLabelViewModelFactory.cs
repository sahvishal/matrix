using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Operations.ViewModels;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Infrastructure.Operations.Factories
{
    [DefaultImplementation]
    public class CdLabelViewModelFactory : ICdLabelViewModelFactory
    {
        public IEnumerable<CdLabelViewModel> Create(IEnumerable<EventCustomer> eventCustomers,IEnumerable<Customer> customers, Event eventData)
        {
            var listModel = new List<CdLabelViewModel>();

            foreach (var eventCustomer in eventCustomers)
            {
                var customer = customers.Where(c => c.CustomerId == eventCustomer.CustomerId).First();
                var model = new CdLabelViewModel
                                {
                                    TestDate = eventData.EventDate,
                                    CustomerName = customer.Name,
                                    CustomerId = customer.CustomerId
                                };
                
                listModel.Add(model);
            }
            return listModel;
        }
    }
}
