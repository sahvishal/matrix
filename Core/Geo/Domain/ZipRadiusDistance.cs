using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Geo.Domain
{
    public class ZipRadiusDistance : DomainObjectBase
    {
        public long SourceZipId { get; set; }
        public long DestinationZipId { get; set; }
        public int Radius { get; set; }
        public double Distance { get; set; }
    }
}
