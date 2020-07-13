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
using Falcon.App.Core.Application.Enum;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Finance;
using Falcon.App.Core.Finance.Impl;
using Falcon.App.Core.Finance.ViewModels;
using Falcon.App.Core.Insurance.ViewModels;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.ValueTypes;
using Falcon.App.UI.Controllers;
using Falcon.App.UI.Filters;

namespace Falcon.App.UI.Areas.Finance.Controllers
{
    [RoleBasedAuthorize]
    [AsyncTimeout(450000)]
    public class ExportableReportsController : BaseReportsController
    {
        private readonly IEventReportingService _eventReportingService;
        private readonly IFinanceReportingService _financeReportingService;
        private readonly IRefundRequestService _refundRequestService;
        private readonly IDailyPatientRecapReportingService _dailyPatientRecapReportingService;
        private readonly ICallCenterBounsReportingService _callCenterBounsReportingService;
        private readonly MediaLocation _tempMediaLocation;


        public ExportableReportsController(IEventReportingService eventReportingService, IFinanceReportingService financeReportingService, IRefundRequestService refundRequestService,
            IDailyPatientRecapReportingService dailyPatientRecapReportingService, IMediaRepository mediaRepository, IZipHelper zipHelper,
            ILogManager logManager, ISessionContext sessionContext, ILoginSettingRepository loginSettingRepository, IRoleRepository roleRepository, IOrganizationRoleUserRepository organizationRoleUserRepository,
            IUserRepository<User> userRepository, ISettings settings, ICallCenterBounsReportingService callCenterBounsReportingService)
            : base(zipHelper, logManager, sessionContext, loginSettingRepository, roleRepository, organizationRoleUserRepository, userRepository, settings)
        {
            _eventReportingService = eventReportingService;
            _financeReportingService = financeReportingService;
            _refundRequestService = refundRequestService;
            _dailyPatientRecapReportingService = dailyPatientRecapReportingService;
            _callCenterBounsReportingService = callCenterBounsReportingService;
            _tempMediaLocation = mediaRepository.GetTempMediaFileLocation();
        }

        public void ExportableDetailOpenOrderAsync(string id = null, DetailOpenOrderModelFilter filter = null)
        {
            if (id == null) return;

            AsyncManager.OutstandingOperations.Increment();
            var dataGen =
                new ExportableDataGenerator<DetailOpenOrdersModel, DetailOpenOrderModelFilter>(
                    _eventReportingService.GetDetailOpenOrderModel);

            var processmanager = new ExportableDataGeneratorProcessManager<DetailOpenOrdersModel, DetailOpenOrderModelFilter>();
            processmanager.Add(id, dataGen);
            GetNewProcessStarted(filter, dataGen, id);
        }

        public ActionResult ExportableDetailOpenOrderCompleted(string id, DetailOpenOrderListModel model)
        {
            if (id == null) return Content("Model can't be null.");

            if (model == null || model.Collection == null || model.Collection.Count() < 1)
                return Content("Model can't be null.");

            RemoveProcess(id);
            var exporter = ExportableDataGeneratorProcessManager<ViewModelBase, ModelFilterBase>.GetCsvExporter<DetailOpenOrdersModel>();
            var message = WriteCsv("DetailOpenOrder.csv", exporter, model.Collection, RequestSubcriberChannelNames.DetailOpenOrderQueue, RequestSubcriberChannelNames.DetailOpenOrderChannel);
            return Content(message);
        }

        public void UpsellAsync(string id = null, CustomerUpsellListModelFilter filter = null)
        {
            if (id == null) return;

            AsyncManager.OutstandingOperations.Increment();
            var dataGen =
                new ExportableDataGenerator<CustomerUpsellModel, CustomerUpsellListModelFilter>(
                    _financeReportingService.GetCustomerUpsellModel);

            var processmanager = new ExportableDataGeneratorProcessManager<CustomerUpsellModel, CustomerUpsellListModelFilter>();
            processmanager.Add(id, dataGen);
            GetNewProcessStarted(filter, dataGen, id);
        }

