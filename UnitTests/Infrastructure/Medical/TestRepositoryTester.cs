using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Web.UnitTests.Infrastructure.Application;
using NUnit.Framework;
using Rhino.Mocks;

namespace Falcon.UnitTests.Infrastructure.Medical
{
    [TestFixture]
    [Ignore("Need access to protected member")]
    public class TestRepositoryTester : RepositoryTesterBase
    {
        private ITestRepository _testRepository;
        private IMapper<Test, TestEntity> _mockedMapper;
        private IUniqueItemRepository<Test> _uniqueItemRepository;

        [SetUp]
        protected override void SetUp()
        {
            base.SetUp();
            _mockedMapper = _mocks.StrictMock<IMapper<Test, TestEntity>>();
            _testRepository = new TestRepository(_mockedMapper);
            _uniqueItemRepository = new TestRepository(_mockedMapper);
        }

        [TearDown]
        protected override void TearDown()
        {
            base.TearDown();
            _testRepository = null;
        }

        [Test]
        [ExpectedException(typeof(ObjectNotFoundInPersistenceException<Test>))]
        public void GetThrowsExceptionWhenTestWithInvalidIdNotFound()
        {
            ExpectGetDataAccessAdapterAndDispose();
            ExpectFetchEntity(false);

            _mocks.ReplayAll();
            _uniqueItemRepository.GetById(0);
            _mocks.VerifyAll();
        }

        [Test]
        public void GetPassesTestToFactoryWhenActiveTestFound()
        {
            ExpectGetDataAccessAdapterAndDispose();
            ExpectFetchEntity(true, new TestEntity { IsActive = true });
            Expect.Call(_mockedMapper.Map((TestEntity)null)).IgnoreArguments().Return(new Test());

            _mocks.ReplayAll();
            _uniqueItemRepository.GetById(1);
            _mocks.VerifyAll();
        }
    }
}