using Falcon.App.Core.ValueTypes;

namespace Falcon.App.Core.Domain
{
    public class MedicalVendorMedicalVendorUser : DomainObjectBase
    {
        public long MedicalVendorId { get; set; }
        public string MedicalVendorName { get; set; }
        public string RoleName { get; set; }
        public Name Name { get; set; }

        public MedicalVendorMedicalVendorUser()
        {}

        public MedicalVendorMedicalVendorUser(long medicalVendorMedicalVendorUserId)
            : base(medicalVendorMedicalVendorUserId)
        {}
    }
}