        public ActionResult UpsellCompleted(string id, CustomerUpsellListModel model)
        {
            if (id == null) return Content("Model can't be null.");

            if (model == null || model.Collection == null || model.Collection.Count() < 1)
                return Content("Model can't be null.");

            RemoveProcess(id);
            var exporter = ExportableDataGeneratorProcessManager<ViewModelBase, ModelFilterBase>.GetCsvExporter<CustomerUpsellModel>();
            var message = WriteCsv("Upsell.csv", exporter, model.Collection, RequestSubcriberChannelNames.UpsellQueue, RequestSubcriberChannelNames.UpsellChannel);
            return View(message);
        }


        public void ExportableCreditCardReconcilationAsync(string id = null, CreditCardReconcileModelFilter filter = null)
        {
            if (id == null) return;

            AsyncManager.OutstandingOperations.Increment();
            var dataGen =
                new ExportableDataGenerator<CreditCardReconcileModel, CreditCardReconcileModelFilter>(
                    _financeReportingService.GetCreditCardReconcileList);

            var processmanager = new ExportableDataGeneratorProcessManager<CreditCardReconcileModel, CreditCardReconcileModelFilter>();
            processmanager.Add(id, dataGen);
            GetNewProcessStarted(filter, dataGen, id);
        }

        public ActionResult ExportableCreditCardReconcilationCompleted(string id, CreditCardReconcileListModel model)
        {
            if (id == null) return Content("Model can't be null.");

            if (model == null || model.Collection == null || model.Collection.Count() < 1)
                return Content("Model can't be null.");

            RemoveProcess(id);
            var exporter = ExportableDataGeneratorProcessManager<ViewModelBase, ModelFilterBase>.GetCsvExporter<CreditCardReconcileModel>();
            var message = WriteCsv("CreditCardReconsile.csv", exporter, model.Collection, RequestSubcriberChannelNames.CreditCardReconsileQueue, RequestSubcriberChannelNames.CreditCardReconsileChannel);
            return Content(message);
        }

        public void ExportableDailyRecapAsync(string id = null, DailyRecapModelFilter filter = null)
        {
            if (id == null) return;

            AsyncManager.OutstandingOperations.Increment();
            var dataGen =
                new ExportableDataGenerator<DailyRecapModel, DailyRecapModelFilter>(
                    _eventReportingService.GetDailyRecapModel);

            var processmanager = new ExportableDataGeneratorProcessManager<DailyRecapModel, DailyRecapModelFilter>();
            processmanager.Add(id, dataGen);
            GetNewProcessStarted(filter, dataGen, id);
        }

        public ActionResult ExportableDailyRecapCompleted(string id, DailyRecapListModel model)
        {
            if (id == null) return Content("Model can't be null.");

            if (model == null || model.Collection == null || model.Collection.Count() < 1)
                return Content("Model can't be null.");

            RemoveProcess(id);
            var exporter = ExportableDataGeneratorProcessManager<ViewModelBase, ModelFilterBase>.GetCsvExporter<DailyRecapModel>();
            var message = WriteCsv("DailyRecap.csv", exporter, model.Collection, RequestSubcriberChannelNames.DailyRecapQueue, RequestSubcriberChannelNames.DailyRecapChannel);
            return Content(message);
        }

        public void DeferredRevenueAsync(string id = null, DeferredRevenueListModelFilter filter = null)
        {
            if (id == null) return;

            AsyncManager.OutstandingOperations.Increment();
            var dataGen =
                new ExportableDataGenerator<DeferredRevenueViewModel, DeferredRevenueListModelFilter>(
                    _financeReportingService.GetDeferredRevenue);

            var processmanager = new ExportableDataGeneratorProcessManager<DeferredRevenueViewModel, DeferredRevenueListModelFilter>();
            processmanager.Add(id, dataGen);

            GetNewProcessStarted(filter, dataGen, id);
        }

        public ActionResult DeferredRevenueCompleted(string id, DeferredRevenueListModel model)
        {
            if (id == null) return Content("Model can't be null.");

            if (model == null || model.Collection == null || model.Collection.Count() < 1)
                return Content("Model can't be null.");

            RemoveProcess(id);
            var message = WriteCsvDeferredRevenue("DeferredRevenue.csv", model.Collection);
            return Content(message);
        }

