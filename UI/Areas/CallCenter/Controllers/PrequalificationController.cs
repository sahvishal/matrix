using System;
using System.Web.Mvc;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.UI.Filters;


namespace Falcon.App.UI.Areas.CallCenter.Controllers
{
    [RoleBasedAuthorize]
    public class PreQualificationController : Controller
    {
        private readonly IPreQualificationResultRepository _preQualificationResultRepository;
        private ILogger _logger;

        public PreQualificationController(IPreQualificationResultRepository preQualificationResultRepository, ILogManager logManager)
        {
            _preQualificationResultRepository = preQualificationResultRepository;
            _logger = logManager.GetLogger<PreQualificationController>();
        }


        [HttpPost]
        public ActionResult SavePreQualificationResult(long eventId, long customerId, long callId, string guid, PackageSelectionInfoEditModel packageSelectionInfoEditModel)
        {
            var registrationFlowModel = Session[guid] as RegistrationFlowModel;

            if (registrationFlowModel != null)
            {
                var preQualificationResult = _preQualificationResultRepository.GetById(registrationFlowModel.PreQualificationResultId) ?? new PreQualificationResult
                {
                    EventId = eventId,
                    CustomerId = customerId,
                    CallId = callId > 0 ? (long?)callId : null
                };

                if (packageSelectionInfoEditModel.SkipPreQualificationQuestion)
                {
                    preQualificationResult.SkipPreQualificationQuestion = packageSelectionInfoEditModel.SkipPreQualificationQuestion;
                    SavePreQualification(preQualificationResult);
                }
                else if (!packageSelectionInfoEditModel.SkipPreQualificationQuestion)
                {
                    if (packageSelectionInfoEditModel.HighBloodPressure <= 0 || packageSelectionInfoEditModel.Smoker <= 0 ||
                        packageSelectionInfoEditModel.HeartDisease <= 0 || packageSelectionInfoEditModel.Diabetic <= 0 ||
                        packageSelectionInfoEditModel.ChestPain <= 0 ||
                        packageSelectionInfoEditModel.DiagnosedHeartProblem <= 0 ||
                        packageSelectionInfoEditModel.HighCholestrol <= 0 || packageSelectionInfoEditModel.OverWeight <= 0)
                        return Json(new { Result = true });

                    preQualificationResult.ChestPain = packageSelectionInfoEditModel.ChestPain;
                    preQualificationResult.HeartDisease = packageSelectionInfoEditModel.HeartDisease;
                    preQualificationResult.HighBloodPressure = packageSelectionInfoEditModel.HighBloodPressure;
                    preQualificationResult.Smoker = packageSelectionInfoEditModel.Smoker;
                    preQualificationResult.Diabetic = packageSelectionInfoEditModel.Diabetic;
                    preQualificationResult.DiagnosedHeartProblem = packageSelectionInfoEditModel.DiagnosedHeartProblem;
                    preQualificationResult.HighCholestrol = packageSelectionInfoEditModel.HighCholestrol;
                    preQualificationResult.OverWeight = packageSelectionInfoEditModel.OverWeight;

                    preQualificationResult.SkipPreQualificationQuestion = packageSelectionInfoEditModel.SkipPreQualificationQuestion;

                    var id = SavePreQualification(preQualificationResult);

                    if (id > 0)
                    {
                        registrationFlowModel.PreQualificationResultId = id;
                    }
                }
            }

            return Json(new { Result = true });
        }

        private long SavePreQualification(PreQualificationResult preQualificationResult)
        {
            try
            {
                preQualificationResult.DateCreated = DateTime.Now;
                preQualificationResult.IsActive = true;
                preQualificationResult.SignUpModeId = (int)SignUpMode.CallCenter;
                preQualificationResult = _preQualificationResultRepository.Save(preQualificationResult);
            }
            catch (Exception exception)
            {
                _logger.Error(string.Format("while save PreQualification Result from CallCenter CustomerId: {0} EventId :{1}  message: {2} \n\t strack trace {3} ",
                        preQualificationResult.CustomerId, preQualificationResult.EventId, exception.Message, exception.StackTrace), exception);
            }


            return preQualificationResult.Id;
        }

        [HttpPost]
        public ActionResult UpdateUserPrefrenceWithPrequalificationQuestion(string guid)
        {
            var registrationFlowModel = Session[guid] as RegistrationFlowModel;
            if (registrationFlowModel != null)
            {
                var preQualificationResult = _preQualificationResultRepository.GetById(registrationFlowModel.PreQualificationResultId);

                if (preQualificationResult != null)
                {
                    preQualificationResult.AgreedWithPrequalificationQuestion = true;
                    registrationFlowModel.PreQualificationResultId = SavePreQualification(preQualificationResult);
                }
            }

            return Json(new { Result = true });
        }

    }
}