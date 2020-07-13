using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Infrastructure.Geo.Impl;
using NUnit.Framework;

namespace Falcon.Web.IntegrationTests.Infrastructure.Geo
{
    [TestFixture]
    [Ignore("The database needs to be in a steady state in order to run this test fixture.")]
    public class TerritoryRepositoryTester
    {
        private readonly ITerritoryRepository _territoryRepository = new TerritoryRepository();
        private const long HOSPITAL_PARTNER_TERRITORY_ID_WITH_ZIPS = 66;
        private const long FRANCHISEE_TERRITORY_ID_WITH_ZIPS = 65;
        private const long READING_PHYSICIAN_TERRITORY_ID = 77;
        private const long ADVERTISER_TERRITORY_ID = 78;
        private const long VALID_ZIP_ID_1 = 1;
        private const long VALID_ZIP_ID_2 = 2;
        private const long VALID_ZIP_ID_3 = 3;
        private const long VALID_HOSPITAL_PARTNER_ID = 1;
        private const long VALID_FRANCHISEE_ID = 97;
        private const long VALID_SALES_REP_PARENT_TERRITORY_ID = 44;
        private const long SALES_REP_ID_THAT_OWNS_TERRITORIES = 172;

        private static List<ZipCode> GetListOfValidZipCodes()
        {
            return new List<ZipCode> {new ZipCode(VALID_ZIP_ID_1), new ZipCode(VALID_ZIP_ID_2), new ZipCode(VALID_ZIP_ID_3)};
        }

        [Test]
        public void GetTerritoryReturnsTerritoryWhenGivenValidTerritoryId()
        {
            Territory territory = _territoryRepository.GetTerritory(HOSPITAL_PARTNER_TERRITORY_ID_WITH_ZIPS);

            Assert.IsNotNull(territory, "Null Territory returned.");
        }

        [Test]
        public void GetTerritoryReturnsTerritoryWithAssociatedZips()
        {
            Territory territory = _territoryRepository.GetTerritory(HOSPITAL_PARTNER_TERRITORY_ID_WITH_ZIPS);

            Assert.IsNotEmpty(territory.ZipCodes, "Territory with zip codes returned without them.");
        }

        [Test]
        public void GetTerritoryGetsFranchiseeOwnerIdForFranchiseeTerritory()
        {
            const long expectedFranchiseeOwnerId = 97;
            Territory territory = _territoryRepository.GetTerritory(FRANCHISEE_TERRITORY_ID_WITH_ZIPS);

            Assert.IsInstanceOf<FranchiseeTerritory>(territory, "Incorrect type of territory given: ", territory.GetType());
            Assert.AreEqual(expectedFranchiseeOwnerId, ((FranchiseeTerritory)territory).FranchiseeOwnerId,
                "Incorrect Franchisee Owner ID returned.");
        }

        [Test]
        public void GetTerritoryCanFetchReadingPhysicianTerritory()
        {
            Territory territory = _territoryRepository.GetTerritory(READING_PHYSICIAN_TERRITORY_ID);

            Assert.IsInstanceOf<ReadingPhysicianTerritory>(territory, "Incorrect type of territory given.");
        }

        [Test]
        public void GetTerritoryCanFetchAdvertiserTerritory()
        {
            Territory territory = _territoryRepository.GetTerritory(ADVERTISER_TERRITORY_ID);

            Assert.IsInstanceOf<AdvertiserTerritory>(territory, "Incorrect type of territory given.");
        }

        [Test]
        public void GetTerritoryGetsHospitalPartnerOwnerIdsForHospitalPartnerTerritory()
        {
            var expectedHospitalPartnerIds = new List<long> {1};
            Territory territory = _territoryRepository.GetTerritory(HOSPITAL_PARTNER_TERRITORY_ID_WITH_ZIPS);

            Assert.IsInstanceOf<HospitalPartnerTerritory>(territory, "Incorrect type of territory given: ", territory.GetType());
            Assert.AreEqual(expectedHospitalPartnerIds, ((HospitalPartnerTerritory)territory).HospitalPartnerOwnerIds,
                "Incorrect Hospital Partner Owner IDs returned.");
        }

