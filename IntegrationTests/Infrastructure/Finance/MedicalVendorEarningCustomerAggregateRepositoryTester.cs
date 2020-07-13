using System;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Infrastructure.Repositories;
using NUnit.Framework;

namespace Falcon.Web.IntegrationTests.Infrastructure.Finance
{
    [TestFixture]
    [Ignore("The database needs to be in a steady state in order to run this test fixture.")]
    public class MedicalVendorEarningCustomerAggregateRepositoryTester
    {
        private readonly IMedicalVendorEarningCustomerAggregateRepository
            _medicalVendorEarningCustomerAggregateRepository = new MedicalVendorEarningCustomerAggregateRepository();
        private const long VALID_ORGANIZATION_ROLE_USER_ID = 610;

        [Test]
        public void GetEarningCustomerAggregatesDoesNotBomb()
        {
            _medicalVendorEarningCustomerAggregateRepository.GetEarningCustomerAggregates(VALID_ORGANIZATION_ROLE_USER_ID,
                new DateTime(2000, 1, 1), DateTime.Today, 2, 26);
        }

        [Test]
        public void GetNumberOfEarningCustomerAggregatesReturnsPositiveNumberForValidId()
        {
            int numberOfEarningCustomerAggregates = _medicalVendorEarningCustomerAggregateRepository.GetNumberofEarningCustomerAggregates
                (VALID_ORGANIZATION_ROLE_USER_ID, new DateTime(2000, 1, 1), DateTime.Today);

            Assert.IsTrue(numberOfEarningCustomerAggregates > 0);
        }
    }
}