using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Enum;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.CallCenter.ViewModels;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.CallQueues.ViewModels;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.ValueTypes;
using Falcon.App.UI.Controllers;
using Falcon.App.UI.Filters;
using Falcon.App.Core.CallCenter.Domain;
using System.Reflection;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Application.Attributes;
using System.ComponentModel;
using Falcon.App.Core.CallCenter;

namespace Falcon.App.UI.Areas.CallCenter.Controllers
{
    [RoleBasedAuthorize]
    [AsyncTimeout(450000)]
    public class ExportableReportsController : BaseReportsController
    {
        //
        // GET: /CallCenter/ExportableReports/
        private readonly ICallQueueService _callQueueService;
        private readonly ICallCenterReportService _callCenterReportService;
        private readonly ICallQueueCustomerReportService _callQueueCustomerReportService;
        private readonly IConfirmationReportingService _confirmationReportingService;
        private readonly ICallSkippedReportService _callSkippedReportService;
        private readonly IGmsExcludedCustomerService _gmsExcludedCustomerService;
        private readonly ILogger _logger;
        private readonly MediaLocation _tempMediaLocation;
        private readonly IPreAssessmentReportingService _preAssessmentReportingService;

        public ExportableReportsController(ICallQueueService callQueueService, IMediaRepository mediaRepository, IZipHelper zipHelper, ILogManager logManager, ISessionContext sessionContext, ILoginSettingRepository loginSettingRepository,
            IRoleRepository roleRepository, IOrganizationRoleUserRepository organizationRoleUserRepository, IUserRepository<User> userRepository, ISettings settings, ICallCenterReportService callCenterReportService,
            ICallQueueCustomerReportService callQueueCustomerReportService, IConfirmationReportingService confirmationReportingService, ICallSkippedReportService callSkippedReportService, IGmsExcludedCustomerService gmsExcludedCustomerService,
            IPreAssessmentReportingService preAssessmentReportingService)
            : base(zipHelper, logManager, sessionContext, loginSettingRepository, roleRepository, organizationRoleUserRepository, userRepository, settings)
        {
            _callQueueService = callQueueService;
            _callCenterReportService = callCenterReportService;
            _callQueueCustomerReportService = callQueueCustomerReportService;
            _confirmationReportingService = confirmationReportingService;
            _callSkippedReportService = callSkippedReportService;
            _gmsExcludedCustomerService = gmsExcludedCustomerService;
            _logger = logManager.GetLogger<ExportableReportsController>();
            _tempMediaLocation = mediaRepository.GetTempMediaFileLocation();
            _preAssessmentReportingService = preAssessmentReportingService;
        }

        public void CallQueueReportAsync(string id = null, CallQueueReportModelFilter filter = null)
        {
            if (id == null) return;

            AsyncManager.OutstandingOperations.Increment();
            var dataGen = new ExportableDataGenerator<CallQueueReportModel, CallQueueReportModelFilter>(_callQueueService.GetCallQueueReport);

            var processmanager = new ExportableDataGeneratorProcessManager<CallQueueReportModel, CallQueueReportModelFilter>();
            processmanager.Add(id, dataGen);

            GetNewProcessStarted(filter, dataGen, id);
        }

        public ActionResult CallQueueReportCompleted(string id, CallQueueReportListModel model)
        {
            if (id == null) return Content("Model can't be null.");

            if (model == null || model.Collection == null || model.Collection.Count() < 1)
                return Content("Model can't be null.");

            RemoveProcess(id);
            var exporter = ExportableDataGeneratorProcessManager<ViewModelBase, ModelFilterBase>.GetCsvExporter<CallQueueReportModel>();
            var message = WriteCsv(string.Format("CallQueueReport_{0}.csv", id), exporter, model.Collection, RequestSubcriberChannelNames.CallQueueReportQueue, RequestSubcriberChannelNames.CallQueueReportChannel);
            return Content(message);
        }

