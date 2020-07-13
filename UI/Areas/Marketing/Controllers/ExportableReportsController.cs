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
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Marketing.Interfaces;
using Falcon.App.Core.Marketing.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.ValueTypes;
using Falcon.App.UI.Controllers;
using Falcon.App.UI.Filters;

namespace Falcon.App.UI.Areas.Marketing.Controllers
{
    [RoleBasedAuthorize]
    [AsyncTimeout(450000)]
    public class ExportableReportsController : BaseReportsController
    {
        //
        // GET: /Marketing/ExportableReports/
        private readonly IProspectCustomerService _prospectCustomerService;
        private readonly MediaLocation _tempMediaLocation;


        public ExportableReportsController(IProspectCustomerService prospectCustomerService, IMediaRepository mediaRepository, IZipHelper zipHelper,
            ILogManager logManager, ISessionContext sessionContext, ILoginSettingRepository loginSettingRepository, IRoleRepository roleRepository, IOrganizationRoleUserRepository organizationRoleUserRepository,
            IUserRepository<User> userRepository, ISettings settings)
            : base(zipHelper, logManager, sessionContext, loginSettingRepository, roleRepository, organizationRoleUserRepository, userRepository, settings)
        {
            _prospectCustomerService = prospectCustomerService;
            _tempMediaLocation = mediaRepository.GetTempMediaFileLocation();
        }

        public void ProspectCustomerAbandonedReportAsync(string id = null, ProspectCustomerListModelFilter filter = null)
        {
            if (id == null) return;

            AsyncManager.OutstandingOperations.Increment();
            var dataGen =
                new ExportableDataGenerator<ProspectCustomerBasicInfoModel, ProspectCustomerListModelFilter>(
                    _prospectCustomerService.GetAbandonedCustomers);

            var processmanager = new ExportableDataGeneratorProcessManager<ProspectCustomerBasicInfoModel, ProspectCustomerListModelFilter>();
            processmanager.Add(id, dataGen);

            GetNewProcessStarted(filter, dataGen, id);
        }

        public ActionResult ProspectCustomerAbandonedReportCompleted(string id, ProspectCustomerListModel model)
        {
            if (id == null) return Content("Model can't be null.");

            if (model == null || model.Collection == null || model.Collection.Count() < 1)
                return Content("Model can't be null.");

            RemoveProcess(id);
            //var exporter = ExportableDataGeneratorProcessManager<ViewModelBase, ModelFilterBase>.GetCsvExporter<ProspectCustomerBasicInfoModel>();
            var message = WriteCsvProspectCustomer("AbandonedProspectCustomer.csv", model.Collection);
            return Content(message);
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

        //    DownloadZipFile(_tempMediaLocation,fileName);

        //    return "CSV File Export was succesful!";
        //}

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


        private string WriteCsvProspectCustomer(string fileName, IEnumerable<ProspectCustomerBasicInfoModel> modelData)
        {
            var csvFilePath = _tempMediaLocation.PhysicalPath + fileName;


            //using (var streamWriter = new StreamWriter(csvFilePath, false))
            //{
            var csvStringBuilder = new StringBuilder();
            var members = (typeof(ProspectCustomerBasicInfoModel)).GetMembers();

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
                        if (string.IsNullOrEmpty(notesViewModel.CreatedByUser))
                            notesString += "Notes: " + notesViewModel.Note + "\n\n";
                        else
                        {
                            notesString += "Updated On: " + (notesViewModel.EnteredOn.HasValue ? notesViewModel.EnteredOn.Value.ToShortDateString() : string.Empty) + "\n";
                            notesString += "Updated By: " + notesViewModel.CreatedByUser + "\n";
                            notesString += "Notes: " + notesViewModel.Note + "\n\n";
                        }
                    }
                    values.Add(sanitizer.EscapeString(notesString));
                }
                else
                    values.Add(string.Empty);

                csvStringBuilder.Append(string.Join(",", values.ToArray()) + Environment.NewLine);

            }

            //    streamWriter.Close();
            //}


            var request = new GenericReportRequest() { CsvFilePath = csvFilePath, Model = csvStringBuilder.ToString() };
            var isGenerated = GetResponse(request, RequestSubcriberChannelNames.GenerateAbandonedProspectCustomerReportQueue, RequestSubcriberChannelNames.GenerateAbandonedProspectCustomerReportChannel);
            if (!isGenerated) return "CSV File Export failed!";

            DownloadZipFile(_tempMediaLocation, fileName);

            return "CSV File Export was succesful!";
        }

    }
}
