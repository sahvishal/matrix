using System;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Infrastructure.Finance.Interfaces;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Web.UnitTests.Infrastructure.Application;
using NUnit.Framework;

namespace Falcon.Web.UnitTests.Infrastructure.Finance
{
    [TestFixture]
    public class MedicalVendorEarningCustomerAggregateRepositoryTester : RepositoryTesterBase
    {
        private IMedicalVendorEarningCustomerAggregateFactory _medicalVendorEarningCustomerAggregateFactory;
        private IMedicalVendorEarningCustomerAggregateRepository _medicalVendorEarningCustomerAggregateRepository;

        [SetUp]
        protected override void SetUp()
        {
            base.SetUp();
            _medicalVendorEarningCustomerAggregateFactory =
                _mocks.StrictMock<IMedicalVendorEarningCustomerAggregateFactory>();
            _medicalVendorEarningCustomerAggregateRepository = new MedicalVendorEarningCustomerAggregateRepository
                (_persistenceLayer, _medicalVendorEarningCustomerAggregateFactory);
        }

        [TearDown]
        protected override void TearDown()
        {
            base.TearDown();
            _medicalVendorEarningCustomerAggregateFactory = null;
            _medicalVendorEarningCustomerAggregateRepository = null;
        }

        [Test]
        public void FetchEarningCustomerAggregatesReturnsNumberOfRecordsFound()
        {
            const int numberOfIterations = 10;
            ExpectGetDataAccessAdapterAndDispose(numberOfIterations);
            
            for (int i = 0; i < numberOfIterations; i++)
            {
                ExpectGetDbCount(i);
            }

            _mocks.ReplayAll();
            for (int i = 0; i < numberOfIterations; i++)
            {
                int numberOfAggregates;
                if (i % 2 == 0)
                {
                    numberOfAggregates = _medicalVendorEarningCustomerAggregateRepository.
                        GetNumberofEarningCustomerAggregates(1, new DateTime(), new DateTime());
                }
                else
                {
                    numberOfAggregates = _medicalVendorEarningCustomerAggregateRepository.
                        GetNumberOfEarningCustomerAggregatesForVendor(1, new DateTime(), new DateTime());
                }
                Assert.IsTrue(numberOfAggregates == i);
            }
            _mocks.VerifyAll();
        }
    }
}