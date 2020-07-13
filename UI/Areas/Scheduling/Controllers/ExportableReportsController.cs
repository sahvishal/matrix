using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Enum;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Communication.Domain;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.ValueTypes;
using Falcon.App.UI.Controllers;
using Falcon.App.UI.Filters;
using Falcon.App.Core.Operations;
using Falcon.App.Core;

namespace Falcon.App.UI.Areas.Scheduling.Controllers
{
    [RoleBasedAuthorize]
    [AsyncTimeout(450000)]
    public class ExportableReportsController : BaseReportsController
    {
        private readonly IEventReportingService _eventReportingService;
        private readonly IEventCustomerReportingService _eventCustomerReportingService;
        private readonly MediaLocation _tempMediaLocation;
        private readonly ISessionContext _sessionContext;
        private readonly IExportableReportsQueueService _exportableReportsQueueService;
        private readonly IPcpTrackingReportService _pcpTrackingReportService;
        private readonly ICustomerScheduleCsvHelper _customerScheduleCsvHelper;
        private readonly IEventService _eventService;

        public ExportableReportsController(IEventReportingService eventReportingService, IEventCustomerReportingService eventCustomerReportingService, IMediaRepository mediaRepository, IZipHelper zipHelper,
            ILogManager logManager, ISessionContext sessionContext, ILoginSettingRepository loginSettingRepository, IRoleRepository roleRepository, IOrganizationRoleUserRepository organizationRoleUserRepository,
            IUserRepository<User> userRepository, ISettings settings, IExportableReportsQueueService exportableReportsQueueService, IEventService eventService, IPcpTrackingReportService pcpTrackingReportService,
            ICustomerScheduleCsvHelper customerScheduleCsvHelper)
            : base(zipHelper, logManager, sessionContext, loginSettingRepository, roleRepository, organizationRoleUserRepository, userRepository, settings)
        {
            _eventReportingService = eventReportingService;
            _eventCustomerReportingService = eventCustomerReportingService;
            _tempMediaLocation = mediaRepository.GetTempMediaFileLocation();
            _sessionContext = sessionContext;
            _exportableReportsQueueService = exportableReportsQueueService;
            _eventService = eventService;
            _pcpTrackingReportService = pcpTrackingReportService;
            _customerScheduleCsvHelper = customerScheduleCsvHelper;
        }


        public void AppointmentsBookedAsync(string id = null, AppointmentsBookedListModelFilter filter = null)
        {
            if (id == null) return;

            AsyncManager.OutstandingOperations.Increment();
            var dataGen =
                new ExportableDataGenerator<AppointmentsBookedModel, AppointmentsBookedListModelFilter>(
                    _eventCustomerReportingService.GetAppointmentsBooked);

            var processmanager = new ExportableDataGeneratorProcessManager<AppointmentsBookedModel, AppointmentsBookedListModelFilter>();
            processmanager.Add(id, dataGen);

            GetNewProcessStarted(filter, dataGen, id);
        }

        public ActionResult AppointmentsBookedCompleted(string id, AppointmentsBookedListModel model)
        {
            if (id == null) return Content("Model can't be null.");

            if (model == null || model.Collection == null || model.Collection.Count() < 1)
                return Content("Model can't be null.");

            RemoveProcess(id);
            var message = WriteCsvAppointmentBooked("AppointmentsBooked.csv", model.Collection);
            return Content(message);
        }

        public void PublicEventVolumeAsync(string id = null, EventVolumeListModelFilter filter = null, bool showThisYear = false)
        {
            if (id == null) return;

            if (showThisYear)
            {
                if (filter == null)
                    filter = new EventVolumeListModelFilter();
                filter.FromDate = Convert.ToDateTime("01/01/" + DateTime.Today.Year);
            }

            AsyncManager.OutstandingOperations.Increment();
            var dataGen =
                new ExportableDataGenerator<EventVolumeModel, EventVolumeListModelFilter>(
                    _eventReportingService.GetEventVolumeForPublicPatients);

            var processmanager = new ExportableDataGeneratorProcessManager<EventVolumeModel, EventVolumeListModelFilter>();
            processmanager.Add(id, dataGen);

            GetNewProcessStarted(filter, dataGen, id);
        }

        public ActionResult PublicEventVolumeCompleted(string id, EventVolumeListModel model, bool showThisYear = false)
        {
            if (id == null) return Content("Model can't be null.");

            if (model == null || model.Collection == null || model.Collection.Count() < 1)
                return Content("Model can't be null.");

            RemoveProcess(id);
            var message = WriteCsvPublicEventVolume("PublicEventVolume.csv", model.Collection);
            return Content(message);
        }

