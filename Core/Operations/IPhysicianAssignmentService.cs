using System.Collections.Generic;
using Falcon.App.Core.Operations.ViewModels;
using Falcon.App.Core.Users.ViewModels;

namespace Falcon.App.Core.Operations
{
    public interface IPhysicianAssignmentService
    {
        IEnumerable<AssignedPhysicianBasicInfoModel> GetPhysiciansAssignedToEvent(long eventId);
        IEnumerable<AssignedPhysicianBasicInfoModel> GetPhysiciansAssignedToCustomer(long eventCustomerId);
        IEnumerable<long> GetPhysicianIdsAssignedtoaCustomer(long eventId, long customerId);
        IEnumerable<AssignedPhysicianViewModel> GetPhysicianAssignments(long eventId, IEnumerable<long> eventCustomerIds);
        IEnumerable<AssignedPhysicianViewModel> GetPhysicianAssignmentsByEventcustomerIds(IEnumerable<long> eventCustomerIds);
        IEnumerable<PhsicianEventTestViewModel> GetPhsiscianAssignedTests(long eventId, long physicianId);
        void Save(PhysicianEventAssignmentEditModel model, OrganizationRoleUserModel currentOrganizationRole);
    }
}
