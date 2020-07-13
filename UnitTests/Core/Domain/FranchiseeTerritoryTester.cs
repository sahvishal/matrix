using Falcon.App.Core.Enum;
using Falcon.App.Core.Geo.Domain;
using NUnit.Framework;

namespace Falcon.UnitTests.Core.Domain
{
    [TestFixture]
    public class FranchiseeTerritoryTester
    {
        [Test]
        public void TerritoryTypeReturnsFranchisee()
        {
            const TerritoryType expectedTerritoryType = TerritoryType.Franchisee;

            Territory territory = new FranchiseeTerritory();

            Assert.AreEqual(expectedTerritoryType, territory.TerritoryType);
        }
    }
}