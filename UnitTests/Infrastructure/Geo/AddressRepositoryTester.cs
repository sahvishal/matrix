using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Infrastructure.Geo;
using Falcon.App.Infrastructure.Geo.Impl;
using Falcon.Web.UnitTests.Infrastructure.Application;
using NUnit.Framework;

namespace Falcon.UnitTests.Infrastructure.Geo
{
    [TestFixture]
    public class AddressRepositoryTester : RepositoryTesterBase
    {
        private IAddressFactory _addressFactory;
        private IAddressRepository _addressRepository;

        [SetUp]
        protected override void SetUp()
        {
            base.SetUp();
            _addressFactory = _mocks.StrictMock<IAddressFactory>();
            _addressRepository = new AddressRepository(_persistenceLayer, _addressFactory);
        }

        [TearDown]
        protected override void TearDown()
        {
            base.TearDown();
            _addressFactory = null;
            _addressRepository = null;
        }

        [Test]
        [ExpectedException(typeof(ObjectNotFoundInPersistenceException<Address>))]
        public void GetAddressThrowsExceptionWhenAddressWithGivenIdNotFound()
        {
            ExpectGetDataAccessAdapterAndDispose();
            ExpectFetchTypedView();

            _mocks.ReplayAll();
            _addressRepository.GetAddress(0);
            _mocks.VerifyAll();
        }
    }
}