        public void OutreachCallReportAsync(string id = null, OutreachCallReportModelFilter filter = null)
        {
            if (id == null) return;

            AsyncManager.OutstandingOperations.Increment();
            var dataGen = new ExportableDataGenerator<OutreachCallReportModel, OutreachCallReportModelFilter>(_callQueueService.GetOutreachCallReport);

            var processmanager = new ExportableDataGeneratorProcessManager<OutreachCallReportModel, OutreachCallReportModelFilter>();
            processmanager.Add(id, dataGen);

            GetNewProcessStarted(filter, dataGen, id);
        }

        public ActionResult OutreachCallReportCompleted(string id, OutreachCallReportListModel model)
        {
            if (id == null) return Content("Model can't be null.");

            if (model == null || model.Collection == null || model.Collection.Count() < 1)
                return Content("Model can't be null.");

            RemoveProcess(id);

            var message = WriteCsvOutreachCallReport(string.Format("OutreachCallReport_{0}.csv", Guid.NewGuid()), model.Collection);
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
                catch (Exception exception)
                {
                    _logger.Error("exception while retriving data from filter " + exception.Message);
                    _logger.Error("Message: " + exception.Message);
                    _logger.Error("Stack Trace " + exception.StackTrace);

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

        private string WriteCsv<T>(string fileName, CSVExporter<T> exporter, IEnumerable<T> modelData, string queue, string channel, string filterCriteria = "")
        {
            var csvFilePath = _tempMediaLocation.PhysicalPath + fileName;

            //using (var streamWriter = new StreamWriter(csvFilePath, false))
            //{
            var csvStringBuilder = new StringBuilder();
            var sanitizer = new CSVSanitizer();

            if (!string.IsNullOrEmpty(filterCriteria))
                csvStringBuilder.Append(sanitizer.EscapeString(filterCriteria) + Environment.NewLine + Environment.NewLine);

            csvStringBuilder.Append(exporter.Header + Environment.NewLine);

            foreach (string line in exporter.ExportObjects(modelData))
            {
                csvStringBuilder.Append(line + Environment.NewLine);
            }
            //    streamWriter.Close();
            //}
            var request = new GenericReportRequest { Model = csvStringBuilder.ToString(), CsvFilePath = csvFilePath };

            if (!GetResponse(request, queue, channel)) return "CSV File Export failed!";

            DownloadZipFile(_tempMediaLocation, fileName);

            return "CSV File Export was succesful!";
        }

        private string WriteCsvOutreachCallReport(string fileName, IEnumerable<OutreachCallReportModel> modelData)
        {
            var csvFilePath = _tempMediaLocation.PhysicalPath + fileName;

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
                    if (propInfo.PropertyType == typeof(FeedbackMessageModel) || propInfo.PropertyType == typeof(IEnumerable<CallCenterNotes>))
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
                        if (propInfo.PropertyType == typeof(FeedbackMessageModel) || propInfo.PropertyType == typeof(IEnumerable<CallCenterNotes>))
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
                    var notesString = model.Notes.Aggregate("", (current, note) => current + ("[ " + note.DateCreated.ToShortDateString() + " ] - Notes: " + note.Notes + "\n"));

                    values.Add(sanitizer.EscapeString(notesString));
                }
                else
                    values.Add("N/A");

                csvStringBuilder.Append(string.Join(",", values.ToArray()) + Environment.NewLine);
            }

            var request = new GenericReportRequest { CsvFilePath = csvFilePath, Model = csvStringBuilder.ToString() };
            var isGenerated = GetResponse(request, RequestSubcriberChannelNames.OutreachCallReportQueue, RequestSubcriberChannelNames.OutreachCallReportChannel);
            if (!isGenerated) return "CSV File Export failed!";

            DownloadZipFile(_tempMediaLocation, fileName);

            return "CSV File Export was succesful!";
        }

        public void UncontactedCustomersReportAsync(string id = null, UncontactedCustomersReportModelFilter filter = null)
        {
            if (id == null) return;

            AsyncManager.OutstandingOperations.Increment();
            var dataGen = new ExportableDataGenerator<UncontactedCustomersReportModel, UncontactedCustomersReportModelFilter>(_callQueueService.GetUncontactedCustomersReport);

            var processmanager = new ExportableDataGeneratorProcessManager<UncontactedCustomersReportModel, UncontactedCustomersReportModelFilter>();
            processmanager.Add(id, dataGen);

            GetNewProcessStarted(filter, dataGen, id);
        }


