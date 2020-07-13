using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Scheduling.Domain;

namespace Falcon.App.Core.Medical
{
    public interface IOnlineHealthAssessmentService
    {
        OnlineHealthAssessmentQuestionModel Get(OnlineHealthAssessmentQuestionModel model);
        bool IsTestPurchased(long eventId, long customerId, long testId);
        void SaveOnlineHealthAssessment(OnlineHealthAssessmentQuestionAnswer model, TempCart tempCart);
    }
}