        [Test]
        public void SaveTerritorySavesNewFranchiseeTerritory()
        {
            var franchiseeTerritory = new FranchiseeTerritory
            {
                Description = "Franchisee Territory test description.",
                FranchiseeOwnerId = VALID_FRANCHISEE_ID,
                Name = "Integration Test Saving Franchisee Territory",
                ParentTerritoryId = null,
                ZipCodes = GetListOfValidZipCodes()
            };
            _territoryRepository.SaveTerritory(franchiseeTerritory);
        }

        [Test]
        public void SaveTerritorySavesNewHospitalPartnerTerritory()
        {
            var hospitalPartnerTerritory = new HospitalPartnerTerritory
            {
                Description = "Hospital Partner Territory test description123.",
                HospitalPartnerOwnerIds = new List<long> { VALID_HOSPITAL_PARTNER_ID },
                Name = "Integration Test Saving Hospital Partner Territory",
                ParentTerritoryId = null,
                ZipCodes = GetListOfValidZipCodes()
            };
            _territoryRepository.SaveTerritory(hospitalPartnerTerritory);
        }

        [Test]
        public void SaveTerritorySavesNewReadingPhysicianTerritory()
        {
            var readingPhysicianTerritory = new ReadingPhysicianTerritory
            {
                Description = "Reading Physician Territory integration test description.",
                Name = "Integration Test for Inserting New Reading Physician Territory",
                ParentTerritoryId = null,
                ZipCodes = GetListOfValidZipCodes()
            };
            _territoryRepository.SaveTerritory(readingPhysicianTerritory);
        }

        [Test]
        public void SaveTerritorySavesNewAdvertiserTerritory()
        {
            var advertiserTerritory = new AdvertiserTerritory
            {
                Description = "Advertiser Territory integration test desciption",
                Name = "Integration Test for Inserting New Reading Physician Territory",
                ParentTerritoryId = null,
                ZipCodes = GetListOfValidZipCodes(),
            };
            _territoryRepository.SaveTerritory(advertiserTerritory);
        }

        [Test]
        public void SaveTerritorySavesSalesRepTerritory()
        {
            var salesRepTerritory = new SalesRepTerritory
            {
                Description = "Sales Rep Territory test description 233.",
                SalesRepTerritoryAssignments = new List<SalesRepTerritoryAssignment>
                    {new SalesRepTerritoryAssignment {EventTypeSetupPermission = RegistrationMode.Public, SalesRep = new SalesRepresentative()}},
                Name = "Integration Test Saving Sales Rep Territory",
                ParentTerritoryId = VALID_SALES_REP_PARENT_TERRITORY_ID,
                ZipCodes = GetListOfValidZipCodes()
            };
            _territoryRepository.SaveTerritory(salesRepTerritory);
        }

        [Test]
        public void SaveTerritoryUpdatesExistingTerritory()
        {
            Territory territoryFromPersistence = _territoryRepository.GetTerritory(FRANCHISEE_TERRITORY_ID_WITH_ZIPS);
            long expectedTerritoryId = territoryFromPersistence.Id;

            long persistedTerritoryId = _territoryRepository.SaveTerritory(territoryFromPersistence);

            Assert.AreEqual(expectedTerritoryId, persistedTerritoryId,
                "The previously-persisted territory was not updated. A new row was inserted.");
        }

        [Test]
        public void GetAllParentTerritoriesReturnsTerritories()
        {
            List<Territory> territories = _territoryRepository.GetAllParentTerritories();

            Assert.IsNotEmpty(territories, "No territories were returned.");
            Assert.IsEmpty(territories.Where(t => t.ParentTerritoryId != null).ToList(), "Non-parent territories were returned.");
        }

        [Test]
        public void GetTerritoriesForSalesRepReturnsTerritories()
        {
            List<SalesRepTerritory> territories = _territoryRepository.GetTerritoriesForSalesRep(SALES_REP_ID_THAT_OWNS_TERRITORIES);

            Assert.IsNotNull(territories, "Null collection of Territories returned.");
            Assert.IsNotEmpty(territories, "No territories were returned.");
        }

        [Test]
        public void GetTerritoriesForSalesRepReturnsTerritoriesWithAssociatedZips()
        {
            List<SalesRepTerritory> territories = _territoryRepository.GetTerritoriesForSalesRep(SALES_REP_ID_THAT_OWNS_TERRITORIES);

            Assert.IsNotEmpty(territories.First().ZipCodes, "Empty collection of zip codes returned.");
        }
    }
}