        public void CallQueueSchedulingReportAsync(string id = null, CallQueueSchedulingReportFilter filter = null)
        {
            if (id == null) return;

            AsyncManager.OutstandingOperations.Increment();
            var dataGen = new ExportableDataGenerator<CallQueueSchedulingReportModel, CallQueueSchedulingReportFilter>(_callCenterReportService.GetHealthPlanCallQueueReport);

            var processmanager = new ExportableDataGeneratorProcessManager<CallQueueSchedulingReportModel, CallQueueSchedulingReportFilter>();
            processmanager.Add(id, dataGen);

            GetNewProcessStarted(filter, dataGen, id);
        }

        public ActionResult CallQueueSchedulingReportCompleted(string id, CallQueueSchedulingReportListModel model)
        {
            if (id == null) return Content("Model can't be null.");

            if (model == null || model.Collection == null || model.Collection.Count() < 1)
                return Content("Model can't be null.");

            RemoveProcess(id);
            var exporter = ExportableDataGeneratorProcessManager<ViewModelBase, ModelFilterBase>.GetCsvExporter<CallQueueSchedulingReportModel>();
            var message = WriteCsv(string.Format("CallQueueCustomerReport_{0}.csv", id), exporter, model.Collection, RequestSubcriberChannelNames.CallQueueSchedulingReportQueue, RequestSubcriberChannelNames.CallQueueSchedulingReportChannel);
            return Content(message);
        }

        public ActionResult UncontactedCustomersReportCompleted(string id, UncontactedCustomersReportListModel model)
        {
            if (id == null) return Content("Model can't be null.");

            if (model == null || model.Collection == null || model.Collection.Count() < 1)
                return Content("Model can't be null.");

            RemoveProcess(id);
            var exporter = ExportableDataGeneratorProcessManager<ViewModelBase, ModelFilterBase>.GetCsvExporter<UncontactedCustomersReportModel>();
            var message = WriteCsv(string.Format("UncontactedCustomersReport_{0}.csv", id), exporter, model.Collection, RequestSubcriberChannelNames.UncontactedCustomersReportQueue, RequestSubcriberChannelNames.UncontactedCustomersReportChannel);
            return Content(message);
        }

        public void CallQueueExcludedCustomerReportAsync(string id = null, CallQueueExcludedCustomerReportModelFilter filter = null)
        {
            if (id == null) return;

            AsyncManager.OutstandingOperations.Increment();
            var dataGen = new ExportableDataGenerator<CallQueueExcludedCustomerReportModel, CallQueueExcludedCustomerReportModelFilter>(_callQueueService.GetCallQueueExcludedCustomerReport);

            var processmanager = new ExportableDataGeneratorProcessManager<CallQueueExcludedCustomerReportModel, CallQueueExcludedCustomerReportModelFilter>();
            processmanager.Add(id, dataGen);

            GetNewProcessStarted(filter, dataGen, id);
        }

        public ActionResult CallQueueExcludedCustomerReportCompleted(string id, CallQueueExcludedCustomerReportListModel model)
        {
            if (id == null) return Content("Model can't be null.");

            if (model == null || model.Collection == null || !model.Collection.Any())
                return Content("Model can't be null.");

            RemoveProcess(id);

            var exporter = ExportableDataGeneratorProcessManager<ViewModelBase, ModelFilterBase>.GetCsvExporter<CallQueueExcludedCustomerReportModel>();
            var message = WriteCsv(string.Format("CallQueueExcludedCustomerReport_{0}.csv", Guid.NewGuid()), exporter, model.Collection, RequestSubcriberChannelNames.CallQueueExcludedCustomerReportQueue, RequestSubcriberChannelNames.CallQueueExcludedCustomerReportChannel);
            return Content(message);
        }

