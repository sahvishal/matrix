using System.Web.Mvc;
using Falcon.App.Core.Finance.ViewModels;
using Falcon.App.Core.Finance;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.ViewModels;
using System;
using Falcon.App.Core.Interfaces;
using Falcon.App.UI.Filters;
using System.Collections.Generic;

namespace Falcon.App.UI.Areas.Finance.Controllers
{
    [RoleBasedAuthorize]
    public class PayPeriodController : Controller
    {

        private readonly IPayPeriodService _payPeriodService;
        private readonly ISessionContext _sessionContext;
        private readonly IPayPeriodRepository _payPeriodRepository;
        private readonly int _pageSize;
        private readonly ILogger _logger;
        public PayPeriodController(IPayPeriodService payPeriodService, ISessionContext sessionContext, ISettings settings, ILogManager logManager, IPayPeriodRepository payPeriodRepository)
        {
            _payPeriodService = payPeriodService;
            _sessionContext = sessionContext;
            _payPeriodRepository = payPeriodRepository;
            _pageSize = settings.DefaultPageSizeForReports;
            _logger = logManager.GetLogger<PayPeriodController>();

        }

        public ActionResult Index(PayPeriodFilter filter = null, int pageNumber = 1)
        {
            int totalRecords;
            var model = _payPeriodService.Get(filter, pageNumber, _pageSize, out totalRecords) ?? new PayPeriodListModel();

            filter = filter ?? new PayPeriodFilter();

            model.Filter = filter;

            var currentAction = ControllerContext.RouteData.Values["action"].ToString();
            Func<int, string> urlFunc = pn => Url.Action(currentAction,
                           new
                           {
                               pageNumber = pn,
                               filter.StartDate
                           });

            model.PagingModel = new PagingModel(pageNumber, _pageSize, totalRecords, urlFunc);
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(long payPeriodId = 0)
        {
            var model = _payPeriodService.GetEditModel(payPeriodId);

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(PayPeriodEditModel model)
        {
            if (ModelState.IsValid)
            {
                _payPeriodService.Save(model, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);
                model.FeedbackMessage = FeedbackMessageModel.CreateSuccessMessage("Pay Period Saved Successfully.");
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult PayperiodDetail(long payPeriodId)
        {
            if (ModelState.IsValid)
            {
                //_payPeriodService.Save(model, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);
                //model.FeedbackMessage = FeedbackMessageModel.CreateSuccessMessage("Health Plan Revenue Saved Successfully.");
            }

            return PartialView("HealthPlanRevenueConfigModel");
        }

        [HttpGet]
        public bool DeletePayPeriod(long payPeriodId)
        {
            try
            {
                if (payPeriodId > 0)
                {
                    _payPeriodService.Delete(payPeriodId);
                }

                return true;
            }
            catch (Exception ex)
            {
                _logger.Error("exception occurred whiled deleting pay period. Message: " + ex.Message);
                _logger.Error("stack trace: " + ex.StackTrace);

                return false;
            }
        }

        [HttpPost]
        public JsonResult GetRangeForPayPeriod(long payPeriodId)
        {
            var dropDownList = new List<SelectListItem>();
            dropDownList.Add(new SelectListItem { Text = "-- Select --", Value = "" });

            if (payPeriodId <= 0) return Json(dropDownList);

            var payPeriod = _payPeriodRepository.GetById(payPeriodId);

            var nextPayPeriod = _payPeriodRepository.GetNextPublishedPayPeriod(payPeriod.StartDate);
            var startDate = payPeriod.StartDate;
            var nextEffectiveDate = DateTime.Today;
            if (nextPayPeriod != null)
            {
                nextEffectiveDate = nextPayPeriod.StartDate > DateTime.Today ? DateTime.Today : nextPayPeriod.StartDate;
            }
            
            while (startDate < nextEffectiveDate)
            {
                var endDate = startDate.AddDays((7 * payPeriod.NumberOfWeeks) - 1);
                dropDownList.Add(new SelectListItem { Text = startDate.ToString("MM/dd/yyyy") + " - " + endDate.ToString("MM/dd/yyyy"), Value = startDate.ToString("MM/dd/yyyy") + "-" + endDate.ToString("MM/dd/yyyy") });
                startDate = endDate.AddDays(1);
            }

            return Json(dropDownList);
        }
    }
}
