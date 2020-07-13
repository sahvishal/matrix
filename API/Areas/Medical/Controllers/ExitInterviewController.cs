using System;
using System.Web.Http;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.ViewModels;

namespace API.Areas.Medical.Controllers
{
   
    public class ExitInterviewController : ApiController
    {
        private readonly ILogger _logger;
        private readonly ISessionContext _sessionContext;

        private readonly IExitInterviewService _exitInterviewService;

        public ExitInterviewController(ILogManager logManager, IExitInterviewService exitInterviewService, ISessionContext sessionContext)
        {
            _exitInterviewService = exitInterviewService;
            _sessionContext = sessionContext;
            _logger = logManager.GetLogger<ExitInterviewController>();
        }

        public MobileResponseModel GetQuestions(long eventCustomerId)
        {
            try
            {
                _logger.Info("Exit Interview (GetQuestions): Event Customer Id : " + eventCustomerId);
                var data = _exitInterviewService.GetQuestions(eventCustomerId);

                return new MobileResponseModel
                {
                    IsSuccess = true,
                    Data = data
                };
            }
            catch (Exception ex)
            {
                _logger.Error("Error while getting Exit Interview Questions.");
                _logger.Error("Message : " + ex.Message);
                _logger.Error("Stack Trace : " + ex.StackTrace);

                return new MobileResponseModel
                {
                    IsSuccess = false,
                    Message = string.Format("Error while getting Exit Interview Questions. Message : {0}", ex.Message)
                };
            }
        }


        [HttpPost]
        public MobileResponseModel Save(ExitInterviewAnswerModel model)
        {
            try
            {
                _logger.Info("Exit Interview (Save): Event Customer Id : " + model.EventCustomerId);
                var isSuccess = _exitInterviewService.Save(model, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);

                if (isSuccess)
                {
                    return new MobileResponseModel
                    {
                        IsSuccess = true,
                        Message = "Exit Interview saved successfully."
                    };
                }
                else
                {
                    return new MobileResponseModel
                    {
                        IsSuccess = false,
                        Message = "Some error occurred while saving the Exit Interview."
                    };
                }

            }
            catch (Exception ex)
            {
                _logger.Error("Error while saving Exit Interview.");
                _logger.Error("Message : " + ex.Message);
                _logger.Error("Stack Trace : " + ex.StackTrace);

                return new MobileResponseModel
                {
                    IsSuccess = false,
                    Message = string.Format("Error while saving Exit Interview. Message : {0}", ex.Message)
                };
            }
        }
    }
}
