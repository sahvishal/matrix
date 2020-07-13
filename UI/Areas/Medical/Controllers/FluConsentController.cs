using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.ViewModels;

namespace Falcon.App.UI.Areas.Medical.Controllers
{
    [AllowAnonymous]
    public class FluConsentController : Controller
    {
        private readonly IFluConsentService _fluConsentService;
        private readonly IFluConsentQuestionRepository _fluConsentQuestionRepository;

        private readonly ISessionContext _sessionContext;
        private readonly int _pageSize;
        private readonly ILogger _logger;
        private readonly ISettings _settings;

        public FluConsentController(ISettings setting, ISessionContext sessionContext, ILogManager logManager, IFluConsentService fluConsentService, ISettings settings, IFluConsentQuestionRepository fluConsentQuestionRepository)
        {
            _sessionContext = sessionContext;
            _fluConsentService = fluConsentService;
            _settings = settings;
            _fluConsentQuestionRepository = fluConsentQuestionRepository;
            _pageSize = setting.DefaultPageSizeForReports;
            _logger = logManager.GetLogger("FluConsent");
        }


        public ActionResult Index(FluConsentTemplateModelFilter filter = null, int pageNumber = 1)
        {
            return View(GetFluConsentTemplateListModel(filter, pageNumber));
        }

        private FluConsentTemplateListModel GetFluConsentTemplateListModel(FluConsentTemplateModelFilter filter, int pageNumber)
        {
            int totalRecords;
            var model = _fluConsentService.GetFluConsentTemplateList(filter, pageNumber, _settings.DefaultPageSizeForReports, out totalRecords);

            var currentAction = ControllerContext.RouteData.Values["action"].ToString();
            Func<int, string> urlFunc = pn => Url.Action(currentAction, new { pageNumber = pn, filter.Name, filter.Active, filter.HealthPlanId });

            if (model != null)
            {
                model.PagingModel = new PagingModel(pageNumber, _pageSize, totalRecords, urlFunc);
                return model;
            }

            return new FluConsentTemplateListModel
            {
                Collection = new List<FluConsentTemplateViewModel>(),
                Filter = new FluConsentTemplateModelFilter()
            };
        }

        public ActionResult Create()
        {
            var model = new FluConsentTemplateEditModel();

            var questions = _fluConsentQuestionRepository.GetAllQuestions();

            model.Questions = questions.Select(x => new FluConsentQuestionEditModel
            {
                QuestionId = x.Id,
                ParentId = x.ParentId,
                Index = x.Index,
                Question = x.Question
            }).ToArray();

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(FluConsentTemplateEditModel model)
        {
            try
            {
                _fluConsentService.Save(model, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);
                model.FeedbackMessage = FeedbackMessageModel.CreateSuccessMessage("Template saved successfully.");
                return View(model);
            }
            catch (Exception ex)
            {
                _logger.Info(ex.Message);
                model.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage("Error : " + ex.Message);
                return View(model);
            }
        }

        public ActionResult Edit(long id)
        {
            var model = _fluConsentService.GetTemplateById(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(FluConsentTemplateEditModel model)
        {
            try
            {
                _fluConsentService.Save(model, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);
                model.FeedbackMessage = FeedbackMessageModel.CreateSuccessMessage("Template saved successfully.");
                return View(model);
            }
            catch (Exception ex)
            {
                _logger.Info(ex.Message);
                model.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage("Error : " + ex.Message);
                return View(model);
            }
        }

        public ActionResult View(long templateId)
        {
            return View();
        }

    }
}
