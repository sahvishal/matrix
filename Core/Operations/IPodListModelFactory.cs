using System.Collections.Generic;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Operations.ViewModels;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.Operations
{
    public interface IPodListModelFactory
    {
        PodListModel Create(IEnumerable<Pod> pods, IEnumerable<PodStaff> multiplePodStaff, IEnumerable<StaffEventRole> staffEventRoles,
                    IEnumerable<OrderedPair<long, string>> podTerritoryNamePair, IEnumerable<OrderedPair<long, string>> organizationRoleUsers, IEnumerable<Organization> organizations);
    }
}