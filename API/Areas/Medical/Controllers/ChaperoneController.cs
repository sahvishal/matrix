using Falcon.App.Core.Application;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.ViewModels;
using System;
using System.Web.Http;

namespace API.Areas.Medical.Controllers
{
   
    public class ChaperoneController : ApiController
    {
        private readonly ISessionContext _sessionContext;
        private readonly ILogger _logger;

        private readonly IChaperoneService _chaperoneService;

        public ChaperoneController(ISessionContext sessionContext, ILogManager logManager, IChaperoneService chaperoneService)
        {
            _sessionContext = sessionContext;
            _chaperoneService = chaperoneService;
            _logger = logManager.GetLogger<ChaperoneController>();
        }

        [HttpPost]
        public MobileResponseModel Save(ChaperoneFormModel model)
        {
            try
            {
                _logger.Info("Chaperone Form (Save) EventCustomerId : " + model.EventCustomerId);
                var isSuccess = _chaperoneService.SaveAnswers(model, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);

                if (isSuccess)
                {
                    return new MobileResponseModel
                    {
                        IsSuccess = true,
                        Message = "Chaperone form data saved successfully."
                    };
                }
                else
                {
                    return new MobileResponseModel
                    {
                        IsSuccess = false,
                        Message = "Unable to save Chaperone form data."
                    };
                }

            }
            catch (Exception ex)
            {
                _logger.Error("Error while saving Chaperone form data.");
                _logger.Error("Message : " + ex.Message);
                _logger.Error("Stack Trace : " + ex.StackTrace);

                return new MobileResponseModel
                {
                    IsSuccess = false,
                    Message = string.Format("Error while saving Chaperone form data. Message : {0}", ex.Message)
                };
            }
        }

        public MobileResponseModel Get([FromUri] long eventCustomerId)
        {
            var model = new MobileResponseModel();
            _logger.Info("Chaperone Form (Get) EventCustomerId : " + eventCustomerId);
            try
            {
                var data = _chaperoneService.GetChaperoneFormModel(eventCustomerId);

                model.IsSuccess = true;
                model.StatusCode = 200;
                model.Data = data;

                return model;

            }
            catch (Exception ex)
            {
                _logger.Error(string.Format("Error occurred while getting chaperone form data Message:{0} \\n Stack Trace:{1}", ex.Message, ex.StackTrace));

                model.IsSuccess = false;
                model.Message = ex.Message.ToString();
                model.StatusCode = 500;
                model.Data = null;

                return model;
            }
        }
    }
}
