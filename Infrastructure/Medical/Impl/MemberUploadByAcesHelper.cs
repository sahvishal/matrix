using System;
using System.IO;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.Application.Helper;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Sales;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.Enum;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class MemberUploadByAcesHelper : IMemberUploadByAcesHelper
    {
        private const long OrgRoleUserId = 1;
        private readonly IUniqueItemRepository<Core.Application.Domain.File> _fileRepository;
        private readonly ICorporateUploadRepository _corporateUploadRepository;

        public MemberUploadByAcesHelper(IUniqueItemRepository<Core.Application.Domain.File> fileRepository, ICorporateUploadRepository corporateUploadRepository)
        {
            _fileRepository = fileRepository;
            _corporateUploadRepository = corporateUploadRepository;
        }

        private Core.Application.Domain.File CreateFileModel(string sourceFile)
        {
            return new Core.Application.Domain.File
            {
                Path = Path.GetFileName(sourceFile),
                FileSize = DirectoryOperationsHelper.FileLength(sourceFile),
                Type = FileType.Txt,
                UploadedBy = new OrganizationRoleUser(OrgRoleUserId),
                UploadedOn = DateTime.Now
            };
        }

        private Core.Application.Domain.File UploadFile(string sourceFile)
        {

            var files = CreateFileModel(sourceFile);
            return _fileRepository.Save(files);
        }

        public CorporateUpload UploadFailedFile(string sourceFile, CorporateUpload corporateUpload)
        {
            var fileModel = UploadFile(sourceFile);

            corporateUpload.LogFileId = fileModel.Id;

            return SaveCorporateUpload(corporateUpload);

        }

        public CorporateUpload SaveCorporateUpload(CorporateUpload corporateUpload)
        {
            return _corporateUploadRepository.Save(corporateUpload);
        }

        public CorporateUpload UploadAdjustOrderFile(string sourceFile, CorporateUpload corporateUpload)
        {
            var fileModel = UploadFile(sourceFile);

            corporateUpload.AdjustOrderLogFileId = fileModel.Id;

            return SaveCorporateUpload(corporateUpload);
        }

        public CorporateUpload Upload(string sourceFile, CorporateAccount account)
        {
            var fileModel = UploadFile(sourceFile);

            var corporateUpload = new CorporateUpload
            {
                AccountId = account.Id,
                FileId = fileModel.Id,
                UploadedBy = OrgRoleUserId,
                UploadTime = DateTime.Now,
                SourceId = (long)MemberUploadSource.Aces
            };

            return SaveCorporateUpload(corporateUpload);
        }

        public CorporateUpload UpdateCorporateUpload(CorporateUpload corporateUpload, int failedCount, int totalCustomers)
        {

            corporateUpload.FailedUploadCount = failedCount;
            corporateUpload.SuccessfullUploadCount = (totalCustomers - failedCount);

            return SaveCorporateUpload(corporateUpload);
        }

    }
}