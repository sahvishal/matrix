using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Geo.ViewModels;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Operations.ViewModels;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Infrastructure.Operations.Factories
{
    [DefaultImplementation]
    public class BatchLabelViewModelFactory : IBatchLabelViewModelFactory
    {
        public IEnumerable<BatchLabelViewModel> Create(IEnumerable<Customer> customers, IEnumerable<EventCustomer> eventCustomers)
        {
            return (from eCustomer in eventCustomers
                    select customers.First(x => x.CustomerId == eCustomer.CustomerId)
                        into customer
                        let address = (AddressViewModel)(customer.Address == null ? null : Mapper.Map<Address, AddressViewModel>(customer.Address))
                        select new BatchLabelViewModel
                        {
                            CustomerAddress = address,
                            CustomerName = customer.Name,
                            CustomerId = customer.CustomerId
                        }).ToList();
        }
    }
}