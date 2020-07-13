using System;
using System.Web.Http;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Users.Enum;

namespace API.Areas.Medical.Controllers
{
    public class HealthAssessmentController : ApiController
    {
        private readonly ICustomerHafQuestionService _customerHafQuestionService;
        private readonly IHealthAssessmentService _healthAssessmentService;

        private readonly ILogger _logger;

        public HealthAssessmentController(ILogManager logManager, ICustomerHafQuestionService customerHafQuestionService, IHealthAssessmentService healthAssessmentService)
        {
            _customerHafQuestionService = customerHafQuestionService;
            _healthAssessmentService = healthAssessmentService;
            _logger = logManager.GetLogger<HealthAssessmentController>();
        }

        [HttpGet]
        public HafModel FetchHealthAssessment([FromUri]HafFilter filter)
        {
            HafModel model;
            _logger.Info("Health Assessment (FetchHealthAssessment) CustomerId : " + filter.CustomerId);
            try
            {
                if (filter == null && filter.CustomerId <= 0 && filter.EventId <= 0)
                {
                    model = new HafModel { IsSuccess = false,  EventId = filter.EventId, CustomerId = filter.CustomerId };
                }
                else
                {
                    model = _customerHafQuestionService.Get(filter);
                   
                    model.IsSuccess = true;
                }
            }
            catch (Exception exception)
            {
                _logger.Error(string.Format("While fechinging health assessment exception {0}", exception.StackTrace));
                model = new HafModel { IsSuccess = false };
            }

            return model;
        }

        [HttpPost]
        public ResponseBaseModel SaveHealthAssessment([FromBody]CustomerHafEditModel model)
        {
            try
            {
                if (model == null)
                    return new ResponseBaseModel { Message = "Customer Haf Model can not be null", IsSuccess = false };

                _logger.Info("Health Assessment (SaveHealthAssessment) CustomerId : " + model.CustomerId);
              
                _healthAssessmentService.Save(new HealthAssessmentEditModel
                {
                    CustomerId = model.CustomerId,
                    EventId = model.EventId,
                    Gender = (Gender)model.Gender,
                    QuestionEditModels = model.QuestionEditModels
                }, 0);

            }
            catch (Exception ex)
            {
                _logger.Error(string.Format("While Save Health Assessment exception {0}", ex.StackTrace));
                return new ResponseBaseModel
                {
                    IsSuccess = false,
                    Message = "Some error has occured while saving data"
                };
            }

            return new ResponseBaseModel
            {
                IsSuccess = true,
                Message = "Data saved successfully"
            };
        }
        
    }
}
