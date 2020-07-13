using System;
using System.Collections.Generic;
using Falcon.App.Core.CallCenter.Domain;
using Falcon.App.Core.CallQueues.Domain;
using Falcon.App.Core.CallQueues.ViewModels;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.CallQueues
{
    public interface ICallQueueListModelFactory
    {
        CallQueueListModel Create(IEnumerable<CallQueue> callQueues, IEnumerable<CallQueueCriteria> callQueueCriterias, IEnumerable<Criteria> criterias, IEnumerable<CallQueueAssignment> callQueueAssignments,
            IEnumerable<OrderedPair<long, string>> idNamePairs, IEnumerable<OrderedPair<long, long>> callQueueIdTotalCustomersInQueuePairs, IEnumerable<OrderedPair<long, long>> callQueueIdTotalCustomersPairs,
            IEnumerable<OrderedPair<long, long>> callQueueIdTotalCustomersContactedPairs);

        HealthPlanCallQueueListModel CreateHealthPlanCallQueueList(IEnumerable<HealthPlanCallQueueCriteria> callQueueCriterias, IEnumerable<OrderedPair<long, string>> idNamePairs,
            IEnumerable<CallQueue> healthPlanCallQueues, IEnumerable<CorporateAccount> healthPlan, IEnumerable<HealthPlanCriteriaAssignment> healthPlanCriteriaAssignments, IEnumerable<Campaign> campaigns,
            IEnumerable<HealthPlanCriteriaTeamAssignment> healthPlanCriteriaTeamAssignment, IEnumerable<OrderedPair<long, string>> teamIdNamePairs, IEnumerable<OrderedPair<long, long>> criteriaCustomerCountPairs,
            IEnumerable<OrderedPair<long, DateTime>> criteriaDirectMailDates, bool showAssignmentMetaData = false);
    }
}
