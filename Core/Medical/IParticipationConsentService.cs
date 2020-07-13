using Falcon.App.Core.Medical.ViewModels;

namespace Falcon.App.Core.Medical
{
    public interface IParticipationConsentService
    {
        bool Save(ParticipationConsentSignatureModel model, long orgRoleUserId);
        
        HealthAssessmentHeaderEditModel GetModel(long eventId, long customerId);

        ParticipationConsentSignatureModel GetParticipationConsentSignature(long eventCustomerId);
    }
}
