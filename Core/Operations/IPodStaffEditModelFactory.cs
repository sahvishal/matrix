using System.Collections.Generic;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Operations.ViewModels;

namespace Falcon.App.Core.Operations
{
    public interface IPodStaffEditModelFactory
    {
        IEnumerable<PodStaffEditModel> Create(long podId, IEnumerable<PodStaff> podStaff, IEnumerable<OrderedPair<long, string>> idNamePairs, IEnumerable<StaffEventRole> eventRoles);
    }
}