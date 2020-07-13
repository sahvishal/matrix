using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.CallQueues.Domain;
using Falcon.App.Core.Users;

namespace Falcon.App.Infrastructure.CallQueues.Impl
{
    [DefaultImplementation]
    public class CallBackCallQueueService : ICallBackCallQueueService
    {
        private readonly IProspectCustomerRepository _prospectCustomerRepository;


        public CallBackCallQueueService(IProspectCustomerRepository prospectCustomerRepository)
        {
            _prospectCustomerRepository = prospectCustomerRepository;
        }

        public IEnumerable<CallQueueCustomer> GetCallQueueCustomers(long callQueueId, DateTime? lastGeneratedDate)
        {
            var prospectCustomers = _prospectCustomerRepository.GetCallBackQueue(lastGeneratedDate);

            if (prospectCustomers == null || !prospectCustomers.Any())
                return null;

            var callQueueCustomerList = new List<CallQueueCustomer>();
             
            foreach (var prospectCustomer in prospectCustomers)
            {
                callQueueCustomerList.Add(new CallQueueCustomer { CallQueueId = callQueueId, CustomerId = prospectCustomer.CustomerId, ProspectCustomerId = prospectCustomer.Id ,CallDate = prospectCustomer.CallBackRequestedDate.Value});
            }

            return callQueueCustomerList;
        }
    }
}
