using System.Web.Http;
using API.Areas.Application.Controllers;
using Falcon.App.Core.Communication;
using Falcon.App.Core.Communication.ViewModels;

namespace API.Areas.Communication.Controllers
{
    [AllowAnonymous]
    public class WebHookController : BaseController
    {
        private readonly ISmsReceivedNotificationService _notificationService;

        public WebHookController(ISmsReceivedNotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpPost]
        public bool TwillioResponse(TwillioMessageResponse message)
        {
            _notificationService.SmsReceivedNotification(message);
            return true;
        }
    }
}
