using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.CallCenter;
using Falcon.App.Core.CallCenter.Domain;
using Falcon.App.Core.CallCenter.ViewModels;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.CallQueues.ViewModels;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Interfaces;
using Falcon.App.Infrastructure.Application.Impl;

namespace Falcon.App.Infrastructure.CallCenter.Impl
{
    [DefaultImplementation]
    public class CallCenterExportableReportHelper : BaseExportableReportHelper, ICallCenterExportableReportHelper
    {
        private readonly ICallQueueService _callQueueService;
        private readonly ICallCenterReportService _callCenterReportService;
        private readonly ICallQueueCustomerReportService _callQueueCustomerReportService;
        private readonly IBaseReportService _baseReportService;
        private readonly IBaseExportableReportHelper _baseExportableReportHelper;
        private readonly IConfirmationReportingService _confirmationReportingService;
        private readonly ICallSkippedReportService _callSkippedReportService;
        private readonly IGmsExcludedCustomerService _excludedCustomerService;
        private readonly IPreAssessmentReportingService _preAssessmentReportingService;


        public CallCenterExportableReportHelper(IMediaRepository mediaRepository, IBaseReportService baseReportService, ILogManager logManager, ICallQueueService callQueueService, ICallCenterReportService callCenterReportService,
            ICallQueueCustomerReportService callQueueCustomerReportService, IBaseExportableReportHelper baseExportableReportHelper, IConfirmationReportingService confirmationReportingService,
            ICallSkippedReportService callSkippedReportService, IGmsExcludedCustomerService excludedCustomerService, IPreAssessmentReportingService preAssessmentReportingService)
            : base(mediaRepository, baseReportService, logManager)
        {
            _baseReportService = baseReportService;
            _callQueueService = callQueueService;
            _callCenterReportService = callCenterReportService;
            _callQueueCustomerReportService = callQueueCustomerReportService;
            _baseExportableReportHelper = baseExportableReportHelper;
            _confirmationReportingService = confirmationReportingService;
            _callSkippedReportService = callSkippedReportService;
            _excludedCustomerService = excludedCustomerService;
            _preAssessmentReportingService = preAssessmentReportingService;
        }

        public string OutreachCallReportExport(OutreachCallReportModelFilter filter, long userId)
        {
            var dataGen = new ExportableDataGenerator<OutreachCallReportModel, OutreachCallReportModelFilter>(_callQueueService.GetOutreachCallReport, Logger);

            var model = dataGen.GetData(filter);

            return WriteCsvOutreachCallReport(GetExportableFileName("OutreachCall"), model.Collection, userId);
        }

        private string WriteCsvOutreachCallReport(string fileName, IEnumerable<OutreachCallReportModel> modelData, long userId)
        {
            var csvFilePath = ExportableMediaLocation.PhysicalPath + fileName;

            var isGenerated = GenerateOutreachCallReportCsv(modelData, csvFilePath, Logger);

            if (!isGenerated) return string.Empty;

            return _baseReportService.DownloadZipFile(ExportableMediaLocation, fileName, userId, Logger);
        }

        public void OutreachCallReportExport(OutreachCallReportModelFilter filter, string filePath, ILogger logger)
        {
            var dataGen = new ExportableDataGenerator<OutreachCallReportModel, OutreachCallReportModelFilter>(_callQueueService.GetOutreachCallReport, logger);

            var model = dataGen.GetData(filter);

            GenerateOutreachCallReportCsv(model.Collection, filePath,logger);
        }

