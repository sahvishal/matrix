using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using Falcon.App.Core;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Enum;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Infrastructure.Application.Impl;
using System.IO;

namespace Falcon.App.Infrastructure.Scheduling.Impl
{
    [DefaultImplementation]
    public class SchedulingExportableReportHelper : BaseExportableReportHelper, ISchedulingExportableReportHelper
    {
        private readonly IEventCustomerReportingService _eventCustomerReportingService;
        private readonly IPcpTrackingReportService _pcpTrackingReportService;
        private readonly IBaseReportService _baseReportService;
        private readonly ICustomerScheduleCsvHelper _customerScheduleCsvHelper;


        public SchedulingExportableReportHelper(IEventCustomerReportingService eventCustomerReportingService, 
            IMediaRepository mediaRepository, IBaseReportService baseReportService, ILogManager logManager,
            ICustomerScheduleCsvHelper customerScheduleCsvHelper,
            IPcpTrackingReportService pcpTrackingReportService)
            : base(mediaRepository, baseReportService, logManager)
        {
            _eventCustomerReportingService = eventCustomerReportingService;
            _baseReportService = baseReportService;
            _customerScheduleCsvHelper = customerScheduleCsvHelper;
            _pcpTrackingReportService = pcpTrackingReportService;
        }

        public string AppointmentBookedReportExport(AppointmentsBookedListModelFilter filter, long userId)
        {
            var dataGen = new ExportableDataGenerator<AppointmentsBookedModel, AppointmentsBookedListModelFilter>(_eventCustomerReportingService.GetAppointmentsBooked, Logger);

            var model = dataGen.GetData(filter);

            return WriteCsvAppointmentBooked(GetExportableFileName("AppointmentsBooked"), model.Collection, userId);
        }

        public string CustomerReportExport(CustomerExportListModelFilter filter, long userId)
        {
            var dataGen = new ExportableDataGenerator<CustomerExportModel, CustomerExportListModelFilter>(_eventCustomerReportingService.GetCustomersForExport, Logger);

            var model = dataGen.GetData(filter);

            /*var exporter = ExportableDataGeneratorProcessManager<ViewModelBase, ModelFilterBase>.GetCsvExporter<CustomerExportModel>();*/

            return WriteCsvForCustomerExport(GetExportableFileName("CustomerExport"), model.Collection, userId);
        }

        public string MemberStatusReportExport(MemberStatusListModelFilter filter, long userId)
        {
            var dataGen = new ExportableDataGenerator<MemberStatusModel, MemberStatusListModelFilter>(_eventCustomerReportingService.GetMemberStatusReport, Logger);

            var model = dataGen.GetData(filter);

            return WriteCsvMemberStatus(GetExportableFileName("HealthPlanMemberStatusReport"), model.Collection, userId);
        }

        public string TestBookedReportExport(TestsBookedListModelFilter filter, long userId)
        {
            var dataGen = new ExportableDataGenerator<TestsBookedModel, TestsBookedListModelFilter>(_eventCustomerReportingService.GetTestsBooked, Logger);

            var model = dataGen.GetData(filter);

            var exporter = ExportableDataGeneratorProcessManager<ViewModelBase, ModelFilterBase>.GetCsvExporter<TestsBookedModel>();

            return WriteCsv(GetExportableFileName("TestBookedReport"), exporter, model.Collection, userId);
        }
        
        public string CustomerScheduleExport(CustomerScheduleModelFilter filter, long userId)
        {
            var fileName = GetExportableFileName("CustomerSchedule");
            var csvFilePath = Path.Combine(ExportableMediaLocation.PhysicalPath, fileName);

            var dataGen = new ExportableDataGenerator<EventCustomerScheduleModel, CustomerScheduleModelFilter>(_eventCustomerReportingService.GetCustomerScheduleModel, Logger);

            var model = dataGen.GetData(filter);

            var exporter = ExportableDataGeneratorProcessManager<ViewModelBase, ModelFilterBase>.GetCsvExporter<CustomerScheduleModel>();

            var csvStringBuilder = _customerScheduleCsvHelper.GetPatientScheduledReport(model.Collection, exporter);

            var request = new GenericReportRequest { CsvFilePath = csvFilePath, Model = csvStringBuilder.ToString() };
            var isGenerated = _baseReportService.GetResponse(request);
            if (!isGenerated) return "CSV File Export failed!";

            return _baseReportService.DownloadZipFile(ExportableMediaLocation, fileName, userId, Logger);
        }

        public string PcpTrackingReportExport(PcpTrackingReportFilter pcpTrackingReportFilter, long userId)
        {
            var dataGen = new ExportableDataGenerator<PcpTrackingReportViewModel, PcpTrackingReportFilter>(_pcpTrackingReportService.GetPcpTrackingReport, Logger);

            var model = dataGen.GetData(pcpTrackingReportFilter);

            var exporter = ExportableDataGeneratorProcessManager<ViewModelBase, ModelFilterBase>.GetCsvExporter<PcpTrackingReportViewModel>();

            return WriteCsv(GetExportableFileName("PcpTrackingReport"), exporter, model.Collection, userId);
        }

