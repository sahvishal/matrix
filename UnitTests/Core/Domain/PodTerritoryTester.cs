using Falcon.App.Core.Domain;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Geo.Domain;
using NUnit.Framework;

namespace HealthYes.Web.UnitTests.Core.Domain
{
    [TestFixture]
    public class PodTerritoryTester
    {
        [Test]
        public void TerritoryTypeReturnsPod()
        {
            const TerritoryType expectedTerritoryType = TerritoryType.Pod;

            Territory territory = new PodTerritory();

            Assert.AreEqual(expectedTerritoryType, territory.TerritoryType);
        }
    }
}