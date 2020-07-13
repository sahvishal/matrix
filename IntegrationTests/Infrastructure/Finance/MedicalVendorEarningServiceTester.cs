using System;
using Falcon.App.Core.Deprecated;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Impl;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Impl;
using Falcon.App.Infrastructure.Service;
using NUnit.Framework;

namespace Falcon.Web.IntegrationTests.Infrastructure.Finance
{
    [TestFixture]
    [Ignore("The database needs to be in a steady state in order to run this test fixture.")]
    public class MedicalVendorEarningServiceTester
    {
        private const long VALID_CUSTOMER_EVENT_TEST_ID = 680;
        private readonly IMedicalVendorEarningService _medicalVendorEarningService = new MedicalVendorEarningService();

        [Test]
        public void GenerateMedicalVendorEarningGeneratesValidEarningWhenGivenValidId()
        {
            IValidator<MedicalVendorEarning> validator =
                new Validator<MedicalVendorEarning>(new MedicalVendorEarningValidationRuleFactory());

            MedicalVendorEarning medicalVendorEarning = _medicalVendorEarningService.GenerateMedicalVendorEarning
                (0, VALID_CUSTOMER_EVENT_TEST_ID, DateTime.Today, true);

            Assert.IsNotNull(medicalVendorEarning);
            Assert.IsTrue(validator.IsValid(medicalVendorEarning));
        }
    }
}