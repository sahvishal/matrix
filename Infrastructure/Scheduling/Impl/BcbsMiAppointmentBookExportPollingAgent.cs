using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users.Domain;
using DateTime = System.DateTime;

namespace Falcon.App.Infrastructure.Scheduling.Impl
{
    [DefaultImplementation]
    public class BcbsMiAppointmentBookExportPollingAgent : IBcbsMiAppointmentBookExportPollingAgent
    {
        private readonly IEventCustomerReportingService _eventCustomerReportingService;
        private readonly ICustomSettingManager _customSettingManager;
        private readonly IUniqueItemRepository<CorporateAccount> _corporateAccountRepository;
        private readonly IAppointmentBookedExportCsvHelper _appointmentBookedExportCsvHelper;
        private readonly ILogger _logger;

        private readonly string _destinationFolderPdfPath;
        private readonly string _appointmentSettings;
        private readonly long _accountId;
        private readonly DateTime _cutOfDate;

        private readonly string[] _bcbsMiRiskPatientTags;
        private readonly string[] _bcbsMiGapPatinetTags;

        public BcbsMiAppointmentBookExportPollingAgent(IEventCustomerReportingService eventCustomerReportingService, ILogManager logManager, ISettings settings,
            ICustomSettingManager customSettingManager, IUniqueItemRepository<CorporateAccount> corporateAccountRepository, IAppointmentBookedExportCsvHelper appointmentBookedExportCsvHelper)
        {
            _logger = logManager.GetLogger("BcbsMiAppointmentBookExportPollingAgent");
            _eventCustomerReportingService = eventCustomerReportingService;

            _customSettingManager = customSettingManager;
            _corporateAccountRepository = corporateAccountRepository;
            _appointmentBookedExportCsvHelper = appointmentBookedExportCsvHelper;

            _appointmentSettings = settings.PcpAppointmentBookedReportDownloadSettings;
            _destinationFolderPdfPath = settings.BcbsMiResultReportDownloadPath;
            _accountId = settings.BcbsMiAccountId;
            _cutOfDate = settings.PcpDownloadCutOfDate;

            _bcbsMiGapPatinetTags = settings.BcbsMiGapPatinetTags;
            _bcbsMiRiskPatientTags = settings.BcbsMiRiskPatientTags;
        }

        public void PollForAppointmentBookExport()
        {
            try
            {
                if (_accountId <= 0) return;
                var account = _corporateAccountRepository.GetById(_accountId);

                try
                {
                    var destinationPath = string.Format(_destinationFolderPdfPath, account.FolderName);

                    var appointmentSettings = string.Format(_appointmentSettings, account.Tag);
                    var customSettings = _customSettingManager.Deserialize(appointmentSettings);

                    _logger.Info(string.Format("Generating AppointmentBooked for accountId {0} and account tag {1}. ", account.Id, account.Tag));

                    var fromDate = (customSettings.LastTransactionDate != null) ? DateTime.Today.GetFirstDateOfYear() : _cutOfDate;
                    var toDate = DateTime.Today.GetLastDateOfYear();

                    CreateDistinationDirectory(destinationPath);

                    if (fromDate.Year == toDate.Year)
                    {
                        DeleteIffileExist(destinationPath, toDate.Year);

                        //AppointmentBookedReportForRiskPatient(fromDate, toDate, account, destinationPath);

                        AppointmentBookedReportForGapPatient(fromDate, toDate, account, destinationPath);

                        //AppointmentBookedReportForNormalPatient(fromDate, toDate, account, destinationPath);
                    }
                    else if (fromDate.Year < DateTime.Today.Year)
                    {
                        toDate = new DateTime(fromDate.Year, 12, 31);

                        while (true)
                        {
                            DeleteIffileExist(destinationPath, toDate.Year);

                            //AppointmentBookedReportForRiskPatient(fromDate, toDate, account, destinationPath);

                            AppointmentBookedReportForGapPatient(fromDate, toDate, account, destinationPath);

                            //AppointmentBookedReportForNormalPatient(fromDate, toDate, account, destinationPath);

                            fromDate = new DateTime((fromDate.Year + 1), 1, 1);

                            toDate = DateTime.Now;

                            if (fromDate.Year < DateTime.Today.Year)
                                toDate = new DateTime(fromDate.Year, 12, 31);

                            if (fromDate.Year > DateTime.Today.Year)
                                break;
                        }
                    }

                    customSettings.LastTransactionDate = toDate;
                    _customSettingManager.SerializeandSave(appointmentSettings, customSettings);
                }
                catch (Exception ex)
                {
                    _logger.Error(string.Format("Exception For AccountId {0} and Account Tag {1} : \n Error {2} \n Trace: {3} \n\n\n", account.Id, account.Tag, ex.Message, ex.StackTrace));
                }
            }
            catch (Exception ex)
            {
                _logger.Error(string.Format("Main App: \n Error {0} \n Trace: {1} \n\n\n", ex.Message, ex.StackTrace));
            }
        }

