using System;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.ValueTypes;
using Falcon.Web.UnitTests.Infrastructure.Application;
using HealthYes.Web.UnitTests.Fakes;
using NUnit.Framework;
using Rhino.Mocks;

namespace Falcon.Web.UnitTests.Infrastructure.Finance
{
    [TestFixture]
    public class UniqueItemRepositoryTester : RepositoryTesterBase
    {
        private IMapper<FakeDomainObject, FakeEntity> _mockedMapper;
        private IUniqueItemRepository<FakeDomainObject> _uniqueItemRepository;
        private RepositoryStrategySet<FakeDomainObject> _repositoryStrategySet;
        private IPrePersistenceStrategy<FakeDomainObject> _fakePrePersistenceStrategy;

        [SetUp]
        protected override void SetUp()
        {
            base.SetUp();
            _mockedMapper = _mocks.StrictMock<IMapper<FakeDomainObject, FakeEntity>>();
            _fakePrePersistenceStrategy = _mocks.StrictMock<IPrePersistenceStrategy<FakeDomainObject>>();
            _repositoryStrategySet = new RepositoryStrategySet<FakeDomainObject>().
                WithPrePersistenceStrategy(_fakePrePersistenceStrategy);

            _uniqueItemRepository = new FakeUniqueItemRepository(_persistenceLayer, _mockedMapper, _repositoryStrategySet);
        }

        [TearDown]
        protected override void TearDown()
        {
            base.TearDown();
            _uniqueItemRepository = null;
        }

        [Test]
        [ExpectedException(typeof(ObjectNotFoundInPersistenceException<FakeDomainObject>))]
        public void GetByIdThrowsExceptionWhenObjectWithGivenIdNotFoundInPersistence()
        {
            const bool entityFound = false;
            ExpectGetDataAccessAdapterAndDispose();
            ExpectFetchEntityUsingUniqueConstraint(entityFound);

            _mocks.ReplayAll();
            _uniqueItemRepository.GetById(0);
            _mocks.VerifyAll();
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SaveThrowsExceptionWhenGivenNullObject()
        {
            _mocks.ReplayAll();
            _uniqueItemRepository.Save(null);
            _mocks.VerifyAll();
        }

        [Test]
        [ExpectedException(typeof(PersistenceFailureException))]
        public void SaveThrowsExceptionWhenObjectFailsToGetPersisted()
        {
            const bool entitySavedSuccessfully = false;
            const bool refetchAfterSaveParameter = true;
            var fakeDomainObject = new FakeDomainObject();
            ExpectGetDataAccessAdapterAndDispose();
            ExpectSaveEntity(entitySavedSuccessfully, refetchAfterSaveParameter);
            Expect.Call(() => _fakePrePersistenceStrategy.ApplyStrategy(fakeDomainObject));
            Expect.Call(_mockedMapper.Map(fakeDomainObject)).Return(new FakeEntity());

            _mocks.ReplayAll();
            _uniqueItemRepository.Save(fakeDomainObject);
            _mocks.VerifyAll();
        }
    }
}