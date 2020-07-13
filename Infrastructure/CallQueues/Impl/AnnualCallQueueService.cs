using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.CallQueues.Domain;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Enum;

namespace Falcon.App.Infrastructure.CallQueues.Impl
{
    [DefaultImplementation]
    public class AnnualCallQueueService : IAnnualCallQueueService
    {
        private readonly ICustomerRepository _customerRepository;

        public AnnualCallQueueService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public IEnumerable<CallQueueCustomer> GetCallQueueCustomers(long callQueueId)
        {
            var annualdate = DateTime.Now.Date.AddYears(-1);
            var customers = _customerRepository.GetCustomerForAnnualNotification(annualdate, 0);

            if (customers != null)
                customers = customers.Where(cp => cp.DoNotContactTypeId == null || cp.DoNotContactTypeId.Value == (long)DoNotContactType.DoNotMail).ToArray();

            if (customers == null || !customers.Any())
                return null;

            var callQueueCustomerList = new List<CallQueueCustomer>();

            foreach (var customer in customers)
            {
                callQueueCustomerList.Add(new CallQueueCustomer { CallQueueId = callQueueId, CustomerId = customer.CustomerId });
            }

            return callQueueCustomerList;
        }
    }
}
