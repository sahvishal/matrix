using System.Collections.Generic;
using Falcon.App.Core.Operations.Domain;

namespace Falcon.App.Core.Operations
{
    public interface IPodStaffAssignmentRepository
    {
        IEnumerable<PodStaff> SaveMultiple(IEnumerable<PodStaff> podDefaultTeams, long podId);
        IEnumerable<PodStaff> GetPodSatff(long podId);
        IEnumerable<PodStaff> GetPodStaffforMultiplePods(IEnumerable<long> podIds);
    }
}