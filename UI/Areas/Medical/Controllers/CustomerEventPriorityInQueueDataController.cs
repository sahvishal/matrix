using System.Web.Mvc;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.UI.Filters;

namespace Falcon.App.UI.Areas.Medical.Controllers
{
    [RoleBasedAuthorize]
    public class CustomerEventPriorityInQueueDataController : Controller
    {
        private readonly ITestResultService _testResultService;

        public CustomerEventPriorityInQueueDataController(ITestResultService testResultService)
        {
            _testResultService = testResultService;
        }

        public ActionResult Edit(long theeventId, long thecustomerId, long thetestId)
        {
            PriorityInQueueTestEditModel model = _testResultService.GetPriorityInQueueTestEditModel(theeventId, thecustomerId, thetestId);
            return View(model);
        }

    }
}