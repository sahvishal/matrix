using Falcon.App.Core;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.CallCenter;
using Falcon.App.Core.CallCenter.Domain;
using Falcon.App.Core.CallCenter.Enum;
using Falcon.App.Core.CallCenter.ViewModels;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Infrastructure.CallCenter.Factories
{
    [DefaultImplementation]
    public class CallUploadListModelFactory : ICallUploadListModelFactory
    {
        public CallUploadListModel Create(IEnumerable<FileModel> fileModels, IEnumerable<CallUpload> callUpload, IEnumerable<OrderedPair<long, string>> uploadedbyAgentNameIdPair)
        {
            var model = new CallUploadListModel();
            var collection = new List<CallUploadViewModel>();
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

                var callUploadViewModel = new CallUploadViewModel
                {
                    File = successFile,
                    SuccessfullCustomer = cp.SuccessfullUploadCount,
                    FailedCustomer = cp.FailedUploadCount,
                    UploadTime = cp.UploadTime,
                    FailedFile = failedFile,
                    Status = ((CallUploadStatus)cp.StatusId).GetDescription(),
                    UploadedBy = agentName,
                };

                collection.Add(callUploadViewModel);
            });

            model.Collection = collection;
            return model;
        }

    }

}
