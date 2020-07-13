using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Helper;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Infrastructure.Application.Impl;

namespace Falcon.App.Infrastructure.Scheduling.Impl
{
    [DefaultImplementation]
    public class PcpAppointmentBookExportPollingAgent : IPcpAppointmentBookExportPollingAgent
    {
        private readonly IEventCustomerReportingService _eventCustomerReportingService;
        private readonly ISettings _settings;
        private readonly ICustomSettingManager _customSettingManager;
        private readonly ICorporateAccountRepository _corporateAccountRepository;
        private readonly IPgpFileEncryptionHelper _pgpFileEncryptionHelper;
        private readonly ISftpCridentialManager _sftpCridentialManager;
        private readonly IAppointmentBookedExportCsvHelper _appointmentBookedExportCsvHelper;
        private readonly ILogger _logger;

        private readonly string _pcpAppointmentBookedReportDownloadPath;
        private readonly string _appointmentSettings;
        private readonly IEnumerable<long> _accountIds;
        private readonly DateTime _cutOfDate;

        private readonly string _destinationSftpFolderPdfPath;
        private readonly IEnumerable<long> _ntspAccountIds;

        private readonly long _bcbsMnAccountId;
        private readonly string _bcbsSftpFolderPath;
        private readonly long _martinsPointExclusiveAccountId;


        public PcpAppointmentBookExportPollingAgent(IEventCustomerReportingService eventCustomerReportingService, ILogManager logManager, ISettings settings,
            ICustomSettingManager customSettingManager, ICorporateAccountRepository corporateAccountRepository, IPgpFileEncryptionHelper pgpFileEncryptionHelper,
            ISftpCridentialManager sftpCridentialManager, IAppointmentBookedExportCsvHelper appointmentBookedExportCsvHelper)
        {
            _logger = logManager.GetLogger("PcpAppointmentBookedReport");
            _eventCustomerReportingService = eventCustomerReportingService;
            _settings = settings;
            _customSettingManager = customSettingManager;
            _corporateAccountRepository = corporateAccountRepository;
            _pgpFileEncryptionHelper = pgpFileEncryptionHelper;
            _sftpCridentialManager = sftpCridentialManager;
            _appointmentBookedExportCsvHelper = appointmentBookedExportCsvHelper;

            _appointmentSettings = settings.PcpAppointmentBookedReportDownloadSettings;
            _pcpAppointmentBookedReportDownloadPath = settings.PcpAppointmentBookedReportDownloadPath;
            _accountIds = settings.PcpAppointmentBookedReportDownloadAccountIds;
            _cutOfDate = settings.PcpDownloadCutOfDate;
            _ntspAccountIds = settings.NtspAccountIds;
            _destinationSftpFolderPdfPath = settings.NtspSftpResultReportDownloadPath;
            _bcbsMnAccountId = settings.BcbsMnAccountId;
            _bcbsSftpFolderPath = settings.BcbsMnSftpResultReportDownloadPath;
            _martinsPointExclusiveAccountId = settings.MartinsPointExclusiveAccountId;
        }

