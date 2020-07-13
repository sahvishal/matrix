using System;
using System.Linq;
using System.Web.Mvc;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Finance;
using Falcon.App.Core.Finance.Impl;
using Falcon.App.Core.Finance.ViewModels;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.DependencyResolution;
using Falcon.App.UI.Filters;

namespace Falcon.App.UI.Areas.Finance.Controllers
{
    [RoleBasedAuthorize]
    public class ReportsController : Controller
    {
        private readonly IEventReportingService _eventReportingService;
        private readonly IFinanceReportingService _financeReportingService;
        private readonly ICustomerReceiptModelService _customerReceiptModelService;
        private readonly IDailyPatientRecapReportingService _dailyPatientRecapReporting;
        private readonly ICallCenterBounsReportingService _callCenterBounsReportingService;

        public ReportsController(IEventReportingService eventReportingService, IFinanceReportingService financeReportingService, ICustomerReceiptModelService customerReceiptModelService, ISettings settings,
            IDailyPatientRecapReportingService dailyPatientRecapReporting, ICallCenterBounsReportingService callCenterBounsReportingService)
        {
            _eventReportingService = eventReportingService;
            _financeReportingService = financeReportingService;
            _customerReceiptModelService = customerReceiptModelService;
            _dailyPatientRecapReporting = dailyPatientRecapReporting;
            _callCenterBounsReportingService = callCenterBounsReportingService;
            _pageSize = settings.DefaultPageSizeForReports;
        }

        private readonly int _pageSize;

        public ActionResult DetailOpenOrder(DetailOpenOrderModelFilter filter = null, int pageNumber = 1)
        {
            int totalRecords = 0;
            var model = _eventReportingService.GetDetailOpenOrderModel(pageNumber, _pageSize, filter, out totalRecords);

            if (model == null) model = new DetailOpenOrderListModel();

            model.Filter = filter;


            var currentAction = ControllerContext.RouteData.Values["action"].ToString();
            Func<int, string> urlFunc =
                pn =>
                Url.Action(currentAction,
                           new
                               {
                                   pageNumber = pn,
                                   filter.FromDate,
                                   filter.ToDate,
                                   filter.IsRetailEvent,
                                   filter.IsCorporateEvent,
                                   filter.IsPublicEvent,
                                   filter.IsPrivateEvent
                               });
            model.PagingModel = new PagingModel(pageNumber, _pageSize, totalRecords, urlFunc);

            return View(model);
        }

        public ActionResult Upsell(CustomerUpsellListModelFilter filter = null, int pageNumber = 1)
        {
            if (!filter.FromDate.HasValue && !filter.ToDate.HasValue)
            {
                filter.FromDate = DateTime.Now.AddMonths(-1).Date;
                filter.ToDate = DateTime.Now.Date;
            }
            int totalRecords = 0;
            var model = _financeReportingService.GetCustomerUpsellModel(pageNumber, _pageSize, filter, out totalRecords);

            if (model == null) model = new CustomerUpsellListModel();
            model.Filter = filter;

            var currentAction = ControllerContext.RouteData.Values["action"].ToString();
            Func<int, string> urlFunc =
                pn => Url.Action(currentAction, new { pageNumber = pn, filter.FromDate, filter.ToDate, filter.Vehicle, filter.ZipCode, filter.Territory, filter.UpSellRole, filter.CorporateAccountId });
            model.PagingModel = new PagingModel(pageNumber, _pageSize, totalRecords, urlFunc);

            return View(model);
        }

        public ActionResult ItemizedReceipt(long eventId = 0, long customerId = 0)
        {
            CustomerItemizedReceiptModel model = null;
            if (customerId < 1 || eventId < 1) return View(model);
            try
            {
                model = _customerReceiptModelService.GetItemizedRecieptModel(customerId, eventId);
            }
            catch (ArgumentException)
            {
                model = null;
            }

            return View(model);
        }

        public ActionResult CreditCardReconcilation(CreditCardReconcileModelFilter filter = null, int pageNumber = 1)
        {
            int totalRecords = 0;
            var model = _financeReportingService.GetCreditCardReconcileList(pageNumber, _pageSize, filter, out totalRecords);

            if (model == null) model = new CreditCardReconcileListModel();

            model.Filter = filter;


            var currentAction = ControllerContext.RouteData.Values["action"].ToString();
            Func<int, string> urlFunc =
                pn => Url.Action(currentAction, new { pageNumber = pn, filter.FromDate, filter.ToDate });
            model.PagingModel = new PagingModel(pageNumber, _pageSize, totalRecords, urlFunc);

            return View(model);
        }