        public void CorporateEventVolumeAsync(string id = null, EventVolumeListModelFilter filter = null, bool showThisYear = false)
        {
            if (id == null) return;

            if (showThisYear)
            {
                if (filter == null)
                    filter = new EventVolumeListModelFilter();
                filter.FromDate = Convert.ToDateTime("01/01/" + DateTime.Today.Year);
            }

            AsyncManager.OutstandingOperations.Increment();
            var dataGen =
                new ExportableDataGenerator<EventVolumeModel, EventVolumeListModelFilter>(
                    _eventReportingService.GetEventVolumeForCorporatePatients);

            var processmanager = new ExportableDataGeneratorProcessManager<EventVolumeModel, EventVolumeListModelFilter>();
            processmanager.Add(id, dataGen);

            GetNewProcessStarted(filter, dataGen, id);
        }

        public ActionResult CorporateEventVolumeCompleted(string id, EventVolumeListModel model, bool showThisYear = false)
        {
            if (id == null) return Content("Model can't be null.");

            if (model == null || model.Collection == null || model.Collection.Count() < 1)
                return Content("Model can't be null.");

            RemoveProcess(id);
            var message = WriteCsvCorporateEventVolume("CorporateEventVolume.csv", model.Collection);
            return Content(message);
        }

        public void NoShowCustomerAsync(string id = null, NoShowCustomerModelFilter filter = null)
        {
            if (id == null) return;

            AsyncManager.OutstandingOperations.Increment();
            var dataGen =
                new ExportableDataGenerator<NoShowCustomerModel, NoShowCustomerModelFilter>(
                    _eventCustomerReportingService.GetNoShowCustomers);

            var processmanager = new ExportableDataGeneratorProcessManager<NoShowCustomerModel, NoShowCustomerModelFilter>();
            processmanager.Add(id, dataGen);

            GetNewProcessStarted(filter, dataGen, id);
        }

        public ActionResult NoShowCustomerCompleted(string id, NoShowCustomerListModel model)
        {
            if (id == null) return Content("Model can't be null.");

            if (model == null || model.Collection == null || model.Collection.Count() < 1)
                return Content("Model can't be null.");

            RemoveProcess(id);
            var exporter = ExportableDataGeneratorProcessManager<ViewModelBase, ModelFilterBase>.GetCsvExporter<NoShowCustomerModel>();
            var message = WriteCsv("NoShowCustomer.csv", exporter, model.Collection, RequestSubcriberChannelNames.NoShowCustomerQueue, RequestSubcriberChannelNames.NoShowCustomerChannel);
            return Content(message);
        }

        public void CancelledCustomerAsync(string id = null, CancelledCustomerModelFilter filter = null)
        {
            if (id == null) return;

            AsyncManager.OutstandingOperations.Increment();
            var dataGen =
                new ExportableDataGenerator<CancelledCustomerModel, CancelledCustomerModelFilter>(
                    _eventCustomerReportingService.GetCancelledCustomers);

            var processmanager = new ExportableDataGeneratorProcessManager<CancelledCustomerModel, CancelledCustomerModelFilter>();
            processmanager.Add(id, dataGen);

            GetNewProcessStarted(filter, dataGen, id);
        }

        public ActionResult CancelledCustomerCompleted(string id, CancelledCustomerListModel model)
        {
            if (id == null) return Content("Model can't be null.");

            if (model == null || model.Collection == null || model.Collection.Count() < 1)
                return Content("Model can't be null.");

            RemoveProcess(id);
            var exporter = ExportableDataGeneratorProcessManager<ViewModelBase, ModelFilterBase>.GetCsvExporter<CancelledCustomerModel>();
            var message = WriteCsvCancelledCustomer("CancelledCustomer.csv", model.Collection);
            return Content(message);
        }

        public void CustomerScheduleAsync(string id = null, CustomerScheduleModelFilter filter = null)
        {
            if (id == null) return;

            AsyncManager.OutstandingOperations.Increment();
            var dataGen =
                new ExportableDataGenerator<EventCustomerScheduleModel, CustomerScheduleModelFilter>(
                    _eventCustomerReportingService.GetCustomerScheduleModel);

            var processmanager = new ExportableDataGeneratorProcessManager<EventCustomerScheduleModel, CustomerScheduleModelFilter>();
            processmanager.Add(id, dataGen);

            GetNewProcessStarted(filter, dataGen, id);
        }

        public ActionResult CustomerScheduleCompleted(string id, EventCustomerScheduleListModel model)
        {
            if (id == null) return Content("Model can't be null.");

            if (model == null || model.Collection == null || model.Collection.Count() < 1)
                return Content("Model can't be null.");

            RemoveProcess(id);

            var message = WriteCsv("CustomerSchedule.csv", model.Collection);
            return Content(message);
        }

        public ContentResult GetStatus(string id)
        {
            var processmanager = new ExportableDataGeneratorProcessManager<ViewModelBase, ModelFilterBase>();
            return Content(processmanager.GetStatus(id).ToString());
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
            //streamWriter.Close();
            //}

            var request = new GenericReportRequest { Model = csvStringBuilder.ToString(), CsvFilePath = csvFilePath };
            var isGenerated = GetResponse(request, queue, channel);
            if (!isGenerated) return "CSV File Export failed!";

            DownloadZipFile(_tempMediaLocation, fileName);

            return "CSV File Export was succesful!";
        }

