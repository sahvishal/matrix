using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Exceptions;
using Falcon.Web.UnitTests.Infrastructure.Application;
using HealthYes.Web.UnitTests.Fakes;
using NUnit.Framework;
using Rhino.Mocks;

namespace Falcon.UnitTests.Infrastructure.Impl
{
    [TestFixture]
    public class RepositoryTester : RepositoryTesterBase
    {
        private IMapper<FakeDomainObject, FakeEntity> _mapper;

        private IRepository<FakeDomainObject> _repository;

        [SetUp]
        protected override void SetUp()
        {
            base.SetUp();
            _mapper = _mocks.StrictMock<IMapper<FakeDomainObject, FakeEntity>>();
            _repository = new FakeRepository(_persistenceLayer, _mapper);
        }

        [TearDown]
        protected override void TearDown()
        {
            base.TearDown();
        }

        [Test]
        [ExpectedException(typeof(DeletionFailureException<FakeDomainObject>))]
        public void FailedDeletionThrowsException()
        {
            DeletionTest(false);
        }

        [Test]
        public void SuccessfulDeletionDoesNotThrowException()
        {
            DeletionTest(true);            
        }

        public void DeletionTest(bool wasDeletionSuccessful)
        {
            var entityToDelete = new FakeEntity();

            var domainObjectToDelete = new FakeDomainObject();

            ExpectGetDataAccessAdapterAndDispose();
            Expect.Call(_mapper.Map(domainObjectToDelete)).Return(entityToDelete);
            ExpectDeleteEntity(wasDeletionSuccessful);

            _mocks.ReplayAll();
            _repository.Delete(domainObjectToDelete);
            _mocks.VerifyAll();
        }
    }
}