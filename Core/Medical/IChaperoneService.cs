using Falcon.App.Core.Medical.ViewModels;

namespace Falcon.App.Core.Medical
{
    public interface IChaperoneService
    {
        ChaperoneFormModel GetChaperoneFormModel(long eventCustomerId);
        bool SaveAnswers(ChaperoneFormModel model, long orgRoleUserId);
        ChaperoneFormViewModel GetModel(long eventId, long customerId);
    }
}
