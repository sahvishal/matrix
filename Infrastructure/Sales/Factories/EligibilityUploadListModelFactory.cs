using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Extension;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.CallCenter.Enum;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Sales.Interfaces;
using Falcon.App.Core.Sales.ViewModels;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Infrastructure.Sales.Factories
{
    [DefaultImplementation]
    public class EligibilityUploadListModelFactory : IEligibilityUploadListModelFactory
    {
        public EligibilityUploadListModel Create(IEnumerable<FileModel> fileModels, IEnumerable<EligibilityUpload> eligibilityUpload,
                                                 IEnumerable<OrderedPair<long, string>> uploadedbyAgentNameIdPair, IEnumerable<CorporateAccount> corporateAccounts)
        {
            var model = new EligibilityUploadListModel();
            var collection = new List<EligibilityUploadViewModel>();
            eligibilityUpload.ToList().ForEach(eu =>
            {
                var account = corporateAccounts.FirstOrDefault(x => x.Id == eu.AccountId);
                var agentName = "N/A";
                if (uploadedbyAgentNameIdPair != null && uploadedbyAgentNameIdPair.Any())
                {
                    agentName = uploadedbyAgentNameIdPair.Single(ap => ap.FirstValue == eu.UploadedBy).SecondValue;
                }

                var successFile = (from f in fileModels where f.Id == eu.FileId select f).Single();

                FileModel failedFile = null;

                if (eu.LogFileId.HasValue)
                {
                    failedFile = (from f in fileModels where f.Id == eu.LogFileId select f).Single();
                }

                var eligibilityUploadViewModel = new EligibilityUploadViewModel
                {
                    File = successFile,
                    SuccessfullCustomer = eu.SuccessfullUploadCount,
                    FailedCustomer = eu.FailedUploadCount,
                    UploadTime = eu.UploadTime,
                    FailedFile = failedFile,
                    Status = ((CallUploadStatus)eu.StatusId).GetDescription(),
                    UploadedBy = agentName,
                    UploadedForAccount = account == null ? "N/A" : account.Name
                };

                collection.Add(eligibilityUploadViewModel);
            });

            model.Collection = collection;
            return model;
        }
    }
}
