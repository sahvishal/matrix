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
    public class EasiestToConvertCallQueueService : IEasiestToConvertCallQueueService
    {
        private readonly IProspectCustomerRepository _prospectCustomerRepository;

        public EasiestToConvertCallQueueService(IProspectCustomerRepository prospectCustomerRepository)
        {
            _prospectCustomerRepository = prospectCustomerRepository;
        }

        public IEnumerable<CallQueueCustomer> GetCallQueueCustomers(long callQueueId, DateTime? lastGeneratedDate)
        {
            var prospects = _prospectCustomerRepository.GetEasiestToConvertProspect(lastGeneratedDate);
            if (prospects == null || !prospects.Any())
                return null;

            var callQueueCustomerList = new List<CallQueueCustomer>();

            foreach (var pc in prospects)
            {
                callQueueCustomerList.Add(new CallQueueCustomer { CallQueueId = callQueueId, CustomerId = pc.SecondValue, ProspectCustomerId = pc.FirstValue });
            }

            return callQueueCustomerList;
        }
    }
}
