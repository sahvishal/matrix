using System.Web.Mvc;

namespace Falcon.SPA.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CallCenterRep()
        {
            return PartialView();
        }
	}
}