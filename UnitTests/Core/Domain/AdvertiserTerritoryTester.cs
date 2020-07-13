using Falcon.App.Core.Enum;
using Falcon.App.Core.Geo.Domain;
using NUnit.Framework;

namespace Falcon.UnitTests.Core.Domain
{
    [TestFixture]
    public class AdvertiserTerritoryTester
    {
        [Test]
        public void TerritoryTypeReturnsAdvertiser()
        {
            const TerritoryType expectedTerritoryType = TerritoryType.Advertiser;

            var advertiserTerritory = new AdvertiserTerritory();

            Assert.AreEqual(expectedTerritoryType, advertiserTerritory.TerritoryType, "Incorrect Territory Type returned.");
        }
    }
}