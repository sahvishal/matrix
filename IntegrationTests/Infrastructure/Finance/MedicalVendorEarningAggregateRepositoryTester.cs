using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Infrastructure.Repositories;
using NUnit.Framework;

namespace Falcon.Web.IntegrationTests.Infrastructure.Finance
{
    [TestFixture]
    [Ignore("The database needs to be in a steady state in order to run this test fixture.")]
    public class MedicalVendorEarningAggregateRepositoryTester
    {
        const int VALID_CUSTOMER_EVENT_TEST_ID = 680;
        private readonly IMedicalVendorEarningAggregateRepository _medicalVendorEarningAggregateRepository =
            new MedicalVendorEarningAggregateRepository();

        [Test]
        public void GetMedicalVendorEarningAggregateReturnsAggregateWhenGivenValidId()
        {
            MedicalVendorEarningAggregate medicalVendorEarningAggregate = _medicalVendorEarningAggregateRepository.
                GetMedicalVendorEarningAggregate(609, VALID_CUSTOMER_EVENT_TEST_ID, false);

            Assert.IsNotNull(medicalVendorEarningAggregate);
        }
    }
}