        public ActionResult DailyRecap(DailyRecapModelFilter filter = null, int pageNumber = 1)
        {
            int totalRecords = 0;
            var model = _eventReportingService.GetDailyRecapModel(pageNumber, _pageSize, filter, out totalRecords) ??
                        new DailyRecapListModel();

            if (filter == null)
                filter = new DailyRecapModelFilter { EventDateFrom = DateTime.Now, EventDateTo = DateTime.Now };

            filter.EventDateFrom = filter.EventDateFrom.HasValue ? filter.EventDateFrom.Value : DateTime.Now;
            filter.EventDateTo = filter.EventDateTo.HasValue ? filter.EventDateTo.Value : DateTime.Now;

            model.Filter = filter;

            var currentAction = ControllerContext.RouteData.Values["action"].ToString();
            Func<int, string> urlFunc =
                pn =>
                Url.Action(currentAction,
                           new
                               {
                                   pageNumber = pn,
                                   filter.EventDateFrom,
                                   filter.EventDateTo,
                                   filter.Pod,
                                   filter.IsRetailEvent,
                                   filter.IsCorporateEvent,
                                   filter.IsPublicEvent,
                                   filter.IsPrivateEvent,
                                   filter.IsHealthPlan

                               });
            model.PagingModel = new PagingModel(pageNumber, _pageSize, totalRecords, urlFunc);

            return View(model);
        }

        public ActionResult CustomerOrders(long customerId)
        {
            var model = _financeReportingService.GetAllOrdersForCustomer(customerId);
            return View(model);
        }

        public ActionResult DeferredRevenue(DeferredRevenueListModelFilter filter = null, int pageNumber = 1)
        {
            var filterValidator = IoC.Resolve<DeferredRevenueListModelFilterValidator>();
            var result = filterValidator.Validate(filter);
            if (result.IsValid)
            {
                int totalRecords = 0;
                var model = _financeReportingService.GetDeferredRevenue(pageNumber, _pageSize, filter, out totalRecords);

                if (model == null) model = new DeferredRevenueListModel();

                model.Filter = filter;


                var currentAction = ControllerContext.RouteData.Values["action"].ToString();
                Func<int, string> urlFunc =
                    pn =>
                    Url.Action(currentAction,
                               new
                                   {
                                       pageNumber = pn,
                                       filter.FromEventDate,
                                       filter.ToEventDate,
                                       filter.EventId,
                                       filter.Pod,
                                       filter.PaidCustomers,
                                       filter.UnPaidCustomers,
                                       filter.FromRegistrationDate,
                                       filter.ToRegistrationDate,
                                       filter.IsRetailEvent,
                                       filter.IsCorporateEvent,
                                       filter.IsPublicEvent,
                                       filter.IsPrivateEvent
                                   });
                model.PagingModel = new PagingModel(pageNumber, _pageSize, totalRecords, urlFunc);

                return View(model);
            }
            var propertyNames = result.Errors.Select(e => e.PropertyName).Distinct();
            var htmlString = propertyNames.Aggregate("", (current, property) => current + (result.Errors.Where(e => e.PropertyName == property).FirstOrDefault().ErrorMessage + "<br />"));

            return View(new DeferredRevenueListModel { Filter = filter, FeedbackMessage = FeedbackMessageModel.CreateFailureMessage(htmlString) });
        }

        public ActionResult ShippingRevenueSummary(ShippingRevenueListModelFilter filter = null, int pageNumber = 1)
        {
            int totalRecords = 0;

            var model = _financeReportingService.GetShippingRevenueSummary(pageNumber, _pageSize, filter, out totalRecords);

            if (model == null)
                model = new ShippingRevenueSummaryListModel();

            if (filter == null)
                filter = new ShippingRevenueListModelFilter { FromDate = DateTime.Now, ToDate = DateTime.Now };

            if (!filter.FromDate.HasValue && !filter.ToDate.HasValue && filter.PodId <= 0 && filter.EventId <= 0)
            {
                filter.FromDate = DateTime.Now;
                filter.ToDate = DateTime.Now;
            }

            model.Filter = filter;

            var currentAction = ControllerContext.RouteData.Values["action"].ToString();

            Func<int, string> urlFunc =
                pn => Url.Action(currentAction, new
                {
                    pageNumber = pn,
                    filter.EventId,
                    filter.FromDate,
                    filter.ToDate,
                    filter.PodId,
                });
            model.PagingModel = new PagingModel(pageNumber, _pageSize, totalRecords, urlFunc);
            return View(model);
        }