        public void AgentConversionReportAsync(string id = null, AgentConversionReportFilter filter = null)
        {
            if (id == null) return;

            AsyncManager.OutstandingOperations.Increment();
            var dataGen = new ExportableDataGenerator<AgentConversionReportViewModel, AgentConversionReportFilter>(_callCenterReportService.GetAgentConversionReport);

            var processmanager = new ExportableDataGeneratorProcessManager<AgentConversionReportViewModel, AgentConversionReportFilter>();
            processmanager.Add(id, dataGen);

            GetNewProcessStarted(filter, dataGen, id);
        }

        public ActionResult AgentConversionReportCompleted(string id, AgentConversionReportListModel model)
        {
            if (id == null) return Content("Model can't be null.");

            if (model == null || model.Collection.IsNullOrEmpty())
                return Content("Model can't be null.");

            RemoveProcess(id);

            var exporter = ExportableDataGeneratorProcessManager<ViewModelBase, ModelFilterBase>.GetCsvExporter<AgentConversionReportViewModel>();
            var message = WriteCsv(string.Format("AgentConversionReport_{0}.csv", id), exporter, model.Collection, RequestSubcriberChannelNames.AgentConversionReportQueue, RequestSubcriberChannelNames.AgentConversionReportChannel);
            return Content(message);
        }

        public void CallQueueCustomersAsync(string id = null, OutboundCallQueueFilter filter = null)
        {
            if (id == null) return;

            AsyncManager.OutstandingOperations.Increment();
            var dataGen = new ExportableDataGenerator<CallQueueCustomersReportModel, OutboundCallQueueFilter>(_callQueueCustomerReportService.GetCallQueueCustomers);

            var processmanager = new ExportableDataGeneratorProcessManager<CallQueueCustomersReportModel, OutboundCallQueueFilter>();
            processmanager.Add(id, dataGen);

            GetNewProcessStarted(filter, dataGen, id);
        }

        public ActionResult CallQueueCustomersCompleted(string id, CallQueueCustomersReportModelListModel model)
        {
            if (id == null) return Content("Model can't be null.");

            if (model == null || model.Collection.IsNullOrEmpty())
                return Content("Model can't be null.");

            RemoveProcess(id);

            var exporter = ExportableDataGeneratorProcessManager<ViewModelBase, ModelFilterBase>.GetCsvExporter<CallQueueCustomersReportModel>();
            var fileName = "CallQueueCustomers_" + model.HealthPlanName.Replace(" ", string.Empty) + "_" + model.CallQueueName.Replace(" ", string.Empty) + "_" + (model.Filter.EventId > 0 ? model.Filter.EventId + "_" : "") + id + ".csv";
            var message = WriteCsv(fileName, exporter, model.Collection, RequestSubcriberChannelNames.CallQueueCustomersReportQueue, RequestSubcriberChannelNames.CallQueueCustomersReportChannel);
            return Content(message);
        }

        public void CustomerWithNoEventsInAreaReportAsync(string id = null, CustomerWithNoEventsInAreaReportModelFilter filter = null)
        {
            if (id == null) return;

            AsyncManager.OutstandingOperations.Increment();
            var dataGen = new ExportableDataGenerator<CustomerWithNoEventsInAreaReportModel, CustomerWithNoEventsInAreaReportModelFilter>(_callQueueService.GetCustomerWithNoEventsInArea);

            var processmanager = new ExportableDataGeneratorProcessManager<CustomerWithNoEventsInAreaReportModel, CustomerWithNoEventsInAreaReportModelFilter>();
            processmanager.Add(id, dataGen);

            GetNewProcessStarted(filter, dataGen, id);
        }

        public ActionResult CustomerWithNoEventsInAreaReportCompleted(string id, CustomerWithNoEventsInAreaReportListModel model)
        {
            if (id == null) return Content("Model can't be null.");

            if (model == null || model.Collection == null || !model.Collection.Any())
                return Content("Model can't be null.");

            RemoveProcess(id);

            var exporter = ExportableDataGeneratorProcessManager<ViewModelBase, ModelFilterBase>.GetCsvExporter<CustomerWithNoEventsInAreaReportModel>();
            var message = WriteCsv(string.Format("CustomerWithNoEventsInAreaReport_{0}.csv", Guid.NewGuid()), exporter, model.Collection, RequestSubcriberChannelNames.CustomerWithNoEventsInAreaReportQueue, RequestSubcriberChannelNames.CustomerWithNoEventsInAreaReportChannel);
            return Content(message);
        }

