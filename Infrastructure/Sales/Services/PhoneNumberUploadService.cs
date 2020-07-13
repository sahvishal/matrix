using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Sales;
using Falcon.App.Core.Sales.Interfaces;
using Falcon.App.Core.Sales.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.Core.ValueTypes;

namespace Falcon.App.Infrastructure.Sales.Services
{
    [DefaultImplementation]
    public class PhoneNumberUploadService : IPhoneNumberUploadService
    {
        private readonly ICustomerPhoneNumberUpdateUploadRepository _customerPhoneNumberUpdateUploadRepository;
        private readonly IUniqueItemRepository<File> _fileRepository;
        private readonly IMediaRepository _mediaRepository;
        private readonly IOrganizationRoleUserRepository _organizationRoleUserRepository;
        private readonly ICustomerPhoneNumberListModelFactory _customerPhoneNumberListModelFactory;

        public PhoneNumberUploadService(ICustomerPhoneNumberUpdateUploadRepository customerPhoneNumberUpdateUploadRepository, IUniqueItemRepository<File> fileRepository,
            IMediaRepository mediaRepository,IOrganizationRoleUserRepository organizationRoleUserRepository,ICustomerPhoneNumberListModelFactory customerPhoneNumberListModelFactory)
        {
            _customerPhoneNumberUpdateUploadRepository = customerPhoneNumberUpdateUploadRepository;
            _fileRepository = fileRepository;
            _mediaRepository = mediaRepository;
            _organizationRoleUserRepository = organizationRoleUserRepository;
            _customerPhoneNumberListModelFactory = customerPhoneNumberListModelFactory;
        }

        public CustomerPhoneNumberListModel GetPhoneNumberUploadDetails(CustomerPhoneNumberUpdateModelFilter filter, int pageNumber, int pageSize, out int totalRecords)
        {
            var phoneNumberUploads = _customerPhoneNumberUpdateUploadRepository.GetByFilter(pageNumber, pageSize, filter, out totalRecords);

            if (phoneNumberUploads == null || !phoneNumberUploads.Any())
                return null;

            var successFieldIds = phoneNumberUploads.Select(s => s.FileId).ToArray();
            var failedFileIds = phoneNumberUploads.Where(x => x.LogFileId.HasValue).Select(x => x.LogFileId.Value).ToArray();
            var totalFileIds = successFieldIds.Concat(failedFileIds);

            IEnumerable<FileModel> fileModels = null;
            if (!totalFileIds.IsNullOrEmpty())
            {
                var files = _fileRepository.GetByIds(totalFileIds);
                if (files != null && files.Any())
                {
                    fileModels = GetFileModelFromFile(files, _mediaRepository.GetCustomerPhoneNumberUploadLocation());
                }
            }

            var phoneNumberUploadedByIds = phoneNumberUploads.Select(x => x.UploadedByOrgRoleUserId).ToArray();
            IEnumerable<OrderedPair<long, string>> uploadedbyAgentNameIdPair = null;
            if (!phoneNumberUploadedByIds.IsNullOrEmpty())
            {
                uploadedbyAgentNameIdPair = _organizationRoleUserRepository.GetNameIdPairofUsers(phoneNumberUploadedByIds).ToArray();
            }

            return _customerPhoneNumberListModelFactory.Create(fileModels, phoneNumberUploads, uploadedbyAgentNameIdPair);
        }

        private IEnumerable<FileModel> GetFileModelFromFile(IEnumerable<File> files, MediaLocation location)
        {
            var collection = new List<FileModel>();
            files.ToList().ForEach(f =>
            {
                var fileModel = new FileModel
                {
                    Id = f.Id,
                    Caption = System.IO.Path.GetFileNameWithoutExtension(f.Path),
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
    }
}