        private bool GenerateOutreachCallReportCsv(IEnumerable<OutreachCallReportModel> modelData, string csvFilePath, ILogger logger)
        {
            var csvStringBuilder = new StringBuilder();
            var members = (typeof(OutreachCallReportModel)).GetMembers();

            var header = new List<string>();
            foreach (var memberInfo in members)
            {
                if (memberInfo.MemberType != MemberTypes.Property)
                    continue;

                var propInfo = (memberInfo as PropertyInfo);
                if (propInfo != null)
                {
                    if (propInfo.PropertyType == typeof(FeedbackMessageModel) ||
                        propInfo.PropertyType == typeof(IEnumerable<CallCenterNotes>))
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

            header.Add("Disposition Notes");
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
                        if (propInfo.PropertyType == typeof(FeedbackMessageModel) ||
                            propInfo.PropertyType == typeof(IEnumerable<CallCenterNotes>))
                            continue;
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


                if (model.Notes != null && model.Notes.Count() > 0)
                {
                    var notesString = model.Notes.Aggregate("",
                        (current, note) =>
                            current + ("[ " + note.DateCreated.ToShortDateString() + " ] - Notes: " + note.Notes + "\n"));

                    values.Add(sanitizer.EscapeString(notesString));
                }
                else
                    values.Add("N/A");

                csvStringBuilder.Append(string.Join(",", values.ToArray()) + Environment.NewLine);
            }

            var request = new GenericReportRequest { CsvFilePath = csvFilePath, Model = csvStringBuilder.ToString() };
            var isGenerated = _baseReportService.GetResponse(request);

            logger.Info("destination Path: " + csvFilePath);

            return isGenerated;
        }


        public string CallQueueSchedulingReportExport(CallQueueSchedulingReportFilter filter, long userId)
        {
            var dataGen = new ExportableDataGenerator<CallQueueSchedulingReportModel, CallQueueSchedulingReportFilter>(_callCenterReportService.GetHealthPlanCallQueueReport, Logger);

            var model = dataGen.GetData(filter);

            var exporter = ExportableDataGeneratorProcessManager<ViewModelBase, ModelFilterBase>.GetCsvExporter<CallQueueSchedulingReportModel>();
            return WriteCsv(GetExportableFileName("CallQueueSchedulingReport"), exporter, model.Collection, userId);
        }

        public string CallQueueExcludedCustomerReportExport(CallQueueExcludedCustomerReportModelFilter filter, long userId)
        {
            var dataGen = new ExportableDataGenerator<CallQueueExcludedCustomerReportModel, CallQueueExcludedCustomerReportModelFilter>(_callQueueService.GetCallQueueExcludedCustomerReport, Logger);

            var model = dataGen.GetData(filter);

            var exporter = ExportableDataGeneratorProcessManager<ViewModelBase, ModelFilterBase>.GetCsvExporter<CallQueueExcludedCustomerReportModel>();
            return WriteCsv(GetExportableFileName("CallQueueExcludedCustomerReport"), exporter, model.Collection, userId);
        }

        public string CallQueueCustomersReportExport(OutboundCallQueueFilter filter, long userId)
        {
            var dataGen = new ExportableDataGenerator<CallQueueCustomersReportModel, OutboundCallQueueFilter>(_callQueueCustomerReportService.GetCallQueueCustomers, Logger);

            var model = dataGen.GetData(filter);
            var listModel = model as CallQueueCustomersReportModelListModel;
            listModel = listModel ?? new CallQueueCustomersReportModelListModel();

            var exporter = ExportableDataGeneratorProcessManager<ViewModelBase, ModelFilterBase>.GetCsvExporter<CallQueueCustomersReportModel>();
            var fileName = "CallQueueCustomers_" + listModel.HealthPlanName + "_" + listModel.CallQueueName + (model.Filter.EventId > 0 ? "_" + listModel.Filter.EventId : "");

            return WriteCsv(GetExportableFileName(fileName), exporter, model.Collection, userId);
        }

        public string CustomerWithNoEventsInAreaReportExport(CustomerWithNoEventsInAreaReportModelFilter filter, long userId)
        {
            var dataGen = new ExportableDataGenerator<CustomerWithNoEventsInAreaReportModel, CustomerWithNoEventsInAreaReportModelFilter>(_callQueueService.GetCustomerWithNoEventsInArea, Logger);

            var model = dataGen.GetData(filter);

            var exporter = ExportableDataGeneratorProcessManager<ViewModelBase, ModelFilterBase>.GetCsvExporter<CustomerWithNoEventsInAreaReportModel>();
            return WriteCsv(GetExportableFileName("CustomerWithNoEventsInAreaReport"), exporter, model.Collection, userId);
        }

        public string CallCenterCallReportExport(CallCenterCallReportModelFilter filter, long userId)
        {
            var dataGen = new ExportableDataGenerator<CallCenterCallReportModel, CallCenterCallReportModelFilter>(_callQueueService.GetCallCenterCallReport, Logger);

            var model = dataGen.GetData(filter);

            return WriteCsvCallCenterCallReport(GetExportableFileName("CallCenterCallReport"), model.Collection, userId);
        }

        private string WriteCsvCallCenterCallReport(string fileName, IEnumerable<CallCenterCallReportModel> modelData, long userId)
        {
            var csvFilePath = ExportableMediaLocation.PhysicalPath + fileName;

            var isGenerated = GenerateCallCenterCallReportCsv(modelData, csvFilePath);

            if (!isGenerated) return string.Empty;

            return _baseReportService.DownloadZipFile(ExportableMediaLocation, fileName, userId, Logger);
        }

        private bool GenerateCallCenterCallReportCsv(IEnumerable<CallCenterCallReportModel> modelData, string csvFilePath)
        {
            var csvStringBuilder = new StringBuilder();
            var members = (typeof(CallCenterCallReportModel)).GetMembers();

            var header = new List<string>();
            foreach (var memberInfo in members)
            {
                if (memberInfo.MemberType != MemberTypes.Property)
                    continue;

                var propInfo = (memberInfo as PropertyInfo);
                if (propInfo != null)
                {
                    if (propInfo.PropertyType == typeof(FeedbackMessageModel) ||
                        propInfo.PropertyType == typeof(IEnumerable<CallCenterNotes>))
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

            header.Add("Disposition Notes");
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
                        if (propInfo.PropertyType == typeof(FeedbackMessageModel) ||
                            propInfo.PropertyType == typeof(IEnumerable<CallCenterNotes>))
                            continue;
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


                if (model.Notes != null && model.Notes.Count() > 0)
                {
                    var notesString = model.Notes.Aggregate("",
                        (current, note) =>
                            current + ("[ " + note.DateCreated.ToShortDateString() + " ] - Notes: " + note.Notes + "\n"));

                    values.Add(sanitizer.EscapeString(notesString));
                }
                else
                    values.Add("N/A");

                csvStringBuilder.Append(string.Join(",", values.ToArray()) + Environment.NewLine);
            }

            var request = new GenericReportRequest { CsvFilePath = csvFilePath, Model = csvStringBuilder.ToString() };
            var isGenerated = _baseReportService.GetResponse(request);
            return isGenerated;
        }

        public string ConfirmationReportExport(ConfirmationReportFilter filter, long userId)
        {
            var dataGen = new ExportableDataGenerator<ConfirmationReportViewModel, ConfirmationReportFilter>(_confirmationReportingService.GetConfirmationReport, Logger);

            var model = dataGen.GetData(filter);

            var exporter = ExportableDataGeneratorProcessManager<ViewModelBase, ModelFilterBase>.GetCsvExporter<ConfirmationReportViewModel>();
            return WriteCsv(GetExportableFileName("ConfirmationReport"), exporter, model.Collection, userId);
        }

        public string CallSkippedReportExport(CallSkippedReportFilter filter, long userId)
        {
            var dataGen = new ExportableDataGenerator<CallSkippedReportViewModel, CallSkippedReportFilter>(_callSkippedReportService.GetCallSkippedReport, Logger);
            var model = dataGen.GetData(filter);
            var exporter = ExportableDataGeneratorProcessManager<ViewModelBase, ModelFilterBase>.GetCsvExporter<CallSkippedReportViewModel>();
            return WriteCsv(GetExportableFileName("CallSkippedReport"), exporter, model.Collection, userId);
        }

        public string ExcludedCusomerReportExport(OutboundCallQueueFilter filter, long userId)
        {
            var dataGen = new ExportableDataGenerator<GmsExcludedCustomerViewModel, OutboundCallQueueFilter>(_excludedCustomerService.GetExcludedCustomers, Logger);
            var model = dataGen.GetData(filter);
            var exporter = ExportableDataGeneratorProcessManager<ViewModelBase, ModelFilterBase>.GetCsvExporter<GmsExcludedCustomerViewModel>();
            return WriteCsv(GetExportableFileName("ExcludedCustomerReport"), exporter, model.Collection, userId);
        }

        public string PreAssessmentReportExport(PreAssessmentReportFilter filter, long userId)
        {
            var dataGen = new ExportableDataGenerator<PreAssessmentReportViewModel, PreAssessmentReportFilter>(_preAssessmentReportingService.GetPreAssessmentReport, Logger);

            var model = dataGen.GetData(filter);

            var exporter = ExportableDataGeneratorProcessManager<ViewModelBase, ModelFilterBase>.GetCsvExporter<PreAssessmentReportViewModel>();
            return WriteCsv(GetExportableFileName("PreAssessmentReport"), exporter, model.Collection, userId);
        }
    }


}
