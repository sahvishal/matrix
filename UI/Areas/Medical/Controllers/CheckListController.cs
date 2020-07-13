using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.UI.Filters;
using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.UI.Areas.Medical.Controllers
{
    [RoleBasedAuthorize]
    public class CheckListController : Controller
    {
        private readonly ICheckListTemplateRepository _checkListTemplateRepository;
        private readonly ICorporateAccountRepository _corporateAccountRepository;
        private readonly ICheckListTemplateService _checkListTemplateService;
        private readonly ISessionContext _sessionContext;
        private readonly int _pageSize;

        public CheckListController(ISettings setting, ICheckListTemplateRepository checkListTemplateRepository, ICorporateAccountRepository corporateAccountRepository,
            ICheckListTemplateService checkListTemplateService, ISessionContext sessionContext)
        {
            _checkListTemplateRepository = checkListTemplateRepository;
            _corporateAccountRepository = corporateAccountRepository;
            _checkListTemplateService = checkListTemplateService;
            _sessionContext = sessionContext;
            _pageSize = setting.DefaultPageSizeForReports;
        }

        //
        // GET: /Medical/HealthAssessment/

        public ActionResult Index(CheckListTemplateModelFilter filter = null, int pageNumber = 1)
        {
            return View(GetCheckListTemplateListModel(filter, pageNumber));
        }

        private CheckListTemplateListModel GetCheckListTemplateListModel(CheckListTemplateModelFilter filter, int pageNumber = 1)
        {
            var totalRecords = 0;
            var templates = _checkListTemplateRepository.GetTemplatesByFilters(filter, pageNumber, _pageSize, out  totalRecords);
            var healthPlans = _corporateAccountRepository.GetByChecklistTemplateIds(templates.Select(x => x.Id));
            var list = new List<CheckListTemplateViewModel>();

            foreach (var checkListTemplate in templates)
            {
                var healthPlanName = "N/A";
                var checklisthealthPlans = healthPlans.Where(x => x.CheckListTemplateId == checkListTemplate.Id);
                if (!checklisthealthPlans.IsNullOrEmpty())
                    healthPlanName = string.Join(", ", checklisthealthPlans.Select(x => x.Name));
                
                string typeName = string.Empty;
                var checklistType = CheckListType.CheckList.GetNameValuePairs().FirstOrDefault(x => x.FirstValue == checkListTemplate.Type);
                typeName = checklistType == null ? "N/A" : checklistType.SecondValue;

                list.Add(new CheckListTemplateViewModel
                {
                    Name = checkListTemplate.Name,
                    HealthPlan = healthPlanName,
                    Id = checkListTemplate.Id,
                    IsActive = checkListTemplate.IsActive,
                    IsPublished = checkListTemplate.IsPublished,
                    Type = typeName

                });
            }
            var currentAction = ControllerContext.RouteData.Values["action"].ToString();
            Func<int, string> urlFunc = pn => Url.Action(currentAction, new { pageNumber = pn, filter.Name, filter.Active, filter.Inactive, filter.HealthPlanId });
            return new CheckListTemplateListModel
            {
                Filter = filter,
                PagingModel = new PagingModel(pageNumber, _pageSize, totalRecords, urlFunc),
                Templates = list
            };
        }

        public ActionResult Create(long templateId = 0)
        {
            return View(_checkListTemplateService.GetbyId(templateId));
        }

        [HttpPost]
        public ActionResult Create(CheckListTemplateEditModel model)
        {
            try
            {
                var newModel = _checkListTemplateService.GetbyId(model.Id);
                var questionsIds = model.Questions != null && model.Questions.Any() ? model.Questions.Select(x => x.Id) : null;

                newModel.Questions.ForEach(x => { x.IsSelected = questionsIds != null && questionsIds.Contains(x.Id) ? true : false; });
                model.Questions = newModel.Questions;

                if (ModelState.IsValid)
                {
                    _checkListTemplateService.SaveTemplate(model, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);

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
            return View(_checkListTemplateService.GetbyId(id));
        }

        [HttpPost]
        public ActionResult Edit(CheckListTemplateEditModel model)
        {
            try
            {
                var newModel = _checkListTemplateService.GetbyId(model.Id);
                var questionsIds = model.Questions != null && model.Questions.Any() ? model.Questions.Select(x => x.Id) : null;

                newModel.Questions.ForEach(x => { x.IsSelected = questionsIds != null && questionsIds.Contains(x.Id) ? true : false; });
                model.Questions = newModel.Questions;

                if (ModelState.IsValid)
                {
                    _checkListTemplateService.SaveTemplate(model, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);
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

        public ActionResult View(long templateId)
        {
            return View(_checkListTemplateService.ViewTemplate(templateId));
        }

    }
}
