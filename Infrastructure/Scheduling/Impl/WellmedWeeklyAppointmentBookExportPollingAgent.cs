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
using Falcon.App.Infrastructure.Application.Impl;

namespace Falcon.App.Infrastructure.Scheduling.Impl
{
    [DefaultImplementation]
    public class WellmedWeeklyAppointmentBookExportPollingAgent : IWellmedWeeklyAppointmentBookExportPollingAgent
    {
        private readonly IEventCustomerReportingService _eventCustomerReportingService;

        private readonly IUniqueItemRepository<CorporateAccount> _corporateAccountRepository;
        private readonly IPgpFileEncryptionHelper _pgpFileEncryptionHelper;
        private readonly ILogger _logger;

        private readonly string _destinationAppointmentBookedReportPath;
        private readonly string _destinationSftpFolderAppointmentBookedReportPath;

        private readonly long _accountId;

        private readonly string _sftpHost;
        private readonly string _sftpUserName;
        private readonly string _sftpPassword;
        private readonly bool _sendReportToSftp;

        private readonly DayOfWeek _dayOfWeek;
        private readonly IAppointmentBookedExportCsvHelper _appointmentBookedExportCsvHelper;

        public WellmedWeeklyAppointmentBookExportPollingAgent(IEventCustomerReportingService eventCustomerReportingService, ILogManager logManager, ISettings settings,
            IUniqueItemRepository<CorporateAccount> corporateAccountRepository, IPgpFileEncryptionHelper pgpFileEncryptionHelper, IAppointmentBookedExportCsvHelper appointmentBookedExportCsvHelper)
        {
            _logger = logManager.GetLogger("WellmedWeeklyAppointmentBookedReport");
            _eventCustomerReportingService = eventCustomerReportingService;
            _corporateAccountRepository = corporateAccountRepository;
            _pgpFileEncryptionHelper = pgpFileEncryptionHelper;

            _destinationAppointmentBookedReportPath = settings.WellmedWeeklyAppointmentBookedReportPath;
            _destinationSftpFolderAppointmentBookedReportPath = settings.WellmedSftpWeeklyAppointmentBookedReportPath;

            _sftpHost = settings.WellmedSftpHost;
            _sftpUserName = settings.WellmedSftpUserName;
            _sftpPassword = settings.WellmedSftpPassword;
            _accountId = settings.WellmedAccountId;
            _sendReportToSftp = settings.SendReportToWellmedSftp;

            _dayOfWeek = settings.WellmedWeeklyAppointmentBookedReportIntervalDay;
            _appointmentBookedExportCsvHelper = appointmentBookedExportCsvHelper;
        }

