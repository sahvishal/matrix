using System.Collections.Generic;
using Falcon.App.Core.Operations.ViewModels;

namespace Falcon.App.Core.Operations
{
    public interface IPodService
    {
        PodListModel GetPodListModel(int pageNumber, int pageSize);
        PodEditModel GetPodEditModel(long podId);
        void SavePodRooms(IEnumerable<PodRoomEditModel> podRoomEditModels, long podId);
    }
}