using Falcon.App.Core.Medical.ViewModels;

namespace Falcon.App.Core.Medical
{
    public interface IPhysicianRecordRequestService
    {
        bool Save(PhysicianRecordRequestSignatureModel model, long orgRoleUserId);

        PhysicianRecordRequestSignatureModel GetPhysicianRecordRequestSignature(long EventCustomerId);
    }
}
