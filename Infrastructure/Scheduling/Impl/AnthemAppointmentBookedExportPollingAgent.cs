using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Sales.Interfaces;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using NLog;

namespace Falcon.App.Infrastructure.Scheduling.Impl
{
    [DefaultImplementation]
    public class AnthemAppointmentBookedExportPollingAgent : IAnthemAppointmentBookedExportPollingAgent
    {
        private readonly IEventCustomerReportingService _eventCustomerReportingService;
        private readonly ISettings _settings;
        private readonly ICustomSettingManager _customSettingManager;
        private readonly ICorporateAccountRepository _corporateAccountRepository;
        private readonly IPgpFileEncryptionHelper _pgpFileEncryptionHelper;
        private readonly ICorporateTagRepository _corporateTagRepository;
        private readonly IAppointmentBookedExportCsvHelper _appointmentBookedExportCsvHelper;
        private readonly string _appointmentSettings;
        private readonly ILogger _logger;
        private readonly string[] _customTags;
        private readonly DateTime _cutOfDate;

        public AnthemAppointmentBookedExportPollingAgent(IEventCustomerReportingService eventCustomerReportingService, ILogManager logManager, ISettings settings,
            ICustomSettingManager customSettingManager, ICorporateAccountRepository corporateAccountRepository, IPgpFileEncryptionHelper pgpFileEncryptionHelper, ICorporateTagRepository corporateTagRepository, IAppointmentBookedExportCsvHelper appointmentBookedExportCsvHelper)
        {
            _eventCustomerReportingService = eventCustomerReportingService;
            _settings = settings;
            _logger = logManager.GetLogger("AnthemAppointmentBookedReport");
            _customSettingManager = customSettingManager;
            _corporateAccountRepository = corporateAccountRepository;
            _pgpFileEncryptionHelper = pgpFileEncryptionHelper;
            _corporateTagRepository = corporateTagRepository;
            _appointmentBookedExportCsvHelper = appointmentBookedExportCsvHelper;
            _customTags = settings.AnthemCustomTags;
            _cutOfDate = settings.PcpDownloadCutOfDate;

            _appointmentSettings = settings.PcpAppointmentBookedReportDownloadSettings;
        }

        public void PollForAppointmentBookedReport()
        {
            try
            {
                foreach (var customTag in _customTags)
                {
                    try
                    {
                        _logger.Info("Running report for CustomTag: " + customTag);
                        var corporateTag = _corporateTagRepository.GetByTag(customTag);
                        if (corporateTag == null)
                        {
                            _logger.Info("No Corporate Tag Found: " + customTag);
                            continue;
                        }
                        var account = ((IUniqueItemRepository<CorporateAccount>)_corporateAccountRepository).GetById(corporateTag.CorporateId);

                        _logger.Info(string.Format("Generating AppointmentBooked for accountId {0} and account tag {1}. ", account.Id, account.Tag));

                        DateTime fromDate;
                        if (DateTime.Now.Year > _cutOfDate.Date.Year)
                            fromDate = DateTime.Today.GetFirstDateOfYear();
                        else
                            fromDate = _cutOfDate;

                        var folderStateCode = string.Empty;

                        if (_settings.AnthemAccountId == account.Id)
                        {
                            folderStateCode = "CA";
                        }
                        else
                        {
                            foreach (var stateCode in _settings.AnthemCustomTagStates)
                            {
                                if (customTag.Contains(stateCode))
                                {
                                    folderStateCode = stateCode.Substring(stateCode.Length - 2);

                                    break;
                                }
                            }  
                        }

                        if (folderStateCode == string.Empty)
                            continue;

                        var toDate = DateTime.Today.GetLastDateOfYear();
                        var destinationPath = string.Format(_settings.AnthemDownloadPath, folderStateCode);
                        destinationPath = Path.Combine(destinationPath, "Appointments");

                        CreateDistinationDirectory(destinationPath);

                        try
                        {
                            var files = Directory.GetFiles(destinationPath);
                            var fileNottoDeleted = Directory.GetFiles("HLTHFAIR_" + "*.csv");
                            if (files.Any())
                            {
                                foreach (var file in files)
                                {
                                    if (!fileNottoDeleted.Contains(file))
                                        File.Delete(file);
                                }
                            }
                        }
                        catch
                        {
                        }

                        var appointmentFileName = "HLTHFAIR_appointmentsbooked_" + DateTime.Today.ToString("yyyyMMdd") + ".csv";

                        var appointmentSettings = string.Format(_appointmentSettings, account.Tag);
                        var customSettings = _customSettingManager.Deserialize(appointmentSettings);

                        _logger.Info(string.Format("Generating AppointmentBooked Date From. {0} To Date {1}", fromDate.Date.ToShortDateString(), toDate.ToShortDateString()));
                        var customTags = new[] { customTag };

                        AppointmentsBooked(new AppointmentsBookedListModelFilter { EventFrom = fromDate, EventTo = toDate.Date, AccountId = account.Id, CustomTags = customTags, Tag = account.Tag }, destinationPath, appointmentFileName);

                        var fileName = Path.Combine(destinationPath, appointmentFileName);
                        _logger.Info(string.Format("Completed AppointmentBooked Date From. {0} To Date {1}", fromDate.Date.ToShortDateString(), toDate.ToShortDateString()));

                        if (File.Exists(fileName))
                        {
                            _pgpFileEncryptionHelper.EncryptFile(account, fileName);
                        }
                        else
                        {
                            _logger.Info("file Not found " + fileName);
                        }

                        customSettings.LastTransactionDate = toDate;
                        _customSettingManager.SerializeandSave(appointmentSettings, customSettings);
                    }
                    catch (Exception ex)
                    {
                        _logger.Error(string.Format("Exception For custom Tag {0} : \n Error {1} \n Trace: {2} \n\n\n", customTag, ex.Message, ex.StackTrace));
                    }

                }
            }
            catch (Exception ex)
            {
                _logger.Error("Message " + ex.Message);
                _logger.Error("Stack Trace " + ex.StackTrace);
            }



        }

        private void AppointmentsBooked(AppointmentsBookedListModelFilter filter, string destinationPath, string destinationFileName)
        {
            var pageNumber = 1;
            const int pageSize = 100;

            var list = new List<AppointmentsBookedModel>();

            var fileName = Path.Combine(destinationPath, destinationFileName);

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
                _appointmentBookedExportCsvHelper.WriteCsv(list, fileName, _logger);
        }

        private void CreateDistinationDirectory(string directoryPath)
        {
            if (!Directory.Exists(directoryPath)) Directory.CreateDirectory(directoryPath);
        }

    }
}