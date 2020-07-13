using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.Infrastructure.Geo;
using Falcon.App.Infrastructure.Geo.Impl;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.Web.UnitTests.Infrastructure.Application;
using NUnit.Framework;
using Rhino.Mocks;

namespace Falcon.UnitTests.Infrastructure.Geo
{
    [TestFixture]
    public class TerritoryRepositoryTester : RepositoryTesterBase
    {
        private ITerritoryFactory _territoryFactory;
        private ITerritoryRepository _territoryRepository;
        private IOrganizationRoleUserRepository _organizationRoleUserRepository;
        private IHospitalPartnerRepository _hospitalPartnerRepository;
        

        [SetUp]
        protected override void SetUp()
        {
            base.SetUp();
            _territoryFactory = _mocks.StrictMock<ITerritoryFactory>();
            _organizationRoleUserRepository = _mocks.StrictMock<IOrganizationRoleUserRepository>();
            _hospitalPartnerRepository = _mocks.StrictMock<IHospitalPartnerRepository>();
            _territoryRepository = new TerritoryRepository(_persistenceLayer, _territoryFactory, _organizationRoleUserRepository, _hospitalPartnerRepository);
        }

        [TearDown]
        protected override void TearDown()
        {
            base.TearDown();
            _territoryFactory = null;
            _territoryRepository = null;
        }

        [Test]
        [ExpectedException(typeof(ObjectNotFoundInPersistenceException<Territory>))]
        public void GetTerritoryThrowsExceptionWhenTerritoryWithGivenIdNotFound()
        {
            ExpectGetDataAccessAdapterAndDispose();
            ExpectLinqFetchEntityCollection();

            _mocks.ReplayAll();
            _territoryRepository.GetTerritory(0);
            _mocks.VerifyAll();
        }

        [Test]
        [ExpectedException(typeof(DuplicateObjectException<Territory>))]
        public void GetTerritoryThrowsExceptionWhenMoreThanOneTerritoryFoundWithGivenId()
        {
            var returnedEntities = new EntityCollection<TerritoryEntity> { new TerritoryEntity(), new TerritoryEntity() };
            ExpectGetDataAccessAdapterAndDispose();
            ExpectLinqFetchEntityCollection(returnedEntities);

            _mocks.ReplayAll();
            _territoryRepository.GetTerritory(0);
            _mocks.VerifyAll();
        }

        [Test]
        public void GetTerritoryPassesFoundTerritoryToFactory()
        {
            var returnedEntity = new TerritoryEntity();
            var territoryEntities = new EntityCollection<TerritoryEntity> {returnedEntity};
            ExpectGetDataAccessAdapterAndDispose();
            ExpectLinqFetchEntityCollection(territoryEntities);

            Expect.Call(_territoryFactory.CreateTerritory(returnedEntity)).Return(null);

            _mocks.ReplayAll();
            _territoryRepository.GetTerritory(1);
            _mocks.VerifyAll();
        }
    }
}