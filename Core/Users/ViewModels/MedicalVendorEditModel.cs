using System.ComponentModel;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Users.ViewModels
{
    public class MedicalVendorEditModel : ViewModelBase
    {
        public OrganizationEditModel OrganizationEditModel { get; set; }

        [DisplayName("Medical Vendor Type")]
        public long MedicalVendorType { get; set; }

        [DisplayName("Contract")]
        public long ContractId { get; set; }

        public bool IsHospitalPartner { get; set; }

        public HospitalPartnerEditModel HospitalPartnerEditModel { get; set; }

        public File ResultLetterCoBrandingFile { get; set; }

        public File DoctorLetterFile { get; set; }

        public MedicalVendorEditModel()
        {
            OrganizationEditModel = new OrganizationEditModel();
            HospitalPartnerEditModel = new HospitalPartnerEditModel();
        }

    }
}