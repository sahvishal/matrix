using System;
using System.Web.Http;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.ViewModels;

namespace API.Areas.Medical.Controllers
{
   
    public class PhysicianRecordRequestController : ApiController
    {
        private readonly ILogger _logger;
        private readonly ISessionContext _sessionContext;

        private readonly IPhysicianRecordRequestService _physicianRecordRequestService;

        public PhysicianRecordRequestController(ILogManager logManager, ISessionContext sessionContext, IPhysicianRecordRequestService physicianRecordRequestService)
        {
            _sessionContext = sessionContext;
            _physicianRecordRequestService = physicianRecordRequestService;
            _logger = logManager.GetLogger<PhysicianRecordRequestController>();
        }

        [HttpPost]
        public MobileResponseModel Save([FromBody]PhysicianRecordRequestSignatureModel model)
        {
            try
            {
                _logger.Info("Physician Record Request (Save) EventCustomerId : " + model.EventCustomerId);

                var isSuccess = _physicianRecordRequestService.Save(model, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);

                if (isSuccess)
                {
                    return new MobileResponseModel
                    {
                        IsSuccess = true,
                        Message = "Physician Record Request saved successfully."
                    };
                }
                else
                {
                    return new MobileResponseModel
                    {
                        IsSuccess = false,
                        Message = "Unable to save Physician Record Request."
                    };
                }

            }
            catch (Exception ex)
            {
                _logger.Error("Error while saving Physician Record Request.");
                _logger.Error("Message : " + ex.Message);
                _logger.Error("Stack Trace : " + ex.StackTrace);

                return new MobileResponseModel
                {
                    IsSuccess = false,
                    Message = string.Format("Error while saving Physician Record Request. Message : {0}", ex.Message)
                };
            }
        }

        [HttpGet]
        public MobileResponseModel Get([FromUri]long eventCustomerId)
        {
            MobileResponseModel physicianRecordRequestSignature;

            _logger.Info("Physician Record Request (Get) EventCustomerId : " + eventCustomerId);

            try
            {
                var data = _physicianRecordRequestService.GetPhysicianRecordRequestSignature(eventCustomerId);

                physicianRecordRequestSignature = new MobileResponseModel
                {
                    IsSuccess = true,
                    Data = data,
                    StatusCode = 200
                };
            }
            catch (Exception exception)
            {
                _logger.Error(string.Format("while physician Record Request Signature Message:{0} \\n Stack Trace:{1}", exception.Message, exception.StackTrace));

                physicianRecordRequestSignature = new MobileResponseModel
                {
                    IsSuccess = false,
                    Message = exception.Message,
                    StatusCode = 500,
                    Data = null
                };
            }

            return physicianRecordRequestSignature;
        }
    
    }
}