        public ActionResult ShippingRevenueDetail(ShippingRevenueListModelFilter filter = null, int pageNumber = 1)
        {
            int totalRecords = 0;

            var model = _financeReportingService.GetShippingRevenueDetail(pageNumber, _pageSize, filter, out totalRecords);

            if (model == null)
                model = new ShippingRevenueDetailListModel();
            model.Filter = filter;

            var currentAction = ControllerContext.RouteData.Values["action"].ToString();

            Func<int, string> urlFunc =
                pn => Url.Action(currentAction, new
                {
                    pageNumber = pn,
                    filter.EventId,
                    filter.FromDate,
                    filter.ToDate,
                    filter.PodId,
                });
            model.PagingModel = new PagingModel(pageNumber, _pageSize, totalRecords, urlFunc);
            return View(model);
        }

        public ActionResult CustomerOpenOrder(CustomerOpenOrderListModelFilter filter = null, int pageNumber = 1)
        {
            int totalRecords = 0;
            var model = _financeReportingService.GetCustomerOpenOrder(pageNumber, _pageSize, filter, out totalRecords);

            if (model == null) model = new CustomerOpenOrderListModel();

            model.Filter = filter;


            var currentAction = ControllerContext.RouteData.Values["action"].ToString();
            Func<int, string> urlFunc =
                pn =>
                Url.Action(currentAction,
                           new
                           {
                               pageNumber = pn,
                               filter.FromDate,
                               filter.ToDate,
                               filter.IsRetailEvent,
                               filter.IsCorporateEvent,
                               filter.IsPublicEvent,
                               filter.IsPrivateEvent,
                               filter.EventId
                           });
            model.PagingModel = new PagingModel(pageNumber, _pageSize, totalRecords, urlFunc);

            return View(model);
        }

        public ActionResult CorporateInvoice(int pageNumber = 1, CorporateAccountInvoiceListModelFilter filter = null)
        {
            int totalRecords;
            var list = _financeReportingService.GetCorporateAccountInvoiceList(pageNumber, _pageSize, filter, out totalRecords);

            filter = list.Filter;

            var currentAction = ControllerContext.RouteData.Values["action"].ToString();
            Func<int, string> urlFunc = pn => Url.Action(currentAction,
                                                         new
                                                             {
                                                                 pageNumber = pn,
                                                                 filter.EventFrom,
                                                                 filter.EventTo,
                                                                 filter.CorpCode,
                                                                 filter.AccountId,
                                                                 filter.EventId
                                                             });

            list.PagingModel = new PagingModel(pageNumber, _pageSize, totalRecords, urlFunc);

            return View(list);
        }

        public ActionResult InsurancePayment(int pageNumber = 1, InsurancePaymentListModelFilter filter = null)
        {
            int totalRecords;
            var model = _financeReportingService.GetInsurancePayment(pageNumber, _pageSize, filter, out totalRecords);

            if (model == null) model = new InsurancePaymentListModel();

            model.Filter = filter;

            var currentAction = ControllerContext.RouteData.Values["action"].ToString();
            Func<int, string> urlFunc = pn => Url.Action(currentAction,
                                                         new
                                                         {
                                                             pageNumber = pn,
                                                             filter.EventFrom,
                                                             filter.EventTo,
                                                             filter.EventId,
                                                             filter.Status
                                                         });

            model.PagingModel = new PagingModel(pageNumber, _pageSize, totalRecords, urlFunc);

            return View(model);
        }

        public ActionResult DailyPatientRecap(DailyPatientRecapModelFilter filter = null, int pageNumber = 1)
        {
            int totalRecords = 0;

            var model = _dailyPatientRecapReporting.GetDailyPatientReapModel(pageNumber, _pageSize, filter, out totalRecords) ??
                        new DailyPatientRecapListModel();

            if (filter == null)
                filter = new DailyPatientRecapModelFilter { EventDateFrom = DateTime.Now, EventDateTo = DateTime.Now };

            filter.EventDateFrom = filter.EventDateFrom.HasValue ? filter.EventDateFrom.Value : DateTime.Now.Date;
            filter.EventDateTo = filter.EventDateTo.HasValue ? filter.EventDateTo.Value : DateTime.Now.Date;

            model.Filter = filter;

            var currentAction = ControllerContext.RouteData.Values["action"].ToString();
            Func<int, string> urlFunc =
                pn =>
                Url.Action(currentAction,
                           new
                           {
                               pageNumber = pn,
                               filter.EventDateFrom,
                               filter.EventDateTo,
                               filter.CustomerName,
                               filter.CustomerId,
                               filter.IsRetailEvent,
                               filter.IsCorporateEvent,
                               filter.IsPublicEvent,
                               filter.IsPrivateEvent,
                               filter.CorporateAccountId,
                               filter.HospitalPartnerId,
                               filter.Pod,
                               filter.IsHealthPlanEvent,
                               filter.IsGiftCertificateDeleievred
                           });

            model.PagingModel = new PagingModel(pageNumber, _pageSize, totalRecords, urlFunc);

            return View(model);
        }

