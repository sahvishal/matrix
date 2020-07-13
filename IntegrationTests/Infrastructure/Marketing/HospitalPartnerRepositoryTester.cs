using System.Collections.Generic;
using Falcon.App.Core.Domain.MedicalVendors;
using Falcon.App.Core.Interfaces;
using Falcon.App.Infrastructure.Repositories;
using NUnit.Framework;

namespace Falcon.Web.IntegrationTests.Infrastructure.Marketing
{
    [TestFixture]
    [Ignore("The database needs to be in a steady state in order to run this test fixture.")]
    public class HospitalPartnerRepositoryTester
    {
        [Test]
        public void GetAllHospitalPartnersReturnsHospitalPartners()
        {
            IHospitalPartnerRepository hospitalPartnerRepository = new HospitalPartnerRepository();

            var hospitalPartners = hospitalPartnerRepository.GetIdNamePairsforHospitalPartners();

            Assert.IsNotNull(hospitalPartners);
            Assert.IsNotEmpty(hospitalPartners, "No hospital partners were returned from persistence.");
        }
    }
}