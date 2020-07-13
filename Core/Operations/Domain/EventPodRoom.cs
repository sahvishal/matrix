using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Operations.Domain
{
    public class EventPodRoom : DomainObjectBase
    {
        public long EventPodId { get; set; }
        public int RoomNo { get; set; }
        public int Duration { get; set; }
    }
}
