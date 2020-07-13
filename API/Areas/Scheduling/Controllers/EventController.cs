using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using API.Areas.Scheduling.Models;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Scheduling.ViewModels;

namespace API.Areas.Scheduling.Controllers
{

    public class EventController : ApiController
    {
        private readonly IEventCustomerBriefListService _eventCustomerBriefListService;
        private readonly ILogger _logger;
        private readonly IEventService _eventService;
        private readonly ISessionContext _sessionContext;
        private readonly IEventCustomerRepository _eventCustomerRepository;

        public EventController(ILogManager logManager, IEventCustomerBriefListService eventCustomerBriefListService, IEventService eventService, ISessionContext sessionContext, IEventCustomerRepository eventCustomerRepository)
        {
            _eventCustomerBriefListService = eventCustomerBriefListService;
            _eventService = eventService;
            _sessionContext = sessionContext;
            _eventCustomerRepository = eventCustomerRepository;
            _logger = logManager.GetLogger<EventController>();
        }


        [HttpGet]
        public MobileResponseModel FetchEvents([FromUri]EventSearchModelFilter filter)
        {
            MobileResponseModel model;
            try
            {
                if (_sessionContext.UserSession == null || _sessionContext.UserSession.CurrentOrganizationRole == null)
                {
                    throw new Exception("Invalid User");
                }

                filter = filter ?? new EventSearchModelFilter();

                filter.StaffId = _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId;
                filter.FromDate = DateTime.Today;
                filter.ToDate = DateTime.Today;
                var data = _eventService.GetEventBasicInfoForStaff(filter) ?? new List<ShortEventInfoViewModel>();

                model = new MobileResponseModel
                {
                    IsSuccess = true,
                    Data = data
                };
            }
            catch (Exception exception)
            {
                _logger.Error(string.Format("While Fetch Events Message:{0} \\n Stack Trace:{1}", exception.Message, exception.StackTrace));

                model = new MobileResponseModel
                {
                    IsSuccess = false,
                    Message = exception.Message,
                    Data = null
                };
            }

            return model;
        }

        [HttpGet]
        public MobileResponseModel FetchCustomerForEvent([FromUri]long eventId)
        {
            MobileResponseModel eventCustomerListModel;
            try
            {
                var data = _eventCustomerBriefListService.GetPatientsByEventyId(eventId);

                eventCustomerListModel = new MobileResponseModel
                {
                    IsSuccess = true,
                    Data = data,
                    StatusCode = 200
                };
            }
            catch (Exception exception)
            {
                _logger.Error(string.Format("while FetchCustomerForEvent Message:{0} \\n Stack Trace:{1}", exception.Message, exception.StackTrace));

                eventCustomerListModel = new MobileResponseModel
                {
                    IsSuccess = false,
                    Message = exception.Message,
                    StatusCode = 500,
                    Data = null
                };
            }

            return eventCustomerListModel;
        }

        [HttpPost]
        public MobileResponseModel UpdateCheckInCheckOutTime(CustomerCheckInCheckOutTimeModel model)
        {
            var result = new MobileResponseModel { IsSuccess = false };
            try
            {
                var isUpdated = _eventCustomerBriefListService.UpdateCheckinCheckOutTime(model.EventCustomerId, model.AppointmentId, model.CheckInTime, model.CheckOutTime);
                if (isUpdated)
                    result.IsSuccess = true;
                else
                {
                    result.IsSuccess = false;
                    result.Message = "Checkin/Checkout time update failed.";
                }
            }
            catch (Exception exception)
            {
                _logger.Error(string.Format("While Updating Checkin/Checkout Time Message: {0} \n Stack Trace {1}", exception.Message, exception.StackTrace));
                result.IsSuccess = false;
                result.Message = exception.Message;
            }
            return result;
        }