        public void ShippingRevenueSummaryAsync(string id = null, ShippingRevenueListModelFilter filter = null)
        {
            if (id == null) return;

            AsyncManager.OutstandingOperations.Increment();
            var dataGen =
                new ExportableDataGenerator<ShippingRevenueSummaryViewModel, ShippingRevenueListModelFilter>(
                    _financeReportingService.GetShippingRevenueSummary);

            var processmanager = new ExportableDataGeneratorProcessManager<ShippingRevenueSummaryViewModel, ShippingRevenueListModelFilter>();
            processmanager.Add(id, dataGen);
            GetNewProcessStarted(filter, dataGen, id);
        }

        public ActionResult ShippingRevenueSummaryCompleted(string id, ShippingRevenueSummaryListModel model)
        {
            if (id == null) return Content("Model can't be null.");

            if (model == null || model.Collection == null || model.Collection.Count() < 1)
                return Content("Model can't be null.");

            RemoveProcess(id);
            var exporter = ExportableDataGeneratorProcessManager<ViewModelBase, ModelFilterBase>.GetCsvExporter<ShippingRevenueSummaryViewModel>();
            var message = WriteCsv("ShippingRevenueSummary.csv", exporter, model.Collection, RequestSubcriberChannelNames.ShippingRevenueSummaryQueue, RequestSubcriberChannelNames.ShippingRevenueSummaryChannel);
            return View(message);
        }

        public void ShippingRevenueDetailAsync(string id = null, ShippingRevenueListModelFilter filter = null)
        {
            if (id == null) return;

            AsyncManager.OutstandingOperations.Increment();
            var dataGen =
                new ExportableDataGenerator<ShippingRevenueDetailViewModel, ShippingRevenueListModelFilter>(
                    _financeReportingService.GetShippingRevenueDetail);

            var processmanager = new ExportableDataGeneratorProcessManager<ShippingRevenueDetailViewModel, ShippingRevenueListModelFilter>();
            processmanager.Add(id, dataGen);

            GetNewProcessStarted(filter, dataGen, id);
        }

        public ActionResult ShippingRevenueDetailCompleted(string id, ShippingRevenueDetailListModel model)
        {
            if (id == null) return Content("Model can't be null.");

            if (model == null || model.Collection == null || model.Collection.Count() < 1)
                return Content("Model can't be null.");

            RemoveProcess(id);
            var message = WriteCsvShippingRevenueDetail("ShippingRevenueDetail.csv", model.Collection);
            return Content(message);
        }

        public void ExportableCustomerOpenOrderAsync(string id = null, CustomerOpenOrderListModelFilter filter = null)
        {
            if (id == null) return;

            AsyncManager.OutstandingOperations.Increment();
            var dataGen =
                new ExportableDataGenerator<CustomerOpenOrderViewModel, CustomerOpenOrderListModelFilter>(
                    _financeReportingService.GetCustomerOpenOrder);

            var processmanager = new ExportableDataGeneratorProcessManager<CustomerOpenOrderViewModel, CustomerOpenOrderListModelFilter>();
            processmanager.Add(id, dataGen);
            GetNewProcessStarted(filter, dataGen, id);
        }

        public ActionResult ExportableCustomerOpenOrderCompleted(string id, CustomerOpenOrderListModel model)
        {
            if (id == null) return Content("Model can't be null.");

            if (model == null || model.Collection == null || model.Collection.Count() < 1)
                return Content("Model can't be null.");

            RemoveProcess(id);
            var exporter = ExportableDataGeneratorProcessManager<ViewModelBase, ModelFilterBase>.GetCsvExporter<CustomerOpenOrderViewModel>();
            var message = WriteCsv("CustomerOpenOrder.csv", exporter, model.Collection, RequestSubcriberChannelNames.CustomerOpenOrderQueue, RequestSubcriberChannelNames.CustomerOpenOrderChannel);
            return Content(message);
        }


