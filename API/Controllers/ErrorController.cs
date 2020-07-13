using System;
using System.Web.Mvc;

namespace API.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult General(Exception exception)
        {
            return Content(exception.Message, "text/plain");
        }

        public ActionResult Http404()
        {
            return Content("Not found", "text/plain");
        }

        public ActionResult Http403()
        {
            return Content("Forbidden", "text/plain");
        }

        public ActionResult Http401()
        {
            return Content("Unauthorized access", "text/html");
        }
    }
}
