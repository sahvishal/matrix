using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Extension;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Operations.Enum;
using Falcon.App.Core.Operations.ViewModels;

namespace Falcon.App.Infrastructure.Operations.Factories
{
    [DefaultImplementation]
    public class StaffEventScheduleUploadListModelFactory : IStaffEventScheduleUploadListModelFactory
    {
        public StaffEventScheduleUploadListModel Create(IEnumerable<FileModel> fileModels, IEnumerable<StaffEventScheduleUpload> staffEventScheduleUpload,
            IEnumerable<OrderedPair<long, string>> uploadedbyAgentNameIdPair)
        {
            var model = new StaffEventScheduleUploadListModel();
            var collection = new List<StaffEventScheduleUploadViewModel>();

            staffEventScheduleUpload.ToList().ForEach(eu =>
            {
                var agentName = "N/A";
                if (uploadedbyAgentNameIdPair != null && uploadedbyAgentNameIdPair.Any())
                {
                    agentName = uploadedbyAgentNameIdPair.Single(ap => ap.FirstValue == eu.UploadedByOrgRoleUserId).SecondValue;
                }
                var successFile = (from f in fileModels where f.Id == eu.FileId select f).Single();
                FileModel failedFile = null;
                if (eu.LogFileId.HasValue)
                {
                    failedFile = (from f in fileModels where f.Id == eu.LogFileId select f).Single();
                }
                var eligibilityUploadViewModel = new StaffEventScheduleUploadViewModel
                {
                    File = successFile,
                    SuccessfullCustomer = eu.SuccessUploadCount,
                    FailedCustomer = eu.FailedUploadCount,
                    UploadTime = eu.UploadTime,
                    FailedFile = failedFile,
                    Status = ((StaffEventScheduleParseStatus)eu.StatusId).GetDescription(),
                    UploadedBy = agentName,
                };
                collection.Add(eligibilityUploadViewModel);
            });

            model.Collection = collection;
            return model;
        }
    }
}
