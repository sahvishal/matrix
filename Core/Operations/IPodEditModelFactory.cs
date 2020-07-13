using System.Collections.Generic;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Operations.ViewModels;

namespace Falcon.App.Core.Operations
{
    public interface IPodEditModelFactory
    {
        PodEditModel Create(Pod pod, IEnumerable<Territory> territories, IEnumerable<OrderedPair<long, string>> podTerritories, IEnumerable<PodStaff> podStaff,
            IEnumerable<OrderedPair<long, string>> idNamePairs, IEnumerable<StaffEventRole> eventRoles, IEnumerable<PodRoom> podRooms, IEnumerable<PodRoomTest> podRoomTests, IEnumerable<Test> tests);
    }
}