using Falcon.App.Core.Enum;
using Falcon.App.Core.Geo.Domain;
using NUnit.Framework;

namespace Falcon.UnitTests.Core.Domain
{
    [TestFixture]
    public class HospitalPartnerTerritoryTester
    {
        [Test]
        public void TerritoryTypeReturnsHospitalPartner()
        {
            const TerritoryType expectedTerritoryType = TerritoryType.HospitalPartner;

            Territory territory = new HospitalPartnerTerritory();

            Assert.AreEqual(expectedTerritoryType, territory.TerritoryType);
        }
    }
}