        public void CorporateInvoiceAsync(string id = null, CorporateAccountInvoiceListModelFilter filter = null)
        {
            if (id == null) return;

            AsyncManager.OutstandingOperations.Increment();
            var dataGen =
                new ExportableDataGenerator<CorporateAccountInvoiceLineItemViewModel, CorporateAccountInvoiceListModelFilter>(
                    _financeReportingService.GetCorporateAccountInvoiceList);

            var processmanager = new ExportableDataGeneratorProcessManager<CorporateAccountInvoiceLineItemViewModel, CorporateAccountInvoiceListModelFilter>();
            processmanager.Add(id, dataGen);
            GetNewProcessStarted(filter, dataGen, id);
        }

        public ActionResult CorporateInvoiceCompleted(string id, CorporateAccountInvoiceListModel model)
        {
            if (id == null) return Content("Model can't be null.");

            if (model == null || model.Collection == null || model.Collection.Count() < 1)
                return Content("Model can't be null.");

            RemoveProcess(id);
            var exporter = ExportableDataGeneratorProcessManager<ViewModelBase, ModelFilterBase>.GetCsvExporter<CorporateAccountInvoiceLineItemViewModel>();
            var message = WriteCsv("CorporateInvoice.csv", exporter, model.Collection, RequestSubcriberChannelNames.CorporateInvoiceQueue, RequestSubcriberChannelNames.CorporateInvoiceChannel);
            return Content(message);
        }

        private string WriteCsvShippingRevenueDetail(string fileName, IEnumerable<ShippingRevenueDetailViewModel> modelData)
        {
            var csvFilePath = _tempMediaLocation.PhysicalPath + fileName;

            //using (var streamWriter = new StreamWriter(csvFilePath, false))
            //{
            var csvStringBuilder = new StringBuilder();
            var members = (typeof(ShippingRevenueDetailViewModel)).GetMembers();

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
            //}
            var request = new GenericReportRequest { CsvFilePath = csvFilePath, Model = csvStringBuilder.ToString() };
            var isGenerated = GetResponse(request, RequestSubcriberChannelNames.GenerateShippingRevenueDetailReportQueue, RequestSubcriberChannelNames.GenerateShippingRevenueDetailReportChannel);
            if (!isGenerated) return "CSV File Export failed!";

            DownloadZipFile(_tempMediaLocation, fileName);

            return "CSV File Export was succesful!";
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
            if (!GetResponse(request, queue, channel)) return "CSV File Export failed!";

            DownloadZipFile(_tempMediaLocation, fileName);

            return "CSV File Export was succesful!";
        }

