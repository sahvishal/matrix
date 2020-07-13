using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;
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
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.ValueTypes;
using Falcon.App.UI.Controllers;
using Falcon.App.UI.Filters;

namespace Falcon.App.UI.Areas.Medical.Controllers
{
    [RoleBasedAuthorize]
    [AsyncTimeout(450000)]
    public class ExportableReportsController : BaseReportsController
    {
        //
        // GET: /Medical/ExportableReports/
        private readonly IPhysicianEvaluationService _physicianEvaluationService;
        private readonly ITestResultService _testResultService;
        private readonly ITestRepository _testRepository;
        private readonly IKynCustomerReportService _kynCustomerReportService;
        private readonly IEventCustomerReportingService _eventCustomerReportingService;
        private readonly MediaLocation _tempMediaLocation;
        private readonly ISessionContext _sessionContext;
        private readonly ITestNotPerformedService _testNotPerformedService;
        private readonly IEventArchiveStatsService _eventArchiveStatsService;
        private readonly IEventCustomerQuestionAnswerService _eventCustomerQuestionAnswerServcie;

        public ExportableReportsController(IPhysicianEvaluationService physicianEvaluationService, ITestResultService testResultService, ITestRepository testRepository, IKynCustomerReportService kynCustomerReportService,
            IMediaRepository mediaRepository, IZipHelper zipHelper, ILogManager logManager, ISessionContext sessionContext, ILoginSettingRepository loginSettingRepository, IRoleRepository roleRepository,
            IOrganizationRoleUserRepository organizationRoleUserRepository, IUserRepository<User> userRepository, ISettings settings, IEventCustomerReportingService eventCustomerReportingService, ITestNotPerformedService testNotPerformedService,
            IEventArchiveStatsService eventArchiveStatsService, IEventCustomerQuestionAnswerService eventCustomerQuestionAnswerServcie)
            : base(zipHelper, logManager, sessionContext, loginSettingRepository, roleRepository, organizationRoleUserRepository, userRepository, settings)
        {
            _physicianEvaluationService = physicianEvaluationService;
            _testResultService = testResultService;
            _testRepository = testRepository;
            _kynCustomerReportService = kynCustomerReportService;
            _eventCustomerReportingService = eventCustomerReportingService;
            _tempMediaLocation = mediaRepository.GetTempMediaFileLocation();
            _sessionContext = sessionContext;
            _testNotPerformedService = testNotPerformedService;
            _eventArchiveStatsService = eventArchiveStatsService;
            _eventCustomerQuestionAnswerServcie = eventCustomerQuestionAnswerServcie;
        }

        public void PhysicianReviewSummaryAsync(string id = null, PhysicianReviewSummaryListModelFilter filter = null)
        {
            if (id == null) return;

            AsyncManager.OutstandingOperations.Increment();
            var dataGen =
                new ExportableDataGenerator<PhysicianReviewSummaryViewModel, PhysicianReviewSummaryListModelFilter>(
                    _physicianEvaluationService.GetPhysicianReviewSummary);

            var processmanager = new ExportableDataGeneratorProcessManager<PhysicianReviewSummaryViewModel, PhysicianReviewSummaryListModelFilter>();
            processmanager.Add(id, dataGen);

            GetNewProcessStarted(filter, dataGen, id);
        }

        public ActionResult PhysicianReviewSummaryCompleted(string id, PhysicianReviewSummaryListModel model)
        {
            if (id == null) return Content("Model can't be null.");

            if (model == null || model.Collection == null || model.Collection.Count() < 1)
                return Content("Model can't be null.");

            RemoveProcess(id);
            var exporter = ExportableDataGeneratorProcessManager<ViewModelBase, ModelFilterBase>.GetCsvExporter<PhysicianReviewSummaryViewModel>();
            var message = WriteCsv("PhysicianReviewSummary.csv", exporter, model.Collection, RequestSubcriberChannelNames.PhysicianReviewSummaryQueue, RequestSubcriberChannelNames.PhysicianReviewSummaryChannel);
            return Content(message);
        }