        private string WriteCsv(string fileName, IEnumerable<EventCustomerScheduleModel> modelData)
        {
            var csvFilePath = _tempMediaLocation.PhysicalPath + fileName;


            var exporter = ExportableDataGeneratorProcessManager<ViewModelBase, ModelFilterBase>.GetCsvExporter<CustomerScheduleModel>();

            var csvStringBuilder = _customerScheduleCsvHelper.GetPatientScheduledReport(modelData, exporter);

            var request = new GenericReportRequest { CsvFilePath = csvFilePath, Model = csvStringBuilder.ToString() };
            var isGenerated = GetResponse(request, RequestSubcriberChannelNames.GenerateCustomerScheduleReportQueue, RequestSubcriberChannelNames.GenerateCustomerScheduleReportChannel);
            if (!isGenerated) return "CSV File Export failed!";

            DownloadZipFile(_tempMediaLocation, fileName);

            return "CSV File Export was succesful!";
        }

        private string WriteCsvCancelledCustomer(string fileName, IEnumerable<CancelledCustomerModel> modelData)
        {
            var csvFilePath = _tempMediaLocation.PhysicalPath + fileName;

            //using (var streamWriter = new StreamWriter(csvFilePath, false))
            //{
            var csvStringBuilder = new StringBuilder();
            var members = (typeof(CancelledCustomerModel)).GetMembers();

            var header = new List<string>();
            foreach (var memberInfo in members)
            {
                if (memberInfo.MemberType != MemberTypes.Property)
                    continue;

                var propInfo = (memberInfo as PropertyInfo);
                if (propInfo != null)
                {
                    if (propInfo.PropertyType == typeof(FeedbackMessageModel) || propInfo.PropertyType == typeof(IEnumerable<CustomerCallNotes>))
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
                        if (propInfo.PropertyType == typeof(FeedbackMessageModel) || propInfo.PropertyType == typeof(IEnumerable<CustomerCallNotes>))
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
                    var notesString = model.Notes.Aggregate("", (current, note) => current + ("[ " + note.DataRecorderMetaData.DateCreated.ToShortDateString() + " ] - Notes: " + note.Notes + "\n"));

                    values.Add(sanitizer.EscapeString(notesString));
                }
                else
                    values.Add(string.Empty);

                csvStringBuilder.Append(string.Join(",", values.ToArray()) + Environment.NewLine);
            }

            //    streamWriter.Close();
            //}*/ 
            var request = new GenericReportRequest { CsvFilePath = csvFilePath, Model = csvStringBuilder.ToString() };
            var isGenerated = GetResponse(request, RequestSubcriberChannelNames.GenerateCancelledCustomerReportQueue, RequestSubcriberChannelNames.GenerateCancelledCustomerReportChannel);
            if (!isGenerated) return "CSV File Export failed!";

            DownloadZipFile(_tempMediaLocation, fileName);

            return "CSV File Export was succesful!";
        }