        public ActionResult GiftCertificate(GiftCertificateReportFilter filter = null, int pageNumber = 1)
        {
            int totalRecords;
            filter = filter ?? new GiftCertificateReportFilter();

            var model = _financeReportingService.GetGiftCertificateReport(pageNumber, _pageSize, filter, out totalRecords) ?? new GiftCertificateReportListModel();

            model.Filter = filter;

            var currentAction = ControllerContext.RouteData.Values["action"].ToString();

            Func<int, string> urlFunc = pn => Url.Action(currentAction, new { pageNumber = pn, filter.EventId, filter.HealthPlanId, filter.CustomerId, filter.EventFrom, filter.EventTo });
            model.PagingModel = new PagingModel(pageNumber, _pageSize, totalRecords, urlFunc);

            return View(model);
        }

        public ActionResult CallCenterBonus(CallCenterBonusFilter filter = null, int pageNumber = 1)
        {
            int totalRecords;
            filter = filter ?? new CallCenterBonusFilter();
            if (filter.PayPeriodId <= 0 || string.IsNullOrEmpty(filter.PayRange))
            {
                return View(new CallCenterBonusListModel { Filter = filter, FeedbackMessage = FeedbackMessageModel.CreateFailureMessage("Please select both the filters.") });
            }

            var model = _callCenterBounsReportingService.GetCallCenterBonus(pageNumber, _pageSize, filter, out totalRecords) ?? new CallCenterBonusListModel();

            model.Filter = filter;

            var currentAction = ControllerContext.RouteData.Values["action"].ToString();

            Func<int, string> urlFunc = pn => Url.Action(currentAction, new { pageNumber = pn, filter.PayPeriodId, filter.CallCenterAgentId, filter.PayRange });

            model.PagingModel = new PagingModel(pageNumber, _pageSize, totalRecords, urlFunc);

            return View(model);
        }

        public ActionResult PayPeriodBookedCustomers(PayPeriodBookedCustomerFilter filter = null, int pageNumber = 1)
        {
            int totalRecords;
            filter = filter ?? new PayPeriodBookedCustomerFilter();

            var model = _callCenterBounsReportingService.GetPayPeriodAppointmentBooked(pageNumber, _pageSize, filter, out totalRecords);
            model = model ?? new PayPeriodBookedCustomerListModel();
            model.Filter = filter;

            var currentAction = ControllerContext.RouteData.Values["action"].ToString();

            Func<int, string> urlFunc = pn => Url.Action(currentAction, new { pageNumber = pn, filter.PayPeriodId, filter.AgentId, filter.StartDate, filter.EndDate });
            model.PagingModel = new PagingModel(pageNumber, _pageSize, totalRecords, urlFunc);

            return View(model);
        }


        public ActionResult AppointmentsShowed(CallCenterBonusFilter filter = null, int pageNumber = 1)
        {
            int totalRecords;
            filter = filter ?? new CallCenterBonusFilter();

            var model = _callCenterBounsReportingService.GetAppointmentsShowed(pageNumber, _pageSize, filter, out totalRecords) ?? new AppointmentsShowedListModel();

            model.Filter = filter;

            var currentAction = ControllerContext.RouteData.Values["action"].ToString();

            Func<int, string> urlFunc = pn => Url.Action(currentAction, new { pageNumber = pn, filter.StartDate, filter.EndDate, filter.CallCenterAgentId });

            model.PagingModel = new PagingModel(pageNumber, _pageSize, totalRecords, urlFunc);

            return View(model);
        }
        
        public ActionResult ActualCustomerShowed(PayPeriodBookedCustomerFilter filter = null, int pageNumber = 1)
        {
            int totalRecords;
            filter = filter ?? new PayPeriodBookedCustomerFilter();

            var model = _callCenterBounsReportingService.GetActualCustomerShowed(pageNumber, _pageSize, filter, out totalRecords);
            model = model ?? new ActualCustomerShowedListModel();
            model.Filter = filter;

            var currentAction = ControllerContext.RouteData.Values["action"].ToString();

            Func<int, string> urlFunc = pn => Url.Action(currentAction, new { pageNumber = pn, filter.AgentId, filter.StartDate, filter.EndDate });
            model.PagingModel = new PagingModel(pageNumber, _pageSize, totalRecords, urlFunc);

            return View(model);
        }
    }
}
