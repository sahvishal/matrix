using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using Falcon.App.Core;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.ValueTypes;
using File = Falcon.App.Core.Application.Domain.File;

namespace Falcon.App.Infrastructure.Scheduling.Impl
{
    [DefaultImplementation]
    public class MolinaAppointmentBookExportPollingAgent : IMolinaAppointmentBookExportPollingAgent
    {
        private readonly IEventCustomerReportingService _eventCustomerReportingService;
        private readonly ICustomSettingManager _customSettingManager;
        private readonly IUniqueItemRepository<CorporateAccount> _corporateAccountRepository;
        private readonly IPgpFileEncryptionHelper _pgpFileEncryptionHelper;

        private readonly ILogger _logger;

        private readonly string _destinationAppointmentBookedReportPath;

        private readonly string _appointmentSettings;

        private readonly long _accountId;
        private readonly DateTime _cutOfDate;
        private readonly IAppointmentBookedExportCsvHelper _appointmentBookedExportCsvHelper;

        public MolinaAppointmentBookExportPollingAgent(IEventCustomerReportingService eventCustomerReportingService, ILogManager logManager, ISettings settings,
            ICustomSettingManager customSettingManager, IUniqueItemRepository<CorporateAccount> corporateAccountRepository, IPgpFileEncryptionHelper pgpFileEncryptionHelper, IAppointmentBookedExportCsvHelper appointmentBookedExportCsvHelper)
        {
            _logger = logManager.GetLogger("MolinaAppointmentBookedReport");
            _eventCustomerReportingService = eventCustomerReportingService;
            _customSettingManager = customSettingManager;
            _corporateAccountRepository = corporateAccountRepository;
            _pgpFileEncryptionHelper = pgpFileEncryptionHelper;

            _cutOfDate = settings.PcpDownloadCutOfDate;

            _accountId = settings.MolinaAccountId;

            _appointmentSettings = settings.MolinaAppointmentBookedReportDownloadSettings;
            _destinationAppointmentBookedReportPath = settings.MolinaAppointmentBookedReportDownloadPath;
            _appointmentBookedExportCsvHelper = appointmentBookedExportCsvHelper;

        }

        public void PollForAppointmentBookExport()
        {
            try
            {
                if (_accountId <= 0) return;

                var account = _corporateAccountRepository.GetById(_accountId);

                if (account == null)
                {
                    _logger.Info("Account can't be null");
                    return;
                }

                _logger.Info(string.Format("Generating AppointmentBooked for accountId {0} and account tag {1}. ", account.Id, account.Tag));

                var fromDate = DateTime.Now.Year > _cutOfDate.Date.Year ? DateTime.Today.GetFirstDateOfYear() : _cutOfDate;

                var destinationPath = string.Format(_destinationAppointmentBookedReportPath, fromDate.Year);
                var appointmentSettings = string.Format(_appointmentSettings, account.Tag);
                var customSettings = _customSettingManager.Deserialize(appointmentSettings);

                try
                {
                    var files = Directory.GetFiles(destinationPath);
                    if (files.Any())
                    {
                        foreach (var file in files)
                        {
                            System.IO.File.Delete(file);
                        }
                    }
                }
                catch
                {
                }

                var toDate = DateTime.Today.GetLastDateOfYear();

                CreateDistinationDirectory(destinationPath);

                var sourcePath = destinationPath + string.Format(@"\AppointmentBookedReport_{0}.csv", DateTime.Today.ToString("yyyyMMdd"));

                AppointmentsBooked(new AppointmentsBookedListModelFilter { EventFrom = fromDate, EventTo = toDate.Date, AccountId = account.Id, Tag = account.Tag }, sourcePath);

                try
                {
                    _pgpFileEncryptionHelper.EncryptFile(account, sourcePath);
                }
                catch (Exception exception)
                {
                    _logger.Error("Message : " + exception.Message + " Stack Trace : " + exception.StackTrace);
                }

                customSettings.LastTransactionDate = toDate;
                _customSettingManager.SerializeandSave(appointmentSettings, customSettings);

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

        private void CreateDistinationDirectory(string directoryPath)
        {
            if (!Directory.Exists(directoryPath)) Directory.CreateDirectory(directoryPath);
        }

    }
}