        public void PhysicianReviewAsync(string id = null, PhysicianReviewListModelFilter filter = null)
        {
            if (id == null) return;

            AsyncManager.OutstandingOperations.Increment();
            var dataGen =
                new ExportableDataGenerator<PhysicianReviewViewModel, PhysicianReviewListModelFilter>(
                    _physicianEvaluationService.GetPhysicianReviews);

            var processmanager = new ExportableDataGeneratorProcessManager<PhysicianReviewViewModel, PhysicianReviewListModelFilter>();
            processmanager.Add(id, dataGen);

            GetNewProcessStarted(filter, dataGen, id);
        }

        public ActionResult PhysicianReviewCompleted(string id, PhysicianReviewListModel model)
        {
            if (id == null) return Content("Model can't be null.");

            if (model == null || model.Collection == null || model.Collection.Count() < 1)
                return Content("Model can't be null.");

            RemoveProcess(id);
            var exporter = ExportableDataGeneratorProcessManager<ViewModelBase, ModelFilterBase>.GetCsvExporter<PhysicianReviewViewModel>();
            var message = WriteCsv("PhysicianReview.csv", exporter, model.Collection, RequestSubcriberChannelNames.PhysicianReviewSummaryQueue, RequestSubcriberChannelNames.PhysicianReviewSummaryChannel);
            return Content(message);
        }


        public void PhysicianQueueAsync(string id = null, PhysicianQueueListModelFilter filter = null)
        {
            if (id == null) return;

            AsyncManager.OutstandingOperations.Increment();
            var dataGen =
                new ExportableDataGenerator<PhysicianQueueViewModel, PhysicianQueueListModelFilter>(
                    _physicianEvaluationService.GetPhysicianQueue);

            var processmanager = new ExportableDataGeneratorProcessManager<PhysicianQueueViewModel, PhysicianQueueListModelFilter>();
            processmanager.Add(id, dataGen);

            GetNewProcessStarted(filter, dataGen, id);
        }

        public ActionResult PhysicianQueueCompleted(string id, PhysicianQueueListModel model)
        {
            if (id == null) return Content("Model can't be null.");

            if (model == null || model.Collection == null || model.Collection.Count() < 1)
                return Content("Model can't be null.");

            RemoveProcess(id);
            var exporter = ExportableDataGeneratorProcessManager<ViewModelBase, ModelFilterBase>.GetCsvExporter<PhysicianQueueViewModel>();
            var message = WriteCsv("PhysicianQueue.csv", exporter, model.Collection, RequestSubcriberChannelNames.PhysicianQueueQueue, RequestSubcriberChannelNames.PhysicianQueueChannel);
            return Content(message);
        }

        public void PhysicianEventQueueAsync(string id = null, PhysicianEventQueueListModelFilter filter = null)
        {
            if (id == null) return;

            AsyncManager.OutstandingOperations.Increment();
            var dataGen =
                new ExportableDataGenerator<PhysicianEventQueueViewModel, PhysicianEventQueueListModelFilter>(
                    _physicianEvaluationService.GetPhysicianEventQueue);

            var processmanager = new ExportableDataGeneratorProcessManager<PhysicianEventQueueViewModel, PhysicianEventQueueListModelFilter>();
            processmanager.Add(id, dataGen);

            GetNewProcessStarted(filter, dataGen, id);
        }

        public ActionResult PhysicianEventQueueCompleted(string id, PhysicianEventQueueListModel model)
        {
            if (id == null) return Content("Model can't be null.");

            if (model == null || model.Collection == null || model.Collection.Count() < 1)
                return Content("Model can't be null.");

            RemoveProcess(id);
            var exporter = ExportableDataGeneratorProcessManager<ViewModelBase, ModelFilterBase>.GetCsvExporter<PhysicianEventQueueViewModel>();
            var message = WriteCsv("PhysicianEventQueue.csv", exporter, model.Collection, RequestSubcriberChannelNames.PhysicianEventQueueQueue, RequestSubcriberChannelNames.PhysicianEventQueueChannel);
            return Content(message);
        }

        public void TestPerformedAsync(string id = null, TestPerformedListModelFilter filter = null)
        {
            if (id == null) return;

            AsyncManager.OutstandingOperations.Increment();
            var dataGen =
                new ExportableDataGenerator<TestPerformedViewModel, TestPerformedListModelFilter>(
                    _testResultService.GetTestPerformed);

            var processmanager = new ExportableDataGeneratorProcessManager<TestPerformedViewModel, TestPerformedListModelFilter>();
            processmanager.Add(id, dataGen);

            GetNewProcessStarted(filter, dataGen, id);
        }

