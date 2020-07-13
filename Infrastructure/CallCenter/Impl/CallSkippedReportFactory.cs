using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.CallCenter;
using Falcon.App.Core.CallCenter.ViewModels;
using Falcon.App.Core.CallQueues.Domain;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Infrastructure.CallCenter.Impl
{
    [DefaultImplementation]
    public class CallSkippedReportFactory : ICallSkippedReportFactory
    {
        public IEnumerable<CallSkippedReportViewModel> Create(IReadOnlyCollection<OrderedPair<long, string>> orgRoleUserIdNamePair, IReadOnlyCollection<CallQueue> callQueues,
            IReadOnlyCollection<CorporateAccount> corpAccounts, IReadOnlyCollection<CallSkippedReportEditModel> skippedCallReportData)
        {
            var list = new List<CallSkippedReportViewModel>();
            foreach (var data in skippedCallReportData)
            {
                var record = data;

                var agentInfo = orgRoleUserIdNamePair.FirstOrDefault(x => x.FirstValue == record.AgentId);
                var customerInfo = orgRoleUserIdNamePair.FirstOrDefault(x => x.FirstValue == record.CustomerId);
                var healthPlan = corpAccounts.FirstOrDefault(x => x.Id == record.HealthPlanId);
                var callQueue = callQueues.FirstOrDefault(x => x.Id == record.CallQueueId);

                list.Add(new CallSkippedReportViewModel(record.SkipCallDate)
                {
                    AgentName = agentInfo == null ? "N/A" : agentInfo.SecondValue,
                    CallQueue = callQueue == null ? "N/A" : callQueue.Name,
                    CustomerId = record.CustomerId,
                    CustomerName = customerInfo == null ? "N/A" : customerInfo.SecondValue,
                    HealthPlan = healthPlan == null ? "N/A" : healthPlan.Name,
                    Notes = record.SkipCallNote
                });
            }
            return list;
        }
    }
}
