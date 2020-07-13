using System.Collections.Generic;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Users.ViewModels
{
    public class HospitalFacilityListModel
    {
        public IEnumerable<HospitalFacilityViewModel> HospitalFacilities { get; set; }
        public HospitalFacilityListModelFilter Filter { get; set; }
        [IgnoreAudit]
        public PagingModel PagingModel { get; set; }
    }
}