        [HttpPost]
        public MobileResponseModel UpdateCustomerConsentList(EventCustomerConsentsListModel customersConsentListModel)
        {
            if (customersConsentListModel != null && customersConsentListModel.CustomersConsent != null && customersConsentListModel.CustomersConsent.Any())
            {
                try
                {
                    var data = customersConsentListModel.CustomersConsent.Select(eventCustomerConsent => _eventCustomerBriefListService.UpdateConsentsStatusforEventIdCustomerId(eventCustomerConsent)).ToList();

                    return new MobileResponseModel
                    {
                        IsSuccess = true,
                        Data = data
                    };
                }
                catch (Exception ex)
                {
                    _logger.Info(string.Format("While updating consent for multiple customers. \n Message : {0} \n Stack Trace : {1}", ex.Message, ex.StackTrace));

                    return new MobileResponseModel
                    {
                        IsSuccess = true,
                        Message = ex.Message
                    };
                }
            }
            return new MobileResponseModel
            {
                IsSuccess = false,
                Message = "No data found for consent update."
            };
        }

        [HttpPost]
        public MobileResponseModel UpdateCustomerConsent(EventCustomerConsents customersConsent)
        {
            try
            {
                var data = _eventCustomerBriefListService.UpdateConsentsStatusforEventIdCustomerId(customersConsent);

                return new MobileResponseModel
                {
                    IsSuccess = true,
                    Data = data
                };
            }
            catch (Exception ex)
            {
                _logger.Info(string.Format("While updating consent for multiple customers. \n Message : {0} \n Stack Trace : {1}", ex.Message, ex.StackTrace));

                return new MobileResponseModel
                {
                    IsSuccess = true,
                    Message = ex.Message
                };
            }
        }

        [HttpPost]
        public MobileResponseModel UpdateHipaaConsent([FromBody]ConsentUpdateModel model)
        {
            try
            {
                var isUpdated = _eventCustomerRepository.UpdateHippaStatus(model.EventCustomerId, model.Status);
                if (isUpdated)
                {
                    return new MobileResponseModel
                    {
                        IsSuccess = true,
                        Message = "Hipaa Consent updated successfully."
                    };
                }
                else
                {
                    return new MobileResponseModel
                    {
                        IsSuccess = true,
                        Message = "Unable to update Hipaa Consent."
                    };
                }
            }
            catch (Exception ex)
            {
                _logger.Info(string.Format("While updating Hipaa Consent for EventCustomer ID : {0}. \n Message : {1} \n Stack Trace : {2}", model.EventCustomerId, ex.Message, ex.StackTrace));

                return new MobileResponseModel
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }

        [HttpPost]
        public MobileResponseModel UpdatePcpConsent([FromBody]ConsentUpdateModel model)
        {
            try
            {
                var isUpdated = _eventCustomerRepository.UpdatePcpConsentStatus(model.EventCustomerId, model.Status);
                if (isUpdated)
                {
                    return new MobileResponseModel
                    {
                        IsSuccess = true,
                        Message = "PCP Consent updated successfully."
                    };
                }
                else
                {
                    return new MobileResponseModel
                    {
                        IsSuccess = true,
                        Message = "Unable to update PCP Consent."
                    };
                }
            }
            catch (Exception ex)
            {
                _logger.Info(string.Format("While updating PCP Consent for EventCustomer ID : {0}. \n Message : {1} \n Stack Trace : {2}", model.EventCustomerId, ex.Message, ex.StackTrace));

                return new MobileResponseModel
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }

        [HttpGet]
        public MobileResponseModel FetchEvent([FromUri] long EventId)
        {
            MobileResponseModel model;
            try
            {
                if (_sessionContext.UserSession == null || _sessionContext.UserSession.CurrentOrganizationRole == null)
                {
                    throw new Exception("Invalid User");
                }

                var filter = new EventSearchModelFilter();
                filter.EventId = EventId;

                filter.StaffId = _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId;
                filter.FromDate = DateTime.Today;
                filter.ToDate = DateTime.Today;
                var data = _eventService.GetEventBasicDetailsForStaff(filter) ?? null;

                model = new MobileResponseModel
                {
                    IsSuccess = true,
                    Data = data
                };
            }
            catch (Exception exception)
            {
                _logger.Error(string.Format("While Fetch Events Message:{0} \\n Stack Trace:{1}", exception.Message, exception.StackTrace));

                model = new MobileResponseModel
                {
                    IsSuccess = false,
                    Message = exception.Message,
                    Data = null
                };
            }

            return model;
        }
    }
}
