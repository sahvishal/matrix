using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Infrastructure.Geo;
using Falcon.Data.EntityClasses;
using Falcon.App.Core;
using Falcon.App.Core.Enum;
using Falcon.App.Infrastructure.Factories;
using NUnit.Framework;

namespace Falcon.Web.UnitTests.Infrastructure.Factories
{
    [TestFixture]
    public class TerritoryFactoryTester
    {
        private readonly ITerritoryFactory _territoryFactory = new TerritoryFactory();

        [Test]
        public void CreateTerritoryEntitySetsIsActiveToTrue()
        {
            var territory = new FranchiseeTerritory();

            TerritoryEntity territoryEntity = _territoryFactory.CreateTerritoryEntity(territory,
                DateTime.Now, DateTime.Now);

            Assert.IsTrue(territoryEntity.IsActive, "TerritoryEntity IsActive not set to true.");
        }

        [Test]
        public void CreateTerritoryEntitySetsDateCreatedToGivenDateCreated()
        {
            var expectedDateCreated = new DateTime(2003, 2, 3);
            var territory = new FranchiseeTerritory();

            TerritoryEntity territoryEntity = _territoryFactory.CreateTerritoryEntity(territory, expectedDateCreated, DateTime.Now);

            Assert.AreEqual(expectedDateCreated, territoryEntity.DateCreated, 
                "DateCreated was not set on the entity correctly.");
        }

        [Test]
        public void CreateTerritoryEntitySetsDateModifiedToGivenDateModified()
        {
            var expectedDateModified = new DateTime(2003, 2, 3);
            var territory = new FranchiseeTerritory();

            TerritoryEntity territoryEntity = _territoryFactory.CreateTerritoryEntity
                (territory, DateTime.Now, expectedDateModified);

            Assert.AreEqual(expectedDateModified, territoryEntity.DateModified, 
                "DateModified was not set on the entity correctly.");
        }
       
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateTerritoryEntityThrowsExceptionIfNullTerritoryGiven()
        {
            _territoryFactory.CreateTerritoryEntity(null, DateTime.Now, DateTime.Now);
        }

        [Test]
        public void CreateTerritoryCreatesFranchiseeTerritoryWhenEntityTypeIsFranchiseeTerritory()
        {
            var territoryEntity = new TerritoryEntity {Type = (byte)TerritoryType.Franchisee};

            Territory territory = _territoryFactory.CreateTerritory(territoryEntity);

            Assert.IsInstanceOf<FranchiseeTerritory>(territory);
        }

        [Test]
        public void CreateTerritoryCreatesHospitalPartnerTerritoryWhenEntityIsHospitalPartner()
        {
            var territoryEntity = new TerritoryEntity 
                { Type = (byte)TerritoryType.HospitalPartner };

            Territory territory = _territoryFactory.CreateTerritory(territoryEntity);

            Assert.IsInstanceOf<HospitalPartnerTerritory>(territory);
        }

        [Test]
        public void CreateTerritoryCreatesReadingPhysicianTerritoryWhenEntityIsReadingPhysician()
        {
            var territoryEntity = new TerritoryEntity 
                {Type = (byte) TerritoryType.ReadingPhysician};

            Territory territory = _territoryFactory.CreateTerritory(territoryEntity);

            Assert.IsInstanceOf<ReadingPhysicianTerritory>(territory, 
                "Incorrect type of Territory created.");
        }

        [Test]
        public void CreateTerritoryCreatesAdvertiserTerritoryWhenEntityIsAdvertiser()
        {
            var territoryEntity = new TerritoryEntity {Type = (byte) TerritoryType.Advertiser};

            Territory territory = _territoryFactory.CreateTerritory(territoryEntity);

            Assert.IsInstanceOf<AdvertiserTerritory>(territory, 
                "Incorrect type of Territory created.");
        }

        [Test]
        [ExpectedException(typeof(NotSupportedException))]
        public void CreateTerritoryThrowsExceptionWhenEntitySetToUnsupportedTerritoryType()
        {
            _territoryFactory.CreateTerritory(new TerritoryEntity {Type = 93});
        }

        [Test]
        public void CreateSalesRepTerritorySetsSalesRepTerritoryAssignemntsToEmptyWhenEntityHasNoOwners()
        {
            var territoryEntity = new TerritoryEntity {Type = (byte)TerritoryType.SalesRep};

            SalesRepTerritory territory = _territoryFactory.CreateSalesRepTerritory(territoryEntity,
                new List<OrderedPair<OrganizationRoleUser, RegistrationMode>>(),
                new List<OrderedPair<long, long>>());

            Assert.IsNotNull(territory.SalesRepTerritoryAssignments,
                "Null list of Sales Rep Owner IDs returned.");
            Assert.IsEmpty(territory.SalesRepTerritoryAssignments,
                "Incorrect Sales Rep Owner ID list returned.");
        }