        public void CallCenterCallReportAsync(string id = null, CallCenterCallReportModelFilter filter = null)
        {
            if (id == null) return;

            AsyncManager.OutstandingOperations.Increment();
            var dataGen = new ExportableDataGenerator<CallCenterCallReportModel, CallCenterCallReportModelFilter>(_callQueueService.GetCallCenterCallReport);

            var processmanager = new ExportableDataGeneratorProcessManager<CallCenterCallReportModel, CallCenterCallReportModelFilter>();
            processmanager.Add(id, dataGen);

            GetNewProcessStarted(filter, dataGen, id);
        }

        public ActionResult CallCenterCallReportCompleted(string id, CallCenterCallReportListModel model)
        {
            if (id == null) return Content("Model can't be null.");

            if (model == null || model.Collection == null || model.Collection.Count() < 1)
                return Content("Model can't be null.");

            RemoveProcess(id);

            var message = WriteCsvCallCenterCallReport(string.Format("CallCenterCallReport_{0}.csv", Guid.NewGuid()), model.Collection);
            return Content(message);
        }

        private string WriteCsvCallCenterCallReport(string fileName, IEnumerable<CallCenterCallReportModel> modelData)
        {
            var csvFilePath = _tempMediaLocation.PhysicalPath + fileName;

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
                    if (propInfo.PropertyType == typeof(FeedbackMessageModel) || propInfo.PropertyType == typeof(IEnumerable<CallCenterNotes>))
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
                        if (propInfo.PropertyType == typeof(FeedbackMessageModel) || propInfo.PropertyType == typeof(IEnumerable<CallCenterNotes>))
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
                    var notesString = model.Notes.Aggregate("", (current, note) => current + ("[ " + note.DateCreated.ToShortDateString() + " ] - Notes: " + note.Notes + "\n"));

                    values.Add(sanitizer.EscapeString(notesString));
                }
                else
                    values.Add("N/A");

                csvStringBuilder.Append(string.Join(",", values.ToArray()) + Environment.NewLine);
            }

            var request = new GenericReportRequest { CsvFilePath = csvFilePath, Model = csvStringBuilder.ToString() };
            var isGenerated = GetResponse(request, RequestSubcriberChannelNames.CallCenterCallReportQueue, RequestSubcriberChannelNames.CallCenterCallReportChannel);
            if (!isGenerated) return "CSV File Export failed!";

            DownloadZipFile(_tempMediaLocation, fileName);

