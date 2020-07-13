using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.ViewModels;

namespace Falcon.App.Infrastructure.Users.Impl
{
    [DefaultImplementation]
    public class HospitalFacilityListModelFactory : IHospitalFacilityListModelFactory
    {
        public HospitalFacilityListModel Create(IEnumerable<HospitalFacility> hospitalFacilities, OrganizationListModel orgListModel, IEnumerable<OrderedPair<long, string>> contracts,
            IEnumerable<OrderedPair<long, long>> hospitalPartnerIdHospitalFacilityIdPairs)
        {
            var model = new HospitalFacilityListModel();
            var basicModels = new HospitalFacilityViewModel[hospitalFacilities.Count()];
            var index = 0;
            foreach (var hospitalFacility in hospitalFacilities)
            {
                long parentHospitalPartnerId = 0;
                if (hospitalPartnerIdHospitalFacilityIdPairs != null && hospitalPartnerIdHospitalFacilityIdPairs.Any())
                    parentHospitalPartnerId = hospitalPartnerIdHospitalFacilityIdPairs.Where(hphf => hphf.SecondValue == hospitalFacility.Id).Select(hphf => hphf.FirstValue).SingleOrDefault();

                basicModels[index++] = new HospitalFacilityViewModel()
                {
                    Contract = contracts.Where(c => c.FirstValue == hospitalFacility.Id).Select(c => c.SecondValue).FirstOrDefault(),
                    OrganizationBasicInfoModel = orgListModel.Organizations.FirstOrDefault(o => o.Id == hospitalFacility.Id),
                    ParentHospitalPartner = parentHospitalPartnerId > 0 ? orgListModel.Organizations.First(o => o.Id == parentHospitalPartnerId).Name : string.Empty
                };
            }
            model.HospitalFacilities = basicModels;
            return model;
        }
    }
}
