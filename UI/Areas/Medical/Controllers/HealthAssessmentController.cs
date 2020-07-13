using System;
using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.UI.Filters;

namespace Falcon.App.UI.Areas.Medical.Controllers
{
    [RoleBasedAuthorize]
    public class HealthAssessmentController : Controller
    {
        private readonly int _pageSize;
        private readonly IHealthAssessmentTemplateRepository _healthAssessmentTemplateRepository;
        private readonly ISessionContext _sessionContext;
        private readonly IHospitalPartnerRepository _hospitalPartnerRepository;
        private readonly IHealthAssessmentRepository _healthAssessmentRepository;
        private readonly IHealthAssessmentTemplateService _healthAssessmentTemplateService;
        private readonly IClinicalQuestionsHealthAssessmentHelper _clinicalQuestionsHealthAssessmentHelper;


        public HealthAssessmentController(ISettings setting, IHealthAssessmentTemplateRepository healthAssessmentTemplateRepository, ISessionContext sessionContext, IHospitalPartnerRepository hospitalPartnerRepository,
            IHealthAssessmentRepository healthAssessmentRepository, IHealthAssessmentTemplateService healthAssessmentTemplateService, IClinicalQuestionsHealthAssessmentHelper clinicalQuestionsHealthAssessmentHelper)
        {
            _pageSize = setting.DefaultPageSizeForReports;
            _healthAssessmentTemplateRepository = healthAssessmentTemplateRepository;
            _sessionContext = sessionContext;
            _hospitalPartnerRepository = hospitalPartnerRepository;
            _healthAssessmentRepository = healthAssessmentRepository;
            _healthAssessmentTemplateService = healthAssessmentTemplateService;
            _clinicalQuestionsHealthAssessmentHelper = clinicalQuestionsHealthAssessmentHelper;
        }
        //
        // GET: /Medical/HealthAssessment/

        public ActionResult Index(HealthAssessmentTemplateListModelFilter filter = null, int pageNumber = 1)
        {
            int totalRecords;
            if (filter == null) filter = new HealthAssessmentTemplateListModelFilter();
            if (filter.Category <= 0)
            {
                filter.Category = (long)HealthAssessmentTemplateCategory.HealthAssessmentTemplate;
            }
            var templates = _healthAssessmentTemplateRepository.GetHealthAssessmentTemplate(filter, pageNumber, _pageSize, out totalRecords);
            var model = new HealthAssessmentTemplateListModel
                            {
                                HealthAssessmentTemplates = Mapper.Map<IEnumerable<HealthAssessmentTemplate>, IEnumerable<HealthAssessmentTemplateViewModel>>(templates)
                            };


            model.Filter = filter;

            var currentAction = ControllerContext.RouteData.Values["action"].ToString();
            Func<int, string> urlFunc = pn => Url.Action(currentAction, new { pageNumber = pn, filter.Name, filter.Active, filter.Inactive, filter.TemplateType, filter.Category });
            model.PagingModel = new PagingModel(pageNumber, _pageSize, totalRecords, urlFunc);

            return View(model);
        }

        public ActionResult SetTemplateIsActiveState(long templateId, bool isActive)
        {
            var template = _healthAssessmentTemplateRepository.GetById(templateId);

            if (template.IsDefault && template.IsPublished && template.TemplateType.HasValue && template.TemplateType.Value == (long)HealthAssessmentTemplateType.Event)
                return Json(new { IsSuccess = false, Message = "Template can not be deactivated since it default template for event. To deactivate it, Please make another template as default and publish it." }, JsonRequestBehavior.AllowGet);

            template.IsActive = isActive;
            _healthAssessmentTemplateRepository.Save(template);
            return Json(new { IsSuccess = true, Message = isActive ? "Template activated successfully." : "Template deactivated successfully." }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Create(long templateId = 0)
        {
            return View(_healthAssessmentTemplateService.GetHealthAssessmentTemplate(templateId, (long)HealthAssessmentTemplateCategory.HealthAssessmentTemplate));
        }

        [HttpPost]
        public ActionResult Create(HealthAssessmentTemplateEditModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _healthAssessmentTemplateService.SaveTemplate(model, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);
                    model.FeedbackMessage = FeedbackMessageModel.CreateSuccessMessage("Template is created successfully. You can create more templates or close this page.");
                    return View(model);
                }
                return View(model);
            }
            catch (Exception ex)
            {
                model.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage("System Error:" + ex);
                return View(model);
            }
        }

        public ActionResult Edit(long id)
        {
            var template = _healthAssessmentTemplateRepository.GetById(id);
            var model = Mapper.Map<HealthAssessmentTemplate, HealthAssessmentTemplateEditModel>(template);

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(HealthAssessmentTemplateEditModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _healthAssessmentTemplateService.SaveTemplate(model, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);
                    model.FeedbackMessage = FeedbackMessageModel.CreateSuccessMessage("Template is edited successfully.");
                    return View(model);
                }
                return View(model);
            }
            catch (Exception ex)
            {
                model.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage("System Error:" + ex);
                return View(model);
            }
        }

        [HttpPost]
        public JsonResult GetHealthAssessmentTemplateForEvent(long hospitalPartnerId)
        {
            var templateList = new List<HealthAssessmentTemplateViewModel>();
            if (hospitalPartnerId > 0)
            {
                var hospitalPartner = _hospitalPartnerRepository.GetHospitalPartnerforaVendor(hospitalPartnerId);
                if (hospitalPartner != null && hospitalPartner.HealthAssessmentTemplateId.HasValue && hospitalPartner.HealthAssessmentTemplateId.Value > 0)
                {
                    var template = _healthAssessmentTemplateRepository.GetById(hospitalPartner.HealthAssessmentTemplateId.Value);
                    template.IsDefault = true;
                    var viewModel = Mapper.Map<HealthAssessmentTemplate, HealthAssessmentTemplateViewModel>(template);
                    templateList.Add(viewModel);
                }
            }

            var templates = _healthAssessmentTemplateRepository.GetByType(HealthAssessmentTemplateType.Event);
            if (templateList.Count > 0)
            {
                foreach (var healthAssessmentTemplate in templates)
                {
                    healthAssessmentTemplate.IsDefault = false;
                }
            }
            var viewModels = Mapper.Map<IEnumerable<HealthAssessmentTemplate>, IEnumerable<HealthAssessmentTemplateViewModel>>(templates);

            templateList.AddRange(viewModels);


            return Json(templateList, JsonRequestBehavior.AllowGet);
        }

        public ActionResult View(long id)
        {
            var template = _healthAssessmentTemplateRepository.GetById(id);
            var questions = _healthAssessmentRepository.GetByIds(template.QuestionIds);
            var questionModelCollection = Mapper.Map<IEnumerable<HealthAssessmentQuestion>, IEnumerable<HealthAssessmentQuestionEditModel>>(questions);

            var model = new HealthAssessmentEditModel
            {
                QuestionEditModels = questionModelCollection
            };

            if (template.Category == (long)HealthAssessmentTemplateCategory.ClinicalQuestions)
            {
                _clinicalQuestionsHealthAssessmentHelper.SetRecommendationLogic(id, model);
            }

            return View(model);
        }

    }
}
