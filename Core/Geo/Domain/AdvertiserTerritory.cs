using Falcon.App.Core.Enum;

namespace Falcon.App.Core.Geo.Domain
{
    public class AdvertiserTerritory : Territory
    {
        public AdvertiserTerritory()
        {}

        public AdvertiserTerritory(long territoryId)
            : base (territoryId)
        {}

        public override TerritoryType TerritoryType
        {
            get { return TerritoryType.Advertiser; }
        }
    }
}