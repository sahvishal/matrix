using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Finance.Domain
{
    public class MedicalVendorEarning : DomainObjectBase
    {
        public long OrganizationRoleUserId { get; set; }
        public long MedicalVendorUserEventTestLockId { get; set; }
        public decimal MedicalVendorUserAmountEarned { get; set; }
        [IgnoreAudit]
        public DataRecorderMetaData DataRecorderMetaData { get; set; }

        public MedicalVendorEarning()
        {}

        public MedicalVendorEarning(long medicalVendorEarningId)
            : base(medicalVendorEarningId)
        {}
    }
}