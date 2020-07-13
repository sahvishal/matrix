using System.Collections.Generic;
using Falcon.App.Core.Operations.Domain;

namespace Falcon.App.Core.Operations
{
    public interface IPodRoomRepository
    {
        PodRoom Save(PodRoom domain);
        void SavePodRoomTests(IEnumerable<long> testIds, long podRoomId);
        void DeletePodRooms(IEnumerable<long> podRoomIds);
        IEnumerable<PodRoom> GetByPodId(long podId);
        IEnumerable<PodRoomTest> GetPodRoomTestsByPodId(long podId);
    }
}
