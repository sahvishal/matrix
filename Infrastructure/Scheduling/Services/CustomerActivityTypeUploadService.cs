using Falcon.App.Core;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Extension;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.Core.ValueTypes;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using File = Falcon.App.Core.Application.Domain.File;

namespace Falcon.App.Infrastructure.Scheduling.Services
{
    [DefaultImplementation]
    public class CustomerActivityTypeUploadService : ICustomerActivityTypeUploadService
    {
        private readonly IMediaRepository _mediaRepository;
        private readonly ICustomerActivityTypeUploadRepository _customerActivityTypeUploadRepository;
        private readonly IUniqueItemRepository<File> _fileRepository;
        private readonly IOrganizationRoleUserRepository _organizationRoleUserRepository;

        public CustomerActivityTypeUploadService(IMediaRepository mediaRepository, ICustomerActivityTypeUploadRepository customerActivityTypeUploadRepository,
            IUniqueItemRepository<File> fileRepository, IOrganizationRoleUserRepository organizationRoleUserRepository)
        {
            _mediaRepository = mediaRepository;
            _customerActivityTypeUploadRepository = customerActivityTypeUploadRepository;
            _fileRepository = fileRepository;
            _organizationRoleUserRepository = organizationRoleUserRepository;
        }
        public CustomerActivityTypeUploadListModel GetCustomerActivityTypeUploadDetails(int pageNumber, int pageSize, CustomerActivityTypeUploadListModelFilter filter, out int totalRecords)
        {
            var customerActivityTypeUploads = (IReadOnlyCollection<CustomerActivityTypeUpload>)_customerActivityTypeUploadRepository.GetByFilter(pageNumber, pageSize, filter, out totalRecords);

            if (customerActivityTypeUploads == null || !customerActivityTypeUploads.Any()) return null;

            var successfileIds = customerActivityTypeUploads.Select(s => s.FileId).ToArray();
            var failedfileIds = customerActivityTypeUploads.Where(x => x.LogFileId.HasValue).Select(s => s.LogFileId.Value).ToArray();
            var fileIds = successfileIds.Concat(failedfileIds).ToArray();

            IEnumerable<FileModel> fileModels = null;
            if (fileIds != null && fileIds.Any())
            {
                var files = _fileRepository.GetByIds(fileIds);

                if (files != null && files.Any())
                {
                    fileModels = GetFileModelFromFile(files, _mediaRepository.GetCustomerActivityTypeUploadMediaFileLocation());
                }
            }
            var customerActivityTypeUploadByIds = customerActivityTypeUploads.Select(c => c.UploadedBy).ToArray();
            IEnumerable<OrderedPair<long, string>> uploadedbyNameIdPair = null;
            uploadedbyNameIdPair = _organizationRoleUserRepository.GetNameIdPairofUsers(customerActivityTypeUploadByIds).ToArray();

            return GetListModel(fileModels, customerActivityTypeUploads, uploadedbyNameIdPair);
        }

        private IEnumerable<FileModel> GetFileModelFromFile(IEnumerable<File> files, MediaLocation location)
        {
            var collection = new List<FileModel>();
            files.ToList().ForEach(f =>
            {
                var fileModel = new FileModel
                {
                    Id = f.Id,
                    Caption = Path.GetFileNameWithoutExtension(f.Path),
                    FileName = f.Path,
                    FileSize = f.FileSize,
                    FileType = (long)f.Type,
                    PhisicalPath = f.Path,
                    UploadedBy = f.UploadedBy.Id,
                    Url = location.Url
                };
                collection.Add(fileModel);
            });
            return collection;
        }

        private CustomerActivityTypeUploadListModel GetListModel(IEnumerable<FileModel> fileModels, IEnumerable<CustomerActivityTypeUpload> eligibilityUpload,
                                                 IEnumerable<OrderedPair<long, string>> uploadedbyNameIdPair)
        {
            var model = new CustomerActivityTypeUploadListModel();
            var collection = new List<CustomerActivityTypeUploadViewModel>();
            eligibilityUpload.ToList().ForEach(eu =>
            {
                var uploadedBy = "N/A";
                if (uploadedbyNameIdPair != null && uploadedbyNameIdPair.Any())
                {
                    uploadedBy = uploadedbyNameIdPair.Single(ap => ap.FirstValue == eu.UploadedBy).SecondValue;
                }

                var successFile = (from f in fileModels where f.Id == eu.FileId select f).Single();

                FileModel failedFile = null;

                if (eu.LogFileId.HasValue)
                {
                    failedFile = (from f in fileModels where f.Id == eu.LogFileId select f).Single();
                }

                var eligibilityUploadViewModel = new CustomerActivityTypeUploadViewModel
                {
                    File = successFile,
                    SuccessfullCustomer = eu.SuccessfullUploadCount,
                    FailedCustomer = eu.FailedUploadCount,
                    UploadTime = eu.UploadTime,
                    FailedFile = failedFile,
                    Status = ((Falcon.App.Core.CallCenter.Enum.CallUploadStatus)eu.StatusId).GetDescription(),
                    UploadedBy = uploadedBy
                };

                collection.Add(eligibilityUploadViewModel);
            });

            model.Collection = collection;
            return model;
        }
    }
}
