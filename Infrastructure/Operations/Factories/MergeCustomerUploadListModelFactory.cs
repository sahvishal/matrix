using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Operations.Enum;
using Falcon.App.Core.Operations.ViewModels;

namespace Falcon.App.Infrastructure.Operations.Factories
{
    [DefaultImplementation]
    public class MergeCustomerUploadListModelFactory : IMergeCustomerUploadListModelFactory
    {
        public MergeCustomerUploadListModel Create(IEnumerable<FileModel> fileModels, IEnumerable<MergeCustomerUpload> callUpload, 
            IEnumerable<OrderedPair<long, string>> uploadedbyAgentNameIdPair)
        {
            var model = new MergeCustomerUploadListModel();
            var collection = new List<MergeCustomerUploadViewModel>();
            callUpload.ToList().ForEach(cp =>
            {

                var agentName = "N/A";
                if (uploadedbyAgentNameIdPair != null && uploadedbyAgentNameIdPair.Any())
                {
                    agentName = uploadedbyAgentNameIdPair.Single(ap => ap.FirstValue == cp.UploadedBy).SecondValue;
                }

                var successFile = (from f in fileModels where f.Id == cp.FileId select f).Single();

                FileModel failedFile = null;

                if (cp.LogFileId.HasValue)
                {
                    failedFile = (from f in fileModels where f.Id == cp.LogFileId select f).Single();
                }

                var callUploadViewModel = new MergeCustomerUploadViewModel
                {
                    Id = cp.Id,
                    File = successFile,
                    SuccessfullCustomer = cp.SuccessUploadCount,
                    FailedCustomer = cp.FailedUploadCount,
                    UploadTime = cp.UploadTime,
                    FailedFile = failedFile,
                    Status = ((MergeCustomerUploadStatus)cp.StatusId).GetDescription(),
                    UploadedBy = agentName,
                };

                collection.Add(callUploadViewModel);
            });

            model.Collection = collection;
            return model;
        }
    }
}
