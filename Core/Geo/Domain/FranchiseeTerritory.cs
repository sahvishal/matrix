using Falcon.App.Core.Enum;

namespace Falcon.App.Core.Geo.Domain
{
    public class FranchiseeTerritory : Territory
    {
        public long FranchiseeOwnerId { get; set; }
        public override TerritoryType TerritoryType { get { return TerritoryType.Franchisee; } }

        public FranchiseeTerritory()
        {}

        public FranchiseeTerritory(long territoryId)
            : base(territoryId)
        {}
    }
}