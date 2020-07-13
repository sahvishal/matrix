using Falcon.App.Core.Application;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.UI.Filters;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Falcon.App.UI.Areas.Medical.Controllers
{
    [RoleBasedAuthorize]
    public class SurveyController : Controller
    {
        private readonly ISurveyTemplateService _SurveyTemplateService;
        private readonly ISessionContext _sessionContext;
        private readonly int _pageSize;

        public SurveyController(ISettings setting, ISurveyTemplateService SurveyTemplateService, ISessionContext sessionContext)
        {
            _SurveyTemplateService = SurveyTemplateService;
            _sessionContext = sessionContext;
            _pageSize = setting.DefaultPageSizeForReports;
        }

        public ActionResult Index(SurveyTemplateModelFilter filter = null, int pageNumber = 1)
        {
            var totalRecords = 0;
            var list = _SurveyTemplateService.GetSurveyTemplateList(filter, pageNumber, _pageSize, out totalRecords);

            var currentAction = ControllerContext.RouteData.Values["action"].ToString();
            Func<int, string> urlFunc = pn => Url.Action(currentAction, new { pageNumber = pn, filter.Name });
            var model = new SurveyTemplateListModel
            {
                Filter = filter,
                PagingModel = new PagingModel(pageNumber, _pageSize, totalRecords, urlFunc),
                Templates = list
            };

            return View(model);
        }

        public ActionResult Create(long templateId = 0)
        {
            return View(_SurveyTemplateService.GetbyId(templateId));
        }

        [HttpPost]
        public ActionResult Create(SurveyTemplateEditModel model)
        {
            try
            {
                var newModel = _SurveyTemplateService.GetbyId(model.Id);
                var questionsIds = model.Questions != null && model.Questions.Any() ? model.Questions.Select(x => x.Id) : null;

                newModel.Questions.ForEach(x => { x.IsSelected = questionsIds != null && questionsIds.Contains(x.Id) ? true : false; });
                model.Questions = newModel.Questions;

                if (ModelState.IsValid)
                {
                    _SurveyTemplateService.SaveTemplate(model, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);

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
            return View(_SurveyTemplateService.GetbyId(id));
        }

        [HttpPost]
        public ActionResult Edit(SurveyTemplateEditModel model)
        {
            try
            {
                var newModel = _SurveyTemplateService.GetbyId(model.Id);
                var questionsIds = model.Questions != null && model.Questions.Any() ? model.Questions.Select(x => x.Id) : null;

                newModel.Questions.ForEach(x => { x.IsSelected = questionsIds != null && questionsIds.Contains(x.Id) ? true : false; });
                model.Questions = newModel.Questions;

                if (ModelState.IsValid)
                {
                    _SurveyTemplateService.SaveTemplate(model, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);
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
            return View(_SurveyTemplateService.ViewTemplate(templateId));
        }

    }
}
