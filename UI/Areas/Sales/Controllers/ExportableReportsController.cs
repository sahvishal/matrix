using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;
using Falcon.App.Core;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Enum;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Core.Sales;
using Falcon.App.Core.Sales.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.ValueTypes;
using Falcon.App.UI.Controllers;
using Falcon.App.UI.Filters;
using System.Text;

namespace Falcon.App.UI.Areas.Sales.Controllers
{
    [RoleBasedAuthorize]
    [AsyncTimeout(450000)]
    public class ExportableReportsController : BaseReportsController
    {
        //
        // GET: /Sales/ExportableReports/
        private readonly IHospitalPartnerService _hospitalPartnerService;
        private readonly ITestRepository _testRepository;
        private readonly MediaLocation _tempMediaLocation;
        private readonly ILogger _logger;
        public ExportableReportsController(IHospitalPartnerService hospitalPartnerService, ITestRepository testRepository, IMediaRepository mediaRepository, IZipHelper zipHelper,
            ILogManager logManager, ISessionContext sessionContext, ILoginSettingRepository loginSettingRepository, IRoleRepository roleRepository, IOrganizationRoleUserRepository organizationRoleUserRepository,
            IUserRepository<User> userRepository, ISettings settings)
            : base(zipHelper, logManager, sessionContext, loginSettingRepository, roleRepository, organizationRoleUserRepository, userRepository, settings)
        {
            _hospitalPartnerService = hospitalPartnerService;
            _logger = logManager.GetLogger<ExportableReportsController>();
            _testRepository = testRepository;
            _tempMediaLocation = mediaRepository.GetTempMediaFileLocation();
        }

        public void EventCustomersAsync(string id = null, HospitalPartnerCustomerListModelFilter filter = null)
        {
            if (id == null) return;

            AsyncManager.OutstandingOperations.Increment();
            var dataGen =
                new ExportableDataGenerator<HospitalPartnerCustomerViewModel, HospitalPartnerCustomerListModelFilter>(
                    _hospitalPartnerService.GetHospitalPartnerEventCustomers, _logger);

            var processmanager = new ExportableDataGeneratorProcessManager<HospitalPartnerCustomerViewModel, HospitalPartnerCustomerListModelFilter>();
            processmanager.Add(id, dataGen);

            GetNewProcessStarted(filter, dataGen, id);
        }

        public ActionResult EventCustomersCompleted(string id, HospitalPartnerCustomerListModel model)
        {
            if (id == null) return Content("Model can't be null.");

            if (model == null || model.Collection == null || model.Collection.Count() < 1)
                return Content("Model can't be null.");

            RemoveProcess(id);
            var message = WriteCsvHospitalPartnerCustomer("Customers.csv", model.Collection);
            return Content(message);
        }

        public void SearchCustomersAsync(string id = null, HospitalPartnerCustomerListModelFilter filter = null)
        {
            if (id == null) return;

            AsyncManager.OutstandingOperations.Increment();
            var dataGen =
                new ExportableDataGenerator<HospitalPartnerCustomerViewModel, HospitalPartnerCustomerListModelFilter>(
                    _hospitalPartnerService.GetHospitalPartnerCustomers);

            var processmanager = new ExportableDataGeneratorProcessManager<HospitalPartnerCustomerViewModel, HospitalPartnerCustomerListModelFilter>();
            processmanager.Add(id, dataGen);

            GetNewProcessStarted(filter, dataGen, id);
        }

        public ActionResult SearchCustomersCompleted(string id, HospitalPartnerCustomerListModel model)
        {
            if (id == null) return Content("Model can't be null.");

            if (model == null || model.Collection == null || model.Collection.Count() < 1)
                return Content("Model can't be null.");

            RemoveProcess(id);
            var message = WriteCsvHospitalPartnerCustomer("Customers.csv", model.Collection);
            return Content(message);
        }

        public void CustomerAggregateResultSummaryAsync(string id = null, HospitalPartnerCustomerListModelFilter filter = null)
        {
            if (id == null) return;

            AsyncManager.OutstandingOperations.Increment();
            var dataGen =
                new ExportableDataGenerator<HospitalPartnerCustomerViewModel, HospitalPartnerCustomerListModelFilter>(
                    _hospitalPartnerService.GetCustomerAggregateResultSummary, _logger);

            var processmanager = new ExportableDataGeneratorProcessManager<HospitalPartnerCustomerViewModel, HospitalPartnerCustomerListModelFilter>();
            processmanager.Add(id, dataGen);

            GetNewProcessStarted(filter, dataGen, id);
        }

