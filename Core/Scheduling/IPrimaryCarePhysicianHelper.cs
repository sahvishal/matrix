using Falcon.App.Core.Medical.ViewModels;

namespace Falcon.App.Core.Scheduling
{
    public interface IPrimaryCarePhysicianHelper
    {
        PrimaryCarePhysicianEditModel GetPrimaryCarePhysicianEditModel(long customerId);
        void UpdatePrimaryCarePhysician(PrimaryCarePhysicianEditModel primaryCarePhysician, long customerId, long orgRoleUserId);

        PrimaryCarePhysicianViewModel GetPrimaryCarePhysicianViewModel(long customerId);
    }
}