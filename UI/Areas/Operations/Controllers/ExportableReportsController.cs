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
using Falcon.App.Core.Finance.ViewModels;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Operations.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.ValueTypes;
using Falcon.App.UI.Controllers;
using Falcon.App.UI.Filters;

namespace Falcon.App.UI.Areas.Operations.Controllers
{
    [RoleBasedAuthorize]
    [AsyncTimeout(450000)]
    public class ExportableReportsController : BaseReportsController
    {
        private readonly IOperationsReportingService _operationsReportingService;
        private readonly IStaffEventScheduleExportService _staffEventScheduleExportService;
        private readonly MediaLocation _tempMediaLocation;
        private readonly ISessionContext _sessionContext;

        public ExportableReportsController(IOperationsReportingService operationsReportingService, IMediaRepository mediaRepository, IZipHelper zipHelper,
            ILogManager logManager, ISessionContext sessionContext, ILoginSettingRepository loginSettingRepository, IRoleRepository roleRepository, IOrganizationRoleUserRepository organizationRoleUserRepository,
            IUserRepository<User> userRepository, ISettings settings, IStaffEventScheduleExportService staffEventScheduleExportService)
            : base(zipHelper, logManager, sessionContext, loginSettingRepository, roleRepository, organizationRoleUserRepository, userRepository, settings)
        {
            _operationsReportingService = operationsReportingService;
            _staffEventScheduleExportService = staffEventScheduleExportService;
            _tempMediaLocation = mediaRepository.GetTempMediaFileLocation();
            _sessionContext = sessionContext;
        }

        public void CdImageStatusAsync(string id = null, CdImageStatusModelFilter filter = null)
        {
            if (id == null) return;

            AsyncManager.OutstandingOperations.Increment();
            var dataGen =
                new ExportableDataGenerator<CdImageStatusModel, CdImageStatusModelFilter>(
                    _operationsReportingService.GetCdImageStatusmodel);

            var processmanager = new ExportableDataGeneratorProcessManager<CdImageStatusModel, CdImageStatusModelFilter>();
            processmanager.Add(id, dataGen);

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

        public ActionResult CdImageStatusCompleted(string id, CdImageStatusListModel model)
        {
            if (id == null) return Content("Model can't be null.");

            if (model == null || model.Collection == null || model.Collection.Count() < 1)
                return Content("Model can't be null.");

            RemoveProcess(id);
            var exporter = ExportableDataGeneratorProcessManager<ViewModelBase, ModelFilterBase>.GetCsvExporter<CdImageStatusModel>();
            var message = WriteCsv("CdImageStatus.csv", exporter, model.Collection, RequestSubcriberChannelNames.CdImageStatusQueue, RequestSubcriberChannelNames.CdImageStatusChannel);
            return Content(message);
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

        public ContentResult GetStatus(string id)
        {
            var processmanager = new ExportableDataGeneratorProcessManager<DetailOpenOrdersModel, DetailOpenOrderModelFilter>();
            return Content(processmanager.GetStatus(id).ToString());
        }

        public void RemoveProcess(string id)
        {
            var processmanager = new ExportableDataGeneratorProcessManager<DetailOpenOrdersModel, DetailOpenOrderModelFilter>();
            processmanager.Remove(id);
        }

        public void StaffEventScheduleAsync(string id = null, EventStaffAssignmentListModelFilter filter = null)
        {
            if (id == null) return;
            AsyncManager.OutstandingOperations.Increment();
            filter.UserSessionModel = _sessionContext.UserSession;              //used to make filter

            var dataGen = new ExportableDataGenerator<StaffEventSchedulingModel, EventStaffAssignmentListModelFilter>(_staffEventScheduleExportService.GetStaffScheduleForCsvExport);
            var processmanager = new ExportableDataGeneratorProcessManager<StaffEventSchedulingModel, EventStaffAssignmentListModelFilter>();
            processmanager.Add(id, dataGen);

            GetNewProcessStarted(filter, dataGen, id);
        }

        public ActionResult StaffEventScheduleCompleted(string id, StaffEventSchedulingListModel model)
        {
            if (id == null) return Content("Model can't be null.");

            if (model == null || model.Collection == null || !model.Collection.Any())
                return Content("Model can't be null.");

            RemoveProcess(id);
            var exporter = ExportableDataGeneratorProcessManager<ViewModelBase, ModelFilterBase>.GetCsvExporter<StaffEventSchedulingModel>();
            var message = WriteCsv("StaffEventSchedule.csv", exporter, model.Collection, RequestSubcriberChannelNames.StaffEventAssignmentExportQueue, RequestSubcriberChannelNames.StaffEventAssignmentExportChannel);

            return Content(message);
        }

    }
}
