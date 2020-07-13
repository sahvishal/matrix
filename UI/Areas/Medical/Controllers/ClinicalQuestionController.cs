using System;
using System.Web.Mvc;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.UI.Filters;

namespace Falcon.App.UI.Areas.Medical.Controllers
{
    [RoleBasedAuthorize]
    public class ClinicalQuestionController : Controller
    {
        private readonly int _pageSize;
        private readonly ISessionContext _sessionContext;
        private readonly ILogger _logger;

        private readonly IHealthAssessmentTemplateService _healthAssessmentTemplateService;
        private readonly IClinicalTemplateService _clinicalTemplateService;
        private readonly ICustomerClinicalQuestionAnswerService _customerClinicalQuestionAnswerService;


        public ClinicalQuestionController(ISettings setting, ILogManager logManager, ISessionContext sessionContext, IHealthAssessmentTemplateService healthAssessmentTemplateService,
            IClinicalTemplateService clinicalTemplateService, ICustomerClinicalQuestionAnswerService customerClinicalQuestionAnswerService)
        {
            _sessionContext = sessionContext;
            _pageSize = setting.DefaultPageSizeForReports;
            _logger = logManager.GetLogger<ClinicalQuestionController>();
            _healthAssessmentTemplateService = healthAssessmentTemplateService;
            _clinicalTemplateService = clinicalTemplateService;
            _customerClinicalQuestionAnswerService = customerClinicalQuestionAnswerService;
        }

        public ActionResult Index(HealthAssessmentTemplateListModelFilter filter = null, int pageNumber = 1)
        {
            int totalRecords;
            if (filter == null) filter = new HealthAssessmentTemplateListModelFilter();
            if (filter.Category <= 0)
            {
                filter.Category = (long)HealthAssessmentTemplateCategory.ClinicalQuestions;
            }
            var model = _clinicalTemplateService.GetClinicalTemplate(filter, pageNumber, _pageSize, out totalRecords);

            var currentAction = ControllerContext.RouteData.Values["action"].ToString();
            Func<int, string> urlFunc = pn => Url.Action(currentAction, new { pageNumber = pn, filter.Name, filter.Active, filter.Inactive, filter.TemplateType, filter.Category });
            model.PagingModel = new PagingModel(pageNumber, _pageSize, totalRecords, urlFunc);
            return View(model);
        }

        public ActionResult Create()
        {
            return View(new ClinicalTemplateEditModel { TemplateId = 0, OpenNextTab = false });
        }

        public ActionResult Edit(long id)
        {
            return View(new ClinicalTemplateEditModel { TemplateId = id, OpenNextTab = false });
        }

        public ActionResult EditModel(long id, bool openNextTab = false)
        {
            var model = new ClinicalTemplateEditModel { TemplateId = id, OpenNextTab = openNextTab };
            return PartialView(model);
        }

        public ActionResult QuestionTemplate(long id)
        {
            return PartialView(_healthAssessmentTemplateService.GetHealthAssessmentTemplate(id, (long)HealthAssessmentTemplateCategory.ClinicalQuestions));
        }

        [HttpPost]
        public ActionResult QuestionTemplate(HealthAssessmentTemplateEditModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ModelState.Clear();
                    model = _healthAssessmentTemplateService.SaveTemplate(model, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);
                    model.FeedbackMessage = FeedbackMessageModel.CreateSuccessMessage("Template is created successfully. You can create more templates or close this page.");
                    return PartialView("QuestionTemplateEditModel", model);
                }
                return PartialView("QuestionTemplateEditModel", model);
            }
            catch (Exception ex)
            {
                _logger.Error(string.Format("System Error: exception- {0} \n stacktrace: {1} ", ex.Message, ex.StackTrace));
                model.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage("System Error:" + ex);
                return PartialView("QuestionTemplateEditModel", model);
            }
        }

        public ActionResult TemplateCriteria(long templateId)
        {
            return PartialView(_clinicalTemplateService.GetTemplateCriteriaEditModel(templateId));
        }

        [HttpPost]
        public ActionResult TemplateCriteria(TemplateCriteriaEditModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _clinicalTemplateService.SaveCriteria(model, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);
                    model.FeedbackMessage = FeedbackMessageModel.CreateSuccessMessage("Updated Successfully");
                }
                else
                {
                    model.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage("Validation Fails");
                }
            }
            catch (Exception ex)
            {
                _logger.Error(string.Format("System Error: exception- {0} \n stacktrace: {1} ", ex.Message, ex.StackTrace));
                model.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage("System Error:" + ex);
            }

            return PartialView("TemplateCriteriaEditModel", model);
        }

        public ActionResult GetClinicalQuestion(string guid, long customerId, long eventId, long clinicalQuestionTemplateId,long eventCustomerId= 0)
        {
            var model = _customerClinicalQuestionAnswerService.Get(guid, customerId, eventId, clinicalQuestionTemplateId, eventCustomerId);
            return View(model);
        }

        [HttpPost]
        public ActionResult SaveClinicalQuestion(HealthAssessmentEditModel model, string guid, long clinicalQuestionTemplateId)
        {
            _customerClinicalQuestionAnswerService.Save(model, guid, clinicalQuestionTemplateId, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);

            return Json(new { Result = true, Message = "" });
        }

        [HttpGet]
        public ActionResult GetRecommendations(string guid, long customerId, long eventId)
        {
            var recommendedTestNames = _customerClinicalQuestionAnswerService.RecommendTestToCustomer(guid, customerId, eventId);

            return Json(new { Result = recommendedTestNames, Message = "" }, JsonRequestBehavior.AllowGet);
        }

    }
}