        private void AppointmentBookedReportForRiskPatient(DateTime fromDate, DateTime toDate, CorporateAccount account, string destinationPath)
        {
            _logger.Info(string.Format("Generating R-AppointmentBooked Date From. {0} To Date {1}", fromDate.Date.ToShortDateString(), toDate.ToShortDateString()));

            var filter = new AppointmentsBookedListModelFilter
            {
                EventFrom = fromDate,
                EventTo = toDate.Date,
                AccountId = account.Id,
                CustomTags = _bcbsMiRiskPatientTags,
                Tag = account.Tag

            };

            var fileName = destinationPath + string.Format(@"\R_AppointmentBookedReport_{0}.csv", DateTime.Today.ToString("yyyyMMdd"));

            AppointmentsBooked(filter, destinationPath, fileName);

        }

        private void AppointmentBookedReportForGapPatient(DateTime fromDate, DateTime toDate, CorporateAccount account, string destinationPath)
        {
            _logger.Info(string.Format("Generating Q_MOBILE_AppointmentBooked Date From. {0} To Date {1}", fromDate.Date.ToShortDateString(), toDate.ToShortDateString()));

            var filter = new AppointmentsBookedListModelFilter
            {
                EventFrom = fromDate,
                EventTo = toDate.Date,
                AccountId = account.Id,
                CustomTags = _bcbsMiGapPatinetTags,
                Tag = account.Tag
            };

            var fileName = destinationPath + string.Format(@"\Q_MOBILE_AppointmentBookedReport_{0}.csv", DateTime.Today.ToString("yyyyMMdd"));

            AppointmentsBooked(filter, destinationPath, fileName);
        }

        private void AppointmentBookedReportForNormalPatient(DateTime fromDate, DateTime toDate, CorporateAccount account, string destinationPath)
        {
            _logger.Info(string.Format("Generating AppointmentBooked Date From. {0} To Date {1}", fromDate.Date.ToShortDateString(), toDate.ToShortDateString()));

            var tagToExlude = new List<string>();
            if (!_bcbsMiGapPatinetTags.IsNullOrEmpty())
                tagToExlude.AddRange(_bcbsMiGapPatinetTags);

            if (!_bcbsMiRiskPatientTags.IsNullOrEmpty())
                tagToExlude.AddRange(_bcbsMiRiskPatientTags);

            var filter = new AppointmentsBookedListModelFilter
            {
                EventFrom = fromDate,
                EventTo = toDate.Date,
                AccountId = account.Id,
                CustomTags = tagToExlude.ToArray(),
                ExcludeCustomerWithCustomTag = true,
                Tag = account.Tag
            };

            var fileName = destinationPath + string.Format(@"\AppointmentBookedReport_{0}.csv", DateTime.Today.ToString("yyyyMMdd"));

            AppointmentsBooked(filter, destinationPath, fileName);
        }

        private void AppointmentsBooked(AppointmentsBookedListModelFilter filter, string destinationPath, string fileName)
        {
            var pageNumber = 1;
            const int pageSize = 100;

            var list = new List<AppointmentsBookedModel>();

            CreateDistinationDirectory(destinationPath);

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

        private void DeleteIffileExist(string destinationPath, int year)
        {
            var files = Directory.GetFiles(destinationPath, "*.csv");

            foreach (var file in files)
            {
                if (!string.IsNullOrEmpty(file) && file.Contains("AppointmentBookedReport_") && file.Contains("_" + year))
                {
                    if (File.Exists(file))
                        File.Delete(file);
                }

            }
        }
    }
}