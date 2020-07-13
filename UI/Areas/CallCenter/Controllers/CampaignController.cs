using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.CallCenter;
using Falcon.App.Core.CallCenter.Enum;
using Falcon.App.Core.CallCenter.ViewModels;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Sales.Interfaces;
using Falcon.App.UI.Filters;
using System;
using System.Web.Mvc;
using Falcon.App.Core.CallQueues;

namespace Falcon.App.UI.Areas.CallCenter.Controllers
{
    [RoleBasedAuthorize]
    public class CampaignController : Controller
    {
        private readonly ICampaignService _campaignService;
        private readonly ISessionContext _sessionContext;
        private readonly ILogger logger;
        private readonly int _pageSize;
        private readonly ICorporateTagRepository _corporateTagRepository;
        private readonly IHealthPlanCallQueueCriteriaRepository _healthPlanCallQueueCriteriaRepository;
        private readonly ICampaignRepository _campaignRepository;
        private readonly ICampaignActivityRepository _campaignActivityRepository;

        public CampaignController(ICampaignService campaignService, ISettings settings, ISessionContext sessionContext,
            ILogManager logManager, ICorporateTagRepository corporateTagRepository,
            IHealthPlanCallQueueCriteriaRepository healthPlanCallQueueCriteriaRepository,
            ICampaignRepository campaignRepository, ICampaignActivityRepository campaignActivityRepository)
        {
            _campaignService = campaignService;
            _sessionContext = sessionContext;
            _corporateTagRepository = corporateTagRepository;
            _pageSize = settings.DefaultPageSizeForReports;
            _healthPlanCallQueueCriteriaRepository = healthPlanCallQueueCriteriaRepository;
            _campaignRepository = campaignRepository;
            _campaignActivityRepository = campaignActivityRepository;
            logger = logManager.GetLogger("Campaign");
        }

        public ActionResult Create()
        {
            return View(_campaignService.GetEditModel(0));
        }

        [HttpPost]
        public ActionResult Create(CampaignEditModel model)
        {
            try
            {
                var orgRoleId = _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId;

                if (ModelState.IsValid)
                {
                    _campaignService.Save(model, orgRoleId);
                    model.FeedbackMessage = FeedbackMessageModel.CreateSuccessMessage("Campaign created successfully");

                    //return RedirectToAction("ManageCampaign");
                }
            }
            catch (Exception ex)
            {
                model.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage("Some Error occured while saving your record");
                logger.Error("Message: " + ex.Message + " stack Trace: " + ex.StackTrace);
            }

            return View(model);
        }

        public ActionResult Edit(long campaignId)
        {

            return View(_campaignService.GetEditModel(campaignId));
        }

        [HttpPost]
        public ActionResult Edit(CampaignEditModel model)
        {
            try
            {
                var orgRoleId = _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId;

                if (ModelState.IsValid)
                {
                    if (!IsAlreadyPublished(model.CampaignId))
                    {
                        _campaignService.Save(model, orgRoleId);
                        model.FeedbackMessage = FeedbackMessageModel.CreateSuccessMessage("Campaign updated successfully");
                    }

                    else
                    {
                        model.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage("Campaign has been already published");
                    }


                    //return RedirectToAction("ManageCampaign");
                }
            }
            catch (Exception ex)
            {
                model.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage("Some Error occured while saving your record");
                logger.Error("Message: " + ex.Message + " stack Trace: " + ex.StackTrace);
            }

            return View(model);
        }


        private bool IsAlreadyPublished(long campaignId)
        {
            return _campaignRepository.IsCampaignAlreadyPublished(campaignId);
        }


        public ActionResult EditActivity(long activityId, long campaignId)
        {
            var model = _campaignService.GetActivityEditModel(activityId, campaignId);
            model.ActivityEditMode = true;
            return View(model);
        }

        [HttpPost]
        public ActionResult EditActivityModel(CampaignActivityEditModel model)
        {

            if (ModelState.IsValid)
            {
                var camapign = _campaignService.GetEditModel(model.CampaigndId);
                var campaignActivities = camapign.CampaignActivity.IsNullOrEmpty() ? new List<CampaignActivityEditModel>() : camapign.CampaignActivity.ToList();

                if (model.ActivityId <= 0)
                {
                    var activity = campaignActivities.OrderBy(x => x.Sequence).LastOrDefault();
                    model.Sequence = activity.Sequence + 1;
                    campaignActivities.Add(model);
                }
                else
                {
                    campaignActivities = campaignActivities.Where(x => x.ActivityId != model.ActivityId).ToList();
                    campaignActivities.Add(model);
                }

                var IsValid = IsValidActivity(campaignActivities);
                if (!IsValid)
                {
                    model.FeedbackMessage = FeedbackMessageModel.CreateWarningMessage("First activity can not be Outbound Call");
                }

                model.IsValid = IsValid;
                var orgId = _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId;

                if (IsValid)
                {
                    _campaignService.EditActivity(orgId, model);
                }

                if (model.IsValid)
                    model.FeedbackMessage = FeedbackMessageModel.CreateSuccessMessage("Successfully updated");
            }

            return View("EditActivityModel", model);
        }




