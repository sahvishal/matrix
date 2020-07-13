using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using Falcon.App.Core;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.Application.Enum;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Infrastructure.Application.Impl;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class MedicalExportableReportHelper : BaseExportableReportHelper, IMedicalExportableReportHelper
    {
        private readonly ITestResultService _testResultService;
        private readonly ITestNotPerformedService _testNotPerformedService;
        private readonly IEventCustomerReportingService _eventCustomersReportingService;
        private readonly IEventArchiveStatsService _eventArchiveStatsService;
        private readonly IBaseReportService _baseReportService;
        private readonly ITestPerformedCsvExportHelper _testPerformedCsvExportHelper;
        private readonly IEventCustomerQuestionAnswerService _eventCustomerQuestionAnswerServcie;

        public MedicalExportableReportHelper(IMediaRepository mediaRepository, IBaseReportService baseReportService, ILogManager logManager, ITestResultService testResultService, ITestNotPerformedService testNotPerformedService,
            IEventCustomerReportingService eventCustomersReportingService, IEventArchiveStatsService eventArchiveStatsService, ITestPerformedCsvExportHelper testPerformedCsvExportHelper, IEventCustomerQuestionAnswerService eventCustomerQuestionAnswerServcie)
            : base(mediaRepository, baseReportService, logManager)
        {
            _testResultService = testResultService;
            _testNotPerformedService = testNotPerformedService;
            _eventCustomersReportingService = eventCustomersReportingService;
            _eventArchiveStatsService = eventArchiveStatsService;
            _baseReportService = baseReportService;
            _testPerformedCsvExportHelper = testPerformedCsvExportHelper;
            _eventCustomerQuestionAnswerServcie = eventCustomerQuestionAnswerServcie;
        }

        public string TestPerformedReportExport(TestPerformedListModelFilter filter, long userId)
        {
            var dataGen = new ExportableDataGenerator<TestPerformedViewModel, TestPerformedListModelFilter>(_testResultService.GetTestPerformed, Logger);

            var model = dataGen.GetData(filter);

            //var exporter = ExportableDataGeneratorProcessManager<ViewModelBase, ModelFilterBase>.GetCsvExporter<TestPerformedViewModel>();
            //return WriteCsv(GetExportableFileName("TestPerformed"), exporter, model.Collection, userId);
            var fileName = GetExportableFileName("TestPerformed");
            return _testPerformedCsvExportHelper.WriteCsvTestPerformed(ExportableMediaLocation.PhysicalPath, fileName, model.Collection, userId, Logger, true);
        }

        public string TestNotPerformedReportExport(TestNotPerformedListModelFilter filter, long userId)
        {
            var dataGen = new ExportableDataGenerator<TestNotPerformedViewModel, TestNotPerformedListModelFilter>(_testNotPerformedService.GetTestNotPerformed, Logger);

            var model = dataGen.GetData(filter);

            var exporter = ExportableDataGeneratorProcessManager<ViewModelBase, ModelFilterBase>.GetCsvExporter<TestNotPerformedViewModel>();
            return WriteCsv(GetExportableFileName("TestNotPerformed"), exporter, model.Collection, userId);
        }

        public string GapsReportExport(GapsClosureModelFilter filter, long userId)
        {
            var dataGen = new ExportableDataGenerator<GapsClosureModel, GapsClosureModelFilter>(_eventCustomersReportingService.GetGapsClosureReport, Logger);

            var model = dataGen.GetData(filter);

            return WriteCsvGapClosureCustomer(GetExportableFileName("GapsReportExport"), model.Collection, userId);
        }

        private string WriteCsvGapClosureCustomer(string fileName, IEnumerable<GapsClosureModel> modelData, long userId)
        {
            var csvFilePath = ExportableMediaLocation.PhysicalPath + fileName;

            //using (var streamWriter = new StreamWriter(csvFilePath, false))
            //{
            var csvStringBuilder = new StringBuilder();
            var members = (typeof(GapsClosureModel)).GetMembers();

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

            //header.Add("Pre-approved Tests");
            //header.Add("Test Performed");
            //header.Add("Test Not Performed");
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
                        if (propInfo.PropertyType == typeof(FeedbackMessageModel) || propInfo.PropertyType == typeof(IEnumerable<string>) || propInfo.PropertyType == typeof(IEnumerable<OrderedPair<string, string>>))
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


                //if (model.PreApprovedTests != null && model.PreApprovedTests.Any())
                //{
                //    var notesString = string.Join(", ", model.PreApprovedTests);

                //    values.Add(sanitizer.EscapeString(notesString));
                //}
                //else
                //    values.Add(string.Empty);

                //if (model.ResultStatus != null && model.ResultStatus.Any())
                //{
                //    var resultString = model.ResultStatus.Aggregate(string.Empty, (current, status) => current + status.FirstValue + " : " + status.SecondValue + " \n");

                //    values.Add(sanitizer.EscapeString(resultString));
                //}
                //else
                //    values.Add(string.Empty);

                //if (model.TestNotPerformed != null && model.TestNotPerformed.Any())
                //{
                //    var resultString = model.TestNotPerformed.Aggregate(string.Empty, (current, status) => current + status.FirstValue + " : " + status.SecondValue + " \n");

                //    values.Add(sanitizer.EscapeString(resultString));
                //}
                //else
                //    values.Add(string.Empty);

                csvStringBuilder.Append(string.Join(",", values.ToArray()) + Environment.NewLine);
            }


            var request = new GenericReportRequest { CsvFilePath = csvFilePath, Model = csvStringBuilder.ToString() };
            var isGenerated = _baseReportService.GetResponse(request);

            if (!isGenerated) return "CSV File Export failed!";

            return _baseReportService.DownloadZipFile(ExportableMediaLocation, fileName, userId, Logger);
        }

        public string EventArchiveStatsExport(EventArchiveStatsFilter filter, long userId)
        {
            var dataGen = new ExportableDataGenerator<EventArchiveStatsViewModel, EventArchiveStatsFilter>(_eventArchiveStatsService.GetEventArchiveStats, Logger);

            var model = dataGen.GetData(filter);

            var exporter = ExportableDataGeneratorProcessManager<ViewModelBase, ModelFilterBase>.GetCsvExporter<EventArchiveStatsViewModel>();
            return WriteCsv(GetExportableFileName("EventArchiveStats"), exporter, model.Collection, userId);
        }

        public string DisqualifiedTestReportExport(DisqualifiedTestReportFilter filter, long userId)
        {
            var dataGen = new ExportableDataGenerator<DisqualifiedTestReportViewModel, DisqualifiedTestReportFilter>(_eventCustomerQuestionAnswerServcie.GetDisqualifiedTestReport, Logger);

            var model = dataGen.GetData(filter);

            var exporter = ExportableDataGeneratorProcessManager<ViewModelBase, ModelFilterBase>.GetCsvExporter<DisqualifiedTestReportViewModel>();
            return WriteCsv(GetExportableFileName("DisqualifiedTestReport"), exporter, model.Collection, userId);
        }
    }
}
