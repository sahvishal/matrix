using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.CallQueues.Domain;
using Falcon.App.Core.CallQueues.ViewModels;

namespace Falcon.App.Infrastructure.CallQueues.Factories
{
    [DefaultImplementation]
    public class CallQueueReportListModelFactory : ICallQueueReportListModelFactory
    {
        public CallQueueReportListModel Create(IEnumerable<CallQueueAssignment> callQueueAssignments, IEnumerable<CallQueue> callQueues, IEnumerable<OrderedPair<long, string>> idNamePairs,
            IEnumerable<CallQueueCustomerStats> totalCustomerStats, IEnumerable<CallQueueCustomerStats> contactedCustomerStats)
        {
            var model = new CallQueueReportListModel();
            var collection = new List<CallQueueReportModel>();

            callQueueAssignments.ToList().ForEach(cqa =>
            {
                var idNamePair = idNamePairs.Where(inp => inp.FirstValue == cqa.AssignedOrgRoleUserId).Select(inp => inp).Single();
                var callQueue = callQueues.Where(cq => cq.Id == cqa.CallQueueId).Select(cq => cq).Single();
                var totalCustomerStat = totalCustomerStats.Where(tcs => tcs.CallQueueId == cqa.CallQueueId && tcs.AssignedToOrgRoleUserId == cqa.AssignedOrgRoleUserId).Select(tcs => tcs).SingleOrDefault();
                var contactedCustomerStat = contactedCustomerStats.Where(ccs => ccs.CallQueueId == cqa.CallQueueId && ccs.AssignedToOrgRoleUserId == cqa.AssignedOrgRoleUserId).Select(ccs => ccs).SingleOrDefault();

                var callQueueReportModel = new CallQueueReportModel()
                {
                    AgentName = idNamePair.SecondValue,
                    QueueName = callQueue.Name,
                    TotalCustomerAssigned = totalCustomerStat != null ? totalCustomerStat.Count : 0,
                    TotalCustomerContacted = contactedCustomerStat != null ? contactedCustomerStat.Count : 0
                };
                collection.Add(callQueueReportModel);
            });

            model.Collection = collection;
            return model;
        }
    }
}
