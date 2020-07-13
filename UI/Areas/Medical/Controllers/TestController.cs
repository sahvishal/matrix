using System;
using System.Web.Mvc;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.UI.Filters;

namespace Falcon.App.UI.Areas.Medical.Controllers
{
    [RoleBasedAuthorize]
    public class TestController : Controller
    {
        //
        // GET: /Medical/Test/
        private readonly int _pageSize;
        private readonly ITestService _testService;
        private readonly IUserService _userService;

        public TestController(ISettings settings, ITestService testService, IUserService userService)
        {
            _pageSize = settings.DefaultPageSizeForReports;
            _testService = testService;
            _userService = userService;
        }

        public ActionResult Index(TestListModelFilter filter = null, int pageNumber = 1)
        {
            int totalRecords = 0;
            var model = _testService.GetAllTest(pageNumber, _pageSize, filter, out totalRecords);

            if (model == null) model = new TestListModel();

            model.Filter = filter;

            var currentAction = ControllerContext.RouteData.Values["action"].ToString();
            Func<int, string> urlFunc =
                pn => Url.Action(currentAction, new { pageNumber = pn, filter.Name });
            model.PagingModel = new PagingModel(pageNumber, _pageSize, totalRecords, urlFunc);

            return View(model);
        }

        public ActionResult Edit(long id)
        {
            var model = _testService.GetTestEditModel(id);
            SetRoles(model);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(TestEditModel testEditmodel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    testEditmodel.DateModified = DateTime.Now;
                    if (testEditmodel.PreQualificationQuestionTemplateId <= 0)
                        testEditmodel.PreQualificationQuestionTemplateId = null;
                    _testService.SaveTestEditModel(testEditmodel);
                    testEditmodel.FeedbackMessage = FeedbackMessageModel.CreateSuccessMessage(string.Format("The test {0} was saved successfully.", testEditmodel.Name));
                }
                SetRoles(testEditmodel);
                return View(testEditmodel);
            }
            catch (Exception exception)
            {
                SetRoles(testEditmodel);
                testEditmodel.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage("System Error:" + exception.Message);
                return View(testEditmodel);
            }
        }

        private void SetRoles(TestEditModel model)
        {
            model.Roles = _userService.GetRoleswithRegistrationEnabled();
        }

    }
}