        private string WriteCsvAppointmentBooked(string fileName, IEnumerable<AppointmentsBookedModel> modelData, long userId)
        {
            var csvFilePath = ExportableMediaLocation.PhysicalPath + fileName;

            var csvStringBuilder = new StringBuilder();
            var members = (typeof(AppointmentsBookedModel)).GetMembers();

            var header = new List<string>();
            foreach (var memberInfo in members)
            {
                if (memberInfo.MemberType != MemberTypes.Property)
                    continue;

                var propInfo = (memberInfo as PropertyInfo);
                if (propInfo != null)
                {
                    if (propInfo.PropertyType == typeof(FeedbackMessageModel) || propInfo.PropertyType == typeof(IEnumerable<OrderedPair<string, string>>))
                        continue;
                }
                else
                    continue;

                string propertyName = memberInfo.Name;
                bool isHidden = false;

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

            header.Add("Additional Fields");

            csvStringBuilder.Append(string.Join(",", header.ToArray()) + Environment.NewLine);

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
                            if (model.ShippingOptions != null && model.ShippingOptions.Count() > 0)
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

                        if (propInfo.PropertyType == typeof(IEnumerable<RescheduleApplointmentModel>) || propInfo.PropertyType == typeof(IEnumerable<OrderedPair<string, string>>))
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
                    else if (memberInfo.Name == "Zip")
                    {
                        values.Add("=" + sanitizer.EscapeString(obj.ToString()));
                    }
                    else if (formatter != null)
                        values.Add(formatter.ToString(obj));
                    else
                        values.Add(sanitizer.EscapeString(obj.ToString()));

                }

                if (model.AdditionalFields != null && model.AdditionalFields.Any())
                {
                    string additionFiledString = model.AdditionalFields.Aggregate(string.Empty,
                        (current, item) => current + item.FirstValue + ": " + item.SecondValue + "\n");

                    values.Add(sanitizer.EscapeString(additionFiledString));
                }
                else
                    values.Add(string.Empty);

                csvStringBuilder.Append(string.Join(",", values.ToArray()) + Environment.NewLine);

            }

            var request = new GenericReportRequest { CsvFilePath = csvFilePath, Model = csvStringBuilder.ToString() };
            var isGenerated = _baseReportService.GetResponse(request);
            if (!isGenerated) return "CSV File Export failed!";

            return _baseReportService.DownloadZipFile(ExportableMediaLocation, fileName, userId, Logger);
        }

        private string WriteCsvMemberStatus(string fileName, IEnumerable<MemberStatusModel> modelData, long userId)
        {
            var csvFilePath = ExportableMediaLocation.PhysicalPath + fileName;

            var csvStringBuilder = new StringBuilder();
            var members = (typeof(MemberStatusModel)).GetMembers();

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

                string propertyName = memberInfo.Name;

                var attributes = propInfo.GetCustomAttributes(false);
                if (!attributes.IsNullOrEmpty())
                {
                    foreach (var attribute in attributes)
                    {
                        if (attribute is DisplayNameAttribute)
                        {
                            propertyName = (attribute as DisplayNameAttribute).DisplayName;
                        }
                    }
                }

                header.Add(propertyName);
            }

            csvStringBuilder.Append(string.Join(",", header.ToArray()) + Environment.NewLine);

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
                        if (propInfo.PropertyType == typeof(IEnumerable<OrderedPair<string, string>>))
                        {
                            if (model.AdditionalFields != null && model.AdditionalFields.Any())
                            {
                                string additionFiledString = model.AdditionalFields.Aggregate(string.Empty, (current, item) => current + item.FirstValue + ": " + item.SecondValue + "\n");
                                values.Add(sanitizer.EscapeString(additionFiledString));
                            }
                            else
                            {
                                values.Add(string.Empty);
                            }
                            continue;
                        }

                    }
                    else
                        continue;

                    FormatAttribute formatter = null;

                    var attributes = propInfo.GetCustomAttributes(false);
                    if (!attributes.IsNullOrEmpty())
                    {
                        foreach (var attribute in attributes)
                        {

                            if (attribute is FormatAttribute)
                            {
                                formatter = (FormatAttribute)attribute;
                            }
                        }
                    }


                    var obj = propInfo.GetValue(model, null);
                    if (obj == null)
                        values.Add(string.Empty);
                    else if (formatter != null)
                        values.Add(formatter.ToString(obj));
                    else
                        values.Add(sanitizer.EscapeString(obj.ToString()));
                }
                csvStringBuilder.Append(string.Join(",", values.ToArray()) + Environment.NewLine);

            }
            var request = new GenericReportRequest { CsvFilePath = csvFilePath, Model = csvStringBuilder.ToString() };
            var isGenerated = _baseReportService.GetResponse(request);
            if (!isGenerated) return "CSV File Export failed!";

            return _baseReportService.DownloadZipFile(ExportableMediaLocation, fileName, userId, Logger);
        }

        private string WriteCsvForCustomerExport(string fileName, IEnumerable<CustomerExportModel> modelData, long userId)
        {
            var csvFilePath = ExportableMediaLocation.PhysicalPath + fileName;

            var csvStringBuilder = new StringBuilder();
            var members = (typeof(CustomerExportModel)).GetMembers();

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

                string propertyName = memberInfo.Name;
                bool isHidden = false;

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

            csvStringBuilder.Append(string.Join(",", header.ToArray()) + Environment.NewLine);

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

                        if (propInfo.PropertyType == typeof(IEnumerable<OrderedPair<string, string>>))
                        {
                            string additionalFieldsString;
                            if (model.AdditionalFields == null || !model.AdditionalFields.Any())
                                additionalFieldsString = "N/A";
                            else
                                additionalFieldsString = model.AdditionalFields.Aggregate(string.Empty, (current, item) => current + item.FirstValue + ": " + item.SecondValue + "\n");

                            values.Add(sanitizer.EscapeString(additionalFieldsString));
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

                csvStringBuilder.Append(string.Join(",", values.ToArray()) + Environment.NewLine);

            }
            var request = new GenericReportRequest { CsvFilePath = csvFilePath, Model = csvStringBuilder.ToString() };
            var isGenerated = _baseReportService.GetResponse(request);
            if (!isGenerated) return "CSV File Export failed!";

            return _baseReportService.DownloadZipFile(ExportableMediaLocation, fileName, userId, Logger);
        }
    }
}
