using Falcon.App.Core.Application.Attributes;

namespace Falcon.App.Core.Users.ViewModels
{
    [NoValidationRequired]
    public class HospitalFacilityListModelFilter
    {
        public string Name { get; set; }
        public long ParentHospitalPartnerId { get; set; }
    }
}
