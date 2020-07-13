using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Helper;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Infrastructure.Application.Impl;

namespace Falcon.App.Infrastructure.Scheduling.Impl
{
    [DefaultImplementation]
    public class WellmedAppointmentBookExportPollingAgent : IWellmedAppointmentBookExportPollingAgent
    {
        private readonly IEventCustomerReportingService _eventCustomerReportingService;
        
        private readonly IUniqueItemRepository<CorporateAccount> _corporateAccountRepository;
        private readonly IPgpFileEncryptionHelper _pgpFileEncryptionHelper;
        private readonly ILogger _logger;
        private readonly ISettings _settings;


        private readonly IAppointmentBookedExportCsvHelper _appointmentBookedExportCsvHelper;
        public WellmedAppointmentBookExportPollingAgent(IEventCustomerReportingService eventCustomerReportingService, ILogManager logManager, ISettings settings,
             IUniqueItemRepository<CorporateAccount> corporateAccountRepository, IPgpFileEncryptionHelper pgpFileEncryptionHelper,
            IAppointmentBookedExportCsvHelper appointmentBookedExportCsvHelper)
        {
            _logger = logManager.GetLogger("WellmedAppointmentBookedReport");
            _eventCustomerReportingService = eventCustomerReportingService;
            
            _corporateAccountRepository = corporateAccountRepository;
            _pgpFileEncryptionHelper = pgpFileEncryptionHelper;
            _appointmentBookedExportCsvHelper = appointmentBookedExportCsvHelper;
            _settings = settings;
        }

        public void PollForAppointmentBookExport()
        {
            try
            {
                var corporateAccounts = _corporateAccountRepository.GetByIds(new[] { _settings.WellmedAccountId, _settings.WellmedTxAccountId });

                if (corporateAccounts.IsNullOrEmpty())
                {
                    _logger.Info("Account can't be null");
                    return;
                }

                foreach (var account in corporateAccounts)
                {
                    _logger.Info(string.Format("Generating AppointmentBooked for accountId {0} and account tag {1}. ", account.Id, account.Tag));

                    var fileName = "";

                    var fromDate = DateTime.Today.GetFirstDateOfYear();
                    var toDate = DateTime.Today.GetLastDateOfYear();

                    var folderName = account.Id == _settings.WellmedAccountId ? _settings.WellmedFlFolder : _settings.WellmedTxFolder;

                    var destinationPath = Path.Combine(string.Format(_settings.OutTakeReportPath, folderName), "Appointments");

                    fileName = string.Format("AppointmentsBooked_{0}_{1}_{2}.csv", account.AcesClientShortName, folderName, DateTime.Today.ToString("MMddyyyy"));

                    DirectoryOperationsHelper.CreateDirectoryIfNotExist(destinationPath);

                    var sourcePath = Path.Combine(destinationPath, fileName);

                    AppointmentsBooked(new AppointmentsBookedListModelFilter { EventFrom = fromDate, EventTo = toDate.Date, AccountId = account.Id, Tag = account.Tag }, sourcePath);

                    if (DirectoryOperationsHelper.IsFileExist(sourcePath))
                    {
                        _pgpFileEncryptionHelper.EncryptFile(account, sourcePath);
                    }
                }

            }
            catch (Exception ex)
            {
                _logger.Error(string.Format("Main App: \n Error {0} \n Trace: {1} \n\n\n", ex.Message, ex.StackTrace));
            }
        }

        private void AppointmentsBooked(AppointmentsBookedListModelFilter filter, string destinationPath)
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

            if (list.Any())
                _appointmentBookedExportCsvHelper.WriteCsv(list, destinationPath, _logger);
        }
    }
}