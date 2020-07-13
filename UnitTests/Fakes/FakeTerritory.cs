using System.Collections.Generic;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Geo.Domain;

namespace HealthYes.Web.UnitTests.Fakes
{
    internal class FakeTerritory : Territory
    {
        public TerritoryType FakeTerritoryType { get; set; }

        public FakeTerritory()
            : this(0)
        { }
        public FakeTerritory(long territoryId)
            : base(territoryId)
        {
            ZipCodes = new List<ZipCode>();
        }
        
        public override TerritoryType TerritoryType { get { return FakeTerritoryType; } }
    }
}