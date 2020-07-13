using System.Collections.Generic;

namespace Falcon.App.Core.Operations.ViewModels
{
    public class PodRoomEditModel
    {
        public long PodRoomId { get; set; }
        public int RoomNo { get; set; }
        public int Duration { get; set; }
        public IList<PodRoomTestEditModel> RoomTests { get; set; }

        public PodRoomEditModel()
        {
            RoomTests = new List<PodRoomTestEditModel>();
        }
    }
}
