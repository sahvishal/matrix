using Falcon.App.Core.Enum;

namespace Falcon.App.Core.Users.ViewModels
{
    public class MedicalVendorModel
    {
        public OrganizationBasicInfoModel OrganizationBasicInfoModel { get; set; }
        public MedicalVendorType MedicalVendorType { get; set; }
        public string Contract { get; set; }
    }
}