        public ActionResult TestPerformedCompleted(string id, TestPerformedListModel model)
        {
            if (id == null) return Content("Model can't be null.");

            if (model == null || model.Collection == null || model.Collection.Count() < 1)
                return Content("Model can't be null.");

            RemoveProcess(id);
            //var exporter = ExportableDataGeneratorProcessManager<ViewModelBase, ModelFilterBase>.GetCsvExporter<TestPerformedViewModel>();
            //var message = WriteCsv("TestPerformed.csv", exporter, model.Collection, RequestSubcriberChannelNames.TestPerformedQueue, RequestSubcriberChannelNames.TestPerformedChannel);
            var message = WriteCsvTestPerformed("TestPerformed.csv", model.Collection);
            return Content(message);
        }

        public void TestNotPerformedAsync(string id = null, TestNotPerformedListModelFilter filter = null)
        {
            if (id == null) return;

            AsyncManager.OutstandingOperations.Increment();
            var dataGen =
                new ExportableDataGenerator<TestNotPerformedViewModel, TestNotPerformedListModelFilter>(
                    _testNotPerformedService.GetTestNotPerformed);

            var processmanager = new ExportableDataGeneratorProcessManager<TestNotPerformedViewModel, TestNotPerformedListModelFilter>();
            processmanager.Add(id, dataGen);

            GetNewProcessStarted(filter, dataGen, id);
        }

        public ActionResult TestNotPerformedCompleted(string id, TestNotPerformedListModel model)
        {
            if (id == null) return Content("Model can't be null.");

            if (model == null || model.Collection == null || model.Collection.Count() < 1)
                return Content("Model can't be null.");

            RemoveProcess(id);
            var exporter = ExportableDataGeneratorProcessManager<ViewModelBase, ModelFilterBase>.GetCsvExporter<TestNotPerformedViewModel>();
            var message = WriteCsv("TestNotPerformed.csv", exporter, model.Collection, RequestSubcriberChannelNames.TestNotPerformedQueue, RequestSubcriberChannelNames.TestNotPerformedChannel);
            return Content(message);
        }


        private void GetNewProcessStarted<T, TN>(TN filter, ExportableDataGenerator<T, TN> dataGen, string id)
            where T : ViewModelBase
            where TN : ModelFilterBase
        {
            Task.Factory.StartNew(() =>
            {
                AsyncManager.Parameters["id"] = id;
                try
                {
                    AsyncManager.Parameters["model"] = dataGen.GetData(filter);
                }
                catch (Exception)
                {
                    AsyncManager.Parameters["model"] = null;
                }
                AsyncManager.OutstandingOperations.Decrement();
                Thread.Sleep(5000);
            });
        }

        public void RemoveProcess(string id)
        {
            var processmanager = new ExportableDataGeneratorProcessManager<ViewModelBase, ModelFilterBase>();
            processmanager.Remove(id);
        }

        private string WriteCsv<T>(string fileName, CSVExporter<T> exporter, IEnumerable<T> modelData, string queue, string channel)
        {
            var csvFilePath = _tempMediaLocation.PhysicalPath + fileName;

            //using (var streamWriter = new StreamWriter(csvFilePath, false))
            //{
            var csvStringBuilder = new StringBuilder();
            csvStringBuilder.Append(exporter.Header + Environment.NewLine);

            foreach (string line in exporter.ExportObjects(modelData))
            {
                csvStringBuilder.Append(line + Environment.NewLine);
            }

            //    streamWriter.Close();
            //}
            var request = new GenericReportRequest { Model = csvStringBuilder.ToString(), CsvFilePath = csvFilePath };
            var isGenerated = GetResponse(request, queue, channel);
            if (!isGenerated) return "CSV File Export failed!";


            DownloadZipFile(_tempMediaLocation, fileName);

            return "CSV File Export was succesful!";
        }


