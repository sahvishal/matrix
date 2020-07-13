using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Infrastructure.Application.Impl;

namespace Falcon.App.Infrastructure.Scheduling.Impl
{
    [DefaultImplementation]
    public class WellCareToWellmedAppointmentBookExportPollingAgent : IWellCareToWellmedAppointmentBookExportPollingAgent
    {
        private readonly IEventCustomerReportingService _eventCustomerReportingService;
        
        private readonly ICustomSettingManager _customSettingManager;
        private readonly IUniqueItemRepository<CorporateAccount> _corporateAccountRepository;
        private readonly IPgpFileEncryptionHelper _pgpFileEncryptionHelper;
        private readonly ILogger _logger;

        private readonly string _destinationAppointmentBookedReportPath;
        private readonly string _destinationSftpFolderAppointmentBookedReportPath;
        private readonly string _appointmentSettings;

        private readonly IEnumerable<long> _accountIds;
        private readonly DateTime _cutOfDate;

        private readonly string _sftpHost;
        private readonly string _sftpUserName;
        private readonly string _sftpPassword;
        private readonly bool _sendReportToSftp;

        private readonly IAppointmentBookedExportCsvHelper _appointmentBookedExportCsvHelper;

        public WellCareToWellmedAppointmentBookExportPollingAgent(IEventCustomerReportingService eventCustomerReportingService,
            ILogManager logManager, ISettings settings, ICustomSettingManager customSettingManager,
            IUniqueItemRepository<CorporateAccount> corporateAccountRepository, IPgpFileEncryptionHelper pgpFileEncryptionHelper,
            IAppointmentBookedExportCsvHelper appointmentBookedExportCsvHelper)
        {
            _logger = logManager.GetLogger("WellCareToWellmedAppointmentBookedReport");
            _eventCustomerReportingService = eventCustomerReportingService;
            
            _customSettingManager = customSettingManager;
            _corporateAccountRepository = corporateAccountRepository;
            _pgpFileEncryptionHelper = pgpFileEncryptionHelper;

            _appointmentSettings = settings.WellmedAppointmentBookedReportDownloadSettings;
            _destinationAppointmentBookedReportPath = settings.WellmedAppointmentBookedReportDownloadPath;
            _destinationSftpFolderAppointmentBookedReportPath = settings.WellmedSftpAppointmentBookedReportDownloadPath;

            _cutOfDate = settings.PcpDownloadCutOfDate;

            _sftpHost = settings.WellmedSftpHost;
            _sftpUserName = settings.WellmedSftpUserName;
            _sftpPassword = settings.WellmedSftpPassword;

            _sendReportToSftp = settings.SendReportToWellmedSftp;
            _appointmentBookedExportCsvHelper = appointmentBookedExportCsvHelper;

            _accountIds = settings.WellCareToWellmedAccountId;
        }

        public void PollForAppointmentBookExport()
        {
            try
            {
                if (_accountIds.IsNullOrEmpty()) return;

                var accounts = (_corporateAccountRepository).GetByIds(_accountIds);

                if (accounts.IsNullOrEmpty())
                {
                    _logger.Info("Accounts can't be null");
                    return;
                }

                foreach (var account in accounts)
                {
                    _logger.Info("Running for account " + account.Tag);
                    var list = new List<AppointmentsBookedModel>();

                    var toDate = DateTime.Today.GetLastDateOfYear();
                    var destinationPath = string.Format(_destinationAppointmentBookedReportPath, toDate.Year);
                    destinationPath = Path.Combine(destinationPath, account.FolderName);

                    var sourcePath = destinationPath + string.Format(@"\WCR_AppointmentBookedReport_{0}.csv", DateTime.Today.ToString("yyyyMMdd"));

                    var appointmentSettings = string.Format(_appointmentSettings, "WellCareToWellmed");
                    var customSettings = _customSettingManager.Deserialize(appointmentSettings);
                    customSettings = customSettings ?? new CustomSettings();

                    var fromDate = (customSettings.LastTransactionDate == null) ? _cutOfDate : DateTime.Today.GetFirstDateOfYear();

                    _logger.Info(string.Format("Generating AppointmentBooked for accountId {0} and account tag {1}. ", account.Id, account.Tag));

                    CreateDistinationDirectory(destinationPath);

                    list.AddRange(AppointmentsBooked(new AppointmentsBookedListModelFilter { EventFrom = fromDate, EventTo = toDate.Date, AccountId = account.Id, Tag = account.Tag }));

                    if (File.Exists(sourcePath))
                    {
                        sourcePath = _pgpFileEncryptionHelper.EncryptFile(account, sourcePath);
                    }

                    customSettings.LastTransactionDate = toDate;
                    _customSettingManager.SerializeandSave(appointmentSettings, customSettings);

                    if (list.Any())
                    {
                        _appointmentBookedExportCsvHelper.WriteCsv(list, sourcePath, _logger);

                        if (_sendReportToSftp)
                        {
                            var sftpFolderAppointmentBookedReportDirectory = string.Format(_destinationSftpFolderAppointmentBookedReportPath, toDate.Year);

                            sftpFolderAppointmentBookedReportDirectory = sftpFolderAppointmentBookedReportDirectory + "\\" + account.FolderName;

                            _logger.Info("source path:" + sourcePath);

                            var processFtp = new ProcessFtp(_logger, _sftpHost, _sftpUserName, _sftpPassword);
                            processFtp.UploadSingleFile(sourcePath, sftpFolderAppointmentBookedReportDirectory, "");

                            _logger.Info("destination :" + sftpFolderAppointmentBookedReportDirectory);
                        }
                    }
                    else
                    { _logger.Info("No Records Found for account " + account.Tag); }

                    _logger.Info("********** Completed for Account " + account.Tag + " *****************");
                }


            }
            catch (Exception ex)
            {
                _logger.Error(string.Format("Main App: \n Error {0} \n Trace: {1} \n\n\n", ex.Message, ex.StackTrace));
            }
        }

        private List<AppointmentsBookedModel> AppointmentsBooked(AppointmentsBookedListModelFilter filter)
        {
            var pageNumber = 1;
            const int pageSize = 100;

            var list = new List<AppointmentsBookedModel>();

            while (true)
            {
                int totalRecords;
                var model = _eventCustomerReportingService.GetAppointmentsBooked(pageNumber, pageSize, filter, out totalRecords);
                if (model == null || model.Collection == null || !model.Collection.Any()) break;

                list.AddRange(model.Collection);
                _logger.Info(String.Format("\n\nPageNumber:{0} Totalrecords: {1}  Current Length: {2}", pageNumber, totalRecords, list.Count));

                pageNumber++;

                if (list.Count >= totalRecords)
                    break;
            }

            return list;
        }

        private void CreateDistinationDirectory(string directoryPath)
        {
            if (!Directory.Exists(directoryPath)) Directory.CreateDirectory(directoryPath);
        }
    }
}