using Falcon.App.Core.Application.Attributes;
using System;

namespace Falcon.App.Core.Medicare.ViewModels
{
    [NoValidationRequired]
    public class MedicationEditModel
    {
        public long Id { get; set; }
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

        public bool IsEdited { get; set; }
    }
}
