using System;
using System.Web.Http;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.ViewModels;
using Newtonsoft.Json;

namespace API.Areas.Medical.Controllers
{
   
    public class FluConsentController : ApiController
    {
        private readonly ISessionContext _sessionContext;
        private readonly ILogger _logger;

        private readonly IFluConsentService _fluConsentService;

        public FluConsentController(ISessionContext sessionContext, ILogManager logManager, IFluConsentService fluConsentService)
        {
            _sessionContext = sessionContext;
            _fluConsentService = fluConsentService;
            _logger = logManager.GetLogger<FluConsentController>();
        }

        public MobileResponseModel Save(FluVaccineConsentModel model)
        {
            try
            {
                _logger.Info("Flu Consent (Save): Event Customer Id : " + model.EventCustomerId);
                var isSuccess = _fluConsentService.SaveAnswers(model, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);

                if (isSuccess)
                {
                    return new MobileResponseModel
                    {
                        IsSuccess = true,
                        Message = "Flu Vaccine Consent saved successfully."
                    };
                }
                else
                {
                    return new MobileResponseModel
                    {
                        IsSuccess = false,
                        Message = "Unable to save Flu Vaccine Consent."
                    };
                }

            }
            catch (Exception ex)
            {
                _logger.Error("Error while saving Flu Vaccine Consent.");
                _logger.Error("Message : " + ex.Message);
                _logger.Error("Stack Trace : " + ex.StackTrace);

                return new MobileResponseModel
                {
                    IsSuccess = false,
                    Message = string.Format("Error while saving Flu Vaccine Consent. Message : {0}", ex.Message)
                };
            }
        }


        public MobileResponseModel Get([FromUri] long eventCustomerId)
        {
            MobileResponseModel fluVaccineConsentModel;
            _logger.Info("Flu Consent (Get): Event Customer Id : " + eventCustomerId);
            try
            {
                var data = _fluConsentService.GetFluConsent(eventCustomerId);

                fluVaccineConsentModel = new MobileResponseModel
                {
                    IsSuccess = true,
                    StatusCode = 200,
                    Data = data
                };

                return fluVaccineConsentModel;

            }
            catch (Exception ex)
            {
                _logger.Error(string.Format("while Get Flu Consent Message:{0} \\n Stack Trace:{1}", ex.Message, ex.StackTrace));

                fluVaccineConsentModel = new MobileResponseModel
                {
                    IsSuccess = false,
                    Message = ex.Message,
                    StatusCode = 500,
                    Data = null
                };
                
                return fluVaccineConsentModel;
            }
        }
    
    }
}