        public void TechnicalLimitedScreeningAsync(string id = null, TechnicalLimitedScreeningCustomerListModelFilter filter = null)
        {
            if (id == null) return;

            AsyncManager.OutstandingOperations.Increment();
            var dataGen =
                new ExportableDataGenerator<TechnicalLimitedScreeningCustomerViewModel, TechnicalLimitedScreeningCustomerListModelFilter>(
                    _testResultService.GetCustomerwithTechnicallimitedScreening);

            var processmanager = new ExportableDataGeneratorProcessManager<TechnicalLimitedScreeningCustomerViewModel, TechnicalLimitedScreeningCustomerListModelFilter>();
            processmanager.Add(id, dataGen);

            GetNewProcessStarted(filter, dataGen, id);
        }

        public ActionResult TechnicalLimitedScreeningCompleted(string id, TechnicalLimitedScreeningCustomerListModel model)
        {
            if (id == null) return Content("Model can't be null.");

            if (model == null || model.Collection == null || model.Collection.Count() < 1)
                return Content("Model can't be null.");

            RemoveProcess(id);
            var message = WriteCsvTechnicalLimitedScreening("TechnicalLimitedScreening.csv", model.Collection);
            return Content(message);
        }


        private string WriteCsvTechnicalLimitedScreening(string fileName, IEnumerable<TechnicalLimitedScreeningCustomerViewModel> modelData)
        {
            var csvFilePath = _tempMediaLocation.PhysicalPath + fileName;


            //using (var streamWriter = new StreamWriter(csvFilePath, false))
            //{
            var csvStringBuilder = new StringBuilder();
            var members = (typeof(TechnicalLimitedScreeningCustomerViewModel)).GetMembers();

            var header = new List<string>();
            foreach (var memberInfo in members)
            {
                if (memberInfo.MemberType != MemberTypes.Property)
                    continue;

                var propInfo = (memberInfo as PropertyInfo);
                if (propInfo != null)
                {
                    if (propInfo.PropertyType == typeof(FeedbackMessageModel) || propInfo.PropertyType == typeof(IEnumerable<TestUnabletoScreenViewModel>))
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

            var tests = _testRepository.GetRecordableTests();
            header.AddRange(tests.Select(test => test.Name));
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
                        if (propInfo.PropertyType == typeof(FeedbackMessageModel) || propInfo.PropertyType == typeof(IEnumerable<TestUnabletoScreenViewModel>))
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
                    else if (obj is TestResultStateLabel)
                    {
                        values.Add(((TestResultStateLabel)obj).GetDescription());
                    }
                    else if (formatter != null)
                        values.Add(formatter.ToString(obj));
                    else
                        values.Add(sanitizer.EscapeString(obj.ToString()));

                }

                foreach (var test in tests)
                {
                    if (model.Test != null && model.Test.Count() > 0)
                    {
                        var viewModels = model.Test.Where(ts => ts.TestId == test.Id).ToArray();
                        if (viewModels.Count() < 1) { values.Add(string.Empty); continue; }
                        string reason = string.Join(" | ", viewModels.Where(tv => !string.IsNullOrEmpty(tv.Reason)).Select(tv => tv.Reason));

                        var summaryFinding =
                            (string.IsNullOrEmpty(reason) ? "Unable to Screen" : reason) + ("  Tech Notes: " + viewModels.FirstOrDefault().TechnicianNotes);
                        values.Add(sanitizer.EscapeString(summaryFinding));
                    }
                    else
                        values.Add(string.Empty);
                }

                csvStringBuilder.Append(string.Join(",", values.ToArray()) + Environment.NewLine + Environment.NewLine);

            }

            //    streamWriter.Close();
            //} 

            var request = new GenericReportRequest { CsvFilePath = csvFilePath, Model = csvStringBuilder.ToString() };
            var isGenerated = GetResponse(request, RequestSubcriberChannelNames.GenerateTechnicalLimitedScreeningReportQueue, RequestSubcriberChannelNames.GenerateTechnicalLimitedScreeningReportChannel);
            if (!isGenerated) return "CSV File Export failed!";

            DownloadZipFile(_tempMediaLocation, fileName);

            return "CSV File Export was succesful!";
        }

        public void GetCustomerEventCriticalDataAsync(string id = null, CustomerEventCriticalDataListModelFilter filter = null)
        {
            if (id == null) return;

            AsyncManager.OutstandingOperations.Increment();
            var dataGen =
                new ExportableDataGenerator<CustomerEventCriticalDataViewModel, CustomerEventCriticalDataListModelFilter>(
                    _testResultService.GetCustomerwithCriticalData);

            var processmanager = new ExportableDataGeneratorProcessManager<CustomerEventCriticalDataViewModel, CustomerEventCriticalDataListModelFilter>();
            processmanager.Add(id, dataGen);

            GetNewProcessStarted(filter, dataGen, id);
        }

