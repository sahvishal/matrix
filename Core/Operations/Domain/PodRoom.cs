using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Operations.Domain
{
    public class PodRoom : DomainObjectBase
    {
        public long PodId { get; set; }
        public int RoomNo { get; set; }
        public int Duration { get; set; }
    }
}
