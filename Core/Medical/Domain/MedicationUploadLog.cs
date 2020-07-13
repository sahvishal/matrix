using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Medical.Domain
{
    public class MedicationUploadLog : DomainObjectBase
    {
        public long MedicationUploadId { get; set; }

        public string ServiceDate { get; set; }
        public string CmsHicn { get; set; }
        public string MemberId { get; set; }
        public string MemberDob { get; set; }
        public string NdcProductCode { get; set; }

        public bool IsSuccessFull { get; set; }
        public string ErrorMessage { get; set; }
    }
}
