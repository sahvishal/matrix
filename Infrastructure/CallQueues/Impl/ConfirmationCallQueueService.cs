using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.CallQueues.Domain;
using Falcon.App.Core.Scheduling.Interfaces;

namespace Falcon.App.Infrastructure.CallQueues.Impl
{
    [DefaultImplementation]
    public class ConfirmationCallQueueService : IConfirmationCallQueueService
    {
        private readonly IEventCustomerRepository _eventCustomerRepository; 

        public ConfirmationCallQueueService(IEventCustomerRepository eventCustomerRepository)
        {
            _eventCustomerRepository = eventCustomerRepository; 
        }

        public IEnumerable<CallQueueCustomer> GetCallQueueCustomers(long callQueueId,int noOfDays)
        {
            var eventIdCustomerIdPairs = _eventCustomerRepository.GetCustomerForConfirmationCallQueue(noOfDays);

            if (eventIdCustomerIdPairs == null || !eventIdCustomerIdPairs.Any())
                return null;

            var callQueueCustomerList = new List<CallQueueCustomer>();

            foreach (var eventIdCustomerIdPair in eventIdCustomerIdPairs)
            {
                callQueueCustomerList.Add(new CallQueueCustomer { CallQueueId = callQueueId, CustomerId = eventIdCustomerIdPair.SecondValue, EventId = eventIdCustomerIdPair.FirstValue });
            }

            return callQueueCustomerList;
        }

        //public void SaveConfirmationCallQueueCustomers(long callQueueId, int noOfDays)
        //{
        //    var callQueueCustomers = GetCallQueueCustomers(callQueueId, noOfDays);
        //    if (callQueueCustomers != null && callQueueCustomers.Any())
        //    {
        //        _logger.Info(string.Format("{0} single call queue customer found for {1} for Agent Id : {2}", callQueueCustomers.Count(), callQueue.Category, criteria.AssignedToOrgRoleUserId));
        //        _callQueueCustomerHelper.SaveCallQueueCustomer(callQueueCustomers);
        //        _logger.Info(string.Format("{0} single call queue customer saved for {1} for Agent Id : {2}", callQueueCustomers.Count(), callQueue.Category, criteria.AssignedToOrgRoleUserId));
        //    }
        //    else
        //        _logger.Info(string.Format("No call queue customer found for {0}", callQueue.Category));
        //}
    }
}
