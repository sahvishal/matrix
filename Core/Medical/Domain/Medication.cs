using System;
using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Medical.Domain
{
    public class Medication : DomainObjectBase
    {
        public long CustomerId { get; set; }
        public DateTime ServiceDate { get; set; }
        public string Hicn { get; set; }
        public string MemberId { get; set; }
        public DateTime? MemberDob { get; set; }

        public string NdcProductCode { get; set; }

        public string ProprietaryName { get; set; }
        public string Dose { get; set; }
        public string Unit { get; set; }
        public string Frequency { get; set; }
        public bool? IsPrescribed { get; set; }
        public bool? IsOtc { get; set; }
        public string Indication { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public long CreatedBy { get; set; }
        public long? ModifiedBy { get; set; }

        public bool IsActive { get; set; }
        public bool IsManual { get; set; }
        public bool IsSynced { get; set; }
    }
}
