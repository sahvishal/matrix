using System.Web.Http;
using API.Areas.Application.Controllers;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Scheduling.ViewModels;

namespace API.Areas.Scheduling.Controllers
{
    [AllowAnonymous]
    public class OnlineConfirmationController : BaseController
    {
        private readonly ITempcartService _tempcartService;
        private readonly IEventRepository _eventRepository;
        
        public OnlineConfirmationController(ITempcartService tempcartService, IEventRepository eventRepository)
        {
            _tempcartService = tempcartService;
            _eventRepository = eventRepository;
        }

        [HttpGet]
        public OnlineAppointmentConfirmation GetAppointmentConfirmation(string guid)
        {
            var model = new OnlineAppointmentConfirmation
            {
                RequestValidationModel = _tempcartService.ValidateOnlineRequest(guid)
            };

            if (model.RequestValidationModel.RequestStatus != OnlineRequestStatus.Completed)
                return model;
            var tempCart = model.RequestValidationModel.TempCart;

            var eventData = _eventRepository.GetById(tempCart.EventId.Value);
            model.EventType = eventData.EventType;
            

            return model;
        }

    }
}
