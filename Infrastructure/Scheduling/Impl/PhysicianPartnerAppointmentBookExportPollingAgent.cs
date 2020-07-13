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
    public class PhysicianPartnerAppointmentBookExportPollingAgent : IPhysicianPartnerAppointmentBookExportPollingAgent
    {
        private readonly IEventCustomerReportingService _eventCustomerReportingService;
        private readonly ICustomSettingManager _customSettingManager;
        private readonly IPgpFileEncryptionHelper _pgpFileEncryptionHelper;
        private readonly IUniqueItemRepository<CorporateAccount> _corporateAccountRepository;
        private readonly ILogger _logger;
        private readonly string _appointmentSettings;
        private readonly string _physicianPartnerAppointmentBookedReportDownloadPath;
        private readonly long _accountId;

        public PhysicianPartnerAppointmentBookExportPollingAgent(IEventCustomerReportingService eventCustomerReportingService, ILogManager logManager, ISettings settings, ICustomSettingManager customSettingManager,
            IPgpFileEncryptionHelper pgpFileEncryptionHelper, IUniqueItemRepository<CorporateAccount> corporateAccountRepository)
        {
            _logger = logManager.GetLogger("AppointmentBookedReport");
            _eventCustomerReportingService = eventCustomerReportingService;
            _customSettingManager = customSettingManager;
            _pgpFileEncryptionHelper = pgpFileEncryptionHelper;
            _corporateAccountRepository = corporateAccountRepository;
            _appointmentSettings = settings.PhysicianPartnerAppointmentBookedReportDownloadSettings;
            _physicianPartnerAppointmentBookedReportDownloadPath = settings.PhysicianPartnerAppointmentBookedReportDownloadPath;
            _accountId = settings.PhysicianPartnerAccountId;

        }

        public void PollForAppointmentBookExport()
        {
            try
            {
                var customSettings = _customSettingManager.Deserialize(_appointmentSettings);
                var fromDate = (customSettings.LastTransactionDate != null ? customSettings.LastTransactionDate.Value.AddDays(1).Date : (DateTime?)null);
                var toDate = DateTime.Now;
                var account = _corporateAccountRepository.GetById(_accountId);
                var appointmentBoodFile = AppointmentsBooked(new AppointmentsBookedListModelFilter { FromDate = fromDate, ToDate = toDate.Date, AccountId = _accountId, Tag = account.Tag });

                if (File.Exists(appointmentBoodFile))
                {
                    _pgpFileEncryptionHelper.EncryptFile(account, appointmentBoodFile);
                }
                customSettings.LastTransactionDate = toDate;
                _customSettingManager.SerializeandSave(_appointmentSettings, customSettings);
            }
            catch (Exception ex)
            {
                _logger.Error(string.Format("Main App: \n Error {0} \n Trace: {1} \n\n\n", ex.Message, ex.StackTrace));
            }
        }

        private string AppointmentsBooked(AppointmentsBookedListModelFilter filter)
        {
            var pageNumber = 1;
            const int pageSize = 100;

            var list = new List<AppointmentsBookedModel>();

            CreateDestinationDirectory(_physicianPartnerAppointmentBookedReportDownloadPath);
            var fileName = _physicianPartnerAppointmentBookedReportDownloadPath + string.Format(@"\AppointmentBookedReport_{0}.csv", DateTime.Today.ToString("yyyyMMdd"));

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
                WriteCsv(list, fileName);

            return fileName;
        }

        //Todo : Move this function in a generic class.
        private void WriteCsv(IEnumerable<AppointmentsBookedModel> modelData, string fileName)
        {

            if (File.Exists(fileName))
                File.Delete(fileName);

            var fileWriter = new StreamWriter(fileName);

            try
            {
                var members = (typeof(AppointmentsBookedModel)).GetMembers();

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
                            if (propInfo.PropertyType == typeof(IEnumerable<string>))
                            {
                                if (model.ShippingOptions != null && model.ShippingOptions.Any())
                                {
                                    var shippingOptions = string.Join(", \n", model.ShippingOptions.ToArray());
                                    values.Add(sanitizer.EscapeString(shippingOptions));
                                }
                                else
                                {
                                    values.Add(string.Empty);
                                }
                                continue;
                            }

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
        private void CreateDestinationDirectory(string directoryPath)
        {
            if (!Directory.Exists(directoryPath)) Directory.CreateDirectory(directoryPath);
        }
    }
}
