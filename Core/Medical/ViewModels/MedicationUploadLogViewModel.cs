using System.ComponentModel;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Medical.ViewModels
{
    [NoValidationRequired]
    public class MedicationUploadLogViewModel : ViewModelBase
    {
        //[Format("MM/dd/yyyy")]
        [DisplayName("Date of Service")]
        public string ServiceDate { get; set; }

        [DisplayName("HICN")]
        public string Hicn { get; set; }

        //[Format("MM/dd/yyyy")]
        [DisplayName("Date of Birth")]
        public string MemberDob { get; set; }

        [DisplayName("Member ID")]
        public string MemberId { get; set; }

        [DisplayName("NDC_TXT")]
        public string NdcProductCode { get; set; }

        [DisplayName("Error Message")]
        public string ErrorMessage { get; set; }
    }
}
