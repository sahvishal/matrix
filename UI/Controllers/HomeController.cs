using System.Web.Mvc;
using Falcon.App.Core.Geo.ViewModels;

namespace Falcon.App.UI.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View(new ZipSearchModel { Radius = 25 });
        }

        [HttpPost]
        public ActionResult Index(ZipSearchModel zipSearchModel)
        { 
            return RedirectToAction("LocationAndAppointmentSlot", "Online", new { Area = "Scheduling", Radius = zipSearchModel.Radius, ZipCode = zipSearchModel.ZipCode });
        }

        public ActionResult ThankYou()
        {
            return View();
        }

        public ActionResult UnauthorizeAccess()
        {
            return View();
        }
        public ActionResult Error()
        {
            return View();
        }
    }
}
