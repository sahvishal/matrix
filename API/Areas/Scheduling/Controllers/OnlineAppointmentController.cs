using System.Linq;
using API.Areas.Application.Controllers;
using Falcon.App.Core.Marketing;
using Falcon.App.Core.Scheduling;
using System.Web.Http;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Scheduling.ViewModels;

namespace API.Areas.Scheduling.Controllers
{
    [AllowAnonymous]
    public class OnlineAppointmentController : BaseController
    {
        private readonly ITempcartService _tempcartService;
        private readonly IOnlineAppointmentService _onlineAppointmentService;
        private readonly IOnlinePackageService _onlinePackageService;


        public OnlineAppointmentController(ITempcartService tempcartService, IOnlineAppointmentService onlineAppointmentService, IOnlinePackageService onlinePackageService)
        {
            _tempcartService = tempcartService;
            _onlineAppointmentService = onlineAppointmentService;
            _onlinePackageService = onlinePackageService;
        }

        [HttpGet]
        public EventAppointmentOnlineListModel GetEventAppointmentSlotOnline(string guid)
        {
            var onlineRequestValidationModel = _tempcartService.ValidateOnlineRequest(guid);

            if (onlineRequestValidationModel.RequestStatus != OnlineRequestStatus.Valid)
                return new EventAppointmentOnlineListModel() { RequestValidationModel = onlineRequestValidationModel };

            var model = _onlineAppointmentService.GetEventAppointmentSlotOnline(onlineRequestValidationModel.TempCart);
            model.RequestValidationModel = onlineRequestValidationModel;

            var tempCart = onlineRequestValidationModel.TempCart;
            if (tempCart.EventId.HasValue && tempCart.EventId > 0 && tempCart.EventPackageId.HasValue)
            {
                var allAdditionalTests = _onlinePackageService.GetAdditionalTest(tempCart);
                model.IsAdditionalTestAvailable = allAdditionalTests != null && allAdditionalTests.Any();
                model.UpsellTestAvailable = _onlinePackageService.IsUpsellTestAvailable(tempCart);
            }
            return model;
        }

        [HttpPost]
        public EventAppointmentOnlineListModel SaveEventAppointmentSlotOnline(EventAppointmentOnlineListModel model)
        {
            var onlineRequestValidationModel = _tempcartService.ValidateOnlineRequest(model.Guid);

            if (onlineRequestValidationModel.RequestStatus != OnlineRequestStatus.Valid)
                return new EventAppointmentOnlineListModel() { RequestValidationModel = onlineRequestValidationModel };

            onlineRequestValidationModel.TempCart.AppointmentId = model.SelectedSlotId;
            model = _onlineAppointmentService.SaveEventAppointmentSlotOnline(onlineRequestValidationModel.TempCart);
            model.RequestValidationModel = onlineRequestValidationModel;

            return model;
        }
    }
}
