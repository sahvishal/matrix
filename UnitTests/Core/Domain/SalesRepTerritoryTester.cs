using Falcon.App.Core.Enum;
using Falcon.App.Core.Geo.Domain;
using NUnit.Framework;

namespace HealthYes.Web.UnitTests.Core.Domain
{
    [TestFixture]
    public class SalesRepTerritoryTester
    {
        [Test]
        public void TerritoryTypeReturnsSalesRep()
        {
            const TerritoryType expectedTerritoryType = TerritoryType.SalesRep;

            Territory territory = new SalesRepTerritory();

            Assert.AreEqual(expectedTerritoryType, territory.TerritoryType);
        }
    }
}