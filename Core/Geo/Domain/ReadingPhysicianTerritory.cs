using Falcon.App.Core.Enum;

namespace Falcon.App.Core.Geo.Domain
{
    public class ReadingPhysicianTerritory : Territory
    {
        public ReadingPhysicianTerritory()
        {}

        public ReadingPhysicianTerritory(long territoryId)
            : base(territoryId)
        {}

        public override TerritoryType TerritoryType
        {
            get { return TerritoryType.ReadingPhysician; }
        }
    }
}