        private string WriteCsvDeferredRevenue(string fileName, IEnumerable<DeferredRevenueViewModel> modelData)
        {
            var csvFilePath = _tempMediaLocation.PhysicalPath + fileName;


            //using (var streamWriter = new StreamWriter(csvFilePath, false))
            //{
            var csvStringBuilder = new StringBuilder();
            var eventMembers = (typeof(DeferredRevenueViewModel)).GetMembers();
            var cutomermembers = (typeof(DeferredRevenueCustomerViewModel)).GetMembers();


            var header = new List<string>();
            foreach (var memberInfo in eventMembers)
            {
                if (memberInfo.MemberType != MemberTypes.Property)
                    continue;

                var propInfo = (memberInfo as PropertyInfo);
                if (propInfo != null)
                {
                    if (propInfo.PropertyType == typeof(FeedbackMessageModel) || propInfo.PropertyType == typeof(IEnumerable<DeferredRevenueCustomerViewModel>))
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

            foreach (var memberInfo in cutomermembers)
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
                foreach (var cutomerModel in model.Customers)
                {
                    var values = new List<string>();
                    foreach (var memberInfo in eventMembers)
                    {
                        if (memberInfo.MemberType != MemberTypes.Property)
                            continue;

                        var propInfo = (memberInfo as PropertyInfo);
                        if (propInfo != null)
                        {
                            if (propInfo.PropertyType == typeof(FeedbackMessageModel) ||
                                propInfo.PropertyType == typeof(IEnumerable<DeferredRevenueCustomerViewModel>))
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

                    foreach (var cutomerModelMemberInfo in cutomermembers)
                    {
                        if (cutomerModelMemberInfo.MemberType != MemberTypes.Property)
                            continue;

                        var cutomerModelPropInfo = (cutomerModelMemberInfo as PropertyInfo);
                        if (cutomerModelPropInfo != null)
                        {
                            if (cutomerModelPropInfo.PropertyType == typeof(FeedbackMessageModel))
                                continue;
                        }
                        else
                            continue;


                        bool cutomerModelIsHidden = false;
                        FormatAttribute cutomerModelFormatter = null;

                        var cutomerModelAttributes = cutomerModelPropInfo.GetCustomAttributes(false);
                        if (!cutomerModelAttributes.IsNullOrEmpty())
                        {
                            foreach (var attribute in cutomerModelAttributes)
                            {
                                if (attribute is HiddenAttribute)
                                {
                                    cutomerModelIsHidden = true;
                                    break;
                                }
                                if (attribute is FormatAttribute)
                                {
                                    cutomerModelFormatter = (FormatAttribute)attribute;
                                }
                            }
                        }

                        if (cutomerModelIsHidden) continue;
                        var cutomerModelObj = cutomerModelPropInfo.GetValue(cutomerModel, null);
                        if (cutomerModelObj == null)
                            values.Add(string.Empty);
                        else if (cutomerModelFormatter != null)
                            values.Add(cutomerModelFormatter.ToString(cutomerModelObj));
                        else
                            values.Add(sanitizer.EscapeString(cutomerModelObj.ToString()));
                    }
                    csvStringBuilder.Append(string.Join(",", values.ToArray()) + Environment.NewLine);
                }

            }

            //    streamWriter.Close();
            //} 


            var request = new GenericReportRequest { CsvFilePath = csvFilePath, Model = csvStringBuilder.ToString() };
            var isGenerated = GetResponse(request, RequestSubcriberChannelNames.GenerateDeferredRevenueReportQueue, RequestSubcriberChannelNames.GenerateDeferredRevenueReportChannel);
            if (!isGenerated) return "CSV File Export failed!";

            DownloadZipFile(_tempMediaLocation, fileName);

            return "CSV File Export was succesful!";
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

        public void ExportableRefundRequestAsync(string id = null, RefundRequestListModelFilter filter = null)
        {
            if (id == null) return;

            AsyncManager.OutstandingOperations.Increment();
            var dataGen =
                new ExportableDataGenerator<RefundRequestBasicInfoModel, RefundRequestListModelFilter>(
                    _refundRequestService.GetPendingRequests);

            var processmanager = new ExportableDataGeneratorProcessManager<RefundRequestBasicInfoModel, RefundRequestListModelFilter>();
            processmanager.Add(id, dataGen);
            GetNewProcessStarted(filter, dataGen, id);
        }

        public ActionResult ExportableRefundRequestCompleted(string id, RefundRequestListModel model)
        {
            if (id == null) return Content("Model can't be null.");

            if (model == null || model.Collection == null || model.Collection.Count() < 1)
                return Content("Model can't be null.");

            RemoveProcess(id);
            var exporter = ExportableDataGeneratorProcessManager<ViewModelBase, ModelFilterBase>.GetCsvExporter<RefundRequestBasicInfoModel>();
            var message = WriteCsv("RefundRequest.csv", exporter, model.Collection, RequestSubcriberChannelNames.RefundRequestQueue, RequestSubcriberChannelNames.RefundRequestChannel);
            return Content(message);
        }

        public void ExportableInsurancePaymentAsync(string id = null, InsurancePaymentListModelFilter filter = null)
        {
            if (id == null) return;

            AsyncManager.OutstandingOperations.Increment();
            var dataGen =
                new ExportableDataGenerator<InsurancePaymentViewModel, InsurancePaymentListModelFilter>(_financeReportingService.GetInsurancePayment);

            var processmanager = new ExportableDataGeneratorProcessManager<InsurancePaymentViewModel, InsurancePaymentListModelFilter>();
            processmanager.Add(id, dataGen);
            GetNewProcessStarted(filter, dataGen, id);
        }

        public ActionResult ExportableInsurancePaymentCompleted(string id, InsurancePaymentListModel model)
        {
            if (id == null) return Content("Model can't be null.");

            if (model == null || model.Collection == null || model.Collection.Count() < 1)
                return Content("Model can't be null.");

            RemoveProcess(id);
            var message = WriteCsvInsurancePayment("InsurancePayment.csv", model.Collection);
            return Content(message);
        }

        private string WriteCsvInsurancePayment(string fileName, IEnumerable<InsurancePaymentViewModel> modelData)
        {
            var csvFilePath = _tempMediaLocation.PhysicalPath + fileName;


            // using (var streamWriter = new StreamWriter(csvFilePath, false))
            //{
            var csvStringBuilder = new StringBuilder();
            var members = (typeof(InsurancePaymentViewModel)).GetMembers();

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
                        if (propInfo.PropertyType == typeof(IEnumerable<OrderedPair<string, decimal>>))
                        {
                            if (model.PaymentInstruments != null && model.PaymentInstruments.Any())
                            {
                                var paymentInstruments = string.Empty;
                                foreach (var paymentInstrument in model.PaymentInstruments)
                                {
                                    paymentInstruments += paymentInstrument.FirstValue + ": $" + paymentInstrument.SecondValue.ToString("0.00") + "\n";
                                }
                                values.Add(sanitizer.EscapeString(paymentInstruments));
                            }
                            else
                            {
                                values.Add(string.Empty);
                            }
                            continue;
                        }

                        if (propInfo.PropertyType == typeof(InsuranceDetailViewModel))
                        {
                            if (model.InsuranceDetail != null)
                            {
                                var insuranceDetail = string.Empty;
                                insuranceDetail += "Member Id: " + model.InsuranceDetail.MemberId + "\n";
                                insuranceDetail += "Insurance Company: " + model.InsuranceDetail.InsuranceCompany + "\n";
                                insuranceDetail += "Plan Name: " + model.InsuranceDetail.PlanName + "\n";
                                insuranceDetail += "Plan Id: " + model.InsuranceDetail.PlanId + "\n";
                                insuranceDetail += "Group Name: " + model.InsuranceDetail.GroupName + "\n";
                                insuranceDetail += "Group Id: " + model.InsuranceDetail.GroupId + "\n";

                                values.Add(sanitizer.EscapeString(insuranceDetail));
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
            var isGenerated = GetResponse(request, RequestSubcriberChannelNames.GenerateInsurancePaymentReportQueue, RequestSubcriberChannelNames.GenerateInsurancePaymentReportChannel);
            if (!isGenerated) return "CSV File Export failed!";

            DownloadZipFile(_tempMediaLocation, fileName);

            return "CSV File Export was succesful!";
        }

        public void ExportableDailyPatientRecapAsync(string id = null, DailyPatientRecapModelFilter filter = null)
        {
            if (id == null) return;

            AsyncManager.OutstandingOperations.Increment();
            var dataGen = new ExportableDataGenerator<DailyPatientRecapModel, DailyPatientRecapModelFilter>(_dailyPatientRecapReportingService.GetDailyPatientReapModel);

            var processmanager = new ExportableDataGeneratorProcessManager<DailyPatientRecapModel, DailyPatientRecapModelFilter>();
            processmanager.Add(id, dataGen);
            GetNewProcessStarted(filter, dataGen, id);
        }

        public ActionResult ExportableDailyPatientRecapCompleted(string id, DailyPatientRecapListModel model)
        {
            if (id == null) return Content("Model can't be null.");

            if (model == null || model.Collection == null || !model.Collection.Any())
                return Content("Model can't be null.");

            RemoveProcess(id);
            var message = WriteCsvDailyPatientRecap("DailyRecapCustomer.csv", model.Collection);
            return Content(message);
        }

        private string WriteCsvDailyPatientRecap(string fileName, IEnumerable<DailyPatientRecapModel> modelData)
        {
            var csvFilePath = _tempMediaLocation.PhysicalPath + fileName;

            var csvStringBuilder = new StringBuilder();
            var members = (typeof(DailyPatientRecapModel)).GetMembers();

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

                        //if (propInfo.PropertyType == typeof(bool))
                        //{
                        //    values.Add(sanitizer.EscapeString(model.IsGiftCertificateDeleievred == null ? "N/A" : (model.IsGiftCertificateDeleievred.Value ? "Yes" : "No")));
                        //    continue;
                        //}
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
            var isGenerated = GetResponse(request, RequestSubcriberChannelNames.DailyRecapCustomerQueue, RequestSubcriberChannelNames.DailyRecapCustomerChannel);
            if (!isGenerated) return "CSV File Export failed!";

            DownloadZipFile(_tempMediaLocation, fileName);

            return "CSV File Export was succesful!";
        }

        public void GiftCertificateAsync(string id = null, GiftCertificateReportFilter filter = null)
        {
            if (id == null) return;

            AsyncManager.OutstandingOperations.Increment();
            var dataGen = new ExportableDataGenerator<GiftCertificateReportViewModel, GiftCertificateReportFilter>(_financeReportingService.GetGiftCertificateReport);

            var processmanager = new ExportableDataGeneratorProcessManager<GiftCertificateReportViewModel, GiftCertificateReportFilter>();
            processmanager.Add(id, dataGen);

            GetNewProcessStarted(filter, dataGen, id);
        }

        public ActionResult GiftCertificateCompleted(string id, GiftCertificateReportListModel model)
        {
            if (id == null) return Content("Model can't be null.");

            if (model == null || model.Collection == null || !model.Collection.Any())
                return Content("Model can't be null.");

            RemoveProcess(id);
            var message = WriteCsvGiftCertificate("GiftCertificate.csv", model.Collection);
            return Content(message);
        }

        private string WriteCsvGiftCertificate(string fileName, IEnumerable<GiftCertificateReportViewModel> modelData)
        {
            var csvFilePath = _tempMediaLocation.PhysicalPath + fileName;

            var csvStringBuilder = new StringBuilder();
            var members = (typeof(GiftCertificateReportViewModel)).GetMembers();

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

            var request = new GenericReportRequest { CsvFilePath = csvFilePath, Model = csvStringBuilder.ToString() };
            var isGenerated = GetResponse(request, RequestSubcriberChannelNames.GiftCertificateQueue, RequestSubcriberChannelNames.GiftCertificateChannel);
            if (!isGenerated) return "CSV File Export failed!";

            DownloadZipFile(_tempMediaLocation, fileName);

            return "CSV File Export was succesful!";
        }

        public void PayPeriodBookedCustomersAsync(string id = null, PayPeriodBookedCustomerFilter filter = null)
        {
            if (id == null) return;

            AsyncManager.OutstandingOperations.Increment();
            var dataGen = new ExportableDataGenerator<PayPeriodBookedCustomerViewModel, PayPeriodBookedCustomerFilter>(_callCenterBounsReportingService.GetPayPeriodAppointmentBooked);

            var processmanager = new ExportableDataGeneratorProcessManager<PayPeriodBookedCustomerViewModel, PayPeriodBookedCustomerFilter>();
            processmanager.Add(id, dataGen);

            GetNewProcessStarted(filter, dataGen, id);
        }

        public ActionResult PayPeriodBookedCustomersCompleted(string id, PayPeriodBookedCustomerListModel model)
        {
            if (id == null) return Content("Model can't be null.");

            if (model == null || model.Collection == null || !model.Collection.Any())
                return Content("Model can't be null.");

            RemoveProcess(id);


            var exporter = ExportableDataGeneratorProcessManager<ViewModelBase, ModelFilterBase>.GetCsvExporter<PayPeriodBookedCustomerViewModel>();
            var message = WriteCsv((model.Filter.ShowAttendedCustomersOnly ? "PayPeriodAttendedCustomers_" : "PayPeriodBookedCustomers_") + model.RegisteredBy.Replace(" ", "_") + "_" + id + ".csv", exporter, model.Collection, RequestSubcriberChannelNames.PayPeriodAppointmentBookedQueue, RequestSubcriberChannelNames.PayPeriodAppointmentBookedChannel);
            return Content(message);
        }

        public void CallCenterBonusAsync(string id = null, CallCenterBonusFilter filter = null)
        {
            if (id == null) return;

            AsyncManager.OutstandingOperations.Increment();
            var dataGen = new ExportableDataGenerator<CallCenterBonusViewModel, CallCenterBonusFilter>(_callCenterBounsReportingService.GetCallCenterBonus);

            var processmanager = new ExportableDataGeneratorProcessManager<CallCenterBonusViewModel, CallCenterBonusFilter>();
            processmanager.Add(id, dataGen);

            GetNewProcessStarted(filter, dataGen, id);
        }

        public ActionResult CallCenterBonusCompleted(string id, CallCenterBonusListModel model)
        {
            if (id == null) return Content("Model can't be null.");

            if (model == null || model.Collection == null || !model.Collection.Any())
                return Content("Model can't be null.");

            RemoveProcess(id);


            var exporter = ExportableDataGeneratorProcessManager<ViewModelBase, ModelFilterBase>.GetCsvExporter<CallCenterBonusViewModel>();
            var message = WriteCsv("ExpectedCallCenterBonus_" + id + ".csv", exporter, model.Collection, RequestSubcriberChannelNames.CallCenterBonusQueue, RequestSubcriberChannelNames.CallCenterBonusChannel);
            return Content(message);
        }

        public void AppointmentsShowedAsync(string id = null, CallCenterBonusFilter filter = null)
        {
            if (id == null) return;

            AsyncManager.OutstandingOperations.Increment();
            var dataGen = new ExportableDataGenerator<AppointmentsShowedViewModel, CallCenterBonusFilter>(_callCenterBounsReportingService.GetAppointmentsShowed);

            var processmanager = new ExportableDataGeneratorProcessManager<AppointmentsShowedViewModel, CallCenterBonusFilter>();
            processmanager.Add(id, dataGen);

            GetNewProcessStarted(filter, dataGen, id);
        }

        public ActionResult AppointmentsShowedCompleted(string id, AppointmentsShowedListModel model)
        {
            if (id == null) return Content("Model can't be null.");

            if (model == null || model.Collection == null || !model.Collection.Any())
                return Content("Model can't be null.");

            RemoveProcess(id);


            var exporter = ExportableDataGeneratorProcessManager<ViewModelBase, ModelFilterBase>.GetCsvExporter<AppointmentsShowedViewModel>();
            var message = WriteCsv("ActualCallCenterBonus_" + id + ".csv", exporter, model.Collection, RequestSubcriberChannelNames.CallCenterBonusQueue, RequestSubcriberChannelNames.CallCenterBonusChannel);
            return Content(message);
        }

        public void ActualCustomerShowedAsync(string id = null, PayPeriodBookedCustomerFilter filter = null)
        {
            if (id == null) return;

            AsyncManager.OutstandingOperations.Increment();
            var dataGen = new ExportableDataGenerator<ActualCustomerShowedViewModel, PayPeriodBookedCustomerFilter>(_callCenterBounsReportingService.GetActualCustomerShowed);

            var processmanager = new ExportableDataGeneratorProcessManager<ActualCustomerShowedViewModel, PayPeriodBookedCustomerFilter>();
            processmanager.Add(id, dataGen);

            GetNewProcessStarted(filter, dataGen, id);
        }

        public ActionResult ActualCustomerShowedCompleted(string id, ActualCustomerShowedListModel model)
        {
            if (id == null) return Content("Model can't be null.");

            if (model == null || model.Collection == null || !model.Collection.Any())
                return Content("Model can't be null.");

            RemoveProcess(id);


            var exporter = ExportableDataGeneratorProcessManager<ViewModelBase, ModelFilterBase>.GetCsvExporter<ActualCustomerShowedViewModel>();
            var message = WriteCsv("ActualCustomerShowed_" + model.RegisteredBy.Replace(" ", "_") + "_" + id + ".csv", exporter, model.Collection, RequestSubcriberChannelNames.ActualCustomerShowedQueue, RequestSubcriberChannelNames.ActualCustomerShowedChannel);
            return Content(message);
        }
    }
}
