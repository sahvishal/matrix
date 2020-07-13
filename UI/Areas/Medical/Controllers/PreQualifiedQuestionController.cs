using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.UI.Filters;
using System;
using System.Web.Mvc;

namespace Falcon.App.UI.Areas.Medical.Controllers
{
    [RoleBasedAuthorize]
    public class PreQualifiedQuestionController : Controller
    {
        private readonly IPreQualifiedQuestionTemplateService _preQualifiedQuestionTemplateService;
        private readonly IPreQualificationQuestionRepository _preQualificationQuestionRepository;
        private readonly ISessionContext _sessionContext;
        private readonly ITestRepository _testRepository;
        private readonly int _pageSize;

        public PreQualifiedQuestionController(ISettings setting, IPreQualifiedQuestionTemplateService preQualifiedQuestionTemplateService, IPreQualificationQuestionRepository preQualificationQuestionRepository, ISessionContext sessionContext, 
            ITestRepository testRepository)
        {
            _preQualifiedQuestionTemplateService = preQualifiedQuestionTemplateService;
            _preQualificationQuestionRepository = preQualificationQuestionRepository;
            _sessionContext = sessionContext;
            _testRepository = testRepository;
            _pageSize = setting.DefaultPageSizeForReports;
        }

        public ActionResult Index(PreQualifiedQuestionTemplateModelFilter filter = null, int pageNumner = 1)
        {
            int totalRecords = 0;
            var model = _preQualifiedQuestionTemplateService.GetPreQualifiedQuestionTemplateListModel(filter, _pageSize, out totalRecords, pageNumner);

            var currentAction = ControllerContext.RouteData.Values["action"].ToString();
            Func<int, string> urlFunc = pn => Url.Action(currentAction, new { pageNumber = pn, filter.Name, filter.TestId });
            model.PagingModel = new PagingModel(pageNumner, _pageSize, totalRecords, urlFunc);

            return View(model);
        }

        public ActionResult Create(long id = 0)
        {
            var model = _preQualifiedQuestionTemplateService.GetbyId(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(PreQualifiedQuestionTemplateEditModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _preQualifiedQuestionTemplateService.SaveTemplate(model, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);

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
            var model = _preQualifiedQuestionTemplateService.GetbyId(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(PreQualifiedQuestionTemplateEditModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _preQualifiedQuestionTemplateService.SaveTemplate(model, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);
                    model.FeedbackMessage = FeedbackMessageModel.CreateSuccessMessage("Template is updated successfully.");
                    return View(model);
                }

                return View(model);
            }
            catch (Exception ex)
            {
                model.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage("System Error:" + ex.Message);
                return View(model);
            }
        }

        public ActionResult View(long id)
        {
            var model = _preQualifiedQuestionTemplateService.GetbyId(id);
            return View(model);
        }

        public JsonResult GetQuestionByTestId(long testId)
        {
            var questions = _preQualificationQuestionRepository.GetByTestId(testId);
            return Json(questions, JsonRequestBehavior.AllowGet);
        }

        [AllowAnonymous]
        public JsonResult GetDependentTests(long testId)
        {
            var dependentTests = _testRepository.GetDependentTests(testId);

            var collection = dependentTests.OrderBy(t => t.Name).Select(dt => new OrderedPair<long, string>
            {
                FirstValue = dt.Id,
                SecondValue = dt.Name
            });

            return Json(collection, JsonRequestBehavior.AllowGet);
        } 
    }
}