        public ActionResult CustomerAggregateResultSummaryCompleted(string id, HospitalPartnerCustomerListModel model)
        {
            if (id == null) return Content("Model can't be null.");

            if (model == null || model.Collection == null || model.Collection.Count() < 1)
                return Content("Model can't be null.");

            RemoveProcess(id);
            var message = WriteCsvHospitalPartnerCustomer("Customers.csv", model.Collection);
            return Content(message);
        }

        public void SearchEventsAsync(string id = null, HospitalPartnerEventListModelFilter filter = null)
        {
            if (id == null) return;

            AsyncManager.OutstandingOperations.Increment();
            var dataGen =
                new ExportableDataGenerator<HospitalPartnerEventViewModel, HospitalPartnerEventListModelFilter>(
                    _hospitalPartnerService.GetHospitalPartnerEvents);

            var processmanager = new ExportableDataGeneratorProcessManager<HospitalPartnerEventViewModel, HospitalPartnerEventListModelFilter>();
            processmanager.Add(id, dataGen);

            GetNewProcessStarted(filter, dataGen, id);
        }

        public ActionResult SearchEventsCompleted(string id, HospitalPartnerEventListModel model)
        {
            if (id == null) return Content("Model can't be null.");

            if (model == null || model.Collection == null || !model.Collection.Any())
                return Content("Model can't be null.");

            RemoveProcess(id);

            var message = WriteCsvHospitalPartnerEvent("Events.csv", model.Collection);
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
                catch (Exception ex)
                {
                    var message = ex.Message;
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

        //private string WriteCsv<T>(string fileName, CSVExporter<T> exporter, IEnumerable<T> modelData)
        //{
        //    var csvFilePath = _tempMediaLocation.PhysicalPath + fileName;

        //    using (var streamWriter = new StreamWriter(csvFilePath, false))
        //    {
        //        streamWriter.Write(exporter.Header + Environment.NewLine);

        //        foreach (string line in exporter.ExportObjects(modelData))
        //        {
        //            streamWriter.Write(line + Environment.NewLine);
        //        }

        //        streamWriter.Close();
        //    }

        //    DownloadZipFile(_tempMediaLocation, fileName);

        //    return "CSV File Export was succesful!";
        //}

        private string WriteCsvHospitalPartnerCustomer(string fileName, IEnumerable<HospitalPartnerCustomerViewModel> modelData)
        {
            var csvFilePath = _tempMediaLocation.PhysicalPath + fileName;


            //using (var streamWriter = new StreamWriter(csvFilePath, false))
            //{
            var csvStringBuilder = new StringBuilder();
            var members = (typeof(HospitalPartnerCustomerViewModel)).GetMembers();

            var header = new List<string>();
            foreach (var memberInfo in members)
            {
                if (memberInfo.MemberType != MemberTypes.Property)
                    continue;

                var propInfo = (memberInfo as PropertyInfo);
                if (propInfo != null)
                {
                    if (propInfo.PropertyType == typeof(FeedbackMessageModel) || propInfo.PropertyType == typeof(IEnumerable<OrderedPair<long, string>>) || propInfo.PropertyType == typeof(IEnumerable<HospitalPartnerCustomerActivityViewModel>))
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
            header.Add("Activity");
            header.Add(HealthAssessmentQuestionLabel.PrimaryCare.GetDescription());
            header.Add(HealthAssessmentQuestionLabel.MammogramProstateScreening.GetDescription());
            header.Add(HealthAssessmentQuestionLabel.Colonoscopy.GetDescription());
            header.Add(HealthAssessmentQuestionLabel.Cancer.GetDescription());
            header.Add(HealthAssessmentQuestionLabel.WeightBariatric.GetDescription());
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
                        if (propInfo.PropertyType == typeof(FeedbackMessageModel) || propInfo.PropertyType == typeof(IEnumerable<OrderedPair<long, string>>) || propInfo.PropertyType == typeof(IEnumerable<HospitalPartnerCustomerActivityViewModel>))
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
                    if (model.TestSummary != null && model.TestSummary.Count() > 0)
                    {
                        var summaryFinding =
                            model.TestSummary.Where(ts => ts.FirstValue == test.Id).Select(ts => ts.SecondValue).
                                FirstOrDefault();
                        values.Add(summaryFinding);
                    }
                    else
                        values.Add(string.Empty);
                }

                if (model.Activities != null && model.Activities.Count() > 0)
                {
                    var activitySummary = string.Empty;
                    foreach (var activity in model.Activities)
                    {
                        activitySummary += "Status: " + activity.Status + "\n";
                        activitySummary += "Outcome: " + activity.Outcome + "\n";
                        activitySummary += "Updated On: " + activity.UpdateOn.ToShortDateString() + "\n";
                        activitySummary += "Updated By: " + activity.UpdatedBy + "\n";
                        activitySummary += "Notes: " + activity.Notes + "\n\n";
                    }
                    values.Add(sanitizer.EscapeString(activitySummary));
                }
                else
                    values.Add(string.Empty);

                values.Add(model.PrimaryCare);
                values.Add(model.MammogramProstateScreening);
                values.Add(model.Colonoscopy);
                values.Add(model.Cancer);
                values.Add(model.WeightBariatric);
                csvStringBuilder.Append(string.Join(",", values.ToArray()) + Environment.NewLine);

            }

            //    streamWriter.Close();
            //}



            var request = new GenericReportRequest { CsvFilePath = csvFilePath, Model = csvStringBuilder.ToString() };
            var isGenerated = GetResponse(request, RequestSubcriberChannelNames.GenerateHospitalPartnerCustomerReportQueue, RequestSubcriberChannelNames.GenerateHospitalPartnerCustomerReportChannel);
            if (!isGenerated) return "CSV File Export failed!";

            DownloadZipFile(_tempMediaLocation, fileName);

            return "CSV File Export was succesful!";
        }

        private string WriteCsvHospitalPartnerEvent(string fileName, IEnumerable<HospitalPartnerEventViewModel> modelData)
        {
            var csvFilePath = _tempMediaLocation.PhysicalPath + fileName;


            //  using (var streamWriter = new StreamWriter(csvFilePath, false))
            //{
            var csvStringBuilder = new StringBuilder();
            var members = (typeof(HospitalPartnerEventViewModel)).GetMembers();

            var header = new List<string>();
            foreach (var memberInfo in members)
            {
                if (memberInfo.MemberType != MemberTypes.Property)
                    continue;

                var propInfo = (memberInfo as PropertyInfo);
                if (propInfo != null)
                {
                    if (propInfo.PropertyType == typeof(FeedbackMessageModel) || propInfo.PropertyType == typeof(IEnumerable<NotesViewModel>))
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
                        if (propInfo.PropertyType == typeof(FeedbackMessageModel) || propInfo.PropertyType == typeof(IEnumerable<NotesViewModel>))
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
                    var notesString = string.Empty;
                    foreach (var notesViewModel in model.Notes)
                    {
                        notesString += "Updated On: " + (notesViewModel.EnteredOn.HasValue ? notesViewModel.EnteredOn.Value.ToShortDateString() : string.Empty) + "\n";
                        notesString += "Updated By: " + notesViewModel.CreatedByUser + "\n";
                        notesString += "Notes: " + notesViewModel.Note + "\n\n";
                    }
                    values.Add(sanitizer.EscapeString(notesString));
                }
                else
                    values.Add(string.Empty);

                csvStringBuilder.Append(string.Join(",", values.ToArray()) + Environment.NewLine);

            }

            //    streamWriter.Close();
            //}


            var request = new GenericReportRequest { CsvFilePath = csvFilePath, Model = csvStringBuilder.ToString() };
            var isGenerated = GetResponse(request, RequestSubcriberChannelNames.GenerateHospitalPartnerEventReportQueue, RequestSubcriberChannelNames.GenerateHospitalPartnerEventReportChannel);
            if (!isGenerated) return "CSV File Export failed!";

            DownloadZipFile(_tempMediaLocation, fileName);

            return "CSV File Export was succesful!";
        }

        public void SearchHospitalFacilityEventsAsync(string id = null, HospitalPartnerEventListModelFilter filter = null)
        {
            if (id == null) return;

            AsyncManager.OutstandingOperations.Increment();
            var dataGen = new ExportableDataGenerator<HospitalPartnerEventViewModel, HospitalPartnerEventListModelFilter>(_hospitalPartnerService.GetHospitalFacilityEvents);

            var processmanager = new ExportableDataGeneratorProcessManager<HospitalPartnerEventViewModel, HospitalPartnerEventListModelFilter>();
            processmanager.Add(id, dataGen);

            GetNewProcessStarted(filter, dataGen, id);
        }

        public ActionResult SearchHospitalFacilityEventsCompleted(string id, HospitalPartnerEventListModel model)
        {
            if (id == null) return Content("Model can't be null.");

            if (model == null || model.Collection == null || !model.Collection.Any())
                return Content("Model can't be null.");

            RemoveProcess(id);

            var message = WriteCsvHospitalPartnerEvent("Events.csv", model.Collection);
            return Content(message);
        }

    }
}
