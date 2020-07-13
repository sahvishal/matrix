using System.Collections.Generic;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Infrastructure.Repositories;
using NUnit.Framework;

namespace Falcon.Web.IntegrationTests.Infrastructure.Users
{
    [TestFixture]
    [Ignore("The database needs to be in a steady state in order to run this test fixture.")]
    public class MedicalVendorRepositoryTester
    {
        const int VALID_MEDICAL_VENDOR_ID = 1;

        private readonly IMedicalVendorRepository _medicalVendorRepository = new MedicalVendorRepository();

        [Test]
        public void GetMedicalVendorReturnsVendorWhenGivenValidId()
        {
            MedicalVendor medicalVendor = _medicalVendorRepository.GetMedicalVendor(VALID_MEDICAL_VENDOR_ID);

            Assert.IsNotNull(medicalVendor);
        }

        [Test]
        public void GetMedicalVendorsReturnsListOfMedicalVendors()
        {
            List<MedicalVendor> medicalVendors = _medicalVendorRepository.GetMedicalVendors();

            Assert.IsNotNull(medicalVendors);
            Assert.IsNotEmpty(medicalVendors);
        }

        [Test]
        public void GetMedicalVendorsDoesNotReturnInactiveUsers()
        {
            Assert.Fail("The database needs to be in a steady state before this test can be written.");
            //List<MedicalVendor> medicalVendors = _medicalVendorRepository.GetMedicalVendors();
            // Insert five rows, three of which are active.
            // Assert that three are returned.
            //Assert.IsEmpty(medicalVendors.Where());
        }
    }
}