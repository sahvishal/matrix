using Falcon.App.Core.Enum;
using Falcon.App.Core.Geo.Domain;
using NUnit.Framework;

namespace HealthYes.Web.UnitTests.Core.Domain
{
    [TestFixture]
    public class ReadingPhysicianTerritoryTester
    {
        [Test]
        public void TerritoryTypeReturnsReadingPhysician()
        {
            const TerritoryType expectedTerritoryType = TerritoryType.ReadingPhysician;

            var readingPhysicianTerritory = new ReadingPhysicianTerritory();

            Assert.AreEqual(expectedTerritoryType, readingPhysicianTerritory.TerritoryType, "Incorrect Territory Type returned.");
        }
    }
}