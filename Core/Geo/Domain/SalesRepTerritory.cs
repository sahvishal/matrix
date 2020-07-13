using System.Collections.Generic;
using Falcon.App.Core.Enum;

namespace Falcon.App.Core.Geo.Domain
{
    public class SalesRepTerritory : Territory
    {
        public List<SalesRepTerritoryAssignment> SalesRepTerritoryAssignments { get; set; }
        public override TerritoryType TerritoryType { get { return TerritoryType.SalesRep; } }

        public SalesRepTerritory()
        {}

        public SalesRepTerritory(long territoryId)
            : base(territoryId)
        {}
    }
}