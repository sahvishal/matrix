using System;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class PhysicianPartnerResultExportPollingAgent : IPhysicianPartnerResultExportPollingAgent
    {
        private readonly IPhysicianPartnerResultExportService _physicianPartnerResultExportService;
        private readonly IUniqueItemRepository<CorporateAccount> _corporateAccountRepository;
        private readonly IPgpFileEncryptionHelper _pgpFileEncryptionHelper;
        private readonly long _accountId;

        private readonly string _destinationDirectory;
        public PhysicianPartnerResultExportPollingAgent(IPhysicianPartnerResultExportService physicianPartnerResultExportService, ISettings settings, IUniqueItemRepository<CorporateAccount> corporateAccountRepository, IPgpFileEncryptionHelper pgpFileEncryptionHelper)
        {
            _physicianPartnerResultExportService = physicianPartnerResultExportService;
            _corporateAccountRepository = corporateAccountRepository;
            _pgpFileEncryptionHelper = pgpFileEncryptionHelper;
            _destinationDirectory = settings.PhysicianPartnerResultReportDownloadPath;
            _accountId = settings.PhysicianPartnerAccountId;
        }

        public void PollForResultExport()
        {
            var account = _corporateAccountRepository.GetById(_accountId);
            _physicianPartnerResultExportService.ResultExport();

            var fileName = _destinationDirectory + string.Format(@"\ResultExport_{0}.csv", DateTime.Now.Date.ToString("yyyyMMdd"));

            if (System.IO.File.Exists(fileName))
            {
                _pgpFileEncryptionHelper.EncryptFile(account, fileName);
            }
        }
    }
}
