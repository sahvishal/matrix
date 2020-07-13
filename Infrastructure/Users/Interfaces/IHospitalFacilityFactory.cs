using System.Collections.Generic;
using Falcon.App.Core.Users.Domain;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Users.Interfaces
{
    public interface IHospitalFacilityFactory
    {
        List<HospitalFacility> CreateHospitalFacilities(IEnumerable<HospitalFacilityEntity> hospitalFacilityEntities);
        HospitalFacility CreateHospitalFacility(HospitalFacilityEntity hospitalFacilityEntity);
        HospitalFacilityEntity CreateHospitalFacilityEntity(HospitalFacility hospitalFacility);
    }
}
