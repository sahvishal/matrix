using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Sales.ViewModels;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.Sales.Interfaces
{
    public interface IEligibilityUploadListModelFactory
    {
        EligibilityUploadListModel Create(IEnumerable<FileModel> fileModels, IEnumerable<EligibilityUpload> eligibilityUpload,
            IEnumerable<OrderedPair<long, string>> uploadedbyAgentNameIdPair, IEnumerable<CorporateAccount> corporateAccounts);
    }
}
