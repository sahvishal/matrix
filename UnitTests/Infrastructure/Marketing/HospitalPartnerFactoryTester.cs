using Falcon.App.Core.Application;
using Falcon.App.Core.Domain.MedicalVendors;
using Falcon.App.Infrastructure.Mappers;
using Falcon.Data.EntityClasses;
using NUnit.Framework;

namespace Falcon.UnitTests.Infrastructure.Marketing
{
    [TestFixture]
    [Ignore("New user system changed, please fix these.")]
    public class HospitalPartnerFactoryTester
    {
        private readonly IMapper<HospitalPartner, HospitalPartnerEntity> _mapper = 
            new HospitalPartnerMapper();

        private static HospitalPartnerEntity GetValidHospitalPartnerEntity(long hospitalPartnerId, 
            string medicalVendorBusinessName)
        {
            //var medicalVendorEntity = new MedicalVendorEntity(hospitalPartnerId) 
            //    {BusinessName = medicalVendorBusinessName};
            ////Commented By Bidhan
            ////return new HospitalPartnerEntity {MedicalVendor = medicalVendorEntity};
            return null;
        }

        [Test]
        public void MapMapsEntityIdToHospitalPartnerId()
        {
            //Commented By Bidhan
            //const long expectedId = 456;
            //var hospitalPartnerEntity = new HospitalPartnerEntity(expectedId) 
            //    {MedicalVendor = new MedicalVendorEntity()};

            //HospitalPartner hospitalPartner = _mapper.Map(hospitalPartnerEntity);

            //Assert.AreEqual(expectedId, hospitalPartner.Id, 
            //    "Hospital Partner ID was not mapped correctly.");
        }

        [Test]
        public void MapMapsEntityNameToAssociatedMedicalVendorBusinessName()
        {
            const string expectedName = "Hospital Partner Name";
            var hospitalPartnerEntity = GetValidHospitalPartnerEntity(0, expectedName);

            HospitalPartner hospitalPartner = _mapper.Map(hospitalPartnerEntity);

            Assert.AreEqual(expectedName, hospitalPartner.Name, 
                "Hospital Partner name was not mapped correctly.");
        }
    }
}