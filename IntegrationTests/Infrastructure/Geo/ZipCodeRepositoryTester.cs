using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Infrastructure.Geo.Impl;
using NUnit.Framework;

namespace Falcon.Web.IntegrationTests.Infrastructure.Geo
{
    [TestFixture]
    [Ignore("The database needs to be in a steady state in order to run this test fixture.")]
    public class ZipCodeRepositoryTester
    {
        private readonly IZipCodeRepository _zipCodeRepository = new ZipCodeRepository();
        private const long VALID_ZIP_ID = 2;
        private const long VALID_TERRITORY_ID = 1;
        private const long STATE_ID_WITH_ZIPS = 49;
        private const string VALID_ZIP_CODE = "00603";
        private const string ZIP_WITH_OTHERS_IN_RANGE = "78701";

        [Test]
        public void GetZipCodeReturnsZipCodeWhenGivenValidId()
        {
            ZipCode zipCode = _zipCodeRepository.GetZipCode(VALID_ZIP_ID);

            Assert.IsNotNull(zipCode);
            Assert.AreEqual(VALID_ZIP_ID, zipCode.Id);
        }

        [Test]
        public void GetZipCodeReturnsZipCodeWhenGivenValidZipCode()
        {
            var zipCodes = _zipCodeRepository.GetZipCode(VALID_ZIP_CODE);

            Assert.IsNotNull(zipCodes);
            Assert.IsNotEmpty(zipCodes.ToList());
            Assert.Contains(VALID_ZIP_ID, zipCodes.Select(z => z.Id).ToList());
        }

        [Test]
        public void GetZipCodesForTerritoryReturnsCodesForTerritoryWithZips()
        {
            List<ZipCode> zipCodes = _zipCodeRepository.GetZipCodesForTerritory(VALID_TERRITORY_ID);

            Assert.IsNotNull(zipCodes);
            Assert.IsNotEmpty(zipCodes);
        }

        [Test]
        public void GetZipCodesForStateReturnsCodesForStateWithZips()
        {
            List<ZipCode> zipCodes = _zipCodeRepository.GetZipCodesForState(STATE_ID_WITH_ZIPS);

            Assert.IsNotNull(zipCodes);
            Assert.IsNotEmpty(zipCodes);
        }

        [Test]
        public void GetZipCodesInRadiusReturnsZipCodes()
        {
            List<ZipCode> zipCodes = _zipCodeRepository.GetZipCodesInRadius(ZIP_WITH_OTHERS_IN_RANGE, 1);

            Assert.IsNotNull(zipCodes);
            Assert.IsNotEmpty(zipCodes, "No zip codes returned from persistence.");
        }

        // TODO: This should be a unit test.
        [Test]
        public void GetZipCodesInRadiusReturnsNoZipCodesForInvalidZipCode()
        {
            List<ZipCode> zipCodes = _zipCodeRepository.GetZipCodesInRadius("23854382", 1);

            Assert.IsNotNull(zipCodes);
            Assert.IsEmpty(zipCodes, "Zip codes returned from persistence when none expected.");
        }

        // TODO: This should be a unit test.
        [Test]
        public void GetZipCodesInRadiusReturnsNoZipCodesForNullZipCode()
        {
            List<ZipCode> zipCodes = _zipCodeRepository.GetZipCodesInRadius(null, 1);

            Assert.IsNotNull(zipCodes);
            Assert.IsEmpty(zipCodes, "Zip codes returned from persistence when none expected.");
        }

        [Test]
        public void GetAllZipCodesReturnsZipCodes()
        {
            List<ZipCode> zipCodes = _zipCodeRepository.GetAllZipCodes();

            Assert.IsNotNull(zipCodes);
            Assert.IsNotEmpty(zipCodes, "No zip codes returned from persistence.");
        }

        [Test]
        public void GetAllExistingZipCodesReturnsZipCodes()
        {
            var zipCodesToFetch = new List<string> {"78701", "38328", "90210"};

            List<ZipCode> zipCodes = _zipCodeRepository.GetAllExistingZipCodes(zipCodesToFetch);

            Assert.IsNotNull(zipCodes);
            Assert.IsNotEmpty(zipCodes, "No zip codes were returned from persistence.");
        }

        [Test]
        public void GetAllExistingZipCodesDoesNotBombWhenGivenHugeList()
        {
            var zipCodesToCheck = new List<string>();
            for (int i = 10000; i < 20000; i++)
            {
                zipCodesToCheck.Add(i.ToString());
            }

            _zipCodeRepository.GetAllExistingZipCodes(zipCodesToCheck);
        }
    }
}