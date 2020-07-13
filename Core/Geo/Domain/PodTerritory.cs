using System.Collections.Generic;
using Falcon.App.Core.Enum;

namespace Falcon.App.Core.Geo.Domain
{
    public class PodTerritory : Territory
    {
        public List<long> PodIds { get; set; }
        public override TerritoryType TerritoryType { get { return TerritoryType.Pod; } }
        public List<long> PackageIds { get; set; }
        public PodTerritory()
        {}

        public PodTerritory(long territoryId)
            : base(territoryId)
        {}
    }
}