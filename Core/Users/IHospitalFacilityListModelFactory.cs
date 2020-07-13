using System.Collections.Generic;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.ViewModels;

namespace Falcon.App.Core.Users
{
    public interface IHospitalFacilityListModelFactory
    {
        HospitalFacilityListModel Create(IEnumerable<HospitalFacility> hospitalFacilities, OrganizationListModel orgListModel, IEnumerable<OrderedPair<long, string>> contracts, 
            IEnumerable<OrderedPair<long, long>> hospitalPartnerIdHospitalFacilityIdPairs);
    }
}
