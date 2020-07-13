using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Infrastructure.Scheduling.Impl
{
    [DefaultImplementation]
    public class HcpCaAppointmentBookExportPollingAgent : IHcpCaAppointmentBookExportPollingAgent
    {
        private readonly ICustomAppointmentBookedReportingService _customAppointmentBookedReportingService;
        private readonly ICustomSettingManager _customSettingManager;
        private readonly IUniqueItemRepository<CorporateAccount> _corporateAccountRepository;

        private readonly ILogger _logger;

        private readonly string _destinationAppointmentBookedReportPath;

        private readonly string _appointmentReportSetingPath;

        private readonly long _accountId;
        private readonly DateTime _cutOfDate;

        public HcpCaAppointmentBookExportPollingAgent(ICustomAppointmentBookedReportingService customAppointmentBookedReportingService, ILogManager logManager, ISettings settings,
            ICustomSettingManager customSettingManager, IUniqueItemRepository<CorporateAccount> corporateAccountRepository, IPgpFileEncryptionHelper pgpFileEncryptionHelper)
        {
            _logger = logManager.GetLogger("HCP CA AppointmentBookedReport");
            _customAppointmentBookedReportingService = customAppointmentBookedReportingService;
            _customSettingManager = customSettingManager;
            _corporateAccountRepository = corporateAccountRepository;


            _appointmentReportSetingPath = settings.PcpAppointmentBookedReportDownloadSettings;
            _destinationAppointmentBookedReportPath = settings.PcpAppointmentBookedReportDownloadPath;

            _cutOfDate = settings.PcpDownloadCutOfDate;
            _accountId = settings.HcpCaliforniaAccountId;
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

                var fromDate = DateTime.Now.Year > _cutOfDate.Date.Year ? new DateTime(DateTime.Now.Year, 1, 1) : _cutOfDate;

                var destinationPath = string.Format(_destinationAppointmentBookedReportPath, account.FolderName);
                destinationPath = Path.Combine(destinationPath, fromDate.Year.ToString());
                var appointmentSettings = string.Format(_appointmentReportSetingPath, account.Tag);
                var customSettings = _customSettingManager.Deserialize(appointmentSettings);

                try
                {
                    var files = Directory.GetFiles(destinationPath);
                    if (files.Any())
                    {
                        foreach (var file in files)
                        {
                            File.Delete(file);
                        }
                    }
                }
                catch
                {
                }

                var toDate = DateTime.Now;

                CreateDistinationDirectory(destinationPath);

                var sourcePath = destinationPath + string.Format(@"\AppointmentBookedReport_{0}.csv", toDate.ToString("yyyyMMdd"));

                AppointmentsBooked(new CustomAppointmentsBookedListModelFilter { FromDate = fromDate, ToDate = toDate.Date, AccountId = account.Id, Tag = account.Tag }, sourcePath);

                customSettings.LastTransactionDate = toDate;
                _customSettingManager.SerializeandSave(appointmentSettings, customSettings);
            }
            catch (Exception ex)
            {
                _logger.Error(string.Format("Main App: \n Error {0} \n Trace: {1} \n\n\n", ex.Message, ex.StackTrace));
            }
        }

        private void AppointmentsBooked(CustomAppointmentsBookedListModelFilter filter, string destinationPath)
        {
            var pageNumber = 1;
            const int pageSize = 100;

            var list = new List<CustomAppointmentsBookedModel>();

            while (true)
            {
                int totalRecords;
                var model = _customAppointmentBookedReportingService.GetCustomAppointmentsBooked(pageNumber, pageSize, filter, out totalRecords);
                if (model == null || model.Collection == null || !model.Collection.Any()) break;

                list.AddRange(model.Collection);
                _logger.Info(String.Format("\n\nPageNumber:{0} Totalrecords: {1}  Current Length: {2}", pageNumber, totalRecords, list.Count));

                pageNumber++;

                if (list.Count >= totalRecords)
                    break;
            }

            if (list.Any())
                WriteCsv(list, destinationPath);
        }

        //Todo : Move this function in a generic class.
        private void WriteCsv(IEnumerable<CustomAppointmentsBookedModel> modelData, string fileName)
        {

            if (File.Exists(fileName))
                File.Delete(fileName);

            var fileWriter = new StreamWriter(fileName);

            try
            {
                var members = (typeof(CustomAppointmentsBookedModel)).GetMembers();

                var header = new List<string>();

                foreach (var memberInfo in members)
                {
                    if (memberInfo.MemberType != MemberTypes.Property)
                        continue;

                    var propInfo = (memberInfo as PropertyInfo);

                    if (propInfo != null)
                    {
                        if (propInfo.PropertyType == typeof(FeedbackMessageModel))
                            continue;
                    }
                    else
                        continue;

                    var propertyName = memberInfo.Name;
                    var isHidden = false;

                    var attributes = propInfo.GetCustomAttributes(false);

                    if (!attributes.IsNullOrEmpty())
                    {
                        foreach (var attribute in attributes)
                        {
                            if (attribute is HiddenAttribute)
                            {
                                isHidden = true;
                                break;
                            }
                            if (attribute is DisplayNameAttribute)
                            {
                                propertyName = (attribute as DisplayNameAttribute).DisplayName;
                            }
                        }
                    }

                    if (isHidden) continue;

                    header.Add(propertyName);
                }

                fileWriter.WriteLine(string.Join(",", header.ToArray()));

                var sanitizer = new CSVSanitizer();


                foreach (var model in modelData)
                {
                    var values = new List<string>();
                    foreach (var memberInfo in members)
                    {
                        if (memberInfo.MemberType != MemberTypes.Property)
                            continue;

                        var propInfo = (memberInfo as PropertyInfo);
                        if (propInfo != null)
                        {
                            if (propInfo.PropertyType == typeof(FeedbackMessageModel))
                                continue;

                            if (propInfo.PropertyType == typeof(IEnumerable<RescheduleApplointmentModel>))
                            {
                                if (model.RescheduleInfo != null && model.RescheduleInfo.Any())
                                {
                                    var rescheduleInfoString = string.Empty;
                                    foreach (var rescheduleInfo in model.RescheduleInfo)
                                    {
                                        rescheduleInfoString += "Rescheduled By: " + rescheduleInfo.RescheduledBy + "\n";
                                        rescheduleInfoString += "Reason: " + rescheduleInfo.Reason + "\n";
                                        if (!string.IsNullOrEmpty(rescheduleInfo.SubReason))
                                            rescheduleInfoString += "SubReason: " + rescheduleInfo.SubReason + "\n";
                                        if (!string.IsNullOrEmpty(rescheduleInfo.Notes))
                                            rescheduleInfoString += "Notes: " + rescheduleInfo.Notes + "\n";
                                        rescheduleInfoString += "---------------------------\n";
                                    }
                                    values.Add(sanitizer.EscapeString(rescheduleInfoString));
                                }
                                else
                                {
                                    values.Add("N/A");
                                }
                                continue;
                            }
                        }
                        else
                            continue;


                        bool isHidden = false;
                        FormatAttribute formatter = null;

                        var attributes = propInfo.GetCustomAttributes(false);
                        if (!attributes.IsNullOrEmpty())
                        {
                            foreach (var attribute in attributes)
                            {
                                if (attribute is HiddenAttribute)
                                {
                                    isHidden = true;
                                    break;
                                }
                                if (attribute is FormatAttribute)
                                {
                                    formatter = (FormatAttribute)attribute;
                                }
                            }
                        }

                        if (isHidden) continue;
                        var obj = propInfo.GetValue(model, null);
                        if (obj == null)
                            values.Add(string.Empty);
                        else if (formatter != null)
                            values.Add(formatter.ToString(obj));
                        else
                            values.Add(sanitizer.EscapeString(obj.ToString()));

                    }

                    fileWriter.WriteLine(string.Join(",", values.ToArray()));
                }

                _logger.Info("CSV File Export was succesful!");
            }
            catch (Exception ex)
            {
                _logger.Error((string.Format("File Write: \n Error {0} \n Trace: {1} \n\n\n", ex.Message, ex.StackTrace)));
            }
            finally
            {
                fileWriter.Close();
                fileWriter.Dispose();
            }

        }

        private void CreateDistinationDirectory(string directoryPath)
        {
            if (!Directory.Exists(directoryPath)) Directory.CreateDirectory(directoryPath);
        }
    }
}