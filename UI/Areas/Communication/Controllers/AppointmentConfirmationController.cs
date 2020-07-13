using System.Web.Mvc;
using Falcon.App.Core.Communication;
using Falcon.App.DependencyResolution;
using Falcon.App.UI.Filters;

namespace Falcon.App.UI.Areas.Communication.Controllers
{
    public class AppointmentConfirmationController : Controller
    {
        //
        // GET: /Communication/AppointmentConfirmation/

        private IEmailNotificationModelsFactory _emailNotificationModelsFactory;

        public AppointmentConfirmationController()
        {
            _emailNotificationModelsFactory = IoC.Resolve<IEmailNotificationModelsFactory>();
        }

        [RoleBasedAuthorize]
        public ActionResult Index(long eventId, long customerId)
        {
            var appointmentConfirmationViewModel =
                _emailNotificationModelsFactory.GetAppointmentConfirmationModel(eventId, customerId);
            return View(appointmentConfirmationViewModel);
        }
        [AllowAnonymous]
        public ActionResult Online(long eventId, long customerId)
        {
            var appointmentConfirmationViewModel =
                _emailNotificationModelsFactory.GetAppointmentConfirmationModel(eventId, customerId);
            return View(appointmentConfirmationViewModel);
        }
    }
}
