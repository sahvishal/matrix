using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using API.Areas.Scheduling.Models;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Scheduling.ViewModels;
using FluentValidation;

namespace API.Areas.Scheduling.Controllers
{
    public class OnSiteRegistrationController : ApiController
    {
        private readonly IEventSchedulingSlotService _eventSchedulingSlotService;
        private readonly IValidator<OnSiteRegistrationEditModel> _onSiteRegistrationModel;
        private readonly IOnSiteRegistrationService _onSiteRegistrationService;

        private readonly ILogger _logger;
        public OnSiteRegistrationController(IEventSchedulingSlotService eventSchedulingSlotService, IValidator<OnSiteRegistrationEditModel> onSiteRegistrationModel, ILogManager logManager, IOnSiteRegistrationService onSiteRegistrationService)
        {
            _eventSchedulingSlotService = eventSchedulingSlotService;
            _onSiteRegistrationModel = onSiteRegistrationModel;
            _onSiteRegistrationService = onSiteRegistrationService;

            _logger = logManager.GetLogger<OnSiteRegistrationController>();
        }

        [HttpGet]
        public IEnumerable<EventSchedulingSlot> GetAppointmentSlots(long eventId)
        {
            return _eventSchedulingSlotService.GetSlots(eventId, AppointmentStatus.Free);
        }

        [HttpPost]
        public OnsiteCustomerRegistrationResponse RegisterCustomer(OnSiteRegistrationEditModel model)
        {
            var customerRegistrationResponse = new OnsiteCustomerRegistrationResponse { IsSuccess = false };
            try
            {
                var result = _onSiteRegistrationModel.Validate(model);

                if (result.IsValid)
                {
                    try
                    {
                        var order = _onSiteRegistrationService.RegisterCustomerOnSite(model);
                        customerRegistrationResponse.AppointmentViewModel = _onSiteRegistrationService.FetchEventCustomerDetail(model.EventId, order.CustomerId);
                        customerRegistrationResponse.IsSuccess = true;
                    }
                    catch (Exception ex)
                    {
                        _logger.Error(string.Format("message : {0} \n stack trace {1}", ex.Message, ex.StackTrace));
                        customerRegistrationResponse.Message = ex.Message;

                    }
                }
                else
                {
                    var firstOrDefault = result.Errors.First();
                    customerRegistrationResponse.Message = firstOrDefault.ErrorMessage;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(string.Format("message : {0} \n stack trace {1}", ex.Message, ex.StackTrace));
            }


            return customerRegistrationResponse;
        }

    }
}
