using Falcon.App.Core.Medical.ViewModels;

namespace Falcon.App.Core.Medical
{
    public interface IKynHealthAssessmentService
    {
        KynHealthAssessmentEditModel GetKynHealthAssessment(long customerId, long eventId, long testId, bool isNewResultFlow);
        void SetKynHealthAssessment(KynHealthAssessmentEditModel model, long uploadedby);
    }
}