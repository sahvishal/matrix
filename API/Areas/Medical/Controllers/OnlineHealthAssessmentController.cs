using System;
using System.Web.Http;
using API.Areas.Application.Controllers;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Enum;

namespace API.Areas.Medical.Controllers
{
    [AllowAnonymous]
    public class OnlineHealthAssessmentController : BaseController
    {
        private readonly ITempcartService _tempcartService;
        private readonly IOnlineHealthAssessmentService _onlineHealthAssessmentService;
        private readonly ILogger _logger;

        public OnlineHealthAssessmentController(ILogManager logManager, ITempcartService tempcartService, IOnlineHealthAssessmentService onlineHealthAssessmentService)
        {
            _tempcartService = tempcartService;
            _onlineHealthAssessmentService = onlineHealthAssessmentService;
            _logger = logManager.GetLogger<OnlineHealthAssessmentController>();
        }

        [HttpGet]
        public OnlineHealthAssessmentQuestionModel GetHealthAssessmentQuestion(string guid)
        {
            var requestValidatonModel = _tempcartService.ValidateOnlineRequest(guid);

            var model = new OnlineHealthAssessmentQuestionModel { RequestValidationModel = requestValidatonModel };

            var tempCart = model.RequestValidationModel.TempCart;

            if ((requestValidatonModel.RequestStatus != OnlineRequestStatus.Valid && requestValidatonModel.RequestStatus != OnlineRequestStatus.Completed) || tempCart == null || !(tempCart.EventId.HasValue && tempCart.CustomerId.HasValue))
                return model;

            return _onlineHealthAssessmentService.Get(model); ;
        }

        [HttpPost]
        public OnlineHealthAssessmentQuestionModel SaveHealthAssessment([FromBody]OnlineHealthAssessmentQuestionAnswer model)
        {
            var hafModel = new OnlineHealthAssessmentQuestionModel
            {
                RequestValidationModel = _tempcartService.ValidateOnlineRequest(model.Guid)
            };

            try
            {
                if (model == null)
                {
                    hafModel.RequestValidationModel.RequestStatus = OnlineRequestStatus.InvalidOperation;
                    return hafModel;
                }

                var tempCart = hafModel.RequestValidationModel.TempCart;

                if ((hafModel.RequestValidationModel.RequestStatus != OnlineRequestStatus.Valid && hafModel.RequestValidationModel.RequestStatus != OnlineRequestStatus.Completed) || tempCart == null || !(tempCart.EventId.HasValue && tempCart.CustomerId.HasValue))
                    return hafModel;

                _onlineHealthAssessmentService.SaveOnlineHealthAssessment(model, tempCart);
                
            }
            catch (Exception ex)
            {
                _logger.Error(string.Format("While Save Health Assessment exception {0}", ex.StackTrace));
            }

            return hafModel;
        }
    }
}