        [Test]
        public void CreateSalesRepTerritoryMapsOrganizationRoleUsersToSalesRepTerritoryAssignments()
        {
            var owningUsersAndEventTypes = new List<OrderedPair<OrganizationRoleUser, RegistrationMode>>
            {
                //TODO: SRE ... NEEd to check these
                new OrderedPair<OrganizationRoleUser, RegistrationMode>(
                    new OrganizationRoleUser
                        {OrganizationId = 1, UserId = 2, RoleId = (long) Roles.SalesRep},
                    RegistrationMode.Public),
                new OrderedPair<OrganizationRoleUser, RegistrationMode>(
                    new OrganizationRoleUser
                        {OrganizationId = 3, UserId = 4, RoleId = (long) Roles.SalesRep},
                    RegistrationMode.Private)
            };

            var userSalesRepIds = new List<OrderedPair<long, long>>
                {new OrderedPair<long, long>(2, 7), new OrderedPair<long, long>(4, 8)};
            var expectedsalesRepIds = userSalesRepIds.Select(usr => usr.SecondValue);
            var expectedUserIds = owningUsersAndEventTypes.Select(ouet => ouet.FirstValue.UserId);

            SalesRepTerritory salesRepTerritory = _territoryFactory.
                CreateSalesRepTerritory(new TerritoryEntity(), owningUsersAndEventTypes,
                userSalesRepIds);

            Assert.IsTrue(salesRepTerritory.SalesRepTerritoryAssignments.
                Where(srta => expectedsalesRepIds.Contains
                    (srta.SalesRep.SalesRepresentativeId)).Count() == 2, 
                "Owning Sales Representatives' Sales Rep IDs mapped incorrectly.");
            Assert.IsTrue(salesRepTerritory.SalesRepTerritoryAssignments.
                Where(osr => expectedUserIds.Contains
                    (osr.SalesRep.Id)).Count() == 2, 
                "Owning Sales Representatives' User IDs mapped incorrectly.");
        }

        [Test]
        public void CreateSalesRepTerritoryMapsEventTypeSetupPermissionsToTerritoryAssignments()
        {
            var owningUsersAndEventTypes = new List<OrderedPair<OrganizationRoleUser, RegistrationMode>>
            {
                new OrderedPair<OrganizationRoleUser, RegistrationMode>(
                    new OrganizationRoleUser(2, (long) Roles.SalesRep, 3),
                    RegistrationMode.Public),
            };
            var userSalesRepIds = new List<OrderedPair<long, long>>
                {new OrderedPair<long, long>(2, 7)};
            RegistrationMode expectedEventType = owningUsersAndEventTypes.Single().SecondValue;

            SalesRepTerritory salesRepTerritory = _territoryFactory.CreateSalesRepTerritory
                (new TerritoryEntity(), owningUsersAndEventTypes, userSalesRepIds);

            Assert.AreEqual(expectedEventType, 
                salesRepTerritory.SalesRepTerritoryAssignments.Single().EventTypeSetupPermission,
                "Sales Rep Territory Event Type Setup Permission was mapped incorrectly.");
        }

        [Test]
        public void CreateSalesRepTerritorySetsTerritoryIdToEntityTerritoryIdForSalesRepTerritory()
        {
            const long expectedTerritoryId = 555;
            var territoryEntity = new TerritoryEntity(expectedTerritoryId) 
                {Type = (byte)TerritoryType.SalesRep};

            Territory territory = _territoryFactory.CreateSalesRepTerritory(territoryEntity,
                new List<OrderedPair<OrganizationRoleUser, RegistrationMode>>(),
                new List<OrderedPair<long, long>>());

            Assert.AreEqual(expectedTerritoryId, territory.Id, 
                "Sales Rep Territory ID did not get set correctly.");
        }

        [Test]
        public void CreateTerritoriesReturnsEmptyListWhenEmptyEnumerableGiven()
        {
            var territoryEntities = new List<TerritoryEntity>();

            List<Territory> territories = _territoryFactory.CreateTerritories(territoryEntities);

            Assert.IsNotNull(territories, "Null list of Territories returned.");
            Assert.IsEmpty(territories, "Incorrect list of Territories returned.");
        }

        [Test]
        public void CreateTerritoriesReturnsListWith1TerritoryWhen1TerritoryEntityGiven()
        {
            var territoryEntities = new List<TerritoryEntity> {new TerritoryEntity()};

            List<Territory> territories = _territoryFactory.CreateTerritories(territoryEntities);

            Assert.AreEqual(territoryEntities.Count, territories.Count, 
                "Incorrect number of territories returned.");
        }

        [Test]
        public void CreateTerritoriesReturnsListWith3TerritoriesWhen3TerritoryEntitiesGiven()
        {
            var territoryEntities = new List<TerritoryEntity>
                { new TerritoryEntity(), new TerritoryEntity(), new TerritoryEntity() };

            List<Territory> territories = _territoryFactory.CreateTerritories(territoryEntities);

            Assert.AreEqual(territoryEntities.Count, territories.Count, 
                "Incorrect number of territories returned.");
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateTerritoriesThrowsExceptionWhenNullEnumerableGiven()
        {
            _territoryFactory.CreateTerritories(null);
        }
    }
}