        public ActionResult GetCustomerEventCriticalDataCompleted(string id, CustomerEventCriticalDataListModel model)
        {
            if (id == null) return Content("Model can't be null.");

            if (model == null || model.Collection == null || model.Collection.Count() < 1)
                return Content("Model can't be null.");

            RemoveProcess(id);
            var message = WriteCsvCustomerEventCriticalData("CriticalCustomer.csv", model.Collection);
            return Content(message);
        }

        private string WriteCsvCustomerEventCriticalData(string fileName, IEnumerable<CustomerEventCriticalDataViewModel> modelData)
        {
            var csvFilePath = _tempMediaLocation.PhysicalPath + fileName;


            // using (var streamWriter = new StreamWriter(csvFilePath, false))
            //{
            var csvStringBuilder = new StringBuilder();
            var members = (typeof(CustomerEventCriticalDataViewModel)).GetMembers();

            var header = new List<string>();
            foreach (var memberInfo in members)
            {
                if (memberInfo.MemberType != MemberTypes.Property)
                    continue;

                var propInfo = (memberInfo as PropertyInfo);
                if (propInfo != null)
                {
                    if (propInfo.PropertyType == typeof(FeedbackMessageModel) || propInfo.PropertyType == typeof(IEnumerable<CustomerEventCriticalTestDataViewModel>) || propInfo.PropertyType == typeof(IEnumerable<Notes>))
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

            var tests = _testRepository.GetRecordableTests();
            header.AddRange(tests.Select(test => test.Name));
            header.Add("Notes");
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
                        if (propInfo.PropertyType == typeof(FeedbackMessageModel) || propInfo.PropertyType == typeof(IEnumerable<CustomerEventCriticalTestDataViewModel>) || propInfo.PropertyType == typeof(IEnumerable<Notes>))
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
                    else if (obj is TestResultStateLabel)
                    {
                        values.Add(((TestResultStateLabel)obj).GetDescription());
                    }
                    else if (formatter != null)
                        values.Add(formatter.ToString(obj));
                    else
                        values.Add(sanitizer.EscapeString(obj.ToString()));

                }

                foreach (var test in tests)
                {
                    if (model.Tests != null && model.Tests.Count() > 0)
                    {
                        var viewModel = model.Tests.Where(ts => ts.TestId == test.Id).SingleOrDefault();
                        if (viewModel == null)
                        {
                            values.Add(string.Empty); continue;
                        }
                        string summaryFinding;
                        if (!viewModel.IsCritical && viewModel.IsUrgent)
                        {
                            summaryFinding = "Physician: " + viewModel.PrimaryPhysicianName + "\n";
                            summaryFinding += "Physician notes for Customer: " + viewModel.TechnicianNotesForPhysician + "\n";
                        }
                        else
                        {
                            summaryFinding = "Date of Submission: " + (viewModel.DateOfSubmission.HasValue ? viewModel.DateOfSubmission.Value.ToShortDateString() : "N/A") + "\n";
                            summaryFinding += "Technician Name: " + viewModel.TechnicianName + "\n";
                            summaryFinding += "Validating Technician Name: " + viewModel.ValidatingTechnicianName + "\n";
                            summaryFinding += "Physician: " + viewModel.PrimaryPhysicianName + "\n";
                            summaryFinding += "Tech Notes: " + viewModel.TechnicianNotes + "\n";
                            summaryFinding += "Physician notes for Customer: " + viewModel.TechnicianNotesForPhysician + "\n";
                        }
                        values.Add(sanitizer.EscapeString(summaryFinding));
                    }
                    else
                        values.Add(string.Empty);
                }

                if (model.Notes != null && model.Notes.Count() > 0)
                {
                    var notesString = model.Notes.Aggregate("", (current, note) => current + ("[ " + note.DataRecorderMetaData.DateCreated.ToShortDateString() + " ] - " + note.Text + "\n"));
                    values.Add(sanitizer.EscapeString(notesString));
                }
                else
                    values.Add(string.Empty);

                csvStringBuilder.Append(string.Join(",", values.ToArray()) + Environment.NewLine);

            }

            //    streamWriter.Close();
            //}


            var request = new GenericReportRequest { CsvFilePath = csvFilePath, Model = csvStringBuilder.ToString() };
            var isGenerated = GetResponse(request, RequestSubcriberChannelNames.GenerateCustomerEventCriticalDataReportQueue, RequestSubcriberChannelNames.GenerateCustomerEventCriticalDataReportChannel);
            if (!isGenerated) return "CSV File Export failed!";

            DownloadZipFile(_tempMediaLocation, fileName);

            return "CSV File Export was succesful!";
        }

