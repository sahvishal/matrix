using System.Collections.Generic;
using Falcon.App.Core.CallCenter.ViewModels;
using Falcon.App.Core.CallQueues.Domain;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.CallCenter
{
    public interface ICallSkippedReportFactory
    {
        IEnumerable<CallSkippedReportViewModel> Create(IReadOnlyCollection<OrderedPair<long, string>> orgRoleUserIdNamePair, IReadOnlyCollection<CallQueue> callQueues, IReadOnlyCollection<CorporateAccount> corpAccounts,
            IReadOnlyCollection<CallSkippedReportEditModel> skippedCallReportData);
    }
}
