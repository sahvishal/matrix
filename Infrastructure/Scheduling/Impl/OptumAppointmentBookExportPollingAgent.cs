using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using Falcon.App.Core;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Helper;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users;

namespace Falcon.App.Infrastructure.Scheduling.Impl
{
    [DefaultImplementation]
    public class OptumAppointmentBookExportPollingAgent : IOptumAppointmentBookExportPollingAgent
    {
        private readonly IEventCustomerReportingService _eventCustomerReportingService;
        private readonly ICustomSettingManager _customSettingManager;
        private readonly ICorporateAccountRepository _corporateAccountRepository;
        private readonly IPgpFileEncryptionHelper _pgpFileEncryptionHelper;
        private readonly ILogger _logger;

        private readonly string _optumAppointmentBookedReportDownloadPath;
        private readonly string _appointmentSettings;
        private readonly IEnumerable<long> _accountIds;
        private readonly DateTime _cutOfDate;
        private readonly IAppointmentBookedExportCsvHelper _appointmentBookedExportCsvHelper;

        public OptumAppointmentBookExportPollingAgent(IEventCustomerReportingService eventCustomerReportingService, ILogManager logManager, ISettings settings,
            ICustomSettingManager customSettingManager, ICorporateAccountRepository corporateAccountRepository, IPgpFileEncryptionHelper pgpFileEncryptionHelper, IAppointmentBookedExportCsvHelper appointmentBookedExportCsvHelper)
        {
            _logger = logManager.GetLogger("OptumAppointmentBookedReport");
            _eventCustomerReportingService = eventCustomerReportingService;
            _customSettingManager = customSettingManager;
            _corporateAccountRepository = corporateAccountRepository;
            _pgpFileEncryptionHelper = pgpFileEncryptionHelper;

            _appointmentSettings = settings.PcpAppointmentBookedReportDownloadSettings;
            _cutOfDate = settings.PcpDownloadCutOfDate;

            _optumAppointmentBookedReportDownloadPath = settings.OptumAppointmentBookedReportDownloadPath;
            _accountIds = settings.OptumAppointmentBookedReportDownloadAccountIds;
            _appointmentBookedExportCsvHelper = appointmentBookedExportCsvHelper;
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

                        var fromDate = DateTime.Now.Year > _cutOfDate.Date.Year ? DateTime.Today.GetFirstDateOfYear() : _cutOfDate;

                        var destinationPath = string.Format(_optumAppointmentBookedReportDownloadPath, account.FolderName, fromDate.Year);
                        var appointmentSettings = string.Format(_appointmentSettings, account.Tag);
                        var customSettings = _customSettingManager.Deserialize(appointmentSettings);

                        try
                        {
                            DirectoryOperationsHelper.DeleteDirectory(destinationPath, true);
                        }
                        catch (Exception ex)
                        {
                            _logger.Error("Some error occurred while deleting directory at path: " + destinationPath);
                            _logger.Error("Message: " + ex.Message);
                            _logger.Error("Stack Trace: " + ex.StackTrace);
                        }

                        var toDate = DateTime.Today.GetLastDateOfYear();

                        AppointmentsBooked(new AppointmentsBookedListModelFilter { EventFrom = fromDate, EventTo = toDate.Date, AccountId = account.Id, Tag = account.Tag }, destinationPath);

                        var fileName = destinationPath + string.Format(@"\AppointmentBookedReport_{0}.csv", DateTime.Today.ToString("yyyyMMdd"));

                        if (DirectoryOperationsHelper.IsFileExist(fileName))
                            _pgpFileEncryptionHelper.EncryptFile(account, fileName);

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

        private void AppointmentsBooked(AppointmentsBookedListModelFilter filter, string destinationPath)
        {
            var pageNumber = 1;
            const int pageSize = 100;

            var list = new List<AppointmentsBookedModel>();

            CreateDistinationDirectory(destinationPath);

            var fileName = destinationPath + string.Format(@"\AppointmentBookedReport_{0}.csv", DateTime.Today.ToString("yyyyMMdd"));

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

        private void CreateDistinationDirectory(string directoryPath)
        {
            if (!Directory.Exists(directoryPath)) Directory.CreateDirectory(directoryPath);
        }
    }
}