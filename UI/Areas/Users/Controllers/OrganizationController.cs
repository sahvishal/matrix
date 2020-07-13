using System.Web.Mvc;
using Falcon.App.UI.Filters;

namespace Falcon.App.UI.Areas.Users.Controllers
{
    [RoleBasedAuthorize]
    public class OrganizationController : Controller
    {
      
        //
        // GET: /Users/Organization/Create
        public ActionResult Create()
        {
            return View();
        }       
      
    }
}
