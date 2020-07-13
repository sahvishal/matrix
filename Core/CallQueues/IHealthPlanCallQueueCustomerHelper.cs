using System.Collections.Generic;
using Falcon.App.Core.CallQueues.Domain;

namespace Falcon.App.Core.CallQueues
{
    public interface IHealthPlanCallQueueCustomerHelper
    {
        void SaveCallQueueCustomer(IEnumerable<CallQueueCustomer> callQueueCustomers, long healthPlanId, long callQueueCriteriaId, long callQueueId);
        void SaveCallQueueCustomerForFillEvent(IEnumerable<OrderedPair<long, long>> eventCustomersPair, long criteriaId, long healthPlanId, long callQueueId, IEnumerable<long> customerIds);//, IEnumerable<long> eventids
        void SaveCallQueueCustomerForMailRound(IEnumerable<CallQueueCustomer> callQueueCustomers, long healthPlanId, long callQueueCriteriaId, long callQueueId, long campaignId);
        void SaveCallQueueCustomersForConfirmation(IEnumerable<CallQueueCustomer> callQueueCustomers, long healthPlanId, long callQueueCriteriaId, long callQueueId);
    }
}