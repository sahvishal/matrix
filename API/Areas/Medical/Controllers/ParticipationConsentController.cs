using System;
using System.Web.Http;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.ViewModels;

namespace API.Areas.Medical.Controllers
{
   
    public class ParticipationConsentController : ApiController
    {
        private readonly ISessionContext _sessionContext;
        private readonly ILogger _logger;

        private readonly IParticipationConsentService _participationConsentService;

        public ParticipationConsentController(ISessionContext sessionContext, ILogManager logManager, IParticipationConsentService participationConsentService)
        {
            _sessionContext = sessionContext;
            _participationConsentService = participationConsentService;
            _logger = logManager.GetLogger<ParticipationConsentController>();
        }

        public MobileResponseModel Save([FromBody]ParticipationConsentSignatureModel model)
        {
            try
            {
                _logger.Info("Participation Consent (Save) EventCustomerId : " + model.EventCustomerId);

                var isSuccess = _participationConsentService.Save(model, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);
                if (isSuccess)
                {
                    return new MobileResponseModel
                    {
                        IsSuccess = true,
                        Message = "Matrix Consent saved successfully."
                    };
                }
                else
                {
                    return new MobileResponseModel
                    {
                        IsSuccess = false,
                        Message = "Unable to save Matrix Consent."
                    };
                }

            }
            catch (Exception ex)
            {
                _logger.Error("Error while saving Matrix Consent.");
                _logger.Error("Message : " + ex.Message);
                _logger.Error("Stack Trace : " + ex.StackTrace);

                return new MobileResponseModel
                {
                    IsSuccess = false,
                    Message = string.Format("Error while saving Matrix Consent. Message : {0}", ex.Message)
                };
            }
        }

        public MobileResponseModel Get([FromUri] long eventCustomerId)
        {
            MobileResponseModel participationConsentSignature;

            _logger.Info("Participation Consent (Get) EventCustomerId : " + eventCustomerId);

            try
            {
                var data = _participationConsentService.GetParticipationConsentSignature(eventCustomerId);
                participationConsentSignature = new MobileResponseModel
                {
                    IsSuccess = true,
                    StatusCode = 200,
                    Data = data


                };
                return participationConsentSignature;

            }
            catch (Exception ex)
            {
                _logger.Error(string.Format("while Participation Consent Record Request Signature Message:{0} \\n Stack Trace:{1}", ex.Message, ex.StackTrace));
                participationConsentSignature = new MobileResponseModel
                {
                    IsSuccess = false,
                    Message = ex.Message.ToString(),
                    StatusCode = 500,
                    Data = null
                };
                return participationConsentSignature;
            }
        }
    }
}
