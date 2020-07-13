using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.CallQueues.Domain;
using Falcon.App.Core.Scheduling.Interfaces;

namespace Falcon.App.Infrastructure.CallQueues.Impl
{
    [DefaultImplementation]
    public class UpsellCallQueueService : IUpsellCallQueueService
    {
        private readonly IEventCustomerRepository _eventCustomerRepository;

        public UpsellCallQueueService(IEventCustomerRepository eventCustomerRepository)
        {
            _eventCustomerRepository = eventCustomerRepository;
        }

        public IEnumerable<CallQueueCustomer> GetCallQueueCustomers(long callQueueId, decimal amount, int days)
        {
            var eventIdcustomerIdPairs = _eventCustomerRepository.GetCustomersForUpsellCallQueue(amount, days);

            if (eventIdcustomerIdPairs == null || !eventIdcustomerIdPairs.Any())
                return null;

            var callQueueCustomerList = new List<CallQueueCustomer>();

            foreach (var eventIdcustomerIdPair in eventIdcustomerIdPairs)
            {
                callQueueCustomerList.Add(new CallQueueCustomer { CallQueueId = callQueueId, CustomerId = eventIdcustomerIdPair.SecondValue, EventId = eventIdcustomerIdPair.FirstValue});
            }

            return callQueueCustomerList;
        }
    }
}