            return "CSV File Export was succesful!";
        }

        public void ConfirmationReportAsync(string id = null, ConfirmationReportFilter filter = null)
        {
            if (id == null) return;

            AsyncManager.OutstandingOperations.Increment();
            var dataGen = new ExportableDataGenerator<ConfirmationReportViewModel, ConfirmationReportFilter>(_confirmationReportingService.GetConfirmationReport);

            var processmanager = new ExportableDataGeneratorProcessManager<ConfirmationReportViewModel, ConfirmationReportFilter>();
            processmanager.Add(id, dataGen);

            GetNewProcessStarted(filter, dataGen, id);
        }

        public ActionResult ConfirmationReportCompleted(string id, ConfirmationReportListModel model)
        {
            if (id == null) return Content("Model can't be null.");

            if (model == null || model.Collection == null || model.Collection.Count() < 1)
                return Content("Model can't be null.");

            RemoveProcess(id);

            var exporter = ExportableDataGeneratorProcessManager<ViewModelBase, ModelFilterBase>.GetCsvExporter<ConfirmationReportViewModel>();
            var message = WriteCsv(string.Format("ConfirmationReport_{0}.csv", Guid.NewGuid()), exporter, model.Collection, RequestSubcriberChannelNames.ConfirmationReportQueue, RequestSubcriberChannelNames.ConfirmationReportChannel);
            return Content(message);
        }

        public void CallSkippedReportAsync(string id = null, CallSkippedReportFilter filter = null)
        {
            if (id == null) return;

            AsyncManager.OutstandingOperations.Increment();
            var dataGen = new ExportableDataGenerator<CallSkippedReportViewModel, CallSkippedReportFilter>(_callSkippedReportService.GetCallSkippedReport);

            var processmanager = new ExportableDataGeneratorProcessManager<CallSkippedReportViewModel, CallSkippedReportFilter>();
            processmanager.Add(id, dataGen);

            GetNewProcessStarted(filter, dataGen, id);
        }

        public ActionResult CallSkippedReportCompleted(string id, CallSkippedReportListModel model)
        {
            if (id == null) return Content("Model can't be null.");

            if (model == null || model.Collection == null || !model.Collection.Any())
                return Content("Model can't be null.");

            RemoveProcess(id);
            var exporter = ExportableDataGeneratorProcessManager<ViewModelBase, ModelFilterBase>.GetCsvExporter<CallSkippedReportViewModel>();
            var message = WriteCsv(string.Format("CallSkippedReport{0}.csv", Guid.NewGuid()), exporter, model.Collection, RequestSubcriberChannelNames.CallSkippedReportQueue, RequestSubcriberChannelNames.CallSkippedReportChannel);
            return Content(message);
        }

        public void ExcludedCustomersAsync(string id = null, OutboundCallQueueFilter filter = null)
        {
            if (id == null) return;

            AsyncManager.OutstandingOperations.Increment();
            var dataGen = new ExportableDataGenerator<GmsExcludedCustomerViewModel, OutboundCallQueueFilter>(_gmsExcludedCustomerService.GetExcludedCustomers);

            var processmanager = new ExportableDataGeneratorProcessManager<GmsExcludedCustomerViewModel, OutboundCallQueueFilter>();
            processmanager.Add(id, dataGen);

            GetNewProcessStarted(filter, dataGen, id);
        }

        public ActionResult ExcludedCustomersCompleted(string id, ExcludedCustomerListModel model)
        {
            if (id == null) return Content("Model can't be null.");

            if (model == null || model.Collection == null || !model.Collection.Any())
                return Content("Model can't be null.");

            RemoveProcess(id);
            var exporter = ExportableDataGeneratorProcessManager<ViewModelBase, ModelFilterBase>.GetCsvExporter<GmsExcludedCustomerViewModel>();
            var message = WriteCsv(string.Format("ExcludedCustomerReport{0}.csv", Guid.NewGuid()), exporter, model.Collection, RequestSubcriberChannelNames.ExcludedCustomerReportQueue, RequestSubcriberChannelNames.ExcludedCustomerReportChannel);
            return Content(message);
        }

        public void PreAssessmentReportAsync(string id = null, PreAssessmentReportFilter filter = null)
        {
            if (id == null) return;

            AsyncManager.OutstandingOperations.Increment();
            var dataGen = new ExportableDataGenerator<PreAssessmentReportViewModel, PreAssessmentReportFilter>(_preAssessmentReportingService.GetPreAssessmentReport);

            var processmanager = new ExportableDataGeneratorProcessManager<PreAssessmentReportViewModel, PreAssessmentReportFilter>();
            processmanager.Add(id, dataGen);

            GetNewProcessStarted(filter, dataGen, id);
        }

        public ActionResult PreAssessmentReportCompleted(string id, PreAssessmentReportListModel model)
        {
            if (id == null) return Content("Model can't be null.");

            if (model == null || model.Collection == null || model.Collection.Count() < 1)
                return Content("Model can't be null.");

            RemoveProcess(id);

            var exporter = ExportableDataGeneratorProcessManager<ViewModelBase, ModelFilterBase>.GetCsvExporter<PreAssessmentReportViewModel>();
            var message = WriteCsv(string.Format("PreAssessmentReport_{0}.csv", Guid.NewGuid()), exporter, model.Collection, RequestSubcriberChannelNames.PreAssessmentReportQueue, RequestSubcriberChannelNames.PreAssessmentReportChannel);
            return Content(message);
        }
    
    }
}