        public void PollForAppointmentBookExport()
        {
            try
            {
                if (_accountIds.IsNullOrEmpty()) return;
                var corporateAccounts = _corporateAccountRepository.GetByIds(_accountIds);

                foreach (var account in corporateAccounts)
                {
                    try
                    {
                        _logger.Info(string.Format("Generating AppointmentBooked for accountId {0} and account tag {1}. ", account.Id, account.Tag));

                        DateTime fromDate;
                        if (DateTime.Now.Year > _cutOfDate.Date.Year)
                            fromDate = DateTime.Today.GetFirstDateOfYear();
                        else
                            fromDate = _cutOfDate;

                        var destinationPath = string.Format(_pcpAppointmentBookedReportDownloadPath, account.FolderName);

                        if (account.Id != _settings.ExcellusAccountId && account.Id != _settings.HealthNowAccountId)
                        {
                            destinationPath = Path.Combine(destinationPath, DateTime.Today.Year.ToString());
                        }

                        var appointmentSettings = string.Format(_appointmentSettings, account.Tag);
                        var customSettings = _customSettingManager.Deserialize(appointmentSettings);


                        var toDate = DateTime.Today.GetLastDateOfYear();

                        _logger.Info(string.Format("Generating AppointmentBooked Date From. {0} To Date {1}", fromDate.Date.ToShortDateString(), toDate.ToShortDateString()));
                        string[] customTags = null;
                        var appointmentFileName = string.Format(@"\AppointmentBookedReport_{0}.csv", DateTime.Today.ToString("yyyyMMdd"));

                        if (account.Id == _martinsPointExclusiveAccountId)
                        {
                            appointmentFileName = string.Format(@"\Exclusive_AppointmentBookedReport_{0}.csv", DateTime.Today.ToString("yyyyMMdd"));
                            DirectoryOperationsHelper.DeleteFiles(destinationPath, "Exclusive_AppointmentBookedReport*.csv");
                        }
                        else if (account.Id == _settings.ExcellusAccountId)
                        {
                            appointmentFileName = string.Format(@"\AppointmentBooked_{0}.csv", DateTime.Today.ToString("yyyyMMdd"));
                            customTags = _settings.ExcellusCustomTags;
                            DirectoryOperationsHelper.DeleteFiles(destinationPath, "AppointmentBooked*.csv");

                        }
                        else if (account.Id == _settings.HealthNowAccountId)
                        {
                            destinationPath = string.Format(_settings.HealthPlanDownloadPath, account.FolderName);
                            appointmentFileName = string.Format(@"\AppointmentBooked_{0}.csv", DateTime.Today.ToString("yyyyMMdd"));
                            customTags = _settings.HealthNowCustomTags;
                            DirectoryOperationsHelper.DeleteFiles(destinationPath, "AppointmentBooked*.csv");
                        }
                        else if (account.Id == _settings.MedMutualAccountId)
                        {
                            destinationPath = string.Format(_settings.HealthPlanDownloadPath, account.FolderName);
                            appointmentFileName = string.Format(@"\AppointmentsBooked_{0}.csv", DateTime.Today.ToString("yyyyMMdd"));
                            DirectoryOperationsHelper.DeleteFiles(destinationPath, "AppointmentsBooked*.csv");

                        }
                        else if (account.Id == _settings.AppleCareAccountId)
                        {
                            if (DateTime.Today.DayOfWeek != _settings.AppleCareAppointmentBookedReportDayOfWeek)
                            {
                                _logger.Info("today is " + DateTime.Today.DayOfWeek + " while service is configured to run on " + _settings.AppleCareAppointmentBookedReportDayOfWeek);
                                _logger.Info("Please set in " + (int)DateTime.Today.DayOfWeek + " to run Service today");
                                continue;
                            }

                            appointmentFileName = @"\AppointmentsBooked.csv";
                            DirectoryOperationsHelper.DeleteFiles(destinationPath, "AppointmentsBooked.csv");
                        }
                        else if (account.Id == _settings.ConnecticareAccountId)
                        {
                            destinationPath = string.Format(_settings.HealthPlanDownloadPath, account.FolderName);
                            appointmentFileName = @"\Comm Appts Booked " + DateTime.Today.ToString("yyyy-MM-dd") + ".csv";
                        }
                        else if (account.Id == _settings.ConnecticareMaAccountId)
                        {
                            destinationPath = string.Format(_settings.HealthPlanDownloadPath, account.FolderName);
                            appointmentFileName = @"\MCR Appts Booked " + DateTime.Today.ToString("yyyy-MM-dd") + ".csv";
                        }
                        else if (account.Id == _settings.BcbsScAssessmentAccountId)
                        {
                            destinationPath = string.Format(_settings.HealthPlanExportRootPath, account.FolderName);
                        }
                        else if (account.Id == _settings.FloridaBlueFepAccountId)
                        {
                            destinationPath = Path.Combine(string.Format(_settings.HealthPlanDownloadPath, account.FolderName), "Reports");
                            appointmentFileName = string.Format(@"\AppointmentBooked_{0}.csv", DateTime.Today.ToString("yyyyMMdd"));
                        }
                        else if (account.Id == _settings.NammAccountId)
                        {
                            destinationPath = string.Format(_settings.HealthPlanExportRootPath, account.FolderName);
                            appointmentFileName = string.Format(@"\AppointmentBooked_{0}.csv", DateTime.Today.ToString("yyyyMMdd"));
                        }
                        //else if (account.Id == _settings.BcbsScAccountId)
                        //{
                        //    var folder = _settings.BcbsScFolder;
                        //    destinationPath = Path.Combine(string.Format(_settings.OutTakeReportPath, folder), "Appointments");
                        //    appointmentFileName = string.Format(@"\AppointmentsBooked_{0}_{1}_{2}.csv", account.AcesClientShortName, folder, DateTime.Today.ToString("MMddyyyy"));
                        //}
                        else
                        {
                            DirectoryOperationsHelper.DeleteFiles(destinationPath, "AppointmentBookedReport*.csv");
                        }

                        AppointmentsBooked(new AppointmentsBookedListModelFilter { EventFrom = fromDate, EventTo = toDate.Date, AccountId = account.Id, CustomTags = customTags, Tag = account.Tag }, destinationPath, appointmentFileName);

                        var fileName = destinationPath + appointmentFileName;
                        _logger.Info(string.Format("Completed AppointmentBooked Date From. {0} To Date {1}", fromDate.Date.ToShortDateString(), toDate.ToShortDateString()));

                        if (File.Exists(fileName))
                        {
                            _pgpFileEncryptionHelper.EncryptFile(account, fileName);

                            if (account.Id == _settings.FloridaBlueFepAccountId && _settings.SendReportToFloridaBlueSftp)
                            {
                                var destinationSftpPath = _settings.FloridaBlueSftpPath + "\\" + account.FolderName + "\\Download\\Reports";
                                PostFile(fileName, destinationSftpPath, _settings.FloridaBlueSftpHost, _settings.FloridaBlueSftpUserName, _settings.FloridaBlueSftpPassword);
                            }
                            else
                            {
                                PostFileOnClientSftp(account, fromDate, fileName);
                            }
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
                        _logger.Error(string.Format("Exception For AccountId {0} and Account Tag {1} : \n Error {2} \n Trace: {3} \n\n\n", account.Id, account.Tag, ex.Message, ex.StackTrace));
                    }
                }

            }
            catch (Exception ex)
            {
                _logger.Error(string.Format("Main App: \n Error {0} \n Trace: {1} \n\n\n", ex.Message, ex.StackTrace));
            }
        }

        private void PostFileOnClientSftp(CorporateAccount account, DateTime fromDate, string fileName)
        {
            var sftpSettings = _sftpCridentialManager.Deserialize(_settings.SftpResouceFilePath + account.Tag + ".xml");

            if (sftpSettings != null)
            {
                _logger.Info(string.Format("Sending Appointment booked File on {0} sftp", account.Tag));

                if (_ntspAccountIds != null && _ntspAccountIds.Contains(account.Id))
                {
                    var destinationPathOnSftp = string.Format(_destinationSftpFolderPdfPath, account.FolderName);

                    destinationPathOnSftp = destinationPathOnSftp + "/" + "Appointments" + "/" + fromDate.Year;

                    ExportFileOnClientSftp(fileName, destinationPathOnSftp, sftpSettings);
                }
                else if (_bcbsMnAccountId == account.Id)
                {
                    var destinationPathOnSftp = _bcbsSftpFolderPath;

                    ExportFileOnClientSftp(fileName, destinationPathOnSftp, sftpSettings);
                }
                else if (_settings.HcpNvAccountId == account.Id)
                {
                    //var destinationPathOnSftp = string.Format("{0}/{1}/{2}", _settings.HcpNvSftpResultReportDownloadPath, "Patient Schedules", fromDate.Year);
                    var destinationPathOnSftp = (!string.IsNullOrEmpty(_settings.HcpNvSftpResultReportDownloadPath) ? _settings.HcpNvSftpResultReportDownloadPath + "/" : string.Empty) + "Patient Schedules";

                    ExportFileOnClientSftp(fileName, destinationPathOnSftp, sftpSettings);
                }
                else if (_settings.BcbsAlAccountId == account.Id)
                {
                    ExportFileOnClientSftp(fileName, _settings.BcbsAlSftpDownloadPath + "Reports", sftpSettings);
                }

                _logger.Info(string.Format("Appointment booked File on {0} sftp", account.Tag));
            }
        }

        private void ExportFileOnClientSftp(string sourcePath, string destination, SftpCridential cridential)
        {
            PostFile(sourcePath, destination, cridential.HostName, cridential.UserName, cridential.Password);
        }

        private void PostFile(string sourcePath, string destination, string hostName, string userName, string password)
        {
            _logger.Info("Sending File at client SFTP has been disabled");
            //var processFtp = new ProcessFtp(_logger, hostName, userName, password);
            //var fileName = Path.GetFileName(sourcePath);

            //_logger.Info("Destination Path:  " + destination);
            //_logger.Info("File Name Path:  " + fileName);
            //_logger.Info("Source Path: " + sourcePath);

            //processFtp.UploadSingleFile(sourcePath, destination, fileName);
        }

        private void AppointmentsBooked(AppointmentsBookedListModelFilter filter, string destinationPath, string destinationFileName)
        {
            var pageNumber = 1;
            const int pageSize = 100;

            var list = new List<AppointmentsBookedModel>();

            DirectoryOperationsHelper.CreateDirectoryIfNotExist(destinationPath);

            var fileName = destinationPath + destinationFileName;

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
    }
}