        [HttpPost]
        public ActionResult CampaignActivity(CampaignActivityEditModel model)
        {
            if (model.IsNew)
                ModelState.Clear();

            if (model.IsForValidate)
                model.IsValid = ModelState.IsValid;

            return View(model);
        }

        public ActionResult ManageCampaign(CampaignListModelFilter filter = null, int pageNumber = 1)
        {
            int totalRecords;
            var model = _campaignService.GetCampaignDetails(pageNumber, _pageSize, filter, out totalRecords) ?? new CampaignListModel();
            model.Filter = filter;

            var currentAction = ControllerContext.RouteData.Values["action"].ToString();
            Func<int, string> urlFunc =
                pn =>
                Url.Action(currentAction,
                           new
                           {
                               pageNumber = pn,
                               filter.Name,
                               filter.CampaignTypeId,
                               filter.CampaignModeId,
                               filter.StartDate,
                               filter.EndDate,
                               filter.IsPublished,
                               filter.AccountId
                           });
            model.PagingModel = new PagingModel(pageNumber, _pageSize, totalRecords, urlFunc);
            return View(model);
        }

        [HttpPost]
        public JsonResult GetCustomTagsByAccountId(long accountId)
        {
            var customTags = _corporateTagRepository.GetByCorporateId(accountId);

            return Json(customTags, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetRandomUniqueCampaignCodeInstance()
        {
            var sourceCode = _campaignService.GetRandomUniqueCampaignCodeInstance();
            return Json(sourceCode, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ActivityDetail(long campaignId)
        {
            CampaignAcivityDetailViewModel model = null;
            if (campaignId > 0)
            {
                model = _campaignService.GetCampaignActivity(campaignId);
                return View(model);
            }
            return View(model);
        }

        private bool IsValidActivity(IEnumerable<CampaignActivityEditModel> activities)
        {
            if (activities == null || !activities.Any()) return true;

            var result = false;
            var activity = activities.OrderBy(x => x.Sequence).First();
            result = activity.ActivityType != (long)CampaignActivityType.OutboundCall;

            if (result)
            {
                activity = activities.Where(x => x.ActivityDate.HasValue).OrderBy(x => x.ActivityDate.Value).FirstOrDefault();
                result = activity != null && activity.ActivityType != (long)CampaignActivityType.OutboundCall;
            }

            return result;
        }

        [HttpGet]
        public ActionResult EditPublishedCampaign(long campaignId)
        {
            var camapign = _campaignService.GetPublishedCampaignEditModel(campaignId);
            return PartialView(camapign);
        }

        [HttpPost]
        public ActionResult EditPublishedCampaign(UpdatePublishedCampaignEditModel model)
        {
            if (ModelState.IsValid)
            {
                _campaignService.EditPublishedCampaign(model);

                model.FeedbackMessage = FeedbackMessageModel.CreateWarningMessage("Campaign end date upadted successfully");
            }
            return PartialView(model);
        }

        [HttpPost]
        public JsonResult GetCampaignsForHealthPlan(long healthPlanId)
        {
            var dropDownList = new List<SelectListItem> { new SelectListItem { Text = "-- Select --", Value = "-1" } };

            if (healthPlanId <= 0) return Json(dropDownList);

            var campaigns = _campaignRepository.GetCampaignsByHealthPlanId(healthPlanId).ToArray();
            dropDownList.AddRange(campaigns.Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }));

            return Json(dropDownList);
        }

        [HttpPost]
        public JsonResult GetDirectMailDateForCampaign(long campaignId)
        {
            var dropDownList = new List<SelectListItem> { new SelectListItem { Text = "-- Select --", Value = "-1" } };

            if (campaignId <= 0) return Json(dropDownList);

            var campaigns = _campaignActivityRepository.GetDirectMailActivityDates(campaignId).ToArray();
            dropDownList.AddRange(campaigns.Select(x => new SelectListItem { Text = x.ToString("MM/dd/yyyy"), Value = x.ToString("MM/dd/yyyy") }));

            return Json(dropDownList);
        }
    }
}