        public void PollForAppointmentBookExport()
        {
            try
            {
                _logger.Info("Day of the Week is " + _dayOfWeek);

                if (_accountId <= 0 || DateTime.Today.DayOfWeek != _dayOfWeek) return;

                var account = _corporateAccountRepository.GetById(_accountId);

                if (account == null)
                {
                    _logger.Info("Account can't be null");
                    return;
                }

                _logger.Info(string.Format("Generating AppointmentBooked for accountId {0} and account tag {1}. ", account.Id, account.Tag));

                var toDate = DateTime.Now;
                var fromDate = toDate.AddDays(-7);

                var destinationPath = string.Format(_destinationAppointmentBookedReportPath, fromDate.Year);

                try
                {
                    var files = Directory.GetFiles(destinationPath);
                    if (files.Any())
                    {
                        foreach (var file in files)
                        {
                            File.Delete(file);

                            if (_sendReportToSftp)
                            {
                                var sftpFolderAppointmentBookedReportDirectory = string.Format(_destinationSftpFolderAppointmentBookedReportPath, fromDate.Year);
                                var processFtp = new ProcessFtp(_logger, _sftpHost, _sftpUserName, _sftpPassword);

                                processFtp.RemoveFile(sftpFolderAppointmentBookedReportDirectory, Path.GetFileName(file));
                            }
                        }
                    }
                }
                catch
                {
                }

                CreateDestinationDirectory(destinationPath);

                var sourcePath = destinationPath + string.Format(@"\{0}_{1}.csv", toDate.ToString("yyyyMMdd"), fromDate.ToString("yyyyMMdd"));

                AppointmentsBooked(new AppointmentsBookedListModelFilter { FromDate = fromDate, ToDate = toDate.Date, AccountId = account.Id, Tag = account.Tag }, sourcePath);

                if (File.Exists(sourcePath))
                {
                    sourcePath = _pgpFileEncryptionHelper.EncryptFile(account, sourcePath);
                }

                if (_sendReportToSftp)
                {
                    var sftpFolderAppointmentBookedReportDirectory = string.Format(_destinationSftpFolderAppointmentBookedReportPath, fromDate.Year);
                    var processFtp = new ProcessFtp(_logger, _sftpHost, _sftpUserName, _sftpPassword);

                    processFtp.UploadSingleFile(sourcePath, sftpFolderAppointmentBookedReportDirectory, "");
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

        //Todo : Move this function in a generic class.
        //private void WriteCsv(IEnumerable<AppointmentsBookedModel> modelData, string fileName)
        //{

        //    if (File.Exists(fileName))
        //        File.Delete(fileName);

        //    var fileWriter = new StreamWriter(fileName);

        //    try
        //    {
        //        var members = (typeof(AppointmentsBookedModel)).GetMembers();

        //        var header = new List<string>();

        //        foreach (var memberInfo in members)
        //        {
        //            if (memberInfo.MemberType != MemberTypes.Property)
        //                continue;

        //            var propInfo = (memberInfo as PropertyInfo);

        //            if (propInfo != null)
        //            {
        //                if (propInfo.PropertyType == typeof(FeedbackMessageModel) || propInfo.PropertyType == typeof(IEnumerable<OrderedPair<string, string>>))
        //                    continue;
        //            }
        //            else
        //                continue;

        //            var propertyName = memberInfo.Name;
        //            var isHidden = false;

        //            var attributes = propInfo.GetCustomAttributes(false);

        //            if (!attributes.IsNullOrEmpty())
        //            {
        //                foreach (var attribute in attributes)
        //                {
        //                    if (attribute is HiddenAttribute)
        //                    {
        //                        isHidden = true;
        //                        break;
        //                    }
        //                    if (attribute is DisplayNameAttribute)
        //                    {
        //                        propertyName = (attribute as DisplayNameAttribute).DisplayName;
        //                    }
        //                }
        //            }

        //            if (isHidden) continue;

        //            header.Add(propertyName);
        //        }
        //        header.Add("Additional Fields");
        //        fileWriter.WriteLine(string.Join(",", header.ToArray()));

        //        var sanitizer = new CSVSanitizer();


        //        foreach (var model in modelData)
        //        {
        //            var values = new List<string>();
        //            foreach (var memberInfo in members)
        //            {
        //                if (memberInfo.MemberType != MemberTypes.Property)
        //                    continue;

        //                var propInfo = (memberInfo as PropertyInfo);
        //                if (propInfo != null)
        //                {
        //                    if (propInfo.PropertyType == typeof(FeedbackMessageModel) || propInfo.PropertyType == typeof(IEnumerable<OrderedPair<string, string>>))
        //                        continue;
        //                    if (propInfo.PropertyType == typeof(IEnumerable<string>))
        //                    {
        //                        if (model.ShippingOptions != null && model.ShippingOptions.Any())
        //                        {
        //                            var shippingOptions = string.Join(", \n", model.ShippingOptions.ToArray());
        //                            values.Add(sanitizer.EscapeString(shippingOptions));
        //                        }
        //                        else
        //                        {
        //                            values.Add(string.Empty);
        //                        }
        //                        continue;
        //                    }

        //                    if (propInfo.PropertyType == typeof(IEnumerable<RescheduleApplointmentModel>))
        //                    {
        //                        if (model.RescheduleInfo != null && model.RescheduleInfo.Any())
        //                        {
        //                            var rescheduleInfoString = string.Empty;
        //                            foreach (var rescheduleInfo in model.RescheduleInfo)
        //                            {
        //                                rescheduleInfoString += "Rescheduled By: " + rescheduleInfo.RescheduledBy + "\n";
        //                                rescheduleInfoString += "Reason: " + rescheduleInfo.Reason + "\n";
        //                                if (!string.IsNullOrEmpty(rescheduleInfo.Notes))
        //                                    rescheduleInfoString += "Notes: " + rescheduleInfo.Notes + "\n";
        //                                rescheduleInfoString += "---------------------------\n";
        //                            }
        //                            values.Add(sanitizer.EscapeString(rescheduleInfoString));
        //                        }
        //                        else
        //                        {
        //                            values.Add("N/A");
        //                        }
        //                        continue;
        //                    }
        //                }
        //                else
        //                    continue;


        //                bool isHidden = false;
        //                FormatAttribute formatter = null;

        //                var attributes = propInfo.GetCustomAttributes(false);
        //                if (!attributes.IsNullOrEmpty())
        //                {
        //                    foreach (var attribute in attributes)
        //                    {
        //                        if (attribute is HiddenAttribute)
        //                        {
        //                            isHidden = true;
        //                            break;
        //                        }
        //                        if (attribute is FormatAttribute)
        //                        {
        //                            formatter = (FormatAttribute)attribute;
        //                        }
        //                    }
        //                }

        //                if (isHidden) continue;
        //                var obj = propInfo.GetValue(model, null);
        //                if (obj == null)
        //                    values.Add(string.Empty);
        //                else if (formatter != null)
        //                    values.Add(formatter.ToString(obj));
        //                else
        //                    values.Add(sanitizer.EscapeString(obj.ToString()));

        //            }

        //            if (model.AdditionalFields != null && model.AdditionalFields.Any())
        //            {
        //                string additionFiledString = model.AdditionalFields.Aggregate(string.Empty,
        //                    (current, item) => current + item.FirstValue + ": " + item.SecondValue + "\n");

        //                values.Add(sanitizer.EscapeString(additionFiledString));
        //            }
        //            else
        //                values.Add(string.Empty);


        //            fileWriter.WriteLine(string.Join(",", values.ToArray()));
        //        }

        //        _logger.Info("CSV File Export was succesful!");
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.Error((string.Format("File Write: \n Error {0} \n Trace: {1} \n\n\n", ex.Message, ex.StackTrace)));
        //    }
        //    finally
        //    {
        //        fileWriter.Close();
        //        fileWriter.Dispose();
        //    }

        //}

        private void CreateDestinationDirectory(string directoryPath)
        {
            if (!Directory.Exists(directoryPath)) Directory.CreateDirectory(directoryPath);
        }
    }
}