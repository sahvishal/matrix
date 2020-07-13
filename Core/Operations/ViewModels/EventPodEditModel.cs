using System.Collections.Generic;

namespace Falcon.App.Core.Operations.ViewModels
{
    public class EventPodEditModel
    {
        public long EventPodId { get; set; }
        public long EventId { get; set; }
        public long PodId { get; set; }
        public string Name { get; set; }
        public long? TerritoryId { get; set; }
        public IList<EventPodRoomEditModel> EventPodRooms { get; set; } 
    }
}
