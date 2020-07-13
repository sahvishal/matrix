using System.Web.Mvc;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.UI.Filters;

namespace Falcon.App.UI.Areas.Medical.Controllers
{
    [RoleBasedAuthorize]
    public class PrimaryCarePhysicianController : Controller
    {
        private readonly IPrimaryCarePhysicianImportService _physicianImportService;

        public PrimaryCarePhysicianController(IPrimaryCarePhysicianImportService physicianImportService)
        {
            _physicianImportService = physicianImportService;
        }

        public ActionResult SearchPcp(string firstName, string lastName, string zipcode, int pageNumber)
        {
            int totalRecords;
            int pageSize = 10;
            var model = _physicianImportService.SearchPcp(firstName, lastName, zipcode, pageNumber,pageSize,out totalRecords) ??
                        new PhysicianMasterListModel();

            model.PagingModel = new PagingModel(pageNumber, pageSize, totalRecords, null);
            return View(model);
        }
    }
}