        private string WriteCsvAppointmentBooked(string fileName, IEnumerable<AppointmentsBookedModel> modelData)
        {
            var csvFilePath = _tempMediaLocation.PhysicalPath + fileName;

            //using (var streamWriter = new StreamWriter(csvFilePath, false))
            //{
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
                        if (propInfo.PropertyType == typeof(FeedbackMessageModel) || propInfo.PropertyType == typeof(IEnumerable<OrderedPair<string, string>>))
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

            //    streamWriter.Close();
            //} 

            var request = new GenericReportRequest { CsvFilePath = csvFilePath, Model = csvStringBuilder.ToString() };
            var isGenerated = GetResponse(request, RequestSubcriberChannelNames.GenerateAppointmentBookedReportQueue, RequestSubcriberChannelNames.GenerateAppointmentBookedReportChannel);
            if (!isGenerated) return "CSV File Export failed!";

            DownloadZipFile(_tempMediaLocation, fileName);

            return "CSV File Export was succesful!";
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

        public void CustomerExportAsync(string id = null, CustomerExportListModelFilter filter = null)
        {
            if (id == null) return;

            AsyncManager.OutstandingOperations.Increment();
            var dataGen = new ExportableDataGenerator<CustomerExportModel, CustomerExportListModelFilter>(_eventCustomerReportingService.GetCustomersForExport);

            var processmanager = new ExportableDataGeneratorProcessManager<CustomerExportModel, CustomerExportListModelFilter>();
            processmanager.Add(id, dataGen);

            GetNewProcessStarted(filter, dataGen, id);
        }

        public ActionResult CustomerExportCompleted(string id, CustomerExportListModel model)
        {
            if (id == null) return Content("Model can't be null.");

            if (model == null || model.Collection == null || model.Collection.Count() < 1)
                return Content("Model can't be null.");

            RemoveProcess(id);
            var exporter = ExportableDataGeneratorProcessManager<ViewModelBase, ModelFilterBase>.GetCsvExporter<CustomerExportModel>();
            var message = WriteCsvForCustomerExport("CustomerExport.csv", model.Collection);
            return Content(message);
        }

        private string WriteCsvForCustomerExport(string fileName, IEnumerable<CustomerExportModel> modelData)
        {
            var csvFilePath = _tempMediaLocation.PhysicalPath + fileName;

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
            var isGenerated = GetResponse(request, RequestSubcriberChannelNames.EventReportQueue, RequestSubcriberChannelNames.EventReportQueue);
            if (!isGenerated) return "CSV File Export failed!";

            DownloadZipFile(_tempMediaLocation, fileName);

            return "CSV File Export was succesful!";
        }

        public void RescheduleAppointmentAsync(string id = null, RescheduleApplointmentListModelFilter filter = null)
        {
            if (id == null) return;

            AsyncManager.OutstandingOperations.Increment();
            var dataGen =
                new ExportableDataGenerator<RescheduleApplointmentModel, RescheduleApplointmentListModelFilter>(
                    _eventCustomerReportingService.GetRescheduleAppointments);

            var processmanager = new ExportableDataGeneratorProcessManager<RescheduleApplointmentModel, RescheduleApplointmentListModelFilter>();
            processmanager.Add(id, dataGen);

            GetNewProcessStarted(filter, dataGen, id);
        }

        public ActionResult RescheduleAppointmentCompleted(string id, RescheduleApplointmentListModel model)
        {
            if (id == null) return Content("Model can't be null.");

            if (model == null || model.Collection == null || model.Collection.Count() < 1)
                return Content("Model can't be null.");

            RemoveProcess(id);
            var exporter = ExportableDataGeneratorProcessManager<ViewModelBase, ModelFilterBase>.GetCsvExporter<RescheduleApplointmentModel>();
            var message = WriteCsv("RescheduleAppointment.csv", exporter, model.Collection, RequestSubcriberChannelNames.RescheduleAppointmentQueue, RequestSubcriberChannelNames.RescheduleAppointmentChannel);
            return Content(message);
        }

        private string WriteCsvPublicEventVolume(string fileName, IEnumerable<EventVolumeModel> modelData)
        {

            var csvFilePath = _tempMediaLocation.PhysicalPath + "PublicEventVolume.csv";

            //using (var streamWriter = new StreamWriter(csvFilePath, false))
            //{
            var csvStringBuilder = new StringBuilder();
            var members = (typeof(EventVolumeModel)).GetMembers();

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
                if (memberInfo.Name == "CorporateAccount") continue;

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
                        if (propInfo.PropertyType == typeof(IEnumerable<string>))
                        {
                            if (model.Technicians != null && model.Technicians.Any())
                            {
                                var shippingOptions = string.Join(",", model.Technicians.ToArray());
                                values.Add(sanitizer.EscapeString(shippingOptions));
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
                    if (memberInfo.Name == "CorporateAccount") continue;

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

                csvStringBuilder.Append(string.Join(",", values.ToArray()) + Environment.NewLine);
            }
            //    streamWriter.Close();
            //}



            var request = new GenericReportRequest { CsvFilePath = csvFilePath, Model = csvStringBuilder.ToString() };
            var isGenerated = GetResponse(request, RequestSubcriberChannelNames.GeneratePublicEventVolumeReportQueue, RequestSubcriberChannelNames.GeneratePublicEventVolumeReportChannel);
            if (!isGenerated) return "CSV File Export failed!";

            DownloadZipFile(_tempMediaLocation, fileName);

            return "CSV File Export was succesful!";
        }

        private string WriteCsvCorporateEventVolume(string fileName, IEnumerable<EventVolumeModel> modelData)
        {
            var csvFilePath = _tempMediaLocation.PhysicalPath + "CorporateEventVolume.csv";

            //using (var streamWriter = new StreamWriter(csvFilePath, false))
            //{
            var csvStringBuilder = new StringBuilder();
            var members = (typeof(EventVolumeModel)).GetMembers();

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
                        if (propInfo.PropertyType == typeof(IEnumerable<string>))
                        {
                            if (model.Technicians != null && model.Technicians.Any())
                            {
                                var shippingOptions = string.Join(",", model.Technicians.ToArray());
                                values.Add(sanitizer.EscapeString(shippingOptions));
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

                csvStringBuilder.Append(string.Join(",", values.ToArray()) + Environment.NewLine);
            }
            //    streamWriter.Close();
            //}



            var request = new GenericReportRequest { CsvFilePath = csvFilePath, Model = csvStringBuilder.ToString() };
            var isGenerated = GetResponse(request, RequestSubcriberChannelNames.GenerateCorporateEventVolumeReportQueue, RequestSubcriberChannelNames.GenerateCorporateEventVolumeReportChannel);
            if (!isGenerated) return "CSV File Export failed!";

            DownloadZipFile(_tempMediaLocation, fileName);

            return "CSV File Export was succesful!";
        }

        public void EventCancelationAsync(string id = null, EventCancellationModelFilter filter = null)
        {
            if (id == null) return;

            AsyncManager.OutstandingOperations.Increment();
            var dataGen =
                new ExportableDataGenerator<EventCancellationModel, EventCancellationModelFilter>(
                    _eventReportingService.GetCancelledEventsList);

            var processmanager = new ExportableDataGeneratorProcessManager<EventCancellationModel, EventCancellationModelFilter>();
            processmanager.Add(id, dataGen);

            GetNewProcessStarted(filter, dataGen, id);
        }

        public ActionResult EventCancelationCompleted(string id, EventCancellationListModel model)
        {
            if (id == null) return Content("Model can't be null.");

            if (model == null || model.Collection == null || model.Collection.Count() < 1)
                return Content("Model can't be null.");

            RemoveProcess(id);
            var exporter = ExportableDataGeneratorProcessManager<ViewModelBase, ModelFilterBase>.GetCsvExporter<EventCancellationModel>();
            var message = WriteCsv("EventCancelation.csv", exporter, model.Collection, RequestSubcriberChannelNames.EventCancelationQueue, RequestSubcriberChannelNames.EventCancelationChannel);
            return Content(message);
        }

        public void TestsBookedAsync(string id = null, TestsBookedListModelFilter filter = null)
        {
            if (id == null) return;

            AsyncManager.OutstandingOperations.Increment();
            var dataGen =
                new ExportableDataGenerator<TestsBookedModel, TestsBookedListModelFilter>(
                    _eventCustomerReportingService.GetTestsBooked);

            var processmanager = new ExportableDataGeneratorProcessManager<TestsBookedModel, TestsBookedListModelFilter>();
            processmanager.Add(id, dataGen);

            GetNewProcessStarted(filter, dataGen, id);
        }

        public ActionResult TestsBookedCompleted(string id, TestsBookedListModel model)
        {
            if (id == null) return Content("Model can't be null.");

            if (model == null || model.Collection == null || model.Collection.Count() < 1)
                return Content("Model can't be null.");

            RemoveProcess(id);
            var exporter = ExportableDataGeneratorProcessManager<ViewModelBase, ModelFilterBase>.GetCsvExporter<TestsBookedModel>();
            var message = WriteCsv("TestBooked.csv", exporter, model.Collection, RequestSubcriberChannelNames.TestBookedQueue, RequestSubcriberChannelNames.TestBookedChannel);
            return Content(message);
        }

        public void PcpAppointmentDispositionAsync(string id = null, PcpAppointmentListModelFilter filter = null)
        {
            if (id == null) return;

            AsyncManager.OutstandingOperations.Increment();
            var dataGen = new ExportableDataGenerator<PcpAppointmentViewModel, PcpAppointmentListModelFilter>(_eventCustomerReportingService.GetPcpAppointment);

            var processmanager = new ExportableDataGeneratorProcessManager<PcpAppointmentViewModel, PcpAppointmentListModelFilter>();
            processmanager.Add(id, dataGen);

            GetNewProcessStarted(filter, dataGen, id);
        }

        public ActionResult PcpAppointmentDispositionCompleted(string id, PcpAppointmentListModel model)
        {
            if (id == null) return Content("Model can't be null.");

            if (model == null || model.Collection == null || model.Collection.Count() < 1)
                return Content("Model can't be null.");

            RemoveProcess(id);
            var exporter = ExportableDataGeneratorProcessManager<ViewModelBase, ModelFilterBase>.GetCsvExporter<PcpAppointmentViewModel>();
            var message = WriteCsv("PCPAppointmentDisposition.csv", exporter, model.Collection, RequestSubcriberChannelNames.PcpAppointmentDispositionQueue, RequestSubcriberChannelNames.PcpAppointmentDispositionChannel);
            return Content(message);
        }

        public void ClientEventVolumeAsync(string id = null, ClientEventVolumeListModelFilter filter = null, bool showThisYear = false)
        {
            if (id == null) return;

            if (showThisYear)
            {
                if (filter == null)
                    filter = new ClientEventVolumeListModelFilter();
                filter.FromDate = Convert.ToDateTime("01/01/" + DateTime.Today.Year);
            }

            AsyncManager.OutstandingOperations.Increment();
            var dataGen = new ExportableDataGenerator<ClientEventVolumeModel, ClientEventVolumeListModelFilter>(_eventReportingService.GetEventVolumeForHealthPlanPatients);

            var processmanager = new ExportableDataGeneratorProcessManager<ClientEventVolumeModel, ClientEventVolumeListModelFilter>();
            processmanager.Add(id, dataGen);

            GetNewProcessStarted(filter, dataGen, id);
        }

        public ActionResult ClientEventVolumeCompleted(string id, ClientEventVolumeListModel model, bool showThisYear = false)
        {
            if (id == null) return Content("Model can't be null.");

            if (model == null || model.Collection == null || model.Collection.Count() < 1)
                return Content("Model can't be null.");

            RemoveProcess(id);
            var message = WriteCsvClientEventVolume("HealthPlanEventVolume.csv", model.Collection);
            return Content(message);
        }

        public void MemberStatusReportAsync(string id = null, MemberStatusListModelFilter filter = null)
        {
            if (id == null) return;

            AsyncManager.OutstandingOperations.Increment();
            var dataGen = new ExportableDataGenerator<MemberStatusModel, MemberStatusListModelFilter>(_eventCustomerReportingService.GetMemberStatusReport);

            var processmanager = new ExportableDataGeneratorProcessManager<MemberStatusModel, MemberStatusListModelFilter>();
            processmanager.Add(id, dataGen);

            GetNewProcessStarted(filter, dataGen, id);
        }

        public ActionResult MemberStatusReportCompleted(string id, MemberStatusListModel model)
        {
            if (id == null) return Content("Model can't be null.");

            if (model == null || model.Collection == null || model.Collection.Count() < 1)
                return Content("Model can't be null.");

            RemoveProcess(id);
            var message = WriteCsvMemberStatus("HealthPlanMemberStatusReport.csv", model.Collection);
            return Content(message);
        }

        public void HealthPlanMemberStatusReportAsync(string id = null, MemberStatusListModelFilter filter = null)
        {
            if (id == null) return;

            if (filter == null) filter = new MemberStatusListModelFilter();
            filter.HealthPlanId = _sessionContext.UserSession.CurrentOrganizationRole.OrganizationId;

            AsyncManager.OutstandingOperations.Increment();
            var dataGen = new ExportableDataGenerator<MemberStatusModel, MemberStatusListModelFilter>(_eventCustomerReportingService.GetMemberStatusReport);

            var processmanager = new ExportableDataGeneratorProcessManager<MemberStatusModel, MemberStatusListModelFilter>();
            processmanager.Add(id, dataGen);

            GetNewProcessStarted(filter, dataGen, id);
        }

        public ActionResult HealthPlanMemberStatusReportCompleted(string id, MemberStatusListModel model)
        {
            if (id == null) return Content("Model can't be null.");

            if (model == null || model.Collection == null || !model.Collection.Any())
                return Content("Model can't be null.");

            RemoveProcess(id);
            var message = WriteCsvMemberStatus("HealthPlanMemberStatusReport.csv", model.Collection);
            return Content(message);
        }

        private string WriteCsvClientEventVolume(string fileName, IEnumerable<ClientEventVolumeModel> modelData)
        {
            var csvFilePath = _tempMediaLocation.PhysicalPath + "HealthPlanEventVolume.csv";

            var csvStringBuilder = new StringBuilder();
            var members = (typeof(ClientEventVolumeModel)).GetMembers();

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
                        if (propInfo.PropertyType == typeof(IEnumerable<string>))
                        {
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

                csvStringBuilder.Append(string.Join(",", values.ToArray()) + Environment.NewLine);
            }

            var request = new GenericReportRequest { CsvFilePath = csvFilePath, Model = csvStringBuilder.ToString() };
            var isGenerated = GetResponse(request, RequestSubcriberChannelNames.GenerateClientEventVolumeReportQueue, RequestSubcriberChannelNames.GenerateClientEventVolumeReportChannel);
            if (!isGenerated) return "CSV File Export failed!";

            DownloadZipFile(_tempMediaLocation, fileName);

            return "CSV File Export was succesful!";
        }


        public void DailyVolumeAsync(string id = null, DailyVolumeListModelFilter filter = null)
        {
            if (id == null) return;

            AsyncManager.OutstandingOperations.Increment();

            var dataGen = new ExportableDataGenerator<DailyVolumeModel, DailyVolumeListModelFilter>(_eventReportingService.GetDailyVolumeReport);

            var processmanager = new ExportableDataGeneratorProcessManager<DailyVolumeModel, DailyVolumeListModelFilter>();
            processmanager.Add(id, dataGen);

            GetNewProcessStarted(filter, dataGen, id);
        }

        public ActionResult DailyVolumeCompleted(string id, DailyVolumeListModel model)
        {
            if (id == null) return Content("Model can't be null.");

            if (model == null || model.Collection == null || model.Collection.Count() < 1)
                return Content("Model can't be null.");

            RemoveProcess(id);
            var exporter = ExportableDataGeneratorProcessManager<ViewModelBase, ModelFilterBase>.GetCsvExporter<DailyVolumeModel>();
            var message = WriteCsv("DailyVolumeReport.csv", exporter, model.Collection, RequestSubcriberChannelNames.DailyVolumeReportQueue, RequestSubcriberChannelNames.DailyVolumeReportChannel);

            return Content(message);
        }

        public void CustomerLeftWithoutScreeningAsync(string id = null, CustomerLeftWithoutScreeningModelFilter filter = null)
        {
            if (id == null) return;

            AsyncManager.OutstandingOperations.Increment();
            var dataGen =
                new ExportableDataGenerator<CustomerLeftWithoutScreeningModel, CustomerLeftWithoutScreeningModelFilter>(
                    _eventCustomerReportingService.GetCustomerLeftWithoutScreening);

            var processmanager = new ExportableDataGeneratorProcessManager<CustomerLeftWithoutScreeningModel, CustomerLeftWithoutScreeningModelFilter>();
            processmanager.Add(id, dataGen);

            GetNewProcessStarted(filter, dataGen, id);
        }

        public ActionResult CustomerLeftWithoutScreeningCompleted(string id, CustomerLeftWithoutScreeningListModel model)
        {
            if (id == null) return Content("Model can't be null.");

            if (model == null || model.Collection == null || model.Collection.Count() < 1)
                return Content("Model can't be null.");

            RemoveProcess(id);
            var exporter = ExportableDataGeneratorProcessManager<ViewModelBase, ModelFilterBase>.GetCsvExporter<CustomerLeftWithoutScreeningModel>();
            var message = WriteCsv("CustomerLeftWithoutScreening_" + id + ".csv", exporter, model.Collection, RequestSubcriberChannelNames.CustomerLeftWithoutScreeningQueue, RequestSubcriberChannelNames.CustomerLeftWithoutScreeningChannel);
            return Content(message);
        }

        public void VoiceMailReminderAsync(string id = null, VoiceMailReminderModelFilter filter = null)
        {
            if (id == null) return;

            AsyncManager.OutstandingOperations.Increment();
            var dataGen =
                new ExportableDataGenerator<VoiceMailReminderModel, VoiceMailReminderModelFilter>(
                    _eventCustomerReportingService.GetVoiceMailReminderReport);

            var processmanager = new ExportableDataGeneratorProcessManager<VoiceMailReminderModel, VoiceMailReminderModelFilter>();
            processmanager.Add(id, dataGen);

            GetNewProcessStarted(filter, dataGen, id);
        }

        public ActionResult VoiceMailReminderCompleted(string id, VoiceMailReminderListModel model)
        {
            if (id == null) return Content("Model can't be null.");

            if (model == null || model.Collection == null || model.Collection.Count() < 1)
                return Content("Model can't be null.");

            RemoveProcess(id);
            var exporter = ExportableDataGeneratorProcessManager<ViewModelBase, ModelFilterBase>.GetCsvExporter<VoiceMailReminderModel>();
            var message = WriteCsv("VoiceMailReminder.csv", exporter, model.Collection, RequestSubcriberChannelNames.VoiceMailReminderQueue, RequestSubcriberChannelNames.VoiceMailReminderChannel);
            return Content(message);
        }


        public void TextReminderAsync(string id = null, TextReminderModelFilter filter = null)
        {
            if (id == null) return;

            AsyncManager.OutstandingOperations.Increment();
            var dataGen =
                new ExportableDataGenerator<TextReminderViewModel, TextReminderModelFilter>(
                    _eventCustomerReportingService.GetTextReminderReport);

            var processmanager = new ExportableDataGeneratorProcessManager<TextReminderViewModel, TextReminderModelFilter>();
            processmanager.Add(id, dataGen);

            GetNewProcessStarted(filter, dataGen, id);
        }

        public ActionResult TextReminderCompleted(string id, TextReminderListModel model)
        {
            if (id == null) return Content("Model can't be null.");

            if (model == null || model.Collection == null || model.Collection.Count() < 1)
                return Content("Model can't be null.");

            RemoveProcess(id);
            var exporter = ExportableDataGeneratorProcessManager<ViewModelBase, ModelFilterBase>.GetCsvExporter<TextReminderViewModel>();
            var message = WriteCsv("SMSReminder.csv", exporter, model.Collection, RequestSubcriberChannelNames.TextReminderQueue, RequestSubcriberChannelNames.TextReminderChannel);
            return Content(message);
        }

        private string WriteCsvMemberStatus(string fileName, IEnumerable<MemberStatusModel> modelData)
        {
            var csvFilePath = _tempMediaLocation.PhysicalPath + fileName;

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
            var isGenerated = GetResponse(request, RequestSubcriberChannelNames.MemberStatusReportQueue, RequestSubcriberChannelNames.MemberStatusReportChannel);
            if (!isGenerated) return "CSV File Export failed!";

            DownloadZipFile(_tempMediaLocation, fileName);

            return "CSV File Export was succesful!";
        }

        public void HealthPlanEventsAsync(string id, bool showUpcoming = false, EventBasicInfoViewModelFilter filter = null)
        {
            if (id == null) return;

            if (filter == null) filter = new EventBasicInfoViewModelFilter();
            filter.AccountId = _sessionContext.UserSession.CurrentOrganizationRole.OrganizationId;
            if (showUpcoming)
            {
                filter.DateFrom = DateTime.Now.Date;
                filter.DateTo = null;
            }

            AsyncManager.OutstandingOperations.Increment();
            var dataGen = new ExportableDataGenerator<HealthPlanEventViewModel, EventBasicInfoViewModelFilter>(_eventService.GetHealthPlanEvents);

            var processmanager = new ExportableDataGeneratorProcessManager<HealthPlanEventViewModel, EventBasicInfoViewModelFilter>();
            processmanager.Add(id, dataGen);

            GetNewProcessStarted(filter, dataGen, id);
        }

        public ActionResult HealthPlanEventsCompleted(string id, HealthPlanEventListModel model)
        {
            if (id == null) return Content("Model can't be null.");

            if (model == null || model.Collection == null || !model.Collection.Any())
                return Content("Model can't be null.");

            RemoveProcess(id);
            var message = WriteCsvHealthPlanMemberStatus("HealthPlanEvents.csv", model.Collection);
            return Content(message);
        }

        private string WriteCsvHealthPlanMemberStatus(string fileName, IEnumerable<HealthPlanEventViewModel> modelData)
        {
            var csvFilePath = _tempMediaLocation.PhysicalPath + fileName;

            var csvStringBuilder = new StringBuilder();
            var members = (typeof(HealthPlanEventViewModel)).GetMembers();

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

                        if (propInfo.PropertyType == typeof(IEnumerable<OrderedPair<long, string>>))
                        {
                            values.Add(sanitizer.EscapeString(model.PodNames()));
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
            var isGenerated = GetResponse(request, RequestSubcriberChannelNames.EventReportQueue, RequestSubcriberChannelNames.EventReportQueue);
            if (!isGenerated) return "CSV File Export failed!";

            DownloadZipFile(_tempMediaLocation, fileName);

            return "CSV File Export was succesful!";
        }

        public void CorporateEventCustomerListAsync(string id = null, long eventId = 0)
        {
            if (id == null) return;
            var filter = new CorporateEventCustomerModelFilter();
            filter.EventId = eventId;
            AsyncManager.OutstandingOperations.Increment();
            var dataGen =
                new ExportableDataGenerator<CorporateEventCustomersModel, CorporateEventCustomerModelFilter>(
                    _eventCustomerReportingService.GetEventCustomerListModel);

            var processmanager = new ExportableDataGeneratorProcessManager<CorporateEventCustomersModel, CorporateEventCustomerModelFilter>();
            processmanager.Add(id, dataGen);

            GetNewProcessStarted(filter, dataGen, id);
        }

        public ActionResult CorporateEventCustomerListCompleted(string id, CorporateEventCustomerListModel model)
        {
            if (id == null) return Content("Model can't be null.");

            if (model == null || model.Collection == null || model.Collection.Count() < 1)
                return Content("Model can't be null.");

            RemoveProcess(id);
            var exporter = ExportableDataGeneratorProcessManager<ViewModelBase, ModelFilterBase>.GetCsvExporter<CorporateEventCustomersModel>();
            var message = WriteCsv("CorporateEventCustomers" + (model.Filter.EventId > 0 ? "_" + model.Filter.EventId : "") + ".csv", exporter, model.Collection, RequestSubcriberChannelNames.CorporateEventCustomersQueue, RequestSubcriberChannelNames.CorporateEventCustomersChannel);
            return Content(message);
        }

        public void PcpTrackingReportAsync(string id = null, PcpTrackingReportFilter filter = null)
        {
            if (id == null) return;
            filter = filter ?? new PcpTrackingReportFilter();

            AsyncManager.OutstandingOperations.Increment();
            var dataGen = new ExportableDataGenerator<PcpTrackingReportViewModel, PcpTrackingReportFilter>(
                    _pcpTrackingReportService.GetPcpTrackingReport);

            var processmanager = new ExportableDataGeneratorProcessManager<PcpTrackingReportViewModel, PcpTrackingReportFilter>();
            processmanager.Add(id, dataGen);

            GetNewProcessStarted(filter, dataGen, id);
        }

        public ActionResult PcpTrackingReportCompleted(string id, PcpTrackingReportListModel model)
        {
            if (id == null) return Content("Model can't be null.");

            if (model == null || model.Collection == null || model.Collection.Count() < 1)
                return Content("Model can't be null.");

            RemoveProcess(id);
            var exporter = ExportableDataGeneratorProcessManager<ViewModelBase, ModelFilterBase>.GetCsvExporter<PcpTrackingReportViewModel>();
            var message = WriteCsv("PcpTrackingReport _" + id + ".csv", exporter, model.Collection, RequestSubcriberChannelNames.PcpTrackingReportQueue, RequestSubcriberChannelNames.PcpTrackingReportChannel);
            return Content(message);
        }
    }
}
