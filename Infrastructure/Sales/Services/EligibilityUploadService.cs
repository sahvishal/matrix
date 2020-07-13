using System.Collections.Generic;
using System.IO;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Sales;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Sales.Interfaces;
using Falcon.App.Core.Sales.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.Core.ValueTypes;
using File = Falcon.App.Core.Application.Domain.File;

namespace Falcon.App.Infrastructure.Sales.Services
{
    [DefaultImplementation]
    public class EligibilityUploadService : IEligibilityUploadService
    {
        private readonly IMediaRepository _mediaRepository;
        private readonly IEligibilityUploadRepository _eligibilityUploadRepository;
        private readonly IUniqueItemRepository<File> _fileRepository;
        private readonly IOrganizationRoleUserRepository _organizationRoleUserRepository;
        private readonly IEligibilityUploadListModelFactory _eligibilityUploadListModelFactory;
        private readonly ICorporateAccountRepository _corporateAccountRepository;

        public EligibilityUploadService(IMediaRepository mediaRepository, IEligibilityUploadRepository eligibilityUploadRepository,
                                        IUniqueItemRepository<File> fileRepository, IOrganizationRoleUserRepository organizationRoleUserRepository,
                                        IEligibilityUploadListModelFactory eligibilityUploadListModelFactory, ICorporateAccountRepository corporateAccountRepository)
        {
            _mediaRepository = mediaRepository;
            _eligibilityUploadRepository = eligibilityUploadRepository;
            _fileRepository = fileRepository;
            _organizationRoleUserRepository = organizationRoleUserRepository;
            _eligibilityUploadListModelFactory = eligibilityUploadListModelFactory;
            _corporateAccountRepository = corporateAccountRepository;
        }

        public EligibilityUploadListModel GetEligibilityUploadDetails(int pageNumber, int pageSize, EligibilityUploadListModelFilter filter, out int totalRecords)
        {
            var eligibilityUploads = (IReadOnlyCollection<EligibilityUpload>)_eligibilityUploadRepository.GetByFilter(pageNumber, pageSize, filter, out totalRecords);

            if (eligibilityUploads == null || !eligibilityUploads.Any()) return null;

            var successfileIds = eligibilityUploads.Select(s => s.FileId).ToArray();
            var failedfileIds = eligibilityUploads.Where(x => x.LogFileId.HasValue).Select(s => s.LogFileId.Value).ToArray();
            var fileIds = successfileIds.Concat(failedfileIds).ToArray();
            var accountIds = eligibilityUploads.Select(x => x.AccountId).ToArray();
            var accounts = _corporateAccountRepository.GetByIds(accountIds);

            IEnumerable<FileModel> fileModels = null;
            if (fileIds != null && fileIds.Any())
            {
                var files = _fileRepository.GetByIds(fileIds);

                if (files != null && files.Any())
                {
                    fileModels = GetFileModelFromFile(files, _mediaRepository.GetEligibilityUploadMediaFileLocation());
                }
            }
            var eligibilityUploadByIds = eligibilityUploads.Select(c => c.UploadedBy).ToArray();
            IEnumerable<OrderedPair<long, string>> uploadedbyAgentNameIdPair = null;
            uploadedbyAgentNameIdPair = _organizationRoleUserRepository.GetNameIdPairofUsers(eligibilityUploadByIds).ToArray();

            return _eligibilityUploadListModelFactory.Create(fileModels, eligibilityUploads, uploadedbyAgentNameIdPair, accounts);
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
    }
}
