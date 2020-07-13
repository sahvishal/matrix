using System.Web.Mvc;
using Falcon.App.UI.Filters;
using Falcon.App.Core.Finance.ViewModels;
using Falcon.App.Core.Finance;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.ViewModels;
using System;
using System.Collections.Generic;


namespace Falcon.App.UI.Areas.Finance.Controllers
{
    [RoleBasedAuthorize]
    public class HealthPlanRevenueController : Controller
    {
        private readonly IHealthPlanRevenueService _healthPlanRevenueService;
        private readonly ISessionContext _sessionContext;
        private readonly int _pageSize;
        public HealthPlanRevenueController(IHealthPlanRevenueService healthPlanRevenueService, ISessionContext sessionContext, ISettings settings)
        {
            _healthPlanRevenueService = healthPlanRevenueService;
            _sessionContext = sessionContext;
            _pageSize = settings.DefaultPageSizeForReports;

        }

        public ActionResult Index(HealthPlanRevenueListModelFilter filter = null, int pageNumber = 1)
        {
            int totalRecords;
            var model = _healthPlanRevenueService.GetHealthPlanRevenues(filter, pageNumber, _pageSize, out totalRecords) ?? new HealthPlanRevenueListModel();

            filter = filter ?? new HealthPlanRevenueListModelFilter();

            model.Filter = filter;

            var currentAction = ControllerContext.RouteData.Values["action"].ToString();
            Func<int, string> urlFunc = pn => Url.Action(currentAction,
                           new
                           {
                               pageNumber = pn,
                               filter.HealthPlanId
                           });

            model.PagingModel = new PagingModel(pageNumber, _pageSize, totalRecords, urlFunc);
            return View(model);
        }

        [HttpGet]
        public ActionResult HealthPlanRevenueConfig(long accountId = 0)
        {
            var model = new HealthPlanRevenueEditModel { SelectedAccountId = accountId, HealthPlanId = accountId };
            model.PackageMasterList = _healthPlanRevenueService.GetHealthPlansPackages(model.HealthPlanId);
            model.TestMasterList = _healthPlanRevenueService.GetHealthPlansTests(model.HealthPlanId);

            return View(model);
        }

        [HttpPost]
        public ActionResult HealthPlanRevenueConfigModel(HealthPlanRevenueEditModel model)
        {
            if (ModelState.IsValid)
            {
                _healthPlanRevenueService.SaveHealthPlanRevenue(model, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);
                model.FeedbackMessage = FeedbackMessageModel.CreateSuccessMessage("Health Plan Revenue Saved Successfully.");
            }

            model.PackageMasterList = _healthPlanRevenueService.GetHealthPlansPackages(model.HealthPlanId);
            model.TestMasterList = _healthPlanRevenueService.GetHealthPlansTests(model.HealthPlanId);
            return PartialView("HealthPlanRevenueConfigModel", model);
        }

        public ActionResult HealthPlanRevenueDetails(long accountId)
        {
            int currentPage = 1;
            var model = _healthPlanRevenueService.GetHealthPlanRevenueDetails(accountId) ?? new HealthPlanRevenueDetailsListModel();
            model.SelectedAccountId = accountId;

            var healthPlanRevenueEventList = SelectHealthPlanRevenueEventList(accountId, currentPage);
            if (healthPlanRevenueEventList != null && healthPlanRevenueEventList.Collection != null)
                model.HealthPlanRevenueEventListModel = healthPlanRevenueEventList;

            return View(model);
        }

        private HealthPlanRevenueEventListModel SelectHealthPlanRevenueEventList(long healthPlanId, int pageNumber = 1)
        {
            int pageSize = 10;
            int totalRecords;
            var filter = new HealthPlanRevenueEventModelFilter();
            filter.HealthPlanId = healthPlanId;
            var model = _healthPlanRevenueService.GetEventListByHealthPlan(filter, pageNumber, pageSize, out totalRecords);
            if (model == null)
                model = new HealthPlanRevenueEventListModel();

            var currentAction = "HealthPlanEventInfo";
            Func<int, string> urlFunc = pn => Url.Action(currentAction,
                           new
                           {
                               pageNumber = pn,
                               filter.HealthPlanId
                           });

            model.PagingModel = new PagingModel(pageNumber, pageSize, totalRecords, urlFunc);

            return model;
        }

        [HttpGet]
        public ActionResult HealthPlanEventInfo(long healthPlanId, int pageNumber = 1)
        {
            var model = SelectHealthPlanRevenueEventList(healthPlanId, pageNumber);
            return PartialView("HealthPlanEventInfo", model);
        }

        [HttpPost]
        public JsonResult GetTests(long healthPlanId)
        {
            var packages = _healthPlanRevenueService.GetHealthPlansTests(healthPlanId);
            return Json(packages, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetPackages(long healthPlanId)
        {
            var tests = _healthPlanRevenueService.GetHealthPlansPackages(healthPlanId);
            return Json(tests, JsonRequestBehavior.AllowGet);
        }

    }
}
