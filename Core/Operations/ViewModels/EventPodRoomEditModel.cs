using System.Collections.Generic;

namespace Falcon.App.Core.Operations.ViewModels
{
    public class EventPodRoomEditModel
    {
        public long EventPodRoomId { get; set; }
        public long EventPodId { get; set; }
        public int RoomNo { get; set; }
        public int Duration { get; set; }
        public IList<EventPodRoomTestEditModel> EventPodRoomTests { get; set; }
    }
}