        public void PhysicianTestReviewAsync(string id = null, PhysicianTestReviewListModelFilter filter = null)
        {
            if (id == null) return;

            AsyncManager.OutstandingOperations.Increment();
            var dataGen =
                new ExportableDataGenerator<PhysicianTestReviewViewModel, PhysicianTestReviewListModelFilter>(
                    _physicianEvaluationService.GetPhysicianTestReview);

            var processmanager = new ExportableDataGeneratorProcessManager<PhysicianTestReviewViewModel, PhysicianTestReviewListModelFilter>();
            processmanager.Add(id, dataGen);

            GetNewProcessStarted(filter, dataGen, id);
        }

        public ActionResult PhysicianTestReviewCompleted(string id, PhysicianTestReviewListModel model)
        {
            if (id == null) return Content("Model can't be null.");

            if (model == null || model.Collection == null || model.Collection.Count() < 1)
                return Content("Model can't be null.");

            RemoveProcess(id);
            var message = WriteCsvPhysicianTestReview("TestReviewed.csv", model.Collection);
            return Content(message);
        }

        private string WriteCsvPhysicianTestReview(string fileName, IEnumerable<PhysicianTestReviewViewModel> modelData)
        {
            var csvFilePath = _tempMediaLocation.PhysicalPath + fileName;


            // using (var streamWriter = new StreamWriter(csvFilePath, false))
            //{
            var csvStringBuilder = new StringBuilder();
            var members = (typeof(PhysicianTestReviewViewModel)).GetMembers();

            var header = new List<string>();
            foreach (var memberInfo in members)
            {
                if (memberInfo.MemberType != MemberTypes.Property)
                    continue;

                var propInfo = (memberInfo as PropertyInfo);
                if (propInfo != null)
                {
                    if (propInfo.PropertyType == typeof(FeedbackMessageModel) || propInfo.PropertyType == typeof(IEnumerable<OrderedPair<long, int>>))
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

            var tests = _testRepository.GetReviewableTests().OrderBy(t => t.RelativeOrder).ToList();
            header.AddRange(tests.Select(test => test.Name));
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
                        if (propInfo.PropertyType == typeof(FeedbackMessageModel) || propInfo.PropertyType == typeof(IEnumerable<OrderedPair<long, int>>))
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

                foreach (var test in tests)
                {
                    if (model.TestIdCountPairs != null && model.TestIdCountPairs.Count() > 0)
                    {
                        var testCount = model.TestIdCountPairs.Where(ts => ts.FirstValue == test.Id).Select(ts => ts.SecondValue).SingleOrDefault();

                        values.Add(testCount.ToString());
                    }
                    else
                        values.Add("0");
                }

                csvStringBuilder.Append(string.Join(",", values.ToArray()) + Environment.NewLine);

            }

            //    streamWriter.Close();
            //} 
            var request = new GenericReportRequest { CsvFilePath = csvFilePath, Model = csvStringBuilder.ToString() };
            var isGenerated = GetResponse(request, RequestSubcriberChannelNames.GeneratePhysicianTestReviewReportQueue, RequestSubcriberChannelNames.GeneratePhysicianTestReviewReportChannel);
            if (!isGenerated) return "CSV File Export failed!";

            DownloadZipFile(_tempMediaLocation, fileName);

            return "CSV File Export was succesful!";
        }

        public void KynCustomerResultAsync(string id = null, KynCustomerModelFilter filter = null)
        {
            if (id == null) return;

            AsyncManager.OutstandingOperations.Increment();
            var dataGen =
                new ExportableDataGenerator<KynCustomerModel, KynCustomerModelFilter>(
                    _kynCustomerReportService.GetKynCustomerReport);

            var processmanager = new ExportableDataGeneratorProcessManager<KynCustomerModel, KynCustomerModelFilter>();
            processmanager.Add(id, dataGen);

            GetNewProcessStarted(filter, dataGen, id);
        }

        public ActionResult KynCustomerResultCompleted(string id, KynCustomerListModel model)
        {
            if (id == null) return Content("Model can't be null.");

            if (model == null || model.Collection == null || model.Collection.Count() < 1)
                return Content("Model can't be null.");

            RemoveProcess(id);
            var exporter = ExportableDataGeneratorProcessManager<ViewModelBase, ModelFilterBase>.GetCsvExporter<KynCustomerModel>();
            var message = WriteCsv("KynCustomers.csv", exporter, model.Collection, RequestSubcriberChannelNames.KynCustomersQueue, RequestSubcriberChannelNames.KynCustomersChannel);
            return Content(message);
        }

        public void GapClosureAsync(string id = null, GapsClosureModelFilter filter = null)
        {
            if (id == null) return;

            AsyncManager.OutstandingOperations.Increment();
            var dataGen =
                new ExportableDataGenerator<GapsClosureModel, GapsClosureModelFilter>(_eventCustomerReportingService.GetGapsClosureReport);

            var processmanager = new ExportableDataGeneratorProcessManager<GapsClosureModel, GapsClosureModelFilter>();
            processmanager.Add(id, dataGen);

            GetNewProcessStarted(filter, dataGen, id);
        }

        public ActionResult GapClosureCompleted(string id, GapsClosureListModel model)
        {
            if (id == null) return Content("Model can't be null.");

            if (model == null || model.Collection == null || !model.Collection.Any())
                return Content("Model can't be null.");

            RemoveProcess(id);

            var message = WriteCsvGapClosureCustomer(string.Format("HealthPlanGapsClosureReport_{0}.csv", Guid.NewGuid()), model.Collection);
            return Content(message);
        }

        public void HealthPlanGapClosureAsync(string id = null, GapsClosureModelFilter filter = null)
        {
            if (id == null) return;
            if (filter == null) filter = new GapsClosureModelFilter();
            filter.AccountId = _sessionContext.UserSession.CurrentOrganizationRole.OrganizationId;

            AsyncManager.OutstandingOperations.Increment();
            var dataGen = new ExportableDataGenerator<GapsClosureModel, GapsClosureModelFilter>(_eventCustomerReportingService.GetGapsClosureReport);

            var processmanager = new ExportableDataGeneratorProcessManager<GapsClosureModel, GapsClosureModelFilter>();
            processmanager.Add(id, dataGen);

            GetNewProcessStarted(filter, dataGen, id);
        }

        public ActionResult HealthPlanGapClosureCompleted(string id, GapsClosureListModel model)
        {
            if (id == null) return Content("Model can't be null.");

            if (model == null || model.Collection == null || model.Collection.Count() < 1)
                return Content("Model can't be null.");

            RemoveProcess(id);

            var message = WriteCsvGapClosureCustomer(string.Format("GapsClosureReport_{0}.csv", Guid.NewGuid()), model.Collection);
            return Content(message);
        }

        private string WriteCsvGapClosureCustomer(string fileName, IEnumerable<GapsClosureModel> modelData)
        {
            var csvFilePath = _tempMediaLocation.PhysicalPath + fileName;

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

            //    streamWriter.Close();
            //}*/ 
            var request = new GenericReportRequest { CsvFilePath = csvFilePath, Model = csvStringBuilder.ToString() };
            var isGenerated = GetResponse(request, RequestSubcriberChannelNames.GapsClosureReportQueue, RequestSubcriberChannelNames.GapsClosureReportChannel);
            if (!isGenerated) return "CSV File Export failed!";

            DownloadZipFile(_tempMediaLocation, fileName);

            return "CSV File Export was succesful!";
        }

        public void EventArchiveStatsAsync(string id = null, EventArchiveStatsFilter filter = null)
        {
            if (id == null) return;

            AsyncManager.OutstandingOperations.Increment();
            var dataGen = new ExportableDataGenerator<EventArchiveStatsViewModel, EventArchiveStatsFilter>(_eventArchiveStatsService.GetEventArchiveStats);

            var processmanager = new ExportableDataGeneratorProcessManager<EventArchiveStatsViewModel, EventArchiveStatsFilter>();
            processmanager.Add(id, dataGen);

            GetNewProcessStarted(filter, dataGen, id);
        }

        public ActionResult EventArchiveStatsCompleted(string id, EventArchiveStatsListModel model)
        {
            if (id == null) return Content("Model can't be null.");

            if (model == null || model.Collection == null || !model.Collection.Any())
                return Content("Model can't be null.");

            RemoveProcess(id);
            var exporter = ExportableDataGeneratorProcessManager<ViewModelBase, ModelFilterBase>.GetCsvExporter<EventArchiveStatsViewModel>();
            var message = WriteCsv("EventArchiveStats.csv", exporter, model.Collection, RequestSubcriberChannelNames.EventArchiveStatsQueue, RequestSubcriberChannelNames.EventArchiveStatsChannel);
            return Content(message);
        }

        private string WriteCsvTestPerformed(string fileName, IEnumerable<TestPerformedViewModel> modelData)
        {
            var csvFilePath = _tempMediaLocation.PhysicalPath + fileName;

            var csvStringBuilder = new StringBuilder();
            var members = (typeof(TestPerformedViewModel)).GetMembers();

            var header = new List<string>();
            foreach (var memberInfo in members)
            {
                if (memberInfo.MemberType != MemberTypes.Property)
                    continue;

                var propInfo = (memberInfo as PropertyInfo);
                if (propInfo != null)
                {
                    if (propInfo.PropertyType == typeof(FeedbackMessageModel) || propInfo.PropertyType == typeof(IEnumerable<OrderedPair<long, int>>))
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
            //header.Add("Additional Fields");

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
                        if (propInfo.PropertyType == typeof(IEnumerable<OrderedPair<string, string>>))
                        {
                            if (model.AdditionalFields != null && model.AdditionalFields.Any())
                            {
                                string additionFiledString = model.AdditionalFields.Aggregate(string.Empty,
                                    (current, item) => current + item.FirstValue + ": " + item.SecondValue + "\n");

                                values.Add(sanitizer.EscapeString(additionFiledString));
                            }
                            else
                                values.Add(string.Empty);
                            continue;
                        }
                        else if (propInfo.PropertyType == typeof(FeedbackMessageModel))
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




                csvStringBuilder.Append(string.Join(",", values.ToArray()) + Environment.NewLine);

            }

            var request = new GenericReportRequest { CsvFilePath = csvFilePath, Model = csvStringBuilder.ToString() };
            var isGenerated = GetResponse(request, RequestSubcriberChannelNames.TestPerformedQueue, RequestSubcriberChannelNames.TestPerformedChannel);
            if (!isGenerated) return "CSV File Export failed!";

            DownloadZipFile(_tempMediaLocation, fileName);

            return "CSV File Export was succesful!";
        }

        public void DisqualifiedTestReportAsync(string id = null, DisqualifiedTestReportFilter filter = null)
        {
            if (id == null) return;

            AsyncManager.OutstandingOperations.Increment();
            var dataGen = new ExportableDataGenerator<DisqualifiedTestReportViewModel, DisqualifiedTestReportFilter>(_eventCustomerQuestionAnswerServcie.GetDisqualifiedTestReport);

            var processmanager = new ExportableDataGeneratorProcessManager<DisqualifiedTestReportViewModel, DisqualifiedTestReportFilter>();
            processmanager.Add(id, dataGen);

            GetNewProcessStarted(filter, dataGen, id);
        }

        public ActionResult DisqualifiedTestReportCompleted(string id, DisqualifiedTestReportListModel model)
        {
            if (id == null) return Content("Model can't be null.");

            if (model == null || model.Collection == null || !model.Collection.Any())
                return Content("Model can't be null.");

            RemoveProcess(id);
            var exporter = ExportableDataGeneratorProcessManager<ViewModelBase, ModelFilterBase>.GetCsvExporter<DisqualifiedTestReportViewModel>();
            var message = WriteCsv("DisqualifiedTestReport.csv", exporter, model.Collection, RequestSubcriberChannelNames.DisqualifiedTestReportQueue, RequestSubcriberChannelNames.DisqualifiedTestReportChannel);
            return Content(message);
        }
    }
}
