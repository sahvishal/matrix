using System.Web.Mvc;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.UI.Filters;

namespace Falcon.App.UI.Areas.FileManager.Controllers
{
    [RoleBasedAuthorize]
    public class DisplayController : Controller
    {
        //
        // GET: /FileManager/Display/

        public ActionResult Index()
        {
            return PartialView("FileView", new FileModel());
        }

    }
}
