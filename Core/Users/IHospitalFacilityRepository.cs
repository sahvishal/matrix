using System.Collections.Generic;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.ViewModels;

namespace Falcon.App.Core.Users
{
    public interface IHospitalFacilityRepository
    {
        HospitalFacility GetHospitalFacility(long hospitalFacilityId);
        HospitalFacility Save(HospitalFacility hospitalFacility);
        List<HospitalFacility> GetByFilter(int pageNumber, int pageSize, HospitalFacilityListModelFilter filter, out int totalRecords);
        IEnumerable<HospitalFacility> GetByHospitalPartnerId(long hospitalPartnerId);
        IEnumerable<OrderedPair<long, string>> GetAllForHospitalPartner(long hospitalPartnerId);
        IEnumerable<OrderedPair<long, long>> GetHospitalPartnerIdHositalFacilityIdPair(IEnumerable<long> hospitalFacilityIds);
        IEnumerable<OrderedPair<long, string>> GetByEventId(long eventId);
        long GetHospitalPartnerId(long hospitalFacilityId);
        IEnumerable<long> GetEventIdsForHospitalFacility(long hospitalFacilityId);
        IEnumerable<HospitalFacility> GetByIds(IEnumerable<long> hospitalFacilityIds);
        IEnumerable<long> GetSelectedHospitalFacilityIdForEvent(long eventId);
    }
}
