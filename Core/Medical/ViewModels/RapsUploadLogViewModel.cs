using System;
using System.ComponentModel;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class RapsUploadLogViewModel : ViewModelBase
    {
        [DisplayName("HICN")]
        public string CmsHicn { get; set; }
        [DisplayName("MEMBERDOB")]
        [Format("yyyyMMdd")]
        public DateTime? MemberDob { get; set; }

        [DisplayName("FIRST_NAME")]
        public string FirstName { get; set; }

        [DisplayName("LAST_NAME")]
        public string SecondName { get; set; }
        [DisplayName("ICD_VERSION")]
        public int IcdVersion { get; set; }

        [Format("yyyyMMdd")]
        [DisplayName("SERVICE_DATE")]
        public DateTime? ServiceDate { get; set; }
        [DisplayName("ICD")]
        public string IcdCode { get; set; } 
        public string ErrorMessage { get; set; } 
    }
}
