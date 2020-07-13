using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Extension;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Sales;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Sales.Enum;
using Falcon.App.Core.Sales.ViewModels;

namespace Falcon.App.Infrastructure.Sales.Factories
{
    [DefaultImplementation]
    public class CustomerPhoneNumberListModelFactory : ICustomerPhoneNumberListModelFactory
    {
        public CustomerPhoneNumberListModel Create(IEnumerable<FileModel> fileModels, IEnumerable<CustomerPhoneNumberUpdateUpload> phoneNumberUploads, IEnumerable<OrderedPair<long, string>> uploadedbyAgentNameIdPair)
        {
            var model = new CustomerPhoneNumberListModel();
            var collection = new List<CustomerPhoneNumberUpdateUploadViewModel>();

            foreach (var phoneNumberUpload in phoneNumberUploads)
            {
                var agentName = "N/A";
                if (uploadedbyAgentNameIdPair != null && uploadedbyAgentNameIdPair.Any())
                {
                    agentName = uploadedbyAgentNameIdPair.Single(ap => ap.FirstValue == phoneNumberUpload.UploadedByOrgRoleUserId).SecondValue;
                }

                var successFile = (from f in fileModels where f.Id == phoneNumberUpload.FileId select f).Single();

                FileModel failedFile = null;
                if (phoneNumberUpload.LogFileId.HasValue)
                {
                    failedFile = (from f in fileModels where f.Id == phoneNumberUpload.LogFileId select f).Single();
                }

                var customerPhoneNumberUpdateUploadViewModel = new CustomerPhoneNumberUpdateUploadViewModel
                {
                    File = successFile,
                    SuccessfullCustomer = phoneNumberUpload.SuccessUploadCount,
                    FailedCustomer = phoneNumberUpload.FailedUploadCount,
                    UploadTime = phoneNumberUpload.UploadTime,
                    FailedFile = failedFile,
                    Status = ((PhoneNumberUploadStatus) phoneNumberUpload.StatusId).GetDescription(),
                    UploadedBy = agentName,
                };

                collection.Add(customerPhoneNumberUpdateUploadViewModel);
            }
            model.Collection = collection;
            return model;
        }
    }
}
