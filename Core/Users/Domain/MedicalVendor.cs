using Falcon.App.Core.Enum;

namespace Falcon.App.Core.Users.Domain
{
    public class MedicalVendor : Organization
    {
        public MedicalVendorType MedicalVendorType { get; set; }
        public long ContractId { get; set; }
        public bool IsHospitalPartner { get; set; }
        public long? ResultLetterCoBrandingFileId { get; set; }
        public long? DoctorLetterFileId { get; set; }
           
        
        public MedicalVendor()
        {}

        public MedicalVendor(Organization organization)
            :base(organization)
        {}

        public MedicalVendor(long medicalVendorId)
            : base(medicalVendorId)
        {}
    }
}